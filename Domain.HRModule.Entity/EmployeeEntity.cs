using System;
using System.Runtime.Serialization;
namespace FengSharp.OneCardAccess.Domain.HRModule.Entity
{
    /// <summary>
    /// 员工表
    /// </summary>
    [DataContract(Namespace = "http://www.fengsharp.com/onecardaccess/")]
    public class EmployeeEntity
    {
        /// <summary>
        /// ctor
        /// </summary>
        public EmployeeEntity()
        {
            EmpId = string.Empty;
            EmpNo = string.Empty;
            EmpName = string.Empty;
            Sex = string.Empty;
            Nation = string.Empty;
            Birthday = string.Empty;
            Address = string.Empty;
            TelPhone = string.Empty;
            Mobile = string.Empty;
            Origin = string.Empty;
            Title = string.Empty;
            Duty = string.Empty;
            Post = string.Empty;
            WedStatus = string.Empty;
            AttCardNo = string.Empty;
            GenCardNo = string.Empty;
            IdCardNo = string.Empty;
            Photo = string.Empty;
            Specialty = string.Empty;
            Diploma = string.Empty;
            GraduateSchool = string.Empty;
            PoliticalStatus = string.Empty;
            JoinDate = string.Empty;
            TrialStartDate = string.Empty;
            TrialEndDate = string.Empty;
            PositiveDate = string.Empty;
            ContractStartDate = string.Empty;
            ContractEndDate = string.Empty;
            CreateId = string.Empty;
            LastModifyId = string.Empty;
            Remark = string.Empty;
            Remark1 = string.Empty;
            Remark2 = string.Empty;

        }
        /// <summary>
        /// 员工Id
        /// </summary>
        [DataMember]
        public string EmpId { get; set; }
        /// <summary>
        /// 员工编号
        /// </summary>
        [DataMember]
        public string EmpNo { get; set; }
        /// <summary>
        /// 员工姓名
        /// </summary>
        [DataMember]
        public string EmpName { get; set; }
        /// <summary>
        /// 部门Id
        /// </summary>
        [DataMember]
        public int DeptId { get; set; }
        /// <summary>
        /// 性别
        /// </summary>
        [DataMember]
        public string Sex { get; set; }
        /// <summary>
        /// 民族
        /// </summary>
        [DataMember]
        public string Nation { get; set; }
        /// <summary>
        /// 生日
        /// </summary>
        [DataMember]
        public string Birthday { get; set; }
        /// <summary>
        /// 家庭住址
        /// </summary>
        [DataMember]
        public string Address { get; set; }
        /// <summary>
        /// 联系电话
        /// </summary>
        [DataMember]
        public string TelPhone { get; set; }
        /// <summary>
        /// 手机
        /// </summary>
        [DataMember]
        public string Mobile { get; set; }
        /// <summary>
        /// 籍贯
        /// </summary>
        [DataMember]
        public string Origin { get; set; }
        /// <summary>
        /// 职称
        /// </summary>
        [DataMember]
        public string Title { get; set; }
        /// <summary>
        /// 职务
        /// </summary>
        [DataMember]
        public string Duty { get; set; }
        /// <summary>
        /// 岗位
        /// </summary>
        [DataMember]
        public string Post { get; set; }
        /// <summary>
        /// 职位状态（1，在职，2，试用，3，停职，4，离职）
        /// </summary>
        [DataMember]
        public short EmpStatus { get; set; }
        /// <summary>
        /// 婚姻状况
        /// </summary>
        [DataMember]
        public string WedStatus { get; set; }
        /// <summary>
        /// 考勤卡号
        /// </summary>
        [DataMember]
        public string AttCardNo { get; set; }
        /// <summary>
        /// 通用卡号（生产刷卡，材料领用）
        /// </summary>
        [DataMember]
        public string GenCardNo { get; set; }
        /// <summary>
        /// 身份证号
        /// </summary>
        [DataMember]
        public string IdCardNo { get; set; }
        /// <summary>
        /// 照片
        /// </summary>
        [DataMember]
        public string Photo { get; set; }
        /// <summary>
        /// 专业
        /// </summary>
        [DataMember]
        public string Specialty { get; set; }
        /// <summary>
        /// 最高学历
        /// </summary>
        [DataMember]
        public string Diploma { get; set; }
        /// <summary>
        /// 毕业学校
        /// </summary>
        [DataMember]
        public string GraduateSchool { get; set; }
        /// <summary>
        /// 政治面貌
        /// </summary>
        [DataMember]
        public string PoliticalStatus { get; set; }
        /// <summary>
        /// 入职日期
        /// </summary>
        [DataMember]
        public string JoinDate { get; set; }
        /// <summary>
        /// 试用期开始日期
        /// </summary>
        [DataMember]
        public string TrialStartDate { get; set; }
        /// <summary>
        /// 试用期结束日期
        /// </summary>
        [DataMember]
        public string TrialEndDate { get; set; }
        /// <summary>
        /// 转正日期
        /// </summary>
        [DataMember]
        public string PositiveDate { get; set; }
        /// <summary>
        /// 合同开始日期
        /// </summary>
        [DataMember]
        public string ContractStartDate { get; set; }
        /// <summary>
        /// 合同结束日期
        /// </summary>
        [DataMember]
        public string ContractEndDate { get; set; }
        /// <summary>
        /// 节假日短信祝福
        /// </summary>
        [DataMember]
        public bool HolidaySMS { get; set; }
        /// <summary>
        /// 生日短信祝福
        /// </summary>
        [DataMember]
        public bool BirthdaySMS { get; set; }
        /// <summary>
        /// 是否记考勤
        /// </summary>
        [DataMember]
        public bool Att { get; set; }
        /// <summary>
        /// 创建人
        /// </summary>
        [DataMember]
        public string CreateId { get; set; }
        /// <summary>
        /// 创建日期
        /// </summary>
        [DataMember]
        public DateTime CreateDate { get; set; }
        /// <summary>
        /// 最后更改人Id
        /// </summary>
        [DataMember]
        public string LastModifyId { get; set; }
        /// <summary>
        /// 最后更改日期
        /// </summary>
        [DataMember]
        public DateTime LastModifyDate { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        [DataMember]
        public string Remark { get; set; }
        /// <summary>
        /// 备注1
        /// </summary>
        [DataMember]
        public string Remark1 { get; set; }
        /// <summary>
        /// 备注2
        /// </summary>
        [DataMember]
        public string Remark2 { get; set; }
    }

