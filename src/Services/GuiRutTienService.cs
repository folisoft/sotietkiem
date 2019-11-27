using SoTietKiem.Data;
using SoTietKiem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SoTietKiem.Services
{
    public class GuiRutTienService
    {
        private DatabaseContext context;

        public GuiRutTienService(DatabaseContext context)
        {
            this.context = context;
        }

        public async Task<bool> ThemGuiRut(ThemGuiRutTienRequest request)
        {
            var soTietKiem = context.SoTk.Find(request.MSKH);
            var loaiTietKiem = context.LoaiTietKiem.Find(soTietKiem.LoaiTietKiemId);
            var khongKyHan = context.LoaiTietKiem.Find(1);
            var chitietSoTruoc = context.ChiTietSoTietKiem.Where(ct => ct.Mskh == request.MSKH).OrderByDescending(ord => ord.NgayGui).ToList()[0];
            if(loaiTietKiem.KyHan > 0)
            {
                var truoc = request.Ngay;
                var sau = chitietSoTruoc.NgayGui;
                int soNam = truoc.Year - sau.Value.Year;
                int soThang = 0;
                if (soNam > 0) soThang = truoc.Month + 12 - sau.Value.Month;
                else soThang = truoc.Month - sau.Value.Month;
                if (soThang < loaiTietKiem.KyHan) return false;
            }

            if (request.Action == "GUI")
            {
                return this.GuiRutTien(request, chitietSoTruoc, loaiTietKiem, khongKyHan, "GUI", soTietKiem);
            }
            else if (request.Action == "RUT")
            {
                request.SoTien = request.SoTien * -1;
                return this.GuiRutTien(request, chitietSoTruoc, loaiTietKiem, khongKyHan, "RUT", soTietKiem);
            }
            else return false;
        }

        private bool GuiRutTien(ThemGuiRutTienRequest request, ChiTietSoTietKiem chitietSoTruoc, LoaiTietKiem loaitietkiem, LoaiTietKiem khongkyhan, string nghiepvu, SoTk soTietKiem)
        {
            var phieuGuiTien = this.TaoPhieuGuiRut(request);
            if (phieuGuiTien == null) return false;

            var result = this.AddChiTietSo(phieuGuiTien, chitietSoTruoc, loaitietkiem, khongkyhan, nghiepvu, soTietKiem);
            return result;
        }

        //private bool RutTien(ThemGuiRutTienRequest request, LoaiTietKiem loaitietkiem, LoaiTietKiem khongkyhan)
        //{
        //    var phieuGuiTien = this.TaoPhieuGuiRut(request);
        //    if (phieuGuiTien == null) return false;
        //    var chitietSoTruoc = context.ChiTietSoTietKiem.OrderByDescending(ord => ord.NgayGui).ToList()[0];
            
        //}

        #region GUI RUT TIEN
        private bool AddChiTietSo(PhieuGuiRutTien phieuGuiTien, ChiTietSoTietKiem chitietSoTruoc, LoaiTietKiem loaitietkiem, LoaiTietKiem khongkyhan, string nghiepvu, SoTk soTietKiem)
        {
            var addChiTietSo = this.KhoiTaoChiTiet(phieuGuiTien, chitietSoTruoc, loaitietkiem, nghiepvu);
            addChiTietSo.NghiepVu = nghiepvu;

            int soNam = phieuGuiTien.Ngay.Value.Year - chitietSoTruoc.NgayGui.Value.Year;
            int soThang = 0;
            if (soNam > 0) soThang = phieuGuiTien.Ngay.Value.Month + 12 - chitietSoTruoc.NgayGui.Value.Month;
            else soThang = phieuGuiTien.Ngay.Value.Month - chitietSoTruoc.NgayGui.Value.Month;
            var soNgay = Math.Abs(phieuGuiTien.Ngay.Value.Day - chitietSoTruoc.NgayGui.Value.Month);
            if (soThang > 0 && nghiepvu == "GUI")
            {
                addChiTietSo.SoThangLaiSuat = soThang;
                addChiTietSo.LaiSuatThang = this.LaiThang(chitietSoTruoc.SoDuCuoiKy.Value, addChiTietSo.LaiSuat.Value / 100, (double)soThang);
                addChiTietSo.SoNgayLaiSuat = 0;
                addChiTietSo.LaiSuatNgay = 0;
            }
            if (soNgay > 0 && nghiepvu == "GUI")
            {
                addChiTietSo.SoNgayLaiSuat = (int)soNgay;
                addChiTietSo.LaiSuatNgay = this.LaiNgay(chitietSoTruoc.SoDuCuoiKy.Value, khongkyhan.LaiSuat / 100, (double)soThang, soNgay);
            }

            if(nghiepvu == "RUT")
            {
                addChiTietSo.SoThangLaiSuat = 0;
                addChiTietSo.LaiSuatThang = 0;
                addChiTietSo.SoNgayLaiSuat = 0;
                addChiTietSo.LaiSuatNgay = 0;
            }
            addChiTietSo.SoDuCuoiKy = addChiTietSo.SoDuDauKy + addChiTietSo.LaiSuatThang + addChiTietSo.LaiSuatNgay;

            context.ChiTietSoTietKiem.Add(addChiTietSo);

            soTietKiem.SoDu = addChiTietSo.SoDuCuoiKy;
            if(nghiepvu == "RUT")
            {
                soTietKiem.NgayDongSo = DateTime.Now;
                soTietKiem.SoDu = 0;
            }
            context.SoTk.Update(soTietKiem);
            return context.SaveChanges() > 0;
        }

        //private bool RutChiTietSo(PhieuGuiRutTien phieuGuiTien, ChiTietSoTietKiem chitietSoTruoc, LoaiTietKiem loaitietkiem, LoaiTietKiem khongkyhan)
        //{
        //    var addChiTietSo = this.KhoiTaoChiTiet(phieuGuiTien, chitietSoTruoc, loaitietkiem);
        //    addChiTietSo.NghiepVu = "RUT";

        //    var soThang = phieuGuiTien.Ngay.Value.Month - chitietSoTruoc.NgayGui.Value.Month;
        //    var soNgay = (phieuGuiTien.Ngay.Value - chitietSoTruoc.NgayGui.Value).TotalDays;
        //    if (soThang > 0)
        //    {
        //        addChiTietSo.SoThangLaiSuat = soThang;
        //        addChiTietSo.LaiSuatThang = this.LaiThang(chitietSoTruoc.SoDuCuoiKy.Value, addChiTietSo.LaiSuat.Value, (double)soThang);
        //    }
        //    if (soNgay > 0)
        //    {
        //        addChiTietSo.SoNgayLaiSuat = (int)soNgay;
        //        addChiTietSo.LaiSuatNgay = this.LaiNgay(chitietSoTruoc.SoDuCuoiKy.Value, khongkyhan.LaiSuat, (double)soThang, soNgay);
        //        addChiTietSo.SoDuCuoiKy = addChiTietSo.SoDuDauKy + addChiTietSo.LaiSuatThang + addChiTietSo.LaiSuatNgay;
        //    }
        //}
        #endregion

        #region TINH LAI SUAT
        private double LaiThang(double soduCuoiKy, double laiSuat, double soThang)
        {
            return ((soduCuoiKy * laiSuat) / 12 * soThang);
        }

        private double LaiNgay(double soduCuoiKy, double laiSuat, double soThang, double soNgay)
        {
            soThang = soThang == 0 ? 1 : soThang;
            return (((soduCuoiKy * laiSuat) / 12 * soThang) / 365 * soNgay);
        }
        #endregion

        #region TAO PHIEU RUT
        private PhieuGuiRutTien TaoPhieuGuiRut(ThemGuiRutTienRequest request)
        {
            var phieuGuiRut = new PhieuGuiRutTien
            {
                Mskh = request.MSKH,
                KhachHang = request.KhachHang,
                SoTien = request.SoTien,
                Ngay = request.Ngay
            };
            context.PhieuGuiRutTien.Add(phieuGuiRut);
            if (context.SaveChanges() > 0) return phieuGuiRut;
            else return null;
        }
        #endregion

        private ChiTietSoTietKiem KhoiTaoChiTiet(PhieuGuiRutTien phieuGuiTien, ChiTietSoTietKiem chitietSoTruoc, LoaiTietKiem loaitietkiem, string nghiepvu)
        {
            var result = new ChiTietSoTietKiem
            {
                PhieuGuiRutTienId = phieuGuiTien.Id,
                Mskh = phieuGuiTien.Mskh,
                NgayGui = phieuGuiTien.Ngay,
                SoTienGui = phieuGuiTien.SoTien,
                LoaiTietKiemId = loaitietkiem.Id,
                LaiSuat = loaitietkiem.LaiSuat,

            };
            if (nghiepvu == "RUT") result.SoDuDauKy = chitietSoTruoc.SoDuCuoiKy + 0;
            if (nghiepvu == "GUI") result.SoDuDauKy = chitietSoTruoc.SoDuCuoiKy + phieuGuiTien.SoTien;
            return result;
        }
    }

    public partial class ThemGuiRutTienRequest
    {
        public string MSKH { get; set; }
        public string KhachHang { get; set; }
        public float SoTien { get; set; }
        public DateTime Ngay { get; set; }
        public string Action { get; set; }
    }
}
