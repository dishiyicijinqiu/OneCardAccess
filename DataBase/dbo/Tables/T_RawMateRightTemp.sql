CREATE TABLE [dbo].[T_RawMateRightTemp] (
    [RoleId]    VARCHAR (36) NOT NULL,
    [RawMateId] INT          NOT NULL,
    [Flag]      VARCHAR (36) NOT NULL
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'原材料权限临时数据', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'T_RawMateRightTemp';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'角色Id', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'T_RawMateRightTemp', @level2type = N'COLUMN', @level2name = N'RoleId';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'原材料Id', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'T_RawMateRightTemp', @level2type = N'COLUMN', @level2name = N'RawMateId';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'状态标识', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'T_RawMateRightTemp', @level2type = N'COLUMN', @level2name = N'Flag';

