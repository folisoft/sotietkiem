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
    [Route("api/sotietkiem")]
    public class SoTietKiemController : ControllerBase
    {
        [HttpPost]
        [Route("add")]
        public async Task<ActionResult<bool>> MoSoTietKiem(SoTietKiemRequest request)
        {
            using(var context = new DatabaseContext())
            {
                var soTKService = new SoTietKiemService(context);
                var result = await soTKService.MoSoTietKiemAsync(request);
                return result;
            }
        }

        [HttpGet]
        [Route("getloaitietkiem")]
        public async Task<ActionResult<IEnumerable<LoaiTietKiemResponse>>> GetLoaiTietKiems()
        {
            using (var context = new DatabaseContext())
            {
                var soTKService = new SoTietKiemService(context);
                var result = await soTKService.GetLoaiTietKiems();
                return this.Ok(result);
            }
        }
    }
}