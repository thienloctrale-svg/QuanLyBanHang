using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using QuanLyBanHang.BLL;
using QuanLyBanHang.DTO;

namespace QuanLyBanHang.Tests.BanHang
{
    [TestClass]
    public class BanHang_KhachHangBLLTests
    {
        private List<KhachHangDTO> TaoDanhSachKhachHangMau()
        {
            return new List<KhachHangDTO>
            {
                new KhachHangDTO
                {
                    MaKhachHang = "KH001",
                    TenKhachHang = "Nguyễn Văn An",
                    SoDienThoai = "0901234567"
                },
                new KhachHangDTO
                {
                    MaKhachHang = "KH002",
                    TenKhachHang = "Trần Thị Bích",
                    SoDienThoai = "0987654321"
                },
                new KhachHangDTO
                {
                    MaKhachHang = "KH003",
                    TenKhachHang = "Lê Hoàng Nam",
                    SoDienThoai = "0911223344"
                }
            };
        }

        [TestMethod] // Kiểm tra tìm kiếm khách hàng trả về đúng bản ghi khi từ khóa khớp với tên
        public void TimKiemKhachHang_KhiTuKhoaKhopTen_TraVeDungKhachHang()
        {
            var bll = new KhachHangBLL();
            var danhSach = TaoDanhSachKhachHangMau();

            var ketQua = bll.TimKiemKhachHang(danhSach, "văn an");

            Assert.AreEqual(1, ketQua.Count);
            Assert.AreEqual("KH001", ketQua[0].MaKhachHang);
        }

        [TestMethod] // Kiểm tra chức năng tìm kiếm không phân biệt chữ hoa, chữ thường
        public void TimKiemKhachHang_KhiTuKhoaChuHoaChuThuong_VanTimThay()
        {
            var bll = new KhachHangBLL();
            var danhSach = TaoDanhSachKhachHangMau();

            var ketQua = bll.TimKiemKhachHang(danhSach, "TRẦN THỊ");

            Assert.AreEqual(1, ketQua.Count);
            Assert.AreEqual("KH002", ketQua[0].MaKhachHang);
        }

        [TestMethod] // Kiểm tra trả về danh sách rỗng khi từ khóa tìm kiếm không tồn tại trong dữ liệu
        public void TimKiemKhachHang_KhiTuKhoaKhongTonTai_TraVeDanhSachRong()
        {
            var bll = new KhachHangBLL();
            var danhSach = TaoDanhSachKhachHangMau();

            var ketQua = bll.TimKiemKhachHang(danhSach, "Phạm Quốc Cường");

            Assert.AreEqual(0, ketQua.Count);
        }

        [TestMethod] // Kiểm tra trả về toàn bộ danh sách khi từ khóa là rỗng hoặc khoảng trắng
        public void TimKiemKhachHang_KhiTuKhoaRongHoacKhoangTrang_TraVeToanBoDanhSach()
        {
            var bll = new KhachHangBLL();
            var danhSach = TaoDanhSachKhachHangMau();

            var ketQua = bll.TimKiemKhachHang(danhSach, "   ");

            Assert.AreEqual(3, ketQua.Count);
        }

        [TestMethod] // Kiểm tra ném ngoại lệ ArgumentNullException khi danh sách nguồn truyền vào là null
        public void TimKiemKhachHang_KhiDanhSachTruyenVaoNull_NemLoiArgumentNullException()
        {
            var bll = new KhachHangBLL();

            Assert.Throws<ArgumentNullException>(() =>
                bll.TimKiemKhachHang(null!, "An"));
        }
    }
}