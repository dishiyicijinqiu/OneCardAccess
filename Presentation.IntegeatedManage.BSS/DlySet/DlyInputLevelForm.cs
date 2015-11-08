using FengSharp.OneCardAccess.Domain.BSSModule.Entity;
using FengSharp.OneCardAccess.Domain.BSSModule.Service.Interface;
using FengSharp.OneCardAccess.Infrastructure;
using FengSharp.OneCardAccess.Infrastructure.Base;
using FengSharp.OneCardAccess.Infrastructure.WinForm.Base;
using FengSharp.OneCardAccess.Infrastructure.WinForm.Controls;
using FengSharp.OneCardAccess.Presentation.IntegeatedManage.BSS.Interface;
using FengSharp.OneCardAccess.Presentation.IntegeatedManage.SystemSet.Interface;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FengSharp.OneCardAccess.Presentation.IntegeatedManage.BSS
{
    public partial class DlyInputLevelForm : DlyInputLevelForm_Design
    {
        public DlyInputLevelForm()
        {
            InitializeComponent();
            if (!DesignMode)
            {
                PopInputerId1.Properties.PopupControl = CreatePopupContainerControl(1);
                PopInputerId2.Properties.PopupControl = CreatePopupContainerControl(2);
                PopInputerId3.Properties.PopupControl = CreatePopupContainerControl(3);
                PopInputerId4.Properties.PopupControl = CreatePopupContainerControl(4);
                PopInputerId5.Properties.PopupControl = CreatePopupContainerControl(5);
            }
        }

        private DevExpress.XtraEditors.PopupContainerControl CreatePopupContainerControl(short inputlevel)
        {
            var popupContainerControl = new InputLevelSelectPopupContainerControl();
            popupContainerControl.Width = 320;
            popupContainerControl.Height = 240;
            popupContainerControl.Tag = inputlevel;
            return popupContainerControl;
        }

        private void DlyInputLevelForm_Load(object sender, EventArgs e)
        {
            this.cbbInPutLevel.EditValue = ((short)(0));
            this.Facade = new DlyInputLevelFormFacade(this);
        }

        private void btnSelectDly_Click(object sender, EventArgs e)
        {
            try
            {
                ISingleDlyTypeSelect singleselect = ServiceLoader.LoadService<ISingleDlyTypeSelect>("SingleDlyTypeFormSelect");
                var result = singleselect.GetResult();
                if (singleselect.IsSelect)
                {
                    this.CurrentDlyTypeCateEntity = result;
                    this.Facade.BindInputLevel(result);
                }
            }
            catch (Exception ex)
            {
                MessageBoxEx.Error(ex);
            }
        }
        DlyTypeCateEntity _CurrentDlyTypeCateEntity;
        DlyTypeCateEntity CurrentDlyTypeCateEntity
        {
            get
            {
                return _CurrentDlyTypeCateEntity;
            }
            set
            {
                if (value == null)
                {
                    this.layoutControlGroup1.Text = "审核流程控制";
                    this.cbbInPutLevel.EditValue = ((short)0);
                }
                else
                {
                    this.layoutControlGroup1.Text = string.Format("[{0}]审核流程控制", value.DlyName);
                    this.cbbInPutLevel.EditValue = value.InputLevel;
                }
                _CurrentDlyTypeCateEntity = value;
            }
        }

        #region 绑定审核人
        internal void BindInputLevel1(DlyInputLevelInputerEntity[] entitys1)
        {
            PopInputerId1.EditValue = FengSharp.OneCardAccess.Infrastructure.ResourceMessages.PleaseSelect;
            var singleUserSelect = PopInputerId1.Properties.PopupControl as InputLevelSelectPopupContainerControl;
            singleUserSelect.Bind(entitys1);
        }

        internal void BindInputLevel2(DlyInputLevelInputerEntity[] entitys2)
        {
            PopInputerId2.EditValue = FengSharp.OneCardAccess.Infrastructure.ResourceMessages.PleaseSelect;
            var singleUserSelect = PopInputerId2.Properties.PopupControl as InputLevelSelectPopupContainerControl;
            singleUserSelect.Bind(entitys2);
        }

        internal void BindInputLevel3(DlyInputLevelInputerEntity[] entitys3)
        {
            PopInputerId3.EditValue = FengSharp.OneCardAccess.Infrastructure.ResourceMessages.PleaseSelect;
            var singleUserSelect = PopInputerId3.Properties.PopupControl as InputLevelSelectPopupContainerControl;
            singleUserSelect.Bind(entitys3);
        }

        internal void BindInputLevel4(DlyInputLevelInputerEntity[] entitys4)
        {
            PopInputerId4.EditValue = FengSharp.OneCardAccess.Infrastructure.ResourceMessages.PleaseSelect;
            var singleUserSelect = PopInputerId4.Properties.PopupControl as InputLevelSelectPopupContainerControl;
            singleUserSelect.Bind(entitys4);
        }

        internal void BindInputLevel5(DlyInputLevelInputerEntity[] entitys5)
        {
            PopInputerId5.EditValue = FengSharp.OneCardAccess.Infrastructure.ResourceMessages.PleaseSelect;
            var singleUserSelect = PopInputerId5.Properties.PopupControl as InputLevelSelectPopupContainerControl;
            singleUserSelect.Bind(entitys5);
        }
        #endregion

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (_CurrentDlyTypeCateEntity == null)
                {
                    MessageBoxEx.Info("请选择一个单据");
                    return;
                }
                short inputlevel = (short)this.cbbInPutLevel.EditValue;
                List<DlyInputLevelInputerEntity> inputlevels = new List<DlyInputLevelInputerEntity>();
                if (inputlevel > 0)
                {
                    var inputpop = PopInputerId1.Properties.PopupControl as InputLevelSelectPopupContainerControl;
                    List<DlyInputLevelInputerEntity> data = inputpop.GetData();
                    inputlevels.AddRange(data);
                }
                if (inputlevel > 1)
                {
                    var inputpop = PopInputerId2.Properties.PopupControl as InputLevelSelectPopupContainerControl;
                    List<DlyInputLevelInputerEntity> data = inputpop.GetData();
                    inputlevels.AddRange(data);
                }
                if (inputlevel > 2)
                {
                    var inputpop = PopInputerId3.Properties.PopupControl as InputLevelSelectPopupContainerControl;
                    List<DlyInputLevelInputerEntity> data = inputpop.GetData();
                    inputlevels.AddRange(data);
                }
                if (inputlevel > 3)
                {
                    var inputpop = PopInputerId4.Properties.PopupControl as InputLevelSelectPopupContainerControl;
                    List<DlyInputLevelInputerEntity> data = inputpop.GetData();
                    inputlevels.AddRange(data);
                }
                if (inputlevel > 4)
                {
                    var inputpop = PopInputerId5.Properties.PopupControl as InputLevelSelectPopupContainerControl;
                    List<DlyInputLevelInputerEntity> data = inputpop.GetData();
                    inputlevels.AddRange(data);
                }
                this.Facade.SaveInputLevel(_CurrentDlyTypeCateEntity.DlyTypeId, inputlevel, inputlevels);
                MessageBoxEx.Info(FengSharp.OneCardAccess.Infrastructure.ResourceMessages.SaveSuccess);
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

        private void PopInputerId_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            try
            {
                if (this._CurrentDlyTypeCateEntity == null)
                {
                    MessageBoxEx.Info("请选择一个单据");
                    return;
                }
                BasePopupContainerEdit popEdit = sender as BasePopupContainerEdit;
                if (popEdit == null)
                    return;
                var popControl = popEdit.Properties.PopupControl as InputLevelSelectPopupContainerControl;
                if (popControl == null)
                    return;
                if (e.Button.Kind == DevExpress.XtraEditors.Controls.ButtonPredefines.Plus)
                {
                    ISingleUserSelect singleUserSelect = ServiceLoader.LoadService<ISingleUserSelect>("SingleUserSelectForm");
                    singleUserSelect.BeforeBind += (para) =>
                    {
                        var entitys = para.Para1;
                        var listdata = popControl.GetData();
                        para.Para1 = entitys.Where(t => listdata.Count(m => m.InputerId == t.UserId) <= 0).ToArray();
                    };
                    var result = singleUserSelect.GetResult();
                    if (!singleUserSelect.IsSelect)
                        return;
                    if (result != null)
                    {
                        popEdit.EditValue = result.UserName;
                        popEdit.Tag = result.UserId;
                        var entity = new DlyInputLevelInputerEntity();
                        entity.DlyTypeId = this._CurrentDlyTypeCateEntity.DlyTypeId;
                        entity.InputerId = result.UserId;
                        entity.InputerName = result.UserName;
                        entity.InputLevel = (short)popControl.Tag;
                        popControl.AddEntity(entity);
                    }
                }
                else if (e.Button.Kind == DevExpress.XtraEditors.Controls.ButtonPredefines.Delete)
                {
                    if (popEdit.Tag == null)
                    {
                        MessageBoxEx.Info("请选择要给审核人");
                        return;
                    }
                    popControl.RemoveEntity(popEdit.Tag.ToString());
                    popEdit.EditValue = FengSharp.OneCardAccess.Infrastructure.ResourceMessages.PleaseSelect;
                    popEdit.Tag = null;
                }
            }
            catch (Exception ex)
            {
                MessageBoxEx.Error(ex);
            }
        }

        private void PopInputerId_QueryResultValue(object sender, DevExpress.XtraEditors.Controls.QueryResultValueEventArgs e)
        {
            var basePopupContainerEdit = sender as BasePopupContainerEdit;
            var singleUserSelect = basePopupContainerEdit.Properties.PopupControl as InputLevelSelectPopupContainerControl;
            if (!singleUserSelect.IsSelect) return;
            var result = singleUserSelect.GetResult();
            if (result == null)
            {
                e.Value = string.Empty;
                basePopupContainerEdit.Tag = null;
            }
            else
            {
                e.Value = result.InputerName;
                basePopupContainerEdit.Tag = result.InputerId;
            }
        }

        private void PopInputerId_QueryPopUp(object sender, System.ComponentModel.CancelEventArgs e)
        {

        }

        private void cbbInPutLevel_EditValueChanged(object sender, EventArgs e)
        {
            if (this.cbbInPutLevel.EditValue == null) return;
            short editvalue = (short)this.cbbInPutLevel.EditValue;
            ItemForPopInputerId1.Enabled = editvalue >= ((short)1);
            ItemForPopInputerId2.Enabled = editvalue >= ((short)2);
            ItemForPopInputerId3.Enabled = editvalue >= ((short)3);
            ItemForPopInputerId4.Enabled = editvalue >= ((short)4);
            ItemForPopInputerId5.Enabled = editvalue >= ((short)5);
        }
    }
    public class DlyInputLevelForm_Design : Base_Form<DlyInputLevelFormFacade>
    {

    }
    public class DlyInputLevelFormFacade : ActualBase<DlyInputLevelForm>
    {
        private IInputLevelService _InputLevelService = ServiceProxyFactory.Create<IInputLevelService>();
        public DlyInputLevelFormFacade(DlyInputLevelForm actual)
            : base(actual) { }
        internal void BindInputLevel(DlyTypeCateEntity result)
        {
            var entitys = _InputLevelService.GetInputLevelsByDlyTypeId(result.DlyTypeId);
            var entitys1 = entitys.Where(t => t.InputLevel == ((short)1)).ToArray();
            var entitys2 = entitys.Where(t => t.InputLevel == ((short)2)).ToArray();
            var entitys3 = entitys.Where(t => t.InputLevel == ((short)3)).ToArray();
            var entitys4 = entitys.Where(t => t.InputLevel == ((short)4)).ToArray();
            var entitys5 = entitys.Where(t => t.InputLevel == ((short)5)).ToArray();
            this.Actual.BindInputLevel1(entitys1);
            this.Actual.BindInputLevel2(entitys2);
            this.Actual.BindInputLevel3(entitys3);
            this.Actual.BindInputLevel4(entitys4);
            this.Actual.BindInputLevel5(entitys5);
        }

        internal void SaveInputLevel(int DlyTypeId, short inputlevel, List<DlyInputLevelInputerEntity> inputlevels)
        {
            _InputLevelService.SaveInputLevel(DlyTypeId, inputlevel, inputlevels);
        }
    }
}
