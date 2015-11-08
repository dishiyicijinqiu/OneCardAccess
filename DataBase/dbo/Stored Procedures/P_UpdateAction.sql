--CREATE PROCEDURE P_UpdateAction
CREATE PROCEDURE P_UpdateAction
(
	@OldActionNo varchar(50),
	@ActionNo varchar(50),
	@ActionName varchar(100),
	@ParentActionNo varchar(50),
	@Order int,
	@Remark varchar(200),
	@ActionType varchar(20)
)
AS

declare @errmsg varchar(max)
select 1 from T_Action where ActionNo=@ActionNo and ActionNo<>@OldActionNo
if(@@ROWCOUNT>0) begin select @errmsg=dbo.F_GetError('',1) RAISERROR(@errmsg,11,1) end--编号重复

update T_Action set 
ActionNo=@ActionNo,
ActionName=@ActionName,
ParentActionNo=@ParentActionNo,
[Order]=@Order,
ActionType=@ActionType,
Remark=@Remark
where ActionNo=@OldActionNo

if(@@ROWCOUNT<=0) begin select @errmsg=dbo.F_GetError('',3) RAISERROR(@errmsg,11,1) end--更新失败
