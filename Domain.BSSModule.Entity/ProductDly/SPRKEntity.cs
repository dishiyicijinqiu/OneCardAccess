using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Linq;
namespace FengSharp.OneCardAccess.Domain.BSSModule.Entity
{
    /// <summary>
    /// 商品入库单
    /// </summary>
    [DataContract(Namespace = "http://www.fengsharp.com/onecardaccess/")]
    public class SPRKDlyNdxEntity : DlyNdxFullNameEntity
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public SPRKDlyNdxEntity()
            : base()
        {
        }
    }
    /// <summary>
    /// 商品入库草稿单
    /// </summary>
    [DataContract(Namespace = "http://www.fengsharp.com/onecardaccess/")]
    public class SPRKDlyCGNdxEntity : DlyNdxFullNameEntity
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public SPRKDlyCGNdxEntity()
            : base()
        {
        }
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
        List<PDlyABakEntity> _PDlyABaks;
        /// <summary>
        /// 单据资产明细备份
        /// </summary>
        [DataMember]
        public List<PDlyABakEntity> PDlyABaks
        {
            get
            {
                if (_PDlyABaks == null)
                    _PDlyABaks = new List<PDlyABakEntity>();
                return _PDlyABaks;
            }
            set
            {
                _PDlyABaks = value;
            }
        }
        /// <summary>
        /// 合计数量
        /// </summary>
        [DataMember]
        public decimal Qty { get; set; }
        //{
        //    get
        //    {
        //        return PDlyBaks.Sum(t => t.Qty);
        //    }
        //}
        /// <summary>
        /// 合计金额
        /// </summary>
        [DataMember]
        public override decimal Total { get; set; }
        //{
        //    get
        //    {
        //        return PDlyBaks.Sum(t => t.Total);
        //    }
        //}
        /// <summary>
        /// 优惠
        /// </summary>
        [DataMember]
        public decimal Prefer { get; set; }
        //private decimal _AfterPreferTotal;
        /// <summary>
        /// 优惠后金额
        /// </summary>
        [DataMember]
        public decimal AfterPreferTotal { get; set; }
        //{
        //    get
        //    {
        //        return this.Total - this.Prefer;
        //    }
        //}
    }
}
