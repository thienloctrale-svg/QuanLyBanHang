using System;
using System.Collections.Generic;
using QuanLyBanHang.DAL;
using QuanLyBanHang.DTO;
using QuanLyBanHang.Logging;

namespace QuanLyBanHang.BLL
{
    public class HoaDonBLL
    {
        private readonly IHoaDonDAL hoaDonDAL;

        // Dùng khi chạy ứng dụng thật
        public HoaDonBLL()
        {
            hoaDonDAL = new HoaDonDAL();
        }

        // Dùng khi chạy Unit Test
        public HoaDonBLL(IHoaDonDAL hoaDonDAL)
        {
            this.hoaDonDAL = hoaDonDAL ?? throw new ArgumentNullException(nameof(hoaDonDAL));
        }

        public string TaoMaHoaDonMoi()
        {
            return hoaDonDAL.TaoMaHoaDonMoi();
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
            KiemTraThongTinHoaDon(maHoaDon, maTaiKhoan, tongTien, chiTiet);

            if (string.IsNullOrWhiteSpace(phuongThucThanhToan))
                throw new ArgumentException("Vui lòng chọn phương thức thanh toán.");

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

                AppLogger.Information($"Lưu hóa đơn {maHoaDon} thành công.");
            }
            catch (Exception ex)
            {
                AppLogger.Error(ex, $"Không thể lưu hóa đơn {maHoaDon}.");
                throw;
            }
        }

        public void LuuHoaDonHuy(
            string maHoaDon,
            DateTime ngayLap,
            string? maKhachHang,
            int maTaiKhoan,
            decimal tongTien,
            List<ChiTietHoaDonDTO> chiTiet)
        {
            KiemTraThongTinHoaDon(maHoaDon, maTaiKhoan, tongTien, chiTiet);

            try
            {
                hoaDonDAL.LuuHoaDonHuy(
                    maHoaDon,
                    ngayLap,
                    maKhachHang,
                    maTaiKhoan,
                    tongTien,
                    chiTiet);

                AppLogger.Information($"Hủy hóa đơn {maHoaDon} thành công.");
            }
            catch (Exception ex)
            {
                AppLogger.Error(ex, $"Không thể hủy hóa đơn {maHoaDon}.");
                throw;
            }
        }

        private void KiemTraThongTinHoaDon(
            string maHoaDon,
            int maTaiKhoan,
            decimal tongTien,
            List<ChiTietHoaDonDTO> chiTiet)
        {
            if (string.IsNullOrWhiteSpace(maHoaDon))
                throw new ArgumentException("Mã hóa đơn không hợp lệ.");

            if (maTaiKhoan <= 0)
                throw new ArgumentException("Tài khoản không hợp lệ.");

            if (chiTiet == null || chiTiet.Count == 0)
                throw new InvalidOperationException("Giỏ hàng chưa có sản phẩm.");

            if (tongTien <= 0)
                throw new InvalidOperationException("Tổng tiền hóa đơn phải lớn hơn 0.");

            foreach (ChiTietHoaDonDTO item in chiTiet)
            {
                if (item.SoLuong <= 0)
                    throw new ArgumentException("Số lượng sản phẩm phải lớn hơn 0.");

                if (item.DonGia < 0 || item.ThanhTien < 0)
                    throw new ArgumentException("Giá sản phẩm không hợp lệ.");
            }
        }
    }
}