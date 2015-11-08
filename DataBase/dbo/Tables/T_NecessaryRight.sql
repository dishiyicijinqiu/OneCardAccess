CREATE TABLE [dbo].[T_NecessaryRight] (
    [RoleId]      VARCHAR (36) NOT NULL,
    [NecessaryId] INT          NOT NULL,
    CONSTRAINT [PK_T_NecessaryRight] PRIMARY KEY CLUSTERED ([NecessaryId] ASC, [RoleId] ASC)
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'必需品权限表', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'T_NecessaryRight';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'角色Id', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'T_NecessaryRight', @level2type = N'COLUMN', @level2name = N'RoleId';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'必需品表Id', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'T_NecessaryRight', @level2type = N'COLUMN', @level2name = N'NecessaryId';

