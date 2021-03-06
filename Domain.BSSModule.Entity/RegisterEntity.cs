﻿

using System;
using System.Runtime.Serialization;
namespace FengSharp.OneCardAccess.Domain.BSSModule.Entity
{
    /// <summary>
    /// 注册证信息
    /// </summary>
    [DataContract(Namespace = "http://www.fengsharp.com/onecardaccess/")]
    public class RegisterEntity
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public RegisterEntity()
        {
            RegisterId = string.Empty;
            RegisterNo = string.Empty;
            RegisterProductName = string.Empty;
            StandardCode = string.Empty;
            RegisterNo1 = string.Empty;
            RegisterProductName1 = string.Empty;
            StandardCode1 = string.Empty;
            RegisterFile = string.Empty;
            StartDate = string.Empty;
            EndDate = string.Empty;
            Remark = string.Empty;

        }
        /// <summary>
        /// 主键Id
        /// </summary>
        [DataMember]
        public string RegisterId { get; set; }
        /// <summary>
        /// 注册证编号
        /// </summary>
        [DataMember]
        public string RegisterNo { get; set; }
        /// <summary>
        /// 注册证名称
        /// </summary>
        [DataMember]
        public string RegisterProductName { get; set; }
        /// <summary>
        /// 标准号
        /// </summary>
        [DataMember]
        public string StandardCode { get; set; }
        /// <summary>
        /// 注册证编号(英文)
        /// </summary>
        [DataMember]
        public string RegisterNo1 { get; set; }
        /// <summary>
        /// 注册证名称(英文)
        /// </summary>
        [DataMember]
        public string RegisterProductName1 { get; set; }
        /// <summary>
        /// 标准号(英文)
        /// </summary>
        [DataMember]
        public string StandardCode1 { get; set; }
        /// <summary>
        /// 注册证文件
        /// </summary>
        [DataMember]
        public string RegisterFile { get; set; }
        /// <summary>
        /// 启用日期
        /// </summary>
        [DataMember]
        public string StartDate { get; set; }
        /// <summary>
        /// 停用日期
        /// </summary>
        [DataMember]
        public string EndDate { get; set; }
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
        /// 备注
        /// </summary>
        [DataMember]
        public string Remark { get; set; }
    }
    /// <summary>
    /// 注册证信息
    /// </summary>
    [DataContract(Namespace = "http://www.fengsharp.com/onecardaccess/")]
    public class RegisterCMEntity : RegisterEntity
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public RegisterCMEntity()
            : base()
        {

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
}
