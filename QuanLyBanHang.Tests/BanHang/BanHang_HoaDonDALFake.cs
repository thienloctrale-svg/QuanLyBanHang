using System;
using System.Collections.Generic;
using QuanLyBanHang.DAL;
using QuanLyBanHang.DTO;

namespace QuanLyBanHang.Tests.BanHang
{
    // Lớp giả lập (Mock/Fake) tầng DAL của nghiệp vụ Hóa đơn phục vụ chạy Unit Test độc lập với cơ sở dữ liệu
    public class BanHang_HoaDonDALFake : IHoaDonDAL
    {
        public bool LuuHoaDonDuocGoi { get; private set; } = false; // Đánh dấu hàm LuuHoaDon đã được gọi hay chưa
        public bool LuuHoaDonHuyDuocGoi { get; private set; } = false; // Đánh dấu hàm LuuHoaDonHuy đã được gọi hay chưa
        public bool PhatSinhLoi { get; set; } = false; // Cờ kích hoạt giả lập ném lỗi ngoại lệ từ database

        public string MaHoaDonDaLuu { get; private set; } = string.Empty; // Lưu lại mã hóa đơn vừa truyền vào để kiểm tra kết quả test
        public decimal TongTienDaLuu { get; private set; } = 0; // Lưu lại tổng tiền vừa truyền vào để đối chiếu kiểm thử
        public string PhuongThucDaLuu { get; private set; } = string.Empty; // Lưu lại phương thức thanh toán để kiểm tra tính chính xác
        public List<ChiTietHoaDonDTO> ChiTietDaLuu { get; private set; } = new List<ChiTietHoaDonDTO>(); // Lưu danh sách chi tiết hàng hóa đã truyền xuống

        // Giả lập hàm tạo mã hóa đơn tự động sinh mã mẫu cố định "HD999"
        public string TaoMaHoaDonMoi()
        {
            if (PhatSinhLoi)
                throw new Exception("Lỗi giả lập khi sinh mã hóa đơn.");

            return "HD999";
        }

        // Giả lập lưu hóa đơn thành công vào bộ nhớ tạm thay vì ghi vào SQL Server
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

        // Giả lập ghi nhận hóa đơn bị hủy vào bộ nhớ tạm
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