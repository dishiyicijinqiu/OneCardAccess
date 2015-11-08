using DevExpress.XtraEditors;
using FengSharp.OneCardAccess.Infrastructure.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FengSharp.OneCardAccess.Infrastructure.WinForm.Controls
{

    public static class MessageBoxEx
    {
        public static DialogResult Info(string content, string title = null, IWin32Window owner = null)
        {
            title = title ?? FengSharp.OneCardAccess.Infrastructure.ResourceMessages.Infomation_Title;
            if (owner == null)
                return XtraMessageBox.Show(content, title, MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                return XtraMessageBox.Show(owner, content, title, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        public static DialogResult Error(Exception ex, string title = null, IWin32Window owner = null)
        {
            title = title ?? FengSharp.OneCardAccess.Infrastructure.ResourceMessages.Exception_Title;
            if (owner == null)
                return XtraMessageBox.Show(ex.Message, title, MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
                return XtraMessageBox.Show(ex.Message, title, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        public static DialogResult Error(string content, string title = null, IWin32Window owner = null)
        {
            title = title ?? FengSharp.OneCardAccess.Infrastructure.ResourceMessages.Exception_Title;
            if (owner == null)
                return XtraMessageBox.Show(content, title, MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
                return XtraMessageBox.Show(content, title, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        public static DialogResult YesNoInfo(string content, string title = null, IWin32Window owner = null)
        {
            title = title ?? FengSharp.OneCardAccess.Infrastructure.ResourceMessages.Infomation_Title;
            if (owner == null)
                return XtraMessageBox.Show(content, title, MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            else
                return XtraMessageBox.Show(owner, content, title, MessageBoxButtons.YesNo, MessageBoxIcon.Information);
        }
    }
}
