CREATE TABLE [dbo].[T_UserLog] (
    [Id]        VARCHAR (36) DEFAULT (newid()) NOT NULL,
    [UserId]    VARCHAR (36) NOT NULL,
    [Operation] VARCHAR (50) NOT NULL,
    [LogDate]   DATETIME     NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'用户日志表', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'T_UserLog';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'日志表Id', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'T_UserLog', @level2type = N'COLUMN', @level2name = N'Id';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'用户Id', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'T_UserLog', @level2type = N'COLUMN', @level2name = N'UserId';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'操作', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'T_UserLog', @level2type = N'COLUMN', @level2name = N'Operation';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'日志日期', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'T_UserLog', @level2type = N'COLUMN', @level2name = N'LogDate';

