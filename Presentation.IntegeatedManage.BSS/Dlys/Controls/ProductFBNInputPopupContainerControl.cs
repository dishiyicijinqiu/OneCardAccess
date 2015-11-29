using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Repository;
using FengSharp.OneCardAccess.Domain.BSSModule.Entity;
using FengSharp.OneCardAccess.Presentation.IntegeatedManage.BSS.Interface;
using System.Linq;

namespace FengSharp.OneCardAccess.Presentation.IntegeatedManage.BSS
{
    public class ProductFBNInputPopupContainerControl : PopupContainerControl, IProductFBNInput
    {
        private ProductFBNInputUserControl selectUserControl1;
        public ProductFBNInputPopupContainerControl()
        {
            InitializeComponent();
        }
        private void InitializeComponent()
        {
            this.selectUserControl1 = new ProductFBNInputUserControl();
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
            // 
            // ProductFBNInputPopupContainerControl
            // 
            this.Controls.Add(this.selectUserControl1);
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
        }
        public void BindData(FBNInputEntity[] entitys)
        {
            this.selectUserControl1.BindData(entitys);
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
                    this.PopupContainerProperties.Popup -= PopupContainerProperties_Popup;
                    this.PopupContainerProperties.Popup += PopupContainerProperties_Popup;
                }
            }
        }

        void PopupContainerProperties_Popup(object sender, System.EventArgs e)
        {
            this.selectUserControl1.ResetValue();
        }


        public FBNInputEntity[] EntityResults
        {
            get { return this.selectUserControl1.EntityResults; }
        }

        public int Qty
        {
            get { return this.selectUserControl1.EntityResults.Sum(t => t.Qty); }
        }

        public string BN
        {
            get
            {
                if (this.selectUserControl1.EntityResults.Length <= 0) return string.Empty;
                return this.selectUserControl1.EntityResults[0].BN;
            }
        }
    }
}
