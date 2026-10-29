using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using QuanLyBanHang.DTO;
using QuanLyBanHang.Logging;

namespace QuanLyBanHang.DAL
{
    public class KhachHangDAL
    {
        public List<KhachHangDTO> LayDanhSachKhachHang()
        {
            List<KhachHangDTO> danhSach = new List<KhachHangDTO>();

            string sql = @"
                SELECT MaKhachHang, TenKhachHang, GioiTinh,
                       SoDienThoai, Email, LoaiKhachHang,
                       DiaChi, TrangThai
                FROM KhachHang
                WHERE TrangThai = N'Đang hoạt động'
                ORDER BY TenKhachHang;";

            try
            {
                using (SqlConnection connection =
                       DbConnectionFactory.CreateConnection())
                {
                    connection.Open();

                    using (SqlCommand command =
                           new SqlCommand(sql, connection))
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            KhachHangDTO kh = new KhachHangDTO
                            {
                                MaKhachHang = reader["MaKhachHang"].ToString()
                                    ?? string.Empty,

                                TenKhachHang = reader["TenKhachHang"].ToString()
                                    ?? string.Empty,

                                GioiTinh = reader["GioiTinh"].ToString()
                                    ?? string.Empty,

                                SoDienThoai = reader["SoDienThoai"].ToString()
                                    ?? string.Empty,

                                Email = reader["Email"].ToString()
                                    ?? string.Empty,

                                LoaiKhachHang = reader["LoaiKhachHang"].ToString()
                                    ?? string.Empty,

                                DiaChi = reader["DiaChi"].ToString()
                                    ?? string.Empty,

                                TrangThai = reader["TrangThai"].ToString()
                                    ?? string.Empty
                            };

                            danhSach.Add(kh);
                        }
                    }
                }

                AppLogger.Information(
                    $"DAL: Đọc danh sách khách hàng thành công. Số lượng: {danhSach.Count}");

                return danhSach;
            }
            catch (Exception ex)
            {
                AppLogger.Error(ex, "DAL: Lỗi khi đọc danh sách khách hàng.");
                throw;
            }
        }
    }
}
