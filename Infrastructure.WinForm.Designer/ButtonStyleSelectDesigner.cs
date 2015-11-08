using DevExpress.XtraEditors;
using System;
using System.ComponentModel.Design;
using System.Linq;
using System.Windows.Forms;

namespace Infrastructure.WinForm.Designer
{
    internal class ButtonStyleSelectDesigner : ComponentDesigner
    {
        readonly SimpleButton yssimpleButton = new SimpleButton();
        readonly SimpleButton cusSimpleButton = (SimpleButton)Activator.CreateInstance(Type.GetType(ResourceMessages.SimpleButtonTypeString));
        public SimpleButton defaultSimpleButton
        {
            get
            {
                if (MessageBox.Show("是否使用原生类型", "提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    return yssimpleButton;
                else
                    return cusSimpleButton;
            }
        }

        public ButtonStyleSelectDesigner()
            : base()
        {
            this.Verbs.AddRange(new DesignerVerb[] { 
            new DesignerVerb("AddWithLargeImage", new EventHandler(OnDesignItems)){  Description="AddWithLargeImage"},
            new DesignerVerb("AddWithSmallImage", new EventHandler(OnDesignItems)){  Description="AddWithSmallImage"},
            new DesignerVerb("CopyAddWithLargeImage", new EventHandler(OnDesignItems)){  Description="CopyAddWithLargeImage"},
            new DesignerVerb("CopyAddWithSmallImage", new EventHandler(OnDesignItems)){  Description="CopyAddWithSmallImage"},
            new DesignerVerb("EditWithLargeImage", new EventHandler(OnDesignItems)){  Description="EditWithLargeImage"},
            new DesignerVerb("EditWithSmallImage", new EventHandler(OnDesignItems)){  Description="EditWithSmallImage"},
            new DesignerVerb("DeleteWithLargeImage", new EventHandler(OnDesignItems)){  Description="DeleteWithLargeImage"},
            new DesignerVerb("DeleteWithSmallImage", new EventHandler(OnDesignItems)){  Description="DeleteWithSmallImage"},
            new DesignerVerb("OKWithLargeImage", new EventHandler(OnDesignItems)){  Description="OKWithLargeImage"},
            new DesignerVerb("OKWithSmallImage", new EventHandler(OnDesignItems)){  Description="OKWithSmallImage"},
            new DesignerVerb("CancelWithLargeImage", new EventHandler(OnDesignItems)){  Description="CancelWithLargeImage"},
            new DesignerVerb("CancelWithSmallImage", new EventHandler(OnDesignItems)){  Description="CancelWithSmallImage"},
            new DesignerVerb("SaveWithLargeImage", new EventHandler(OnDesignItems)){  Description="SaveWithLargeImage"},
            new DesignerVerb("SaveWithSmallImage", new EventHandler(OnDesignItems)){  Description="SaveWithSmallImage"},
            new DesignerVerb("CloseWithLargeImage", new EventHandler(OnDesignItems)){  Description="CloseWithLargeImage"},
            new DesignerVerb("CloseWithSmallImage", new EventHandler(OnDesignItems)){  Description="CloseWithSmallImage"},
            new DesignerVerb("KindWithLargeImage", new EventHandler(OnDesignItems)){  Description="KindWithLargeImage"},
            new DesignerVerb("KindWithSmallImage", new EventHandler(OnDesignItems)){  Description="KindWithSmallImage"},
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
                    case "AddWithLargeImage":
                        this.DoDefaultAction();
                        break;
                    case "AddWithSmallImage":
                        this.SetStyle(this.SetAddWithSmallImageStyle);
                        break;
                    case "CopyAddWithLargeImage":
                        this.SetStyle(this.SetCopyAddWithLargeImageStyle);
                        break;
                    case "CopyAddWithSmallImage":
                        this.SetStyle(this.SetCopyAddWithSmallImageStyle);
                        break;
                    case "EditWithLargeImage":
                        this.SetStyle(this.SetEditWithLargeImageStyle);
                        break;
                    case "EditWithSmallImage":
                        this.SetStyle(this.SetEditWithSmallImageStyle);
                        break;
                    case "DeleteWithLargeImage":
                        this.SetStyle(this.SetDeleteWithLargeImageStyle);
                        break;
                    case "DeleteWithSmallImage":
                        this.SetStyle(this.SetDeleteWithSmallImageStyle);
                        break;
                    case "OKWithLargeImage":
                        this.SetStyle(this.SetOKWithLargeImageStyle);
                        break;
                    case "OKWithSmallImage":
                        this.SetStyle(this.SetOKWithSmallImageStyle);
                        break;
                    case "CancelWithLargeImage":
                        this.SetStyle(this.SetCancelWithLargeImageStyle);
                        break;
                    case "CancelWithSmallImage":
                        this.SetStyle(this.SetCancelWithSmallImageStyle);
                        break;
                    case "SaveWithLargeImage":
                        this.SetStyle(this.SetSaveWithLargeImageStyle);
                        break;
                    case "SaveWithSmallImage":
                        this.SetStyle(this.SetSaveWithSmallImageStyle);
                        break;
                    case "CloseWithLargeImage":
                        this.SetStyle(this.SetCloseWithLargeImageStyle);
                        break;
                    case "CloseWithSmallImage":
                        this.SetStyle(this.SetCloseWithSmallImageStyle);
                        break;
                    case "KindWithLargeImage":
                        this.SetStyle(this.SetKindWithLargeImageStyle);
                        break;
                    case "KindWithSmallImage":
                        this.SetStyle(this.SetKindWithSmallImageStyle);
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
            SetStyle(SetAddWithLargeImageStyle);
        }

        private void SetStyle(Action<SimpleButton> setstyleaction)
        {
            SetStyle(setstyleaction, false);
        }
        private void SetStyle(Action<SimpleButton> setstyleaction, bool isdefault)
        {
            var p = this.Component.GetType().GetProperty("SimpleButton");
            var control = p.GetValue(this.Component, null) as SimpleButton;
            if (control == null)
            {
                MessageBox.Show("请先选择SimpleButton");
                return;
            }
            IDesignerHost host = (IDesignerHost)control.Site.GetService(typeof(IDesignerHost));
            DesignerTransaction transaction = host.CreateTransaction("ButtonStyleSelectDesigner");//创建事务 
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


        private void SetAddWithLargeImageStyle(SimpleButton button)
        {
            button.Image = DevExpress.Images.ImageResourceCache.Default.GetImage("images/actions/add_32x32.png");
            button.Text = Infrastructure.WinForm.Designer.ResourceMessages.btnAdd;
            button.Site.Name = Infrastructure.WinForm.Designer.ResourceMessages.btnAddName;
        }
        private void SetAddWithSmallImageStyle(SimpleButton button)
        {
            button.Image = DevExpress.Images.ImageResourceCache.Default.GetImage("images/actions/add_16x16.png");
            button.Text = Infrastructure.WinForm.Designer.ResourceMessages.btnAdd;
            button.Site.Name = Infrastructure.WinForm.Designer.ResourceMessages.btnAddName;
        }
        private void SetCopyAddWithLargeImageStyle(SimpleButton button)
        {
            button.Image = DevExpress.Images.ImageResourceCache.Default.GetImage("images/edit/paste_32x32.png");
            button.Text = Infrastructure.WinForm.Designer.ResourceMessages.btnCopyAdd;
            button.Site.Name = Infrastructure.WinForm.Designer.ResourceMessages.btnCopyAddName;
        }
        private void SetCopyAddWithSmallImageStyle(SimpleButton button)
        {
            button.Image = DevExpress.Images.ImageResourceCache.Default.GetImage("images/edit/paste_16x16.png");
            button.Text = Infrastructure.WinForm.Designer.ResourceMessages.btnCopyAdd;
            button.Site.Name = Infrastructure.WinForm.Designer.ResourceMessages.btnCopyAddName;
        }
        private void SetEditWithLargeImageStyle(SimpleButton button)
        {
            button.Image = DevExpress.Images.ImageResourceCache.Default.GetImage("images/edit/edit_32x32.png");
            button.Text = Infrastructure.WinForm.Designer.ResourceMessages.btnEdit;
            button.Site.Name = Infrastructure.WinForm.Designer.ResourceMessages.btnEditName;
        }
        private void SetEditWithSmallImageStyle(SimpleButton button)
        {
            button.Image = DevExpress.Images.ImageResourceCache.Default.GetImage("images/edit/edit_16x16.png");
            button.Text = Infrastructure.WinForm.Designer.ResourceMessages.btnEdit;
            button.Site.Name = Infrastructure.WinForm.Designer.ResourceMessages.btnEditName;
        }
        private void SetDeleteWithLargeImageStyle(SimpleButton button)
        {
            button.Image = DevExpress.Images.ImageResourceCache.Default.GetImage("images/edit/delete_32x32.png");
            button.Text = Infrastructure.WinForm.Designer.ResourceMessages.btnDelete;
            button.Site.Name = Infrastructure.WinForm.Designer.ResourceMessages.btnDeleteName;
        }
        private void SetDeleteWithSmallImageStyle(SimpleButton button)
        {
            button.Image = DevExpress.Images.ImageResourceCache.Default.GetImage("images/edit/delete_16x16.png");
            button.Text = Infrastructure.WinForm.Designer.ResourceMessages.btnDelete;
            button.Site.Name = Infrastructure.WinForm.Designer.ResourceMessages.btnDeleteName;
        }
        private void SetOKWithLargeImageStyle(SimpleButton button)
        {
            button.Image = DevExpress.Images.ImageResourceCache.Default.GetImage("images/actions/apply_16x16.png");
            button.Text = Infrastructure.WinForm.Designer.ResourceMessages.btnOK;
            button.Site.Name = Infrastructure.WinForm.Designer.ResourceMessages.btnOKName;
        }
        private void SetOKWithSmallImageStyle(SimpleButton button)
        {
            button.Image = DevExpress.Images.ImageResourceCache.Default.GetImage("images/actions/apply_16x16.png");
            button.Text = Infrastructure.WinForm.Designer.ResourceMessages.btnOK;
            button.Site.Name = Infrastructure.WinForm.Designer.ResourceMessages.btnOKName;
        }
        private void SetCancelWithLargeImageStyle(SimpleButton button)
        {
            button.Image = DevExpress.Images.ImageResourceCache.Default.GetImage("images/actions/cancel_16x16.png");
            button.Text = Infrastructure.WinForm.Designer.ResourceMessages.btnCancel;
            button.Site.Name = Infrastructure.WinForm.Designer.ResourceMessages.btnCancelName;
        }
        private void SetCancelWithSmallImageStyle(SimpleButton button)
        {
            button.Image = DevExpress.Images.ImageResourceCache.Default.GetImage("images/actions/cancel_16x16.png");
            button.Text = Infrastructure.WinForm.Designer.ResourceMessages.btnCancel;
            button.Site.Name = Infrastructure.WinForm.Designer.ResourceMessages.btnCancelName;
        }
        private void SetSaveWithLargeImageStyle(SimpleButton button)
        {
            button.Image = DevExpress.Images.ImageResourceCache.Default.GetImage("images/save/save_32x32.png");
            button.Text = Infrastructure.WinForm.Designer.ResourceMessages.btnSave;
            button.Site.Name = Infrastructure.WinForm.Designer.ResourceMessages.btnSaveName;
        }
        private void SetSaveWithSmallImageStyle(SimpleButton button)
        {
            button.Image = DevExpress.Images.ImageResourceCache.Default.GetImage("images/save/save_16x16.png");
            button.Text = Infrastructure.WinForm.Designer.ResourceMessages.btnSave;
            button.Site.Name = Infrastructure.WinForm.Designer.ResourceMessages.btnSaveName;
        }
        private void SetCloseWithLargeImageStyle(SimpleButton button)
        {
            button.Image = DevExpress.Images.ImageResourceCache.Default.GetImage("images/actions/close_32x32.png");
            button.Text = Infrastructure.WinForm.Designer.ResourceMessages.btnClose;
            button.Site.Name = Infrastructure.WinForm.Designer.ResourceMessages.btnCloseName;
        }
        private void SetCloseWithSmallImageStyle(SimpleButton button)
        {
            button.Image = DevExpress.Images.ImageResourceCache.Default.GetImage("images/actions/close_16x16.png");
            button.Text = Infrastructure.WinForm.Designer.ResourceMessages.btnClose;
            button.Site.Name = Infrastructure.WinForm.Designer.ResourceMessages.btnCloseName;
        }
        private void SetKindWithLargeImageStyle(SimpleButton button)
        {
            button.Image = DevExpress.Images.ImageResourceCache.Default.GetImage("images/Grid/cards_32x32.png");
            button.Text = Infrastructure.WinForm.Designer.ResourceMessages.btnKind;
            button.Site.Name = Infrastructure.WinForm.Designer.ResourceMessages.btnKindName;
        }
        private void SetKindWithSmallImageStyle(SimpleButton button)
        {
            button.Image = DevExpress.Images.ImageResourceCache.Default.GetImage("images/grid/cards_16x16.png");
            button.Text = Infrastructure.WinForm.Designer.ResourceMessages.btnKind;
            button.Site.Name = Infrastructure.WinForm.Designer.ResourceMessages.btnKindName;
        }
        private void SetDefaultStyle(SimpleButton button)
        {
            var _defaultSimpleButton = defaultSimpleButton;
            button.Image = _defaultSimpleButton.Image;
        }
    }
}
