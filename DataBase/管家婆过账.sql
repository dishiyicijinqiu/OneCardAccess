USE [GJPTest2]
GO
/****** 对象:  StoredProcedure [dbo].[Z_CreateDly]    脚本日期: 11/20/2015 09:20:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO


--过帐用
--  -11 没有开帐
--  -12 在月结存日期之前
--  -133 单位已经删除
--  -132 商品已经删除
--  -134 职员已经删除
--  -135 仓库已经删除
--  -136 部门已经删除
--  -137 科目已经删除
--  -8 收付款金额不等
--  -2,4? 操作失败
ALTER                           PROCEDURE [dbo].[Z_CreateDly]
(
        @nVchcode numeric(10, 0),
        @szPTypeIDo varchar(25) output,
        @szBTypeIDo varchar(25) output,
        @szATypeIDo varchar(25) output,
        @szKTypeIDo varchar(25) output
)
AS
    --  set nocount off

        declare @AVERAGE smallint
        declare @FIFO    smallint
        declare @LIFO    smallint
        declare @HAND    smallint

        select @AVERAGE=0
        select @FIFO   =1
        select @LIFO   =2
        select @HAND   =3

        declare  @GOODS_ID varchar(25),
                 @CASH_ID  varchar(25),
                 @CASH_BANK_ID varchar(25),
                 @AR_ID varchar(25),
                 @AP_ID varchar(25),
                 @GOODS_LOSS_ID varchar(25),
                 @GOODS_GET_ID varchar(25),
                 @TAX_ID  varchar(25),
                 @SALE_INCOME_ID varchar(25),
                 @SALE_COST_ID  varchar(25),
                 @OTHER_INCOME_ID varchar(25),
                 @PriceALLOT_CHANGE_ID varchar(25),
                 @ALLOT_INCOME_ID varchar(25),
                 @BUY_BUYBACK_ID varchar(25),
                @GOODS_GIVE_ID varchar(25),
                @GOODS_GIVEME_ID varchar(25),
                @GOODS_PRODUCE_ID varchar(25),
                @FIXED_REDUCE_ID  varchar(25),
                @EXPENSE_HAPPEN_ID varchar(25),
                @LENDOUT_STOCK varchar(25),
                @BORROWIN_STOCK varchar(25),
                @BORROW_BORROWBACK_ID varchar(25),
                @LENDOUT_GOODS_ID varchar(25),
                @BORROWIN_GOODS_ID  varchar(25),

                @SEND_GOODS_ID varchar(25),   --发出商品
--              @AR_SALETAX_ID varchar(25),  --应收-销项增值税
                @COMMISSION_GOODS_ID varchar(25),  --委托发出商品款
                @RECOMMISSION_GOODS_ID varchar(25),  --受托接收商品款
--              @AP_BUYTAX_ID varchar(25),  --应付-进项增值税
                @SEND_GOODS_STOCK_ID varchar(25),
                @COMMISSION_STOCK_ID varchar(25),
                @RECOMMISSION_STOCK_ID varchar(25),
                @PREPERENTIAL_ID varchar(25)--优惠科目

        select @GOODS_ID='0000100001'
        select @CASH_ID='0000100003'
        select @CASH_BANK_ID='0000100004'
        select @AR_ID='0000100005'
        select @AP_ID='0000200001'
        select @GOODS_LOSS_ID='000040000200001'
        select @GOODS_GET_ID='000030000200001'
        select @TAX_ID = '0000200004'
        select @SALE_INCOME_ID='0000300001'
        select @SALE_COST_ID='0000400001'
        select @OTHER_INCOME_ID ='0000300003'
        select @PriceALLOT_CHANGE_ID='000030000200005'
        select @ALLOT_INCOME_ID = '000030000200003'
        select @BUY_BUYBACK_ID = '000030000200004'
        select @GOODS_GIVE_ID = '000040000200002'
        select @GOODS_GIVEME_ID = '000030000200002'
        select @GOODS_PRODUCE_ID = '000030000200006'
        select @FIXED_REDUCE_ID='000040000300002'
        select @EXPENSE_HAPPEN_ID='0000100007'
        select @LENDOUT_STOCK ='9999999999'
        select @BORROWIN_STOCK ='9999999998'
        select @BORROW_BORROWBACK_ID='000030000200007'
        select @LENDOUT_GOODS_ID ='0000100006'
        select @BORROWIN_GOODS_ID  ='0000200002'

        select @SEND_GOODS_ID ='0000100009'   --发出商品
--      select @AR_SALETAX_ID ='000010000500002'  --应收-销项增值税
        select @COMMISSION_GOODS_ID ='0000100008'  --委托发出商品款
        select @RECOMMISSION_GOODS_ID ='0000200003'  --受托接收商品款
--      select @AP_BUYTAX_ID ='000020000100002'  --应付-进项增值税
        select @SEND_GOODS_STOCK_ID='9999900001'
        select @COMMISSION_STOCK_ID='9999900002'
        select @RECOMMISSION_STOCK_ID='9999900003'
        SELECT @PREPERENTIAL_ID = '000040000390000'--优惠

        declare @nHandInputZero int --0成本强制出库
	declare @nPstatus int -- 状态,0 正常 1赠品
        declare @tDate varchar(10), @nCostMode int, @deleted int
        declare @dTotalMoney numeric(18,4),@dTotalinMoney numeric(18,4),@nOrderCode int,@nOrderDlyCode int, @dInvoceTotal numeric(18,4), @nInvoceTag smallint,@ninvTag smallint
        declare @nVchType numeric(4, 0),@szATypeID varchar(25),@szPTypeID varchar(25),@szBTypeID varchar(25),@szETypeID varchar(25),@szKTypeID varchar(25),@szKTypeID2 varchar(25)
        declare @dTotal numeric(18,4),@dQty numeric(18,4),@nPeriod int,@szBlockno varchar(20),@szProdate varchar(12),@dPrice FLOAT
        declare @szATypeIDtemp varchar(25),@szPTypeIDtemp varchar(25),@szBTypeIDtemp varchar(25),@szETypeIDtemp varchar(25),@szKTypeIDtemp varchar(25)
        declare @dDiscount numeric(18,4),@dDiscountPrice FLOAT ,@dDiscountTotal numeric(18,4)
        declare @dTax numeric(18,4),@dTaxPrice FLOAT ,@dTaxTotal numeric(18,4),@dTax_Total numeric(18,4)
        declare @dCostPrice FLOAT ,@dCostTotal numeric(18,4), @RetailPrice FLOAT
        declare @szMemo varchar(256), @UsedType char(1),@jhdate varchar(10),@xsdate varchar(10)
        declare @dTemptaxTotal numeric(18,4), @dTempCostTotal numeric(18,4)


        declare @dTempAr numeric(18,4),@dTempAp numeric(18,4),@redword char(1)
        declare @dTempQty numeric(18,4),@dTempTotal numeric(18,4)

        declare @nGoodsNo int,@dCostPriceout numeric(18,4),@dTemp numeric(18,4),@nRet smallint
        declare @execsql [varchar](500)
        declare @dTemp1 numeric(18,4), @dTemp2 numeric(18,4)
        declare @szTemp varchar(30), @nTemp numeric(18,0), @unit int
        declare @nTrackPrice smallint,@nTrackDiscount smallint, @nModiSalePrice smallint          --价格跟踪和修改预设售价的配置

        declare @type int --发货、委托等类型
        declare @dInvoce numeric(18,2),@svchcode int, @jsTotal numeric(18,4),@dQtyover numeric(18,4),@dlyorder int,@odlyorder int
        declare @dTax_Totaljs numeric(18,4),@dDiscountTotaljs numeric(18,4), @dQtyjs numeric(18,4), @dCostTotaljs numeric(18,4)
        declare @dTax_Totalover numeric(18,4),@dDiscountTotalover numeric(18,4), @dQtyoverin numeric(18,4), @dCostTotalover numeric(18,4),@dTotalover numeric(18,4)
        declare @nSon int,@szNumber varchar(20),@szAutoSummary varchar(60),@DeptID varchar(25)
	declare @nDlyOrder int
--      declare @BUYTAX_ID varchar(25),@SALETAX_ID varchar(25)
        DECLARE @dPreferential NUMERIC(18,4)--优惠金额
	declare @dChangeTotal numeric(18,4) --换货金额，换货单专用
	declare @iChangeDay int --换货期限
	declare @dChangeRate numeric(10,5) --换货率
	declare @szCanDate varchar(10) --可以换货时间
	declare @lsSerial int --是否严格管理序列号
	declare @dqtyDB numeric(18,4),@szJobNumberDB varchar(20),@szOutFactoryDateDB varchar(13) ,@dPriceDB numeric(18,4) --调拨入库专用
	declare @dTotalDB numeric(18,4),@nTimeDB int,@nChangeDB int,@dChangeTotalDB numeric(18,4) --调拨入库专用
	declare @nChangeCode int,@tChangeDate varchar(10),@dChangeTotalTemp numeric(18,4)
        declare @nCXdlyorder int --促销明细号
	declare @nVipCardID  int 
        SET @dPreferential = 0
 	set @nHandInputZero = 0 --0成本强制出库
	set @nPstatus = 0

              Select @nPeriod = isnull(SubValue,0) from SysData where SubName='Period'
              if @nPeriod<=0 or @nPeriod>12 return -11

        select @szTemp=subvalue from sysdata where subname='iniover'
        if @szTemp='0' return -11

        SELECT @nVchType=VchType,@tDate=[Date],@szBTypeID=BTypeID,@szETypeID=ETypeID,@szKTypeID=KTypeID,@szKTypeID2=KTypeID2,
        @DeptID = DeptID FROM dlyndx WHERE Vchcode=@nVchcode

if @szBTypeID<>'' if not Exists( Select typeid from btype where typeid=@szBTypeID and Deleted=0 and SonNum=0) Return -133
if @szETypeID<>'' if not Exists( Select typeid from employee where typeid=@szETypeID and Deleted=0 and SonNum=0) Return -134

if @nVchType in (100,101)
begin
  if @szKTypeID<>'' if not Exists( Select typeid from ZeroType where typeid=@szKTypeID and Deleted=0 and SonNum=0) Return -135
end
else
begin
  if @szKTypeID<>'' if not Exists( Select typeid from Stock where typeid=@szKTypeID and Deleted=0 and SonNum=0) Return -135
  if @szKTypeID2<>'' if not Exists( Select typeid from Stock where typeid=@szKTypeID2 and Deleted=0 and SonNum=0) Return -135
end

if @DeptID<>'' if not Exists( Select typeid from Department where typeid=@DeptID and Deleted=0 and SonNum=0) Return -136

        select @szTemp=subvalue from sysdata where subname='startdate'
        if @szTemp>@tDate return -12


--检查第一张
        select @nTemp = count(*) from dlyndx where draft=2
        if @nTemp=0
        begin
                update sysdata set subvalue=@tDate where subname='startdate'
                update sysdata set subvalue=@tDate where subname='enddate'
	  	update monthproc set startdate=@tDate,enddate=@tDate where period=13

        end

        select @szNumber = count(*)+1 from dlyndx where @nVchType=VchType and draft=2
        if @szNumber is null Set @szNumber='1'

        select @szATypeID=''
        select @szPTypeID=''
        if @szBTypeID<>''
        begin
                select @deleted=deleted from btype where typeid=@szBTypeID
                if @deleted=1 goto error133
        end
        if @szKTypeID<>''
        begin
                select @deleted=deleted from stock where typeid=@szKTypeID
                select @szKTypeIDo = @szKTypeID
                if @deleted=1 goto error135
        end
        if @szKTypeID2<>''
        begin
                select @deleted=deleted from stock where typeid=@szKTypeID2
                select @szKTypeIDo = @szKTypeID2
                if @deleted=1 goto error135
        end

        begin tran Account
------------------------------进货单------------------------------
        if @nVchType=34
        begin
                select @execsql='declare CreateDly_cursor cursor for '
                                +' select ATypeID, PTypeID,KTypeID, qty, Price, Total, discount, discountPrice, discountTotal,
                                tax, taxPrice, taxTotal, tax_Total, costPrice, CostTotal, blockno, prodate, comment,
                                UsedType, goodsno, unit, OrderCode, OrderDlyCode, InvoceTotal, RetailPrice,dlyorder,Pstutas from bakdly
                                 where Vchcode= '+CAST(@nVchcode AS varchar(10))
                exec (@execsql)

                select @nTrackPrice = [stats] from syscon where [order]=8
	   select @nTrackDisCount = [stats] from syscon where [order]=47
                select @dTotalinMoney = 0
                select @dTempTotal = 0
                select @dTemptaxTotal = 0
                select @dTempQty = 0
                select @dTotalMoney = 0
		select @ninvTag = 0
                OPEN CreateDly_cursor

                fetch next from CreateDly_cursor into @szATypeID, @szPTypeID,@szKTypeID,@dQty,@dPrice,@dTotal,@dDiscount,@dDiscountPrice, @dDiscountTotal,
                        @dTax,@dTaxPrice,@dTaxTotal,@dTax_Total,@dCostPrice, @dCostTotal,@szBlockno,@szProdate, @szMemo, @UsedType,@nGoodsNo,@unit,@nOrderCode,
			@nOrderDlyCode, @dInvoceTotal, @RetailPrice,@odlyorder,@nPstatus
                while @@FETCH_STATUS=0
                begin
                        if @szPTypeID<>''
                        begin
                                if @dInvoceTotal<>0 Set @nInvoceTag =1 else Set @nInvoceTag =0
				if @ninvTag = 0 set @nInvTag = @nInvocetag  
                                select @nCostmode=costmode, @deleted=deleted, @nSon=sonnum,@lsSerial = lsSerial from ptype where typeid=@szPTypeID
                                if @deleted=1 or @nSon>0 goto error132
				if not Exists( Select typeid from Stock where typeid=@szKTypeID and Deleted=0 and SonNum=0) goto error135r

                                Exec @nRet = ModifyDbf 34,@nVchcode,@tDate,@nCostmode,@GOODS_ID,@szPTypeID,'',@szETypeID,@szKTypeID,
                                @nPeriod,@dQty,@dDiscountTotal,@szBlockno,@szProdate,0,@dTemp output,@odlyorder,@lsSerial,@nPstatus
                                if @nRet<0 goto error
                                select @dTempTotal = @dTempTotal+@dDiscountTotal
                                select @dTempQty = @dTempQty+@dQty
                                select @dTotalMoney = @dTotalMoney+@dTax_Total
                                select @dTemptaxTotal = @dTemptaxTotal + @dTaxTotal
                                select @dCostPrice = @dTemp / @dQty
                                select @dCostTotal = @dTemp
				if @nPstatus = 0  --如果是进货单上的获赠,则不跟踪价格
				begin
		                        update ptype set recprice=@ddiscountprice,recprice1=@dPrice where typeid=@szPTypeID
			     		if @nTrackPrice=1 Exec F_GetCustomerPrice 'C',@szPtypeId,@szBtypeId,@dPrice,0,1,1,'','',1
			     		if @nTrackDisCount=1 Exec F_GetCustomerPrice 'BD',@szPtypeId,@szBtypeId,0,0,@ddiscount,1,'','',1		
					if ((@nTrackPrice=1) or (@nTrackDisCount=1))
		
					begin
					 	select @jhdate = CONVERT(varchar(10),getdate(),120)
							Exec F_GetCustomerPrice 'BDT',@szPtypeId,@szBtypeId,0,0,1,1,@jhdate,'',1 
					end			
				end
                                insert into dlybuy(vchcode,Date,VchType,ATypeID,PTypeID,BTypeID,ETypeID,KTypeID,KTypeID2,
                                    	qty,Price,Total,costPrice,CostTotal,discount,discountPrice,discountTotal,
                                	tax,taxPrice,taxTotal,tax_Total,Blockno,Prodate,comment,period,UsedType,costmode,unit,OrderCode,
					OrderDlyCode, InvoceTotal, InvoceTag,DeptID, RetailPrice,Pstutas)
                                values(@nVchcode,@tDate,@nVchType,@szATypeID,@szPTypeID,@szBTypeID,@szETypeID,@szKTypeID,@szKTypeID2,
                                	@dQty,@dPrice,@dTotal,@dCostPrice,@dCostTotal,@dDiscount,@dDiscountPrice,@dDiscountTotal,
                                	@dTax,@dTaxPrice,@dTaxTotal,@dTax_Total,@szBlockno,@szProdate,@szMemo,@nPeriod,@UsedType,@nCostMode,@unit,@nOrderCode,@nOrderDlyCode, @dInvoceTotal,
		 			@nInvoceTag ,@DeptID, @RetailPrice,@nPstatus)
				--add by dcsong 2004.8.17 更新对应库存变动，一个单据号的且dlyorder为0的，当前变动的明细
                                select @nDlyOrder = @@identity
				update T_GoodsStocksGlide set dlyorder = @nDlyOrder where VchCode = @nVchcode and dlyorder = 0		
				update SN set VchLineNO = @nDlyorder,Tag = 2 where Vchcode = @nVchcode and VchLineNO = 0	
				if (@nOrderCode <> 0) and (@nOrderDlyCode <> 0)   --更新定单到货数量和定单完成标志
				begin
					update BakDlyOrder set [ToQty]=[ToQty]+@dQty where [Vchcode]=@nOrderCode and [DlyOrder]=@nOrderDlyCode 
					if not exists(select [VchCode] from BakDlyOrder where vchcode=@nOrderCode and [qty] > [Toqty]) 
						Update DlyndxOrder set [orderover]=1 where Vchcode=@nOrderCode 
				end
                        end
                        else
			if @szATypeID=@PREPERENTIAL_ID
			begin
				select @dPreferential = @dTotal
				insert into dlya(vchcode,Date,VchType,ATypeID,BTypeID,ETypeID,KTypeID,
				    Total,period,UsedType,DeptID)
				values(@nVchcode,@tDate,@nVchType,@szATypeID,@szBTypeID,@szETypeID,@szKTypeID,
					-@dTotal,@nPeriod,@UsedType,@DeptID)
			end
			else 
                        begin
				if not Exists( Select typeid from Atype where typeid=@szATypeID and Deleted=0 and SonNum=0) goto error137r
                                select @dTotalinMoney = @dTotalinMoney + @dTotal
                                select @dTotal = -@dTotal
                                insert into dlya(vchcode,Date,VchType,ATypeID,BTypeID,ETypeID,KTypeID,
                                            Total,period,UsedType,DeptID)
                                values(@nVchcode,@tDate,@nVchType,@szATypeID,@szBTypeID,@szETypeID,@szKTypeID,
                                        @dTotal,@nPeriod,@UsedType,@DeptID)
                        end

                        if @@error <> 0 goto error1
                        fetch next from CreateDly_cursor into @szATypeID, @szPTypeID,@szKTypeID,@dQty,@dPrice,@dTotal,@dDiscount,@dDiscountPrice, @dDiscountTotal,
                        	@dTax,@dTaxPrice,@dTaxTotal,@dTax_Total,@dCostPrice, @dCostTotal,@szBlockno,@szProdate, @szMemo, @UsedType,@nGoodsNo,@unit,@nOrderCode,
				@nOrderDlyCode,@dInvoceTotal, @RetailPrice,@odlyorder,@nPstatus
                end
--库存商品增加
		if @dTempTotal <> 0 
		begin
	                insert into dlya(vchcode,Date,VchType,ATypeID,BTypeID,ETypeID,KTypeID,
	
	                                    Total,period,UsedType,DeptID)
	                        values(@nVchcode,@tDate,@nVchType,@GOODS_ID,@szBTypeID,@szETypeID,@szKTypeID,
	                                @dTempTotal,@nPeriod,'',@DeptID)
	                if @@rowcount <=0 goto error1
		end
--应交税金减少
                if @dTempTaxTotal<>0
                begin
                        insert into dlya(vchcode,Date,VchType,ATypeID,BTypeID,ETypeID,KTypeID,

                                    Total,period,UsedType,DeptID)
                        values(@nVchcode,@tDate,@nVchType,@TAX_ID,@szBTypeID,@szETypeID,@szKTypeID,
                                -@dTemptaxTotal,@nPeriod,'',@DeptID)
                        if @@rowcount <=0 goto error1
                end
--应收应付
		select @dTemp = @dTotalMoney-@dTotalInMoney-@dPreferential
		if @dTemp <> 0
               -- if @dTotalInMoney <> @dTotalMoney
                begin
                 --       select @dTemp = @dTotalMoney-@dTotalInMoney
                        insert into dlya(vchcode,Date,VchType,ATypeID,BTypeID,ETypeID,KTypeID,

                                    Total,period,UsedType,DeptID)
                        values(@nVchcode,@tDate,@nVchType,@AP_ID,@szBTypeID,@szETypeID,@szKTypeID,
                                @dTemp,@nPeriod,'',@DeptID)
                        if @@rowcount <=0 goto error1
                end

                update dlyndx set Total=Abs(@dTotalMoney),InvoceTag = @nInvTag where vchcode=@nVchcode
                if @@rowcount <=0 goto error1

                CLOSE CreateDly_cursor
                DEALLOCATE CreateDly_cursor
                goto finish
        end

------------------------------进货单处理结束--------------------------


------------------------------进货退货单------------------------------
	if @nVchType=6
	begin
		select @execsql='declare CreateDly_cursor cursor for '
				+' select atypeid, ptypeid,KTypeid, qty, price, total, discount, discountprice, discounttotal,
				tax, taxprice, taxtotal, tax_total, costprice, costtotal, blockno, prodate, comment,usedtype, goodsno,unit,dlyorder,HandZeroCost from bakdly
				 where Vchcode= '+CAST(@nVchcode AS varchar(10))
		exec (@execsql)

		select @dTotalinMoney = 0
		select @dTempTotal = 0
		select @dTemptaxtotal = 0
		select @dTempQty = 0
		select @dTempcosttotal = 0
		select @dTotalMoney = 0
		OPEN CreateDly_cursor
		fetch next from CreateDly_cursor into @szatypeid, @szPtypeId,@szKTypeID,@dQty,@dPrice,@dTotal,@ddiscount,@ddiscountprice, @ddiscounttotal,
			@dtax,@dtaxprice,@dtaxtotal,@dtax_total,@dcostprice, @dcosttotal,@szBlockno,@szProdate, @szmemo,@usedtype,@nGoodsNo,@unit,@odlyorder,@nHandInputZero
		while @@FETCH_STATUS=0
		begin
			if @szPtypeid<>''
			begin
				select @nCostmode=costmode, @deleted=deleted,@lsSerial = lsSerial from ptype where typeid=@szptypeid
				if @deleted=1 goto error132
				if not Exists( Select typeid from Stock where typeid=@szKTypeID and Deleted=0 and SonNum=0) goto error135r

				select @dQty = -@dQty
				select @dCostTotal = -@dCostTotal
				select @dTotal = -@dTotal
				select @dDiscountTotal = -@dDiscountTotal
				select @dTax_Total = -@dTax_Total
				select @dTemp=@dcostprice
				
				Exec @nRet = ModifyDbf 6,@nVchcode,@tDate,@nCostmode,@GOODs_ID,@szptypeid,'',@szetypeid,@szktypeid,
				@nperiod,@dqty,@dCostTotal,@szBlockno,@szProdate,@nGoodsNo,@dTemp output,@odlyorder,@lsSerial,@nHandInputZero

				if @nRet<0 goto error
				select @dcostprice = @dtemp / @dqty
				select @dcosttotal = @dtemp
				select @dTempTotal = @dTemptotal - @dDiscountTotal
				select @dTempQty = @dTempQty+@dQty
				select @dTotalMoney = @dTotalMoney - @dTax_total


				select @dTaxTotal = @dTax_total - @dDiscountTotal
				select @dtemptaxtotal = @dtemptaxtotal - @dtaxtotal
				select @dtempcosttotal = @dtempcosttotal + @dcosttotal

				insert into dlybuy(vchcode,Date,vchType,atypeid,ptypeid,btypeid,etypeid,ktypeid,ktypeid2,
				    qty,price,total,costprice,costtotal,discount,discountprice,discounttotal,
				tax,taxprice,taxtotal,tax_total,Blockno,Prodate,comment,period,usedtype,costmode,unit,DeptID)
				values(@nVchcode,@tDate,@nVchType,@szAtypeID,@szPtypeid,@szBtypeid,@szEtypeid,@szKtypeId,@szktypeid2,
				@dQty,@dPrice,@dTotal,@dcostPrice,@dcostTotal,@ddiscount,@ddiscountprice,@ddiscounttotal,
				@dtax,@dtaxprice,@dtaxtotal,@dtax_total,@szBlockno,@szProdate,@szmemo,@nPeriod,@usedtype,@nCostMode,@unit,@DeptID)
				--add by dcsong 2004.8.17 更新对应库存变动，一个单据号的且dlyorder为0的，当前变动的明细
                                select @nDlyOrder = @@identity
				update T_GoodsStocksGlide set dlyorder = @nDlyOrder where VchCode = @nVchcode and dlyorder = 0		
				update SN set VchLineNO = @nDlyorder,Tag = 3 where Vchcode = @nVchcode and VchLineNO = 0	
			end
			else
			if @szATypeID=@PREPERENTIAL_ID
			begin
				select @dPreferential = @dTotal
				insert into dlya(vchcode,Date,VchType,ATypeID,BTypeID,ETypeID,KTypeID,
				    Total,period,UsedType,DeptID)
				values(@nVchcode,@tDate,@nVchType,@szATypeID,@szBTypeID,@szETypeID,@szKTypeID,
					@dTotal,@nPeriod,@UsedType,@DeptID)
			end	
			else 
			begin
				if not Exists( Select typeid from Atype where typeid=@szATypeID and Deleted=0 and SonNum=0) goto error137r
				select @dTotalinMoney = @dTotalinMoney + @dTotal
				insert into dlya(vchcode,Date,vchType,atypeid,btypeid,etypeid,ktypeid,

				    total,period,usedtype,DeptID)
				values(@nVchcode,@tDate,@nVchType,@szAtypeid,@szBtypeid,@szEtypeid,@szKtypeId,
					@dTotal,@nPeriod,@usedtype,@DeptID)
			end
			if @@error <> 0 goto error1
			fetch next from CreateDly_cursor into @szatypeid, @szPtypeId,@szKTypeID,@dQty,@dPrice,@dTotal,@ddiscount,@ddiscountprice, @ddiscounttotal,
			@dtax,@dtaxprice,@dtaxtotal,@dtax_total,@dcostprice, @dcosttotal,@szBlockno,@szProdate, @szmemo,@usedtype,@nGoodsNo,@unit,@odlyorder,@nHandInputZero
		end
--库存商品
		if @dtempCostTotal <> 0 
		begin
			insert into dlya(vchcode,Date,vchType,atypeid,btypeid,etypeid,ktypeid,
					    total,period,usedtype,DeptID)
				values(@nVchcode,@tDate,@nVchType,@GOODS_ID,@szBtypeid,@szEtypeid,@szKtypeId,
					@dtempCostTotal,@nPeriod,'',@DeptID)
			if @@rowcount <=0 goto error1
		end
 --应交税金增加

		if @dTempTaxtotal<>0
		begin
			insert into dlya(vchcode,Date,vchType,atypeid,btypeid,etypeid,ktypeid,

				    total,period,usedtype,DeptID)
			values(@nVchcode,@tDate,@nVchType,@TAX_ID,@szBtypeid,@szEtypeid,@szKtypeId,
				@dtemptaxTotal,@nPeriod,'',@DeptID)
			if @@rowcount <=0 goto error1
		end
--应付

		select @dTemp = -(@dTotalMoney-@dTotalInMoney-@dPreferential)
		if @dTemp <> 0
		--if @dTotalInMoney <> @dTotalMoney
		begin
			--select @dTemp = -(@dTotalMoney - @dTotalInMoney)
			insert into dlya(vchcode,Date,vchType,atypeid,btypeid,etypeid,ktypeid,

				    total,period,usedtype,DeptID)
			values(@nVchcode,@tDate,@nVchType,@AP_ID,@szBtypeid,@szEtypeid,@szKtypeId,
				@dTemp,@nPeriod,'',@DeptID)
			if @@rowcount <=0 goto error1
		end
--进货与退货差价
		select @dTemp = @dTempTotal+@dTempCostTotal
		if @dTemp<>0
		begin
			insert into dlya(vchcode,Date,vchType,atypeid,btypeid,etypeid,ktypeid,

				    total,period,usedtype,DeptID)
			values(@nVchcode,@tDate,@nVchType,@BUY_BUYBACK_ID,@szBtypeid,@szEtypeid,@szKtypeId,
				@dTemp,@nPeriod,'',@DeptID)
			if @@rowcount <=0 goto error1
		end

		CLOSE CreateDly_cursor
		DEALLOCATE CreateDly_cursor

                update dlyndx set Total=Abs(@dTotalMoney) where vchcode=@nVchcode

		goto finish
	end

------------------------------进货退货单处理结束--------------------------

------------------------------进货换货单------------------------------
        if @nVchType=143
        begin
                select @execsql='declare CreateDly_cursor cursor for '
                  +' select ATypeID, PTypeID,KTypeID, qty, Price, Total, discount, discountPrice, discountTotal,
                                tax, taxPrice, taxTotal, tax_Total, costPrice, CostTotal, blockno, prodate, comment,
                                UsedType, goodsno, unit, OrderCode, OrderDlyCode, InvoceTotal, RetailPrice,dlyorder,HandZeroCost from bakdly
                                 where Vchcode= '+CAST(@nVchcode AS varchar(10))
                exec (@execsql)

                select @nTrackPrice = [stats] from syscon where [order]=8
	   select @nTrackDisCount = [stats] from syscon where [order]=47
                select @dTotalinMoney = 0
                select @dTempTotal = 0
                select @dTemptaxTotal = 0

                select @dTempQty = 0


                select @dTotalMoney = 0
		select @dChangeTotal = 0
		select @dtempCostTotal = 0
		select @ninvTag = 0
                OPEN CreateDly_cursor

                fetch next from CreateDly_cursor into @szATypeID, @szPTypeID,@szKTypeID,@dQty,@dPrice,@dTotal,@dDiscount,@dDiscountPrice, @dDiscountTotal,
                        @dTax,@dTaxPrice,@dTaxTotal,@dTax_Total,@dCostPrice, @dCostTotal,@szBlockno,@szProdate, @szMemo, @UsedType,@nGoodsNo,@unit,@nOrderCode,
			@nOrderDlyCode, @dInvoceTotal, @RetailPrice,@odlyorder,@nHandInputZero
                while @@FETCH_STATUS=0
                begin
                        if @szPTypeID<>''
                        begin
				if @UsedType = 1  --退货
				begin
					select @nCostmode=costmode, @deleted=deleted,@lsSerial = lsSerial from ptype where typeid=@szptypeid
					if @deleted=1 goto error132
					if not Exists( Select typeid from Stock where typeid=@szKTypeID and Deleted=0 and SonNum=0) goto error135r
	
					select @dQty = -@dQty
					select @dCostTotal = -@dCostTotal
					select @dTotal = -@dTotal
					select @dDiscountTotal = -@dDiscountTotal
					select @dTax_Total = -@dTax_Total
					select @dTemp=@dcostprice
	
					Exec @nRet = ModifyDbf @nVchType,@nVchcode,@tDate,@nCostmode,@GOODs_ID,@szptypeid,'',@szetypeid,@szktypeid,
					@nperiod,@dqty,@dCostTotal,@szBlockno,@szProdate,@nGoodsNo,@dTemp output,@odlyorder,@lsSerial,@nHandInputZero

					if @nRet<0 goto error
					select @dcostprice = @dtemp / @dqty
					select @dcosttotal = @dtemp
					select @dTempTotal = @dTemptotal + @dDiscountTotal
					select @dTempQty = @dTempQty+@dQty
					select @dTotalMoney = @dTotalMoney + @dTax_total
	
	
					select @dTaxTotal = @dTax_total - @dDiscountTotal
					select @dtemptaxtotal = @dtemptaxtotal + @dtaxtotal
					select @dtempcosttotal = @dtempcosttotal + @dcosttotal
					select @dChangeTotal = @dTotalMoney
	
					insert into dlybuy(vchcode,Date,vchType,atypeid,ptypeid,btypeid,etypeid,ktypeid,ktypeid2,
					    qty,price,total,costprice,costtotal,discount,discountprice,discounttotal,
					tax,taxprice,taxtotal,tax_total,Blockno,Prodate,comment,period,usedtype,costmode,unit,DeptID,RetailPrice)
					values(@nVchcode,@tDate,@nVchType,@szAtypeID,@szPtypeid,@szBtypeid,@szEtypeid,@szKtypeId,@szktypeid2,
					@dQty,@dPrice,@dTotal,@dcostPrice,@dcostTotal,@ddiscount,@ddiscountprice,@ddiscounttotal,
					@dtax,@dtaxprice,@dtaxtotal,@dtax_total,@szBlockno,@szProdate,@szmemo,@nPeriod,@usedtype,@nCostMode,@unit,@DeptID,@RetailPrice)
					--add by dcsong 2004.8.17 更新对应库存变动，一个单据号的且dlyorder为0的，当前变动的明细
	                                select @nDlyOrder = @@identity
					update T_GoodsStocksGlide set dlyorder = @nDlyOrder where VchCode = @nVchcode and dlyorder = 0		
					update SN set VchLineNO = @nDlyorder,Tag = 3 where Vchcode = @nVchcode and VchLineNO = 0	
				end
				else if @UsedType = 2  --进货
				begin
	                                if @dInvoceTotal<>0 Set @nInvoceTag =1 else Set @nInvoceTag =0
					if @ninvTag = 0 set @nInvTag = @nInvocetag  
	                                select @nCostmode=costmode, @deleted=deleted, @nSon=sonnum,@lsSerial = lsSerial from ptype where typeid=@szPTypeID
	                                if @deleted=1 or @nSon>0 goto error132
					if not Exists( Select typeid from Stock where typeid=@szKTypeID and Deleted=0 and SonNum=0) goto error135r
	                                Exec @nRet = ModifyDbf @nVchType,@nVchcode,@tDate,@nCostmode,@GOODS_ID,@szPTypeID,'',@szETypeID,@szKTypeID,
	                                @nPeriod,@dQty,@dDiscountTotal,@szBlockno,@szProdate,0,@dTemp output,@odlyorder,@lsSerial

			                if @nRet<0 goto error
	                                select @dTempTotal = @dTempTotal+@dDiscountTotal
	                                select @dTempQty = @dTempQty+@dQty
	                                select @dTotalMoney = @dTotalMoney+@dTax_Total
	                                select @dTemptaxTotal = @dTemptaxTotal + @dTaxTotal
	                                select @dCostPrice = @dTemp / @dQty
	                                select @dCostTotal = @dTemp
					select @dtempcosttotal = @dtempcosttotal + @dcosttotal
	                                update ptype set recprice=@ddiscountprice,recprice1=@dPrice where typeid=@szPTypeID
	
	                                insert into dlybuy(vchcode,Date,VchType,ATypeID,PTypeID,BTypeID,ETypeID,KTypeID,KTypeID2,
	                                    qty,Price,Total,costPrice,CostTotal,discount,discountPrice,discountTotal,
	                                tax,taxPrice,taxTotal,tax_Total,Blockno,Prodate,comment,period,UsedType,costmode,unit,OrderCode,OrderDlyCode, InvoceTotal, InvoceTag,DeptID, RetailPrice)
	                                values(@nVchcode,@tDate,@nVchType,@szATypeID,@szPTypeID,@szBTypeID,@szETypeID,@szKTypeID,@szKTypeID2,
	                                @dQty,@dPrice,@dTotal,@dCostPrice,@dCostTotal,@dDiscount,@dDiscountPrice,@dDiscountTotal,
	                                @dTax,@dTaxPrice,@dTaxTotal,@dTax_Total,@szBlockno,@szProdate,@szMemo,@nPeriod,@UsedType,@nCostMode,@unit,@nOrderCode,@nOrderDlyCode, @dInvoceTotal, @nInvoceTag ,@DeptID, @RetailPrice)
					--add by dcsong 2004.8.17 更新对应库存变动，一个单据号的且dlyorder为0的，当前变动的明细
	                                select @nDlyOrder = @@identity
					update T_GoodsStocksGlide set dlyorder = @nDlyOrder where VchCode = @nVchcode and dlyorder = 0		
					update SN set VchLineNO = @nDlyorder,Tag = 2 where Vchcode = @nVchcode and VchLineNO = 0	
				end
                        end
                        else
			if @szATypeID=@PREPERENTIAL_ID
			begin
				select @dPreferential = @dTotal
				insert into dlya(vchcode,Date,VchType,ATypeID,BTypeID,ETypeID,KTypeID,
				    Total,period,UsedType,DeptID)
				values(@nVchcode,@tDate,@nVchType,@szATypeID,@szBTypeID,@szETypeID,@szKTypeID,
					-@dTotal,@nPeriod,@UsedType,@DeptID)
			end	
			else 
			begin
				if not Exists( Select typeid from Atype where typeid=@szATypeID and Deleted=0 and SonNum=0) goto error137r
				select @dTotalinMoney = @dTotalinMoney + @dTotal
                                select @dTotal = -@dTotal
				insert into dlya(vchcode,Date,vchType,atypeid,btypeid,etypeid,ktypeid,
				    total,period,usedtype,DeptID)
				values(@nVchcode,@tDate,@nVchType,@szAtypeid,@szBtypeid,@szEtypeid,@szKtypeId,
					@dTotal,@nPeriod,@usedtype,@DeptID)
			end
			if @@error <> 0 goto error1

			fetch next from CreateDly_cursor into @szatypeid, @szPtypeId,@szKTypeID,@dQty,@dPrice,@dTotal,@ddiscount,@ddiscountprice, @ddiscounttotal,
			@dtax,@dtaxprice,@dtaxtotal,@dtax_total,@dcostprice, @dcosttotal,@szBlockno,@szProdate, @szmemo,@usedtype,@nGoodsNo,@unit,@nOrderCode,@nOrderDlyCode,
		 	@dInvoceTotal, @RetailPrice,@odlyorder,@nHandInputZero
		end
--库存商品
 		if @dtempCostTotal <> 0 
		begin
			insert into dlya(vchcode,Date,vchType,atypeid,btypeid,etypeid,ktypeid,
					    total,period,usedtype,DeptID)
				values(@nVchcode,@tDate,@nVchType,@GOODS_ID,@szBtypeid,@szEtypeid,@szKtypeId,
					@dtempCostTotal,@nPeriod,'',@DeptID)
			if @@rowcount <=0 goto error1
		end
 --应交税金减少

		if @dTempTaxtotal<>0
		begin
			insert into dlya(vchcode,Date,vchType,atypeid,btypeid,etypeid,ktypeid,
				    total,period,usedtype,DeptID)
			values(@nVchcode,@tDate,@nVchType,@TAX_ID,@szBtypeid,@szEtypeid,@szKtypeId,
				-@dtemptaxTotal,@nPeriod,'',@DeptID)
			if @@rowcount <=0 goto error1
		end
--应付

		select @dTemp = (@dTotalMoney-@dTotalInMoney-@dPreferential)
		if @dTemp <> 0
		begin
			insert into dlya(vchcode,Date,vchType,atypeid,btypeid,etypeid,ktypeid,

				    total,period,usedtype,DeptID)
			values(@nVchcode,@tDate,@nVchType,@AP_ID,@szBtypeid,@szEtypeid,@szKtypeId,
				@dTemp,@nPeriod,'',@DeptID)
			if @@rowcount <=0 goto error1
		end
--进货与退货差价
		select @dTemp = -1*(@dTempTotal-@dTempCostTotal)
		if @dTemp<>0
		begin
			insert into dlya(vchcode,Date,vchType,atypeid,btypeid,etypeid,ktypeid,
				    total,period,usedtype,DeptID)
			values(@nVchcode,@tDate,@nVchType,@BUY_BUYBACK_ID,@szBtypeid,@szEtypeid,@szKtypeId,
				@dTemp,@nPeriod,'',@DeptID)
			if @@rowcount <=0 goto error1
		end
		CLOSE CreateDly_cursor
		DEALLOCATE CreateDly_cursor

                update dlyndx set Total=@dTotalMoney where vchcode=@nVchcode
		--add by dcsong 2004.9.14 分配换货金额----------
		select @iChangeDay = ChangeDay,@dChangeRate = ChangeRate from btype where typeid = @szBTypeID --取得换货期限
		if @dChangeRate > 0 --如果换货率为0则不受限制
		begin
			set  @szCanDate=convert(varchar(10),(convert(datetime,@tDate)-@iChangeDay),120)
			select @dChangeTotal = abs(@dChangeTotal) + abs(isnull(sum(Total*@dChangeRate/100),0)) from dlyndx
			where [date] >= @szCanDate and [date] <= @tDate and draft = 2 and vchtype = 6 and redold = 'F' and ChangeTotal = 0 and btypeid = @szBTypeID --先处理退货 
			update dlyndx set ChangeTotal = -Total*@dChangeRate/100
			where [date] >= @szCanDate and [date] <= @tDate and draft = 2 and vchtype = 6 and redold = 'F' and ChangeTotal = 0 and btypeid = @szBTypeID --先处理退货 
			declare CreateDly_cursor cursor for select vchcode,[date],total - ChangeTotal from dlyndx 
			where [date] >= @szCanDate and [date] <= @tDate and draft = 2 and vchtype = 34 and btypeid = @szBTypeID 
				and redold = 'F' and total - ChangeTotal > 0--再处理进货
			order by [date]
		        OPEN CreateDly_cursor	
		        fetch next from CreateDly_cursor into @nChangeCode,@tChangeDate,@dChangeTotalTemp
		        while @@FETCH_STATUS=0
		        begin
				if @dChangeTotal > @dChangeTotalTemp --如果待哦分配的换货金额大于本行金额，则继续
				begin


					update dlyndx set ChangeTotal = ChangeTotal + @dChangeTotalTemp 
					where vchcode = @nChangeCode

					select @dChangeTotal = @dChangeTotal - @dChangeTotalTemp
					fetch next from CreateDly_cursor into @nChangeCode,@tChangeDate,@dChangeTotalTemp
				end
				else
				begin
					update dlyndx set ChangeTotal =  ChangeTotal + @dChangeTotal 
					where vchcode = @nChangeCode
					CLOSE CreateDly_cursor
					DEALLOCATE CreateDly_cursor
					goto finish
				end
			end
			CLOSE CreateDly_cursor
			DEALLOCATE CreateDly_cursor
		end
		--add by dcsong 2004.9.14 分配换货金额----------

		goto finish
	end

------------------------------进货换货单处理结束--------------------------


---销售单开始

        if @nVchType=11
        begin
                select @execsql='declare CreateDly_cursor cursor for '
                                +' select ATypeID, PTypeID,KTypeid, qty, Price, Total, discount, discountPrice, discountTotal,
                                tax, taxPrice, taxTotal, tax_Total, costPrice, CostTotal, blockno, prodate, comment,
                                UsedType,goodsno,unit, OrderCode,OrderDlyCode, InvoceTotal,RetailPrice,dlyorder,HandZeroCost,
				CXdlyorder,Pstutas,VipCardID from bakdly
                                 where Vchcode= '+CAST(@nVchcode AS varchar(10))
                exec (@execsql)

                select @nModiSalePrice= [stats] from syscon where [order]=3
                select @nTrackPrice = [stats] from syscon where [order]=8
	        select @nTrackDisCount = [stats] from syscon where [order]=47
                select @dTotalinMoney = 0
                select @dTempTotal = 0
                select @dTempQty = 0
                select @dTotalMoney = 0
                select @dTempCostTotal = 0
		select @nInvTag = 0
                select @dTemptaxTotal = 0

                OPEN CreateDly_cursor
                fetch next from CreateDly_cursor into @szATypeID, @szPTypeID,@szKTypeID,@dQty,@dPrice,@dTotal,@dDiscount,@dDiscountPrice, @dDiscountTotal,
                        @dTax,@dTaxPrice,@dTaxTotal,@dTax_Total,@dCostPrice, @dCostTotal,@szBlockno,@szProdate, @szMemo, @UsedType,@nGoodsNo,@unit,@nOrderCode,
			@nOrderDlyCode,@dInvoceTotal,@RetailPrice,@odlyorder,@nHandInputZero,@nCXdlyorder,@nPstatus,@nVipCardID
                while @@FETCH_STATUS=0
                begin
                        if @szPTypeID<>''
                        begin
                                if @dInvoceTotal<>0 Set @nInvoceTag =1 else Set @nInvoceTag =0
				if @nInvTag = 0 set @nInvTag = @nInvoceTag 
                                select @nCostmode=costmode, @deleted=deleted, @nSon=sonnum,@lsSerial = lsSerial from ptype where typeid=@szPTypeID
                                if @deleted=1 or @nSon>0 goto error132
				if not Exists( Select typeid from Stock where typeid=@szKTypeID and Deleted=0 and SonNum=0) goto error135r

                                select @dQty = -@dQty
                                select @dCostTotal = -@dCostTotal
                                select @dTotal = -@dTotal
                                select @dDiscountTotal = -@dDiscountTotal
                                select @dTax_Total = -@dTax_Total
                                select @dTemp=@dCostPrice--手式带入单价

                                exec  @nRet = ModifyDbf 11,@nVchcode,@tDate,@nCostmode,@GOODs_ID,@szPTypeID,'',@szETypeID,@szKTypeID,
                                @nPeriod,@dQty,@dCostTotal,@szBlockno,@szProdate,@nGoodsNo,@dTemp out,@odlyorder,@lsSerial,@nHandInputZero
                                if @nRet<0 goto error
                                select @dCostPrice = @dTemp / @dQty
                                select @dCostTotal = @dTemp

                                select @dTempTotal = @dTempTotal+@dDiscountTotal
                                select @dTempQty = @dTempQty+@dQty
                                select @dTempCostTotal = @dTempCostTotal+@dCostTotal
                                select @dTotalMoney = @dTotalMoney+@dTax_Total
                                select @dTaxTotal=@dTax_Total-@dDiscountTotal--必须用减
                                select @dTemptaxTotal = @dTemptaxTotal + @dTaxTotal

				if (@nCXdlyorder = 0) and (@nPstatus = 0) --不是特价才跟踪
				begin 
                                        if @nModiSalePrice=1 update ptype set prePrice1=@dPrice where typeid=@szPTypeID
			     		if @nTrackPrice=1 Exec F_GetCustomerPrice 'S',@szPtypeId,@szBtypeId,0,@dPrice,1,1,'','',1
			     		if @nTrackDisCount=1 Exec F_GetCustomerPrice 'SD',@szPtypeId,@szBtypeId,0,0,1,@ddiscount,'','',1		
					if (@nTrackPrice=1) or (@nTrackDisCount=1)
					begin
						select @xsdate = CONVERT(varchar(10),getdate(),120) 
						Exec F_GetCustomerPrice 'SDT',@szPtypeId,@szBtypeId,0,0,1,1,'',@xsdate,1 
					end
				end

                                insert into dlysale(vchcode,Date,VchType,ATypeID,PTypeID,BTypeID,ETypeID,KTypeID,KTypeID2,
                                    	qty,Price,Total,costPrice,CostTotal,discount,discountPrice,discountTotal,
                                	tax,taxPrice,taxTotal,tax_Total,Blockno,Prodate,comment,period,UsedType,costmode,unit,OrderCode,OrderDlyCode, 
					InvoceTotal, InvoceTag,DeptID,RetailPrice,CXdlyorder,Pstutas,VipCardID)
                                values(@nVchcode,@tDate,@nVchType,@szATypeID,@szPTypeID,@szBTypeID,@szETypeID,@szKTypeID,@szKTypeID2,
                                	@dQty,@dPrice,@dTotal,@dCostPrice,@dCostTotal,@dDiscount,@dDiscountPrice,@dDiscountTotal,
                                	@dTax,@dTaxPrice,@dTaxTotal,@dTax_Total,@szBlockno,@szProdate,@szMemo,@nPeriod,@UsedType,@nCostMode,@unit,@nOrderCode,@nOrderDlyCode, @dInvoceTotal, 
					@nInvoceTag,@DeptID,@RetailPrice,@nCXdlyorder,@nPstatus,@nVipCardID)
				--add by dcsong 2004.8.17 更新对应库存变动，一个单据号的且dlyorder为0的，当前变动的明细
                                select @nDlyOrder = @@identity
				update T_GoodsStocksGlide set dlyorder = @nDlyOrder where VchCode = @nVchcode and dlyorder = 0		
				update SN set VchLineNO = @nDlyorder,Tag = 3 where Vchcode = @nVchcode and VchLineNO = 0	
				if (@nOrderCode <> 0) and (@nOrderDlyCode <> 0)   --更新定单到货数量和定单完成标志
				begin
					update BakDlyOrder set [ToQty]=[ToQty]-@dQty where [Vchcode]=@nOrderCode and [DlyOrder]=@nOrderDlyCode 
					if not exists(select [VchCode] from BakDlyOrder where vchcode=@nOrderCode and [qty] > [Toqty]) 
						Update DlyndxOrder set [orderover]=1 where Vchcode=@nOrderCode 
				end
                        end
                        else


                        if @szATypeID=@PREPERENTIAL_ID
                        begin
                                select @dPreferential = @dTotal
                                insert into dlya(vchcode,Date,VchType,ATypeID,BTypeID,ETypeID,KTypeID,
                                    Total,period,UsedType,DeptID)
                                values(@nVchcode,@tDate,@nVchType,@szATypeID,@szBTypeID,@szETypeID,@szKTypeID,

                                        @dTotal,@nPeriod,@UsedType,@DeptID)
                        end
                        else
                        begin
				if not Exists( Select typeid from Atype where typeid=@szATypeID and Deleted=0 and SonNum=0) goto error137r
                                select @dTotalinMoney = @dTotalinMoney + @dTotal
                                insert into dlya(vchcode,Date,VchType,ATypeID,BTypeID,ETypeID,KTypeID,
                                    Total,period,UsedType,DeptID)
                                values(@nVchcode,@tDate,@nVchType,@szATypeID,@szBTypeID,@szETypeID,@szKTypeID,
                                        @dTotal,@nPeriod,@UsedType,@DeptID)
                        end
                        if @@error <> 0 goto error1


                        fetch next from CreateDly_cursor into @szATypeID, @szPTypeID,@szKTypeID,@dQty,@dPrice,@dTotal,@dDiscount,@dDiscountPrice, @dDiscountTotal,

                        @dTax,@dTaxPrice,@dTaxTotal,@dTax_Total,@dCostPrice, @dCostTotal,@szBlockno,@szProdate, @szMemo, @UsedType,@nGoodsNo,@unit,@nOrderCode,@nOrderDlyCode,
			@dInvoceTotal, @RetailPrice,@odlyorder,@nHandInputZero,@nCXdlyorder,@nPstatus,@nVipCardID
                end
--库存商品
		if @dTempCostTotal <> 0
		begin
	                insert into dlya(vchcode,Date,VchType,ATypeID,BTypeID,ETypeID,KTypeID,
	
	                                    Total,period,UsedType,DeptID)
	                        values(@nVchcode,@tDate,@nVchType,@GOODS_ID,@szBTypeID,@szETypeID,@szKTypeID,
	                                @dTempCostTotal,@nPeriod,'',@DeptID)
	                if @@rowcount <=0 goto error1
		end
--应交税金增加
                if @dTempTaxTotal<>0
                begin
                        insert into dlya(vchcode,Date,VchType,ATypeID,BTypeID,ETypeID,KTypeID,

                                    Total,period,UsedType,DeptID)
                        values(@nVchcode,@tDate,@nVchType,@TAX_ID,@szBTypeID,@szETypeID,@szKTypeID,
                                -@dTemptaxTotal,@nPeriod,'',@DeptID)
                        if @@rowcount <=0 goto error1
                end

--销售收入
		if @dTempTotal <> 0 
		begin
	                insert into dlya(vchcode,Date,VchType,ATypeID,BTypeID,ETypeID,KTypeID,
	                            Total,period,UsedType,DeptID)
	                        values(@nVchcode,@tDate,@nVchType,@SALE_INCOME_ID,@szBTypeID,@szETypeID,@szKTypeID,
	                                -@dTempTotal,@nPeriod,'',@DeptID)
	                if @@rowcount <=0 goto error1
		end
--销售成本
		if @dTempCostTotal <> 0
		begin
	                insert into dlya(vchcode,Date,VchType,ATypeID,BTypeID,ETypeID,KTypeID,
	
	                                    Total,period,UsedType,DeptID)
	                        values(@nVchcode,@tDate,@nVchType,@SALE_COST_ID,@szBTypeID,@szETypeID,@szKTypeID,
	                                -@dTempCostTotal,@nPeriod,'',@DeptID)
	                if @@rowcount <=0 goto error1
		end
--应收应付
                select @dTemp = -@dTotalMoney-(@dTotalInMoney+@dPreferential) --应收 = 合计金额-（优惠金额+收款金额)
                if @dTemp<>0
                begin
                        insert into dlya(vchcode,Date,VchType,ATypeID,BTypeID,ETypeID,KTypeID,


                                    Total,period,UsedType,DeptID)
                        values(@nVchcode,@tDate,@nVchType,@AR_ID,@szBTypeID,@szETypeID,@szKTypeID,
                                @dTemp,@nPeriod,'',@DeptID)
                        if @@rowcount <=0 goto error1
                end

                update dlyndx set Total=Abs(@dTotalMoney),InvoceTag = @nInvTag where vchcode=@nVchcode
                if @@rowcount <=0 goto error1

                CLOSE CreateDly_cursor
                DEALLOCATE CreateDly_cursor
        end
------------------------------销售单处理结束--------------------------

---销售换货单开始

        if @nVchType=142
        begin
                select @execsql='declare CreateDly_cursor cursor for '
                                +' select ATypeID, PTypeID,KTypeid, qty, Price, Total, discount, discountPrice, discountTotal,
                                tax, taxPrice, taxTotal, tax_Total, costPrice, CostTotal, blockno, prodate, comment,
                                UsedType,goodsno,unit, OrderCode,OrderDlyCode, InvoceTotal,RetailPrice,dlyorder,HandZeroCost from bakdly
                                 where Vchcode= '+CAST(@nVchcode AS varchar(10))

                exec (@execsql)

                select @nModiSalePrice= [stats] from syscon where [order]=3
                select @nTrackPrice = [stats] from syscon where [order]=8
	   select @nTrackDisCount = [stats] from syscon where [order]=47
                select @dTotalinMoney = 0
                select @dTempTotal = 0
                select @dTempQty = 0
                select @dTotalMoney = 0
                select @dTempCostTotal = 0
		select @nInvTag = 0
                select @dTemptaxTotal = 0
		select @dChangeTotal = 0

                OPEN CreateDly_cursor
                fetch next from CreateDly_cursor into @szATypeID, @szPTypeID,@szKTypeID,@dQty,@dPrice,@dTotal,@dDiscount,@dDiscountPrice, @dDiscountTotal,
                        @dTax,@dTaxPrice,@dTaxTotal,@dTax_Total,@dCostPrice, @dCostTotal,@szBlockno,@szProdate, @szMemo, @UsedType,@nGoodsNo,@unit,@nOrderCode,
			@nOrderDlyCode,@dInvoceTotal,@RetailPrice,@odlyorder,@nHandInputZero
                while @@FETCH_STATUS=0
                begin
                        if @szPTypeID<>''
                        begin
				if @UsedType = 1 --退货
				begin
	                                select @nCostmode=costmode, @deleted=deleted, @nSon=sonnum,@lsSerial = lsSerial from ptype where typeid=@szPTypeID
	                                if @deleted=1 or @nSon>0 goto error132
					if not Exists( Select typeid from Stock where typeid=@szKTypeID and Deleted=0 and SonNum=0) goto error135r

	                                exec  @nRet = ModifyDbf @nVchType,@nVchcode,@tDate,@nCostmode,@GOODs_ID,@szPTypeID,'',@szETypeID,@szKTypeID,
	                                @nPeriod,@dQty,@dCostTotal,@szBlockno,@szProdate,0,@dTemp out,@odlyorder,@lsSerial
	                                if @nRet<0 goto error
	                                select @dCostPrice = @dTemp / @dQty
	                                select @dCostTotal = @dTemp
	
	                                select @dTempTotal = @dTempTotal+@dDiscountTotal
	                                select @dTempQty = @dTempQty+@dQty
	                                select @dTempCostTotal = @dTempCostTotal+@dCostTotal
	                                select @dTotalMoney = @dTotalMoney+@dTax_Total
					select @dChangeTotal = @dTotalMoney
	                                select @dTemptaxTotal = @dTemptaxTotal + @dTaxTotal
	
	                                insert into dlysale(vchcode,Date,VchType,ATypeID,PTypeID,BTypeID,ETypeID,KTypeID,KTypeID2,
	                                    qty,Price,Total,costPrice,CostTotal,discount,discountPrice,discountTotal,
	                                tax,taxPrice,taxTotal,tax_Total,Blockno,Prodate,comment,period,UsedType,costmode,unit,DeptID,RetailPrice)
	                                values(@nVchcode,@tDate,@nVchType,@szATypeID,@szPTypeID,@szBTypeID,@szETypeID,@szKTypeID,@szKTypeID2,
	                                @dQty,@dPrice,@dTotal,@dCostPrice,@dCostTotal,@dDiscount,@dDiscountPrice,@dDiscountTotal,
	                                @dTax,@dTaxPrice,@dTaxTotal,@dTax_Total,@szBlockno,@szProdate,@szMemo,@nPeriod,@UsedType,@nCostMode,@unit,@DeptID,@RetailPrice)
					--add by dcsong 2004.8.17 更新对应库存变动，一个单据号的且dlyorder为0的，当前变动的明细
	                                select @nDlyOrder = @@identity

					update T_GoodsStocksGlide set dlyorder = @nDlyOrder where VchCode = @nVchcode and dlyorder = 0		
					update SN set VchLineNO = @nDlyorder,Tag = 2 where Vchcode = @nVchcode and VchLineNO = 0	
				end
				else if @UsedType = 2  --销售
				begin
					if @dInvoceTotal<>0 Set @nInvoceTag =1 else Set @nInvoceTag =0
					if @nInvTag = 0 set @nInvTag = @nInvoceTag 
					select @nCostmode=costmode, @deleted=deleted, @nSon=sonnum,@lsSerial = lsSerial from ptype where typeid=@szPTypeID
					if @deleted=1 or @nSon>0 goto error132
					if not Exists( Select typeid from Stock where typeid=@szKTypeID and Deleted=0 and SonNum=0) goto error135r
					
					select @dQty = -@dQty
					select @dCostTotal = -@dCostTotal
					select @dTotal = -@dTotal
					select @dDiscountTotal = -@dDiscountTotal
					select @dTax_Total = -@dTax_Total
					select @dTemp=@dCostPrice--手式带入单价
					
					exec  @nRet = ModifyDbf @nVchType,@nVchcode,@tDate,@nCostmode,@GOODs_ID,@szPTypeID,'',@szETypeID,@szKTypeID,
						@nPeriod,@dQty,@dCostTotal,@szBlockno,@szProdate,@nGoodsNo,@dTemp out,@odlyorder,@lsSerial,@nHandInputZero
					if @nRet<0 goto error
					select @dCostPrice = @dTemp / @dQty
					select @dCostTotal = @dTemp
					
					select @dTempTotal = @dTempTotal+@dDiscountTotal
					select @dTempQty = @dTempQty+@dQty
					select @dTempCostTotal = @dTempCostTotal+@dCostTotal
					select @dTotalMoney = @dTotalMoney+@dTax_Total
					select @dTaxTotal=@dTax_Total-@dDiscountTotal--必须用减
					select @dTemptaxTotal = @dTemptaxTotal + @dTaxTotal
					if @nModiSalePrice=1 update ptype set prePrice1=@dPrice where typeid=@szPTypeID					
					insert into dlysale(vchcode,Date,VchType,ATypeID,PTypeID,BTypeID,ETypeID,KTypeID,KTypeID2,
					    qty,Price,Total,costPrice,CostTotal,discount,discountPrice,discountTotal,
					tax,taxPrice,taxTotal,tax_Total,Blockno,Prodate,comment,period,UsedType,costmode,unit,OrderCode,OrderDlyCode, InvoceTotal, InvoceTag,DeptID,RetailPrice)
					values(@nVchcode,@tDate,@nVchType,@szATypeID,@szPTypeID,@szBTypeID,@szETypeID,@szKTypeID,@szKTypeID2,
					@dQty,@dPrice,@dTotal,@dCostPrice,@dCostTotal,@dDiscount,@dDiscountPrice,@dDiscountTotal,
					@dTax,@dTaxPrice,@dTaxTotal,@dTax_Total,@szBlockno,@szProdate,@szMemo,@nPeriod,@UsedType,@nCostMode,@unit,@nOrderCode,@nOrderDlyCode, @dInvoceTotal, @nInvoceTag,@DeptID,@RetailPrice)
					--add by dcsong 2004.8.17 更新对应库存变动，一个单据号的且dlyorder为0的，当前变动的明细
	                                select @nDlyOrder = @@identity
					update T_GoodsStocksGlide set dlyorder = @nDlyOrder where VchCode = @nVchcode and dlyorder = 0		
					update SN set VchLineNO = @nDlyorder,Tag = 3 where Vchcode = @nVchcode and VchLineNO = 0	
				end
                        end
                        else
                        if @szATypeID=@PREPERENTIAL_ID
                        begin
                                select @dPreferential = @dTotal
                                insert into dlya(vchcode,Date,VchType,ATypeID,BTypeID,ETypeID,KTypeID,
                                    Total,period,UsedType,DeptID)
                                values(@nVchcode,@tDate,@nVchType,@szATypeID,@szBTypeID,@szETypeID,@szKTypeID,
                                        @dTotal,@nPeriod,@UsedType,@DeptID)
                        end
                        else
                        begin
				if not Exists( Select typeid from Atype where typeid=@szATypeID and Deleted=0 and SonNum=0) goto error137r
                                select @dTotalinMoney = @dTotalinMoney + @dTotal
                                insert into dlya(vchcode,Date,VchType,ATypeID,BTypeID,ETypeID,KTypeID,
                                    Total,period,UsedType,DeptID)
                                values(@nVchcode,@tDate,@nVchType,@szATypeID,@szBTypeID,@szETypeID,@szKTypeID,
                                        @dTotal,@nPeriod,@UsedType,@DeptID)
                        end
                        if @@error <> 0 goto error1


                        fetch next from CreateDly_cursor into @szATypeID, @szPTypeID,@szKTypeID,@dQty,@dPrice,@dTotal,@dDiscount,@dDiscountPrice, @dDiscountTotal,

                        @dTax,@dTaxPrice,@dTaxTotal,@dTax_Total,@dCostPrice, @dCostTotal,@szBlockno,@szProdate, @szMemo, @UsedType,@nGoodsNo,@unit,@nOrderCode,
			@nOrderDlyCode,@dInvoceTotal, @RetailPrice,@odlyorder,@nHandInputZero
                end
--库存商品
		if @dTempCostTotal <> 0 
		begin
	                insert into dlya(vchcode,Date,VchType,ATypeID,BTypeID,ETypeID,KTypeID,
	
	                                    Total,period,UsedType,DeptID)
	                        values(@nVchcode,@tDate,@nVchType,@GOODS_ID,@szBTypeID,@szETypeID,@szKTypeID,
	                                @dTempCostTotal,@nPeriod,'',@DeptID)
	                if @@rowcount <=0 goto error1
		end
--应交税金增加
                if @dTempTaxTotal<>0
                begin
                        insert into dlya(vchcode,Date,VchType,ATypeID,BTypeID,ETypeID,KTypeID,

                                    Total,period,UsedType,DeptID)
                        values(@nVchcode,@tDate,@nVchType,@TAX_ID,@szBTypeID,@szETypeID,@szKTypeID,
                                -@dTemptaxTotal,@nPeriod,'',@DeptID)
                        if @@rowcount <=0 goto error1
                end

--销售收入
		if @dTempTotal <> 0 
		begin
	                insert into dlya(vchcode,Date,VchType,ATypeID,BTypeID,ETypeID,KTypeID,
	                            Total,period,UsedType,DeptID)
	                        values(@nVchcode,@tDate,@nVchType,@SALE_INCOME_ID,@szBTypeID,@szETypeID,@szKTypeID,
	                                -@dTempTotal,@nPeriod,'',@DeptID)
	                if @@rowcount <=0 goto error1
		end
--销售成本
		if @dTempCostTotal <> 0
		begin
	                insert into dlya(vchcode,Date,VchType,ATypeID,BTypeID,ETypeID,KTypeID,
	
	                                    Total,period,UsedType,DeptID)
	                        values(@nVchcode,@tDate,@nVchType,@SALE_COST_ID,@szBTypeID,@szETypeID,@szKTypeID,
	                                -@dTempCostTotal,@nPeriod,'',@DeptID)
	                if @@rowcount <=0 goto error1
		end
--应收应付
                select @dTemp = -@dTotalMoney-(@dTotalInMoney+@dPreferential) --应收 = 合计金额-（优惠金额+收款金额)
                if @dTemp<>0
                begin
                        insert into dlya(vchcode,Date,VchType,ATypeID,BTypeID,ETypeID,KTypeID,
                                    Total,period,UsedType,DeptID)
                        values(@nVchcode,@tDate,@nVchType,@AR_ID,@szBTypeID,@szETypeID,@szKTypeID,
                                @dTemp,@nPeriod,'',@DeptID)
                        if @@rowcount <=0 goto error1
                end

                update dlyndx set Total=-1*@dTotalMoney,InvoceTag = @nInvTag where vchcode=@nVchcode
                if @@rowcount <=0 goto error1

                CLOSE CreateDly_cursor
                DEALLOCATE CreateDly_cursor

		--add by dcsong 2004.9.14 分配换货金额----------
		select @iChangeDay = ChangeDay,@dChangeRate = ChangeRate from btype where typeid = @szBTypeID --取得换货期限
		if @dChangeRate > 0 --如果换货率为0则不受限制
		begin
			set  @szCanDate=convert(varchar(10),(convert(datetime,@tDate)-@iChangeDay),120)
			select @dChangeTotal = abs(@dChangeTotal) + abs(isnull(sum(Total*@dChangeRate/100),0)) from dlyndx
			where [date] >= @szCanDate and [date] <= @tDate and draft = 2 and vchtype = 45 and redold = 'F' and ChangeTotal = 0 and btypeid = @szBTypeID --先处理退货 

			update dlyndx set ChangeTotal = -1*Total*@dChangeRate/100
			where [date] >= @szCanDate and [date] <= @tDate and draft = 2 and vchtype = 45 and redold = 'F' and ChangeTotal = 0 and btypeid = @szBTypeID --先处理退货 
		
			declare CreateDly_cursor cursor for select vchcode,[date],total - ChangeTotal from dlyndx 
			where [date] >= @szCanDate and [date] <= @tDate and draft = 2 and vchtype = 11 
				and redold = 'F' and total - ChangeTotal > 0 and btypeid = @szBTypeID --再处理进货
			order by [date]
		        OPEN CreateDly_cursor	
		        fetch next from CreateDly_cursor into @nChangeCode,@tChangeDate,@dChangeTotalTemp
		        while @@FETCH_STATUS=0
		        begin
				if @dChangeTotal > @dChangeTotalTemp --如果待分配的换货金额小于本行金额，则继续
				begin
					update dlyndx set ChangeTotal = ChangeTotal + @dChangeTotalTemp 
					where vchcode = @nChangeCode
					select @dChangeTotal = @dChangeTotal - @dChangeTotalTemp
					fetch next from CreateDly_cursor into @nChangeCode,@tChangeDate,@dChangeTotalTemp
				end
				else
				begin
					update dlyndx set ChangeTotal = ChangeTotal + @dChangeTotal 
					where vchcode = @nChangeCode
			                CLOSE CreateDly_cursor
			                DEALLOCATE CreateDly_cursor
					goto finish
				end
			end
			CLOSE CreateDly_cursor
			DEALLOCATE CreateDly_cursor
		end
		--add by dcsong 2004.9.14 分配换货金额----------

        end
------------------------------销售换货单单处理结束--------------------------


---发货单开始

        if @nVchType=23
        begin
                select @type=4
                select @szAutoSummary = '第'+@szNumber+'发货单'
                select @execsql='declare CreateDly_cursor cursor for '
                                +' select ATypeID, PTypeID, qty, Price, Total, discount, discountPrice, discountTotal,
                                tax, taxPrice, taxTotal, tax_Total, costPrice, CostTotal, blockno, prodate, comment, UsedType,goodsno,ordercode,unit from bakdly
                                 where Vchcode= '+CAST(@nVchcode AS varchar(10))+' order by dlyorder'

                exec (@execsql)


                select @nModiSalePrice= [stats] from syscon where [order]=3
                select @nTrackPrice = [stats] from syscon where [order]=8

                select @dTempTotal = 0
                select @dTempQty = 0
                select @dTotalMoney = 0
                select @dTempCostTotal = 0
                select @dTemptaxTotal = 0
                OPEN CreateDly_cursor
                fetch next from CreateDly_cursor into @szATypeID, @szPTypeID,@dQty,@dPrice,@dTotal,@dDiscount,@dDiscountPrice, @dDiscountTotal,
                        @dTax,@dTaxPrice,@dTaxTotal,@dTax_Total,@dCostPrice, @dCostTotal,@szBlockno,@szProdate, @szMemo,  @UsedType,@nGoodsNo,@nOrderCode,@unit
                while @@FETCH_STATUS=0
                begin
                        if (@szPTypeID<>''  ) and (@szPTypeID<>'00000')
                        begin
                                select @nCostmode=costmode, @deleted=deleted, @nSon=sonnum from ptype where typeid=@szPTypeID
                                if @deleted=1 or @nSon>0 goto error132
                                select @dQty = -@dQty
                                select @dCostTotal = -@dCostTotal
                                select @dTotal = -@dTotal
                                select @dDiscountTotal = -@dDiscountTotal
                                select @dTax_Total = -@dTax_Total
                                select @dTemp=@dCostPrice

                                exec  @nRet = ModifyDbf @nVchType,@nVchcode,@tDate,@nCostmode,@GOODs_ID,@szPTypeID,'',@szETypeID,@szKTypeID,
                                @nPeriod,@dQty,@dCostTotal,@szBlockno,@szProdate,@nGoodsNo,@dTemp out
                                if @nRet<0 goto error

                                select @dCostPrice = @dTemp / @dQty
                                select @dCostTotal = @dTemp

                                select @dTempTotal = @dTempTotal+@dDiscountTotal
                                select @dTempQty = @dTempQty+@dQty
                                select @dTempCostTotal = @dTempCostTotal+@dCostTotal
                                select @dTotalMoney = @dTotalMoney+@dTax_Total
                                select @dTaxTotal=@dTax_Total-@dDiscountTotal
                                select @dTemptaxTotal = @dTemptaxTotal + @dTaxTotal

                                insert into dlyother(vchcode,Date,VchType,ATypeID,PTypeID,BTypeID,ETypeID,KTypeID,KTypeID2,
                                    qty,Price,Total,costPrice,CostTotal,discount,discountPrice,discountTotal,
                                tax,taxPrice,taxTotal,tax_Total,Blockno,Prodate,comment,period,UsedType,costmode,unit,DeptID)
                                values(@nVchcode,@tDate,@nVchType,@szATypeID,@szPTypeID,@szBTypeID,@szETypeID,@szKTypeID,@szKTypeID2,
                                @dQty,@dPrice,@dTotal,@dCostPrice,@dCostTotal,@dDiscount,@dDiscountPrice,@dDiscountTotal,
                                @dTax,@dTaxPrice,@dTaxTotal,@dTax_Total,@szBlockno,@szProdate,@szMemo,@nPeriod,@UsedType,@nCostMode,@unit,@DeptID)
				--add by dcsong 2004.8.17 更新对应库存变动，一个单据号的且dlyorder为0的，当前变动的明细
                                select @nDlyOrder = @@identity
				update T_GoodsStocksGlide set dlyorder = @nDlyOrder where VchCode = @nVchcode and dlyorder = 0	
                                if @@rowcount <=0 goto error1

                                select @dQty = -@dQty
                                select @dCostTotal = -@dCostTotal
                                select @dDiscountTotal = -@dDiscountTotal
                                select @dTax_Total = -@dTax_Total

                                insert into dlyother(vchcode,Date,VchType,ATypeID,PTypeID,BTypeID,ETypeID,KTypeID,KTypeID2,
                                    qty,Price,Total,costPrice,CostTotal,discount,discountPrice,discountTotal,
                                tax,taxPrice,taxTotal,tax_Total,Blockno,Prodate,comment,period,UsedType,costmode,unit,PDETAIL,DeptID)
                                values(@nVchcode,@tDate,@nVchType,@szATypeID,@szPTypeID,@szBTypeID,@szETypeID,@SEND_GOODS_STOCK_ID,@szKTypeID2,
                                @dQty,@dPrice,-@dTotal,@dCostPrice,@dCostTotal,@dDiscount,@dDiscountPrice,@dDiscountTotal,
                                @dTax,@dTaxPrice,-@dTaxTotal,@dTax_Total,@szBlockno,@szProdate,@szMemo,@nPeriod,0,@nCostMode,@unit,2,@DeptID)
                                if @@rowcount <=0 goto error1


                                exec  @nRet = ModifyDbfCom @nVchType,@GOODs_ID,@szPTypeID,@szBTypeID,
                                @dQty,@dTax_Total,@szBlockno,@szProdate,@dCostTotal,@type,@dTemp out,@dTemp1 out
                                if @nRet<0 goto error
                        end


                        fetch next from CreateDly_cursor into @szATypeID, @szPTypeID,@dQty,@dPrice,@dTotal,@dDiscount,@dDiscountPrice, @dDiscountTotal,

                        @dTax,@dTaxPrice,@dTaxTotal,@dTax_Total,@dCostPrice, @dCostTotal,@szBlockno,@szProdate, @szMemo,  @UsedType,@nGoodsNo,@nOrderCode,@unit
                end
--库存商品

                insert into dlya(vchcode,Date,VchType,ATypeID,BTypeID,ETypeID,KTypeID,
                                    Total,period,UsedType,comment,DeptID)
                        values(@nVchcode,@tDate,@nVchType,@GOODS_ID,@szBTypeID,@szETypeID,@szKTypeID,
                                @dTempCostTotal,@nPeriod,'',@szAutoSummary,@DeptID)
                if @@rowcount <=0 goto error1
--发出商品

                insert into dlya(vchcode,Date,VchType,ATypeID,BTypeID,ETypeID,KTypeID,
                                    Total,period,UsedType,comment,DeptID)
                        values(@nVchcode,@tDate,@nVchType,@SEND_GOODS_ID,@szBTypeID,@szETypeID,@szKTypeID,

                                -@dTempCostTotal,@nPeriod,'',@szAutoSummary,@DeptID)
                if @@rowcount <=0 goto error1
--应收_销项增值税和应交税金
/*              if @dTempTaxTotal<>0
                begin
                        insert into dlya(vchcode,Date,VchType,ATypeID,BTypeID,ETypeID,KTypeID,

                                    debitTotal,lendTotal,period,UsedType,comment,DeptID)
                        values(@nVchcode,@tDate,@nVchType,@AR_SALETAX_ID,@szBTypeID,@szETypeID,@szKTypeID,
                                -@dTemptaxTotal,0,@nPeriod,'',@szAutoSummary,@DeptID)
                        if @@rowcount <=0 goto error1
                        insert into dlya(vchcode,Date,VchType,ATypeID,BTypeID,ETypeID,KTypeID,

                                    debitTotal,lendTotal,period,UsedType,comment,DeptID)
                        values(@nVchcode,@tDate,@nVchType,@SALETAX_ID,@szBTypeID,@szETypeID,@szKTypeID,

                                0,-@dTemptaxTotal,@nPeriod,'',@szAutoSummary,@DeptID)
                        if @@rowcount <=0 goto error1
                end
*/
--修改BTYPE发出商品
	update btype set sendgoods=sendgoods-@dTempCostTotal,sendgoodsj=sendgoodsj-@dtotalMoney where typeid=@szBtypeid
	if @@rowcount <=0 goto error1

                update dlyndx set Total=Abs(@dTotalMoney) where vchcode=@nVchcode
                if @@rowcount <=0 goto error1

                CLOSE CreateDly_cursor
                DEALLOCATE CreateDly_cursor
        end
