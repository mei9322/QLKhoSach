using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Text.RegularExpressions;
using System.Data.SqlClient;
using Btl_QuanLyNhaSach.Modify;
using System.Runtime.CompilerServices;
using Btl_QuanLyNhaSach.CrystalReport;

namespace Btl_QuanLyNhaSach
{
    public partial class dangky : Form
    {
        ModifyTaiKhoan modify = new ModifyTaiKhoan();

        public dangky()
        {
            InitializeComponent();
            fillCombobox();
        }

        // Sử lí sự kiện nhập các kí tự vào textbox
        public bool checkAccount(string ac) // Check mật khẩu và tài khoản
        {
            return Regex.IsMatch(ac, "^[a-zA-Z0-9]{6,24}$");
        }

        // Sử lí sự kiện ẩn hiện password
        private void checkShow_dangky_CheckedChanged(object sender, EventArgs e)
        {
            // Xử lí sự kiện ẩn hiện passwword
            if (checkShow_dangky.Checked)
            {
                txtPassword_dangky.UseSystemPasswordChar = true;
            }
            else
            {
                txtPassword_dangky.UseSystemPasswordChar = false;
            }
        }

        private void dangky_Load(object sender, EventArgs e)
        {
            try
            {
                dataGridView_TaiKhoan.DataSource = modify.Table("SELECT sTenTK AS 'Tên Tài Khoản', sMatKhau AS 'Mật Khẩu', sTen AS 'Tên Người Sử Dụng', sMaLoai AS 'Mã Loại'  FROM tblTaiKhoan");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
            DeleteTextBoxes();
            checkShow_dangky.Checked= false;
        }

        // Sử lí sự kiện nút botton Đăng ký
        private void btnDangKyTaiKhoan_Click(object sender, EventArgs e)
        {
            string sTenTk = txtUsername_dangky.Text;
            string sMatKhau = txtPassword_dangky.Text;
            string sTen = txtAccountname_dangky.Text;
            string sMaLoai = cbb_MaLoai.Text;

            // Tạo điều kiện check để đăng kí
            if (!checkAccount(sMatKhau))
            {
                MessageBox.Show("Password ít nhất 6 kí tự hoặc Password không đúng định dạng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (sTenTk.Trim() == "")
            {
                MessageBox.Show("UserName không được để trống!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (sTen.Trim() == "")
            {
                MessageBox.Show("AccountName không được để trống!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (sMaLoai.Trim() == "")
            {
                MessageBox.Show("Mã Loại không được để trống!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (!char.IsUpper(sMatKhau[0])) // kiểm tra kí tự đầu tiên có phải là kí tự viết hoa không
            {
                MessageBox.Show("Mật khẩu phải có kí tự đầu tiên viết hoa!");
                return;
            }

            try
            {
                string query = "Insert into tblTaiKhoan values ('" + sTenTk + "','" + sMatKhau + "','" + sTen + "','" + sMaLoai + "')";
                modify.Command(query);
                MessageBox.Show("Bạn đã đăng kí tài khoản thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dangky_Load(sender, e);
            }
            catch
            {
                MessageBox.Show("Tài khoản đã được đăng kí vui lòng đăng kí tài khoản khác!", "Thông báo", MessageBoxButtons.OK);
            }
        }

        // Sử lí sự kiện đổ dữ liệu vào combobox
        public void fillCombobox()
        {
            // Đổ dữ liệu vào combobox
            string query = "SELECT * FROM tblLoaiTaiKhoan";
            SqlConnection sqlConnection = Connection.GetSqlConnection();
            sqlConnection.Open();
            SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = sqlCommand;
            DataTable table = new DataTable();
            adapter.Fill(table);
            cbb_MaLoai.DataSource = table;
            cbb_MaLoai.DisplayMember = "sMaLoai";
            cbb_MaLoai.ValueMember = "sTenLoai";
        }

        // Sử lí sự kiện xóa hết các kí tự trong các ô
        private void DeleteTextBoxes()
        {
            txtUsername_dangky.Text = "";
            txtPassword_dangky.Text = "";
            txtAccountname_dangky.Text = "";
        }

        // Sử lí sự kiện xóa tài khoản
        private void btnXoaTaiKhoan_Click(object sender, EventArgs e)
        {
            // Check lớn hơn 1 dòng
            if (dataGridView_TaiKhoan.Rows.Count > 1)
            {
                string choose = dataGridView_TaiKhoan.SelectedRows[0].Cells[0].Value.ToString();
                string query = "DELETE tblTaiKhoan ";
                query += " WHERE sTenTk = '" + choose + "'";
                try
                {
                    if (MessageBox.Show("Bạn có muốn xóa không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                    {
                        modify.Command(query);
                        MessageBox.Show("Bạn đã xóa 1 tài khoản thành công!");
                        dangky_Load(sender, e);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi xóa: " + ex.Message);
                }
            }
        }

        // Sử lí click vào item trong daatagridview
        private void dataGridView_TaiKhoan_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView_TaiKhoan.Rows.Count > 1)
            {
                txtUsername_dangky.Text = dataGridView_TaiKhoan.SelectedRows[0].Cells[0].Value.ToString();
                txtPassword_dangky.Text = dataGridView_TaiKhoan.SelectedRows[0].Cells[1].Value.ToString();
                txtAccountname_dangky.Text = dataGridView_TaiKhoan.SelectedRows[0].Cells[2].Value.ToString();
                cbb_MaLoai.SelectedItem = dataGridView_TaiKhoan.SelectedRows[0].Cells[3].Value.ToString();
            }
        }

        private void btnSuaTaiKhoan_Click(object sender, EventArgs e)
        {
            string sTenTk = txtUsername_dangky.Text;
            string sMatKhau = txtPassword_dangky.Text;
            string sTen = txtAccountname_dangky.Text;
            string sMaLoai = cbb_MaLoai.Text;

            // Tạo điều kiện check để đăng kí
            if (!checkAccount(sMatKhau))
            {
                MessageBox.Show("Password ít nhất 6 kí tự hoặc Password không đúng định dạng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (sTenTk.Trim() == "")
            {
                MessageBox.Show("UserName không được để trống!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (sTen.Trim() == "")
            {
                MessageBox.Show("AccountName không được để trống!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (sMaLoai.Trim() == "")
            {
                MessageBox.Show("Mã Loại không được để trống!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (!char.IsUpper(sMatKhau[0])) // kiểm tra kí tự đầu tiên có phải là kí tự viết hoa không
            {
                MessageBox.Show("Mật khẩu phải có kí tự đầu tiên viết hoa!");
                return;
            }

            try
            {
                string query = "Update tblTaiKhoan set sTenTk = '" + sTenTk + "',sMatKhau = '" + sMatKhau + "',sTen = '" + sTen + "'," +
                    " sMaLoai = '" + sMaLoai + "' WHERE sTenTk = '" + sTenTk + "'";
                modify.Command(query);
                MessageBox.Show("Bạn đã sửa tài khoản thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dangky_Load(sender, e);
            }
            catch
            {
                MessageBox.Show("Tài khoản đã được đăng kí vui lòng đăng kí tài khoản khác!", "Thông báo", MessageBoxButtons.OK);
            }
        }

        private void inds_Click(object sender, EventArgs e)
        {
            SqlConnection conn = Connection.GetSqlConnection();
            string sql = "Select * from tblTaiKhoan WHERE sTenTk = '" + txtUsername_dangky.Text + "'";
            SqlCommand sqlCommand = new SqlCommand(sql, conn);
            conn.Open();

            SqlDataAdapter ad = new SqlDataAdapter();
            ad.SelectCommand = sqlCommand;

            DataTable dataTable = new DataTable();
            ad.Fill(dataTable);

            CrystalReport_taikhoan cryKH = new CrystalReport_taikhoan();
            cryKH.SetDataSource(dataTable);

            inhoadonban inNXB = new inhoadonban();

            inNXB.crystalReportViewer1.ReportSource = cryKH;
            inNXB.ShowDialog();


            conn.Close();
        }
    }
}
