using Btl_QuanLyNhaSach.CrystalReport;
using Btl_QuanLyNhaSach.Modify;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Btl_QuanLyNhaSach
{
    public partial class tbltunghoadonnhap : Form
    {
        ModifyAll modify = new ModifyAll();
      
        // Đổ dữ liệu từ form danh sách hóa đơn nhập sang form từng hóa đơn nhập
        public tbltunghoadonnhap(string smahdnhap, string fthanhtien, string stennguoilaphd, DateTime dngaylaphd)
        {
            InitializeComponent();
            sMaHDNhap.Text = smahdnhap;
            fTongTien.Text = fthanhtien;
            dNgayNhap.Text = dngaylaphd.ToString();
            sTenTK.Text = stennguoilaphd;
        }

        // Danh sách
        private void tbltunghoadonnhap_Load(object sender, EventArgs e)
        {
            try
            {
                dataGridView_sanpham.DataSource = modify.Table("SELECT iID, sMaSach AS 'Mã Sách' ,iSoLuongNhap AS 'Số Lượng' ,fGiaSach AS 'Giá Sách' ,fThanhTien AS 'Thành Tiền'  FROM tblChiTietHoaDonNhap WHERE sMaHDNhap = '" + sMaHDNhap.Text + "'");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void btnInHoaDon_Click(object sender, EventArgs e)
        {
            using (SqlConnection cnn = Connection.GetSqlConnection())
            {       
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = cnn;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "proc_hoadonnhap";
                    cmd.Parameters.AddWithValue("@smahdnhap", sMaHDNhap.Text);
                    using (SqlDataAdapter ad = new SqlDataAdapter())
                    {
                        ad.SelectCommand = cmd;
                        DataTable dt = new DataTable();
                        ad.Fill(dt);
                        CrystalReport_hoadonnhap rpt1 = new CrystalReport_hoadonnhap();
                        rpt1.SetDataSource(dt);                    
                        this.Hide();
                        inhoadonnhap f = new inhoadonnhap();
                        f.crystalReportViewer1.ReportSource = rpt1;
                        f.ShowDialog();
                        f = null;
                        this.Show();
                    }
                }
                
            }
        }
    }
}