------------------------------发货单处理结束--------------------------

---发货退货单开始

        if @nVchType=29
        begin
                select @type=4
                select @szAutoSummary = '第'+@szNumber+'发货退货单'
                select @execsql='declare CreateDly_cursor cursor for '
                                +' select ATypeID, PTypeID, qty, Price, Total, discount, discountPrice, discountTotal,
                                tax, taxPrice, taxTotal, tax_Total, costPrice, CostTotal, blockno, prodate, comment, UsedType,goodsno,ordercode,unit from bakdly
                                 where Vchcode= '+CAST(@nVchcode AS varchar(10))+' order by dlyorder'
                exec (@execsql)

                select @nModiSalePrice= [stats] from syscon where [order]=3
                select @nTrackPrice = [stats] from syscon where [order]=8

                select @dTempTotal = 0
                select @dTempQty = 0
                select @dTotalMoney = 0
                select @dTempCostTotal = 0
                select @dTemptaxTotal = 0
                OPEN CreateDly_cursor
                fetch next from CreateDly_cursor into @szATypeID, @szPTypeID,@dQty,@dPrice,@dTotal,@dDiscount,@dDiscountPrice, @dDiscountTotal,
                        @dTax,@dTaxPrice,@dTaxTotal,@dTax_Total,@dCostPrice, @dCostTotal,@szBlockno,@szProdate, @szMemo,  @UsedType,@nGoodsNo,@nOrderCode,@unit
                while @@FETCH_STATUS=0
                begin
                        if (@szPTypeID<>''  ) and (@szPTypeID<>'00000')
                        begin
                                select @nCostmode=costmode, @deleted=deleted, @nSon=sonnum from ptype where typeid=@szPTypeID
                                if @deleted=1 or @nSon>0 goto error132
                                select @dQty = -@dQty
                 select @dCostTotal = -@dCostTotal
