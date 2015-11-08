--CREATE PROCEDURE P_CreateMenu
CREATE PROCEDURE P_CreateMenu
(
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
select 1 from T_Menu where MenuNo=@MenuNo
if(@@ROWCOUNT>0) begin select @errmsg=dbo.F_GetError('',1) RAISERROR(@errmsg,11,1) end--存在相同的编号

insert into T_Menu (
   MenuNo,--菜单编号
   PNo,--父级菜单编号
   MenuName,--菜单名称
   [Order],--菜单序号
   Glyph,--显示图像
   OnClick,--点击事件
   KeyTip,--提示
   MenuControl--菜单编程控件
)
values(
   @MenuNo,--菜单编号
   @PNo,--父级菜单编号
   @MenuName,--菜单名称
   @Order,--菜单序号
   @Glyph,--显示图像
   @OnClick,--点击事件
   @KeyTip,--提示
   @MenuControl--菜单编程控件
)
if(@@ROWCOUNT<=0) begin select @errmsg=dbo.F_GetError('',2) RAISERROR(@errmsg,11,1) end--插入失败
