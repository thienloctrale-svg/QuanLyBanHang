using System;
using System.Collections.Generic;
using QuanLyBanHang.DAL;
using QuanLyBanHang.DTO;
using QuanLyBanHang.Logging;

namespace QuanLyBanHang.BLL
{
    public class SanPhamBLL
    {
        private readonly ISanPhamDAL sanPhamDAL;

        // Dùng khi chạy ứng dụng thật
        public SanPhamBLL()
        {
            sanPhamDAL = new SanPhamDAL();
        }

        // Dùng khi kiểm thử
        public SanPhamBLL(ISanPhamDAL sanPhamDAL)
        {
            this.sanPhamDAL = sanPhamDAL
                ?? throw new ArgumentNullException(nameof(sanPhamDAL));
        }

        public List<SanPhamDTO> LayDanhSachSanPham()
        {
            try
            {
                List<SanPhamDTO> danhSach =
                    sanPhamDAL.LayDanhSachSanPham();

                AppLogger.Information(
                    $"BLL: Lấy danh sách sản phẩm thành công. Số lượng: {danhSach.Count}");

                return danhSach;
            }
            catch (Exception ex)
            {
                AppLogger.Error(
                    ex,
                    "BLL: Không thể lấy danh sách sản phẩm.");

                throw;
            }
        }
    }
}
