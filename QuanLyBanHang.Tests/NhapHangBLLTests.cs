using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Data;
using QuanLyBanHang.BLL;
using QuanLyBanHang.DAL;

namespace QuanLyBanHang.Tests
{
    [TestClass]
    public class NhapHangBLLTests
    {
        [TestMethod]
        public void TestThemPhieuNhap_ThanhCong()
        {
            // Mục tiêu: Kiểm tra kịch bản thêm phiếu nhập thành công khi DAL trả về true.
            var mockDal = new Mock<INhapHangDAL>();

            mockDal.Setup(d => d.ThemPhieuNhap(
                It.IsAny<string>(),
                It.IsAny<DateTime>(),
                It.IsAny<string>(),
                It.IsAny<int>(),
                It.IsAny<DataTable>()))
                   .Returns(true);

            var bll = new NhapHangBLL(mockDal.Object);

            DataTable dtChiTiet = new DataTable();
            dtChiTiet.Columns.Add("MaSanPham", typeof(string));
            dtChiTiet.Rows.Add("SP01");

            // Act
            bool result = bll.ThemPhieuNhap("PN01", DateTime.Now, "NCC01", 1, dtChiTiet);

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void TestXoaPhieuNhap_ThanhCong()
        {
            // Mục tiêu: Kiểm tra kịch bản xóa phiếu nhập thành công.
            var mockDal = new Mock<INhapHangDAL>();

            mockDal.Setup(d => d.XoaPhieuNhap("PN01"))
                   .Returns(true);

            var bll = new NhapHangBLL(mockDal.Object);

            // Act
            bool result = bll.XoaPhieuNhap("PN01");

            // Assert
            Assert.IsTrue(result);
        }
    }
}