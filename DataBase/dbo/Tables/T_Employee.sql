CREATE TABLE [dbo].[T_Employee] (
    [EmpId]             VARCHAR (36)  CONSTRAINT [DF__tmp_ms_xx__EmpId__10566F31] DEFAULT (newid()) NOT NULL,
    [EmpNo]             VARCHAR (50)  NOT NULL,
    [EmpName]           VARCHAR (50)  NOT NULL,
    [DeptId]            INT           NOT NULL,
    [Sex]               VARCHAR (5)   NOT NULL,
    [Nation]            VARCHAR (20)  NOT NULL,
    [Birthday]          VARCHAR (10)  NOT NULL,
    [Address]           VARCHAR (500) NOT NULL,
    [TelPhone]          VARCHAR (20)  NOT NULL,
    [Mobile]            VARCHAR (20)  NOT NULL,
    [Origin]            VARCHAR (10)  NOT NULL,
    [Title]             VARCHAR (50)  NOT NULL,
    [Duty]              VARCHAR (50)  NOT NULL,
    [Post]              VARCHAR (50)  NOT NULL,
    [EmpStatus]         SMALLINT      NOT NULL,
    [WedStatus]         VARCHAR (5)   NOT NULL,
    [AttCardNo]         VARCHAR (20)  NOT NULL,
    [GenCardNo]         VARCHAR (20)  NOT NULL,
    [IdCardNo]          VARCHAR (30)  NOT NULL,
    [Photo]             VARCHAR (50)  NOT NULL,
    [Specialty]         VARCHAR (50)  NOT NULL,
    [Diploma]           VARCHAR (10)  NOT NULL,
    [GraduateSchool]    VARCHAR (100) NOT NULL,
    [PoliticalStatus]   VARCHAR (10)  NOT NULL,
    [JoinDate]          VARCHAR (10)  NOT NULL,
    [TrialStartDate]    VARCHAR (10)  NOT NULL,
    [TrialEndDate]      VARCHAR (10)  NOT NULL,
    [PositiveDate]      VARCHAR (10)  NOT NULL,
    [ContractStartDate] VARCHAR (10)  NOT NULL,
    [ContractEndDate]   VARCHAR (10)  NOT NULL,
    [HolidaySMS]        BIT           NOT NULL,
    [BirthdaySMS]       BIT           NOT NULL,
    [Att]               BIT           CONSTRAINT [DF__tmp_ms_xx_T__Att__114A936A] DEFAULT ((1)) NOT NULL,
    [Deleted]           BIT           CONSTRAINT [DF__tmp_ms_xx__Delet__123EB7A3] DEFAULT ((0)) NOT NULL,
    [CreateId]          VARCHAR (36)  NOT NULL,
    [CreateDate]        DATETIME      CONSTRAINT [DF__tmp_ms_xx__Creat__1332DBDC] DEFAULT (getdate()) NOT NULL,
    [LastModifyId]      VARCHAR (36)  NOT NULL,
    [LastModifyDate]    DATETIME      CONSTRAINT [DF__tmp_ms_xx__LastM__14270015] DEFAULT (getdate()) NOT NULL,
    [Remark]            VARCHAR (200) NOT NULL,
    [Remark1]           VARCHAR (200) NOT NULL,
    [Remark2]           VARCHAR (200) NOT NULL,
    CONSTRAINT [PK__tmp_ms_xx_T_Empl__0F624AF8] PRIMARY KEY CLUSTERED ([EmpId] ASC)
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'员工表', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'T_Employee';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'员工Id', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'T_Employee', @level2type = N'COLUMN', @level2name = N'EmpId';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'员工编号', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'T_Employee', @level2type = N'COLUMN', @level2name = N'EmpNo';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'员工姓名', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'T_Employee', @level2type = N'COLUMN', @level2name = N'EmpName';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'部门Id', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'T_Employee', @level2type = N'COLUMN', @level2name = N'DeptId';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'性别', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'T_Employee', @level2type = N'COLUMN', @level2name = N'Sex';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'民族', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'T_Employee', @level2type = N'COLUMN', @level2name = N'Nation';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'生日', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'T_Employee', @level2type = N'COLUMN', @level2name = N'Birthday';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'家庭住址', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'T_Employee', @level2type = N'COLUMN', @level2name = N'Address';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'联系电话', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'T_Employee', @level2type = N'COLUMN', @level2name = N'TelPhone';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'手机', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'T_Employee', @level2type = N'COLUMN', @level2name = N'Mobile';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'籍贯', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'T_Employee', @level2type = N'COLUMN', @level2name = N'Origin';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'职称', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'T_Employee', @level2type = N'COLUMN', @level2name = N'Title';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'职务', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'T_Employee', @level2type = N'COLUMN', @level2name = N'Duty';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'岗位', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'T_Employee', @level2type = N'COLUMN', @level2name = N'Post';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'职位状态（1，在职，2，试用，3，停职，4，离职）', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'T_Employee', @level2type = N'COLUMN', @level2name = N'EmpStatus';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'婚姻状况', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'T_Employee', @level2type = N'COLUMN', @level2name = N'WedStatus';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'考勤卡号', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'T_Employee', @level2type = N'COLUMN', @level2name = N'AttCardNo';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'通用卡号（生产刷卡，材料领用）', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'T_Employee', @level2type = N'COLUMN', @level2name = N'GenCardNo';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'身份证号', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'T_Employee', @level2type = N'COLUMN', @level2name = N'IdCardNo';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'照片', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'T_Employee', @level2type = N'COLUMN', @level2name = N'Photo';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'专业', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'T_Employee', @level2type = N'COLUMN', @level2name = N'Specialty';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'最高学历', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'T_Employee', @level2type = N'COLUMN', @level2name = N'Diploma';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'毕业学校', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'T_Employee', @level2type = N'COLUMN', @level2name = N'GraduateSchool';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'政治面貌', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'T_Employee', @level2type = N'COLUMN', @level2name = N'PoliticalStatus';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'入职日期', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'T_Employee', @level2type = N'COLUMN', @level2name = N'JoinDate';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'试用期开始日期', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'T_Employee', @level2type = N'COLUMN', @level2name = N'TrialStartDate';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'试用期结束日期', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'T_Employee', @level2type = N'COLUMN', @level2name = N'TrialEndDate';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'转正日期', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'T_Employee', @level2type = N'COLUMN', @level2name = N'PositiveDate';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'合同开始日期', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'T_Employee', @level2type = N'COLUMN', @level2name = N'ContractStartDate';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'合同结束日期', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'T_Employee', @level2type = N'COLUMN', @level2name = N'ContractEndDate';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'节假日短信祝福', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'T_Employee', @level2type = N'COLUMN', @level2name = N'HolidaySMS';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'生日短信祝福', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'T_Employee', @level2type = N'COLUMN', @level2name = N'BirthdaySMS';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'是否记考勤', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'T_Employee', @level2type = N'COLUMN', @level2name = N'Att';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'删除标识', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'T_Employee', @level2type = N'COLUMN', @level2name = N'Deleted';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'创建人', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'T_Employee', @level2type = N'COLUMN', @level2name = N'CreateId';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'创建日期', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'T_Employee', @level2type = N'COLUMN', @level2name = N'CreateDate';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'最后更改人Id', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'T_Employee', @level2type = N'COLUMN', @level2name = N'LastModifyId';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'最后更改日期', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'T_Employee', @level2type = N'COLUMN', @level2name = N'LastModifyDate';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'备注', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'T_Employee', @level2type = N'COLUMN', @level2name = N'Remark';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'备注1', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'T_Employee', @level2type = N'COLUMN', @level2name = N'Remark1';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'备注2', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'T_Employee', @level2type = N'COLUMN', @level2name = N'Remark2';

