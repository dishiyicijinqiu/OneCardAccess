using System;
using System.Runtime.Serialization;
namespace FengSharp.OneCardAccess.Domain.RBACModule.Entity
{
    /// <summary>
    /// 功能表
    /// </summary>
    [DataContract(Namespace = "http://www.fengsharp.com/onecardaccess/")]
    public class ActionEntity
    {
        /// <summary>
        /// ctor
        /// </summary>
        public ActionEntity()
        {
            ActionNo = string.Empty;
            ActionName = string.Empty;
            ParentActionNo = string.Empty;
            ActionType = string.Empty;
            Remark = string.Empty;
        }
        /// <summary>
        /// 功能编号
        /// </summary>
        [DataMember]
        public string ActionNo { get; set; }
        /// <summary>
        /// 功能名称
        /// </summary>
        [DataMember]
        public string ActionName { get; set; }
        /// <summary>
        /// 父级编号
        /// </summary>
        [DataMember]
        public string ParentActionNo { get; set; }
        /// <summary>
        /// 序号
        /// </summary>
        [DataMember]
        public int Order { get; set; }
        /// <summary>
        /// 类型
        /// </summary>
        [DataMember]
        public string ActionType { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        [DataMember]
        public string Remark { get; set; }
    }
}
