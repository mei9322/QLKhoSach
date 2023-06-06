using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;
using CrystalDecisions.CrystalReports.Engine;
using Btl_QuanLyNhaSach.CrystalReport;

namespace Btl_QuanLyNhaSach
{
    public partial class trangchu : Form
    {
        bool sidebarExpand;
        bool hoadonCollapse;
        bool isThoat;

        public trangchu(string stentk, string smatkhau)
        {
            InitializeComponent();
            
            string query = "SELECT sMaLoai FROM tblTaiKhoan WHERE sTenTk = @stentk AND sMatKhau = @smatkhau";
            string connectionString = @"Data Source=DESKTOP-IHLHQSB\SQLEXPRESS;Initial Catalog=QuanLyNhaSach;Integrated Security=True";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@stentk", stentk);
                    command.Parameters.AddWithValue("@smatkhau", smatkhau);
                    string sMaLoai = (string)command.ExecuteScalar();

                    if (sMaLoai == "admin")
                    {
                        button_TaiKhoan.Visible = true;
                        btnNhanVien.Visible = true;
                    }
                    else
                    {
                        button_TaiKhoan.Visible = false;
                        btnNhanVien.Visible = false;
                    }    

                }
            }


        }



        // Sử lí sự kiện đóng mở sideBar
        private void sidebarTimer_Tick(object sender, EventArgs e)
        {
            if (sidebarExpand)
            {
                sidebar.Width -= 10;
                if (sidebar.Width == sidebar.MinimumSize.Width)
                {
                    sidebarExpand = false;
                    sidebarTimer.Stop();
                }     
            }
            else
            {
                sidebar.Width += 10;
                if (sidebar.Width == sidebar.MaximumSize.Width)
                {
                    sidebarExpand = true;
                    sidebarTimer.Stop();
                }    
            }
        }

        // Bắt sự kiện click vào logo
        private void logo_button_Click(object sender, EventArgs e)
        {
            sidebarTimer.Start();
        }

        private Form currentFormChild;

        // Sử lí sự kiện bấm vào icon logo
        private void OpenChildForm(Form childForm)
        {
            if (currentFormChild != null)
            {
                currentFormChild.Close();
            }    
            currentFormChild= childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panel_Body.Controls.Add(childForm);
            panel_Body.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }


        // Chuyển sang form hóa đơn nhập
        private void chitiethoadonnhap_Click(object sender, EventArgs e)
        {
            OpenChildForm(new tblchitiethoadonnhap());
        }

        // Chuyển sang form hóa đơn bán
        private void chitiethoadonban_Click(object sender, EventArgs e)
        {
            OpenChildForm(new tblchitiethoadonban());
        }

        // Chuyển sang form tài khoản
        private void button_TaiKhoan_Click(object sender, EventArgs e)
        {
            OpenChildForm(new dangky());
        }

        // Sử lí sự kiện click vào button hóa đơn
        private void button_HoaDon_Click(object sender, EventArgs e)
        {
            timerHoaDon.Start();
        }

        // Sử lí sự kiện bấm và button hóa đơn sẽ đổ ra hai button hoadonban và hoadonnhap
        private void timerHoaDon_Tick(object sender, EventArgs e)
        {
            if (hoadonCollapse)
            {
                panelHoaDon.Height += 10;
                if (panelHoaDon.Height == panelHoaDon.MaximumSize.Height)
                {
                    hoadonCollapse = false;
                    timerHoaDon.Stop();
                }
            }
            else
            {
                panelHoaDon.Height -= 10;
                if (panelHoaDon.Height == panelHoaDon.MinimumSize.Height)
                {
                    hoadonCollapse = true;
                    timerHoaDon.Stop();
                }
            }    
        }

        // Chuyển sang form hóa đơn nhập
        private void button_hoadonnhap_Click(object sender, EventArgs e)
        {
            OpenChildForm(new tblhoadonnhap());
        }

        // Chuyển sang form hóa đơn bán
        private void button_hoadonban_Click(object sender, EventArgs e)
        {
            OpenChildForm(new tblhoadonban());
        }

        // Chuyển sang form danh sách hóa đơn nhập
        private void dsHoaDonNhap_Click(object sender, EventArgs e)
        {
            OpenChildForm(new tbldanhsachhoadonnhap());
        }

        // Chuyển sang form danh sách hóa đơn xuất
        private void dsHoaDonXuat_Click(object sender, EventArgs e)
        {
            OpenChildForm(new tbldanhsachhoadonban());
        }

        // Chuyển sang form thống kê
        private void ThongKe_Click(object sender, EventArgs e)
        {
            OpenChildForm(new tblthongke());
        }

        // Bắt sự kiện đăng xuất sẽ chuyển sang màn hình đăng nhập
        private void button1_Click(object sender, EventArgs e)
        {
            isThoat = false;
            this.Close();
            dangnhap dn = new dangnhap();
            dn.Show();
        }

        // Bắt sự kiện khi bấm icon x sẽ chuyển sang màn hình đăng nhập
        private void trangchu_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (isThoat)
            {
                Application.Exit();
            }
        }

        // Chuyển sang form khách hàng
        private void button_KhachHang_Click(object sender, EventArgs e)
        { 
            OpenChildForm(new tblkhachhang());
        }

        // Chuyển sang form tài khoản
        private void button_TaiKhoan_Click_1(object sender, EventArgs e)
        {
            OpenChildForm(new dangky());
        }

        private void button_Sach_Click(object sender, EventArgs e)
        {
            OpenChildForm(new tblsach());
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
           // OpenChildForm(new tblthongke());
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            OpenChildForm(new tblchitiethoadonnhap());
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            OpenChildForm(new tblchitiethoadonban());
        }

        private void toolStripMenuItem6_Click(object sender, EventArgs e)
        {
            OpenChildForm(new thongketheonam());
        }

        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {

        }

        private void InBáoCáoTimTheoTênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenChildForm(new thongkeloinhuam());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenChildForm(new tblNhanVien());
        }
    }
}


