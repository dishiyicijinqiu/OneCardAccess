using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using DevExpress.XtraGrid.Views.Grid;

namespace FengSharp.OneCardAccess.Infrastructure.WinForm.Components
{
    [ToolboxItem(true)]
    [Description("使用GridView通用属性")]
    [ProvideProperty("EnableCommonStyle", typeof(GridView))]
    public partial class GridViewCommonStyle : Component, IExtenderProvider
    {
        #region fileds
        private Dictionary<GridView, GridViewCommonPara> list = null;
        #endregion
        #region ctor
        public GridViewCommonStyle()
        {
            InitializeComponent();
            list = new Dictionary<GridView, GridViewCommonPara>();
        }

        public GridViewCommonStyle(IContainer container)
        {
            container.Add(this);
            InitializeComponent();
            list = new Dictionary<GridView, GridViewCommonPara>();
        }
        #endregion
        public bool CanExtend(object extendee)
        {
            return extendee is GridView;
        }

        [Category("扩展")]
        [Description("是否使用GridView通用属性")]
        public bool GetEnableCommonStyle(GridView gridview)
        {
            if (this.list.ContainsKey(gridview))
            {
                return list[gridview].EnableCommonStyle;
            }
            return true;
        }
        public void SetEnableCommonStyle(GridView gridview, bool isEnable)
        {
            if (!list.ContainsKey(gridview))
            {
                list.Add(gridview, new GridViewCommonPara() { EnableCommonStyle = isEnable });
            }
            else
            {
                list[gridview].EnableCommonStyle = isEnable;
            }
            if (isEnable)
            {
                gridview.Appearance.EvenRow.BackColor = System.Drawing.Color.LightYellow;
                gridview.Appearance.EvenRow.Options.UseBackColor = true;
                gridview.Appearance.OddRow.BackColor = System.Drawing.Color.White;
                gridview.Appearance.OddRow.Options.UseBackColor = true;
                gridview.IndicatorWidth = 40;
                gridview.OptionsCustomization.AllowFilter = false;
                gridview.OptionsCustomization.AllowQuickHideColumns = false;
                //gridview.OptionsCustomization.AllowSort = false;
                gridview.OptionsDetail.EnableMasterViewMode = false;
                gridview.OptionsLayout.Columns.StoreAllOptions = false;
                gridview.OptionsLayout.Columns.StoreLayout = false;
                gridview.OptionsLayout.StoreDataSettings = false;
                gridview.OptionsLayout.StoreVisualOptions = false;
                gridview.OptionsMenu.EnableColumnMenu = false;
                gridview.OptionsNavigation.EnterMoveNextColumn = true;
                gridview.OptionsView.ShowGroupPanel = false;
                gridview.OptionsSelection.MultiSelect = true;
                gridview.OptionsSelection.EnableAppearanceFocusedCell = false;
                gridview.OptionsView.ColumnAutoWidth = false;
                gridview.OptionsView.EnableAppearanceEvenRow = true;
                gridview.OptionsView.EnableAppearanceOddRow = true;
                gridview.OptionsBehavior.Editable = false;
            }
        }
    }
    public class GridViewCommonPara
    {
        private bool enableCommonStyle = true;
        public bool EnableCommonStyle
        {
            get
            {
                return enableCommonStyle;
            }
            set
            {
                enableCommonStyle = value;
            }
        }
    }
}
