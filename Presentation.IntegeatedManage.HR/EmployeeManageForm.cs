using FengSharp.OneCardAccess.Domain.HRModule.Entity;
using FengSharp.OneCardAccess.Domain.HRModule.Service.Interface;
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
namespace FengSharp.OneCardAccess.Presentation.IntegeatedManage.HR
{
    public partial class EmployeeManageForm : EmployeeManageForm_Design
    {
        public EmployeeManageForm()
        {
            InitializeComponent();
        }
        private void EmployeeManageForm_Load(object sender, EventArgs e)
        {
            try
            {
                this.Facade = new EmployeeManageFormFacade(this);
                this.Facade.BindData();
            }
            catch (Exception ex)
            {
                this.formLoadErrorExit1.SetLoadError(this, true);
                MessageBoxEx.Error(ex);
            }
        }

        public void Bind(EmployeeCMDeptEntity[] entitys)
        {
            bindingSource.DataSource = new List<EmployeeCMDeptEntity>(entitys);
            this.gridControl1.DataSource = bindingSource;
        }

        void form_AfterEdit(CEventArgs<ViewType, string> e)
        {
            try
            {
                switch (e.Para1)
                {
                    case ViewType.Add:
                    case ViewType.CopyAdd:
                        {
                            var entity = this.Facade.FindEntity(e.Para2);
                            var list = bindingSource.DataSource as List<EmployeeCMDeptEntity>;
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

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                var form = new EmployeeEditForm();
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
                var entity = this.gridView1.GetRow(this.gridView1.FocusedRowHandle) as EmployeeCMDeptEntity;
                var form = new EmployeeEditForm(ViewType.CopyAdd, entity.EmpId);
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
                var entity = this.gridView1.GetRow(this.gridView1.FocusedRowHandle) as EmployeeCMDeptEntity;
                var form = new EmployeeEditForm(ViewType.Edit, entity.EmpId);
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
                t => this.gridView1.GetRow(t) as EmployeeCMDeptEntity
            ).ToArray();
                if (entitys.Length <= 0)
                {
                    MessageBoxEx.Info(FengSharp.OneCardAccess.Infrastructure.ResourceMessages.List_AtLeastOne);
                    return;
                }
                var diaResult = MessageBoxEx.YesNoInfo(FengSharp.OneCardAccess.Infrastructure.ResourceMessages.DeleteConfirm);
                if (diaResult != System.Windows.Forms.DialogResult.Yes)
                    return;
                this.Facade.DeleteEmployee(entitys);
                MessageBoxEx.Info(FengSharp.OneCardAccess.Infrastructure.ResourceMessages.DeleteSuccess);
                this.bindingSource.RemoveEntityIfDataSourceIsList<EmployeeCMDeptEntity>(entitys.ToList());
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

        private void gridView1_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            try
            {
                if (e.Clicks != 2 || e.RowHandle < 0)
                    return;
                if (btnEdit.Enabled)
                    btnEditView_Click(btnEdit, null);
            }
            catch (Exception ex)
            {
                MessageBoxEx.Error(ex);
            }
        }

        private void gridView1_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            if (string.Compare(e.Column.FieldName, "EmpStatus", true) == 0)
            {
                if (e.Value == null) return;
                switch (e.Value.ToString())
                {
                    case "1":
                        e.DisplayText = "在职";
                        break;
                    case "2":
                        e.DisplayText = "试用";
                        break;
                    case "3":
                        e.DisplayText = "停职";
                        break;
                    case "4":
                        e.DisplayText = "离职";
                        break;
                }
            }
        }
    }
    public class EmployeeManageForm_Design : Base_Form<EmployeeManageFormFacade>
    {
    }
    public class EmployeeManageFormFacade : ActualBase<EmployeeManageForm>
    {
        private IEmployeeService _EmployeeService = ServiceProxyFactory.Create<IEmployeeService>();
        public EmployeeManageFormFacade(EmployeeManageForm actual)
            : base(actual) { }

        internal void BindData()
        {
            EmployeeCMDeptEntity[] entitys = this._EmployeeService.GetAllCMDeptEmployee();
            if (entitys == null)
                entitys = new EmployeeCMDeptEntity[0];
            this.Actual.Bind(entitys);
        }

        internal void DeleteEmployee(EmployeeCMDeptEntity[] entitys)
        {
            this._EmployeeService.DeleteDeployees(entitys.Select(t => t.EmpId).ToArray());
        }

        internal EmployeeCMDeptEntity FindEntity(string empid)
        {
            var entity = this._EmployeeService.FindEmployeeById(empid);
            if (entity == null) return null;
            var result = new EmployeeCMDeptEntity();
            FengSharp.Tool.Reflect.ClassValueCopier.Copy(result, entity);
            result.CreateName = ServiceProxyFactory.Create<IUserService>().FindUserById(result.CreateId).UserName;
            result.LastModifyName = ServiceProxyFactory.Create<IUserService>().FindUserById(result.LastModifyId).UserName;
            var deptEntity = ServiceProxyFactory.Create<IDeptService>().GetDeptById(result.DeptId);
            if (deptEntity != null)
            {
                result.DeptNo = deptEntity.DeptNo;
                result.DeptName = deptEntity.DeptName;
            }
            return result;
        }
    }
}