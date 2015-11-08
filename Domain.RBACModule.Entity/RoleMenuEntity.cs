using System.Runtime.Serialization;

namespace FengSharp.OneCardAccess.Domain.RBACModule.Entity
{
    /// <summary>
    /// 角色菜单表
    /// </summary>
    [DataContract(Namespace = "http://www.fengsharp.com/onecardaccess/")]
    public class RoleMenuEntity
    {
        /// <summary>
        /// ctor
        /// </summary>
        public RoleMenuEntity()
        {
            MenuNo = string.Empty;
            RoleId = string.Empty;
        }
        /// <summary>
        /// 角色Id
        /// </summary>
        [DataMember]
        public string RoleId { get; set; }
        /// <summary>
        /// 菜单编号
        /// </summary>
        [DataMember]
        public string MenuNo { get; set; }
    }
}
