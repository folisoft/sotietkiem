using System;
using System.Collections.Generic;

namespace SoTietKiem.Models
{
    public partial class LoaiTietKiem
    {
        public LoaiTietKiem()
        {
            SoTk = new HashSet<SoTk>();
        }

        public int Id { get; set; }
        public string LoaiTietKiem1 { get; set; }
        public double? LaiSuat { get; set; }
        public DateTime? NgayHieuLuc { get; set; }
        public int? KyHan { get; set; }

        public virtual ICollection<SoTk> SoTk { get; set; }
    }
}
