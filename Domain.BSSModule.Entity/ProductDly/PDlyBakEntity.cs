using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
namespace FengSharp.OneCardAccess.Domain.BSSModule.Entity
{
    /// <summary>
    /// 商品单据草稿
    /// </summary>
    [DataContract(Namespace = "http://www.fengsharp.com/onecardaccess/")]
    public class PDlyBakEntity
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public PDlyBakEntity()
        {
            PDlyBakId = string.Empty;
            DlyNdxId = string.Empty;
            DlyDate = string.Empty;
            BN = string.Empty;
            Remark = string.Empty;
            C_OrderNdxId = string.Empty;
            C_ProductOrderId = string.Empty;

        }
        /// <summary>
        /// 主键Id
        /// </summary>
        [DataMember]
        public string PDlyBakId { get; set; }
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
        /// 单据类型
        /// </summary>
        [DataMember]
        public int DlyTypeId { get; set; }
        /// <summary>
        /// 单据日期
        /// </summary>
        [DataMember]
        public string DlyDate { get; set; }
        /// <summary>
        /// 经手人Id，员工Id
        /// </summary>
        [DataMember]
        public int JSRId { get; set; }
        /// <summary>
        /// 仓库Id1
        /// </summary>
        [DataMember]
        public int StockId1 { get; set; }
        /// <summary>
        /// 仓库Id2
        /// </summary>
        [DataMember]
        public int StockId2 { get; set; }
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
        /// 数量
        /// </summary>
        [DataMember]
        public decimal Qty { get; set; }
        /// <summary>
        /// 成本单价
        /// </summary>
        [DataMember]
        public double CostPrice { get; set; }
        /// <summary>
        /// 成本金额
        /// </summary>
        [DataMember]
        public decimal CostTotal { get; set; }
        /// <summary>
        /// 单价
        /// </summary>
        [DataMember]
        public double Price { get; set; }
        /// <summary>
        /// 金额
        /// </summary>
        [DataMember]
        public virtual decimal Total { get; set; }
        /// <summary>
        /// 折扣(--)
        /// </summary>
        [DataMember]
        public decimal DisCount { get; set; }
        /// <summary>
        /// 折后单价 单价*折扣(--)
        /// </summary>
        [DataMember]
        public double DisPrice { get; set; }
        /// <summary>
        /// 折后金额 金额*折扣(--)
        /// </summary>
        [DataMember]
        public decimal DisTotal { get; set; }
        /// <summary>
        /// 税率(%?)(--)
        /// </summary>
        [DataMember]
        public decimal TaxRate { get; set; }
        /// <summary>
        /// 税额  折后金额*税率(--)
        /// </summary>
        [DataMember]
        public decimal Tax { get; set; }
        /// <summary>
        /// 含税单价 折后单价+(折后单价*税率)(--)
        /// </summary>
        [DataMember]
        public double TaxPrice { get; set; }
        /// <summary>
        /// 含税金额 折后金额+税额(--)
        /// </summary>
        [DataMember]
        public decimal TaxTotal { get; set; }
        /// <summary>
        /// 零售价格(--)
        /// </summary>
        [DataMember]
        public double RetailPrice { get; set; }
        /// <summary>
        /// 开票金额(--)
        /// </summary>
        [DataMember]
        public decimal InvoceTotal { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        [DataMember]
        public string Remark { get; set; }
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
        /// 顺序
        /// </summary>
        [DataMember]
        public int SortNo { get; set; }

        List<PFBNBakEntity> _PFBNBaks;
        /// <summary>
        /// 商品单据草稿批号备份
        /// </summary>
        [DataMember]
        public List<PFBNBakEntity> PFBNBaks
        {
            get
            {
                if (_PFBNBaks == null)
                {
                    _PFBNBaks = new List<PFBNBakEntity>();
                }
                return _PFBNBaks;
            }
            set
            {
                _PFBNBaks = value;
            }
        }
        List<PSNBakEntity> _PSNBaks;
        /// <summary>
        /// 商品单据草稿序列号备份
        /// </summary>
        [DataMember]
        public List<PSNBakEntity> PSNBaks
        {
            get
            {
                if (_PSNBaks == null)
                {
                    _PSNBaks = new List<PSNBakEntity>();
                }
                return _PSNBaks;
            }
            set
            {
                _PSNBaks = value;
            }
        }
    }

    /// <summary>
    /// 商品单据草稿
    /// </summary>
    [DataContract(Namespace = "http://www.fengsharp.com/onecardaccess/")]
    public class PDlyBakFullNameEntity : PDlyBakEntity
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public PDlyBakFullNameEntity()
            : base()
        {
        }
        /// <summary>
        /// 产品编号
        /// </summary>
        [DataMember]
        public string ProductNo { get; set; }
        /// <summary>
        /// 商品名称
        /// </summary>
        [DataMember]
        public string ProductName { get; set; }
        /// <summary>
        /// 规格型号
        /// </summary>
        [DataMember]
        public string Spec { get; set; }
        /// <summary>
        /// 货位号
        /// </summary>
        [DataMember]
        public string GoodCode { get; set; }
        /// <summary>
        /// 单位
        /// </summary>
        [DataMember]
        public string Unit { get; set; }
        /// <summary>
        /// 数量模式
        /// </summary>
        [DataMember]
        public short QtyMode { get; set; }
        /// <summary>
        /// 金额
        /// </summary>
        [DataMember]
        //public virtual decimal Total { get; set; }
        public override decimal Total
        {
            get
            {
                return this.Qty * (decimal)this.Price;
            }
            set
            {
                base.Total = value;
            }
        }
    }
}
