using System;
using System.Runtime.Serialization;

namespace FengSharp.OneCardAccess.Domain.RBACModule.Entity
{
    /// <summary>
    /// 角色表
    /// </summary>
    [DataContract(Namespace = "http://www.fengsharp.com/onecardaccess/")]
    public class RoleEntity
    {
        /// <summary>
        /// 
        /// </summary>
        public RoleEntity()
        {
            RoleId = string.Empty;
            RoleNo = string.Empty;
            RoleName = string.Empty;
            Remark = string.Empty;
            CreateId = string.Empty;
            LastModifyId = string.Empty;
        }
        /// <summary>
        /// 角色Id
        /// </summary>
        [DataMember]
        public string RoleId { get; set; }
        /// <summary>
        /// 角色编号
        /// </summary>
        [DataMember]
        public string RoleNo { get; set; }
        /// <summary>
        /// 角色名称
        /// </summary>
        [DataMember]
        public string RoleName { get; set; }
        /// <summary>
        /// 是否锁定
        /// </summary>
        [DataMember]
        public bool IsLock { get; set; }
        /// <summary>
        /// 是否是超级管理员角色
        /// </summary>
        [DataMember]
        public bool IsSuper { get; set; }
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
    }

    /// <summary>
    /// 角色表(创建人姓名和最后修改人姓名)
    /// </summary>
    [DataContract(Namespace = "http://www.fengsharp.com/onecardaccess/")]
    public class RoleWithCreateAndModify : RoleEntity
    {

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
