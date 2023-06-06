using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Btl_QuanLyNhaSach
{
    class TaiKhoan
    {
        private string sTenTk;
        private string sMatKhau;

        public TaiKhoan()
        {

        }

        public TaiKhoan(string sTenTk, string sMatKhau)
        {
            this.sTenTk = sTenTk;
            this.sMatKhau = sMatKhau;
        }

        public string STenTk { get => sTenTk; set => sTenTk = value; }
        public string SMatKhau { get => sMatKhau; set => sMatKhau = value; }
    }
}
