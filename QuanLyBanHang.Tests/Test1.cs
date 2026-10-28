using System;
using System.Data;
using System.IO;
using System.Text.RegularExpressions;
using Microsoft.Data.SqlClient;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using QuanLyBanHang.BLL;

namespace QuanLyBanHang.Tests
{
    [TestClass]
    public sealed class Test1
    {
        [TestMethod]
        public void KiemTraLayDanhSachKhachHangTuBLL()
        {
            var bll = new KhachHangBLL();
            DataTable dt = bll.LayDanhSachKhachHang();

            Assert.IsNotNull(dt, "DataTable trả về null");
            Assert.IsTrue(dt.Rows.Count >= 8, $"Số lượng khách hàng phải >= 8, thực tế: {dt.Rows.Count}");
            Assert.IsTrue(dt.Columns.Contains("STT"), "Thiếu cột STT");
            Assert.IsTrue(dt.Columns.Contains("MaKhachHang"), "Thiếu cột MaKhachHang");
            Assert.IsTrue(dt.Columns.Contains("TenKhachHang"), "Thiếu cột TenKhachHang");

            Console.WriteLine($"Lấy thành công {dt.Rows.Count} khách hàng từ SQL Server!");
        }

        [TestMethod]
        public void KiemTraTimKiemKhachHang()
        {
            var bll = new KhachHangBLL();
            DataTable dt = bll.LayDanhSachKhachHang("Nguyễn Văn An");

            Assert.IsNotNull(dt);
            Assert.AreEqual(1, dt.Rows.Count, "Tìm kiếm theo tên 'Nguyễn Văn An' phải ra đúng 1 kết quả.");
            Assert.AreEqual("KH001", dt.Rows[0]["MaKhachHang"].ToString());
        }
    }
}
