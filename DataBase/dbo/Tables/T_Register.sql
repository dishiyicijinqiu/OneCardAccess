CREATE TABLE [dbo].[T_Register] (
    [RegisterId]           VARCHAR (36)  DEFAULT (newid()) NOT NULL,
    [RegisterNo]           VARCHAR (100) NOT NULL,
    [RegisterProductName]  VARCHAR (100) NOT NULL,
    [StandardCode]         VARCHAR (100) NOT NULL,
    [RegisterNo1]          VARCHAR (100) NOT NULL,
    [RegisterProductName1] VARCHAR (100) NOT NULL,
    [StandardCode1]        VARCHAR (100) NOT NULL,
    [RegisterFile]         VARCHAR (50)  NOT NULL,
    [StartDate]            VARCHAR (10)  NOT NULL,
    [EndDate]              VARCHAR (10)  NOT NULL,
    [CreateId]             VARCHAR (36)  NOT NULL,
    [CreateDate]           DATETIME      NOT NULL,
    [LastModifyId]         VARCHAR (36)  NOT NULL,
    [LastModifyDate]       DATETIME      NOT NULL,
    [Remark]               VARCHAR (200) NOT NULL,
    [Deleted]              BIT           CONSTRAINT [DF_T_Register_Deleted] DEFAULT ((0)) NOT NULL,
    CONSTRAINT [PK_Base_Register] PRIMARY KEY CLUSTERED ([RegisterId] ASC)
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'注册证信息', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'T_Register';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'主键Id', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'T_Register', @level2type = N'COLUMN', @level2name = N'RegisterId';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'注册证编号', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'T_Register', @level2type = N'COLUMN', @level2name = N'RegisterNo';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'注册证名称', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'T_Register', @level2type = N'COLUMN', @level2name = N'RegisterProductName';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'标准号', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'T_Register', @level2type = N'COLUMN', @level2name = N'StandardCode';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'注册证编号(英文)', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'T_Register', @level2type = N'COLUMN', @level2name = N'RegisterNo1';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'注册证名称(英文)', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'T_Register', @level2type = N'COLUMN', @level2name = N'RegisterProductName1';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'标准号(英文)', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'T_Register', @level2type = N'COLUMN', @level2name = N'StandardCode1';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'注册证文件', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'T_Register', @level2type = N'COLUMN', @level2name = N'RegisterFile';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'启用日期', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'T_Register', @level2type = N'COLUMN', @level2name = N'StartDate';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'停用日期', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'T_Register', @level2type = N'COLUMN', @level2name = N'EndDate';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'创建人Id', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'T_Register', @level2type = N'COLUMN', @level2name = N'CreateId';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'创建日期', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'T_Register', @level2type = N'COLUMN', @level2name = N'CreateDate';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'最后更改人Id', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'T_Register', @level2type = N'COLUMN', @level2name = N'LastModifyId';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'最后更改日期', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'T_Register', @level2type = N'COLUMN', @level2name = N'LastModifyDate';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'备注', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'T_Register', @level2type = N'COLUMN', @level2name = N'Remark';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'删除标识', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'T_Register', @level2type = N'COLUMN', @level2name = N'Deleted';

