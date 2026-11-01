using System;
using System.Collections.Generic;
using QuanLyBanHang.DAL;
using QuanLyBanHang.DTO;

namespace QuanLyBanHang.Tests.BanHang
{
    public class BanHang_HoaDonDALFake : IHoaDonDAL
    {
        public bool LuuHoaDonDuocGoi { get; private set; } = false;
        public bool LuuHoaDonHuyDuocGoi { get; private set; } = false;
        public bool PhatSinhLoi { get; set; } = false;

        public string MaHoaDonDaLuu { get; private set; } = string.Empty;
        public decimal TongTienDaLuu { get; private set; } = 0;
        public string PhuongThucDaLuu { get; private set; } = string.Empty;
        public List<ChiTietHoaDonDTO> ChiTietDaLuu { get; private set; } = new List<ChiTietHoaDonDTO>();

        public string TaoMaHoaDonMoi()
        {
            if (PhatSinhLoi)
                throw new Exception("Lỗi giả lập khi sinh mã hóa đơn.");

            return "HD999";
        }

        public void LuuHoaDon(
            string maHoaDon,
            DateTime ngayLap,
            string? maKhachHang,
            int maTaiKhoan,
            decimal tongTien,
            string phuongThucThanhToan,
            List<ChiTietHoaDonDTO> chiTiet)
        {
            if (PhatSinhLoi)
                throw new Exception("Lỗi cơ sở dữ liệu giả lập khi lưu hóa đơn.");

            LuuHoaDonDuocGoi = true;
            MaHoaDonDaLuu = maHoaDon;
            TongTienDaLuu = tongTien;
            PhuongThucDaLuu = phuongThucThanhToan;
            ChiTietDaLuu = chiTiet;
        }

        public void LuuHoaDonHuy(
            string maHoaDon,
            DateTime ngayLap,
            string? maKhachHang,
            int maTaiKhoan,
            decimal tongTien,
            List<ChiTietHoaDonDTO> chiTiet)
        {
            if (PhatSinhLoi)
                throw new Exception("Lỗi cơ sở dữ liệu giả lập khi hủy hóa đơn.");

            LuuHoaDonHuyDuocGoi = true;
            MaHoaDonDaLuu = maHoaDon;
            TongTienDaLuu = tongTien;
            ChiTietDaLuu = chiTiet;
        }
    }
}