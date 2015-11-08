CREATE TABLE [dbo].[T_Menu] (
    [MenuNo]      VARCHAR (100) NOT NULL,
    [PNo]         VARCHAR (100) NOT NULL,
    [MenuName]    VARCHAR (100) NOT NULL,
    [Order]       INT           CONSTRAINT [DF__T_Menu__Order__25518C17] DEFAULT ((-1)) NOT NULL,
    [Glyph]       VARCHAR (200) NOT NULL,
    [OnClick]     VARCHAR (200) NOT NULL,
    [KeyTip]      VARCHAR (30)  NOT NULL,
    [MenuControl] VARCHAR (20)  NOT NULL,
    CONSTRAINT [PK__T_Menu__245D67DE] PRIMARY KEY CLUSTERED ([MenuNo] ASC)
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'系统菜单表', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'T_Menu';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'菜单编号', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'T_Menu', @level2type = N'COLUMN', @level2name = N'MenuNo';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'父级菜单编号', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'T_Menu', @level2type = N'COLUMN', @level2name = N'PNo';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'菜单名称', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'T_Menu', @level2type = N'COLUMN', @level2name = N'MenuName';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'菜单序号', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'T_Menu', @level2type = N'COLUMN', @level2name = N'Order';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'显示图像', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'T_Menu', @level2type = N'COLUMN', @level2name = N'Glyph';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'点击事件', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'T_Menu', @level2type = N'COLUMN', @level2name = N'OnClick';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'提示', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'T_Menu', @level2type = N'COLUMN', @level2name = N'KeyTip';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'菜单编程控件', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'T_Menu', @level2type = N'COLUMN', @level2name = N'MenuControl';

