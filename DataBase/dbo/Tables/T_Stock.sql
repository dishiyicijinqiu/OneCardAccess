CREATE TABLE [dbo].[T_Stock] (
    [StockId]        INT           IDENTITY (1, 1) NOT NULL,
    [StockNo]        VARCHAR (50)  NOT NULL,
    [StockName]      VARCHAR (100) NOT NULL,
    [CreateId]       VARCHAR (36)  NOT NULL,
    [CreateDate]     DATETIME      NOT NULL,
    [LastModifyId]   VARCHAR (36)  NOT NULL,
    [LastModifyDate] DATETIME      NOT NULL,
    [Deleted]        BIT           DEFAULT ((0)) NOT NULL,
    [Remark]         VARCHAR (200) NOT NULL,
    PRIMARY KEY CLUSTERED ([StockId] ASC)
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'仓库表', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'T_Stock';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'主键Id', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'T_Stock', @level2type = N'COLUMN', @level2name = N'StockId';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'仓库编号', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'T_Stock', @level2type = N'COLUMN', @level2name = N'StockNo';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'仓库名称', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'T_Stock', @level2type = N'COLUMN', @level2name = N'StockName';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'创建人Id', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'T_Stock', @level2type = N'COLUMN', @level2name = N'CreateId';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'创建日期', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'T_Stock', @level2type = N'COLUMN', @level2name = N'CreateDate';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'最后修改人Id', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'T_Stock', @level2type = N'COLUMN', @level2name = N'LastModifyId';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'最后修改日期', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'T_Stock', @level2type = N'COLUMN', @level2name = N'LastModifyDate';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'删除标识', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'T_Stock', @level2type = N'COLUMN', @level2name = N'Deleted';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'备注', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'T_Stock', @level2type = N'COLUMN', @level2name = N'Remark';

