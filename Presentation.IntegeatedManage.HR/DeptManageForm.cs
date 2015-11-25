using DevExpress.XtraGrid.Views.Grid;
using FengSharp.OneCardAccess.Domain.HRModule.Entity;
using FengSharp.OneCardAccess.Domain.HRModule.Service.Interface;
using FengSharp.OneCardAccess.Domain.RBACModule.Service.Interface;
using FengSharp.OneCardAccess.Infrastructure;
using FengSharp.OneCardAccess.Infrastructure.Base;
using FengSharp.OneCardAccess.Infrastructure.Events;
using FengSharp.OneCardAccess.Infrastructure.WinForm;
using FengSharp.OneCardAccess.Infrastructure.WinForm.Controls;
using FengSharp.OneCardAccess.Infrastructure.WinForm.Forms;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FengSharp.OneCardAccess.Presentation.IntegeatedManage.HR
{
    public partial class DeptManageForm : DeptManageForm_Design
    {
        public DeptManageForm()
        {
            InitializeComponent();
        }

        private void DeptManageForm_Load(object sender, System.EventArgs e)
        {
            try
            {
                this.Facade = new DeptManageFormFacade(this);
                this.Facade.BindData(this.TreeLevel.PId);
            }
            catch (Exception ex)
            {
                this.formLoadErrorExit1.LoadError();
                MessageBoxEx.Error(ex);
            }
        }

        #region TreeLevelForm
        public override void DeepIn(int pid)
        {
            this.Facade.BindData(pid);
            base.DeepIn(pid);
        }

        public override void DeepOut(int pid)
        {
            pid = this.Facade.BindFaterData(pid);
            base.DeepOut(pid);
        }
        #endregion

        #region Events
        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                var form = new DeptEditForm(this.TreeLevel.PId);
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
                var entity = this.gridView1.GetRow(this.gridView1.FocusedRowHandle) as DeptCMCateEntity;
                var form = new DeptEditForm(this.TreeLevel.PId, ViewType.CopyAdd, entity.DeptId);
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
                var entity = this.gridView1.GetRow(this.gridView1.FocusedRowHandle) as DeptCMCateEntity;
                var form = new DeptEditForm(this.TreeLevel.PId, ViewType.Edit, entity.DeptId);
                form.AfterEdit += form_AfterEdit;
                form.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBoxEx.Error(ex.Message);
            }
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            try
            {
                var entitys = this.gridView1.GetSelectedRows().Select
                    (
                        t => this.gridView1.GetRow(t) as DeptCMCateEntity
                    ).ToArray();
                if (entitys.Length <= 0)
                {
                    MessageBoxEx.Info(FengSharp.OneCardAccess.Infrastructure.ResourceMessages.List_AtLeastOne);
                    return;
                }
                var diaResult = MessageBoxEx.YesNoInfo(FengSharp.OneCardAccess.Infrastructure.ResourceMessages.DeleteConfirm);
                if (diaResult != System.Windows.Forms.DialogResult.Yes)
                    return;
                this.Facade.DeleteDepts(entitys);
                MessageBoxEx.Info(FengSharp.OneCardAccess.Infrastructure.ResourceMessages.DeleteSuccess);
                this.bindingSource.RemoveEntityIfDataSourceIsList<DeptCMCateEntity>(entitys.ToList());
            }
            catch (Exception ex)
            {
                MessageBoxEx.Error(ex);
            }
        }

        private void btnKind_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.gridView1.FocusedRowHandle < 0)
                {
                    MessageBoxEx.Info(FengSharp.OneCardAccess.Infrastructure.ResourceMessages.List_AtLeastOne);
                    return;
                }
                var entity = this.gridView1.GetRow(this.gridView1.FocusedRowHandle) as DeptCMCateEntity;
                var form = new DeptEditForm(entity.DeptId, ViewType.Kind, entity.DeptId);
                form.AfterEdit += form_AfterEdit;
                form.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBoxEx.Error(ex);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            try
            {
                this.DeepOut(this.TreeLevel.PId);
            }
            catch (Exception ex)
            {
                MessageBoxEx.Error(ex);
            }
        }

        public void Bind(DeptCMCateEntity[] entitys)
        {
            bindingSource.DataSource = new List<DeptCMCateEntity>(entitys);
            this.gridControl1.DataSource = bindingSource;
        }

        void form_AfterEdit(CEventArgs<ViewType, int, int> e)
        {
            try
            {
                switch (e.Para1)
                {
                    case ViewType.Add:
                    case ViewType.CopyAdd:
                        {
                            var entity = this.Facade.FindEntity(e.Para2);
                            var list = bindingSource.DataSource as List<DeptCMCateEntity>;
                            list.Add(entity);
                            bindingSource.ResetBindings(false);
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
                        this.DeepIn(e.Para3);
                        break;
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

        private void gridView1_RowClick(object sender, RowClickEventArgs e)
        {
            try
            {
                if (e.Clicks != 2 || this.gridView1.FocusedRowHandle < 0)
                    return;
                var entity = this.gridView1.GetRow(this.gridView1.FocusedRowHandle) as DeptCMCateEntity;
                if (entity.HasCate)
                {
                    this.DeepIn(entity.DeptId);
                }
                else
                {
                    this.btnEdit_Click(null, null);
                }
            }
            catch (Exception ex)
            {
                MessageBoxEx.Error(ex);
            }
        }
        #endregion
    }

    public class DeptManageForm_Design : TreeLevelForm<DeptManageFormFacade>
    {
    }
    public class DeptManageFormFacade : ActualBase<DeptManageForm>
    {
        private IDeptService _DeptService = ServiceProxyFactory.Create<IDeptService>();

        public DeptManageFormFacade(DeptManageForm actual)
            : base(actual) { }

        internal void BindData(int pid)
        {
            DeptCMCateEntity[] depts = this._DeptService.GetDeptTree(pid);
            if (depts == null)
                depts = new DeptCMCateEntity[0];
            this.Actual.Bind(depts);
        }

        internal int BindFaterData(int pid)
        {
            var pEntity = this._DeptService.GetDeptById(pid);
            if (pEntity != null)
            {
                this.BindData(pEntity.PId);
                return pEntity.PId;
            }
            return 0;
        }

        internal DeptCMCateEntity FindEntity(int id)
        {
            var entity = this._DeptService.GetDeptById(id);
            if (entity == null)
                return null;
            var cmcateentity = new DeptCMCateEntity();
            FengSharp.Tool.Reflect.ClassValueCopier.Copy(cmcateentity, entity);
            cmcateentity.CreateName = ServiceLoader.LoadService<SystemSet.Interface.IClientUserSerice>().FindUserByIdFromCache(cmcateentity.CreateId).UserName;
            cmcateentity.LastModifyName = ServiceLoader.LoadService<SystemSet.Interface.IClientUserSerice>().FindUserByIdFromCache(cmcateentity.LastModifyId).UserName;
            cmcateentity.HasCate = cmcateentity.Level_Num > 0;
            return cmcateentity;
        }

        internal void DeleteDepts(DeptCMCateEntity[] entitys)
        {
            this._DeptService.DeleteDepts(entitys.Select(t => t.DeptId).ToArray());
        }
    }
}