using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SoTietKiem.Data;
using SoTietKiem.Models;
using SoTietKiem.Services;

namespace SoTietKiem.Controllers
{
    [ApiController]
    [Route("sotietkiem")]
    public class SoTietKiemController : ControllerBase
    {
        [HttpPost]
        [Route("")]
        public async Task<ActionResult<bool>> MoSoTietKiem(SoTietKiemRequest request)
        {
            using (var context = new DatabaseContext())
            {
                var dinhMuc = context.DinhMuc.FirstOrDefault();
                if (request.SoTienGui < dinhMuc.TienGuiLanDauToiThieu)
                {
                    return Ok(new { status = false, message = "Số tiền gửi lần đầu phải lớn hơn " + dinhMuc.TienGuiLanDauToiThieu + " VNĐ." });
                }
                var soTKService = new SoTietKiemService(context);
                var result = await soTKService.MoSoTietKiemAsync(request);
                if (result)
                {
                    return Ok(new { status = result, message = "Mở sổ thành công!" });
                }
                else return Ok(new { status = result, message = "Mở sổ thất bại. Vui lòng thử lại sau!" });
            }
        }
    }
}