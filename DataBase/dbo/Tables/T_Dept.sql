CREATE TABLE [dbo].[T_Dept] (
    [DeptId]         INT            IDENTITY (1, 1) NOT NULL,
    [DeptNo]         VARCHAR (50)   NOT NULL,
    [DeptName]       VARCHAR (50)   NOT NULL,
    [Remark]         VARCHAR (200)  NOT NULL,
    [PId]            INT            NOT NULL,
    [Level_Path]     VARCHAR (1000) NOT NULL,
    [Level_Num]      INT            NOT NULL,
    [Level_Total]    INT            NOT NULL,
    [Level_Deep]     INT            NOT NULL,
    [CreateId]       VARCHAR (36)   NOT NULL,
    [CreateDate]     DATETIME       NOT NULL,
    [LastModifyId]   VARCHAR (36)   NOT NULL,
    [LastModifyDate] DATETIME       NOT NULL,
    [Deleted]        BIT            CONSTRAINT [DF_T_Dept_Deleted] DEFAULT ((0)) NOT NULL,
    CONSTRAINT [PK__tmp_ms_xx_T_Dept__33D4B598] PRIMARY KEY CLUSTERED ([DeptId] ASC)
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'部门', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'T_Dept';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'部门Id', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'T_Dept', @level2type = N'COLUMN', @level2name = N'DeptId';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'部门编号', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'T_Dept', @level2type = N'COLUMN', @level2name = N'DeptNo';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'部门名称', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'T_Dept', @level2type = N'COLUMN', @level2name = N'DeptName';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'备注', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'T_Dept', @level2type = N'COLUMN', @level2name = N'Remark';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'树性父结构代码', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'T_Dept', @level2type = N'COLUMN', @level2name = N'PId';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'树性结构路径', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'T_Dept', @level2type = N'COLUMN', @level2name = N'Level_Path';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'儿子数量', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'T_Dept', @level2type = N'COLUMN', @level2name = N'Level_Num';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'子孙数量', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'T_Dept', @level2type = N'COLUMN', @level2name = N'Level_Total';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'树的深度', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'T_Dept', @level2type = N'COLUMN', @level2name = N'Level_Deep';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'创建人Id', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'T_Dept', @level2type = N'COLUMN', @level2name = N'CreateId';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'创建日期', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'T_Dept', @level2type = N'COLUMN', @level2name = N'CreateDate';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'最后更改人Id', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'T_Dept', @level2type = N'COLUMN', @level2name = N'LastModifyId';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'最后更改日期', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'T_Dept', @level2type = N'COLUMN', @level2name = N'LastModifyDate';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'删除标志', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'T_Dept', @level2type = N'COLUMN', @level2name = N'Deleted';

