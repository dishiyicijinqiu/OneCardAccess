CREATE TABLE [dbo].[T_Product_TechStep] (
    [Id]               VARCHAR (36)    DEFAULT (newid()) NOT NULL,
    [ProductId]        INT             NOT NULL,
    [DrawingId]        INT             NOT NULL,
    [TechId]           INT             NOT NULL,
    [TechStepId]       INT             NOT NULL,
    [Runtime]          NUMERIC (18, 2) NULL,
    [AvgRunTime]       NUMERIC (18, 2) NULL,
    [Wage]             NUMERIC (18, 2) NULL,
    [IsSelect]         BIT             NOT NULL,
    [IsContinue]       BIT             NOT NULL,
    [Remark]           TEXT            NULL,
    [CreateUserId]     INT             NOT NULL,
    [CreateDate]       DATETIME        NOT NULL,
    [LastModifyUserId] INT             NOT NULL,
    [LastModifyDate]   DATETIME        NOT NULL,
    [Deleted]          BIT             CONSTRAINT [DF_T_Product_TechStep_Deleted] DEFAULT ((0)) NOT NULL,
    CONSTRAINT [PK_Base_Product_TechStep] PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'产品Id', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'T_Product_TechStep', @level2type = N'COLUMN', @level2name = N'ProductId';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'图纸Id', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'T_Product_TechStep', @level2type = N'COLUMN', @level2name = N'DrawingId';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'工艺文件Id', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'T_Product_TechStep', @level2type = N'COLUMN', @level2name = N'TechId';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'工艺步骤Id，顺序', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'T_Product_TechStep', @level2type = N'COLUMN', @level2name = N'TechStepId';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'预设时长', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'T_Product_TechStep', @level2type = N'COLUMN', @level2name = N'Runtime';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'平均时长', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'T_Product_TechStep', @level2type = N'COLUMN', @level2name = N'AvgRunTime';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'工价', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'T_Product_TechStep', @level2type = N'COLUMN', @level2name = N'Wage';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'是否选择', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'T_Product_TechStep', @level2type = N'COLUMN', @level2name = N'IsSelect';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'是否连续', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'T_Product_TechStep', @level2type = N'COLUMN', @level2name = N'IsContinue';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'备注', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'T_Product_TechStep', @level2type = N'COLUMN', @level2name = N'Remark';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'创建人Id', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'T_Product_TechStep', @level2type = N'COLUMN', @level2name = N'CreateUserId';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'创建日期', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'T_Product_TechStep', @level2type = N'COLUMN', @level2name = N'CreateDate';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'最后更改人Id', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'T_Product_TechStep', @level2type = N'COLUMN', @level2name = N'LastModifyUserId';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'最后更改日期', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'T_Product_TechStep', @level2type = N'COLUMN', @level2name = N'LastModifyDate';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'删除标识', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'T_Product_TechStep', @level2type = N'COLUMN', @level2name = N'Deleted';

