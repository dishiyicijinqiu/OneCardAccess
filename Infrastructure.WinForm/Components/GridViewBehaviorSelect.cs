using DevExpress.XtraGrid.Views.Grid;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace FengSharp.OneCardAccess.Infrastructure.WinForm.Components
{
    [Designer("Infrastructure.WinForm.Designer.GridViewBehaviorSelectDesigner,Infrastructure.WinForm.Designer", typeof(IDesigner))]
    public partial class GridViewBehaviorSelect : Component
    {
        public GridViewBehaviorSelect()
        {
            InitializeComponent();
        }

        public GridViewBehaviorSelect(IContainer container)
        {
            container.Add(this);
            InitializeComponent();
        }
        GridView gridView;
        [Category("UIGenerate")]
        [Description("选择GridView通用行为")]
        public GridView GridView
        {
            get { return gridView; }
            set { gridView = value; }
        }
    }
}
