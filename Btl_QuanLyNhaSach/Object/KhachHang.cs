using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Btl_QuanLyNhaSach.Object
{
    class KhachHang
    {
        private string sMaKH;
        private string sTenKH;
        private string sDiaChi;
        private string sSdt;
        private string sEmail;

        public KhachHang()
        {
        }

        public KhachHang(string sMaKH, string sTenKH, string sDiaChi, string sSdt, string sEmail)
        {
            this.sMaKH = sMaKH;
            this.sTenKH = sTenKH;
            this.sDiaChi = sDiaChi;
            this.sSdt = sSdt;
            this.sEmail = sEmail;
        }

        public string SMaKH { get => sMaKH; set => sMaKH = value; }
        public string STenKH { get => sTenKH; set => sTenKH = value; }
        public string SDiaChi { get => sDiaChi; set => sDiaChi = value; }
        public string SSdt { get => sSdt; set => sSdt = value; }
        public string SEmail { get => sEmail; set => sEmail = value; }
    }
}
