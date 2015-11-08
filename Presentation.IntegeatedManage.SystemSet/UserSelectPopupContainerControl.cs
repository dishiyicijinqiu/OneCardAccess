using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Repository;
using FengSharp.OneCardAccess.Domain.RBACModule.Entity;
using FengSharp.OneCardAccess.Infrastructure.Events;
using FengSharp.OneCardAccess.Presentation.IntegeatedManage.SystemSet.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FengSharp.OneCardAccess.Presentation.IntegeatedManage.SystemSet
{
    public class UserSelectPopupContainerControl : PopupContainerControl, ISingleUserSelect
    {
        private UserSelectUserControl userSelectUserControl1;
        bool isMulSelect = false;
        public UserSelectPopupContainerControl(bool isMulSelect)
        {
            InitializeComponent();
            userSelectUserControl1.BeforeBind += userSelectUserControl1_BeforeBind;
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

        void userSelectUserControl1_BeforeBind(CEventArgs<UserEntity[]> e)
        {
            if (BeforeBind != null)
            {
                this.BeforeBind(e);
            }
        }
        void PopupContainerProperties_QueryPopUp(object sender, System.ComponentModel.CancelEventArgs e)
        {
            this.userSelectUserControl1.IsMulSelect = isMulSelect;
        }

        private void InitializeComponent()
        {
            this.userSelectUserControl1 = new FengSharp.OneCardAccess.Presentation.IntegeatedManage.SystemSet.UserSelectUserControl();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // userSelectUserControl1
            // 
            this.userSelectUserControl1.Facade = null;
            this.userSelectUserControl1.Location = new System.Drawing.Point(0, 0);
            this.userSelectUserControl1.Name = "userSelectUserControl1";
            this.userSelectUserControl1.Size = new System.Drawing.Size(573, 357);
            this.userSelectUserControl1.TabIndex = 0;
            this.userSelectUserControl1.OKClick += userSelectUserControl1_OKClick;
            this.userSelectUserControl1.CancelClick += userSelectUserControl1_CancelClick;
            // 
            // UserSelectPopupContainerControl
            // 
            this.Controls.Add(this.userSelectUserControl1);
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        void userSelectUserControl1_CancelClick(EventArgs e)
        {
            IsSelect = false;
            var popupContainerEdit = ((RepositoryItemPopupBase)(this.PopupContainerProperties)).OwnerEdit;
            popupContainerEdit.ClosePopup();
        }

        void userSelectUserControl1_OKClick(EventArgs e)
        {
            IsSelect = true;
            var popupContainerEdit = ((RepositoryItemPopupBase)(this.PopupContainerProperties)).OwnerEdit;
            popupContainerEdit.ClosePopup();
        }
        public event VEventHandler<CEventArgs<UserEntity[]>> BeforeBind;

        public Domain.RBACModule.Entity.UserEntity GetResult()
        {
            return this.userSelectUserControl1.EntityResult;
        }

        public bool IsSelect
        {
            get;
            private set;
        }
    }
}
