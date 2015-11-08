

using System;
using System.Runtime.Serialization;
namespace FengSharp.OneCardAccess.Domain.HRModule.Entity
{
    /// <summary>
    /// 部门
    /// </summary>
    [DataContract(Namespace = "http://www.fengsharp.com/onecardaccess/")]
    public class DeptEntity
    {
        /// <summary>
        /// ctor
        /// </summary>
        public DeptEntity()
        {
            DeptNo = string.Empty;
            DeptName = string.Empty;
            Remark = string.Empty;
            Level_Path = string.Empty;
            CreateId = string.Empty;
            LastModifyId = string.Empty;

        }
        /// <summary>
        /// 部门Id
        /// </summary>
        [DataMember]
        public int DeptId { get; set; }
        /// <summary>
        /// 部门编号
        /// </summary>
        [DataMember]
        public string DeptNo { get; set; }
        /// <summary>
        /// 部门名称
        /// </summary>
        [DataMember]
        public string DeptName { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        [DataMember]
        public string Remark { get; set; }
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
        /// <summary>
        /// 是否删除
        /// </summary>
        public bool Deleted { get; set; }
    }

    /// <summary>
    /// 部门
    /// </summary>
    [DataContract(Namespace = "http://www.fengsharp.com/onecardaccess/")]
    public class DeptCMEntity : DeptEntity
    {
        /// <summary>
        /// ctor
        /// </summary>
        public DeptCMEntity()
            : base()
        {
            CreateName = string.Empty;
            LastModifyName = string.Empty;
        }
        /// <summary>
        /// 创建人姓名
        /// </summary>
        [DataMember]
        public string CreateName { get; set; }
        /// <summary>
        /// 最后更改人姓名
        /// </summary>
        [DataMember]
        public string LastModifyName { get; set; }
    }

    /// <summary>
    /// 部门
    /// </summary>
    [DataContract(Namespace = "http://www.fengsharp.com/onecardaccess/")]
    public class DeptCMCateEntity : DeptCMEntity
    {
        /// <summary>
        /// ctor
        /// </summary>
        public DeptCMCateEntity()
            : base()
        {
        }
        /// <summary>
        /// 是否有分类
        /// </summary>
        [DataMember]
        public bool HasCate { get; set; }
    }

    /// <summary>
    /// 部门
    /// </summary>
    [DataContract(Namespace = "http://www.fengsharp.com/onecardaccess/")]
    public class DeptCateEntity : DeptEntity
    {
        /// <summary>
        /// ctor
        /// </summary>
        public DeptCateEntity()
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
