using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Btl_QuanLyNhaSach.Object
{
    class NhaXuatBan
    {
        private string sMaNXB;
        private string sTenNXB;
        private string sDiaChi;

        public NhaXuatBan()
        {
        }

        public NhaXuatBan(string sMaNXB, string sTenNXB)
        {
            this.sMaNXB = sMaNXB;
            this.sTenNXB = sTenNXB;
        }

        public string SMaNXB { get => sMaNXB; set => sMaNXB = value; }
        public string STenNXB { get => sTenNXB; set => sTenNXB = value; }
        public string SDiaChi { get => sDiaChi; set => sDiaChi = value; }
    }
}
