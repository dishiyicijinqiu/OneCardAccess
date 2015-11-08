using DevExpress.XtraEditors.Controls;
using FengSharp.OneCardAccess.Application.IntegeatedManage.Config;
using FengSharp.OneCardAccess.Infrastructure.Exceptions;
using FengSharp.OneCardAccess.Infrastructure.WinForm.Base;
using FengSharp.OneCardAccess.Infrastructure.WinForm.Helper;
using System;
using System.IO;
using System.Windows.Forms;

namespace FengSharp.OneCardAccess.Infrastructure.WinForm.Controls
{
    public class FilePictureEdit : BasePictureEdit
    {
        public FilePictureEdit()
            : base()
        {
            InitializeComponent();
            fileLoader.Loaded += fileLoader_Loaded;
            fileUpLoader.UpLoaded += fileUpLoader_UpLoaded;
        }
        BackgroundFileLoader fileLoader = BackgroundFileLoader.DefaultInstance;
        BackgroundUpLoader fileUpLoader = BackgroundUpLoader.DefaultInstance;
        private string _PdfPath;

        public string PdfPath
        {
            get
            {
                return _PdfPath;
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    this.EditValue = FengSharp.OneCardAccess.Infrastructure.WinForm.ResourceMessages.FileNotFound;
                }
                else
                {
                    this.EditValue = FengSharp.OneCardAccess.Infrastructure.WinForm.ResourceMessages.Pdf;
                }
                _PdfPath = value;
            }
        }
        private PictureMenu _Menu;
        protected override PictureMenu Menu
        {
            get
            {
                if (_Menu == null)
                {
                    _Menu = new PictureMenu(this);
                    _Menu.Items.Clear();
                    _Menu.Items.Add(new DevExpress.Utils.Menu.DXMenuItem("打开", OnOpenClick, FengSharp.OneCardAccess.Infrastructure.WinForm.ResourceMessages.PictureMenuPriview));
                    _Menu.Items.Add(new DevExpress.Utils.Menu.DXMenuItem("删除", OnDeleteClick, FengSharp.OneCardAccess.Infrastructure.WinForm.ResourceMessages.PictureMenuDelete));
                    _Menu.Items.Add(new DevExpress.Utils.Menu.DXMenuItem("上传", OnUpLoadClick, FengSharp.OneCardAccess.Infrastructure.WinForm.ResourceMessages.PictureMenuLoad));
                }
                return _Menu;
            }
        }
        private void OnUpLoadClick(object sender, EventArgs e)
        {
            try
            {
                if (fileLoader.Loading || fileUpLoader.UpLoading)
                {
                    return;
                }
                if (string.IsNullOrWhiteSpace(AttachmentPath))
                {
                    throw new BusinessException("附件路径错误");
                }
                OpenFileDialog opendia = new OpenFileDialog();
                opendia.Multiselect = false;
                opendia.Filter = Filter;
                if (opendia.ShowDialog() == DialogResult.OK)
                {
                    if (File.Exists(opendia.FileName))
                    {
                        string savename = string.Format("{0}\\{1}{2}",
                       AttachmentPath,
                       DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss"),
                       Path.GetExtension(opendia.FileName));
                        if (!splashScreenManager1.IsSplashFormVisible)
                            splashScreenManager1.ShowWaitForm();
                        splashScreenManager1.SetWaitFormCaption(FengSharp.OneCardAccess.Infrastructure.ResourceMessages.Infomation_Title);
                        splashScreenManager1.SetWaitFormDescription(FengSharp.OneCardAccess.Infrastructure.ResourceMessages.UpLoadingPleaseWait);
                        fileUpLoader.UpLoad(opendia.FileName, savename);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBoxEx.Error(ex);
            }
        }
        void fileUpLoader_UpLoaded(object sender, BackgroundUpLoaderEventArgs e)
        {
            try
            {
                if (e.HasError)
                    throw e.Error;
                if (!e.Cancelled)
                {
                    this.PdfPath = Path.GetFileName(e.SaveName);
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

        void fileLoader_Loaded(object sender, BackgroundFileLoaderEventArgs e)
        {
            try
            {
                if (e.HasError)
                    throw e.Error;
                if (!e.Cancelled)
                {
                    if (!File.Exists(e.SaveName))
                    {
                        throw new BusinessException("下载失败");
                    }
                    System.Diagnostics.Process.Start(e.SaveName);
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
        private string filter = "(请选择pdf文件)|*.pdf";
        public string Filter
        {
            get
            {
                return filter;
            }
            set
            {
                filter = value;
            }
        }
        public string AttachmentPath { get; set; }

        private void OnDeleteClick(object sender, EventArgs e)
        {
            this.PdfPath = string.Empty;
        }

        private void OnOpenClick(object sender, EventArgs e)
        {
            try
            {
                if (fileLoader.Loading || fileUpLoader.UpLoading)
                {
                    return;
                }
                if (string.IsNullOrWhiteSpace(AttachmentPath))
                {
                    throw new BusinessException("附件路径错误");
                }
                if (string.IsNullOrWhiteSpace(_PdfPath))
                {
                    throw new BusinessException("文件不存在");
                }
                OpenFileDialog opendia = new OpenFileDialog();
                if (!splashScreenManager1.IsSplashFormVisible)
                    splashScreenManager1.ShowWaitForm();
                splashScreenManager1.SetWaitFormCaption(FengSharp.OneCardAccess.Infrastructure.ResourceMessages.Infomation_Title);
                splashScreenManager1.SetWaitFormDescription(FengSharp.OneCardAccess.Infrastructure.ResourceMessages.LoadingPleaseWait);
                string filename = string.Format("{0}/{1}/{2}", ApplicationConfig.AttachmentPath, AttachmentPath, _PdfPath);
                fileLoader.Load(filename);
            }
            catch (Exception ex)
            {
                MessageBoxEx.Error(ex);
            }
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
        protected override void Dispose(bool disposing)
        {
            base.fDisposing = true;
            if (disposing)
            {
                if (this.fileLoader != null)
                {
                    this.fileLoader.Dispose();
                }
                if (this.fileUpLoader != null)
                {
                    this.fileUpLoader.Dispose();
                }
            }
            base.Dispose(disposing);
        }
        private DevExpress.XtraSplashScreen.SplashScreenManager splashScreenManager1;
    }
}
