CREATE TABLE [dbo].[T_RoleMenu] (
    [RoleId] VARCHAR (36) NOT NULL,
    [MenuNo] VARCHAR (50) NOT NULL,
    PRIMARY KEY CLUSTERED ([MenuNo] ASC, [RoleId] ASC)
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'角色菜单表', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'T_RoleMenu';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'角色Id', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'T_RoleMenu', @level2type = N'COLUMN', @level2name = N'RoleId';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'菜单编号', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'T_RoleMenu', @level2type = N'COLUMN', @level2name = N'MenuNo';

