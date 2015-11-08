using DevExpress.XtraLayout;
using DevExpress.XtraLayout.Utils;
using System.Collections.Generic;
using System.ComponentModel;

namespace FengSharp.OneCardAccess.Infrastructure.WinForm.Components
{
    [ToolboxItem(true)]
    [Description("使用LayoutControl通用属性")]
    [ProvideProperty("EnableCommonStyle", typeof(Component))]
    [ProvideProperty("LayoutControlGroupPadding", typeof(LayoutControlGroup))]
    public partial class LayoutControlCommonStyle : Component, IExtenderProvider
    {
        #region fileds
        private Dictionary<Component, LayoutCommonPara> list = null;
        #endregion
        #region ctor
        public LayoutControlCommonStyle()
        {
            InitializeComponent();
            list = new Dictionary<Component, LayoutCommonPara>();
        }

        public LayoutControlCommonStyle(IContainer container)
        {
            container.Add(this);
            InitializeComponent();
            list = new Dictionary<Component, LayoutCommonPara>();
        }
        #endregion
        public bool CanExtend(object extendee)
        {
            bool result = false;
            if (extendee is LayoutControl)
                result = true;
            if (extendee is LayoutControlGroup)
                result = true;
            return result;
        }
        [Category("LayoutControl通用属性")]
        [Description("是否使用LayoutControl通用属性")]
        public bool GetEnableCommonStyle(Component component)
        {
            if (this.list.ContainsKey(component))
            {
                return list[component].EnableCommonStyle;
            }
            return true;
        }
        public void SetEnableCommonStyle(Component component, bool isEnable)
        {
            if (!list.ContainsKey(component))
            {
                list.Add(component, new LayoutCommonPara() { EnableCommonStyle = isEnable });
            }
            else
            {
                list[component].EnableCommonStyle = isEnable;
            }
            if (isEnable)
            {
                var para = list[component];
                if (component is LayoutControl)
                {
                    var layoutControl = component as LayoutControl;
                    layoutControl.OptionsItemText.TextAlignMode = TextAlignMode.AlignInGroups;
                }
                else if (component is LayoutControlGroup)
                {
                    var layoutControlGroup = component as LayoutControlGroup;
                    layoutControlGroup.Padding = para.LayoutControlGroupPadding;
                    layoutControlGroup.GroupBordersVisible = true;
                }
            }
        }
        [Category("LayoutControl通用属性")]
        [Description("设置LayoutControlGroupPadding")]
        public Padding GetLayoutControlGroupPadding(LayoutControlGroup layoutControlGroup)
        {
            if (this.list.ContainsKey(layoutControlGroup))
            {
                return list[layoutControlGroup].LayoutControlGroupPadding;
            }
            return new Padding(3, 3, 3, 3);
        }
        public void SetLayoutControlGroupPadding(LayoutControlGroup layoutControlGroup, Padding layoutControlGroupPadding)
        {
            if (!list.ContainsKey(layoutControlGroup))
            {
                list.Add(layoutControlGroup, new LayoutCommonPara() { LayoutControlGroupPadding = layoutControlGroupPadding });
            }
            else
            {
                list[layoutControlGroup].LayoutControlGroupPadding = layoutControlGroupPadding;
            }
        }
    }
    public class LayoutCommonPara
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
        private Padding layoutControlGroupPadding = new Padding(3, 3, 3, 3);
        public Padding LayoutControlGroupPadding
        {
            get
            {
                return layoutControlGroupPadding;
            }
            set
            {
                layoutControlGroupPadding = value;
            }
        }
    }
}
