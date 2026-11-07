using System;
using System.Collections.Generic;
using QuanLyBanHang.DTO;

namespace QuanLyBanHang.DAL
{
    public interface IHoaDonDAL
    {
        string TaoMaHoaDonMoi();

        void LuuHoaDon(
            string maHoaDon,
            DateTime ngayLap,
            string? maKhachHang,
            int maTaiKhoan,
            decimal tongTien,
            string phuongThucThanhToan,
            List<ChiTietHoaDonDTO> chiTiet);

        void LuuHoaDonHuy(
            string maHoaDon,
            DateTime ngayLap,
            string? maKhachHang,
            int maTaiKhoan,
            decimal tongTien,
            List<ChiTietHoaDonDTO> chiTiet);
    }
}