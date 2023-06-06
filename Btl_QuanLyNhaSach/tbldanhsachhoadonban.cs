using Btl_QuanLyNhaSach.Modify;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Btl_QuanLyNhaSach
{
    public partial class tbldanhsachhoadonban : Form
    {
        ModifyAll modify = new ModifyAll();

        public tbldanhsachhoadonban()
        {
            InitializeComponent();
        }

        

        // Sử lí sự kiện click danh sách ra datagridview
        private void dataGridView_DanhSachHDBan_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView_DanhSachHDBan.Rows.Count > 1)
            {
                string smahdban = dataGridView_DanhSachHDBan.SelectedRows[0].Cells[0].Value.ToString();
                string stenkh = dataGridView_DanhSachHDBan.SelectedRows[0].Cells[2].Value.ToString();
                string stennguoilaphd = dataGridView_DanhSachHDBan.SelectedRows[0].Cells[1].Value.ToString();
                DateTime dngaylaphd = DateTime.Parse(dataGridView_DanhSachHDBan.SelectedRows[0].Cells[3].Value.ToString());
                string fthanhtien = dataGridView_DanhSachHDBan.SelectedRows[0].Cells[5].Value.ToString();
                tbltunghoadonban thd = new tbltunghoadonban(smahdban, stenkh, fthanhtien, stennguoilaphd, dngaylaphd);
                thd.ShowDialog();
            }
        }

        // Sử lí sự kiện tìm kiếm theo mã hóa đơn bán
        private void sMaHDBan_TextChanged(object sender, EventArgs e)
        {
            string name = sMaHDBan.Text;
            if (name == "")
            {
                danhsachhoadonban_Load(sender, e);
            }    
            else
            {
                string query = "select tblHoaDonBan.sMaHDBan AS N'Mã Hóa Đơn', sTenTk AS N'Tên Người Lập HĐ', tblKhachHang.sTenKH AS N'Tên Khách Hàng', dNgayLap AS N'Ngày Lập HĐ', COUNT(tblChiTietHoaDonBan.iSoLuongBan) AS N'Tổng Số Lượng Sách Bán', SUM(tblChiTietHoaDonBan.fThanhTien) AS N'Tổng Tiền' " +
                "FROM tblChiTietHoaDonBan inner join tblHoaDonBan on tblHoaDonBan.sMaHDBan = tblChiTietHoaDonBan.sMaHDBan " +
                "inner join tblKhachHang on tblHoaDonBan.sMaKH = tblKhachHang.sMaKH WHERE tblHoaDonBan.sMaHDBan LIKE N'%" + name + "%' group by tblHoaDonBan.sMaHDBan,sTenTk,tblKhachHang.sTenKH,dNgayLap";
                dataGridView_DanhSachHDBan.DataSource = modify.Table(query);
            }    
        }

        // Sử lí sự kiện đổ danh sách ra datagridview
        private void danhsachhoadonban_Load(object sender, EventArgs e)
        {
            try
            {
                dataGridView_DanhSachHDBan.DataSource = modify.Table("select tblHoaDonBan.sMaHDBan AS N'Mã Hóa Đơn', sTenTk AS N'Tên Người Lập HĐ', tblKhachHang.sTenKH AS N'Tên Khách Hàng', dNgayLap AS N'Ngày Lập HĐ', COUNT(tblChiTietHoaDonBan.iSoLuongBan) AS N'Tổng Số Lượng Sách Bán', SUM(tblChiTietHoaDonBan.fThanhTien) AS N'Tổng Tiền' " +
                    "FROM tblChiTietHoaDonBan inner join tblHoaDonBan on tblHoaDonBan.sMaHDBan = tblChiTietHoaDonBan.sMaHDBan inner join tblKhachHang on tblHoaDonBan.sMaKH = tblKhachHang.sMaKH where dNgayLap like GETDATE() group by tblHoaDonBan.sMaHDBan,sTenTk,tblKhachHang.sTenKH,dNgayLap");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

    }
}
