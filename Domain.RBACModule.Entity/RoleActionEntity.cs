using System.Runtime.Serialization;

namespace FengSharp.OneCardAccess.Domain.RBACModule.Entity
{
    /// <summary>
    /// 角色功能表
    /// </summary>
    [DataContract(Namespace = "http://www.fengsharp.com/onecardaccess/")]
    public class RoleActionEntity
    {
        /// <summary>
        /// ctor
        /// </summary>
        public RoleActionEntity()
        {
            ActionNo = string.Empty;
            RoleId = string.Empty;
        }
        /// <summary>
        /// 角色Id
        /// </summary>
        [DataMember]
        public string RoleId { get; set; }
        /// <summary>
        /// 功能编号
        /// </summary>
        [DataMember]
        public string ActionNo { get; set; }
    }
}