--                              select @dTotal = -@dTotal
                                select @dDiscountTotal = -@dDiscountTotal
                                select @dTax_Total = -@dTax_Total
                                exec  @nRet = ModifyDbfCom @nVchType,@GOODs_ID,@szPTypeID,@szBTypeID,
                                @dQty,@dTax_Total,@szBlockno,@szProdate,@dCostTotal,@type,@dTemp out,@dTemp1 out
                                if @nRet<0 goto error

                                select @dCostTotal=@dTemp1
                                insert into dlyother(vchcode,Date,VchType,ATypeID,PTypeID,BTypeID,ETypeID,KTypeID,KTypeID2,
                                    qty,Price,Total,costPrice,CostTotal,discount,discountPrice,discountTotal,
                                tax,taxPrice,taxTotal,tax_Total,Blockno,Prodate,comment,period,UsedType,costmode,unit,PDETAIL,DeptID)
                                values(@nVchcode,@tDate,@nVchType,@szATypeID,@szPTypeID,@szBTypeID,@szETypeID,@SEND_GOODS_STOCK_ID,@szKTypeID2,
                                @dQty,@dPrice,-@dTotal,@dCostPrice,@dCostTotal,@dDiscount,@dDiscountPrice,@dDiscountTotal,
                                @dTax,@dTaxPrice,-@dTaxTotal,@dTax_Total,@szBlockno,@szProdate,@szMemo,@nPeriod,0,@nCostMode,@unit,2,@DeptID)
                                if @@rowcount <=0 goto error1

                                select @dQty = -@dQty
                                select @dCostTotal = -@dTemp1
--                              select @dTotal = -@dTotal
                                select @dDiscountTotal = -@dDiscountTotal
                                select @dTax_Total = -@dTax_Total

                                exec  @nRet = ModifyDbf @nVchType,@nVchcode,@tDate,@nCostmode,@GOODs_ID,@szPTypeID,'',@szETypeID,@szKTypeID,
                                @nPeriod,@dQty,@dCostTotal,@szBlockno,@szProdate,@nGoodsNo,@dTemp out
                                if @nRet<0 goto error
                                select @dCostPrice = @dTemp / @dQty
                                select @dCostTotal = @dTemp

                                select @dTempTotal = @dTempTotal+@dDiscountTotal

                                select @dTempQty = @dTempQty+@dQty
                                select @dTempCostTotal = @dTempCostTotal+@dCostTotal
                                select @dTotalMoney = @dTotalMoney+@dTax_Total
                                select @dTaxTotal=@dTax_Total-@dDiscountTotal
                                select @dTemptaxTotal = @dTemptaxTotal + @dTaxTotal

                                insert into dlyother(vchcode,Date,VchType,ATypeID,PTypeID,BTypeID,ETypeID,KTypeID,KTypeID2,

                                    qty,Price,Total,costPrice,CostTotal,discount,discountPrice,discountTotal,
                                tax,taxPrice,taxTotal,tax_Total,Blockno,Prodate,comment,period,UsedType,costmode,unit,DeptID)
                                values(@nVchcode,@tDate,@nVchType,@szATypeID,@szPTypeID,@szBTypeID,@szETypeID,@szKTypeID,@szKTypeID2,
                                @dQty,@dPrice,@dTotal,@dCostPrice,@dCostTotal,@dDiscount,@dDiscountPrice,@dDiscountTotal,
                                @dTax,@dTaxPrice,@dTaxTotal,@dTax_Total,@szBlockno,@szProdate,@szMemo,@nPeriod,@UsedType,@nCostMode,@unit,@DeptID)
				--add by dcsong 2004.8.17 更新对应库存变动，一个单据号的且dlyorder为0的，当前变动的明细
                                select @nDlyOrder = @@identity
				update T_GoodsStocksGlide set dlyorder = @nDlyOrder where VchCode = @nVchcode and dlyorder = 0	
                                if @@rowcount <=0 goto error1
                        end


                        fetch next from CreateDly_cursor into @szATypeID, @szPTypeID,@dQty,@dPrice,@dTotal,@dDiscount,@dDiscountPrice, @dDiscountTotal,

                        @dTax,@dTaxPrice,@dTaxTotal,@dTax_Total,@dCostPrice, @dCostTotal,@szBlockno,@szProdate, @szMemo, @UsedType,@nGoodsNo,@nOrderCode,@unit
                end
--库存商品
                insert into dlya(vchcode,Date,VchType,ATypeID,BTypeID,ETypeID,KTypeID,
                                 Total,   period,UsedType,comment,DeptID)
                        values(@nVchcode,@tDate,@nVchType,@GOODS_ID,@szBTypeID,@szETypeID,@szKTypeID,
                                @dTempCostTotal,@nPeriod,'',@szAutoSummary,@DeptID)
                if @@rowcount <=0 goto error1
--发出商品

                insert into dlya(vchcode,Date,VchType,ATypeID,BTypeID,ETypeID,KTypeID,

                                    Total,period,UsedType,comment,DeptID)
                        values(@nVchcode,@tDate,@nVchType,@SEND_GOODS_ID,@szBTypeID,@szETypeID,@szKTypeID,
                                -@dTempCostTotal,@nPeriod,'',@szAutoSummary,@DeptID)
                if @@rowcount <=0 goto error1
--应收_销项增值税和应交税金
/*              if @dTempTaxTotal<>0
                begin
                        insert into dlya(vchcode,Date,VchType,ATypeID,BTypeID,ETypeID,KTypeID,

                                    debitTotal,lendTotal,period,UsedType,comment,DeptID)
                        values(@nVchcode,@tDate,@nVchType,@AR_SALETAX_ID,@szBTypeID,@szETypeID,@szKTypeID,
                                0,@dTemptaxTotal,@nPeriod,'',@szAutoSummary,@DeptID)
                        if @@rowcount <=0 goto error1
                        insert into dlya(vchcode,Date,VchType,ATypeID,BTypeID,ETypeID,KTypeID,

                                    debitTotal,lendTotal,period,UsedType,comment,DeptID)
                        values(@nVchcode,@tDate,@nVchType,@SALETAX_ID,@szBTypeID,@szETypeID,@szKTypeID,
                                @dTemptaxTotal,0,@nPeriod,'',@szAutoSummary,@DeptID)
                        if @@rowcount <=0 goto error1
                end
*/
--修改BTYPE发出商品
		update btype set sendgoods=sendgoods-@dTempCostTotal,sendgoodsj=sendgoodsj-@dtotalMoney where typeid=@szBtypeid
		if @@rowcount <=0 goto error1

                update dlyndx set Total=Abs(@dTotalMoney) where vchcode=@nVchcode

                if @@rowcount <=0 goto error1

                CLOSE CreateDly_cursor
                DEALLOCATE CreateDly_cursor
        end
------------------------------发货退货单处理结束--------------------------




---发货单结算开始

        if @nVchType=24
        begin
                select @type=4
                select @szAutoSummary = '第'+@szNumber+'发货结算单'

                select @dTempTotal = 0
                select @dTempQty = 0
                select @dTotalMoney = 0
                select @dTempCostTotal = 0
                select @dTemptaxTotal = 0
                select @dTotalInMoney=0

                select @execsql='declare CreateDly_send cursor for '
                                +' select ATypeID, PTypeID, qty, Price, Total, discount, discountPrice, discountTotal,
                                tax, taxPrice, taxTotal, tax_Total, costPrice, CostTotal, blockno, prodate, comment,  UsedType from bakdly
                                 where Vchcode= '+CAST(@nVchcode AS varchar(10))+' order by dlyorder'
                exec (@execsql)

                OPEN CreateDly_send

                fetch next from CreateDly_send into @szATypeID, @szPTypeID,@dQty,@dPrice,@dTotal,@dDiscount,@dDiscountPrice, @dDiscountTotal,
                        @dTax,@dTaxPrice,@dTaxTotal,@dTax_Total,@dCostPrice, @dCostTotal,@szBlockno,@szProdate, @szMemo,  @UsedType
                while @@FETCH_STATUS=0
                begin

                        if @UsedType='1'
                        begin
                                select @dTotalInMoney = @dTotalInMoney+@dTotal

                        end
                        insert into dlya(vchcode,Date,VchType,ATypeID,BTypeID,ETypeID,KTypeID,
                                    Total,period,UsedType,comment,DeptID,memo)
       values(@nVchcode,@tDate,@nVchType,@szATypeID,@szBTypeID,@szETypeID,@szKTypeID,
                                @dTotal,@nPeriod,@UsedType,@szAutoSummary,@DeptID,@szMemo)
                        if @@rowcount <=0 goto error1
                        fetch next from CreateDly_send into @szATypeID, @szPTypeID,@dQty,@dPrice,@dTotal,@dDiscount,@dDiscountPrice, @dDiscountTotal,
                        @dTax,@dTaxPrice,@dTaxTotal,@dTax_Total,@dCostPrice, @dCostTotal,@szBlockno,@szProdate, @szMemo, @UsedType
                end
                CLOSE CreateDly_send
                DEALLOCATE CreateDly_send

                select @execsql='declare CreateDly_cursor cursor for '
                                +' select svchcode,Total from sendjsdly where draft=1 and jsvchcode='+CAST(@nVchcode AS varchar(10))+
                                  ' order by dlyorder'
                exec (@execsql)
                OPEN CreateDly_cursor
                fetch next from CreateDly_cursor into @svchcode, @jsTotal
                while @@FETCH_STATUS=0
                begin
                        select @dTax_Totalover=0

                        select @dDiscountTotalover=0,@dCostTotalover=0
                        select @nTemp=VchType from dlyndx where vchcode=@sVchcode
                        if @svchcode=0 --结算期初
                        begin
                                select @dTax_Total=sum(taxTotal),@dTotal=sum(Total),@dCostTotal=sum(CostTotal)  from inicommission where BTypeID=@szBTypeID and type=4
                                select @dTax_Totalover=isnull(Total,0),@dDiscountTotalover=isnull(discountTotalover,0),
                                @dCostTotalover=isnull(CostTotalover,0) from sendjsdly where svchcode=0 and draft=3 and btypeid=@szBtypeid
                        end
                        else
                        begin
                                select @dTax_Total=sum(-tax_Total),@dTotal=sum(-discountTotal),@dCostTotal=sum(-CostTotal) from dlyother where vchcode=@svchcode and pdetail<>2
                                select @dTax_Totalover=isnull(Total,0),@dDiscountTotalover=isnull(discountTotalover,0),
                                @dCostTotalover=isnull(CostTotalover,0) from sendjsdly where svchcode=@svchcode and draft=3 and btypeid=@szBtypeid

                                if @nTemp=52--发货调价单
                                begin
                                        select @dTax_Total=-@dTax_Total
                                end
                        end


                        if  @jsTotal>=@dTax_Total-@dTax_Totalover
                        begin
                                if exists(select * from sendjsdly where svchcode=@svchcode and draft=3 and type=4 and btypeid=@szBtypeid)
                                update sendjsdly set Total=@dTax_Total where svchcode=@svchcode and draft=3 and type=4 and btypeid=@szBtypeid
                                else insert into sendjsdly(BTypeID,Total,draft,jsvchcode,svchcode,type)
                                values(@szBTypeID,@dTax_Total,3,@nVchcode,@svchcode,4)
                                if @@error<>0 goto error145
                                select @dCostTotaljs=@dCostTotal-@dCostTotalover
                                select @dTax_Totaljs=@jsTotal
                                select @dDiscountTotaljs=@dTotal-@dDiscountTotalover
                                if @nTemp=52 select @dDiscountTotaljs=@dTax_Totaljs
                        end
                        else
                        begin
                                select @dTax_Totaljs=@jsTotal
                                select @dDiscountTotaljs=@dTotal*(@dTax_Totaljs/@dTax_Total)
                                select @dCostTotaljs=@dCostTotal*(@dTax_Totaljs/@dTax_Total)

                                if exists(select * from sendjsdly where svchcode=@svchcode and draft=3 and type=4 and btypeid=@szBtypeid)
                                update sendjsdly set Total=Total+@jsTotal,discountTotalover=discountTotalover+@dDiscountTotaljs,
                                CostTotalover=CostTotalover+@dCostTotaljs where svchcode=@svchcode and draft=3 and btypeid=@szBtypeid
                                else
                                begin
                                        insert into sendjsdly(BTypeID,Total,draft,jsvchcode,svchcode,type,discountTotalover,CostTotalover)
                                        values(@szBTypeID,@jsTotal,3,@nVchcode,@svchcode,4,@dDiscountTotaljs,@dCostTotaljs)
                                end
                                if @@error<>0 goto error145
                                if @nTemp=52 select @dDiscountTotaljs=@dTax_Totaljs
                        end

                        select @dTempCostTotal = @dTempCostTotal+@dCostTotaljs
                        select @dTempTotal = @dTempTotal+@dDiscountTotaljs--销售收入
                        select @dTotalMoney = @dTotalMoney+@dTax_Totaljs--销售收入
                        select @dTempTaxTotal = @dTempTaxTotal+(@dTax_Totaljs-@dDiscountTotaljs)

                        fetch next from CreateDly_cursor into @svchcode, @jsTotal
                end
                update sendjsdly set draft=2 where jsvchcode=@nVchcode and draft=1
--贷应收_销项增值税

                if @dTempTaxTotal<>0
                begin
                        insert into dlya(vchcode,Date,VchType,ATypeID,BTypeID,ETypeID,KTypeID,
                                    Total,period,UsedType,comment,DeptID)
                        values(@nVchcode,@tDate,@nVchType,@TAX_ID,@szBTypeID,@szETypeID,@szKTypeID,
                                @dTemptaxTotal,@nPeriod,'',@szAutoSummary,@DeptID)
                        if @@rowcount <=0 goto error1
                end
--销售收入
                if @dTempTotal<>0
                begin
                        insert into dlya(vchcode,Date,VchType,ATypeID,BTypeID,ETypeID,KTypeID,
                                    Total,period,UsedType,comment,DeptID)
                        values(@nVchcode,@tDate,@nVchType,@SALE_INCOME_ID,@szBTypeID,@szETypeID,@szKTypeID,
                                @dTempTotal,@nPeriod,'',@szAutoSummary,@DeptID)

                        if @@rowcount <=0 goto error1
                end

--应收应付
                if @dTotalInMoney <> @dTotalMoney
                begin
                        select @dTemp = @dTotalMoney-@dTotalInMoney
                        insert into dlya(vchcode,Date,VchType,ATypeID,BTypeID,ETypeID,KTypeID,
                                    Total,period,UsedType,comment,DeptID)
                        values(@nVchcode,@tDate,@nVchType,@AR_ID,@szBTypeID,@szETypeID,@szKTypeID,
                                @dTemp,@nPeriod,'',@szAutoSummary,@DeptID)
                        if @@rowcount <=0 goto error1
                end

--销售成本
                if @dTempCostTotal<>0
                begin
                        insert into dlya(vchcode,Date,VchType,ATypeID,BTypeID,ETypeID,KTypeID,
                                    Total,period,UsedType,comment,DeptID)
                        values(@nVchcode,@tDate,@nVchType,@SALE_COST_ID,@szBTypeID,@szETypeID,@szKTypeID,
                                @dTempCostTotal,@nPeriod,'',@szAutoSummary,@DeptID)
                        if @@rowcount <=0 goto error1

--发出商品
                        insert into dlya(vchcode,Date,VchType,ATypeID,BTypeID,ETypeID,KTypeID,
                                    Total,period,UsedType,comment,DeptID)
                        values(@nVchcode,@tDate,@nVchType,@SEND_GOODS_ID,@szBTypeID,@szETypeID,@szKTypeID,
                                -@dTempCostTotal,@nPeriod,'',@szAutoSummary,@DeptID)
                        if @@rowcount <=0 goto error1
                end
--修改BTYPE发出商品
		update btype set sendgoods=sendgoods-@dTempCostTotal,sendgoodsj=sendgoodsj-@dtempTotal-@dTemptaxtotal where typeid=@szBtypeid
		if @@rowcount <=0 goto error1

                update dlyndx set Total=Abs(@dTotalInMoney) where vchcode=@nVchcode
                if @@rowcount <=0 goto error1

           CLOSE CreateDly_cursor
           DEALLOCATE CreateDly_cursor
        end
------------------------------发货单结算处理结束--------------------------


---发货调价单开始

        if @nVchType=52
        begin
                select @type=4
                select @szAutoSummary = '第'+@szNumber+'发货调价单'
                select @execsql='declare CreateDly_cursor cursor for '
                                +' select ATypeID, PTypeID, qty, Price, Total, discount, discountPrice, discountTotal,
                                tax, taxPrice, taxTotal, tax_Total, costPrice, CostTotal, blockno, prodate, comment, UsedType,goodsno,ordercode,unit from bakdly
                                 where Vchcode= '+CAST(@nVchcode AS varchar(10))+' order by dlyorder'
                exec (@execsql)


                select @dTempTotal = 0
                select @dTempQty = 0
                select @dTotalMoney = 0
                select @dTempCostTotal = 0
                select @dTemptaxTotal = 0
                OPEN CreateDly_cursor
                fetch next from CreateDly_cursor into @szATypeID, @szPTypeID,@dQty,@dPrice,@dTotal,@dDiscount,@dDiscountPrice, @dDiscountTotal,
                        @dTax,@dTaxPrice,@dTaxTotal,@dTax_Total,@dCostPrice, @dCostTotal,@szBlockno,@szProdate, @szMemo,  @UsedType,@nGoodsNo,@nOrderCode,@unit
                while @@FETCH_STATUS=0
                begin
                                insert into dlyother(vchcode,Date,VchType,ATypeID,PTypeID,BTypeID,ETypeID,KTypeID,KTypeID2,
                                    qty,Price,Total,costPrice,CostTotal,discount,discountPrice,discountTotal,
                                tax,taxPrice,taxTotal,tax_Total,Blockno,Prodate,comment,period,UsedType,costmode,unit,DeptID)
                                values(@nVchcode,@tDate,@nVchType,'99999','',@szBTypeID,@szETypeID,@szKTypeID,@szKTypeID2,
                                0,@dPrice,@dTotal,@dCostPrice,0,@dDiscount,0,0,
                                0,0,0,@dTotal,'','',@szMemo,@nPeriod,@UsedType,0,0,@DeptID)
                                if @@rowcount <=0 goto error1
                        fetch next from CreateDly_cursor into @szATypeID, @szPTypeID,@dQty,@dPrice,@dTotal,@dDiscount,@dDiscountPrice, @dDiscountTotal,

                        @dTax,@dTaxPrice,@dTaxTotal,@dTax_Total,@dCostPrice, @dCostTotal,@szBlockno,@szProdate, @szMemo,  @UsedType,@nGoodsNo,@nOrderCode,@unit
                end

--修改BTYPE发出商品
	update btype set sendgoodsj=sendgoodsj+@dtotal where typeid=@szBtypeid
	if @@rowcount <=0 goto error1

                update dlyndx set Total=Abs(@dTotal) where vchcode=@nVchcode
                if @@rowcount <=0 goto error1


                CLOSE CreateDly_cursor
                DEALLOCATE CreateDly_cursor
        end
------------------------------发货调价单处理结束--------------------------


---委托发货开始

        if @nVchType=25
        begin
                select @type=1
                select @szAutoSummary = '第'+@szNumber+'委托发货单'
                select @execsql='declare CreateDly_cursor cursor for '
                                +' select ATypeID, PTypeID,KTypeid, qty, Price, Total, discount, discountPrice, discountTotal,
                                tax, taxPrice, taxTotal, tax_Total, costPrice, CostTotal, blockno, prodate, comment, UsedType,goodsno,ordercode,unit,dlyorder,HandZeroCost from bakdly
                                 where Vchcode= '+CAST(@nVchcode AS varchar(10))+' order by dlyorder'
                exec (@execsql)

                select @nModiSalePrice= [stats] from syscon where [order]=3
                select @nTrackPrice = [stats] from syscon where [order]=8

                select @dTempTotal = 0
                select @dTempQty = 0
                select @dTotalMoney = 0
                select @dTempCostTotal = 0
                select @dTemptaxTotal = 0
                OPEN CreateDly_cursor
                fetch next from CreateDly_cursor into @szATypeID, @szPTypeID,@szKTypeID,@dQty,@dPrice,@dTotal,@dDiscount,@dDiscountPrice, @dDiscountTotal,
                        @dTax,@dTaxPrice,@dTaxTotal,@dTax_Total,@dCostPrice, @dCostTotal,@szBlockno,@szProdate, @szMemo,  @UsedType,@nGoodsNo,@nOrderCode,
			@unit,@odlyorder,@nHandInputZero
                while @@FETCH_STATUS=0

                begin
                        if (@szPTypeID<>''  ) and (@szPTypeID<>'00000')
                        begin
                                select @nCostmode=costmode, @deleted=deleted, @nSon=sonnum,@lsSerial = lsSerial from ptype where typeid=@szPTypeID
                                if @deleted=1 or @nSon>0 goto error132
				if not Exists( Select typeid from Stock where typeid=@szKTypeID and Deleted=0 and SonNum=0) goto error135r

                                select @dQty = -@dQty
                                select @dCostTotal = -@dCostTotal
                                select @dTotal = -@dTotal
                                select @dDiscountTotal = -@dDiscountTotal
                                select @dTax_Total = -@dTax_Total
                                select @dTemp=@dCostPrice

                                exec  @nRet = ModifyDbf @nVchType,@nVchcode,@tDate,@nCostmode,@GOODs_ID,@szPTypeID,'',@szETypeID,@szKTypeID,
                                @nPeriod,@dQty,@dCostTotal,@szBlockno,@szProdate,@nGoodsNo,@dTemp out,@odlyorder,@lsSerial,@nHandInputZero
                                if @nRet<0 goto error
                                select @dCostPrice = @dTemp / @dQty
                                select @dCostTotal = @dTemp

                                select @dTempTotal = @dTempTotal+@dDiscountTotal
                                select @dTempQty = @dTempQty+@dQty
                                select @dTempCostTotal = @dTempCostTotal+@dCostTotal
                                select @dTotalMoney = @dTotalMoney+@dTax_Total
                                select @dTaxTotal=@dTax_Total-@dDiscountTotal
                                select @dTemptaxTotal = @dTemptaxTotal + @dTaxTotal

                                insert into dlyother(vchcode,Date,VchType,ATypeID,PTypeID,BTypeID,ETypeID,KTypeID,KTypeID2,
                                    qty,Price,Total,costPrice,CostTotal,discount,discountPrice,discountTotal,

                                tax,taxPrice,taxTotal,tax_Total,Blockno,Prodate,comment,period,UsedType,costmode,unit,DeptID)
                                values(@nVchcode,@tDate,@nVchType,@szATypeID,@szPTypeID,@szBTypeID,@szETypeID,@szKTypeID,@szKTypeID2,
                                @dQty,@dPrice,@dTotal,@dCostPrice,@dCostTotal,@dDiscount,@dDiscountPrice,@dDiscountTotal,
                                @dTax,@dTaxPrice,@dTaxTotal,@dTax_Total,@szBlockno,@szProdate,@szMemo,@nPeriod,@UsedType,@nCostMode,@unit,@DeptID)
				--add by dcsong 2004.8.17 更新对应库存变动，一个单据号的且dlyorder为0的，当前变动的明细
                                select @nDlyOrder = @@identity
				update T_GoodsStocksGlide set dlyorder = @nDlyOrder where VchCode = @nVchcode and dlyorder = 0		
				update SN set VchLineNO = @nDlyorder,Tag = 3 where Vchcode = @nVchcode and VchLineNO = 0	
                                if @@error <> 0 goto error1

                                select @dQty = -@dQty
                                select @dCostTotal = -@dCostTotal
                                select @dDiscountTotal = -@dDiscountTotal
                                select @dTax_Total = -@dTax_Total
                                exec  @nRet = ModifyDbfCom @nVchType,@GOODs_ID,@szPTypeID,@szBTypeID,
                                @dQty,@dTax_Total,@szBlockno,@szProdate,@dCostTotal,@type,@dTemp out,@dTemp1 out
                                if @nRet<0 goto error

                                insert into dlyother(vchcode,Date,VchType,ATypeID,PTypeID,BTypeID,ETypeID,KTypeID,KTypeID2,
                                    qty,Price,Total,costPrice,CostTotal,discount,discountPrice,discountTotal,
                                tax,taxPrice,taxTotal,tax_Total,Blockno,Prodate,comment,period,UsedType,costmode,unit,PDETAIL,DeptID)
                                values(@nVchcode,@tDate,@nVchType,@szATypeID,@szPTypeID,@szBTypeID,@szETypeID,@COMMISSION_STOCK_ID,@szKTypeID2,
                                @dQty,@dPrice,-@dTotal,@dCostPrice,@dCostTotal,@dDiscount,@dDiscountPrice,@dDiscountTotal,
                                @dTax,@dTaxPrice,-@dTaxTotal,@dTax_Total,@szBlockno,@szProdate,@szMemo,@nPeriod,0,@nCostMode,@unit,2,@DeptID)
                                if @@rowcount <=0 goto error1
                        end

                        fetch next from CreateDly_cursor into @szATypeID, @szPTypeID,@szKTypeID,@dQty,@dPrice,@dTotal,@dDiscount,@dDiscountPrice, @dDiscountTotal,
                        @dTax,@dTaxPrice,@dTaxTotal,@dTax_Total,@dCostPrice, @dCostTotal,@szBlockno,@szProdate, @szMemo, @UsedType,@nGoodsNo,@nOrderCode,
			@unit,@odlyorder,@nHandInputZero
                end
--库存商品
		if @dTempCostTotal <> 0
		begin
	                insert into dlya(vchcode,Date,VchType,ATypeID,BTypeID,ETypeID,KTypeID,
	                                    Total,period,UsedType,comment,DeptID)
	                        values(@nVchcode,@tDate,@nVchType,@GOODS_ID,@szBTypeID,@szETypeID,@szKTypeID,
	                                @dTempCostTotal,@nPeriod,'',@szAutoSummary,@DeptID)
	                if @@rowcount <=0 goto error1
		end
--委托发出商品
		if @dTempCostTotal <> 0
		begin
	                insert into dlya(vchcode,Date,VchType,ATypeID,BTypeID,ETypeID,KTypeID,
	                                    Total,period,UsedType,comment,DeptID)
	                        values(@nVchcode,@tDate,@nVchType,@COMMISSION_GOODS_ID,@szBTypeID,@szETypeID,@szKTypeID,
	                                -@dTempCostTotal,@nPeriod,'',@szAutoSummary,@DeptID)
	                if @@rowcount <=0 goto error1
		end
                update dlyndx set Total=Abs(@dTotalMoney) where vchcode=@nVchcode
                if @@rowcount <=0 goto error1

                CLOSE CreateDly_cursor
                DEALLOCATE CreateDly_cursor
        end
------------------------------委托发货单处理结束--------------------------


---委托发货退货开始

        if @nVchType=30
        begin
                select @type=1
                select @szAutoSummary = '第'+@szNumber+'委托发货退货单'
                select @execsql='declare CreateDly_cursor cursor for '
                                +' select ATypeID, PTypeID,KTypeid, qty, Price, Total, discount, discountPrice, discountTotal,
                                tax, taxPrice, taxTotal, tax_Total, costPrice, CostTotal, blockno, prodate, comment,UsedType,
				goodsno,ordercode,OrderDlyCode,unit,dlyorder from bakdly
                                 where Vchcode= '+CAST(@nVchcode AS varchar(10))+' order by dlyorder'
                exec (@execsql)

                select @nModiSalePrice= [stats] from syscon where [order]=3
                select @nTrackPrice = [stats] from syscon where [order]=8

                select @dTempTotal = 0
                select @dTempQty = 0


                select @dTotalMoney = 0
                select @dTempCostTotal = 0
                select @dTemptaxTotal = 0
                OPEN CreateDly_cursor
                fetch next from CreateDly_cursor into @szATypeID, @szPTypeID,@szKTypeID,@dQty,@dPrice,@dTotal,@dDiscount,@dDiscountPrice, @dDiscountTotal,
                        @dTax,@dTaxPrice,@dTaxTotal,@dTax_Total,@dCostPrice, @dCostTotal,@szBlockno,@szProdate, @szMemo, @UsedType,@nGoodsNo,@nOrderCode,@nOrderDlyCode,
			@unit,@odlyorder
                while @@FETCH_STATUS=0
                begin
                        if (@szPTypeID<>''  ) and (@szPTypeID<>'00000')
                        begin
                                select @nCostmode=costmode, @deleted=deleted, @nSon=sonnum,@lsSerial = lsSerial from ptype where typeid=@szPTypeID
                                if @deleted=1 or @nSon>0 goto error132
				if not Exists( Select typeid from Stock where typeid=@szKTypeID and Deleted=0 and SonNum=0) goto error135r

                                select @dQty = -@dQty
                                select @dCostTotal = -@dCostTotal
                                select @dDiscountTotal = -@dDiscountTotal
                                select @dTax_Total = -@dTax_Total
                                exec  @nRet = ModifyDbfCom @nVchType,@GOODs_ID,@szPTypeID,@szBTypeID,
                                @dQty,@dTax_Total,@szBlockno,@szProdate,@dCostTotal,@type,@dTemp out,@dTemp1 out
                                if @nRet<0 goto error

                                select @dCostTotal=@dTemp1
