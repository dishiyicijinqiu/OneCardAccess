CREATE PROCEDURE P_UpdateUser
--CREATE PROCEDURE P_UpdateUser
(
	@UserId varchar(36),
	@UserNo varchar(50),
	@UserName varchar(50),
	@IsLock bit,
	@Remark varchar(100),
	@LastModifyId varchar(36)
)
AS
declare @errmsg varchar(max)
select 1 from T_User where UserNo=@UserNo and UserId<>@UserId and Deleted=0
if(@@ROWCOUNT>0) begin select @errmsg=dbo.F_GetError('',1) RAISERROR(@errmsg,11,1) end--编号重复

update T_User set 
UserNo=@UserNo,
UserName=@UserName,
IsLock=@IsLock,
Remark=@Remark,
LastModifyId=@LastModifyId,
LastModifyDate=getdate()
where UserId=@UserId

if(@@ROWCOUNT<=0) begin select @errmsg=dbo.F_GetError('',3) RAISERROR(@errmsg,11,1) end--更新失败


if(@IsLock=1)
begin
--检查未被禁用且未被删除的超级用户数量，若为0则回滚
select 1 from T_Role r 
	join T_UserInRole ur on ur.RoleId = r.RoleId and r.IsSuper=1 
	join T_User u on u.UserId = ur.UserId and u.Deleted=0 and u.IsLock=0
if(@@ROWCOUNT<=0) begin select @errmsg=dbo.F_GetError('最后一个超级用户不可禁用',0) RAISERROR(@errmsg,11,1) end--最后一个超级用户不可禁用
--检查未被禁用且未被删除的超级用户数量，若为0则回滚
end
