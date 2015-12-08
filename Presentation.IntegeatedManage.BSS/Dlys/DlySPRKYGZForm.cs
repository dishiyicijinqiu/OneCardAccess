using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using FengSharp.OneCardAccess.Domain.BSSModule.Entity;
using FengSharp.OneCardAccess.Domain.BSSModule.Service.Interface;
using FengSharp.OneCardAccess.Infrastructure;
using FengSharp.OneCardAccess.Infrastructure.Base;
using FengSharp.OneCardAccess.Infrastructure.Exceptions;
using FengSharp.OneCardAccess.Infrastructure.WinForm.Base;
using FengSharp.OneCardAccess.Infrastructure.WinForm.Controls;
using System;
using System.Linq;
using FengSharp.OneCardAccess.Infrastructure.WinForm;
using FengSharp.OneCardAccess.Presentation.IntegeatedManage.BSS.Interface;
using DevExpress.XtraEditors;

namespace FengSharp.OneCardAccess.Presentation.IntegeatedManage.BSS
{
    public partial class DlySPRKYGZForm : DlySPRKYGZForm_Design
    {
        public string NdxId { get; set; }
        public DlySPRKYGZForm(string ndxId)
        {
            InitializeComponent();
            NdxId = ndxId;
            if (!DesignMode)
            {
                var qtyFBNPopupContainerControl = ServiceLoader.LoadService<IProductFBNLook>("ProductFBNLook") as PopupContainerControl;
                qtyFBNPopupContainerControl.Width = 500;
                qtyFBNPopupContainerControl.Height = 600;
                qtyFBNRepItemPopupContainerEdit.PopupControl = qtyFBNPopupContainerControl;

                var qtySNPopupContainerControl = ServiceLoader.LoadService<IProductSNLook>("ProductSNLook") as PopupContainerControl;
                qtySNPopupContainerControl.Width = 500;
                qtySNPopupContainerControl.Height = 600;
                qtySNRepItemPopupContainerEdit.PopupControl = qtySNPopupContainerControl;
            }
            for (int i = 0; i < this.gridView1.Columns.Count; i++)
            {
                var col = this.gridView1.Columns[i];
                if (col == colProductNo)
                    continue;
                col.RealColumnEdit.EditValueChanging += RealColumnEdit_EditValueChanging;
            }
            this.gridControl1.DataSource = this.bindingSource1;
        }

        private void RealColumnEdit_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            try
            {
                if (this.gridView1.FocusedColumn == colProductNo) return;
                var row = this.gridView1.GetRow(this.gridView1.FocusedRowHandle) as PDlyBakFullNameEntity;
                if (row == null || row.ProductId <= 0)
                {
                    e.Cancel = true;
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBoxEx.Error(ex);
            }
        }

