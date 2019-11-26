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
    [Route("loaitietkiem")]
    public class LoaiTietKiemController : ControllerBase
    {
        [HttpGet("")]
        public async Task<IActionResult> GetAll()
        {
            var optionsBuilder = new DbContextOptions<DatabaseContext>();
            using (var db = new DatabaseContext(optionsBuilder))
            {
                var loaiTietKiem = db.LoaiTietKiem.ToList();

                return Ok(loaiTietKiem);
            }
        }

        [HttpPost("")]
        public async Task<IActionResult> Create(LoaiTietKiemDto model)
        {
            var optionsBuilder = new DbContextOptions<DatabaseContext>();
            using (var db = new DatabaseContext(optionsBuilder))
            {
                var result = false;
                var loaiTietKiemMoi = new LoaiTietKiem()
                {
                    TenLoaiTietKiem = model.TenLoaiTietKiem,
                    LaiSuat = model.LaiSuat,
                    NgayHieuLuc = model.NgayHieuLuc
                };
                db.LoaiTietKiem.Add(loaiTietKiemMoi);
                result = db.SaveChanges() > 0;


                return this.Ok(result);
            }
        }

        [HttpPut("")]
        public async Task<IActionResult> Edit(LoaiTietKiemDto model)
        {
            var optionsBuilder = new DbContextOptions<DatabaseContext>();
            using (var db = new DatabaseContext(optionsBuilder))
            {
                var result = false;
                var loaiTietKiem = db.LoaiTietKiem.FirstOrDefault(ltk => ltk.Id == model.Id);
                if (loaiTietKiem != null)
                {
                    loaiTietKiem.TenLoaiTietKiem = model.TenLoaiTietKiem;
                    loaiTietKiem.LaiSuat = model.LaiSuat;
                    loaiTietKiem.NgayHieuLuc = model.NgayHieuLuc;

                    result = db.SaveChanges() > 0;
                }

                return this.Ok(result);
            }
        }

        [HttpPost("delete")]
        public async Task<IActionResult> Delete(int id)
        {
            var optionsBuilder = new DbContextOptions<DatabaseContext>();
            using (var db = new DatabaseContext(optionsBuilder))
            {
                var result = false;
                var loaiTietKiem = db.LoaiTietKiem.FirstOrDefault(ltk => ltk.Id == id);
                if (loaiTietKiem != null)
                {
                    db.LoaiTietKiem.Remove(loaiTietKiem);
                    result = db.SaveChanges() > 0;
                }
                

                return this.Ok(result);
            }
        }
    }
}