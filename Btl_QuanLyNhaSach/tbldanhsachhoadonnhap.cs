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
    public partial class tbldanhsachhoadonnhap : Form
    {
        ModifyAll modify = new ModifyAll();

        public tbldanhsachhoadonnhap()
        {
            InitializeComponent();
        }


        // Xử lí sự kiện click 1 hóa đơn trong datagridview thì dữ liệu sẽ đổ sang form chi tiết hóa đơn đó
        private void dataGridView_DanhSachHDNhap_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView_DanhSachHDNhap.Rows.Count > 1)
            {
                string smahdnhap = dataGridView_DanhSachHDNhap.SelectedRows[0].Cells[0].Value.ToString();
                string stennguoilaphd = dataGridView_DanhSachHDNhap.SelectedRows[0].Cells[1].Value.ToString();
                DateTime dngaylaphd = DateTime.Parse(dataGridView_DanhSachHDNhap.SelectedRows[0].Cells[2].Value.ToString());
                string fthanhtien = dataGridView_DanhSachHDNhap.SelectedRows[0].Cells[4].Value.ToString();
                tbltunghoadonnhap thd = new tbltunghoadonnhap(smahdnhap, fthanhtien, stennguoilaphd, dngaylaphd);
                thd.ShowDialog();
            }
        }

        // Hiện dữ liệu ra bảng 
        private void tbldanhsachhoadonnhap_Load(object sender, EventArgs e)
        {
            try
            {
                dataGridView_DanhSachHDNhap.DataSource = modify.Table("select tblHoaDonNhap.sMaHDNhap AS N'Mã Hóa Đơn', sTenTk AS N'Tên Người Lập HĐ', dNgayNhap AS N'Ngày Nhập HĐ', COUNT(tblChiTietHoaDonNhap.iSoLuongNhap) AS N'Tổng Số Lượng Sách Nhập', SUM(tblChiTietHoaDonNhap.fThanhTien) AS N'Tổng Tiền' FROM tblChiTietHoaDonNhap inner join tblHoaDonNhap on tblHoaDonNhap.sMaHDNhap = tblChiTietHoaDonNhap.sMaHDNhap where dNgayNhap like GETDATE() group by tblHoaDonNhap.sMaHDNhap, sTenTk, dNgayNhap");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        // Xử lí sự kiện tìm kiếm theo mã hóa đơn bán
        private void sMaHDBan_TextChanged(object sender, EventArgs e)
        {
            string name = sMaHDBan.Text;
            if (name == "")
            {
                tbldanhsachhoadonnhap_Load(sender, e);
            }
            else
            {
                string query = "select tblHoaDonNhap.sMaHDNhap AS N'Mã Hóa Đơn', sTenTk AS N'Tên Người Lập HĐ', dNgayNhap AS N'Ngày Nhập HĐ', COUNT(tblChiTietHoaDonNhap.iSoLuongNhap) AS N'Tổng Số Lượng Sách Nhập', SUM(tblChiTietHoaDonNhap.fThanhTien) AS N'Tổng Tiền' " +
                "FROM tblChiTietHoaDonNhap inner join tblHoaDonNhap on tblHoaDonNhap.sMaHDNhap = tblChiTietHoaDonNhap.sMaHDNhap " +
                "WHERE tblHoaDonNhap.sMaHDNhap LIKE N'%" + name + "%' group by tblHoaDonNhap.sMaHDNhap, sTenTk, dNgayNhap";
                dataGridView_DanhSachHDNhap.DataSource = modify.Table(query);
            }
        }




    }
}
