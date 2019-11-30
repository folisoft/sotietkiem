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
    [Route("baocao")]
    public class BaoCaoController : ControllerBase
    {
        [HttpGet("doanhso")]
        public async Task<IActionResult> GetBaoCaoDoanhSo(string day)
        {
            var ngayChon = DateTime.Parse(day);
            var optionsBuilder = new DbContextOptions<DatabaseContext>();
            using (var db = new DatabaseContext(optionsBuilder))
            {
                var doanhSoThu = from p in db.PhieuGuiRutTien
                                 join c in db.ChiTietSoTietKiem on p.Id equals c.PhieuGuiRutTienId
                                 join l in db.LoaiTietKiem on c.LoaiTietKiemId equals l.Id
                                 where (c.NghiepVu == "MO" || c.NghiepVu == "GUI")
                                 && c.NgayGui.Value.Date == ngayChon.Date
                                 select new
                                 {
                                     LoaiTietKiemId = c.LoaiTietKiemId,
                                     TenLoaiTietKiem = l.TenLoaiTietKiem,
                                     SoTien = p.SoTien
                                 } into s group s by new { s.LoaiTietKiemId, s.TenLoaiTietKiem } into g
                                 select new { TongThu = g.Sum(t => t.SoTien), g.Key.LoaiTietKiemId, g.Key.TenLoaiTietKiem };

                var doanhSoChi = from p in db.PhieuGuiRutTien
                                 join c in db.ChiTietSoTietKiem on p.Id equals c.PhieuGuiRutTienId
                                 join l in db.LoaiTietKiem on c.LoaiTietKiemId equals l.Id
                                 where (c.NghiepVu == "RUT" || c.NghiepVu == "DONG")
                                 && c.NgayRut.Value.Date == ngayChon.Date
                                 select new
                                 {
                                     LoaiTietKiemId = c.LoaiTietKiemId,
                                     TenLoaiTietKiem = l.TenLoaiTietKiem,
                                     SoTien = p.SoTien ?? 0
                                 } into s
                                 group s by new { s.LoaiTietKiemId, s.TenLoaiTietKiem } into g
                                 select new { TongChi = g.Sum(t => t.SoTien), g.Key.LoaiTietKiemId, g.Key.TenLoaiTietKiem };
                
                var doanhSo = new List<DoanhSoDto>();
                var isExistDoanhSoThu = doanhSoThu.Any();
                var isExistDoanhSoChi = doanhSoChi.Any();
                if (isExistDoanhSoThu && isExistDoanhSoChi) 
                {
                    var loaiTk = (from thu in doanhSoThu select new { LoaiTietKiemId = thu.LoaiTietKiemId, TenLoaiTietKiem = thu.TenLoaiTietKiem })
                                .Union(from chi in doanhSoChi select new { LoaiTietKiemId = chi.LoaiTietKiemId, TenLoaiTietKiem = chi.TenLoaiTietKiem });

                    var doanhSoThuByLoaiTietKiem = from l in loaiTk
                                                   join thu in doanhSoThu on l.LoaiTietKiemId equals thu.LoaiTietKiemId into dstltk
                                                   from p in dstltk.DefaultIfEmpty()
                                                   select new 
                                                   {
                                                       LoaiTietKiemId = l.LoaiTietKiemId,
                                                       TenLoaiTietKiem = l.TenLoaiTietKiem,
                                                       TongThu = p == null ? 0 : p.TongThu 
                                                   };

                    var doanhSoChiByLoaiTietKiem = from l in loaiTk
                                                   join chi in doanhSoChi on l.LoaiTietKiemId equals chi.LoaiTietKiemId into dscltk
                                                   from p in dscltk.DefaultIfEmpty()
                                                   select new
                                                   {
                                                       LoaiTietKiemId = l.LoaiTietKiemId,
                                                       TenLoaiTietKiem = l.TenLoaiTietKiem,
                                                       TongChi = p == null ? 0 : p.TongChi
                                                   };

                    var doanhSoNgay = from thu in doanhSoThuByLoaiTietKiem
                                      join chi in doanhSoChiByLoaiTietKiem on thu.LoaiTietKiemId equals chi.LoaiTietKiemId
                                  into temp from j in temp.DefaultIfEmpty()
                                      select new DoanhSoDto
                                  {
                                      LoaiTietKiemId = thu.LoaiTietKiemId,
                                      TenLoaiTietKiem = thu.TenLoaiTietKiem,
                                      TongThu = thu.TongThu,
                                      TongChi = j.TongChi
                                  };
                    return Ok(doanhSoNgay.ToList());
                }
                else if (isExistDoanhSoThu && !isExistDoanhSoChi)
                {
                    var doanhSoNgay = from thu in doanhSoThu
                                   select new DoanhSoDto
                                   {
                                       LoaiTietKiemId = thu.LoaiTietKiemId,
                                       TenLoaiTietKiem = thu.TenLoaiTietKiem,
                                       TongThu = thu.TongThu,
                                       TongChi = 0
                                   };
                    return Ok(doanhSoNgay.ToList());
                }
                else if (!isExistDoanhSoThu && isExistDoanhSoChi)
                {
                    var doanhSoNgay = from chi in doanhSoChi
                                   select new DoanhSoDto
                                   {
                                       LoaiTietKiemId = chi.LoaiTietKiemId,
                                       TenLoaiTietKiem = chi.TenLoaiTietKiem,
                                       TongThu = 0,
                                       TongChi = chi.TongChi
                                   };
                    return Ok(doanhSoNgay.ToList());
                }


                return Ok(doanhSo);
            }
        }

        [HttpGet("modong")]
        public async Task<IActionResult> GetBaoCaoMoDong(int loaiTietKiem, string thang)
        {
            var ngayChon = DateTime.Parse(thang);
            var optionsBuilder = new DbContextOptions<DatabaseContext>();
            using (var db = new DatabaseContext(optionsBuilder))
            {
                var doanhSoMo = from p in db.PhieuGuiRutTien
                                 join c in db.ChiTietSoTietKiem on p.Id equals c.PhieuGuiRutTienId
                                 where c.NghiepVu == "MO"
                                 && c.LoaiTietKiemId == loaiTietKiem
                                 && c.NgayGui.Value.Month == ngayChon.Month
                                 && c.NgayGui.Value.Year == ngayChon.Year
                                select new
                                 {
                                     Ngay = c.NgayGui.Value.Date,
                                     SoTien = p.SoTien
                                 } into s
                                 group s by new { s.Ngay } into g
                                 select new { TongMo = g.Sum(t => t.SoTien), g.Key.Ngay };

                var doanhSoDong = from p in db.PhieuGuiRutTien
                                 join c in db.ChiTietSoTietKiem on p.Id equals c.PhieuGuiRutTienId
                                 join l in db.LoaiTietKiem on c.LoaiTietKiemId equals l.Id
                                 where c.NghiepVu == "DONG"
                                 && c.LoaiTietKiemId == loaiTietKiem
                                 && c.NgayRut.Value.Month == ngayChon.Month
                                 && c.NgayRut.Value.Year == ngayChon.Year
                                 select new
                                 {
                                     Ngay = c.NgayRut.Value.Date,
                                     SoTien = p.SoTien
                                 } into s
                                 group s by new { s.Ngay } into g
                                 select new { TongDong = g.Sum(t => t.SoTien), g.Key.Ngay };

                var doanhSo = new List<DoanhSoMoDongDto>();
                var isExistDoanhSoThu = doanhSoMo.Any();
                var isExistDoanhSoChi = doanhSoDong.Any();
                if (isExistDoanhSoThu && isExistDoanhSoChi)
                {
                    var loaiTk = (from mo in doanhSoMo select new { Ngay = mo.Ngay })
                                .Union(from dong in doanhSoDong select new { Ngay = dong.Ngay });

                    var doanhSoMoByLoaiTietKiem = from l in loaiTk
                                                   join mo in doanhSoMo on l.Ngay equals mo.Ngay into dsmltk
                                                   from p in dsmltk.DefaultIfEmpty()
                                                   select new
                                                   {
                                                       Ngay = l.Ngay,
                                                       TongMo = p == null ? 0 : p.TongMo
                                                   };

                    var doanhSoDongByLoaiTietKiem = from l in loaiTk
                                                   join dong in doanhSoDong on l.Ngay equals dong.Ngay into dsdltk
                                                   from p in dsdltk.DefaultIfEmpty()
                                                   select new
                                                   {
                                                       Ngay = l.Ngay,
                                                       TongDong = p == null ? 0 : p.TongDong
                                                   };

                    var doanhSoThang = from mo in doanhSoMoByLoaiTietKiem
                                       join dong in doanhSoDongByLoaiTietKiem on mo.Ngay.Date equals dong.Ngay.Date
                                      into temp
                                      from j in temp.DefaultIfEmpty()
                                      select new DoanhSoMoDongDto
                                      {
                                          Ngay = mo.Ngay,
                                          TongMo = mo.TongMo,
                                          TongDong = j.TongDong
                                      };
                    return Ok(doanhSoThang.ToList());
                }
                else if (isExistDoanhSoThu && !isExistDoanhSoChi)
                {
                    var doanhSoThang = from mo in doanhSoMo
                                      select new DoanhSoMoDongDto
                                      {
                                          Ngay = mo.Ngay,
                                          TongMo = mo.TongMo,
                                          TongDong = 0
                                      };
                    return Ok(doanhSoThang.ToList());
                }
                else if (!isExistDoanhSoThu && isExistDoanhSoChi)
                {
                    var doanhSoThang = from dong in doanhSoDong
                                      select new DoanhSoMoDongDto
                                      {
                                          Ngay = dong.Ngay,
                                          TongMo = 0,
                                          TongDong = dong.TongDong
                                      };
                    return Ok(doanhSoThang.ToList());
                }


                return Ok(doanhSo);
            }
        }
    }
}