--                              select @dDiscountTotal=
                                insert into dlyother(vchcode,Date,VchType,ATypeID,PTypeID,BTypeID,ETypeID,KTypeID,KTypeID2,
                                    qty,Price,Total,costPrice,CostTotal,discount,discountPrice,discountTotal,
                                tax,taxPrice,taxTotal,tax_Total,Blockno,Prodate,comment,period,UsedType,costmode,unit,PDETAIL,DeptID,OrderCode,OrderDlyCode)
                                values(@nVchcode,@tDate,@nVchType,@szATypeID,@szPTypeID,@szBTypeID,@szETypeID,@COMMISSION_STOCK_ID,@szKTypeID2,
                                @dQty,@dPrice,-@dTotal,@dCostPrice,@dCostTotal,@dDiscount,@dDiscountPrice,@dDiscountTotal,
                                @dTax,@dTaxPrice,-@dTaxTotal,@dTax_Total,@szBlockno,@szProdate,@szMemo,@nPeriod,0,@nCostMode,@unit,2,@DeptID,@nOrderCode,@nOrderDlyCode)
                                if @@rowcount <=0 goto error1

                                select @dQty = -@dQty
                                select @dCostTotal = -@dTemp1
                                select @dDiscountTotal = -@dDiscountTotal
                                select @dTax_Total = -@dTax_Total
                                exec  @nRet = ModifyDbf @nVchType,@nVchcode,@tDate,@nCostmode,@GOODs_ID,@szPTypeID,'',@szETypeID,@szKTypeID,
                                @nPeriod,@dQty,@dCostTotal,@szBlockno,@szProdate,@nGoodsNo,@dTemp out,@odlyorder,@lsSerial
                                if @nRet<0 goto error
                                select @dCostPrice = @dTemp / @dQty
                                select @dCostTotal = @dTemp

                                select @dTempTotal = @dTempTotal+@dDiscountTotal
                                select @dTempQty = @dTempQty+@dQty
                                select @dTempCostTotal = @dTempCostTotal+@dCostTotal
                                select @dTotalMoney = @dTotalMoney+@dTax_Total
                                select @dTaxTotal=@dTax_Total-@dDiscountTotal
                                select @dTemptaxTotal = @dTemptaxTotal + @dTaxTotal


                                insert into dlyother(vchcode,Date,VchType,ATypeID,PTypeID,BTypeID,ETypeID,KTypeID,KTypeID2,
                                    qty,Price,Total,costPrice,CostTotal,discount,discountPrice,discountTotal,
                                tax,taxPrice,taxTotal,tax_Total,Blockno,Prodate,comment,period,UsedType,costmode,unit,DeptID,OrderCode,OrderDlyCode)
                                values(@nVchcode,@tDate,@nVchType,@szATypeID,@szPTypeID,@szBTypeID,@szETypeID,@szKTypeID,@szKTypeID2,
                                @dQty,@dPrice,@dTotal,@dCostPrice,@dCostTotal,@dDiscount,@dDiscountPrice,@dDiscountTotal,
                                @dTax,@dTaxPrice,@dTaxTotal,@dTax_Total,@szBlockno,@szProdate,@szMemo,@nPeriod,@UsedType,@nCostMode,@unit,@DeptID,@nOrderCode,@nOrderDlyCode)
				--add by dcsong 2004.8.17 更新对应库存变动，一个单据号的且dlyorder为0的，当前变动的明细
                                select @nDlyOrder = @@identity
				update T_GoodsStocksGlide set dlyorder = @nDlyOrder where VchCode = @nVchcode and dlyorder = 0		
				update SN set VchLineNO = @nDlyorder,Tag = 2 where Vchcode = @nVchcode and VchLineNO = 0	
                                if @@error <> 0 goto error1
				--更新委托发货数量
				if @nOrderCode <> 0 and @nOrderDlyCode <> 0 
				begin
					if exists(select VchCode from dlyother where [qty] < [Toqty] - @dQty and vchcode=@nOrderCode and dlyorder = @nOrderDlyCode and Pdetail <> 2)
					begin
						update dlyother set ToQty = ToQty - @dQty where vchcode = @nOrderCode and dlyorder = @nOrderDlyCode and Pdetail <> 2
						if @@error <> 0 goto error1
					end
					else
					begin 
						update dlyother set ToQty = Qty where vchcode = @nOrderCode and dlyorder = @nOrderDlyCode and Pdetail <> 2
						if @@error <> 0 goto error1
					end
				end 
                        end

                        fetch next from CreateDly_cursor into @szATypeID, @szPTypeID,@szKTypeID,@dQty,@dPrice,@dTotal,@dDiscount,@dDiscountPrice, @dDiscountTotal,
                        @dTax,@dTaxPrice,@dTaxTotal,@dTax_Total,@dCostPrice, @dCostTotal,@szBlockno,@szProdate, @szMemo, @UsedType,@nGoodsNo,@nOrderCode,@nOrderDlyCode,
			@unit,@odlyorder
                end
--库存商品
		if @dTempCostTotal <> 0
		begin
	                insert into dlya(vchcode,Date,VchType,ATypeID,BTypeID,ETypeID,KTypeID,
	                                    Total,period,UsedType,comment,DeptID)
	                        values(@nVchcode,@tDate,@nVchType,@GOODS_ID,@szBTypeID,@szETypeID,@szKTypeID,
	                                @dTempCostTotal,@nPeriod,'',@szAutoSummary,@DeptID)
	                if @@rowcount <=0 goto error1
		end
--委托发出商品
		if @dTempCostTotal <> 0
		begin
	                insert into dlya(vchcode,Date,VchType,ATypeID,BTypeID,ETypeID,KTypeID,
	                                    Total,period,UsedType,comment,DeptID)
	                        values(@nVchcode,@tDate,@nVchType,@COMMISSION_GOODS_ID,@szBTypeID,@szETypeID,@szKTypeID,
	                                -@dTempCostTotal,@nPeriod,'',@szAutoSummary,@DeptID)
	                if @@rowcount <=0 goto error1
		end
--应收_销项增值税和应交税金

                update dlyndx set Total=Abs(@dTotalMoney) where vchcode=@nVchcode
                if @@rowcount <=0 goto error1

                CLOSE CreateDly_cursor
                DEALLOCATE CreateDly_cursor
        end
------------------------------委托发货退货单处理结束--------------------------


---委托结算开始

        if @nVchType=26

        begin
                select @type=1
                select @szAutoSummary = '第'+@szNumber+'委托结算单'
                select @execsql='declare CreateDly_cursor cursor for '
                                +' select ATypeID, PTypeID, qty, Price, Total, discount, discountPrice, discountTotal,
                                tax, taxPrice, taxTotal, tax_Total, costPrice, CostTotal, blockno, prodate, comment,UsedType,goodsno,ordercode,OrderDlyCode,unit from bakdly
                                 where Vchcode= '+CAST(@nVchcode AS varchar(10))+ '   order by dlyorder'
                exec (@execsql)

                select @nModiSalePrice= [stats] from syscon where [order]=3
                select @nTrackPrice = [stats] from syscon where [order]=8

                select @dTempTotal = 0
                select @dTempQty = 0
                select @dTotalMoney = 0
                select @dTempCostTotal = 0
                select @dTemptaxTotal = 0
                select @dTotalInMoney=0
                OPEN CreateDly_cursor
                fetch next from CreateDly_cursor into @szATypeID, @szPTypeID,@dQty,@dPrice,@dTotal,@dDiscount,@dDiscountPrice, @dDiscountTotal,
                        @dTax,@dTaxPrice,@dTaxTotal,@dTax_Total,@dCostPrice, @dCostTotal,@szBlockno,@szProdate, @szMemo, @UsedType,@nGoodsNo,@nOrderCode,@nOrderDlyCode,@unit
                while @@FETCH_STATUS=0
                begin
                        if (@szPTypeID<>''  ) and (@szPTypeID<>'00000')
                        begin
                                select @nCostmode=costmode, @deleted=deleted, @nSon=sonnum from ptype where typeid=@szPTypeID
                                if @deleted=1 or @nSon>0 goto error132
                                select @dQty = -@dQty
                                select @dTotal = -@dTotal
                                select @dCostTotal = -1*@dCostTotal
                                select @dDiscountTotal = -@dDiscountTotal
                                select @dTax_Total = -@dTax_Total
                                exec  @nRet = ModifyDbfCom @nVchType,@GOODs_ID,@szPTypeID,@szBTypeID,
                                @dQty,@dTax_Total,@szBlockno,@szProdate,@dCostTotal,@type,@dTemp out,@dTemp1 out
                                if @nRet<0 goto error
                                select @dCostPrice = @dTemp1 / @dQty
                                select @dCostTotal = @dTemp1
                                select @dTax_Total=@dTemp

                                select @dTempTotal = @dTempTotal+@dDiscountTotal

                                select @dTempQty = @dTempQty+@dQty
                                select @dTempCostTotal = @dTempCostTotal+@dCostTotal
                                select @dTotalMoney = @dTotalMoney+@dTax_Total
                                select @dTaxTotal=@dTax_Total-@dDiscountTotal
                                select @dTemptaxTotal = @dTemptaxTotal + @dTaxTotal

                                insert into dlysale(vchcode,Date,VchType,ATypeID,PTypeID,BTypeID,ETypeID,KTypeID,KTypeID2,
                                    qty,Price,Total,costPrice,CostTotal,discount,discountPrice,discountTotal,
                                tax,taxPrice,taxTotal,tax_Total,Blockno,Prodate,comment,period,UsedType,costmode,unit,pdetail,DeptID,OrderCode,OrderDlyCode)
                                values(@nVchcode,@tDate,@nVchType,@szATypeID,@szPTypeID,@szBTypeID,@szETypeID,@COMMISSION_STOCK_ID,@szKTypeID2,
                                @dQty,@dPrice,@dTotal,@dCostPrice,@dCostTotal,@dDiscount,@dDiscountPrice,@dDiscountTotal,
                                @dTax,@dTaxPrice,@dTaxTotal,@dTax_Total,@szBlockno,@szProdate,@szMemo,@nPeriod,@UsedType,@nCostMode,@unit,2,@DeptID,@nOrderCode,@nOrderDlyCode)
                                if @@rowcount <=0 goto error1
				--更新委托发货数量
				IF @NORDERCODE <> 0 AND @NORDERDLYCODE <> 0 
				BEGIN
					IF EXISTS(SELECT VCHCODE FROM DLYOTHER WHERE [QTY] < [TOQTY] + @DQTY AND VCHCODE=@NORDERCODE AND DLYORDER = @NORDERDLYCODE AND PDETAIL <> 2)
					BEGIN
						UPDATE DLYOTHER SET TOQTY = TOQTY + @DQTY WHERE VCHCODE = @NORDERCODE AND DLYORDER = @NORDERDLYCODE AND PDETAIL <> 2
						IF @@ERROR <> 0 GOTO ERROR1
					END
					ELSE
					BEGIN 
						UPDATE DLYOTHER SET TOQTY = QTY WHERE VCHCODE = @NORDERCODE AND DLYORDER = @NORDERDLYCODE AND PDETAIL <> 2
						IF @@ERROR <> 0 GOTO ERROR1
					END
				END 
                        end
                        else
                        begin
                                select @dTotalinMoney = @dTotalinMoney + @dTotal
                                insert into dlya(vchcode,Date,VchType,ATypeID,BTypeID,ETypeID,KTypeID,
                                    Total,period,UsedType,comment,DeptID)
                                values(@nVchcode,@tDate,@nVchType,@szATypeID,@szBTypeID,@szETypeID,@szKTypeID,
                                        @dTotal,@nPeriod,@UsedType,@szAutoSummary,@DeptID)
                                if @@rowcount <=0 goto error1
                        end

                        fetch next from CreateDly_cursor into @szATypeID, @szPTypeID,@dQty,@dPrice,@dTotal,@dDiscount,@dDiscountPrice, @dDiscountTotal,
                        @dTax,@dTaxPrice,@dTaxTotal,@dTax_Total,@dCostPrice, @dCostTotal,@szBlockno,@szProdate, @szMemo, @UsedType,@nGoodsNo,@nOrderCode,@nOrderDlyCode,@unit
                end
--贷销项税

                if @dTempTaxTotal<>0
                begin
                        insert into dlya(vchcode,Date,VchType,ATypeID,BTypeID,ETypeID,KTypeID,
                                    Total,period,UsedType,comment,DeptID)
                        values(@nVchcode,@tDate,@nVchType,@TAX_ID,@szBTypeID,@szETypeID,@szKTypeID,
                                -@dTemptaxTotal,@nPeriod,'',@szAutoSummary,@DeptID)
                        if @@rowcount <=0 goto error1
                end
--贷销售收入
		if @dTempTotal <> 0
		begin
                        insert into dlya(vchcode,Date,VchType,ATypeID,BTypeID,ETypeID,KTypeID,
                                    Total,period,UsedType,comment,DeptID)
                        values(@nVchcode,@tDate,@nVchType,@SALE_INCOME_ID,@szBTypeID,@szETypeID,@szKTypeID,
                                -@dTempTotal,@nPeriod,'',@szAutoSummary,@DeptID)
                        if @@rowcount <=0 goto error1
		end
--应收应付
                if @dTotalInMoney <> @dTotalMoney
                begin
                        select @dTemp = -@dTotalMoney-@dTotalInMoney
                        insert into dlya(vchcode,Date,VchType,ATypeID,BTypeID,ETypeID,KTypeID,
                                    Total,period,UsedType,comment,DeptID)
                        values(@nVchcode,@tDate,@nVchType,@AR_ID,@szBTypeID,@szETypeID,@szKTypeID,
                                @dTemp,@nPeriod,'',@szAutoSummary,@DeptID)
                        if @@rowcount <=0 goto error1
                end

--销售成本
		if @dTempCostTotal <> 0 
		begin
	                insert into dlya(vchcode,Date,VchType,ATypeID,BTypeID,ETypeID,KTypeID,
	                                    Total,period,UsedType,comment,DeptID)

	                        values(@nVchcode,@tDate,@nVchType,@SALE_COST_ID,@szBTypeID,@szETypeID,@szKTypeID,
	                                -@dTempCostTotal,@nPeriod,'',@szAutoSummary,@DeptID)
	                if @@rowcount <=0 goto error1
		end
--委托发出商品
		if @dTempCostTotal <> 0
		begin
	                insert into dlya(vchcode,Date,VchType,ATypeID,BTypeID,ETypeID,KTypeID,
	                                    Total,period,UsedType,comment,DeptID)
	                        values(@nVchcode,@tDate,@nVchType,@COMMISSION_GOODS_ID,@szBTypeID,@szETypeID,@szKTypeID,
	                                @dTempCostTotal,@nPeriod,'',@szAutoSummary,@DeptID)
	                if @@rowcount <=0 goto error1
		end

                update dlyndx set Total=Abs(@dTotalMoney) where vchcode=@nVchcode
                if @@rowcount <=0 goto error1

                CLOSE CreateDly_cursor
                DEALLOCATE CreateDly_cursor
        end
------------------------------委托结算处理结束--------------------------


---委托调价开始

        if @nVchType=50
        begin
                select @type=1
                select @szAutoSummary = '第'+@szNumber+'委托调价单'
                select @execsql='declare CreateDly_cursor cursor for '
                                +' select ATypeID, PTypeID, qty, Price, Total, discount, discountPrice, discountTotal,
                                tax, taxPrice, taxTotal, tax_Total, costPrice, CostTotal, blockno, prodate, comment, UsedType,goodsno,ordercode,unit from bakdly
                                 where Vchcode= '+CAST(@nVchcode AS varchar(10))+' order by dlyorder'

                exec (@execsql)

                select @dTempTotal = 0
                select @dTempQty = 0
                select @dTotalMoney = 0
                select @dTempCostTotal = 0
                select @dTemptaxTotal = 0
                OPEN CreateDly_cursor
                fetch next from CreateDly_cursor into @szATypeID, @szPTypeID,@dQty,@dPrice,@dTotal,@dDiscount,@dDiscountPrice, @dDiscountTotal,
                        @dTax,@dTaxPrice,@dTaxTotal,@dTax_Total,@dCostPrice, @dCostTotal,@szBlockno,@szProdate, @szMemo,  @UsedType,@nGoodsNo,@nOrderCode,@unit
                while @@FETCH_STATUS=0
                begin
                        if (@szPTypeID<>''  ) and (@szPTypeID<>'00000')
                        begin
                                select @nCostmode=costmode, @deleted=deleted, @nSon=sonnum from ptype where typeid=@szPTypeID
                                if @deleted=1 or @nSon>0 goto error132
                                select @dTempTotal = @dTempTotal+@dDiscountTotal
                                select @dTaxTotal=@dTax_Total-@dDiscountTotal
                                select @dTemptaxTotal = @dTemptaxTotal + @dTaxTotal
                                select @dTotalMoney = @dTotalMoney+@dTax_Total

                                insert into dlyother(vchcode,Date,VchType,ATypeID,PTypeID,BTypeID,ETypeID,KTypeID,KTypeID2,
                                    qty,Price,Total,costPrice,CostTotal,discount,discountPrice,discountTotal,
                                tax,taxPrice,taxTotal,tax_Total,Blockno,Prodate,comment,period,UsedType,costmode,unit,pdetail,DeptID)
                                values(@nVchcode,@tDate,@nVchType,@szATypeID,@szPTypeID,@szBTypeID,@szETypeID,@COMMISSION_STOCK_ID,@szKTypeID2,
                                @dQty,@dPrice,@dTotal,@dCostPrice,@dCostTotal,@dDiscount,@dDiscountPrice,@dDiscountTotal,
                                @dTax,@dTaxPrice,@dTaxTotal,@dTax_Total,@szBlockno,@szProdate,@szMemo,@nPeriod,@UsedType,@nCostMode,@unit,2,@DeptID)
                                if @@rowcount <=0 goto error1

                                exec  @nRet = ModifyDbfCom @nVchType,@GOODs_ID,@szPTypeID,@szBTypeID,
                                0,@dTax_Total,@szBlockno,@szProdate,0,@type,@dTemp out,@dTemp1 out
                                if @nRet<0 goto error
                        end

                        fetch next from CreateDly_cursor into @szATypeID, @szPTypeID,@dQty,@dPrice,@dTotal,@dDiscount,@dDiscountPrice, @dDiscountTotal,

                        @dTax,@dTaxPrice,@dTaxTotal,@dTax_Total,@dCostPrice, @dCostTotal,@szBlockno,@szProdate, @szMemo, @UsedType,@nGoodsNo,@nOrderCode,@unit
                end
--应收_销项增值税和应交税金

                update dlyndx set Total=@dTotalMoney where vchcode=@nVchcode
                if @@rowcount <=0 goto error1

                CLOSE CreateDly_cursor
                DEALLOCATE CreateDly_cursor
        end
------------------------------委托调价单处理结束--------------------------



---受托收货单开始

        if @nVchType=27
        begin
                select @type=5
                select @szAutoSummary = '第'+@szNumber+'受托收货单'
                select @execsql='declare CreateDly_cursor cursor for '
                                +' select ATypeID, PTypeID,KTypeid, qty, Price, Total, discount, discountPrice, discountTotal,

                                tax, taxPrice, taxTotal, tax_Total, costPrice, CostTotal, blockno, prodate, comment,UsedType,goodsno,ordercode,unit,dlyorder from bakdly
                                 where Vchcode= '+CAST(@nVchcode AS varchar(10))+' order by dlyorder'
                exec (@execsql)

                select @nModiSalePrice= [stats] from syscon where [order]=3
                select @nTrackPrice = [stats] from syscon where [order]=8

                select @dTempTotal = 0
                select @dTempQty = 0
                select @dTotalMoney = 0
                select @dTempCostTotal = 0
                select @dTemptaxTotal = 0
                OPEN CreateDly_cursor
                fetch next from CreateDly_cursor into @szATypeID, @szPTypeID,@szKTypeID,@dQty,@dPrice,@dTotal,@dDiscount,@dDiscountPrice, @dDiscountTotal,

                        @dTax,@dTaxPrice,@dTaxTotal,@dTax_Total,@dCostPrice, @dCostTotal,@szBlockno,@szProdate, @szMemo,  @UsedType,@nGoodsNo,@nOrderCode,@unit,@odlyorder
                while @@FETCH_STATUS=0
                begin
                        if (@szPTypeID<>''  ) and (@szPTypeID<>'00000')
                        begin
                                select @nCostmode=costmode, @deleted=deleted, @nSon=sonnum,@lsSerial = lsSerial from ptype where typeid=@szPTypeID
                                if @deleted=1 or @nSon>0 goto error132
				if not Exists( Select typeid from Stock where typeid=@szKTypeID and Deleted=0 and SonNum=0) goto error135r

                                exec  @nRet = ModifyDbf @nVchType,@nVchcode,@tDate,@nCostmode,@GOODs_ID,@szPTypeID,'',@szETypeID,@szKTypeID,
                                @nPeriod,@dQty,@dDiscountTotal,@szBlockno,@szProdate,@nGoodsNo,@dTemp out,@odlyorder,@lsSerial
                                if @nRet<0 goto error
                                select @dCostPrice = @dTemp / @dQty
                                select @dCostTotal = @dTemp

                                select @dTempTotal = @dTempTotal+@dDiscountTotal
                                select @dTempQty = @dTempQty+@dQty
                                select @dTempCostTotal = @dTempCostTotal+@dCostTotal
                                select @dTotalMoney = @dTotalMoney+@dTax_Total
                                select @dTaxTotal=@dTax_Total-@dDiscountTotal
                                select @dTemptaxTotal = @dTemptaxTotal + @dTaxTotal

                                insert into dlyother(vchcode,Date,VchType,ATypeID,PTypeID,BTypeID,ETypeID,KTypeID,KTypeID2,
                                    qty,Price,Total,costPrice,CostTotal,discount,discountPrice,discountTotal,
                                tax,taxPrice,taxTotal,tax_Total,Blockno,Prodate,comment,period,UsedType,costmode,unit,DeptID)
                                values(@nVchcode,@tDate,@nVchType,@szATypeID,@szPTypeID,@szBTypeID,@szETypeID,@szKTypeID,@szKTypeID2,
                                @dQty,@dPrice,@dTotal,@dCostPrice,@dCostTotal,@dDiscount,@dDiscountPrice,@dDiscountTotal,
                                @dTax,@dTaxPrice,@dTaxTotal,@dTax_Total,@szBlockno,@szProdate,@szMemo,@nPeriod,@UsedType,@nCostMode,@unit,@DeptID)
				--add by dcsong 2004.8.17 更新对应库存变动，一个单据号的且dlyorder为0的，当前变动的明细
                                select @nDlyOrder = @@identity
				update T_GoodsStocksGlide set dlyorder = @nDlyOrder where VchCode = @nVchcode and dlyorder = 0		
				update SN set VchLineNO = @nDlyorder,Tag = 2 where Vchcode = @nVchcode and VchLineNO = 0	
                                if @@error <> 0 goto error1

                                exec  @nRet = ModifyDbfCom @nVchType,@GOODs_ID,@szPTypeID,@szBTypeID,

                                @dQty,@dTax_Total,@szBlockno,@szProdate,@dCostTotal,@type,@dTemp out,@dTemp1 out
                                if @nRet<0 goto error

                                insert into dlyother(vchcode,Date,VchType,ATypeID,PTypeID,BTypeID,ETypeID,KTypeID,KTypeID2,
                                    qty,Price,Total,costPrice,CostTotal,discount,discountPrice,discountTotal,
                                tax,taxPrice,taxTotal,tax_Total,Blockno,Prodate,comment,period,UsedType,costmode,unit,pdetail,DeptID)
                                values(@nVchcode,@tDate,@nVchType,@szATypeID,@szPTypeID,@szBTypeID,@szETypeID,@RECOMMISSION_STOCK_ID,@szKTypeID2,
                                @dQty,@dPrice,@dTotal,@dCostPrice,@dCostTotal,@dDiscount,@dDiscountPrice,@dDiscountTotal,

                                @dTax,@dTaxPrice,@dTaxTotal,@dTax_Total,@szBlockno,@szProdate,@szMemo,@nPeriod,0,@nCostMode,@unit,2,@DeptID)
                                if @@rowcount <=0 goto error1
                        end

                        fetch next from CreateDly_cursor into @szATypeID, @szPTypeID,@szKTypeID,@dQty,@dPrice,@dTotal,@dDiscount,@dDiscountPrice, @dDiscountTotal,

                       @dTax,@dTaxPrice,@dTaxTotal,@dTax_Total,@dCostPrice, @dCostTotal,@szBlockno,@szProdate, @szMemo,  @UsedType,@nGoodsNo,@nOrderCode,@unit,@odlyorder
                end
--库存商品
		if @dTempCostTotal <> 0
		begin
	                insert into dlya(vchcode,Date,VchType,ATypeID,BTypeID,ETypeID,KTypeID,
	                                    Total,period,UsedType,comment,DeptID)
	                        values(@nVchcode,@tDate,@nVchType,@GOODS_ID,@szBTypeID,@szETypeID,@szKTypeID,
	                                @dTempCostTotal,@nPeriod,'',@szAutoSummary,@DeptID)
	                if @@rowcount <=0 goto error1
		end
