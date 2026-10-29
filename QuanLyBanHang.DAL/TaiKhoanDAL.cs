using System;
using System.Data;
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
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();

            return config.GetConnectionString("DefaultConnection");
        }

        // Đăng nhập hệ thống
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

        // 1. Lấy danh sách toàn bộ tài khoản lên DataGridView
        public DataTable LayDanhSachTaiKhoan()
        {
            DataTable dt = new DataTable();
            string connString = GetConnectionString();
            if (string.IsNullOrEmpty(connString)) return dt;

            using (SqlConnection conn = new SqlConnection(connString))
            {
                string query = "SELECT MaTaiKhoan, TenDangNhap, MatKhau, HoTen, Email, SoDienThoai, VaiTro, TrangThai, NgayTao FROM TaiKhoan";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        da.Fill(dt);
                    }
                }
            }
            return dt;
        }

        // 2. Thêm tài khoản mới
        public bool ThemTaiKhoan(string user, string pass, string hoTen, string email, string sdt, string vaiTro, string trangThai)
        {
            string connString = GetConnectionString();
            if (string.IsNullOrEmpty(connString)) return false;

            string query = "INSERT INTO TaiKhoan (TenDangNhap, MatKhau, HoTen, Email, SoDienThoai, VaiTro, TrangThai, NgayTao) " +
                           "VALUES (@TenDangNhap, @MatKhau, @HoTen, @Email, @SoDienThoai, @VaiTro, @TrangThai, GETDATE())";
            using (SqlConnection conn = new SqlConnection(connString))
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@TenDangNhap", user);
                    cmd.Parameters.AddWithValue("@MatKhau", pass);
                    cmd.Parameters.AddWithValue("@HoTen", hoTen);
                    cmd.Parameters.AddWithValue("@Email", string.IsNullOrEmpty(email) ? (object)DBNull.Value : email);
                    cmd.Parameters.AddWithValue("@SoDienThoai", string.IsNullOrEmpty(sdt) ? (object)DBNull.Value : sdt);
                    cmd.Parameters.AddWithValue("@VaiTro", vaiTro);
                    cmd.Parameters.AddWithValue("@TrangThai", trangThai);

                    try
                    {
                        conn.Open();
                        int rows = cmd.ExecuteNonQuery();
                        return rows > 0;
                    }
                    catch
                    {
                        return false;
                    }
                }
            }
        }

        // 3. Sửa thông tin tài khoản
        public bool SuaTaiKhoan(int maTK, string hoTen, string pass, string email, string sdt, string vaiTro, string trangThai)
        {
            string connString = GetConnectionString();
            if (string.IsNullOrEmpty(connString)) return false;

            string query = "UPDATE TaiKhoan SET HoTen = @HoTen, MatKhau = @MatKhau, Email = @Email, " +
                           "SoDienThoai = @SoDienThoai, VaiTro = @VaiTro, TrangThai = @TrangThai " +
                           "WHERE MaTaiKhoan = @MaTaiKhoan";
            using (SqlConnection conn = new SqlConnection(connString))
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@MaTaiKhoan", maTK);
                    cmd.Parameters.AddWithValue("@HoTen", hoTen);
                    cmd.Parameters.AddWithValue("@MatKhau", pass);
                    cmd.Parameters.AddWithValue("@Email", string.IsNullOrEmpty(email) ? (object)DBNull.Value : email);
                    cmd.Parameters.AddWithValue("@SoDienThoai", string.IsNullOrEmpty(sdt) ? (object)DBNull.Value : sdt);
                    cmd.Parameters.AddWithValue("@VaiTro", vaiTro);
                    cmd.Parameters.AddWithValue("@TrangThai", trangThai);

                    try
                    {
                        conn.Open();
                        int rows = cmd.ExecuteNonQuery();
                        return rows > 0;
                    }
                    catch
                    {
                        return false;
                    }
                }
            }
        }

        // 4. Cập nhật trạng thái (Khóa / Mở khóa)
        public bool CapNhatTrangThai(int maTK, string trangThai)
        {
            string connString = GetConnectionString();
            if (string.IsNullOrEmpty(connString)) return false;

            string query = "UPDATE TaiKhoan SET TrangThai = @TrangThai WHERE MaTaiKhoan = @MaTaiKhoan";
            using (SqlConnection conn = new SqlConnection(connString))
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@MaTaiKhoan", maTK);
                    cmd.Parameters.AddWithValue("@TrangThai", trangThai);

                    try
                    {
                        conn.Open();
                        int rows = cmd.ExecuteNonQuery();
                        return rows > 0;
                    }
                    catch
                    {
                        return false;
                    }
                }
            }
        }
        // 5. Xóa tài khoản theo Mã tài khoản
        public bool XoaTaiKhoan(int maTK)
        {
            string query = "DELETE FROM TaiKhoan WHERE MaTaiKhoan = @MaTaiKhoan";

            // Khai báo biến connString 
            string connString = "Server=.;Database=QuanLyBanHang;Integrated Security=True;TrustServerCertificate=True;";

            using (SqlConnection conn = new SqlConnection(connString))
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@MaTaiKhoan", maTK);
                    try
                    {
                        conn.Open();
                        return cmd.ExecuteNonQuery() > 0;
                    }
                    catch
                    {
                        return false;
                    }
                }
            }
        }
    }
}