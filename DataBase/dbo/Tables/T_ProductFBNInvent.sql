CREATE TABLE [dbo].[T_ProductFBNInvent]
(
	[PFBNInventId] VARCHAR(36) NOT NULL PRIMARY KEY DEFAULT newid(), 
    [PBNInventId] VARCHAR(36) NOT NULL, 
    [PInventId] VARCHAR(36) NOT NULL, 
    [ProductId] INT NOT NULL, 
    [BN] VARCHAR(10) NOT NULL, 
    [StockId] INT NOT NULL, 
    [FBN] VARCHAR(10) NOT NULL, 
    [Qty] NUMERIC(18, 4) NOT NULL
)

GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'商品完整批号库存Id',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'T_ProductFBNInvent',
    @level2type = N'COLUMN',
    @level2name = N'PFBNInventId'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'商品完整批号库存表',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'T_ProductFBNInvent',
    @level2type = NULL,
    @level2name = NULL
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'商品批号库存Id',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'T_ProductFBNInvent',
    @level2type = N'COLUMN',
    @level2name = N'PBNInventId'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'商品库存Id',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'T_ProductFBNInvent',
    @level2type = N'COLUMN',
    @level2name = N'PInventId'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'商品Id',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'T_ProductFBNInvent',
    @level2type = N'COLUMN',
    @level2name = N'ProductId'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'批号',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'T_ProductFBNInvent',
    @level2type = N'COLUMN',
    @level2name = N'BN'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'仓库Id',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'T_ProductFBNInvent',
    @level2type = N'COLUMN',
    @level2name = N'StockId'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'完整批号',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'T_ProductFBNInvent',
    @level2type = N'COLUMN',
    @level2name = N'FBN'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'数量',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'T_ProductFBNInvent',
    @level2type = N'COLUMN',
    @level2name = N'Qty'