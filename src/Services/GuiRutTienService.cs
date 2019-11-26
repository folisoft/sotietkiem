using SoTietKiem.Data;
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
            return true;
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
