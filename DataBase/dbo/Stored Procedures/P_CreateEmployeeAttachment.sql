
--CREATE PROCEDURE P_CreateEmployeeAttachment
CREATE PROCEDURE P_CreateEmployeeAttachment
(
	@Id VARCHAR(36) output,
	@EmpId varchar(36),
	@SaveName varchar(50),
	@ShowName varchar(50)
)
AS
declare @errmsg varchar(max)
set @Id = newid();

insert into T_EmployeeAttachment(
   Id,--主键Id
   EmpId,--员工Id
   SaveName,--保存名称
   ShowName--显示名称
)
values(
   @Id,--主键Id
   @EmpId,--员工Id
   @SaveName,--保存名称
   @ShowName--显示名称
)
if(@@ROWCOUNT<=0) begin select @errmsg=dbo.F_GetError('',2) RAISERROR(@errmsg,11,1) end--插入失败