        private void DlySPRKYGZForm_Load(object sender, EventArgs e)
        {
            try
            {
                this.Facade = new DlySPRKYGZFormFacade(this);
                this.Facade.SetData();
            }
            catch (Exception ex)
            {
                MessageBoxEx.Error(ex);
                this.formLoadErrorExit1.LoadError();
            }
        }
        internal void SetData(SPRKDlyYGZNdxEntity entity)
        {
            this.bindbaseDataLayoutControl1.DataSource = entity;
            if (entity == null)
                this.bindingSource1.DataSource = typeof(PDlyFullNameEntity);
            else
                this.bindingSource1.DataSource = entity.PDlys;
            this.baseDataLayoutControl1.SetReadOnly(true);
            this.ItemForSHRName1.Visibility = string.IsNullOrWhiteSpace(entity.SHRId1) ? DevExpress.XtraLayout.Utils.LayoutVisibility.Never : DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
            this.ItemForSHRName2.Visibility = string.IsNullOrWhiteSpace(entity.SHRId2) ? DevExpress.XtraLayout.Utils.LayoutVisibility.Never : DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
            this.ItemForSHRName3.Visibility = string.IsNullOrWhiteSpace(entity.SHRId3) ? DevExpress.XtraLayout.Utils.LayoutVisibility.Never : DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
            this.ItemForSHRName4.Visibility = string.IsNullOrWhiteSpace(entity.SHRId4) ? DevExpress.XtraLayout.Utils.LayoutVisibility.Never : DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
            this.ItemForSHRName5.Visibility = string.IsNullOrWhiteSpace(entity.SHRId5) ? DevExpress.XtraLayout.Utils.LayoutVisibility.Never : DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
        }
        public void SummaryChange()
        {
            var data = this.bindingSource1.DataSource as System.Collections.Generic.List<PDlyFullNameEntity>;
            if (data == null) return;
            this.QtyTextEdit.EditValue = data.Sum(t => t.Qty);
            this.TotalTextEdit.EditValue = data.Sum(t => t.Total);
            this.AfterPreferTotalTextEdit.EditValue = Convert.ToDecimal(this.TotalTextEdit.EditValue) - Convert.ToDecimal(this.PreferTextEdit.EditValue);
        }
        private void gridView1_CellValueChanged(object sender, CellValueChangedEventArgs e)
        {
            try
            {
                if (e.Column == colPrice || e.Column == colQty || e.Column == colTotal)
                {
                    SummaryChange();
                }
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

        private void PreferTextEdit_EditValueChanged(object sender, EventArgs e)
        {
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
        }

        private void gridView1_CustomRowCellEdit(object sender, CustomRowCellEditEventArgs e)
        {
            try
            {
                if (e.Column == colQty)
                {
                    var row = this.gridView1.GetRow(e.RowHandle) as PDlyFullNameEntity;
                    if (row == null)
                        return;
                    if (row.QtyMode == 1)
                    {
                        e.RepositoryItem = qtySNRepItemPopupContainerEdit;
                    }
                    else if (row.QtyMode == 2)
                    {
                        e.RepositoryItem = qtyFBNRepItemPopupContainerEdit;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBoxEx.Error(ex);
            }
        }

        private void productNoRepItemPopupContainerEdit_EditValueChanged(object sender, EventArgs e)
        {
        }

        private void productNoRepItemPopupContainerEdit_QueryResultValue(object sender, DevExpress.XtraEditors.Controls.QueryResultValueEventArgs e)
        {
        }


        private void priceRepItemPopupContainerEdit_QueryPopUp(object sender, System.ComponentModel.CancelEventArgs e)
        {
        }

        private void priceRepItemPopupContainerEdit_QueryResultValue(object sender, DevExpress.XtraEditors.Controls.QueryResultValueEventArgs e)
        {
        }

        private void SHRNameButtonEdit_Properties_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
        }

        private void StockName1PopupContainerEdit_Properties_QueryResultValue(object sender, DevExpress.XtraEditors.Controls.QueryResultValueEventArgs e)
        {
        }

        private void JSRNamePopupContainerEdit_Properties_QueryResultValue(object sender, DevExpress.XtraEditors.Controls.QueryResultValueEventArgs e)
        {
        }


        private void qtySNRepItemPopupContainerEdit_QueryPopUp(object sender, System.ComponentModel.CancelEventArgs e)
        {
            try
            {
                var basePopupContainerEdit = sender as PopupContainerEdit;
                var singleSelect = basePopupContainerEdit.Properties.PopupControl as IProductSNLook;
                var row = this.gridView1.GetRow(this.gridView1.FocusedRowHandle) as PDlyFullNameEntity;
                if (row == null)
                {
                    e.Cancel = true;
                    return;
                }
                singleSelect.BindData(row.PSNInOutDetails.ToArray());
            }
            catch (Exception ex)
            {
                MessageBoxEx.Error(ex);
            }
        }

        private void qtySNRepItemPopupContainerEdit_QueryResultValue(object sender, DevExpress.XtraEditors.Controls.QueryResultValueEventArgs e)
        {
        }

        private void qtyFBNRepItemPopupContainerEdit_QueryPopUp(object sender, System.ComponentModel.CancelEventArgs e)
        {
            try
            {
                var basePopupContainerEdit = sender as PopupContainerEdit;
                var singleSelect = basePopupContainerEdit.Properties.PopupControl as IProductFBNLook;
                var row = this.gridView1.GetRow(this.gridView1.FocusedRowHandle) as PDlyFullNameEntity;
                if (row == null)
                {
                    e.Cancel = true;
                    return;
                }
                singleSelect.BindData(row.PFBNInOutDetails.ToArray());
            }
            catch (Exception ex)
            {
                MessageBoxEx.Error(ex);
            }
        }

        private void qtyFBNRepItemPopupContainerEdit_QueryResultValue(object sender, DevExpress.XtraEditors.Controls.QueryResultValueEventArgs e)
        {
        }
    }
    public class DlySPRKYGZForm_Design : Base_Form<DlySPRKYGZFormFacade>
    {
    }
    public class DlySPRKYGZFormFacade : ActualBase<DlySPRKYGZForm>
    {
        private IDlyNdxService _DlyNdxService = ServiceProxyFactory.Create<IDlyNdxService>();
        private IInputLevelService _InputLevelService = ServiceProxyFactory.Create<IInputLevelService>();

        public DlySPRKYGZFormFacade(DlySPRKYGZForm actual)
            : base(actual)
        { }
        internal void SetData()
        {
            var entity = _DlyNdxService.GetSPRKDlyYGZNdxEntity(this.Actual.NdxId);
            if (entity == null) throw new BusinessException("单据不存在");
            this.Actual.SetData(entity);
        }
    }
}
