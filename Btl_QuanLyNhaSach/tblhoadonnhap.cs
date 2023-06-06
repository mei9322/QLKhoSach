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
    public partial class tblhoadonnhap : Form
    {
        ModifyAll modify = new ModifyAll();
        HoaDonNhap hoadonnhap;

        public tblhoadonnhap()
        {
            InitializeComponent();
        }

        // Sử lí sự kiện xóa hết các kí tự trong các ô
        private void DeleteTextBoxes()
        {
            sMaHDNhap.Text = "";
            sTenTk.Text = "";
            dNgayNhap.Text = "";
        }

        // Sử lí sự kiện nhập không được để trống
        private bool CheckText()
        {
            if (sMaHDNhap.Text == "" || sTenTk.Text == "" )
            {
                MessageBox.Show("Mời bạn nhập đầy đủ thông tin!");
                return false;
            }

            return true;
        }

        // Sử lí thêm dữ liệu vào đối tượng hóa đơn bán
        private void GetValuesTextBox()
        {
            string smaHDNhap = sMaHDNhap.Text;
            string stenTk = sTenTk.Text;
            DateTime dngayNhap = DateTime.Parse(dNgayNhap.Text);
            hoadonnhap = new HoaDonNhap(smaHDNhap, stenTk, dngayNhap);
        }

        // Sử lị sự kiện cập nhật hóa đơn nhập
        private void btnCapNhatHDNhap_Click(object sender, EventArgs e)
        {
            if (CheckText())
            {
                SqlConnection conn = Connection.GetSqlConnection();
                string sql = "SELECT COUNT(*) FROM tblHoaDonNhap WHERE sMaHDNhap = @sMaHDNhap";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@sMaHDNhap", sMaHDNhap.Text);
                conn.Open();
                int count = (int)cmd.ExecuteScalar();
                if (count == 0)
                {
                    MessageBox.Show("Mã hóa đơn nhập không tồn tại!");
                    return;
                }

                GetValuesTextBox();
                string query = "UPDATE tblHoaDonNhap SET sTenTk = @sTenTk, dNgayNhap = @dNgayNhap WHERE sMaHDNhap = @sMaHDNhap";
                SqlCommand updateCmd = new SqlCommand(query, conn);
                updateCmd.Parameters.AddWithValue("@sTenTk", hoadonnhap.STenTk);
                updateCmd.Parameters.AddWithValue("@dNgayNhap", hoadonnhap.DNgayNhap);
                updateCmd.Parameters.AddWithValue("@sMaHDNhap", hoadonnhap.SMaHDNhap);

                try
                {
                    if (MessageBox.Show("Bạn có muốn sửa lại dữ liệu không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                    {
                        updateCmd.ExecuteNonQuery();
                        MessageBox.Show("Bạn đã sửa thông tin của hóa đơn thành công!");
                        tblhoadonnhap_Load(sender, e);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi sửa: " + ex.Message);
                }
            }

        }

        // Sử lí sự kiện thêm hóa đơn
        private void btnThemHDNhap_Click(object sender, EventArgs e)
        {
            if (CheckText())
            {
                SqlConnection conn = Connection.GetSqlConnection();
                string sql = "SELECT sMaHDNhap FROM tblHoaDonNhap WHERE sMaHDNhap = @sMaHDNhap";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@sMaHDNhap", sMaHDNhap.Text);
                conn.Open();
                string smahdnhap = (string)cmd.ExecuteScalar();
                if (smahdnhap != null)
                {
                    MessageBox.Show("Mã hóa đơn nhập đã tồn tại");
                    return;
                }

                GetValuesTextBox();
                string query = "INSERT INTO tblHoaDonNhap values ('" + hoadonnhap.SMaHDNhap + "', N'" + hoadonnhap.STenTk + "'," +
                " '" + hoadonnhap.DNgayNhap + "' ) ";
                try
                {
                    if (MessageBox.Show("Bạn có muốn thêm vào không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                    {
                        modify.Command(query);
                        MessageBox.Show("Bạn đã thêm 1 hóa đơn thành công!");
                        tblhoadonnhap_Load(sender, e);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi thêm: " + ex.Message);
                }
            }
        }

        // Sử lí sự kiện xóa hóa đơn
        private void btnXoaHDNhap_Click(object sender, EventArgs e)
        {
            // Check lớn hơn 1 dòng
            if (dataGridView_HDNhap.Rows.Count > 1)
            {
                string choose = dataGridView_HDNhap.SelectedRows[0].Cells[0].Value.ToString();
                string query = "DELETE tblHoaDonNhap ";
                query += " WHERE sMaHDNhap = '" + choose + "'";
                try
                {
                    if (MessageBox.Show("Bạn có muốn xóa không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                    {
                        modify.Command(query);
                        MessageBox.Show("Bạn đã xóa 1 hóa đơn thành công!");
                        tblhoadonnhap_Load(sender, e);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi xóa: " + ex.Message);
                }
            }
        }

        // Sử lí sự click vào item trong datagridview
        private void dataGridView_HDNhap_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView_HDNhap.Rows.Count > 1)
            {
                sMaHDNhap.Text = dataGridView_HDNhap.SelectedRows[0].Cells[0].Value.ToString();
                sTenTk.Text = dataGridView_HDNhap.SelectedRows[0].Cells[1].Value.ToString();
                dNgayNhap.Text = dataGridView_HDNhap.SelectedRows[0].Cells[2].Value.ToString();
            }
        }

        // Sử lí sự kiện đổ dữ liệu từ sql vào datagridview
        private void tblhoadonnhap_Load(object sender, EventArgs e)
        {
            try
            {
                dataGridView_HDNhap.DataSource = modify.Table("SELECT sMaHDNhap AS 'Mã HĐ Nhập', sTenTk AS 'Tên Tài Khoản Lập', dNgayNhap AS 'Ngày Nhập' FROM tblHoaDonNhap");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
            DeleteTextBoxes();
        }

        private void sTimKiemMaHDNhap_TextChanged(object sender, EventArgs e)
        {
            string name = sTimKiemMaHDNhap.Text.Trim();
            if (name == "")
            {
                tblhoadonnhap_Load(sender, e);
            }
            else
            {
                string query = "SELECT sMaHDNhap AS 'Mã HĐ Nhập', sTenTk AS 'Tên Tài Khoản Lập', dNgayNhap AS 'Ngày Nhập' FROM tblHoaDonNhap WHERE sMaHDNhap LIKE N'%" + name + "%'";
                dataGridView_HDNhap.DataSource = modify.Table(query);
            }
        }
    }
}
