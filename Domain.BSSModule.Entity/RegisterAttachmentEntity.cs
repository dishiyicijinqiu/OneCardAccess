using System;
using System.Runtime.Serialization;
namespace FengSharp.OneCardAccess.Domain.BSSModule.Entity
{
    /// <summary>
    /// 注册证附件表
    /// </summary>
    [DataContract(Namespace = "http://www.fengsharp.com/onecardaccess/")]
    public class RegisterAttachmentEntity
    {
        /// <summary>
        /// ctor
        /// </summary>
        public RegisterAttachmentEntity()
        {
            Id = string.Empty;
            RegisterId = string.Empty;
            ShowName = string.Empty;
            SaveName = string.Empty;

        }
        /// <summary>
        /// 主键Id
        /// </summary>
        [DataMember]
        public string Id { get; set; }
        /// <summary>
        /// 注册证Id
        /// </summary>
        [DataMember]
        public string RegisterId { get; set; }
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
    /// 注册证附件表
    /// </summary>
    public class RegisterAttachmentEntityNewLogic : RegisterAttachmentEntity
    {
        /// <summary>
        /// ctor
        /// </summary>
        public RegisterAttachmentEntityNewLogic()
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
