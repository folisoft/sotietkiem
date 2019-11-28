﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SoTietKiem.Data;
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
                    if (soThang != loaiTietKiem.KyHan) return new { status = false, message = "Vui lòng gửi tiền đúng kỳ hạn." };
                }

                if(request.SoTien < 100000) return new { status = false, message = "Số tiền gửi phải lớn hơn 100,000 VNĐ." };

                var result = await service.ThemGuiRut(request, soTietKiem, loaiTietKiem, khongKyHan, chitietSoTruoc);
                return new { status = result };
            }
        }
    }
}