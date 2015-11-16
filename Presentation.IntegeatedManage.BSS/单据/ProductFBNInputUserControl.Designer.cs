namespace FengSharp.OneCardAccess.Presentation.IntegeatedManage.BSS
{
    partial class ProductFBNInputUserControl
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProductFBNInputUserControl));
            this.baseLayoutControl1 = new FengSharp.OneCardAccess.Infrastructure.WinForm.Base.BaseLayoutControl();
            this.txtQty = new DevExpress.XtraEditors.TextEdit();
            this.txtFBN = new DevExpress.XtraEditors.TextEdit();
            this.btnDelete = new FengSharp.OneCardAccess.Infrastructure.WinForm.Base.BaseSimpleButton();
            this.btnClear = new FengSharp.OneCardAccess.Infrastructure.WinForm.Base.BaseSimpleButton();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new FengSharp.OneCardAccess.Infrastructure.WinForm.Base.BaseGridView();
            this.colBN = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFullBN = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colQty = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRemark = new DevExpress.XtraGrid.Columns.GridColumn();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.ItemForFBN = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForQty = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem2 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.gridView_ShowLine1 = new FengSharp.WinForm.Dev.Components.GridView_ShowLine(this.components);
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.gridView_MouseMulSelect1 = new FengSharp.WinForm.Dev.Components.GridView_MouseMulSelect(this.components);
            this.columnViewGeneColumn1 = new FengSharp.WinForm.Dev.Components.ColumnViewGeneColumn(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.baseLayoutControl1)).BeginInit();
            this.baseLayoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtQty.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFBN.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForFBN)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForQty)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // baseLayoutControl1
            // 
            this.baseLayoutControl1.Controls.Add(this.txtQty);
            this.baseLayoutControl1.Controls.Add(this.txtFBN);
            this.baseLayoutControl1.Controls.Add(this.btnDelete);
            this.baseLayoutControl1.Controls.Add(this.btnClear);
            this.baseLayoutControl1.Controls.Add(this.gridControl1);
            this.baseLayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.baseLayoutControl1.Location = new System.Drawing.Point(0, 0);
            this.baseLayoutControl1.Name = "baseLayoutControl1";
            this.baseLayoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(126, 239, 531, 479);
            this.baseLayoutControl1.OptionsItemText.TextAlignMode = DevExpress.XtraLayout.TextAlignMode.AlignInGroups;
            this.baseLayoutControl1.Root = this.layoutControlGroup1;
            this.baseLayoutControl1.Size = new System.Drawing.Size(560, 502);
            this.baseLayoutControl1.TabIndex = 0;
            this.baseLayoutControl1.Text = "baseLayoutControl1";
            // 
            // txtQty
            // 
            this.txtQty.EditValue = 1;
            this.txtQty.Location = new System.Drawing.Point(332, 6);
            this.txtQty.Name = "txtQty";
            this.txtQty.Properties.NullText = "1";
            this.txtQty.Properties.NullValuePromptShowForEmptyValue = true;
            this.txtQty.Size = new System.Drawing.Size(60, 20);
            this.txtQty.StyleController = this.baseLayoutControl1;
            this.txtQty.TabIndex = 63;
            this.txtQty.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtQty_KeyDown);
            // 
            // txtFBN
            // 
            this.txtFBN.EnterMoveNextControl = true;
            this.txtFBN.Location = new System.Drawing.Point(57, 6);
            this.txtFBN.Name = "txtFBN";
            this.txtFBN.Properties.DisplayFormat.FormatString = "\\d.*";
            this.txtFBN.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.txtFBN.Properties.EditFormat.FormatString = "\\d.*";
            this.txtFBN.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.txtFBN.Properties.Mask.EditMask = "\\d.*";
            this.txtFBN.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
            this.txtFBN.Size = new System.Drawing.Size(220, 20);
            this.txtFBN.StyleController = this.baseLayoutControl1;
            this.txtFBN.TabIndex = 62;
            // 
            // btnDelete
            // 
            this.btnDelete.Image = ((System.Drawing.Image)(resources.GetObject("btnDelete.Image")));
            this.btnDelete.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.btnDelete.Location = new System.Drawing.Point(454, 470);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(100, 26);
            this.btnDelete.StyleController = this.baseLayoutControl1;
            this.btnDelete.TabIndex = 11;
            this.btnDelete.Text = "删除(&D)";
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnClear
            // 
            this.btnClear.Image = ((System.Drawing.Image)(resources.GetObject("btnClear.Image")));
            this.btnClear.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.btnClear.Location = new System.Drawing.Point(350, 470);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(100, 26);
            this.btnClear.StyleController = this.baseLayoutControl1;
            this.btnClear.TabIndex = 61;
            this.btnClear.Text = "清空";
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // gridControl1
            // 
            this.gridControl1.Location = new System.Drawing.Point(6, 30);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(548, 436);
            this.gridControl1.TabIndex = 4;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Appearance.EvenRow.BackColor = System.Drawing.Color.LightYellow;
            this.gridView1.Appearance.EvenRow.Options.UseBackColor = true;
            this.gridView1.Appearance.OddRow.BackColor = System.Drawing.Color.White;
            this.gridView1.Appearance.OddRow.Options.UseBackColor = true;
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colBN,
            this.colFullBN,
            this.colQty,
            this.colRemark});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.IndicatorWidth = 40;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsCustomization.AllowFilter = false;
            this.gridView1.OptionsCustomization.AllowQuickHideColumns = false;
            this.gridView1.OptionsDetail.EnableMasterViewMode = false;
            this.gridView1.OptionsLayout.Columns.StoreLayout = false;
            this.gridView1.OptionsLayout.StoreDataSettings = false;
            this.gridView1.OptionsLayout.StoreVisualOptions = false;
            this.gridView1.OptionsMenu.EnableColumnMenu = false;
            this.gridView1.OptionsNavigation.EnterMoveNextColumn = true;
            this.gridView1.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView1.OptionsSelection.MultiSelect = true;
            this.gridView1.OptionsView.ColumnAutoWidth = false;
            this.gridView1.OptionsView.EnableAppearanceEvenRow = true;
            this.gridView1.OptionsView.EnableAppearanceOddRow = true;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView_ShowLine1.SetShowLineNo(this.gridView1, true);
            // 
            // colBN
            // 
            this.colBN.Caption = "批号";
            this.colBN.FieldName = "BN";
            this.colBN.Name = "colBN";
            this.colBN.OptionsColumn.AllowEdit = false;
            this.colBN.Visible = true;
            this.colBN.VisibleIndex = 0;
            this.colBN.Width = 87;
            // 
            // colFullBN
            // 
            this.colFullBN.Caption = "完整批号";
            this.colFullBN.FieldName = "FullBN";
            this.colFullBN.Name = "colFullBN";
            this.colFullBN.OptionsColumn.AllowEdit = false;
            this.colFullBN.Visible = true;
            this.colFullBN.VisibleIndex = 1;
            this.colFullBN.Width = 158;
            // 
            // colQty
            // 
            this.colQty.Caption = "数量";
            this.colQty.FieldName = "Qty";
            this.colQty.Name = "colQty";
            this.colQty.Visible = true;
            this.colQty.VisibleIndex = 2;
            this.colQty.Width = 58;
            // 
            // colRemark
            // 
            this.colRemark.Caption = "备注";
            this.colRemark.FieldName = "Remark";
            this.colRemark.Name = "colRemark";
            this.colRemark.Visible = true;
            this.colRemark.VisibleIndex = 3;
            this.colRemark.Width = 100;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem2,
            this.layoutControlItem3,
            this.emptySpaceItem1,
            this.ItemForFBN,
            this.ItemForQty,
            this.emptySpaceItem2});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "Root";
            this.layoutControlGroup1.Padding = new DevExpress.XtraLayout.Utils.Padding(3, 3, 3, 3);
            this.layoutControlGroup1.Size = new System.Drawing.Size(560, 502);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.gridControl1;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 24);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(552, 440);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.btnClear;
            this.layoutControlItem2.Location = new System.Drawing.Point(344, 464);
            this.layoutControlItem2.MaxSize = new System.Drawing.Size(104, 30);
            this.layoutControlItem2.MinSize = new System.Drawing.Size(104, 30);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(104, 30);
            this.layoutControlItem2.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextVisible = false;
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.btnDelete;
            this.layoutControlItem3.Location = new System.Drawing.Point(448, 464);
            this.layoutControlItem3.MaxSize = new System.Drawing.Size(104, 30);
            this.layoutControlItem3.MinSize = new System.Drawing.Size(104, 30);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(104, 30);
            this.layoutControlItem3.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem3.TextVisible = false;
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.Location = new System.Drawing.Point(0, 464);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(344, 30);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // ItemForFBN
            // 
            this.ItemForFBN.Control = this.txtFBN;
            this.ItemForFBN.Location = new System.Drawing.Point(0, 0);
            this.ItemForFBN.MaxSize = new System.Drawing.Size(275, 24);
            this.ItemForFBN.MinSize = new System.Drawing.Size(275, 24);
            this.ItemForFBN.Name = "ItemForFBN";
            this.ItemForFBN.Size = new System.Drawing.Size(275, 24);
            this.ItemForFBN.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.ItemForFBN.Text = "完整批号";
            this.ItemForFBN.TextSize = new System.Drawing.Size(48, 13);
            // 
            // ItemForQty
            // 
            this.ItemForQty.Control = this.txtQty;
            this.ItemForQty.Location = new System.Drawing.Point(275, 0);
            this.ItemForQty.MaxSize = new System.Drawing.Size(115, 24);
            this.ItemForQty.MinSize = new System.Drawing.Size(115, 24);
            this.ItemForQty.Name = "ItemForQty";
            this.ItemForQty.Size = new System.Drawing.Size(115, 24);
            this.ItemForQty.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.ItemForQty.Text = "数量";
            this.ItemForQty.TextSize = new System.Drawing.Size(48, 13);
            // 
            // emptySpaceItem2
            // 
            this.emptySpaceItem2.AllowHotTrack = false;
            this.emptySpaceItem2.Location = new System.Drawing.Point(390, 0);
            this.emptySpaceItem2.Name = "emptySpaceItem2";
            this.emptySpaceItem2.Size = new System.Drawing.Size(162, 24);
            this.emptySpaceItem2.TextSize = new System.Drawing.Size(0, 0);
            // 
            // columnViewGeneColumn1
            // 
            this.columnViewGeneColumn1.ColumnView = this.gridView1;
            // 
            // ProductFBNInputUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.baseLayoutControl1);
            this.Name = "ProductFBNInputUserControl";
            this.Size = new System.Drawing.Size(560, 502);
            this.Load += new System.EventHandler(this.ProductFBNInputUserControl_Load);
            ((System.ComponentModel.ISupportInitialize)(this.baseLayoutControl1)).EndInit();
            this.baseLayoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtQty.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFBN.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForFBN)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForQty)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Infrastructure.WinForm.Base.BaseLayoutControl baseLayoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private FengSharp.OneCardAccess.Infrastructure.WinForm.Base.BaseGridView gridView1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private WinForm.Dev.Components.GridView_ShowLine gridView_ShowLine1;
        private Infrastructure.WinForm.Base.BaseSimpleButton btnDelete;
        private Infrastructure.WinForm.Base.BaseSimpleButton btnClear;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private System.Windows.Forms.BindingSource bindingSource1;
        private WinForm.Dev.Components.GridView_MouseMulSelect gridView_MouseMulSelect1;
        private WinForm.Dev.Components.ColumnViewGeneColumn columnViewGeneColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn colBN;
        private DevExpress.XtraGrid.Columns.GridColumn colFullBN;
        private DevExpress.XtraGrid.Columns.GridColumn colQty;
        private DevExpress.XtraGrid.Columns.GridColumn colRemark;
        private DevExpress.XtraEditors.TextEdit txtFBN;
        private DevExpress.XtraLayout.LayoutControlItem ItemForFBN;
        private DevExpress.XtraEditors.TextEdit txtQty;
        private DevExpress.XtraLayout.LayoutControlItem ItemForQty;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem2;
    }
}
