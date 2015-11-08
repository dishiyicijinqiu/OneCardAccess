CREATE TABLE [dbo].[T_StockRightTemp] (
    [RoleId]  VARCHAR (36) NOT NULL,
    [StockId] INT          NOT NULL,
    [Flag]    VARCHAR (36) NOT NULL
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'仓库权限临时数据', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'T_StockRightTemp';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'角色Id', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'T_StockRightTemp', @level2type = N'COLUMN', @level2name = N'RoleId';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'仓库Id', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'T_StockRightTemp', @level2type = N'COLUMN', @level2name = N'StockId';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'状态标识', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'T_StockRightTemp', @level2type = N'COLUMN', @level2name = N'Flag';

