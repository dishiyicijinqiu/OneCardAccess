
--CREATE PROCEDURE P_CreateEmployee
CREATE PROCEDURE P_CreateEmployee
(
	@EmpId VARCHAR(36) output,
	@EmpNo varchar(50),
	@EmpName varchar(50),
	@DeptId int,
	@Sex varchar(5),
	@Nation varchar(20),
	@Birthday varchar(10),
	@Address varchar(500),
	@TelPhone varchar(20),
	@Mobile varchar(20),
	@Origin varchar(10),
	@Title varchar(50),
	@Duty varchar(50),
	@Post varchar(50),
	@EmpStatus smallint,
	@WedStatus varchar(5),
	@AttCardNo varchar(20),
	@GenCardNo varchar(20),
	@IdCardNo varchar(30),
	@Photo varchar(50),
	@Specialty varchar(50),
	@Diploma varchar(10),
	@GraduateSchool varchar(100),
	@PoliticalStatus varchar(10),
	@JoinDate varchar(10),
	@TrialStartDate varchar(10),
	@TrialEndDate varchar(10),
	@PositiveDate varchar(10),
	@ContractStartDate varchar(10),
	@ContractEndDate varchar(10),
	@HolidaySMS bit,
	@BirthdaySMS bit,
	@Att bit,
	@CreateId varchar(36),
	@Remark varchar(200),
	@Remark1 varchar(200),
	@Remark2 varchar(200)
)
AS
declare @errmsg varchar(max)
select 1 from T_Employee where EmpNo=@EmpNo and Deleted=0
if(@@ROWCOUNT>0) begin select @errmsg=dbo.F_GetError('',1) RAISERROR(@errmsg,11,1) end--存在相同的编号
set @EmpId = newid();

insert into T_Employee (
   EmpId,--员工Id
   EmpNo,--员工编号
   EmpName,--员工姓名
   DeptId,--部门Id
   Sex,--性别
   Nation,--民族
   Birthday,--生日
   Address,--家庭住址
   TelPhone,--联系电话
   Mobile,--手机
   Origin,--籍贯
   Title,--职称
   Duty,--职务
   Post,--岗位
   EmpStatus,--职位状态（1，在职，2，试用，3，停职，4，离职）
   WedStatus,--婚姻状况
   AttCardNo,--考勤卡号
   GenCardNo,--通用卡号（生产刷卡，材料领用）
   IdCardNo,--身份证号
   Photo,--照片
   Specialty,--专业
   Diploma,--最高学历
   GraduateSchool,--毕业学校
   PoliticalStatus,--政治面貌
   JoinDate,--入职日期
   TrialStartDate,--试用期开始日期
   TrialEndDate,--试用期结束日期
   PositiveDate,--转正日期
   ContractStartDate,--合同开始日期
   ContractEndDate,--合同结束日期
   HolidaySMS,--节假日短信祝福
   BirthdaySMS,--生日短信祝福
   Att,--是否记考勤
   CreateId,--创建人
   CreateDate,--创建日期
   LastModifyId,--最后更改人Id
   LastModifyDate,--最后更改日期
   Remark,--备注
   Remark1,--备注1
   Remark2--备注2
)
values(
   @EmpId,--员工Id
   @EmpNo,--员工编号
   @EmpName,--员工姓名
   @DeptId,--部门Id
   @Sex,--性别
   @Nation,--民族
   @Birthday,--生日
   @Address,--家庭住址
   @TelPhone,--联系电话
   @Mobile,--手机
   @Origin,--籍贯
   @Title,--职称
   @Duty,--职务
   @Post,--岗位
   @EmpStatus,--职位状态（1，在职，2，试用，3，停职，4，离职）
   @WedStatus,--婚姻状况
   @AttCardNo,--考勤卡号
   @GenCardNo,--通用卡号（生产刷卡，材料领用）
   @IdCardNo,--身份证号
   @Photo,--照片
   @Specialty,--专业
   @Diploma,--最高学历
   @GraduateSchool,--毕业学校
   @PoliticalStatus,--政治面貌
   @JoinDate,--入职日期
   @TrialStartDate,--试用期开始日期
   @TrialEndDate,--试用期结束日期
   @PositiveDate,--转正日期
   @ContractStartDate,--合同开始日期
   @ContractEndDate,--合同结束日期
   @HolidaySMS,--节假日短信祝福
   @BirthdaySMS,--生日短信祝福
   @Att,--是否记考勤
   @CreateId,--创建人
   getdate(),--创建日期
   @CreateId,--最后更改人Id
   getdate(),--最后更改日期
   @Remark,--备注
   @Remark1,--备注1
   @Remark2--备注2
)
if(@@ROWCOUNT<=0) begin select @errmsg=dbo.F_GetError('',2) RAISERROR(@errmsg,11,1) end--插入失败
