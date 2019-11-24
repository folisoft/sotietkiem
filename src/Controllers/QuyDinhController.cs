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
    [Route("api/quydinh")]
    public class QuyDinhController : ControllerBase
    {
        [HttpGet("")]
        public IEnumerable<QuyDinh> GetAll()
        {
            var optionsBuilder = new DbContextOptions<DatabaseContext>();
            using (var db = new DatabaseContext(optionsBuilder))
            {
                var quiDinh = db.QuyDinh.ToList();

                return quiDinh;
            }
        }
    }
}