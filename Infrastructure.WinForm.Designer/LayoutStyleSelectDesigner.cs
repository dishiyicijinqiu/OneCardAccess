using DevExpress.XtraLayout;
using System;
using System.ComponentModel.Design;
using System.Linq;
using System.Windows.Forms;

namespace Infrastructure.WinForm.Designer
{
    internal class LayoutStyleSelectDesigner : ComponentDesigner
    {

        readonly LayoutControl ysLayoutControl = new LayoutControl();

        readonly LayoutControl cusLayoutControl = (LayoutControl)Activator.CreateInstance(Type.GetType(ResourceMessages.LayoutControlTypeString));

        public LayoutControl defaultLayoutControl
        {
            get
            {
                if (MessageBox.Show("是否使用原生类型", "提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    return ysLayoutControl;
                else
                    return cusLayoutControl;
            }
        }

        readonly LayoutControlGroup defaultLayoutControlGroup = new LayoutControlGroup();
        public LayoutStyleSelectDesigner()
            : base()
        {
            this.Verbs.AddRange(new DesignerVerb[] { 
            new DesignerVerb("LayoutControl通用样式1", new EventHandler(OnDesignItems)){  Description="通用样式1"},
            new DesignerVerb("LayoutControl通用样式2", new EventHandler(OnDesignItems)){  Description="通用样式2"},
            new DesignerVerb("LayoutControl通用样式3", new EventHandler(OnDesignItems)){  Description="通用样式3"},
            new DesignerVerb("LayoutControl通用样式4", new EventHandler(OnDesignItems)){  Description="通用样式4"},
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
                    case "LayoutControl通用样式1":
                        this.DoDefaultAction();
                        break;
                    case "LayoutControl通用样式2":
                        SetStyle(SetStyle2);
                        break;
                    case "LayoutControl通用样式3":
                        SetStyle(SetStyle3);
                        break;
                    case "LayoutControl通用样式4":
                        SetStyle(SetStyle4);
                        break;
                    case "恢复默认":
                        SetStyle(SetDefaultStyle, true);
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

        private void SetStyle(Action<LayoutControl> setstyleaction)
        {
            SetStyle(setstyleaction, false);
        }
        private void SetStyle(Action<LayoutControl> setstyleaction, bool isdefault)
        {
            var p = this.Component.GetType().GetProperty("LayoutControl");
            var control = p.GetValue(this.Component, null) as LayoutControl;
            if (control == null)
            {
                MessageBox.Show("请先选择LayoutControl");
                return;
            }
            IDesignerHost host = (IDesignerHost)control.Site.GetService(typeof(IDesignerHost));
            DesignerTransaction transaction = host.CreateTransaction("LayoutStyleSelectDesigner");//创建事务 
            try
            {
                SetDefaultStyle(control);
                if (!isdefault)
                    setstyleaction(control);
                transaction.Commit();//提交事务 
            }
            catch (Exception ex)
            {
                transaction.Cancel();
                throw ex;
            }
        }
        private void SetStyle1(LayoutControl layoutControl)
        {
            layoutControl.OptionsItemText.TextAlignMode = TextAlignMode.AlignInGroups;
            var groups = layoutControl.Items.OfType<BaseLayoutItem>().Where(t => t is LayoutControlGroup).ToList();
            foreach (LayoutControlGroup group in groups)
            {
                group.Padding = new DevExpress.XtraLayout.Utils.Padding(3, 3, 3, 3);
                group.GroupBordersVisible = true;
            }
        }
        private void SetStyle2(LayoutControl layoutControl)
        {

        }
        private void SetStyle3(LayoutControl layoutControl)
        {

        }
        private void SetStyle4(LayoutControl layoutControl)
        {

        }
        private void SetDefaultStyle(LayoutControl layoutControl)
        {
            var _defaultLayoutControl = defaultLayoutControl;
            layoutControl.OptionsItemText.TextAlignMode = _defaultLayoutControl.OptionsItemText.TextAlignMode;
            var groups = layoutControl.Items.OfType<BaseLayoutItem>().Where(t => t is LayoutControlGroup).ToList();
            foreach (LayoutControlGroup group in groups)
            {
                group.Padding = defaultLayoutControlGroup.Padding;
                group.GroupBordersVisible = defaultLayoutControlGroup.GroupBordersVisible;
            }
        }
    }
}
