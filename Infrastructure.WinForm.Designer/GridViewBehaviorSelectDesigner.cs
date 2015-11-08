using DevExpress.XtraGrid.Views.Grid;
using System;
using System.ComponentModel.Design;
using System.Windows.Forms;

namespace Infrastructure.WinForm.Designer
{
    internal class GridViewBehaviorSelectDesigner : ComponentDesigner
    {
        public GridViewBehaviorSelectDesigner()
            : base()
        {
            DesignerVerb verb = new DesignerVerb("GridView通用行为", new EventHandler(OnDesignItems));
            this.Verbs.Add(verb);
        }
        private void OnDesignItems(object sender, EventArgs e)
        {
            this.DoDefaultAction();
        }
        public override void DoDefaultAction()
        {
            try
            {
                var p = this.Component.GetType().GetProperty("GridView");
                var gv = p.GetValue(this.Component, null) as GridView;
                if (gv == null)
                {
                    MessageBox.Show("请先选择GridView");
                    return;
                }
                GridViewBehaviorSelectForm dialog = new GridViewBehaviorSelectForm(gv);
                dialog.ShowDialog();
                dialog.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
