--CREATE PROCEDURE P_Glo_FindByNo
CREATE PROCEDURE P_Glo_FindByNo
(
	@cMode VARCHAR(50),
	@EntityNo VARCHAR(50)
)
AS 
if @cMode = 'dept' --部门
select		DeptId,--Id
			DeptNo,--部门编号
			DeptName,--部门名称
			Remark,--备注
			PId,--父级Id
			Level_Path,--属性结构路径
			Level_Num,--儿子数量
			Level_Total,--子孙数量,
			Level_Deep,--树深度
			CreateId,--创建人Id
			CreateDate,--创建日期
			LastModifyId,--最后更改人Id
			LastModifyDate--最后更改日期
from T_Dept
where DeptNo=@EntityNo and Deleted=0
else if @cMode = 'employee' --部门
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
where EmpNo=@EntityNo and Deleted=0
else if @cMode = 'role' --角色
select		 RoleId
			,RoleNo
			,RoleName
			,IsLock
			,IsSuper
			,Remark
			,CreateId
			,CreateDate
			,LastModifyId
			,LastModifyDate
from T_Role
where RoleNo=@EntityNo and Deleted=0
else if @cMode = 'user'
select		 UserId
			,UserNo
			,UserName
			,UserPassWord
			,IsLock
			,Remark
			,CreateId
			,CreateDate
			,LastModifyId
			,LastModifyDate
			,IsUserAuthority
from T_User
where UserNo=@EntityNo and Deleted=0
else if @cMode = 'action' -- 功能表
select *
from T_Action
where ActionNo=@EntityNo
else if @cMode = 'menu' -- 菜单表
select *
from T_Menu
where MenuNo=@EntityNo
else
begin
	declare @errmsg varchar(max)
	select @errmsg=dbo.F_GetError('',5) RAISERROR(@errmsg,11,1)--方法未实现
end