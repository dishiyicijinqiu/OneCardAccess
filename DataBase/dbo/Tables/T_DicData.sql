CREATE TABLE [dbo].[T_DicData] (
    [DicType]  VARCHAR (20)  NOT NULL,
    [DicValue] VARCHAR (100) NOT NULL,
    CONSTRAINT [PK_T_DicData] PRIMARY KEY CLUSTERED ([DicValue] ASC, [DicType] ASC)
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'字典表', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'T_DicData';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'字典类型', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'T_DicData', @level2type = N'COLUMN', @level2name = N'DicType';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'字典键', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'T_DicData', @level2type = N'COLUMN', @level2name = N'DicValue';

