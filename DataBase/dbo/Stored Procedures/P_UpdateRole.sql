CREATE PROCEDURE P_UpdateRole
--CREATE PROCEDURE P_UpdateRole
(
	@RoleId VARCHAR(36),
	@RoleNo VARCHAR(50),
	@RoleName VARCHAR(50),
	@LastModifyId VARCHAR(36),
	@IsLock bit,
	@Remark varchar(100)
)
AS
declare @errmsg varchar(max)
select 1 from T_Role where RoleId=@RoleId and IsSuper=1
if(@@ROWCOUNT>0) begin select @errmsg=dbo.F_GetError('超级角色不可更改',0) RAISERROR(@errmsg,11,1) end--超级角色不可更改

select 1 from T_Role where RoleNo=@RoleNo and Roleid<>@RoleId and Deleted=0
if(@@ROWCOUNT>0) begin select @errmsg=dbo.F_GetError('',1) RAISERROR(@errmsg,11,1) end--编号重复

update T_Role set 
RoleNo=@RoleNo,
RoleName=@RoleName,
LastModifyId=@LastModifyId,
LastModifyDate=getdate(),
IsLock=@IsLock,
Remark=@Remark
where RoleId=@RoleId
if(@@ROWCOUNT<=0) begin select @errmsg=dbo.F_GetError('',3) RAISERROR(@errmsg,11,1) end--更新失败
