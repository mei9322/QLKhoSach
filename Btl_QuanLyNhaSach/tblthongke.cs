using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Btl_QuanLyNhaSach
{
    public partial class tblthongke : Form
    {
        public tblthongke()
        {
            InitializeComponent();
        }

        // Sử lí sự kiện nhập vào textbox số lượng chỉ nhận số không nhận kí tự chữ
        private void textBox_Nam_KeyPress(object sender, KeyPressEventArgs e)
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

        // Sử lí sự kiện nhập vào textbox số lượng chỉ nhận số không nhận kí tự chữ
        private void textBox_Thang_KeyPress(object sender, KeyPressEventArgs e)
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

        // Sử lí sự kiện nhập không được để trống
        private bool CheckText()
        {
            if (textBox_Nam.Text == "" || textBox_Thang.Text == "")
            {
                MessageBox.Show("Mời bạn nhập đầy đủ thông tin!");
                return false;
            }

            return true;

        }

        // Sử lí sự kiện đổ dữ liệu vào 
        private void button_timkiem_Click(object sender, EventArgs e)
        {
            if (textBox_Nam.Text == "" || textBox_Thang.Text == "")
            {
                MessageBox.Show("Mời bạn nhập thông tin!");
                return;
            }
            else
            {
                
                SqlConnection con = Connection.GetSqlConnection();
                string sql = "SELECT TOP 1 tblSach.sMaSach, tblSach.sTenSach, COUNT(tblSach.sMaSach)  FROM " +
                    "tblChiTietHoaDonBan inner join tblHoaDonBan on tblHoaDonBan.sMaHDBan = tblChiTietHoaDonBan.sMaHDBan " +
                    "INNER JOIN tblSach on tblChiTietHoaDonBan.sMaSach = tblSach.sMaSach " +
                    "WHERE YEAR(tblHoaDonBan.dNgayLap) = '" + textBox_Nam.Text + "' AND MONTH(tblHoaDonBan.dNgayLap) = '" + textBox_Thang.Text + "' group by  tblSach.sMaSach, tblSach.sTenSach";
                SqlCommand cmd = new SqlCommand(sql, con);
                SqlDataReader myreader; try
                {
                    con.Open();
                    myreader = cmd.ExecuteReader();
                    while (myreader.Read())
                    {
                        sTenSach.Text = myreader.GetString(1);
                        int a = myreader.GetInt32(2);
                        iSoLuongSach.Text = a.ToString();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                
                
                SqlConnection conn1 = Connection.GetSqlConnection();
                string sql1 = "SELECT TOP 1 tblTaiKhoan.sTen, tblHoaDonBan.sTenTk, SUM(tblChiTietHoaDonBan.fThanhTien), COUNT(tblChiTietHoaDonBan.sMaHDBan) FROM tblChiTietHoaDonBan " +
                    "inner join tblHoaDonBan on tblHoaDonBan.sMaHDBan = tblChiTietHoaDonBan.sMaHDBan " +
                    "INNER JOIN tblTaiKhoan on tblHoaDonBan.sTenTk = tblTaiKhoan.sTenTk " +
                    "WHERE YEAR(tblHoaDonBan.dNgayLap) = '" + textBox_Nam.Text + "' AND MONTH(tblHoaDonBan.dNgayLap) = '" + textBox_Thang.Text + "' group by  tblTaiKhoan.sTen, tblHoaDonBan.sTenTk";
                SqlCommand cmd1 = new SqlCommand(sql1, conn1);
                SqlDataReader myreader1; try
                {
                    conn1.Open();
                    myreader1 = cmd1.ExecuteReader();
                    while (myreader1.Read())
                    {
                        sTenTk.Text = myreader1.GetString(0);
                        double b = myreader1.GetDouble(2);
                        int c = myreader1.GetInt32(3);
                        iSoTien.Text = b.ToString();
                        iSoHD.Text = c.ToString();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }


                SqlConnection conn2 = Connection.GetSqlConnection();
                string sql2 = "SELECT SUM(tblChiTietHoaDonBan.fThanhTien) FROM tblChiTietHoaDonBan " +
                    "inner join tblHoaDonBan on tblChiTietHoaDonBan.sMaHDBan = tblHoaDonBan.sMaHDBan " +
                    "WHERE YEAR(tblHoaDonBan.dNgayLap) = '" + textBox_Nam.Text + "' AND MONTH(tblHoaDonBan.dNgayLap) = '" + textBox_Thang.Text + "'";
                SqlCommand cmd2 = new SqlCommand(sql2, conn2);
                SqlDataReader myreader2; try
                {
                    conn2.Open();
                    myreader2 = cmd2.ExecuteReader();
                    while (myreader2.Read())
                    {
                        double d = myreader2.GetDouble(0);
                        iTongTienBan.Text = d.ToString();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }


                SqlConnection conn3 = Connection.GetSqlConnection();
                string sql3 = "SELECT TOP 1 tblKhachHang.sTenKH, tblKhachHang.sSdt, COUNT(tblHoaDonBan.sMaHDBan), SUM(tblChiTietHoaDonBan.fThanhTien) FROM tblKhachHang " +
                    "inner join tblHoaDonBan on tblKhachHang.sMaKH = tblHoaDonBan.sMaKH " +
                    "inner join tblChiTietHoaDonBan on tblChiTietHoaDonBan.sMaHDBan = tblHoaDonBan.sMaHDBan " +
                    "WHERE YEAR(tblHoaDonBan.dNgayLap) = '" + textBox_Nam.Text + "' AND MONTH(tblHoaDonBan.dNgayLap) = '" + textBox_Thang.Text + "' GROUP BY tblKhachHang.sTenKH, tblKhachHang.sSdt";
                SqlCommand cmd3 = new SqlCommand(sql3, conn3);
                SqlDataReader myreader3; try
                {
                    conn3.Open();
                    myreader3 = cmd3.ExecuteReader();
                    while (myreader3.Read())
                    {
                        sTenKH.Text = myreader3.GetString(0);
                        sSDT.Text = myreader3.GetString(1);
                        double a1 = myreader3.GetDouble(3);
                        iSoTienMua.Text = a1.ToString();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }
        }

        // Sử lí sự kiện check năm có trong bảng hóa đơn bán không
        private void textBox_Nam_Leave(object sender, EventArgs e)
        {
            int nam;
            if (int.TryParse(textBox_Nam.Text, out nam))
            {
                string query = "SELECT COUNT(*) FROM tblHoaDonBan WHERE YEAR(dNgayLap) = @Nam";

                using (SqlConnection connection = Connection.GetSqlConnection())
                {
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@Nam", nam);
                    connection.Open();
                    int count = (int)command.ExecuteScalar();
                    connection.Close();

                    if (count < 0)
                    {
                        MessageBox.Show("Trong năm '" + textBox_Nam.Text + "' không có hóa đơn được tạo!");
                    }
                    
                }
            }
            else
            {
                MessageBox.Show("Vui lòng nhập số năm không được để trống!");
            }
        }

        // Sử lí sự kiện check thang có trong bảng hóa đơn bán không
        private void textBox_Thang_Leave(object sender, EventArgs e)
        {
            int thang;
            if (int.TryParse(textBox_Thang.Text, out thang))
            {
                string query = "SELECT COUNT(*) FROM tblHoaDonBan WHERE MONTH(dNgayLap) = @Thang";

                using (SqlConnection connection = Connection.GetSqlConnection())
                {
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@Thang", thang);
                    connection.Open();
                    int count = (int)command.ExecuteScalar();
                    connection.Close();

                    if (count < 0)
                    {
                        MessageBox.Show("Trong tháng '" + textBox_Thang.Text + "' không có hóa đơn được tạo!");
                    }
                }
            }
            else
            {
                MessageBox.Show("Vui lòng nhập số tháng không được để trống!");
            }
        }
    }
}
