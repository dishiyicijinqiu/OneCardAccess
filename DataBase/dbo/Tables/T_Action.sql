CREATE TABLE [dbo].[T_Action] (
    [ActionNo]       VARCHAR (100) NOT NULL,
    [ActionName]     VARCHAR (100) NOT NULL,
    [ParentActionNo] VARCHAR (100) NOT NULL,
    [Order]          INT           NOT NULL,
    [ActionType]     VARCHAR (20)  NOT NULL,
    [Remark]         VARCHAR (200) NOT NULL,
    CONSTRAINT [PK__T_Action__3A4CA8FD] PRIMARY KEY CLUSTERED ([ActionNo] ASC)
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'功能表', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'T_Action';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'功能编号', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'T_Action', @level2type = N'COLUMN', @level2name = N'ActionNo';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'功能名称', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'T_Action', @level2type = N'COLUMN', @level2name = N'ActionName';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'父级编号', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'T_Action', @level2type = N'COLUMN', @level2name = N'ParentActionNo';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'序号', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'T_Action', @level2type = N'COLUMN', @level2name = N'Order';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'类型', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'T_Action', @level2type = N'COLUMN', @level2name = N'ActionType';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'备注', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'T_Action', @level2type = N'COLUMN', @level2name = N'Remark';

