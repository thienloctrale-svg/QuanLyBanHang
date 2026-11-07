using Microsoft.VisualStudio.TestTools.UnitTesting;
using QuanLyBanHang.BLL;
using System;
using System.Data;

namespace QuanLyBanHang.Tests
{
    [TestClass]
    public class TaiKhoanBLLTests
    {
        private TaiKhoanBLL bll;

        [TestInitialize]
        public void SetUp()
        {
            // Khởi tạo đối tượng BLL trước mỗi bài test
            bll = new TaiKhoanBLL();
        }

        [TestMethod]
        public void Test_LayDanhSachTaiKhoan_ShouldReturnDataTable()
        {
            // Act
            DataTable dt = bll.LayDanhSachTaiKhoan();

            // Assert
            Assert.IsNotNull(dt, "Danh sách tài khoản trả về không được null.");
        }

        [TestMethod]
        public void Test_ThemSuaXoaTaiKhoan_Workflow()
        {
            // Arrange: Tạo dữ liệu giả lập để test
            string uniqueUser = "test_" + DateTime.Now.Ticks;
            string pass = "123456";
            string hoTen = "Nguyen Van Test";
            string email = "test@gmail.com";
            string sdt = "0901234567";
            string vaiTro = "Nhân viên";
            string trangThai = "Đang hoạt động";

            // 1. Test Chức Năng Thêm
            bool isAdded = bll.ThemTaiKhoan(uniqueUser, pass, hoTen, email, sdt, vaiTro, trangThai);
            Assert.IsTrue(isAdded, "Thêm tài khoản thất bại hoặc tên đăng nhập bị trùng.");

            // Lấy lại danh sách để tìm ra mã tài khoản vừa tạo
            DataTable dt = bll.LayDanhSachTaiKhoan();
            int maTK = -1;

            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    // Kiểm tra cột thứ 2 (index 1) hoặc tùy chỉnh theo thứ tự cột trong SQL của bạn (thường là TenDangNhap / Username)
                    // Hoặc bạn có thể in ra tên các cột để kiểm tra nếu cần. Ở đây giả định cột index 1 là Tên đăng nhập và index 0 là Mã.
                    string dbUser = row[1]?.ToString(); // Thay số 1 bằng vị trí cột Tên Đăng Nhập trong bảng của bạn

                    if (dbUser == uniqueUser)
                    {
                        maTK = Convert.ToInt32(row[0]); // Thay số 0 bằng vị trí cột Mã Tài Khoản trong bảng của bạn
                        break;
                    }
                }
            }

            Assert.IsTrue(maTK > 0, "Không tìm thấy mã tài khoản vừa thêm trong cơ sở dữ liệu.");

            // 2. Test Chức Năng Sửa
            string updatedHoTen = "Nguyen Van Updated";
            bool isUpdated = bll.SuaTaiKhoan(maTK, updatedHoTen, pass, email, sdt, vaiTro, trangThai);
            Assert.IsTrue(isUpdated, "Cập nhật thông tin tài khoản thất bại.");

            // 3. Test Chức Năng Xóa (Dọn dẹp dữ liệu test)
            bool isDeleted = bll.XoaTaiKhoan(maTK);
            Assert.IsTrue(isDeleted, "Xóa tài khoản test thất bại.");
        }
    }
}