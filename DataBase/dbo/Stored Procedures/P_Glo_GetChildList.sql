CREATE PROCEDURE P_Glo_GetChildList;1
--CREATE PROCEDURE P_Glo_GetChildList;1
(
	@cMode VARCHAR(50),
	@PId varchar(100)
)
AS 
begin
if @cMode = 'menu' --部门
select		*
from T_Menu
where PNo=@PId

else if @cMode = 'action' --部门
select		*
from T_Action
where ParentActionNo=@PId
else
begin
	declare @errmsg varchar(max)
	select @errmsg=dbo.F_GetError('',5) RAISERROR(@errmsg,11,1)--方法未实现
end
end