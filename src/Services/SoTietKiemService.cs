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
            var soTK = new SoTk();
            soTK.Mskh = request.Mskh;
            soTK.LoaiTietKiemId = request.LoaiTietKiemId;
            soTK.KhachHang = request.KhachHang;
            soTK.Cmnd = request.Cmnd;
            soTK.DiaChi = request.DiaChi;
            soTK.NgayMoSo = request.NgayMoSo;
            soTK.SoTienGui = request.SoTienGui;
            //soTK.NgayDongSo = request.NgayDongSo;
            soTK.SoDu = request.SoTienGui;
            context.SoTk.Add(soTK);

            return await context.SaveChangesAsync() > 0;
        }

        public async Task<IEnumerable<LoaiTietKiemResponse>> GetLoaiTietKiems()
        {
            var loaitietkiems = await context.LoaiTietKiem.ToListAsync();
            var responses = new List<LoaiTietKiemResponse>();
            foreach(var item in loaitietkiems)
            {
                var res = new LoaiTietKiemResponse { Value = item.Id, Name = item.LoaiTietKiem1 };
                responses.Add(res);
            }
            return responses;
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
        public DateTime NgayDongSo { get; set; }
    }

    public partial class LoaiTietKiemResponse
    {
        public int Value { get; set; }
        public string Name { get; set; }
    }
}
