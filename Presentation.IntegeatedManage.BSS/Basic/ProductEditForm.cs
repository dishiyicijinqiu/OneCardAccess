using DevExpress.XtraEditors;
using FengSharp.OneCardAccess.Domain.BSSModule.Entity;
using FengSharp.OneCardAccess.Domain.BSSModule.Service.Interface;
using FengSharp.OneCardAccess.Domain.RBACModule.Service.Interface;
using FengSharp.OneCardAccess.Infrastructure;
using FengSharp.OneCardAccess.Infrastructure.Base;
using FengSharp.OneCardAccess.Infrastructure.Events;
using FengSharp.OneCardAccess.Infrastructure.Exceptions;
using FengSharp.OneCardAccess.Infrastructure.Services.Interface;
using FengSharp.OneCardAccess.Infrastructure.WinForm;
using FengSharp.OneCardAccess.Infrastructure.WinForm.Base;
using FengSharp.OneCardAccess.Infrastructure.WinForm.Controls;
using FengSharp.OneCardAccess.Infrastructure.WinForm.Helper;
using FengSharp.OneCardAccess.Presentation.IntegeatedManage.BSS.Interface;
using System;
using System.Linq;
using System.Windows.Forms;
namespace FengSharp.OneCardAccess.Presentation.IntegeatedManage.BSS
{
    public partial class ProductEditForm : ProductEditForm_Design
    {
        public ProductEditForm(int pid, ViewType viewtype = ViewType.Add, int id = 0)
        {
            InitializeComponent();
            this.EntityId = id;
            this.PId = pid;
            this.ViewType = viewtype;
            if (!DesignMode)
            {
                var popupContainerControl = ServiceLoader.LoadService<ISingleRegisterSelect>("SingleRegisterControlSelect") as PopupContainerControl;
                popupContainerControl.Width = 800;
                popupContainerControl.Height = 500;
                this.RegisterNoPopupContainerEdit.Properties.PopupControl = popupContainerControl;
            }
        }
        public event VEventHandler<CEventArgs<ViewType, int, int>> AfterEdit;
        public int EntityId { get; set; }
        public int PId { get; set; }
        ViewType viewtype = ViewType.ReadOnly;
        public ViewType ViewType
        {
            get
            {
                return viewtype;
            }
            set
            {
                bool isreadonly = value == ViewType.ReadOnly;
                this.baseDataLayoutControl1.SetReadOnly(isreadonly, new Control[]{
                    this.CreateDateTextEdit,this.CreateNameTextEdit,this.LastModifyNameTextEdit,this.LastModifyDateTextEdit
                });
                this.btnSave.Enabled = !isreadonly;
                viewtype = value;
            }
        }

        private void ProductEditForm_Load(object sender, EventArgs e)
        {
            try
            {
                this.Facade = new ProductEditFormFacade(this);
                this.Facade.SetData();
            }
            catch (Exception ex)
            {
                MessageBoxEx.Error(ex);
                this.formLoadErrorExit1.LoadError();
            }
        }

        private void OnAfterEdit()
        {
            if (AfterEdit != null)
                this.AfterEdit(new CEventArgs<ViewType, int, int>(this.viewtype, this.EntityId, this.PId));
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.ViewType == ViewType.ReadOnly)
                {

                }
                else
                {
                    this.bindbaseDataLayoutControl1.EndEdit();
                    var entity = new ProductEntity();
                    FengSharp.Tool.Reflect.ClassValueCopier.Copy(entity, this.bindbaseDataLayoutControl1.DataSource);
                    Infrastructure.EntityTool.CopyModify(entity);
                    switch (this.ViewType)
                    {
                        case ViewType.Add:
                        case ViewType.CopyAdd:
                            this.EntityId = this.Facade.CreateProduct(entity);
                            MessageBoxEx.Info(FengSharp.OneCardAccess.Infrastructure.ResourceMessages.AddSuccess);
                            break;
                        case ViewType.Edit:
                            this.Facade.UpdateProduct(entity);
                            MessageBoxEx.Info(FengSharp.OneCardAccess.Infrastructure.ResourceMessages.SaveSuccess);
                            break;
                        case ViewType.Kind:
                            this.EntityId = this.Facade.CreateProduct(entity);
                            MessageBoxEx.Info(FengSharp.OneCardAccess.Infrastructure.ResourceMessages.CateSuccess);
                            break;
                    }
                }
                OnAfterEdit();
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
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


        internal void SetData(Product_Register_Draw_CMCateEntity bindentity)
        {
            this.bindbaseDataLayoutControl1.DataSource = bindentity;
        }

