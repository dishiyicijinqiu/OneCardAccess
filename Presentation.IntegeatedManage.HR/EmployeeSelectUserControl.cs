using DevExpress.XtraGrid.Views.Grid;
using FengSharp.OneCardAccess.Domain.HRModule.Entity;
using FengSharp.OneCardAccess.Domain.HRModule.Service.Interface;
using FengSharp.OneCardAccess.Infrastructure;
using FengSharp.OneCardAccess.Infrastructure.Base;
using FengSharp.OneCardAccess.Infrastructure.Events;
using FengSharp.OneCardAccess.Infrastructure.WinForm.Base;
using FengSharp.OneCardAccess.Infrastructure.WinForm.Controls;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FengSharp.OneCardAccess.Presentation.IntegeatedManage.HR
{
    public partial class EmployeeSelectUserControl : EmployeeSelectUserControl_Design
    {
        public event VEventHandler<CEventArgs<EmployeeCMDeptEntity[]>> BeforeBind;
        public event VEventHandler<EventArgs> OKClick;
        public event VEventHandler<EventArgs> CancelClick;
        private bool isMulSelect = false;
        public EmployeeSelectUserControl()
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

        private void EmployeeSelectUserControl_Load(object sender, EventArgs e)
        {
            if (this.DesignMode)
                return;
            if (System.Diagnostics.Process.GetCurrentProcess().ProcessName == "devenv")
                return;
            EntityResult = null;
            EntityResults = null;
            this.gridView1.OptionsSelection.MultiSelect = this.isMulSelect;
            this.Facade = new EmployeeSelectUserControlFacade(this);
            this.Facade.BindData();
        }

        public EmployeeCMDeptEntity EntityResult { get; private set; }

        public EmployeeCMDeptEntity[] EntityResults { get; private set; }

        private void gridView1_RowClick(object sender, RowClickEventArgs e)
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
        private void btnOK_Click(object sender, EventArgs e)
        {
            if (this.gridView1.FocusedRowHandle < 0)
            {
                MessageBoxEx.Info(FengSharp.OneCardAccess.Infrastructure.ResourceMessages.List_AtLeastOne);
                return;
            }
            if (this.gridView1.FocusedRowHandle >= 0)
            {
                EntityResult = this.gridView1.GetRow(this.gridView1.FocusedRowHandle) as EmployeeCMDeptEntity;
                EntityResults = this.gridView1.GetSelectedRows().Select(
                    t => this.gridView1.GetRow(t) as EmployeeCMDeptEntity
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

        internal void Bind(EmployeeCMDeptEntity[] entitys)
        {
            if (BeforeBind != null)
            {
                var args = new CEventArgs<EmployeeCMDeptEntity[]>(entitys);
                this.BeforeBind(args);
                entitys = args.Para1;
            }
            this.bindingSource1.DataSource = new List<EmployeeCMDeptEntity>(entitys);
            this.gridControl1.DataSource = this.bindingSource1;
        }

    }
    public class EmployeeSelectUserControl_Design : Base_UserControl<EmployeeSelectUserControlFacade>
    {

    }
    public class EmployeeSelectUserControlFacade : ActualBase<EmployeeSelectUserControl>
    {
        private IEmployeeService _EmployeeService = ServiceProxyFactory.Create<IEmployeeService>();
        public EmployeeSelectUserControlFacade(EmployeeSelectUserControl actual)
            : base(actual) { }

        internal void BindData()
        {
            EmployeeCMDeptEntity[] entitys = this._EmployeeService.GetAllCMDeptEmployee();
            if (entitys == null)
                entitys = new EmployeeCMDeptEntity[0];
            this.Actual.Bind(entitys);
        }
    }
}
