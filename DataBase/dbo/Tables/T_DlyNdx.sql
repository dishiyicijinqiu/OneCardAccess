CREATE TABLE [dbo].[T_DlyNdx] (
    [DlyNdxId] VARCHAR (36) NOT NULL DEFAULT newid(),
    [DlyNo] VARCHAR(30) NOT NULL, 
    [DlyType] SMALLINT NOT NULL, 
    [DlyDate] VARCHAR(10) NOT NULL, 
    [CompanyId] INT NOT NULL, 
    [JSRId] INT NOT NULL, 
    [StockId1] INT NOT NULL, 
    [StockId2] INT NOT NULL, 
    [Draft] SMALLINT NOT NULL, 
    [Summary] VARCHAR(256) NOT NULL, 
    [Comment] VARCHAR(256) NOT NULL, 
    [ZDRId] VARCHAR(36) NOT NULL, 
    [SHRId1] VARCHAR(36) NOT NULL, 
    [SHRId2] VARCHAR(36) NOT NULL, 
    [SHRId3] VARCHAR(36) NOT NULL, 
    [SHRId4] VARCHAR(36) NOT NULL, 
    [SHRId5] VARCHAR(36) NOT NULL, 
    [IsInvoce] NCHAR(10) NOT NULL, 
    [Total] NUMERIC(18, 4) NOT NULL, 
    [QGNo] VARCHAR(36) NOT NULL, 
    [QGDate] VARCHAR(10) NOT NULL, 
    [QGR] VARCHAR(10) NOT NULL, 
    [YDJNo] VARCHAR(36) NOT NULL, 
    [BuyDate] VARCHAR(10) NOT NULL, 
    [Buyer] VARCHAR(10) NOT NULL, 
    [LXR] VARCHAR(10) NOT NULL, 
    [LXFS] VARCHAR(20) NOT NULL, 
    CONSTRAINT [PK_T_DLYNDX] PRIMARY KEY CLUSTERED ([DlyNdxId] ASC)
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = '单据索引表', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'T_DlyNdx';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = '单据索引表Id', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'T_DlyNdx', @level2type = N'COLUMN', @level2name = 'DlyNdxId';


GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'单据类型',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'T_DlyNdx',
    @level2type = N'COLUMN',
    @level2name = N'DlyType'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'单据日期',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'T_DlyNdx',
    @level2type = N'COLUMN',
    @level2name = N'DlyDate'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'往来单位Id',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'T_DlyNdx',
    @level2type = N'COLUMN',
    @level2name = N'CompanyId'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'经手人Id，员工Id',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'T_DlyNdx',
    @level2type = N'COLUMN',
    @level2name = N'JSRId'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'仓库Id1',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'T_DlyNdx',
    @level2type = N'COLUMN',
    @level2name = N'StockId1'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'仓库Id2',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'T_DlyNdx',
    @level2type = N'COLUMN',
    @level2name = N'StockId2'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'制单人Id,系统用户Id',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'T_DlyNdx',
    @level2type = N'COLUMN',
    @level2name = N'ZDRId'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'一级审核人,系统用户Id',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'T_DlyNdx',
    @level2type = N'COLUMN',
    @level2name = N'SHRId1'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'金额',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'T_DlyNdx',
    @level2type = N'COLUMN',
    @level2name = N'Total'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'联系方式',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'T_DlyNdx',
    @level2type = N'COLUMN',
    @level2name = N'LXFS'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'联系人',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'T_DlyNdx',
    @level2type = N'COLUMN',
    @level2name = N'LXR'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'购买人',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'T_DlyNdx',
    @level2type = N'COLUMN',
    @level2name = N'Buyer'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'购买日期',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'T_DlyNdx',
    @level2type = N'COLUMN',
    @level2name = N'BuyDate'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'原单据号',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'T_DlyNdx',
    @level2type = N'COLUMN',
    @level2name = N'YDJNo'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'请购单号',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'T_DlyNdx',
    @level2type = N'COLUMN',
    @level2name = N'QGNo'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'请购日期',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'T_DlyNdx',
    @level2type = N'COLUMN',
    @level2name = N'QGDate'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'请购人',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'T_DlyNdx',
    @level2type = N'COLUMN',
    @level2name = N'QGR'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'(是否过账0为草稿，1为过账,2被红冲标记，3红冲标记,4临时单据)',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'T_DlyNdx',
    @level2type = N'COLUMN',
    @level2name = N'Draft'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'摘要',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'T_DlyNdx',
    @level2type = N'COLUMN',
    @level2name = N'Summary'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'附加说明',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'T_DlyNdx',
    @level2type = N'COLUMN',
    @level2name = N'Comment'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'二级审核人,系统用户Id',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'T_DlyNdx',
    @level2type = N'COLUMN',
    @level2name = N'SHRId2'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'三级审核人,系统用户Id',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'T_DlyNdx',
    @level2type = N'COLUMN',
    @level2name = N'SHRId3'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'四级审核人,系统用户Id',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'T_DlyNdx',
    @level2type = N'COLUMN',
    @level2name = N'SHRId4'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'五级审核人,系统用户Id',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'T_DlyNdx',
    @level2type = N'COLUMN',
    @level2name = N'SHRId5'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'是否开票',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'T_DlyNdx',
    @level2type = N'COLUMN',
    @level2name = N'IsInvoce'