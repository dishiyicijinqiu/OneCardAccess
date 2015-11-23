USE [GJPTest2]
GO
/****** 对象:  StoredProcedure [dbo].[ModifyDbf]    脚本日期: 11/20/2015 09:20:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO



/*
--------RETURN  VALUES--------
   0  Success
  -1  库存数量不够
  -2  failure
  -3  数量为零
  -5  没有成本价
  -41 数据库操作失败
  -51 库存序列号不存在
  -52 库存序列号已经存在
  -53 序列号与数量不等
  -54 系统不允许0成本出库
-----------------------------
如果是出库，则返回负的成本金额
能自动将应收应付余额合并在一个科目中
*/

ALTER                      PROCEDURE  [dbo].[ModifyDbf]
(
  @nVchType  numeric(4,0),
  @nVchCode  numeric(10,0),
  @szBillDate  varchar(10), --录单日期 
  @costmode  int,
  @szatypeid  varchar(25),
  @szptypeid  varchar(25),
  @szbtypeid  varchar(25),
  @szetypeid  varchar(25),
  @szktypeid  varchar(25),
  @szperiod    varchar(2),--00为期初，其它为当前
  @dQty      numeric(18,4),
  @dTotal  numeric(18,4),
  @szBlockno  varchar(20),
  @szProdate  varchar(20),
  @nGoodsNo  int,
  @dCostTotal  numeric(18,4)  output,
  @oDlyorder int = 0,
  @nlsSerial int = 0,--是否严格管理序列号 0 不严格,1 严格
  @nInputZero int = 0 --如果是出库单据,表示是否0成本强制出库 0 不是, 1 是；
		      --如果是入库，则此标志表示是否采用0单价入库 0 不是, 1 是(此时用于获赠单)
)
AS


  SET NOCOUNT ON

  DECLARE
      @GOODS_ID  varchar(25),
      @AR_ID  varchar(25),
      @AP_ID  varchar(25),
      @CHANGE_PRICE_VCHTYPE  int

  SELECT      @GOODS_ID = '0000100001'
  SELECT      @AR_ID = '0000100005'
  SELECT      @AP_ID = '0000200001'
  SELECT      @CHANGE_PRICE_VCHTYPE = 57
------------------

-------Costing  method------------
  DECLARE  @AVERAGE     smallint
  DECLARE  @FIFO        smallint
  DECLARE  @LIFO        smallint
  DECLARE  @HAND        smallint

  SELECT  @AVERAGE    = 0
  SELECT  @FIFO       = 1
  SELECT  @LIFO       = 2
  SELECT  @HAND       = 3
---------------------

  DECLARE  @szJobNumber  varchar(20),@OutFactoryDate  varchar(10)
  DECLARE  @dTotaltemp  numeric(18,4),@dQtytemp  numeric(18,4),@dCostTotaltemp  numeric(18,4),@dCostQtytemp  numeric(18,4),
    @dPricetemp  numeric(18,8),@dCostPricetemp  numeric(18,8),@nPeriod  int,@nGoodsNoTemp  int,@TotalTemp numeric(18,4)
  DECLARE  @RegativeStock  int  ,@nTemp  int,@nGoodsOrderID int --连接序列号库存
  declare @nGoodsID int --连接变动表对应的序列号
  declare @nSerialCountTemp int 
  declare @nZeroCostPrice int --零成本出库标志
  DECLARE  @DOUBLE_ZERO  NUMERIC(18,5)
  SET  @DOUBLE_ZERO = 0.0001

