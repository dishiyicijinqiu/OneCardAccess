CREATE PROCEDURE P_CreateStock
--ALTER PROCEDURE P_CreateStock
(
@StockId int output,--主键Id
@StockNo varchar(50),--仓库编号
@StockName varchar(100),--仓库名称
@CreateId varchar(36),--创建人Id
@Remark varchar(200)--备注
)
AS

declare @errmsg varchar(max)
select @StockId=0
select 1 from T_Stock where StockNo=@StockNo and Deleted=0
if(@@ROWCOUNT>0) begin select @errmsg=dbo.F_GetError('',1) RAISERROR(@errmsg,11,1) end--存在相同的编号



insert into T_Stock (
   StockNo,--仓库编号
   StockName,--仓库名称
   CreateId,--创建人Id
   CreateDate,--创建日期
   LastModifyId,--最后修改人Id
   LastModifyDate,--最后修改日期
   Deleted,--删除标识
   Remark--备注
) values (
   @StockNo,--仓库编号
   @StockName,--仓库名称
   @CreateId,--创建人Id
   getdate(),--创建日期
   @CreateId,--最后修改人Id
   getdate(),--最后修改日期
   0,--删除标识
   @Remark--备注
)
select @StockId = @@IDENTITY;
if(@@ROWCOUNT<=0) begin select @errmsg=dbo.F_GetError('',2) RAISERROR(@errmsg,11,1) end--插入失败
