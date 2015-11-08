CREATE TABLE [dbo].[T_UserInRole] (
    [UserId] VARCHAR (36) NOT NULL,
    [RoleId] VARCHAR (36) NOT NULL,
    CONSTRAINT [PK_T_UserInRole] PRIMARY KEY CLUSTERED ([UserId] ASC, [RoleId] ASC)
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'用户角色表', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'T_UserInRole';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'用户Id', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'T_UserInRole', @level2type = N'COLUMN', @level2name = N'UserId';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'角色Id', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'T_UserInRole', @level2type = N'COLUMN', @level2name = N'RoleId';

