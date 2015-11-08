--CREATE PROCEDURE P_UpdateMenu
CREATE PROCEDURE P_UpdateMenu
(
	@OldMenuNo varchar(100),
	@MenuNo varchar(100),
	@PNo varchar(100),
	@MenuName varchar(100),
	@Order int,
	@Glyph varchar(200),
	@OnClick varchar(200),
	@KeyTip varchar(30),
	@MenuControl varchar(20)
)
AS
declare @errmsg varchar(max)
select 1 from T_Menu where MenuNo=@MenuNo and MenuNo<>@OldMenuNo
if(@@ROWCOUNT>0) begin select @errmsg=dbo.F_GetError('',1) RAISERROR(@errmsg,11,1) end--编号重复

update T_Menu set 
MenuNo=@OldMenuNo,
PNo=@PNo,
MenuName=@MenuName,
[Order]=@Order,
Glyph=@Glyph,
OnClick=@OnClick,
KeyTip=@KeyTip,
MenuControl=@MenuControl
where MenuNo=@OldMenuNo

if(@@ROWCOUNT<=0) begin select @errmsg=dbo.F_GetError('',3) RAISERROR(@errmsg,11,1) end--更新失败
