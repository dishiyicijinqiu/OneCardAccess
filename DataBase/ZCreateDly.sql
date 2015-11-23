IF EXISTS ( SELECT  1
            FROM    sys.sysobjects
            WHERE   id = OBJECT_ID('P_ZCreatePDly')
                    AND type IN ( 'P', 'PC' ) ) 
    DROP PROCEDURE dbo.P_ZCreatePDly
go
CREATE PROCEDURE P_ZCreatePDly
    (
      @DlyNdxId VARCHAR(36) OUTPUT ,--单据索引表Id
      @UserId VARCHAR(36) , --用户Id
      @ProductIdError INT OUTPUT ,--错误的产品Id
      @CompanyIdError INT OUTPUT ,--错误的往来单位Id
      @StockId1Error INT OUTPUT ,--错误的仓库1Id
      @StockId2Error INT OUTPUT ,--错误的仓库2Id
      @ATypeIdError INT OUTPUT,--错误的科目Id
      @BNError VARCHAR(10) OUTPUT--错误的批号
    )
AS 
    DECLARE @errmsg VARCHAR(200) ,
        @execsql VARCHAR(500),@dTemp NUMERIC(18,4),@nRet smallint
------------------------------------------------科目Id------------------------------------------------
    DECLARE @SPYHAtypeId INT,--商品优惠Id
    @KCSPAtypeId INT--库存商品科目Id
    SELECT @SPYHAtypeId= 4153,@KCSPAtypeId=1101
------------------------------------------------科目Id------------------------------------------------
------------------------------------------------单据索引------------------------------------------------
    DECLARE @DlyNo VARCHAR(30) ,--单据编号
        @DlyTypeId INT ,--单据类型
        @DlyDate VARCHAR(10) ,--单据日期
        @CompanyId INT ,--往来单位Id
        @JSRId VARCHAR(36) ,--经手人Id
        @StockId1 INT ,--仓库1Id
        @StockId2 INT ,--仓库2Id
        @Draft SMALLINT ,--单据标识(是否过账0为草稿，1为过账,2被红冲标记，3红冲标记,4临时单据)
        @ZDRId VARCHAR(36) ,--制单人Id
        @SHRId1 VARCHAR(36) ,--审核人1Id
        @SHRId2 VARCHAR(36) ,--审核人2Id
        @SHRId3 VARCHAR(36) ,--审核人3Id
        @SHRId4 VARCHAR(36) ,--审核人4Id
        @SHRId5 VARCHAR(36)--审核人5Id
    SELECT  @DlyNo = T_DlyNdx.DlyNo ,
            @DlyTypeId = T_DlyNdx.DlyTypeId ,
            @DlyDate = T_DlyNdx.DlyDate ,
            @CompanyId = T_DlyNdx.CompanyId ,
            @JSRId = T_DlyNdx.JSRId ,
            @StockId1 = T_DlyNdx.StockId1 ,
            @StockId2 = T_DlyNdx.StockId2 ,
            @Draft = T_DlyNdx.Draft ,
            @ZDRId = T_DlyNdx.ZDRId ,
            @SHRId1 = T_DlyNdx.SHRId1 ,
            @SHRId2 = T_DlyNdx.SHRId2 ,
            @SHRId3 = T_DlyNdx.SHRId3 ,
            @SHRId4 = T_DlyNdx.SHRId4 ,
            @SHRId5 = T_DlyNdx.SHRId5
    FROM    dbo.T_DlyNdx
    WHERE   T_DlyNdx.DlyNdxId = @DlyNdxId
    BEGIN
        SELECT  @errmsg = dbo.F_GetError('单据不存在', 0)
        RAISERROR(@errmsg,11,1)
        RETURN
    END
------------------------------------------------单据索引------------------------------------------------

