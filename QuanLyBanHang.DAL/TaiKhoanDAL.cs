using System;
using System.IO;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using QuanLyBanHang.DTO;

namespace QuanLyBanHang.DAL
{
    public class TaiKhoanDAL
    {
        private string GetConnectionString()
        {
            IConfiguration config = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .Build();
            return config.GetConnectionString("DefaultConnection");
        }

        public TaiKhoanDTO KiemTraDangNhap(string tenDangNhap, string matKhau)
        {
            TaiKhoanDTO tk = null;
            string connString = GetConnectionString();

            if (string.IsNullOrEmpty(connString)) return null;

            using (SqlConnection conn = new SqlConnection(connString))
            {
                string query = "SELECT MaTaiKhoan, TenDangNhap, MatKhau, HoTen FROM TaiKhoan WHERE TenDangNhap = @user AND MatKhau = @pass";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@user", tenDangNhap);
                    cmd.Parameters.AddWithValue("@pass", matKhau);

                    try
                    {
                        conn.Open();
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                tk = new TaiKhoanDTO()
                                {
                                    MaTaiKhoan = Convert.ToInt32(reader["MaTaiKhoan"]),
                                    TenDangNhap = reader["TenDangNhap"].ToString(),
                                    MatKhau = reader["MatKhau"].ToString(),
                                    HoTen = reader["HoTen"] != DBNull.Value ? reader["HoTen"].ToString() : ""
                                };
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        // Ghi log hoặc xử lý ngoại lệ kết nối nếu cần
                    }
                }
            }
            return tk;
        }
    }
}