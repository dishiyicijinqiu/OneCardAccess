using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FengSharp.OneCardAccess.Infrastructure.WinForm.Controls
{
    public partial class CreateModifiyControl : DevExpress.XtraEditors.XtraUserControl
    {
        public CreateModifiyControl()
        {
            InitializeComponent();
        }
        public string CreateUserId { get; set; }
        public string CreateUserName { get { return txtCreate.Text; } set { txtCreate.Text = value; } }
        public DateTime CreateDate
        {
            get
            {
                if (this.txtCreateDate.EditValue is DateTime)
                    return (DateTime)this.txtCreateDate.EditValue;
                return DateTime.MinValue;
            }
            set
            {
                this.txtCreateDate.EditValue = value;
            }
        }
        public string LastModifyUserId { get; set; }
        public string LastModUserName { get { return txtLastModUser.Text; } set { txtLastModUser.Text = value; } }
        public DateTime LastModifyDate
        {
            get
            {
                if (this.txtLastModDate.EditValue is DateTime)
                    return (DateTime)this.txtLastModDate.EditValue;
                return DateTime.MinValue;
            }
            set
            {
                this.txtLastModDate.EditValue = value;
            }
        }
        public void SetData(string createuserid, string createusername, DateTime createdate, string lastmoduserid, string lastmodusername, DateTime lastmoddate)
        {
            this.CreateUserId = createuserid;
            this.CreateUserName = createusername;
            this.CreateDate = createdate;
            this.LastModifyUserId = lastmoduserid;
            this.LastModUserName = lastmodusername;
            this.LastModifyDate = lastmoddate;
        }

        public string CurrentUserId
        {
            get
            {
                //return AuthPrincipal.CurrentAuthPrincipal.Identity.UserId;
                return ApplicationContext.Current.AuthPrincipal.Identity.UserId;
            }
        }
        public DateTime CurrentDateTime
        {
            get
            {
                return DateTime.Now;
            }
        }

        //private bool _readonly;
        //public bool ReadOnly
        //{
        //    get
        //    {
        //        return _readonly;
        //    }
        //    set
        //    {
        //        this.txtCreateDate.ReadOnly = value;
        //        this.txtCreate.ReadOnly = value;
        //        this.txtLastModDate.ReadOnly = value;
        //        this.txtLastModUser.ReadOnly = value;
        //        _readonly = value;
        //    }
        //}
    }
}
