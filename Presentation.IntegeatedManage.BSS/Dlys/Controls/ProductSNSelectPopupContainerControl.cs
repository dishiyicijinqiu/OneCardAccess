using DevExpress.XtraEditors;
using FengSharp.OneCardAccess.Domain.BSSModule.Entity;
using FengSharp.OneCardAccess.Presentation.IntegeatedManage.BSS.Interface;
using System.Linq;
using System;
using DevExpress.XtraEditors.Repository;

namespace FengSharp.OneCardAccess.Presentation.IntegeatedManage.BSS
{
    public class ProductSNSelectPopupContainerControl : PopupContainerControl, IProductSNSelect
    {
        private ProductSNSelectUserControl selectUserControl1;
        public ProductSNSelectPopupContainerControl()
        {
            InitializeComponent();
        }
        private void InitializeComponent()
        {
            this.selectUserControl1 = new ProductSNSelectUserControl();
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
            // ProductSNSelectPopupContainerControl
            // 
            this.Controls.Add(this.selectUserControl1);
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
        }
        public string BN
        {
            get
            {
                if (this.selectUserControl1.EntityResults.Length <= 0) return string.Empty;
                return this.selectUserControl1.EntityResults[0].BN;
            }
        }

        public void BindData(PSNBakEntity[] entitys, int StockId, int ProductId, string BN)
        {
            this.selectUserControl1.BindData(entitys, StockId, ProductId, BN);
        }

        public PSNBakEntity[] EntityResults
        {
            get
            {
                return this.selectUserControl1.EntityResults;
            }
        }

        public int Qty
        {
            get { return (int)this.selectUserControl1.EntityResults.Length; }
        }
    }
}
