
using System;
using System.Runtime.Serialization;
namespace FengSharp.OneCardAccess.Domain.BSSModule.Entity
{
    /// <summary>
    /// 商品完整批号库存表
    /// </summary>
    [DataContract(Namespace = "http://www.fengsharp.com/onecardaccess/")]
    public class PFBNInventEntity
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public PFBNInventEntity()
        {
            PFBNInventId = string.Empty;
            PBNInventId = string.Empty;
            PInventId = string.Empty;
            BN = string.Empty;
            FullBN = string.Empty;

        }
        /// <summary>
        /// 商品完整批号库存Id
        /// </summary>
        [DataMember]
        public string PFBNInventId { get; set; }
        /// <summary>
        /// 商品批号库存Id
        /// </summary>
        [DataMember]
        public string PBNInventId { get; set; }
        /// <summary>
        /// 商品库存Id
        /// </summary>
        [DataMember]
        public string PInventId { get; set; }
        /// <summary>
        /// 商品Id
        /// </summary>
        [DataMember]
        public int ProductId { get; set; }
        /// <summary>
        /// 批号
        /// </summary>
        [DataMember]
        public string BN { get; set; }
        /// <summary>
        /// 仓库Id
        /// </summary>
        [DataMember]
        public int StockId { get; set; }
        /// <summary>
        /// 完整批号
        /// </summary>
        [DataMember]
        public string FullBN { get; set; }
        /// <summary>
        /// 数量
        /// </summary>
        [DataMember]
        public decimal Qty { get; set; }

    }
}
