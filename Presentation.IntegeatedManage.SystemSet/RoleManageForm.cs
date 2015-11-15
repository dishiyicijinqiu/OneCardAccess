using FengSharp.OneCardAccess.Domain.RBACModule.Entity;
using FengSharp.OneCardAccess.Domain.RBACModule.Service.Interface;
using FengSharp.OneCardAccess.Infrastructure;
using FengSharp.OneCardAccess.Infrastructure.Base;
using FengSharp.OneCardAccess.Infrastructure.Events;
using FengSharp.OneCardAccess.Infrastructure.Exceptions;
using FengSharp.OneCardAccess.Infrastructure.WinForm.Base;
using FengSharp.OneCardAccess.Infrastructure.WinForm.Controls;
using System;
using System.Windows.Forms;
namespace FengSharp.OneCardAccess.Presentation.IntegeatedManage.SystemSet
{
    public partial class RoleManageForm : RoleManageForm_Design
    {
        BindingSource bindingSource = new BindingSource();
        bool loadError = false;
        public RoleManageForm()
        {
            InitializeComponent();
        }

        private void RoleManage_Load(object sender, System.EventArgs e)
        {
            try
            {
                if (!ServiceProxyFactory.Create<IAccessService>().IsSuper())
                    throw new BusinessException("只要超级管理员才可操作");
                this.Facade = new RoleManageFormFacade(this);
                this.Facade.BindData();
            }
            catch (Exception ex)
            {
                this.formLoadErrorExit1.LoadError();
                MessageBoxEx.Error(ex);
            }
        }
        public void Bind(RoleEntity[] bindentitys)
        {
            this.Invoke(new Action(() =>
            {
                this.treeList1.BeginUnboundLoad();
                bindingSource.DataSource = bindentitys;
                this.treeList1.DataSource = bindingSource;
                this.treeList1.EndUnboundLoad();
                this.treeList1.ExpandAll();
            }));
        }

        public void Delete()
        {
            this.Facade.DeleteRole(this.currentBindRole);
        }

        public void Add()
        {
            var form = new RoleEditForm(ViewType.Add);
            form.AfterEdit += form_AfterEdit;
            form.ShowDialog();
        }

        void form_AfterEdit(CEventArgs<ViewType, string> e)
        {
            try
            {
                this.Facade.BindData();
            }
            catch (Exception ex)
            {
                MessageBoxEx.Error(ex);
            }
        }

        public void CopyAdd()
        {
            if (currentBindRole == null)
            {
                MessageBoxEx.Info(FengSharp.OneCardAccess.Infrastructure.ResourceMessages.List_AtLeastOne);
                return;
            }
            var form = new RoleEditForm(ViewType.CopyAdd, currentBindRole.RoleId);
            form.AfterEdit += form_AfterEdit;
            form.ShowDialog();
        }

        public void Edit()
        {
            if (currentBindRole == null)
            {
                MessageBoxEx.Info(FengSharp.OneCardAccess.Infrastructure.ResourceMessages.List_AtLeastOne);
                return;
            }
            var form = new RoleEditForm(ViewType.Edit, currentBindRole.RoleId);
            form.AfterEdit += form_AfterEdit;
            form.ShowDialog();
        }

        public void View()
        {
            if (currentBindRole == null)
            {
                MessageBoxEx.Info(FengSharp.OneCardAccess.Infrastructure.ResourceMessages.List_AtLeastOne);
                return;
            }
            var form = new RoleEditForm(ViewType.ReadOnly, currentBindRole.RoleId);
            form.ShowDialog();
        }

        public void UnLockRole(RoleEntity role)
        {
            if (role == null)
            {
                MessageBoxEx.Info(FengSharp.OneCardAccess.Infrastructure.ResourceMessages.ObjCanNotEmpty);
                return;
            }
            if (role.IsSuper)
            {
                MessageBoxEx.Info(FengSharp.OneCardAccess.Presentation.IntegeatedManage.SystemSet.ResourceMessages.SuperCanNotOP);
                return;
            }
            if (!role.IsLock)
            {
                MessageBoxEx.Info(FengSharp.OneCardAccess.Presentation.IntegeatedManage.SystemSet.ResourceMessages.RoleIsDisable);
                return;
            }
            this.Facade.UnLockRole(role.RoleId);
        }
        public void LockRole(RoleEntity role)
        {
            if (role == null)
            {
                MessageBoxEx.Info(FengSharp.OneCardAccess.Infrastructure.ResourceMessages.ObjCanNotEmpty);
                return;
            }
            if (role.IsSuper)
            {
                MessageBoxEx.Info(FengSharp.OneCardAccess.Presentation.IntegeatedManage.SystemSet.ResourceMessages.SuperCanNotOP);
                return;
            }
            if (role.IsLock)
            {
                MessageBoxEx.Info(FengSharp.OneCardAccess.Presentation.IntegeatedManage.SystemSet.ResourceMessages.RoleIsEnable);
                return;
            }
            this.Facade.LockRole(role.RoleId);
        }

