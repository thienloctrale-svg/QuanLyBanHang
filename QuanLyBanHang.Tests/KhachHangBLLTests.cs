using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using QuanLyBanHang.BLL;
using QuanLyBanHang.DTO;
using QuanLyBanHang.Logging;

namespace QuanLyBanHang.Tests
{
    [TestClass]
    public class KhachHangBLLTests
    {
        private static KhachHangBLL _bll = null!;

        [ClassInitialize]
        public static void ClassInit(TestContext context)
        {
            AppLogger.Initialize();
            _bll = new KhachHangBLL();
        }

        [TestMethod]
        public void LayDanhSachKhachHang_KhiKhongCoDieuKien_TraVeDanhSachDayDu()
        {
            // Act
            DataTable dt = _bll.LayDanhSachKhachHang();

            // Assert
            Assert.IsNotNull(dt, "DataTable trả về không được null.");
            Assert.IsTrue(dt.Rows.Count >= 8, $"Dữ liệu mẫu phải có ít nhất 8 khách hàng. Thực tế: {dt.Rows.Count}");
            Assert.IsTrue(dt.Columns.Contains("STT"), "Bảng phải có cột STT.");
            Assert.IsTrue(dt.Columns.Contains("MaKhachHang"), "Bảng phải có cột MaKhachHang.");
            Assert.IsTrue(dt.Columns.Contains("TenKhachHang"), "Bảng phải có cột TenKhachHang.");
            Assert.IsTrue(dt.Columns.Contains("SoDienThoai"), "Bảng phải có cột SoDienThoai.");
        }

        [TestMethod]
        public void LayDanhSachKhachHang_KhiTimKiemTheoTen_TraVeDungKetQua()
        {
            // Act: Tìm khách hàng có tên 'Nguyễn Văn An'
            DataTable dt = _bll.LayDanhSachKhachHang(tuKhoa: "Nguyễn Văn An");

            // Assert
            Assert.IsNotNull(dt);
            Assert.AreEqual(1, dt.Rows.Count, "Phải tìm thấy chính xác 1 khách hàng có tên Nguyễn Văn An.");
            Assert.AreEqual("KH001", dt.Rows[0]["MaKhachHang"].ToString());
        }

        [TestMethod]
        public void LayDanhSachKhachHang_KhiTimKiemTheoSoDienThoai_TraVeDungKetQua()
        {
            // Act: Tìm khách hàng qua số điện thoại '0901234567' (thuộc KH001)
            DataTable dt = _bll.LayDanhSachKhachHang(tuKhoa: "0901234567");

            // Assert
            Assert.IsNotNull(dt);
            Assert.IsTrue(dt.Rows.Count >= 1, "Phải tìm thấy khách hàng với số điện thoại tương ứng.");
            Assert.AreEqual("KH001", dt.Rows[0]["MaKhachHang"].ToString());
        }

        [TestMethod]
        public void LayDanhSachKhachHang_KhiLocTheoLoaiKhachHang_TraVeDungLoai()
        {
            // Act: Lọc theo loại 'Khách VIP'
            DataTable dt = _bll.LayDanhSachKhachHang(loaiKhachHang: "Khách VIP");

            // Assert
            Assert.IsNotNull(dt);
            Assert.IsTrue(dt.Rows.Count > 0, "Phải có ít nhất 1 khách hàng VIP.");
            foreach (DataRow row in dt.Rows)
            {
                Assert.AreEqual("Khách VIP", row["LoaiKhachHang"].ToString(), "Tất cả khách hàng lọc ra phải có loại là 'Khách VIP'.");
            }
        }

        [TestMethod]
        public void LayDanhSachKhachHangDTO_TraVeDanhSachKhachHangHoatDong()
        {
            // Act
            List<KhachHangDTO> danhSach = _bll.LayDanhSachKhachHangDTO();

            // Assert
            Assert.IsNotNull(danhSach);
            Assert.IsTrue(danhSach.Count > 0, "Danh sách DTO phải chứa ít nhất 1 khách hàng hoạt động.");
            foreach (var kh in danhSach)
            {
                Assert.AreEqual("Đang hoạt động", kh.TrangThai, "Khách hàng trong DTO phải có trạng thái 'Đang hoạt động'.");
            }
        }

