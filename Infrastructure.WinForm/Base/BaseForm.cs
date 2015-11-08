using System.Diagnostics;
using System.Windows.Forms;

namespace FengSharp.OneCardAccess.Infrastructure.WinForm.Base
{
    public partial class BaseForm : DevExpress.XtraEditors.XtraForm
    {
        public BaseForm()
        {
            InitializeComponent();
        }
        [DebuggerStepThrough]
        protected override bool ProcessDialogKey(Keys keyData)
        {
            if (keyData == Keys.Escape)
            {
                this.Close();
            }
            return base.ProcessDialogKey(keyData);
        }
    }
}