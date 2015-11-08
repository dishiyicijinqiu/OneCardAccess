CREATE TABLE [dbo].[T_CompanyRight] (
    [RoleId]    VARCHAR (36) NOT NULL,
    [CompanyId] INT          NOT NULL,
    CONSTRAINT [PK_T_CompanyRight] PRIMARY KEY CLUSTERED ([RoleId] ASC, [CompanyId] ASC)
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'往来单位权限表', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'T_CompanyRight';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'角色Id', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'T_CompanyRight', @level2type = N'COLUMN', @level2name = N'RoleId';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'往来单位主键Id', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'T_CompanyRight', @level2type = N'COLUMN', @level2name = N'CompanyId';

