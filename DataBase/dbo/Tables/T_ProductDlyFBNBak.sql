CREATE TABLE [dbo].[T_ProductDlyFBNBak]
(
	[PDlyFBNBakId] VARCHAR(36) NOT NULL PRIMARY KEY DEFAULT newid(), 
    [DlyNdxId] VARCHAR(36) NOT NULL, 
    [ATypeId] INT NOT NULL, 
    [PDlyBakId] VARCHAR(36) NOT NULL, 
    [ProductId] INT NOT NULL, 
    [CompanyId] INT NOT NULL, 
    [StockId1] INT NOT NULL, 
    [StockId2] INT NOT NULL, 
    [JSRId] INT NOT NULL, 
    [FullBN] VARCHAR(30) NOT NULL, 
    [Remark] VARCHAR(50) NOT NULL, 
    [DlyDate] VARCHAR(10) NOT NULL, 
    [Qty] NUMERIC(18, 4) NOT NULL, 
    [C_OrderNdxId] VARCHAR(36) NOT NULL, 
    [C_ProductOrderId] VARCHAR(36) NOT NULL, 
    [DlyType] SMALLINT NOT NULL
)

GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'商品单据草稿批号备份',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'T_ProductDlyFBNBak',
    @level2type = NULL,
    @level2name = NULL
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'主键Id',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'T_ProductDlyFBNBak',
    @level2type = N'COLUMN',
    @level2name = N'PDlyFBNBakId'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'单据索引表Id',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'T_ProductDlyFBNBak',
    @level2type = N'COLUMN',
    @level2name = 'DlyNdxId'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'商品单据草稿Id',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'T_ProductDlyFBNBak',
    @level2type = N'COLUMN',
    @level2name = N'PDlyBakId'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'商品Id',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'T_ProductDlyFBNBak',
    @level2type = N'COLUMN',
    @level2name = N'ProductId'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'往来单位Id',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'T_ProductDlyFBNBak',
    @level2type = N'COLUMN',
    @level2name = N'CompanyId'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'仓库Id1',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'T_ProductDlyFBNBak',
    @level2type = N'COLUMN',
    @level2name = N'StockId1'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'仓库Id2',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'T_ProductDlyFBNBak',
    @level2type = N'COLUMN',
    @level2name = N'StockId2'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'经手人Id，员工Id',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'T_ProductDlyFBNBak',
    @level2type = N'COLUMN',
    @level2name = N'JSRId'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'完整批号',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'T_ProductDlyFBNBak',
    @level2type = N'COLUMN',
    @level2name = N'FullBN'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'备注',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'T_ProductDlyFBNBak',
    @level2type = N'COLUMN',
    @level2name = N'Remark'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'单据日期',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'T_ProductDlyFBNBak',
    @level2type = N'COLUMN',
    @level2name = N'DlyDate'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'数量',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'T_ProductDlyFBNBak',
    @level2type = N'COLUMN',
    @level2name = N'Qty'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'订单索引表Id',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'T_ProductDlyFBNBak',
    @level2type = N'COLUMN',
    @level2name = N'C_OrderNdxId'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'商品订单Id',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'T_ProductDlyFBNBak',
    @level2type = N'COLUMN',
    @level2name = N'C_ProductOrderId'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'科目表Id',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'T_ProductDlyFBNBak',
    @level2type = N'COLUMN',
    @level2name = 'ATypeId'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'单据类型',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'T_ProductDlyFBNBak',
    @level2type = N'COLUMN',
    @level2name = N'DlyType'