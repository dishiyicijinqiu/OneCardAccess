CREATE PROCEDURE P_RoleUserFlow
--CREATE PROCEDURE P_RoleUserFlow
(
	@OP VARCHAR(20),
	@UserId VARCHAR(36),
	@RoleId VARCHAR(36),
	@Lock bit
)
AS
declare @errmsg varchar(max)
if @OP='removeuserfromrole'
begin
	delete from T_UserInRole where UserId=@UserId and RoleId=@RoleId;
	select 1 from T_Role r 
	join T_UserInRole ur on ur.RoleId = r.RoleId and r.IsSuper=1 
	if(@@ROWCOUNT<=0)
	begin
		select @errmsg=dbo.F_GetError('最后一个超级用户不可删除',0) 
		RAISERROR(@errmsg,11,1)
	end
end
else if @OP='addusertorole'
begin
	insert into T_UserInRole(UserId,RoleId) values(@UserId,@RoleId);
end
else if @OP='lockrole'
begin
	if(@Lock=0)
	begin
		select 1 from T_Role where RoleId=@RoleId and IsSuper=1
		if(@@ROWCOUNT>0) begin select @errmsg=dbo.F_GetError('超级角色不可禁用',0) RAISERROR(@errmsg,11,1) end
	end
	update T_Role set IsLock=@Lock where RoleId=@RoleId
	if(@@ROWCOUNT<=0)--角色状态更改失败
	begin select @errmsg=dbo.F_GetError('角色状态更改失败',0) RAISERROR(@errmsg,11,1) end
end
else if @OP='lockuser'
begin
	update T_User set IsLock=@Lock where UserId=@UserId
	if(@@ROWCOUNT<=0)--用户状态更改失败
	begin select @errmsg=dbo.F_GetError('用户状态更改失败',0) RAISERROR(@errmsg,11,1) end
	--检查超级用户数量，若为0则回滚
	select 1 from T_Role r 
		join T_UserInRole ur on ur.RoleId = r.RoleId and r.IsSuper=1 
		join T_User u on u.UserId = ur.UserId and u.Deleted=0
	if(@@ROWCOUNT<=0) 
	begin select @errmsg=dbo.F_GetError('最后一个超级用户不可删除',0) RAISERROR(@errmsg,11,1) end
end
else
begin
	select @errmsg=dbo.F_GetError('',5) RAISERROR(@errmsg,11,1)--方法未实现
end