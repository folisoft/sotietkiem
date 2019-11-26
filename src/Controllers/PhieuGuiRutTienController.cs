using System;
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
        public async Task<ActionResult<bool>> ThemPhieu(ThemGuiRutTienRequest request)
        {
            using (var context = new DatabaseContext())
            {
                var service = new GuiRutTienService(context);
                var result = await service.ThemGuiRut(request);
                return result;
            }
        }
    }
}