        private RoleEntity currentBindRole;
        public RoleEntity CurrentBindRole
        {
            get
            {
                return currentBindRole;
            }
            set
            {
                if (this.DesignMode)
                    return;
                this.roleUserControl1.CurrentBindEntity = value;
                this.roleMenuControl1.CurrentBindEntity = value;
                this.roleActionControl1.CurrentBindEntity = value;
                this.roleStockControl1.CurrentBindEntity = value;
                this.roleProductControl1.CurrentBindEntity = value;
                this.roleCompanyControl1.CurrentBindEntity = value;
                this.roleRawMateControl1.CurrentBindEntity = value;
                this.lblCurrentRole.Text = string.Empty;
                if (value == null)
                {
                    this.btnSetLockEnable.Enabled = this.btnAdd.Enabled = this.btnCopyAdd.Enabled = this.btnEditView.Enabled = this.btnDelete.Enabled = false;
                }
                else
                {
                    this.btnSetLockEnable.Enabled = this.btnCopyAdd.Enabled = this.btnEditView.Enabled = this.btnDelete.Enabled = this.btnAdd.Enabled = true;
                    this.btnEditView.Text = FengSharp.OneCardAccess.Infrastructure.WinForm.ResourceMessages.btnEdit;
                    Entity_PropertyChange<RoleEntity>(value, "IsLock", value.IsLock);
                    if (value.IsSuper)
                    {
                        this.btnSetLockEnable.Enabled = false;
                        this.btnDelete.Enabled = false;
                        this.btnCopyAdd.Enabled = false;
                        this.btnEditView.Text = FengSharp.OneCardAccess.Infrastructure.WinForm.ResourceMessages.btnView;
                    }
                    this.lblCurrentRole.Text = value.RoleName;
                }
                currentBindRole = value;
            }
        }

        void Entity_PropertyChange<E>(E Entity, string propertyName, object value)
        {
            if (propertyName == "IsLock")
            {
                var p = Entity.GetType().GetProperty(propertyName);
                p.SetValue(Entity, value, null);
                this.btnSetLockEnable.Text = (bool)value ?
                          FengSharp.OneCardAccess.Presentation.IntegeatedManage.SystemSet.ResourceMessages.EnableRole :
                          FengSharp.OneCardAccess.Presentation.IntegeatedManage.SystemSet.ResourceMessages.DisableRole;
            }
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                this.Add();
            }
            catch (Exception ex)
            {
                MessageBoxEx.Error(ex.Message);
            }
        }

        private void btnCopyAdd_Click(object sender, EventArgs e)
        {
            try
            {
                this.CopyAdd();
            }
            catch (Exception ex)
            {
                MessageBoxEx.Error(ex.Message);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (currentBindRole == null)
                {
                    MessageBoxEx.Info(FengSharp.OneCardAccess.Infrastructure.ResourceMessages.List_AtLeastOne);
                    return;
                }
                if (currentBindRole.IsSuper)
                {
                    MessageBoxEx.Info(FengSharp.OneCardAccess.Infrastructure.ResourceMessages.CanNotDelete);
                    return;
                }
                var diaresult = MessageBoxEx.YesNoInfo(FengSharp.OneCardAccess.Infrastructure.ResourceMessages.DeleteConfirm);
                if (diaresult == System.Windows.Forms.DialogResult.Yes)
                {
                    this.Delete();
                    MessageBoxEx.Info(FengSharp.OneCardAccess.Infrastructure.ResourceMessages.OPSuccess);
                    this.Facade.BindData();
                }
            }
            catch (Exception ex)
            {
                MessageBoxEx.Error(ex);
            }
        }

        private void btnEditView_Click(object sender, EventArgs e)
        {
            try
            {
                if (currentBindRole == null)
                {
                    MessageBoxEx.Info(FengSharp.OneCardAccess.Infrastructure.ResourceMessages.List_AtLeastOne);
                    return;
                }
                if (currentBindRole.IsSuper)
                {
                    this.View();
                }
                else
                    this.Edit();
            }
            catch (Exception ex)
            {
                MessageBoxEx.Error(ex);
            }
        }

        private void btnSetLockEnable_Click(object sender, EventArgs e)
        {
            try
            {
                if (currentBindRole == null)
                {
                    MessageBoxEx.Info(FengSharp.OneCardAccess.Infrastructure.ResourceMessages.List_AtLeastOne);
                    return;
                }
                if (currentBindRole.IsSuper)
                {
                    MessageBoxEx.Info(FengSharp.OneCardAccess.Presentation.IntegeatedManage.SystemSet.ResourceMessages.SuperCanNotOP);
                    return;
                }
                string content = currentBindRole.IsLock ? "确实要禁用当前角色吗？" : "确实要启用当前角色吗？";
                if (MessageBoxEx.YesNoInfo(content) != System.Windows.Forms.DialogResult.Yes)
                    return;
                if (currentBindRole.IsLock)
                    this.UnLockRole(currentBindRole);
                else
                    this.LockRole(currentBindRole);
                Entity_PropertyChange<RoleEntity>(currentBindRole, "IsLock", !currentBindRole.IsLock);
                MessageBoxEx.Info(FengSharp.OneCardAccess.Infrastructure.ResourceMessages.OPSuccess);
            }
            catch (Exception ex)
            {
                MessageBoxEx.Error(ex);
            }
        }

