using DevExpress.XtraTreeList;
using System.ComponentModel;
using System.ComponentModel.Design;

namespace FengSharp.OneCardAccess.Infrastructure.WinForm.Components
{
    [Designer("Infrastructure.WinForm.Designer.TreeListStyleSelectDesigner,Infrastructure.WinForm.Designer", typeof(IDesigner))]
    public partial class TreeListStyleSelect : Component
    {
        public TreeListStyleSelect()
        {
            InitializeComponent();
        }

        public TreeListStyleSelect(IContainer container)
        {
            container.Add(this);
            InitializeComponent();
        }
        TreeList treeList;
        [Category("UIGenerate")]
        [Description("选择TreeList通用样式")]
        public TreeList TreeList
        {
            get { return treeList; }
            set { treeList = value; }
        }
    }
}
