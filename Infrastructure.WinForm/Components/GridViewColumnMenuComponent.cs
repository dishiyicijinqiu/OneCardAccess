using DevExpress.Utils.Menu;
using DevExpress.XtraGrid.Views.Grid;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace FengSharp.OneCardAccess.Infrastructure.WinForm.Components
{
    [ToolboxItem(true)]
    [Description("GridView列菜单配置")]
    [ProvideProperty("EnableColumnMenu", typeof(GridView))]
    [ProvideProperty("EnableGroupByThisColumn", typeof(GridView))]
    [ProvideProperty("EnableShowGroupBox", typeof(GridView))]
    [ProvideProperty("EnableRemoveColumn", typeof(GridView))]
    [ProvideProperty("EnableColumnSelect", typeof(GridView))]
    [ProvideProperty("EnableBestFit", typeof(GridView))]
    [ProvideProperty("EnableBestFitAll", typeof(GridView))]
    public partial class GridViewColumnMenuComponent : Component, IExtenderProvider
    {
        private Dictionary<GridView, GridViewColumnMenuPara> list = null;
        public GridViewColumnMenuComponent()
        {
            InitializeComponent();
            list = new Dictionary<GridView, GridViewColumnMenuPara>();
        }
        public GridViewColumnMenuComponent(IContainer container)
        {
            container.Add(this);
            InitializeComponent();
            list = new Dictionary<GridView, GridViewColumnMenuPara>();
        }
        public bool CanExtend(object extendee)
        {
            return extendee is GridView;
        }
        [Category("Menu")]
        [Description("EnableColumnMenu"), DefaultValue(false)]
        public bool GetEnableColumnMenu(GridView gv)
        {
            if (this.list.ContainsKey(gv))
            {
                return list[gv].EnableColumnMenu;
            }
            return true;
        }
        public void SetEnableColumnMenu(GridView gv, bool enableColumnMenu)
        {
            if (!this.list.ContainsKey(gv))
            {
                this.list.Add(gv, new GridViewColumnMenuPara() { EnableColumnMenu = enableColumnMenu });
            }
            else
            {
                this.list[gv].EnableColumnMenu = enableColumnMenu;
            }
            gv.PopupMenuShowing -= gv_PopupMenuShowing;
            if (enableColumnMenu)
            {
                gv.PopupMenuShowing += gv_PopupMenuShowing;
            }
        }

        void gv_PopupMenuShowing(object sender, PopupMenuShowingEventArgs e)
        {
            if (e.Menu == null) return;
            GridView gv = sender as GridView;
            if (!this.list.ContainsKey(gv))
                return;
            var para = this.list[gv];
            if (!para.EnableGroupByThisColumn)
            {
                var menuitem = e.Menu.Items.Cast<DXMenuItem>().FirstOrDefault(t => ((t.Tag != null) && ((DevExpress.XtraGrid.Localization.GridStringId)t.Tag
                    == DevExpress.XtraGrid.Localization.GridStringId.MenuColumnGroup)));
                if (menuitem != null)
                    menuitem.Visible = false;
            }
            if (!para.EnableShowGroupBox)
            {
                var menuitem = e.Menu.Items.Cast<DXMenuItem>().FirstOrDefault(t => ((t.Tag != null) && ((DevExpress.XtraGrid.Localization.GridStringId)t.Tag
                    == DevExpress.XtraGrid.Localization.GridStringId.MenuColumnGroupBox)));
                if (menuitem != null)
                    menuitem.Visible = false;
            }
            if (!para.EnableRemoveColumn)
            {
                var menuitem = e.Menu.Items.Cast<DXMenuItem>().FirstOrDefault(t => ((t.Tag != null) && ((DevExpress.XtraGrid.Localization.GridStringId)t.Tag
                    == DevExpress.XtraGrid.Localization.GridStringId.MenuColumnRemoveColumn)));
                if (menuitem != null)
                    menuitem.Visible = false;
            }
            if (!para.EnableColumnSelect)
            {
                var menuitem = e.Menu.Items.Cast<DXMenuItem>().FirstOrDefault(t => ((t.Tag != null) && ((DevExpress.XtraGrid.Localization.GridStringId)t.Tag
                    == DevExpress.XtraGrid.Localization.GridStringId.MenuColumnColumnCustomization)));
                if (menuitem != null)
                    menuitem.Visible = false;
            }
            if (!para.EnableBestFit)
            {
                var menuitem = e.Menu.Items.Cast<DXMenuItem>().FirstOrDefault(t => ((t.Tag != null) && ((DevExpress.XtraGrid.Localization.GridStringId)t.Tag
                    == DevExpress.XtraGrid.Localization.GridStringId.MenuColumnBestFit)));
                if (menuitem != null)
                    menuitem.Visible = false;
            }
            if (!para.EnableBestFitAll)
            {
                var menuitem = e.Menu.Items.Cast<DXMenuItem>().FirstOrDefault(t => ((t.Tag != null) && ((DevExpress.XtraGrid.Localization.GridStringId)t.Tag
                    == DevExpress.XtraGrid.Localization.GridStringId.MenuColumnBestFitAllColumns)));
                if (menuitem != null)
                    menuitem.Visible = false;
            }
        }

        [Category("Menu")]
        [Description("EnableGroupByThisColumn"), DefaultValue(false)]
        public bool GetEnableGroupByThisColumn(GridView gv)
        {
            if (this.list.ContainsKey(gv))
            {
                return list[gv].EnableGroupByThisColumn;
            }
            return true;
        }
        public void SetEnableGroupByThisColumn(GridView gv, bool enableGroupByThisColumn)
        {
            if (!this.list.ContainsKey(gv))
            {
                this.list.Add(gv, new GridViewColumnMenuPara() { EnableGroupByThisColumn = enableGroupByThisColumn });
            }
            else
            {
                this.list[gv].EnableGroupByThisColumn = enableGroupByThisColumn;
            }
        }

        [Category("Menu")]
        [Description("EnableShowGroupBox"), DefaultValue(false)]
        public bool GetEnableShowGroupBox(GridView gv)
        {
            if (this.list.ContainsKey(gv))
            {
                return list[gv].EnableShowGroupBox;
            }
            return true;
        }
        public void SetEnableShowGroupBox(GridView gv, bool enableShowGroupBox)
        {
            if (!this.list.ContainsKey(gv))
            {
                this.list.Add(gv, new GridViewColumnMenuPara() { EnableShowGroupBox = enableShowGroupBox });
            }
            else
            {
                this.list[gv].EnableShowGroupBox = enableShowGroupBox;
            }
        }

        [Category("Menu")]
        [Description("EnableRemoveColumn"), DefaultValue(false)]
        public bool GetEnableRemoveColumn(GridView gv)
        {
            if (this.list.ContainsKey(gv))
            {
                return list[gv].EnableRemoveColumn;
            }
            return true;
        }
        public void SetEnableRemoveColumn(GridView gv, bool enableRemoveColumn)
        {
            if (!this.list.ContainsKey(gv))
            {
                this.list.Add(gv, new GridViewColumnMenuPara() { EnableRemoveColumn = enableRemoveColumn });
            }
            else
            {
                this.list[gv].EnableRemoveColumn = enableRemoveColumn;
            }
        }

        [Category("Menu")]
        [Description("EnableColumnSelect"), DefaultValue(false)]
        public bool GetEnableColumnSelect(GridView gv)
        {
            if (this.list.ContainsKey(gv))
            {
                return list[gv].EnableColumnSelect;
            }
            return true;
        }
        public void SetEnableColumnSelect(GridView gv, bool enableColumnSelect)
        {
            if (!this.list.ContainsKey(gv))
            {
                this.list.Add(gv, new GridViewColumnMenuPara() { EnableColumnSelect = enableColumnSelect });
            }
            else
            {
                this.list[gv].EnableColumnSelect = enableColumnSelect;
            }
        }

        [Category("Menu")]
        [Description("EnableBestFit"), DefaultValue(true)]
        public bool GetEnableBestFit(GridView gv)
        {
            if (this.list.ContainsKey(gv))
            {
                return list[gv].EnableBestFit;
            }
            return true;
        }
        public void SetEnableBestFit(GridView gv, bool enableBestFit)
        {
            if (!this.list.ContainsKey(gv))
            {
                this.list.Add(gv, new GridViewColumnMenuPara() { EnableBestFit = enableBestFit });
            }
            else
            {
                this.list[gv].EnableBestFit = enableBestFit;
            }
        }

        [Category("Menu")]
        [Description("EnableBestFitAll"), DefaultValue(true)]
        public bool GetEnableBestFitAll(GridView gv)
        {
            if (this.list.ContainsKey(gv))
            {
                return list[gv].EnableBestFitAll;
            }
            return true;
        }
        public void SetEnableBestFitAll(GridView gv, bool enableBestFitAll)
        {
            if (!this.list.ContainsKey(gv))
            {
                this.list.Add(gv, new GridViewColumnMenuPara() { EnableBestFitAll = enableBestFitAll });
            }
            else
            {
                this.list[gv].EnableBestFitAll = enableBestFitAll;
            }
        }
    }
    internal class GridViewColumnMenuPara
    {
        private bool _EnableColumnMenu = true;
        public bool EnableColumnMenu
        {
            get { return _EnableColumnMenu; }
            set { _EnableColumnMenu = value; }
        }

        private bool _EnableGroupByThisColumn = false;
        public bool EnableGroupByThisColumn
        {
            get { return _EnableGroupByThisColumn; }
            set { _EnableGroupByThisColumn = value; }
        }

        private bool _EnableShowGroupBox = false;
        public bool EnableShowGroupBox
        {
            get { return _EnableShowGroupBox; }
            set { _EnableShowGroupBox = value; }
        }

        private bool _EnableRemoveColumn = false;
        public bool EnableRemoveColumn
        {
            get { return _EnableRemoveColumn; }
            set { _EnableRemoveColumn = value; }
        }

        private bool _EnableColumnSelect = false;
        public bool EnableColumnSelect
        {
            get { return _EnableColumnSelect; }
            set { _EnableColumnSelect = value; }
        }

        private bool _EnableBestFit = true;
        public bool EnableBestFit
        {
            get { return _EnableBestFit; }
            set { _EnableBestFit = value; }
        }

        private bool _EnableBestFitAll = true;
        public bool EnableBestFitAll
        {
            get { return _EnableBestFitAll; }
            set { _EnableBestFitAll = value; }
        }
    }
}
