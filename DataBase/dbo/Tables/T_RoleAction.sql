CREATE TABLE [dbo].[T_RoleAction] (
    [RoleId]   VARCHAR (36) NOT NULL,
    [ActionNo] VARCHAR (50) NOT NULL,
    PRIMARY KEY CLUSTERED ([RoleId] ASC, [ActionNo] ASC)
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'角色功能表', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'T_RoleAction';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'角色Id', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'T_RoleAction', @level2type = N'COLUMN', @level2name = N'RoleId';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'功能编号', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'T_RoleAction', @level2type = N'COLUMN', @level2name = N'ActionNo';

