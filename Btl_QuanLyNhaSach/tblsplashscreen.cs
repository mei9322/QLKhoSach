using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Btl_QuanLyNhaSach
{
    public partial class tblsplashscreen : Form
    {
        public tblsplashscreen()
        {
            InitializeComponent();
        }

        private void batdau_Load(object sender, EventArgs e)
        {
            panel_load.Width = 0;
            timer.Start();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            for (int i = 0; i < 99; i++)
            {
                panel_load.Width = panel_load.Width + 6;
                Thread.Sleep(20);
            }
            timer.Stop();
            dangnhap dangnhap = new dangnhap();
            dangnhap.ShowDialog();

        }
    }
}
