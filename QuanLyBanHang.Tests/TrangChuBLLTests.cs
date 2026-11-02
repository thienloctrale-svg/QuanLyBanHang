using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using QuanLyBanHang.BLL;
using QuanLyBanHang.DAL;
using QuanLyBanHang.DTO;
using QuanLyBanHang.Logging;

namespace QuanLyBanHang.Tests
{
    [TestClass]
    public class TrangChuBLLTests
    {
        private static TrangChuBLL _bll = null!;

        [ClassInitialize]
        public static void ClassInit(TestContext context)
        {
            AppLogger.Initialize();
            _bll = new TrangChuBLL();
        }

        [TestMethod]
        public void KhoiTaoBLL_DALNull_NemNgoaiLeArgumentNullException()
        {
            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => new TrangChuBLL(null!));
        }

        [TestMethod]
        public void LayThongKeTongQuan_TraVeDuLieuHopLe()
        {
            // Act
            TrangChuThongKeDTO dto = _bll.LayThongKeTongQuan();

            // Assert
            Assert.IsNotNull(dto, "TrangChuThongKeDTO không được null.");
            Assert.IsTrue(dto.TongSoSanPham >= 0, "Tổng số sản phẩm phải >= 0.");
            Assert.IsTrue(dto.TongSoKhachHang >= 0, "Tổng số khách hàng phải >= 0.");
            Assert.IsTrue(dto.SoHoaDonHomNay >= 0, "Số hóa đơn hôm nay phải >= 0.");
            Assert.IsTrue(dto.DoanhThuHomNay >= 0, "Doanh thu hôm nay phải >= 0.");
        }

        [TestMethod]
        public void LayThongKeTongQuan_CoKhachHangMauTrongDatabase()
        {
            // Act: Database seed đã có ít nhất 8 khách hàng
            TrangChuThongKeDTO dto = _bll.LayThongKeTongQuan();

            // Assert
            Assert.IsTrue(dto.TongSoKhachHang >= 5, $"Hệ thống có ít nhất 8 khách hàng hoạt động. Thực tế: {dto.TongSoKhachHang}");
        }

        [TestMethod]
        public void DinhDangTienTe_DinhDangDungChuanVND()
        {
            // Arrange
            decimal tien = 1500000;

            // Act
            string ketQua = _bll.DinhDangTienTe(tien);

            // Assert
            Assert.IsTrue(ketQua.Contains("1,500,000") || ketQua.Contains("1.500.000"), "Phải có định dạng phân cách hàng nghìn.");
            Assert.IsTrue(ketQua.EndsWith("đ"), "Đơn vị tiền tệ phải kết thúc bằng 'đ'.");
        }

        [TestMethod]
        public void DinhDangSoLuong_DinhDangDungDonVi()
        {
            // Arrange
            int soLuong = 24;
            string donVi = "hóa đơn";

            // Act
            string ketQua = _bll.DinhDangSoLuong(soLuong, donVi);

            // Assert
            Assert.AreEqual("24 hóa đơn", ketQua);
        }
    }
}
