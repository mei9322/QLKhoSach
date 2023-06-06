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
    public partial class tblchitiethoadonnhap : Form
    {
        ModifyAll modify = new ModifyAll();
        ChiTietHoaDonNhap chiTietHoaDonNhap;

        public tblchitiethoadonnhap()
        {
            InitializeComponent();
        }

        private void button_TimKiemHDNhap_Click(object sender, EventArgs e)
        {
            if (sMaHDNhap.Text == "")
            {
                MessageBox.Show("Mời bạn nhập mã hóa đơn nhập!");
                return;
            }
            else
            {
                SqlConnection con = Connection.GetSqlConnection();
                string sql = "SELECT * FROM tblHoaDonNhap WHERE sMaHDNhap" +
                    "    = '" + sMaHDNhap.Text + "'";
                SqlCommand cmd = new SqlCommand(sql, con);
                SqlDataReader myreader; try
                {
                    con.Open();
                    myreader = cmd.ExecuteReader();
                    while (myreader.Read())
                    {
                        sMaHDNhap.Text = myreader.GetString(0);
                        sTenTk.Text = myreader.GetString(1);
                        dNgayNhap.Value = myreader.GetDateTime(2);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        // Sử lí sự kiện xóa hết các kí tự trong các ô
        private void DeleteTextBoxes()
        {
            text_id.Text = "";
            sMaSach.Text = "";
            sTenSach.Text = "";
            fGiaSach.Text = "";
            iSoLuong.Text = "";
            fThanhTien.Text = "";
        }

        // Sử lí sự kiện nhập không được để trống
        private bool CheckText()
        {
            if (sMaSach.Text == "" || sTenSach.Text == "" || fGiaSach.Text == "" || iSoLuong.Text == "" || fThanhTien.Text == "" || text_id.Text == "")
            {
                MessageBox.Show("Mời bạn nhập đầy đủ thông tin!");
                return false;
            }

            return true;
        }

        // Sử lí thêm dữ liệu vào đối tượng hóa đơn nhập
        private void GetValuesTextBox()
        {
            int iiD = int.Parse(text_id.Text);
            string smahdNhap = sMaHDNhap.Text;
            string smasach = sMaSach.Text;
            int isoLuongNhap = int.Parse(iSoLuong.Text);
            float fgiaSach = float.Parse(fGiaSach.Text);
            float fthanhTien = float.Parse(fThanhTien.Text);
            chiTietHoaDonNhap = new ChiTietHoaDonNhap(iiD, smahdNhap, smasach, isoLuongNhap, fgiaSach, fthanhTien);
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

        // Sử lí sự click vào item trong datagridview
        private void dataGridView_HDNhap_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView_HDNhap.Rows.Count > 1)
            {
                text_id.Text = dataGridView_HDNhap.SelectedRows[0].Cells[0].Value.ToString();
                sTenSach.Text = dataGridView_HDNhap.SelectedRows[0].Cells[2].Value.ToString();
                iSoLuong.Text = dataGridView_HDNhap.SelectedRows[0].Cells[3].Value.ToString();
                fGiaSach.Text = dataGridView_HDNhap.SelectedRows[0].Cells[4].Value.ToString();
                fThanhTien.Text = dataGridView_HDNhap.SelectedRows[0].Cells[5].Value.ToString();
                sMaHDNhap.Text = dataGridView_HDNhap.SelectedRows[0].Cells[1].Value.ToString();

                SqlConnection con = Connection.GetSqlConnection();
                string sql = "SELECT * FROM tblSach WHERE sTenSach =N'" + sTenSach.Text + "'";
                SqlCommand cmd = new SqlCommand(sql, con);
                SqlDataReader myreader; try
                {
                    con.Open();
                    myreader = cmd.ExecuteReader();
                    while (myreader.Read())
                    {
                        sMaSach.Text = myreader.GetString(0);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        // Sử lí sự kiện đổ dữ liệu từ sql vào datagridview
        private void tblchitiethoadonnhap_Load(object sender, EventArgs e)
        {
            try
            {
                dataGridView_HDNhap.DataSource = modify.Table("SELECT iID, sMaHDNhap AS N'Mã HĐ Bán', tblSach.sTenSach AS N'Tên Sách', iSoLuongNhap AS N'Số Lượng Nhập', tblChiTietHoaDonNhap.fGiaSach AS N'Giá Sách', tblChiTietHoaDonNhap.fThanhTien AS N'Thành Tiền' " +
                    "FROM tblChiTietHoaDonNhap inner join tblSach ON tblChiTietHoaDonNhap.sMaSach = tblSach.sMaSach ");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi load: " + ex.Message);
            }
            DeleteTextBoxes();
        }

        // Sử lí sự kiện khi nhập mã sách thì hiện tên sách
        private void sMaSach_TextChanged(object sender, EventArgs e)
        {
            SqlConnection con = Connection.GetSqlConnection();
            string sql = "SELECT * FROM tblSach WHERE sMaSach" +
                "    = '" + sMaSach.Text + "'";
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataReader myreader; try
            {
                con.Open();
                myreader = cmd.ExecuteReader();
                while (myreader.Read())
                {
                    sTenSach.Text = myreader.GetString(1);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi : " + ex.Message);
            }
        }

        // Sử lí sự kiện thêm dữ liệu
        private void btnThemHDNhap_Click(object sender, EventArgs e)
        {
            if (sMaHDNhap.Text == "")
            {
                MessageBox.Show("Mời bạn nhập mã hóa đơn nhập!");
                return;
            }
            else
            {
                if (CheckText())
                {
                    SqlConnection conn = Connection.GetSqlConnection();
                    string sql = "SELECT sMaSach FROM tblChiTietHoaDonNhap WHERE sMaSach = @sMaSach AND sMaHDNhap = '" + sMaHDNhap.Text + "'";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@sMaSach", sMaSach.Text);
                    conn.Open();
                    string smaSach = (string)cmd.ExecuteScalar();
                    if (smaSach != null)
                    {
                        MessageBox.Show("Sách này đã tồn tại trong hóa đơn!");
                        return;
                    }

                    SqlConnection conn1 = Connection.GetSqlConnection();
                    string sql1 = "SELECT iID FROM tblChiTietHoaDonNhap WHERE iID = '" + text_id.Text + "'";
                    SqlCommand cmd1 = new SqlCommand(sql1, conn1);
                    conn1.Open();
                    int? IID = (int?)cmd1.ExecuteScalar();
                    if (IID != null)
                    {
                        MessageBox.Show("ID đã tồn tại!");
                        return;
                    }

                    GetValuesTextBox();
                    string query = "INSERT INTO tblChiTietHoaDonNhap values ('" + chiTietHoaDonNhap.IID + "', N'" + chiTietHoaDonNhap.SMaHDNhap + "', N'" + chiTietHoaDonNhap.SMaSach + "'," +
                        " N'" + chiTietHoaDonNhap.ISoLuongNhap + "', '" + chiTietHoaDonNhap.FGiaSach + "'," +
                        " '" + chiTietHoaDonNhap.FThanhTien + "' ) ";
                    try
                    {
                        if (MessageBox.Show("Bạn có muốn thêm vào không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                        {
                            modify.Command(query);
                            MessageBox.Show("Bạn đã thêm 1 sản phẩm của hóa đơn " + chiTietHoaDonNhap.SMaHDNhap + " thành công!");
                            tblchitiethoadonnhap_Load(sender, e);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi thêm: " + ex.Message);
                    }
                }
            }
        }

        // Sử lí sự kiện xóa dữ liệu
        private void btnXoaHDNhap_Click(object sender, EventArgs e)
        {
            // Check lớn hơn 1 dòng
            if (dataGridView_HDNhap.Rows.Count > 1)
            {
                string choose = dataGridView_HDNhap.SelectedRows[0].Cells[0].Value.ToString();
                string query = "DELETE tblChiTietHoaDonNhap ";
                query += " WHERE iID = '" + choose + "'";
                try
                {
                    if (MessageBox.Show("Bạn có muốn xóa không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                    {
                        modify.Command(query);
                        MessageBox.Show("Bạn đã xóa 1 sản phẩm trong hóa đơn bán thành công!");
                        tblchitiethoadonnhap_Load(sender, e);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi xóa: " + ex.Message);
                }
            }
        }

        // Sử lí sự kiện cập nhật dữ liệu
        private void btnCapNhatHDNhap_Click(object sender, EventArgs e)
        {
            if (sMaHDNhap.Text == "")
            {
                MessageBox.Show("Mời bạn nhập mã hóa đơn bán!");
                return;
            }
            else
            {
                if (CheckText())
                {
                    SqlConnection conn = Connection.GetSqlConnection();
                    string sql = "SELECT sMaSach FROM tblChiTietHoaDonNhap WHERE sMaSach = @sMaSach AND sMaHDNhap = '" + sMaHDNhap.Text + "'";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@sMaSach", sMaSach.Text);
                    conn.Open();
                    string smaSach = (string)cmd.ExecuteScalar();
                    if (smaSach == null)
                    {
                        MessageBox.Show("Sách này ko tồn tại trong hóa đơn!");
                        return;
                    }

                    SqlConnection conn1 = Connection.GetSqlConnection();
                    string sql1 = "SELECT iID FROM tblChiTietHoaDonNhap WHERE iID = '" + text_id.Text + "'";
                    SqlCommand cmd1 = new SqlCommand(sql1, conn1);
                    conn1.Open();
                    int? IID = (int?)cmd1.ExecuteScalar();
                    if (IID == null)
                    {
                        MessageBox.Show("ID ko tồn tại!");
                        return;
                    }

                    GetValuesTextBox();
                    string query = "UPDATE tblChiTietHoaDonNhap SET iID = '" + chiTietHoaDonNhap.IID + "', sMaHDNhap = '" + chiTietHoaDonNhap.SMaHDNhap + "'," +
                    " sMaSach = '" + chiTietHoaDonNhap.SMaSach + "', iSoLuongNhap = '" + chiTietHoaDonNhap.ISoLuongNhap + "'," +
                    " fGiaSach = '" + chiTietHoaDonNhap.FGiaSach + "',fThanhTien = '" + chiTietHoaDonNhap.FThanhTien + "'";
                    query += "WHERE iID = '" + chiTietHoaDonNhap.IID + "'";
                    try
                    {
                        if (MessageBox.Show("Bạn có muốn sửa lại dữ liệu không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                        {
                            modify.Command(query);
                            MessageBox.Show("Bạn đã sửa thông tin của sản phẩm trong hóa đơn thành công!");
                            tblchitiethoadonnhap_Load(sender, e);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi sửa: " + ex.Message);
                    }
                }
            }
        }

        // Sử lí sự kiện ô số lượng
        private void iSoLuong_TextChanged(object sender, EventArgs e)
        {
            // Nếu giá hoặc số lượng sản phẩm không hợp lệ thì không tính toán
            if (!decimal.TryParse(fGiaSach.Text, out decimal gia) ||
                gia < 0 || gia > 1000000000 ||
                !int.TryParse(iSoLuong.Text, out int soLuong) ||
                soLuong < 0 || soLuong > 1000000)
            {
                fThanhTien.Text = "";
                return;
            }

            // Tính tổng giá tiền
            decimal tongTien = gia * soLuong;

            // Hiển thị tổng giá tiền trên TextBox
            fThanhTien.Text = tongTien.ToString();

        }

        // Sử lí sự kiện ô giá sách
        private void fGiaSach_TextChanged(object sender, EventArgs e)
        {
            // Nếu giá hoặc số lượng sản phẩm không hợp lệ thì không tính toán
            if (!decimal.TryParse(fGiaSach.Text, out decimal gia) ||
                gia < 0 || gia > 1000000000 ||
                !int.TryParse(iSoLuong.Text, out int soLuong) ||
                soLuong < 0 || soLuong > 1000000)
            {
                fThanhTien.Text = "";
                return;
            }

            // Tính tổng giá tiền
            decimal tongTien = gia * soLuong;

            // Hiển thị tổng giá tiền trên TextBox
            fThanhTien.Text = tongTien.ToString();
        }
    }
}
