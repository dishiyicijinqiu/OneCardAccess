CREATE TABLE [dbo].[T_EmployeeAttachment] (
    [Id]       VARCHAR (36) NOT NULL,
    [EmpId]    VARCHAR (36) NOT NULL,
    [ShowName] VARCHAR (50) NOT NULL,
    [SaveName] VARCHAR (50) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'员工附件表', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'T_EmployeeAttachment';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'主键Id', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'T_EmployeeAttachment', @level2type = N'COLUMN', @level2name = N'Id';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'员工Id', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'T_EmployeeAttachment', @level2type = N'COLUMN', @level2name = N'EmpId';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'附件名称', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'T_EmployeeAttachment', @level2type = N'COLUMN', @level2name = N'ShowName';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'保存名称', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'T_EmployeeAttachment', @level2type = N'COLUMN', @level2name = N'SaveName';

