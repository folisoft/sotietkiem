using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SoTietKiem.Models
{
    public partial class ChiTietSoTietKiem
    {
        public int PhieuGuiRutTienId { get; set; }
        public string Mskh { get; set; }
        public DateTime? NgayGui { get; set; }
        public double? SoTienGui { get; set; }
        public DateTime? NgayRut { get; set; }
        public double? SoTienRut { get; set; }
        public int? LoaiTietKiemId { get; set; }
        public double? LaiSuat { get; set; }
        public double? SoDuDauKy { get; set; }
        public int? SoThangLaiSuat { get; set; }
        public double? LaiSuatThang { get; set; }
        public int? SoNgayLaiSuat { get; set; }
        public double? LaiSuatNgay { get; set; }
        public double? SoDuCuoiKy { get; set; }
        public string NghiepVu { get; set; }

        public virtual PhieuGuiRutTien PhieuGuiRutTien { get; set; }
    }
}
