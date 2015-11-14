using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FengSharp.OneCardAccess.Presentation.IntegeatedManage.BSS
{
    public partial class DJ_Exit : DevExpress.XtraEditors.XtraForm
    {
        public DJ_Exit()
        {
            InitializeComponent();
        }

        private void btnSaveDJ_Click(object sender, EventArgs e)
        {
            _Dialog_Result = DialogResultEx.保存单据;
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private void btnSaveCG_Click(object sender, EventArgs e)
        {
            _Dialog_Result = DialogResultEx.存入草稿;
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        [System.Diagnostics.DebuggerStepThrough]
        protected override bool ProcessDialogKey(Keys keyData)
        {
            if (keyData == Keys.Escape)
            {
                _Dialog_Result = DialogResultEx.取消操作;
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
            }
            return base.ProcessDialogKey(keyData);
        }
        private void btnFQTC_Click(object sender, EventArgs e)
        {
            _Dialog_Result = DialogResultEx.废弃退出;
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }
        private DialogResultEx _Dialog_Result = DialogResultEx.取消操作;
        public DialogResultEx Dialog_Result
        {
            get
            {
                return _Dialog_Result;
            }
        }

        public DialogResultEx ShowDialogResultEx()
        {
            this.ShowDialog();
            return Dialog_Result;
        }
    }
    public enum DialogResultEx
    {
        取消操作 = 0,
        存入草稿 = 1,
        保存单据 = 2,
        废弃退出 = 3,
    }
}
