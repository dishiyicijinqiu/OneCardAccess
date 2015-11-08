CREATE TABLE [dbo].[T_ProductSNInvent]
(
	[PSNInventId] VARCHAR(36) NOT NULL PRIMARY KEY, 
    [PBNInventId] VARCHAR(36) NOT NULL, 
    [PInventId] VARCHAR(36) NOT NULL, 
    [ProductId] INT NOT NULL, 
    [BN] VARCHAR(10) NOT NULL, 
    [StockId] INT NOT NULL, 
    [SN] VARCHAR(30) NOT NULL
)

GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'商品批号库存Id',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'T_ProductSNInvent',
    @level2type = N'COLUMN',
    @level2name = N'PBNInventId'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'商品序列号库存Id',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'T_ProductSNInvent',
    @level2type = N'COLUMN',
    @level2name = N'PSNInventId'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'商品库存Id',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'T_ProductSNInvent',
    @level2type = N'COLUMN',
    @level2name = N'PInventId'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'序列号',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'T_ProductSNInvent',
    @level2type = N'COLUMN',
    @level2name = N'SN'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'商品Id',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'T_ProductSNInvent',
    @level2type = N'COLUMN',
    @level2name = N'ProductId'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'批号',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'T_ProductSNInvent',
    @level2type = N'COLUMN',
    @level2name = N'BN'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'仓库Id',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'T_ProductSNInvent',
    @level2type = N'COLUMN',
    @level2name = N'StockId'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'商品序列号库存表',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'T_ProductSNInvent',
    @level2type = NULL,
    @level2name = NULL