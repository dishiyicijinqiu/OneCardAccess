using DevExpress.XtraTreeList;
using System;
using System.ComponentModel.Design;
using System.Linq;
using System.Windows.Forms;

namespace Infrastructure.WinForm.Designer
{
    internal class TreeListStyleSelectDesigner : ComponentDesigner
    {
        readonly TreeList ystreeList = new TreeList();

        readonly TreeList cusTreeList = (TreeList)Activator.CreateInstance(Type.GetType(ResourceMessages.TreeListTypeString));

        public TreeList defaultTreeList
        {
            get
            {
                if (MessageBox.Show("是否使用原生类型", "提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    return ystreeList;
                else
                    return cusTreeList;
            }
        }

        public TreeListStyleSelectDesigner()
            : base()
        {
            this.Verbs.AddRange(new DesignerVerb[] { 
            new DesignerVerb("TreeList通用样式1", new EventHandler(OnDesignItems)){  Description="通用样式1"},
            new DesignerVerb("TreeList通用样式2", new EventHandler(OnDesignItems)){  Description="通用样式2"},
            new DesignerVerb("TreeList通用样式3", new EventHandler(OnDesignItems)){  Description="通用样式3"},
            new DesignerVerb("TreeList通用样式4", new EventHandler(OnDesignItems)){  Description="通用样式4"},
            new DesignerVerb("恢复默认", new EventHandler(OnDesignItems)){  Description="恢复默认"},
            });
        }
        private void OnDesignItems(object sender, EventArgs e)
        {
            try
            {
                var designerVerb = sender as DesignerVerb;
                switch (designerVerb.Description)
                {
                    default:
                    case "TreeList通用样式1":
                        this.DoDefaultAction();
                        break;
                    case "TreeList通用样式2":
                        SetStyle(SetStyle2);
                        break;
                    case "TreeList通用样式3":
                        SetStyle(SetStyle3);
                        break;
                    case "TreeList通用样式4":
                        SetStyle(SetStyle4);
                        break;
                    case "恢复默认":
                        this.SetStyle(SetDefaultStyle, true);
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public override void DoDefaultAction()
        {
            SetStyle(SetStyle1);
        }

        private void SetStyle(Action<TreeList> setstyleaction)
        {
            SetStyle(setstyleaction, false);
        }

        private void SetStyle(Action<TreeList> setstyleaction, bool isdefault)
        {
            var p = this.Component.GetType().GetProperty("TreeList");
            var control = p.GetValue(this.Component, null) as TreeList;
            if (control == null)
            {
                MessageBox.Show("请先选择TreeList");
                return;
            }
            IDesignerHost host = (IDesignerHost)control.Site.GetService(typeof(IDesignerHost));
            DesignerTransaction transaction = host.CreateTransaction("TreeListStyleSelectDesigner");//创建事务 
            try
            {
                SetDefaultStyle(control);
                if (!isdefault)
                    setstyleaction(control);
                string tempname = control.Site.Name;
                control.Site.Name = "treelist99999";
                control.Site.Name = tempname;
                transaction.Commit();//提交事务 
            }
            catch (Exception ex)
            {
                transaction.Cancel();
                throw ex;
            }
        }

        private void SetStyle1(TreeList treelist)
        {
            treelist.IndicatorWidth = 40;
            treelist.OptionsSelection.EnableAppearanceFocusedCell = false;
            treelist.OptionsSelection.UseIndicatorForSelection = true;
            treelist.OptionsBehavior.Editable = false;
        }
        private void SetStyle2(TreeList treelist)
        {

        }
        private void SetStyle3(TreeList treelist)
        {

        }
        private void SetStyle4(TreeList treelist)
        {

        }
        private void SetDefaultStyle(TreeList treelist)
        {
            var _defaultTreeList = defaultTreeList;
            treelist.OptionsSelection.EnableAppearanceFocusedCell = _defaultTreeList.OptionsSelection.EnableAppearanceFocusedCell;
            treelist.OptionsSelection.UseIndicatorForSelection = _defaultTreeList.OptionsSelection.UseIndicatorForSelection;
            treelist.IndicatorWidth = _defaultTreeList.IndicatorWidth;
            treelist.OptionsBehavior.Editable = _defaultTreeList.OptionsBehavior.Editable;
        }
    }
}
