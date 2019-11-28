using SoTietKiem.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SoTietKiem.Models;
using Microsoft.EntityFrameworkCore;

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
            try
            {
                var soTK = new SoTk();
                soTK.LoaiTietKiemId = request.LoaiTietKiemId;
                soTK.KhachHang = request.KhachHang;
                soTK.Cmnd = request.Cmnd;
                soTK.DiaChi = request.DiaChi;
                soTK.NgayMoSo = request.NgayMoSo;
                soTK.SoTienGui = request.SoTienGui;
                soTK.SoDu = request.SoTienGui;
                context.SoTk.Add(soTK);

                var phieuGuiTien = new PhieuGuiRutTien
                {
                    Mskh = soTK.Mskh,
                    KhachHang = request.KhachHang,
                    SoTien = request.SoTienGui,
                    Ngay = DateTime.Now
                };
                context.PhieuGuiRutTien.Add(phieuGuiTien);
                context.SaveChanges();

                var loaiTK = context.LoaiTietKiem.Find(request.LoaiTietKiemId);
                var chiTietSo = new ChiTietSoTietKiem
                {
                    PhieuGuiRutTienId = phieuGuiTien.Id,
                    Mskh = soTK.Mskh,
                    NgayGui = request.NgayMoSo,
                    SoTienGui = request.SoTienGui,
                    LoaiTietKiemId = request.LoaiTietKiemId,
                    LaiSuat = loaiTK.LaiSuat,
                    SoDuDauKy = 0,
                    SoDuCuoiKy = request.SoTienGui,
                    SoThangLaiSuat = 0,
                    SoNgayLaiSuat = 0,
                    LaiSuatNgay = 0,
                    NghiepVu = "MO"
                };
                context.ChiTietSoTietKiem.Add(chiTietSo);

                return await context.SaveChangesAsync() > 0;
            }
            catch(Exception e)
            {
                throw e;
            }
        }
    }

    public partial class SoTietKiemRequest
    {
        public string Mskh { get; set; }
        public int LoaiTietKiemId { get; set; }
        public string KhachHang { get; set; }
        public string Cmnd { get; set; }
        public string DiaChi { get; set; }
        public DateTime NgayMoSo { get; set; }
        public float SoTienGui { get; set; }
    }
}
