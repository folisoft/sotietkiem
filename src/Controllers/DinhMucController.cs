using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SoTietKiem.Data;
using SoTietKiem.Models;
using SoTietKiem.Models.Dto;

namespace SoTietKiem.Controllers
{
    [ApiController]
    [Route("dinhmuc")]
    public class DinhMucController : ControllerBase
    {
        [HttpGet("")]
        public async Task<IActionResult> Get()
        {
            var optionsBuilder = new DbContextOptions<DatabaseContext>();
            using (var db = new DatabaseContext(optionsBuilder))
            {
                var dinhMuc = db.DinhMuc.FirstOrDefault();

                return Ok(dinhMuc);
            }
        }

        [HttpPut("")]
        public async Task<IActionResult> Edit(DinhMucDto model)
        {
            var optionsBuilder = new DbContextOptions<DatabaseContext>();
            using (var db = new DatabaseContext(optionsBuilder))
            {
                var dinhMuc = db.DinhMuc.FirstOrDefault(dm => dm.Id == model.Id);
                if (dinhMuc != null)
                {
                    dinhMuc.TienGuiLanDauToiThieu = model.TienGuiLanDauToiThieu;

                    db.SaveChanges();
                }

                return this.Ok(model);
            }
        }
    }
}