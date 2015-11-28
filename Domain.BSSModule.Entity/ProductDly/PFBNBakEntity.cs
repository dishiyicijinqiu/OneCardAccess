using System;
using System.Runtime.Serialization;
namespace FengSharp.OneCardAccess.Domain.BSSModule.Entity
{
    /// <summary>
    /// 商品单据草稿批号备份
    /// </summary>
    [DataContract(Namespace = "http://www.fengsharp.com/onecardaccess/")]
    public class PFBNBakEntity
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public PFBNBakEntity()
        {
            PFBNBakId = string.Empty;
            DlyNdxId = string.Empty;
            PDlyBakId = string.Empty;
            FullBN = string.Empty;
            Remark = string.Empty;
            DlyDate = string.Empty;
            C_OrderNdxId = string.Empty;
            C_ProductOrderId = string.Empty;
            BN = string.Empty;
            JSRId = string.Empty;
        }
        /// <summary>
        /// 主键Id
        /// </summary>
        [DataMember]
        public string PFBNBakId { get; set; }
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
        [DataMember]
        public string BN { get; set; }
        /// <summary>
        /// 完整批号
        /// </summary>
        [DataMember]
        public string FullBN { get; set; }
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
        /// 数量
        /// </summary>
        [DataMember]
        public decimal Qty { get; set; }
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
    /// 批号录入
    /// </summary>
    [DataContract(Namespace = "http://www.fengsharp.com/onecardaccess/")]
    public class FBNInputEntity
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public FBNInputEntity()
        {
            FullBN = string.Empty;
            BN = string.Empty;
        }
        /// <summary>
        /// 批号
        /// </summary>
        public string BN { get; set; }
        /// <summary>
        /// 完整批号
        /// </summary>
        [DataMember]
        public string FullBN { get; set; }
        /// <summary>
        /// 数量
        /// </summary>
        [DataMember]
        public int Qty { get; set; }
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
    /// <summary>
    /// 批号选择
    /// </summary>
    [DataContract(Namespace = "http://www.fengsharp.com/onecardaccess/")]
    public class FBNSelectEntity
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public FBNSelectEntity()
        {
            FullBN = string.Empty;
            BN = string.Empty;
        }
        /// <summary>
        /// 批号
        /// </summary>
        public string BN { get; set; }
        /// <summary>
        /// 完整批号
        /// </summary>
        [DataMember]
        public string FullBN { get; set; }
        /// <summary>
        /// 数量
        /// </summary>
        [DataMember]
        public int Qty { get; set; }
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
        /// <summary>
        /// 选择数量
        /// </summary>
        [DataMember]
        public int SelectQty { get; set; }
    }
}
