

using System;
using System.Runtime.Serialization;
namespace FengSharp.OneCardAccess.Domain.BSSModule.Entity
{
    /// <summary>
    /// 单据类型表
    /// </summary>
    [DataContract(Namespace = "http://www.fengsharp.com/onecardaccess/")]
    public class DlyTypeEntity
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public DlyTypeEntity()
        {
            DlyName = string.Empty;
            Remark = string.Empty;
            DlyHeader = string.Empty;
            Level_Path = string.Empty;
            DlyFormat = string.Empty;

        }
        /// <summary>
        /// 单据类型表Id
        /// </summary>
        [DataMember]
        public int DlyTypeId { get; set; }
        /// <summary>
        /// 单据名称
        /// </summary>
        [DataMember]
        public string DlyName { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        [DataMember]
        public string Remark { get; set; }
        /// <summary>
        /// 单据编号标头
        /// </summary>
        [DataMember]
        public string DlyHeader { get; set; }
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
        /// 父Id
        /// </summary>
        [DataMember]
        public int PId { get; set; }
        /// <summary>
        /// 单据编号格式化字符串
        /// </summary>
        [DataMember]
        public string DlyFormat { get; set; }
        /// <summary>
        /// 审核级别
        /// </summary>
        [DataMember]
        public short InputLevel { get; set; }
    }
    /// <summary>
    /// 单据类型表
    /// </summary>
    public class DlyTypeCateEntity : DlyTypeEntity
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public DlyTypeCateEntity()
            : base()
        {
        }
        /// <summary>
        /// 是否有分类
        /// </summary>
        [DataMember]
        public bool HasCate { get; set; }
    }
}
