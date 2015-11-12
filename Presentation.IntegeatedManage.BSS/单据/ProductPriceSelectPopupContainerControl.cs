using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Repository;
using FengSharp.OneCardAccess.Presentation.IntegeatedManage.BSS.Interface;

namespace FengSharp.OneCardAccess.Presentation.IntegeatedManage.BSS
{
    public class ProductPriceSelectPopupContainerControl : PopupContainerControl, ISingleProductPriceSelect
    {
        private ProductPriceSelectUserControl selectUserControl1;
        bool isMulSelect = false;
        public ProductPriceSelectPopupContainerControl()
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
                    this.PopupContainerProperties.QueryPopUp -= Properties_QueryPopUp;
                    this.PopupContainerProperties.QueryPopUp += Properties_QueryPopUp;
                }
            }
        }
        void Properties_QueryPopUp(object sender, System.ComponentModel.CancelEventArgs e)
        {
            IsSelect = false;
            this.selectUserControl1.IsMulSelect = isMulSelect;
        }
        private void InitializeComponent()
        {
            this.selectUserControl1 = new ProductPriceSelectUserControl();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // selectUserControl1
            // 
            this.selectUserControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.selectUserControl1.Location = new System.Drawing.Point(0, 0);
            this.selectUserControl1.Name = "selectUserControl1";
            this.selectUserControl1.Size = new System.Drawing.Size(200, 100);
            this.selectUserControl1.TabIndex = 0;
            this.selectUserControl1.OKClick += selectUserControl1_OKClick;
            this.selectUserControl1.CancelClick += selectUserControl1_CancelClick;
            // 
            // ProductPriceSelectPopupContainerControl
            // 
            this.Controls.Add(this.selectUserControl1);
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
        }

        void selectUserControl1_CancelClick(System.EventArgs e)
        {
            IsSelect = false;
            this.PopupContainerProperties.PopupControl.OwnerEdit.ClosePopup();
        }
        void selectUserControl1_OKClick(System.EventArgs e)
        {
            IsSelect = true;
            this.PopupContainerProperties.PopupControl.OwnerEdit.ClosePopup();
        }
        public double GetResult()
        {
            return this.selectUserControl1.EntityResult;
        }
        public bool IsSelect
        {
            get;
            private set;
        }

        public void BindData(int entityid)
        {
            this.selectUserControl1.BindData(entityid);
        }
    }
}
