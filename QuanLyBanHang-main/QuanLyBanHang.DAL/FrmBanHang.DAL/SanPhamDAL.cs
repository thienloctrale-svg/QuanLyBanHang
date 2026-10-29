using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using QuanLyBanHang.DTO;
using QuanLyBanHang.Logging;

namespace QuanLyBanHang.DAL
{
    public class SanPhamDAL : ISanPhamDAL
    {
        public List<SanPhamDTO> LayDanhSachSanPham()
        {
            List<SanPhamDTO> danhSach = new List<SanPhamDTO>();

            string sql = @"
                SELECT MaSanPham, TenSanPham, DonViTinh,
                       GiaBan, SoLuongTon, TrangThai
                FROM SanPham
                WHERE TrangThai = @TrangThai
                ORDER BY TenSanPham;";

            try
            {
                using (SqlConnection connection =
                       DbConnectionFactory.CreateConnection())
                {
                    connection.Open();

                    using (SqlCommand command =
                           new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue(
                            "@TrangThai", "Đang kinh doanh");

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                SanPhamDTO sanPham = new SanPhamDTO
                                {
                                    MaSanPham = reader["MaSanPham"].ToString()
                                        ?? string.Empty,

                                    TenSanPham = reader["TenSanPham"].ToString()
                                        ?? string.Empty,

                                    DonViTinh = reader["DonViTinh"].ToString()
                                        ?? string.Empty,

                                    GiaBan = Convert.ToDecimal(reader["GiaBan"]),

                                    SoLuongTon = Convert.ToInt32(
                                        reader["SoLuongTon"]),

                                    TrangThai = reader["TrangThai"].ToString()
                                        ?? string.Empty
                                };

                                danhSach.Add(sanPham);
                            }
                        }
                    }
                }

                AppLogger.Information(
                    $"Đọc danh sách sản phẩm thành công. Số lượng: {danhSach.Count}");

                return danhSach;
            }
            catch (Exception ex)
            {
                AppLogger.Error(ex, "Lỗi khi đọc danh sách sản phẩm.");

                throw;
            }
        }
    }
}
