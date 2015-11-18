using System;
using System.Runtime.Serialization;

namespace FengSharp.OneCardAccess.Domain.RBACModule.Entity
{
    /// <summary>
    /// 用户表
    /// </summary>
    [DataContract(Namespace = "http://www.fengsharp.com/onecardaccess/")]
    public class UserEntity
    {
        /// <summary>
        /// ctor
        /// </summary>
        public UserEntity()
        {
            UserId = string.Empty;
            UserNo = string.Empty;
            UserName = string.Empty;
            UserPassWord = string.Empty;
            Remark = string.Empty;
            CreateId = string.Empty;
            LastModifyId = string.Empty;
        }
        /// <summary>
        /// 用户Id
        /// </summary>
        [DataMember]
        public string UserId { get; set; }
        /// <summary>
        /// 用户账号
        /// </summary>
        [DataMember]
        public string UserNo { get; set; }
        /// <summary>
        /// 用户名称
        /// </summary>
        [DataMember]
        public string UserName { get; set; }
        /// <summary>
        /// 用户密码
        /// </summary>
        [DataMember]
        public string UserPassWord { get; set; }
        /// <summary>
        /// 是否锁定
        /// </summary>
        [DataMember]
        public bool IsLock { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        [DataMember]
        public string Remark { get; set; }
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
        /// 是否启用用户权限
        /// </summary>
        [DataMember]
        public bool IsUserAuthority { get; set; }
    }

    /// <summary>
    /// 用户表(创建人姓名和最后修改人姓名)
    /// </summary>
    [DataContract(Namespace = "http://www.fengsharp.com/onecardaccess/")]
    public class UserWithCreateAndModify : UserEntity
    {
        /// <summary>
        /// ctor
        /// </summary>
        public UserWithCreateAndModify()
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
}
