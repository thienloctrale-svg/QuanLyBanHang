
using System;
using System.Collections.Generic;
using QuanLyBanHang.DAL;
using QuanLyBanHang.DTO;
using QuanLyBanHang.Logging;

namespace QuanLyBanHang.BLL
{
    public class HoaDonBLL
    {
        private readonly HoaDonDAL hoaDonDAL = new HoaDonDAL();

        public void LuuHoaDon(
            string maHoaDon,
            DateTime ngayLap,
            string? maKhachHang,
            decimal tongTien,
            string phuongThucThanhToan,
            List<ChiTietHoaDonDTO> chiTiet)
        {
            if (string.IsNullOrWhiteSpace(maHoaDon))
                throw new Exception("Mã hóa đơn không hợp lệ.");

            if (chiTiet == null || chiTiet.Count == 0)
                throw new Exception("Giỏ hàng chưa có sản phẩm.");

            if (tongTien <= 0)
                throw new Exception("Tổng tiền hóa đơn phải lớn hơn 0.");

            if (string.IsNullOrWhiteSpace(phuongThucThanhToan))
                throw new Exception("Vui lòng chọn phương thức thanh toán.");

            foreach (ChiTietHoaDonDTO item in chiTiet)
            {
                if (item.SoLuong <= 0)
                    throw new Exception("Số lượng sản phẩm phải lớn hơn 0.");

                if (item.DonGia < 0 || item.ThanhTien < 0)
                    throw new Exception("Giá sản phẩm không hợp lệ.");
            }

            try
            {
                hoaDonDAL.LuuHoaDon(
                    maHoaDon,
                    ngayLap,
                    maKhachHang,
                    tongTien,
                    phuongThucThanhToan,
                    chiTiet);

                AppLogger.Information(
                    $"Lưu hóa đơn {maHoaDon} thành công.");
            }
            catch (Exception ex)
            {
                AppLogger.Error(ex, $"Không thể lưu hóa đơn {maHoaDon}.");
                throw;
            }
        }
    }
}
