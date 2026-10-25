using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using QuanLyBanHang.BLL;


namespace QuanLyBanHang.Tests
{
    [TestClass]
    public class ConnectionServiceTests
    {
        [TestMethod]
        public void TestConnection_KhiSqlServerHoatDong_TraVeThanhCong()
        {
            // Act: Kiem tra ket noi SQL Server
            bool ketQua =
                ConnectionService.TestConnection(out string message);

            // Assert: Xac nhan ket noi thanh cong
            Assert.IsTrue(
                ketQua,
                "Ket noi SQL Server that bai: " + message);
        }
    }
}