        private void RegisterNoPopupContainerEdit_Properties_QueryResultValue(object sender, DevExpress.XtraEditors.Controls.QueryResultValueEventArgs e)
        {
            var basePopupContainerEdit = sender as BasePopupContainerEdit;
            var singleRegisterSelect = basePopupContainerEdit.Properties.PopupControl as ISingleRegisterSelect;
            if (!singleRegisterSelect.IsSelect) return;
            var result = singleRegisterSelect.GetResult();
            var entity = this.bindbaseDataLayoutControl1.DataSource as Product_Register_Draw_CMCateEntity;
            if (result == null)
            {
                entity.RegisterId = string.Empty;
                entity.RegisterNo = string.Empty;
                entity.RegisterNo1 = string.Empty;
                entity.RegisterProductName = string.Empty;
                entity.RegisterProductName1 = string.Empty;
                entity.StandardCode = string.Empty;
                entity.StandardCode1 = string.Empty;
            }
            else
            {
                entity.RegisterId = result.RegisterId;
                entity.RegisterNo = result.RegisterNo;
                entity.RegisterNo1 = result.RegisterNo1;
                entity.RegisterProductName = result.RegisterProductName;
                entity.RegisterProductName1 = result.RegisterProductName1;
                entity.StandardCode = result.StandardCode;
                entity.StandardCode1 = result.StandardCode1;
            }
            e.Value = entity.RegisterNo;
            RegisterProductNameTextEdit.DataBindings[0].ReadValue();
            StandardCodeTextEdit.DataBindings[0].ReadValue();
        }

        internal void BindUnit(DicDataEntity[] PUnits)
        {
            new PopupContainerEditPopupListBoxHelper(this.UnitPopupContainerEdit.Properties)
            {
                DataSource = PUnits,
                DisplayMember = "DicValue",
                ValueMember = "DicValue"
            };
        }

        private void RegisterNoPopupContainerEdit_Properties_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            switch (e.Button.Kind)
            {
                case DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis:
                    break;
                case DevExpress.XtraEditors.Controls.ButtonPredefines.Delete:
                    {
                        var entity = this.bindbaseDataLayoutControl1.DataSource as Product_Register_Draw_CMCateEntity;
                        entity.RegisterId = string.Empty;
                        entity.RegisterNo = string.Empty;
                        entity.RegisterNo1 = string.Empty;
                        entity.RegisterProductName = string.Empty;
                        entity.RegisterProductName1 = string.Empty;
                        entity.StandardCode = string.Empty;
                        entity.StandardCode1 = string.Empty;
                        RegisterNoPopupContainerEdit.DataBindings[0].ReadValue();
                        RegisterProductNameTextEdit.DataBindings[0].ReadValue();
                        StandardCodeTextEdit.DataBindings[0].ReadValue();
                    }
                    break;
                default:
                    break;
            }
        }

