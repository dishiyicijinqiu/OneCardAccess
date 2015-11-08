using System.Runtime.Serialization;
namespace FengSharp.OneCardAccess.Domain.RBACModule.Entity
{
    /// <summary>
    /// 往来单位权限临时数据
    /// </summary>
    [DataContract(Namespace = "http://www.fengsharp.com/onecardaccess/")]
    public class CompanyRightTempEntity
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public CompanyRightTempEntity()
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
        /// 往来单位Id
        /// </summary>
        [DataMember]
        public int CompanyId { get; set; }
        /// <summary>
        /// 标识
        /// </summary>
        [DataMember]
        public string Flag { get; set; }
    }
    
    /// <summary>
    /// 往来单位权限临时数据
    /// </summary>
    [DataContract(Namespace = "http://www.fengsharp.com/onecardaccess/")]
    public class CompanyInfoRightStatusTempEntity : CompanyRightTempEntity
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public CompanyInfoRightStatusTempEntity()
            : base()
        {
            this.CompanyNo = string.Empty;
            this.CompanyName = string.Empty;
            this.Level_Path = string.Empty;
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
