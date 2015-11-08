--CREATE PROCEDURE P_Glo_DeleteRelationData;1
CREATE PROCEDURE P_Glo_DeleteRelationData;1
(
	@cMode VARCHAR(50),
	@EntityId VARCHAR(100)
)
AS 
if @cMode = 'employeeattachment' --员工附件
begin
	delete from T_EmployeeAttachment where EmpId=@EntityId
end
else if @cMode = 'registerattach' --员工附件
begin
	delete from T_RegisterAttachment where RegisterId=@EntityId
end
else if(@cMode='roleaction')
delete from T_RoleAction where RoleId=@EntityId;
else if(@cMode='rolemenu')
delete from T_RoleMenu where RoleId=@EntityId
else if(@cMode='roleuser')
delete from T_UserInRole
where UserId in (select UserId from T_UserInRole where RoleId=@EntityId)
else
begin
	declare @errmsg varchar(max)
	select @errmsg=dbo.F_GetError('',5) RAISERROR(@errmsg,11,1)--方法未实现
end