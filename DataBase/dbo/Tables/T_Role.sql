CREATE TABLE [dbo].[T_Role] (
    [RoleId]         VARCHAR (36)  CONSTRAINT [DF_T_Role_RoleId] DEFAULT (newid()) NOT NULL,
    [RoleNo]         VARCHAR (50)  NOT NULL,
    [RoleName]       NVARCHAR (50) NOT NULL,
    [IsLock]         BIT           NOT NULL,
    [IsSuper]        BIT           NOT NULL,
    [Remark]         VARCHAR (100) CONSTRAINT [DF__tmp_ms_xx__Remar__18EBB532] DEFAULT ('') NOT NULL,
    [CreateId]       VARCHAR (36)  NOT NULL,
    [CreateDate]     DATETIME      NOT NULL,
    [LastModifyId]   VARCHAR (36)  NOT NULL,
    [LastModifyDate] DATETIME      NOT NULL,
    [Deleted]        BIT           CONSTRAINT [DF_T_Role_Deleted] DEFAULT ((0)) NOT NULL,
    CONSTRAINT [PK__tmp_ms_xx_T_Role__160F4887] PRIMARY KEY CLUSTERED ([RoleId] ASC)
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'角色表', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'T_Role';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'角色Id', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'T_Role', @level2type = N'COLUMN', @level2name = N'RoleId';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'角色编号', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'T_Role', @level2type = N'COLUMN', @level2name = N'RoleNo';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'角色名称', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'T_Role', @level2type = N'COLUMN', @level2name = N'RoleName';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'是否锁定', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'T_Role', @level2type = N'COLUMN', @level2name = N'IsLock';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'是否是超级管理员角色', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'T_Role', @level2type = N'COLUMN', @level2name = N'IsSuper';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'备注', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'T_Role', @level2type = N'COLUMN', @level2name = N'Remark';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'创建人Id', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'T_Role', @level2type = N'COLUMN', @level2name = N'CreateId';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'创建日期', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'T_Role', @level2type = N'COLUMN', @level2name = N'CreateDate';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'最后更改人Id', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'T_Role', @level2type = N'COLUMN', @level2name = N'LastModifyId';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'最后更改日期', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'T_Role', @level2type = N'COLUMN', @level2name = N'LastModifyDate';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'删除标志', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'T_Role', @level2type = N'COLUMN', @level2name = N'Deleted';

