using System;
using System.Collections.Generic;

namespace SoTietKiem.Models.Dto
{
    public class LoaiTietKiemDto
    {
        public int Id { get; set; }
        public string TenLoaiTietKiem { get; set; }
        public double LaiSuat { get; set; }
        public DateTime NgayHieuLuc { get; set; }
    }
}
