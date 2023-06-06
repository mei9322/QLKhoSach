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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace Btl_QuanLyNhaSach
{
    public partial class tblhoadonban : Form
    {
        ModifyAll modify = new ModifyAll();
        HoaDonBan hoadonban;

        public tblhoadonban()
        {
            InitializeComponent();
            fillCombobox();
        }

        // Sử lí sự kiện đổ dữ liệu từ sql vào datagridview
        private void tblhoadonban_Load(object sender, EventArgs e)
        {
            try
            {
                dataGridView_HDBan.DataSource = modify.Table("SELECT sMaHDBan AS 'Mã HĐ Bán', sTenTk AS 'Tên Tài Khoản Lập', tblKhachHang.sTenKH AS 'Tên Khách Hàng', dNgayLap AS 'Ngày Lập' " +
                    "FROM tblHoaDonBan inner join tblKhachHang on tblHoaDonBan.sMaKH = tblKhachHang.sMaKH");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
            DeleteTextBoxes();
        }

        // Sử lí sự kiện xóa hết các kí tự trong các ô
        private void DeleteTextBoxes()
        {
            sMaHDBan.Text = "";
            sTenTk.Text = "";
            dNgayLap.Text = "";
        }

        // Sử lí sự kiện nhập không được để trống
        private bool CheckText()
        {
            if (sMaHDBan.Text == "" || sTenTk.Text == "" )
            {
                MessageBox.Show("Mời bạn nhập đầy đủ thông tin!");
                return false;
            }

            return true;
        }

        // Sử lí thêm dữ liệu vào đối tượng hóa đơn bán
        private void GetValuesTextBox()
        {
            string smaHDBan = sMaHDBan.Text;
            string stenTk = sTenTk.Text;
            // Lấy giá trị mã khách hàng tương ứng
            string smaKh = comboBox_sTenKH.SelectedValue.ToString();
            DateTime dngayLap = DateTime.Parse(dNgayLap.Text);
            hoadonban = new HoaDonBan(smaHDBan, stenTk, smaKh, dngayLap);
        }

        // Sử lí sự kiện xóa hóa đơn
        private void btnXoaHDBan_Click(object sender, EventArgs e)
        {
            // Check lớn hơn 1 dòng
            if (dataGridView_HDBan.Rows.Count > 1)
            {
                string choose = dataGridView_HDBan.SelectedRows[0].Cells[0].Value.ToString();
                string query = "DELETE tblHoaDonBan ";
                query += " WHERE sMaHDBan = '" + choose + "'";
                try
                {
                    if (MessageBox.Show("Bạn có muốn xóa không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                    {
                        modify.Command(query);
                        MessageBox.Show("Bạn đã xóa 1 hóa đơn thành công!");
                        tblhoadonban_Load(sender, e);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi xóa: " + ex.Message);
                }
            }
        }

        // Sử lí sự kiện cập nhật hóa đơn
        private void btnCapNhatHDBan_Click(object sender, EventArgs e)
        {
            if (CheckText())
            {
                SqlConnection conn = Connection.GetSqlConnection();
                string sql = "SELECT COUNT(*) FROM tblHoaDonBan WHERE sMaHDBan = @sMaHDBan";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@sMaHDBan", sMaHDBan.Text);
                conn.Open();
                int count = (int)cmd.ExecuteScalar();
                if (count == 0)
                {
                    MessageBox.Show("Mã hóa đơn bán không  tồn tại!");
                    return;
                }

                GetValuesTextBox();
                string query = "UPDATE tblHoaDonBan SET sMaHDBan = @newMaHDBan, sTenTk = @sTenTk, sMaKH = @sMaKH, dNgayLap = @dNgayLap WHERE sMaHDBan = @oldMaHDBan";
                SqlCommand updateCmd = new SqlCommand(query, conn);
                updateCmd.Parameters.AddWithValue("@newMaHDBan", hoadonban.SMaHDBan);
                updateCmd.Parameters.AddWithValue("@sTenTk", hoadonban.STenTk);
                updateCmd.Parameters.AddWithValue("@sMaKH", hoadonban.SMaKH);
                updateCmd.Parameters.AddWithValue("@dNgayLap", hoadonban.DNgayLap);
                updateCmd.Parameters.AddWithValue("@oldMaHDBan", hoadonban.SMaHDBan);

                try
                {
                    if (MessageBox.Show("Bạn có muốn sửa lại dữ liệu không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                    {
                        updateCmd.ExecuteNonQuery();
                        MessageBox.Show("Bạn đã sửa thông tin của hóa đơn thành công!");
                        tblhoadonban_Load(sender, e);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi sửa: " + ex.Message);
                }
            }

        }

        // Sử lí sự kiện thêm hóa đơn
        private void btnThemHDBan_Click(object sender, EventArgs e)
        {
            if (CheckText())
            {
                SqlConnection conn = Connection.GetSqlConnection();
                string sql = "SELECT sMaHDBan FROM tblHoaDonBan WHERE sMaHDBan = @sMaHDBan";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@sMaHDBan", sMaHDBan.Text);
                conn.Open();
                string smahdban = (string)cmd.ExecuteScalar();
                if (smahdban != null)
                {
                    MessageBox.Show("Mã hóa đơn bán đã tồn tại");
                    return;
                }


                GetValuesTextBox();
                string query = "INSERT INTO tblHoaDonBan values ('" + hoadonban.SMaHDBan + "', N'" + hoadonban.STenTk + "', N'" + hoadonban.SMaKH + "'," +
                " '" + hoadonban.DNgayLap + "' ) ";
                try
                {
                    if (MessageBox.Show("Bạn có muốn thêm vào không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                    {
                        modify.Command(query);
                        MessageBox.Show("Bạn đã thêm 1 hóa đơn thành công!");
                        tblhoadonban_Load(sender, e);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi thêm: " + ex.Message);
                }
            }
        }

        // Sử lí sự click vào item trong datagridview
        private void dataGridView_HDBan_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView_HDBan.Rows.Count > 1)
            {
                sMaHDBan.Text = dataGridView_HDBan.SelectedRows[0].Cells[0].Value.ToString();
                sTenTk.Text = dataGridView_HDBan.SelectedRows[0].Cells[1].Value.ToString();
                comboBox_sTenKH.Text = dataGridView_HDBan.SelectedRows[0].Cells[2].Value.ToString();
                dNgayLap.Text = dataGridView_HDBan.SelectedRows[0].Cells[3].Value.ToString();
            }
        }

        // Sử lí sự kiện tìm kiếm trong hóa đơn bán
        private void sTimKiemMaHDBan_TextChanged(object sender, EventArgs e)
        {
            string name = sTimKiemMaHDBan.Text.Trim();
            if (name == "")
            {
                tblhoadonban_Load(sender, e);
            }
            else
            {
                string query = "SELECT sMaHDBan AS 'Mã HĐ Bán', sTenTk AS 'Tên Tài Khoản Lập', sMaKH AS 'Mã Khách Hàng', dNgayLap AS 'Ngày Lập' FROM tblHoaDonBan WHERE sMaHDBan LIKE N'%" + name + "%'";
                dataGridView_HDBan.DataSource = modify.Table(query);
            }
        }

        // Sử lí sự kiện đổ dữ liệu vào combobox
        public void fillCombobox()
        {
            // Đổ dữ liệu vào combobox
            string query = "SELECT * FROM tblKhachHang";
            SqlConnection sqlConnection = Connection.GetSqlConnection();
            sqlConnection.Open();
            SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = sqlCommand;
            DataTable table = new DataTable();
            adapter.Fill(table);
            comboBox_sTenKH.DataSource = table;
            comboBox_sTenKH.DisplayMember = "sTenKH";
            comboBox_sTenKH.ValueMember = "sMaKH";
            sqlConnection.Close();
        }
    }
}
