using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Btl_QuanLyNhaSach.Object
{
    class ChiTietHoaDonBan
    {
        private int iID;
        private string sMaHDBan;
        private string sMaSach;
        private string sTenSach;
        private int iSoLuongBan;
        private float fGiaSach;
        private float fThanhTien;

        public ChiTietHoaDonBan()
        {
        }

        public ChiTietHoaDonBan(int iID, string sMaHDBan, string sMaSach, string sTenSach, int iSoLuongBan, float fGiaSach, float fThanhTien)
        {
            this.iID = iID;
            this.sMaHDBan = sMaHDBan;
            this.sMaSach = sMaSach;
            this.sTenSach = sTenSach;
            this.iSoLuongBan = iSoLuongBan;
            this.fGiaSach = fGiaSach;
            this.fThanhTien = fThanhTien;
        }

        public int IID { get => iID; set => iID = value; }
        public string SMaHDBan { get => sMaHDBan; set => sMaHDBan = value; }
        public string SMaSach { get => sMaSach; set => sMaSach = value; }
        public string STenSach { get => sTenSach; set => sTenSach = value; }
        public int ISoLuongBan { get => iSoLuongBan; set => iSoLuongBan = value; }
        public float FGiaSach { get => fGiaSach; set => fGiaSach = value; }
        public float FThanhTien { get => fThanhTien; set => fThanhTien = value; }
    }
}
