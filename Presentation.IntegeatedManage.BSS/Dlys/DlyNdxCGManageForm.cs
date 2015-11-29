using DevExpress.Utils.Menu;
using DevExpress.XtraGrid.Views.Base;
using FengSharp.OneCardAccess.Domain.BSSModule.Entity;
using FengSharp.OneCardAccess.Domain.BSSModule.Service.Interface;
using FengSharp.OneCardAccess.Infrastructure;
using FengSharp.OneCardAccess.Infrastructure.Base;
using FengSharp.OneCardAccess.Infrastructure.Exceptions;
using FengSharp.OneCardAccess.Infrastructure.WinForm.Controls;
using FengSharp.OneCardAccess.Infrastructure.WinForm.Forms;
using FengSharp.OneCardAccess.Presentation.IntegeatedManage.MainStruct.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using FengSharp.OneCardAccess.Infrastructure.WinForm;

namespace FengSharp.OneCardAccess.Presentation.IntegeatedManage.BSS
{
    public partial class DlyNdxCGManageForm : DlyNdxCGManageForm_Design
    {
        public DlyNdxCGManageForm()
        {
            InitializeComponent();
        }

        private void DlyNdxCGManageForm_Load(object sender, EventArgs e)
        {
            try
            {
                this.Facade = new DlyNdxCGManageFormFacade(this);
                this.Facade.Bind();
            }
            catch (Exception ex)
            {
                this.formLoadErrorExit1.LoadError();
                MessageBoxEx.Error(ex);
            }
        }