--  IF  @szPtypeid = ''  or  @szPtypeid = '00000'  RETURN  -6
--  IF  @szKtypeid = ''  or  @szKtypeid = '00000'  RETURN  -6
  IF  @szperiod = '00'
  BEGIN
    SELECT  @nTemp = subvalue  FROM  sysdata  WHERE  subname = 'iniover'
    IF  @nTemp = 1  RETURN  -100
  END

  select @nZeroCostPrice = [stats]  FROM  syscon  WHERE  [order] = 73  --是否允许零成本出库
  SELECT  @RegativeStock = [stats]  FROM  syscon  WHERE  [order] = 14  --是否允许负库存

  if (@szperiod = '00') or (@costmode <> @HAND) SELECT  @dCostTotal = 0 --modi by dcsong 2001.01.05
  select @dTotaltemp = 0,@dQtytemp = 0,@dCostTotaltemp = 0,@dCostQtytemp = 0,@dPricetemp = 0,@dCostPricetemp = 0

  IF  @szatypeid = @GOODS_ID  AND  @szptypeid<>''
  BEGIN
    IF  @szperiod<>'00'
    BEGIN
	if (@dQty < 0) --出库金额为0,不允许0成本出库,则提示错误
		if (@dTotal = 0) and (@nInputZero = 1) and (@nZeroCostPrice = 0) goto Error54
	---------------------判断是否有相同的个数是否相等--------------------------------
	if @nlsSerial = 1   --严格管理序列号，判断序列号够不够
	begin
		select @nSerialCountTemp = 0
		select @nSerialCountTemp = count(SN) from t_bakserial  			
		where VchCode = @nVchCode and VchLineNO = @oDlyorder
		if @nSerialCountTemp <> abs(@dQty) goto error53 
	end
	---------------------判断是否有相同的个数是否相等--------------------------------
	
	---------------------判断是否有相同的序列号--------------------------------
       if @dQty > 0  --入库
       begin
		select SN from t_bakserial b,t_serial s
			where b.VchCode = @nVchCode and b.VchLineNO = @oDlyorder and b.SN = s.SERIALNO 
			and s.PTYPEID = @szptypeid
		if @@rowcount > 0 goto error52   --相同商品的库存序列号不能重复
       end
	---------------------判断是否有相同的序列号--------------------------------
      IF  @costmode = @AVERAGE
      BEGIN
        IF  @dQty = 0  GOTO  Error3
	
	---------------------判断是否有足够的序列号---add by dcsong 2004.9.21------
	if @dQty < 0  --出库 
	begin
		if @nlsSerial = 1   --严格管理序列号，判断序列号够不够
		begin
			select SN from t_bakserial where VchCode = @nVchCode and VchLineNO = @oDlyorder and SN 
				not in (select SERIALNO from t_serial where PTYPEID = @szptypeid and KTYPEID = @szktypeid)
			if @@rowcount > 0 goto error51   --如果有数据，则有库存不存在的序列号
		end
		delete t_serial from t_bakserial b where b.VchCode = @nVchCode and b.VchLineNO = @oDlyorder
			and b.SN = t_serial.SERIALNO and t_serial.PTYPEID = @szptypeid and t_serial.KTYPEID = @szktypeid 
		if @@error <> 0 goto error41 --改变库存序列号
	end
	---------------------判断是否有足够的序列号---add by dcsong 2004.9.21------

        DECLARE  ModIFyDbf_CURSOR  CURSOR  for
        SELECT  qty,price,total,jobnumber,OutFactoryDate,GoodsOrder,goodsorderid  FROM  goodsstocks
        WHERE  ptypeid = @szptypeid  AND  ktypeid = @szktypeid  FOR  UPDATE

        OPEN  ModIFyDbf_CURSOR
        FETCH  NEXT  FROM  ModIFyDbf_CURSOR  INTO  @dCostQtytemp,@dCostPricetemp,@dCostTotaltemp,
            @szJobNumber,@OutFactoryDate,@nGoodsNoTemp,@nGoodsorderid
        IF  @@FETCH_STATUS = 0
        BEGIN
          IF  @dQty<0  --出库
          BEGIN
            IF  @dTotal<>0  --出库，有出库金额
            BEGIN
              IF  @dCostQtytemp<abs(@dQty  )
              BEGIN
                IF  @RegativeStock = 0  GOTO  Error1
                IF  @nVchtype = @CHANGE_PRICE_VCHTYPE  GOTO  Error1
              END
              SELECT  @dTotaltemp = @dCostTotaltemp+@dTotal
              SELECT  @dQtytemp = @dCostQtytemp+@dQty
              IF  @dQtytemp = 0  AND  @dTotalTemp = 0
              BEGIN
                DELETE  FROM  goodsstocks  WHERE  CURRENT  OF  ModIFyDbf_CURSOR
                IF  @@RowCount = 0  GOTO  error44c
              END
              ELSE
              BEGIN
                SELECT  @dCostPricetemp = 0
                IF  @dQtytemp<>0  SELECT  @dCostPricetemp = @dTotaltemp/@dQtytemp
                UPDATE  goodsstocks  SET  total = @dTotaltemp,qty = @dQtytemp,price = @dCostPriceTemp
                WHERE  CURRENT  OF  ModIFyDbf_CURSOR
                IF  @@RowCount = 0  GOTO  error44c
              END
		--add by dcsong 2004.8.25 增加写入库存变动表的功能 dlyorder暂填0，等有了后再填
	      insert into T_GoodsStocksGlide(VchCode,dlyorder,ptypeid,ktypeid,GoodsDate,GoodsOrder,JobNumber,OutFactoryDate,Qty,Price,Total)
	      values (@nVchCode,0,@szptypeid,@szktypeid,@szBillDate,0,@szBlockno,@szProdate,@dQty,@dTotal/@dQty,@dTotal)
	      if @@RowCount = 0  GOTO  error44c
	      else select @nGoodsID = @@identity 
	--------------add by dcsong 2004.9.21----------------------
		    INSERT into SN(VCHTYPE,VCHCODE,VCHLINENO,PTYPEID,BTYPEID,KTYPEID,ETYPEID,SN,BILLDATE,GOODSID,Memo)
		    SELECT VCHTYPE,@NVCHCODE,0,PTYPEID,BTYPEID,@szKTYPEID,ETYPEID,SN,BILLDATE,@nGoodsID,Memo from t_bakserial
		    WHERE VCHCODE = @NVCHCODE AND VCHLINENO = @ODLYORDER 
		    IF @@error <> 0  GOTO  ERROR44C --写过帐序列号
	--------------add by dcsong 2004.9.21----------------------
              SELECT  @dCostTotal = @dTotal
              GOTO  CleanUp
            END
            ELSE  --出库无出库金额
            BEGIN
            	IF  @dCostQtytemp = abs(@dQty  ) --库存数量等于出库数量时
              	BEGIN
                	IF  ((@dCosttotaltemp>0) and (@nInputZero = 0)) or --库存成本大于0,并且不0成本强制出库
			    ((@nZeroCostPrice = 1) and (@dCosttotaltemp = 0)) --库存成本等于0且允许0成本出库时  
                	BEGIN
				DELETE  FROM  goodsstocks  WHERE  CURRENT  OF  ModIFyDbf_CURSOR
				IF  @@RowCount = 0  GOTO  error44c
				--add by dcsong 2004.8.25 增加写入库存变动表的功能 dlyorder暂填0，等有了后再填
				insert into T_GoodsStocksGlide(VchCode,dlyorder,ptypeid,ktypeid,GoodsDate,GoodsOrder,JobNumber,OutFactoryDate,Qty,Price,Total)
				values (@nVchCode,0,@szptypeid,@szktypeid,@szBillDate,0,@szBlockno,@szProdate,@dQty,-1*@dCosttotaltemp/@dQty,-1*@dCosttotaltemp)
				if @@RowCount = 0  GOTO  error44c
				else select @nGoodsID = @@identity 
				--------------add by dcsong 2004.9.21----------------------
				INSERT into SN(VCHTYPE,VCHCODE,VCHLINENO,PTYPEID,BTYPEID,KTYPEID,ETYPEID,SN,BILLDATE,GOODSID,Memo)
				SELECT VCHTYPE,@NVCHCODE,0,PTYPEID,BTYPEID,@szKTYPEID,ETYPEID,SN,BILLDATE,@nGoodsID,Memo from t_bakserial
				
				WHERE VCHCODE = @NVCHCODE AND VCHLINENO = @ODLYORDER 
				IF @@error <> 0  GOTO  ERROR44C --写过帐序列号
				--------------add by dcsong 2004.9.21----------------------
				SELECT  @dCostTotal = -@dCostTotaltemp
				GOTO  CleanUp
			END
			ELSE  --@dCosttotaltemp< = 数量和金额反号 或0成本强制出库
			BEGIN
				if (@nInputZero = 1) select @dTotaltemp = 0--0成本强制出库
				else --成本异常,取最近进价
				begin
					SELECT  @dTotaltemp = @dQty*recprice  FROM  ptype  WHERE  typeid = @szptypeid
					IF (@dTotaltemp> = 0) GOTO  errorInputCostPrice --最近进价为0
				end
				SELECT  @dTotaltemp = @dCostTotaltemp+@dTotaltemp
				SELECT  @dQtytemp = @dCostQtytemp+@dQty--0
				UPDATE  goodsstocks  SET  total = @dTotaltemp,qty = @dQtytemp,price = 0
				WHERE  CURRENT  OF  ModIFyDbf_CURSOR
				IF  @@RowCount = 0  GOTO  error44c
				--add by dcsong 2004.8.25 增加写入库存变动表的功能 dlyorder暂填0，等有了后再填
				insert into T_GoodsStocksGlide(VchCode,dlyorder,ptypeid,ktypeid,GoodsDate,GoodsOrder,JobNumber,OutFactoryDate,Qty,Price,Total)
				values (@nVchCode,0,@szptypeid,@szktypeid,@szBillDate,0,@szBlockno,@szProdate,@dQty,(@dTotaltemp-@dCosttotaltemp)/@dQty,(@dTotaltemp-@dCosttotaltemp))
				if @@RowCount = 0  GOTO  error44c
				else select @nGoodsID = @@identity 
				--------------add by dcsong 2004.9.21----------------------
				INSERT into SN(VCHTYPE,VCHCODE,VCHLINENO,PTYPEID,BTYPEID,KTYPEID,ETYPEID,SN,BILLDATE,GOODSID,Memo)
				SELECT VCHTYPE,@NVCHCODE,0,PTYPEID,BTYPEID,@szKTYPEID,ETYPEID,SN,BILLDATE,@nGoodsID,Memo from t_bakserial
				WHERE VCHCODE = @NVCHCODE AND VCHLINENO = @ODLYORDER 
				IF @@error <> 0  GOTO  ERROR44C --写过帐序列号
				--------------add by dcsong 2004.9.21----------------------
				SELECT  @dCostTotal = @dTotaltemp-@dCosttotaltemp
				GOTO  CleanUp
			END
		END  
		ELSE
		BEGIN
			IF  @dCostQtytemp<abs(@dQty  ) --库存数量小于出库数量 
			BEGIN
				IF  @RegativeStock = 0  GOTO  Error1
				IF  @nVchtype = @CHANGE_PRICE_VCHTYPE  GOTO  Error1
			END
			if ((@nZeroCostPrice = 1) and (@dCostQtytemp>abs(@dQty)) and (@dCosttotaltemp = 0)) select @dCostPricetemp = 0
			else
			begin
				if (@nInputZero = 1) select @dCostPricetemp = 0 --强制出库
				else 
				begin
					IF  @dCostQtytemp = 0  or  @dCosttotaltemp = 0  SELECT  @dCostPricetemp = recprice  FROM  ptype  WHERE  typeid = @szPtypeid
					ELSE  SELECT  @dCostPricetemp = @dCostTotaltemp  /  @dCostQtyTemp
					IF  (@dCostPricetemp <= 0) GOTO  errorInputCostPrice --成本价为负或0
				end
			end
			SELECT  @dCostTotal = (@dQty*@dCostPricetemp)
			SELECT  @dTotaltemp = @dCostTotaltemp+@dCostTotal  --@dQty*@dCostPricetemp
			SELECT  @dQtytemp = @dCostQtytemp+@dQty
			SELECT  @dCostPricetemp = 0
			IF  @dQtytemp<>0  SELECT  @dCostPricetemp = @dTotaltemp/@dQtytemp
			UPDATE  goodsstocks  SET  total = @dTotaltemp,qty = @dQtytemp,price = @dCostPricetemp
			WHERE  CURRENT  OF  ModIFyDbf_CURSOR
			IF  @@RowCount = 0  GOTO  error44c
			--add by dcsong 2004.8.25 增加写入库存变动表的功能 dlyorder暂填0，等有了后再填
			insert into T_GoodsStocksGlide(VchCode,dlyorder,ptypeid,ktypeid,GoodsDate,GoodsOrder,JobNumber,OutFactoryDate,Qty,Price,Total)
			values (@nVchCode,0,@szptypeid,@szktypeid,@szBillDate,0,@szBlockno,@szProdate,@dQty,@dCostPricetemp,@dCostTotal)
			if @@RowCount = 0  GOTO  error44c
			else select @nGoodsID = @@identity 
			--------------add by dcsong 2004.9.21----------------------
			INSERT into SN(VCHTYPE,VCHCODE,VCHLINENO,PTYPEID,BTYPEID,KTYPEID,ETYPEID,SN,BILLDATE,GOODSID,Memo)
			SELECT VCHTYPE,@NVCHCODE,0,PTYPEID,BTYPEID,@szKTYPEID,ETYPEID,SN,BILLDATE,@nGoodsID,Memo from t_bakserial
			WHERE VCHCODE = @NVCHCODE AND VCHLINENO = @ODLYORDER 
			IF @@error <> 0  GOTO  ERROR44C --写过帐序列号
			--------------add by dcsong 2004.9.21----------------------
			
			GOTO  CleanUp
		END
	END
        END  ELSE--有记录入库
          BEGIN

            IF ((@dTotal = 0) and (@nInputZero = 0)) --入库金额为0，并且不采用0单价入库
            BEGIN
              IF  @dCostQtytemp = 0  or  @dCosttotaltemp = 0  SELECT  @dCostPricetemp = recprice  FROM  ptype  WHERE  typeid = @szPtypeid
              ELSE  SELECT  @dCostPricetemp = @dCostTotaltemp  /  @dCostQtyTemp
              IF  @dCostPricetemp< = 0  GOTO  errorInputCostPrice
              SELECT  @dTotal = @dCostPriceTemp*@dQty  --已经有库存了
              IF  @dTotal< = 0    GOTO  errorInputCostPrice
            END
            SELECT  @dTotaltemp = @dCostTotaltemp+@dTotal
            SELECT  @dQtytemp = @dCostQtytemp+@dQty
            SELECT  @dCostPricetemp = 0
            IF  @dQtytemp<>0  SELECT  @dCostPricetemp = @dTotaltemp/@dQtytemp
            UPDATE  goodsstocks  SET  total = @dTotaltemp,qty = @dQtytemp,price = @dCostPricetemp--,outfactorydate = @szProdate, JobNumber =@szBlockNO
            WHERE  CURRENT  OF  ModIFyDbf_CURSOR
            IF  @@RowCount = 0  GOTO  error44c
	 --add by dcsong 2004.8.25 增加写入库存变动表的功能 dlyorder暂填0，等有了后再填
	    if @dQty = 0 
	    begin
		    insert into T_GoodsStocksGlide(VchCode,dlyorder,ptypeid,ktypeid,GoodsDate,GoodsOrder,JobNumber,OutFactoryDate,Qty,Price,Total)
		    values (@nVchCode,0,@szptypeid,@szktypeid,@szBillDate,0,@szBlockno,@szProdate,@dQty,0,@dTotal)
		    if @@RowCount = 0  GOTO  error44c
		    else select @nGoodsID = @@identity 
	    end	
            else
	    begin
		    insert into T_GoodsStocksGlide(VchCode,dlyorder,ptypeid,ktypeid,GoodsDate,GoodsOrder,JobNumber,OutFactoryDate,Qty,Price,Total)
		    values (@nVchCode,0,@szptypeid,@szktypeid,@szBillDate,0,@szBlockno,@szProdate,@dQty,@dTotal/@dQty,@dTotal)
		    if @@RowCount = 0  GOTO  error44c
		    else select @nGoodsID = @@identity 
	    end
	--------------add by dcsong 2004.9.21----------------------
	    insert into t_serial(PTYPEID,GOODSORDERID,KTYPEID,SERIALNO,Memo)
	    	select PTYPEID,@nGoodsOrderID,@szKTYPEID,SN,Memo from t_bakserial
		where VchCode = @nVchCode and VchLineNO = @oDlyorder 
	    if @@error <> 0  GOTO  error44c --改变序列号库存

	    insert into SN(VCHTYPE,VCHCODE,VchLineNO,PTYPEID,BTYPEID,KTYPEID,ETYPEID,SN,BillDate,GoodsID,Memo)
	    select VCHTYPE,@nVchCode,0,PTYPEID,BTYPEID,@szKTYPEID,ETYPEID,SN,BillDate,@nGoodsID,Memo from t_bakserial
	    where VchCode = @nVchCode and VchLineNO = @oDlyorder 
	    if @@error <> 0  GOTO  error44c --写过帐序列号
	--------------add by dcsong 2004.9.21----------------------
            SELECT  @dCostTotal = @dTotal
            GOTO  CleanUp
          END
        END  ELSE--库存无记录
        BEGIN
          IF  @dQty<0
          BEGIN
            IF  @RegativeStock = 0  GOTO  Error1
            IF  @nVchtype = @CHANGE_PRICE_VCHTYPE  GOTO  Error1
          END
          IF  ((@dTotal = 0) and (@nInputZero = 0)) --入库金额为0，并且不采用0单价入库,或出库不强制出库
          BEGIN
            SELECT  @dTotal = (recprice*@dQty)  FROM  ptype  WHERE  typeid = @szptypeid
            IF  @dTotal = 0    GOTO  errorInputCostPrice
          END
          SELECT  @dCostPricetemp = @dTotal/@dQty
          INSERT  goodsstocks(ptypeid,ktypeid,qty,total,price)--,OutFactoryDate, JobNumber)
          VALUES(@szPtypeid,@szKtypeid,@dQty,@dTotal,@dCostPricetemp)--,@szProdate,@szBlockNO)
          IF  @@RowCount = 0  GOTO  error44c
	   else select @nGoodsOrderID = @@identity 
	 --add by dcsong 2004.8.25 增加写入库存变动表的功能 dlyorder暂填0，等有了后再填
	    insert into T_GoodsStocksGlide(VchCode,dlyorder,ptypeid,ktypeid,GoodsDate,GoodsOrder,JobNumber,OutFactoryDate,Qty,Price,Total)
	    values (@nVchCode,0,@szptypeid,@szktypeid,@szBillDate,0,@szBlockno,@szProdate,@dQty,@dCostPricetemp,@dTotal)
	    if @@RowCount = 0  GOTO  error44c
	    else select @nGoodsID = @@identity 

	--------------add by dcsong 2004.9.21----------------------
	  if @dQty > 0 --入库
	  begin 
	    insert into t_serial(PTYPEID,GOODSORDERID,KTYPEID,SERIALNO,Memo)

	    	select PTYPEID,@nGoodsOrderID,@szKTYPEID,SN,Memo from t_bakserial
		where VchCode = @nVchCode and VchLineNO = @oDlyorder 
	    if @@error <> 0  GOTO  error44c --改变序列号库存
	  end
	    insert into SN(VCHTYPE,VCHCODE,VchLineNO,PTYPEID,BTYPEID,KTYPEID,ETYPEID,SN,BillDate,GoodsID,Memo)
	    select VCHTYPE,@nVchCode,0,PTYPEID,BTYPEID,@szKTYPEID,ETYPEID,SN,BillDate,@nGoodsID,Memo from t_bakserial
	    where VchCode = @nVchCode and VchLineNO = @oDlyorder 
	    if @@error <> 0  GOTO  error44c --写过帐序列号
	--------------add by dcsong 2004.9.21----------------------
          SELECT  @dCostTotal = @dTotal
          GOTO  CleanUp
        END
      END

      ELSE
      IF  @costmode = @FIFO
      BEGIN
        IF  @dQty = 0  GOTO  Error3

        EXEC  Getdbf  @GOODS_ID,@szPtypeId,'','',@szKtypeId,'','',@dQtytemp  output,@dTotaltemp  output
        IF  (@dQtytemp+@dQty)<0
        BEGIN
          RETURN  -1
        END

        IF  @dQty<0
        BEGIN
          SET  @dPriceTemp = @dTotal/@dQty
          IF (@dTotal<>0) or (@nInputZero = 1) --金额不为0 或强制出库
          DECLARE  ModIFyDbf_CURSOR  SCROLL  CURSOR  for
          SELECT  qty,price,total,jobnumber,OutFactoryDate,GoodsOrder,GoodsOrderID  FROM  goodsstocks
          WHERE  ptypeid = @szptypeid  AND  ktypeid = @szktypeid  AND
                                    abs(price-@dPriceTemp)< = @DOUBLE_ZERO -- AND  outfactorydate = @szProdate  AND  jobnumber = @szBlockno
          ORDER  BY  GoodsOrder  asc  FOR  UPDATE
          ELSE
          DECLARE  ModIFyDbf_CURSOR  SCROLL  CURSOR  for
          SELECT  qty,price,total,jobnumber,OutFactoryDate,GoodsOrder,GoodsOrderID  FROM  goodsstocks
          WHERE  ptypeid = @szptypeid  AND  ktypeid = @szktypeid -- AND  outfactorydate = @szProdate  AND  jobnumber = @szBlockno
          ORDER  BY  GoodsOrder  asc  FOR  UPDATE

        END
        ELSE
        BEGIN
          DECLARE  ModIFyDbf_CURSOR    SCROLL  CURSOR  for
          SELECT  qty,price,total,jobnumber,OutFactoryDate,GoodsOrder,GoodsOrderID  FROM  goodsstocks
          WHERE  ptypeid = @szptypeid  AND  ktypeid = @szktypeid  AND  outfactorydate = @szProdate  AND  jobnumber = @szBlockno
          ORDER  BY  GoodsOrder  DESC  FOR  UPDATE
        END

        SELECT  @dQtytemp = @dQty,@dTotaltemp = 0
        OPEN  ModIFyDbf_CURSOR
        FETCH  NEXT  FROM  ModIFyDbf_CURSOR  INTO  @dCostQtytemp,@dCostPricetemp,@dCostTotaltemp,
            @szJobNumber,@OutFactoryDate,@nGoodsNoTemp,@nGoodsOrderID
        while  @@FETCH_STATUS = 0
        BEGIN
          IF  @dQty<0
          BEGIN
            SELECT  @dQty = @dCostQtytemp+@dQty
            IF  @dQty< = 0
            BEGIN
              SELECT  @dTotaltemp = @dTotaltemp-@dCostTotaltemp
              DELETE  FROM  goodsstocks  WHERE  CURRENT  OF  ModIFyDbf_CURSOR
              IF  @@RowCount = 0  GOTO  error44c

	 --add by dcsong 2004.8.25 增加写入库存变动表的功能 dlyorder暂填0，等有了后再填
	      insert into T_GoodsStocksGlide(VchCode,dlyorder,ptypeid,ktypeid,GoodsDate,GoodsOrder,JobNumber,OutFactoryDate,Qty,Price,Total)
	      values (@nVchCode,0,@szptypeid,@szktypeid,@szBillDate,0,@szJobNumber,@OutFactoryDate,-1*@dCostQtytemp,@dCostTotaltemp/@dCostQtytemp,-1*@dCostTotaltemp)
	      if @@RowCount = 0  GOTO  error44c
	      else select @nGoodsID = @@identity 

              IF  @dQty<>0
              BEGIN
                FETCH  NEXT  FROM  ModIFyDbf_CURSOR  INTO  @dCostQtytemp,@dCostPricetemp,@dCostTotaltemp,
                    @szJobNumber,@OutFactoryDate,@nGoodsNoTemp,@nGoodsOrderID
                CONTINUE
              END  ELSE  IF  @dQty = 0
              BEGIN
                SELECT  @dCostTotal = @dTotaltemp
	--------------add by dcsong 2004.9.21----------------------
		delete t_serial from t_bakserial b where b.VchCode = @nVchCode and b.VchLineNO = @oDlyorder
			and b.SN = t_serial.SERIALNO and t_serial.PTYPEID = @szptypeid and t_serial.KTYPEID = @szktypeid-- and t_serial.Goodsorderid = @nGoodsorderid
		if @@error <> 0 goto error41 --改变库存序列号

		INSERT into SN(VCHTYPE,VCHCODE,VCHLINENO,PTYPEID,BTYPEID,KTYPEID,ETYPEID,SN,BILLDATE,GOODSID,Memo)
		SELECT VCHTYPE,@NVCHCODE,0,PTYPEID,BTYPEID,@szKTYPEID,ETYPEID,SN,BILLDATE,@nGoodsID,Memo from t_bakserial
		WHERE VCHCODE = @NVCHCODE AND VCHLINENO = @ODLYORDER 
		IF @@error <> 0  GOTO  ERROR44C --写过帐序列号
	--------------add by dcsong 2004.9.21----------------------

                GOTO  CleanUp
              END
            END  ELSE
            BEGIN
	      select  @TotalTemp  = -(@dCostQtytemp-@dQty)*@dCostpricetemp	
              SELECT  @dTotaltemp = @dTotaltemp+@TotalTemp
              SELECT  @dCostTotal = @dTotaltemp
              UPDATE  goodsstocks  SET  qty = @dQty,total = total + @TotalTemp --@dQty*@dCostPriceTemp
              WHERE  CURRENT  OF  ModIFyDbf_CURSOR
              IF  @@RowCount = 0  GOTO  error44c
	 --add by dcsong 2004.8.25 增加写入库存变动表的功能 dlyorder暂填0，等有了后再填
	      insert into T_GoodsStocksGlide(VchCode,dlyorder,ptypeid,ktypeid,GoodsDate,GoodsOrder,JobNumber,OutFactoryDate,Qty,Price,Total)
	      values (@nVchCode,0,@szptypeid,@szktypeid,@szBillDate,0,@szJobNumber,@OutFactoryDate,(@dQty-@dCostQtytemp),@dCostpricetemp,@TotalTemp)
	      if @@RowCount = 0  GOTO  error44c
		else select @nGoodsID = @@identity 
	--------------add by dcsong 2004.9.21----------------------
		delete t_serial from t_bakserial b where b.VchCode = @nVchCode and b.VchLineNO = @oDlyorder
			and b.SN = t_serial.SERIALNO and t_serial.PTYPEID = @szptypeid and t_serial.KTYPEID = @szktypeid --and t_serial.Goodsorderid = @nGoodsorderid
		if @@error <> 0 goto error41 --改变库存序列号

		INSERT into SN(VCHTYPE,VCHCODE,VCHLINENO,PTYPEID,BTYPEID,KTYPEID,ETYPEID,SN,BILLDATE,GOODSID,Memo)
		SELECT VCHTYPE,@NVCHCODE,0,PTYPEID,BTYPEID,@szKTYPEID,ETYPEID,SN,BILLDATE,@nGoodsID,Memo from t_bakserial
		WHERE VCHCODE = @NVCHCODE AND VCHLINENO = @ODLYORDER 
		IF @@error <> 0  GOTO  ERROR44C --写过帐序列号
	--------------add by dcsong 2004.9.21----------------------

              GOTO  CleanUp
            END
          END  ELSE  --入库
          BEGIN
            IF  ((@dTotal = 0) and (@nInputZero = 0)) --入库金额为0，并且不采用0单价入库
            BEGIN
              SELECT  @dTotal = (recprice*@dQty)  FROM  ptype  WHERE  typeid = @szptypeid
              IF  @dTotal = 0  GOTO  errorInputCostPrice
            END
            SELECT  @dPricetemp = @dTotal/@dQty
            IF  @nVchType = @CHANGE_PRICE_VCHTYPE
            BEGIN
              FETCH  LAST  FROM  ModIFyDbf_CURSOR  INTO  @dCostQtytemp,@dCostPricetemp,@dCostTotaltemp,
                        @szJobNumber,@OutFactoryDate,@nGoodsNoTemp,@nGoodsOrderID
              IF    @dPricetemp = @dCostPricetemp
              BEGIN
                SELECT  @dTotaltemp = @dCostTotaltemp+@dTotal
                SELECT  @dQtytemp = @dCostQtytemp+@dQty
                UPDATE  goodsstocks  SET  qty = @dQtytemp,total = @dTotaltemp
                WHERE  CURRENT  OF  ModIFyDbf_CURSOR
                IF  @@RowCount = 0  GOTO  error44c

	--------------add by dcsong 2004.9.21----------------------
		insert into T_GoodsStocksGlide(VchCode,dlyorder,ptypeid,ktypeid,GoodsDate,GoodsOrder,JobNumber,OutFactoryDate,Qty,Price,Total)
		values (@nVchCode,0,@szptypeid,@szktypeid,@szBillDate,0,@szBlockno,@szProdate,@dQty,@dPricetemp,@dTotal)
		if @@RowCount = 0  GOTO  error44c
		else select @nGoodsID = @@identity

		insert into t_serial(PTYPEID,GOODSORDERID,KTYPEID,SERIALNO,Memo)
			select PTYPEID,@nGoodsOrderID,@szKTYPEID,SN,Memo from t_bakserial
		where VchCode = @nVchCode and VchLineNO = @oDlyorder 
		if @@error <> 0  GOTO  error44c --改变序列号库存
		
		insert into SN(VCHTYPE,VCHCODE,VchLineNO,PTYPEID,BTYPEID,KTYPEID,ETYPEID,SN,BillDate,GoodsID,Memo)
		select VCHTYPE,@nVchCode,0,PTYPEID,BTYPEID,@szKTYPEID,ETYPEID,SN,BillDate,@nGoodsID,Memo from t_bakserial

		where VchCode = @nVchCode and VchLineNO = @oDlyorder 
		if @@error <> 0  GOTO  error44c --写过帐序列号
	--------------add by dcsong 2004.9.21----------------------

                SELECT  @dCostTotal = @dTotal
                GOTO  CleanUp
              END  ELSE
              BEGIN
                SELECT  @dCostTotal = @dTotal
                INSERT  goodsstocks(ptypeid,ktypeid,qty,total,price,GoodsOrder,JobNumber,OutFactoryDate)
                VALUES(@szPtypeid,@szKtypeid,@dQty,@dTotal,@dPricetemp,@nGoodsNoTemp-1,@szBlockNO,@szProdate)  --调价，先进的出了，入的时候要入在前面。
                IF  @@RowCount = 0  GOTO  error44c

	 --add by dcsong 2004.8.25 增加写入库存变动表的功能 dlyorder暂填0，等有了后再填
	        insert into T_GoodsStocksGlide(VchCode,dlyorder,ptypeid,ktypeid,GoodsDate,GoodsOrder,JobNumber,OutFactoryDate,Qty,Price,Total)
	        values (@nVchCode,0,@szptypeid,@szktypeid,@szBillDate,0,@szBlockno,@szProdate,@dQty,@dPricetemp,@dTotal)
	        if @@RowCount = 0  GOTO  error44c
		else select @nGoodsID = @@identity

		insert into t_serial(PTYPEID,GOODSORDERID,KTYPEID,SERIALNO,Memo)
			select PTYPEID,@nGoodsOrderID,@szKTYPEID,SN,Memo from t_bakserial
		where VchCode = @nVchCode and VchLineNO = @oDlyorder 
		if @@error <> 0  GOTO  error44c --改变序列号库存
		
		insert into SN(VCHTYPE,VCHCODE,VchLineNO,PTYPEID,BTYPEID,KTYPEID,ETYPEID,SN,BillDate,GoodsID,Memo)
		select VCHTYPE,@nVchCode,0,PTYPEID,BTYPEID,@szKTYPEID,ETYPEID,SN,BillDate,@nGoodsID,Memo from t_bakserial
		where VchCode = @nVchCode and VchLineNO = @oDlyorder 
		if @@error <> 0  GOTO  error44c --写过帐序列号
	--------------add by dcsong 2004.9.21----------------
                GOTO  CleanUp
              END
            END
            IF    @dPricetemp = @dCostPricetemp
            BEGIN
              SELECT  @dTotaltemp = @dCostTotaltemp+@dTotal
              SELECT  @dQtytemp = @dCostQtytemp+@dQty
              UPDATE  goodsstocks  SET  qty = @dQtytemp,total = @dTotaltemp--,outfactorydate = @szProdate, JobNumber =@szBlockNO
              WHERE  CURRENT  OF  ModIFyDbf_CURSOR
              IF  @@RowCount = 0  GOTO  error44c
	 --add by dcsong 2004.8.25 增加写入库存变动表的功能 dlyorder暂填0，等有了后再填
	        insert into T_GoodsStocksGlide(VchCode,dlyorder,ptypeid,ktypeid,GoodsDate,GoodsOrder,JobNumber,OutFactoryDate,Qty,Price,Total)
	        values (@nVchCode,0,@szptypeid,@szktypeid,@szBillDate,0,@szBlockno,@szProdate,@dQty,@dCostPricetemp,@dTotal)
	        if @@RowCount = 0  GOTO  error44c
		else select @nGoodsID = @@identity

		insert into t_serial(PTYPEID,GOODSORDERID,KTYPEID,SERIALNO,Memo)
			select PTYPEID,@nGoodsOrderID,@szKTYPEID,SN,Memo from t_bakserial
		where VchCode = @nVchCode and VchLineNO = @oDlyorder 
		if @@error <> 0  GOTO  error44c --改变序列号库存
		
		insert into SN(VCHTYPE,VCHCODE,VchLineNO,PTYPEID,BTYPEID,KTYPEID,ETYPEID,SN,BillDate,GoodsID,Memo)
		select VCHTYPE,@nVchCode,0,PTYPEID,BTYPEID,@szKTYPEID,ETYPEID,SN,BillDate,@nGoodsID,Memo from t_bakserial
		where VchCode = @nVchCode and VchLineNO = @oDlyorder 
		if @@error <> 0  GOTO  error44c --写过帐序列号
	--------------add by dcsong 2004.9.21----------------
              SELECT  @dCostTotal = @dTotal
              GOTO  CleanUp
            END  ELSE
            BEGIN
              SELECT  @dCostTotal = @dTotal
              INSERT  goodsstocks(ptypeid,ktypeid,qty,total,price,GoodsOrder,JobNumber,OutFactoryDate)
              VALUES(@szPtypeid,@szKtypeid,@dQty,@dTotal,@dPriceTemp,@nGoodsNoTemp+1,@szBlockNO,@szProdate)
              IF  @@RowCount = 0  GOTO  error44c
	 --add by dcsong 2004.8.25 增加写入库存变动表的功能 dlyorder暂填0，等有了后再填
	    	insert into T_GoodsStocksGlide(VchCode,dlyorder,ptypeid,ktypeid,GoodsDate,GoodsOrder,JobNumber,OutFactoryDate,Qty,Price,Total)
	    	values (@nVchCode,0,@szptypeid,@szktypeid,@szBillDate,0,@szBlockno,@szProdate,@dQty,@dPriceTemp,@dTotal)
	    	if @@RowCount = 0  GOTO  error44c
		else select @nGoodsID = @@identity

		insert into t_serial(PTYPEID,GOODSORDERID,KTYPEID,SERIALNO,Memo)
			select PTYPEID,@nGoodsOrderID,@szKTYPEID,SN,Memo from t_bakserial
		where VchCode = @nVchCode and VchLineNO = @oDlyorder 
		if @@error <> 0  GOTO  error44c --改变序列号库存
		
		insert into SN(VCHTYPE,VCHCODE,VchLineNO,PTYPEID,BTYPEID,KTYPEID,ETYPEID,SN,BillDate,GoodsID,Memo)
		select VCHTYPE,@nVchCode,0,PTYPEID,BTYPEID,@szKTYPEID,ETYPEID,SN,BillDate,@nGoodsID,Memo from t_bakserial
		where VchCode = @nVchCode and VchLineNO = @oDlyorder 
		if @@error <> 0  GOTO  error44c --写过帐序列号
	--------------add by dcsong 2004.9.21----------------
              GOTO  CleanUp
            END
          END
        END
        IF  @@FETCH_STATUS<>0  --库存无记录
        BEGIN
          IF  @dQty<0  GOTO  Error1
          ELSE
          BEGIN
            IF  ((@dTotal = 0) and (@nInputZero = 0)) --入库金额为0，并且不采用0单价入库
            BEGIN
              SELECT  @dTotal = (recprice*@dQty)  FROM  ptype  WHERE  typeid = @szptypeid
              IF  @dTotal = 0  GOTO  errorInputCostPrice
            END
            SELECT  @dPricetemp = @dTotal/@dQty
            SELECT  @dCostTotal = @dTotal
            INSERT  goodsstocks(ptypeid,ktypeid,qty,total,price,GoodsOrder,JobNumber,OutFactoryDate)
            VALUES(@szPtypeid,@szKtypeid,@dQty,@dTotal,@dPricetemp,1,@szBlockNO,@szProdate)--只此一批，ORDER为1
            IF  @@RowCount = 0  GOTO  error44c
	    else select @nGoodsOrderID = @@identity
	 --add by dcsong 2004.8.25 增加写入库存变动表的功能 dlyorder暂填0，等有了后再填
	    	insert into T_GoodsStocksGlide(VchCode,dlyorder,ptypeid,ktypeid,GoodsDate,GoodsOrder,JobNumber,OutFactoryDate,Qty,Price,Total)
	    	values (@nVchCode,0,@szptypeid,@szktypeid,@szBillDate,0,@szBlockno,@szProdate,@dQty,@dPriceTemp,@dTotal)
	    	if @@RowCount = 0  GOTO  error44c
		else select @nGoodsID = @@identity

		insert into t_serial(PTYPEID,GOODSORDERID,KTYPEID,SERIALNO,Memo)
			select PTYPEID,@nGoodsOrderID,@szKTYPEID,SN,Memo from t_bakserial
		where VchCode = @nVchCode and VchLineNO = @oDlyorder 
		if @@error <> 0  GOTO  error44c --改变序列号库存
		
		insert into SN(VCHTYPE,VCHCODE,VchLineNO,PTYPEID,BTYPEID,KTYPEID,ETYPEID,SN,BillDate,GoodsID,Memo)
		select VCHTYPE,@nVchCode,0,PTYPEID,BTYPEID,@szKTYPEID,ETYPEID,SN,BillDate,@nGoodsID,Memo from t_bakserial
		where VchCode = @nVchCode and VchLineNO = @oDlyorder 
		if @@error <> 0  GOTO  error44c --写过帐序列号
	--------------add by dcsong 2004.9.21----------------
            GOTO  CleanUp
          END
        END



      END
      ELSE
      IF  @costmode = @LIFO
      BEGIN
        IF  @dQty = 0  GOTO  Error3


        EXEC  Getdbf  @GOODS_ID,@szPtypeId,'','',@szKtypeId,'','',@dQtytemp  output,@dTotaltemp  output
        IF  (@dQtytemp+@dQty)<0              --负库存
        BEGIN
          RETURN  -1
        END
        SET  @dPriceTemp = @dTotal/@dQty
        IF @dQty<0  AND ((@dTotal<>0) or (@nInputZero = 1)) --金额不为0 或强制出库 
          DECLARE  ModIFyDbf_CURSOR  SCROLL  CURSOR  for
          SELECT  qty,price,total,jobnumber,OutFactoryDate,GoodsOrder,GoodsOrderID  FROM  goodsstocks
          WHERE  ptypeid = @szptypeid  AND  ktypeid = @szktypeid  AND
                              abs(price-@dPriceTemp)< = @DOUBLE_ZERO -- AND  outfactorydate = @szProdate  AND  jobnumber = @szBlockno
          ORDER  BY  GoodsOrder  DESC  FOR  UPDATE
        ELSE
          DECLARE  ModIFyDbf_CURSOR  SCROLL  CURSOR  for
          SELECT  qty,price,total,jobnumber,OutFactoryDate,GoodsOrder,GoodsOrderID  FROM  goodsstocks
          WHERE  ptypeid = @szptypeid  AND  ktypeid = @szktypeid -- AND  outfactorydate = @szProdate  AND  jobnumber = @szBlockno
          ORDER  BY  GoodsOrder  DESC  FOR  UPDATE


        SELECT  @dQtytemp = @dQty,@dTotaltemp = 0
        OPEN  ModIFyDbf_CURSOR
        FETCH  NEXT  FROM  ModIFyDbf_CURSOR  INTO  @dCostQtytemp,@dCostPricetemp,@dCostTotaltemp,
            @szJobNumber,@OutFactoryDate,@nGoodsNoTemp,@nGoodsOrderID

        while  @@FETCH_STATUS = 0
        BEGIN
          IF  @dQty<0
          BEGIN
            SELECT  @dQty = @dCostQtytemp+@dQty
            IF  @dQty< = 0--在这里 = 0出库完毕，<0还要出库
            BEGIN
   	      SELECT  @dTotaltemp = @dTotaltemp-@dCostTotaltemp
              DELETE  FROM  goodsstocks  WHERE  CURRENT  OF  ModIFyDbf_CURSOR
              IF  @@RowCount = 0  GOTO  error44c
	 --add by dcsong 2004.8.25 增加写入库存变动表的功能 dlyorder暂填0，等有了后再填
	      insert into T_GoodsStocksGlide(VchCode,dlyorder,ptypeid,ktypeid,GoodsDate,GoodsOrder,JobNumber,OutFactoryDate,Qty,Price,Total)
	      values (@nVchCode,0,@szptypeid,@szktypeid,@szBillDate,0,@szJobNumber,@OutFactoryDate,-1*@dCostQtytemp,@dCostTotaltemp/@dCostQtytemp,-1*@dCostTotaltemp)
	      if @@RowCount = 0  GOTO  error44c
	      else select @nGoodsID = @@identity 

              IF  @dQty<>0
              BEGIN
                FETCH  NEXT  FROM  ModIFyDbf_CURSOR  INTO  @dCostQtytemp,@dCostPricetemp,@dCostTotaltemp,
                    @szJobNumber,@OutFactoryDate,@nGoodsNoTemp,@nGoodsOrderID
                CONTINUE
              END  ELSE  IF  @dQty = 0
              BEGIN
                SELECT  @dCostTotal = @dTotaltemp
	--------------add by dcsong 2004.9.21----------------------
		delete t_serial from t_bakserial b where b.VchCode = @nVchCode and b.VchLineNO = @oDlyorder
			and b.SN = t_serial.SERIALNO and t_serial.PTYPEID = @szptypeid and t_serial.KTYPEID = @szktypeid --and t_serial.Goodsorderid = @nGoodsorderid
		if @@error <> 0 goto error41 --改变库存序列号

		INSERT into SN(VCHTYPE,VCHCODE,VCHLINENO,PTYPEID,BTYPEID,KTYPEID,ETYPEID,SN,BILLDATE,GOODSID,Memo)
		SELECT VCHTYPE,@NVCHCODE,0,PTYPEID,BTYPEID,@szKTYPEID,ETYPEID,SN,BILLDATE,@nGoodsID,Memo from t_bakserial
		WHERE VCHCODE = @NVCHCODE AND VCHLINENO = @ODLYORDER 
		IF @@error <> 0  GOTO  ERROR44C --写过帐序列号
	--------------add by dcsong 2004.9.21----------------------
                GOTO  CleanUp
              END
            END  ELSE
            BEGIN
	      select  @TotalTemp  = -(@dCostQtytemp-@dQty)*@dCostpricetemp
              SELECT  @dTotaltemp = @dTotaltemp + @TotalTemp   -- -(@dCostQtytemp-@dQty)*@dCostpricetemp
              SELECT  @dCostTotal = @dTotaltemp
              UPDATE  goodsstocks  SET  qty = @dQty,total = total + @TotalTemp  -- @dQty*@dCostPriceTemp
              WHERE  CURRENT  OF  ModIFyDbf_CURSOR
              IF  @@RowCount = 0  GOTO  error44c
	 --add by dcsong 2004.8.25 增加写入库存变动表的功能 dlyorder暂填0，等有了后再填
	      insert into T_GoodsStocksGlide(VchCode,dlyorder,ptypeid,ktypeid,GoodsDate,GoodsOrder,JobNumber,OutFactoryDate,Qty,Price,Total)
	      values (@nVchCode,0,@szptypeid,@szktypeid,@szBillDate,0,@szJobNumber,@OutFactoryDate,(@dQty-@dCostQtytemp),@dCostpricetemp,@TotalTemp)
	      if @@RowCount = 0  GOTO  error44c
		else select @nGoodsID = @@identity 
	--------------add by dcsong 2004.9.21----------------------
		delete t_serial from t_bakserial b where b.VchCode = @nVchCode and b.VchLineNO = @oDlyorder
			and b.SN = t_serial.SERIALNO and t_serial.PTYPEID = @szptypeid and t_serial.KTYPEID = @szktypeid --and t_serial.Goodsorderid = @nGoodsorderid
		if @@error <> 0 goto error41 --改变库存序列号

		INSERT into SN(VCHTYPE,VCHCODE,VCHLINENO,PTYPEID,BTYPEID,KTYPEID,ETYPEID,SN,BILLDATE,GOODSID,Memo)
		SELECT VCHTYPE,@NVCHCODE,0,PTYPEID,BTYPEID,@szKTYPEID,ETYPEID,SN,BILLDATE,@nGoodsID,Memo from t_bakserial
		WHERE VCHCODE = @NVCHCODE AND VCHLINENO = @ODLYORDER 
		IF @@error <> 0  GOTO  ERROR44C --写过帐序列号
	--------------add by dcsong 2004.9.21----------------------

              GOTO  CleanUp
            END
          END  ELSE  --入库
          BEGIN
            IF  ((@dTotal = 0) and (@nInputZero = 0)) --入库金额为0，并且不采用0单价入库
            BEGIN
              SELECT  @dTotal = (recprice*@dQty)  FROM  ptype  WHERE  typeid = @szptypeid
              IF  @dTotal = 0  GOTO  errorInputCostPrice
            END
            SELECT  @dPricetemp = @dTotal/@dQty
            IF    @dPricetemp = @dCostPricetemp

            BEGIN
              SELECT  @dTotaltemp = @dCostTotaltemp+@dTotal
              SELECT  @dQtytemp = @dCostQtytemp+@dQty
              UPDATE  goodsstocks  SET  qty = @dQtytemp,total = @dTotaltemp--,outfactorydate = @szProdate, JobNumber =@szBlockNO
              WHERE  CURRENT  OF  ModIFyDbf_CURSOR
              IF  @@RowCount = 0  GOTO  error44c
	 --add by dcsong 2004.8.25 增加写入库存变动表的功能 dlyorder暂填0，等有了后再填
	      insert into T_GoodsStocksGlide(VchCode,dlyorder,ptypeid,ktypeid,GoodsDate,GoodsOrder,JobNumber,OutFactoryDate,Qty,Price,Total)
	      values (@nVchCode,0,@szptypeid,@szktypeid,@szBillDate,0,@szBlockno,@szProdate,@dQty,@dPricetemp,@dTotal)
	      if @@RowCount = 0  GOTO  error44c
		else select @nGoodsID = @@identity

		insert into t_serial(PTYPEID,GOODSORDERID,KTYPEID,SERIALNO,Memo)
			select PTYPEID,@nGoodsOrderID,@szKTYPEID,SN,Memo from t_bakserial
		where VchCode = @nVchCode and VchLineNO = @oDlyorder 
		if @@error <> 0  GOTO  error44c --改变序列号库存
		
		insert into SN(VCHTYPE,VCHCODE,VchLineNO,PTYPEID,BTYPEID,KTYPEID,ETYPEID,SN,BillDate,GoodsID,Memo)
		select VCHTYPE,@nVchCode,0,PTYPEID,BTYPEID,@szKTYPEID,ETYPEID,SN,BillDate,@nGoodsID,Memo from t_bakserial
		where VchCode = @nVchCode and VchLineNO = @oDlyorder 
		if @@error <> 0  GOTO  error44c --写过帐序列号
	--------------add by dcsong 2004.9.21----------------------

              SELECT  @dCostTotal = @dTotal
              GOTO  CleanUp
            END  ELSE
            BEGIN
              SELECT  @dCostTotal =   @dTotal
              INSERT  goodsstocks(ptypeid,ktypeid,qty,total,price,GoodsOrder,JobNumber,OutFactoryDate)
              VALUES(@szPtypeid,@szKtypeid,@dQty,@dTotal,@dPricetemp,@nGoodsNoTemp+1,@szBlockNO,@szProdate)
              IF  @@RowCount = 0  GOTO  error44c
	 --add by dcsong 2004.8.25 增加写入库存变动表的功能 dlyorder暂填0，等有了后再填
	      insert into T_GoodsStocksGlide(VchCode,dlyorder,ptypeid,ktypeid,GoodsDate,GoodsOrder,JobNumber,OutFactoryDate,Qty,Price,Total)
	      values (@nVchCode,0,@szptypeid,@szktypeid,@szBillDate,0,@szBlockno,@szProdate,@dQty,@dPricetemp,@dTotal)
	      if @@RowCount = 0  GOTO  error44c
		else select @nGoodsID = @@identity

		insert into t_serial(PTYPEID,GOODSORDERID,KTYPEID,SERIALNO,Memo)
			select PTYPEID,@nGoodsOrderID,@szKTYPEID,SN,Memo from t_bakserial
		where VchCode = @nVchCode and VchLineNO = @oDlyorder 
		if @@error <> 0  GOTO  error44c --改变序列号库存
		
		insert into SN(VCHTYPE,VCHCODE,VchLineNO,PTYPEID,BTYPEID,KTYPEID,ETYPEID,SN,BillDate,GoodsID,Memo)
		select VCHTYPE,@nVchCode,0,PTYPEID,BTYPEID,@szKTYPEID,ETYPEID,SN,BillDate,@nGoodsID,Memo from t_bakserial
		where VchCode = @nVchCode and VchLineNO = @oDlyorder 
		if @@error <> 0  GOTO  error44c --写过帐序列号
	--------------add by dcsong 2004.9.21----------------

              GOTO  CleanUp
            END
          END
        END
        IF  @@FETCH_STATUS<>0
        BEGIN
          IF  @dQty<0  GOTO  Error1
          ELSE
          BEGIN
            IF  ((@dTotal = 0) and (@nInputZero = 0)) --入库金额为0，并且不采用0单价入库
            BEGIN
              SELECT  @dTotal = (recprice*@dQty)  FROM  ptype  WHERE  typeid = @szptypeid
              IF  @dTotal = 0  GOTO  errorInputCostPrice
            END
            SELECT  @dPricetemp = @dTotal/@dQty
            SELECT  @dCosttotal = @dTotal
            INSERT  goodsstocks(ptypeid,ktypeid,qty,total,price,GoodsOrder,JobNumber,OutFactoryDate)
            VALUES(@szPtypeid,@szKtypeid,@dQty,@dTotal,@dPricetemp,1,@szBlockNO,@szProdate)
            IF  @@RowCount = 0  GOTO  error44c
	    else select @nGoodsOrderID = @@identity
	 --add by dcsong 2004.8.25 增加写入库存变动表的功能 dlyorder暂填0，等有了后再填
	    	insert into T_GoodsStocksGlide(VchCode,dlyorder,ptypeid,ktypeid,GoodsDate,GoodsOrder,JobNumber,OutFactoryDate,Qty,Price,Total)
	    	values (@nVchCode,0,@szptypeid,@szktypeid,@szBillDate,0,@szBlockno,@szProdate,@dQty,@dPriceTemp,@dTotal)
	    	if @@RowCount = 0  GOTO  error44c
		else select @nGoodsID = @@identity

		insert into t_serial(PTYPEID,GOODSORDERID,KTYPEID,SERIALNO,Memo)
			select PTYPEID,@nGoodsOrderID,@szKTYPEID,SN,Memo from t_bakserial
		where VchCode = @nVchCode and VchLineNO = @oDlyorder 
		if @@error <> 0  GOTO  error44c --改变序列号库存
		
		insert into SN(VCHTYPE,VCHCODE,VchLineNO,PTYPEID,BTYPEID,KTYPEID,ETYPEID,SN,BillDate,GoodsID,Memo)
		select VCHTYPE,@nVchCode,0,PTYPEID,BTYPEID,@szKTYPEID,ETYPEID,SN,BillDate,@nGoodsID,Memo from t_bakserial
		where VchCode = @nVchCode and VchLineNO = @oDlyorder 
		if @@error <> 0  GOTO  error44c --写过帐序列号
	--------------add by dcsong 2004.9.21----------------

            GOTO  CleanUp
          END
        END
      END
      ELSE
      IF  @costmode = @HAND
      BEGIN
        update goodsstocks set price=total/qty where qty<>0 and ptypeid = @szptypeid  AND  ktypeid = @szktypeid --解决手工指定法单价太小，造成误差太大的问题 dcsong modi by 2004.7.19
        IF  @dQty = 0  GOTO  Error3
        IF  @dQty<0
        BEGIN
          SET  @dPriceTemp = @dCostTotal--@dTotal/@dQty

          DECLARE  ModIFyDbf_CURSOR  SCROLL  CURSOR  for
          SELECT  qty,price,total,jobnumber,OutFactoryDate,GoodsOrder,GoodsOrderID  FROM  goodsstocks
          WHERE  ptypeid = @szptypeid  AND  ktypeid = @szktypeid
        AND  abs(price-@dPriceTemp)< = @DOUBLE_ZERO  
	--AND  @nGoodsNO=GoodsOrder 
	AND outfactorydate = @szProdate  
        AND  jobnumber = @szBlockno

          ORDER  BY  qty  DESC  FOR  UPDATE  --如果有两个批次完全相同，则先出数量大的那个
        END  ELSE
        BEGIN
          IF  ((@dTotal = 0) and (@nInputZero = 0)) --入库金额为0，并且不采用0单价入库
          BEGIN
            SELECT  @dTotal = (recprice*@dQty)  FROM  ptype  WHERE  typeid = @szptypeid
            IF  @dTotal = 0  RETURN  -5      --GOTO  errorInputCostPrice
          END
          SELECT  @dPricetemp = @dTotal/@dQty
          DECLARE  ModIFyDbf_CURSOR  SCROLL  CURSOR  for
          SELECT  qty,price,total,jobnumber,OutFactoryDate,GoodsOrder,GoodsOrderID  FROM  goodsstocks
          WHERE  ptypeid = @szptypeid  AND  ktypeid = @szktypeid  AND  JobNumber = @szBlockno  AND  price = @dPricetemp  AND  OutFactoryDate = @szProdate
          ORDER  BY  GoodsOrder  DESC  FOR  UPDATE
        END



        OPEN  ModIFyDbf_CURSOR
        FETCH  NEXT  FROM  ModIFyDbf_CURSOR  INTO  @dCostQtytemp,@dCostPricetemp,@dCostTotaltemp,
            @szJobNumber,@OutFactoryDate,@nGoodsNoTemp,@nGoodsOrderID
        IF  @@FETCH_STATUS = 0
        BEGIN
          IF  @dQty<0  --出库
	  BEGIN
            IF  @dCostQtytemp<abs(@dQty)  GOTO  Error1  --数量不够，返回错误
            IF  @dCostQtytemp = abs(@dQty)    --数量相同
            BEGIN
              DELETE  FROM  goodsstocks  WHERE  CURRENT  OF  ModIFyDbf_CURSOR
              IF  @@RowCount = 0  GOTO  error44c
	 --add by dcsong 2004.8.25 增加写入库存变动表的功能 dlyorder暂填0，等有了后再填
	    	insert into T_GoodsStocksGlide(VchCode,dlyorder,ptypeid,ktypeid,GoodsDate,GoodsOrder,JobNumber,OutFactoryDate,Qty,Price,Total)
	    	values (@nVchCode,0,@szptypeid,@szktypeid,@szBillDate,0,@szBlockno,@szProdate,@dQty,@dPricetemp,@dTotal)
	    	if @@RowCount = 0  GOTO  error44c
	      	else select @nGoodsID = @@identity 
	--------------add by dcsong 2004.9.21----------------------
		delete t_serial from t_bakserial b where b.VchCode = @nVchCode and b.VchLineNO = @oDlyorder
			and b.SN = t_serial.SERIALNO and t_serial.PTYPEID = @szptypeid and t_serial.KTYPEID = @szktypeid --and t_serial.Goodsorderid = @nGoodsorderid
		if @@error <> 0 goto error41 --改变库存序列号

		INSERT into SN(VCHTYPE,VCHCODE,VCHLINENO,PTYPEID,BTYPEID,KTYPEID,ETYPEID,SN,BILLDATE,GOODSID,Memo)
		SELECT VCHTYPE,@NVCHCODE,0,PTYPEID,BTYPEID,@szKTYPEID,ETYPEID,SN,BILLDATE,@nGoodsID,Memo from t_bakserial
		WHERE VCHCODE = @NVCHCODE AND VCHLINENO = @ODLYORDER 
		IF @@error <> 0  GOTO  ERROR44C --写过帐序列号
	--------------add by dcsong 2004.9.21----------------------

              SELECT  @dCostTotal = -@dCostTotaltemp
              GOTO  CleanUp
            END  
	    ELSE               --出库数量少于库存数量
            BEGIN
              SELECT  @dCostTotaltemp = @dCostTotaltemp+@dQty*@dCostPricetemp
              SELECT  @dQtytemp = @dCostQtytemp+@dQty
              UPDATE  goodsstocks  SET  total = @dCostTotaltemp,qty = @dQtytemp
              WHERE  CURRENT  OF  ModIFyDbf_CURSOR
              IF  @@RowCount = 0  GOTO  error44c
	 --add by dcsong 2004.8.25 增加写入库存变动表的功能 dlyorder暂填0，等有了后再填
	    	insert into T_GoodsStocksGlide(VchCode,dlyorder,ptypeid,ktypeid,GoodsDate,GoodsOrder,JobNumber,OutFactoryDate,Qty,Price,Total)
	    	values (@nVchCode,0,@szptypeid,@szktypeid,@szBillDate,0,@szBlockno,@szProdate,@dQty,@dCostPricetemp,@dQty*@dCostPricetemp)
	    	if @@RowCount = 0  GOTO  error44c
	      	else select @nGoodsID = @@identity 
	--------------add by dcsong 2004.9.21----------------------
		delete t_serial from t_bakserial b where b.VchCode = @nVchCode and b.VchLineNO = @oDlyorder
			and b.SN = t_serial.SERIALNO and t_serial.PTYPEID = @szptypeid and t_serial.KTYPEID = @szktypeid --and t_serial.Goodsorderid = @nGoodsorderid
		if @@error <> 0 goto error41 --改变库存序列号

		INSERT into SN(VCHTYPE,VCHCODE,VCHLINENO,PTYPEID,BTYPEID,KTYPEID,ETYPEID,SN,BILLDATE,GOODSID,Memo)
		SELECT VCHTYPE,@NVCHCODE,0,PTYPEID,BTYPEID,@szKTYPEID,ETYPEID,SN,BILLDATE,@nGoodsID,Memo from t_bakserial
		WHERE VCHCODE = @NVCHCODE AND VCHLINENO = @ODLYORDER 
		IF @@error <> 0  GOTO  ERROR44C --写过帐序列号
	--------------add by dcsong 2004.9.21----------------------

              SELECT  @dCostTotal = @dQty*@dCostPricetemp
              GOTO  CleanUp
            END
          END  
	  ELSE   --有指定批次入库
          BEGIN
            SELECT  @dTotaltemp = @dCostTotaltemp+@dTotal
            SELECT  @dQtytemp = @dCostQtytemp+@dQty
            UPDATE  goodsstocks  SET  qty = @dQtytemp,total = @dTotaltemp
            WHERE  CURRENT  OF  ModIFyDbf_CURSOR
            IF  @@RowCount = 0  GOTO  error44c
	 --add by dcsong 2004.8.25 增加写入库存变动表的功能 dlyorder暂填0，等有了后再填
	    	insert into T_GoodsStocksGlide(VchCode,dlyorder,ptypeid,ktypeid,GoodsDate,GoodsOrder,JobNumber,OutFactoryDate,Qty,Price,Total)
	    	values (@nVchCode,0,@szptypeid,@szktypeid,@szBillDate,0,@szBlockno,@szProdate,@dQty,@dPricetemp,@dTotal)
	    	if @@RowCount = 0  GOTO  error44c
		else select @nGoodsID = @@identity

		insert into t_serial(PTYPEID,GOODSORDERID,KTYPEID,SERIALNO,Memo)
			select PTYPEID,@nGoodsOrderID,@szKTYPEID,SN,Memo from t_bakserial
		where VchCode = @nVchCode and VchLineNO = @oDlyorder 
		if @@error <> 0  GOTO  error44c --改变序列号库存
		
		insert into SN(VCHTYPE,VCHCODE,VchLineNO,PTYPEID,BTYPEID,KTYPEID,ETYPEID,SN,BillDate,GoodsID,Memo)
		select VCHTYPE,@nVchCode,0,PTYPEID,BTYPEID,@szKTYPEID,ETYPEID,SN,BillDate,@nGoodsID,Memo from t_bakserial
		where VchCode = @nVchCode and VchLineNO = @oDlyorder 
		if @@error <> 0  GOTO  error44c --写过帐序列号
	--------------add by dcsong 2004.9.21----------------------

            SELECT  @dCostTotal = @dTotal
            GOTO  CleanUp
          END
        END  
	ELSE  --无该批次入库
        BEGIN
          IF  @dQty<0  GOTO  Error1
          ELSE
          BEGIN
            IF  ((@dTotal = 0) and (@nInputZero = 0)) --入库金额为0，并且不采用0单价入库
            BEGIN
              SELECT  @dTotal = (recprice*@dQty)  FROM  ptype  WHERE  typeid = @szptypeid
              IF  @dTotal = 0  GOTO  errorInputCostPrice
            END
            SELECT  @nGoodsNoTemp = isnull(max(goodsorder),0)  FROM  goodsstocks  WHERE  ptypeid = @szptypeid  AND  ktypeid = @szktypeid
            SELECT  @dPricetemp = @dTotal/@dQty
            SELECT  @dCostTotal = @dTotal
            INSERT  goodsstocks(ptypeid,ktypeid,qty,total,price,JobNumber,GoodsOrder,OutFactoryDate)
            VALUES(@szPtypeid,@szKtypeid,@dQty,@dTotal,@dPricetemp,@szBlockno,@nGoodsNoTemp+1,@szProdate)
            	IF  @@RowCount = 0  GOTO  error44c
		else select @nGoodsOrderID = @@identity
	 --add by dcsong 2004.8.25 增加写入库存变动表的功能 dlyorder暂填0，等有了后再填
	    	insert into T_GoodsStocksGlide(VchCode,dlyorder,ptypeid,ktypeid,GoodsDate,GoodsOrder,JobNumber,OutFactoryDate,Qty,Price,Total)
	    	values (@nVchCode,0,@szptypeid,@szktypeid,@szBillDate,0,@szBlockno,@szProdate,@dQty,@dPricetemp,@dTotal)
	    	if @@RowCount = 0  GOTO  error44c
		else select @nGoodsID = @@identity

		insert into t_serial(PTYPEID,GOODSORDERID,KTYPEID,SERIALNO,Memo)
			select PTYPEID,@nGoodsOrderID,@szKTYPEID,SN,Memo from t_bakserial
		where VchCode = @nVchCode and VchLineNO = @oDlyorder 
		if @@error <> 0  GOTO  error44c --改变序列号库存
		
		insert into SN(VCHTYPE,VCHCODE,VchLineNO,PTYPEID,BTYPEID,KTYPEID,ETYPEID,SN,BillDate,GoodsID,Memo)
		select VCHTYPE,@nVchCode,0,PTYPEID,BTYPEID,@szKTYPEID,ETYPEID,SN,BillDate,@nGoodsID,Memo from t_bakserial
		where VchCode = @nVchCode and VchLineNO = @oDlyorder 
		if @@error <> 0  GOTO  error44c --写过帐序列号
	--------------add by dcsong 2004.9.21----------------------

            GOTO  CleanUp
          END
        END
      END
    END
    ELSE
    BEGIN              /*---------------------修改期初--------------------*/
      IF  @costmode = @AVERAGE
      BEGIN
        DECLARE  ModIFyDbf_CURSOR  CURSOR  for
        SELECT  qty,price,total,jobnumber,OutFactoryDate,GoodsOrder  FROM  inigoodsstocks
        WHERE  ptypeid = @szptypeid  AND  ktypeid = @szktypeid
        FOR  UPDATE

        OPEN  ModIFyDbf_CURSOR
        FETCH  NEXT  FROM  ModIFyDbf_CURSOR  INTO  @dCostQtytemp,@dCostPricetemp,@dCostTotaltemp,
            @szJobNumber,@OutFactoryDate,@nGoodsNoTemp
        IF  @@FETCH_STATUS = 0
        BEGIN
          IF  @dQty<0
          BEGIN
            IF  @dCostQtytemp<abs(@dQty  )  GOTO  Error1
            IF  @dCostQtytemp = abs(@dQty  )
            BEGIN
              DELETE  FROM  inigoodsstocks    WHERE  CURRENT  OF  ModIFyDbf_CURSOR
              IF  @@RowCount = 0  GOTO  error44c

              SELECT  @dCostTotal = -@dCostTotaltemp
              GOTO  CleanUp
            END  ELSE
            BEGIN
              SELECT  @dTotaltemp = @dTotaltemp+@dCostTotaltemp
              SELECT  @dQtytemp = @dCostQtytemp+@dQty
              UPDATE  inigoodsstocks    SET  total = @dTotaltemp,qty = @dQtytemp
              WHERE  CURRENT  OF  ModIFyDbf_CURSOR
              IF  @@RowCount = 0  GOTO  error44c
              SELECT  @dCosttotal = @dQty*@dCostPricetemp
              GOTO  CleanUp
            END
          END  ELSE
          BEGIN
            SELECT  @dCostTotaltemp = @dCostTotaltemp+@dTotal
            SELECT  @dQtytemp = @dCostQtytemp+@dQty
            SELECT  @dCostPricetemp = @dCostTotaltemp/@dQtytemp
            UPDATE  inigoodsstocks    SET  total = @dCostTotaltemp,qty = @dQtytemp,price = @dCostPricetemp,outfactorydate = @szProdate

            WHERE  CURRENT  OF  ModIFyDbf_CURSOR
            IF  @@RowCount = 0  GOTO  error44c
            SELECT  @dCostTotal = @dTotal
            GOTO  CleanUp
          END
        END  ELSE
        BEGIN
          IF  @dQty< = 0  GOTO  Error1
          SELECT  @dCostPricetemp = @dTotal/@dQty
          INSERT  inigoodsstocks(ptypeid,ktypeid,qty,total,price,OutFactoryDate)
          VALUES(@szPtypeid,@szKtypeid,@dQty,@dTotal,@dCostPricetemp,@szProdate)
          IF  @@RowCount = 0  GOTO  error44c
          SELECT  @dCostTotal = @dTotal
          GOTO  CleanUp
        END
      END
      ELSE
      IF  @costmode = @FIFO
      BEGIN
        IF  @dQty = 0  GOTO  Error3

        EXEC  Getdbf  @GOODS_ID,@szPtypeId,'','',@szKtypeId,'00','',@dQtytemp  output,@dTotaltemp  output
        IF  (@dQtytemp+@dQty)<0
        BEGIN
          RETURN  -1
        END

        IF  @dQty<0
        BEGIN
          DECLARE  ModIFyDbf_CURSOR  SCROLL  CURSOR  for
          SELECT  qty,price,total,jobnumber,OutFactoryDate,GoodsOrder  FROM  inigoodsstocks
          WHERE  ptypeid = @szptypeid  AND  ktypeid = @szktypeid -- AND  outfactorydate = @szProdate  AND  jobnumber = @szBlockno
          ORDER  BY  GoodsOrder  asc  FOR  UPDATE

        END
        ELSE
        BEGIN
          DECLARE  ModIFyDbf_CURSOR    SCROLL  CURSOR  for

          SELECT  qty,price,total,jobnumber,OutFactoryDate,GoodsOrder  FROM  inigoodsstocks
          WHERE  ptypeid = @szptypeid  AND  ktypeid = @szktypeid  AND  outfactorydate = @szProdate  AND  jobnumber = @szBlockno
          ORDER  BY  GoodsOrder  DESC  FOR  UPDATE
        END
        SELECT  @dQtytemp = @dQty,@dTotaltemp = 0
        OPEN  ModIFyDbf_CURSOR
        FETCH  NEXT  FROM  ModIFyDbf_CURSOR  INTO  @dCostQtytemp,@dCostPricetemp,@dCostTotaltemp,
            @szJobNumber,@OutFactoryDate,@nGoodsNoTemp
        while  @@FETCH_STATUS = 0
        BEGIN
          IF  @dQty<0
          BEGIN
            SELECT  @dQty = @dCostQtytemp+@dQty
            IF  @dQty< = 0
            BEGIN
              SELECT  @dTotaltemp = @dTotaltemp-@dCostTotaltemp
              DELETE  FROM  inigoodsstocks    WHERE  CURRENT  OF  ModIFyDbf_CURSOR
              IF  @@RowCount = 0  GOTO  error44c
              IF  @dQty<>0
              BEGIN
                FETCH  NEXT  FROM  ModIFyDbf_CURSOR  INTO  @dCostQtytemp,@dCostPricetemp,@dCostTotaltemp,
                    @szJobNumber,@OutFactoryDate,@nGoodsNoTemp
                CONTINUE
              END  ELSE  IF  @dQty = 0

              BEGIN
                SELECT  @dCostTotal = @dTotaltemp
                GOTO  CleanUp
              END
            END  ELSE
            BEGIN
              SELECT  @dTotaltemp = @dTotaltemp+(@dCostQtytemp-@dQty)*@dCostpricetemp
              SELECT  @dCostTotal = @dTotaltemp
              UPDATE  inigoodsstocks    SET  qty = @dQty,total = @dQty*@dCostPricetemp
              WHERE  CURRENT  OF  ModIFyDbf_CURSOR
              IF  @@RowCount = 0  GOTO  error44c
              GOTO  CleanUp
            END
          END  ELSE
          BEGIN
            SELECT  @dPricetemp = @dTotal/@dQty
            IF    @dPricetemp = @dCostPricetemp
            BEGIN
              SELECT  @dTotaltemp = @dCostTotaltemp+@dTotal
              SELECT  @dQtytemp = @dCostQtytemp+@dQty
              UPDATE  inigoodsstocks    SET  qty = @dQtytemp,total = @dTotaltemp,outfactorydate = @szProdate, jobnumber = @szBlockno
              WHERE  CURRENT  OF  ModIFyDbf_CURSOR
              IF  @@RowCount = 0  GOTO  error44c
              SELECT  @dCostTotal = @dTotal
              GOTO  CleanUp
            END  ELSE
            BEGIN
              SELECT  @dCostTotal = @dTotal
              INSERT  inigoodsstocks  (ptypeid,ktypeid,qty,total,price,GoodsOrder,JobNumber,OutFactoryDate)
              VALUES(@szPtypeid,@szKtypeid,@dQty,@dTotal,@dPricetemp,@nGoodsNoTemp+1,@szBlockno,@szProdate)
              IF  @@RowCount = 0  GOTO  error44c
              GOTO  CleanUp
            END
          END
        END
        IF  @@FETCH_STATUS<>0
        BEGIN
          IF  @dQty<0  GOTO  Error1
          ELSE
          BEGIN
            SELECT  @dPricetemp = @dTotal/@dQty
            SELECT  @dCostTotal = @dTotal
            INSERT  inigoodsstocks  (ptypeid,ktypeid,qty,total,price,GoodsOrder,JobNumber,OutFactoryDate)
            VALUES(@szPtypeid,@szKtypeid,@dQty,@dTotal,@dPricetemp,1,@szBlockno,@szProdate)
            IF  @@RowCount = 0  GOTO  error44c
            GOTO  CleanUp
          END
        END
      END
      ELSE
      IF  @costmode = @LIFO
      BEGIN
        IF  @dQty = 0  GOTO  Error3

        EXEC  Getdbf  @GOODS_ID,@szPtypeId,'','',@szKtypeId,'00','',@dQtytemp  output,@dTotaltemp  output
        IF  (@dQtytemp+@dQty)<0
        BEGIN
          RETURN  -1
        END
        SELECT  @dQtytemp = @dQty,@dTotaltemp = 0

        DECLARE  ModIFyDbf_CURSOR  SCROLL  CURSOR  for
        SELECT  qty,price,total,jobnumber,OutFactoryDate,GoodsOrder  FROM  inigoodsstocks
        WHERE  ptypeid = @szptypeid  AND  ktypeid = @szktypeid  AND  outfactorydate = @szProdate  AND  jobnumber = @szBlockno
        ORDER  BY  GoodsOrder  DESC  FOR  UPDATE

        OPEN  ModIFyDbf_CURSOR
        FETCH  NEXT  FROM  ModIFyDbf_CURSOR  INTO  @dCostQtytemp,@dCostPricetemp,@dCostTotaltemp,
            @szJobNumber,@OutFactoryDate,@nGoodsNoTemp
        while  @@FETCH_STATUS = 0
        BEGIN
          IF  @dQty<0
          BEGIN
            SELECT  @dQty = @dCostQtytemp+@dQty
            IF  @dQty< = 0
            BEGIN
              SELECT  @dTotaltemp = @dTotaltemp+@dCostTotaltemp
              DELETE  FROM  inigoodsstocks    WHERE  CURRENT  OF  ModIFyDbf_CURSOR
              IF  @@RowCount = 0  GOTO  error44c
              IF  @dQty<>0
              BEGIN
                FETCH  NEXT  FROM  ModIFyDbf_CURSOR  INTO  @dCostQtytemp,@dCostPricetemp,@dCostTotaltemp,
                    @szJobNumber,@OutFactoryDate,@nGoodsNoTemp
                CONTINUE
              END  ELSE  IF  @dQty = 0
              BEGIN
                SELECT  @dCostTotal = @dTotaltemp
                GOTO  CleanUp
              END
            END  ELSE
            BEGIN
              SELECT  @dTotaltemp = @dTotaltemp+(@dCostQtytemp-@dQty)*@dCostpricetemp
              SELECT  @dCostTotal = @dTotaltemp
              UPDATE  inigoodsstocks    SET  qty = @dQty,total = @dQty*@dCostPricetemp
              WHERE  CURRENT  OF  ModIFyDbf_CURSOR
              IF  @@RowCount = 0  GOTO  error44c
              GOTO  CleanUp
            END
          END  ELSE
          BEGIN
            SELECT  @dPricetemp = @dTotal/@dQty  --期初必然有金额
            IF    @dPricetemp = @dCostPricetemp
            BEGIN


              SELECT  @dTotaltemp = @dCostTotaltemp+@dTotal
              SELECT  @dQtytemp = @dCostQtytemp+@dQty
              UPDATE  inigoodsstocks    SET  qty = @dQtytemp,total = @dTotaltemp,outfactorydate = @szProdate, jobnumber = @szBlockno

              WHERE  CURRENT  OF  ModIFyDbf_CURSOR
              IF  @@RowCount = 0  GOTO  error44c
              SELECT  @dCostTotal = @dTotal
              GOTO  CleanUp
            END  ELSE
            BEGIN
              SELECT  @dCostTotal =   @dTotal
              INSERT  inigoodsstocks  (ptypeid,ktypeid,qty,total,price,GoodsOrder,JobNumber,OutFactoryDate)
              VALUES(@szPtypeid,@szKtypeid,@dQty,@dTotal,@dPricetemp,@nGoodsNoTemp+1,@szBlockno,@szProdate)
              IF  @@RowCount = 0  GOTO  error44c
              GOTO  CleanUp
            END
          END
        END
        IF  @@FETCH_STATUS<>0
        BEGIN
          IF  @dQty<0  GOTO  Error1
          ELSE
          BEGIN
            SELECT  @dPricetemp = @dTotal/@dQty
            SELECT  @dCostTotal = @dTotal
            INSERT  inigoodsstocks  (ptypeid,ktypeid,qty,total,price,GoodsOrder,JobNumber,OutFactoryDate)
            VALUES(@szPtypeid,@szKtypeid,@dQty,@dTotal,@dPricetemp,0,@szBlockno,@szProdate)
            IF  @@RowCount = 0  GOTO  error44c
            GOTO  CleanUp
          END
        END
      END
      ELSE
      IF  @costmode = @HAND
      BEGIN
        IF  @dQty = 0  GOTO  Error3

        IF  @dQty<0
        BEGIN
          DECLARE  ModIFyDbf_CURSOR  SCROLL  CURSOR  for
          SELECT  qty,price,total,jobnumber,OutFactoryDate,GoodsOrder  FROM  inigoodsstocks
          WHERE  ptypeid = @szptypeid  AND  ktypeid = @szktypeid  AND  Goodsorder = @nGoodsNo
          ORDER  BY  GoodsOrder  DESC  FOR  UPDATE
        END  ELSE
        BEGIN
          SELECT  @dPricetemp = @dTotal/@dQty
          DECLARE  ModIFyDbf_CURSOR  SCROLL  CURSOR  for
          SELECT  qty,price,total,jobnumber,OutFactoryDate,GoodsOrder  FROM  inigoodsstocks
          WHERE  ptypeid = @szptypeid  AND  ktypeid = @szktypeid  AND  JobNumber = @szBlockno  AND  price = @dPricetemp  AND  OutFactoryDate = @szProdate
          ORDER  BY  GoodsOrder  DESC  FOR  UPDATE

        END
        OPEN  ModIFyDbf_CURSOR
        FETCH  NEXT  FROM  ModIFyDbf_CURSOR  INTO  @dCostQtytemp,@dCostPricetemp,@dCostTotaltemp,
            @szJobNumber,@OutFactoryDate,@nGoodsNoTemp
        IF  @@FETCH_STATUS = 0
        BEGIN
          IF  @dQty<0
          BEGIN
            IF  @dCostQtytemp<abs(@dQty)  GOTO  Error1
            IF  @dCostQtytemp = abs(@dQty)
            BEGIN
              DELETE  FROM  inigoodsstocks    WHERE  CURRENT  OF  ModIFyDbf_CURSOR
              IF  @@RowCount = 0  GOTO  error44c
              SELECT  @dCostTotal = @dCostTotaltemp
              GOTO  CleanUp
            END  ELSE
            BEGIN
              SELECT  @dCostTotaltemp = @dCostTotaltemp+@dQty*@dCostPricetemp
              SELECT  @dQtytemp = @dCostQtytemp+@dQty
              UPDATE  inigoodsstocks    SET  total = @dCostTotaltemp,qty = @dQtytemp
              WHERE  CURRENT  OF  ModIFyDbf_CURSOR
              IF  @@RowCount = 0  GOTO  error44c
              SELECT  @dCostTotal = @dQty*@dCostPricetemp
              GOTO  CleanUp
            END
          END  ELSE
          BEGIN
            SELECT  @dTotaltemp = @dCostTotaltemp+@dTotal
            SELECT  @dQtytemp = @dCostQtytemp+@dQty
            UPDATE  inigoodsstocks    SET  qty = @dQtytemp,total = @dTotaltemp,outfactorydate = @szProdate, jobnumber = @szBlockno
            WHERE  CURRENT  OF  ModIFyDbf_CURSOR
            IF  @@RowCount = 0  GOTO  error44c
            SELECT  @dCosttotal = @dTotal
            GOTO  CleanUp
          END
        END  ELSE
        BEGIN
          IF  @dQty<0  GOTO  Error1
          ELSE
          BEGIN
            SELECT  @nGoodsNoTemp = isnull(max(goodsorder),0)  FROM  inigoodsstocks    WHERE  ptypeid = @szptypeid  AND  ktypeid = @szktypeid
            SELECT  @dPricetemp = @dTotal/@dQty
            SELECT  @dCosttotal = @dTotal
            INSERT  inigoodsstocks(ptypeid,ktypeid,qty,total,price,JobNumber,GoodsOrder,OutFactoryDate)
            VALUES(@szPtypeid,@szKtypeid,@dQty,@dTotal,@dPricetemp,@szBlockno,@nGoodsNoTemp+1,@szProdate)
            IF  @@RowCount = 0  GOTO  error44c
            GOTO  CleanUp
          END
        END
      END
    END
  END
  ELSE  IF  @szatypeid = @AR_ID          --应收
  BEGIN
    IF  @szperiod<>'00'
    BEGIN
      EXEC      Getdbf  @AR_ID,'',@szBtypeId,'','','','',@dQtyTemp  output,@dTotaltemp  output
      EXEC      Getdbf  @AP_ID,'',@szBtypeId,'','','','',@dQtyTemp  output,@dCostTotaltemp  output
      SELECT  @dTotaltemp = @dTotaltemp+@dTotal-@dCostTotalTemp
      IF  @dTotalTemp>0  UPDATE  btype  SET  artotal = @dTotaltemp,aptotal = 0    WHERE  typeid = @szBtypeid
      ELSE  UPDATE  btype  SET  artotal = 0,aptotal = -@dTotaltemp    WHERE  typeid = @szBtypeid
      IF  @@rowcount = 0  GOTO  error42  ELSE  GOTO  success
    END  ELSE
    BEGIN
      EXEC      Getdbf  @AR_ID,'',@szBtypeId,'','','00','',@dQtyTemp  output,@dTotaltemp  output
      SELECT  @dTotaltemp = @dTotaltemp+@dTotal
      UPDATE  btype  SET  artotal00 = @dTotaltemp  WHERE  typeid = @szBtypeid
      IF  @@rowcount = 0  GOTO  error42  ELSE  GOTO  success

    END
  END
  ELSE  IF  @szatypeid = @AP_ID        --应付
  BEGIN
    IF  @szperiod<>'00'
    BEGIN
      EXEC      Getdbf  @AP_ID,'',@szBtypeId,'','','','',@dQtyTemp  output,@dTotaltemp  output
      EXEC      Getdbf  @AR_ID,'',@szBtypeId,'','','','',@dQtyTemp  output,@dCostTotaltemp  output
      SELECT  @dTotaltemp = @dTotaltemp+@dTotal-@dCostTotalTemp
      IF  @dTotalTemp>0  UPDATE  btype  SET  aptotal = @dTotaltemp,artotal = 0    WHERE  typeid = @szBtypeid
      ELSE  UPDATE  btype  SET  aptotal = 0,artotal = -@dTotaltemp    WHERE  typeid = @szBtypeid
      IF  @@rowcount = 0  GOTO  error41  ELSE  GOTO  success
    END  ELSE
    BEGIN
      EXEC      Getdbf  @AP_ID,'',@szBtypeId,'','','00','',@dQtyTemp  output,@dTotaltemp  output
      SELECT  @dTotaltemp = @dTotaltemp+@dTotal
      UPDATE  btype  SET  aptotal00 = @dTotaltemp  WHERE  typeid = @szBtypeid
      IF  @@rowcount = 0  GOTO  error41  ELSE  GOTO  success
    END
  END
  ELSE                    --一般科目
  BEGIN
    IF  @szperiod<>'00'
    BEGIN
      EXEC      Getdbf  @szAtypeid,'','','','','','',@dQtyTemp  output,@dTotaltemp  output
      SELECT  @dTotaltemp = @dTotaltemp+@dTotal
      UPDATE  atype  SET  total = @dTotaltemp  WHERE  typeid = @szAtypeid
      IF  @@rowcount = 0  GOTO  error43  ELSE  GOTO  success
    END  ELSE
    BEGIN
      EXEC      Getdbf  @szAtypeid,'','','','','00','',@dQtyTemp  output,@dTotaltemp  output
      SELECT  @dTotaltemp = @dTotaltemp+@dTotal
      UPDATE  atype  SET  TTL00 = @dTotaltemp  WHERE  typeid = @szAtypeid
      IF  @@rowcount = 0  GOTO  error43  ELSE  GOTO  success
    END
  END

CleanUp:
          deallocate    ModIFyDbf_CURSOR
  RETURN  0

Error1:
  deallocate    ModIFyDbf_CURSOR
  RETURN  -1

Error2:
  deallocate    ModIFyDbf_CURSOR
  RETURN  -2

Error44c:
  deallocate    ModIFyDbf_CURSOR
  RETURN  -44


Error3:
  RETURN  -3

Error41:
  RETURN  -41

Error42:
  RETURN  -42

Error43:
  RETURN  -43

error51:  
  RETURN  -51


error52:  
  RETURN  -52

error53:  
  RETURN  -53

Error54:
  RETURN  -54

errorInputCostPrice:
  deallocate  ModIFyDbf_CURSOR
  RETURN  -5

Success:
  RETURN  0

