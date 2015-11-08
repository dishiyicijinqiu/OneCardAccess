CREATE TABLE [dbo].[T_ProductRightTemp] (
    [RoleId]    VARCHAR (36) NOT NULL,
    [ProductId] INT          NOT NULL,
    [Flag]      VARCHAR (36) NOT NULL
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'角色Id', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'T_ProductRightTemp', @level2type = N'COLUMN', @level2name = N'RoleId';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'产品Id', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'T_ProductRightTemp', @level2type = N'COLUMN', @level2name = N'ProductId';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'状态标识', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'T_ProductRightTemp', @level2type = N'COLUMN', @level2name = N'Flag';