        private void UnitPopupContainerEdit_QueryPopUp(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (this.UnitPopupContainerEdit.Properties.PopupControl == null)
            {
                this.Facade.BindData(); return;
            }
            var ctl = this.UnitPopupContainerEdit.Properties.PopupControl.Controls[0];
            var p = ctl.GetType().GetProperty("DataSource");
            if (p.GetValue(ctl, null) == null)
                this.Facade.BindData();
        }
    }
    public class ProductEditForm_Design : Base_Form<ProductEditFormFacade>
    {

    }
    public class ProductEditFormFacade : ActualBase<ProductEditForm>
    {
        private IProductService _ProductService = ServiceProxyFactory.Create<IProductService>();
        public ProductEditFormFacade(ProductEditForm actual)
            : base(actual) { }

        internal Product_Register_Draw_CMCateEntity FindEntity(int entityId)
        {
            var entity = this._ProductService.GetProductById(entityId);
            switch (this.Actual.ViewType)
            {
                case ViewType.Add:
                case ViewType.CopyAdd:
                    if (entity == null)
                        return null;
                    EntityTool.CopyCreateAndModify(entity);
                    break;
                case ViewType.Edit:
                case ViewType.ReadOnly:
                case ViewType.Kind:
                default:
                    if (entity == null)
                        throw new BusinessException(FengSharp.OneCardAccess.Infrastructure.ResourceMessages.ObjectCannotFind);
                    break;
            }
            var cmcateentity = new Product_Register_Draw_CMCateEntity();
            FengSharp.Tool.Reflect.ClassValueCopier.Copy(cmcateentity, entity);
            cmcateentity.CreateName = ServiceProxyFactory.Create<IUserService>().FindUserById(cmcateentity.CreateId).UserName;
            cmcateentity.LastModifyName = ServiceProxyFactory.Create<IUserService>().FindUserById(cmcateentity.LastModifyId).UserName;
            //注册证信息赋值
            //cmcateentity.RegisterNo
            //图纸信息赋值
            //cmcateentity.DrawingName
            return cmcateentity;
        }

        internal int CreateProduct(ProductEntity entity)
        {
            return this._ProductService.CreateProduct(entity);
        }

        internal void UpdateProduct(ProductEntity entity)
        {
            this._ProductService.UpdateProduct(entity);
        }

        internal void BindData()
        {
            DicDataEntity[] entitys = ServiceProxyFactory.Create<IDicDataService>().GetDataByDicTypes(
             new string[] { 
                        "PUnit"//,"Duty", "Title","Origin","Nation"
                    }
                );
            var PUnits = entitys.Where(t => string.Compare(t.DicType, "PUnit", true) == 0).ToArray();
            this.Actual.BindUnit(PUnits);
        }

        internal void SetData()
        {
            switch (this.Actual.ViewType)
            {
                case ViewType.Add:
                    {
                        #region Add
                        ProductEntity entity = new ProductEntity();
                        Infrastructure.EntityTool.CopyCreateAndModify(entity);
                        entity.PId = this.Actual.PId;
                        Product_Register_Draw_CMCateEntity bindentity = new Product_Register_Draw_CMCateEntity();
                        FengSharp.Tool.Reflect.ClassValueCopier.Copy(bindentity, entity);
                        bindentity.CreateName = ServiceProxyFactory.Create<IUserService>().FindUserById(bindentity.CreateId).UserName;
                        bindentity.LastModifyName = ServiceProxyFactory.Create<IUserService>().FindUserById(bindentity.LastModifyId).UserName;
                        this.Actual.SetData(bindentity);
                        #endregion
                    }
                    break;
                case ViewType.CopyAdd:
                case ViewType.Kind:
                    {
                        #region CopyAdd,Kind
                        ProductEntity entity = this._ProductService.GetProductById(this.Actual.EntityId);
                        if (entity == null)
                            throw new BusinessException(FengSharp.OneCardAccess.Infrastructure.ResourceMessages.ObjectCannotFind);
                        Infrastructure.EntityTool.CopyCreateAndModify(entity);
                        entity.PId = this.Actual.PId;
                        Product_Register_Draw_CMCateEntity bindentity = new Product_Register_Draw_CMCateEntity();
                        FengSharp.Tool.Reflect.ClassValueCopier.Copy(bindentity, entity);
                        bindentity.CreateName = ServiceProxyFactory.Create<IUserService>().FindUserById(bindentity.CreateId).UserName;
                        bindentity.LastModifyName = ServiceProxyFactory.Create<IUserService>().FindUserById(bindentity.LastModifyId).UserName;
                        bindentity.Remark1 = string.Empty;
                        bindentity.Remark2 = string.Empty;
                        bindentity.Remark3 = string.Empty;
                        bindentity.Remark4 = string.Empty;
                        bindentity.Remark5 = string.Empty;
                        bindentity.Remark6 = string.Empty;
                        bindentity.Remark7 = string.Empty;
                        bindentity.Remark8 = string.Empty;
                        bindentity.ProductImage = string.Empty;
                        this.Actual.SetData(bindentity);
                        #endregion
                    }
                    break;
                case ViewType.Edit:
                case ViewType.ReadOnly:
                    {
                        #region Edit,ReadOnly
                        ProductEntity entity = this._ProductService.GetProductById(this.Actual.EntityId);
                        if (entity == null)
                            throw new BusinessException(FengSharp.OneCardAccess.Infrastructure.ResourceMessages.ObjectCannotFind);
                        Product_Register_Draw_CMCateEntity bindentity = new Product_Register_Draw_CMCateEntity();
                        FengSharp.Tool.Reflect.ClassValueCopier.Copy(bindentity, entity);
                        bindentity.CreateName = ServiceProxyFactory.Create<IUserService>().FindUserById(bindentity.CreateId).UserName;
                        bindentity.LastModifyName = ServiceProxyFactory.Create<IUserService>().FindUserById(bindentity.LastModifyId).UserName;
                        var registerEntity = ServiceProxyFactory.Create<IRegisterService>().GetRegisterById(bindentity.RegisterId);
                        if (registerEntity != null)
                        {
                            bindentity.RegisterNo = registerEntity.RegisterNo;
                            bindentity.RegisterNo1 = registerEntity.RegisterNo1;
                            bindentity.RegisterProductName = registerEntity.RegisterProductName;
                            bindentity.RegisterProductName1 = registerEntity.RegisterProductName1;
                            bindentity.StandardCode = registerEntity.StandardCode;
                            bindentity.StandardCode1 = registerEntity.StandardCode1;
                        }
                        this.Actual.SetData(bindentity);
                        #endregion
                    }
                    break;
                case ViewType.AddChild:
                default:
                    throw new BusinessException(FengSharp.OneCardAccess.Infrastructure.ResourceMessages.ErrorType);
            }
        }
    }
}