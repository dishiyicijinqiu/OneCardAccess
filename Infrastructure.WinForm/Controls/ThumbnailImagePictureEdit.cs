using DevExpress.XtraEditors.Controls;
using FengSharp.OneCardAccess.Application.IntegeatedManage.Config;
using FengSharp.OneCardAccess.Infrastructure.WinForm.Base;
using FengSharp.OneCardAccess.Infrastructure.WinForm.Forms;
using FengSharp.OneCardAccess.Infrastructure.WinForm.Helper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;

namespace FengSharp.OneCardAccess.Infrastructure.WinForm.Controls
{
    public class ThumbnailImagePictureEdit : BasePictureEdit
    {
        private BackgroundImageURLUpLoader imageUpLoader;
        private DevExpress.XtraSplashScreen.SplashScreenManager splashScreenManager1;
        public ThumbnailImagePictureEdit()
            : base()
        {
            InitializeComponent();
            this.imageUpLoader = new BackgroundImageURLUpLoader();
            this.imageUpLoader.UpLoaded += imageUpLoader_UpLoaded;
        }
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FilePictureEdit));
            if (!DesignMode)
                this.splashScreenManager1 = new DevExpress.XtraSplashScreen.SplashScreenManager(this.FindForm(), typeof(FengSharp.OneCardAccess.Infrastructure.WinForm.Forms.BaseWaitForm), true, true);
            this.SuspendLayout();
            // 
            // splashScreenManager1
            // 
            if (!DesignMode)
                splashScreenManager1.ClosingDelay = 500;
            this.ResumeLayout(false);
        }
        void imageUpLoader_UpLoaded(object sender, BackgroundImageUpLoaderEventArgs e)
        {
            try
            {
                if (!e.Cancelled)
                {
                    if (e.HasError)
                    {
                        MessageBoxEx.Error(e.Error);
                    }
                    else
                    {
                        this.ImageURL = this.imageUpLoader.SaveName;
                    }
                }
            }
            catch (Exception ex)
            {
                if (splashScreenManager1.IsSplashFormVisible)
                    splashScreenManager1.CloseWaitForm();
                MessageBoxEx.Error(ex);
            }
            finally
            {
                if (splashScreenManager1.IsSplashFormVisible)
                    splashScreenManager1.CloseWaitForm();
            }
        }

        private string _ImageURL;
        public string ImageURL
        {
            get
            {
                return _ImageURL;
            }
            set
            {
                if (_ImageURL == value) return;
                _ImageURL = value;
                this.LoadAsync(string.Format("{0}/{1}/{2}", ApplicationConfig.AttachmentPath, ThumbnailAttachmentPath, _ImageURL));
            }
        }

        public string ThumbnailAttachmentPath { get; set; }
        public string AttachmentPath { get; set; }
        private PictureMenu _Menu;
        protected override PictureMenu Menu
        {
            get
            {
                if (_Menu == null)
                {
                    _Menu = new PictureMenu(this);
                    _Menu.Items.Clear();
                    _Menu.Items.Add(new DevExpress.Utils.Menu.DXMenuItem("预览", OnPriviewClick, FengSharp.OneCardAccess.Infrastructure.WinForm.ResourceMessages.PictureMenuPriview));
                    _Menu.Items.Add(new DevExpress.Utils.Menu.DXMenuItem("复制", OnCopyClick, FengSharp.OneCardAccess.Infrastructure.WinForm.ResourceMessages.PictureMenuCopy));
                    _Menu.Items.Add(new DevExpress.Utils.Menu.DXMenuItem("删除", OnDeleteClick, FengSharp.OneCardAccess.Infrastructure.WinForm.ResourceMessages.PictureMenuDelete));
                    _Menu.Items.Add(new DevExpress.Utils.Menu.DXMenuItem("上传", OnUpLoadClick, FengSharp.OneCardAccess.Infrastructure.WinForm.ResourceMessages.PictureMenuLoad));
                    _Menu.Items.Add(new DevExpress.Utils.Menu.DXMenuItem("保存", OnSaveClick, FengSharp.OneCardAccess.Infrastructure.WinForm.ResourceMessages.PictureMenuSave));
                }
                return _Menu;
            }
        }

        private void OnSaveClick(object sender, EventArgs e)
        {
            var method = typeof(PictureMenu).GetMethod("OnClickedSave", BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.ExactBinding);
            method.Invoke(Menu, new object[] { null, null });
        }

        private void OnUpLoadClick(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog opendia = new OpenFileDialog();
                opendia.Multiselect = false;
                opendia.Filter = "(请选择jpg图片)|*.jpg";
                if (opendia.ShowDialog() == DialogResult.OK)
                {
                    if (File.Exists(opendia.FileName))
                    {
                        this.imageUpLoader.UpLoadName = opendia.FileName;

                        //this.imageUpLoader.LastImage = this.Image;
                        //this.Image = this.Properties.InitialImage;

                        if (!splashScreenManager1.IsSplashFormVisible)
                            splashScreenManager1.ShowWaitForm();
                        splashScreenManager1.SetWaitFormCaption(FengSharp.OneCardAccess.Infrastructure.ResourceMessages.Infomation_Title);
                        splashScreenManager1.SetWaitFormDescription(FengSharp.OneCardAccess.Infrastructure.ResourceMessages.UpLoadingPleaseWait);
                        this.imageUpLoader.SaveName = string.Format("{0}.jpg", DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss"));
                        this.UpLoadAsync(string.Format("{0}\\{1}", AttachmentPath, this.imageUpLoader.SaveName));
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBoxEx.Error(ex);
            }
        }

        private void OnDeleteClick(object sender, EventArgs e)
        {
            var method = typeof(PictureMenu).GetMethod("OnClickedDelete", BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.ExactBinding);
            method.Invoke(Menu, new object[] { null, null });
            this._ImageURL = string.Empty;
        }

        private void OnCopyClick(object sender, EventArgs e)
        {
            var method = typeof(PictureMenu).GetMethod("OnClickedCopy", BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.ExactBinding);
            method.Invoke(Menu, new object[] { null, null });
        }

        private void OnPriviewClick(object sender, EventArgs e)
        {
            try
            {
                string imageURL = string.Format("{0}/{1}/{2}",
                      ApplicationConfig.AttachmentPath, AttachmentPath, _ImageURL);
                PictureExplorer explorer = new PictureExplorer(imageURL);
                explorer.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBoxEx.Error(ex);
            }
        }

        public void CancelUpLoadAsync()
        {
            this.imageUpLoader.Abort();
        }
        public void UpLoadAsync(string savename)
        {
            this.imageUpLoader.UpLoad(savename);
        }
        protected override void Dispose(bool disposing)
        {
            base.fDisposing = true;
            if (disposing)
            {
                if (this.imageUpLoader != null)
                {
                    this.imageUpLoader.Dispose();
                }
            }
            base.Dispose(disposing);
        }
    }
}
