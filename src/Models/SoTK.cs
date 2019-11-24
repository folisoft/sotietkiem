using System;
using System.Collections.Generic;

namespace SoTietKiem.Models
{
    public partial class SoTk
    {
        public SoTk()
        {
            PhieuGuiRutTien = new HashSet<PhieuGuiRutTien>();
        }

        public string Mskh { get; set; }
        public int LoaiTietKiemId { get; set; }
        public string KhachHang { get; set; }
        public string Cmnd { get; set; }
        public string DiaChi { get; set; }
        public DateTime? NgayMoSo { get; set; }
        public double? SoTienGui { get; set; }
        public DateTime? NgayDongSo { get; set; }
        public double? SoDu { get; set; }

        public virtual LoaiTietKiem LoaiTietKiem { get; set; }
        public virtual ICollection<PhieuGuiRutTien> PhieuGuiRutTien { get; set; }
    }
}
