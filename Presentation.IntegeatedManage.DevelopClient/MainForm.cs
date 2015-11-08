using System;
using System.Windows.Forms;

namespace FengSharp.OneCardAccess.Presentation.IntegeatedManage.DevelopClient
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                this.Visible = false;
                LoginForm loginForm = new LoginForm();
                var result = loginForm.ShowDialog();
                if (result == DialogResult.OK)
                {
                    this.Visible = true;
                }
                else
                {
                    Application.Exit();
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
                Application.Exit();
            }
        }

        private void btnMenuSet_Click(object sender, EventArgs e)
        {
            new MenuManageForm().ShowDialog();
        }

        private void btnGenerateMenu_Click(object sender, EventArgs e)
        {
            new MenuLoadForm().ShowDialog();
        }

        private void btnActionSet_Click(object sender, EventArgs e)
        {
            new ActionManageForm().ShowDialog();
        }
    }
}
