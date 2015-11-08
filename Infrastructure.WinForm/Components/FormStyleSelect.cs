using System.ComponentModel;
using System.ComponentModel.Design;
using System.Windows.Forms;

namespace FengSharp.OneCardAccess.Infrastructure.WinForm.Components
{
    [Designer("Infrastructure.WinForm.Designer.FormStyleSelectDesigner,Infrastructure.WinForm.Designer", typeof(IDesigner))]
    public partial class FormStyleSelect : Component
    {
        public FormStyleSelect()
        {
            InitializeComponent();
        }

        public FormStyleSelect(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }
        Form form;
        [Category("UIGenerate")]
        [Description("选择Form通用样式")]
        public Form Form
        {
            get { return form; }
            set { form = value; }
        }
    }
}
