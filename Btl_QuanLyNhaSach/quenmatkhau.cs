using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Btl_QuanLyNhaSach
{
    public partial class quenmatkhau : Form
    {
        ModifyTaiKhoan modify = new ModifyTaiKhoan();

        public quenmatkhau()
        {
            InitializeComponent();
            label_KetQua.Text = "";
        }

        // Sử lí sự kiện nút button Lấy mật khẩu
        private void btnLayMatKhau_Click(object sender, EventArgs e)
        {
            string username = txtUsername_quenmatkhau.Text;
            if (username.Trim() == "")
            {
                MessageBox.Show("Vui lòng nhập username!");
            }
            else
            {
                string query = "SELECT * FROM tblTaiKhoan WHERE sTenTK = N'" + username + "' and sTenTk <> 'adminchu'";
                if (modify.TaiKhoans(query).Count != 0)
                {
                    label_KetQua.ForeColor = Color.Blue;
                    label_KetQua.Text = "Mật khẩu là: " + modify.TaiKhoans(query)[0].SMatKhau;
                }
                else
                {
                    label_KetQua.ForeColor = Color.Red;
                    label_KetQua.Text = "Tài khoản này chưa đăng kí! ";
                }
            }
        }

        // Sử lí sự kiện click là lable quay lại màn đăng nhập
        private void quayLaiMan_DangNhap_Click(object sender, EventArgs e)
        {
            this.Hide();
            dangnhap dangnhap = new dangnhap();
            dangnhap.ShowDialog();
            dangnhap = null;
            this.Show();
        }
    }
}
