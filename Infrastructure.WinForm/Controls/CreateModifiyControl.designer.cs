namespace FengSharp.OneCardAccess.Infrastructure.WinForm.Controls
{
    partial class CreateModifiyControl
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
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.txtLastModDate = new DevExpress.XtraEditors.TextEdit();
            this.txtLastModUser = new DevExpress.XtraEditors.TextEdit();
            this.txtCreateDate = new DevExpress.XtraEditors.TextEdit();
            this.txtCreate = new DevExpress.XtraEditors.TextEdit();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.textEdit_TimeStyle1 = new FengSharp.WinForm.Dev.Components.TextEdit_TimeStyle();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtLastModDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLastModUser.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCreateDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCreate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.txtLastModDate);
            this.layoutControl1.Controls.Add(this.txtLastModUser);
            this.layoutControl1.Controls.Add(this.txtCreateDate);
            this.layoutControl1.Controls.Add(this.txtCreate);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(205, 342, 1016, 738);
            this.layoutControl1.OptionsPrint.AppearanceGroupCaption.BackColor = System.Drawing.Color.LightGray;
            this.layoutControl1.OptionsPrint.AppearanceGroupCaption.Font = new System.Drawing.Font("Tahoma", 10.25F);
            this.layoutControl1.OptionsPrint.AppearanceGroupCaption.Options.UseBackColor = true;
            this.layoutControl1.OptionsPrint.AppearanceGroupCaption.Options.UseFont = true;
            this.layoutControl1.OptionsPrint.AppearanceGroupCaption.Options.UseTextOptions = true;
            this.layoutControl1.OptionsPrint.AppearanceGroupCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.layoutControl1.OptionsPrint.AppearanceGroupCaption.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.layoutControl1.OptionsPrint.AppearanceItemCaption.Options.UseTextOptions = true;
            this.layoutControl1.OptionsPrint.AppearanceItemCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.layoutControl1.OptionsPrint.AppearanceItemCaption.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(525, 53);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // txtLastModDate
            // 
            this.textEdit_TimeStyle1.SetEnableTimeStyle(this.txtLastModDate, true);
            this.txtLastModDate.Location = new System.Drawing.Point(339, 28);
            this.txtLastModDate.Name = "txtLastModDate";
            this.txtLastModDate.Properties.DisplayFormat.FormatString = "yyyy-MM-dd HH:mm:ss";
            this.txtLastModDate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.txtLastModDate.Properties.EditFormat.FormatString = "yyyy-MM-dd HH:mm:ss";
            this.txtLastModDate.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.txtLastModDate.Properties.Mask.EditMask = "yyyy-MM-dd HH:mm:ss";
            this.txtLastModDate.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTime;
            this.txtLastModDate.Properties.ReadOnly = true;
            this.txtLastModDate.Size = new System.Drawing.Size(182, 20);
            this.txtLastModDate.StyleController = this.layoutControl1;
            this.txtLastModDate.TabIndex = 1;
            this.textEdit_TimeStyle1.SetTimeStyleFormatString(this.txtLastModDate, "yyyy-MM-dd HH:mm:ss");
            // 
            // txtLastModUser
            // 
            this.textEdit_TimeStyle1.SetEnableTimeStyle(this.txtLastModUser, false);
            this.txtLastModUser.Location = new System.Drawing.Point(79, 28);
            this.txtLastModUser.Name = "txtLastModUser";
            this.txtLastModUser.Properties.ReadOnly = true;
            this.txtLastModUser.Size = new System.Drawing.Size(181, 20);
            this.txtLastModUser.StyleController = this.layoutControl1;
            this.txtLastModUser.TabIndex = 2;
            this.textEdit_TimeStyle1.SetTimeStyleFormatString(this.txtLastModUser, "yyyy-MM-dd HH:mm:ss");
            // 
            // txtCreateDate
            // 
            this.textEdit_TimeStyle1.SetEnableTimeStyle(this.txtCreateDate, true);
            this.txtCreateDate.Location = new System.Drawing.Point(339, 4);
            this.txtCreateDate.Name = "txtCreateDate";
            this.txtCreateDate.Properties.DisplayFormat.FormatString = "yyyy-MM-dd HH:mm:ss";
            this.txtCreateDate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.txtCreateDate.Properties.EditFormat.FormatString = "yyyy-MM-dd HH:mm:ss";
            this.txtCreateDate.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.txtCreateDate.Properties.Mask.EditMask = "yyyy-MM-dd HH:mm:ss";
            this.txtCreateDate.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTime;
            this.txtCreateDate.Properties.ReadOnly = true;
            this.txtCreateDate.Size = new System.Drawing.Size(182, 20);
            this.txtCreateDate.StyleController = this.layoutControl1;
            this.txtCreateDate.TabIndex = 3;
            this.textEdit_TimeStyle1.SetTimeStyleFormatString(this.txtCreateDate, "yyyy-MM-dd HH:mm:ss");
            // 
            // txtCreate
            // 
            this.textEdit_TimeStyle1.SetEnableTimeStyle(this.txtCreate, false);
            this.txtCreate.Location = new System.Drawing.Point(79, 4);
            this.txtCreate.Name = "txtCreate";
            this.txtCreate.Properties.ReadOnly = true;
            this.txtCreate.Size = new System.Drawing.Size(181, 20);
            this.txtCreate.StyleController = this.layoutControl1;
            this.txtCreate.TabIndex = 4;
            this.textEdit_TimeStyle1.SetTimeStyleFormatString(this.txtCreate, "yyyy-MM-dd HH:mm:ss");
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.CustomizationFormText = "layoutControlGroup1";
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem3,
            this.layoutControlItem2,
            this.layoutControlItem4});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Padding = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
            this.layoutControlGroup1.Size = new System.Drawing.Size(525, 53);
            this.layoutControlGroup1.Text = "layoutControlGroup1";
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.txtCreate;
            this.layoutControlItem1.CustomizationFormText = "创建人";
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(260, 24);
            this.layoutControlItem1.Text = "创建人";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(72, 13);
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.txtLastModUser;
            this.layoutControlItem3.CustomizationFormText = "最后修改人";
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 24);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(260, 25);
            this.layoutControlItem3.Text = "最后修改人";
            this.layoutControlItem3.TextSize = new System.Drawing.Size(72, 13);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.txtCreateDate;
            this.layoutControlItem2.CustomizationFormText = "创建日期";
            this.layoutControlItem2.Location = new System.Drawing.Point(260, 0);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(261, 24);
            this.layoutControlItem2.Text = "创建日期";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(72, 13);
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.txtLastModDate;
            this.layoutControlItem4.CustomizationFormText = "最后修改日期";
            this.layoutControlItem4.Location = new System.Drawing.Point(260, 24);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(261, 25);
            this.layoutControlItem4.Text = "最后修改日期";
            this.layoutControlItem4.TextSize = new System.Drawing.Size(72, 13);
            // 
            // CreateModifiyControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.layoutControl1);
            this.Name = "CreateModifiyControl";
            this.Size = new System.Drawing.Size(525, 53);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtLastModDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLastModUser.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCreateDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCreate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraEditors.TextEdit txtCreate;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraEditors.TextEdit txtLastModDate;
        private DevExpress.XtraEditors.TextEdit txtLastModUser;
        private DevExpress.XtraEditors.TextEdit txtCreateDate;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private FengSharp.WinForm.Dev.Components.TextEdit_TimeStyle textEdit_TimeStyle1;
    }
}
