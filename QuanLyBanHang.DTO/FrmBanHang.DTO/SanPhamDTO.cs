using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace QuanLyBanHang.DTO
{
    public class SanPhamDTO
    {
        public string MaSanPham { get; set; } = string.Empty;

        public string TenSanPham { get; set; } = string.Empty;

        public string DonViTinh { get; set; } = string.Empty;

        public decimal GiaBan { get; set; }

        public int SoLuongTon { get; set; }

        public string TrangThai { get; set; } = string.Empty;
    }
}
