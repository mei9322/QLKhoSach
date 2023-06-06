using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Btl_QuanLyNhaSach.Object
{
    class NhanVien
    {
        private string sMaNV;
        private string sTenNV;
        private string sDiaChi;
        private string sSDT;
        private string sTenLoai;

        public NhanVien(string sMaNV, string sTenNV, string sDiaChi, string sSDT, string sTenLoai)
        {
            this.sMaNV = sMaNV;
            this.sTenNV = sTenNV;
            this.sDiaChi = sDiaChi;
            this.sSDT = sSDT;
            this.sTenLoai = sTenLoai;
        }

        public string SMaNV { get => sMaNV; set => sMaNV = value; }
        public string STenNV { get => sTenNV; set => sTenNV = value; }
        public string SDiaChi { get => sDiaChi; set => sDiaChi = value; }
        public string SSDT { get => sSDT; set => sSDT = value; }
        public string STenLoai { get => sTenLoai; set => sTenLoai = value; }
    }

}
