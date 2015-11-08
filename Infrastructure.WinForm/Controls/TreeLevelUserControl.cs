using DevExpress.XtraEditors;
using FengSharp.OneCardAccess.Infrastructure.WinForm.Base;
using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace FengSharp.OneCardAccess.Infrastructure.WinForm.Controls
{
    public class TreeLevelUserControl<TFacade> : Base_UserControl<TFacade>
    {
        TreeLevel treelevel = new TreeLevel();
        public virtual TreeLevel TreeLevel
        {
            get
            {
                return treelevel;
            }
            set
            {
                treelevel = value;
            }
        }

        public TreeLevelUserControl()
        {
            this.Load += TreeLevelUserControl_Load;
        }

        void TreeLevelUserControl_Load(object sender, EventArgs e)
        {
            if (TreeLevel == null)
                TreeLevel = new TreeLevel();
            TreeLevel.PropertyChanged += TreeLevel_PropertyChanged;
        }
        public virtual void TreeLevel_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "Level_Deep")
            {
                var btns = this.Controls.Find("btnCancel", true);
                if (btns.Length > 0)
                {
                    var btn = btns[0] as SimpleButton;
                    btn.Text = TreeLevel.Level_Deep > 0 ? ResourceMessages.btnReturn : ResourceMessages.btnCancel;
                }
                if (TreeLevel.Level_Deep < 0)
                    this.FindForm().DialogResult = DialogResult.Cancel;
            }
        }
        public virtual void DeepIn(int pid)
        {
            this.treelevel.PId = pid;
            this.treelevel.Level_Deep++;
        }
        public virtual void DeepOut(int pid)
        {
            this.treelevel.PId = pid;
            this.treelevel.Level_Deep--;
        }
        [DebuggerStepThrough]
        protected override bool ProcessDialogKey(Keys keyData)
        {
            if (keyData == Keys.Escape)
            {
                try
                {
                    this.DeepOut(this.TreeLevel.PId);
                }
                catch (Exception ex)
                {
                    MessageBoxEx.Error(ex);
                }
            }
            return true;
        }
    }
}
