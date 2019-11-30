using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SoTietKiem.Data;
using SoTietKiem.Models;
using SoTietKiem.Services;

namespace SoTietKiem.Controllers
{
    [Route("guirutien")]
    [ApiController]
    public class PhieuGuiRutTienController : ControllerBase
    {
        [HttpPost]
        [Route("")]
        public async Task<ActionResult<object>> ThemPhieu(ThemGuiRutTienRequest request)
        {
            using (var context = new DatabaseContext())
            {
                var service = new GuiRutTienService(context);

                var soTietKiem = context.SoTk.Find(request.MSKH);
                var loaiTietKiem = context.LoaiTietKiem.Find(soTietKiem.LoaiTietKiemId);
                var khongKyHan = context.LoaiTietKiem.Find(1);
                var chitietSoTruoc = context.ChiTietSoTietKiem.Where(ct => ct.Mskh == request.MSKH).OrderByDescending(ord => ord.NgayGui).ToList()[0];
                if (loaiTietKiem.KyHan > 0)
                {
                    var truoc = request.Ngay;
                    var sau = chitietSoTruoc.NgayGui;
                    int soNam = truoc.Year - sau.Value.Year;
                    int soThang = 0;
                    if (soNam > 0) soThang = truoc.Month + 12 - sau.Value.Month;
                    else soThang = truoc.Month - sau.Value.Month;
                    if (soThang != loaiTietKiem.KyHan)
                    {
                        if (request.Action == "GUI ") return new { status = false, message = "Vui lòng gửi tiền đúng kỳ hạn." };
                    }
                }
                var compare = DateTime.Compare(request.Ngay, chitietSoTruoc.NgayGui.Value);
                if (compare < 0)
                {
                    return new { status = false, message = "Rút tiền sau ngày " + chitietSoTruoc.NgayGui.Value.ToString("dd/MM/yyyy") + "." };
                }

                if (request.SoTien < 100000) return new { status = false, message = "Số tiền gửi tối thiểu phải lớn hơn 100,000 VNĐ." };

                var result = await service.ThemGuiRut(request, soTietKiem, loaiTietKiem, khongKyHan, chitietSoTruoc);
                return new { status = result };
            }
        }


        [HttpGet]
        [Route("")]
        public async Task<ActionResult<IEnumerable<PhieuGuiRutTien>>> GetChiTietSo(string mskh)
        {
            using(var context = new DatabaseContext())
            {
                var result = await context.PhieuGuiRutTien.Include(c => c.ChiTietSoTietKiem).Where(p => p.Mskh == mskh).OrderByDescending(ord => ord.Ngay).ToListAsync();
                return result;
            }
        }
    }
}