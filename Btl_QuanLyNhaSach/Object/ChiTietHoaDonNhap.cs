using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Btl_QuanLyNhaSach.Object
{
    class ChiTietHoaDonNhap
    {
        private int iID;
        private string sMaHDNhap;
        private string sMaSach;
        private int iSoLuongNhap;
        private float fGiaSach;
        private float fThanhTien;

        public ChiTietHoaDonNhap()
        {
        }

        public ChiTietHoaDonNhap(int iID, string sMaHDNhap, string sMaSach, int iSoLuongNhap, float fGiaSach, float fThanhTien)
        {
            this.iID = iID;
            this.sMaHDNhap = sMaHDNhap;
            this.sMaSach = sMaSach;
            this.iSoLuongNhap = iSoLuongNhap;
            this.fGiaSach = fGiaSach;
            this.fThanhTien = fThanhTien;
        }

        public int IID { get => iID; set => iID = value; }
        public string SMaHDNhap { get => sMaHDNhap; set => sMaHDNhap = value; }
        public string SMaSach { get => sMaSach; set => sMaSach = value; }
        public int ISoLuongNhap { get => iSoLuongNhap; set => iSoLuongNhap = value; }
        public float FGiaSach { get => fGiaSach; set => fGiaSach = value; }
        public float FThanhTien { get => fThanhTien; set => fThanhTien = value; }
    }
}
