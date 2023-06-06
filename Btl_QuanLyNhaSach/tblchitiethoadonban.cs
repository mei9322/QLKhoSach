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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Btl_QuanLyNhaSach
{
    public partial class tblchitiethoadonban : Form
    {
        ModifyAll modify = new ModifyAll();
        ChiTietHoaDonBan chiTietHoaDonBan;

        public tblchitiethoadonban()
        {
            InitializeComponent();
        }

        private void btnTimKienHoaDon_Click(object sender, EventArgs e)
        {
            if (sMaHDBan.Text == "")
            {
                MessageBox.Show("Mời bạn nhập mã hóa đơn nhập!");
                return;
            }
            else
            {
                SqlConnection con = Connection.GetSqlConnection();
                string sql = "SELECT * FROM tblHoaDonBan WHERE sMaHDBan" +
                    "    = '" + sMaHDBan.Text + "'";
                SqlCommand cmd = new SqlCommand(sql, con);
                SqlDataReader myreader; try
                {
                    con.Open();
                    myreader = cmd.ExecuteReader();
                    while (myreader.Read())
                    {
                        sMaHDBan.Text = myreader.GetString(0);
                        sTenTk.Text = myreader.GetString(1);
                        sMaKH.Text = myreader.GetString(2);
                        dNgayLap.Value = myreader.GetDateTime(3);
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

        // Sử lí thêm dữ liệu vào đối tượng hóa đơn bán
        private void GetValuesTextBox()
        {
            int iiD = int.Parse(text_id.Text);
            string smahdBan = sMaHDBan.Text;
            string smasach = sMaSach.Text;
            string stenSach = sTenSach.Text;
            int isoLuongBan = int.Parse(iSoLuong.Text);
            float fgiaSach = float.Parse(fGiaSach.Text);
            float fthanhTien = float.Parse(fThanhTien.Text);
            chiTietHoaDonBan = new ChiTietHoaDonBan(iiD, smahdBan, smasach, stenSach, isoLuongBan, fgiaSach, fthanhTien);
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

        // Sử lí sự kiện đổ dữ liệu từ sql vào datagridview
        private void tblchitiethoadonban_Load(object sender, EventArgs e)
        {
            try
            {
                dataGridView_ChiTietHDBan.DataSource = modify.Table("SELECT iID, sMaHDBan AS N'Mã HĐ Bán', sMaSach AS N'Mã Sách', sTenSach AS N'Tên Sách', iSoLuongBan AS N'Số Lượng Bán', fGiaSach AS N'Giá Sách', fThanhTien AS N'Thành Tiền'  FROM tblChiTietHoaDonBan ");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
            DeleteTextBoxes();
        }

        // Sử lí sự click vào item trong datagridview
        private void dataGridView_ChiTietHDBan_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView_ChiTietHDBan.Rows.Count > 1)
            {
                text_id.Text = dataGridView_ChiTietHDBan.SelectedRows[0].Cells[0].Value.ToString();
                sMaHDBan.Text = dataGridView_ChiTietHDBan.SelectedRows[0].Cells[1].Value.ToString();
                sMaSach.Text = dataGridView_ChiTietHDBan.SelectedRows[0].Cells[2].Value.ToString();
                sTenSach.Text = dataGridView_ChiTietHDBan.SelectedRows[0].Cells[3].Value.ToString();
                iSoLuong.Text = dataGridView_ChiTietHDBan.SelectedRows[0].Cells[4].Value.ToString();
                fGiaSach.Text = dataGridView_ChiTietHDBan.SelectedRows[0].Cells[5].Value.ToString();
                fThanhTien.Text = dataGridView_ChiTietHDBan.SelectedRows[0].Cells[6].Value.ToString();
            }
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
                    Double a = myreader.GetDouble(2);
                    fGiaSach.Text = a.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // Sử lí sự kiện thêm 
        private void btnThemHDBan_Click(object sender, EventArgs e)
        {
            /*if (sMaHDBan.Text == "")
            {
                MessageBox.Show("Mời bạn nhập mã hóa đơn bán!");
                return ;
            }
            else
            {
                if (CheckText())
                {

                    SqlConnection conn = Connection.GetSqlConnection();
                    string sql = "SELECT sMaSach FROM tblChiTietHoaDonBan WHERE sMaSach = @sMaSach AND sMaHDBan = '" + sMaHDBan.Text +"'";
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
                    string sql1 = "SELECT iID FROM tblChiTietHoaDonBan WHERE iID = '" + text_id.Text + "'";
                    SqlCommand cmd1 = new SqlCommand(sql1, conn1);
                    conn1.Open();
                    int? IID = (int?)cmd1.ExecuteScalar();
                    if (IID != null)
                    {
                        MessageBox.Show("ID đã tồn tại!");
                        return;
                    }

                    GetValuesTextBox();
                    string query = "INSERT INTO tblChiTietHoaDonBan values ('" + chiTietHoaDonBan.IID + "', N'" + chiTietHoaDonBan.SMaHDBan + "', N'" + chiTietHoaDonBan.SMaSach + "'," +
                        " N'" + chiTietHoaDonBan.STenSach + "', '" + chiTietHoaDonBan.ISoLuongBan + "', '" + chiTietHoaDonBan.FGiaSach + "'," +
                        " '" + chiTietHoaDonBan.FThanhTien + "' ) ";
                    try
                    {
                        if (MessageBox.Show("Bạn có muốn thêm vào không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                        {
                            modify.Command(query);
                            MessageBox.Show("Bạn đã thêm 1 sản phẩm của hóa đơn " + chiTietHoaDonBan.SMaHDBan + " thành công!");
                            tblchitiethoadonban_Load(sender, e);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi thêm: " + ex.Message);
                    }
                }*/
            if (sMaHDBan.Text == "")
            {
                MessageBox.Show("Mời bạn nhập mã hóa đơn bán!");
                return;
            }
            else
            {
                if (CheckText())
                {
                    using (SqlConnection conn = Connection.GetSqlConnection())
                    {
                        string sql = "SELECT sMaSach FROM tblChiTietHoaDonBan WHERE sMaSach = @sMaSach AND sMaHDBan = @sMaHDBan";
                        SqlCommand cmd = new SqlCommand(sql, conn);
                        cmd.Parameters.AddWithValue("@sMaSach", sMaSach.Text);
                        cmd.Parameters.AddWithValue("@sMaHDBan", sMaHDBan.Text);
                        conn.Open();
                        string smaSach = (string)cmd.ExecuteScalar();
                        if (smaSach != null)
                        {
                            MessageBox.Show("Sách này đã tồn tại trong hóa đơn!");
                            return;
                        }
                    }

                    using (SqlConnection conn = Connection.GetSqlConnection())
                    {
                        string sql = "SELECT iID FROM tblChiTietHoaDonBan WHERE iID = @iID";
                        SqlCommand cmd = new SqlCommand(sql, conn);
                        cmd.Parameters.AddWithValue("@iID", text_id.Text);
                        conn.Open();
                        int? IID = (int?)cmd.ExecuteScalar();
                        if (IID != null)
                        {
                            MessageBox.Show("ID đã tồn tại!");
                            return;
                        }
                    }

                    GetValuesTextBox();
                    using (SqlConnection conn = Connection.GetSqlConnection())
                    {
                        string query = "INSERT INTO tblChiTietHoaDonBan (iID, sMaHDBan, sMaSach, sTenSach, iSoLuongBan, fGiaSach, fThanhTien) " +
                                       "VALUES (@iID, @sMaHDBan, @sMaSach, @sTenSach, @iSoLuongBan, @fGiaSach, @fThanhTien)";
                        SqlCommand cmd = new SqlCommand(query, conn);
                        cmd.Parameters.AddWithValue("@iID", chiTietHoaDonBan.IID);
                        cmd.Parameters.AddWithValue("@sMaHDBan", chiTietHoaDonBan.SMaHDBan);
                        cmd.Parameters.AddWithValue("@sMaSach", chiTietHoaDonBan.SMaSach);
                        cmd.Parameters.AddWithValue("@sTenSach", chiTietHoaDonBan.STenSach);
                        cmd.Parameters.AddWithValue("@iSoLuongBan", chiTietHoaDonBan.ISoLuongBan);
                        cmd.Parameters.AddWithValue("@fGiaSach", chiTietHoaDonBan.FGiaSach);
                        cmd.Parameters.AddWithValue("@fThanhTien", chiTietHoaDonBan.FThanhTien);
                        try
                        {
                            if (MessageBox.Show("Bạn có muốn thêm vào không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                            {
                                conn.Open();
                                cmd.ExecuteNonQuery();
                                MessageBox.Show("Bạn đã thêm 1 sản phẩm của hóa đơn " + chiTietHoaDonBan.SMaHDBan + " thành công!");
                                tblchitiethoadonban_Load(sender, e);
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Lỗi thêm: " + ex.Message);
                        }
                    }
                }
            }
        }
        // Sử lí sự kiện ô số lượng
        private void iSoLuong_TextChanged(object sender, EventArgs e)
        {
            int soLuong = 0;
            bool isValidSoLuong = int.TryParse(iSoLuong.Text.Trim(), out soLuong);

            if (isValidSoLuong)
            {
                SqlConnection con = Connection.GetSqlConnection();
                string sql = "SELECT iSoLuong FROM tblSach WHERE sMaSach = @maSach";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@maSach", sMaSach.Text);

                try
                {
                    con.Open();
                    int soLuongTrongKho = (int)cmd.ExecuteScalar();

                    if (soLuong > soLuongTrongKho)
                    {
                        MessageBox.Show("Số lượng sách trong kho không đủ!", "Thông báo");
                        iSoLuong.Clear();
                    }
                    else
                    {
                        fThanhTien.Text = (float.Parse(iSoLuong.Text) *
                        float.Parse(fGiaSach.Text)).ToString();
                    }    
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message, "Thông báo");
                }
                finally
                {
                    con.Close();
                }
            }
        }

        // Sử lí sự kiện cập nhật dữ liệu
        private void btnCapNhatHDBan_Click(object sender, EventArgs e)
        {
            if (sMaHDBan.Text == "")
            {
                MessageBox.Show("Mời bạn nhập mã hóa đơn bán!");
                return;
            }
            else
            {
                if (CheckText())
                {
                    SqlConnection conn = Connection.GetSqlConnection();
                    string sql = "SELECT sMaSach FROM tblChiTietHoaDonBan WHERE sMaSach = @sMaSach AND sMaHDBan = @sMaHDBan";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@sMaSach", sMaSach.Text);
                    cmd.Parameters.AddWithValue("@sMaHDBan", sMaHDBan.Text);
                    conn.Open();
                    string smaSach = (string)cmd.ExecuteScalar();
                    string smaHDBan = (string)cmd.ExecuteScalar();
                    if (smaSach == null && smaHDBan == null)
                    {
                        MessageBox.Show("Sách và hóa đơn bán này không tồn tại trong hóa đơn!");
                        return;
                    }

                    SqlConnection conn1 = Connection.GetSqlConnection();
                    string sql1 = "SELECT iID FROM tblChiTietHoaDonBan WHERE iID = @iID";
                    SqlCommand cmd1 = new SqlCommand(sql1, conn1);
                    cmd1.Parameters.AddWithValue("@iID", text_id.Text);
                    conn1.Open();
                    int? IID = (int?)cmd1.ExecuteScalar();
                    if (IID == null)
                    {
                        MessageBox.Show("ID không tồn tại!");
                        return;
                    }

                    GetValuesTextBox();
                    string query = "UPDATE tblChiTietHoaDonBan SET iID = @iID, sMaHDBan = @sMaHDBan, sMaSach = @sMaSach, sTenSach = @sTenSach, iSoLuongBan = @iSoLuongBan, fGiaSach = @fGiaSach, fThanhTien = @fThanhTien WHERE iID = @iID";

                    cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@iID", chiTietHoaDonBan.IID);
                    cmd.Parameters.AddWithValue("@sMaHDBan", chiTietHoaDonBan.SMaHDBan);
                    cmd.Parameters.AddWithValue("@sMaSach", chiTietHoaDonBan.SMaSach);
                    cmd.Parameters.AddWithValue("@sTenSach", chiTietHoaDonBan.STenSach);
                    cmd.Parameters.AddWithValue("@iSoLuongBan", chiTietHoaDonBan.ISoLuongBan);
                    cmd.Parameters.AddWithValue("@fGiaSach", chiTietHoaDonBan.FGiaSach);
                    cmd.Parameters.AddWithValue("@fThanhTien", chiTietHoaDonBan.FThanhTien);

                    try
                    {
                        if (MessageBox.Show("Bạn có muốn sửa lại dữ liệu không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                        {
                            cmd.ExecuteNonQuery();
                            MessageBox.Show("Bạn đã sửa thông tin của sản phẩm trong hóa đơn thành công!");
                            tblchitiethoadonban_Load(sender, e);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi sửa: " + ex.Message);
                    }


                }
            }

        }

        // Sử lí sự kiện xóa dữ liệu
        private void btnXoaHDBan_Click(object sender, EventArgs e)
        {
            // Check lớn hơn 1 dòng
            if (dataGridView_ChiTietHDBan.Rows.Count > 1)
            {
                string choose = dataGridView_ChiTietHDBan.SelectedRows[0].Cells[0].Value.ToString();
                string query = "DELETE tblChiTietHoaDonBan ";
                query += " WHERE iID = '" + choose + "'";
                try
                {
                    if (MessageBox.Show("Bạn có muốn xóa không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                    {
                        modify.Command(query);
                        MessageBox.Show("Bạn đã xóa 1 sản phẩm trong hóa đơn bán thành công!");
                        tblchitiethoadonban_Load(sender, e);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi xóa: " + ex.Message);
                }
            }
        }
    }
}
