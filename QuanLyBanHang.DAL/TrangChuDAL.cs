using System;
using Microsoft.Data.SqlClient;
using QuanLyBanHang.DTO;
using QuanLyBanHang.Logging;

namespace QuanLyBanHang.DAL
{
    public class TrangChuDAL
    {
        public TrangChuThongKeDTO LayThongKeTongQuan()
        {
            var dto = new TrangChuThongKeDTO();

            string sql = @"
                SELECT 
                    (SELECT ISNULL(SUM(TongTien), 0) FROM HoaDon WHERE CAST(NgayLap AS DATE) = CAST(GETDATE() AS DATE)) AS DoanhThuHomNay,
                    (SELECT COUNT(*) FROM HoaDon WHERE CAST(NgayLap AS DATE) = CAST(GETDATE() AS DATE)) AS SoHoaDonHomNay,
                    (SELECT COUNT(*) FROM SanPham) AS TongSoSanPham,
                    (SELECT COUNT(*) FROM KhachHang WHERE TrangThai = N'Đang hoạt động') AS TongSoKhachHang;";

            try
            {
                using (SqlConnection conn = DbConnectionFactory.CreateConnection())
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            dto.DoanhThuHomNay = reader["DoanhThuHomNay"] != DBNull.Value ? Convert.ToDecimal(reader["DoanhThuHomNay"]) : 0;
                            dto.SoHoaDonHomNay = reader["SoHoaDonHomNay"] != DBNull.Value ? Convert.ToInt32(reader["SoHoaDonHomNay"]) : 0;
                            dto.TongSoSanPham = reader["TongSoSanPham"] != DBNull.Value ? Convert.ToInt32(reader["TongSoSanPham"]) : 0;
                            dto.TongSoKhachHang = reader["TongSoKhachHang"] != DBNull.Value ? Convert.ToInt32(reader["TongSoKhachHang"]) : 0;
                        }
                    }
                }

                AppLogger.Information($"DAL: Lay thong ke tong quan trang chu thanh cong. Doanh thu: {dto.DoanhThuHomNay:N0} đ, HD: {dto.SoHoaDonHomNay}, SP: {dto.TongSoSanPham}, KH: {dto.TongSoKhachHang}");
                return dto;
            }
            catch (Exception ex)
            {
                AppLogger.Error(ex, "DAL: Loi khi truy van thong ke tong quan trang chu.");
                throw;
            }
        }
    }
}
