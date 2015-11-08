using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FengSharp.OneCardAccess.Server.IntegeatedManageSupport
{
    public partial class Form1 : Form
    {
        private string ServerId = System.Configuration.ConfigurationManager.AppSettings["ServerId"];
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
            }
            catch (Exception ex)
            {
                ex.ToString();
                Application.Exit();
            }
        }
    }
}
