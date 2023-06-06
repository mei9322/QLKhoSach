using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;

namespace Btl_QuanLyNhaSach
{
    public partial class dangnhap : Form
    {
        ModifyTaiKhoan modify = new ModifyTaiKhoan();
        int count = 0; // khởi tạo biến đếm

        public dangnhap()
        {
            InitializeComponent();

        }

        // Sử lí sự kiện nút button Đăng nhập
        private void btnDangNhap_Click(object sender, EventArgs e)
        {

            string sTenTk = txtUsername_dangnhap.Text.Trim();
            string sMatKhau = txtPassword_dangnhap.Text.Trim();
            string selectedLoaiTaiKhoan = comboBox1.SelectedItem.ToString();

            if (sTenTk.Trim() == "" )
            {
                MessageBox.Show("Vui lòng nhập tên và loại tài khoản ");
            }
            else if (sMatKhau.Trim() == "")
            {
                MessageBox.Show("Vui lòng nhập mật khẩu tài khoản!");
            }
            else
            {
                using (SqlConnection conn = Connection.GetSqlConnection())
                {
                    conn.Open();

                    string query = "SELECT COUNT(*) FROM tblTaiKhoan WHERE sTenTk = @sTenTk AND sMatKhau = @sMatKhau AND sMaLoai = @sMaLoai";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@sTenTk", sTenTk);
                    cmd.Parameters.AddWithValue("@sMatKhau", sMatKhau);
                    cmd.Parameters.AddWithValue("@sMaLoai", selectedLoaiTaiKhoan);

                    int matchingAccounts = (int)cmd.ExecuteScalar();
                   

                    if (selectedLoaiTaiKhoan == "admin")
                    {
                        string queryCheckNhanVien = "SELECT COUNT(*) FROM tblTaiKhoan WHERE sTenTk = @sTenTk AND sMaLoai = 'nhanvien'";
                        SqlCommand cmdCheckNhanVien = new SqlCommand(queryCheckNhanVien, conn);
                        cmdCheckNhanVien.Parameters.AddWithValue("@sTenTk", sTenTk);

                        int nhanVienAccounts = (int)cmdCheckNhanVien.ExecuteScalar();

                        if (matchingAccounts > 0 && nhanVienAccounts == 0)
                        {
                            // Đăng nhập thành công cho tài khoản admin
                            MessageBox.Show("Đăng nhập thành công với tài khoản admin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            // Ẩn form đăng nhập
                            this.Hide();

                            // Mở trang chủ và truyền thông tin tài khoản
                            trangchu trangchu = new trangchu(sTenTk, sMatKhau);
                            trangchu.ShowDialog();

                            // Hiển thị form đăng nhập và xóa trống các ô tài khoản
                            this.Show();
                            txtUsername_dangnhap.Text = "";
                            txtPassword_dangnhap.Text = "";
                        }
                        else
                        {
                            MessageBox.Show("Không thể sử dụng tài khoản nhân viên với loại tài khoản admin!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else if (selectedLoaiTaiKhoan == "nhanvien")
                    {
                        string queryCheckAdmin = "SELECT COUNT(*) FROM tblTaiKhoan WHERE sTenTk = @sTenTk AND sMaLoai = 'admin'";
                        SqlCommand cmdCheckAdmin = new SqlCommand(queryCheckAdmin, conn);
                        cmdCheckAdmin.Parameters.AddWithValue("@sTenTk", sTenTk);

                        int adminAccounts = (int)cmdCheckAdmin.ExecuteScalar();

                        if (matchingAccounts > 0 && adminAccounts == 0)
                        {
                            // Đăng nhập thành công cho tài khoản nhân viên
                            MessageBox.Show("Đăng nhập thành công với tài khoản nhân viên");
                            this.Hide();

                            // Mở trang chủ và truyền thông tin tài khoản
                            trangchu trangchu = new trangchu(sTenTk, sMatKhau);
                            trangchu.ShowDialog();

                            // Hiển thị form đăng nhập và xóa trống các ô tài khoản
                            this.Show();
                            txtUsername_dangnhap.Text = "";
                            txtPassword_dangnhap.Text = "";
                        }
                        else
                        {
                            MessageBox.Show("Không thể sử dụng tài khoản admin với loại tài khoản nhân viên!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Tên tài khoản, mật khẩu hoặc loại tài khoản không chính xác!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }

        }



                    // Đặt điều kiện đầu tiên password hình chấm tròn
                    private void dangnhap_Load(object sender, EventArgs e)
        {
            checkBox.Checked = true;
        }

        // Sử lí sự kiện ẩn hiện password
        private void checkBox_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox.Checked)
            {
                // Ẩn mật khẩu
                txtPassword_dangnhap.UseSystemPasswordChar = true;
            }
            else
            {
                // Hiện mật khẩu
                txtPassword_dangnhap.UseSystemPasswordChar = false;
            }
        }

        // Sử lí sự button Quên mật khẩu
        private void txtQuenMatKhau_Click(object sender, EventArgs e)
        {
            this.Hide();
            quenmatkhau quenmatkhau = new quenmatkhau();
            quenmatkhau.ShowDialog();
            quenmatkhau = null;
            this.Show();
        }

        // Sử lí sự kiện khi bấm icon x sẽ tắt cả ứng dụng
        private void dangnhap_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                Application.Exit();
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {
            dangky DK = new dangky();
            DK.ShowDialog();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedLoaiTaiKhoan = comboBox1.SelectedItem.ToString();

            if (selectedLoaiTaiKhoan == "admin")
            {
                // Hiển thị các trường cần thiết cho tài khoản admin
               /* *//*labelTenTk.Visible = true;
                textBoxTenTk.Visible = true;
                labelMatKhau.Visible = true;
                textBoxMatKhau.Visible = true;
                labelTen.Visible = false;
                textBoxTen.Visible = false; *//**/
            }
            else if (selectedLoaiTaiKhoan == "nhân viên")
            {
                /**//* // Hiển thị các trường cần thiết cho tài khoản nhân viên
                 labelTenTk.Visible = true;
                textBoxTenTk.Visible = true;
                labelMatKhau.Visible = true;
                textBoxMatKhau.Visible = true;
                labelTen.Visible = true;
                textBoxTen.Visible = true; *//**/
            }
            
        }

        /*private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedLoaiTaiKhoan = comboBox1.SelectedItem.ToString();

            if (selectedLoaiTaiKhoan == "admin")
            {
                // Hiển thị các trường cần thiết cho tài khoản admin
                *//*labelTenTk.Visible = true;
                textBoxTenTk.Visible = true;
                labelMatKhau.Visible = true;
                textBoxMatKhau.Visible = true;
                labelTen.Visible = false;
                textBoxTen.Visible = false;*//*
            }
            else if (selectedLoaiTaiKhoan == "nhân viên")
            {
               *//* // Hiển thị các trường cần thiết cho tài khoản nhân viên
                labelTenTk.Visible = true;
                textBoxTenTk.Visible = true;
                labelMatKhau.Visible = true;
                textBoxMatKhau.Visible = true;
                labelTen.Visible = true;
                textBoxTen.Visible = true;*//*
            }*/
        //}
    }
}
