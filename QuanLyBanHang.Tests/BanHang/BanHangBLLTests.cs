using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using QuanLyBanHang.BLL;
using QuanLyBanHang.DTO;
using System.Linq;

namespace QuanLyBanHang.Tests.BanHang
{
    [TestClass]
    public class BanHangBLLTests
    {
        // =====================================================
        // 1. KIỂM THỬ SẢN PHẨM
        // =====================================================

        [TestMethod]
        public void LayDanhSachSanPham_KhiCoDuLieu_TraVeDanhSach()
        {
            // Arrange: Chuẩn bị dữ liệu giả lập.
            var fake = new BanHang_SanPhamDALFake();

            fake.DanhSachSanPham = new List<SanPhamDTO>
            {
                new SanPhamDTO
                {
                    MaSanPham = "SP001",
                    TenSanPham = "Áo thun",
                    DonViTinh = "Cái",
                    GiaBan = 150000,
                    SoLuongTon = 20,
                    TrangThai = "Đang kinh doanh"
                },
                new SanPhamDTO
                {
                    MaSanPham = "SP002",
                    TenSanPham = "Áo khoác",
                    DonViTinh = "Cái",
                    GiaBan = 300000,
                    SoLuongTon = 10,
                    TrangThai = "Đang kinh doanh"
                }
            };

            var bll = new SanPhamBLL(fake);

            // Act: Gọi chức năng lấy danh sách.
            List<SanPhamDTO> ketQua = bll.LayDanhSachSanPham();

            // Assert: Kiểm tra kết quả.
            Assert.IsNotNull(ketQua);
            Assert.AreEqual(2, ketQua.Count);
            Assert.AreEqual("SP001", ketQua[0].MaSanPham);
            Assert.AreEqual("Áo thun", ketQua[0].TenSanPham);
        }

        [TestMethod]
        public void LayDanhSachSanPham_KhiDanhSachRong_TraVeDanhSachRong()
        {
            // Arrange
            var fake = new BanHang_SanPhamDALFake();
            fake.DanhSachSanPham = new List<SanPhamDTO>();

            var bll = new SanPhamBLL(fake);

            // Act
            List<SanPhamDTO> ketQua = bll.LayDanhSachSanPham();

            // Assert
            Assert.IsNotNull(ketQua);
            Assert.AreEqual(0, ketQua.Count);
        }

        [TestMethod]
        public void LayDanhSachSanPham_KhiDALPhatSinhLoi_NemLaiLoi()
        {
            // Arrange
            var fake = new BanHang_SanPhamDALFake
            {
                PhatSinhLoi = true
            };

            var bll = new SanPhamBLL(fake);

            // Act
            var loi = Assert.Throws<Exception>(
                () => bll.LayDanhSachSanPham());

            // Assert
            Assert.AreEqual(
                "Lỗi giả lập khi lấy sản phẩm.",
                loi.Message);
        }



        // =====================================================
        // 2. KIỂM THỬ TÌM KIẾM SẢN PHẨM
        // =====================================================

        private List<SanPhamDTO> TaoDanhSachSanPhamTimKiem()
        {
            return new List<SanPhamDTO>
            {
                new SanPhamDTO
                {
                    MaSanPham = "SP001",
                    TenSanPham = "Áo thun nam",
                    DonViTinh = "Cái",
                    GiaBan = 150000,
                    SoLuongTon = 20,
                    TrangThai = "Đang kinh doanh"
                },
                new SanPhamDTO
                {
                    MaSanPham = "SP002",
                    TenSanPham = "Áo khoác nam",
                    DonViTinh = "Cái",
                    GiaBan = 300000,
                    SoLuongTon = 10,
                    TrangThai = "Đang kinh doanh"
                },
                new SanPhamDTO
                {
                    MaSanPham = "SP003",
                    TenSanPham = "Quần jean",
                    DonViTinh = "Cái",
                    GiaBan = 250000,
                    SoLuongTon = 15,
                    TrangThai = "Đang kinh doanh"
                }
            };
        }

        [TestMethod]
        public void TimKiemSanPham_KhiTimTheoMa_TraVeDungSanPham()
        {
            var bll = new SanPhamBLL(new BanHang_SanPhamDALFake());
            var danhSach = TaoDanhSachSanPhamTimKiem();

            var ketQua = bll.TimKiemSanPham(danhSach, "SP001");

            Assert.AreEqual(1, ketQua.Count);
            Assert.AreEqual("SP001", ketQua[0].MaSanPham);
        }

        [TestMethod]
        public void TimKiemSanPham_KhiTimTheoTen_TraVeDungSanPham()
        {
            var bll = new SanPhamBLL(new BanHang_SanPhamDALFake());
            var danhSach = TaoDanhSachSanPhamTimKiem();

            var ketQua = bll.TimKiemSanPham(danhSach, "Áo thun nam");

            Assert.AreEqual(1, ketQua.Count);
            Assert.AreEqual("SP001", ketQua[0].MaSanPham);
        }

        [TestMethod]
        public void TimKiemSanPham_KhiKhacChuHoaThuong_VanTimThay()
        {
            var bll = new SanPhamBLL(new BanHang_SanPhamDALFake());
            var danhSach = TaoDanhSachSanPhamTimKiem();

            var ketQua = bll.TimKiemSanPham(danhSach, "áO THUN");

            Assert.AreEqual(1, ketQua.Count);
            Assert.AreEqual("SP001", ketQua[0].MaSanPham);
        }

