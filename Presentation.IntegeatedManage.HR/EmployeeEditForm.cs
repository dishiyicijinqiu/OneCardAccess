using DevExpress.XtraEditors;
using FengSharp.OneCardAccess.Application.IntegeatedManage.Config;
using FengSharp.OneCardAccess.Domain.HRModule.Entity;
using FengSharp.OneCardAccess.Domain.HRModule.Service.Interface;
using FengSharp.OneCardAccess.Domain.RBACModule.Service.Interface;
using FengSharp.OneCardAccess.Infrastructure;
using FengSharp.OneCardAccess.Infrastructure.Base;
using FengSharp.OneCardAccess.Infrastructure.Events;
using FengSharp.OneCardAccess.Infrastructure.Exceptions;
using FengSharp.OneCardAccess.Infrastructure.Services.Interface;
using FengSharp.OneCardAccess.Infrastructure.WinForm;
using FengSharp.OneCardAccess.Infrastructure.WinForm.Base;
using FengSharp.OneCardAccess.Infrastructure.WinForm.Controls;
using FengSharp.OneCardAccess.Infrastructure.WinForm.Helper;
using FengSharp.OneCardAccess.Presentation.IntegeatedManage.HR.Interface;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace FengSharp.OneCardAccess.Presentation.IntegeatedManage.HR
{
    public partial class EmployeeEditForm : EmployeeEditForm_Design
    {
        #region ctor
        public EmployeeEditForm(ViewType viewtype = ViewType.Add, string id = null)
        {
            InitializeComponent();
            this.EntityId = id;
            this.ViewType = viewtype;
            if (!DesignMode)
            {
                var popupContainerControl = ServiceLoader.LoadService<ISingleDeptSelect>("SingleDeptControlSelect") as PopupContainerControl;
                popupContainerControl.Width = 500;
                popupContainerControl.Height = 300;
                this.DeptNamePopupContainerEdit.Properties.PopupControl = popupContainerControl;
            }
        }
        #endregion
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
        #region 绑定数据
        public void SetData(EmployeeCMDeptEntity entity)
        {
            this.bindbaseDataLayoutControl1.DataSource = entity;
        }

        internal void BindNation(DicDataEntity[] NationEntitys)
        {
            new PopupContainerEditPopupListBoxHelper(this.NationPopupContainerEdit.Properties)
            {
                DataSource = NationEntitys,
                DisplayMember = "DicValue",
                ValueMember = "DicValue"
            };
        }

        internal void BindOrigin(DicDataEntity[] OriginEntitys)
        {
            new PopupContainerEditPopupListBoxHelper(this.OriginPopupContainerEdit.Properties)
            {
                DataSource = OriginEntitys,
                DisplayMember = "DicValue",
                ValueMember = "DicValue"
            };
        }

        internal void BindPost(DicDataEntity[] PostEntitys)
        {
            new PopupContainerEditPopupListBoxHelper(this.PostPopupContainerEdit.Properties)
            {
                TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor,
                DataSource = PostEntitys,
                DisplayMember = "DicValue",
                ValueMember = "DicValue"
            };
        }

        internal void BindTitle(DicDataEntity[] TitleEntitys)
        {
            new PopupContainerEditPopupListBoxHelper(this.TitlePopupContainerEdit.Properties)
            {
                TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor,
                DataSource = TitleEntitys,
                DisplayMember = "DicValue",
                ValueMember = "DicValue"
            };
        }

        internal void BindDuty(DicDataEntity[] DutyEntitys)
        {
            new PopupContainerEditPopupListBoxHelper(this.DutyPopupContainerEdit.Properties)
            {
                TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor,
                DataSource = DutyEntitys,
                DisplayMember = "DicValue",
                ValueMember = "DicValue"
            };
        }
        #endregion

        private void EmployeeEditForm_Load(object sender, EventArgs e)
        {
            try
            {
                this.Facade = new EmployeeEditFormFacade(this);
                this.Facade.BindData();
                this.Facade.SetData();
            }
            catch (Exception ex)
            {
                this.formLoadErrorExit1.LoadError();
                MessageBoxEx.Error(ex);
            }
        }
        private void OnAfterEdit()
        {
            if (AfterEdit != null) this.AfterEdit(new CEventArgs<ViewType, string>(this.viewtype, this.EntityId));
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
                    this.bindingAttachment.ResetBindings(false);
                    this.bindbaseDataLayoutControl1.EndEdit();
                    var bindEntity = this.bindbaseDataLayoutControl1.DataSource as EmployeeCMDeptEntity;
                    var entity = new EmployeeEntity();
                    var attachments = this.bindingAttachment.DataSource as List<EmployeeAttachmentEntityNewLogic>;
                    FengSharp.Tool.Reflect.ClassValueCopier.Copy(entity, bindEntity);
                    Infrastructure.EntityTool.CopyModify(entity);
                    switch (this.ViewType)
                    {
                        case ViewType.Add:
                        case ViewType.CopyAdd:
                            this.EntityId = this.Facade.CreateEmployee(entity, attachments);
                            MessageBoxEx.Info(FengSharp.OneCardAccess.Infrastructure.ResourceMessages.AddSuccess);
                            break;
                        case ViewType.Edit:
                            this.Facade.UpdateEmployee(entity, attachments);
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


        private void btnClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }

        private void DeptNamePopupContainerEdit_Properties_QueryResultValue(object sender, DevExpress.XtraEditors.Controls.QueryResultValueEventArgs e)
        {
            var basePopupContainerEdit = sender as BasePopupContainerEdit;
            var singleDeptSelect = basePopupContainerEdit.Properties.PopupControl as ISingleDeptSelect;
            if (!singleDeptSelect.IsSelect) return;
            var deptEntity = singleDeptSelect.GetResult();
            var empEntity = this.bindbaseDataLayoutControl1.DataSource as EmployeeCMDeptEntity;
            if (deptEntity == null)
            {
                empEntity.DeptId = 0;
                empEntity.DeptNo = string.Empty;
                empEntity.DeptName = string.Empty;
            }
            else
            {
                empEntity.DeptId = deptEntity.DeptId;
                empEntity.DeptNo = deptEntity.DeptNo;
                empEntity.DeptName = deptEntity.DeptName;
            }
            e.Value = empEntity.DeptName;
        }

        internal void BindAttachmentData(EmployeeAttachmentEntityNewLogic[] attachmentEntitys)
        {
            this.bindingAttachment.DataSource = new List<EmployeeAttachmentEntityNewLogic>(attachmentEntitys);
            this.gridControl1.DataSource = this.bindingAttachment;
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
                var row = this.gvAttachment.GetRow(this.gvAttachment.FocusedRowHandle) as EmployeeAttachmentEntityNewLogic;
                string filename = string.Format("{0}/{1}/{2}", ApplicationConfig.AttachmentPath, ApplicationConfig.EmployeeAttachmentPath, row.SaveName);
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
                var data = this.bindingAttachment.DataSource as List<EmployeeAttachmentEntityNewLogic>;
                this.gvAttachment.GetSelectedRows().Select(t => this.gvAttachment.GetRow(t) as EmployeeAttachmentEntityNewLogic).ToList().ForEach(
                    new Action<EmployeeAttachmentEntityNewLogic>((entity) =>
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
                            FengSharp.OneCardAccess.Application.IntegeatedManage.Config.ApplicationConfig.EmployeeAttachmentPath,
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
                    var data = this.bindingAttachment.DataSource as List<EmployeeAttachmentEntityNewLogic>;
                    data.Add(new EmployeeAttachmentEntityNewLogic()
                    {
                        EmpId = this.EntityId,
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
    public class EmployeeEditForm_Design : Base_Form<EmployeeEditFormFacade>
    {
    }
    public class EmployeeEditFormFacade : ActualBase<EmployeeEditForm>
    {
        private IEmployeeService _EmployeeService = ServiceProxyFactory.Create<IEmployeeService>();
        public EmployeeEditFormFacade(EmployeeEditForm actual)
            : base(actual)
        { }
        internal void BindData()
        {
            DicDataEntity[] entitys = ServiceProxyFactory.Create<IDicDataService>().GetDataByDicTypes(
                    new string[] { 
                        "Post","Duty", "Title","Origin","Nation"
                    }
                );
            var NationEntitys = entitys.Where(t => string.Compare(t.DicType, "Nation", true) == 0).ToArray();
            this.Actual.BindNation(NationEntitys);
            var OriginEntitys = entitys.Where(t => string.Compare(t.DicType, "Origin", true) == 0).ToArray();
            this.Actual.BindOrigin(OriginEntitys);
            var PostEntitys = entitys.Where(t => string.Compare(t.DicType, "Post", true) == 0).ToArray();
            this.Actual.BindPost(PostEntitys);
            var TitleEntitys = entitys.Where(t => string.Compare(t.DicType, "Title", true) == 0).ToArray();
            this.Actual.BindTitle(TitleEntitys);
            var DutyEntitys = entitys.Where(t => string.Compare(t.DicType, "Duty", true) == 0).ToArray();
            this.Actual.BindDuty(DutyEntitys);
        }

        internal void SetData()
        {
            switch (this.Actual.ViewType)
            {
                case ViewType.Add:
                    {
                        #region Add
                        this.Actual.BindAttachmentData(new EmployeeAttachmentEntityNewLogic[0]);

                        EmployeeEntity entity = new EmployeeEntity();
                        Infrastructure.EntityTool.CopyCreateAndModify(entity);
                        EmployeeCMDeptEntity bindentity = new EmployeeCMDeptEntity();
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
                        EmployeeEntity entity = this._EmployeeService.FindEmployeeById(this.Actual.EntityId);
                        if (entity == null)
                            throw new BusinessException(FengSharp.OneCardAccess.Infrastructure.ResourceMessages.ObjectCannotFind);
                        Infrastructure.EntityTool.CopyCreateAndModify(entity);

                        EmployeeCMDeptEntity bindentity = new EmployeeCMDeptEntity();
                        FengSharp.Tool.Reflect.ClassValueCopier.Copy(bindentity, entity);
                        bindentity.CreateName = ServiceProxyFactory.Create<IUserService>().FindUserById(bindentity.CreateId).UserName;
                        bindentity.LastModifyName = ServiceProxyFactory.Create<IUserService>().FindUserById(bindentity.LastModifyId).UserName;
                        bindentity.Photo = string.Empty;
                        bindentity.EmpName = string.Empty;
                        bindentity.GenCardNo = string.Empty;
                        bindentity.AttCardNo = string.Empty;
                        this.Actual.SetData(bindentity);

                        this.Actual.BindAttachmentData(new EmployeeAttachmentEntityNewLogic[0]);
                        #endregion
                    }
                    break;
                case ViewType.Edit:
                case ViewType.ReadOnly:
                    {
                        #region Edit,ReadOnly
                        EmployeeEntity entity = this._EmployeeService.FindEmployeeById(this.Actual.EntityId);
                        if (entity == null)
                            throw new BusinessException(FengSharp.OneCardAccess.Infrastructure.ResourceMessages.ObjectCannotFind);

                        EmployeeCMDeptEntity bindentity = new EmployeeCMDeptEntity();
                        FengSharp.Tool.Reflect.ClassValueCopier.Copy(bindentity, entity);
                        bindentity.CreateName = ServiceProxyFactory.Create<IUserService>().FindUserById(bindentity.CreateId).UserName;
                        bindentity.LastModifyName = ServiceProxyFactory.Create<IUserService>().FindUserById(bindentity.LastModifyId).UserName;
                        var deptEntity = ServiceProxyFactory.Create<IDeptService>().GetDeptById(bindentity.DeptId);
                        if (deptEntity != null)
                        {
                            bindentity.DeptNo = deptEntity.DeptNo;
                            bindentity.DeptName = deptEntity.DeptName;
                        }
                        this.Actual.SetData(bindentity);

                        EmployeeAttachmentEntity[] employeeAttachmentEntitys = this._EmployeeService.GetEmployeeAttachmentEntitys(bindentity.EmpId);
                        EmployeeAttachmentEntityNewLogic[] attachmentEntitys = new EmployeeAttachmentEntityNewLogic[employeeAttachmentEntitys.Length];
                        for (int i = 0; i < attachmentEntitys.Length; i++)
                        {
                            attachmentEntitys[i] = new EmployeeAttachmentEntityNewLogic();
                            FengSharp.Tool.Reflect.ClassValueCopier.Copy(attachmentEntitys[i], employeeAttachmentEntitys[i]);
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

        internal string CreateEmployee(EmployeeEntity entity, List<EmployeeAttachmentEntityNewLogic> attachments)
        {
            AuthIdentity authidentity = (System.Threading.Thread.CurrentPrincipal as AuthPrincipal).Identity as AuthIdentity;
            entity.CreateId = authidentity.UserId;
            entity.CreateDate = DateTime.Now;
            entity.LastModifyId = authidentity.UserId;
            entity.LastModifyDate = DateTime.Now;
            return _EmployeeService.CreateEmployeeWithAttachment(entity, attachments.ToArray());
        }

        internal void UpdateEmployee(EmployeeEntity entity, List<EmployeeAttachmentEntityNewLogic> attachments)
        {
            AuthIdentity authidentity = (System.Threading.Thread.CurrentPrincipal as AuthPrincipal).Identity as AuthIdentity;
            entity.LastModifyId = authidentity.UserId;
            entity.LastModifyDate = DateTime.Now;
            _EmployeeService.UpdateEmployeeWithAttachment(entity, attachments.ToArray());
        }
    }
}
