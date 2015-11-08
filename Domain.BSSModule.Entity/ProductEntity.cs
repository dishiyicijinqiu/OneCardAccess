using System;
using System.Runtime.Serialization;
namespace FengSharp.OneCardAccess.Domain.BSSModule.Entity
{
    /// <summary>
    /// 产品信息
    /// </summary>
    [DataContract(Namespace = "http://www.fengsharp.com/onecardaccess/")]
    public class ProductEntity
    {
        /// <summary>
        /// ctor
        /// </summary>
        public ProductEntity()
        {
            ProductNo = string.Empty;
            ProductName = string.Empty;
            ProductName1 = string.Empty;
            Spec = string.Empty;
            Spec1 = string.Empty;
            ProductImage = string.Empty;
            Unit = string.Empty;
            Material = string.Empty;
            Code = string.Empty;
            GoodCode = string.Empty;
            CheckCodeOne = string.Empty;
            CheckCodeMany = string.Empty;
            RegisterId = string.Empty;
            Remark1 = string.Empty;
            Remark2 = string.Empty;
            Remark3 = string.Empty;
            Remark4 = string.Empty;
            Remark5 = string.Empty;
            Remark6 = string.Empty;
            Remark7 = string.Empty;
            Remark8 = string.Empty;
            ShowNo = string.Empty;
            ShowProductName = string.Empty;
            ShowSpec = string.Empty;
            ShowLOrR = string.Empty;
            ShowPos = string.Empty;
            NewRemark = string.Empty;
            Level_Path = string.Empty;
            CreateId = string.Empty;
            LastModifyId = string.Empty;

        }
        /// <summary>
        /// Id
        /// </summary>
        [DataMember]
        public int ProductId { get; set; }
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
        /// 商品名称(英文)
        /// </summary>
        [DataMember]
        public string ProductName1 { get; set; }
        /// <summary>
        /// 规格型号
        /// </summary>
        [DataMember]
        public string Spec { get; set; }
        /// <summary>
        /// 规格型号(英文)
        /// </summary>
        [DataMember]
        public string Spec1 { get; set; }
        /// <summary>
        /// 产品类型（成品，零部件）
        /// </summary>
        [DataMember]
        public short ProductType { get; set; }
        /// <summary>
        /// 产品大图
        /// </summary>
        [DataMember]
        public string ProductImage { get; set; }
        /// <summary>
        /// 计量单位
        /// </summary>
        [DataMember]
        public string Unit { get; set; }
        /// <summary>
        /// 材料标识
        /// </summary>
        [DataMember]
        public string Material { get; set; }
        /// <summary>
        /// 产品代码
        /// </summary>
        [DataMember]
        public string Code { get; set; }
        /// <summary>
        /// 货位号
        /// </summary>
        [DataMember]
        public string GoodCode { get; set; }
        /// <summary>
        /// 校验码（单）
        /// </summary>
        [DataMember]
        public string CheckCodeOne { get; set; }
        /// <summary>
        /// 校验码（多）
        /// </summary>
        [DataMember]
        public string CheckCodeMany { get; set; }
        /// <summary>
        /// 包装数量
        /// </summary>
        [DataMember]
        public int PackQty { get; set; }
        /// <summary>
        /// 证件类型（a证，b证）
        /// </summary>
        [DataMember]
        public short CertType { get; set; }
        /// <summary>
        /// 产品注册证Id
        /// </summary>
        [DataMember]
        public string RegisterId { get; set; }
        /// <summary>
        /// 最小库存
        /// </summary>
        [DataMember]
        public int MinStore { get; set; }
        /// <summary>
        /// 最大库存
        /// </summary>
        [DataMember]
        public int MaxStore { get; set; }
        /// <summary>
        /// 生产周期（小时）
        /// </summary>
        [DataMember]
        public decimal Cycle { get; set; }
        /// <summary>
        /// 图纸Id
        /// </summary>
        [DataMember]
        public int DrawingId { get; set; }
        /// <summary>
        /// 库存报警标识
        /// </summary>
        [DataMember]
        public bool IsRemind { get; set; }
        /// <summary>
        /// 数量模式（0，通用模式，1严格管理序列号，2严格管理批号）
        /// </summary>
        [DataMember]
        public short QtyMode { get; set; }
        /// <summary>
        /// 预设价格1
        /// </summary>
        [DataMember]
        public decimal preprice1 { get; set; }
        /// <summary>
        /// 预设价格2
        /// </summary>
        [DataMember]
        public decimal preprice2 { get; set; }
        /// <summary>
        /// 预设价格3
        /// </summary>
        [DataMember]
        public decimal preprice3 { get; set; }
        /// <summary>
        /// 零售价
        /// </summary>
        [DataMember]
        public decimal preprice4 { get; set; }
        /// <summary>
        /// 最近价格
        /// </summary>
        [DataMember]
        public decimal recprice { get; set; }
        /// <summary>
        /// 备注1
        /// </summary>
        [DataMember]
        public string Remark1 { get; set; }
        /// <summary>
        /// 备注2
        /// </summary>
        [DataMember]
        public string Remark2 { get; set; }
        /// <summary>
        /// 备注3
        /// </summary>
        [DataMember]
        public string Remark3 { get; set; }
        /// <summary>
        /// 备注4
        /// </summary>
        [DataMember]
        public string Remark4 { get; set; }
        /// <summary>
        /// 备注5
        /// </summary>
        [DataMember]
        public string Remark5 { get; set; }
        /// <summary>
        /// 备注6
        /// </summary>
        [DataMember]
        public string Remark6 { get; set; }
        /// <summary>
        /// 备注7
        /// </summary>
        [DataMember]
        public string Remark7 { get; set; }
        /// <summary>
        /// 备注8
        /// </summary>
        [DataMember]
        public string Remark8 { get; set; }
        /// <summary>
        /// 显示编号
        /// </summary>
        [DataMember]
        public string ShowNo { get; set; }
        /// <summary>
        /// 显示产品名称
        /// </summary>
        [DataMember]
        public string ShowProductName { get; set; }
        /// <summary>
        /// 显示规格型号
        /// </summary>
        [DataMember]
        public string ShowSpec { get; set; }
        /// <summary>
        /// 显示左右
        /// </summary>
        [DataMember]
        public string ShowLOrR { get; set; }
        /// <summary>
        /// 显示适应部位
        /// </summary>
        [DataMember]
        public string ShowPos { get; set; }
        /// <summary>
        /// 是否销售（所有show开头均为销售选项）
        /// </summary>
        [DataMember]
        public bool IsShow { get; set; }
        /// <summary>
        /// 是否为新品
        /// </summary>
        [DataMember]
        public bool IsNew { get; set; }
        /// <summary>
        /// 新品发布说明
        /// </summary>
        [DataMember]
        public string NewRemark { get; set; }
        /// <summary>
        /// 树性父结构代码
        /// </summary>
        [DataMember]
        public int PId { get; set; }
        /// <summary>
        /// 树性结构路径
        /// </summary>
        [DataMember]
        public string Level_Path { get; set; }
        /// <summary>
        /// 儿子数量
        /// </summary>
        [DataMember]
        public int Level_Num { get; set; }
        /// <summary>
        /// 子孙数量
        /// </summary>
        [DataMember]
        public int Level_Total { get; set; }
        /// <summary>
        /// 树的深度
        /// </summary>
        [DataMember]
        public int Level_Deep { get; set; }
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
        /// 最后更改人Id
        /// </summary>
        [DataMember]
        public string LastModifyId { get; set; }
        /// <summary>
        /// 最后更改日期
        /// </summary>
        [DataMember]
        public DateTime LastModifyDate { get; set; }
    }
    /// <summary>
    /// 产品信息
    /// </summary>
    public class ProductCMEntity : ProductEntity
    {
        /// <summary>
        /// ctor
        /// </summary>
        public ProductCMEntity()
            : base()
        {
        }
        /// <summary>
        /// 创建人姓名
        /// </summary>
        [DataMember]
        public string CreateName { get; set; }
        /// <summary>
        /// 最后更改人姓名
        /// </summary>
        [DataMember]
        public string LastModifyName { get; set; }
    }
    /// <summary>
    /// 产品信息
    /// </summary>
    public class ProductCMCateEntity : ProductCMEntity
    {
        /// <summary>
        /// ctor
        /// </summary>
        public ProductCMCateEntity()
            : base() { }
        /// <summary>
        /// 是否有分类
        /// </summary>
        [DataMember]
        public bool HasCate { get; set; }
    }

    /// <summary>
    /// 产品信息
    /// </summary>
    public class Product_Register_Draw_CMCateEntity : ProductCMCateEntity
    {
        /// <summary>
        /// ctor
        /// </summary>
        public Product_Register_Draw_CMCateEntity()
            : base()
        {

        }
        /// <summary>
        /// 注册证编号
        /// </summary>
        public string RegisterNo { get; set; }
        /// <summary>
        /// 注册产品名称
        /// </summary>
        public string RegisterProductName { get; set; }
        /// <summary>
        /// 标准号
        /// </summary>
        public string StandardCode { get; set; }
        /// <summary>
        /// 注册证编号（英文）
        /// </summary>
        public string RegisterNo1 { get; set; }
        /// <summary>
        /// 注册产品名称（英文）
        /// </summary>
        public string RegisterProductName1 { get; set; }
        /// <summary>
        /// 标准号（英文）
        /// </summary>
        public string StandardCode1 { get; set; }
        /// <summary>
        /// 图纸名称
        /// </summary>
        public string DrawingName { get; set; } 
    }
}
