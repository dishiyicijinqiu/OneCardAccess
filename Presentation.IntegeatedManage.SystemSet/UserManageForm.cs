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
using System.Linq;
using System.Windows.Forms;

namespace FengSharp.OneCardAccess.Presentation.IntegeatedManage.SystemSet
{
    public partial class UserManageForm : UserManageForm_Design
    {
        BindingSource bindingSource = new BindingSource();
        public UserManageForm()
        {
            InitializeComponent();
        }

        private void UserManageForm_Load(object sender, System.EventArgs e)
        {
            try
            {
                AuthPrincipal authprincipal = System.Threading.Thread.CurrentPrincipal as AuthPrincipal;
                if (!ServiceProxyFactory.Create<IAccessService>().IsSuper(authprincipal.Ticket))
                    throw new BusinessException("只要超级管理员才可操作");
                this.Facade = new UserManageFormFacade(this);
                this.Facade.BindData();
            }
            catch (Exception ex)
            {
                this.formLoadErrorExit1.LoadError();
                MessageBoxEx.Error(ex);
            }
        }
        public void Bind(UserWithCreateAndModify[] entitys)
        {
            bindingSource.DataSource = new System.Collections.Generic.List<UserWithCreateAndModify>(entitys);
            this.gridControl1.DataSource = bindingSource;
        }
        void form_AfterEdit(CEventArgs<ViewType, string> e)
        {
            try
            {
                switch (e.Para1)
                {
                    default:
                    case ViewType.Edit:
                        {
                            UserWithCreateAndModify bindEntity = this.Facade.FindBindEntityById(e.Para2);
                            var row = this.gridView1.GetRow(this.gridView1.FocusedRowHandle);
                            FengSharp.Tool.Reflect.ClassValueCopier.Copy(row, bindEntity);
                            this.gridView1.RefreshRow(this.gridView1.FocusedRowHandle);
                        }
                        break;
                    case ViewType.Add:
                    case ViewType.CopyAdd:
                        {
                            UserWithCreateAndModify bindEntity = this.Facade.FindBindEntityById(e.Para2);
                            int dataindex = bindingSource.Add(bindEntity);
                            this.gridView1.RefreshRow(this.gridView1.GetRowHandle(dataindex));
                        }
                        break;
                    case ViewType.Kind:
                        break;
                    case ViewType.ReadOnly:
                        break;
                    case ViewType.AddChild:
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBoxEx.Error(ex);
            }
        }
        public void View()
        {
        }

        public void UnLockUser(UserEntity bindentity)
        {
            this.Facade.UnLockUser(bindentity.UserId);
        }

        public void LockUser(UserEntity bindentity)
        {
            this.Facade.LockUser(bindentity.UserId);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                var form = new UserEditForm(ViewType.Add);
                form.AfterEdit += form_AfterEdit;
                form.ShowDialog();
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
                if (this.gridView1.FocusedRowHandle < 0)
                {
                    MessageBoxEx.Info(FengSharp.OneCardAccess.Infrastructure.ResourceMessages.List_AtLeastOne);
                    return;
                }
                var entity = this.gridView1.GetRow(this.gridView1.FocusedRowHandle) as UserEntity;
                var form = new UserEditForm(ViewType.CopyAdd, entity.UserId);
                form.AfterEdit += form_AfterEdit;
                form.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBoxEx.Error(ex.Message);
            }
        }

        private void btnEditView_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.gridView1.FocusedRowHandle < 0)
                {
                    MessageBoxEx.Info(FengSharp.OneCardAccess.Infrastructure.ResourceMessages.List_AtLeastOne);
                    return;
                }
                var entity = this.gridView1.GetRow(this.gridView1.FocusedRowHandle) as UserEntity;
                var form = new UserEditForm(ViewType.Edit, entity.UserId);
                form.AfterEdit += form_AfterEdit;
                form.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBoxEx.Error(ex);
            }
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            try
            {
                var entitys = this.gridView1.GetSelectedRows().Select
            (
                t => this.gridView1.GetRow(t) as UserWithCreateAndModify
            ).ToArray();
                if (entitys.Length <= 0)
                {
                    MessageBoxEx.Info(FengSharp.OneCardAccess.Infrastructure.ResourceMessages.List_AtLeastOne);
                    return;
                }
                var diaResult = MessageBoxEx.YesNoInfo(FengSharp.OneCardAccess.Infrastructure.ResourceMessages.DeleteConfirm);
                if (diaResult != System.Windows.Forms.DialogResult.Yes)
                    return;
                this.Facade.DeleteUsers(entitys);
                MessageBoxEx.Info(FengSharp.OneCardAccess.Infrastructure.ResourceMessages.DeleteSuccess);
                this.bindingSource.RemoveEntityIfDataSourceIsList<UserWithCreateAndModify>(entitys.ToList());
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

        private void gridView1_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            try
            {
                if (e.Clicks != 2 || e.RowHandle < 0)
                    return;
                if (btnEditView.Enabled)
                    btnEditView_Click(btnEditView, null);
            }
            catch (Exception ex)
            {
                MessageBoxEx.Error(ex);
            }
        }


    }
    public partial class UserManageForm_Design : Base_Form<UserManageFormFacade>
    {
    }
    public class UserManageFormFacade : ActualBase<UserManageForm>
    {
        private IUserService _Service = ServiceProxyFactory.Create<IUserService>();
        public UserManageFormFacade(UserManageForm actual)
            : base(actual)
        { }

        public void BindData()
        {
            var entitys = this._Service.GetAllUserWithCreateAndModify();
            if (entitys == null)
                entitys = new UserWithCreateAndModify[0];
            this.Actual.Bind(entitys);
        }
        public void UnLockUser(string userid)
        {
            ServiceProxyFactory.Create<IAccessService>().UnLockUser(userid);
        }

        public void LockUser(string userid)
        {
            ServiceProxyFactory.Create<IAccessService>().LockUser(userid);
        }

        public void DeleteUsers(UserWithCreateAndModify[] entitys)
        {
            this._Service.DeleteUsers(entitys.Select(t => t.UserId).ToArray());
        }

        public UserWithCreateAndModify FindBindEntityById(string userid)
        {
            UserEntity entity = _Service.FindUserById(userid);
            UserWithCreateAndModify bindentity = new UserWithCreateAndModify();
            FengSharp.Tool.Reflect.ClassValueCopier.Copy(bindentity, entity);
            bindentity.CreateName = _Service.FindUserById(bindentity.CreateId).UserName;
            bindentity.LastModifyName = _Service.FindUserById(bindentity.LastModifyId).UserName;
            return bindentity;
        }
    }
}
