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
    public partial class thongketheonam : Form
    {
        public thongketheonam()
        {
            InitializeComponent();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void Xem_Click(object sender, EventArgs e)
        {
            // Lấy năm từ TextBox nhập vào
            int nam = int.Parse(txtNam.Text);

            // Tạo kết nối tới CSDL
            string connectionString = @"Data Source=DESKTOP-IHLHQSB\SQLEXPRESS;Initial Catalog=QuanLyNhaSach;Integrated Security=True";
            SqlConnection connection = new SqlConnection(connectionString);

            // Tạo command để gọi stored procedure và truyền tham số
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter();
            SqlCommand cmd = new SqlCommand("sp_GetHoaDonBanByYear", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@nam", int.Parse(txtNam.Text)); // Giả sử năm được nhập vào từ textbox txtNam
            da.SelectCommand = cmd;
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            dataGridView1.Columns["sTenKH"].Visible = false;
            dataGridView1.Columns["sSdt"].Visible = false;
            double tongTien = 0;
            foreach (DataRow row in dt.Rows)
            {
                tongTien += Convert.ToDouble(row["fThanhTien"]);
            }
            txtTongtien.Text = tongTien.ToString();

          /*  try
            {
                // Mở kết nối và thực thi command
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                // Hiển thị kết quả lên các TextBox tương ứng   
                while (reader.Read())
                {
                    txtTenKh.Text = reader["sTenKH"].ToString();
                    txtSDT.Text = reader["sSdt"].ToString();
                   // txtNgaylap.Text = reader["dNgayLap"].ToString();
                }
                txtTongtien.Text = tongTien.ToString();
            }
            catch (Exception ex)
            {
                // Xử lý lỗi nếu có
                MessageBox.Show("Lỗi: " + ex.Message);
            }
            finally
            {
                // Đóng kết nối
                connection.Close();
            }*/


        }
    }
}