        private void gridView1_CustomColumnDisplayText(object sender, CustomColumnDisplayTextEventArgs e)
        {
            try
            {
                if (e.Column == colDlyTypeId)
                {
                    DlyFormat.ColumnDisplayTextForDlyTypeId(e);
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
                if (e.Clicks != 2 || this.gridView1.FocusedRowHandle < 0)
                    return;
                var entity = this.gridView1.GetRow(this.gridView1.FocusedRowHandle) as DlyNdxEntity;
                if (entity == null)
                    throw new BusinessException(Properties.Resources.DlyNotExists);
                switch (entity.DlyTypeId)
                {
                    default:
                        throw new BusinessException("错误的单据类型");
                    case FengSharp.OneCardAccess.Application.Config.DlyConfig.SPRKDlyTypeId:
                        {
                            DlySPRKForm form = new DlySPRKForm(entity.DlyNdxId);
                            form.Show();
                        }
                        break;
                    case FengSharp.OneCardAccess.Application.Config.DlyConfig.SPFGDlyTypeId:
                        {
                            DlySPFGForm form = new DlySPFGForm(entity.DlyNdxId);
                            form.Show();
                        }
                        break;
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

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                var entitys = this.gridView1.GetSelectedRows().Select
                    (
                        t => this.gridView1.GetRow(t) as DlyNdxFullNameEntity
                    ).ToArray();
                if (entitys.Length <= 0)
                {
                    MessageBoxEx.Info(FengSharp.OneCardAccess.Infrastructure.ResourceMessages.List_AtLeastOne);
                    return;
                }
                var diaResult = MessageBoxEx.YesNoInfo(FengSharp.OneCardAccess.Infrastructure.ResourceMessages.DeleteConfirm);
                if (diaResult != System.Windows.Forms.DialogResult.Yes)
                    return;
                this.Facade.DeleteCGs(entitys);
                MessageBoxEx.Info(FengSharp.OneCardAccess.Infrastructure.ResourceMessages.DeleteSuccess);
                this.bindingSource1.RemoveEntityIfDataSourceIsList<DlyNdxFullNameEntity>(entitys.ToList());
            }
            catch (Exception ex)
            {
                MessageBoxEx.Error(ex);
            }
        }

        internal void Bind(DlyNdxFullNameEntity[] entitys)
        {
            bindingSource1.DataSource = new List<DlyNdxFullNameEntity>(entitys);
            this.gridControl1.DataSource = bindingSource1;
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            try
            {
                this.Facade.Bind();
            }
            catch (Exception ex)
            {
                MessageBoxEx.Error(ex);
            }
        }
        void InterRefreshRowId(string oldid, string newid)
        {
            var data = this.bindingSource1.DataSource as List<DlyNdxFullNameEntity>;
            var datasourceIndex = data.FindIndex(t => string.Compare(t.DlyNdxId, oldid, false) == 0);
            if (datasourceIndex >= 0)
            {
                var rowhandle = this.gridView1.GetRowHandle(datasourceIndex);
                var row = this.gridView1.GetRow(rowhandle) as DlyNdxFullNameEntity;
                row.DlyNdxId = newid;
                this.gridView1.RefreshRow(rowhandle);
            }
        }
        static internal void RefreshRowId(string oldid, string newid)
        {

            if (!string.IsNullOrWhiteSpace(oldid))
            {
                var imainform = ServiceLoader.LoadService<IMainForm>();
                DlyNdxCGManageForm[] forms = imainform.FindForms<DlyNdxCGManageForm>();
                foreach (var form in forms)
                {
                    form.InterRefreshRowId(oldid, newid);
                }
            }
        }

        private void gridView1_PopupMenuShowing(object sender, DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs e)
        {
            try
            {
                if (e.MenuType == DevExpress.XtraGrid.Views.Grid.GridMenuType.Row)
                {
                    if (this.gridView1.SelectedRowsCount != 1)
                        return;
                    var row = this.gridView1.GetRow(e.HitInfo.RowHandle) as DlyNdxEntity;
                    if (row == null)
                        return;
                    if (row.DlyTypeId == FengSharp.OneCardAccess.Application.Config.DlyConfig.SPRKDlyTypeId)
                    {
                        var menuItem = new DXSubMenuItem("复制为");
                        menuItem.Items.Add(new DXMenuItem("商品入库单", CopyDlyClick) { Tag = Application.Config.DlyConfig.SPRKDlyTypeId });
                        menuItem.Items.Add(new DXMenuItem("商品返工单", CopyDlyClick) { Tag = Application.Config.DlyConfig.SPFGDlyTypeId });
                        e.Menu.Items.Add(menuItem);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBoxEx.Error(ex);
            }
        }
        private void CopyDlyClick(object sender, EventArgs e)
        {
            try
            {
                DXMenuItem menuItem = sender as DXMenuItem;
                if (menuItem == null) return;
                var row = this.gridView1.GetRow(this.gridView1.FocusedRowHandle) as DlyNdxFullNameEntity;
                if (row == null)
                    return;
                int DlyTypeId = Convert.ToInt32(menuItem.Tag);
                string copydlyndx = this.Facade.CopyDlyAs(row.DlyNdxId, DlyTypeId);
                DlyNdxFullNameEntity entity = this.Facade.FindEntity(copydlyndx);
                if (entity != null)
                    MessageBoxEx.Info(FengSharp.OneCardAccess.Infrastructure.ResourceMessages.OPSuccess);
                else
                    MessageBoxEx.Info(FengSharp.OneCardAccess.Infrastructure.ResourceMessages.OPFailure);
                var list = bindingSource1.DataSource as List<DlyNdxFullNameEntity>;
                list.Add(entity);
                bindingSource1.ResetBindings(false);
            }
            catch (Exception ex)
            {
                MessageBoxEx.Error(ex);
            }
        }
    }
    public class DlyNdxCGManageForm_Design : TreeLevelForm<DlyNdxCGManageFormFacade>
    {

    }
    public class DlyNdxCGManageFormFacade : ActualBase<DlyNdxCGManageForm>
    {
        private IDlyNdxService _DlyNdxService = ServiceProxyFactory.Create<IDlyNdxService>();
        public DlyNdxCGManageFormFacade(DlyNdxCGManageForm actual)
            : base(actual)
        { }

        internal void Bind()
        {
            var entitys = _DlyNdxService.GetCGList();
            this.Actual.Bind(entitys);
        }

        internal string CopyDlyAs(string dlyNdxId, int dlyTypeId)
        {
            if (string.IsNullOrWhiteSpace(dlyNdxId))
                throw new BusinessException("单据不可为空");
            if (dlyTypeId == 0)
                throw new BusinessException("错误的单据类型");
            return _DlyNdxService.CopyDlyAs(dlyNdxId, dlyTypeId);
        }

        internal void DeleteCGs(DlyNdxEntity[] entitys)
        {
            _DlyNdxService.DeleteCGs(entitys.Select(t => t.DlyNdxId).ToArray());
        }

        internal DlyNdxFullNameEntity FindEntity(string dlyndx)
        {
            return _DlyNdxService.FindEntity(dlyndx);
        }
    }
}