using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace FengSharp.OneCardAccess.Infrastructure
{
    /// <summary>
    /// 字典数据
    /// </summary>
    [DataContract(Namespace = "http://www.fengsharp.com/onecardaccess/")]
    public class DicDataEntity
    {
        /// <summary>
        /// 字典数据类型
        /// </summary>
        [DataMember]
        public string DicType { get; set; }
        /// <summary>
        /// 字典值
        /// </summary>
        [DataMember]
        public string DicValue { get; set; }
    }
}
