namespace FengSharp.OneCardAccess.Presentation.IntegeatedManage.DevelopClient
{
    partial class MainForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnMenuSet = new System.Windows.Forms.Button();
            this.btnGenerateMenu = new System.Windows.Forms.Button();
            this.btnActionSet = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnMenuSet
            // 
            this.btnMenuSet.Location = new System.Drawing.Point(28, 35);
            this.btnMenuSet.Name = "btnMenuSet";
            this.btnMenuSet.Size = new System.Drawing.Size(94, 23);
            this.btnMenuSet.TabIndex = 0;
            this.btnMenuSet.Text = "系统菜单配置";
            this.btnMenuSet.UseVisualStyleBackColor = true;
            this.btnMenuSet.Click += new System.EventHandler(this.btnMenuSet_Click);
            // 
            // btnGenerateMenu
            // 
            this.btnGenerateMenu.Location = new System.Drawing.Point(163, 35);
            this.btnGenerateMenu.Name = "btnGenerateMenu";
            this.btnGenerateMenu.Size = new System.Drawing.Size(94, 23);
            this.btnGenerateMenu.TabIndex = 1;
            this.btnGenerateMenu.Text = "生成菜单文件";
            this.btnGenerateMenu.UseVisualStyleBackColor = true;
            this.btnGenerateMenu.Click += new System.EventHandler(this.btnGenerateMenu_Click);
            // 
            // btnActionSet
            // 
            this.btnActionSet.Location = new System.Drawing.Point(306, 35);
            this.btnActionSet.Name = "btnActionSet";
            this.btnActionSet.Size = new System.Drawing.Size(94, 23);
            this.btnActionSet.TabIndex = 2;
            this.btnActionSet.Text = "系统功能配置";
            this.btnActionSet.UseVisualStyleBackColor = true;
            this.btnActionSet.Click += new System.EventHandler(this.btnActionSet_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(542, 358);
            this.Controls.Add(this.btnActionSet);
            this.Controls.Add(this.btnGenerateMenu);
            this.Controls.Add(this.btnMenuSet);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "系统配置";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnMenuSet;
        private System.Windows.Forms.Button btnGenerateMenu;
        private System.Windows.Forms.Button btnActionSet;
    }
}