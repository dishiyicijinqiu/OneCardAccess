--CREATE PROCEDURE P_CreateRole
CREATE PROCEDURE P_CreateRole
(
	@RoleId VARCHAR(36) output,
	@RoleNo VARCHAR(50),
	@RoleName VARCHAR(50),
	@CreateId VARCHAR(36),
	@IsLock bit,
	@Remark varchar(100)
)
AS
declare @errmsg varchar(max)
select 1 from T_Role where RoleNo=@RoleNo and Deleted=0
if(@@ROWCOUNT>0) begin select @errmsg=dbo.F_GetError('',1) RAISERROR(@errmsg,11,1) end--存在相同的编号
set @RoleId = newid()
insert into T_Role(RoleId,RoleNo,RoleName,IsLock,IsSuper,Deleted,Remark,CreateId,CreateDate,LastModifyId,LastModifyDate)
values (@RoleId,@RoleNo,@RoleName,@IsLock,0,0,@Remark,@CreateId,getdate(),@CreateId,getdate())
if(@@ROWCOUNT<=0) begin select @errmsg=dbo.F_GetError('',2) RAISERROR(@errmsg,11,1) end--插入失败
