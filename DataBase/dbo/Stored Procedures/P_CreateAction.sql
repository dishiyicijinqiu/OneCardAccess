--CREATE PROCEDURE P_CreateAction
CREATE PROCEDURE P_CreateAction
(
	@ActionNo varchar(50),
	@ActionName varchar(100),
	@ParentActionNo varchar(50),
	@Order int,
	@Remark varchar(200),
	@ActionType varchar(20)
)
AS
declare @errmsg varchar(max)
select 1 from T_Action where ActionNo=@ActionNo
if(@@ROWCOUNT>0) begin select @errmsg=dbo.F_GetError('',1) RAISERROR(@errmsg,11,1) end--存在相同的编号

insert into T_Action (
   ActionNo,--功能编号
   ActionName,--功能名称
   ParentActionNo,--父级编号
   [Order],--序号
   ActionType,--类型
   Remark--备注
)
values(
   @ActionNo,--功能编号
   @ActionName,--功能名称
   @ParentActionNo,--父级编号
   @Order,--序号
   @ActionType,--类型
   @Remark--备注
);
if(@@ROWCOUNT<=0) begin select @errmsg=dbo.F_GetError('',2) RAISERROR(@errmsg,11,1) end--插入失败
