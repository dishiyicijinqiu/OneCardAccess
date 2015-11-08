using System;
using System.ComponentModel.Design;
using System.Windows.Forms;

namespace Infrastructure.WinForm.Designer
{
    internal class FormStyleSelectDesigner : ComponentDesigner
    {
        readonly Form ysForm = new Form();

        readonly Form cusForm = (Form)Activator.CreateInstance(Type.GetType(Infrastructure.WinForm.Designer.ResourceMessages.FormTypeString));

        public Form defaultForm
        {
            get
            {
                if (MessageBox.Show("是否使用原生类型", "提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    return ysForm;
                else
                    return cusForm;
            }
        }
        public FormStyleSelectDesigner()
            : base()
        {
            this.Verbs.AddRange(new DesignerVerb[] { 
            new DesignerVerb("Form通用样式1", new EventHandler(OnDesignItems)){  Description="通用样式1"},
            new DesignerVerb("Form通用样式2", new EventHandler(OnDesignItems)){  Description="通用样式2"},
            new DesignerVerb("Form通用样式3", new EventHandler(OnDesignItems)){  Description="通用样式3"},
            new DesignerVerb("Form通用样式4", new EventHandler(OnDesignItems)){  Description="通用样式4"},
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
                    case "Form通用样式1":
                        this.DoDefaultAction();
                        break;
                    case "Form通用样式2":
                        SetStyle(SetStyle2);
                        break;
                    case "Form通用样式3":
                        SetStyle(SetStyle3);
                        break;
                    case "Form通用样式4":
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

        private void SetStyle(Action<Form> setstyleaction)
        {
            SetStyle(setstyleaction, false);
        }
        private void SetStyle(Action<Form> setstyleaction, bool isdefault)
        {
            var p = this.Component.GetType().GetProperty("Form");
            var control = p.GetValue(this.Component, null) as Form;
            if (control == null)
            {
                MessageBox.Show("请先选择Form");
                return;
            }
            IDesignerHost host = (IDesignerHost)control.Site.GetService(typeof(IDesignerHost));
            DesignerTransaction transaction = host.CreateTransaction("FormStyleSelectDesigner");//创建事务 
            try
            {
                SetDefaultStyle(control);
                if (!isdefault)
                    setstyleaction(control);
                string tempname = control.Site.Name;
                control.Site.Name = "form99999";
                control.Site.Name = tempname;
                transaction.Commit();//提交事务 
            }
            catch (Exception ex)
            {
                transaction.Cancel();
                throw ex;
            }
        }
        private void SetStyle1(Form form)
        {
            form.StartPosition = FormStartPosition.CenterParent;
            form.MaximizeBox = false;
            form.MinimizeBox = false;
            form.FormBorderStyle = FormBorderStyle.FixedDialog;
        }
        private void SetStyle2(Form form)
        {

        }
        private void SetStyle3(Form form)
        {

        }
        private void SetStyle4(Form form)
        {

        }
        private void SetDefaultStyle(Form form)
        {
            var _defaultForm = defaultForm;
            form.StartPosition = _defaultForm.StartPosition;
            form.MaximizeBox = _defaultForm.MaximizeBox;
            form.MinimizeBox = _defaultForm.MinimizeBox;
            form.FormBorderStyle = _defaultForm.FormBorderStyle;
        }
    }
}
