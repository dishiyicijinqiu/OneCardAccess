CREATE TABLE [dbo].[T_ProductRight] (
    [RoleId]    VARCHAR (36) NOT NULL,
    [ProductId] INT          NOT NULL,
    CONSTRAINT [PK__T_ProductRight__6F1576F7] PRIMARY KEY CLUSTERED ([ProductId] ASC, [RoleId] ASC)
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'产品权限表', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'T_ProductRight';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'角色Id', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'T_ProductRight', @level2type = N'COLUMN', @level2name = N'RoleId';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'产品Id', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'T_ProductRight', @level2type = N'COLUMN', @level2name = N'ProductId';

