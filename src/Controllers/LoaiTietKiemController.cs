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

namespace SoTietKiem.Controllers
{
    [ApiController]
    [Route("api/loaitietkiem")]
    public class LoaiTietKiemController : ControllerBase
    {
        [HttpGet("")]
        public IEnumerable<LoaiTietKiem> GetAll()
        {
            var optionsBuilder = new DbContextOptions<DatabaseContext>();
            using (var db = new DatabaseContext(optionsBuilder))
            {
                var loaiTietKiem = db.LoaiTietKiem.ToList();

                return loaiTietKiem;
            }
        }
    }
}