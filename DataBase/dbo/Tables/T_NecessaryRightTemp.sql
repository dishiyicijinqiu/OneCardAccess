CREATE TABLE [dbo].[T_NecessaryRightTemp] (
    [RoleId]      VARCHAR (36) NOT NULL,
    [NecessaryId] INT          NOT NULL,
    [Flag]        VARCHAR (36) NOT NULL
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'必需品权限临时数据', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'T_NecessaryRightTemp';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'角色Id', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'T_NecessaryRightTemp', @level2type = N'COLUMN', @level2name = N'RoleId';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'必需品表Id', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'T_NecessaryRightTemp', @level2type = N'COLUMN', @level2name = N'NecessaryId';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'状态标识', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'T_NecessaryRightTemp', @level2type = N'COLUMN', @level2name = N'Flag';

