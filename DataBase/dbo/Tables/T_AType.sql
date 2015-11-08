CREATE TABLE [dbo].[T_AType]
(
	[ATypeId] INT NOT NULL PRIMARY KEY, 
    [ATypeNo] VARCHAR(26) NOT NULL, 
    [ATypeName] VARCHAR(66) NOT NULL, 
    [Total] NUMERIC(18, 4) NOT NULL, 
    [Remark] VARCHAR(256) NOT NULL, 
    [Level_Path] VARCHAR(1000) NOT NULL, 
    [Level_Num] INT NOT NULL, 
    [Level_Total] INT NOT NULL, 
    [Level_Deep] INT NOT NULL, 
    [PId] INT NOT NULL
)

GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'科目表',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'T_AType',
    @level2type = NULL,
    @level2name = NULL
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'科目表Id',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'T_AType',
    @level2type = N'COLUMN',
    @level2name = N'ATypeId'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'科目编号',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'T_AType',
    @level2type = N'COLUMN',
    @level2name = N'ATypeNo'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'科目名称',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'T_AType',
    @level2type = N'COLUMN',
    @level2name = N'ATypeName'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'金额',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'T_AType',
    @level2type = N'COLUMN',
    @level2name = N'Total'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'备注',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'T_AType',
    @level2type = N'COLUMN',
    @level2name = N'Remark'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'树形结构路径',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'T_AType',
    @level2type = N'COLUMN',
    @level2name = N'Level_Path'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'儿子数量',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'T_AType',
    @level2type = N'COLUMN',
    @level2name = N'Level_Num'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'子孙数量',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'T_AType',
    @level2type = N'COLUMN',
    @level2name = N'Level_Total'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'树的深度',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'T_AType',
    @level2type = N'COLUMN',
    @level2name = N'Level_Deep'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'父Id',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'T_AType',
    @level2type = N'COLUMN',
    @level2name = N'PId'