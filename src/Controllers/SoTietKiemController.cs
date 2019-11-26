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
            using(var context = new DatabaseContext())
            {
                var soTKService = new SoTietKiemService(context);
                var result = await soTKService.MoSoTietKiemAsync(request);
                return result;
            }
        }
    }
}