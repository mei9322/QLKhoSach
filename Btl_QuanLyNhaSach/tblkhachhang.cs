using Btl_QuanLyNhaSach.CrystalReport;
using Btl_QuanLyNhaSach.Modify;
using Btl_QuanLyNhaSach.Object;
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

namespace Btl_QuanLyNhaSach
{
    public partial class tblkhachhang : Form
    {
        //Khởi tạo 
        ModifyAll modifyKhachHang = new ModifyAll();
        KhachHang kh;

        public tblkhachhang()
        {
            InitializeComponent();
        }

        // Sử lí sự kiện đổ dữ liệu từ sql vào datagridview
        private void tblkhachhang_Load(object sender, EventArgs e)
        {
            try
            {
                dataGridView_KhachHang.DataSource = modifyKhachHang.Table("SELECT sMaKH AS 'Mã Khách Hàng', sTenKH AS 'Tên Khách Hàng', sDiachi AS 'Địa Chỉ', sSdt AS 'Số Điện Thoại', sEmail AS 'Email' FROM tblKhachHang");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
            DeleteTextBoxes();
        }

        // Sử lí sự kiện nhập vào textbox số lượng chỉ nhận số không nhận kí tự chữ
        private void iSoLuong_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Sử lí sự kiện chỉ được nhập số
            if (char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        // Sử lí sự kiện xóa hết các kí tự trong các ô
        private void DeleteTextBoxes()
        {
            sTenKH.Text = "";
            sSDT.Text = "";
            sMaKH.Text = "";
            sDiaChi.Text = "";
            sEmail.Text = "";
        }

        // Sử lí sự kiện nhập không được để trống
        private bool CheckText()
        {
            if (sTenKH.Text == "" || sSDT.Text == "" || sDiaChi.Text == "" || sEmail.Text == ""
                || sMaKH.Text == "" )
            {
                MessageBox.Show("Mời bạn nhập đầy đủ thông tin!");
                return false;
            }

            return true;
        }

        // Sử lí thêm dữ liệu vào đối tượng khách hàng
        private void GetValuesTextBox()
        {
            string smaKhachHang = sMaKH.Text;
            string stenKhachHang = sTenKH.Text;
            string ssdt = sSDT.Text;
            string sdiaChi = sDiaChi.Text;
            string semail = sEmail.Text;
            kh = new KhachHang(smaKhachHang, stenKhachHang, sdiaChi, ssdt, semail);
        }

        // Sử lí sự kiện xóa một khách hàng
        private void btnXoaKhachHang_Click(object sender, EventArgs e)
        {
            // Check lớn hơn 1 dòng
            if (dataGridView_KhachHang.Rows.Count > 1)
            {
                string choose = dataGridView_KhachHang.SelectedRows[0].Cells[0].Value.ToString();
                string query = "DELETE tblKhachHang ";
                query += " WHERE sMaKH = '" + choose + "'";
                try
                {
                    if (MessageBox.Show("Bạn có muốn xóa không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                    {
                        modifyKhachHang.Command(query);
                        MessageBox.Show("Bạn đã xóa 1 khách hàng thành công!");
                        tblkhachhang_Load(sender, e);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi xóa: " + ex.Message);
                }
            }
        }

        // Sử lí sự kiện thêm một khách hàng
        private void btnThemKhachHang_Click(object sender, EventArgs e)
        {
            if (CheckText())
            {
                SqlConnection conn = Connection.GetSqlConnection();
                string sql = "SELECT sMaKH FROM tblKhachHang WHERE sMaKH = @sMaKH";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@sMaKH", sMaKH.Text);
                conn.Open();
                string smaKH = (string)cmd.ExecuteScalar();
                if (smaKH != null)
                {
                    MessageBox.Show("Mã khách hàng đã tồn tại");
                    return;
                }

                GetValuesTextBox();
                string query = "INSERT INTO tblKhachHang values ('" + kh.SMaKH + "', N'" + kh.STenKH + "', N'" + kh.SDiaChi + "'," +
                " '" + kh.SSdt + "' , N'" + kh.SEmail + "' ) ";
                try
                {
                    if (MessageBox.Show("Bạn có muốn thêm vào không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                    {
                        modifyKhachHang.Command(query);
                        MessageBox.Show("Bạn đã thêm 1 khách hàng thành công!");
                        tblkhachhang_Load(sender, e);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi thêm: " + ex.Message);
                }
            }
        }

        // Sử lí sự kiện cập nhật thông tin của một khách hàng
        private void btnCapNhatKhachHang_Click(object sender, EventArgs e)
        {
            /*if (CheckText())
            {
                SqlConnection conn = Connection.GetSqlConnection();
                string sql = "SELECT sMaKH FROM tblKhachHang WHERE sMaKH = @sMaKH";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@sMaKH", sMaKH.Text);
                conn.Open();
                string smaKH = (string)cmd.ExecuteScalar();
                if (smaKH != null)
                {
                    MessageBox.Show("Mã khách hàng đã tồn tại");
                    return;
                }


                GetValuesTextBox();
                string query = "UPDATE tblKhachHang SET sMaKH = '" + kh.SMaKH + "', sTenKH = N'" + kh.STenKH + "'," +
                " sDiaChi = N'" + kh.SDiaChi + "', sSdt = '" + kh.SSdt + "'" +
                ", sEmail = '" + kh.SEmail + "' ";
                query += "WHERE sMaKH = '" + kh.SMaKH + "'";
                try
                {
                    if (MessageBox.Show("Bạn có muốn sửa lại dữ liệu không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                    {
                        modifyKhachHang.Command(query);
                        MessageBox.Show("Bạn đã sửa 1 thông tin của khách hàng thành công!");
                        tblkhachhang_Load(sender, e);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi sửa: " + ex.Message);
                }
            }*/
            if (CheckText())
            {
                SqlConnection conn = Connection.GetSqlConnection();
                string sqlCheck = "SELECT COUNT(*) FROM tblKhachHang WHERE sMaKH = @sMaKH";
                SqlCommand cmdCheck = new SqlCommand(sqlCheck, conn);
                cmdCheck.Parameters.AddWithValue("@sMaKH", sMaKH.Text);
                conn.Open();
                int count = (int)cmdCheck.ExecuteScalar();
                if (count == 0)
                {
                    MessageBox.Show("Mã khách hàng không tồn tại");
                    return;
                }

                GetValuesTextBox();
                string query = "UPDATE tblKhachHang SET sTenKH = N'" + kh.STenKH + "', sDiaChi = N'" + kh.SDiaChi + "', sSdt = '" + kh.SSdt + "', sEmail = '" + kh.SEmail + "' ";
                query += "WHERE sMaKH = @sMaKH";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@sMaKH", kh.SMaKH);
                try
                {
                    if (MessageBox.Show("Bạn có muốn sửa lại dữ liệu không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                    {
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Bạn đã sửa 1 thông tin của khách hàng thành công!");
                        tblkhachhang_Load(sender, e);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi sửa: " + ex.Message);
                }

            }

        }

        // Sử lí sự kiện cellclick trong datagridview
        private void dataGridView_KhachHang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView_KhachHang.Rows.Count > 1)
            {
                sMaKH.Text = dataGridView_KhachHang.SelectedRows[0].Cells[0].Value.ToString();
                sTenKH.Text = dataGridView_KhachHang.SelectedRows[0].Cells[1].Value.ToString();
                sDiaChi.Text = dataGridView_KhachHang.SelectedRows[0].Cells[2].Value.ToString();
                sSDT.Text = dataGridView_KhachHang.SelectedRows[0].Cells[3].Value.ToString();
                sEmail.Text = dataGridView_KhachHang.SelectedRows[0].Cells[4].Value.ToString();
            }
        }

        private void textBox_TimKiemKhachHang_TextChanged(object sender, EventArgs e)
        {
            string name = textBox_TimKiemKhachHang.Text.Trim();
            if (name == "")
            {
                tblkhachhang_Load(sender, e);
            }
            else
            {
                string query = "SELECT sMaKH AS 'Mã Khách Hàng', sTenKH AS 'Tên Khách Hàng', sDiachi AS 'Địa Chỉ', sSdt AS 'Số Điện Thoại', sEmail AS 'Email' FROM tblKhachHang WHERE sMaKH LIKE N'%" + name + "%'";
                dataGridView_KhachHang.DataSource = modifyKhachHang.Table(query);
            }
        }

        private void inds_Click(object sender, EventArgs e)
        {
            SqlConnection conn = Connection.GetSqlConnection();
            string sql = "Select * from tblKhachHang";
            SqlCommand sqlCommand = new SqlCommand(sql, conn);
            conn.Open();

            SqlDataAdapter ad = new SqlDataAdapter();
            ad.SelectCommand = sqlCommand;

            DataTable dataTable = new DataTable();
            ad.Fill(dataTable);

            CrystalReport_sach cryKH = new CrystalReport_sach();
            cryKH.SetDataSource(dataTable);

            inhoadonban inNXB = new inhoadonban();

            inNXB.crystalReportViewer1.ReportSource = cryKH;
            inNXB.ShowDialog();


            conn.Close();
        }
    }
}
