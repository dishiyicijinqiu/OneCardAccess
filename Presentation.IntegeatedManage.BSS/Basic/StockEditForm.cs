using FengSharp.OneCardAccess.Application.IntegeatedManage.Config;
using FengSharp.OneCardAccess.Domain.BSSModule.Entity;
using FengSharp.OneCardAccess.Domain.BSSModule.Service.Interface;
using FengSharp.OneCardAccess.Domain.RBACModule.Service.Interface;
using FengSharp.OneCardAccess.Infrastructure;
using FengSharp.OneCardAccess.Infrastructure.Base;
using FengSharp.OneCardAccess.Infrastructure.Events;
using FengSharp.OneCardAccess.Infrastructure.Exceptions;
using FengSharp.OneCardAccess.Infrastructure.WinForm;
using FengSharp.OneCardAccess.Infrastructure.WinForm.Base;
using FengSharp.OneCardAccess.Infrastructure.WinForm.Controls;
using FengSharp.OneCardAccess.Infrastructure.WinForm.Helper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace FengSharp.OneCardAccess.Presentation.IntegeatedManage.BSS
{
    public partial class StockEditForm : StockEditForm_Design
    {
        public StockEditForm(ViewType viewtype = ViewType.Add, int id = 0)
        {
            InitializeComponent();
            this.EntityId = id;
            this.ViewType = viewtype;
        }
        #region fileds
        public event VEventHandler<CEventArgs<ViewType, int>> AfterEdit;
        public int EntityId { get; set; }
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
                this.baseDataLayoutControl1.SetReadOnly(isreadonly, new Control[] {
                    this.CreateNameTextEdit,this.CreateDateTextEdit,this.LastModifyNameTextEdit,this.LastModifyDateTextEdit
                });
                this.btnSave.Enabled = !isreadonly;
                viewtype = value;
            }
        }
        #endregion

        internal void SetData(StockCMEntity bindentity)
        {
            this.bindbaseDataLayoutControl1.DataSource = bindentity;
        }

        private void OnAfterEdit()
        {
            if (AfterEdit != null) this.AfterEdit(new CEventArgs<ViewType, int>(this.viewtype, this.EntityId));
        }

        private void StockEditForm_Load(object sender, EventArgs e)
        {
            try
            {
                this.Facade = new StockEditFormFacade(this);
                this.Facade.SetData();
            }
            catch (Exception ex)
            {
                this.formLoadErrorExit1.LoadError();
                MessageBoxEx.Error(ex);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
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
                    var bindEntity = this.bindbaseDataLayoutControl1.DataSource as StockCMEntity;
                    var entity = new StockEntity();
                    FengSharp.Tool.Reflect.ClassValueCopier.Copy(entity, bindEntity);
                    Infrastructure.EntityTool.CopyModify(entity);
                    switch (this.ViewType)
                    {
                        case ViewType.Add:
                        case ViewType.CopyAdd:
                            this.EntityId = this.Facade.CreateStock(entity);
                            MessageBoxEx.Info(FengSharp.OneCardAccess.Infrastructure.ResourceMessages.AddSuccess);
                            break;
                        case ViewType.Edit:
                            this.Facade.UpdateStock(entity);
                            MessageBoxEx.Info(FengSharp.OneCardAccess.Infrastructure.ResourceMessages.SaveSuccess);
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
    }
    public class StockEditForm_Design : Base_Form<StockEditFormFacade>
    {
    }
    public class StockEditFormFacade : ActualBase<StockEditForm>
    {
        private IStockService _StockService = ServiceProxyFactory.Create<IStockService>();
        public StockEditFormFacade(StockEditForm actual)
            : base(actual)
        { }

        internal void SetData()
        {
            switch (this.Actual.ViewType)
            {
                case ViewType.Add:
                    {
                        #region Add
                        StockEntity entity = new StockEntity();
                        Infrastructure.EntityTool.CopyCreateAndModify(entity);
                        StockCMEntity bindentity = new StockCMEntity();
                        FengSharp.Tool.Reflect.ClassValueCopier.Copy(bindentity, entity);
                        bindentity.CreateName = ServiceProxyFactory.Create<IUserService>().FindUserById(bindentity.CreateId).UserName;
                        bindentity.LastModifyName = ServiceProxyFactory.Create<IUserService>().FindUserById(bindentity.LastModifyId).UserName;
                        this.Actual.SetData(bindentity);
                        #endregion
                    }
                    break;
                case ViewType.CopyAdd:
                    {
                        #region CopyAdd
                        StockEntity entity = this._StockService.GetStockById(this.Actual.EntityId);
                        if (entity == null)
                            throw new BusinessException(FengSharp.OneCardAccess.Infrastructure.ResourceMessages.ObjectCannotFind);
                        Infrastructure.EntityTool.CopyCreateAndModify(entity);
                        StockCMEntity bindentity = new StockCMEntity();
                        FengSharp.Tool.Reflect.ClassValueCopier.Copy(bindentity, entity);
                        bindentity.CreateName = ServiceProxyFactory.Create<IUserService>().FindUserById(bindentity.CreateId).UserName;
                        bindentity.LastModifyName = ServiceProxyFactory.Create<IUserService>().FindUserById(bindentity.LastModifyId).UserName;
                        bindentity.Remark = string.Empty;
                        this.Actual.SetData(bindentity);

                        #endregion
                    }
                    break;
                case ViewType.Edit:
                case ViewType.ReadOnly:
                    {
                        #region Edit,ReadOnly
                        StockEntity entity = this._StockService.GetStockById(this.Actual.EntityId);
                        if (entity == null)
                            throw new BusinessException(FengSharp.OneCardAccess.Infrastructure.ResourceMessages.ObjectCannotFind);

                        StockCMEntity bindentity = new StockCMEntity();
                        FengSharp.Tool.Reflect.ClassValueCopier.Copy(bindentity, entity);
                        bindentity.CreateName = ServiceProxyFactory.Create<IUserService>().FindUserById(bindentity.CreateId).UserName;
                        bindentity.LastModifyName = ServiceProxyFactory.Create<IUserService>().FindUserById(bindentity.LastModifyId).UserName;
                        this.Actual.SetData(bindentity);
                        #endregion
                    }
                    break;
                case ViewType.Kind:
                case ViewType.AddChild:
                default:
                    throw new BusinessException(FengSharp.OneCardAccess.Infrastructure.ResourceMessages.ErrorType);
            }
        }

        internal int CreateStock(StockEntity entity)
        {
            EntityTool.CopyCreateAndModify(entity);
            return _StockService.CreateStock(entity);

        }

        internal void UpdateStock(StockEntity entity)
        {
            EntityTool.CopyModify(entity);
            _StockService.UpdateStock(entity);
        }
    }
}