--受托商品款(不含税）
		if @dTempCostTotal <> 0 
		begin
	                insert into dlya(vchcode,Date,VchType,ATypeID,BTypeID,ETypeID,KTypeID,
	                                    Total,period,UsedType,comment,DeptID)
	                        values(@nVchcode,@tDate,@nVchType,@RECOMMISSION_GOODS_ID,@szBTypeID,@szETypeID,@szKTypeID,
	                                @dTempCostTotal,@nPeriod,'',@szAutoSummary,@DeptID)
	                if @@rowcount <=0 goto error1
		end
                update dlyndx set Total=Abs(@dTotalMoney) where vchcode=@nVchcode
                if @@rowcount <=0 goto error1

                CLOSE CreateDly_cursor
                DEALLOCATE CreateDly_cursor
        end
------------------------------受托收货单处理结束--------------------------


---受托退货单开始

        if @nVchType=31
        begin
                select @type=5
                select @szAutoSummary = '第'+@szNumber+'受托退货单'
                select @execsql='declare CreateDly_cursor cursor for '
                                +' select ATypeID, PTypeID,KTypeid, qty, Price, Total, discount, discountPrice, discountTotal,
                                tax, taxPrice, taxTotal, tax_Total, costPrice, CostTotal, blockno, prodate, comment,  UsedType,
				goodsno,ordercode,OrderDlyCode,unit,dlyorder,HandZeroCost from bakdly
                                 where Vchcode= '+CAST(@nVchcode AS varchar(10))+' order by dlyorder'
                exec (@execsql)

                select @nModiSalePrice= [stats] from syscon where [order]=3
                select @nTrackPrice = [stats] from syscon where [order]=8

                select @dTempTotal = 0
                select @dTempQty = 0
                select @dTotalMoney = 0
                select @dTempCostTotal = 0
                select @dTemptaxTotal = 0
                OPEN CreateDly_cursor
                fetch next from CreateDly_cursor into @szATypeID, @szPTypeID,@szKTypeID,@dQty,@dPrice,@dTotal,@dDiscount,@dDiscountPrice, @dDiscountTotal,
                        @dTax,@dTaxPrice,@dTaxTotal,@dTax_Total,@dCostPrice, @dCostTotal,@szBlockno,@szProdate, @szMemo, @UsedType,@nGoodsNo,@nOrderCode,@nOrderDlyCode,
			@unit,@odlyorder,@nHandInputZero
                while @@FETCH_STATUS=0
                begin
                        if (@szPTypeID<>''  ) and (@szPTypeID<>'00000')
                        begin
                                select @nCostmode=costmode, @deleted=deleted, @nSon=sonnum,@lsSerial = lsSerial from ptype where typeid=@szPTypeID
                                if @deleted=1 or @nSon>0 goto error132
				if not Exists( Select typeid from Stock where typeid=@szKTypeID and Deleted=0 and SonNum=0) goto error135r

                                select @dQty = -@dQty
                                select @dCostTotal = -@dCostTotal
                                select @dDiscountTotal = -@dDiscountTotal
                                select @dTax_Total = -@dTax_Total
                                exec  @nRet = ModifyDbfCom @nVchType,@GOODs_ID,@szPTypeID,@szBTypeID,
                                @dQty,@dTax_Total,@szBlockno,@szProdate,@dTax_Total,@type,@dTemp out,@dTemp1 out
                                if @nRet<0 goto error

                                --select @dCostTotal=@dTemp1  受托退货的成本和库存成本不应该是同一个成本
                              insert into dlyother(vchcode,Date,VchType,ATypeID,PTypeID,BTypeID,ETypeID,KTypeID,KTypeID2,
                                    qty,Price,Total,costPrice,CostTotal,discount,discountPrice,discountTotal,
                                tax,taxPrice,taxTotal,tax_Total,Blockno,Prodate,comment,period,UsedType,costmode,unit,PDETAIL,DeptID,OrderCode,OrderDlyCode)
                                values(@nVchcode,@tDate,@nVchType,@szATypeID,@szPTypeID,@szBTypeID,@szETypeID,@RECOMMISSION_STOCK_ID,@szKTypeID2,
                                @dQty,@dPrice,-@dTotal,@dCostPrice,@dTemp1,@dDiscount,@dDiscountPrice,@dDiscountTotal,
                                @dTax,@dTaxPrice,-@dTaxTotal,@dTax_Total,@szBlockno,@szProdate,@szMemo,@nPeriod,0,@nCostMode,@unit,2,@DeptID,@nOrderCode,@nOrderDlyCode)
                                if @@rowcount <=0 goto error1

--                              select @dTax_Total = -@dTax_Total
                                select @dTotal = -@dTotal
                                select @dTemp=@dCostPrice

                                exec  @nRet = ModifyDbf @nVchType,@nVchcode,@tDate,@nCostmode,@GOODs_ID,@szPTypeID,'',@szETypeID,@szKTypeID,
                                @nPeriod,@dQty,@dCostTotal,@szBlockno,@szProdate,@nGoodsNo,@dTemp out,@oDlyorder,@lsSerial,@nHandInputZero
                                if @nRet<0 goto error
                                select @dCostPrice = @dTemp / @dQty
                                select @dCostTotal = @dTemp

                                select @dTempTotal = @dTempTotal+@dDiscountTotal
                                select @dTempQty = @dTempQty+@dQty
                                select @dTempCostTotal = @dTempCostTotal+@dCostTotal
                                select @dTotalMoney = @dTotalMoney+@dTax_Total
                                select @dTaxTotal=@dTax_Total-@dDiscountTotal
                                select @dTemptaxTotal = @dTemptaxTotal + @dTaxTotal

                                insert into dlyother(vchcode,Date,VchType,ATypeID,PTypeID,BTypeID,ETypeID,KTypeID,KTypeID2,
                                    qty,Price,Total,costPrice,CostTotal,discount,discountPrice,discountTotal,
                                tax,taxPrice,taxTotal,tax_Total,Blockno,Prodate,comment,period,UsedType,costmode,unit,DeptID,OrderCode,OrderDlyCode)
                                values(@nVchcode,@tDate,@nVchType,@szATypeID,@szPTypeID,@szBTypeID,@szETypeID,@szKTypeID,@szKTypeID2,
                                @dQty,@dPrice,@dTotal,@dCostPrice,@dCostTotal,@dDiscount,@dDiscountPrice,@dDiscountTotal,
                                @dTax,@dTaxPrice,@dTaxTotal,@dTax_Total,@szBlockno,@szProdate,@szMemo,@nPeriod,@UsedType,@nCostMode,@unit,@DeptID,@nOrderCode,@nOrderDlyCode)
				--add by dcsong 2004.8.17 更新对应库存变动，一个单据号的且dlyorder为0的，当前变动的明细
                                select @nDlyOrder = @@identity
				update T_GoodsStocksGlide set dlyorder = @nDlyOrder where VchCode = @nVchcode and dlyorder = 0		
				update SN set VchLineNO = @nDlyorder,Tag = 3 where Vchcode = @nVchcode and VchLineNO = 0	
                                if @@error <> 0 goto error1
				--更新委托发货数量
				if @nOrderCode <> 0 and @nOrderDlyCode <> 0 
				begin
					if exists(select VchCode from dlyother where [qty] > [Toqty] - @dQty and vchcode=@nOrderCode and dlyorder = @nOrderDlyCode and Pdetail <> 2)
					begin
						update dlyother set ToQty = ToQty - @dQty where vchcode = @nOrderCode and dlyorder = @nOrderDlyCode and Pdetail <> 2
						if @@error <> 0 goto error1
					end
					else 
					begin
						update dlyother set ToQty = Qty where vchcode = @nOrderCode and dlyorder = @nOrderDlyCode and Pdetail <> 2
						if @@error <> 0 goto error1
					end
				end 
                        end

                        fetch next from CreateDly_cursor into @szATypeID, @szPTypeID,@szKTypeID,@dQty,@dPrice,@dTotal,@dDiscount,@dDiscountPrice, @dDiscountTotal,
                        	@dTax,@dTaxPrice,@dTaxTotal,@dTax_Total,@dCostPrice, @dCostTotal,@szBlockno,@szProdate, @szMemo,@UsedType,@nGoodsNo,@nOrderCode,@nOrderDlyCode,
				@unit,@oDlyorder,@nHandInputZero
                end
--库存商品
		if @dTempCostTotal <> 0
		begin
	                insert into dlya(vchcode,Date,VchType,ATypeID,BTypeID,ETypeID,KTypeID,
	                                    Total,period,UsedType,comment,DeptID)
	                        values(@nVchcode,@tDate,@nVchType,@GOODS_ID,@szBTypeID,@szETypeID,@szKTypeID,
	                                @dTempCostTotal,@nPeriod,'',@szAutoSummary,@DeptID)
	                if @@rowcount <=0 goto error1
		end
--受托退货出库金额与结算金额不一样影响的销售成本
		if @dTotalMoney<>@dTempCosttotal
		begin
                		insert into dlya(vchcode,Date,VchType,ATypeID,BTypeID,ETypeID,KTypeID,
                                    		Total,period,UsedType,comment,DeptID)
                        		values(@nVchcode,@tDate,@nVchType,@SALE_COST_ID,@szBTypeID,@szETypeID,@szKTypeID,
                                		@dTotalMoney-@dTempCostTotal,@nPeriod,'',@szAutoSummary,@DeptID)
			if @@rowcount <=0 goto error1
		end
--受托商品款（含税）
		if @dTotalMoney <> 0
		begin
	                insert into dlya(vchcode,Date,VchType,ATypeID,BTypeID,ETypeID,KTypeID,
	                                    Total,period,UsedType,comment,DeptID)
	                        values(@nVchcode,@tDate,@nVchType,@RECOMMISSION_GOODS_ID,@szBTypeID,@szETypeID,@szKTypeID,
	                                @dTotalMoney,@nPeriod,'',@szAutoSummary,@DeptID)
	                if @@rowcount <=0 goto error1
		end

                update dlyndx set Total=Abs(@dTotalMoney) where vchcode=@nVchcode
                if @@rowcount <=0 goto error1

                CLOSE CreateDly_cursor
                DEALLOCATE CreateDly_cursor
        end
------------------------------受托退货单处理结束--------------------------


---受托结算开始

        if @nVchType=28
        begin
                select @type=5
                select @szAutoSummary = '第'+@szNumber+'受托结算单'
                select @execsql='declare CreateDly_cursor cursor for '
                                +' select ATypeID, PTypeID, qty, Price, Total, discount, discountPrice, discountTotal,
                                tax, taxPrice, taxTotal, tax_Total, costPrice, CostTotal, blockno, prodate, comment, UsedType,goodsno,ordercode,OrderDlyCode,unit from bakdly
                                 where Vchcode= '+CAST(@nVchcode AS varchar(10))+ '   order by dlyorder'
                exec (@execsql)

                select @nModiSalePrice= [stats] from syscon where [order]=3

                select @nTrackPrice = [stats] from syscon where [order]=8


                select @dTempTotal = 0
                select @dTempQty = 0
                select @dTotalMoney = 0
                select @dTempCostTotal = 0
                select @dTemptaxTotal = 0
                select @dTotalInMoney=0
                OPEN CreateDly_cursor
                fetch next from CreateDly_cursor into @szATypeID, @szPTypeID,@dQty,@dPrice,@dTotal,@dDiscount,@dDiscountPrice, @dDiscountTotal,
                        @dTax,@dTaxPrice,@dTaxTotal,@dTax_Total,@dCostPrice, @dCostTotal,@szBlockno,@szProdate, @szMemo, @UsedType,@nGoodsNo,@nOrderCode,@nOrderDlyCode,@unit
                while @@FETCH_STATUS=0
                begin
                        if (@szPTypeID<>''  ) and (@szPTypeID<>'00000')
                        begin
                                select @nCostmode=costmode, @deleted=deleted, @nSon=sonnum from ptype where typeid=@szPTypeID
                                if @deleted=1 or @nSon>0 goto error132
                                select @dQty = -@dQty
                                select @dTotal = -@dTotal
                                select @dDiscountTotal = -@dDiscountTotal
                                select @dTax_Total = -@dTax_Total
                                select @dCostTotal=@dDiscountTotal
                                exec  @nRet = ModifyDbfCom @nVchType,@GOODs_ID,@szPTypeID,@szBTypeID,
                                @dQty,@dTax_Total,@szBlockno,@szProdate,@dCostTotal,@type,@dTemp out,@dTemp1 out
                                if @nRet<0 goto error
--                              select @dCostPrice = @dTemp1 / @dQty
--                              select @dCostTotal = @dTemp1

--                              select @dTax_Total=@dTemp

                                select @dTempTotal = @dTempTotal+@dDiscountTotal
                                select @dTempQty = @dTempQty+@dQty
                                select @dTempCostTotal = @dTempCostTotal+@dCostTotal
                                select @dTotalMoney = @dTotalMoney+@dTax_Total
                                select @dTaxTotal=@dTax_Total-@dDiscountTotal
                                select @dTemptaxTotal = @dTemptaxTotal + @dTaxTotal

                                insert into dlybuy(vchcode,Date,VchType,ATypeID,PTypeID,BTypeID,ETypeID,KTypeID,KTypeID2,
                                    qty,Price,Total,costPrice,CostTotal,discount,discountPrice,discountTotal,
                                tax,taxPrice,taxTotal,tax_Total,Blockno,Prodate,comment,period,UsedType,costmode,unit,pdetail,DeptID,OrderCode,OrderDlyCode)


                                values(@nVchcode,@tDate,@nVchType,@szATypeID,@szPTypeID,@szBTypeID,@szETypeID,@RECOMMISSION_STOCK_ID,@szKTypeID2,
                                @dQty,@dPrice,@dTotal,@dCostPrice,@dCostTotal,@dDiscount,@dDiscountPrice,@dDiscountTotal,
                                @dTax,@dTaxPrice,@dTaxTotal,@dTax_Total,@szBlockno,@szProdate,@szMemo,@nPeriod,@UsedType,@nCostMode,@unit,2,@DeptID,@nOrderCode,@nOrderDlyCode)
                                if @@rowcount <=0 goto error1

				--更新委托发货数量
				if @nOrderCode <> 0 and @nOrderDlyCode <> 0 
				begin
					if exists(select VchCode from dlyother where [qty] > [Toqty] - @dQty and vchcode=@nOrderCode and dlyorder = @nOrderDlyCode and Pdetail <> 2)
					begin
						update dlyother set ToQty = ToQty - @dQty where vchcode = @nOrderCode and dlyorder = @nOrderDlyCode and Pdetail <> 2
						if @@error <> 0 goto error1
					end
					else
					begin 
						update dlyother set ToQty = Qty where vchcode = @nOrderCode and dlyorder = @nOrderDlyCode and Pdetail <> 2
						if @@error <> 0 goto error1
					end
				end 
                        end
                        else
                        begin
                                select @dTotalinMoney = @dTotalinMoney + @dTotal
                                insert into dlya(vchcode,Date,VchType,ATypeID,BTypeID,ETypeID,KTypeID,
                                    Total,period,UsedType,comment,DeptID)
                                values(@nVchcode,@tDate,@nVchType,@szATypeID,@szBTypeID,@szETypeID,@szKTypeID,
                                       -@dTotal,@nPeriod,@UsedType,@szAutoSummary,@DeptID)
                                if @@rowcount <=0 goto error1
                        end

                        FETCH NEXT FROM CREATEDLY_CURSOR INTO @SZATYPEID, @SZPTYPEID,@DQTY,@DPRICE,@DTOTAL,@DDISCOUNT,@DDISCOUNTPRICE, @DDISCOUNTTOTAL,
                        @DTAX,@DTAXPRICE,@DTAXTOTAL,@DTAX_TOTAL,@DCOSTPRICE, @DCOSTTOTAL,@SZBLOCKNO,@SZPRODATE, @SZMEMO,  @USEDTYPE,@NGOODSNO,@NORDERCODE,@NORDERDLYCODE,@UNIT
                end

--贷应付_进项增值税
                if @dTempTaxTotal<>0
                begin
                        insert into dlya(vchcode,Date,VchType,ATypeID,BTypeID,ETypeID,KTypeID,
                                    Total,period,UsedType,comment,DeptID)
                        values(@nVchcode,@tDate,@nVchType,@TAX_ID,@szBTypeID,@szETypeID,@szKTypeID,
                                @dTemptaxTotal,@nPeriod,'',@szAutoSummary,@DeptID)
                        if @@rowcount <=0 goto error1
                end

--应收应付
                if @dTotalInMoney <> @dTotalMoney
                begin
                        select @dTemp = abs(@dTotalMoney)-@dTotalInMoney
                        insert into dlya(vchcode,Date,VchType,ATypeID,BTypeID,ETypeID,KTypeID,
                                    Total,period,UsedType,comment,DeptID)
                        values(@nVchcode,@tDate,@nVchType,@AP_ID,@szBTypeID,@szETypeID,@szKTypeID,
                                @dTemp,@nPeriod,'',@szAutoSummary,@DeptID)
                        if @@rowcount <=0 goto error1
                end


--借受托商品款（含税）
		if @dTempCostTotal <> 0
		begin
	                insert into dlya(vchcode,Date,VchType,ATypeID,BTypeID,ETypeID,KTypeID,
	                                    Total,period,UsedType,comment,DeptID)
	                        values(@nVchcode,@tDate,@nVchType,@RECOMMISSION_GOODS_ID,@szBTypeID,@szETypeID,@szKTypeID,
	                                @dTempCostTotal,@nPeriod,'',@szAutoSummary,@DeptID)
	                if @@rowcount <=0 goto error1
		end

                update dlyndx set Total=Abs(@dTotalMoney) where vchcode=@nVchcode
                if @@rowcount <=0 goto error1


                CLOSE CreateDly_cursor
                DEALLOCATE CreateDly_cursor
        end
------------------------------受托结算处理结束--------------------------


---受托调价单开始

        if @nVchType=51
        begin
                select @type=5
                select @szAutoSummary = '第'+@szNumber+'受托调价单'
                select @execsql='declare CreateDly_cursor cursor for '
                                +' select ATypeID, PTypeID, qty, Price, Total, discount, discountPrice, discountTotal,
                                tax, taxPrice, taxTotal, tax_Total, costPrice, CostTotal, blockno, prodate, comment,UsedType,goodsno,ordercode,unit from bakdly

                                 where Vchcode= '+CAST(@nVchcode AS varchar(10))+' order by dlyorder'
                exec (@execsql)

                select @dTempTotal = 0
                select @dTempQty = 0
                select @dTotalMoney = 0
                select @dTempCostTotal = 0
                select @dTemptaxTotal = 0
                OPEN CreateDly_cursor
                fetch next from CreateDly_cursor into @szATypeID, @szPTypeID,@dQty,@dPrice,@dTotal,@dDiscount,@dDiscountPrice, @dDiscountTotal,
                        @dTax,@dTaxPrice,@dTaxTotal,@dTax_Total,@dCostPrice, @dCostTotal,@szBlockno,@szProdate, @szMemo,  @UsedType,@nGoodsNo,@nOrderCode,@unit
                while @@FETCH_STATUS=0
                begin
                        if (@szPTypeID<>''  ) and (@szPTypeID<>'00000')
                        begin
                                select @nCostmode=costmode, @deleted=deleted, @nSon=sonnum from ptype where typeid=@szPTypeID
                                if @deleted=1 or @nSon>0 goto error132
/*                              exec  @nRet = ModifyDbf @nVchType,@nCostmode,@GOODs_ID,@szPTypeID,'',@szETypeID,@szKTypeID,
                                @nPeriod,@dQty,@dDiscountTotal,@szBlockno,@szProdate,@nGoodsNo,@dTemp out
                                if @nRet<0 goto error
                                select @dCostPrice = @dTemp / @dQty
                                select @dCostTotal = @dTemp */

                                select @dTempTotal = @dTempTotal+@dDiscountTotal
                                select @dTempQty = @dTempQty+@dQty
                                select @dTempCostTotal = @dTempCostTotal+@dCostTotal
                                select @dTotalMoney = @dTotalMoney+@dTax_Total
                                select @dTaxTotal=@dTax_Total-@dDiscountTotal
                                select @dTemptaxTotal = @dTemptaxTotal + @dTaxTotal

                                insert into dlyother(vchcode,Date,VchType,ATypeID,PTypeID,BTypeID,ETypeID,KTypeID,KTypeID2,
                                qty,Price,Total,costPrice,CostTotal,discount,discountPrice,discountTotal,
                                tax,taxPrice,taxTotal,tax_Total,Blockno,Prodate,comment,period,UsedType,costmode,unit,PDETAIL,DeptID)
                                values(@nVchcode,@tDate,@nVchType,@szATypeID,@szPTypeID,@szBTypeID,@szETypeID,@RECOMMISSION_STOCK_ID,@szKTypeID2,
                                @dQty,@dPrice,@dTotal,@dCostPrice,@dCostTotal,@dDiscount,@dDiscountPrice,@dDiscountTotal,
                                @dTax,@dTaxPrice,@dTaxTotal,@dTax_Total,@szBlockno,@szProdate,@szMemo,@nPeriod,@UsedType,@nCostMode,@unit,2,@DeptID)

                                if @@rowcount <=0 goto error1

                                exec  @nRet = ModifyDbfCom @nVchType,@GOODs_ID,@szPTypeID,@szBTypeID,
                                0,@dTax_Total,@szBlockno,@szProdate,@dTax_Total,@type,@dTemp out,@dTemp1 out
                                if @nRet<0 goto error
                        end

                        fetch next from CreateDly_cursor into @szATypeID, @szPTypeID,@dQty,@dPrice,@dTotal,@dDiscount,@dDiscountPrice, @dDiscountTotal,
                        @dTax,@dTaxPrice,@dTaxTotal,@dTax_Total,@dCostPrice, @dCostTotal,@szBlockno,@szProdate, @szMemo,  @UsedType,@nGoodsNo,@nOrderCode,@unit
                end

--受托商品增加
		if @dTotalMoney <> 0
		begin
			insert into dlya(vchcode,Date,vchType,atypeid,btypeid,etypeid,ktypeid,
				total,period,usedtype,DeptID)
				values(@nVchcode,@tDate,@nVchType,@RECOMMISSION_GOODS_ID,@szBtypeid,@szEtypeid,@szKtypeId,
					@dTotalMoney,@nperiod,'',@DeptID)
			if @@rowcount <=0 goto error1
		end
--销售成本增加
		if @dTotalMoney <> 0
		begin
			insert into dlya(vchcode,Date,vchType,atypeid,btypeid,etypeid,ktypeid,
				total,period,usedtype,DeptID)
				values(@nVchcode,@tDate,@nVchType,@SALE_COST_ID,@szBtypeid,@szEtypeid,@szKtypeId,
					@dTotalMoney,@nperiod,'',@DeptID)
			if @@rowcount <=0 goto error1
		end

                update dlyndx set Total=@dTotalMoney where vchcode=@nVchcode
                if @@rowcount <=0 goto error1

                CLOSE CreateDly_cursor
                DEALLOCATE CreateDly_cursor
        end
------------------------------受托收货单处理结束--------------------------


---销售退货单开始

        if @nVchType=45
        begin
                select @execsql='declare CreateDly_cursor cursor for '
                                +' select ATypeID, PTypeID,KTypeid, qty, Price, Total, discount, discountPrice, discountTotal,
                                tax, taxPrice, taxTotal, tax_Total, costPrice, CostTotal, blockno, prodate, comment, UsedType,
				goodsno,unit,dlyorder,VipCardID from bakdly
                                 where Vchcode= '+CAST(@nVchcode AS varchar(10))
                exec (@execsql)

                select @dTotalinMoney = 0

                select @dTempTotal = 0
                select @dTempQty = 0
                select @dTotalMoney = 0
                select @dTempCostTotal = 0
                select @dTemptaxTotal = 0
                OPEN CreateDly_cursor
                fetch next from CreateDly_cursor into @szATypeID, @szPTypeID,@szKTypeID,@dQty,@dPrice,@dTotal,@dDiscount,@dDiscountPrice, @dDiscountTotal,
                        @dTax,@dTaxPrice,@dTaxTotal,@dTax_Total,@dCostPrice, @dCostTotal,@szBlockno,@szProdate, @szMemo, @UsedType,@nGoodsNo,@unit,@odlyorder,@nVipCardID
                while @@FETCH_STATUS=0
                begin
                        if @szPTypeID<>''
                        begin
                                select @nCostmode=costmode, @deleted=deleted, @nSon=sonnum,@lsSerial = lsSerial from ptype where typeid=@szPTypeID
                                if @deleted=1 or @nSon>0 goto error132
				if not Exists( Select typeid from Stock where typeid=@szKTypeID and Deleted=0 and SonNum=0) goto error135r

                                exec  @nRet = ModifyDbf 45,@nVchcode,@tDate,@nCostmode,@GOODs_ID,@szPTypeID,'',@szETypeID,@szKTypeID,
                                @nPeriod,@dQty,@dCostTotal,@szBlockno,@szProdate,0,@dTemp out,@odlyorder,@lsSerial
                                if @nRet<0 goto error
                                select @dCostPrice = @dTemp / @dQty
                                select @dCostTotal = @dTemp

                                select @dTempTotal = @dTempTotal+@dDiscountTotal
                                select @dTempQty = @dTempQty+@dQty
                                select @dTempCostTotal = @dTempCostTotal+@dCostTotal
                                select @dTotalMoney = @dTotalMoney+@dTax_Total
                                select @dTemptaxTotal = @dTemptaxTotal + @dTaxTotal

                                insert into dlysale(vchcode,Date,VchType,ATypeID,PTypeID,BTypeID,ETypeID,KTypeID,KTypeID2,
                                    qty,Price,Total,costPrice,CostTotal,discount,discountPrice,discountTotal,
                                tax,taxPrice,taxTotal,tax_Total,Blockno,Prodate,comment,period,UsedType,costmode,unit,DeptID,VipCardID)
                                values(@nVchcode,@tDate,@nVchType,@szATypeID,@szPTypeID,@szBTypeID,@szETypeID,@szKTypeID,@szKTypeID2,
                                @dQty,@dPrice,@dTotal,@dCostPrice,@dCostTotal,@dDiscount,@dDiscountPrice,@dDiscountTotal,
                                @dTax,@dTaxPrice,@dTaxTotal,@dTax_Total,@szBlockno,@szProdate,@szMemo,@nPeriod,@UsedType,@nCostMode,@unit,@DeptID,@nVipCardID)
				--add by dcsong 2004.8.17 更新对应库存变动，一个单据号的且dlyorder为0的，当前变动的明细
                                select @nDlyOrder = @@identity
				update T_GoodsStocksGlide set dlyorder = @nDlyOrder where VchCode = @nVchcode and dlyorder = 0		
				update SN set VchLineNO = @nDlyorder,Tag = 2 where Vchcode = @nVchcode and VchLineNO = 0	
                        end
                        else
			if @szATypeID=@PREPERENTIAL_ID
			begin
				select @dPreferential = @dTotal
				insert into dlya(vchcode,Date,VchType,ATypeID,BTypeID,ETypeID,KTypeID,
				    Total,period,UsedType,DeptID)
				values(@nVchcode,@tDate,@nVchType,@szATypeID,@szBTypeID,@szETypeID,@szKTypeID,
					-@dTotal,@nPeriod,@UsedType,@DeptID)
			end
			else
                        begin
				if not Exists( Select typeid from Atype where typeid=@szATypeID and Deleted=0 and SonNum=0) goto error137r
                                select @dTotalinMoney = @dTotalinMoney + @dTotal
                                select @dTotal= -@dTotal
                                insert into dlya(vchcode,Date,VchType,ATypeID,BTypeID,ETypeID,KTypeID,
                                    Total,period,UsedType,DeptID)
                                values(@nVchcode,@tDate,@nVchType,@szATypeID,@szBTypeID,@szETypeID,@szKTypeID,
                                        @dTotal,@nPeriod,@UsedType,@DeptID)
                        end
                        if @@error <> 0 goto error1


                        fetch next from CreateDly_cursor into @szATypeID, @szPTypeID,@szKTypeID,@dQty,@dPrice,@dTotal,@dDiscount,@dDiscountPrice, @dDiscountTotal,
                        @dTax,@dTaxPrice,@dTaxTotal,@dTax_Total,@dCostPrice, @dCostTotal,@szBlockno,@szProdate, @szMemo, @UsedType,@nGoodsNo,@unit,@odlyorder,@nVipCardID
                end
--库存商品
		if @dTempCostTotal <> 0
		begin
	                insert into dlya(vchcode,Date,VchType,ATypeID,BTypeID,ETypeID,KTypeID,
	                                    Total,period,UsedType,DeptID)
	                        values(@nVchcode,@tDate,@nVchType,@GOODS_ID,@szBTypeID,@szETypeID,@szKTypeID,
	                                @dTempCostTotal,@nPeriod,'',@DeptID)
	                if @@rowcount <=0 goto error1
		end
--应交税金减少
                if @dTempTaxTotal<>0
                begin

                        insert into dlya(vchcode,Date,VchType,ATypeID,BTypeID,ETypeID,KTypeID,
                    Total,period,UsedType,DeptID)
                        values(@nVchcode,@tDate,@nVchType,@TAX_ID,@szBTypeID,@szETypeID,@szKTypeID,
                                -@dTemptaxTotal,@nPeriod,'',@DeptID)
                        if @@rowcount <=0 goto error1
                end

--销售收入
		if @dTempTotal <> 0
		begin
	                insert into dlya(vchcode,Date,VchType,ATypeID,BTypeID,ETypeID,KTypeID,
	                                    Total,period,UsedType,DeptID)
	                        values(@nVchcode,@tDate,@nVchType,@SALE_INCOME_ID,@szBTypeID,@szETypeID,@szKTypeID,
	                                -@dTempTotal,@nPeriod,'',@DeptID)
	                if @@rowcount <=0 goto error1
		end
--销售成本
		if @dTempCostTotal <> 0

		begin
	                insert into dlya(vchcode,Date,VchType,ATypeID,BTypeID,ETypeID,KTypeID,
	                                    Total,period,UsedType,DeptID)
	                        values(@nVchcode,@tDate,@nVchType,@SALE_COST_ID,@szBTypeID,@szETypeID,@szKTypeID,
	                                -@dTempCostTotal,@nPeriod,'',@DeptID)
	                if @@rowcount <=0 goto error1
		end
--应收应付
		select @dTemp = -(@dTotalMoney-@dTotalInMoney-@dPreferential)
		if @dTemp<>0
               -- if @dTotalInMoney <> @dTotalMoney
                begin
                 --       select @dTemp = -(@dTotalMoney-@dTotalInMoney)
                        insert into dlya(vchcode,Date,VchType,ATypeID,BTypeID,ETypeID,KTypeID,
                                    Total,period,UsedType,DeptID)
                        values(@nVchcode,@tDate,@nVchType,@AR_ID,@szBTypeID,@szETypeID,@szKTypeID,
                                @dTemp,@nPeriod,'',@DeptID)
                        if @@rowcount <=0 goto error1
                end

                update dlyndx set Total=Abs(@dTotalMoney) where vchcode=@nVchcode
                if @@rowcount <=0 goto error1

                CLOSE CreateDly_cursor
                DEALLOCATE CreateDly_cursor
        end
------------------------------销售退货单处理结束--------------------------


---变价调拨单开始

        if @nVchType=21
        begin
                select @execsql='declare CreateDly_cursor cursor for '
                                +' select ATypeID, PTypeID, qty, Price, Total, discount, discountPrice, discountTotal,
                                tax, taxPrice, taxTotal, tax_Total, costPrice, CostTotal, blockno, prodate, comment, 
				UsedType,goodsno,unit,RetailPrice,dlyorder,HandZeroCost from bakdly
                                 where Vchcode= '+CAST(@nVchcode AS varchar(10))
                exec (@execsql)

                select @dTotalinMoney = 0
                select @dTempTotal = 0
                select @dTempQty = 0
                select @dTotalMoney = 0
                select @dTempCostTotal = 0
                select @dTemptaxTotal = 0
                OPEN CreateDly_cursor
                fetch next from CreateDly_cursor into @szATypeID, @szPTypeID,@dQty,@dPrice,@dTotal,@dDiscount,@dDiscountPrice, @dDiscountTotal,
                        @dTax,@dTaxPrice,@dTaxTotal,@dTax_Total,@dCostPrice, @dCostTotal,@szBlockno,@szProdate, @szMemo, @UsedType,@nGoodsNo,
			@unit,@RetailPrice,@odlyorder,@nHandInputZero
                while @@FETCH_STATUS=0
                begin
                                select @nCostmode=costmode, @deleted=deleted, @nSon=sonnum,@lsSerial = lsSerial from ptype where typeid=@szPTypeID
                                if @deleted=1 or @nSon>0 goto error132
                        	select @dQty = -@dQty
                        	select @dCostTotal = -@dCostTotal
				select @dTemp=@dcostprice

                                exec  @nRet = ModifyDbf 21,@nVchcode,@tDate,@nCostmode,@GOODs_ID,@szPTypeID,'',@szETypeID,@szKTypeID2,
                                @nPeriod,@dQty,@dCostTotal,@szBlockno,@szProdate,@nGoodsNo,@dTemp out,@odlyorder,@lsSerial,@nHandInputZero
                                if @nRet<0 goto error
                                select @dCostPrice = @dTemp / @dQty

                                select @dCostTotal = @dTemp

                        insert into dlyother(vchcode,Date,VchType,ATypeID,PTypeID,BTypeID,ETypeID,KTypeID,KTypeID2,
                                    qty,Price,Total,costPrice,CostTotal,discount,discountPrice,discountTotal,
                                tax,taxPrice,taxTotal,tax_Total,Blockno,Prodate,comment,period,UsedType,costmode,unit,DeptID,RetailPrice)
                        values(@nVchcode,@tDate,@nVchType,@GOODS_ID,@szPTypeID,@szBTypeID,@szETypeID,@szKTypeID2,@szKTypeID,
                                @dQty,@dPrice,@dTotal,@dCostPrice,@dCostTotal,@dDiscount,@dDiscountPrice,@dDiscountTotal,
                                @dTax,@dTaxPrice,@dTaxTotal,@dTax_Total,@szBlockno,@szProdate,@szMemo,@nPeriod,@UsedType,@nCostMode,@unit,@DeptID,@RetailPrice)
				--add by dcsong 2004.8.17 更新对应库存变动，一个单据号的且dlyorder为0的，当前变动的明细
                                select @nDlyOrder = @@identity
				update T_GoodsStocksGlide set dlyorder = @nDlyOrder where VchCode = @nVchcode and dlyorder = 0		
				update SN set VchLineNO = @nDlyorder,Tag = 3 where Vchcode = @nVchcode and VchLineNO = 0	
                        	if @@error <> 0 goto error1

                                select @dTempTotal = @dTempTotal+@dDiscountTotal
                                select @dTempQty = @dTempQty+@dQty
                                select @dTempCostTotal = @dTempCostTotal+@dCostTotal

			-----------modi by dcsong 2004.10.12 修改同价调拨单调批次问题-----------------
			if @nCostmode in (1,2) --如果是先进先出或后进先出,用此方法
			begin
				select @nTimeDB = 0
				select @dQty = -@dQty
				select @dChangeTotalDB = 0
				select distinct JobNumber,OutFactoryDate from T_GoodsStocksGlide
				where VchCode = @nVchcode and dlyorder = @nDlyOrder
				select @nChangeDB = @@RowCount

				declare DBCreatedly_cursor cursor for 
				select sum(qty) qty,JobNumber,OutFactoryDate from T_GoodsStocksGlide
				where VchCode = @nVchcode and dlyorder = @nDlyOrder 
				group by JobNumber,OutFactoryDate
                		OPEN DBCreatedly_cursor
                		fetch next from DBCreatedly_cursor into @dqtyDB,@szJobNumberDB,@szOutFactoryDateDB
                		while @@FETCH_STATUS=0  --读出变动表中的数据过帐
				begin
					select @dqtyDB = -1*@dqtyDB
					if @nChangeDB = 1 select @dTotalDB = @dDiscountTotal
					else if @nTimeDB = @nChangeDB - 1
						select @dTotalDB = @dDiscountTotal - @dChangeTotalDB
					else
						select @dTotalDB = @dDiscountTotal*@dqtyDB/@dQty

					if @nTimeDB = 0
					begin
		                                exec  @nRet = ModifyDbf 21,@nVchcode,@tDate,@nCostmode,@GOODs_ID,@szPTypeID,@szBTypeID,@szETypeID,@szKTypeID,
		                                @nPeriod,@dqtyDB,@dTotalDB,@szJobNumberDB,@szOutFactoryDateDB,0,@dTemp out,@odlyorder,@lsSerial
		                                if @nRet<0 goto error2
					end
					else
					begin
		                                exec  @nRet = ModifyDbf 21,@nVchcode,@tDate,@nCostmode,@GOODs_ID,@szPTypeID,@szBTypeID,@szETypeID,@szKTypeID,
		                                @nPeriod,@dqtyDB,@dTotalDB,@szJobNumberDB,@szOutFactoryDateDB,0,@dTemp out,0,0
		                                if @nRet<0 goto error2
					end
					select @nTimeDB = @nTimeDB + 1
					select @dChangeTotalDB = @dChangeTotalDB + @dTotalDB 

                		fetch next from DBCreatedly_cursor into @dqtyDB,@szJobNumberDB,@szOutFactoryDateDB
				end	
				CLOSE DBCreatedly_cursor
        			DEALLOCATE DBCreatedly_cursor			
			end
			else
			begin
                                select @dQty = -@dQty
                                exec  @nRet = ModifyDbf 21,@nVchcode,@tDate,@nCostmode,@GOODs_ID,@szPTypeID,'',@szETypeID,@szKTypeID,
                                @nPeriod,@dQty,@dDiscountTotal,@szBlockno,@szProdate,@nGoodsNo,@dTemp out,@odlyorder,@lsSerial
  if @nRet<0 goto error
			end
			-----------modi by dcsong 2004.10.12 修改同价调拨单调批次问题-----------------

                        insert into dlyother(vchcode,Date,VchType,ATypeID,PTypeID,BTypeID,ETypeID,KTypeID,KTypeID2,
                                    qty,Price,Total,costPrice,CostTotal,discount,discountPrice,discountTotal,
                                tax,taxPrice,taxTotal,tax_Total,Blockno,Prodate,comment,period,UsedType,costmode,unit,DeptID)
                        values(@nVchcode,@tDate,@nVchType,@GOODS_ID,@szPTypeID,@szBTypeID,@szETypeID,@szKTypeID,@szKTypeID,
                                @dQty,@dPrice,@dDiscountTotal,@dDiscountPrice,@dDiscountTotal,@dDiscount,@dDiscountPrice,@dDiscountTotal,
                                @dTax,@dTaxPrice,@dTaxTotal,@dTax_Total,@szBlockno,@szProdate,@szMemo,@nPeriod,'',@nCostMode,@unit,@DeptID)
				--add by dcsong 2004.8.17 更新对应库存变动，一个单据号的且dlyorder为0的，当前变动的明细
                                select @nDlyOrder = @@identity
				update T_GoodsStocksGlide set dlyorder = @nDlyOrder where VchCode = @nVchcode and dlyorder = 0		
				update SN set VchLineNO = @nDlyorder,Tag = 2 where Vchcode = @nVchcode and VchLineNO = 0	
                        	if @@error <> 0 goto error1


                        fetch next from CreateDly_cursor into @szATypeID, @szPTypeID,@dQty,@dPrice,@dTotal,@dDiscount,@dDiscountPrice, @dDiscountTotal,
                        	@dTax,@dTaxPrice,@dTaxTotal,@dTax_Total,@dCostPrice, @dCostTotal,@szBlockno,@szProdate, @szMemo, @UsedType,@nGoodsNo,@unit,
				@RetailPrice,@odlyorder,@nHandInputZero
                end
--库存商品减少
		if @dTempCostTotal <> 0 
		begin
	                insert into dlya(vchcode,Date,VchType,ATypeID,BTypeID,ETypeID,KTypeID,
		                                    Total,period,UsedType,DeptID)
	                        values(@nVchcode,@tDate,@nVchType,@GOODS_ID,@szBTypeID,@szETypeID,@szKTypeID,
	                                @dTempCostTotal,@nPeriod,'',@DeptID)
	                if @@rowcount <=0 goto error1
		end
--库存商品增加
		if @dTempTotal <> 0
		begin
	                insert into dlya(vchcode,Date,VchType,ATypeID,BTypeID,ETypeID,KTypeID,
	                                    Total,period,UsedType,DeptID)
	                        values(@nVchcode,@tDate,@nVchType,@GOODS_ID,@szBTypeID,@szETypeID,@szKTypeID,
	                                @dTempTotal,@nPeriod,'',@DeptID)
	                if @@rowcount <=0 goto error1
		end
--变价调拨与成本差
                select @dTemp = @dTempTotal+@dTempCostTotal
                if @dTemp<>0
                begin
                        insert into dlya(vchcode,Date,VchType,ATypeID,BTypeID,ETypeID,KTypeID,

                                    Total,period,UsedType,DeptID)
                        values(@nVchcode,@tDate,@nVchType,@PriceALLOT_CHANGE_ID,@szBTypeID,@szETypeID,@szKTypeID,
                                @dTemp,@nPeriod,'',@DeptID)
                        if @@rowcount <=0 goto error1
                end

                update dlyndx set Total=Abs(@dTempTotal) where vchcode=@nVchcode
                if @@rowcount <=0 goto error1

                CLOSE CreateDly_cursor
                DEALLOCATE CreateDly_cursor

        end
------------------------------变价调拨单处理结束--------------------------


---调价单开始

        if @nVchType=57
        begin
                select @execsql='declare CreateDly_cursor cursor for '
                                +' select ATypeID, PTypeID, qty, Price, Total, discount, discountPrice, discountTotal,
                                tax, taxPrice, taxTotal, tax_Total, costPrice, CostTotal, blockno, prodate, comment, 
				UsedType,goodsno,unit,dlyorder,RetailPrice,HandZeroCost from bakdly
                                 where Vchcode= '+CAST(@nVchcode AS varchar(10))
                exec (@execsql)



                select @dTempTotal = 0
                select @dTempQty = 0
                select @dTempCostTotal = 0
                OPEN CreateDly_cursor
                fetch next from CreateDly_cursor into @szATypeID, @szPTypeID,@dQty,@dPrice,@dTotal,@dDiscount,@dDiscountPrice, @dDiscountTotal,
                        @dTax,@dTaxPrice,@dTaxTotal,@dTax_Total,@dCostPrice, @dCostTotal,@szBlockno,@szProdate, @szMemo, @UsedType,@nGoodsNo,
			@unit,@odlyorder,@RetailPrice,@nHandInputZero
                while @@FETCH_STATUS=0
                begin

                                select @dQty = -@dQty
                                select @dCostTotal = -@dCostTotal
                                select @nCostmode=costmode, @deleted=deleted, @nSon=sonnum,@lsSerial = lsSerial from ptype where typeid=@szPTypeID
                                if @deleted=1 or @nSon>0 goto error132
				select @dTemp=@dcostprice
                                exec  @nRet = ModifyDbf 57,@nVchcode,@tDate,@nCostmode,@GOODs_ID,@szPTypeID,'',@szETypeID,@szKTypeID,
                                @nPeriod,@dQty,@dCostTotal,@szBlockno,@szProdate,@nGoodsNo,@dTemp out,@odlyorder,0,@nHandInputZero
                                if @nRet<0 goto error
                                select @dCostPrice = @dTemp / @dQty
                                select @dCostTotal = @dTemp

                        insert into dlyother(vchcode,Date,VchType,ATypeID,PTypeID,BTypeID,ETypeID,KTypeID,KTypeID2,
                                    qty,Price,Total,costPrice,CostTotal,discount,discountPrice,discountTotal,
                                tax,taxPrice,taxTotal,tax_Total,Blockno,Prodate,comment,period,UsedType,costmode,unit,DeptID,RetailPrice)
                        values(@nVchcode,@tDate,@nVchType,@GOODS_ID,@szPTypeID,@szBTypeID,@szETypeID,@szKTypeID,@szKTypeID,

                                @dQty,@dPrice,@dTotal,@dCostPrice,@dCostTotal,@dDiscount,@dDiscountPrice,@dCostTotal,
                                @dTax,@dTaxPrice,@dTaxTotal,@dTax_Total,@szBlockno,@szProdate,@szMemo,@nPeriod,@UsedType,@nCostMode,@unit,@DeptID,@RetailPrice)
				--add by dcsong 2004.8.17 更新对应库存变动，一个单据号的且dlyorder为0的，当前变动的明细
                                select @nDlyOrder = @@identity
				update T_GoodsStocksGlide set dlyorder = @nDlyOrder where VchCode = @nVchcode and dlyorder = 0		
				--update SN set VchLineNO = @nDlyorder,Tag = 3 where Vchcode = @nVchcode and VchLineNO = @oDlyorder	
                        	if @@error <> 0 goto error1

                                select @dTempTotal = @dTempTotal+@dTotal
                                select @dTempQty = @dTempQty+@dQty
                                select @dTempCostTotal = @dTempCostTotal+@dCostTotal

			-----------modi by dcsong 2004.10.12 修改同价调拨单调批次问题-----------------
			if @nCostmode in (1,2) --如果是先进先出或后进先出,用此方法
			begin
				select @nTimeDB = 0
				select @dQty = -@dQty
				select @dChangeTotalDB = 0
				select distinct JobNumber,OutFactoryDate from T_GoodsStocksGlide
				where VchCode = @nVchcode and dlyorder = @nDlyOrder
				select @nChangeDB = @@RowCount

				declare DBCreatedly_cursor cursor for 
				select sum(qty) qty,JobNumber,OutFactoryDate from T_GoodsStocksGlide
				where VchCode = @nVchcode and dlyorder = @nDlyOrder 
				group by JobNumber,OutFactoryDate
                		OPEN DBCreatedly_cursor
                		fetch next from DBCreatedly_cursor into @dqtyDB,@szJobNumberDB,@szOutFactoryDateDB
                		while @@FETCH_STATUS=0  --读出变动表中的数据过帐
				begin
					select @dqtyDB = -1*@dqtyDB
					if @nChangeDB = 1 select @dTotalDB = @dDiscountTotal
					else if @nTimeDB = @nChangeDB - 1
						select @dTotalDB = @dDiscountTotal - @dChangeTotalDB
					else
						select @dTotalDB = @dDiscountTotal*@dqtyDB/@dQty

					if @nTimeDB = 0
					begin
		                                exec  @nRet = ModifyDbf 57,@nVchcode,@tDate,@nCostmode,@GOODs_ID,@szPTypeID,@szBTypeID,@szETypeID,@szKTypeID,
		                                @nPeriod,@dqtyDB,@dTotalDB,@szJobNumberDB,@szOutFactoryDateDB,0,@dTemp out,@odlyorder,0
		                                if @nRet<0 goto error2
					end
					else
					begin
		                                exec  @nRet = ModifyDbf 57,@nVchcode,@tDate,@nCostmode,@GOODs_ID,@szPTypeID,@szBTypeID,@szETypeID,@szKTypeID,
		                                @nPeriod,@dqtyDB,@dTotalDB,@szJobNumberDB,@szOutFactoryDateDB,0,@dTemp out,0,0
		                                if @nRet<0 goto error2
					end
					select @nTimeDB = @nTimeDB + 1
					select @dChangeTotalDB = @dChangeTotalDB + @dTotalDB 

                		fetch next from DBCreatedly_cursor into @dqtyDB,@szJobNumberDB,@szOutFactoryDateDB
				end	
				CLOSE DBCreatedly_cursor
        			DEALLOCATE DBCreatedly_cursor			
			end
			else
			begin
                                select @dQty = -@dQty
                                exec  @nRet = ModifyDbf 57,@nVchcode,@tDate,@nCostmode,@GOODs_ID,@szPTypeID,'',@szETypeID,@szKTypeID,
                                @nPeriod,@dQty,@dTotal,@szBlockno,@szProdate,@nGoodsNo,@dTemp out,@odlyorder,0
                                if @nRet<0 goto error
			end
			-----------modi by dcsong 2004.10.12 修改同价调拨单调批次问题-----------------

                        insert into dlyother(vchcode,Date,VchType,ATypeID,PTypeID,BTypeID,ETypeID,KTypeID,KTypeID2,
                                    qty,Price,Total,costPrice,CostTotal,discount,discountPrice,discountTotal,
                                tax,taxPrice,taxTotal,tax_Total,Blockno,Prodate,comment,period,UsedType,costmode,unit,DeptID,RetailPrice)
                        values(@nVchcode,@tDate,@nVchType,@GOODS_ID,@szPTypeID,@szBTypeID,@szETypeID,@szKTypeID,@szKTypeID,
                                @dQty,@dPrice,@dTotal,@dPrice,@dTotal,@dDiscount,@dDiscountPrice,@dTotal,
                                @dTax,@dTaxPrice,@dTaxTotal,@dTax_Total,@szBlockno,@szProdate,@szMemo,@nPeriod,'',@nCostMode,@unit,@DeptID,@RetailPrice)
				--add by dcsong 2004.8.17 更新对应库存变动，一个单据号的且dlyorder为0的，当前变动的明细
                                select @nDlyOrder = @@identity
				update T_GoodsStocksGlide set dlyorder = @nDlyOrder where VchCode = @nVchcode and dlyorder = 0		
				--update SN set VchLineNO = @nDlyorder,Tag = 2 where Vchcode = @nVchcode and VchLineNO = @oDlyorder	
                        	if @@error <> 0 goto error1

			--解决加权平均法调价单调完后序列号出错的问题
			if @nCostmode = 0 
			begin
				update t_serial set GOODSORDERID = (select GOODSORDERID from GoodsStocks where ptypeid = @szPTypeID and ktypeid = @szKTypeID) 
				where ptypeid = @szPTypeID and ktypeid = @szKTypeID 
			end

                        fetch next from CreateDly_cursor into @szATypeID, @szPTypeID,@dQty,@dPrice,@dTotal,@dDiscount,@dDiscountPrice, @dDiscountTotal,
                        	@dTax,@dTaxPrice,@dTaxTotal,@dTax_Total,@dCostPrice, @dCostTotal,@szBlockno,@szProdate, @szMemo, @UsedType,@nGoodsNo,
				@unit,@odlyorder,@RetailPrice,@nHandInputZero
                end
--库存商品减少
		if @dTempCostTotal <> 0 
		begin
	                insert into dlya(vchcode,Date,VchType,ATypeID,BTypeID,ETypeID,KTypeID,
	                                    Total,period,UsedType,DeptID)
	                        values(@nVchcode,@tDate,@nVchType,@GOODS_ID,@szBTypeID,@szETypeID,@szKTypeID,
	                                @dTempCostTotal,@nPeriod,'',@DeptID)
	                if @@rowcount <=0 goto error1
		end
--库存商品增加
		if @dTempTotal <> 0
		begin
	                insert into dlya(vchcode,Date,VchType,ATypeID,BTypeID,ETypeID,KTypeID,
		                                    Total,period,UsedType,DeptID)
	                        values(@nVchcode,@tDate,@nVchType,@GOODS_ID,@szBTypeID,@szETypeID,@szKTypeID,
	                                @dTempTotal,@nPeriod,'',@DeptID)
	                if @@rowcount <=0 goto error1
		end
--调价收入
                select @dTemp = @dTempTotal+@dTempCostTotal
                if @dTemp<>0
                begin
                        insert into dlya(vchcode,Date,VchType,ATypeID,BTypeID,ETypeID,KTypeID,

                                    Total,period,UsedType,DeptID)
                        values(@nVchcode,@tDate,@nVchType,@ALLOT_INCOME_ID,@szBTypeID,@szETypeID,@szKTypeID,
                                @dTemp,@nPeriod,'',@DeptID)
                        if @@rowcount <=0 goto error1
                end

                update dlyndx set Total=Abs(@dTempTotal) where vchcode=@nVchcode
                if @@rowcount <=0 goto error1

                CLOSE CreateDly_cursor
                DEALLOCATE CreateDly_cursor
        end
------------------------------调价单处理结束--------------------------


---生产单开始


        if @nVchType=16
        begin
                select @execsql='declare CreateDly_cursor cursor for '
                                +' select ATypeID, PTypeID, qty, Price, Total, discount, discountPrice, discountTotal,
                                tax, taxPrice, taxTotal, tax_Total, costPrice, CostTotal, blockno, prodate, comment, 
				UsedType, goodsno,unit,dlyorder,HandZeroCost from bakdly
                                 where Vchcode= '+CAST(@nVchcode AS varchar(10))
                exec (@execsql)

                select @dTotalinMoney = 0
                select @dTempTotal = 0
                select @dTempQty = 0
                select @dTotalMoney = 0
                select @dTempCostTotal = 0
                select @dTemptaxTotal = 0
                OPEN CreateDly_cursor
                fetch next from CreateDly_cursor into @szATypeID, @szPTypeID,@dQty,@dPrice,@dTotal,@dDiscount,@dDiscountPrice, @dDiscountTotal,
                        @dTax,@dTaxPrice,@dTaxTotal,@dTax_Total,@dCostPrice, @dCostTotal,@szBlockno,@szProdate, @szMemo, @UsedType,@nGoodsNo,
			@unit,@odlyorder,@nHandInputZero
                while @@FETCH_STATUS=0
                begin
                        if @UsedType=1
                        begin
                                select @dQty = -@dQty
                                select @dCostTotal = -@dCostTotal
                                select @nCostmode=costmode, @deleted=deleted, @nSon=sonnum,@lsSerial = lsSerial from ptype where typeid=@szPTypeID
                                if @deleted=1 or @nSon>0 goto error132
				select @dTemp=@dcostprice
                                exec  @nRet = ModifyDbf 16,@nVchcode,@tDate,@nCostmode,@GOODs_ID,@szPTypeID,'',@szETypeID,@szKTypeID,
                                @nPeriod,@dQty,@dCostTotal,@szBlockno,@szProdate,@nGoodsNo,@dTemp out,@odlyorder,@lsSerial,@nHandInputZero
                                if @nRet<0 goto error
                                select @dCostPrice = @dTemp / @dQty
                                select @dCostTotal = @dTemp

                                insert into dlyother(vchcode,Date,VchType,ATypeID,PTypeID,BTypeID,ETypeID,KTypeID,KTypeID2,
                                    qty,Price,Total,costPrice,CostTotal,discount,discountPrice,discountTotal,
                                tax,taxPrice,taxTotal,tax_Total,Blockno,Prodate,comment,period,UsedType,costmode,unit,DeptID)
                                values(@nVchcode,@tDate,@nVchType,@GOODS_ID,@szPTypeID,@szBTypeID,@szETypeID,@szKTypeID,@szKTypeID2,
                                @dQty,@dPrice,@dCostTotal,@dCostPrice,@dCostTotal,@dDiscount,@dDiscountPrice,@dCostTotal,
                                @dTax,@dTaxPrice,@dTaxTotal,@dTax_Total,@szBlockno,@szProdate,@szMemo,@nPeriod,@UsedType,@nCostMode,@unit,@DeptID)
				--add by dcsong 2004.8.17 更新对应库存变动，一个单据号的且dlyorder为0的，当前变动的明细
                                select @nDlyOrder = @@identity
				update T_GoodsStocksGlide set dlyorder = @nDlyOrder where VchCode = @nVchcode and dlyorder = 0		
				update SN set VchLineNO = @nDlyorder,Tag = 3 where Vchcode = @nVchcode and VchLineNO = 0	
                                if @@error <> 0 goto error1

                                select @dTempQty = @dTempQty+@dQty
        select @dTempCostTotal = @dTempCostTotal+@dCostTotal
                        end
                        else
                        begin
                                select @nCostmode=costmode, @deleted=deleted, @nSon=sonnum,@lsSerial = lsSerial from ptype where typeid=@szPTypeID
                                if @deleted=1 or @nSon>0 goto error132
                                exec  @nRet = ModifyDbf 16,@nVchcode,@tDate,@nCostmode,@GOODs_ID,@szPTypeID,'',@szETypeID,@szKTypeID2,
                                @nPeriod,@dQty,@dTotal,@szBlockno,@szProdate,@nGoodsNo,@dTemp out,@odlyorder,@lsSerial
                                if @nRet<0 goto error
                                select @dCostPrice = @dTemp / @dQty
                                select @dCostTotal = @dTemp

                                insert into dlyother(vchcode,Date,VchType,ATypeID,PTypeID,BTypeID,ETypeID,KTypeID,KTypeID2,
                                    qty,Price,Total,costPrice,CostTotal,discount,discountPrice,discountTotal,
                                tax,taxPrice,taxTotal,tax_Total,Blockno,Prodate,comment,period,UsedType,costmode,unit,DeptID)
                                values(@nVchcode,@tDate,@nVchType,@GOODS_ID,@szPTypeID,@szBTypeID,@szETypeID,@szKTypeID2,@szKTypeID,
                                @dQty,@dPrice,@dCostTotal,@dCostPrice,@dCostTotal,@dDiscount,@dDiscountPrice,@dCostTotal,
                                @dTax,@dTaxPrice,@dTaxTotal,@dTax_Total,@szBlockno,@szProdate,@szMemo,@nPeriod,@UsedType,@nCostMode,@unit,@DeptID)
				--add by dcsong 2004.8.17 更新对应库存变动，一个单据号的且dlyorder为0的，当前变动的明细
                                select @nDlyOrder = @@identity
				update T_GoodsStocksGlide set dlyorder = @nDlyOrder where VchCode = @nVchcode and dlyorder = 0		
				update SN set VchLineNO = @nDlyorder,Tag = 2 where Vchcode = @nVchcode and VchLineNO = 0	

                                if @@error <> 0 goto error1

                                select @dTemptaxTotal = @dTemptaxTotal+@dQty
                                select @dTempTotal = @dTempTotal+@dCostTotal
                        end
                        fetch next from CreateDly_cursor into @szATypeID, @szPTypeID,@dQty,@dPrice,@dTotal,@dDiscount,@dDiscountPrice, @dDiscountTotal,
                        	@dTax,@dTaxPrice,@dTaxTotal,@dTax_Total,@dCostPrice, @dCostTotal,@szBlockno,@szProdate, @szMemo, @UsedType,@nGoodsNo,
				@unit,@odlyorder,@nHandInputZero
                end
--库存商品减少
		if @dTempCostTotal <> 0
		begin
	                insert into dlya(vchcode,Date,VchType,ATypeID,BTypeID,ETypeID,KTypeID,
	                                    Total,period,UsedType,DeptID)
	                        values(@nVchcode,@tDate,@nVchType,@GOODS_ID,@szBTypeID,@szETypeID,@szKTypeID,
	                                @dTempCostTotal,@nPeriod,'',@DeptID)
	                if @@rowcount <=0 goto error1
		end
--库存商品增加
		if @dTempTotal <> 0
		begin
	                insert into dlya(vchcode,Date,VchType,ATypeID,BTypeID,ETypeID,KTypeID,
	                                    Total,period,UsedType,DeptID)
	                        values(@nVchcode,@tDate,@nVchType,@GOODS_ID,@szBTypeID,@szETypeID,@szKTypeID,
	                                @dTempTotal,@nPeriod,'',@DeptID)
	                if @@rowcount <=0 goto error1
		end
--出库与入库成本差
                select @dTemp = @dTempTotal+@dTempCostTotal
                if @dTemp<>0
                begin
                        insert into dlya(vchcode,Date,VchType,ATypeID,BTypeID,ETypeID,KTypeID,

                                    Total,period,UsedType,DeptID)
                        values(@nVchcode,@tDate,@nVchType,@GOODS_PRODUCE_ID,@szBTypeID,@szETypeID,@szKTypeID,
                                @dTemp,@nPeriod,'',@DeptID)
                        if @@rowcount <=0 goto error1
                end

                update dlyndx set Total=Abs(@dTempTotal) where vchcode=@nVchcode
              if @@rowcount <=0 goto error1

                CLOSE CreateDly_cursor
                DEALLOCATE CreateDly_cursor
        end
------------------------------生产单处理结束--------------------------



------------------------------一般费用单、现金费用单、固定资产购置、待摊费用摊销
        if (@nVchType=36) or (@nVchType=35) or (@nVchType=84) or (@nVchType=10)
        begin
                select @execsql='declare CreateDly_cursor cursor for '
                                +' select ATypeID, PTypeID, qty, Price, Total, discount, discountPrice, discountTotal,
                                tax, taxPrice, taxTotal, tax_Total, costPrice, CostTotal, blockno, prodate, comment, UsedType from bakdly
                                 where Vchcode= '+CAST(@nVchcode AS varchar(10))
                exec (@execsql)

                select @dTotalinMoney = 0
                select @dTempTotal = 0
                OPEN CreateDly_cursor

                fetch next from CreateDly_cursor into @szATypeID, @szPTypeID,@dQty,@dPrice,@dTotal,@dDiscount,@dDiscountPrice, @dDiscountTotal,
                        @dTax,@dTaxPrice,@dTaxTotal,@dTax_Total,@dCostPrice, @dCostTotal,@szBlockno,@szProdate, @szMemo, @UsedType
                while @@FETCH_STATUS=0
                begin
			if not Exists( Select typeid from Atype where typeid=@szATypeID and Deleted=0 and SonNum=0) goto error137r

                        if @UsedType='1'
                        begin

                                select @dTempTotal = @dTempTotal+@dTotal
                        end
                        else
                        begin
                                select @dTotalinMoney = @dTotal
                                select @dTotal = -@dTotal
                        end
                        insert into dlya(vchcode,Date,VchType,ATypeID,BTypeID,ETypeID,KTypeID,Comment,

                                    Total,period,UsedType,DeptID)
                        values(@nVchcode,@tDate,@nVchType,@szATypeID,@szBTypeID,@szETypeID,@szKTypeID,@szMemo,
                                @dTotal,@nPeriod,@UsedType,@DeptID)

                        if @@rowcount <=0 goto error1
                        fetch next from CreateDly_cursor into @szATypeID, @szPTypeID,@dQty,@dPrice,@dTotal,@dDiscount,@dDiscountPrice, @dDiscountTotal,
                        @dTax,@dTaxPrice,@dTaxTotal,@dTax_Total,@dCostPrice, @dCostTotal,@szBlockno,@szProdate, @szMemo, @UsedType
                end
--处理科目
                if (@nVchType=10)  --待摊费用摊销
                begin
                        insert into dlya(vchcode,Date,VchType,ATypeID,BTypeID,ETypeID,KTypeID,

                                    Total,period,UsedType,DeptID)
                        values(@nVchcode,@tDate,@nVchType,@EXPENSE_HAPPEN_ID,@szBTypeID,@szETypeID,@szKTypeID,
                                -@dTempTotal,@nPeriod,'',@DeptID)
                end

                if (@dTotalInMoney <> @dTempTotal ) and (@nVchType<>10)
                begin
                        select @dTemp = @dTempTotal-@dTotalInMoney
                        insert into dlya(vchcode,Date,VchType,ATypeID,BTypeID,ETypeID,KTypeID,

                                    Total,period,UsedType,DeptID)
                        values(@nVchcode,@tDate,@nVchType,@AP_ID,@szBTypeID,@szETypeID,@szKTypeID,
                                @dTemp,@nPeriod,'',@DeptID)
                        if @@rowcount <=0 goto error1
                end

                update dlyndx set Total=Abs(@dTempTotal) where vchcode=@nVchcode
                if @@rowcount <=0 goto error1

                CLOSE CreateDly_cursor
                DEALLOCATE CreateDly_cursor
        end
------------------------------一般费用单处理结束--------------------------


--------其它收入单
        if (@nVchType=93)
        begin

                select @execsql='declare CreateDly_cursor cursor for '

                                +' select ATypeID, PTypeID, qty, Price, Total, discount, discountPrice, discountTotal,
                                tax, taxPrice, taxTotal, tax_Total, costPrice, CostTotal, blockno, prodate, comment, UsedType from bakdly
                                 where Vchcode= '+CAST(@nVchcode AS varchar(10))
                exec (@execsql)

                select @dTotalinMoney = 0
                select @dTempTotal = 0
                OPEN CreateDly_cursor

                fetch next from CreateDly_cursor into @szATypeID, @szPTypeID,@dQty,@dPrice,@dTotal,@dDiscount,@dDiscountPrice, @dDiscountTotal,
                        @dTax,@dTaxPrice,@dTaxTotal,@dTax_Total,@dCostPrice, @dCostTotal,@szBlockno,@szProdate, @szMemo, @UsedType
                while @@FETCH_STATUS=0
                begin
                        if @UsedType='1'
                        begin

                                select @dTempTotal = @dTempTotal+@dTotal
                        end
                        else
                        begin
                                select @dTotalinMoney = @dTotal
                        end
                        insert into dlya(vchcode,Date,VchType,ATypeID,BTypeID,ETypeID,KTypeID, Comment,

                                    Total,period,UsedType,DeptID)
                        values(@nVchcode,@tDate,@nVchType,@szATypeID,@szBTypeID,@szETypeID,@szKTypeID, @szMemo,
                                @dTotal,@nPeriod,@UsedType,@DeptID)
                        if @@rowcount <=0 goto error1
                        fetch next from CreateDly_cursor into @szATypeID, @szPTypeID,@dQty,@dPrice,@dTotal,@dDiscount,@dDiscountPrice, @dDiscountTotal,
                        @dTax,@dTaxPrice,@dTaxTotal,@dTax_Total,@dCostPrice, @dCostTotal,@szBlockno,@szProdate, @szMemo, @UsedType

                end

                if @dTotalInMoney <> @dTempTotal

                begin
                        select @dTemp = @dTempTotal-@dTotalInMoney
                        insert into dlya(vchcode,Date,VchType,ATypeID,BTypeID,ETypeID,KTypeID,

                                    Total,period,UsedType,DeptID)
                        values(@nVchcode,@tDate,@nVchType,@AR_ID,@szBTypeID,@szETypeID,@szKTypeID,
                                @dTemp,@nPeriod,'',@DeptID)
                        if @@rowcount <=0 goto error1
                end

                update dlyndx set Total=Abs(@dTempTotal) where vchcode=@nVchcode
                if @@rowcount <=0 goto error1

                CLOSE CreateDly_cursor
                DEALLOCATE CreateDly_cursor
        end
------------------------------其它收入单处理结束--------------------------



--------固定资产变卖 拆旧、待摊费用发生
        if (@nVchType=85)  or (@nVchType=78)or (@nVchType=5)
        begin

                select @execsql='declare CreateDly_cursor cursor for '

                                +' select ATypeID, PTypeID, qty, Price, Total, discount, discountPrice, discountTotal,
                                tax, taxPrice, taxTotal, tax_Total, costPrice, CostTotal, blockno, prodate, comment, UsedType from bakdly
                                 where Vchcode= '+CAST(@nVchcode AS varchar(10))
                exec (@execsql)

                select @dTotalinMoney = 0
                select @dTempTotal = 0
                OPEN CreateDly_cursor

                fetch next from CreateDly_cursor into @szATypeID, @szPTypeID,@dQty,@dPrice,@dTotal,@dDiscount,@dDiscountPrice, @dDiscountTotal,
                        @dTax,@dTaxPrice,@dTaxTotal,@dTax_Total,@dCostPrice, @dCostTotal,@szBlockno,@szProdate, @szMemo, @UsedType
                while @@FETCH_STATUS=0
                begin
			if not Exists( Select typeid from Atype where typeid=@szATypeID and Deleted=0 and SonNum=0) goto error137r

                        if @UsedType='1'
                        begin

                                select @dTempTotal = @dTempTotal+@dTotal
                                select @dTotal=-@dTotal
                        end
                        else
                        begin
                                select @dTotalinMoney = @dTotal
                        end
          insert into dlya(vchcode,Date,VchType,ATypeID,BTypeID,ETypeID,KTypeID, Comment,

                                    Total,period,UsedType,DeptID)
                        values(@nVchcode,@tDate,@nVchType,@szATypeID,@szBTypeID,@szETypeID,@szKTypeID, @szMemo,
                                @dTotal,@nPeriod,@UsedType,@DeptID)
                        if @@rowcount <=0 goto error1
                        fetch next from CreateDly_cursor into @szATypeID, @szPTypeID,@dQty,@dPrice,@dTotal,@dDiscount,@dDiscountPrice, @dDiscountTotal,
                        @dTax,@dTaxPrice,@dTaxTotal,@dTax_Total,@dCostPrice, @dCostTotal,@szBlockno,@szProdate, @szMemo, @UsedType

                end

                if (@nVchType=78)   --拆旧
                begin


                        insert into dlya(vchcode,Date,VchType,ATypeID,BTypeID,ETypeID,KTypeID,


                                    Total,period,UsedType,DeptID)
                        values(@nVchcode,@tDate,@nVchType,@FIXED_REDUCE_ID,@szBTypeID,@szETypeID,@szKTypeID,
                                @dTempTotal,@nPeriod,'',@DeptID)

                end

                if (@nVchType=5)   --待摊发生
                begin
                        insert into dlya(vchcode,Date,VchType,ATypeID,BTypeID,ETypeID,KTypeID,

                                    Total,period,UsedType,DeptID)
                        values(@nVchcode,@tDate,@nVchType,@EXPENSE_HAPPEN_ID,@szBTypeID,@szETypeID,@szKTypeID,
                                @dTempTotal,@nPeriod,'',@DeptID)
                end

--应收应付，只在固定变卖才有
                if (@dTotalInMoney <> @dTempTotal ) and (@nVchType=85)  --变卖
                begin
                        select @dTemp = @dTempTotal-@dTotalInMoney
                        insert into dlya(vchcode,Date,VchType,ATypeID,BTypeID,ETypeID,KTypeID,
                                    Total,period,UsedType,DeptID)
                        values(@nVchcode,@tDate,@nVchType,@AR_ID,@szBTypeID,@szETypeID,@szKTypeID,
                                @dTemp,@nPeriod,'',@DeptID)
                        if @@rowcount <=0 goto error1
                end

                update dlyndx set Total=Abs(@dTempTotal) where vchcode=@nVchcode
                if @@rowcount <=0 goto error1

                CLOSE CreateDly_cursor
                DEALLOCATE CreateDly_cursor
        end
------------------------------其它收入单处理结束--------------------------



------------------------------收款单
        if @nVchType=4
        begin
                select @execsql='declare CreateDly_cursor cursor for '
                                +' select ATypeID, PTypeID, qty, Price, Total, discount, discountPrice, discountTotal,
                                tax, taxPrice, taxTotal, tax_Total, costPrice, CostTotal, blockno, prodate, comment, UsedType from bakdly
                                 where Vchcode= '+CAST(@nVchcode AS varchar(10))
                exec (@execsql)


                select @dTempTotal = 0
                OPEN CreateDly_cursor

                fetch next from CreateDly_cursor into @szATypeID, @szPTypeID,@dQty,@dPrice,@dTotal,@dDiscount,@dDiscountPrice, @dDiscountTotal,
                        @dTax,@dTaxPrice,@dTaxTotal,@dTax_Total,@dCostPrice, @dCostTotal,@szBlockno,@szProdate, @szMemo, @UsedType
                while @@FETCH_STATUS=0
                begin
			if not Exists( Select typeid from Atype where typeid=@szATypeID and Deleted=0 and SonNum=0) goto error137r


			--add by dcsong 2003.08.15 收款单增加优惠
			if @szATypeID=@PREPERENTIAL_ID
			begin
				select @dPreferential = @dTotal
			end
			--add end
                        else if @UsedType='1'
                        begin
                                select @dTempTotal = @dTempTotal+@dTotal
                        end
                        insert into dlya(vchcode,Date,VchType,ATypeID,BTypeID,ETypeID,KTypeID, Comment,

                                    Total,period,UsedType,DeptID)
                        values(@nVchcode,@tDate,@nVchType,@szATypeID,@szBTypeID,@szETypeID,@szKTypeID, @szMemo,
                                @dTotal,@nPeriod,@UsedType,@DeptID)
                        if @@rowcount <=0 goto error1
                        fetch next from CreateDly_cursor into @szATypeID, @szPTypeID,@dQty,@dPrice,@dTotal,@dDiscount,@dDiscountPrice, @dDiscountTotal,
                        @dTax,@dTaxPrice,@dTaxTotal,@dTax_Total,@dCostPrice, @dCostTotal,@szBlockno,@szProdate, @szMemo, @UsedType
                end
--应收款减少
		select @dTemp = @dTempTotal + @dPreferential --add by dcsong 2003.08.15 收款单增加优惠
                insert into dlya(vchcode,Date,VchType,ATypeID,BTypeID,ETypeID,KTypeID,

                                    Total,period,UsedType,DeptID)
                        values(@nVchcode,@tDate,@nVchType,@AR_ID,@szBTypeID,@szETypeID,@szKTypeID,
                                -@dTemp,@nPeriod,'',@DeptID)
                        if @@rowcount <=0 goto error1

                update dlyndx set Total=Abs(@dTempTotal) where vchcode=@nVchcode
                if @@rowcount <=0 goto error1

                CLOSE CreateDly_cursor
                DEALLOCATE CreateDly_cursor
        end
------------------------------收款单处理结束--------------------------

------------------------------付款单
        if @nVchType=66
        begin
                select @execsql='declare CreateDly_cursor cursor for '
                                +' select ATypeID, PTypeID, qty, Price, Total, discount, discountPrice, discountTotal,
                                tax, taxPrice, taxTotal, tax_Total, costPrice, CostTotal, blockno, prodate, comment, UsedType from bakdly
                                 where Vchcode= '+CAST(@nVchcode AS varchar(10))
                exec (@execsql)



                select @dTempTotal = 0
                OPEN CreateDly_cursor

                fetch next from CreateDly_cursor into @szATypeID, @szPTypeID,@dQty,@dPrice,@dTotal,@dDiscount,@dDiscountPrice, @dDiscountTotal,
                        @dTax,@dTaxPrice,@dTaxTotal,@dTax_Total,@dCostPrice, @dCostTotal,@szBlockno,@szProdate, @szMemo, @UsedType

                while @@FETCH_STATUS=0
                begin
			if not Exists( Select typeid from Atype where typeid=@szATypeID and Deleted=0 and SonNum=0) goto error137r

			--add by dcsong 2003.08.15 收款单增加优惠
			if @szATypeID=@PREPERENTIAL_ID
			begin
				select @dPreferential = @dTotal
			end
			--add end
                        else if @UsedType='1'
                        begin
                                select @dTempTotal = @dTempTotal+@dTotal
                        end
                        insert into dlya(vchcode,Date,VchType,ATypeID,BTypeID,ETypeID,KTypeID, Comment,

                                    Total,period,UsedType,DeptID)
                        values(@nVchcode,@tDate,@nVchType,@szATypeID,@szBTypeID,@szETypeID,@szKTypeID, @szMemo,
                                -@dTotal,@nPeriod,@UsedType,@DeptID)
                        if @@rowcount <=0 goto error1
                        fetch next from CreateDly_cursor into @szATypeID, @szPTypeID,@dQty,@dPrice,@dTotal,@dDiscount,@dDiscountPrice, @dDiscountTotal,
                        @dTax,@dTaxPrice,@dTaxTotal,@dTax_Total,@dCostPrice, @dCostTotal,@szBlockno,@szProdate, @szMemo, @UsedType
                end
--应付款减少
		select @dTemp = @dTempTotal + @dPreferential --add by dcsong 2003.08.15 收款单增加优惠
                insert into dlya(vchcode,Date,VchType,ATypeID,BTypeID,ETypeID,KTypeID,

                                    Total,period,UsedType,DeptID)
                        values(@nVchcode,@tDate,@nVchType,@AP_ID,@szBTypeID,@szETypeID,@szKTypeID,
                                -@dTemp,@nPeriod,'',@DeptID)
                        if @@rowcount <=0 goto error1



                update dlyndx set Total=Abs(@dTempTotal) where vchcode=@nVchcode
                if @@rowcount <=0 goto error1

                CLOSE CreateDly_cursor

                DEALLOCATE CreateDly_cursor
        end
------------------------------付款单处理结束--------------------------



------------------------------提现、转帐单
        if @nVchType=77
        begin

                select @execsql='declare CreateDly_cursor cursor for '
                                +' select ATypeID, PTypeID, qty, Price, Total, discount, discountPrice, discountTotal,
                                tax, taxPrice, taxTotal, tax_Total, costPrice, CostTotal, blockno, prodate, comment, UsedType from bakdly
                                 where Vchcode= '+CAST(@nVchcode AS varchar(10))
                exec (@execsql)


                select @dTempTotal = 0
                OPEN CreateDly_cursor

                fetch next from CreateDly_cursor into @szATypeID, @szPTypeID,@dQty,@dPrice,@dTotal,@dDiscount,@dDiscountPrice, @dDiscountTotal,

                        @dTax,@dTaxPrice,@dTaxTotal,@dTax_Total,@dCostPrice, @dCostTotal,@szBlockno,@szProdate, @szMemo, @UsedType
                while @@FETCH_STATUS=0
                begin
			if not Exists( Select typeid from Atype where typeid=@szATypeID and Deleted=0 and SonNum=0) goto error137r

                        if @UsedType='1'
                        begin
                                select @dTempTotal = @dTempTotal+@dTotal
                        end
                        else
                        begin
                                select @dTempqty = @dTotal
                                select @dTotal = -@dTotal
                        end
                        insert into dlya(vchcode,Date,VchType,ATypeID,BTypeID,ETypeID,KTypeID,  Comment,

                                    Total,period,UsedType,DeptID)
                        values(@nVchcode,@tDate,@nVchType,@szATypeID,@szBTypeID,@szETypeID,@szKTypeID, @szMemo,
                                @dTotal,@nPeriod,@UsedType,@DeptID)
                        if @@rowcount <=0 goto error1
                        fetch next from CreateDly_cursor into @szATypeID, @szPTypeID,@dQty,@dPrice,@dTotal,@dDiscount,@dDiscountPrice, @dDiscountTotal,

                        @dTax,@dTaxPrice,@dTaxTotal,@dTax_Total,@dCostPrice, @dCostTotal,@szBlockno,@szProdate, @szMemo, @UsedType
                end

                if @dTempTotal<>@dTempqty
                begin
                        select @nRet = -8
                        goto error
                end

                update dlyndx set Total=Abs(@dTempTotal) where vchcode=@nVchcode
                if @@rowcount <=0 goto error1

                CLOSE CreateDly_cursor

                DEALLOCATE CreateDly_cursor
        end
------------------------------提现、转帐处理结束--------------------------


------------------------------应收款减少、增加单
        if @nVchType=115 or @nVchType=116
        begin
                select @execsql='declare CreateDly_cursor cursor for '
                                +' select ATypeID, PTypeID, qty, Price, Total, discount, discountPrice, discountTotal,
                                tax, taxPrice, taxTotal, tax_Total, costPrice, CostTotal, blockno, prodate, comment, UsedType from bakdly
                                 where Vchcode= '+CAST(@nVchcode AS varchar(10))
                exec (@execsql)


                select @dTempTotal = 0
                OPEN CreateDly_cursor

                fetch next from CreateDly_cursor into @szATypeID, @szPTypeID,@dQty,@dPrice,@dTotal,@dDiscount,@dDiscountPrice, @dDiscountTotal,
                        @dTax,@dTaxPrice,@dTaxTotal,@dTax_Total,@dCostPrice, @dCostTotal,@szBlockno,@szProdate, @szMemo, @UsedType
                while @@FETCH_STATUS=0
                begin
			if not Exists( Select typeid from Atype where typeid=@szATypeID and Deleted=0 and SonNum=0) goto error137r

                        if @UsedType='1'
                        begin
                                select @dTempTotal = @dTempTotal+@dTotal
                        end
                        insert into dlya(vchcode,Date,VchType,ATypeID,BTypeID,ETypeID,KTypeID, Comment,

                                    Total,period,UsedType,DeptID)
                        values(@nVchcode,@tDate,@nVchType,@szATypeID,@szBTypeID,@szETypeID,@szKTypeID, @szMemo,
                                @dTotal,@nPeriod,@UsedType,@DeptID)
                        if @@rowcount <=0 goto error1
                        fetch next from CreateDly_cursor into @szATypeID, @szPTypeID,@dQty,@dPrice,@dTotal,@dDiscount,@dDiscountPrice, @dDiscountTotal,
                        @dTax,@dTaxPrice,@dTaxTotal,@dTax_Total,@dCostPrice, @dCostTotal,@szBlockno,@szProdate, @szMemo, @UsedType
                end

--应收款变化
                if @nVchType=115 select @dTempTotal = -@dTempTotal
                insert into dlya(vchcode,Date,VchType,ATypeID,BTypeID,ETypeID,KTypeID,

                                    Total,period,UsedType,DeptID)
                        values(@nVchcode,@tDate,@nVchType,@AR_ID,@szBTypeID,@szETypeID,@szKTypeID,
                                @dTempTotal,@nPeriod,'',@DeptID)

                if @@rowcount <=0 goto error1

                update dlyndx set Total=Abs(@dTempTotal) where vchcode=@nVchcode
                if @@rowcount <=0 goto error1

                CLOSE CreateDly_cursor

                DEALLOCATE CreateDly_cursor
        end
------------------------------应收款减少、增加处理结束--------------------------



------------------------------应付款减少、增加单
        if @nVchType=128 or @nVchType=129
        begin
                select @execsql='declare CreateDly_cursor cursor for '
                                +' select ATypeID, PTypeID, qty, Price, Total, discount, discountPrice, discountTotal,
                                tax, taxPrice, taxTotal, tax_Total, costPrice, CostTotal, blockno, prodate, comment, UsedType from bakdly
                                 where Vchcode= '+CAST(@nVchcode AS varchar(10))
                exec (@execsql)


                select @dTempTotal = 0

                OPEN CreateDly_cursor

                fetch next from CreateDly_cursor into @szATypeID, @szPTypeID,@dQty,@dPrice,@dTotal,@dDiscount,@dDiscountPrice, @dDiscountTotal,
                        @dTax,@dTaxPrice,@dTaxTotal,@dTax_Total,@dCostPrice, @dCostTotal,@szBlockno,@szProdate, @szMemo, @UsedType
                while @@FETCH_STATUS=0
                begin
			if not Exists( Select typeid from Atype where typeid=@szATypeID and Deleted=0 and SonNum=0) goto error137r

                        if @UsedType='1'
                        begin
                                select @dTempTotal = @dTempTotal+@dTotal

                        end
                        insert into dlya(vchcode,Date,VchType,ATypeID,BTypeID,ETypeID,KTypeID, Comment,

                                    Total,period,UsedType,DeptID)
                        values(@nVchcode,@tDate,@nVchType,@szATypeID,@szBTypeID,@szETypeID,@szKTypeID, @szMemo,
                                @dTotal,@nPeriod,@UsedType,@DeptID)
                        if @@rowcount <=0 goto error1
                        fetch next from CreateDly_cursor into @szATypeID, @szPTypeID,@dQty,@dPrice,@dTotal,@dDiscount,@dDiscountPrice, @dDiscountTotal,
                        @dTax,@dTaxPrice,@dTaxTotal,@dTax_Total,@dCostPrice, @dCostTotal,@szBlockno,@szProdate, @szMemo, @UsedType
                end

--应付款变化
                if @nVchType=129 select @dTempTotal = -@dTempTotal
                insert into dlya(vchcode,Date,VchType,ATypeID,BTypeID,ETypeID,KTypeID,

                                    Total,period,UsedType,DeptID)
                        values(@nVchcode,@tDate,@nVchType,@AP_ID,@szBTypeID,@szETypeID,@szKTypeID,
                                @dTempTotal,@nPeriod,'',@DeptID)
                if @@rowcount <=0 goto error1

                update dlyndx set Total=Abs(@dTempTotal) where vchcode=@nVchcode
                if @@rowcount <=0 goto error1

                CLOSE CreateDly_cursor

                DEALLOCATE CreateDly_cursor
        end
------------------------------应付款减少、增加处理结束--------------------------


------------------------------资金减少、增加单
        if @nVchType=130 or @nVchType=131
        begin
                select @execsql='declare CreateDly_cursor cursor for '
                                +' select ATypeID, PTypeID, qty, Price, Total, discount, discountPrice, discountTotal,
                                tax, taxPrice, taxTotal, tax_Total, costPrice, CostTotal, blockno, prodate, comment, UsedType from bakdly
                                 where Vchcode= '+CAST(@nVchcode AS varchar(10))
                exec (@execsql)
                select @dTempTotal = 0
                OPEN CreateDly_cursor

                fetch next from CreateDly_cursor into @szATypeID, @szPTypeID,@dQty,@dPrice,@dTotal,@dDiscount,@dDiscountPrice, @dDiscountTotal,
                        @dTax,@dTaxPrice,@dTaxTotal,@dTax_Total,@dCostPrice, @dCostTotal,@szBlockno,@szProdate, @szMemo, @UsedType
                while @@FETCH_STATUS=0
                begin
			if not Exists( Select typeid from Atype where typeid=@szATypeID and Deleted=0 and SonNum=0) goto error137r

                        if @UsedType='1'
                        begin
                                select @dTempTotal = @dTempTotal+@dTotal
                        end
                        if @nVchType=130 if @UsedType='2' select @dTotal = -Abs(@dTotal)
                        insert into dlya(vchcode,Date,VchType,ATypeID,BTypeID,ETypeID,KTypeID, Comment,

                                    Total,period,UsedType,DeptID)
                        values(@nVchcode,@tDate,@nVchType,@szATypeID,@szBTypeID,@szETypeID,@szKTypeID, @szMemo,
                                @dTotal,@nPeriod,@UsedType,@DeptID)
                        if @@rowcount <=0 goto error1
                        fetch next from CreateDly_cursor into @szATypeID, @szPTypeID,@dQty,@dPrice,@dTotal,@dDiscount,@dDiscountPrice, @dDiscountTotal,
                        @dTax,@dTaxPrice,@dTaxTotal,@dTax_Total,@dCostPrice, @dCostTotal,@szBlockno,@szProdate, @szMemo, @UsedType
                end

                update dlyndx set Total=Abs(@dTempTotal) where vchcode=@nVchcode
                if @@rowcount <=0 goto error1

                CLOSE CreateDly_cursor

                DEALLOCATE CreateDly_cursor
        end
------------------------------资金减少、增加处理结束--------------------------



---同价调拨单开始

        if @nVchType=17
        begin
                select @execsql='declare CreateDly_cursor cursor for '
                                +' select ATypeID, PTypeID, qty, Price, Total, discount, discountPrice, discountTotal,
                                tax, taxPrice, taxTotal, tax_Total, costPrice, CostTotal, blockno, prodate, comment, 
				UsedType, goodsno,unit,RetailPrice,dlyorder,HandZeroCost from bakdly
                                 where Vchcode= '+CAST(@nVchcode AS varchar(10))
                exec (@execsql)

                select @dTempQty = 0
                select @dTempCostTotal = 0
                OPEN CreateDly_cursor
                fetch next from CreateDly_cursor into @szATypeID, @szPTypeID,@dQty,@dPrice,@dTotal,@dDiscount,@dDiscountPrice, @dDiscountTotal,
                        @dTax,@dTaxPrice,@dTaxTotal,@dTax_Total,@dCostPrice, @dCostTotal,@szBlockno,@szProdate, @szMemo, @UsedType,@nGoodsNo,
			@unit,@RetailPrice,@odlyorder,@nHandInputZero
                while @@FETCH_STATUS=0
                begin
                                select @nCostmode=costmode, @deleted=deleted, @nSon=sonnum,@lsSerial = lsSerial from ptype where typeid=@szPTypeID
                                if @deleted=1 or @nSon>0 goto error132
                                select @dQty = -@dQty
                                select @dCostTotal=-@dCostTotal
				select @dTemp=@dcostprice
                                exec  @nRet = ModifyDbf 17,@nVchcode,@tDate,@nCostmode,@GOODs_ID,@szPTypeID,@szBTypeID,@szETypeID,@szKTypeID2,
                                @nPeriod,@dQty,@dCostTotal,@szBlockno,@szProdate,@nGoodsNo,@dTemp out,@odlyorder,@lsSerial,@nHandInputZero
                                if @nRet<0 goto error
                                select @dCostPrice = @dTemp / @dQty
                                select @dCostTotal = @dTemp


                        insert into dlyother(vchcode,Date,VchType,ATypeID,PTypeID,BTypeID,ETypeID,KTypeID,KTypeID2,
                                    qty,Price,Total,costPrice,CostTotal,discount,discountPrice,discountTotal,
                                tax,taxPrice,taxTotal,tax_Total,Blockno,Prodate,comment,period,UsedType,costmode,unit,DeptID,RetailPrice)
                        values(@nVchcode,@tDate,@nVchType,@GOODS_ID,@szPTypeID,@szBTypeID,@szETypeID,@szKTypeID2,@szKTypeID,
                                @dQty,@dCostPrice,@dCostTotal,@dCostPrice,@dCostTotal,@dDiscount,@dDiscountPrice,@dCostTotal,
                                @dTax,@dTaxPrice,@dTaxTotal,@dTax_Total,@szBlockno,@szProdate,@szMemo,@nPeriod,@UsedType,@nCostMode,@unit,@DeptID,@RetailPrice)
				--add by dcsong 2004.8.17 更新对应库存变动，一个单据号的且dlyorder为0的，当前变动的明细
                                select @nDlyOrder = @@identity
				update T_GoodsStocksGlide set dlyorder = @nDlyOrder where VchCode = @nVchcode and dlyorder = 0		
				update SN set VchLineNO = @nDlyorder,Tag = 3 where Vchcode = @nVchcode and VchLineNO = 0	
                        	if @@error <> 0 goto error1

                                select @dTempQty = @dTempQty+@dQty
                                select @dTempCostTotal = @dTempCostTotal+@dCostTotal

			-----------modi by dcsong 2004.10.12 修改同价调拨单调批次问题-----------------
			if @nCostmode in (1,2) --如果是先进先出或后进先出,用此方法
			begin
				select @nTimeDB = 0
                                select @dQty = -@dQty
                                select @dCostTotal = -@dCostTotal
				declare DBCreatedly_cursor cursor for 
				select qty,JobNumber,OutFactoryDate,Price,Total from T_GoodsStocksGlide
				where VchCode = @nVchcode and dlyorder = @nDlyOrder 
                		OPEN DBCreatedly_cursor
                		fetch next from DBCreatedly_cursor into @dqtyDB,@szJobNumberDB,@szOutFactoryDateDB,@dPriceDB,@dTotalDB
                		while @@FETCH_STATUS=0  --读出变动表中的数据过帐
				begin
					select @dqtyDB = -1*@dqtyDB
					select @dTotalDB = -1*@dTotalDB
					if @nTimeDB = 0
					begin
		                                exec  @nRet = ModifyDbf 17,@nVchcode,@tDate,@nCostmode,@GOODs_ID,@szPTypeID,@szBTypeID,@szETypeID,@szKTypeID,
		                                @nPeriod,@dqtyDB,@dTotalDB,@szJobNumberDB,@szOutFactoryDateDB,0,@dTemp out,@odlyorder,@lsSerial,1
		                                if @nRet<0 goto error2
						select @nTimeDB = 1
					end
					else
					begin
		                                exec  @nRet = ModifyDbf 17,@nVchcode,@tDate,@nCostmode,@GOODs_ID,@szPTypeID,@szBTypeID,@szETypeID,@szKTypeID,
		                                @nPeriod,@dqtyDB,@dTotalDB,@szJobNumberDB,@szOutFactoryDateDB,0,@dTemp out,0,0,1
		                                if @nRet<0 goto error2
					end
                		fetch next from DBCreatedly_cursor into @dqtyDB,@szJobNumberDB,@szOutFactoryDateDB,@dPriceDB,@dTotalDB
				end	
				CLOSE DBCreatedly_cursor
        			DEALLOCATE DBCreatedly_cursor			
			end
			else
			begin
                                select @dQty = -@dQty
                                select @dCostTotal = -@dCostTotal
                                exec  @nRet = ModifyDbf 17,@nVchcode,@tDate,@nCostmode,@GOODs_ID,@szPTypeID,@szBTypeID,@szETypeID,@szKTypeID,
                                @nPeriod,@dQty,@dCostTotal,@szBlockno,@szProdate,0,@dTemp out,@odlyorder,@lsSerial,1
                                if @nRet<0 goto error
			end
			-----------modi by dcsong 2004.10.12 修改同价调拨单调批次问题-----------------

                        insert into dlyother(vchcode,Date,VchType,ATypeID,PTypeID,BTypeID,ETypeID,KTypeID,KTypeID2,
                                    qty,Price,Total,costPrice,CostTotal,discount,discountPrice,discountTotal,
                                tax,taxPrice,taxTotal,tax_Total,Blockno,Prodate,comment,period,UsedType,costmode,unit,DeptID)
                        values(@nVchcode,@tDate,@nVchType,@GOODS_ID,@szPTypeID,@szBTypeID,@szETypeID,@szKTypeID,@szKTypeID,
             @dQty,@dCostPrice,@dCostTotal,@dCostPrice,@dCostTotal,@dDiscount,@dDiscountPrice,@dCostTotal,
                                @dTax,@dTaxPrice,@dTaxTotal,@dTax_Total,@szBlockno,@szProdate,@szMemo,@nPeriod,'',@nCostMode,@unit,@DeptID)
				--add by dcsong 2004.8.17 更新对应库存变动，一个单据号的且dlyorder为0的，当前变动的明细
                                select @nDlyOrder = @@identity
				update T_GoodsStocksGlide set dlyorder = @nDlyOrder where VchCode = @nVchcode and dlyorder = 0		
				update SN set VchLineNO = @nDlyorder,Tag = 2 where Vchcode = @nVchcode and VchLineNO = 0	
                        	if @@error <> 0 goto error1


                        fetch next from CreateDly_cursor into @szATypeID, @szPTypeID,@dQty,@dPrice,@dTotal,@dDiscount,@dDiscountPrice, @dDiscountTotal,
                        	@dTax,@dTaxPrice,@dTaxTotal,@dTax_Total,@dCostPrice, @dCostTotal,@szBlockno,@szProdate, @szMemo, @UsedType,@nGoodsNo,@unit,
				@RetailPrice,@odlyorder,@nHandInputZero
                end
--库存商品减少
		if @dTempCostTotal <> 0
		begin
	                insert into dlya(vchcode,Date,VchType,ATypeID,BTypeID,ETypeID,KTypeID,
	                                    Total,period,UsedType,DeptID)
	                        values(@nVchcode,@tDate,@nVchType,@GOODS_ID,@szBTypeID,@szETypeID,@szKTypeID,
	                                @dTempCostTotal,@nPeriod,'',@DeptID)
	                if @@rowcount <=0 goto error1
		end
--库存商品增加
		if @dTempCostTotal <> 0
		begin
	                insert into dlya(vchcode,Date,VchType,ATypeID,BTypeID,ETypeID,KTypeID,
		                                    Total,period,UsedType,DeptID)
	                        values(@nVchcode,@tDate,@nVchType,@GOODS_ID,@szBTypeID,@szETypeID,@szKTypeID,
	                                -@dTempCostTotal,@nPeriod,'',@DeptID)
	                if @@rowcount <=0 goto error1
		end
                CLOSE CreateDly_cursor
                DEALLOCATE CreateDly_cursor
        end
------------------------------同价调拨单处理结束--------------------------

---报损、报溢、赠送、获赠单开始

        if @nVchType=9 or @nVchType=14 or @nVchType=126 or @nVchType=139
        begin
                select @execsql='declare CreateDly_cursor cursor for '
                                +' select ATypeID, PTypeID, qty, Price, Total, discount, discountPrice, discountTotal,
                                tax, taxPrice, taxTotal, tax_Total, costPrice, CostTotal, blockno, prodate, comment, 
				UsedType, goodsno,unit,RetailPrice,dlyorder,HandZeroCost from bakdly
                                 where Vchcode= '+CAST(@nVchcode AS varchar(10))
                exec (@execsql)

                select @dTempQty = 0
                select @dTempCostTotal = 0
                OPEN CreateDly_cursor
                fetch next from CreateDly_cursor into @szATypeID, @szPTypeID,@dQty,@dPrice,@dTotal,@dDiscount,@dDiscountPrice, @dDiscountTotal,
                        @dTax,@dTaxPrice,@dTaxTotal,@dTax_Total,@dCostPrice, @dCostTotal,@szBlockno,@szProdate, @szMemo, @UsedType,@nGoodsNo,
			@unit,@RetailPrice,@odlyorder,@nHandInputZero
                while @@FETCH_STATUS=0
                begin
                        select @nCostmode=costmode, @deleted=deleted, @nSon=sonnum,@lsSerial = lsSerial from ptype where typeid=@szPTypeID
                        if @deleted=1 or @nSon>0 goto error132
                        select @dTempTotal = 1
                        if @nVchType=9  or @nVchType=139  select @dTempTotal = -1
                        select @dQty = @dTempTotal*@dQty
                        select @dCostTotal = @dTempTotal*@dCostTotal
			if @nVchType=14 select @nHandInputZero = 0 --报溢不管,如果是报损和赠送,则看是否录入强制0出库 
			if @nVchType=126   select @nHandInputZero = [stats]  FROM  syscon  WHERE  [order] = 72  --获赠单采用0成本入库
			select @dTemp=@dcostprice
                        exec  @nRet = ModifyDbf @nVchType,@nVchcode,@tDate,@nCostmode,@GOODs_ID,@szPTypeID,@szBTypeID,@szETypeID,@szKTypeID,
                                @nPeriod,@dQty,@dCostTotal,@szBlockno,@szProdate,@nGoodsNo,@dTemp out,@odlyorder,@lsSerial,@nHandInputZero
                        if @nRet<0 goto error
                        select @dCostPrice = @dTemp / @dQty
                        select @dCostTotal = @dTemp

                        insert into dlyother(vchcode,Date,VchType,ATypeID,PTypeID,BTypeID,ETypeID,KTypeID,KTypeID2,
                                    qty,Price,Total,costPrice,CostTotal,discount,discountPrice,discountTotal,
                                tax,taxPrice,taxTotal,tax_Total,Blockno,Prodate,comment,period,UsedType,costmode,unit,DeptID,RetailPrice)
                        values(@nVchcode,@tDate,@nVchType,@GOODS_ID,@szPTypeID,@szBTypeID,@szETypeID,@szKTypeID,@szKTypeID2,
                                @dQty,@dCostPrice,@dCostTotal,@dCostPrice,@dCostTotal,@dDiscount,@dDiscountPrice,@dCostTotal,
                                @dTax,0,@dTaxTotal,0,@szBlockno,@szProdate,@szMemo,@nPeriod,@UsedType,@nCostMode,@unit,@DeptID,@RetailPrice)
				--add by dcsong 2004.8.17 更新对应库存变动，一个单据号的且dlyorder为0的，当前变动的明细
                                select @nDlyOrder = @@identity
				update T_GoodsStocksGlide set dlyorder = @nDlyOrder where VchCode = @nVchcode and dlyorder = 0		
			if @nVchType=9  or @nVchType=139
				update SN set VchLineNO = @nDlyorder,Tag = 3 where Vchcode = @nVchcode and VchLineNO = 0	
			else
				update SN set VchLineNO = @nDlyorder,Tag = 2 where Vchcode = @nVchcode and VchLineNO = 0	
                        	if @@error <> 0 goto error1

                        select @dTempQty = @dTempQty+@dQty
                        select @dTempCostTotal = @dTempCostTotal+@dCostTotal

                        fetch next from CreateDly_cursor into @szATypeID, @szPTypeID,@dQty,@dPrice,@dTotal,@dDiscount,@dDiscountPrice, @dDiscountTotal,
                        	@dTax,@dTaxPrice,@dTaxTotal,@dTax_Total,@dCostPrice, @dCostTotal,@szBlockno,@szProdate, @szMemo, @UsedType,@nGoodsNo,
				@unit,@RetailPrice,@odlyorder,@nHandInputZero
                end
--库存商品变化
		if @dTempCostTotal <> 0
		begin
	                insert into dlya(vchcode,Date,VchType,ATypeID,BTypeID,ETypeID,KTypeID,
	                                    Total,period,UsedType,DeptID)
	                        values(@nVchcode,@tDate,@nVchType,@GOODS_ID,@szBTypeID,@szETypeID,@szKTypeID,
	                                @dTempCostTotal,@nPeriod,'',@DeptID)
	                if @@rowcount <=0 goto error1
		end
--科目变化
		if (@dTempCostTotal <> 0) 
		begin 
	                if (@nVchType=9)
	                        insert into dlya(vchcode,Date,VchType,ATypeID,BTypeID,ETypeID,KTypeID,
	                                    Total,period,UsedType,DeptID)
	                        values(@nVchcode,@tDate,@nVchType,@GOODS_LOSS_ID,@szBTypeID,@szETypeID,@szKTypeID,
	                                Abs(@dTempCostTotal),@nPeriod,'',@DeptID)
	                else if (@nVchType=14) 
	                        insert into dlya(vchcode,Date,VchType,ATypeID,BTypeID,ETypeID,KTypeID,
	                                    Total,period,UsedType,DeptID)
	                        values(@nVchcode,@tDate,@nVchType,@GOODS_GET_ID,@szBTypeID,@szETypeID,@szKTypeID,
	                                @dTempCostTotal,@nPeriod,'',@DeptID)
	
	                else if @nVchType=126
	                        insert into dlya(vchcode,Date,VchType,ATypeID,BTypeID,ETypeID,KTypeID,
	                                    Total,period,UsedType,DeptID)
	                        values(@nVchcode,@tDate,@nVchType,@GOODS_GIVEME_ID,@szBTypeID,@szETypeID,@szKTypeID,
	                                @dTempCostTotal,@nPeriod,'',@DeptID)
	                else if @nVchType=139
	                        insert into dlya(vchcode,Date,VchType,ATypeID,BTypeID,ETypeID,KTypeID,
	                                    Total,period,UsedType,DeptID)
	                        values(@nVchcode,@tDate,@nVchType,@GOODS_GIVE_ID,@szBTypeID,@szETypeID,@szKTypeID,
	                                -@dTempCostTotal,@nPeriod,'',@DeptID)
	                if @@rowcount <=0 goto error1
		end

                CLOSE CreateDly_cursor
                DEALLOCATE CreateDly_cursor
        end

------------------------------报损、报溢、赠送、获赠单处理结束--------------------------



--借出
        if @nVchType=87
        begin
                select @execsql='declare CreateDly_cursor cursor for '
                                +' select ATypeID, PTypeID, qty, Price, Total, discount, discountPrice, discountTotal,
                                tax, taxPrice, taxTotal, tax_Total, costPrice, CostTotal, blockno, prodate, comment, 
				UsedType, goodsno,unit, RetailPrice,dlyorder,HandZeroCost from bakdly
                                 where Vchcode= '+CAST(@nVchcode AS varchar(10))
                exec (@execsql)

                select @dTempQty = 0
                select @dTempCostTotal = 0
                OPEN CreateDly_cursor
                fetch next from CreateDly_cursor into @szATypeID, @szPTypeID,@dQty,@dPrice,@dTotal,@dDiscount,@dDiscountPrice, @dDiscountTotal,
                        @dTax,@dTaxPrice,@dTaxTotal,@dTax_Total,@dCostPrice, @dCostTotal,@szBlockno,@szProdate, @szMemo, @UsedType,@nGoodsNo,
			@unit, @RetailPrice,@odlyorder,@nHandInputZero
                while @@FETCH_STATUS=0
                begin
                        select @nCostmode=costmode, @deleted=deleted, @nSon=sonnum,@lsSerial = lsSerial from ptype where typeid=@szPTypeID
                        if @deleted=1 or @nSon>0 goto error132
                        select @dQty=-@dQty
                        select @dCostTotal = -@dCostTotal
			select @dTemp=@dcostprice
                        exec  @nRet = ModifyDbf @nVchType,@nVchcode,@tDate,@nCostmode,@GOODs_ID,@szPTypeID,@szBTypeID,@szETypeID,@szKTypeID,
                                @nPeriod,@dQty,@dCostTotal,@szBlockno,@szProdate,@nGoodsNo,@dTemp out,@odlyorder,@lsSerial,@nHandInputZero
                        if @nRet<0 goto error
                        select @dCostPrice = @dTemp / @dQty
                        select @dCostTotal = @dTemp

                        insert into dlyother(vchcode,Date,VchType,ATypeID,PTypeID,BTypeID,ETypeID,KTypeID,KTypeID2,
                                    qty,Price,Total,costPrice,CostTotal,discount,discountPrice,discountTotal,
                                tax,taxPrice,taxTotal,tax_Total,Blockno,Prodate,comment,period,UsedType,costmode,unit,DeptID, RetailPrice)
                        values(@nVchcode,@tDate,@nVchType,@GOODS_ID,@szPTypeID,@szBTypeID,@szETypeID,@szKTypeID,@szKTypeID2,
                                @dQty,@dCostPrice,@dCostTotal,@dCostPrice,@dCostTotal,@dDiscount,@dDiscountPrice,@dDiscountTotal,
                                @dTax,@dTaxPrice,@dTaxTotal,@dTax_Total,@szBlockno,@szProdate,@szMemo,@nPeriod,@UsedType,@nCostMode,@unit,@DeptID, @RetailPrice)
				--add by dcsong 2004.8.17 更新对应库存变动，一个单据号的且dlyorder为0的，当前变动的明细
                                select @nDlyOrder = @@identity
				update T_GoodsStocksGlide set dlyorder = @nDlyOrder where VchCode = @nVchcode and dlyorder = 0		
				update SN set VchLineNO = @nDlyorder,Tag = 3 where Vchcode = @nVchcode and VchLineNO = 0	
                        	if @@error <> 0 goto error1
                        select @dTempQty = @dTempQty+@dQty
                        select @dTempCostTotal = @dTempCostTotal+@dCostTotal

--修改借出库
                        select @dQty=-@dQty
                        select @dCostTotal = -@dCostTotal

                        exec  @nRet = ModifyDbfLend @nVchType,@nCostmode,@GOODs_ID,@szPTypeID,@szBTypeID,@szETypeID,@LENDOUT_STOCK,
                                @nPeriod,@dQty,@dCostTotal,@szBlockno,@szProdate,@nGoodsNo,@dTemp out
                        if @nRet<0 goto error
                        insert into dlyother(vchcode,Date,VchType,ATypeID,PTypeID,BTypeID,ETypeID,KTypeID,KTypeID2,
                  qty,Price,Total,costPrice,CostTotal,discount,discountPrice,discountTotal,
                                tax,taxPrice,taxTotal,tax_Total,Blockno,Prodate,comment,period,UsedType,costmode,unit,PDETAIL,DeptID, RetailPrice)
                        values(@nVchcode,@tDate,@nVchType,@GOODS_ID,@szPTypeID,@szBTypeID,@szETypeID,@LENDOUT_STOCK,@szKTypeID2,

                                @dQty,@dCostPrice,@dCostTotal,@dCostPrice,@dCostTotal,@dDiscount,@dDiscountPrice,@dDiscountTotal,
                                @dTax,@dTaxPrice,@dTaxTotal,@dTax_Total,@szBlockno,@szProdate,@szMemo,@nPeriod,'',@nCostMode,@unit,2,@DeptID, @RetailPrice)

                        fetch next from CreateDly_cursor into @szATypeID, @szPTypeID,@dQty,@dPrice,@dTotal,@dDiscount,@dDiscountPrice, @dDiscountTotal,
                        	@dTax,@dTaxPrice,@dTaxTotal,@dTax_Total,@dCostPrice, @dCostTotal,@szBlockno,@szProdate, @szMemo, @UsedType,@nGoodsNo,
				@unit, @RetailPrice,@odlyorder,@nHandInputZero
                end
--库存商品变化
		if @dTempCostTotal <> 0
		begin
	                insert into dlya(vchcode,Date,VchType,ATypeID,BTypeID,ETypeID,KTypeID,
	                                    Total,period,UsedType,DeptID)
	                        values(@nVchcode,@tDate,@nVchType,@GOODS_ID,@szBTypeID,@szETypeID,@szKTypeID,
	
	                                @dTempCostTotal,@nPeriod,'',@DeptID)
	                if @@rowcount <=0 goto error1
		end
		if @dTempCostTotal <> 0
		begin
	                insert into dlya(vchcode,Date,VchType,ATypeID,BTypeID,ETypeID,KTypeID,
	                                    Total,period,UsedType,DeptID)
	                        values(@nVchcode,@tDate,@nVchType,@LENDOUT_GOODS_ID,@szBTypeID,@szETypeID,@szKTypeID,
	                                -@dTempCostTotal,@nPeriod,'',@DeptID)
	                if @@rowcount <=0 goto error1
		end
                CLOSE CreateDly_cursor
                DEALLOCATE CreateDly_cursor

        end
------------------------------借出单处理结束--------------------------

--借进
        if @nVchType=71

        begin
                select @execsql='declare CreateDly_cursor cursor for '
                                +' select ATypeID, PTypeID, qty, Price, Total, discount, discountPrice, discountTotal,
                                tax, taxPrice, taxTotal, tax_Total, costPrice, CostTotal, blockno, prodate, comment, UsedType, goodsno,unit, RetailPrice,dlyorder from bakdly
                                 where Vchcode= '+CAST(@nVchcode AS varchar(10))
                exec (@execsql)

                select @dTempQty = 0
                select @dTempCostTotal = 0
                OPEN CreateDly_cursor
                fetch next from CreateDly_cursor into @szATypeID, @szPTypeID,@dQty,@dPrice,@dTotal,@dDiscount,@dDiscountPrice, @dDiscountTotal,
                        @dTax,@dTaxPrice,@dTaxTotal,@dTax_Total,@dCostPrice, @dCostTotal,@szBlockno,@szProdate, @szMemo, @UsedType,@nGoodsNo,@unit, @RetailPrice,@odlyorder
                while @@FETCH_STATUS=0
                begin
                                select @nCostmode=costmode, @deleted=deleted, @nSon=sonnum,@lsSerial =lsSerial from ptype where typeid=@szPTypeID
                                if @deleted=1 or @nSon>0 goto error132

                        exec  @nRet = ModifyDbf @nVchType,@nVchcode,@tDate,@nCostmode,@GOODs_ID,@szPTypeID,@szBTypeID,@szETypeID,@szKTypeID,
                                @nPeriod,@dQty,@dCostTotal,@szBlockno,@szProdate,@nGoodsNo,@dTemp out,@odlyorder,@lsSerial
                        if @nRet<0 goto error

                        select @dCostPrice = @dTemp / @dQty
                        select @dCostTotal = @dTemp

                        insert into dlyother(vchcode,Date,VchType,ATypeID,PTypeID,BTypeID,ETypeID,KTypeID,KTypeID2,
                                    qty,Price,Total,costPrice,CostTotal,discount,discountPrice,discountTotal,
              tax,taxPrice,taxTotal,tax_Total,Blockno,Prodate,comment,period,UsedType,costmode,unit,DeptID, RetailPrice)
                        values(@nVchcode,@tDate,@nVchType,@GOODS_ID,@szPTypeID,@szBTypeID,@szETypeID,@szKTypeID,@szKTypeID2,
                                @dQty,@dCostPrice,@dCostTotal,@dCostPrice,@dCostTotal,@dDiscount,@dDiscountPrice,@dDiscountTotal,
                                @dTax,@dTaxPrice,@dTaxTotal,@dTax_Total,@szBlockno,@szProdate,@szMemo,@nPeriod,@UsedType,@nCostMode,@unit,@DeptID, @RetailPrice)
				--add by dcsong 2004.8.17 更新对应库存变动，一个单据号的且dlyorder为0的，当前变动的明细
                                select @nDlyOrder = @@identity
				update T_GoodsStocksGlide set dlyorder = @nDlyOrder where VchCode = @nVchcode and dlyorder = 0		
				update SN set VchLineNO = @nDlyorder,Tag = 2 where Vchcode = @nVchcode and VchLineNO = 0	
                        	if @@error <> 0 goto error1
                        select @dTempQty = @dTempQty+@dQty
                        select @dTempCostTotal = @dTempCostTotal+@dCostTotal
--修改借进库
                        exec  @nRet = ModifyDbfLend @nVchType,@nCostmode,@GOODs_ID,@szPTypeID,@szBTypeID,@szETypeID,@BORROWIN_STOCK,
                                @nPeriod,@dQty,@dCostTotal,@szBlockno,@szProdate,@nGoodsNo,@dTemp out
                        if @nRet<0 goto error
                        insert into dlyother(vchcode,Date,VchType,ATypeID,PTypeID,BTypeID,ETypeID,KTypeID,KTypeID2,
                                    qty,Price,Total,costPrice,CostTotal,discount,discountPrice,discountTotal,
                                tax,taxPrice,taxTotal,tax_Total,Blockno,Prodate,comment,period,UsedType,costmode,unit,PDETAIL,DeptID, RetailPrice)
                        values(@nVchcode,@tDate,@nVchType,@GOODS_ID,@szPTypeID,@szBTypeID,@szETypeID,@BORROWIN_STOCK,@szKTypeID2,
                                @dQty,@dCostPrice,@dCostTotal,@dCostPrice,@dCostTotal,@dDiscount,@dDiscountPrice,@dDiscountTotal,
                                @dTax,@dTaxPrice,@dTaxTotal,@dTax_Total,@szBlockno,@szProdate,@szMemo,@nPeriod,'',@nCostMode,@unit,2,@DeptID, @RetailPrice)

                        fetch next from CreateDly_cursor into @szATypeID, @szPTypeID,@dQty,@dPrice,@dTotal,@dDiscount,@dDiscountPrice, @dDiscountTotal,
                        @dTax,@dTaxPrice,@dTaxTotal,@dTax_Total,@dCostPrice, @dCostTotal,@szBlockno,@szProdate, @szMemo, @UsedType,@nGoodsNo,@unit, @RetailPrice,@odlyorder
                end
--库存商品变化
		if @dTempCostTotal <> 0
		begin
	                insert into dlya(vchcode,Date,VchType,ATypeID,BTypeID,ETypeID,KTypeID,
	                                    Total,period,UsedType,DeptID)
	                        values(@nVchcode,@tDate,@nVchType,@GOODS_ID,@szBTypeID,@szETypeID,@szKTypeID,
	                                @dTempCostTotal,@nPeriod,'',@DeptID)
	                if @@rowcount <=0 goto error1
		end

		if @dTempCostTotal <> 0
		begin
	                insert into dlya(vchcode,Date,VchType,ATypeID,BTypeID,ETypeID,KTypeID,
	                                    Total,period,UsedType,DeptID)
	                        values(@nVchcode,@tDate,@nVchType,@BORROWIN_GOODS_ID,@szBTypeID,@szETypeID,@szKTypeID,
	                                @dTempCostTotal,@nPeriod,'',@DeptID)
	                if @@rowcount <=0 goto error1
		end
                CLOSE CreateDly_cursor
                DEALLOCATE CreateDly_cursor
        end
------------------------------借进单处理结束--------------------------

--借出还回
        if @nVchType=88
        begin
                select @execsql='declare CreateDly_cursor cursor for '

                                +' select ATypeID, PTypeID, qty, Price, Total, discount, discountPrice, discountTotal,
                                tax, taxPrice, taxTotal, tax_Total, costPrice, CostTotal, blockno, prodate, comment, UsedType, goodsno,unit,dlyorder,RetailPrice from bakdly
                                 where Vchcode= '+CAST(@nVchcode AS varchar(10))
                exec (@execsql)



                select @dTempQty = 0
                select @dTempCostTotal = 0
                select @dTempTotal = 0
                OPEN CreateDly_cursor
                fetch next from CreateDly_cursor into @szATypeID, @szPTypeID,@dQty,@dPrice,@dTotal,@dDiscount,@dDiscountPrice, @dDiscountTotal,
                        @dTax,@dTaxPrice,@dTaxTotal,@dTax_Total,@dCostPrice, @dCostTotal,@szBlockno,@szProdate, @szMemo, @UsedType,@nGoodsNo,@unit,@odlyorder,@RetailPrice
                while @@FETCH_STATUS=0
                begin
                                select @nCostmode=costmode, @deleted=deleted, @nSon=sonnum,@lsSerial =lsSerial from ptype where typeid=@szPTypeID
                                if @deleted=1 or @nSon>0 goto error132
                        select @dQty=-@dQty
                        exec  @nRet = ModifyDbfLend @nVchType,@nCostmode,@GOODs_ID,@szPTypeID,@szBTypeID,@szETypeID,@LENDOUT_STOCK,
                                @nPeriod,@dQty,@dCostTotal,@szBlockno,@szProdate,@nGoodsNo,@dTemp out
                        if @nRet<0 goto error

                        select @dCostPrice = @dTemp / @dQty
                        select @dCostTotal = @dTemp

                        select @dQty=-@dQty
                        select @dCostTotal=-@dCostTotal

                        exec  @nRet = ModifyDbf @nVchType,@nVchcode,@tDate,@nCostmode,@GOODs_ID,@szPTypeID,@szBTypeID,@szETypeID,@szKTypeID,
                                @nPeriod,@dQty,@dCostTotal,@szBlockno,@szProdate,@nGoodsNo,@dTemp out,@odlyorder,@lsSerial

                        if @nRet<0 goto error


                        insert into dlyother(vchcode,Date,VchType,ATypeID,PTypeID,BTypeID,ETypeID,KTypeID,KTypeID2,
                                    qty,Price,Total,costPrice,CostTotal,discount,discountPrice,discountTotal,
                                tax,taxPrice,taxTotal,tax_Total,Blockno,Prodate,comment,period,UsedType,costmode,unit,DeptID,RetailPrice)
                        values(@nVchcode,@tDate,@nVchType,@GOODS_ID,@szPTypeID,@szBTypeID,@szETypeID,@szKTypeID,@szKTypeID2,
                                @dQty,@dCostPrice,@dCostTotal,@dCostPrice,@dCostTotal,@dDiscount,@dDiscountPrice,@dDiscountTotal,
                                @dTax,@dTaxPrice,@dTaxTotal,@dTax_Total,@szBlockno,@szProdate,@szMemo,@nPeriod,@UsedType,@nCostMode,@unit,@DeptID,@RetailPrice)
				--add by dcsong 2004.8.17 更新对应库存变动，一个单据号的且dlyorder为0的，当前变动的明细
                                select @nDlyOrder = @@identity
				update T_GoodsStocksGlide set dlyorder = @nDlyOrder where VchCode = @nVchcode and dlyorder = 0		
				update SN set VchLineNO = @nDlyorder,Tag = 2 where Vchcode = @nVchcode and VchLineNO = 0	
                        	if @@error <> 0 goto error1
                        select @dTempQty = @dTempQty+@dQty
                        select @dTempCostTotal = @dTempCostTotal+@dCostTotal
--修改借出库
                        insert into dlyother(vchcode,Date,VchType,ATypeID,PTypeID,BTypeID,ETypeID,KTypeID,KTypeID2,
                                    qty,Price,Total,costPrice,CostTotal,discount,discountPrice,discountTotal,
                                tax,taxPrice,taxTotal,tax_Total,Blockno,Prodate,comment,period,UsedType,costmode,unit,PDETAIL,DeptID)
                        values(@nVchcode,@tDate,@nVchType,@GOODS_ID,@szPTypeID,@szBTypeID,@szETypeID,@LENDOUT_STOCK,@szKTypeID2,
                                -@dQty,@dCostPrice,-@dCostTotal,@dCostPrice,-@dCostTotal,@dDiscount,@dDiscountPrice,@dDiscountTotal,
                                @dTax,@dTaxPrice,@dTaxTotal,@dTax_Total,@szBlockno,@szProdate,@szMemo,@nPeriod,'',@nCostMode,@unit,2,@DeptID)

                        fetch next from CreateDly_cursor into @szATypeID, @szPTypeID,@dQty,@dPrice,@dTotal,@dDiscount,@dDiscountPrice, @dDiscountTotal,
                        @dTax,@dTaxPrice,@dTaxTotal,@dTax_Total,@dCostPrice, @dCostTotal,@szBlockno,@szProdate, @szMemo, @UsedType,@nGoodsNo,@unit,@odlyorder,@RetailPrice
                end
--库存商品变化
		if @dTempCostTotal <> 0
		begin
	                insert into dlya(vchcode,Date,VchType,ATypeID,BTypeID,ETypeID,KTypeID,
	                                    Total,period,UsedType,DeptID)
	                        values(@nVchcode,@tDate,@nVchType,@GOODS_ID,@szBTypeID,@szETypeID,@szKTypeID,
	                                @dTempCostTotal,@nPeriod,'',@DeptID)
	                if @@rowcount <=0 goto error1
		end

		if @dTempCostTotal <> 0
		begin
	                insert into dlya(vchcode,Date,VchType,ATypeID,BTypeID,ETypeID,KTypeID,
	                                    Total,period,UsedType,DeptID)
	                        values(@nVchcode,@tDate,@nVchType,@LENDOUT_GOODS_ID,@szBTypeID,@szETypeID,@szKTypeID,
	                                -@dTempCostTotal,@nPeriod,'',@DeptID)
	                if @@rowcount <=0 goto error1
		end
                CLOSE CreateDly_cursor
                DEALLOCATE CreateDly_cursor
        end
------------------------------借出还回单处理结束--------------------------


--借进还出
        if @nVchType=72
        begin
                select @execsql='declare CreateDly_cursor cursor for '
                                +' select ATypeID, PTypeID, qty, Price, Total, discount, discountPrice, discountTotal,
                                tax, taxPrice, taxTotal, tax_Total, costPrice, CostTotal, blockno, prodate, comment, 
				UsedType, goodsno,unit,dlyorder,HandZeroCost,RetailPrice from bakdly
                                 where Vchcode= '+CAST(@nVchcode AS varchar(10))
                exec (@execsql)

                select @dTempQty = 0
                select @dTempCostTotal = 0
                select @dTempTotal = 0
                OPEN CreateDly_cursor
                fetch next from CreateDly_cursor into @szATypeID, @szPTypeID,@dQty,@dPrice,@dTotal,@dDiscount,@dDiscountPrice, @dDiscountTotal,
                        @dTax,@dTaxPrice,@dTaxTotal,@dTax_Total,@dCostPrice, @dCostTotal,@szBlockno,@szProdate, @szMemo, @UsedType,@nGoodsNo,
			@unit,@odlyorder,@nHandInputZero,@RetailPrice
                while @@FETCH_STATUS=0
                begin
                                select @nCostmode=costmode, @deleted=deleted, @nSon=sonnum,@lsSerial = lsSerial from ptype where typeid=@szPTypeID
                                if @deleted=1 or @nSon>0 goto error132
                        select @dQty=-@dQty
                        select @dCostTotal = -@dCostTotal--如果库存为0
			select @dTemp=@dcostprice
                        exec  @nRet = ModifyDbf @nVchType,@nVchcode,@tDate,@nCostmode,@GOODs_ID,@szPTypeID,@szBTypeID,@szETypeID,@szKTypeID,
                                @nPeriod,@dQty,@dCostTotal,@szBlockno,@szProdate,@nGoodsNo,@dTemp out,@odlyorder,@lsSerial,@nHandInputZero
                        if @nRet<0 goto error
                        select @dCostPrice = @dTemp / @dQty
                        select @dCostTotal = @dTemp
                        select @dTempCostTotal = @dTempCostTotal+@dCostTotal

                        insert into dlyother(vchcode,Date,VchType,ATypeID,PTypeID,BTypeID,ETypeID,KTypeID,KTypeID2,
                                    qty,Price,Total,costPrice,CostTotal,discount,discountPrice,discountTotal,
                                tax,taxPrice,taxTotal,tax_Total,Blockno,Prodate,comment,period,UsedType,costmode,unit,DeptID,RetailPrice)
                        values(@nVchcode,@tDate,@nVchType,@GOODS_ID,@szPTypeID,@szBTypeID,@szETypeID,@szKTypeID,@szKTypeID2,
                                @dQty,@dCostPrice,@dCostTotal,@dCostPrice,@dCostTotal,@dDiscount,@dDiscountPrice,@dCostTotal,
                                @dTax,@dTaxPrice,@dTaxTotal,@dTax_Total,@szBlockno,@szProdate,@szMemo,@nPeriod,@UsedType,@nCostMode,@unit,@DeptID,@RetailPrice)
				--add by dcsong 2004.8.17 更新对应库存变动，一个单据号的且dlyorder为0的，当前变动的明细
               select @nDlyOrder = @@identity
				update T_GoodsStocksGlide set dlyorder = @nDlyOrder where VchCode = @nVchcode and dlyorder = 0		
				update SN set VchLineNO = @nDlyorder,Tag = 3 where Vchcode = @nVchcode and VchLineNO = 0	
                        	if @@error <> 0 goto error1

                        exec  @nRet = ModifyDbfLend @nVchType,@nCostmode,@GOODs_ID,@szPTypeID,@szBTypeID,@szETypeID,@BORROWIN_STOCK,

                                @nPeriod,@dQty,@dCostTotal,@szBlockno,@szProdate,@nGoodsNo,@dTemp out
                        if @nRet<0 goto error
                        select @dCostPrice = @dTemp / @dQty
                        select @dCostTotal = @dTemp
                        select @dTempQty = @dTempQty+@dQty

                        select @dTempTotal = @dTempTotal+@dCostTotal
                        insert into dlyother(vchcode,Date,VchType,ATypeID,PTypeID,BTypeID,ETypeID,KTypeID,KTypeID2,
                                    qty,Price,Total,costPrice,CostTotal,discount,discountPrice,discountTotal,
                                tax,taxPrice,taxTotal,tax_Total,Blockno,Prodate,comment,period,UsedType,costmode,unit,PDETAIL,DeptID)
                        values(@nVchcode,@tDate,@nVchType,@GOODS_ID,@szPTypeID,@szBTypeID,@szETypeID,@BORROWIN_STOCK,@szKTypeID2,
                                @dQty,@dCostPrice,@dCostTotal,@dCostPrice,@dCostTotal,@dDiscount,@dDiscountPrice,@dCostTotal,
                                @dTax,@dTaxPrice,@dTaxTotal,@dTax_Total,@szBlockno,@szProdate,@szMemo,@nPeriod,'',@nCostMode,@unit,2,@DeptID)
                        if @@rowcount <=0 goto error1


                        fetch next from CreateDly_cursor into @szATypeID, @szPTypeID,@dQty,@dPrice,@dTotal,@dDiscount,@dDiscountPrice, @dDiscountTotal,
                        	@dTax,@dTaxPrice,@dTaxTotal,@dTax_Total,@dCostPrice, @dCostTotal,@szBlockno,@szProdate, @szMemo, @UsedType,@nGoodsNo,
				@unit,@odlyorder,@nHandInputZero,@RetailPrice
                end
--库存商品变化
		if @dTempCostTotal <> 0
		begin
	                insert into dlya(vchcode,Date,VchType,ATypeID,BTypeID,ETypeID,KTypeID,
	                                    Total,period,UsedType,DeptID)
	                        values(@nVchcode,@tDate,@nVchType,@GOODS_ID,@szBTypeID,@szETypeID,@szKTypeID,
	                                @dTempCostTotal,@nPeriod,'',@DeptID)
	                if @@rowcount <=0 goto error1
		end
		if @dTempTotal <> 0
		begin
	                insert into dlya(vchcode,Date,VchType,ATypeID,BTypeID,ETypeID,KTypeID,
	                                    Total,period,UsedType,DeptID)
	                        values(@nVchcode,@tDate,@nVchType,@BORROWIN_GOODS_ID,@szBTypeID,@szETypeID,@szKTypeID,
	                                @dTempTotal,@nPeriod,'',@DeptID)
	                if @@rowcount <=0 goto error1
		end
--科目变化
                select @dTemp = @dTempCostTotal-@dTempTotal
                if @dTemp<>0
                begin
                        insert into dlya(vchcode,Date,VchType,ATypeID,BTypeID,ETypeID,KTypeID,
                                    Total,period,UsedType,DeptID)
                        values(@nVchcode,@tDate,@nVchType,@BORROW_BORROWBACK_ID,@szBTypeID,@szETypeID,@szKTypeID,
                                @dTemp,@nPeriod,'',@DeptID)
                        if @@rowcount <=0 goto error1
                end

                CLOSE CreateDly_cursor
                DEALLOCATE CreateDly_cursor
        end
------------------------------借进还出单处理结束--------------------------


--借出转销售
        if @nVchType=89
        begin
                select @execsql='declare CreateDly_cursor cursor for '
                                +' select ATypeID, PTypeID, qty, Price, Total, discount, discountPrice, discountTotal,
                                tax, taxPrice, taxTotal, tax_Total, costPrice, CostTotal, blockno, prodate, comment, UsedType,goodsno,unit, OrderCode,OrderDlyCode,InvoceTotal, RetailPrice from bakdly
                                 where Vchcode= '+CAST(@nVchcode AS varchar(10))
                exec (@execsql)

                select @nModiSalePrice= [stats] from syscon where [order]=3
                select @nTrackPrice = [stats] from syscon where [order]=8
	   select @nTrackDisCount = [stats] from syscon where [order]=47
                select @dTotalinMoney = 0
                select @dTempTotal = 0
                select @dTempQty = 0
                select @dTotalMoney = 0
                select @dTempCostTotal = 0
		select @nInvTag = 0
                select @dTemptaxTotal = 0
                OPEN CreateDly_cursor
                fetch next from CreateDly_cursor into @szATypeID, @szPTypeID,@dQty,@dPrice,@dTotal,@dDiscount,@dDiscountPrice, @dDiscountTotal,
                        @dTax,@dTaxPrice,@dTaxTotal,@dTax_Total,@dCostPrice, @dCostTotal,@szBlockno,@szProdate, @szMemo, @UsedType,@nGoodsNo,@unit,@nOrderCode,@nOrderDlyCode,@dInvoceTotal, @RetailPrice
                while @@FETCH_STATUS=0
                begin
                        if @szPTypeID<>''
                        begin
                                if @dInvoceTotal<>0 Set @nInvoceTag =1 else Set @nInvoceTag =0
				if @nInvTag = 0 set @nInvTag = @nInvoceTag
                                select @nCostmode=costmode, @deleted=deleted, @nSon=sonnum from ptype where typeid=@szPTypeID
                                if @deleted=1 or @nSon>0 goto error132
                                select @dQty = -@dQty
                                select @dCostTotal = -@dCostTotal

                                exec  @nRet = ModifyDbfLend @nVchType,@nCostmode,@GOODs_ID,@szPTypeID,@szBTypeID,@szETypeID,@LENDOUT_STOCK,
                                      @nPeriod,@dQty,@dCostTotal,@szBlockno,@szProdate,@nGoodsNo,@dTemp out
                                if @nRet<0 goto error

                                insert into dlyother(vchcode,Date,VchType,ATypeID,PTypeID,BTypeID,ETypeID,KTypeID,KTypeID2,

                                        qty,Price,Total,costPrice,CostTotal,discount,discountPrice,discountTotal,
                                        tax,taxPrice,taxTotal,tax_Total,Blockno,Prodate,comment,period,UsedType,costmode,unit,PDETAIL,DeptID,InvoceTotal,InvoceTag,RetailPrice)
                                values(@nVchcode,@tDate,@nVchType, @LENDOUT_GOODS_ID ,@szPTypeID,@szBTypeID,@szETypeID,@LENDOUT_STOCK,@szKTypeID2,
                                        @dQty,@dCostPrice,@dCostTotal,@dCostPrice,@dCostTotal,@dDiscount,@dDiscountPrice,@dCostTotal,
                                        @dTax,@dTaxPrice,@dTaxTotal,@dTax_Total,@szBlockno,@szProdate,@szMemo,@nPeriod,@UsedType,@nCostMode,@unit,2,@DeptID,@dInvoceTotal,@nInvoceTag,@RetailPrice)
                                if @@rowcount <=0 goto error1

                                select @dCostTotal = @dTemp
                                select @dCostPrice = @dCostTotal / @dQty

                                select @dTempTotal = @dTempTotal+@dDiscountTotal
                                select @dTempQty = @dTempQty+@dQty
                                select @dTempCostTotal = @dTempCostTotal+@dCostTotal
                                select @dTotalMoney = @dTotalMoney+@dTax_Total
                                select @dTemptaxTotal = @dTemptaxTotal + @dTaxTotal
                        	if @nModiSalePrice=1 update ptype set prePrice1=@dPrice where typeid=@szPTypeID
	     			if @nTrackPrice=1 Exec F_GetCustomerPrice 'S',@szPtypeId,@szBtypeId,0,@dPrice,1,1,'','',1
	     			if @nTrackDisCount=1 Exec F_GetCustomerPrice 'SD',@szPtypeId,@szBtypeId,0,0,1,@ddiscount,'','',1		
				if (@nTrackPrice=1) or (@nTrackDisCount=1)
				begin
					select @xsdate = CONVERT(varchar(10),getdate(),120) 
					Exec F_GetCustomerPrice 'SDT',@szPtypeId,@szBtypeId,0,0,1,1,'',@xsdate,1 
				end
                                insert into DlySale(vchcode,Date,VchType,ATypeID,PTypeID,BTypeID,ETypeID,KTypeID,KTypeID2,
                                    qty,Price,Total,costPrice,CostTotal,discount,discountPrice,discountTotal,
                                tax,taxPrice,taxTotal,tax_Total,Blockno,Prodate,comment,period,UsedType,costmode,unit,OrderCode,OrderDlyCode,DeptID,InvoceTotal,InvoceTag,RetailPrice)
                                values(@nVchcode,@tDate,@nVchType,@szATypeID,@szPTypeID,@szBTypeID,@szETypeID,@LENDOUT_STOCK,@szKTypeID2,
                                @dQty,@dPrice,-@dTotal,@dCostPrice,@dCostTotal,@dDiscount,@dDiscountPrice,-@dDiscountTotal,
                                @dTax,@dTaxPrice,-@dTaxTotal,-@dTax_Total,@szBlockno,@szProdate,@szMemo,@nPeriod,@UsedType,@nCostMode,@unit,@nOrderCode,@nOrderDlyCode,@DeptID,@dInvoceTotal,@nInvoceTag,@RetailPrice)
                        end
                        else
                        begin
                                select @dTotalinMoney = @dTotalinMoney + @dTotal
                                insert into dlya(vchcode,Date,VchType,ATypeID,BTypeID,ETypeID,KTypeID,

                                    Total,period,UsedType,DeptID)
                                values(@nVchcode,@tDate,@nVchType,@szATypeID,@szBTypeID,@szETypeID,@szKTypeID,
                                        @dTotal,@nPeriod,@UsedType,@DeptID)
                        end
                        if @@rowcount <=0 goto error1


                        fetch next from CreateDly_cursor into @szATypeID, @szPTypeID,@dQty,@dPrice,@dTotal,@dDiscount,@dDiscountPrice, @dDiscountTotal,

                        @dTax,@dTaxPrice,@dTaxTotal,@dTax_Total,@dCostPrice, @dCostTotal,@szBlockno,@szProdate, @szMemo, @UsedType,@nGoodsNo,@unit,@nOrderCode,@nOrderDlyCode,@dInvoceTotal, @RetailPrice
                end
--借出商品减少
		if @dTempCostTotal <> 0
		begin
	                insert into dlya(vchcode,Date,VchType,ATypeID,BTypeID,ETypeID,KTypeID,
	                                    Total,period,UsedType,DeptID)
	                        values(@nVchcode,@tDate,@nVchType,@LENDOUT_GOODS_ID,@szBTypeID,@szETypeID,@szKTypeID,
	                                @dTempCostTotal,@nPeriod,'',@DeptID)
	                if @@rowcount <=0 goto error1
		end
--应交税金增加
                if @dTempTaxTotal<>0
                begin
                        insert into dlya(vchcode,Date,VchType,ATypeID,BTypeID,ETypeID,KTypeID,
                                    Total,period,UsedType,DeptID)
                        values(@nVchcode,@tDate,@nVchType,@TAX_ID,@szBTypeID,@szETypeID,@szKTypeID,
                                @dTemptaxTotal,@nPeriod,'',@DeptID)
                        if @@rowcount <=0 goto error1
                end

--销售收入增加
		if @dTempTotal <> 0
		begin
	                insert into dlya(vchcode,Date,VchType,ATypeID,BTypeID,ETypeID,KTypeID,
	                            Total,period,UsedType,DeptID)
	                        values(@nVchcode,@tDate,@nVchType,@SALE_INCOME_ID,@szBTypeID,@szETypeID,@szKTypeID,
	                                @dTempTotal,@nPeriod,'',@DeptID)
	                if @@rowcount <=0 goto error1
		end
--销售成本增加
		if @dTempCostTotal <> 0
		begin
	                insert into dlya(vchcode,Date,VchType,ATypeID,BTypeID,ETypeID,KTypeID,
	                                    Total,period,UsedType,DeptID)
	                        values(@nVchcode,@tDate,@nVchType,@SALE_COST_ID,@szBTypeID,@szETypeID,@szKTypeID,
	                                -@dTempCostTotal,@nPeriod,'',@DeptID)
	                if @@rowcount <=0 goto error1
		end
--应收应付
                if @dTotalInMoney <> @dTotalMoney
                begin
                        select @dTemp = @dTotalMoney-@dTotalInMoney
                        insert into dlya(vchcode,Date,VchType,ATypeID,BTypeID,ETypeID,KTypeID,
                                    Total,period,UsedType,DeptID)
                        values(@nVchcode,@tDate,@nVchType,@AR_ID,@szBTypeID,@szETypeID,@szKTypeID,
                                @dTemp,@nPeriod,'',@DeptID)
                        if @@rowcount <=0 goto error1
                end

                update dlyndx set Total=Abs(@dTotalMoney),InvoceTag = @nInvTag where vchcode=@nVchcode
                if @@rowcount <=0 goto error1

                CLOSE CreateDly_cursor
                DEALLOCATE CreateDly_cursor
        end
------------------------------借出转销售单处理结束--------------------------


--借进转进货
        if @nVchType=73
        begin

                select @execsql='declare CreateDly_cursor cursor for '
                                +' select ATypeID, PTypeID, qty, Price, Total, discount, discountPrice, discountTotal,
                                tax, taxPrice, taxTotal, tax_Total, costPrice, CostTotal, blockno, prodate, comment, UsedType, goodsno, unit, OrderCode, OrderDlyCode,InvoceTotal from bakdly
                                 where Vchcode= '+CAST(@nVchcode AS varchar(10))
                exec (@execsql)

                select @nTrackPrice = [stats] from syscon where [order]=8
	   select @nTrackDisCount = [stats] from syscon where [order]=47
                select @dTotalinMoney = 0
                select @dTempTotal = 0
                select @dTemptaxTotal = 0
                select @dTempCostTotal = 0
                select @dTempQty = 0
		select @nInvTag = 0
                select @dTotalMoney = 0
                OPEN CreateDly_cursor

                fetch next from CreateDly_cursor into @szATypeID, @szPTypeID,@dQty,@dPrice,@dTotal,@dDiscount,@dDiscountPrice, @dDiscountTotal,
                        @dTax,@dTaxPrice,@dTaxTotal,@dTax_Total,@dCostPrice, @dCostTotal,@szBlockno,@szProdate, @szMemo, @UsedType,@nGoodsNo,@unit,@nOrderCode,@nOrderDlyCode,@dInvoceTotal
                while @@FETCH_STATUS=0
                begin
                        if @szPTypeID<>''
                        begin
                                if @dInvoceTotal<>0 Set @nInvoceTag =1 else Set @nInvoceTag =0
				if @nInvTag = 0 set @nInvTag = @nInvoceTag


                                select @nCostmode=costmode, @deleted=deleted, @nSon=sonnum from ptype where typeid=@szPTypeID
                                if @deleted=1 or @nSon>0 goto error132

                                select @dQty = -@dQty

                                select @dCostTotal = -@dCostTotal
                                select @dDiscountTotal = -@dDiscountTotal
                                select @dTax_Total = -@dTax_Total

                                exec  @nRet = ModifyDbfLend @nVchType,@nCostmode,@GOODs_ID,@szPTypeID,@szBTypeID,@szETypeID,@BORROWIN_STOCK,
                                      @nPeriod,@dQty,@dCostTotal,@szBlockno,@szProdate,@nGoodsNo,@dTemp out
                                if @nRet<0 goto error

                                insert into dlyother(vchcode,Date,VchType,ATypeID,PTypeID,BTypeID,ETypeID,KTypeID,KTypeID2,
                                        qty,Price,Total,costPrice,CostTotal,discount,discountPrice,discountTotal,
                                        tax,taxPrice,taxTotal,tax_Total,Blockno,Prodate,comment,period,UsedType,costmode,unit,PDETAIL,DeptID,InvoceTotal,InvoceTag)
                                values(@nVchcode,@tDate,@nVchType, @BORROWIN_GOODS_ID ,@szPTypeID,@szBTypeID,@szETypeID,@BORROWIN_STOCK,@szKTypeID2,
                                        @dQty,@dCostPrice,@dCostTotal,@dCostPrice,@dCostTotal,@dDiscount,@dDiscountPrice,@dCostTotal,
                                        @dTax,@dTaxPrice,@dTaxTotal,@dTax_Total,@szBlockno,@szProdate,@szMemo,@nPeriod,@UsedType,@nCostMode,@unit,2,@DeptID,@dInvoceTotal,@nInvoceTag)
                                if @@rowcount <=0 goto error1

                                select @dQty = -@dQty
--                              select @dCostTotal = -@dCostTotal
                select @dDiscountTotal = -@dDiscountTotal
                                select @dTax_Total = -@dTax_Total

                                select @dTempTotal = @dTempTotal+ @dDiscountTotal
                                select @dTempQty = @dTempQty+@dQty
                                select @dTotalMoney = @dTotalMoney+@dTax_Total
                                select @dTemptaxTotal = @dTemptaxTotal + @dTaxTotal
                                select @dCostTotal = @dTemp
                                select @dCostPrice = @dCostTotal / @dQty
                                select @dTempCostTotal = @dTempCostTotal + @dCostTotal

                                update ptype set recprice=@ddiscountprice,recprice1=@dPrice where typeid=@szPTypeID
		     		if @nTrackPrice=1 Exec F_GetCustomerPrice 'C',@szPtypeId,@szBtypeId,@dPrice,0,1,1,'','',1
		     		if @nTrackDisCount=1 Exec F_GetCustomerPrice 'BD',@szPtypeId,@szBtypeId,0,0,@ddiscount,1,'','',1	
				if ((@nTrackPrice=1) or (@nTrackDisCount=1))
				begin
				 	select @jhdate = CONVERT(varchar(10),getdate(),120)
 					Exec F_GetCustomerPrice 'BDT',@szPtypeId,@szBtypeId,0,0,1,1,@jhdate,'',1 
				end			

                                insert into dlybuy(vchcode,Date,VchType,ATypeID,PTypeID,BTypeID,ETypeID,KTypeID,KTypeID2,
                                    qty,Price,Total,costPrice,CostTotal,discount,discountPrice,discountTotal,
                                tax,taxPrice,taxTotal,tax_Total,Blockno,Prodate,comment,period,UsedType,costmode,unit,OrderCode,OrderDlyCode,DeptID,InvoceTotal,Invocetag)
                                values(@nVchcode,@tDate,@nVchType,@szATypeID,@szPTypeID,@szBTypeID,@szETypeID,@BORROWIN_STOCK,@szKTypeID2,
                                @dQty,@dPrice,@dTotal,-@dCostPrice,-@dCostTotal,@dDiscount,@dDiscountPrice,@dDiscountTotal,
                                @dTax,@dTaxPrice,@dTaxTotal,@dTax_Total,@szBlockno,@szProdate,@szMemo,@nPeriod,@UsedType,@nCostMode,@unit,@nOrderCode,@nOrderDlyCode,@DeptID,@dInvoceTotal,@nInvoceTag)
                        end
                        else
                        begin
                                select @dTotalinMoney = @dTotalinMoney + @dTotal
                                select @dTotal = -@dTotal
                                insert into dlya(vchcode,Date,VchType,ATypeID,BTypeID,ETypeID,KTypeID,

                                            Total,period,UsedType,DeptID)
                                values(@nVchcode,@tDate,@nVchType,@szATypeID,@szBTypeID,@szETypeID,@szKTypeID,
                                        @dTotal,@nPeriod,@UsedType,@DeptID)
                        end
                        if @@rowcount <=0 goto error1
                        fetch next from CreateDly_cursor into @szATypeID, @szPTypeID,@dQty,@dPrice,@dTotal,@dDiscount,@dDiscountPrice, @dDiscountTotal,
                        @dTax,@dTaxPrice,@dTaxTotal,@dTax_Total,@dCostPrice, @dCostTotal,@szBlockno,@szProdate, @szMemo, @UsedType,@nGoodsNo,@unit,@nOrderCode,@nOrderDlyCode,@dInvoceTotal
                end
--借进商品减少
		if @dTempCostTotal <> 0
		begin
	                insert into dlya(vchcode,Date,VchType,ATypeID,BTypeID,ETypeID,KTypeID,
	                                    Total,period,UsedType,DeptID)
	                        values(@nVchcode,@tDate,@nVchType,@BORROWIN_GOODS_ID,@szBTypeID,@szETypeID,@szKTypeID,
	                                @dTempCostTotal,@nPeriod,'',@DeptID)
	                if @@rowcount <=0 goto error1
		end
--应交税金减少
                if @dTempTaxTotal<>0
                begin
                        insert into dlya(vchcode,Date,VchType,ATypeID,BTypeID,ETypeID,KTypeID,
                                    Total,period,UsedType,DeptID)
                        values(@nVchcode,@tDate,@nVchType,@TAX_ID,@szBTypeID,@szETypeID,@szKTypeID,
                                -@dTemptaxTotal,@nPeriod,'',@DeptID)
if @@rowcount <=0 goto error1
                end
--应收应付
                select @dTemp = @dTotalMoney-@dTotalInMoney
                if @dTemp<>0
                begin
                        insert into dlya(vchcode,Date,VchType,ATypeID,BTypeID,ETypeID,KTypeID,
                                    Total,period,UsedType,DeptID)
                        values(@nVchcode,@tDate,@nVchType,@AP_ID,@szBTypeID,@szETypeID,@szKTypeID,
                                @dTemp,@nPeriod,'',@DeptID)
                        if @@rowcount <=0 goto error1
                end
--成本差
                select @dTemp = @dTempCostTotal+@dTempTotal
                if @dTemp<>0
                begin
                        insert into dlya(vchcode,Date,VchType,ATypeID,BTypeID,ETypeID,KTypeID,
                                    Total,period,UsedType,DeptID)
                        values(@nVchcode,@tDate,@nVchType,@BORROW_BORROWBACK_ID,@szBTypeID,@szETypeID,@szKTypeID,
                               -@dTemp,@nPeriod,'',@DeptID)
                        if @@rowcount <=0 goto error1
                end

                update dlyndx set Total=Abs(@dTotalMoney),InvoceTag = @nInvTag where vchcode=@nVchcode
                if @@rowcount <=0 goto error1

                CLOSE CreateDly_cursor
                DEALLOCATE CreateDly_cursor
        end
------------------------------借进转进货单处理结束--------------------------

------------------------------代收代付单处理开始--------------------------

        if @nVchType in (100,101)
        begin
                if @nVchType=100
                begin
                        select @szAutoSummary = '第'+@szNumber+'代收单'
                end
                else
                begin
                        select @szAutoSummary = '第'+@szNumber+'代付单'

                end

                select @execsql='declare CreateDly_cursor cursor for  select PTypeID, qty,blockno, prodate, comment,KTypeID,unit
                                 from bakdly where Vchcode= '+CAST(@nVchcode AS varchar(10))+' order by dlyorder'
                exec (@execsql)



                OPEN CreateDly_cursor

                fetch next from CreateDly_cursor into @szPTypeID,@dQty,@szBlockno,@szProdate,@szMemo,@szKTypeID,@unit--@Type
                while @@FETCH_STATUS=0
                begin
                        select Distinct @nCostmode=costmode, @deleted=deleted , @nSon=sonnum  from ptype  where typeid=@szPTypeID
                        if @deleted=1 or @nSon>0 goto error132

                        if @nVchType=101 Set @dQty = -@dQty

                        exec @nRet = ModifyZeroGoods @nVchType, @szPTypeID, @szBTypeID, @dQty, @szBlockNo,@szProdate,@szKTypeID--@Type@Type
                        if @nRet<0 goto error

                        insert DlyOther(vchcode,  [Date],VchType, ATypeID,PTypeID,   BTypeID,   qty,  Blockno,   Prodate,   comment, Period, UsedType,pdetail,KTypeID,unit)
                                values( @nVchcode,@tDate,@nVchType,'',    @szPTypeID,@szBTypeID,@dQty,@szBlockno,@szProdate,@szMemo,@nPeriod, '1',2,@szKTypeID,@unit)--@Type@Type)
                        if @@rowcount <=0 goto error1

                        fetch next from CreateDly_cursor into @szPTypeID,@dQty,@szBlockno,@szProdate, @szMemo,@szKTypeID,@unit--@Type
                end


                CLOSE CreateDly_cursor
                DEALLOCATE CreateDly_cursor
        end
