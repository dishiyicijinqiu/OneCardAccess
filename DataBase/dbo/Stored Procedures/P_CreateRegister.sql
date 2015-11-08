--CREATE PROCEDURE P_CreateRegister
CREATE PROCEDURE P_CreateRegister
(
	@RegisterId varchar(36) output,
	@RegisterNo varchar(100),
	@RegisterProductName varchar(100),
	@StandardCode varchar(100),
	@RegisterNo1 varchar(100),
	@RegisterProductName1 varchar(100),
	@StandardCode1 varchar(100),
	@RegisterFile varchar(50),
	@StartDate varchar(10),
	@EndDate varchar(10),
	@CreateId varchar(36),
	@Remark varchar(200)
)
AS
declare @errmsg varchar(max)
select 1 from T_Register where RegisterNo=@RegisterNo
if(@@ROWCOUNT>0) begin select @errmsg=dbo.F_GetError('',1) RAISERROR(@errmsg,11,1) end--存在相同的编号
select @RegisterId = newid();
insert into T_Register (
	RegisterId,--主键Id
	RegisterNo,--注册证编号
	RegisterProductName,--注册证名称
	StandardCode,--标准号
	RegisterNo1,--注册证编号(英文)
	RegisterProductName1,--注册证名称(英文)
	StandardCode1,--标准号(英文)
	RegisterFile,--注册证文件
	StartDate,--启用日期
	EndDate,--停用日期
	CreateId,--创建人Id
	CreateDate,--创建日期
	LastModifyId,--最后更改人Id
	LastModifyDate,--最后更改日期
	Remark,--备注
	Deleted--删除标识
)
values(
	@RegisterId,--主键Id
	@RegisterNo,--注册证编号
	@RegisterProductName,--注册证名称
	@StandardCode,--标准号
	@RegisterNo1,--注册证编号(英文)
	@RegisterProductName1,--注册证名称(英文)
	@StandardCode1,--标准号(英文)
	@RegisterFile,--注册证文件
	@StartDate,--启用日期
	@EndDate,--停用日期
	@CreateId,--创建人Id
	getdate(),--创建日期
	@CreateId,--最后更改人Id
	getdate(),--最后更改日期
	@Remark,--备注
	0--删除标识
);
if(@@ROWCOUNT<=0) begin select @errmsg=dbo.F_GetError('',2) RAISERROR(@errmsg,11,1) end--插入失败
