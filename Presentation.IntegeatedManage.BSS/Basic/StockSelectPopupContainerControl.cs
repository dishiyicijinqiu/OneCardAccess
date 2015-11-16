using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Repository;
using FengSharp.OneCardAccess.Domain.BSSModule.Entity;
using FengSharp.OneCardAccess.Infrastructure.Events;
using FengSharp.OneCardAccess.Presentation.IntegeatedManage.BSS.Interface;
using System.Linq;

namespace FengSharp.OneCardAccess.Presentation.IntegeatedManage.BSS
{
    public class StockSelectPopupContainerControl : PopupContainerControl, ISingleStockSelect
    {
        private StockSelectUserControl stockSelectUserControl;
        bool isMulSelect = false;
        public StockSelectPopupContainerControl(bool isMulSelect)
        {
            InitializeComponent();
            stockSelectUserControl.BeforeBind += stockSelectUserControl_BeforeBind;
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

        void stockSelectUserControl_BeforeBind(CEventArgs<StockCMEntity[]> e)
        {
            if (BeforeBind != null)
            {
                this.BeforeBind(e);
            }
        }

        void Properties_QueryPopUp(object sender, System.ComponentModel.CancelEventArgs e)
        {
            IsSelect = false;
            this.stockSelectUserControl.IsMulSelect = isMulSelect;
        }
        private void InitializeComponent()
        {
            this.stockSelectUserControl = new StockSelectUserControl();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // stockSelectUserControl
            // 
            this.stockSelectUserControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.stockSelectUserControl.Location = new System.Drawing.Point(0, 0);
            this.stockSelectUserControl.Name = "deptSelectUserControl1";
            this.stockSelectUserControl.Size = new System.Drawing.Size(200, 100);
            this.stockSelectUserControl.TabIndex = 0;
            this.stockSelectUserControl.OKClick += stockSelectUserControl_OKClick;
            this.stockSelectUserControl.CancelClick += stockSelectUserControl_CancelClick;
            // 
            // stockSelectUserControl
            // 
            this.Controls.Add(this.stockSelectUserControl);
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
        }

        void stockSelectUserControl_CancelClick(System.EventArgs e)
        {
            IsSelect = false;
            var popupContainerEdit = ((RepositoryItemPopupBase)(this.PopupContainerProperties)).OwnerEdit;
            popupContainerEdit.ClosePopup();
        }

        void stockSelectUserControl_OKClick(System.EventArgs e)
        {
            IsSelect = true;
            var popupContainerEdit = ((RepositoryItemPopupBase)(this.PopupContainerProperties)).OwnerEdit;
            popupContainerEdit.ClosePopup();
        }

        public event VEventHandler<CEventArgs<StockCMEntity[]>> BeforeBind;

        public StockCMEntity GetResult()
        {
            return this.stockSelectUserControl.EntityResult;
        }


        public bool IsSelect
        {
            get;
            private set;
        }
    }
}
