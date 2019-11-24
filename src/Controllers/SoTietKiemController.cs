using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SoTietKiem.Data;
using SoTietKiem.Services;

namespace SoTietKiem.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SoTietKiemController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [Route("add")]
        public async Task<bool> MoSoTietKiem(SoTietKiemRequest request)
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