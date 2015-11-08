using DevExpress.XtraLayout;
using System.ComponentModel;
using System.ComponentModel.Design;

namespace FengSharp.OneCardAccess.Infrastructure.WinForm.Components
{
    [Designer("Infrastructure.WinForm.Designer.LayoutStyleSelectDesigner,Infrastructure.WinForm.Designer", typeof(IDesigner))]
    public partial class LayoutStyleSelect : Component
    {
        public LayoutStyleSelect()
        {
            InitializeComponent();
        }

        public LayoutStyleSelect(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }
        LayoutControl layoutControl;
        [Category("UIGenerate")]
        [Description("选择LayoutControl通用样式")]
        public LayoutControl LayoutControl
        {
            get { return layoutControl; }
            set { layoutControl = value; }
        }
    }
}