        [TestMethod]
        public void TimKiemSanPham_KhiTuKhoaRong_TraVeToanBoDanhSach()
        {
            var bll = new SanPhamBLL(new BanHang_SanPhamDALFake());
            var danhSach = TaoDanhSachSanPhamTimKiem();

            var ketQua = bll.TimKiemSanPham(danhSach, "");

            Assert.AreEqual(3, ketQua.Count);
        }



        // =====================================================
        // 3. KIỂM THỬ GIỎ HÀNG
        // =====================================================

        // Tạo sản phẩm mẫu để kiểm thử giỏ hàng.
        private SanPhamDTO TaoSanPhamMau()
        {
            return new SanPhamDTO
            {
                MaSanPham = "SP_TEST",
                TenSanPham = "Áo thun kiểm thử",
                DonViTinh = "Cái",
                GiaBan = 150000,
                SoLuongTon = 10,
                TrangThai = "Đang kinh doanh"
            };
        }

        [TestMethod]
        public void ThemSanPhamVaoGio_KhiHopLe_ThemThanhCong()
        {
            // Arrange
            var bll = new GioHangBLL();
            var gioHang = new List<ChiTietHoaDonDTO>();
            var sanPham = TaoSanPhamMau();

            // Act
            bll.ThemSanPham(gioHang, sanPham, 2);

            // Assert
            Assert.AreEqual(1, gioHang.Count);
            Assert.AreEqual("SP_TEST", gioHang[0].MaSanPham);
            Assert.AreEqual(2, gioHang[0].SoLuong);
            Assert.AreEqual(300000m, gioHang[0].ThanhTien);
        }

        [TestMethod]
        public void ThemSanPhamVaoGio_KhiVuotTonKho_BaoLoi()
        {
            // Arrange
            var bll = new GioHangBLL();
            var gioHang = new List<ChiTietHoaDonDTO>();
            var sanPham = TaoSanPhamMau();

            // Act và Assert
            Assert.Throws<InvalidOperationException>(
                () => bll.ThemSanPham(gioHang, sanPham, 11));

            Assert.AreEqual(0, gioHang.Count);
        }

        [TestMethod]
        public void XoaSanPhamKhoiGio_KhiSanPhamTonTai_XoaThanhCong()
        {
            // Arrange
            var bll = new GioHangBLL();
            var gioHang = new List<ChiTietHoaDonDTO>
            {
                new ChiTietHoaDonDTO
                {
                    MaSanPham = "SP_TEST",
                    SoLuong = 2,
                    DonGia = 150000,
                    ThanhTien = 300000
                }
            };

            // Act
            bll.XoaSanPham(gioHang, "SP_TEST");

            // Assert
            Assert.AreEqual(0, gioHang.Count);
        }

        [TestMethod]
        public void CapNhatSoLuong_KhiHopLe_CapNhatThanhCong()
        {
            // Arrange
            var bll = new GioHangBLL();
            var sanPham = TaoSanPhamMau();

            var gioHang = new List<ChiTietHoaDonDTO>
            {
                new ChiTietHoaDonDTO
                {
                    MaSanPham = "SP_TEST",
                    SoLuong = 2,
                    DonGia = 150000,
                    ThanhTien = 300000
                }
            };

            // Act
            bll.CapNhatSoLuong(gioHang, sanPham, 4);

            // Assert
            Assert.AreEqual(4, gioHang[0].SoLuong);
            Assert.AreEqual(600000m, gioHang[0].ThanhTien);
        }

        [TestMethod]
        public void CapNhatSoLuong_KhiVuotTonKho_BaoLoi()
        {
            // Arrange
            var bll = new GioHangBLL();
            var sanPham = TaoSanPhamMau();

            var gioHang = new List<ChiTietHoaDonDTO>
            {
                new ChiTietHoaDonDTO
                {
                    MaSanPham = "SP_TEST",
                    SoLuong = 2,
                    DonGia = 150000,
                    ThanhTien = 300000
                }
            };

            // Act và Assert
            Assert.Throws<InvalidOperationException>(
                () => bll.CapNhatSoLuong(gioHang, sanPham, 11));

            // Số lượng cũ không được thay đổi khi cập nhật thất bại.
            Assert.AreEqual(2, gioHang[0].SoLuong);
        }

        [TestMethod]
        public void TinhTongTien_KhiCoNhieuSanPham_TraVeChinhXac()
        {
            // Arrange
            var bll = new GioHangBLL();

            var gioHang = new List<ChiTietHoaDonDTO>
            {
                new ChiTietHoaDonDTO
                {
                    MaSanPham = "SP001",
                    SoLuong = 2,
                    DonGia = 150000,
                    ThanhTien = 300000
                },
                new ChiTietHoaDonDTO
                {
                    MaSanPham = "SP002",
                    SoLuong = 3,
                    DonGia = 200000,
                    ThanhTien = 600000
                }
            };

            // Act
            decimal tongTien = bll.TinhTongTien(gioHang);

            // Assert
            Assert.AreEqual(900000m, tongTien);
        }


    }
}
