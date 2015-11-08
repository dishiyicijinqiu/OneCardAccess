CREATE PROCEDURE P_UpdateRegister
--CREATE PROCEDURE P_UpdateRegister
(
	@RegisterId varchar(36),
	@RegisterNo varchar(100),
	@RegisterProductName varchar(100),
	@StandardCode varchar(100),
	@RegisterNo1 varchar(100),
	@RegisterProductName1 varchar(100),
	@StandardCode1 varchar(100),
	@RegisterFile varchar(50),
	@StartDate varchar(10),
	@EndDate varchar(10),
	@LastModifyId varchar(36),
	@Remark varchar(200)
)
AS
declare @errmsg varchar(max)
select 1 from T_Register where RegisterNo=@RegisterNo and RegisterId<>@RegisterId and Deleted=0
if(@@ROWCOUNT>0) begin select @errmsg=dbo.F_GetError('',1) RAISERROR(@errmsg,11,1) end--编号重复
update T_Register set 
RegisterNo=@RegisterNo,
RegisterProductName=@RegisterProductName,
StandardCode=@StandardCode,
RegisterNo1=@RegisterNo1,
RegisterProductName1=@RegisterProductName1,
StandardCode1=@StandardCode1,
RegisterFile=@RegisterFile,
StartDate=@StartDate,
EndDate=@EndDate,
LastModifyId=@LastModifyId,
LastModifyDate=getdate(),
Remark=@Remark
where RegisterId=@RegisterId
if(@@ROWCOUNT<=0) begin select @errmsg=dbo.F_GetError('',3) RAISERROR(@errmsg,11,1) end--更新失败