------------------------------------------------审核检查------------------------------------------------
    DECLARE @InputLevel SMALLINT
    SELECT  @InputLevel = T_DlyType.InputLevel
    FROM    dbo.T_DlyType
    WHERE   T_DlyType.DlyTypeId = @DlyTypeId
    IF ( @InputLevel = 1 ) 
        BEGIN
            IF ( @SHRId1 IS NULL
                 OR LEN(@SHRId1) <> 36
               ) 
                BEGIN
                    SELECT  @errmsg = dbo.F_GetError('审核流程未完成', 0)
                    RAISERROR(@errmsg,11,1)
                    RETURN
                END
        END
    ELSE 
        IF ( @InputLevel = 2 ) 
            BEGIN
                IF ( @SHRId2 IS NULL
                     OR LEN(@SHRId2) <> 36
                   ) 
                    BEGIN
                        SELECT  @errmsg = dbo.F_GetError('审核流程未完成', 0)
                        RAISERROR(@errmsg,11,1)
                        RETURN
                    END
            END
        ELSE 
            IF ( @InputLevel = 3 ) 
                BEGIN
                    IF ( @SHRId3 IS NULL
                         OR LEN(@SHRId3) <> 36
                       ) 
                        BEGIN
                            SELECT  @errmsg = dbo.F_GetError('审核流程未完成', 0)
                            RAISERROR(@errmsg,11,1)
                            RETURN
                        END
                END
            ELSE 
                IF ( @InputLevel = 4 ) 
                    BEGIN
                        IF ( @SHRId4 IS NULL
                             OR LEN(@SHRId4) <> 36
                           ) 
                            BEGIN
                                SELECT  @errmsg = dbo.F_GetError('审核流程未完成', 0)
                                RAISERROR(@errmsg,11,1)
                                RETURN
                            END
                    END
                ELSE 
                    IF ( @InputLevel = 5 ) 
                        BEGIN
                            IF ( @SHRId5 IS NULL
                                 OR LEN(@SHRId5) <> 36
                               ) 
                                BEGIN
                                    SELECT  @errmsg = dbo.F_GetError('审核流程未完成',
                                                              0)
                                    RAISERROR(@errmsg,11,1)
                                    RETURN
                                END
                        END
    IF ( @InputLevel = 1 ) 
        BEGIN
            IF ( @SHRId1 <> @UserId ) 
                BEGIN
                    SELECT  @errmsg = dbo.F_GetError('您不是最终审核人不可过账', 0)
                    RAISERROR(@errmsg,11,1)
                    RETURN
                END
        END
    ELSE 
        IF ( @InputLevel = 2 ) 
            BEGIN
                IF ( @SHRId2 <> @UserId ) 
                    BEGIN
                        SELECT  @errmsg = dbo.F_GetError('您不是最终审核人不可过账', 0)
                        RAISERROR(@errmsg,11,1)
                        RETURN
                    END
            END
        ELSE 
            IF ( @InputLevel = 3 ) 
                BEGIN
                    IF ( @SHRId3 <> @UserId ) 
                        BEGIN
                            SELECT  @errmsg = dbo.F_GetError('您不是最终审核人不可过账', 0)
                            RAISERROR(@errmsg,11,1)
                            RETURN
                        END
                END
            ELSE 
                IF ( @InputLevel = 4 ) 
                    BEGIN
                        IF ( @SHRId4 <> @UserId ) 
                            BEGIN
                                SELECT  @errmsg = dbo.F_GetError('您不是最终审核人不可过账',
                                                              0)
                                RAISERROR(@errmsg,11,1)
                                RETURN
                            END
                    END
                ELSE 
                    IF ( @InputLevel = 5 ) 
                        BEGIN
                            IF ( @SHRId5 <> @UserId ) 
                                BEGIN
                                    SELECT  @errmsg = dbo.F_GetError('您不是最终审核人不可过账',
                                                              0)
                                    RAISERROR(@errmsg,11,1)
                                    RETURN
                                END
                        END
                    ELSE 
                        BEGIN
                            SELECT  @errmsg = dbo.F_GetError('单据审核权限未设置', 0)
                            RAISERROR(@errmsg,11,1)
                            RETURN
                        END
------------------------------------------------审核检查------------------------------------------------

------------------------------------------------删除检查------------------------------------------------
    IF EXISTS ( SELECT  1
                FROM    dbo.T_Employee
                WHERE   T_Employee.EmpId = @JSRId
                        AND T_Employee.deleted = 1 ) 
        GOTO error
    IF EXISTS ( SELECT  1
                FROM    dbo.T_Company
                WHERE   T_Company.CompanyId = @CompanyId
                        AND ( T_Company.deleted = 1
                              OR T_Company.Level_Num > 0
                            ) ) 
        GOTO error
    IF EXISTS ( SELECT  1
                FROM    dbo.T_Stock
                WHERE   T_Stock.StockId = @StockId1
                        AND T_Stock.deleted = 1 ) 
        GOTO error 
    IF EXISTS ( SELECT  1
                FROM    dbo.T_Stock
                WHERE   T_Stock.StockId = @StockId2
                        AND T_Stock.deleted = 1 ) 
        GOTO error1
