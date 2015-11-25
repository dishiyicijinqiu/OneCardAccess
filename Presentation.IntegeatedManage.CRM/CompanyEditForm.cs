using FengSharp.OneCardAccess.Domain.CRMModule.Entity;
using FengSharp.OneCardAccess.Domain.CRMModule.Service.Interface;
using FengSharp.OneCardAccess.Domain.RBACModule.Service.Interface;
using FengSharp.OneCardAccess.Infrastructure;
using FengSharp.OneCardAccess.Infrastructure.Base;
using FengSharp.OneCardAccess.Infrastructure.Events;
using FengSharp.OneCardAccess.Infrastructure.Exceptions;
using FengSharp.OneCardAccess.Infrastructure.WinForm;
using FengSharp.OneCardAccess.Infrastructure.WinForm.Base;
using FengSharp.OneCardAccess.Infrastructure.WinForm.Controls;
using System;
using System.Windows.Forms;

namespace FengSharp.OneCardAccess.Presentation.IntegeatedManage.CRM
{
    public partial class CompanyEditForm : CompanyEditForm_Design
    {
        public CompanyEditForm(int pid, ViewType viewtype = ViewType.Add, int id = 0)
        {
            InitializeComponent();
            this.EntityId = id;
            this.PId = pid;
            this.ViewType = viewtype;
        }
        public event VEventHandler<CEventArgs<ViewType, int, int>> AfterEdit;
        public int EntityId { get; set; }
        public int PId { get; set; }
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
                this.baseDataLayoutControl1.SetReadOnly(isreadonly, new Control[]{
                    this.CreateDateTextEdit,this.CreateNameTextEdit,this.LastModifyNameTextEdit,this.LastModifyDateTextEdit
                });
                this.btnSave.Enabled = !isreadonly;
                viewtype = value;
            }
        }

        private void CompanyEditForm_Load(object sender, EventArgs e)
        {
            try
            {
                this.Facade = new CompanyEditFormFacade(this);
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
            if (AfterEdit != null)
                this.AfterEdit(new CEventArgs<ViewType, int, int>(this.viewtype, this.EntityId, this.PId));
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
                    var entity = new CompanyEntity();
                    FengSharp.Tool.Reflect.ClassValueCopier.Copy(entity, this.bindbaseDataLayoutControl1.DataSource);
                    Infrastructure.EntityTool.CopyModify(entity);
                    switch (this.ViewType)
                    {
                        case ViewType.Add:
                        case ViewType.CopyAdd:
                            this.EntityId = this.Facade.CreateDept(entity);
                            MessageBoxEx.Info(FengSharp.OneCardAccess.Infrastructure.ResourceMessages.AddSuccess);
                            break;
                        case ViewType.Edit:
                            this.Facade.UpdateDept(entity);
                            MessageBoxEx.Info(FengSharp.OneCardAccess.Infrastructure.ResourceMessages.SaveSuccess);
                            break;
                        case ViewType.Kind:
                            this.EntityId = this.Facade.CreateDept(entity);
                            MessageBoxEx.Info(FengSharp.OneCardAccess.Infrastructure.ResourceMessages.CateSuccess);
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
            this.Close();
        }

        internal void SetData(CompanyCMEntity bindentity)
        {
            this.bindbaseDataLayoutControl1.DataSource = bindentity;
        }
    }
    public class CompanyEditForm_Design : Base_Form<CompanyEditFormFacade>
    {
    }
    public class CompanyEditFormFacade : ActualBase<CompanyEditForm>
    {
        private ICompanyService _CompanyService = ServiceProxyFactory.Create<ICompanyService>();

        public CompanyEditFormFacade(CompanyEditForm actual)
            : base(actual) { }

        internal int CreateDept(CompanyEntity entity)
        {
            return this._CompanyService.CreateCompany(entity);
        }

        internal void UpdateDept(CompanyEntity entity)
        {
            this._CompanyService.UpdateCompany(entity);
        }

        internal void SetData()
        {
            switch (this.Actual.ViewType)
            {
                case ViewType.Add:
                    {
                        #region Add
                        CompanyEntity entity = new CompanyEntity();
                        Infrastructure.EntityTool.CopyCreateAndModify(entity);
                        entity.PId = this.Actual.PId;
                        CompanyCMEntity bindentity = new CompanyCMEntity();
                        FengSharp.Tool.Reflect.ClassValueCopier.Copy(bindentity, entity);
                        bindentity.CreateName = ServiceLoader.LoadService<SystemSet.Interface.IClientUserSerice>().FindUserByIdFromCache(bindentity.CreateId).UserName;
                        bindentity.LastModifyName = ServiceLoader.LoadService<SystemSet.Interface.IClientUserSerice>().FindUserByIdFromCache(bindentity.LastModifyId).UserName;
                        this.Actual.SetData(bindentity);
                        #endregion
                    }
                    break;
                case ViewType.CopyAdd:
                case ViewType.Kind:
                    {
                        #region CopyAdd,Kind
                        CompanyEntity entity = this._CompanyService.GetCompanyById(this.Actual.EntityId);
                        if (entity == null)
                            throw new BusinessException(FengSharp.OneCardAccess.Infrastructure.ResourceMessages.ObjectCannotFind);
                        Infrastructure.EntityTool.CopyCreateAndModify(entity);
                        entity.PId = this.Actual.PId;
                        CompanyCMEntity bindentity = new CompanyCMEntity();
                        FengSharp.Tool.Reflect.ClassValueCopier.Copy(bindentity, entity);
                        bindentity.CreateName = ServiceLoader.LoadService<SystemSet.Interface.IClientUserSerice>().FindUserByIdFromCache(bindentity.CreateId).UserName;
                        bindentity.LastModifyName = ServiceLoader.LoadService<SystemSet.Interface.IClientUserSerice>().FindUserByIdFromCache(bindentity.LastModifyId).UserName;
                        this.Actual.SetData(bindentity);
                        #endregion
                    }
                    break;
                case ViewType.Edit:
                case ViewType.ReadOnly:
                    {
                        #region Edit,ReadOnly
                        CompanyEntity entity = this._CompanyService.GetCompanyById(this.Actual.EntityId);
                        if (entity == null)
                            throw new BusinessException(FengSharp.OneCardAccess.Infrastructure.ResourceMessages.ObjectCannotFind);
                        CompanyCMEntity bindentity = new CompanyCMEntity();
                        FengSharp.Tool.Reflect.ClassValueCopier.Copy(bindentity, entity);
                        bindentity.CreateName = ServiceLoader.LoadService<SystemSet.Interface.IClientUserSerice>().FindUserByIdFromCache(bindentity.CreateId).UserName;
                        bindentity.LastModifyName = ServiceLoader.LoadService<SystemSet.Interface.IClientUserSerice>().FindUserByIdFromCache(bindentity.LastModifyId).UserName;
                        this.Actual.SetData(bindentity);
                        #endregion
                    }
                    break;
                case ViewType.AddChild:
                    break;
                default:
                    break;
            }
        }
    }
}