    /// <summary>
    /// 员工表
    /// </summary>
    [DataContract(Namespace = "http://www.fengsharp.com/onecardaccess/")]
    public class EmployeeCMEntity : EmployeeEntity
    {
        /// <summary>
        /// ctor
        /// </summary>
        public EmployeeCMEntity()
            : base()
        {
            CreateName = string.Empty;
            LastModifyName = string.Empty;
        }
        /// <summary>
        /// 创建人姓名
        /// </summary>
        [DataMember]
        public string CreateName { get; set; }
        /// <summary>
        /// 最后更改人姓名
        /// </summary>
        [DataMember]
        public string LastModifyName { get; set; }
    }

    /// <summary>
    /// 员工表
    /// </summary>
    [DataContract(Namespace = "http://www.fengsharp.com/onecardaccess/")]
    public class EmployeeCMDeptEntity : EmployeeCMEntity
    {
        /// <summary>
        /// ctor
        /// </summary>
        public EmployeeCMDeptEntity()
            : base()
        {
            DeptNo = string.Empty;
            DeptName = string.Empty;
        }
        /// <summary>
        /// 部门编号
        /// </summary>
        [DataMember]
        public string DeptNo { get; set; }
        /// <summary>
        /// 部门名称
        /// </summary>
        [DataMember]
        public string DeptName { get; set; }
    }
}
