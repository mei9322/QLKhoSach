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
    public partial class tblNhanVien : Form
    {
        ModifyAll modify = new ModifyAll();
        NhanVien nhanvien;


        public tblNhanVien()
        {
            InitializeComponent();
        }

       

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (CheckText()) // Kiểm tra dữ liệu đã nhập
            {
                SqlConnection conn = Connection.GetSqlConnection();

                string sqlCheck = "SELECT COUNT(*) FROM tblNhanVien WHERE sMaNV = @sMaNV";
                SqlCommand cmdCheck = new SqlCommand(sqlCheck, conn);
                cmdCheck.Parameters.AddWithValue("@sMaNV", txtMaNV.Text);

                try
                {
                    conn.Open();
                    int count = (int)cmdCheck.ExecuteScalar();
                    if (count > 0)
                    {
                        MessageBox.Show("Mã nhân viên đã tồn tại!");
                        return;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi kiểm tra mã nhân viên: " + ex.Message);
                    return;
                }
                finally
                {
                    conn.Close();
                }

                GetValuesTextBox(); // Lấy giá trị từ các TextBox

                string queryInsert = "INSERT INTO tblNhanVien (sMaNV, sTenNV, sDiaChi, sSDT, sTenLoai) VALUES (@sMaNV, @sTenNV, @sDiaChi, @sSDT, @sTenLoai)";
                SqlCommand cmdInsert = new SqlCommand(queryInsert, conn);
                cmdInsert.Parameters.AddWithValue("@sMaNV", nhanvien.SMaNV);
                cmdInsert.Parameters.AddWithValue("@sTenNV", nhanvien.STenNV);
                cmdInsert.Parameters.AddWithValue("@sDiaChi", nhanvien.SDiaChi);
                cmdInsert.Parameters.AddWithValue("@sSDT", nhanvien.SSDT);
                cmdInsert.Parameters.AddWithValue("@sTenLoai", nhanvien.STenLoai);

                try
                {
                    conn.Open();
                    cmdInsert.ExecuteNonQuery();
                    MessageBox.Show("Thêm nhân viên thành công!");
                    tblNhanVien_Load(sender, e); // Tải lại dữ liệu trong DataGridView
                    DeleteTextBoxes(); // Xóa các TextBox sau khi thêm thành công
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi thêm nhân viên: " + ex.Message);
                }
                finally
                {
                    conn.Close();
                }
            }

        }

        private void DeleteTextBoxes()
        {
            txtTenNv.Text = "";
            txtMaNV.Text = "";
            txtDiaChi.Text = "";
            txtSDT.Text = "";
            txtTenLoai.Text = "";
        }

        private void tblNhanVien_Load(object sender, EventArgs e)
        {
            try
            {
                dataGridView_NhanVien.DataSource = modify.Table("SELECT sMaNV AS 'Mã Nhân Viên', sTenNV AS 'Tên Nhân Viên', sDiaChi AS 'Địa Chỉ', sSDT AS 'Số Điện Thoại', sTenLoai AS 'Tên Loại' FROM tblNhanVien");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
            DeleteTextBoxes();
        }

        private bool CheckText()
        {
            if (txtMaNV.Text == "" || txtTenNv.Text == "" || txtSDT.Text == "" || txtDiaChi.Text == "" || txtTenLoai.Text == "")
            {
                MessageBox.Show("Mời bạn nhập đầy đủ thông tin!");
                return false;
            }

            return true;
        }

        // Sử lí thêm dữ liệu vào đối tượng nhân viên
        private void GetValuesTextBox()
        {
            string smaNV = txtMaNV.Text;
            string stenNV = txtTenNv.Text;
            string sdiaChi = txtDiaChi.Text;
            string ssdt = txtSDT.Text;
            string stenLoai = txtTenLoai.Text;
            nhanvien = new NhanVien(smaNV, stenNV, sdiaChi, ssdt, stenLoai);
        }


        // Sử lí sự kiện xóa nhân viên
        private void btnXoaNV_Click(object sender, EventArgs e)
        {
            
        }

        private void btnXoaNV_Click_1(object sender, EventArgs e)
        {
            // Check lớn hơn 1 dòng 
            if (dataGridView_NhanVien.Rows.Count > 0)
            {
                string choose = dataGridView_NhanVien.SelectedRows[0].Cells[0].Value.ToString();
                string query = "DELETE tblNhanVien ";
                query += " WHERE sMaNV = '" + choose + "'";
                try
                {
                    if (MessageBox.Show("Bạn có muốn xóa không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                    {
                        modify.Command(query);
                        MessageBox.Show("Bạn đã xóa 1 nhân viên thành công!");
                        tblNhanVien_Load(sender, e);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi xóa: " + ex.Message);
                }
            }
        }

        private void btnupdate_Click(object sender, EventArgs e)
        {
            // Kiểm tra nếu chưa nhập sMaNV
            if (string.IsNullOrEmpty(txtMaNV.Text))
            {
                MessageBox.Show("Vui lòng nhập mã nhân viên!");
                return;
            }

            if (CheckText())
            {
                SqlConnection conn = Connection.GetSqlConnection();
                string sql = "SELECT COUNT(*) FROM tblNhanVien WHERE sMaNV = @sMaNV";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@sMaNV", txtMaNV.Text);
                conn.Open();
                int count = (int)cmd.ExecuteScalar();
                if (count == 0)
                {
                    MessageBox.Show("Mã nhân viên không tồn tại!");
                    return;
                }

                GetValuesTextBox();
                string query = "UPDATE tblNhanVien SET sTenNV = @sTenNV, sDiaChi = @sDiaChi, sSDT = @sSDT, sTenLoai = @sTenLoai WHERE sMaNV = @sMaNV";
                SqlCommand updateCmd = new SqlCommand(query, conn);
                updateCmd.Parameters.AddWithValue("@sTenNV", nhanvien.STenNV);
                updateCmd.Parameters.AddWithValue("@sDiaChi", nhanvien.SDiaChi);
                updateCmd.Parameters.AddWithValue("@sSDT", nhanvien.SSDT);
                updateCmd.Parameters.AddWithValue("@sTenLoai", nhanvien.STenLoai);
                updateCmd.Parameters.AddWithValue("@sMaNV", nhanvien.SMaNV);

                try
                {
                    if (MessageBox.Show("Bạn có muốn sửa lại dữ liệu không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                    {
                        updateCmd.ExecuteNonQuery();
                        MessageBox.Show("Bạn đã sửa thông tin nhân viên thành công!");
                        tblNhanVien_Load(sender, e);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi sửa: " + ex.Message);
                }
            }
        }

        private void dataGridView_NhanVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // Kiểm tra hàng được chọn có hợp lệ
            {
                DataGridViewRow row = dataGridView_NhanVien.Rows[e.RowIndex];

                // Lấy giá trị từ ô được chọn
                string maNV = row.Cells["Mã Nhân Viên"].Value.ToString();
                string tenNV = row.Cells["Tên Nhân Viên"].Value.ToString();
                string diaChi = row.Cells["Địa Chỉ"].Value.ToString();
                string sdt = row.Cells["Số Điện Thoại"].Value.ToString();
                string tenLoai = row.Cells["Tên Loại"].Value.ToString();

                // Hiển thị thông tin trong các TextBox hoặc điều chỉnh các giá trị khác theo nhu cầu
                txtMaNV.Text = maNV;
                txtTenNv.Text = tenNV;
                txtDiaChi.Text = diaChi;
                txtSDT.Text = sdt;
                txtTenLoai.Text = tenLoai;
            }
        }
    }
}