        [TestMethod]
        public void ThemKhachHang_KhiThieuMaKhachHang_TraVeFalseVaBaoLoi()
        {
            // Arrange
            var kh = new KhachHangDTO
            {
                MaKhachHang = "",
                TenKhachHang = "Nguyễn Văn Test"
            };

            // Act
            bool ketQua = _bll.ThemKhachHang(kh, out string thongBao);

            // Assert
            Assert.IsFalse(ketQua, "Thêm khách hàng thiếu mã phải thất bại.");
            StringAssert.Contains(thongBao, "không được để trống");
        }

        [TestMethod]
        public void ThemKhachHang_KhiThieuTenKhachHang_TraVeFalseVaBaoLoi()
        {
            // Arrange
            var kh = new KhachHangDTO
            {
                MaKhachHang = "KH999",
                TenKhachHang = "   "
            };

            // Act
            bool ketQua = _bll.ThemKhachHang(kh, out string thongBao);

            // Assert
            Assert.IsFalse(ketQua, "Thêm khách hàng thiếu tên phải thất bại.");
            StringAssert.Contains(thongBao, "không được để trống");
        }

        [TestMethod]
        public void ThemKhachHang_KhiTrungMa_TraVeFalseVaBaoLoi()
        {
            // Arrange: Mã 'KH001' đã tồn tại trong database mẫu
            var kh = new KhachHangDTO
            {
                MaKhachHang = "KH001",
                TenKhachHang = "Khách Hàng Trùng Mã"
            };

            // Act
            bool ketQua = _bll.ThemKhachHang(kh, out string thongBao);

            // Assert
            Assert.IsFalse(ketQua, "Thêm khách hàng trùng mã phải thất bại.");
            StringAssert.Contains(thongBao, "đã tồn tại");
        }

        [TestMethod]
        public void ThemKhachHang_KhiHopLe_ThemThanhCongVaXoaDondep()
        {
            // Arrange
            string maTest = "KH_TEST_99";
            var kh = new KhachHangDTO
            {
                MaKhachHang = maTest,
                TenKhachHang = "Khách Hàng Test Unit",
                GioiTinh = "Nam",
                NgaySinh = new DateTime(2000, 1, 1),
                SoDienThoai = "0988888888",
                Email = "test.unit@gmail.com",
                LoaiKhachHang = "Khách thường",
                DiaChi = "TP. Hồ Chí Minh",
                TrangThai = "Đang hoạt động",
                GhiChu = "Dữ liệu phục vụ kiểm thử tự động"
            };

            // Dọn dẹp trước nếu tồn tại từ lần chạy trước
            _bll.XoaKhachHang(maTest, out _);

            // Act: Thêm mới
            bool ketQuaThem = _bll.ThemKhachHang(kh, out string thongBaoThem);

            // Assert
            Assert.IsTrue(ketQuaThem, $"Thêm khách hàng hợp lệ phải thành công. Thông báo: {thongBaoThem}");

            // Cleanup: Xóa bản ghi test để bảo vệ database
            bool ketQuaXoa = _bll.XoaKhachHang(maTest, out string thongBaoXoa);
            Assert.IsTrue(ketQuaXoa, $"Xóa bản ghi test phải thành công. Thông báo: {thongBaoXoa}");
        }

        [TestMethod]
        public void CapNhatKhachHang_KhiMaKhongTonTai_TraVeFalseVaBaoLoi()
        {
            // Arrange
            var kh = new KhachHangDTO
            {
                MaKhachHang = "KH_KHONG_TON_TAI",
                TenKhachHang = "Tên Khách Hàng"
            };

            // Act
            bool ketQua = _bll.CapNhatKhachHang(kh, out string thongBao);

            // Assert
            Assert.IsFalse(ketQua, "Cập nhật khách hàng không tồn tại phải trả về false.");
            StringAssert.Contains(thongBao, "Không tìm thấy");
        }

