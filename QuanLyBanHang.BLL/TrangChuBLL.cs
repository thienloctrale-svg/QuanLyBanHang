using System;
using QuanLyBanHang.DAL;
using QuanLyBanHang.DTO;
using QuanLyBanHang.Logging;

namespace QuanLyBanHang.BLL
{
    public class TrangChuBLL
    {
        private readonly TrangChuDAL _trangChuDAL;

        public TrangChuBLL()
        {
            _trangChuDAL = new TrangChuDAL();
        }

        public TrangChuBLL(TrangChuDAL dal)
        {
            _trangChuDAL = dal ?? throw new ArgumentNullException(nameof(dal));
        }

        public TrangChuThongKeDTO LayThongKeTongQuan()
        {
            try
            {
                TrangChuThongKeDTO thongKe = _trangChuDAL.LayThongKeTongQuan();
                AppLogger.Information("BLL: Lay thong ke tong quan trang chu thanh cong.");
                return thongKe;
            }
            catch (Exception ex)
            {
                AppLogger.Error(ex, "BLL: Loi khi lay thong ke tong quan trang chu.");
                throw;
            }
        }

        public string DinhDangTienTe(decimal soTien)
        {
            return $"{soTien:N0} đ";
        }

        public string DinhDangSoLuong(int soLuong, string donVi)
        {
            return $"{soLuong:N0} {donVi}";
        }
    }
}
