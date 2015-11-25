using FengSharp.OneCardAccess.Domain.RBACModule.Entity;
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
namespace FengSharp.OneCardAccess.Presentation.IntegeatedManage.SystemSet
{
    public partial class RoleEditForm : RoleEditForm_Design
    {
        #region ctor
        public RoleEditForm(ViewType viewtype = ViewType.Add, string id = null)
        {
            InitializeComponent();
            this.EntityId = id;
            this.ViewType = viewtype;
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
                this.btnSave.Enabled = !isreadonly;
                this.baseDataLayoutControl1.SetReadOnly(isreadonly, new Control[] {
                    this.CreateNameTextEdit,this.CreateDateTextEdit,this.LastModifyNameTextEdit,this.LastModifyDateTextEdit,
                      this.IsSuperCheckEdit
                });
                viewtype = value;
            }
        }
        #endregion
        private void RoleEditForm_Load(object sender, EventArgs e)
        {
            try
            {
                this.Facade = new RoleEditFormFacade(this);
                this.Facade.SetData();
            }
            catch (Exception ex)
            {
                this.formLoadErrorExit1.LoadError();
                MessageBoxEx.Error(ex);
            }
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
                    var bindEntity = this.bindbaseDataLayoutControl1.DataSource as RoleWithCreateAndModify;
                    var entity = new RoleEntity();
                    FengSharp.Tool.Reflect.ClassValueCopier.Copy(entity, bindEntity);
                    Infrastructure.EntityTool.CopyModify(entity);
                    switch (this.ViewType)
                    {
                        case ViewType.Add:
                        case ViewType.CopyAdd:
                            this.Facade.CreateRole(entity);
                            MessageBoxEx.Info(FengSharp.OneCardAccess.Infrastructure.ResourceMessages.AddSuccess);
                            break;
                        case ViewType.Edit:
                            this.Facade.UpdateRole(entity);
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
        public void SetData(RoleWithCreateAndModify bindentity)
        {
            this.Invoke(new Action(() =>
            {
                this.bindbaseDataLayoutControl1.DataSource = bindentity;
            }));
        }
        private void OnAfterEdit()
        {
            if (AfterEdit != null) this.AfterEdit(new CEventArgs<ViewType, string>(this.viewtype, this.EntityId));
        }
        //private void chkIsLock_CheckedChanged(object sender, EventArgs e)
        //{
        //    this.chkIsLock.Text = this.chkIsLock.Checked ? "启用" : "禁用";
        //}
        //private void chkIsAdmin_CheckedChanged(object sender, EventArgs e)
        //{
        //    this.chkIsAdmin.Text = this.chkIsAdmin.Checked ? "是" : "否";
        //}
    }

    public partial class RoleEditForm_Design : Base_Form<RoleEditFormFacade>
    {
    }
    public class RoleEditFormFacade : ActualBase<RoleEditForm>
    {
        public RoleEditFormFacade(RoleEditForm actual)
            : base(actual) { }
        private IRoleService _Service = ServiceProxyFactory.Create<IRoleService>();
        public void SetData()
        {
            switch (this.Actual.ViewType)
            {
                case ViewType.Add:
                    {
                        #region Add
                        RoleEntity entity = new RoleEntity();
                        Infrastructure.EntityTool.CopyCreateAndModify(entity);
                        RoleWithCreateAndModify bindentity = new RoleWithCreateAndModify();
                        FengSharp.Tool.Reflect.ClassValueCopier.Copy(bindentity, entity);
                        bindentity.CreateName = ServiceLoader.LoadService<SystemSet.Interface.IClientUserSerice>().FindUserByIdFromCache(bindentity.CreateId).UserName;
                        bindentity.LastModifyName = ServiceLoader.LoadService<SystemSet.Interface.IClientUserSerice>().FindUserByIdFromCache(bindentity.LastModifyId).UserName;
                        this.Actual.SetData(bindentity);
                        #endregion
                    }
                    break;
                case ViewType.CopyAdd:
                    {
                        #region CopyAdd
                        RoleEntity entity = this._Service.FindRoleById(this.Actual.EntityId);
                        if (entity == null)
                            throw new BusinessException(FengSharp.OneCardAccess.Infrastructure.ResourceMessages.ObjectCannotFind);
                        Infrastructure.EntityTool.CopyCreateAndModify(entity);
                        RoleWithCreateAndModify bindentity = new RoleWithCreateAndModify();
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
                        RoleEntity entity = this._Service.FindRoleById(this.Actual.EntityId);
                        if (entity == null)
                            throw new BusinessException(Infrastructure.ResourceMessages.ObjectCannotFind);
                        RoleWithCreateAndModify bindentity = new RoleWithCreateAndModify();
                        FengSharp.Tool.Reflect.ClassValueCopier.Copy(bindentity, entity);
                        bindentity.CreateName = ServiceLoader.LoadService<Interface.IClientUserSerice>().FindUserByIdFromCache(bindentity.CreateId).UserName;
                        bindentity.LastModifyName = ServiceLoader.LoadService<Interface.IClientUserSerice>().FindUserByIdFromCache(bindentity.LastModifyId).UserName;
                        this.Actual.SetData(bindentity);
                        #endregion
                    }
                    break;
                case ViewType.Kind:
                case ViewType.AddChild:
                default:
                    throw new BusinessException(Infrastructure.ResourceMessages.ErrorType);
            }

        }

        public string CreateRole(RoleEntity entity)
        {
            string roleid = this._Service.CreateRole(entity);
            if (string.IsNullOrWhiteSpace(roleid))
            {
                throw new BusinessException(FengSharp.OneCardAccess.Infrastructure.ResourceMessages.AddFailure);
            }
            return roleid;
        }

        public void UpdateRole(RoleEntity entity)
        {
            this._Service.UpdateRole(entity);
        }
    }
}
