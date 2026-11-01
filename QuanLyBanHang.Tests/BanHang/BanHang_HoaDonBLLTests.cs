using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using QuanLyBanHang.BLL;
using QuanLyBanHang.DTO;

namespace QuanLyBanHang.Tests.BanHang
{
    [TestClass]
    public class BanHang_HoaDonBLLTests
    {
        private List<ChiTietHoaDonDTO> TaoChiTietMau()
        {
            return new List<ChiTietHoaDonDTO>
            {
                new ChiTietHoaDonDTO
                {
                    MaSanPham = "SP001",
                    SoLuong = 2,
                    DonGia = 150000,
                    ThanhTien = 300000
                }
            };
        }

        [TestMethod]
        public void TaoMaHoaDonMoi_KhiGoi_TraVeMaTuDAL()
        {
            var fakeDAL = new BanHang_HoaDonDALFake();
            var bll = new HoaDonBLL(fakeDAL);

            string maMoi = bll.TaoMaHoaDonMoi();

            Assert.AreEqual("HD999", maMoi);
        }

        [TestMethod]
        public void LuuHoaDon_KhiDuLieuHopLe_GoiDALThanhCong()
        {
            var fakeDAL = new BanHang_HoaDonDALFake();
            var bll = new HoaDonBLL(fakeDAL);
            var chiTiet = TaoChiTietMau();

            bll.LuuHoaDon("HD001", DateTime.Now, "KH001", 1, 300000, "Tiền mặt", chiTiet);

            Assert.IsTrue(fakeDAL.LuuHoaDonDuocGoi);
            Assert.AreEqual("HD001", fakeDAL.MaHoaDonDaLuu);
            Assert.AreEqual("Tiền mặt", fakeDAL.PhuongThucDaLuu);
            Assert.AreEqual(300000, fakeDAL.TongTienDaLuu);
        }

        [TestMethod]
        public void LuuHoaDonHuy_KhiDuLieuHopLe_GoiDALThanhCong()
        {
            var fakeDAL = new BanHang_HoaDonDALFake();
            var bll = new HoaDonBLL(fakeDAL);
            var chiTiet = TaoChiTietMau();

            bll.LuuHoaDonHuy("HD001", DateTime.Now, "KH001", 1, 300000, chiTiet);

            Assert.IsTrue(fakeDAL.LuuHoaDonHuyDuocGoi);
            Assert.AreEqual("HD001", fakeDAL.MaHoaDonDaLuu);
            Assert.AreEqual(300000, fakeDAL.TongTienDaLuu);
        }

        [TestMethod]
        public void LuuHoaDon_KhiMaHoaDonRong_NemLoiArgumentException()
        {
            var fakeDAL = new BanHang_HoaDonDALFake();
            var bll = new HoaDonBLL(fakeDAL);

            var ex = Assert.Throws<ArgumentException>(() =>
                bll.LuuHoaDon("", DateTime.Now, "KH001", 1, 300000, "Tiền mặt", TaoChiTietMau()));

            Assert.AreEqual("Mã hóa đơn không hợp lệ.", ex.Message);
        }

        [TestMethod]
        public void LuuHoaDon_KhiTaiKhoanKhongHopLe_NemLoiArgumentException()
        {
            var fakeDAL = new BanHang_HoaDonDALFake();
            var bll = new HoaDonBLL(fakeDAL);

            var ex = Assert.Throws<ArgumentException>(() =>
                bll.LuuHoaDon("HD001", DateTime.Now, "KH001", 0, 300000, "Tiền mặt", TaoChiTietMau()));

            Assert.AreEqual("Tài khoản không hợp lệ.", ex.Message);
        }

        [TestMethod]
        public void LuuHoaDon_KhiGioHangRong_NemLoiInvalidOperationException()
        {
            var fakeDAL = new BanHang_HoaDonDALFake();
            var bll = new HoaDonBLL(fakeDAL);

            var ex = Assert.Throws<InvalidOperationException>(() =>
                bll.LuuHoaDon("HD001", DateTime.Now, "KH001", 1, 300000, "Tiền mặt", new List<ChiTietHoaDonDTO>()));

            Assert.AreEqual("Giỏ hàng chưa có sản phẩm.", ex.Message);
        }

        [TestMethod]
        public void LuuHoaDon_KhiTongTienBangKhong_NemLoiInvalidOperationException()
        {
            var fakeDAL = new BanHang_HoaDonDALFake();
            var bll = new HoaDonBLL(fakeDAL);

            var ex = Assert.Throws<InvalidOperationException>(() =>
                bll.LuuHoaDon("HD001", DateTime.Now, "KH001", 1, 0, "Tiền mặt", TaoChiTietMau()));

            Assert.AreEqual("Tổng tiền hóa đơn phải lớn hơn 0.", ex.Message);
        }

        [TestMethod]
        public void LuuHoaDon_KhiThieuPhuongThucThanhToan_NemLoiArgumentException()
        {
            var fakeDAL = new BanHang_HoaDonDALFake();
            var bll = new HoaDonBLL(fakeDAL);

            var ex = Assert.Throws<ArgumentException>(() =>
                bll.LuuHoaDon("HD001", DateTime.Now, "KH001", 1, 300000, "   ", TaoChiTietMau()));

            Assert.AreEqual("Vui lòng chọn phương thức thanh toán.", ex.Message);
        }

        [TestMethod]
        public void LuuHoaDon_KhiChiTietCoSoLuongBangKhong_NemLoiArgumentException()
        {
            var fakeDAL = new BanHang_HoaDonDALFake();
            var bll = new HoaDonBLL(fakeDAL);

            var chiTietLoi = new List<ChiTietHoaDonDTO>
            {
                new ChiTietHoaDonDTO { MaSanPham = "SP001", SoLuong = 0, DonGia = 10000, ThanhTien = 0 }
            };

            var ex = Assert.Throws<ArgumentException>(() =>
                bll.LuuHoaDon("HD001", DateTime.Now, "KH001", 1, 10000, "Tiền mặt", chiTietLoi));

            Assert.AreEqual("Số lượng sản phẩm phải lớn hơn 0.", ex.Message);
        }

        [TestMethod]
        public void LuuHoaDon_KhiDALNemLoi_NemLaiNgoaiLe()
        {
            var fakeDAL = new BanHang_HoaDonDALFake { PhatSinhLoi = true };
            var bll = new HoaDonBLL(fakeDAL);

            var ex = Assert.Throws<Exception>(() =>
                bll.LuuHoaDon("HD001", DateTime.Now, "KH001", 1, 300000, "Tiền mặt", TaoChiTietMau()));

            Assert.AreEqual("Lỗi cơ sở dữ liệu giả lập khi lưu hóa đơn.", ex.Message);
        }
    }
}