------------------------------代收代付单处理结束--------------------------



------------------------------会计凭证单
        if @nVchType=125
        begin
                select @execsql='declare CreateDly_cursor cursor for '
                                +' select ATypeID, PTypeID, qty, Price, Total, discount, discountPrice, discountTotal,
                                tax, taxPrice, taxTotal, tax_Total, costPrice, CostTotal, blockno, prodate, comment, UsedType, BTypeID, redword from bakdly
			     	where Vchcode= '+CAST(@nVchcode AS varchar(10))

                exec (@execsql)


                select @dTempTotal = 0
                OPEN CreateDly_cursor

                fetch next from CreateDly_cursor into @szATypeID, @szPTypeID,@dQty,@dPrice,@dTotal,@dDiscount,@dDiscountPrice, @dDiscountTotal,
                        @dTax,@dTaxPrice,@dTaxTotal,@dTax_Total,@dCostPrice, @dCostTotal,@szBlockno,@szProdate, @szMemo, @UsedType, @szBTypeID, @redword
                while @@FETCH_STATUS=0
                begin
			if not Exists( Select typeid from Atype where typeid=@szATypeID and Deleted=0 and SonNum=0) goto error137r

                        if @UsedType='1'
                        begin
                                select @dTempTotal = @dTempTotal+@dTotal
                        end

                        insert into dlya(vchcode,Date,VchType,ATypeID,BTypeID,ETypeID,KTypeID, Comment,


                                    Total,period,UsedType,redword,DeptID)
                        values(@nVchcode,@tDate,@nVchType,@szATypeID,@szBTypeID,@szETypeID,@szKTypeID, @szMemo,
                                @dTotal,@nPeriod,@UsedType,@redword,@DeptID)

                        if @@rowcount <=0 goto error1
                        fetch next from CreateDly_cursor into @szATypeID, @szPTypeID,@dQty,@dPrice,@dTotal,@dDiscount,@dDiscountPrice, @dDiscountTotal,
                        @dTax,@dTaxPrice,@dTaxTotal,@dTax_Total,@dCostPrice, @dCostTotal,@szBlockno,@szProdate, @szMemo, @UsedType, @szBTypeID, @redword
                end

                CLOSE CreateDly_cursor

                DEALLOCATE CreateDly_cursor
        end
