CREATE TABLE [dbo].[T_ProductInOutDetails]
(
	[PInOutDetailId] VARCHAR(36) NOT NULL PRIMARY KEY DEFAULT newid(), 
    [DlyNdxId] VARCHAR(36) NOT NULL, 
    [PDlyId] VARCHAR(36) NOT NULL,
    [ProductId] INT NOT NULL, 
    [BN] VARCHAR(10) NOT NULL, 
    [StockId] INT NOT NULL, 
    [InOutDate] VARCHAR(10) NOT NULL, 
    [Qty] NUMERIC(18, 4) NOT NULL, 
    [Price] FLOAT NOT NULL, 
    [Total] NUMERIC(18, 4) NOT NULL, 
    [Remark] VARCHAR(50) NOT NULL
)

GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'主键Id',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'T_ProductInOutDetails',
    @level2type = N'COLUMN',
    @level2name = 'PInOutDetailId'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'商品Id',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'T_ProductInOutDetails',
    @level2type = N'COLUMN',
    @level2name = N'ProductId'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'仓库Id',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'T_ProductInOutDetails',
    @level2type = N'COLUMN',
    @level2name = N'StockId'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'出入库日期',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'T_ProductInOutDetails',
    @level2type = N'COLUMN',
    @level2name = N'InOutDate'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'批号',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'T_ProductInOutDetails',
    @level2type = N'COLUMN',
    @level2name = N'BN'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'数量',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'T_ProductInOutDetails',
    @level2type = N'COLUMN',
    @level2name = N'Qty'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'单价',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'T_ProductInOutDetails',
    @level2type = N'COLUMN',
    @level2name = N'Price'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'金额',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'T_ProductInOutDetails',
    @level2type = N'COLUMN',
    @level2name = N'Total'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'单据索引表Id',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'T_ProductInOutDetails',
    @level2type = N'COLUMN',
    @level2name = N'DlyNdxId'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'商品单据表Id',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'T_ProductInOutDetails',
    @level2type = N'COLUMN',
    @level2name = N'PDlyId'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'商品出入库明细表',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'T_ProductInOutDetails',
    @level2type = NULL,
    @level2name = NULL
GO

GO

GO

EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'备注',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'T_ProductInOutDetails',
    @level2type = N'COLUMN',
    @level2name = N'Remark'