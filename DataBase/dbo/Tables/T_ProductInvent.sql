CREATE TABLE [dbo].[T_ProductInvent]
(
	[PInventId] VARCHAR(36) NOT NULL PRIMARY KEY DEFAULT newid(), 
    [ProductId] INT NOT NULL, 
    [StockId] INT NOT NULL, 
    [Qty] NUMERIC(18, 4) NOT NULL, 
    [Price] NUMERIC(18, 4) NOT NULL, 
    [Total] NUMERIC(18, 4) NOT NULL
)

GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'商品库存Id',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'T_ProductInvent',
    @level2type = N'COLUMN',
    @level2name = N'PInventId'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'商品Id',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'T_ProductInvent',
    @level2type = N'COLUMN',
    @level2name = N'ProductId'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'仓库Id',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'T_ProductInvent',
    @level2type = N'COLUMN',
    @level2name = N'StockId'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'数量',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'T_ProductInvent',
    @level2type = N'COLUMN',
    @level2name = N'Qty'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'单价',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'T_ProductInvent',
    @level2type = N'COLUMN',
    @level2name = N'Price'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'金额',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'T_ProductInvent',
    @level2type = N'COLUMN',
    @level2name = N'Total'
GO

GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'商品库存表',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'T_ProductInvent',
    @level2type = NULL,
    @level2name = NULL