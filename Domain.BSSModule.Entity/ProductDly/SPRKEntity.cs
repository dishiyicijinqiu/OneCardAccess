using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Linq;
namespace FengSharp.OneCardAccess.Domain.BSSModule.Entity
{
    /// <summary>
    /// 商品单据草稿
    /// </summary>
    [DataContract(Namespace = "http://www.fengsharp.com/onecardaccess/")]
    public class PDlyNdxCGEntity : DlyNdxFullNameEntity
    {
        List<PDlyBakFullNameEntity> _PDlyBaks;
        /// <summary>
        /// 单据明细备份
        /// </summary>  
        [DataMember]
        public List<PDlyBakFullNameEntity> PDlyBaks
        {
            get
            {
                if (_PDlyBaks == null)
                    _PDlyBaks = new List<PDlyBakFullNameEntity>();
                return _PDlyBaks;
            }
            set
            {
                _PDlyBaks = value;
            }
        }
        /// <summary>
        /// 合计数量
        /// </summary>
        [DataMember]
        public decimal Qty { get; set; }
        /// <summary>
        /// 合计金额
        /// </summary>
        [DataMember]
        public override decimal Total { get; set; }
        /// <summary>
        /// 优惠
        /// </summary>
        [DataMember]
        public decimal Prefer { get; set; }
        /// <summary>
        /// 优惠后金额
        /// </summary>
        [DataMember]
        public decimal AfterPreferTotal { get; set; }
    }
    /// <summary>
    /// 商品已过帐单据
    /// </summary>
    [DataContract(Namespace = "http://www.fengsharp.com/onecardaccess/")]
    public class PDlyNdxYGZEntity : DlyNdxFullNameEntity
    {
        /// <summary>
        /// 合计数量
        /// </summary>
        [DataMember]
        public decimal Qty { get; set; }
        /// <summary>
        /// 合计金额
        /// </summary>
        [DataMember]
        public override decimal Total { get; set; }
        /// <summary>
        /// 优惠
        /// </summary>
        [DataMember]
        public decimal Prefer { get; set; }
        /// <summary>
        /// 优惠后金额
        /// </summary>
        [DataMember]
        public decimal AfterPreferTotal { get; set; }


        List<PDlyFullNameEntity> _PDlys;
        /// <summary>
        /// 单据明细备份
        /// </summary>  
        [DataMember]
        public List<PDlyFullNameEntity> PDlys
        {
            get
            {
                if (_PDlys == null)
                    _PDlys = new List<PDlyFullNameEntity>();
                return _PDlys;
            }
            set
            {
                _PDlys = value;
            }
        }
    }
    /// <summary>
    /// 商品入库草稿单
    /// </summary>
    [DataContract(Namespace = "http://www.fengsharp.com/onecardaccess/")]
    public class SPRKDlyCGNdxEntity : PDlyNdxCGEntity
    {
    }
    /// <summary>
    /// 商品入库单已过帐
    /// </summary>
    [DataContract(Namespace = "http://www.fengsharp.com/onecardaccess/")]
    public class SPRKDlyYGZNdxEntity : PDlyNdxYGZEntity
    {
    }

    /// <summary>
    /// 商品返工草稿单
    /// </summary>
    [DataContract(Namespace = "http://www.fengsharp.com/onecardaccess/")]
    public class SPFGDlyCGNdxEntity : PDlyNdxCGEntity
    {
    }

    /// <summary>
    /// 商品返工单已过帐
    /// </summary>
    [DataContract(Namespace = "http://www.fengsharp.com/onecardaccess/")]
    public class SPFGDlyYGZNdxEntity : PDlyNdxYGZEntity
    {
    }
}