------------------------------会计凭证处理结束--------------------------




-----对科目类型进行过帐
finish:
        set @nRet =0
        select @execsql='declare AccountDly_cursor cursor for '
                                +' select ATypeID, BTypeID,Total from dlya  where  Vchcode= '+CAST(@nVchcode AS varchar(10))
                exec (@execsql)
                OPEN AccountDly_cursor
                fetch next from AccountDly_cursor into @szATypeID,@szBTypeID,@dTotal
                while @@FETCH_STATUS=0
                begin

                        if @szATypeID<>''
                        begin
                                Exec @nRet = ModifyDbf @nVchType,@nVchcode,@tDate,0,@szATypeID,'',@szBTypeID,@szETypeID,'',
                                @nPeriod,@dTotal,@dTotal,'','',0,@dTemp output,0,0
                                if @nRet<0 goto error
                        end
                        fetch next from AccountDly_cursor into @szATypeID, @szBTypeID,@dTotal
                end
                CLOSE AccountDly_cursor
                DEALLOCATE AccountDly_cursor

        update dlyndx set draft=2, Period = @nPeriod where vchcode=@nVchcode
        if @@rowcount <=0 goto error1
        delete from bakdly where vchcode=@nVchcode
        if @@rowcount <=0 goto error1
        select @szTemp=subvalue from sysdata where subname='enddate'
        if @tdate>@szTemp update sysdata set subvalue=@tdate where subname='enddate'
        commit tran Account

        return 0

