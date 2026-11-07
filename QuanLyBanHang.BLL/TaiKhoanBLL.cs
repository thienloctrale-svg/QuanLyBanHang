using System.Data;
using QuanLyBanHang.DAL;
using QuanLyBanHang.DTO;
using System.Security.Cryptography;
using System.Text;

namespace QuanLyBanHang.BLL
{
    public class TaiKhoanBLL
    {
        private TaiKhoanDAL dal = new TaiKhoanDAL();

        // Xử lý nghiệp vụ đăng nhập (Đã tích hợp mã hóa mật khẩu để so sánh)
        public TaiKhoanDTO DangNhap(string tenDangNhap, string matKhau)
        {
            if (string.IsNullOrWhiteSpace(tenDangNhap) || string.IsNullOrWhiteSpace(matKhau))
                return null;

            // Mã hóa mật khẩu người dùng vừa nhập trước khi gọi xuống DAL kiểm tra
            string hashedPassword = HashPassword(matKhau);
            return dal.KiemTraDangNhap(tenDangNhap, hashedPassword);
        }

        // 1. Lấy danh sách tài khoản cho DataGridView
        public DataTable LayDanhSachTaiKhoan()
        {
            return dal.LayDanhSachTaiKhoan();
        }

        // 2. Nghiệp vụ thêm tài khoản mới (Đã tích hợp mã hóa mật khẩu)
        public bool ThemTaiKhoan(string user, string pass, string hoTen, string email, string sdt, string vaiTro, string trangThai)
        {
            if (string.IsNullOrWhiteSpace(user) || string.IsNullOrWhiteSpace(pass) || string.IsNullOrWhiteSpace(hoTen))
                return false;

            // Mã hóa mật khẩu trước khi truyền xuống DAL
            string hashedPassword = HashPassword(pass);
            return dal.ThemTaiKhoan(user, hashedPassword, hoTen, email, sdt, vaiTro, trangThai);
        }

        // 3. Nghiệp vụ sửa thông tin tài khoản (Đã tích hợp mã hóa mật khẩu)
        public bool SuaTaiKhoan(int maTK, string hoTen, string pass, string email, string sdt, string vaiTro, string trangThai)
        {
            if (maTK <= 0 || string.IsNullOrWhiteSpace(hoTen))
                return false;

            // Mã hóa mật khẩu mới trước khi cập nhật xuống CSDL
            string hashedPassword = HashPassword(pass);
            return dal.SuaTaiKhoan(maTK, hoTen, hashedPassword, email, sdt, vaiTro, trangThai);
        }

        // 4. Nghiệp vụ cập nhật trạng thái (Khóa / Mở khóa)
        public bool CapNhatTrangThai(int maTK, string trangThai)
        {
            if (maTK <= 0 || string.IsNullOrWhiteSpace(trangThai))
                return false;

            return dal.CapNhatTrangThai(maTK, trangThai);
        }

        // Xóa tài khoản
        public bool XoaTaiKhoan(int maTK)
        {
            return dal.XoaTaiKhoan(maTK);
        }

        // Hàm mã hoá mật khẩu chuẩn SHA256
        public string HashPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = Encoding.UTF8.GetBytes(password);
                byte[] hashBytes = sha256.ComputeHash(bytes);
                return Convert.ToHexString(hashBytes); // Trả về chuỗi mã hóa dạng Hex an toàn
            }
        }
    }
}