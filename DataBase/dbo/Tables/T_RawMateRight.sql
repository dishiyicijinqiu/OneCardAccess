CREATE TABLE [dbo].[T_RawMateRight] (
    [RoleId]    VARCHAR (36) NOT NULL,
    [RawMateId] INT          NOT NULL,
    CONSTRAINT [PK__T_RawMateRight__71F1E3A2] PRIMARY KEY CLUSTERED ([RawMateId] ASC, [RoleId] ASC)
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'原材料权限表', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'T_RawMateRight';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'角色Id', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'T_RawMateRight', @level2type = N'COLUMN', @level2name = N'RoleId';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'原材料Id', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'T_RawMateRight', @level2type = N'COLUMN', @level2name = N'RawMateId';

