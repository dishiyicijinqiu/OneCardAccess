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
namespace FengSharp.OneCardAccess.Presentation.IntegeatedManage.SystemSet
{
    public partial class RoleEditForm : RoleEditForm_Design
    {
        #region ctor
        public RoleEditForm()
            : this(ViewType.ReadOnly, string.Empty)
        {
        }
        public RoleEditForm(ViewType viewtype)
            : this(viewtype, string.Empty)
        {
        }
        public RoleEditForm(string id)
            : this(ViewType.ReadOnly, id)
        {
        }

        public RoleEditForm(ViewType viewtype, string id)
        {
            InitializeComponent();
            this.EntityId = id;
            this.ViewType = viewtype;
        }
        #endregion
        #region fileds
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
                this.layoutControl1.SetReadOnly(isreadonly);
                this.btnSave.Enabled = !isreadonly;
                this.chkIsAdmin.ReadOnly = true;
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
                    var entity = new RoleEntity();
                    entity.RoleId = EntityId;
                    entity.IsLock = !this.chkIsLock.Checked;
                    entity.Remark = this.txtRemark.Text;
                    entity.RoleName = this.txtRoleName.Text;
                    entity.RoleNo = this.txtRoleNo.Text;
                    entity.CreateId = this.cmControl.CreateUserId;
                    entity.CreateDate = this.cmControl.CreateDate;
                    entity.LastModifyId = this.cmControl.CurrentUserId;
                    entity.LastModifyDate = this.cmControl.CurrentDateTime;
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
            this.txtRoleNo.Text = bindentity.RoleNo;
            this.txtRoleName.Text = bindentity.RoleName;
            this.txtRemark.Text = bindentity.Remark;
            this.cmControl.SetData(bindentity.CreateId,
                bindentity.CreateName,
                bindentity.CreateDate,
                bindentity.LastModifyId,
                bindentity.LastModifyName,
                bindentity.LastModifyDate);
            this.chkIsAdmin.Checked = bindentity.IsSuper;
            this.chkIsLock.Checked = !bindentity.IsLock;
        }
        private void OnAfterEdit()
        {
            if (AfterEdit != null) this.AfterEdit(new CEventArgs<ViewType, string>(this.viewtype, this.EntityId));
        }
        public event VEventHandler<CEventArgs<ViewType, string>> AfterEdit;
        private void chkIsLock_CheckedChanged(object sender, EventArgs e)
        {
            this.chkIsLock.Text = this.chkIsLock.Checked ? "启用" : "禁用";
        }
        private void chkIsAdmin_CheckedChanged(object sender, EventArgs e)
        {
            this.chkIsAdmin.Text = this.chkIsAdmin.Checked ? "是" : "否";
        }

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
            //RoleEntity entity = null;
            //if (this.Actual.ViewType == ViewType.Add)
            //    entity = new RoleEntity();
            //else
            //    entity = this._Service.FindRoleById(this.Actual.EntityId);
            //switch (this.Actual.ViewType)
            //{
            //    case ViewType.Add:
            //    case ViewType.CopyAdd:
            //        AuthIdentity authidentity = (System.Threading.Thread.CurrentPrincipal as AuthPrincipal).Identity as AuthIdentity;
            //        entity.CreateId = authidentity.UserId;
            //        entity.CreateDate = DateTime.Now;
            //        entity.LastModifyDate = DateTime.Now;
            //        entity.LastModifyId = authidentity.UserId;
            //        break;
            //}
            //RoleWithCreateAndModify bindentity = new RoleWithCreateAndModify();
            //FengSharp.Tool.Reflect.ClassValueCopier.Copy(bindentity, entity);
            //bindentity.CreateName = ServiceProxyFactory.Create<IUserService>().FindUserById(bindentity.CreateId).UserName;
            //bindentity.LastModifyName = ServiceProxyFactory.Create<IUserService>().FindUserById(bindentity.LastModifyId).UserName;
            //this.Actual.SetData(bindentity);


            switch (this.Actual.ViewType)
            {
                case ViewType.Add:
                    {
                        #region Add
                        RoleEntity entity = new RoleEntity();
                        Infrastructure.EntityTool.CopyCreateAndModify(entity);
                        RoleWithCreateAndModify bindentity = new RoleWithCreateAndModify();
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
                        RoleEntity entity = this._Service.FindRoleById(this.Actual.EntityId);
                        if (entity == null)
                            throw new BusinessException(FengSharp.OneCardAccess.Infrastructure.ResourceMessages.ObjectCannotFind);
                        Infrastructure.EntityTool.CopyCreateAndModify(entity);
                        RoleWithCreateAndModify bindentity = new RoleWithCreateAndModify();
                        FengSharp.Tool.Reflect.ClassValueCopier.Copy(bindentity, entity);
                        bindentity.CreateName = ServiceProxyFactory.Create<IUserService>().FindUserById(bindentity.CreateId).UserName;
                        bindentity.LastModifyName = ServiceProxyFactory.Create<IUserService>().FindUserById(bindentity.LastModifyId).UserName;
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
                            throw new BusinessException(FengSharp.OneCardAccess.Infrastructure.ResourceMessages.ObjectCannotFind);
                        RoleWithCreateAndModify bindentity = new RoleWithCreateAndModify();
                        FengSharp.Tool.Reflect.ClassValueCopier.Copy(bindentity, entity);
                        bindentity.CreateName = ServiceProxyFactory.Create<IUserService>().FindUserById(bindentity.CreateId).UserName;
                        bindentity.LastModifyName = ServiceProxyFactory.Create<IUserService>().FindUserById(bindentity.LastModifyId).UserName;
                        this.Actual.SetData(bindentity);
                        #endregion
                    }
                    break;
                case ViewType.Kind:
                case ViewType.AddChild:
                default:
                    throw new BusinessException(FengSharp.OneCardAccess.Infrastructure.ResourceMessages.ErrorType);
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
