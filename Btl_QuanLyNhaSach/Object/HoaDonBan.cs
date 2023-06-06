using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Btl_QuanLyNhaSach.Object
{
    class HoaDonBan
    {
        private string sMaHDBan;
        private string sTenTk;
        private string sMaKH;
        private DateTime dNgayLap;

        public HoaDonBan()
        {
        }

        public HoaDonBan(string sMaHDBan, string sTenTk, string sMaKH, DateTime dNgayLap)
        {
            this.sMaHDBan = sMaHDBan;
            this.sTenTk = sTenTk;
            this.sMaKH = sMaKH;
            this.dNgayLap = dNgayLap;
        }

        public string SMaHDBan { get => sMaHDBan; set => sMaHDBan = value; }
        public string STenTk { get => sTenTk; set => sTenTk = value; }
        public string SMaKH { get => sMaKH; set => sMaKH = value; }
        public DateTime DNgayLap { get => dNgayLap; set => dNgayLap = value; }
    }
}
