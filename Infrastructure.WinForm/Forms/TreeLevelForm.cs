using DevExpress.XtraEditors;
using FengSharp.OneCardAccess.Infrastructure.Base;
using FengSharp.OneCardAccess.Infrastructure.WinForm.Base;
using FengSharp.OneCardAccess.Infrastructure.WinForm.Controls;
using System;
using System.Diagnostics;
using System.Windows.Forms;
namespace FengSharp.OneCardAccess.Infrastructure.WinForm.Forms
{
    public class TreeLevelForm<TFacade> : Base_Form<TFacade>
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
        public TreeLevelForm()
        {
            TreeLevel.PropertyChanged += TreeLevel_PropertyChanged;
        }
        public virtual void TreeLevel_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "Level_Deep")
            {
                var btns = this.Controls.Find("btnClose", true);
                if (btns.Length > 0)
                {
                    var btn = btns[0] as SimpleButton;
                    btn.Text = TreeLevel.Level_Deep > 0 ? ResourceMessages.btnReturn : ResourceMessages.btnClose;
                }
                if (TreeLevel.Level_Deep < 0)
                    this.Close();
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