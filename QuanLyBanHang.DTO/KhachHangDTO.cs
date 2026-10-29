using System;

namespace QuanLyBanHang.DTO
{
    public class KhachHangDTO
    {
        public string MaKhachHang { get; set; } = string.Empty;
        public string TenKhachHang { get; set; } = string.Empty;
        public string GioiTinh { get; set; } = "Nam";
        public DateTime? NgaySinh { get; set; }
        public string SoDienThoai { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string LoaiKhachHang { get; set; } = "Khách thường";
        public string DiaChi { get; set; } = string.Empty;
        public string TrangThai { get; set; } = "Đang hoạt động";
        public string GhiChu { get; set; } = string.Empty;
        public DateTime NgayTao { get; set; } = DateTime.Now;
    }
}
