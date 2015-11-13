using DevExpress.Utils.Menu;
using DevExpress.XtraEditors.Controls;
using FengSharp.OneCardAccess.Infrastructure.WinForm.Base;
using System;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

namespace FengSharp.OneCardAccess.Infrastructure.WinForm.Forms
{
    public partial class PictureExplorer : BaseForm
    {
        public PictureExplorer(System.Drawing.Image image)
        {
            InitializeComponent();
            this.picProductImage.Image = image;
        }
        string imageURL;
        public PictureExplorer(string imageURL)
        {
            InitializeComponent();
            this.imageURL = imageURL;
        }

        private void PictureExplorer_Load(object sender, System.EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(imageURL))
                this.picProductImage.LoadAsync(imageURL);
        }
        protected override bool ProcessDialogKey(Keys keyData)
        {
            if (keyData == (Keys.Control | Keys.S))
            {
                this.picProductImage.SaveImage();
            }
            return base.ProcessDialogKey(keyData);
        }

        protected override void WndProc(ref Message msg)
        {
            try
            {
                switch (msg.Msg)
                {
                    case 0x020a://鼠标滚轮滚动
                        if ((long)msg.WParam > 0)//向上滚动
                            this.picProductImage.OnZoomInClick(null, null);//放大
                        else
                            this.picProductImage.OnZoomOutClick(null, null);//缩小
                        break;
                    default:
                        break;
                }
                base.WndProc(ref msg);
            }
            catch (Exception ex)
            {
                FengSharp.OneCardAccess.Infrastructure.WinForm.Controls.MessageBoxEx.Error(ex);
            }
        }
    }
    internal class ExplorerPicture : BasePictureEdit
    {
        private PictureMenu _Menu;
        protected override PictureMenu Menu
        {
            get
            {
                if (_Menu == null)
                {
                    _Menu = new PictureMenu(this);
                    _Menu.Items.Clear();
                    _Menu.Items.Add(new DevExpress.Utils.Menu.DXMenuItem("全尺寸", OnFullSizeClick, FengSharp.OneCardAccess.Infrastructure.WinForm.ResourceMessages.PictureMenuFullSize));
                    _Menu.Items.Add(new DevExpress.Utils.Menu.DXMenuItem("适合图像", OnFitImageClick, FengSharp.OneCardAccess.Infrastructure.WinForm.ResourceMessages.PictureMenuFitSize));
                    _Menu.Items.Add(new DevExpress.Utils.Menu.DXMenuItem("缩小", OnZoomOutClick, FengSharp.OneCardAccess.Infrastructure.WinForm.ResourceMessages.PictureMenuZoomSmall));
                    _Menu.Items.Add(new DevExpress.Utils.Menu.DXMenuItem("放大", OnZoomInClick, FengSharp.OneCardAccess.Infrastructure.WinForm.ResourceMessages.PictureMenuZoomBig));
                    _Menu.Items.Add(new DevExpress.Utils.Menu.DXMenuItem("保存", OnSaveClick, FengSharp.OneCardAccess.Infrastructure.WinForm.ResourceMessages.PictureMenuSave));
                }
                return _Menu;
            }
        }
        internal void OnZoomOutClick(object sender, System.EventArgs e)
        {
            var method = typeof(PictureMenu).GetMethod("OnZoomOut", BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.ExactBinding);
            method.Invoke(Menu, new object[] { null, null });
        }
        internal void OnZoomInClick(object sender, System.EventArgs e)
        {
            var method = typeof(PictureMenu).GetMethod("OnZoomIn", BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.ExactBinding);
            method.Invoke(Menu, new object[] { null, null });
        }
        private void OnSaveClick(object sender, System.EventArgs e)
        {
            var method = typeof(PictureMenu).GetMethod("OnClickedSave", BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.ExactBinding);
            method.Invoke(Menu, new object[] { null, null });
        }
        private void OnFullSizeClick(object sender, System.EventArgs e)
        {
            var method = typeof(PictureMenu).GetMethod("OnFullSize", BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.ExactBinding);
            method.Invoke(Menu, new object[] { null, null });
        }
        private void OnFitImageClick(object sender, System.EventArgs e)
        {
            var method = typeof(PictureMenu).GetMethod("OnFitImage", BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.ExactBinding);
            method.Invoke(Menu, new object[] { null, null });
        }
        internal void SaveImage()
        {
            this.OnSaveClick(null, null);
        }
        //protected override bool ProcessDialogKey(Keys keyData)
        //{
        //    if (keyData == (Keys.Control | Keys.S))
        //    {
        //        this.OnSaveClick(null, null);
        //    }
        //    //return base.ProcessDialogKey(keyData);
        //    return true;
        //}
    }
}