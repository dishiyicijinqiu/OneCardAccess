using DevExpress.XtraEditors;
using System.ComponentModel;
using System.ComponentModel.Design;

namespace FengSharp.OneCardAccess.Infrastructure.WinForm.Components
{
    [Designer("Infrastructure.WinForm.Designer.ButtonStyleSelectDesigner,Infrastructure.WinForm.Designer", typeof(IDesigner))]
    public partial class ButtonStyleSelect : Component
    {
        public ButtonStyleSelect()
        {
            InitializeComponent();
        }

        public ButtonStyleSelect(IContainer container)
        {
            container.Add(this);
            InitializeComponent();
        }
        SimpleButton simpleButton;
        [Category("UIGenerate")]
        [Description("选择SimpleButton通用样式")]
        public SimpleButton SimpleButton
        {
            get { return simpleButton; }
            set { simpleButton = value; }
        }
    }
}
