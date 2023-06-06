using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Btl_QuanLyNhaSach
{
    class Sach
    {
        private string sMaSach;
        private string sTenSach;
        private float fGiaSach;
        private int iSoLuong;
        private string sMaNXB;
        private string sTheLoai;

        public Sach()
        {
        }

        public Sach(string sMaSach, string sTenSach, float fGiaSach, int iSoLuong, string sMaNXB, string sTheLoai)
        {
            this.sMaSach = sMaSach;
            this.sTenSach = sTenSach;
            this.fGiaSach = fGiaSach;
            this.iSoLuong = iSoLuong;
            this.sMaNXB = sMaNXB;
            this.sTheLoai = sTheLoai;
        }

        public string SMaSach { get => sMaSach; set => sMaSach = value; }
        public string STenSach { get => sTenSach; set => sTenSach = value; }
        public float FGiaSach { get => fGiaSach; set => fGiaSach = value; }
        public int ISoLuong { get => iSoLuong; set => iSoLuong = value; }
        public string SMaNXB { get => sMaNXB; set => sMaNXB = value; }
        public string STheLoai { get => sTheLoai; set => sTheLoai = value; }
    }
}
