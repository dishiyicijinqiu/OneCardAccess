using System;
using System.Runtime.Serialization;
namespace FengSharp.OneCardAccess.Domain.BSSModule.Entity
{
    /// <summary>
    /// 单据审核级别
    /// </summary>
    [DataContract(Namespace = "http://www.fengsharp.com/onecardaccess/")]
    public class DlyInputLevelEntity
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public DlyInputLevelEntity()
        {
            this.InputerId = InputerId;
        }
        /// <summary>
        ///自增Id
        /// </summary>
        [DataMember]
        public int Id { get; set; }
        /// <summary>
        /// 单据类型Id
        /// </summary>
        [DataMember]
        public int DlyTypeId { get; set; }
        /// <summary>
        /// 审核级别
        /// </summary>
        [DataMember]
        public short InputLevel { get; set; }
        /// <summary>
        /// 审核人Id
        /// </summary>
        [DataMember]
        public string InputerId { get; set; }
    }
    /// <summary>
    /// 单据审核级别
    /// </summary>
    [DataContract(Namespace = "http://www.fengsharp.com/onecardaccess/")]
    public class DlyInputLevelInputerEntity : DlyInputLevelEntity
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public DlyInputLevelInputerEntity()
            : base()
        {
            this.InputerName = InputerName;
        }
        /// <summary>
        /// 审核人姓名
        /// </summary>
        [DataMember]
        public string InputerName { get; set; }
    }
}
