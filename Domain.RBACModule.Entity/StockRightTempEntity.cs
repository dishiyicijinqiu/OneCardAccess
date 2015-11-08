using System.Runtime.Serialization;

namespace FengSharp.OneCardAccess.Domain.RBACModule.Entity
{
    /// <summary>
    /// 仓库权限临时数据
    /// </summary>
    [DataContract(Namespace = "http://www.fengsharp.com/onecardaccess/")]
    public class StockRightTempEntity
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public StockRightTempEntity()
        {
            this.Flag = string.Empty;
            this.RoleId = string.Empty;
        }
        /// <summary>
        /// 角色Id
        /// </summary>
        [DataMember]
        public string RoleId { get; set; }
        /// <summary>
        /// 仓库Id
        /// </summary>
        [DataMember]
        public int StockId { get; set; }
        /// <summary>
        /// 标识
        /// </summary>
        [DataMember]
        public string Flag { get; set; }
    }
    /// <summary>
    /// 仓库权限临时数据
    /// </summary>
    [DataContract(Namespace = "http://www.fengsharp.com/onecardaccess/")]
    public class StockInfoRightTempStatusEntity : StockRightTempEntity
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public StockInfoRightTempStatusEntity()
            : base()
        {
            this.StockNo = string.Empty;
            this.StockName = string.Empty;
        }
        /// <summary>
        /// 仓库编号
        /// </summary>
        [DataMember]
        public string StockNo { get; set; }
        /// <summary>
        /// 仓库名称
        /// </summary>
        [DataMember]
        public string StockName { get; set; }
        /// <summary>
        /// 选中状态
        /// </summary>
        [DataMember]
        public bool Status { get; set; }
    }
}
