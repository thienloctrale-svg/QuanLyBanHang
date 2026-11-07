using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyBanHang.DTO // hoặc QuanLyBanHang.UI tùy cấu trúc của bạn
{
    public static class SessionManager
    {
        // Lưu thông tin người dùng đang đăng nhập
        public static TaiKhoanDTO TaiKhoanHienTai { get; set; }

        // Kiểm tra xem đã đăng nhập chưa
        public static bool DaDangNhap => TaiKhoanHienTai != null;

        // Hàm xóa phiên khi người dùng ấn "Đăng xuất"
        public static void DangXuat()
        {
            TaiKhoanHienTai = null;
        }
    }
}
