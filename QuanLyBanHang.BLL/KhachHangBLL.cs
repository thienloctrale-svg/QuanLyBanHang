using System.Data;
using QuanLyBanHang.DAL;

namespace QuanLyBanHang.BLL
{
    public class KhachHangBLL
    {
        private readonly KhachHangDAL _khachHangDAL = new KhachHangDAL();

        public DataTable LayDanhSachKhachHang(string tuKhoa = "", string loaiKhachHang = "")
        {
            return _khachHangDAL.LayDanhSachKhachHang(tuKhoa, loaiKhachHang);
        }
    }
}
