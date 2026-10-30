
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

        public string TaoMaHoaDonMoi()
        {
            return hoaDonDAL.TaoMaHoaDonMoi();
        }

        // Lưu hóa đơn bán hàng bình thường
        public void LuuHoaDon(
            string maHoaDon,
            DateTime ngayLap,
            string? maKhachHang,
            int maTaiKhoan,
            decimal tongTien,
            string phuongThucThanhToan,
            List<ChiTietHoaDonDTO> chiTiet)
        {
            KiemTraThongTinHoaDon(
                maHoaDon, maTaiKhoan, tongTien, chiTiet);

            if (string.IsNullOrWhiteSpace(phuongThucThanhToan))
                throw new Exception("Vui lòng chọn phương thức thanh toán.");

            try
            {
                hoaDonDAL.LuuHoaDon(
                    maHoaDon,
                    ngayLap,
                    maKhachHang,
                    maTaiKhoan,
                    tongTien,
                    phuongThucThanhToan,
                    chiTiet);

                AppLogger.Information(
                    $"Lưu hóa đơn {maHoaDon} thành công.");
            }
            catch (Exception ex)
            {
                AppLogger.Error(
                    ex, $"Không thể lưu hóa đơn {maHoaDon}.");

                throw;
            }
        }

        // Lưu hóa đơn đã hủy
        public void LuuHoaDonHuy(
            string maHoaDon,
            DateTime ngayLap,
            string? maKhachHang,
            int maTaiKhoan,
            decimal tongTien,
            List<ChiTietHoaDonDTO> chiTiet)
        {
            KiemTraThongTinHoaDon(
                maHoaDon, maTaiKhoan, tongTien, chiTiet);

            try
            {
                hoaDonDAL.LuuHoaDonHuy(
                    maHoaDon,
                    ngayLap,
                    maKhachHang,
                    maTaiKhoan,
                    tongTien,
                    chiTiet);

                AppLogger.Information(
                    $"Hủy hóa đơn {maHoaDon} thành công.");
            }
            catch (Exception ex)
            {
                AppLogger.Error(
                    ex, $"Không thể hủy hóa đơn {maHoaDon}.");

                throw;
            }
        }

        // Kiểm tra dữ liệu chung
        private void KiemTraThongTinHoaDon(
            string maHoaDon,
            int maTaiKhoan,
            decimal tongTien,
            List<ChiTietHoaDonDTO> chiTiet)
        {
            if (string.IsNullOrWhiteSpace(maHoaDon))
                throw new Exception("Mã hóa đơn không hợp lệ.");

            if (maTaiKhoan <= 0)
                throw new Exception("Tài khoản không hợp lệ.");

            if (chiTiet == null || chiTiet.Count == 0)
                throw new Exception("Giỏ hàng chưa có sản phẩm.");

            if (tongTien <= 0)
                throw new Exception("Tổng tiền hóa đơn phải lớn hơn 0.");

            foreach (ChiTietHoaDonDTO item in chiTiet)
            {
                if (item.SoLuong <= 0)
                    throw new Exception(
                        "Số lượng sản phẩm phải lớn hơn 0.");

                if (item.DonGia < 0 || item.ThanhTien < 0)
                    throw new Exception(
                        "Giá sản phẩm không hợp lệ.");
            }
        }
    }
}
