using FengSharp.WinForm.Dev;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FengSharp.OneCardAccess.Presentation.IntegeatedManage.BSS
{
    public static class DJMessageBox
    {
        public static DialogResultEx Show()
        {
            var buttons = new CusDialogResult[] { 
                new CusDialogResult(DialogResult.Yes, "存入草稿(&S)") ,
                new CusDialogResult(DialogResult.OK, "保存单据") ,
                new CusDialogResult(DialogResult.Ignore, "废弃退出(&D)"),
                //new CusDialogResult(DialogResult.Cancel, "aa(&D)")
            };
            var dia = CusXtraMessageBox.Show("请选择对本单据的处理，按《ESC》键放弃本次处理！", "过账提示", buttons: buttons, icon: MessageBoxIcon.Information, useEscAsCancel: true);
            if (dia == DialogResult.Yes)
                return DialogResultEx.存入草稿;
            else if (dia == DialogResult.OK)
                return DialogResultEx.保存单据;
            else if (dia == DialogResult.Ignore)
                return DialogResultEx.废弃退出;
            return DialogResultEx.取消操作;
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
