using System;
using System.Runtime.Serialization;
namespace FengSharp.OneCardAccess.Domain.BSSModule.Entity
{
    /// <summary>
    /// 商品单据草稿序列号备份
    /// </summary>
    [DataContract(Namespace = "http://www.fengsharp.com/onecardaccess/")]
    public class PSNBakEntity
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public PSNBakEntity()
        {
            PSNBakId = string.Empty;
            DlyNdxId = string.Empty;
            PDlyBakId = string.Empty;
            SN = string.Empty;
            Remark = string.Empty;
            DlyDate = string.Empty;
            C_OrderNdxId = string.Empty;
            C_ProductOrderId = string.Empty;
            SN = string.Empty;
            JSRId = string.Empty;
        }
        /// <summary>
        /// 主键Id
        /// </summary>
        [DataMember]
        public string PSNBakId { get; set; }
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
        /// 商品单据草稿Id
        /// </summary>
        [DataMember]
        public string PDlyBakId { get; set; }
        /// <summary>
        /// 商品Id
        /// </summary>
        [DataMember]
        public int ProductId { get; set; }
        /// <summary>
        /// 往来单位Id
        /// </summary>
        [DataMember]
        public int CompanyId { get; set; }
        /// <summary>
        /// 仓库Id1
        /// </summary>
        [DataMember]
        public int StockId { get; set; }
        /// <summary>
        /// 经手人Id，员工Id
        /// </summary>
        [DataMember]
        public string JSRId { get; set; }
        /// <summary>
        /// 批号
        /// </summary>
        public string BN { get; set; }
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
        /// 单据日期
        /// </summary>
        [DataMember]
        public string DlyDate { get; set; }
        /// <summary>
        /// 订单索引表Id
        /// </summary>
        [DataMember]
        public string C_OrderNdxId { get; set; }
        /// <summary>
        /// 商品订单Id
        /// </summary>
        [DataMember]
        public string C_ProductOrderId { get; set; }
        /// <summary>
        /// 单据类型
        /// </summary>
        [DataMember]
        public int DlyTypeId { get; set; }
        /// <summary>
        /// 顺序
        /// </summary>
        [DataMember]
        public int SortNo { get; set; }
    }
    /// <summary>
    /// 序列号录入
    /// </summary>
    [DataContract(Namespace = "http://www.fengsharp.com/onecardaccess/")]
    public class SNInputEntity
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public SNInputEntity()
        {
            SN = string.Empty;
            BN = string.Empty;
        }
        /// <summary>
        /// 批号
        /// </summary>
        public string BN { get; set; }
        /// <summary>
        /// 序列号
        /// </summary>
        [DataMember]
        public string SN { get; set; }
        /// <summary>
        /// 顺序
        /// </summary>
        [DataMember]
        public int SortNo { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        [DataMember]
        public string Remark { get; set; }
    }
}
