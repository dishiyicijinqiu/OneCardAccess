using FengSharp.OneCardAccess.Domain.BSSModule.Entity;
using FengSharp.OneCardAccess.Domain.BSSModule.Service.Interface;
using FengSharp.OneCardAccess.Infrastructure;
using FengSharp.OneCardAccess.Infrastructure.Base;
using FengSharp.OneCardAccess.Infrastructure.Events;
using FengSharp.OneCardAccess.Infrastructure.Exceptions;
using FengSharp.OneCardAccess.Infrastructure.WinForm.Base;
using FengSharp.OneCardAccess.Infrastructure.WinForm.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using FengSharp.OneCardAccess.Infrastructure.WinForm;


namespace FengSharp.OneCardAccess.Presentation.IntegeatedManage.BSS
{
    public partial class ProductSNInputUserControl : ProductSNInputUserControl_Design
    {
        public ProductSNInputUserControl()
        {
            InitializeComponent();
        }

        private void ProductSNInputUserControl_Load(object sender, EventArgs e)
        {
            if (this.DesignMode)
                return;
            if (System.Diagnostics.Process.GetCurrentProcess().ProcessName == "devenv")
                return;
            CreateFacade();
        }

        private void CreateFacade()
        {
            if (this.Facade == null)
                this.Facade = new ProductSNInputUserControlFacade(this);
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                var entitys = this.gridView1.GetSelectedRows().Select
                    (
                        t => this.gridView1.GetRow(t) as SNInputEntity
                    ).ToList();
                if (entitys.Count <= 0)
                {
                    MessageBoxEx.Info(FengSharp.OneCardAccess.Infrastructure.ResourceMessages.List_AtLeastOne);
                    return;
                }
                this.bindingSource1.RemoveEntityIfDataSourceIsList<SNInputEntity>(entitys);
            }
            catch (Exception ex)
            {
                MessageBoxEx.Error(ex);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            var data = bindingSource1.DataSource as List<SNInputEntity>;
            data.Clear();
            bindingSource1.ResetBindings(false);
        }
        public SNInputEntity[] EntityResults
        {
            get
            {
                return (bindingSource1.DataSource as List<SNInputEntity>).ToArray();
            }
        }

        public void BindData(SNInputEntity[] entitys)
        {
            this.bindingSource1.DataSource = new List<SNInputEntity>(entitys);
            this.gridControl1.DataSource = bindingSource1;
        }
        internal void ResetValue()
        {
            this.txtStart.EditValue = string.Empty;
            this.txtEnd.EditValue = string.Empty;
            this.txtStart.Focus();
        }

        private void txtEnd_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == System.Windows.Forms.Keys.Enter)
                {
                    string strStart = this.txtStart.Text;
                    string strEnd = this.txtEnd.Text;
                    string strbn, errmsg;
                    var results = this.Facade.GetInputSns(strStart, strEnd, out strbn, out errmsg);
                    if (!string.IsNullOrWhiteSpace(errmsg))
                    {
                        MessageBoxEx.Info(errmsg);
                        return;
                    }
                    var data = this.bindingSource1.DataSource as List<SNInputEntity>;
                    if (data.Count > 0)
                    {
                        if (strbn != data[0].BN)
                        {
                            MessageBoxEx.Info("检测到不同的批号");
                            return;
                        }
                    }
                    foreach (var item in results)
                    {
                        var firstsamedata = data.FirstOrDefault(t => t.SN == item);
                        if (firstsamedata == null)
                        {
                            data.Add(new SNInputEntity()
                            {
                                BN = strbn,
                                SN = item,
                                Remark = string.Empty,
                                SortNo = data.Count
                            });
                        }
                    }
                    bindingSource1.ResetBindings(false);
                }
            }
            catch (Exception ex)
            {
                MessageBoxEx.Error(ex);
            }
        }
    }
    public class ProductSNInputUserControl_Design : Base_UserControl<ProductSNInputUserControlFacade>
    {

    }
    public class ProductSNInputUserControlFacade : ActualBase<ProductSNInputUserControl>
    {
        public ProductSNInputUserControlFacade(ProductSNInputUserControl actual)
            : base(actual) { }
        internal bool VerifySN(string strsn, out string strbn)
        {
            strbn = string.Empty;
            if (string.IsNullOrWhiteSpace(strsn))
                return false;
            var firstrule = PFBNSNRule.PSNRuleEntitys.FirstOrDefault(t => t.TotalLen == strsn.Length);
            if (firstrule == null)
                return false;
            strbn = strsn.Substring(firstrule.BNStartPos - 1, (firstrule.BNEndPos - firstrule.BNStartPos + 1));
            return true;
        }
        internal List<string> GetInputSns(string strStart, string strEnd, out string sbn, out string errmsg)
        {
            if (string.IsNullOrWhiteSpace(strStart) && string.IsNullOrWhiteSpace(strEnd))
                throw new BusinessException("序列号录入为空");
            if (string.IsNullOrWhiteSpace(strStart))
            {
                if (!this.VerifySN(strEnd, out sbn))
                {
                    errmsg = "序列号录入不符合规则";
                    return null;
                }
                errmsg = string.Empty;
                return new List<string>() { strEnd };
            }
            if (string.IsNullOrWhiteSpace(strEnd))
            {
                if (!this.VerifySN(strStart, out sbn))
                {
                    errmsg = "序列号录入不符合规则";
                    return null;
                }
                errmsg = string.Empty;
                return new List<string>() { strStart };
            }
            if (strStart.Length != strEnd.Length)
            {
                errmsg = "开始序列号与结束序列号长度不一致";
                sbn = string.Empty;
                return null;
            }
            if (!this.VerifySN(strStart, out sbn))
            {
                errmsg = "序列号录入不符合规则";
                return null;
            }
            string sbn1;
            if (!this.VerifySN(strEnd, out sbn1))
            {
                errmsg = "序列号录入不符合规则";
                return null;
            }
            if (sbn != sbn1)
            {
                errmsg = "两次输入具有不同的批号";
                return null;
            }
            int firstdiffindex = -1;
            for (int i = 0; i < strStart.Length; i++)
            {
                if (strStart[i] != strEnd[i])
                {
                    firstdiffindex = i;
                    break;
                }
            }
            if (firstdiffindex == -1)
            {
                errmsg = string.Empty;
                return new List<string>() { strStart };
            }
            int difflen = strStart.Length - firstdiffindex;
            if (difflen > 6)
            {
                errmsg = "序列号不同长度超过6位";
                return null;
            }
            int num1, num2;
            if (!int.TryParse(strStart.Substring(firstdiffindex), out num1))
            {
                errmsg = "开始序列号批量录入字符串不为数字";
                return null;
            }
            if (!int.TryParse(strEnd.Substring(firstdiffindex), out num2))
            {
                errmsg = "结束序列号批量录入字符串不为数字";
                return null;
            }
            string strsamestring = strStart.Substring(0, firstdiffindex);
            char paddingChar = '0';
            var result = new List<string>();
            for (int i = num1; i <= num2; i++)
            {
                result.Add(string.Format("{0}{1}", strsamestring, i.ToString().PadLeft(difflen, paddingChar)));
            }
            errmsg = string.Empty;
            return result;
        }
    }
}
