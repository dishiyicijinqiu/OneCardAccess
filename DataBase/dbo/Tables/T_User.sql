CREATE TABLE [dbo].[T_User] (
    [UserId]          VARCHAR (36)  DEFAULT (newid()) NOT NULL,
    [UserNo]          VARCHAR (50)  NOT NULL,
    [UserName]        NVARCHAR (50) NOT NULL,
    [UserPassWord]    VARCHAR (50)  NOT NULL,
    [IsLock]          BIT           DEFAULT ((0)) NOT NULL,
    [Deleted]         BIT           DEFAULT ((0)) NOT NULL,
    [Remark]          VARCHAR (100) DEFAULT ('') NOT NULL,
    [CreateId]        VARCHAR (36)  NOT NULL,
    [CreateDate]      DATETIME      DEFAULT (getdate()) NOT NULL,
    [LastModifyId]    VARCHAR (36)  NOT NULL,
    [LastModifyDate]  DATETIME      NOT NULL,
    [IsUserAuthority] BIT           DEFAULT ((0)) NOT NULL,
    PRIMARY KEY CLUSTERED ([UserId] ASC)
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'用户表', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'T_User';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'用户Id', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'T_User', @level2type = N'COLUMN', @level2name = N'UserId';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'用户账号', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'T_User', @level2type = N'COLUMN', @level2name = N'UserNo';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'用户名称', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'T_User', @level2type = N'COLUMN', @level2name = N'UserName';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'用户密码', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'T_User', @level2type = N'COLUMN', @level2name = N'UserPassWord';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'是否锁定', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'T_User', @level2type = N'COLUMN', @level2name = N'IsLock';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'删除标识', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'T_User', @level2type = N'COLUMN', @level2name = N'Deleted';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'备注', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'T_User', @level2type = N'COLUMN', @level2name = N'Remark';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'创建人', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'T_User', @level2type = N'COLUMN', @level2name = N'CreateId';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'创建日期', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'T_User', @level2type = N'COLUMN', @level2name = N'CreateDate';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'最后更改人Id', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'T_User', @level2type = N'COLUMN', @level2name = N'LastModifyId';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'最后更改日期', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'T_User', @level2type = N'COLUMN', @level2name = N'LastModifyDate';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'是否启用用户权限', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'T_User', @level2type = N'COLUMN', @level2name = N'IsUserAuthority';

