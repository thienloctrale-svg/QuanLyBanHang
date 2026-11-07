using System;
using System.Data;

namespace QuanLyBanHang.DAL
{
    public interface INhapHangDAL
    {
        DataTable LayDanhSachNhaCungCap();
        DataTable LayDanhSachSanPham();
        bool ThemPhieuNhap(string maPN, DateTime ngayNhap, string maNCC, int maTaiKhoan, DataTable dtChiTiet);
        DataTable LayDanhSachPhieuNhap();
        bool XoaPhieuNhap(string maPN);
    }
}