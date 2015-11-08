CREATE TABLE [dbo].[T_RawMate] (
    [RawMateId]      INT             IDENTITY (1, 1) NOT NULL,
    [RawMateNo]      VARCHAR (50)    NOT NULL,
    [RawMateName]    VARCHAR (100)   NOT NULL,
    [Spec]           VARCHAR (50)    NOT NULL,
    [MinStore]       NUMERIC (18, 2) CONSTRAINT [DF_T_RawMate_MinStore] DEFAULT ((0)) NOT NULL,
    [MaxStore]       NUMERIC (18, 2) CONSTRAINT [DF_T_RawMate_MaxStore] DEFAULT ((0)) NOT NULL,
    [Unit]           VARCHAR (20)    NOT NULL,
    [IsRemind]       BIT             CONSTRAINT [DF_T_RawMate_IsRemind] DEFAULT ((0)) NOT NULL,
    [QtyMode]        SMALLINT        CONSTRAINT [DF_T_RawMate_QtyMode] DEFAULT ((0)) NOT NULL,
    [preprice1]      NUMERIC (18, 4) CONSTRAINT [DF_T_RawMate_preprice1] DEFAULT ((0)) NOT NULL,
    [preprice2]      NUMERIC (18, 4) CONSTRAINT [DF_T_RawMate_preprice2] DEFAULT ((0)) NOT NULL,
    [preprice3]      NUMERIC (18, 4) CONSTRAINT [DF_T_RawMate_preprice3] DEFAULT ((0)) NOT NULL,
    [recprice]       NUMERIC (18, 4) CONSTRAINT [DF_T_RawMate_price] DEFAULT ((0)) NOT NULL,
    [Remark1]        VARCHAR (500)   NOT NULL,
    [Remark2]        VARCHAR (500)   NOT NULL,
    [Remark3]        VARCHAR (500)   NOT NULL,
    [Remark4]        VARCHAR (500)   NOT NULL,
    [Deleted]        BIT             CONSTRAINT [DF_T_RawMate_Deleted] DEFAULT ((0)) NOT NULL,
    [PId]            INT             NOT NULL,
    [Level_Path]     VARCHAR (1000)  NOT NULL,
    [Level_Num]      INT             NOT NULL,
    [Level_Total]    INT             NOT NULL,
    [Level_Deep]     INT             NOT NULL,
    [CreateId]       VARCHAR (36)    NOT NULL,
    [CreateDate]     DATETIME        NOT NULL,
    [LastModifyId]   VARCHAR (36)    NOT NULL,
    [LastModifyDate] DATETIME        NOT NULL,
    CONSTRAINT [PK_T_RawMate] PRIMARY KEY CLUSTERED ([RawMateId] ASC)
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'原材料信息', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'T_RawMate';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'主键Id', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'T_RawMate', @level2type = N'COLUMN', @level2name = N'RawMateId';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'原材料编号', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'T_RawMate', @level2type = N'COLUMN', @level2name = N'RawMateNo';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'原材料名称', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'T_RawMate', @level2type = N'COLUMN', @level2name = N'RawMateName';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'规格型号', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'T_RawMate', @level2type = N'COLUMN', @level2name = N'Spec';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'最小库存', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'T_RawMate', @level2type = N'COLUMN', @level2name = N'MinStore';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'最大库存', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'T_RawMate', @level2type = N'COLUMN', @level2name = N'MaxStore';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'计量单位', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'T_RawMate', @level2type = N'COLUMN', @level2name = N'Unit';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'库存报警标识', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'T_RawMate', @level2type = N'COLUMN', @level2name = N'IsRemind';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'数量模式（0，通用模式，1严格管理序列号，2严格管理批号）', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'T_RawMate', @level2type = N'COLUMN', @level2name = N'QtyMode';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'预设价格1', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'T_RawMate', @level2type = N'COLUMN', @level2name = N'preprice1';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'预设价格2', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'T_RawMate', @level2type = N'COLUMN', @level2name = N'preprice2';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'预设价格3', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'T_RawMate', @level2type = N'COLUMN', @level2name = N'preprice3';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'最近价格', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'T_RawMate', @level2type = N'COLUMN', @level2name = N'recprice';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'备注1', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'T_RawMate', @level2type = N'COLUMN', @level2name = N'Remark1';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'备注2', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'T_RawMate', @level2type = N'COLUMN', @level2name = N'Remark2';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'备注3', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'T_RawMate', @level2type = N'COLUMN', @level2name = N'Remark3';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'备注4', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'T_RawMate', @level2type = N'COLUMN', @level2name = N'Remark4';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'删除标识', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'T_RawMate', @level2type = N'COLUMN', @level2name = N'Deleted';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'父Id', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'T_RawMate', @level2type = N'COLUMN', @level2name = N'PId';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'树形结构路径', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'T_RawMate', @level2type = N'COLUMN', @level2name = N'Level_Path';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'儿子数量', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'T_RawMate', @level2type = N'COLUMN', @level2name = N'Level_Num';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'子孙数量', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'T_RawMate', @level2type = N'COLUMN', @level2name = N'Level_Total';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'树的深度', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'T_RawMate', @level2type = N'COLUMN', @level2name = N'Level_Deep';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'创建人Id', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'T_RawMate', @level2type = N'COLUMN', @level2name = N'CreateId';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'创建日期', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'T_RawMate', @level2type = N'COLUMN', @level2name = N'CreateDate';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'最后更改人Id', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'T_RawMate', @level2type = N'COLUMN', @level2name = N'LastModifyId';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'最后更改日期', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'T_RawMate', @level2type = N'COLUMN', @level2name = N'LastModifyDate';

