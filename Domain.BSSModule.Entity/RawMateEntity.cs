

using System;
using System.Runtime.Serialization;
namespace FengSharp.OneCardAccess.Domain.BSSModule.Entity
{
    /// <summary>
    /// 原材料信息
    /// </summary>
    [DataContract(Namespace = "http://www.fengsharp.com/onecardaccess/")]
    public class RawMateEntity
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public RawMateEntity()
        {
            RawMateNo = string.Empty;
            RawMateName = string.Empty;
            Spec = string.Empty;
            Unit = string.Empty;
            Remark1 = string.Empty;
            Remark2 = string.Empty;
            Remark3 = string.Empty;
            Remark4 = string.Empty;
            Level_Path = string.Empty;
            CreateId = string.Empty;
            LastModifyId = string.Empty;

        }
        /// <summary>
        /// 主键Id
        /// </summary>
        [DataMember]
        public int RawMateId { get; set; }
        /// <summary>
        /// 原材料编号
        /// </summary>
        [DataMember]
        public string RawMateNo { get; set; }
        /// <summary>
        /// 原材料名称
        /// </summary>
        [DataMember]
        public string RawMateName { get; set; }
        /// <summary>
        /// 规格型号
        /// </summary>
        [DataMember]
        public string Spec { get; set; }
        /// <summary>
        /// 最小库存
        /// </summary>
        [DataMember]
        public decimal MinStore { get; set; }
        /// <summary>
        /// 最大库存
        /// </summary>
        [DataMember]
        public decimal MaxStore { get; set; }
        /// <summary>
        /// 计量单位
        /// </summary>
        [DataMember]
        public string Unit { get; set; }
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
        /// 父Id
        /// </summary>
        [DataMember]
        public int PId { get; set; }
        /// <summary>
        /// 树形结构路径
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
    /// 原材料信息
    /// </summary>
    [DataContract(Namespace = "http://www.fengsharp.com/onecardaccess/")]
    public class RawMateCMEntity : RawMateEntity
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public RawMateCMEntity()
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
    /// <summary>
    /// 原材料信息
    /// </summary>
    public class RawMateCMCateEntity : RawMateCMEntity
    {
        /// <summary>
        /// ctor
        /// </summary>
        public RawMateCMCateEntity()
            : base() { }
        /// <summary>
        /// 是否有分类
        /// </summary>
        [DataMember]
        public bool HasCate { get; set; }
    }
}
