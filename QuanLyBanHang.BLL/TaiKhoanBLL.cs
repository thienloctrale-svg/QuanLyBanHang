using QuanLyBanHang.DAL;
using QuanLyBanHang.DTO;

namespace QuanLyBanHang.BLL
{
    public class TaiKhoanBLL
    {
        private TaiKhoanDAL dal = new TaiKhoanDAL();

        public TaiKhoanDTO DangNhap(string tenDangNhap, string matKhau)
        {
            if (string.IsNullOrWhiteSpace(tenDangNhap) || string.IsNullOrWhiteSpace(matKhau))
                return null;

            return dal.KiemTraDangNhap(tenDangNhap, matKhau);
        }
    }
}