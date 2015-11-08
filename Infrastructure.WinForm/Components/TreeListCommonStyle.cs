using DevExpress.XtraTreeList;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace FengSharp.OneCardAccess.Infrastructure.WinForm.Components
{
    [ToolboxItem(true)]
    [Description("使用TreeList通用属性")]
    [ProvideProperty("EnableCommonStyle", typeof(TreeList))]
    public partial class TreeListCommonStyle : Component, IExtenderProvider
    {
        #region fileds
        private Dictionary<TreeList, TreeListCommonPara> list = null;
        #endregion
        #region ctor
        public TreeListCommonStyle()
        {
            InitializeComponent();
            list = new Dictionary<TreeList, TreeListCommonPara>();
        }

        public TreeListCommonStyle(IContainer container)
        {
            container.Add(this);
            InitializeComponent();
            list = new Dictionary<TreeList, TreeListCommonPara>();
        }
        #endregion
        public bool CanExtend(object extendee)
        {
            return extendee is TreeList;
        }
        [Category("扩展")]
        [Description("是否使用TreeList通用属性")]
        public bool GetEnableCommonStyle(TreeList treelist)
        {
            if (this.list.ContainsKey(treelist))
            {
                return list[treelist].EnableCommonStyle;
            }
            return true;
        }
        public void SetEnableCommonStyle(TreeList treelist, bool isEnable)
        {
            if (!list.ContainsKey(treelist))
            {
                list.Add(treelist, new TreeListCommonPara() { EnableCommonStyle = isEnable });
            }
            else
            {
                list[treelist].EnableCommonStyle = isEnable;
            }
            if (isEnable)
            {
                treelist.OptionsSelection.EnableAppearanceFocusedCell = false;
                treelist.OptionsSelection.UseIndicatorForSelection = true;
                treelist.IndicatorWidth = 40;
                treelist.Appearance.EvenRow.BackColor = System.Drawing.Color.LightYellow;
                treelist.Appearance.EvenRow.Options.UseBackColor = true;
                treelist.Appearance.OddRow.BackColor = System.Drawing.Color.White;
                treelist.Appearance.OddRow.Options.UseBackColor = true;
                treelist.OptionsView.EnableAppearanceEvenRow = true;
                treelist.OptionsView.EnableAppearanceOddRow = true;
                treelist.OptionsBehavior.Editable = false;
            }
        }
    }
    internal class TreeListCommonPara
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
