using DevExpress.XtraGrid.Views.Base;
using FengSharp.OneCardAccess.Domain.BSSModule.Entity;
using FengSharp.OneCardAccess.Domain.BSSModule.Service.Interface;
using FengSharp.OneCardAccess.Infrastructure;
using FengSharp.OneCardAccess.Infrastructure.Base;
using FengSharp.OneCardAccess.Infrastructure.WinForm.Controls;
using FengSharp.OneCardAccess.Infrastructure.WinForm.Forms;
using System;
using System.Linq;
using FengSharp.OneCardAccess.Infrastructure.WinForm;
using System.Collections.Generic;
using FengSharp.OneCardAccess.Domain.RBACModule.Service.Interface;

namespace FengSharp.OneCardAccess.Presentation.IntegeatedManage.BSS
{
    public partial class ProductManageForm : ProductManageForm_Design
    {
        public ProductManageForm()
        {
            InitializeComponent();
        }

        private void ProductManageForm_Load(object sender, System.EventArgs e)
        {
            try
            {
                this.Facade = new ProductManageFormFacade(this);
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

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                var form = new ProductEditForm(this.TreeLevel.PId);
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
                var entity = this.gridView1.GetRow(this.gridView1.FocusedRowHandle) as Product_Register_Draw_CMCateEntity;
                var form = new ProductEditForm(this.TreeLevel.PId, ViewType.CopyAdd, entity.ProductId);
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
                var entity = this.gridView1.GetRow(this.gridView1.FocusedRowHandle) as Product_Register_Draw_CMCateEntity;
                var form = new ProductEditForm(this.TreeLevel.PId, ViewType.Edit, entity.ProductId);
                form.AfterEdit += form_AfterEdit;
                form.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBoxEx.Error(ex.Message);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                var entitys = this.gridView1.GetSelectedRows().Select
                    (
                        t => this.gridView1.GetRow(t) as Product_Register_Draw_CMCateEntity
                    ).ToArray();
                if (entitys.Length <= 0)
                {
                    MessageBoxEx.Info(FengSharp.OneCardAccess.Infrastructure.ResourceMessages.List_AtLeastOne);
                    return;
                }
                var diaResult = MessageBoxEx.YesNoInfo(FengSharp.OneCardAccess.Infrastructure.ResourceMessages.DeleteConfirm);
                if (diaResult != System.Windows.Forms.DialogResult.Yes)
                    return;
                this.Facade.DeleteProducts(entitys);
                MessageBoxEx.Info(FengSharp.OneCardAccess.Infrastructure.ResourceMessages.DeleteSuccess);
                this.bindingSource1.RemoveEntityIfDataSourceIsList<Product_Register_Draw_CMCateEntity>(entitys.ToList());
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
                var entity = this.gridView1.GetRow(this.gridView1.FocusedRowHandle) as Product_Register_Draw_CMCateEntity;
                var form = new ProductEditForm(entity.ProductId, ViewType.Kind, entity.ProductId);
                form.AfterEdit += form_AfterEdit;
                form.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBoxEx.Error(ex);
            }
        }

