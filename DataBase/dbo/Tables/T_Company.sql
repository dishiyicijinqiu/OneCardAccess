CREATE TABLE [dbo].[T_Company] (
    [CompanyId]      INT             IDENTITY (1, 1) NOT NULL,
    [CompanyNo]      VARCHAR (50)    NOT NULL,
    [CompanyName]    VARCHAR (150)   NOT NULL,
    [Address]        VARCHAR (200)   NOT NULL,
    [Tel]            VARCHAR (50)    NOT NULL,
    [Fax]            VARCHAR (50)    NOT NULL,
    [PostCode]       VARCHAR (50)    NOT NULL,
    [EMail]          VARCHAR (100)   NOT NULL,
    [Person]         VARCHAR (50)    NOT NULL,
    [BankAndAcount]  VARCHAR (50)    NOT NULL,
    [TaxNumber]      VARCHAR (50)    NOT NULL,
    [ARTotal]        NUMERIC (18, 4) NOT NULL,
    [APTotal]        NUMERIC (18, 4) NOT NULL,
    [Remark]         VARCHAR (200)   NOT NULL,
    [CreateId]       VARCHAR (36)    NOT NULL,
    [CreateDate]     DATETIME        NOT NULL,
    [LastModifyId]   VARCHAR (36)    NOT NULL,
    [LastModifyDate] DATETIME        NOT NULL,
    [Deleted]        BIT             DEFAULT ((0)) NOT NULL,
    [Password]       VARCHAR (100)   NOT NULL,
    [Enable]         BIT             NOT NULL,
    [PId]            INT             NOT NULL,
    [Level_Path]     VARCHAR (1000)  NOT NULL,
    [Level_Num]      INT             NOT NULL,
    [Level_Total]    INT             NOT NULL,
    [Level_Deep]     INT             NOT NULL,
    CONSTRAINT [PK_T_Company] PRIMARY KEY CLUSTERED ([CompanyId] ASC)
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'往来单位', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'T_Company';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'主键Id', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'T_Company', @level2type = N'COLUMN', @level2name = N'CompanyId';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'单位编号', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'T_Company', @level2type = N'COLUMN', @level2name = N'CompanyNo';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'单位名称', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'T_Company', @level2type = N'COLUMN', @level2name = N'CompanyName';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'单位地址', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'T_Company', @level2type = N'COLUMN', @level2name = N'Address';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'电话', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'T_Company', @level2type = N'COLUMN', @level2name = N'Tel';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'传真', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'T_Company', @level2type = N'COLUMN', @level2name = N'Fax';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'邮政编码', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'T_Company', @level2type = N'COLUMN', @level2name = N'PostCode';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'电子邮件', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'T_Company', @level2type = N'COLUMN', @level2name = N'EMail';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'联系人', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'T_Company', @level2type = N'COLUMN', @level2name = N'Person';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'开户银行', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'T_Company', @level2type = N'COLUMN', @level2name = N'BankAndAcount';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'税号', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'T_Company', @level2type = N'COLUMN', @level2name = N'TaxNumber';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'应收', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'T_Company', @level2type = N'COLUMN', @level2name = N'ARTotal';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'应付', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'T_Company', @level2type = N'COLUMN', @level2name = N'APTotal';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'备注', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'T_Company', @level2type = N'COLUMN', @level2name = N'Remark';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'创建人Id', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'T_Company', @level2type = N'COLUMN', @level2name = N'CreateId';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'创建日期', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'T_Company', @level2type = N'COLUMN', @level2name = N'CreateDate';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'最后更改人Id', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'T_Company', @level2type = N'COLUMN', @level2name = N'LastModifyId';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'最后更改日期', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'T_Company', @level2type = N'COLUMN', @level2name = N'LastModifyDate';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'删除标志', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'T_Company', @level2type = N'COLUMN', @level2name = N'Deleted';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'登陆密码', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'T_Company', @level2type = N'COLUMN', @level2name = N'Password';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'是否启用', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'T_Company', @level2type = N'COLUMN', @level2name = N'Enable';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'父Id', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'T_Company', @level2type = N'COLUMN', @level2name = N'PId';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'树形结构路径', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'T_Company', @level2type = N'COLUMN', @level2name = N'Level_Path';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'儿子数量', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'T_Company', @level2type = N'COLUMN', @level2name = N'Level_Num';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'子孙数量', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'T_Company', @level2type = N'COLUMN', @level2name = N'Level_Total';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'树的深度', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'T_Company', @level2type = N'COLUMN', @level2name = N'Level_Deep';

