using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Repository;
using FengSharp.OneCardAccess.Domain.BSSModule.Entity;
using FengSharp.OneCardAccess.Infrastructure.Events;
using FengSharp.OneCardAccess.Presentation.IntegeatedManage.BSS.Interface;
using System.Collections.Generic;
using System.ComponentModel;

namespace FengSharp.OneCardAccess.Presentation.IntegeatedManage.BSS
{
    public class InputLevelSelectPopupContainerControl : PopupContainerControl
    {
        private InputLevelSelectUserControl inputLevelSelectUserControl;

        public InputLevelSelectPopupContainerControl()
        {
            InitializeComponent();
        }

        protected override RepositoryItemPopupContainerEdit OwnerItem
        {
            get
            {
                return base.OwnerItem;
            }
            set
            {
                base.OwnerItem = value;
                if (this.PopupContainerProperties != null)
                {
                    this.PopupContainerProperties.QueryPopUp -= PopupContainerProperties_QueryPopUp;
                    this.PopupContainerProperties.QueryPopUp += PopupContainerProperties_QueryPopUp;
                }
            }
        }

        internal void Bind(DlyInputLevelInputerEntity[] entitys)
        {
            this.inputLevelSelectUserControl.Bind(entitys);
        }

        void PopupContainerProperties_QueryPopUp(object sender, CancelEventArgs e)
        {
            IsSelect = false;
        }
        private void InitializeComponent()
        {
            this.inputLevelSelectUserControl = new FengSharp.OneCardAccess.Presentation.IntegeatedManage.BSS.InputLevelSelectUserControl();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // inputLevelControl1
            // 
            this.inputLevelSelectUserControl.Location = new System.Drawing.Point(0, 0);
            this.inputLevelSelectUserControl.Name = "inputLevelControl1";
            this.inputLevelSelectUserControl.Size = new System.Drawing.Size(292, 316);
            this.inputLevelSelectUserControl.TabIndex = 0;
            this.inputLevelSelectUserControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.inputLevelSelectUserControl.OKClick += inputLevelSelectUserControl_OKClick;
            this.inputLevelSelectUserControl.CancelClick += inputLevelSelectUserControl_CancelClick;
            //
            // InputLevelSelectPopupContainerControl
            //
            this.Controls.Add(inputLevelSelectUserControl);
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
        }

        void inputLevelSelectUserControl_CancelClick(System.EventArgs e)
        {
            IsSelect = false;
            var popupContainerEdit = ((RepositoryItemPopupBase)(this.PopupContainerProperties)).OwnerEdit;
            popupContainerEdit.ClosePopup();
        }

        void inputLevelSelectUserControl_OKClick(System.EventArgs e)
        {
            IsSelect = true;
            var popupContainerEdit = ((RepositoryItemPopupBase)(this.PopupContainerProperties)).OwnerEdit;
            popupContainerEdit.ClosePopup();
        }


        public DlyInputLevelInputerEntity GetResult()
        {
            if (!this.IsSelect) return null;
            return this.inputLevelSelectUserControl.EntityResult;
        }

        public bool IsSelect
        {
            get;
            private set;
        }

        internal void AddEntity(DlyInputLevelInputerEntity entity)
        {
            this.inputLevelSelectUserControl.AddEntity(entity);
        }

        internal void RemoveEntity(string entityid)
        {
            this.inputLevelSelectUserControl.RemoveEntity(entityid);
        }

        internal List<DlyInputLevelInputerEntity> GetData()
        {
            return this.inputLevelSelectUserControl.GetData();
        }
    }
}
