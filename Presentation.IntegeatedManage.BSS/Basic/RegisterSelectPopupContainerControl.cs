using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Repository;
using FengSharp.OneCardAccess.Domain.BSSModule.Entity;
using FengSharp.OneCardAccess.Infrastructure.Events;
using FengSharp.OneCardAccess.Presentation.IntegeatedManage.BSS.Interface;
using System.Linq;

namespace FengSharp.OneCardAccess.Presentation.IntegeatedManage.BSS
{
    public class RegisterSelectPopupContainerControl : PopupContainerControl, ISingleRegisterSelect
    {
        private RegisterSelectUserControl registerSelectUserControl1;
        bool isMulSelect = false;
        public RegisterSelectPopupContainerControl(bool isMulSelect)
        {
            InitializeComponent();
            registerSelectUserControl1.BeforeBind += registerSelectUserControl1_BeforeBind;
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
                    this.PopupContainerProperties.QueryPopUp -= Properties_QueryPopUp;
                    this.PopupContainerProperties.QueryPopUp += Properties_QueryPopUp;
                }
            }
        }

        void registerSelectUserControl1_BeforeBind(Infrastructure.Events.CEventArgs<RegisterCMEntity[]> e)
        {
            if (BeforeBind != null)
            {
                this.BeforeBind(e);
            }
        }

        void Properties_QueryPopUp(object sender, System.ComponentModel.CancelEventArgs e)
        {
            this.registerSelectUserControl1.IsMulSelect = isMulSelect;
        }

        private void InitializeComponent()
        {
            this.registerSelectUserControl1 = new RegisterSelectUserControl();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // registerSelectUserControl1
            // 
            this.registerSelectUserControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.registerSelectUserControl1.Location = new System.Drawing.Point(0, 0);
            this.registerSelectUserControl1.Name = "deptSelectUserControl1";
            this.registerSelectUserControl1.Size = new System.Drawing.Size(200, 100);
            this.registerSelectUserControl1.TabIndex = 0;
            this.registerSelectUserControl1.OKClick += registerSelectUserControl1_OKClick;
            this.registerSelectUserControl1.CancelClick += registerSelectUserControl1_CancelClick;
            // 
            // DeptSelectPopupContainerControl
            // 
            this.Controls.Add(this.registerSelectUserControl1);
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
        }

        void registerSelectUserControl1_CancelClick(System.EventArgs e)
        {
            IsSelect = false;
            var popupContainerEdit = ((RepositoryItemPopupBase)(this.PopupContainerProperties)).OwnerEdit;
            popupContainerEdit.ClosePopup();
        }
        void registerSelectUserControl1_OKClick(System.EventArgs e)
        {
            IsSelect = true;
            var popupContainerEdit = ((RepositoryItemPopupBase)(this.PopupContainerProperties)).OwnerEdit;
            popupContainerEdit.ClosePopup();
        }

        public event VEventHandler<CEventArgs<RegisterCMEntity[]>> BeforeBind;

        public RegisterCMEntity GetResult()
        {
            return this.registerSelectUserControl1.EntityResult;
        }


        public bool IsSelect
        {
            get;
            private set;
        }
    }
}
