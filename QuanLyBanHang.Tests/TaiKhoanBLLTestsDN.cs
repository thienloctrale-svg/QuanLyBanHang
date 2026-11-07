using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using QuanLyBanHang.BLL;

namespace QuanLyBanHang.Tests
{
    [TestClass]
    public class TaiKhoanBLLTestsDN
    {
        private TaiKhoanBLL bll = null!;

        [TestInitialize]
        public void SetUp()
        {
            // Khởi tạo đối tượng BLL trước mỗi lần chạy test
            bll = new TaiKhoanBLL();
        }

        [TestMethod]
        public void Test_DangNhap_WithInvalidCredentials_ShouldReturnNull()
        {
            // Arrange: Tạo tên đăng nhập giả lập chắc chắn không có trong hệ thống
            string fakeUser = "user_khong_ton_tai_" + DateTime.Now.Ticks;
            string fakePass = "wrongpassword123";

            // Act: Gọi hàm đăng nhập với thông tin sai
            var result = bll.DangNhap(fakeUser, fakePass);

            // Assert: Kết quả trả về phải là null (không đăng nhập được)
            Assert.IsNull(result, "Đăng nhập với tài khoản không tồn tại phải trả về null.");
        }

        [TestMethod]
        public void Test_DangNhap_WithEmptyValues_ShouldReturnNull()
        {
            // Act: Truyền chuỗi rỗng vào tài khoản hoặc mật khẩu
            var resultEmptyAll = bll.DangNhap("", "");
            var resultEmptyPass = bll.DangNhap("admin", "");
            var resultEmptyUser = bll.DangNhap("", "123456");

            // Assert: Tất cả các trường hợp thiếu thông tin đều phải trả về null
            Assert.IsNull(resultEmptyAll, "Đăng nhập khi để trống cả tài khoản và mật khẩu phải trả về null.");
            Assert.IsNull(resultEmptyPass, "Đăng nhập khi thiếu mật khẩu phải trả về null.");
            Assert.IsNull(resultEmptyUser, "Đăng nhập khi thiếu tài khoản phải trả về null.");
        }

        [TestMethod]
        public void Test_DangNhap_WithSqlInjectionString_ShouldNotCrash()
        {
            // Arrange: Thử nghiệm truyền ký tự đặc biệt hoặc cú pháp nháy đơn SQL
            string dangerousUser = "' OR '1'='1";
            string dangerousPass = "' OR '1'='1";

            // Act: Gọi hàm đăng nhập
            var result = bll.DangNhap(dangerousUser, dangerousPass);

            // Assert: Hệ thống phải xử lý an toàn (trả về null hoặc từ chối), không được sập ứng dụng
            Assert.IsNull(result, "Hệ thống phải chặn được các chuỗi nhạy cảm và không cho phép đăng nhập trái phép.");
        }

        [TestMethod]
        public void Test_DangNhap_WithValidCredentials_ShouldReturnUser()
        {
            // Act: Đăng nhập với tài khoản 'tiepdm' và mật khẩu '1234567' đã được mã hóa trong CSDL
            var result = bll.DangNhap("tiepdm", "1234567");

            // Assert
            Assert.IsNotNull(result, "Đăng nhập với tài khoản 'tiepdm' và mật khẩu '1234567' phải thành công.");
            Assert.AreEqual("tiepdm", result.TenDangNhap);
            Assert.AreEqual("Đỗ Minh Tiệp", result.HoTen);
        }
    }
}
