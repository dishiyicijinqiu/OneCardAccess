
using System;
using System.Runtime.Serialization;
namespace FengSharp.OneCardAccess.Domain.BSSModule.Entity
{
    /// <summary>
    /// 商品序列号出入库明细表
    /// </summary>
    [DataContract(Namespace = "http://www.fengsharp.com/onecardaccess/")]
    public class PSNInOutDetailsEntity
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public PSNInOutDetailsEntity()
        {
            PSNInOutDetailId = string.Empty;
            PInOutDetailId = string.Empty;
            DlyNdxId = string.Empty;
            PDlyId = string.Empty;
            BN = string.Empty;
            InOutDate = string.Empty;
            SN = string.Empty;
            Remark = string.Empty;

        }
        /// <summary>
        /// 主键Id
        /// </summary>
        [DataMember]
        public string PSNInOutDetailId { get; set; }
        /// <summary>
        /// 商品出入库明细表Id
        /// </summary>
        [DataMember]
        public string PInOutDetailId { get; set; }
        /// <summary>
        /// 单据索引表Id
        /// </summary>
        [DataMember]
        public string DlyNdxId { get; set; }
        /// <summary>
        /// 商品单据表Id
        /// </summary>
        [DataMember]
        public string PDlyId { get; set; }
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
        /// 出入库日期
        /// </summary>
        [DataMember]
        public string InOutDate { get; set; }
        /// <summary>
        /// 序列号
        /// </summary>
        [DataMember]
        public string SN { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        [DataMember]
        public string Remark { get; set; }
        /// <summary>
        /// 顺序
        /// </summary>
        [DataMember]
        public int SortNo { get; set; }

    }
}
