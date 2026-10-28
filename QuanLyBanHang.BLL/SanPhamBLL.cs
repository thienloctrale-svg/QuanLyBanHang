using System.Data;
using QuanLyBanHang.DAL;

namespace QuanLyBanHang.BLL
{
    public class SanPhamBLL
    {
        private SanPhamDAL dal = new SanPhamDAL();

        public DataTable LayDanhSach() => dal.LayDanhSachSanPham();

        public bool Them(string ma, string ten, string maloai, string dvt, decimal gn, decimal gb, int sl, string tt)
            => dal.ThemSanPham(ma, ten, maloai, dvt, gn, gb, sl, tt);

        public bool Sua(string ma, string ten, string maloai, string dvt, decimal gn, decimal gb, int sl, string tt)
            => dal.SuaSanPham(ma, ten, maloai, dvt, gn, gb, sl, tt);

        public bool Xoa(string ma) => dal.XoaSanPham(ma);

        public DataTable TimKiem(string keyword) => dal.TimKiemSanPham(keyword);
    }
}