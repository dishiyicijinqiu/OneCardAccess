using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace FengSharp.OneCardAccess.Domain.RBACModule.Entity
{
    /// <summary>
    /// 系统菜单表
    /// </summary>
    [DataContract(Namespace = "http://www.fengsharp.com/onecardaccess/")]
    public class MenuEntity
    {
        /// <summary>
        /// ctor
        /// </summary>
        public MenuEntity()
        {
            MenuNo = string.Empty;
            PNo = string.Empty;
            MenuName = string.Empty;
            Glyph = string.Empty;
            OnClick = string.Empty;
            KeyTip = string.Empty;
            MenuControl = string.Empty;
        }
        /// <summary>
        /// 菜单编号
        /// </summary>
        [DataMember]
        public string MenuNo { get; set; }
        /// <summary>
        /// 父级编号
        /// </summary>
        [DataMember]
        public string PNo { get; set; }
        /// <summary>
        /// 菜单名称
        /// </summary>
        [DataMember]
        public string MenuName { get; set; }
        /// <summary>
        /// 菜单序号
        /// </summary>
        [DataMember]
        public int Order { get; set; }
        /// <summary>
        /// 显示图像
        /// </summary>
        [DataMember]
        public string Glyph { get; set; }
        /// <summary>
        /// 点击事件
        /// </summary>
        [DataMember]
        public string OnClick { get; set; }
        /// <summary>
        /// 提示
        /// </summary>
        [DataMember]
        public string KeyTip { get; set; }
        /// <summary>
        /// 菜单编程控件
        /// </summary>
        [DataMember]
        public string MenuControl { get; set; }
    }
}