error:
        CLOSE CreateDly_cursor
        DEALLOCATE CreateDly_cursor
        rollback tran Account
        select @szPTypeIDo = @szPTypeID
        select @szBTypeIDo = @szBTypeID
        select @szATypeIDo = @szATypeID
        select @szKTypeIDo = @szKTypeID
	if @nRet = -54 select @nRet = -5 --如果成本价为0,并且不允许0成本出库,则提示录入成本
        return @nRet
error2:
        CLOSE DBCreatedly_cursor
        DEALLOCATE DBCreatedly_cursor
        rollback tran Account
        select @szPTypeIDo = @szPTypeID
        select @szBTypeIDo = @szBTypeID
        select @szATypeIDo = @szATypeID
        select @szKTypeIDo = @szKTypeID
        return @nRet

error1:
        CLOSE CreateDly_cursor
        DEALLOCATE CreateDly_cursor
        rollback tran Account
        select @szPTypeIDo = @szPTypeID
        select @szBTypeIDo = @szBTypeID
        select @szATypeIDo = @szATypeID
        select @szKTypeIDo = @szKTypeID
        return -2

error132:
        CLOSE CreateDly_cursor
        DEALLOCATE CreateDly_cursor
        rollback tran Account
        select @szPTypeIDo = @szPTypeID
        select @szBTypeIDo = @szBTypeID
        select @szATypeIDo = @szATypeID
        select @szKTypeIDo = @szKTypeID
        return -132

error133:
        select @szPTypeIDo = @szPTypeID
        select @szBTypeIDo = @szBTypeID
        select @szATypeIDo = @szATypeID
        select @szKTypeIDo = @szKTypeID
        return -133

error135:
        select @szPTypeIDo = @szPTypeID
        select @szBTypeIDo = @szBTypeID
        select @szATypeIDo = @szATypeID
        return -135

error135R:
        CLOSE CreateDly_cursor
        DEALLOCATE CreateDly_cursor
        rollback tran Account
        select @szPTypeIDo = @szPTypeID
        select @szBTypeIDo = @szBTypeID
        select @szATypeIDo = @szATypeID
        return -135
error137R:
        CLOSE CreateDly_cursor
        DEALLOCATE CreateDly_cursor
        rollback tran Account
        select @szPTypeIDo = @szPTypeID
        select @szBTypeIDo = @szBTypeID
        select @szATypeIDo = @szATypeID
        return -137

error145:
        select @szPTypeIDo = @szPTypeID
        select @szBTypeIDo = @szBTypeID
        select @szATypeIDo = @szATypeID
        return -145

