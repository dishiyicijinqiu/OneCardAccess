--IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'P_UserAuth')
--	BEGIN
--		DROP  Procedure  P_UserAuth
--	END
--GO
--CREATE PROCEDURE P_UserAuth
CREATE PROCEDURE P_UserAuth
(
	@UserId VARCHAR(36),
	@ActionNo VARCHAR(50),
	@IsAuth bit output
)
AS
select top 1 1 from T_Action where ActionNo=@ActionNo
if(@@ROWCOUNT<=0) 
begin 
	set @IsAuth=0 
	return -101--没有找到对应的权限
end
--检查是否为超级角色
select top 1 1 from T_UserInRole ur join T_Role r on ur.RoleId= r.RoleId and r.IsSuper=1  and ur.UserId=@UserId
if(@@ROWCOUNT>0)
begin
	set @IsAuth=1
	return 0;
end
--检查是否为超级角色
select top 1 1 from T_RoleAction where ActionNo=@ActionNo and RoleId in (
	select ur.RoleId from T_UserInRole ur join T_Role r on ur.RoleId= r.RoleId and r.IsLock=0 and r.Deleted=0 and ur.UserId=@UserId
)
if(@@ROWCOUNT>0)
begin
	set @IsAuth=1
	return 0;
end
else
begin
	set @IsAuth=0
	return 0;
end