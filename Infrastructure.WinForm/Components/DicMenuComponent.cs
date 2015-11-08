using FengSharp.OneCardAccess.Infrastructure.WinForm.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using System.Windows.Forms;

namespace FengSharp.OneCardAccess.Infrastructure.WinForm.Components
{
    [ToolboxItem(true)]
    [Description("字典菜单配置")]
    [ProvideProperty("EnableMenu", typeof(Control))]
    [ProvideProperty("EnableAddMenu", typeof(Control))]
    [ProvideProperty("EnableDeleteMenu", typeof(Control))]
    [ProvideProperty("CustomAddClick", typeof(Control))]
    [ProvideProperty("CustomDeleteClick", typeof(Control))]
    public partial class DicMenuComponent : Component, IExtenderProvider
    {
        #region IExtenderProvider
        private Dictionary<Control, DicMenuPara> list = null;
        public DicMenuComponent()
        {
            InitializeComponent();
            list = new Dictionary<Control, DicMenuPara>();
        }

        public DicMenuComponent(IContainer container)
        {
            container.Add(this);
            InitializeComponent();
            list = new Dictionary<Control, DicMenuPara>();
        }

        public bool CanExtend(object extendee)
        {
            return ((extendee is MyLookUpEdit));
        }
        #endregion
        private DicMenuPara GetDefaultPara()
        {
            return new DicMenuPara()
            {
                CustomAddClick = null,
                CustomDeleteClick = null,
                EnableAddMenu = false,
                EnableDeleteMenu = false,
                EnableMenu = false
            };
        }
        [Category("字典菜单配置")]
        [Description("是否启用菜单")]
        public bool GetEnableMenu(Control ctl)
        {
            if (this.list.ContainsKey(ctl))
            {
                return list[ctl].EnableMenu;
            }
            return false;
        }
        public void SetEnableMenu(Control ctl, bool enablemenu)
        {
            if (!this.list.ContainsKey(ctl))
            {
                var para = GetDefaultPara();
                para.EnableMenu = enablemenu;
                this.list.Add(ctl, para);
            }
            else
            {
                this.list[ctl].EnableMenu = enablemenu;
            }
            DoStyle(ctl);
        }
        [Category("字典菜单配置")]
        [Description("是否启用新增按钮")]
        public bool GetEnableAddMenu(Control ctl)
        {
            if (this.list.ContainsKey(ctl))
            {
                return list[ctl].EnableAddMenu;
            }
            return false;
        }
        public void SetEnableAddMenu(Control ctl, bool enableaddmenu)
        {
            if (!this.list.ContainsKey(ctl))
            {
                var para = GetDefaultPara();
                para.EnableAddMenu = enableaddmenu;
                this.list.Add(ctl, para);
            }
            else
            {
                this.list[ctl].EnableAddMenu = enableaddmenu;
            }
            DoStyle(ctl);
        }

        [Category("字典菜单配置")]
        [Description("是否启用删除按钮")]
        public bool GetEnableDeleteMenu(Control ctl)
        {
            if (this.list.ContainsKey(ctl))
            {
                return list[ctl].EnableDeleteMenu;
            }
            return false;
        }
        public void SetEnableDeleteMenu(Control ctl, bool enabledeletemenu)
        {
            if (!this.list.ContainsKey(ctl))
            {
                var para = GetDefaultPara();
                para.EnableDeleteMenu = enabledeletemenu;
                this.list.Add(ctl, para);
            }
            else
            {
                this.list[ctl].EnableDeleteMenu = enabledeletemenu;
            }
            DoStyle(ctl);
        }


        [Category("字典菜单配置")]
        [Description("自定义新增按钮事件")]
        public EventHandler GetCustomAddClick(Control ctl)
        {
            if (this.list.ContainsKey(ctl))
            {
                return list[ctl].CustomAddClick;
            }
            return null;
        }
        public void SetCustomAddClick(Control ctl, EventHandler customaddclick)
        {
            if (!this.list.ContainsKey(ctl))
            {
                var para = GetDefaultPara();
                para.CustomAddClick = customaddclick;
                this.list.Add(ctl, para);
            }
            else
            {
                this.list[ctl].CustomAddClick = customaddclick;
            }
            DoStyle(ctl);
        }


        [Category("字典菜单配置")]
        [Description("自定义删除按钮事件")]
        public EventHandler GetCustomDeleteClick(Control ctl)
        {
            if (this.list.ContainsKey(ctl))
            {
                return list[ctl].CustomDeleteClick;
            }
            return null;
        }
        public void SetCustomDeleteClick(Control ctl, EventHandler customdeleteclick)
        {
            if (!this.list.ContainsKey(ctl))
            {
                var para = GetDefaultPara();
                para.CustomDeleteClick = customdeleteclick;
                this.list.Add(ctl, para);
            }
            else
            {
                this.list[ctl].CustomDeleteClick = customdeleteclick;
            }
            DoStyle(ctl);
        }

        private void DoStyle(Control ctl)
        {
            if (!this.list.ContainsKey(ctl))
            {
                return;
            }
            var para = this.list[ctl];
            if (para.EnableMenu)
            {
                var field = ctl.GetType().GetField("_Menu", BindingFlags.Instance | BindingFlags.NonPublic);
                if (field != null)
                {
                    var menu = new AddDeleteDXPopupMenu();
                    menu.EnableAdd = para.EnableAddMenu;
                    menu.EnableDelete = para.EnableDeleteMenu;
                    menu.AddClicked -= para.CustomAddClick;
                    menu.AddClicked += para.CustomAddClick;
                    menu.DeleteClicked -= para.CustomDeleteClick;
                    menu.DeleteClicked += para.CustomDeleteClick;
                    field.SetValue(ctl, menu);
                }
            }
        }
    }
    public class DicMenuPara
    {
        public bool EnableMenu { get; set; }
        public bool EnableAddMenu { get; set; }
        public bool EnableDeleteMenu { get; set; }
        public EventHandler CustomAddClick { get; set; }
        public EventHandler CustomDeleteClick { get; set; }
    }
}
