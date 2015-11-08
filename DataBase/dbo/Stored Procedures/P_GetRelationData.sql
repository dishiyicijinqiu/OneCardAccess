--CREATE PROCEDURE P_Glo_GetRelationData;1
CREATE PROCEDURE P_Glo_GetRelationData;1
(
	@cMode VARCHAR(50),
	@EntityId VARCHAR(36)
)
AS
if(@cMode='roleaction')
select		 RoleId
			,ActionNo
from T_RoleAction
where RoleId=@EntityId
else if(@cMode='rolemenu')
select		 RoleId
			,MenuNo
from T_RoleMenu
where RoleId=@EntityId
else if(@cMode='usermenu')
begin
if(exists(select 1 from T_Role
where IsSuper=1 and RoleId in 
(select RoleId from T_UserInRole ur join T_User u on ur.UserId=u.UserId and u.Deleted=0 and u.IsLock=0 and ur.UserId=@EntityId)))
select MenuNo from T_Menu
else
select MenuNo from T_RoleMenu where RoleId in (
select ur.RoleId from T_UserInRole ur join T_User u on ur.UserId=u.UserId and u.Deleted=0 and u.IsLock=0
join T_Role r on ur.RoleId = r.RoleId where u.UserId = @EntityId
)
end
else if(@cMode='roleuser')
select		 UserId
			,UserNo
			,UserName
			,UserPassWord
			,IsLock
			,Deleted
			,Remark
			,CreateId
			,CreateDate
			,LastModifyId
			,LastModifyDate
			,IsUserAuthority
from T_User
where UserId in (select UserId from T_UserInRole where RoleId=@EntityId) and Deleted=0 and IsLock=0
order by UserNo
else if(@cMode='employeeattach')
select * from T_EmployeeAttachment where EmpId=@EntityId order by ShowName;
else if(@cMode='registerattach')
select * from T_RegisterAttachment where RegisterId=@EntityId order by ShowName;
else
begin
	declare @errmsg varchar(max)
	if(@@ROWCOUNT>0) begin select @errmsg=dbo.F_GetError('',5) RAISERROR(@errmsg,11,1) end--查询方法未实现
end