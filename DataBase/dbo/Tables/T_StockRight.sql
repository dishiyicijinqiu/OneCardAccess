CREATE TABLE [dbo].[T_StockRight] (
    [RoleId]  VARCHAR (36) NOT NULL,
    [StockId] INT          NOT NULL,
    CONSTRAINT [PK__T_StockRight__74CE504D] PRIMARY KEY CLUSTERED ([RoleId] ASC, [StockId] ASC)
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'仓库权限表', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'T_StockRight';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'角色Id', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'T_StockRight', @level2type = N'COLUMN', @level2name = N'RoleId';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'仓库Id', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'T_StockRight', @level2type = N'COLUMN', @level2name = N'StockId';

