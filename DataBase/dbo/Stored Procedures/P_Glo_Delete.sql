--CREATE PROCEDURE P_Glo_Delete;1
CREATE PROCEDURE P_Glo_Delete;1
(
	@cMode VARCHAR(50),
	@EntityId VARCHAR(100)
)
AS 
declare @errmsg varchar(max)
if @cMode = 'menu'
begin
	delete from T_Menu where MenuNo=@EntityId
	if(@@ROWCOUNT<=0)  begin select @errmsg=dbo.F_GetError('',6) RAISERROR(@errmsg,11,1) end--删除失败
end
else if @cMode = 'action'
begin
	delete from T_Action where ActionNo=@EntityId
	if(@@ROWCOUNT<=0)  begin select @errmsg=dbo.F_GetError('',6) RAISERROR(@errmsg,11,1) end--删除失败
end
else if @cMode = 'employee' --员工信息
begin
	--begin检查引用：
	--end检查引用：
	update T_Employee set Deleted=1 where EmpId=@EntityId
	if(@@ROWCOUNT<=0) begin select @errmsg=dbo.F_GetError('',6) RAISERROR(@errmsg,11,1) end--删除失败
end
else if @cMode = 'role' --角色信息
begin
	select top 1 1 from T_Role where RoleId=@EntityId and IsSuper=1 --检查是否是超级角色
	if(@@ROWCOUNT>0) begin select @errmsg=dbo.F_GetError('超级角色不可删除',0) RAISERROR(@errmsg,11,1) end --超级角色不可删除
	--begin检查引用：
	--检查用户是否引用
		select 1 from T_Role r join T_UserInRole ur
		on r.RoleId=ur.RoleId and r.RoleId=@EntityId and r.Deleted=0
		join T_User u on ur.UserId=u.UserId and u.Deleted=0
		if(@@ROWCOUNT>0) begin select @errmsg=dbo.F_GetError('',4) RAISERROR(@errmsg,11,1) end--正在使用
	--end检查引用：
	update T_Role set Deleted=1 where RoleId=@EntityId
	if(@@ROWCOUNT<=0)  begin select @errmsg=dbo.F_GetError('',6) RAISERROR(@errmsg,11,1) end--删除失败
end
else if @cMode = 'user' --用户信息
begin
	--begin检查引用：
	--end检查引用：
	update T_User set Deleted=1 where UserId=@EntityId
	if(@@ROWCOUNT<=0)  begin select @errmsg=dbo.F_GetError('',6) RAISERROR(@errmsg,11,1) end--删除失败
	--检查是否为最后一个超级用户
	select 1 from T_Role r 
		join T_UserInRole ur on ur.RoleId = r.RoleId and r.IsSuper=1 
		join T_User u on u.UserId = ur.UserId and u.Deleted=0 and u.UserId = @EntityId
	if(@@ROWCOUNT<=0) begin select @errmsg=dbo.F_GetError('最后一个超级用户不可删除',0) RAISERROR(@errmsg,11,1) end--最后一个超级用户不可删除
	--检查是否为最后一个超级用户
end
else if @cMode = 'register'
begin
	update T_Register set Deleted=1 where RegisterId=@EntityId
	--begin检查引用：
	--end检查引用：
	if(@@ROWCOUNT<=0)  begin select @errmsg=dbo.F_GetError('',6) RAISERROR(@errmsg,11,1) end--删除失败
end
else
begin
	select @errmsg=dbo.F_GetError('',5) RAISERROR(@errmsg,11,1)--方法未实现
end