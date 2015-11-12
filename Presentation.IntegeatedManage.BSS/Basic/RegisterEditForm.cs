using FengSharp.OneCardAccess.Application.IntegeatedManage.Config;
using FengSharp.OneCardAccess.Domain.BSSModule.Entity;
using FengSharp.OneCardAccess.Domain.BSSModule.Service.Interface;
using FengSharp.OneCardAccess.Domain.RBACModule.Service.Interface;
using FengSharp.OneCardAccess.Infrastructure;
using FengSharp.OneCardAccess.Infrastructure.Base;
using FengSharp.OneCardAccess.Infrastructure.Events;
using FengSharp.OneCardAccess.Infrastructure.Exceptions;
using FengSharp.OneCardAccess.Infrastructure.WinForm;
using FengSharp.OneCardAccess.Infrastructure.WinForm.Base;
using FengSharp.OneCardAccess.Infrastructure.WinForm.Controls;
using FengSharp.OneCardAccess.Infrastructure.WinForm.Helper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
namespace FengSharp.OneCardAccess.Presentation.IntegeatedManage.BSS
{
    public partial class RegisterEditForm : RegisterEditForm_Design
    {
        public RegisterEditForm(ViewType viewtype = ViewType.Add, string id = null)
        {
            InitializeComponent();
            RegisterFilePictureEdit.AttachmentPath = ApplicationConfig.RegisterFilePath;
            this.EntityId = id;
            this.ViewType = viewtype;
        }
        #region fileds
        public event VEventHandler<CEventArgs<ViewType, string>> AfterEdit;
        public string EntityId { get; set; }
        ViewType viewtype = ViewType.ReadOnly;
        public ViewType ViewType
        {
            get
            {
                return viewtype;
            }
            set
            {
                bool isreadonly = value == ViewType.ReadOnly;
                this.baseDataLayoutControl1.SetReadOnly(isreadonly, new Control[] {
                    this.CreateNameTextEdit,this.CreateDateTextEdit,this.LastModifyNameTextEdit,this.LastModifyDateTextEdit
                });
                this.btnSave.Enabled = !isreadonly;
                viewtype = value;
            }
        }
        #endregion

