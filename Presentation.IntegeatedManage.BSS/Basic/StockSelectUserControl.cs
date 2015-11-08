using FengSharp.OneCardAccess.Domain.BSSModule.Entity;
using FengSharp.OneCardAccess.Domain.BSSModule.Service.Interface;
using FengSharp.OneCardAccess.Infrastructure;
using FengSharp.OneCardAccess.Infrastructure.Base;
using FengSharp.OneCardAccess.Infrastructure.Events;
using FengSharp.OneCardAccess.Infrastructure.WinForm.Base;
using FengSharp.OneCardAccess.Infrastructure.WinForm.Controls;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FengSharp.OneCardAccess.Presentation.IntegeatedManage.BSS
{
    public partial class StockSelectUserControl : StockSelectUserControl_Design
    {
        public event VEventHandler<CEventArgs<StockCMEntity[]>> BeforeBind;
        public event VEventHandler<EventArgs> OKClick;
        public event VEventHandler<EventArgs> CancelClick;
        private bool isMulSelect = false;
        public StockSelectUserControl()
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

        private void StockSelectUserControl_Load(object sender, EventArgs e)
        {
            if (this.DesignMode)
                return;
            if (System.Diagnostics.Process.GetCurrentProcess().ProcessName == "devenv")
                return;
            EntityResult = null;
            EntityResults = null;
            this.gridView1.OptionsSelection.MultiSelect = this.isMulSelect;
            this.Facade = new StockSelectUserControlFacade(this);
            this.Facade.BindData();
        }

        public StockCMEntity EntityResult { get; private set; }

        public StockCMEntity[] EntityResults { get; private set; }

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

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (this.gridView1.FocusedRowHandle < 0)
            {
                MessageBoxEx.Info(FengSharp.OneCardAccess.Infrastructure.ResourceMessages.List_AtLeastOne);
                return;
            }
            if (this.gridView1.FocusedRowHandle >= 0)
            {
                EntityResult = this.gridView1.GetRow(this.gridView1.FocusedRowHandle) as StockCMEntity;
                EntityResults = this.gridView1.GetSelectedRows().Select(
                    t => this.gridView1.GetRow(t) as StockCMEntity
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

        internal void Bind(StockCMEntity[] entitys)
        {
            if (BeforeBind != null)
            {
                var args = new CEventArgs<StockCMEntity[]>(entitys);
                this.BeforeBind(args);
                entitys = args.Para1;
            }
            this.bindingSource1.DataSource = new List<StockCMEntity>(entitys);
            this.gridControl1.DataSource = this.bindingSource1;
        }
    }

    public class StockSelectUserControl_Design : Base_UserControl<StockSelectUserControlFacade>
    {

    }
    public class StockSelectUserControlFacade : ActualBase<StockSelectUserControl>
    {
        private IStockService _StockService = ServiceProxyFactory.Create<IStockService>();
        public StockSelectUserControlFacade(StockSelectUserControl actual)
            : base(actual) { }

        internal void BindData()
        {
            StockCMEntity[] entitys = this._StockService.GetStockCMList();
            if (entitys == null)
                entitys = new StockCMEntity[0];
            this.Actual.Bind(entitys);
        }
    }
}
