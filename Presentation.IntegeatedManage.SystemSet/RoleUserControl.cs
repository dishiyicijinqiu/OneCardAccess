using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Linq;
using FengSharp.OneCardAccess.Domain.RBACModule.Entity;
using FengSharp.OneCardAccess.Infrastructure.WinForm.Base;
using FengSharp.OneCardAccess.Infrastructure.Base;
using FengSharp.OneCardAccess.Domain.RBACModule.Service.Interface;
using FengSharp.OneCardAccess.Infrastructure;
using FengSharp.OneCardAccess.Infrastructure.WinForm.Controls;
using FengSharp.OneCardAccess.Infrastructure.Events;
using FengSharp.OneCardAccess.Presentation.IntegeatedManage.SystemSet.Interface;

namespace FengSharp.OneCardAccess.Presentation.IntegeatedManage.SystemSet
{
    public partial class RoleUserControl : RoleUserControl_Design
    {
        private string lastbindroleid;
        public RoleUserControl()
        {
            InitializeComponent();
            this.VisibleChanged += RoleUserControl_VisibleChanged;
        }

        void RoleUserControl_VisibleChanged(object sender, EventArgs e)
        {
            this.ResetRoleEntity(this.currentbindentity);
        }

        private RoleEntity currentbindentity;
        public RoleEntity CurrentBindEntity
        {
            get
            {
                return currentbindentity;
            }
            set
            {
                if (this.DesignMode)
                    return;
                if (this.Visible)
                {
                    ResetRoleEntity(value);
                }
                currentbindentity = value;
            }
        }

        private void UserRoleControl_Load(object sender, EventArgs e)
        {
            this.Facade = new RoleUserControlFacade(this);
        }
        private void ResetRoleEntity(RoleEntity roleentity)
        {
            if (roleentity == null)
            {
                this.btnDelete.Enabled = this.btnAdd.Enabled = false;
            }
            else
            {
                this.btnDelete.Enabled = this.btnAdd.Enabled = true;
            }
            if (this.Facade != null)
            {
                if (roleentity != null)
                {
                    if (lastbindroleid != roleentity.RoleId)
                    {
                        this.Facade.BindData(roleentity);
                    }
                }
                else
                {
                    if (lastbindroleid != null)
                    {
                        this.Facade.BindData(roleentity);
                    }
                }
            }
            if (roleentity != null)
            {
                lastbindroleid = roleentity.RoleId;
            }
            else
            {
                lastbindroleid = null;
            }

        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (CurrentBindEntity == null)
                {
                    MessageBoxEx.Info(FengSharp.OneCardAccess.Infrastructure.ResourceMessages.ObjCanNotEmpty);
                    return;
                }
                IMultiUserSelect multiUserSelect = ServiceLoader.LoadService<IMultiUserSelect>("MultiUserSelectForm");
                multiUserSelect.BeforeBind += multiUserSelect_BeforeBind;
                var users = multiUserSelect.GetResults();
                if (!multiUserSelect.IsSelect)
                    return;
                if (users == null || users.Length <= 0)
                {
                    return;
                }
                this.Facade.AddUsersToRole(users, this.CurrentBindEntity);
                MessageBoxEx.Info(FengSharp.OneCardAccess.Infrastructure.ResourceMessages.OPSuccess);
                this.Facade.BindData(this.CurrentBindEntity);
            }
            catch (Exception ex)
            {
                MessageBoxEx.Error(ex);
            }
        }

        void multiUserSelect_BeforeBind(CEventArgs<UserEntity[]> e)
        {
            var users = this.gridControl1.DataSource as UserEntity[];
            if (users != null && users.Length > 0)
            {
                var results = new List<UserEntity>(e.Para1);
                foreach (var user in users)
                {
                    var selectuser = results.FirstOrDefault(t => t.UserId == user.UserId);
                    if (selectuser != null)
                        results.Remove(selectuser);
                }
                e.Para1 = results.ToArray();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                var rowhandles = this.gridView1.GetSelectedRows();
                if (rowhandles.Length <= 0)
                {
                    MessageBoxEx.Info(FengSharp.OneCardAccess.Infrastructure.ResourceMessages.List_AtLeastOne);
                    return;
                }
                var diaResult = MessageBoxEx.YesNoInfo(FengSharp.OneCardAccess.Infrastructure.ResourceMessages.DeleteConfirm);
                if (diaResult != DialogResult.Yes)
                    return;
                UserEntity[] users = new UserEntity[rowhandles.Length];
                for (int i = 0; i < rowhandles.Length; i++)
                {
                    users[i] = this.gridView1.GetRow(rowhandles[i]) as UserEntity;
                }
                this.Facade.RemoveUsersFromRole(users, CurrentBindEntity);
                MessageBoxEx.Info(FengSharp.OneCardAccess.Infrastructure.ResourceMessages.OPSuccess);
                this.Facade.BindData(this.CurrentBindEntity);
            }
            catch (Exception ex)
            {
                MessageBoxEx.Error(ex);
            }
        }

        public void Bind(UserEntity[] users)
        {
            this.gridControl1.DataSource = users;
        }
    }


    public partial class RoleUserControl_Design : Base_UserControl<RoleUserControlFacade>
    {
    }
    public class RoleUserControlFacade : ActualBase<RoleUserControl>
    {
        IAccessService _AccessService = ServiceProxyFactory.Create<IAccessService>();
        public RoleUserControlFacade(RoleUserControl actual)
            : base(actual)
        { }
        public void BindData(RoleEntity bindentity)
        {
            if (bindentity == null)
            {
                this.Actual.Bind(new UserEntity[0]);
                return;
            }
            var users = ServiceProxyFactory.Create<IRoleService>().GetRoleUsers(bindentity.RoleId);
            this.Actual.Bind(users);
        }

        internal void AddUsersToRole(UserEntity[] users, RoleEntity roleWithTree)
        {
            _AccessService.AddUsersToRole(users.Select(t => t.UserId).ToArray(), roleWithTree.RoleId);
        }

        public void RemoveUsersFromRole(UserEntity[] users, RoleEntity CurrentBindRole)
        {
            _AccessService.RemoveUsersFromRole(users.Select(t => t.UserId).ToArray(), CurrentBindRole.RoleId);
        }
    }
}