------------------------------------------------删除检查------------------------------------------------
------------------------------------------------单据详细------------------------------------------------
    DECLARE @ATypeId INT ,--科目Id
        @ProductId INT ,--产品Id
        @BN VARCHAR(10) ,--批号
        @Qty NUMERIC(18, 4) ,--数量
        @Price FLOAT ,--单价
        @Total NUMERIC(18, 4) ,--总价
        @Remark VARCHAR(50) ,--备注
        @SortNo INT,
        @PDlyId VARCHAR(36),--单据明细Id
        @CostPrice FLOAT,--成本单价
        @CostTotal NUMERIC(18, 4),--成本金额
        @PDlyBakId VARCHAR(36)--备份单据Id
------------------------------------------------单据详细------------------------------------------------
------------------------------------------------商品信息------------------------------------------------
    DECLARE @deleted BIT ,--删除标识
        @QtyMode SMALLINT ,
        @Level_Num INT
------------------------------------------------商品信息------------------------------------------------
------------------------------------------------单据变量（金额，数量，单价）------------------------------------------------
    DECLARE @HJMoney NUMERIC(18, 4) ,--合计应收应付金额
        @HJQty NUMERIC(18, 4),--合计数量
        @HJPrefer NUMERIC(18,4),--合计优惠
        @HJKCMoney NUMERIC(18,4)--合计库存金额