        internal void SetData(RegisterCMEntity bindentity)
        {
            this.bindbaseDataLayoutControl1.DataSource = bindentity;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.ViewType == ViewType.ReadOnly)
                {

                }
                else
                {
                    this.bindbaseDataLayoutControl1.EndEdit();
                    var bindEntity = this.bindbaseDataLayoutControl1.DataSource as RegisterCMEntity;
                    var entity = new RegisterEntity();
                    var attachments = this.bindingAttachment.DataSource as List<RegisterAttachmentEntityNewLogic>;
                    FengSharp.Tool.Reflect.ClassValueCopier.Copy(entity, bindEntity);
                    Infrastructure.EntityTool.CopyModify(entity);
                    switch (this.ViewType)
                    {
                        case ViewType.Add:
                        case ViewType.CopyAdd:
                            this.EntityId = this.Facade.CreateRegister(entity, attachments);
                            MessageBoxEx.Info(FengSharp.OneCardAccess.Infrastructure.ResourceMessages.AddSuccess);
                            break;
                        case ViewType.Edit:
                            this.Facade.UpdateRegister(entity, attachments);
                            MessageBoxEx.Info(FengSharp.OneCardAccess.Infrastructure.ResourceMessages.SaveSuccess);
                            break;
                    }
                }
                OnAfterEdit();
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
            }
            catch (Exception ex)
            {
                MessageBoxEx.Error(ex);
            }
        }

        private void OnAfterEdit()
        {
            if (AfterEdit != null) this.AfterEdit(new CEventArgs<ViewType, string>(this.viewtype, this.EntityId));
        }

        internal void BindAttachmentData(RegisterAttachmentEntityNewLogic[] registerAttachmentEntityNewLogic)
        {
            this.bindingAttachment.DataSource = new List<RegisterAttachmentEntityNewLogic>(registerAttachmentEntityNewLogic);
            this.gridControl1.DataSource = this.bindingAttachment;
        }

        private void RegisterEditForm_Load(object sender, EventArgs e)
        {
            try
            {
                this.Facade = new RegisterEditFormFacade(this);
                this.Facade.SetData();
            }
            catch (Exception ex)
            {
                this.formLoadErrorExit1.LoadError();
                MessageBoxEx.Error(ex);
            }
        }

        private void gvAttachment_PopupMenuShowing(object sender, DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs e)
        {
            if (e.MenuType == DevExpress.XtraGrid.Views.Grid.GridMenuType.User || e.MenuType == DevExpress.XtraGrid.Views.Grid.GridMenuType.Row)
            {
                if (e.Menu == null)
                    e.Menu = new DevExpress.XtraGrid.Menu.GridViewMenu(sender as DevExpress.XtraGrid.Views.Grid.GridView);
                e.Menu.Items.Add(new DevExpress.Utils.Menu.DXMenuItem("查看", OnViewClick, FengSharp.OneCardAccess.Infrastructure.WinForm.ResourceMessages.PictureMenuPriview));
                e.Menu.Items.Add(new DevExpress.Utils.Menu.DXMenuItem("上传", OnUpLoadClick, FengSharp.OneCardAccess.Infrastructure.WinForm.ResourceMessages.PictureMenuLoad));
                e.Menu.Items.Add(new DevExpress.Utils.Menu.DXMenuItem("删除", OnDeleteClick, FengSharp.OneCardAccess.Infrastructure.WinForm.ResourceMessages.PictureMenuDelete));
            }
        }

        private void OnViewClick(object sender, EventArgs e)
        {
            try
            {
                if (this.gvAttachment.FocusedRowHandle < 0)
                {
                    MessageBoxEx.Info(FengSharp.OneCardAccess.Infrastructure.ResourceMessages.List_AtLeastOne);
                    return;
                }
                var row = this.gvAttachment.GetRow(this.gvAttachment.FocusedRowHandle) as RegisterAttachmentEntityNewLogic;
                string filename = string.Format("{0}/{1}/{2}", ApplicationConfig.AttachmentPath, ApplicationConfig.RegisterAttachmentPath, row.SaveName);
                var backgroundFileLoader = BackgroundFileLoader.DefaultInstance;
                backgroundFileLoader.Loaded += backgroundFileLoader_Loaded;
                if (!splashScreenManager1.IsSplashFormVisible)
                    splashScreenManager1.ShowWaitForm();
                splashScreenManager1.SetWaitFormCaption(FengSharp.OneCardAccess.Infrastructure.ResourceMessages.Infomation_Title);
                splashScreenManager1.SetWaitFormDescription(FengSharp.OneCardAccess.Infrastructure.ResourceMessages.LoadingPleaseWait);
                backgroundFileLoader.Load(filename);
            }
            catch (Exception ex)
            {
                MessageBoxEx.Error(ex);
            }
        }

        void backgroundFileLoader_Loaded(object sender, BackgroundFileLoaderEventArgs e)
        {
            try
            {
                if (e.HasError)
                    throw e.Error;
                if (!e.Cancelled)
                {
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

        private void OnDeleteClick(object sender, EventArgs e)
        {
            try
            {
                if (this.gvAttachment.FocusedRowHandle < 0)
                {
                    MessageBoxEx.Info(FengSharp.OneCardAccess.Infrastructure.ResourceMessages.List_AtLeastOne);
                    return;
                }
                var data = this.bindingAttachment.DataSource as List<RegisterAttachmentEntityNewLogic>;
                this.gvAttachment.GetSelectedRows().Select(t => this.gvAttachment.GetRow(t) as RegisterAttachmentEntityNewLogic).ToList().ForEach(
                    new Action<RegisterAttachmentEntityNewLogic>((entity) =>
                    {
                        data.Remove(entity);
                    }));
                this.bindingAttachment.ResetBindings(false);
            }
            catch (Exception ex)
            {
                MessageBoxEx.Error(ex);
            }
        }

        private void OnUpLoadClick(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog opendia = new OpenFileDialog();
                opendia.Multiselect = false;
                opendia.Filter = "(请选择jpg图片)|*.jpg|(word文档)|*.doc;*.docx";
                if (opendia.ShowDialog() == DialogResult.OK)
                {
                    if (File.Exists(opendia.FileName))
                    {
                        string savename = string.Format("{0}\\{1}{2}",
                            FengSharp.OneCardAccess.Application.IntegeatedManage.Config.ApplicationConfig.RegisterAttachmentPath,
                            DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss"),
                            Path.GetExtension(opendia.FileName));
                        var backgroundUpLoader = BackgroundUpLoader.DefaultInstance;
                        backgroundUpLoader.UpLoaded += backgroundUpLoader_UpLoaded;
                        if (!splashScreenManager1.IsSplashFormVisible)
                            splashScreenManager1.ShowWaitForm();
                        splashScreenManager1.SetWaitFormCaption(FengSharp.OneCardAccess.Infrastructure.ResourceMessages.Infomation_Title);
                        splashScreenManager1.SetWaitFormDescription(FengSharp.OneCardAccess.Infrastructure.ResourceMessages.UpLoadingPleaseWait);
                        backgroundUpLoader.UpLoad(opendia.FileName, savename);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBoxEx.Error(ex);
            }
        }

        void backgroundUpLoader_UpLoaded(object sender, BackgroundUpLoaderEventArgs e)
        {
            try
            {
                if (e.HasError)
                    throw e.Error;
                if (!e.Cancelled)
                {
                    var data = this.bindingAttachment.DataSource as List<RegisterAttachmentEntityNewLogic>;
                    data.Add(new RegisterAttachmentEntityNewLogic()
                    {
                        RegisterId = this.EntityId,
                        Id = Guid.NewGuid().ToString(),
                        IsNew = true,
                        SaveName = Path.GetFileName(e.SaveName),
                        ShowName = Path.GetFileNameWithoutExtension(e.ShowName)
                    });
                    this.bindingAttachment.ResetBindings(false);
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
    }
    public class RegisterEditForm_Design : Base_Form<RegisterEditFormFacade>
    {
    }
    public class RegisterEditFormFacade : ActualBase<RegisterEditForm>
    {
        private IRegisterService _RegisterService = ServiceProxyFactory.Create<IRegisterService>();
        public RegisterEditFormFacade(RegisterEditForm actual)
            : base(actual)
        { }

        internal void SetData()
        {
            switch (this.Actual.ViewType)
            {
                case ViewType.Add:
                    {
                        #region Add
                        this.Actual.BindAttachmentData(new RegisterAttachmentEntityNewLogic[0]);
                        RegisterEntity entity = new RegisterEntity();
                        Infrastructure.EntityTool.CopyCreateAndModify(entity);
                        RegisterCMEntity bindentity = new RegisterCMEntity();
                        FengSharp.Tool.Reflect.ClassValueCopier.Copy(bindentity, entity);
                        bindentity.CreateName = ServiceProxyFactory.Create<IUserService>().FindUserById(bindentity.CreateId).UserName;
                        bindentity.LastModifyName = ServiceProxyFactory.Create<IUserService>().FindUserById(bindentity.LastModifyId).UserName;
                        this.Actual.SetData(bindentity);
                        #endregion
                    }
                    break;
                case ViewType.CopyAdd:
                    {
                        #region CopyAdd
                        this.Actual.BindAttachmentData(new RegisterAttachmentEntityNewLogic[0]);
                        RegisterEntity entity = this._RegisterService.GetRegisterById(this.Actual.EntityId);
                        if (entity == null)
                            throw new BusinessException(FengSharp.OneCardAccess.Infrastructure.ResourceMessages.ObjectCannotFind);
                        Infrastructure.EntityTool.CopyCreateAndModify(entity);
                        RegisterCMEntity bindentity = new RegisterCMEntity();
                        FengSharp.Tool.Reflect.ClassValueCopier.Copy(bindentity, entity);
                        bindentity.CreateName = ServiceProxyFactory.Create<IUserService>().FindUserById(bindentity.CreateId).UserName;
                        bindentity.LastModifyName = ServiceProxyFactory.Create<IUserService>().FindUserById(bindentity.LastModifyId).UserName;
                        bindentity.RegisterFile = string.Empty;
                        bindentity.Remark = string.Empty;
                        bindentity.StartDate = string.Empty;
                        bindentity.EndDate = string.Empty;
                        this.Actual.SetData(bindentity);

                        #endregion
                    }
                    break;
                case ViewType.Edit:
                case ViewType.ReadOnly:
                    {
                        #region Edit,ReadOnly
                        RegisterEntity entity = this._RegisterService.GetRegisterById(this.Actual.EntityId);
                        if (entity == null)
                            throw new BusinessException(FengSharp.OneCardAccess.Infrastructure.ResourceMessages.ObjectCannotFind);

                        RegisterCMEntity bindentity = new RegisterCMEntity();
                        FengSharp.Tool.Reflect.ClassValueCopier.Copy(bindentity, entity);
                        bindentity.CreateName = ServiceProxyFactory.Create<IUserService>().FindUserById(bindentity.CreateId).UserName;
                        bindentity.LastModifyName = ServiceProxyFactory.Create<IUserService>().FindUserById(bindentity.LastModifyId).UserName;
                        this.Actual.SetData(bindentity);

                        RegisterAttachmentEntity[] registerAttachmentEntitys = this._RegisterService.GetRegisterAttachmentEntitys(bindentity.RegisterId);
                        RegisterAttachmentEntityNewLogic[] attachmentEntitys = new RegisterAttachmentEntityNewLogic[registerAttachmentEntitys.Length];
                        for (int i = 0; i < attachmentEntitys.Length; i++)
                        {
                            attachmentEntitys[i] = new RegisterAttachmentEntityNewLogic();
                            FengSharp.Tool.Reflect.ClassValueCopier.Copy(attachmentEntitys[i], registerAttachmentEntitys[i]);
                            attachmentEntitys[i].IsNew = false;
                        }
                        this.Actual.BindAttachmentData(attachmentEntitys);


                        #endregion
                    }
                    break;
                case ViewType.Kind:
                case ViewType.AddChild:
                default:
                    throw new BusinessException(FengSharp.OneCardAccess.Infrastructure.ResourceMessages.ErrorType);
            }
        }

        internal string CreateRegister(RegisterEntity entity, List<RegisterAttachmentEntityNewLogic> attachments)
        {
            EntityTool.CopyCreateAndModify(entity);
            return _RegisterService.CreateRegisterWithAttachment(entity, attachments.ToArray());

        }

        internal void UpdateRegister(RegisterEntity entity, List<RegisterAttachmentEntityNewLogic> attachments)
        {
            EntityTool.CopyModify(entity);
            _RegisterService.UpdateRegisterWithAttachment(entity, attachments.ToArray());
        }
    }
}