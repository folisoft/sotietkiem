using System;
using System.Collections.Generic;

namespace SoTietKiem.Models
{
    public partial class LoaiTietKiem
    {
        public LoaiTietKiem()
        {
            SoTietKiem = new HashSet<SoTK>();
        }

        public int Id { get; set; }
        public int? LoaiTietKiem1 { get; set; }
        public double? LaiSuat { get; set; }
        public DateTime? NgayHieuLuc { get; set; }
        public int? KyHan { get; set; }

        public virtual ICollection<SoTK> SoTietKiem { get; set; }
    }
}
