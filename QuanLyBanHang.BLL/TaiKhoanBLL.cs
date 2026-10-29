using System.Data;
using QuanLyBanHang.DAL;
using QuanLyBanHang.DTO;

namespace QuanLyBanHang.BLL
{
    public class TaiKhoanBLL
    {
        private TaiKhoanDAL dal = new TaiKhoanDAL();

        // Xử lý nghiệp vụ đăng nhập
        public TaiKhoanDTO DangNhap(string tenDangNhap, string matKhau)
        {
            if (string.IsNullOrWhiteSpace(tenDangNhap) || string.IsNullOrWhiteSpace(matKhau))
                return null;

            return dal.KiemTraDangNhap(tenDangNhap, matKhau);
        }

        // 1. Lấy danh sách tài khoản cho DataGridView
        public DataTable LayDanhSachTaiKhoan()
        {
            return dal.LayDanhSachTaiKhoan();
        }

        // 2. Nghiệp vụ thêm tài khoản mới
        public bool ThemTaiKhoan(string user, string pass, string hoTen, string email, string sdt, string vaiTro, string trangThai)
        {
            if (string.IsNullOrWhiteSpace(user) || string.IsNullOrWhiteSpace(pass) || string.IsNullOrWhiteSpace(hoTen))
                return false;

            return dal.ThemTaiKhoan(user, pass, hoTen, email, sdt, vaiTro, trangThai);
        }

        // 3. Nghiệp vụ sửa thông tin tài khoản
        public bool SuaTaiKhoan(int maTK, string hoTen, string pass, string email, string sdt, string vaiTro, string trangThai)
        {
            if (maTK <= 0 || string.IsNullOrWhiteSpace(hoTen))
                return false;

            return dal.SuaTaiKhoan(maTK, hoTen, pass, email, sdt, vaiTro, trangThai);
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
    }
}