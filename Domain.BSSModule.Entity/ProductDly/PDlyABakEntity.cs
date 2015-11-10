using System;
using System.Runtime.Serialization;
namespace FengSharp.OneCardAccess.Domain.BSSModule.Entity
{
    /// <summary>
    /// 商品单据资产明细备份
    /// </summary>
    [DataContract(Namespace = "http://www.fengsharp.com/onecardaccess/")]
    public class PDlyABakEntity
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public PDlyABakEntity()
        {
            PDlyABakId = string.Empty;
            DlyNdxId = string.Empty;
            DlyDate = string.Empty;
            Remark = string.Empty;

        }
        /// <summary>
        /// 主键Id
        /// </summary>
        [DataMember]
        public string PDlyABakId { get; set; }
        /// <summary>
        /// 单据索引表Id
        /// </summary>
        [DataMember]
        public string DlyNdxId { get; set; }
        /// <summary>
        /// 科目表Id
        /// </summary>
        [DataMember]
        public int ATypeId { get; set; }
        /// <summary>
        /// 往来单位Id
        /// </summary>
        [DataMember]
        public int CompanyId { get; set; }
        /// <summary>
        /// 经手人Id，员工Id
        /// </summary>
        [DataMember]
        public int JSRId { get; set; }
        /// <summary>
        /// 仓库Id
        /// </summary>
        [DataMember]
        public int StockId { get; set; }
        /// <summary>
        /// 金额
        /// </summary>
        [DataMember]
        public decimal Total { get; set; }
        /// <summary>
        /// 单据日期
        /// </summary>
        [DataMember]
        public string DlyDate { get; set; }
        /// <summary>
        /// 单据类型
        /// </summary>
        [DataMember]
        public int DlyTypeId { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        [DataMember]
        public string Remark { get; set; }

    }
}
