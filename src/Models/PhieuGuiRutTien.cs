using System;
using System.Collections.Generic;

namespace SoTietKiem.Models
{
    public partial class PhieuGuiRutTien
    {
        public int Id { get; set; }
        public int? Mskh { get; set; }
        public string KhachHang { get; set; }
        public double? SoTien { get; set; }
        public DateTime? Ngay { get; set; }

        public virtual SoTK MskhNavigation { get; set; }
        public virtual ChiTietSoTietKiem ChiTietSoTietKiem { get; set; }
    }
}
