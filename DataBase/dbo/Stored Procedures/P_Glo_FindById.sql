--CREATE PROCEDURE P_Glo_FindById;1
CREATE PROCEDURE P_Glo_FindById;1
(
	@cMode VARCHAR(50),
	@EntityId VARCHAR(36)
)
AS 
begin
if @cMode = 'employee' --员工信息
select
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
from T_Employee 
where EmpId=@EntityId
else if @cMode = 'role' --角色
select		 RoleId
			,RoleNo
			,RoleName
			,IsLock
			,Deleted
			,Remark
			,CreateId
			,CreateDate
			,LastModifyId
			,LastModifyDate
			,IsSuper
from T_Role
where RoleId=@EntityId
else if @cMode = 'user'
select		 UserId
			,UserNo
			,UserName
			,UserPassWord
			,IsLock
			,Deleted
			,Remark
			,CreateId
			,CreateDate
			,LastModifyId
			,LastModifyDate
			,IsUserAuthority
from T_User
where UserId=@EntityId
else if @cMode = 'register'
select
   RegisterId,--主键Id
   RegisterNo,--注册证编号
   RegisterProductName,--注册证名称
   StandardCode,--标准号
   RegisterNo1,--注册证编号(英文)
   RegisterProductName1,--注册证名称(英文)
   StandardCode1,--标准号(英文)
   RegisterFile,--注册证文件
   StartDate,--启用日期
   EndDate,--停用日期
   CreateId,--创建人Id
   CreateDate,--创建日期
   LastModifyId,--最后更改人Id
   LastModifyDate,--最后更改日期
   Remark,--备注
   Deleted--删除标识
from T_Register
where RegisterId=@EntityId
else
begin
	declare @errmsg varchar(max)
	select @errmsg=dbo.F_GetError('',5) RAISERROR(@errmsg,11,1)--方法未实现
end
end