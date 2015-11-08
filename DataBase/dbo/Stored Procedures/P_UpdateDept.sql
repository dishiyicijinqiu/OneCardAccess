
--Create PROCEDURE P_UpdateDept
CREATE PROCEDURE P_UpdateDept
(
	@DeptId int,
	@DeptNo VARCHAR(50),
	@DeptName VARCHAR(50),
	@Remark VARCHAR(200),
	@LastModifyId VARCHAR(36)
)
AS
declare @errmsg varchar(max)
select 1 from T_Dept where DeptNo=@DeptNo and DeptId<>@DeptId and Deleted=0
if(@@ROWCOUNT>0) begin select @errmsg=dbo.F_GetError('',1) RAISERROR(@errmsg,11,1) end--编号重复
update T_Dept 
set DeptNo=@DeptNo,
	DeptName=@DeptName,
	Remark=@Remark,
	LastModifyId=@LastModifyId,
	LastModifyDate=getdate()
	where DeptId=@DeptId
if(@@ROWCOUNT<=0) begin select @errmsg=dbo.F_GetError('',3) RAISERROR(@errmsg,11,1) end--更新失败