        private void form_AfterEdit(Infrastructure.Events.CEventArgs<ViewType, int, int> e)
        {
            try
            {
                switch (e.Para1)
                {
                    case ViewType.Add:
                    case ViewType.CopyAdd:
                        {
                            var entity = this.Facade.FindEntity(e.Para2);
                            var list = bindingSource1.DataSource as List<Product_Register_Draw_CMCateEntity>;
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

        private void gridView1_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            try
            {
                if (e.Clicks != 2 || this.gridView1.FocusedRowHandle < 0)
                    return;
                var entity = this.gridView1.GetRow(this.gridView1.FocusedRowHandle) as Product_Register_Draw_CMCateEntity;
                if (entity.HasCate)
                {
                    this.DeepIn(entity.ProductId);
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

        private void gridView1_CustomColumnDisplayText(object sender, CustomColumnDisplayTextEventArgs e)
        {
            if (string.Compare(e.Column.FieldName, "ProductType", true) == 0)
            {
                if (e.Value == null) return;
                switch (e.Value.ToString())
                {
                    case "0":
                        e.DisplayText = "成品";
                        break;
                    case "1":
                        e.DisplayText = "零部件";
                        break;
                }
            }
            else if (string.Compare(e.Column.FieldName, "CertType", true) == 0)
            {
                if (e.Value == null) return;
                switch (e.Value.ToString())
                {
                    case "0":
                        e.DisplayText = "a证";
                        break;
                    case "1":
                        e.DisplayText = "b证";
                        break;
                }
            }
            else if (string.Compare(e.Column.FieldName, "QtyMode", true) == 0)
            {
                if (e.Value == null) return;
                switch (e.Value.ToString())
                {
                    case "0":
                        e.DisplayText = "通用模式";
                        break;
                    case "1":
                        e.DisplayText = "严格管理序列号";
                        break;
                    case "2":
                        e.DisplayText = "严格管理批号";
                        break;
                }
            }
        }

        internal void Bind(Product_Register_Draw_CMCateEntity[] entitys)
        {
            bindingSource1.DataSource = new List<Product_Register_Draw_CMCateEntity>(entitys);
            this.gridControl1.DataSource = bindingSource1;
        }
    }
    public class ProductManageForm_Design : TreeLevelForm<ProductManageFormFacade>
    {

    }
    public class ProductManageFormFacade : ActualBase<ProductManageForm>
    {
        private IProductService _ProductService = ServiceProxyFactory.Create<IProductService>();
        public ProductManageFormFacade(ProductManageForm actual)
            : base(actual) { }

        internal void BindData(int pid)
        {
            Product_Register_Draw_CMCateEntity[] entitys = this._ProductService.GetProduct_Register_Draw_CMCateTree(pid);
            if (entitys == null)
                entitys = new Product_Register_Draw_CMCateEntity[0];
            this.Actual.Bind(entitys);
        }

        internal int BindFaterData(int pid)
        {
            var pEntity = this._ProductService.GetProductById(pid);
            if (pEntity != null)
            {
                this.BindData(pEntity.PId);
                return pEntity.PId;
            }
            return 0;
        }

        internal Product_Register_Draw_CMCateEntity FindEntity(int entityid)
        {
            var entity = this._ProductService.GetProductById(entityid);
            if (entity == null)
                return null;
            var cmcateentity = new Product_Register_Draw_CMCateEntity();
            FengSharp.Tool.Reflect.ClassValueCopier.Copy(cmcateentity, entity);
            cmcateentity.CreateName = ServiceLoader.LoadService<SystemSet.Interface.IClientUserSerice>().FindUserByIdFromCache(cmcateentity.CreateId).UserName;
            cmcateentity.LastModifyName = ServiceLoader.LoadService<SystemSet.Interface.IClientUserSerice>().FindUserByIdFromCache(cmcateentity.LastModifyId).UserName;
            cmcateentity.HasCate = cmcateentity.Level_Num > 0;
            //注册证信息赋值
            var registerEntity = ServiceProxyFactory.Create<IRegisterService>().GetRegisterById(cmcateentity.RegisterId);
            if (registerEntity != null)
            {
                cmcateentity.RegisterNo = registerEntity.RegisterNo;
                cmcateentity.RegisterNo1 = registerEntity.RegisterNo1;
                cmcateentity.RegisterProductName = registerEntity.RegisterProductName;
                cmcateentity.RegisterProductName1 = registerEntity.RegisterProductName1;
                cmcateentity.StandardCode = registerEntity.StandardCode;
                cmcateentity.StandardCode1 = registerEntity.StandardCode1;
            }
            //图纸信息赋值
            //cmcateentity.DrawingName
            return cmcateentity;
        }

        internal void DeleteProducts(Product_Register_Draw_CMCateEntity[] entitys)
        {
            this._ProductService.DeleteProducts(entitys.Select(t => t.ProductId).ToArray());
        }
    }
}