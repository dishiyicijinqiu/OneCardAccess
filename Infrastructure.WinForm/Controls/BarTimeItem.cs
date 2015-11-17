using DevExpress.XtraBars;
using System;

namespace FengSharp.OneCardAccess.Infrastructure.WinForm.Controls
{
    public class BarTimeItem : BarStaticItem
    {
        private System.Windows.Forms.Timer timer1;
        public BarTimeItem()
            : base()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.timer1 = new System.Windows.Forms.Timer();
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
        }
        static DateTime baseTime = DateTime.Now;
        static DateTime serverTime = DateTime.Now;
        public static DateTime ServerTime
        {
            set
            {
                baseTime = DateTime.Now;
                serverTime = value;
            }
        }
        private void timer1_Tick(object sender, System.EventArgs e)
        {
            this.Caption = serverTime.Add(DateTime.Now - baseTime).ToString("yyyy年MM月dd日 HH:mm:ss");
        }
    }
}
