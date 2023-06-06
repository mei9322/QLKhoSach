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
    public partial class thongkeloinhuam : Form
    {
        public thongkeloinhuam()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            string tenSach = txtTenSach.Text.Trim();

            if (string.IsNullOrEmpty(tenSach))
            {
                MessageBox.Show("Vui lòng nhập tên sách để tìm kiếm.");
                return;
            }

            SqlConnection conn = Connection.GetSqlConnection();
            string sql = "SELECT tblSach.sTenSach, SUM(tblChiTietHoaDonBan.iSoLuongBan) as TongSoLuongBan, tblSach.fGiaSach, SUM(tblChiTietHoaDonBan.fThanhTien) as TongTienLai " +
                         "FROM tblChiTietHoaDonBan " +
                         "INNER JOIN tblSach ON tblChiTietHoaDonBan.sMaSach = tblSach.sMaSach " +
                         "WHERE tblSach.sTenSach LIKE '%' + @tenSach + '%' " +
                         "GROUP BY tblSach.sTenSach, tblSach.fGiaSach";
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@tenSach", tenSach);

            try
            {
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    txtSoluongBan.Text = reader["TongSoLuongBan"].ToString();
                    float giaSach = float.Parse(reader["fGiaSach"].ToString());
                    int tonKho = GetSoLuongTonKho(tenSach);
                    txttonKho.Text = tonKho.ToString();
                    float tongTienLai = float.Parse(reader["TongTienLai"].ToString());
                    float tongTienLaiTheoTenSach = tongTienLai ;
                    txtTongTienLai.Text = tongTienLaiTheoTenSach.ToString();
                }
                else
                {
                    MessageBox.Show("Không tìm thấy sách có tên \"" + tenSach + "\" trong cơ sở dữ liệu.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        private int GetSoLuongTonKho(string tenSach)
        {
            SqlConnection conn = Connection.GetSqlConnection();
            string sql = "SELECT iSoLuong FROM tblSach WHERE sTenSach = @tenSach";
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@tenSach", tenSach);
            try
            {
                conn.Open();
                object result = cmd.ExecuteScalar();
                if (result != null)
                {
                    return int.Parse(result.ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
            return 0;
        }
    }
}

