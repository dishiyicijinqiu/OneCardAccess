using System.Runtime.Serialization;

namespace FengSharp.OneCardAccess.Domain.RBACModule.Entity
{
    /// <summary>
    /// 原材料权限临时数据
    /// </summary>
    [DataContract(Namespace = "http://www.fengsharp.com/onecardaccess/")]
    public class RawMateRightTempEntity
    {  
        /// <summary>
        /// 构造函数
        /// </summary>
        public RawMateRightTempEntity()
        {
            this.Flag = string.Empty;
            this.RoleId = string.Empty;
        }
        /// <summary>
        /// 角色Id
        /// </summary>
        [DataMember]
        public string RoleId { get; set; }
        /// <summary>
        /// 原材料Id
        /// </summary>
        [DataMember]
        public int RawMateId { get; set; }
        /// <summary>
        /// 标识
        /// </summary>
        [DataMember]
        public string Flag { get; set; }
    }

    /// <summary>
    /// 原材料权限临时数据
    /// </summary>
    [DataContract(Namespace = "http://www.fengsharp.com/onecardaccess/")]
    public class RawMateInfoRightStatusTempEntity : RawMateRightTempEntity
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public RawMateInfoRightStatusTempEntity()
            : base()
        {
            this.RawMateNo = string.Empty;
            this.RawMateName = string.Empty;
            this.Spec = string.Empty;
            this.Level_Path = string.Empty;
        }
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
        /// 选中状态
        /// </summary>
        [DataMember]
        public bool Status { get; set; }
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
        /// 是否有分类
        /// </summary>
        [DataMember]
        public bool HasCate { get; set; }
    }
}
