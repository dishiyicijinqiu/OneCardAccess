CREATE TABLE [dbo].[T_Product_Register] (
    [Id]               VARCHAR (36)  DEFAULT (newid()) NOT NULL,
    [ProductId]        INT           NOT NULL,
    [RegisterId]       VARCHAR (36)  NOT NULL,
    [Spec]             VARCHAR (100) NOT NULL,
    [Spec1]            VARCHAR (100) NOT NULL,
    [CreateUserId]     INT           NOT NULL,
    [CreateDate]       DATETIME      NOT NULL,
    [LastModifyUserId] INT           NOT NULL,
    [LastModifyDate]   DATETIME      NOT NULL,
    [Deleted]          BIT           CONSTRAINT [DF_T_Product_Register_Deleted] DEFAULT ((0)) NOT NULL,
    CONSTRAINT [PK_T_Product_Register] PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'产品Id', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'T_Product_Register', @level2type = N'COLUMN', @level2name = N'ProductId';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'注册证Id', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'T_Product_Register', @level2type = N'COLUMN', @level2name = N'RegisterId';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'规格型号', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'T_Product_Register', @level2type = N'COLUMN', @level2name = N'Spec';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'规格型号(英文)', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'T_Product_Register', @level2type = N'COLUMN', @level2name = N'Spec1';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'创建人Id', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'T_Product_Register', @level2type = N'COLUMN', @level2name = N'CreateUserId';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'创建日期', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'T_Product_Register', @level2type = N'COLUMN', @level2name = N'CreateDate';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'最后更改人Id', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'T_Product_Register', @level2type = N'COLUMN', @level2name = N'LastModifyUserId';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'最后更改日期', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'T_Product_Register', @level2type = N'COLUMN', @level2name = N'LastModifyDate';

