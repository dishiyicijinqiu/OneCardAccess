using FengSharp.OneCardAccess.Domain.RBACModule.Entity;
using FengSharp.OneCardAccess.Domain.RBACModule.Service.Interface;
using FengSharp.OneCardAccess.Infrastructure;
using FengSharp.OneCardAccess.Infrastructure.Base;
using FengSharp.OneCardAccess.Infrastructure.Events;
using FengSharp.OneCardAccess.Infrastructure.WinForm.Base;
using FengSharp.OneCardAccess.Infrastructure.WinForm.Controls;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FengSharp.OneCardAccess.Presentation.IntegeatedManage.SystemSet
{
    public partial class UserSelectUserControl : UserSelectUserControl_Design
    {
        public event VEventHandler<CEventArgs<UserEntity[]>> BeforeBind;
        public event VEventHandler<EventArgs> OKClick;
        public event VEventHandler<EventArgs> CancelClick;
        private bool isMulSelect = false;
        public UserSelectUserControl()
        {
            InitializeComponent();
        }
        public bool IsMulSelect
        {
            get
            {
                return isMulSelect;
            }
            internal set
            {
                isMulSelect = value;
            }
        }

        private void UserSelectUserControl_Load(object sender, EventArgs e)
        {
            if (this.DesignMode)
                return;
            if (System.Diagnostics.Process.GetCurrentProcess().ProcessName == "devenv")
                return;
            EntityResult = null;
            EntityResults = null;
            this.gridView1.OptionsSelection.MultiSelect = this.isMulSelect;
            this.Facade = new UserSelectUserControlFacade(this);
            this.Facade.BindData();
        }

        public UserEntity EntityResult { get; private set; }

        public UserEntity[] EntityResults { get; private set; }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (this.gridView1.FocusedRowHandle < 0)
            {
                MessageBoxEx.Info(FengSharp.OneCardAccess.Infrastructure.ResourceMessages.List_AtLeastOne);
                return;
            }
            if (this.gridView1.FocusedRowHandle >= 0)
            {
                EntityResult = this.gridView1.GetRow(this.gridView1.FocusedRowHandle) as UserEntity;
                EntityResults = this.gridView1.GetSelectedRows().Select(
                    t => this.gridView1.GetRow(t) as UserEntity
                    ).ToArray();
            }
            if (OKClick != null)
            {
                this.OKClick(new EventArgs());
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            EntityResult = null;
            EntityResults = null;
            if (CancelClick != null)
            {
                this.CancelClick(new EventArgs());
            }
        }

        private void gridView1_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            try
            {
                if (e.Clicks != 2 || this.gridView1.FocusedRowHandle < 0)
                    return;
                this.btnOK_Click(null, null);
            }
            catch (Exception ex)
            {
                MessageBoxEx.Error(ex);
            }
        }

        internal void Bind(UserEntity[] entitys)
        {
            if (BeforeBind != null)
            {
                var args = new CEventArgs<UserEntity[]>(entitys);
                this.BeforeBind(args);
                entitys = args.Para1;
            }
            this.bindingSource1.DataSource = new List<UserEntity>(entitys);
            this.gridControl1.DataSource = this.bindingSource1;
        }
    }
    public class UserSelectUserControl_Design : Base_UserControl<UserSelectUserControlFacade>
    {

    }
    public class UserSelectUserControlFacade : ActualBase<UserSelectUserControl>
    {
        private IUserService _UserService = ServiceProxyFactory.Create<IUserService>();
        public UserSelectUserControlFacade(UserSelectUserControl actual)
            : base(actual) { }

        internal void BindData()
        {
            UserEntity[] entitys = this._UserService.GetAllUser();
            if (entitys == null)
                entitys = new UserEntity[0];
            this.Actual.Bind(entitys);
        }
    }
}
