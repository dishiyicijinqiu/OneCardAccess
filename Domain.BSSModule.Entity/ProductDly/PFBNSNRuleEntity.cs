using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace FengSharp.OneCardAccess.Domain.BSSModule.Entity
{
    /// <summary>
    /// 产品批号序列号规则
    /// </summary>
    public class PFBNSNRuleEntity
    {
        /// <summary>
        /// 总长度
        /// </summary>
        [DataMember]
        public int TotalLen { get; set; }
        /// <summary>
        /// 批号开始位置
        /// </summary>
        [DataMember]
        public int BNStartPos { get; set; }
        /// <summary>
        /// 批号结束位置
        /// </summary>
        [DataMember]
        public int BNEndPos { get; set; }
        /// <summary>
        /// 是否为序列号还是批号
        /// </summary>
        [DataMember]
        public bool IsSNOrFBN { get; set; }
    }
}
