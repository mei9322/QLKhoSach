using Btl_QuanLyNhaSach.CrystalReport;
using Btl_QuanLyNhaSach.Modify;
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
    public partial class tbltunghoadonban : Form
    {
        ModifyAll modify = new ModifyAll();

        // Đổ dữ liệu từ form danh sách hóa đơn bán sang form từng hóa đơn bán
        public tbltunghoadonban(string smahdban, string stenkh, string fthanhtien, string stennguoilaphd, DateTime dngaylaphd)
        {
            InitializeComponent();
            sMaHDBan.Text = smahdban;
            sTenKH.Text = stenkh;
            fTongTien.Text = fthanhtien;
            sTenTk.Text = stennguoilaphd;
            dNgayLap.Text = dngaylaphd.ToString();
        }

        // Danh sách
        private void tbltunghoadonban_Load(object sender, EventArgs e)
        {
            try
            {
                dataGridView_sanpham.DataSource = modify.Table("SELECT iID, sMaSach AS 'Mã Sách',sTenSach AS 'Tên Sách' ,iSoLuongBan AS 'Số Lượng' ,fGiaSach AS 'Giá Sách' ,fThanhTien AS 'Thành Tiền'  FROM tblChiTietHoaDonBan WHERE sMaHDBan = '" + sMaHDBan.Text +"'");
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
                    cmd.CommandText = "proc_hoadonban";
                    cmd.Parameters.AddWithValue("@smahdban", sMaHDBan.Text);
                    using (SqlDataAdapter ad = new SqlDataAdapter())
                    {
                        ad.SelectCommand = cmd;
                        DataTable dt = new DataTable();
                        ad.Fill(dt);
                        CrystalReport_hoadonban rpt1 = new CrystalReport_hoadonban();
                        rpt1.SetDataSource(dt);
                        this.Hide();
                        inhoadonban f = new inhoadonban();
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
