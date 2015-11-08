CREATE TABLE [dbo].[T_ProductDlyBak]
(
	[PDlyBakId] VARCHAR(36) NOT NULL PRIMARY KEY DEFAULT newid(), 
    [DlyNdxId] VARCHAR(36) NOT NULL, 
    [ATypeId] INT NOT NULL, 
    [CompanyId] INT NOT NULL, 
    [DlyType] SMALLINT NOT NULL, 
    [DlyDate] VARCHAR(10) NOT NULL, 
    [JSRId] INT NOT NULL, 
    [StockId1] INT NOT NULL, 
    [StockId2] INT NOT NULL, 
    [ProductId] INT NOT NULL, 
    [BN] VARCHAR(10) NOT NULL, 
    [Qty] NUMERIC(18, 4) NOT NULL, 
    [CostPrice] FLOAT NOT NULL, 
    [CostTotal] NUMERIC(18, 4) NOT NULL, 
    [Price] FLOAT NOT NULL, 
    [Total] NUMERIC(18, 4) NOT NULL, 
    [DisCount] NUMERIC(3, 2) NOT NULL , 
    [DisPrice] FLOAT NOT NULL, 
    [DisTotal] NUMERIC(18, 4) NOT NULL, 
    [TaxRate] NUMERIC(18, 4) NOT NULL, 
    [Tax] NUMERIC(18, 4) NOT NULL, 
    [TaxPrice] FLOAT NOT NULL, 
    [TaxTotal] NUMERIC(18, 4) NOT NULL, 
    [RetailPrice] FLOAT NOT NULL, 
    [InvoceTotal] NUMERIC(18, 4) NOT NULL, 
    [Remark] VARCHAR(50) NOT NULL, 
    [C_OrderNdxId] VARCHAR(36) NOT NULL, 
    [C_ProductOrderId] VARCHAR(36) NOT NULL
)

GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'商品单据草稿',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'T_ProductDlyBak',
    @level2type = NULL,
    @level2name = NULL
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'主键Id',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'T_ProductDlyBak',
    @level2type = N'COLUMN',
    @level2name = N'PDlyBakId'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'单据索引表Id',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'T_ProductDlyBak',
    @level2type = N'COLUMN',
    @level2name = 'DlyNdxId'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'科目表Id',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'T_ProductDlyBak',
    @level2type = N'COLUMN',
    @level2name = 'ATypeId'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'往来单位Id',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'T_ProductDlyBak',
    @level2type = N'COLUMN',
    @level2name = N'CompanyId'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'单据类型',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'T_ProductDlyBak',
    @level2type = N'COLUMN',
    @level2name = N'DlyType'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'单据日期',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'T_ProductDlyBak',
    @level2type = N'COLUMN',
    @level2name = N'DlyDate'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'经手人Id，员工Id',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'T_ProductDlyBak',
    @level2type = N'COLUMN',
    @level2name = N'JSRId'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'仓库Id1',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'T_ProductDlyBak',
    @level2type = N'COLUMN',
    @level2name = N'StockId1'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'仓库Id2',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'T_ProductDlyBak',
    @level2type = N'COLUMN',
    @level2name = N'StockId2'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'商品Id',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'T_ProductDlyBak',
    @level2type = N'COLUMN',
    @level2name = N'ProductId'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'批号',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'T_ProductDlyBak',
    @level2type = N'COLUMN',
    @level2name = N'BN'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'数量',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'T_ProductDlyBak',
    @level2type = N'COLUMN',
    @level2name = N'Qty'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'单价',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'T_ProductDlyBak',
    @level2type = N'COLUMN',
    @level2name = N'Price'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'金额',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'T_ProductDlyBak',
    @level2type = N'COLUMN',
    @level2name = N'Total'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'折扣(--)',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'T_ProductDlyBak',
    @level2type = N'COLUMN',
    @level2name = N'DisCount'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'折后单价 单价*折扣(--)',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'T_ProductDlyBak',
    @level2type = N'COLUMN',
    @level2name = N'DisPrice'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'折后金额 金额*折扣(--)',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'T_ProductDlyBak',
    @level2type = N'COLUMN',
    @level2name = N'DisTotal'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'税率(%?)(--)',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'T_ProductDlyBak',
    @level2type = N'COLUMN',
    @level2name = 'TaxRate'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'税额  折后金额*税率(--)',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'T_ProductDlyBak',
    @level2type = N'COLUMN',
    @level2name = 'Tax'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'含税单价 折后单价+(折后单价*税率)(--)',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'T_ProductDlyBak',
    @level2type = N'COLUMN',
    @level2name = N'TaxPrice'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'含税金额 折后金额+税额(--)',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'T_ProductDlyBak',
    @level2type = N'COLUMN',
    @level2name = N'TaxTotal'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'零售价格(--)',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'T_ProductDlyBak',
    @level2type = N'COLUMN',
    @level2name = N'RetailPrice'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'开票金额(--)',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'T_ProductDlyBak',
    @level2type = N'COLUMN',
    @level2name = N'InvoceTotal'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'成本金额',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'T_ProductDlyBak',
    @level2type = N'COLUMN',
    @level2name = N'CostTotal'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'成本单价',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'T_ProductDlyBak',
    @level2type = N'COLUMN',
    @level2name = N'CostPrice'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'备注',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'T_ProductDlyBak',
    @level2type = N'COLUMN',
    @level2name = N'Remark'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'订单索引表Id',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'T_ProductDlyBak',
    @level2type = N'COLUMN',
    @level2name = N'C_OrderNdxId'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'商品订单Id',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'T_ProductDlyBak',
    @level2type = N'COLUMN',
    @level2name = N'C_ProductOrderId'