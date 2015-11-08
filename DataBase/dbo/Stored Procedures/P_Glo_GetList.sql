CREATE PROCEDURE P_Glo_GetList
--CREATE PROCEDURE P_Glo_GetList
(
	@cMode VARCHAR(50)
)
AS 
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
   Remark,
   Remark1,
   Remark2
from T_Employee
where Deleted = 0
order by EmpNo
else if @cMode = 'employeecmdept'
select
   EmpId,--员工Id
   EmpNo,--员工编号
   EmpName,--员工姓名
   e.DeptId,--部门Id
   d.DeptNo,
   d.DeptName,
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
   e.CreateId,--创建人
   e.CreateDate,--创建日期
   e.LastModifyId,--最后更改人Id
   e.LastModifyDate,--最后更改日期
   e.Remark,
   e.Remark1,
   e.Remark2,
   u1.UserName CreateName,
   u2.UserName LastModifyName
from T_Employee e left join T_User u1 on  e.CreateId=u1.UserId left join T_User u2 on e.CreateId=u2.UserId left join T_Dept d on e.DeptId=d.DeptId
where e.Deleted = 0
order by EmpNo
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
from T_User where Deleted=0 order by UserNo
else if @cMode = 'usercm'
select		 u.UserId
			,u.UserNo
			,u.UserName
			,u.UserPassWord
			,u.IsLock
			,u.Remark
			,u.CreateId
			,u.CreateDate
			,u.LastModifyId
			,u.LastModifyDate
			,u.IsUserAuthority
			,u1.UserName CreateName
			,u2.UserName LastModifyName
from T_User u left join T_User u1 on  u.CreateId=u1.UserId left join T_User u2 on u.CreateId=u2.UserId where u.Deleted=0 order by UserNo
else if @cMode = 'role'
select		RoleId,--角色Id
			RoleNo,--角色编号
			RoleName,--角色名称
			Remark,--备注
			CreateId,--创建人Id
			CreateDate,--创建日期
			LastModifyId,--最后更改人Id
			LastModifyDate,--最后更改日期
			IsLock,--是否锁定
			IsSuper
from T_Role where Deleted=0
order by RoleNo
else if @cMode = 'menu'
select * from T_Menu
else if @cMode = 'action'
select * from T_Action
else if @cMode = 'registercm'
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
   r.CreateId,--创建人Id
   r.CreateDate,--创建日期
   r.LastModifyId,--最后更改人Id
   r.LastModifyDate,--最后更改日期
   r.Remark,--备注
   u1.UserName CreateName,
   u2.UserName LastModifyName
from T_Register r left join T_User u1 on  r.CreateId=u1.UserId left join T_User u2 on r.CreateId=u2.UserId
where r.Deleted = 0
order by RegisterNo
else if @cMode = 'stockcm' --仓库表
select
   s.StockId,--主键Id
   s.StockNo,--仓库编号
   s.StockName,--仓库名称
   s.CreateId,--创建人Id
   s.CreateDate,--创建日期
   s.LastModifyId,--最后修改人Id
   s.LastModifyDate,--最后修改日期
   s.Deleted,--删除标识
   s.Remark,--备注
   u1.UserName CreateName,--创建人
   u2.UserName LastModifyName--最后更改人
from T_Stock s 
left join T_User u1 on  s.CreateId=u1.UserId 
left join T_User u2 on s.CreateId=u2.UserId 
where s.Deleted = 0
else
begin
	declare @errmsg varchar(max)
	select @errmsg=dbo.F_GetError('',5) RAISERROR(@errmsg,11,1)--方法未实现
end