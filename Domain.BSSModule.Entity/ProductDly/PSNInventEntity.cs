
using System;
using System.Runtime.Serialization;
namespace FengSharp.OneCardAccess.Domain.BSSModule.Entity
{
    /// <summary>
    /// 商品序列号库存表
    /// </summary>
    [DataContract(Namespace = "http://www.fengsharp.com/onecardaccess/")]
    public class PSNInventEntity
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public PSNInventEntity()
        {
            PSNInventId = string.Empty;
            PBNInventId = string.Empty;
            PInventId = string.Empty;
            BN = string.Empty;
            SN = string.Empty;

        }
        /// <summary>
        /// 商品序列号库存Id
        /// </summary>
        [DataMember]
        public string PSNInventId { get; set; }
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
        /// 序列号
        /// </summary>
        [DataMember]
        public string SN { get; set; }

    }
}
