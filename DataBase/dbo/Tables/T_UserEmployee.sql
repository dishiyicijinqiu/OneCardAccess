CREATE TABLE [dbo].[T_UserEmployee] (
    [UserId] VARCHAR (36) NOT NULL,
    [EmpId]  VARCHAR (36) NOT NULL,
    CONSTRAINT [PK_T_UserEmployee] PRIMARY KEY CLUSTERED ([UserId] ASC, [EmpId] ASC)
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_T_UserEmployee_UserId]
    ON [dbo].[T_UserEmployee]([UserId] ASC);


GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_T_UserEmployee_EmpId]
    ON [dbo].[T_UserEmployee]([EmpId] ASC);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'用户员工关系表', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'T_UserEmployee';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'用户Id', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'T_UserEmployee', @level2type = N'COLUMN', @level2name = N'UserId';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'员工Id', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'T_UserEmployee', @level2type = N'COLUMN', @level2name = N'EmpId';

