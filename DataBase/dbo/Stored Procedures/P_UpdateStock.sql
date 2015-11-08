Create PROCEDURE P_UpdateStock
--ALTER PROCEDURE P_UpdateStock
(
@StockId int,--主键Id
@StockNo varchar(50),--仓库编号
@StockName varchar(100),--仓库名称
@LastModifyId varchar(36),--最后修改人Id
@Remark varchar(200)--备注
)
AS
declare @errmsg varchar(max)
select 1 from T_Stock where StockNo=@StockNo and StockId<>@StockId and Deleted=0
if(@@ROWCOUNT>0) begin select @errmsg=dbo.F_GetError('',1) RAISERROR(@errmsg,11,1) end--编号重复
update T_Stock set 
StockNo=@StockNo,--仓库编号
StockName=@StockName,--仓库名称
LastModifyId=@LastModifyId,--最后修改人Id
LastModifyDate=getdate(),--最后修改日期
Remark=@Remark--备注
where StockId=@StockId
if(@@ROWCOUNT<=0) begin select @errmsg=dbo.F_GetError('',3) RAISERROR(@errmsg,11,1) end--更新失败