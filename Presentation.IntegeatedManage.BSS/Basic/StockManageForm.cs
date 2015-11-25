using FengSharp.OneCardAccess.Domain.BSSModule.Entity;
using FengSharp.OneCardAccess.Domain.BSSModule.Service.Interface;
using FengSharp.OneCardAccess.Domain.RBACModule.Service.Interface;
using FengSharp.OneCardAccess.Infrastructure;
using FengSharp.OneCardAccess.Infrastructure.Base;
using FengSharp.OneCardAccess.Infrastructure.Events;
using FengSharp.OneCardAccess.Infrastructure.WinForm;
using FengSharp.OneCardAccess.Infrastructure.WinForm.Base;
using FengSharp.OneCardAccess.Infrastructure.WinForm.Controls;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FengSharp.OneCardAccess.Presentation.IntegeatedManage.BSS
{
    public partial class StockManageForm : StockManageForm_Design
    {
        public StockManageForm()
        {
            InitializeComponent();
        }

        private void StockManageForm_Load(object sender, EventArgs e)
        {
            try
            {
                this.Facade = new StockManageFormFacade(this);
                this.Facade.BindData();
            }
            catch (Exception ex)
            {
                this.formLoadErrorExit1.SetLoadError(this, true);
                MessageBoxEx.Error(ex);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                var form = new StockEditForm();
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
                var entity = this.gridView1.GetRow(this.gridView1.FocusedRowHandle) as StockCMEntity;
                var form = new StockEditForm(ViewType.CopyAdd, entity.StockId);
                form.AfterEdit += form_AfterEdit;
                form.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBoxEx.Error(ex.Message);
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.gridView1.FocusedRowHandle < 0)
                {
                    MessageBoxEx.Info(FengSharp.OneCardAccess.Infrastructure.ResourceMessages.List_AtLeastOne);
                    return;
                }
                var entity = this.gridView1.GetRow(this.gridView1.FocusedRowHandle) as StockCMEntity;
                var form = new StockEditForm(ViewType.Edit, entity.StockId);
                form.AfterEdit += form_AfterEdit;
                form.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBoxEx.Error(ex);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                var entitys = this.gridView1.GetSelectedRows().Select
            (
                t => this.gridView1.GetRow(t) as StockCMEntity
            ).ToArray();
                if (entitys.Length <= 0)
                {
                    MessageBoxEx.Info(FengSharp.OneCardAccess.Infrastructure.ResourceMessages.List_AtLeastOne);
                    return;
                }
                var diaResult = MessageBoxEx.YesNoInfo(FengSharp.OneCardAccess.Infrastructure.ResourceMessages.DeleteConfirm);
                if (diaResult != System.Windows.Forms.DialogResult.Yes)
                    return;
                this.Facade.DeleteStocks(entitys);
                MessageBoxEx.Info(FengSharp.OneCardAccess.Infrastructure.ResourceMessages.DeleteSuccess);
                this.bindingSource1.RemoveEntityIfDataSourceIsList<StockCMEntity>(entitys.ToList());
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

        internal void Bind(StockCMEntity[] entitys)
        {
            this.bindingSource1.DataSource = new List<StockCMEntity>(entitys);
            this.gridControl1.DataSource = this.bindingSource1;
        }

        private void form_AfterEdit(CEventArgs<ViewType, int> e)
        {
            try
            {
                switch (e.Para1)
                {
                    case ViewType.Add:
                    case ViewType.CopyAdd:
                        {
                            var entity = this.Facade.FindEntity(e.Para2);
                            var list = this.bindingSource1.DataSource as List<StockCMEntity>;
                            list.Add(entity);
                            bindingSource1.ResetBindings(false);
                            if (e.Para1 == ViewType.CopyAdd)
                                this.btnCopyAdd_Click(null, null);
                        }
                        break;
                    case ViewType.Edit:
                        {
                            var entity = this.Facade.FindEntity(e.Para2);
                            var row = this.gridView1.GetRow(this.gridView1.FocusedRowHandle);
                            FengSharp.Tool.Reflect.ClassValueCopier.Copy(row, entity);
                            this.gridView1.RefreshRow(this.gridView1.FocusedRowHandle);
                        }
                        break;
                    case ViewType.Kind:
                    case ViewType.AddChild:
                    default:
                    case ViewType.ReadOnly:
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBoxEx.Error(ex);
            }
        }

        private void gridView1_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            try
            {
                if (e.Clicks != 2 || e.RowHandle < 0)
                    return;
                if (btnEdit.Enabled)
                    btnEdit_Click(btnEdit, null);
            }
            catch (Exception ex)
            {
                MessageBoxEx.Error(ex);
            }
        }

        private void StockManageForm_FormClosing(object sender, System.Windows.Forms.FormClosingEventArgs e)
        {

        }
    }

    public class StockManageForm_Design : Base_Form<StockManageFormFacade>
    {
    }
    public class StockManageFormFacade : ActualBase<StockManageForm>
    {
        private IStockService _StockService = ServiceProxyFactory.Create<IStockService>();
        public StockManageFormFacade(StockManageForm actual)
            : base(actual) { }
        internal void BindData()
        {
            StockCMEntity[] entitys = this._StockService.GetStockCMList();
            if (entitys == null)
                entitys = new StockCMEntity[0];
            this.Actual.Bind(entitys);
        }
        internal void DeleteStocks(StockCMEntity[] entitys)
        {
            this._StockService.DeleteStocks(entitys.Select(t => t.StockId).ToArray());
        }
        internal StockCMEntity FindEntity(int entityid)
        {
            var entity = this._StockService.GetStockById(entityid);
            if (entity == null) return null;
            var result = new StockCMEntity();
            FengSharp.Tool.Reflect.ClassValueCopier.Copy(result, entity);
            result.CreateName = ServiceLoader.LoadService<SystemSet.Interface.IClientUserSerice>().FindUserByIdFromCache(result.CreateId).UserName;
            result.LastModifyName = ServiceLoader.LoadService<SystemSet.Interface.IClientUserSerice>().FindUserByIdFromCache(result.LastModifyId).UserName;
            return result;
        }
    }
}