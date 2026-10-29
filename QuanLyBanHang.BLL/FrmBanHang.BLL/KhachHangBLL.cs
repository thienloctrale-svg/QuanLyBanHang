using System;
using System.Collections.Generic;
using QuanLyBanHang.DAL;
using QuanLyBanHang.DTO;
using QuanLyBanHang.Logging;

namespace QuanLyBanHang.BLL
{
    public class KhachHangBLL
    {
        private readonly KhachHangDAL khachHangDAL;

        public KhachHangBLL()
        {
            khachHangDAL = new KhachHangDAL();
        }

        public List<KhachHangDTO> LayDanhSachKhachHang()
        {
            try
            {
                List<KhachHangDTO> danhSach =
                    khachHangDAL.LayDanhSachKhachHang();

                AppLogger.Information(
                    $"BLL: Lấy danh sách khách hàng thành công. Số lượng: {danhSach.Count}");

                return danhSach;
            }
            catch (Exception ex)
            {
                AppLogger.Error(
                    ex,
                    "BLL: Không thể lấy danh sách khách hàng.");

                throw;
            }
        }
    }
}
