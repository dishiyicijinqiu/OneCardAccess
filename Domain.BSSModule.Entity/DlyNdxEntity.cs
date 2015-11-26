using System;
using System.Runtime.Serialization;
namespace FengSharp.OneCardAccess.Domain.BSSModule.Entity
{
    /// <summary>
    /// 单据索引表
    /// </summary>
    [DataContract(Namespace = "http://www.fengsharp.com/onecardaccess/")]
    public class DlyNdxEntity
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public DlyNdxEntity()
        {
            DlyNdxId = string.Empty;
            DlyNo = string.Empty;
            DlyDate = string.Empty;
            Summary = string.Empty;
            Comment = string.Empty;
            ZDRId = string.Empty;
            SHRId1 = string.Empty;
            SHRId2 = string.Empty;
            SHRId3 = string.Empty;
            SHRId4 = string.Empty;
            SHRId5 = string.Empty;
            QGNo = string.Empty;
            QGDate = string.Empty;
            QGR = string.Empty;
            YDJNo = string.Empty;
            BuyDate = string.Empty;
            Buyer = string.Empty;
            LXR = string.Empty;
            LXFS = string.Empty;
            JSRId = string.Empty;
        }
        /// <summary>
        /// 单据索引表Id
        /// </summary>
        [DataMember]
        public string DlyNdxId { get; set; }
        /// <summary>
        /// 单据编号
        /// </summary>
        [DataMember]
        public string DlyNo { get; set; }
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
        /// 往来单位Id
        /// </summary>
        [DataMember]
        public int CompanyId { get; set; }
        /// <summary>
        /// 经手人Id，员工Id
        /// </summary>
        [DataMember]
        public string JSRId { get; set; }
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
        /// (是否过账0为草稿，1为过账,2被红冲标记，3红冲标记,4临时单据)
        /// </summary>
        [DataMember]
        public short Draft { get; set; }
        /// <summary>
        /// 摘要
        /// </summary>
        [DataMember]
        public string Summary { get; set; }
        /// <summary>
        /// 附加说明
        /// </summary>
        [DataMember]
        public string Comment { get; set; }
        /// <summary>
        /// 制单人Id,系统用户Id
        /// </summary>
        [DataMember]
        public string ZDRId { get; set; }
        /// <summary>
        /// 一级审核人,系统用户Id
        /// </summary>
        [DataMember]
        public string SHRId1 { get; set; }
        /// <summary>
        /// 二级审核人,系统用户Id
        /// </summary>
        [DataMember]
        public string SHRId2 { get; set; }
        /// <summary>
        /// 三级审核人,系统用户Id
        /// </summary>
        [DataMember]
        public string SHRId3 { get; set; }
        /// <summary>
        /// 四级审核人,系统用户Id
        /// </summary>
        [DataMember]
        public string SHRId4 { get; set; }
        /// <summary>
        /// 五级审核人,系统用户Id
        /// </summary>
        [DataMember]
        public string SHRId5 { get; set; }
        /// <summary>
        /// 是否开票
        /// </summary>
        [DataMember]
        public bool IsInvoce { get; set; }
        /// <summary>
        /// 金额
        /// </summary>
        [DataMember]
        public virtual decimal Total { get; set; }
        /// <summary>
        /// 请购单号
        /// </summary>
        [DataMember]
        public string QGNo { get; set; }
        /// <summary>
        /// 请购日期
        /// </summary>
        [DataMember]
        public string QGDate { get; set; }
        /// <summary>
        /// 请购人
        /// </summary>
        [DataMember]
        public string QGR { get; set; }
        /// <summary>
        /// 原单据号
        /// </summary>
        [DataMember]
        public string YDJNo { get; set; }
        /// <summary>
        /// 购买日期
        /// </summary>
        [DataMember]
        public string BuyDate { get; set; }
        /// <summary>
        /// 购买人
        /// </summary>
        [DataMember]
        public string Buyer { get; set; }
        /// <summary>
        /// 联系人
        /// </summary>
        [DataMember]
        public string LXR { get; set; }
        /// <summary>
        /// 联系方式
        /// </summary>
        [DataMember]
        public string LXFS { get; set; }
        /// <summary>
        /// 最后一个审核人
        /// </summary>
        public string LastSHRId
        {
            get
            {
                if (!string.IsNullOrWhiteSpace(this.SHRId5))
                    return this.SHRId5;
                if (!string.IsNullOrWhiteSpace(this.SHRId4))
                    return this.SHRId4;
                if (!string.IsNullOrWhiteSpace(this.SHRId3))
                    return this.SHRId3;
                if (!string.IsNullOrWhiteSpace(this.SHRId2))
                    return this.SHRId2;
                if (!string.IsNullOrWhiteSpace(this.SHRId1))
                    return this.SHRId1;
                return string.Empty;
            }
        }
    }
    /// <summary>
    /// 单据索引表
    /// </summary>
    [DataContract(Namespace = "http://www.fengsharp.com/onecardaccess/")]
    public class DlyNdxFullNameEntity : DlyNdxEntity
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public DlyNdxFullNameEntity()
            : base()
        {
            this.CompanyNo = string.Empty;
            this.CompanyName = string.Empty;
            this.JSRName = string.Empty;
            this.StockNo1 = string.Empty;
            this.StockName1 = string.Empty;
            this.StockNo2 = string.Empty;
            this.StockName2 = string.Empty;
            this.ZDRName = string.Empty;
            this.SHRName1 = string.Empty;
            this.SHRName2 = string.Empty;
            this.SHRName3 = string.Empty;
            this.SHRName4 = string.Empty;
            this.SHRName5 = string.Empty;
        }
        /// <summary>
        /// 往来单位编号
        /// </summary>
        [DataMember]
        public string CompanyNo { get; set; }
        /// <summary>
        /// 往来单位名称
        /// </summary>
        [DataMember]
        public string CompanyName { get; set; }
        /// <summary>
        /// 经手人
        /// </summary>
        [DataMember]
        public string JSRName { get; set; }
        /// <summary>
        /// 仓库1编号
        /// </summary>
        [DataMember]
        public virtual string StockNo1 { get; set; }
        /// <summary>
        /// 仓库1名称
        /// </summary>
        [DataMember]
        public virtual string StockName1 { get; set; }
        /// <summary>
        /// 仓库2编号
        /// </summary>
        [DataMember]
        public virtual string StockNo2 { get; set; }
        /// <summary>
        /// 仓库2名称
        /// </summary>
        [DataMember]
        public virtual string StockName2 { get; set; }
        /// <summary>
        /// 制单人姓名
        /// </summary>
        [DataMember]
        public string ZDRName { get; set; }
        /// <summary>
        /// 一级审核人
        /// </summary>
        [DataMember]
        public string SHRName1 { get; set; }
        /// <summary>
        /// 二级审核人
        /// </summary>
        [DataMember]
        public string SHRName2 { get; set; }
        /// <summary>
        /// 三级审核人
        /// </summary>
        [DataMember]
        public string SHRName3 { get; set; }
        /// <summary>
        /// 四级审核人
        /// </summary>
        [DataMember]
        public string SHRName4 { get; set; }
        /// <summary>
        /// 五级审核人
        /// </summary>
        [DataMember]
        public string SHRName5 { get; set; }
    }


}
