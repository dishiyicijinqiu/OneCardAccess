using System;
using System.Runtime.Serialization;
namespace FengSharp.OneCardAccess.Domain.HRModule.Entity
{
    /// <summary>
    /// 员工附件表
    /// </summary>
    [DataContract(Namespace = "http://www.fengsharp.com/onecardaccess/")]
    public class EmployeeAttachmentEntity
    {
        /// <summary>
        /// ctor
        /// </summary>
        public EmployeeAttachmentEntity()
        {
            Id = string.Empty;
            EmpId = string.Empty;
            ShowName = string.Empty;
            SaveName = string.Empty;

        }
        /// <summary>
        /// 主键Id
        /// </summary>
        [DataMember]
        public string Id { get; set; }
        /// <summary>
        /// 员工Id
        /// </summary>
        [DataMember]
        public string EmpId { get; set; }
        /// <summary>
        /// 附件名称
        /// </summary>
        [DataMember]
        public string ShowName { get; set; }
        /// <summary>
        /// 保存名称
        /// </summary>
        [DataMember]
        public string SaveName { get; set; }
    }
    /// <summary>
    /// 员工附件表
    /// </summary>
    public class EmployeeAttachmentEntityNewLogic : EmployeeAttachmentEntity
    {
        /// <summary>
        /// ctor
        /// </summary>
        public EmployeeAttachmentEntityNewLogic()
            : base()
        {
            IsNew = false;
        }
        /// <summary>
        /// 是否为新增
        /// </summary>
        public bool IsNew { get; set; }
    }
}
