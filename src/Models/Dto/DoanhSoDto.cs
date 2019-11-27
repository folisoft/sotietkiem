using System;
using System.Collections.Generic;

namespace SoTietKiem.Models.Dto
{
    public class DoanhSoDto
    {
        public int? LoaiTietKiemId { get; set; }
        public string TenLoaiTietKiem { get; set; }
        public double? TongThu { get; set; }
        public double? TongChi { get; set; }
    }

    public class DoanhSoMoDongDto
    {
        public DateTime? Ngay { get; set; }
        public double? TongMo { get; set; }
        public double? TongDong { get; set; }
    }
}