------------------------------------------------单据变量（金额，数量，单价）------------------------------------------------
------------------------------------------------商品入库单------------------------------------------------
    IF @DlyTypeId = 2 
        BEGIN
            SELECT  @execsql = 'declare CreateDly_cursor cursor for'
                    + 'select ATypeId,ProductId,BN,Qty,Price,Total,Remark,SortNo from T_PDlyBak where DlyNdxId='''
                    + @DlyNdxId + ''''
            EXEC(@execsql)
            SELECT  @HJMoney = 0 ,
                    @HJQty = 0--初始化
            OPEN CreateDly_cursor
            FETCH NEXT FROM CreateDly_cursor INTO @ATypeId, @ProductId, @BN,
                @Qty, @Price, @Total, @Remark, @SortNo,@PDlyBakId
            WHILE @@FETCH_STATUS = 0 
                BEGIN
                    IF @ProductId IS NOT NULL
                        AND @ProductId <> 0 
                        BEGIN
                            SELECT  @deleted = T_Product.Deleted ,
                                    @QtyMode = T_Product.QtyMode ,
                                    @Level_Num = T_Product.Level_Num
                            FROM    dbo.T_Product
                            WHERE   T_Product.ProductId = @ProductId
                            IF @deleted = 1
                                OR @Level_Num > 0 
                                GOTO error2
                            --------------------------更新库存--------------------------
                            Exec @nRet = dbo.P_AtypeModify @DlyTypeId = 0, -- int
                                @DlyNdxId = @DlyNdxId, -- varchar(36)
                                @DlyDate = @DlyDate, -- varchar(10)
                                @ATypeId = @KCSPAtypeId, -- int
                                @ProductId = @ProductId, -- int
                                @CompanyId = @CompanyId, -- int
                                @JSRId = @JSRId, -- varchar(36)
                                @StockId = @StockId1, -- int
                                @Qty = @Qty, -- numeric
                                @Total = @Total, -- numeric
                                @BN = @BN, -- varchar(10)
                                @CostTotal = @dTemp OUTPUT, -- numeric
                                @QtyMode = @QtyMode, -- smallint
                                @OldPDlyId = @PDlyBakId -- varchar(36)
                            if @nRet<0 goto error
                            --------------------------更新库存--------------------------
                            SELECT  @HJQty = @HJQty + @Qty,
                                    @HJKCMoney=@HJKCMoney+@Total,
                                    @CostPrice=@dTemp/@Qty,
                                    @CostTotal=@dTemp,
                                    @PDlyId=NEWID()
                            INSERT  INTO dbo.T_PDly
                                    ( PDlyId ,
                                      DlyNdxId ,
                                      ATypeId ,
                                      CompanyId ,
                                      DlyTypeId ,
                                      DlyDate ,
                                      JSRId ,
                                      StockId1 ,
                                      StockId2 ,
                                      ProductId ,
                                      BN ,
                                      Qty ,
                                      CostPrice ,
                                      CostTotal ,
                                      Price ,
                                      Total ,
                                      DisCount ,
                                      DisPrice ,
                                      DisTotal ,
                                      TaxRate ,
                                      Tax ,
                                      TaxPrice ,
                                      TaxTotal ,
                                      RetailPrice ,
                                      InvoceTotal ,
                                      Remark ,
                                      C_OrderNdxId ,
                                      C_ProductOrderId ,
                                      SortNo
                                    )
                            VALUES  ( @PDlyId , -- PDlyId - varchar(36)
                                      @DlyNdxId , -- DlyNdxId - varchar(36)
                                      @ATypeId , -- ATypeId - int
                                      @CompanyId , -- CompanyId - int
                                      @DlyTypeId , -- DlyTypeId - int
                                      @DlyDate , -- DlyDate - varchar(10)
                                      @JSRId , -- JSRId - varchar(36)
                                      @StockId1 , -- StockId1 - int
                                      @StockId2 , -- StockId2 - int
                                      @ProductId , -- ProductId - int
                                      @BN , -- BN - varchar(10)
                                      @Qty , -- Qty - numeric
                                      @CostPrice , -- CostPrice - float
                                      @CostTotal , -- CostTotal - numeric
                                      @Price , -- Price - float
                                      @Total , -- Total - numeric
                                      0 , -- DisCount - numeric
                                      0.0 , -- DisPrice - float
                                      0 , -- DisTotal - numeric
                                      0 , -- TaxRate - numeric
                                      0 , -- Tax - numeric
                                      0.0 , -- TaxPrice - float
                                      0 , -- TaxTotal - numeric
                                      0.0 , -- RetailPrice - float
                                      0 , -- InvoceTotal - numeric
                                      @Remark , -- Remark - varchar(50)
                                      '' , -- C_OrderNdxId - varchar(36)
                                      '' , -- C_ProductOrderId - varchar(36)
                                      @SortNo  -- SortNo - char(10)
                                    )
							UPDATE dbo.T_PInOutDetails SET PDlyId=@PDlyId WHERE DlyNdxId=@DlyNdxId
							UPDATE dbo.T_PFBNInOutDetails SET PDlyId=@PDlyId WHERE DlyNdxId=@DlyNdxId
							UPDATE dbo.T_PSNInOutDetails SET PDlyId=@PDlyId WHERE DlyNdxId=@DlyNdxId 
                        END
                        ELSE IF @ATypeId=@SPYHAtypeId
                        BEGIN
                        	SELECT @HJPrefer=@Total
                        	INSERT INTO dbo.T_DlyADetails
                        	        ( DlyADetailId ,
                        	          DlyNdxId ,
                        	          ATypeId ,
                        	          CompanyId ,
                        	          JSRId ,
                        	          StockId ,
                        	          Total ,
                        	          DlyDate ,
                        	          DlyTypeId ,
                        	          Remark
                        	        )
                        	VALUES  ( NEWID() , -- DlyADetailId - varchar(36)
                        	          @DlyNdxId , -- DlyNdxId - varchar(36)
                        	          @ATypeId , -- ATypeId - int
                        	          @CompanyId , -- CompanyId - int
                        	          @JSRId , -- JSRId - int
                        	          @StockId1 , -- StockId - int
                        	          -@Total , -- Total - numeric
                        	          @DlyDate , -- DlyDate - varchar(10)
                        	          @DlyTypeId , -- DlyTypeId - int
                        	          ''  -- Remark - varchar(10)
                        	        )
                        END
                        ELSE
                        BEGIN
                        	IF NOT EXISTS (SELECT 1 FROM dbo.T_AType WHERE ATypeId=@ATypeId AND Level_Num=0)
                        		GOTO error1
                        	INSERT INTO dbo.T_DlyADetails
                        	        ( DlyADetailId ,
                        	          DlyNdxId ,
                        	          ATypeId ,
                        	          CompanyId ,
                        	          JSRId ,
                        	          StockId ,
                        	          Total ,
                        	          DlyDate ,
                        	          DlyTypeId ,
                        	          Remark
                        	        )
                        	VALUES  ( NEWID() , -- DlyADetailId - varchar(36)
                        	          @DlyNdxId , -- DlyNdxId - varchar(36)
                        	          @ATypeId , -- ATypeId - int
                        	          @CompanyId , -- CompanyId - int
                        	          @JSRId , -- JSRId - int
                        	          @StockId1 , -- StockId - int
                        	          -@Total , -- Total - numeric
                        	          @DlyDate , -- DlyDate - varchar(10)
                        	          @DlyTypeId , -- DlyTypeId - int
                        	          ''  -- Remark - varchar(10)
                        	        )
                        END
                                                 
                    IF @@error <> 0 
                        GOTO error
                    FETCH NEXT FROM CreateDly_cursor INTO @ATypeId, @ProductId,
                        @BN, @Qty, @Price, @Total, @Remark, @SortNo,@PDlyBakId
					IF @HJKCMoney<>0--库存商品增加
					BEGIN
						
                        	INSERT INTO dbo.T_DlyADetails
                        	        ( DlyADetailId ,
                        	          DlyNdxId ,
                        	          ATypeId ,
                        	          CompanyId ,
                        	          JSRId ,
                        	          StockId ,
                        	          Total ,
                        	          DlyDate ,
                        	          DlyTypeId ,
                        	          Remark
                        	        )
                        	VALUES  ( NEWID() , -- DlyADetailId - varchar(36)
                        	          @DlyNdxId , -- DlyNdxId - varchar(36)
                        	          @KCSPAtypeId , -- ATypeId - int
                        	          @CompanyId , -- CompanyId - int
                        	          @JSRId , -- JSRId - int
                        	          @StockId1 , -- StockId - int
                        	          @HJKCMoney , -- Total - numeric
                        	          @DlyDate , -- DlyDate - varchar(10)
                        	          @DlyTypeId , -- DlyTypeId - int
                        	          ''  -- Remark - varchar(10)
                        	        )
					END
                END
			update T_DlyNdx set Total=ABS(@HJKCMoney) where DlyNdxId=@DlyNdxId
			if @@rowcount <=0 goto error1
            CLOSE CreateDly_cursor
            DEALLOCATE CreateDly_cursor
			goto finish
        END
------------------------------------------------商品入库单------------------------------------------------

-----对科目类型进行过帐
finish:
	select @nRet=0
	select @execsql='declare AccountDly_Cursor cursor for'
				+'select * from T_PDlyA where DlyNdxId='''+@DlyNdxId+''''
	exec @execsql
	open AccountDly_Cursor
	fetch next from AccountDly_Cursor into @ATypeId,@CompanyId,@Total
	while @@FETCH_STATUS=0
	begin
		if @ATypeId<>0
		begin
            Exec @nRet = dbo.P_AtypeModify @DlyTypeId = @DlyTypeId, -- int
                @DlyNdxId = @DlyNdxId, -- varchar(36)
                @DlyDate = @DlyDate, -- varchar(10)
                @ATypeId = @ATypeId, -- int
                @ProductId = 0, -- int
                @CompanyId = @CompanyId, -- int
                @JSRId = @JSRId, -- varchar(36)
                @StockId = 0, -- int
                @Qty = @Qty, -- numeric
                @Total = @Total, -- numeric
                @BN = '', -- varchar(10)
                @CostTotal = @dTemp OUTPUT, -- numeric
                @QtyMode = -1, -- smallint
                @OldPDlyId = '' -- varchar(36)
            if @nRet<0 goto error
		end
		fetch next from AccountDly_Cursor into @ATypeId,@CompanyId,@Total
	end
	update T_DlyNdx set Draft=1 where DlyNdxId=@DlyNdxId
	
        if @@rowcount <=0 goto error1
        delete from bakdly where vchcode=@nVchcode
error:--产品批号,序列号出入库出现错误
	SELECT  @CompanyIdError = @CompanyId ,
			@StockId1Error = @StockId1 ,
			@StockId2Error = @StockId2
	SELECT  @ProductIdError = @ProductId ,
			@BNError = @BN
	CLOSE CreateDly_cursor
	DEALLOCATE CreateDly_cursor
error1:--往来单位，仓库Id不存在或不是末级节点
SELECT  @CompanyIdError = @CompanyId ,
        @StockId1Error = @StockId1 ,
        @StockId2Error = @StockId2 ,
        @ATypeIdError = @ATypeId
error2:--产品Id不存在或不是末级节点
	SELECT  @CompanyIdError = @CompanyId ,
			@StockId1Error = @StockId1 ,
			@StockId2Error = @StockId2
	SELECT  @ProductIdError = @ProductId 
	CLOSE CreateDly_cursor
	DEALLOCATE CreateDly_cursor
