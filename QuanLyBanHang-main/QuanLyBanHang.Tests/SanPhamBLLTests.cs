using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using QuanLyBanHang.BLL;
using QuanLyBanHang.DTO;

namespace QuanLyBanHang.Tests
{
    [TestClass]
    public class SanPhamBLLTests
    {
        [TestMethod]
        public void LayDanhSachSanPham_CoDuLieu_TraVeDanhSachDung()
        {
            // Arrange: chuẩn bị dữ liệu kiểm thử
            var dalGia = new SanPhamDALGia();

            dalGia.DanhSachSanPham = new List<SanPhamDTO>
            {
                new SanPhamDTO
                {
                    MaSanPham = "SP01",
                    TenSanPham = "Bút bi",
                    DonViTinh = "Cây",
                    GiaBan = 5000,
                    SoLuongTon = 100,
                    TrangThai = "Đang kinh doanh"
                },
                new SanPhamDTO
                {
                    MaSanPham = "SP02",
                    TenSanPham = "Vở",
                    DonViTinh = "Quyển",
                    GiaBan = 12000,
                    SoLuongTon = 50,
                    TrangThai = "Đang kinh doanh"
                }
            };

            var bll = new SanPhamBLL(dalGia);

            // Act: thực hiện chức năng
            List<SanPhamDTO> ketQua = bll.LayDanhSachSanPham();

            // Assert: kiểm tra kết quả
            Assert.AreEqual(2, ketQua.Count);
            Assert.AreEqual("SP01", ketQua[0].MaSanPham);
            Assert.AreEqual("Bút bi", ketQua[0].TenSanPham);
            Assert.AreEqual(12000m, ketQua[1].GiaBan);
        }

        [TestMethod]
        public void LayDanhSachSanPham_DanhSachRong_TraVeDanhSachRong()
        {
            // Arrange
            var dalGia = new SanPhamDALGia();
            var bll = new SanPhamBLL(dalGia);

            // Act
            List<SanPhamDTO> ketQua = bll.LayDanhSachSanPham();

            // Assert
            Assert.IsNotNull(ketQua);
            Assert.AreEqual(0, ketQua.Count);
        }

        [TestMethod]
        public void LayDanhSachSanPham_DALPhatSinhLoi_NemLaiLoi()
        {
            // Arrange
            var dalGia = new SanPhamDALGia
            {
                PhatSinhLoi = true
            };

            var bll = new SanPhamBLL(dalGia);

			// Act + Assert
			Assert.Throws<Exception>(
				() => bll.LayDanhSachSanPham());
		}

        [TestMethod]
        public void KhoiTaoBLL_DALLaNull_PhatSinhArgumentNullException()
        {
			// Act + Assert
			Assert.Throws<ArgumentNullException>(
				() => new SanPhamBLL(null));
		}
    }
}