        [TestMethod]
        public void CapNhatKhachHang_KhiThieuTen_TraVeFalseVaBaoLoi()
        {
            // Arrange
            var kh = new KhachHangDTO
            {
                MaKhachHang = "KH001",
                TenKhachHang = "   "
            };

            // Act
            bool ketQua = _bll.CapNhatKhachHang(kh, out string thongBao);

            // Assert
            Assert.IsFalse(ketQua, "Cập nhật khách hàng thiếu tên phải trả về false.");
            StringAssert.Contains(thongBao, "không được để trống");
        }

        [TestMethod]
        public void CapNhatKhachHang_KhiHopLe_CapNhatThanhCongVaXoaDondep()
        {
            // Arrange
            string maTest = "KH_TEST_UPDATE";
            var khMoi = new KhachHangDTO
            {
                MaKhachHang = maTest,
                TenKhachHang = "Khách Hàng Trước Sửa",
                SoDienThoai = "0977111222",
                LoaiKhachHang = "Khách thường",
                TrangThai = "Đang hoạt động"
            };

            _bll.XoaKhachHang(maTest, out _);
            _bll.ThemKhachHang(khMoi, out _);

            // Act: Cập nhật thông tin
            khMoi.TenKhachHang = "Khách Hàng Sau Khi Sửa";
            khMoi.LoaiKhachHang = "Khách VIP";
            bool ketQuaCapNhat = _bll.CapNhatKhachHang(khMoi, out string thongBaoCapNhat);

            // Assert
            Assert.IsTrue(ketQuaCapNhat, $"Cập nhật khách hàng hợp lệ phải thành công. Thông báo: {thongBaoCapNhat}");

            // Cleanup
            _bll.XoaKhachHang(maTest, out _);
        }

        [TestMethod]
        public void XoaKhachHang_KhiMaRong_TraVeFalseVaBaoLoi()
        {
            // Act
            bool ketQua = _bll.XoaKhachHang("", out string thongBao);

            // Assert
            Assert.IsFalse(ketQua, "Xóa với mã rỗng phải trả về false.");
            StringAssert.Contains(thongBao, "Vui lòng chọn");
        }

        [TestMethod]
        public void XoaKhachHang_KhiKhachHangDaCoHoaDon_KhongChoXoaVaBaoLoi()
        {
            // Arrange: Khách hàng 'KH001' trong seed data đã có hóa đơn bán hàng
            string maKhachHang = "KH001";

            // Act
            bool ketQua = _bll.XoaKhachHang(maKhachHang, out string thongBao);

            // Assert
            Assert.IsFalse(ketQua, "Không được phép xóa khách hàng đã phát sinh hóa đơn trong hệ thống.");
            StringAssert.Contains(thongBao, "hóa đơn", "Thông báo phải giải thích rõ lý do ràng buộc hóa đơn.");
        }

        [TestMethod]
        public void TaoMaKhachHangTuDong_TraVeDungDinhDangKH()
        {
            // Act
            string maTuDong = _bll.TaoMaKhachHangTuDong();

            // Assert
            Assert.IsFalse(string.IsNullOrWhiteSpace(maTuDong), "Mã tự động không được rỗng.");
            Assert.IsTrue(maTuDong.StartsWith("KH"), "Mã khách hàng tự động phải bắt đầu bằng 'KH'.");
            Assert.IsTrue(maTuDong.Length >= 5, "Mã khách hàng tự động phải có độ dài tối thiểu 5 ký tự (VD: KH009).");
        }

        [TestMethod]
        public void TimKiemKhachHang_KhiTuKhoaKhop_TraVeKetQuaLocChinhXac()
        {
            // Arrange
            var danhSach = new List<KhachHangDTO>
            {
                new KhachHangDTO { MaKhachHang = "KH001", TenKhachHang = "Nguyễn Văn An" },
                new KhachHangDTO { MaKhachHang = "KH002", TenKhachHang = "Trần Thị Bích" },
                new KhachHangDTO { MaKhachHang = "KH003", TenKhachHang = "Lê Hoàng Long" }
            };

            // Act
            var ketQua = _bll.TimKiemKhachHang(danhSach, "Bích");

            // Assert
            Assert.IsNotNull(ketQua);
            Assert.AreEqual(1, ketQua.Count);
            Assert.AreEqual("KH002", ketQua[0].MaKhachHang);
        }
    }
}
