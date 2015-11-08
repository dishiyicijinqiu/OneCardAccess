using System;
using System.Runtime.Serialization;
namespace FengSharp.OneCardAccess.Domain.BSSModule.Entity
{
    /// <summary>
    /// 仓库表
    /// </summary>
    [DataContract(Namespace = "http://www.fengsharp.com/onecardaccess/")]
    public class StockEntity
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public StockEntity()
        {
            StockNo = string.Empty;
            StockName = string.Empty;
            CreateId = string.Empty;
            LastModifyId = string.Empty;
            Remark = string.Empty;
        }
        /// <summary>
        /// 主键Id
        /// </summary>
        [DataMember]
        public int StockId { get; set; }
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
        /// 最后修改人Id
        /// </summary>
        [DataMember]
        public string LastModifyId { get; set; }
        /// <summary>
        /// 最后修改日期
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
    /// 仓库表
    /// </summary>
    [DataContract(Namespace = "http://www.fengsharp.com/onecardaccess/")]
    public class StockCMEntity : StockEntity
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public StockCMEntity()
            : base()
        {
            CreateName = string.Empty;
            LastModifyName = string.Empty;
        }
        /// <summary>
        /// 创建人
        /// </summary>
        [DataMember]
        public string CreateName { get; set; }
        /// <summary>
        /// 最后更改人
        /// </summary>
        [DataMember]
        public string LastModifyName { get; set; }
    }
}