        private void treeList1_CustomDrawNodeImages(object sender, DevExpress.XtraTreeList.CustomDrawNodeImagesEventArgs e)
        {
            e.SelectImageIndex = e.Node.ParentNode == null ? 0 : 1;
        }

        private void treeList1_FocusedNodeChanged(object sender, DevExpress.XtraTreeList.FocusedNodeChangedEventArgs e)
        {
            try
            {
                CurrentBindRole = this.treeList1.GetDataRecordByNode(e.Node) as RoleEntity;
            }
            catch (Exception ex)
            {
                MessageBoxEx.Error(ex);
            }
        }

        private void RoleManageForm_Shown(object sender, EventArgs e)
        {
            if (this.loadError)
                this.Close();
        }

        private void treeList1_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (currentBindRole == null)
                {
                    MessageBoxEx.Info(FengSharp.OneCardAccess.Infrastructure.ResourceMessages.List_AtLeastOne);
                    return;
                }
                if (currentBindRole.IsSuper)
                {
                    this.View();
                }
                else
                {
                    this.Edit();
                }
            }
            catch (Exception ex)
            {
                MessageBoxEx.Error(ex);
            }
        }

        private void xtraTabControl1_SelectedPageChanged(object sender, DevExpress.XtraTab.TabPageChangedEventArgs e)
        {
            //IsPageIndexShow
            //if (this.xtraTabControl1.SelectedTabPageIndex == 0)
            //{
            //    this.userRoleControl1.CurrentBindEntity = this.currentBindRole;
            //}
            //else if (this.xtraTabControl1.SelectedTabPageIndex == 1)
            //{
            //    this.roleMenuControl1.CurrentBindEntity = this.currentBindRole;
            //}
            //else if (this.xtraTabControl1.SelectedTabPageIndex == 2)
            //{
            //    this.roleActionControl1.CurrentBindEntity = this.currentBindRole;
            //}
        }

        private void xtraTabControl1_SelectedPageChanging(object sender, DevExpress.XtraTab.TabPageChangingEventArgs e)
        {
            //IsPageIndexShow
            //if (this.xtraTabControl1.SelectedTabPageIndex == 0)
            //{
            //    //this.roleUserControl1.CurrentBindEntity = this.currentBindRole;
            //}
            //else if (this.xtraTabControl1.SelectedTabPageIndex == 1)
            //{
            //    //this.roleMenuControl1.CurrentBindEntity = this.currentBindRole;
            //}
            //else if (this.xtraTabControl1.SelectedTabPageIndex == 2)
            //{
            //    //this.roleActionControl1.CurrentBindEntity = this.currentBindRole;
            //}
            if (e.PrevPage == this.xtraTabPage5)
            {
                this.roleProductControl1.IsPageIndexChanging = true;
            }
            if (e.PrevPage == this.xtraTabPage6)
            {
                this.roleCompanyControl1.IsPageIndexChanging = true;
            }
            if (e.PrevPage == this.xtraTabPage7)
            {
                this.roleRawMateControl1.IsPageIndexChanging = true;
            }
        }
    }
    public partial class RoleManageForm_Design : Base_Form<RoleManageFormFacade>
    {
    }
    public class RoleManageFormFacade : ActualBase<RoleManageForm>
    {
        private IRoleService _RoleService = ServiceProxyFactory.Create<IRoleService>();
        private IAccessService _AccessService = ServiceProxyFactory.Create<IAccessService>();
        public RoleManageFormFacade(RoleManageForm actual)
            : base(actual) { }

        public void BindData()
        {
            var roles = this._RoleService.GetAllRole();
            if (roles == null)
                roles = new RoleEntity[0];
            //var bindRoles = new RoleEntity[roles.Length + 1];
            //bindRoles[0] = new RoleEntity()
            //{
            //    RoleId = Guid.NewGuid().ToString(),
            //    ParentRoleId = string.Empty,
            //    RoleName = "角色列表",
            //    RoleNo = "角色编号",
            //    IsData = false,
            //};
            //for (int i = 1; i < roles.Length + 1; i++)
            //{
            //    bindRoles[i] = RoleEntity.RoleToBindRole(roles[i - 1]);
            //    bindRoles[i].ParentRoleId = bindRoles[0].RoleId;
            //    bindRoles[i].IsData = true;
            //}
            this.Actual.Bind(roles);
        }

        public void UnLockRole(string roleid)
        {
            _AccessService.UnLockRole(roleid);
        }

        public void LockRole(string roleid)
        {
            _AccessService.LockRole(roleid);
        }

        public void DeleteRole(RoleEntity bindRole)
        {
            _RoleService.DeleteRole(bindRole.RoleId);
        }
    }
}