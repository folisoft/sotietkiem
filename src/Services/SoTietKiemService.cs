using SoTietKiem.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SoTietKiem.Models;

namespace SoTietKiem.Services
{
    public class SoTietKiemService
    {
        private DatabaseContext context;

        public SoTietKiemService(DatabaseContext context)
        {
            this.context = context;
        }

        public async Task<bool> MoSoTietKiemAsync(SoTietKiemRequest request)
        {
            var soTK = new SoTk();
            soTK.LoaiTietKiemId = request.LoaiTietKiemId;
            soTK.KhachHang = request.KhachHang;
            soTK.Cmnd = request.Cmnd;
            soTK.DiaChi = request.DiaChi;
            soTK.NgayMoSo = request.NgayMoSo;
            soTK.SoTienGui = request.SoTienGui;
            soTK.NgayDongSo = request.NgayDongSo;
            soTK.SoDu = request.SoDu;
            context.SoTk.Add(soTK);
            return await context.SaveChangesAsync() > 0;
        }
    }

    public partial class SoTietKiemRequest
    {
        public int LoaiTietKiemId { get; set; }
        public string KhachHang { get; set; }
        public string Cmnd { get; set; }
        public string DiaChi { get; set; }
        public DateTime NgayMoSo { get; set; }
        public float SoTienGui { get; set; }
        public DateTime NgayDongSo { get; set; }
        public float SoDu { get; set; }
    }
}
