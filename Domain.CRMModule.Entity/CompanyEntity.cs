using System;
using System.Runtime.Serialization;
namespace FengSharp.OneCardAccess.Domain.CRMModule.Entity
{
    /// <summary>
    /// 往来单位
    /// </summary>
    [DataContract(Namespace = "http://www.fengsharp.com/onecardaccess/")]
    public class CompanyEntity
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public CompanyEntity()
        {
            CompanyNo = string.Empty;
            CompanyName = string.Empty;
            Address = string.Empty;
            Tel = string.Empty;
            Fax = string.Empty;
            PostCode = string.Empty;
            EMail = string.Empty;
            Person = string.Empty;
            BankAndAcount = string.Empty;
            TaxNumber = string.Empty;
            Remark = string.Empty;
            CreateId = string.Empty;
            LastModifyId = string.Empty;
            Password = string.Empty;
            Level_Path = string.Empty;

        }
        /// <summary>
        /// 主键Id
        /// </summary>
        [DataMember]
        public int CompanyId { get; set; }
        /// <summary>
        /// 单位编号
        /// </summary>
        [DataMember]
        public string CompanyNo { get; set; }
        /// <summary>
        /// 单位名称
        /// </summary>
        [DataMember]
        public string CompanyName { get; set; }
        /// <summary>
        /// 单位地址
        /// </summary>
        [DataMember]
        public string Address { get; set; }
        /// <summary>
        /// 电话
        /// </summary>
        [DataMember]
        public string Tel { get; set; }
        /// <summary>
        /// 传真
        /// </summary>
        [DataMember]
        public string Fax { get; set; }
        /// <summary>
        /// 邮政编码
        /// </summary>
        [DataMember]
        public string PostCode { get; set; }
        /// <summary>
        /// 电子邮件
        /// </summary>
        [DataMember]
        public string EMail { get; set; }
        /// <summary>
        /// 联系人
        /// </summary>
        [DataMember]
        public string Person { get; set; }
        /// <summary>
        /// 开户银行
        /// </summary>
        [DataMember]
        public string BankAndAcount { get; set; }
        /// <summary>
        /// 税号
        /// </summary>
        [DataMember]
        public string TaxNumber { get; set; }
        /// <summary>
        /// 应收
        /// </summary>
        [DataMember]
        public decimal ARTotal { get; set; }
        /// <summary>
        /// 应付
        /// </summary>
        [DataMember]
        public decimal APTotal { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        [DataMember]
        public string Remark { get; set; }
        /// <summary>
        /// 创建人Id
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
        /// 登陆密码
        /// </summary>
        [DataMember]
        public string Password { get; set; }
        /// <summary>
        /// 是否启用
        /// </summary>
        [DataMember]
        public bool Enable { get; set; }
        /// <summary>
        /// 父Id
        /// </summary>
        [DataMember]
        public int PId { get; set; }
        /// <summary>
        /// 树形结构路径
        /// </summary>
        [DataMember]
        public string Level_Path { get; set; }
        /// <summary>
        /// 儿子数量
        /// </summary>
        [DataMember]
        public int Level_Num { get; set; }
        /// <summary>
        /// 子孙数量
        /// </summary>
        [DataMember]
        public int Level_Total { get; set; }
        /// <summary>
        /// 树的深度
        /// </summary>
        [DataMember]
        public int Level_Deep { get; set; }
    }
    /// <summary>
    /// 往来单位
    /// </summary>
    [DataContract(Namespace = "http://www.fengsharp.com/onecardaccess/")]
    public class CompanyCMEntity : CompanyEntity
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public CompanyCMEntity()
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
    /// 往来单位
    /// </summary>
    [DataContract(Namespace = "http://www.fengsharp.com/onecardaccess/")]
    public class CompanyCMCateEntity : CompanyCMEntity
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public CompanyCMCateEntity()
            : base()
        {
        }
        /// <summary>
        /// 是否有分类
        /// </summary>
        [DataMember]
        public bool HasCate { get; set; }
    }
}
