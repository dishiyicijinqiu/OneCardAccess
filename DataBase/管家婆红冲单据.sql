USE [GJPTest2]
GO
/****** 对象:  StoredProcedure [dbo].[Z_CreateRed]    脚本日期: 11/20/2015 09:21:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO



--红字反冲
-- 返回  -9  数据库操作失败
--	 -1  库存数量不够
--	 -14 过帐日期小于本月的起始日期
--	-16  已经红冲

ALTER          PROCEDURE [dbo].[Z_CreateRed]
(
	@nVchcode numeric(10, 0),
	@szptypeido varchar(25) output,
	@szbtypeido varchar(25) output,
	@szatypeido varchar(25) output,
	@szktypeido varchar(25) output
)
AS
--	set nocount off



	declare @GOODS_ID varchar(25),
		@LENDOUT_STOCK varchar(25),
		@BORROWIN_STOCK varchar(25)

	declare @SEND_GOODS_STOCK_ID varchar(25),
		@COMMISSION_STOCK_ID varchar(25),
		@RECOMMISSION_STOCK_ID varchar(25)

	select @SEND_GOODS_STOCK_ID='9999900001'
	select @COMMISSION_STOCK_ID='9999900002'
	select @RECOMMISSION_STOCK_ID='9999900003'

	select @GOODS_ID='0000100001'
	select @LENDOUT_STOCK ='9999999999'
	select @BORROWIN_STOCK ='9999999998'

	declare @tDate varchar(10), @nCostMode int

	declare @nVchType numeric(4, 0),@szAtypeId varchar(25),@szPtypeId varchar(25),@szbTypeId varchar(25),@szEtypeId varchar(25),@szKtypeId varchar(25),@szKtypeId2 varchar(25)
	declare @dTotal numeric(18,4),@dQty numeric(18,4),@Period int,@szBlockno varchar(20),@szProdate varchar(12),@dPrice numeric(18,4)
	declare @ddiscount numeric(18,4),@ddiscountprice numeric(18,4),@ddiscounttotal numeric(18,4),@unit int,@dInvoceTotal numeric(18,4), @nInvoceTag smallint,@ninvTag smallint
	declare @dtax numeric(18,4),@dtaxprice numeric(18,4),@dtaxtotal numeric(18,4),@dtax_total numeric(18,4)
	declare @dcostprice numeric(18,4),@dcosttotal numeric(18,4)
	declare @szmemo varchar(256),  @usedtype char(1),@type int, @nSon int, @nDeleted int
	declare @attach int,	 @BillType	Int, @GatheringDate varchar(10), @DeptID varchar(25)

	declare @nGoodsNo int,@nRet smallint, @OrderCode int, @OrderDlyCode int, @InvoceTotal numeric(18,4), @InvoceTag int, @PDetail int
	declare @execsql [varchar](500), @cRed char(1)
	declare @szTemp varchar(30), @dTemp numeric(18,4),@dTemp1 numeric(18,4)

	declare @nNewVchcode numeric(10,0)
	declare @checke varchar(25), @accounte varchar(25), @ifcheck char(1), @inputno varchar(25), @Number varchar(256)
	declare @Summary varchar(256), @Comment varchar(256)
	declare @cDlyOrder int,@oDlyOrder int,@nDlyOrder int
	declare @lsSerial int --是否严格管理序列号
	declare @nPstatus int --状态用于表示赠品
	declare @nlsRetail int --是否零售单
	declare @nlsfull int --是否正常换货

	select @Period = subvalue from sysdata where subname='period'
	      if @Period<=0 or @Period>12 return -14

	select @szTemp=subvalue from sysdata where subname='iniover'
	if @szTemp='0' return -14
	select @szTemp=subvalue from sysdata where subname='startdate'

	select @nVchType=VchType,@tDate=Date,@szbTypeId=btypeid,@szEtypeId=etypeid,@szKtypeId=ktypeid,@szKtypeid2=ktypeid2,
	@Number = number, @Summary = summary, @Comment = Comment,@period = period,@ifcheck = ifcheck, @checke=checke,@nInvoceTag = InvoceTag,
	@accounte= accounte, @inputno=inputno, @cRed=RedOld,@attach=attach,@billtype=billtype,@gatheringdate=gatheringdate,@DeptID=DeptID,@dTotal=total,
	@nlsRetail = lsRetail,@nlsfull = lsfull
	from dlyndx where Vchcode=@nVchcode


	if @nvchtype in (100,101,52) 
	begin	
		if @nvchtype = 52 return -100 
		return -@nvchtype
	end
	if @cRed='T' return -16
	if @szTemp>@tDate return -14

				if @nvchtype in (23,24,29,52) select @type=4
				else
				if @nvchtype in (25,26,30,50) select @type=1
				else
				if @nvchtype in (27,28,31,51) select @type=5

	begin tran RedAccount
		select @Summary=@Summary+'(红字反冲)'
		exec @nNewVchcode = z_insertDlyNdx  @tDate,@Number, @nVchType,@Summary,@Comment, @szBtypeid,
		@szEtypeid,@szKtypeid,@szKtypeid2,@ifcheck,@checke,@Period,@accounte,@inputno,'2','T',@Attach,@billtype,@gatheringdate,@DeptID,0,0,0,@nInvoceTag
		if @nNewVchcode<=0
		begin
			select @nRet = -9
			goto error
		end
--		by Lcb
		update dlyndx set redold='T',Total = -@dTotal,lsRetail = @nlsRetail,lsfull = @nlsfull where vchcode= @nNewVchcode
		update dlyndx set redold='T' where vchcode= @nVchcode
		UPDATE SN SET TAG = 1 WHERE VchCode=@nVchcode--标记序列号表
--
	if @nVchType in (11,45,142,89,26)
	begin
		select @execsql='declare CreateRed_cursor cursor for '
				+' select atypeid, ptypeid, ktypeid, ktypeid2, qty, price, total, discount, discountprice, discounttotal,
				tax, taxprice, taxtotal, tax_total, costprice, costtotal, blockno, prodate, comment, period, usedtype, goodsno ,
				OrderCode , OrderDlyCode , InvoceTotal , InvoceTag ,unit, PDetail,dlyorder,Pstutas
				from dlysale
				 where Vchcode= '+CAST(@nVchcode AS varchar(10))
		exec (@execsql)


		OPEN CreateRed_cursor
		fetch next from CreateRed_cursor into @szatypeid, @szPtypeId,@szKtypeid, @szKtypeid2, @dQty,@dPrice,@dTotal,@ddiscount,@ddiscountprice, @ddiscounttotal,
			@dtax,@dtaxprice,@dtaxtotal,@dtax_total,@dcostprice, @dcosttotal,@szBlockno,@szProdate, @szmemo, @period, @usedtype,@nGoodsNo,
			@OrderCode , @OrderDlyCode , @InvoceTotal , @InvoceTag ,@unit, @PDetail,@oDlyOrder,@nPstatus
		while @@FETCH_STATUS=0
		begin
			select @dQty = -@dQty
			select @dTaxTotal = -@dTaxTotal
			select @dTax_Total = -@dTax_Total
			select @dCostTotal = - @dCostTotal
			select @dTotal = -@dTotal
			select @dDiscountTotal = -@dDiscountTotal
			--增加红冲草稿 add by dcsong 2004.10.25 
			if @nVchType in (11,45,142)  --只对销售、退货实用
			begin
				insert into bakdly(vchcode,Date,vchType,atypeid,ptypeid,btypeid,etypeid,ktypeid,ktypeid2,
					    qty,price,total,costprice,costtotal,discount,discountprice,discounttotal,
					tax,taxprice,taxtotal,tax_total,Blockno,Prodate,comment,period,usedtype,redword)
				values(@nNewVchcode,@tDate,@nVchType,@szAtypeID,@szPtypeid,@szBtypeid,@szEtypeid,@szKtypeId,@szktypeid2,
					@dQty,@dPrice,@dTotal,@dcostPrice,@dcostTotal,@ddiscount,@ddiscountprice,@ddiscounttotal,
					@dtax,@dtaxprice,@dtaxtotal,@dtax_total,@szBlockno,@szProdate,@szmemo,@period,@usedtype,'T')		
				if @@error <> 0 
				begin
					select @nRet = -9
					goto error
				end
				else
		                        select @cDlyOrder = @@identity  --add by dcsong 2002.4.28
					
	                        insert into t_bakserial(VCHTYPE,VCHCODE,VchLineNO,PTYPEID,BTYPEID,KTYPEID,ETYPEID,SN,BillDate,Memo)
	 				select VCHTYPE,@nNewVchcode,@cDlyOrder,PTYPEID,BTYPEID,KTYPEID,ETYPEID,SN,BillDate,Memo 
					from SN where VCHCODE = @nVchcode and VchLineNO = @oDlyOrder
				if @@error <> 0 
				begin
					select @nRet = -9
					goto error
				end
			end
			else
			begin
				select @lsSerial = 0
				select @cDlyOrder = 0
			end
                        --add end

			if @szPtypeId<>''
			begin
				select @nCostmode=costmode, @nSon=sonnum,@nDeleted=deleted,@lsSerial = lsserial from ptype where typeid=@szptypeid
				if @nSon>0 or @nDeleted=1 goto error

				if @nVchType  in (89,26) 
				begin
					select @lsSerial = 0
					select @cDlyOrder = 0
				end
				if @szKtypeid in (@SEND_GOODS_STOCK_ID,@COMMISSION_STOCK_ID,@RECOMMISSION_STOCK_ID)
				begin
					Exec @nRet = ModifyDbfCom @nVchtype,@GOODs_ID,@szptypeid,@szBtypeid,
					@dqty,@dTax_total,'','',@dcosttotal,@type,@dTemp output,@dTemp1 output
				end
				else
				if @szKtypeid=@LENDOUT_STOCK or @szKtypeid=@BORROWIN_STOCK
				Exec @nRet = ModifyDbfLend @nVchtype,@nCostmode,@GOODs_ID,@szptypeid,@szBtypeid,@szetypeid,@szktypeid,
				@period,@dqty,@dcosttotal,@szBlockno,@szProdate,0,@dTemp output
				else
				begin
					if @nCostmode = 3 select @dTemp = @dcostprice
					Exec @nRet = ModifyDbf @nVchtype,@nNewVchcode,@tDate,@nCostmode,@GOODs_ID,@szptypeid,'',@szetypeid,@szktypeid,
					@period,@dqty,@dcosttotal,@szBlockno,@szProdate,0,@dTemp output,@cDlyOrder,@lsSerial,1
				end
			end
			else
			begin
				if @nCostmode = 3 select @dTemp = @dcostprice
				Exec @nRet = ModifyDbf @nVchtype,@nNewVchcode,@tDate,@nCostmode,@szAtypeId,@szptypeid,@szBtypeId,@szetypeid,@szktypeid,
				@period,@dqty,@dTotal,'','',0,@dTemp output,@cDlyOrder,@lsSerial,1
			end
			if @nRet<0 goto error

			insert into dlysale(vchcode,Date,vchType,atypeid,ptypeid,btypeid,etypeid,ktypeid,ktypeid2,
				    qty,price,total,costprice,costtotal,discount,discountprice,discounttotal,
				tax,taxprice,taxtotal,tax_total,Blockno,Prodate,comment,period,usedtype,redword,
				OrderCode , OrderDlyCode , InvoceTotal , InvoceTag ,unit, PDetail, DeptID,Pstutas)
			values(@nNewVchcode,@tDate,@nVchType,@szAtypeID,@szPtypeid,@szBtypeid,@szEtypeid,@szKtypeId,@szktypeid2,
				@dQty,@dPrice,@dTotal,@dcostPrice,@dcostTotal,@ddiscount,@ddiscountprice,@ddiscounttotal,
				@dtax,@dtaxprice,@dtaxtotal,@dtax_total,@szBlockno,@szProdate,@szmemo,@period,@usedtype,'T',
				@OrderCode , @OrderDlyCode , -@InvoceTotal , @InvoceTag ,@unit, @PDetail , @DeptID,@nPstatus)
			if @@error <> 0 
			begin
				select @nRet = -9
				goto error
			end
			else
				select @nDlyOrder = @@identity

			if @nVchType = 89 
			begin
				insert into dlyother(vchcode,Date,VchType,ATypeID,PTypeID,BTypeID,ETypeID,KTypeID,KTypeID2,
				        qty,Price,Total,costPrice,CostTotal,discount,discountPrice,discountTotal,
				        tax,taxPrice,taxTotal,tax_Total,Blockno,Prodate,comment,period,UsedType,redword,costmode,unit,PDETAIL,DeptID)
				values(@nNewVchcode,@tDate,@nVchType, @LENDOUT_STOCK ,@szPTypeID,@szBTypeID,@szETypeID,@LENDOUT_STOCK,@szKTypeID2,
				        @dQty,@dCostPrice,@dCostTotal,@dCostPrice,@dCostTotal,@dDiscount,@dDiscountPrice,@dCostTotal,
				        @dTax,@dTaxPrice,@dTaxTotal,@dTax_Total,@szBlockno,@szProdate,@szMemo,@Period,@UsedType,'T',@nCostMode,@unit,2,@DeptID)
				if @@error <> 0 
				begin
					select @nRet = -9
					goto error
				end
			end
			--add by dcsong 2004.8.17 更新对应库存变动，一个单据号的且dlyorder为0的，当前变动的明细
			update T_GoodsStocksGlide set dlyorder = @nDlyOrder where VchCode = @nNewVchcode and dlyorder = 0		

			if @nVchType in (11,45,142)  --只对销售、退货实用
			begin --红冲用1表示
				update SN set VchLineNO = @nDlyorder,Tag = 1 where Vchcode = @nNewVchcode and VchLineNO = 0	
			end
			IF (@nVchType = 11) and (@ORDERCODE <> 0) AND (@ORDERDLYCODE <> 0)   --更新定单到货数量和定单完成标志
			BEGIN
				UPDATE BAKDLYORDER SET [TOQTY]=[TOQTY]-@DQTY WHERE [VCHCODE]=@ORDERCODE AND [DLYORDER]=@ORDERDLYCODE 
				IF EXISTS(SELECT [VCHCODE] FROM BAKDLYORDER WHERE VCHCODE=@ORDERCODE AND [QTY]>[TOQTY]) 
					UPDATE DLYNDXORDER SET [ORDEROVER]=0 WHERE VCHCODE=@ORDERCODE 
			END
	
			fetch next from CreateRed_cursor into @szatypeid, @szPtypeId, @szKtypeid, @szKtypeid2, @dQty,@dPrice,@dTotal,@ddiscount,@ddiscountprice, @ddiscounttotal,
			@dtax,@dtaxprice,@dtaxtotal,@dtax_total,@dcostprice, @dcosttotal,@szBlockno,@szProdate, @szmemo, @period, @usedtype,@nGoodsNo,
			@OrderCode , @OrderDlyCode , @InvoceTotal , @InvoceTag ,@unit, @PDetail,@oDlyOrder,@nPstatus
		end

		CLOSE CreateRed_cursor
		DEALLOCATE CreateRed_cursor
	end
	else
	if @nVchType in (34,6,143,73,28)
	begin
		select @execsql='declare CreateRed_cursor cursor for '
				+' select atypeid, ptypeid, ktypeid, ktypeid2, qty, price, total, discount, discountprice, discounttotal,
				tax, taxprice, taxtotal, tax_total, costprice, costtotal, blockno, prodate, comment, period, usedtype, goodsno ,
				OrderCode , OrderDlyCode , InvoceTotal , InvoceTag ,unit, PDetail,dlyorder,Pstutas
				from dlybuy
				 where Vchcode= '+CAST(@nVchcode AS varchar(10))
		exec (@execsql)


		OPEN CreateRed_cursor
		fetch next from CreateRed_cursor into @szatypeid, @szPtypeId,@szKtypeid, @szKtypeid2, @dQty,@dPrice,@dTotal,@ddiscount,@ddiscountprice, @ddiscounttotal,
			@dtax,@dtaxprice,@dtaxtotal,@dtax_total,@dcostprice, @dcosttotal,@szBlockno,@szProdate, @szmemo, @period, @usedtype,@nGoodsNo,
			@OrderCode , @OrderDlyCode , @InvoceTotal , @InvoceTag ,@unit, @PDetail,@oDlyOrder,@nPstatus
		while @@FETCH_STATUS=0
		begin
		select @dQty = -@dQty
		select @dTaxTotal = -@dTaxTotal
		select @dTax_Total = -@dTax_Total
		select @dCostTotal = - @dCostTotal
		select @dTotal = -@dTotal
		select @dDiscountTotal = -@dDiscountTotal
		--增加红冲草稿 add by dcsong 2004.10.25 
		if @nVchType in (34,6,143)  --只对进货、退货实用
		begin
			insert into bakdly(vchcode,Date,vchType,atypeid,ptypeid,btypeid,etypeid,ktypeid,ktypeid2,
				    qty,price,total,costprice,costtotal,discount,discountprice,discounttotal,
				tax,taxprice,taxtotal,tax_total,Blockno,Prodate,comment,period,usedtype,redword)
			values(@nNewVchcode,@tDate,@nVchType,@szAtypeID,@szPtypeid,@szBtypeid,@szEtypeid,@szKtypeId,@szktypeid2,
				@dQty,@dPrice,@dTotal,@dcostPrice,@dcostTotal,@ddiscount,@ddiscountprice,@ddiscounttotal,
				@dtax,@dtaxprice,@dtaxtotal,@dtax_total,@szBlockno,@szProdate,@szmemo,@period,@usedtype,'T')		
			if @@error <> 0 
			begin
				select @nRet = -9
				goto error
			end
			else
                        	select @cDlyOrder = @@identity  --add by dcsong 2002.4.28

                        insert into t_bakserial(VCHTYPE,VCHCODE,VchLineNO,PTYPEID,BTYPEID,KTYPEID,ETYPEID,SN,BillDate,Memo)
 				select VCHTYPE,@nNewVchcode,@cDlyOrder,PTYPEID,BTYPEID,KTYPEID,ETYPEID,SN,BillDate,Memo 
				from SN where VCHCODE = @nVchcode and VchLineNO = @oDlyOrder
			if @@error <> 0 
			begin
				select @nRet = -9
				goto error
			end
		end
		else
		begin
			select @lsSerial = 0
			select @cDlyOrder = 0
		end
                --add end

			if @szPtypeId<>''
			begin
				select @nCostmode=costmode, @nSon=sonnum,@nDeleted=deleted,@lsSerial = lsserial from ptype where typeid=@szptypeid
				if @nSon>0 or @nDeleted=1 goto error

				if @nVchType  in (73,28) 
				begin
					select @lsSerial = 0
					select @cDlyOrder = 0
				end

				if @szKtypeid in (@SEND_GOODS_STOCK_ID,@COMMISSION_STOCK_ID,@RECOMMISSION_STOCK_ID)
				begin

					Exec @nRet = ModifyDbfCom @nVchtype,@GOODs_ID,@szptypeid,@szBtypeid,
					@dqty,@dTax_total,'','',@dcosttotal,@type,@dTemp output,@dTemp1 output
				end
				else
				if @szKtypeid=@LENDOUT_STOCK or @szKtypeid=@BORROWIN_STOCK
				begin
					select @dQty = -@dQty
					select @dCostTotal = - @dCostTotal
 					Exec @nRet = ModifyDbfLend @nVchtype,@nCostmode,@GOODs_ID,@szptypeid,@szBtypeid,@szetypeid,@szktypeid,
					@period,@dqty,@dcosttotal,@szBlockno,@szProdate,0,@dTemp output
					select @dQty = -@dQty
					select @dCostTotal = - @dCostTotal
				end
				else
				begin
					if @nCostmode = 3 select @dTemp = @dcostprice
					Exec @nRet = ModifyDbf @nVchtype,@nNewVchcode,@tDate,@nCostmode,@GOODs_ID,@szptypeid,'',@szetypeid,@szktypeid,
					@period,@dqty,@dcosttotal,@szBlockno,@szProdate,0,@dTemp output,@cDlyOrder,@lsSerial,1
				end
			end
			else
			begin
				if @nCostmode = 3 select @dTemp = @dcostprice
				Exec @nRet = ModifyDbf @nVchtype,@nNewVchcode,@tDate,@nCostmode,@szAtypeId,@szptypeid,@szBtypeId,@szetypeid,@szktypeid,
				@period,@dqty,@dTotal,'','',0,@dTemp output,@cDlyOrder,@lsSerial,1
			end
			if @nRet<0 goto error

			insert into dlybuy(vchcode,Date,vchType,atypeid,ptypeid,btypeid,etypeid,ktypeid,ktypeid2,
				    qty,price,total,costprice,costtotal,discount,discountprice,discounttotal,
				tax,taxprice,taxtotal,tax_total,Blockno,Prodate,comment,period,usedtype,redword,
				OrderCode , OrderDlyCode , InvoceTotal , InvoceTag ,unit, PDetail, DeptID,Pstutas)
			values(@nNewVchcode,@tDate,@nVchType,@szAtypeID,@szPtypeid,@szBtypeid,@szEtypeid,@szKtypeId,@szktypeid2,
				@dQty,@dPrice,@dTotal,@dcostPrice,@dcostTotal,@ddiscount,@ddiscountprice,@ddiscounttotal,
				@dtax,@dtaxprice,@dtaxtotal,@dtax_total,@szBlockno,@szProdate,@szmemo,@period,@usedtype,'T',
				@OrderCode , @OrderDlyCode , -@InvoceTotal , @InvoceTag ,@unit, @PDetail , @DeptID,@nPstatus)
			if @@error <> 0 
			begin
				select @nRet = -9
				goto error
			end
			else
				select @nDlyOrder = @@identity

			if @nVchType = 73 
			begin
				insert into dlyother(vchcode,Date,VchType,ATypeID,PTypeID,BTypeID,ETypeID,KTypeID,KTypeID2,
				        qty,Price,Total,costPrice,CostTotal,discount,discountPrice,discountTotal,
				        tax,taxPrice,taxTotal,tax_Total,Blockno,Prodate,comment,period,UsedType,redword,costmode,unit,PDETAIL,DeptID)
				values(@nNewVchcode,@tDate,@nVchType, @BORROWIN_STOCK ,@szPTypeID,@szBTypeID,@szETypeID,@BORROWIN_STOCK,@szKTypeID2,
				        -@dQty,@dCostPrice,-@dCostTotal,@dCostPrice,-@dCostTotal,@dDiscount,@dDiscountPrice,-@dCostTotal,
				        @dTax,@dTaxPrice,@dTaxTotal,-@dTax_Total,@szBlockno,@szProdate,@szMemo,@Period,@UsedType,'T',@nCostMode,@unit,2,@DeptID)
				if @@error <> 0 
				begin
					select @nRet = -9
					goto error
				end
			end
			--add by dcsong 2004.8.17 更新对应库存变动，一个单据号的且dlyorder为0的，当前变动的明细
			update T_GoodsStocksGlide set dlyorder = @nDlyOrder where VchCode = @nNewVchcode and dlyorder = 0		


			if @nVchType in (34,6,143)  --只对进货、退货实用
			begin --红冲用1表示
				update SN set VchLineNO = @nDlyorder,Tag = 1 where Vchcode = @nNewVchcode and VchLineNO = 0	
			end
			IF (@nVchType = 34) and (@ORDERCODE <> 0) AND (@ORDERDLYCODE <> 0)   --更新定单到货数量和定单完成标志
			BEGIN
				UPDATE BAKDLYORDER SET [TOQTY]=[TOQTY]+@DQTY WHERE [VCHCODE]=@ORDERCODE AND [DLYORDER]=@ORDERDLYCODE 
				IF EXISTS(SELECT [VCHCODE] FROM BAKDLYORDER WHERE VCHCODE=@ORDERCODE AND [QTY]>[TOQTY]) 
					UPDATE DLYNDXORDER SET [ORDEROVER]=0 WHERE VCHCODE=@ORDERCODE 
			END
			fetch next from CreateRed_cursor into @szatypeid, @szPtypeId,@szKtypeid, @szKtypeid2, @dQty,@dPrice,@dTotal,@ddiscount,@ddiscountprice, @ddiscounttotal,
			@dtax,@dtaxprice,@dtaxtotal,@dtax_total,@dcostprice, @dcosttotal,@szBlockno,@szProdate, @szmemo, @period, @usedtype,@nGoodsNo,
			@OrderCode , @OrderDlyCode , @InvoceTotal , @InvoceTag ,@unit, @PDetail,@oDlyOrder,@nPstatus
		end

		CLOSE CreateRed_cursor
		DEALLOCATE CreateRed_cursor
	end
	else
	begin
		select @execsql='declare CreateRed_cursor cursor for '
				+' select atypeid, ptypeid, ktypeid,ktypeid2,qty, price, total, discount, discountprice, discounttotal,
				tax, taxprice, taxtotal, tax_total, costprice, costtotal, blockno, prodate, comment, period, usedtype, goodsno ,
				OrderCode , OrderDlyCode , InvoceTotal , InvoceTag , PDetail,dlyorder
				from dlyother
				 where Vchcode= '+CAST(@nVchcode AS varchar(10))+' order by usedtype,dlyorder'
		exec (@execsql)


		OPEN CreateRed_cursor
		fetch next from CreateRed_cursor into @szatypeid, @szPtypeId,@szKtypeid, @szKtypeid2, @dQty,@dPrice,@dTotal,@ddiscount,@ddiscountprice, @ddiscounttotal,
			@dtax,@dtaxprice,@dtaxtotal,@dtax_total,@dcostprice, @dcosttotal,@szBlockno,@szProdate, @szmemo, @period, @usedtype,@nGoodsNo,
			@OrderCode , @OrderDlyCode , @InvoceTotal , @InvoceTag , @PDetail,@oDlyOrder
		while @@FETCH_STATUS=0
		begin
			select @dQty = -@dQty
			select @dCostTotal = - @dCostTotal
			select @dTaxTotal = -@dTaxTotal
			select @dTax_Total = -@dTax_Total
			select @dTotal = -@dTotal
			select @dDiscountTotal = -@dDiscountTotal
			--增加红冲草稿 add by dcsong 2004.10.25 
			if @nVchType not in (50,51,57)  --委托、受托调价,部分调价不处理
			begin
				insert into bakdly(vchcode,Date,vchType,atypeid,ptypeid,btypeid,etypeid,ktypeid,ktypeid2,
					    qty,price,total,costprice,costtotal,discount,discountprice,discounttotal,
					tax,taxprice,taxtotal,tax_total,Blockno,Prodate,comment,period,usedtype,redword)
				values(@nNewVchcode,@tDate,@nVchType,@szAtypeID,@szPtypeid,@szBtypeid,@szEtypeid,@szKtypeId,@szktypeid2,
					@dQty,@dPrice,@dTotal,@dcostPrice,@dcostTotal,@ddiscount,@ddiscountprice,@ddiscounttotal,
					@dtax,@dtaxprice,@dtaxtotal,@dtax_total,@szBlockno,@szProdate,@szmemo,@period,@usedtype,'T')		
				if @@error <> 0 
				begin
					select @nRet = -9
					goto error
				end
				else
		                        select @cDlyOrder = @@identity  --add by dcsong 2002.4.28
					
	                        insert into t_bakserial(VCHTYPE,VCHCODE,VchLineNO,PTYPEID,BTYPEID,KTYPEID,ETYPEID,SN,BillDate,Memo)
	 				select VCHTYPE,@nNewVchcode,@cDlyOrder,PTYPEID,BTYPEID,KTYPEID,ETYPEID,SN,BillDate,Memo 
					from SN where VCHCODE = @nVchcode and VchLineNO = @oDlyOrder
				if @@error <> 0 
				begin
					select @nRet = -9
					goto error
				end
			end
			else
			begin
				select @lsSerial = 0
				select @cDlyOrder = 0
			end

	                --add end

			if @szPtypeId<>''
			begin
				select @nCostmode=costmode, @nSon=sonnum,@nDeleted=deleted,@lsSerial = lsserial from ptype where typeid=@szptypeid
				if @nSon>0 or @nDeleted=1 goto error

				if @nVchType  in (50,51,57) 
				begin
					select @lsSerial = 0
					select @cDlyOrder = 0
				end

				if @szKtypeid in (@SEND_GOODS_STOCK_ID,@COMMISSION_STOCK_ID,@RECOMMISSION_STOCK_ID)
				begin
					if @nVchtype = 50 --委托调价
					begin
  						Exec @nRet = ModifyDbfCom @nVchtype,@GOODs_ID,@szptypeid,@szBtypeid,
						0,@dTax_total,'','',0,@type,@dTemp output,@dTemp1 output
					end
					else if @nVchtype = 51 --受托调价
					begin
  						Exec @nRet = ModifyDbfCom @nVchtype,@GOODs_ID,@szptypeid,@szBtypeid,
						0,@dTax_total,'','',@dTax_total,@type,@dTemp output,@dTemp1 output
					end
                                        else
  						Exec @nRet = ModifyDbfCom @nVchtype,@GOODs_ID,@szptypeid,@szBtypeid,
						@dqty,@dTax_total,'','',@dcosttotal,@type,@dTemp output,@dTemp1 output
				end
				else
				if @szKtypeid=@LENDOUT_STOCK or @szKtypeid=@BORROWIN_STOCK
					Exec @nRet = ModifyDbfLend @nVchtype,@nCostmode,@GOODs_ID,@szptypeid,@szBtypeid,@szetypeid,@szktypeid,
					@period,@dqty,@dcosttotal,@szBlockno,@szProdate,0,@dTemp output
				else
				begin
					if @nCostmode = 3 select @dTemp = @dcostprice
					Exec @nRet = ModifyDbf @nVchtype,@nNewVchcode,@tDate,@nCostmode,@GOODs_ID,@szptypeid,'',@szetypeid,@szktypeid,
					@period,@dqty,@dcosttotal,@szBlockno,@szProdate,0,@dTemp output,@cDlyOrder,@lsSerial,1
				end
			end
			else
			begin
				if @nCostmode = 3 select @dTemp = @dcostprice
				Exec @nRet = ModifyDbf @nVchtype,@nNewVchcode,@tDate,@nCostmode,@szAtypeId,@szptypeid,@szBtypeId,@szetypeid,@szktypeid,
				@period,@dqty,@dTotal,'','',0,@dTemp output,@cDlyOrder,@lsSerial,1
			end
			if @nRet<0 goto error

			insert into dlyother(vchcode,Date,vchType,atypeid,ptypeid,btypeid,etypeid,ktypeid,ktypeid2,
				    	qty,price,total,costprice,costtotal,discount,discountprice,discounttotal,
					tax,taxprice,taxtotal,tax_total,Blockno,Prodate,comment,period,usedtype,redword,
					OrderCode , OrderDlyCode , InvoceTotal , InvoceTag , PDetail, DeptID)
			values(@nNewVchcode,@tDate,@nVchType,@szAtypeID,@szPtypeid,@szBtypeid,@szEtypeid,@szKtypeId,@szktypeid2,
					@dQty,@dPrice,@dTotal,@dcostPrice,@dcostTotal,@ddiscount,@ddiscountprice,@ddiscounttotal,
					@dtax,@dtaxprice,@dtaxtotal,@dtax_total,@szBlockno,@szProdate,@szmemo,@period,@usedtype,'T',
					@OrderCode , @OrderDlyCode , -@InvoceTotal , @InvoceTag , @PDetail ,@DeptID )
			if @@error <> 0 
			begin
				select @nRet = -9
				goto error
			end
			else
				select @nDlyOrder = @@identity

			--add by dcsong 2004.8.17 更新对应库存变动，一个单据号的且dlyorder为0的，当前变动的明细
			update T_GoodsStocksGlide set dlyorder = @nDlyOrder where VchCode = @nNewVchcode and dlyorder = 0		

			if @nVchType not in (50,51,57)  
			begin
				update T_GoodsStocksGlide set dlyorder = @nDlyOrder where VchCode = @nNewVchcode and dlyorder = 0		
				update SN set VchLineNO = @nDlyorder,Tag = 1 where Vchcode = @nNewVchcode and VchLineNO = 0	--红冲用1表示
			end

			fetch next from CreateRed_cursor into @szatypeid, @szPtypeId,@szKtypeid, @szKtypeid2, @dQty,@dPrice,@dTotal,@ddiscount,@ddiscountprice, @ddiscounttotal,
			@dtax,@dtaxprice,@dtaxtotal,@dtax_total,@dcostprice, @dcosttotal,@szBlockno,@szProdate, @szmemo, @period, @usedtype,@nGoodsNo,
			@OrderCode , @OrderDlyCode , @InvoceTotal , @InvoceTag , @PDetail,@oDlyOrder
		end

		CLOSE CreateRed_cursor
		DEALLOCATE CreateRed_cursor
	end

		select @execsql='declare CreateRed_cursor cursor for '
				+' select atypeid, btypeid, total, comment, period, usedtype ,
				InvoceTotal , InvoceTag
				from dlya
				 where Vchcode= '+CAST(@nVchcode AS varchar(10))
		exec (@execsql)


		OPEN CreateRed_cursor
		fetch next from CreateRed_cursor into @szatypeid, @szBtypeid, @dTotal, @szmemo, @period, @usedtype, @InvoceTotal , @InvoceTag
		while @@FETCH_STATUS=0
		begin
			select @dTotal = -@dTotal
			Exec @nRet = ModifyDbf @nVchtype,@nNewVchcode,@tDate,@nCostmode,@szAtypeId,'',@szBtypeId,@szetypeid,@szktypeid,
				@period,@dTotal,@dTotal,'','',0,@dTemp output,0,0
			if @nRet<0 goto error

			insert into dlya(vchcode,Date,vchType,atypeid,btypeid,etypeid,ktypeid,
				    total,comment,period,usedtype,redword,
				InvoceTotal , InvoceTag , DeptID)
			values(@nNewVchcode,@tDate,@nVchType,@szAtypeID,@szBtypeid,@szEtypeid,@szKtypeId,
				@dTotal,@szmemo,@period,@usedtype,'T',
				-@InvoceTotal , @InvoceTag ,@DeptID)
			if @@error <> 0
			begin
				select @nRet = -9
				goto error
			end
			fetch next from CreateRed_cursor into @szatypeid, @szBtypeid, @dTotal, @szmemo, @period, @usedtype, @InvoceTotal , @InvoceTag
		end

		CLOSE CreateRed_cursor
		DEALLOCATE CreateRed_cursor

		if @nVchType in (4,66)
		begin
			delete from gatheringdly where gatheringvchcode=@nVchcode
--			if @@error<>0 goto error
		end

	commit tran RedAccount
	return 0

error:
	CLOSE CreateRed_cursor
	DEALLOCATE CreateRed_cursor
	rollback tran RedAccount
	select @szptypeido = @szptypeid
	select @szbtypeido = @szbtypeid
	select @szatypeido = @szatypeid
	select @szktypeido = @szktypeid
	return @nRet
