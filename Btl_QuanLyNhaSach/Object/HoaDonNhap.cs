using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Btl_QuanLyNhaSach.Object
{
    class HoaDonNhap
    {
        private string sMaHDNhap;
        private string sTenTk;
        private DateTime dNgayNhap;

        public HoaDonNhap() { }

        public HoaDonNhap(string sMaHDNhap, string sTenTk, DateTime dNgayNhap)
        {
            this.sMaHDNhap = sMaHDNhap;
            this.sTenTk = sTenTk;
            this.dNgayNhap = dNgayNhap;
        }

        public string SMaHDNhap { get => sMaHDNhap; set => sMaHDNhap = value; }
        public string STenTk { get => sTenTk; set => sTenTk = value; }
        public DateTime DNgayNhap { get => dNgayNhap; set => dNgayNhap = value; }
    }
}
