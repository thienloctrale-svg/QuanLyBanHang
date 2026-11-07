using System.Data;

namespace QuanLyBanHang.DAL
{
    public interface ISanPhamDAL_SP
    {
        DataTable LayDanhSachSanPham();

        bool ThemSanPham(
            string ma, string ten, string maloai,
            string dvt, decimal gn, decimal gb, int sl, string tt);

        bool SuaSanPham(
            string ma, string ten, string maloai,
            string dvt, decimal gn, decimal gb, int sl, string tt);

        bool XoaSanPham(string ma);

        DataTable TimKiemSanPham(string keyword);
    }
}