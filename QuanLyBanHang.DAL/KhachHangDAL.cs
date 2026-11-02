using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using QuanLyBanHang.DTO;
using QuanLyBanHang.Logging;

namespace QuanLyBanHang.DAL
{
    public class KhachHangDAL
    {
        public DataTable LayDanhSachKhachHang(string tuKhoa = "", string loaiKhachHang = "")
        {
            DataTable dt = new DataTable();

            using (SqlConnection conn = DbConnectionFactory.CreateConnection())
            {
                conn.Open();

                string query = @"
                    SELECT 
                        ROW_NUMBER() OVER (ORDER BY MaKhachHang) AS STT,
                        MaKhachHang,
                        TenKhachHang,
                        GioiTinh,
                        NgaySinh,
                        SoDienThoai,
                        Email,
                        LoaiKhachHang,
                        DiaChi,
                        TrangThai,
                        GhiChu
                    FROM KhachHang
                    WHERE 1 = 1";

                if (!string.IsNullOrWhiteSpace(tuKhoa))
                {
                    query += " AND (MaKhachHang LIKE @TuKhoa OR TenKhachHang LIKE @TuKhoa OR SoDienThoai LIKE @TuKhoa)";
                }

                if (!string.IsNullOrWhiteSpace(loaiKhachHang) && 
                    !loaiKhachHang.Equals("Tất cả", StringComparison.OrdinalIgnoreCase) && 
                    !loaiKhachHang.Equals("Tất cả loại KH", StringComparison.OrdinalIgnoreCase))
                {
                    query += " AND LoaiKhachHang = @LoaiKhachHang";
                }

                query += " ORDER BY MaKhachHang";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    if (!string.IsNullOrWhiteSpace(tuKhoa))
                    {
                        cmd.Parameters.AddWithValue("@TuKhoa", "%" + tuKhoa.Trim() + "%");
                    }

                    if (!string.IsNullOrWhiteSpace(loaiKhachHang) && 
                        !loaiKhachHang.Equals("Tất cả", StringComparison.OrdinalIgnoreCase) && 
                        !loaiKhachHang.Equals("Tất cả loại KH", StringComparison.OrdinalIgnoreCase))
                    {
                        cmd.Parameters.AddWithValue("@LoaiKhachHang", loaiKhachHang.Trim());
                    }

                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        adapter.Fill(dt);
                    }
                }
            }

            return dt;
        }

        public List<KhachHangDTO> LayDanhSachKhachHangDTO()
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
                using (SqlConnection connection = DbConnectionFactory.CreateConnection())
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            KhachHangDTO kh = new KhachHangDTO
                            {
                                MaKhachHang = reader["MaKhachHang"].ToString() ?? string.Empty,
                                TenKhachHang = reader["TenKhachHang"].ToString() ?? string.Empty,
                                GioiTinh = reader["GioiTinh"].ToString() ?? string.Empty,
                                SoDienThoai = reader["SoDienThoai"].ToString() ?? string.Empty,
                                Email = reader["Email"].ToString() ?? string.Empty,
                                LoaiKhachHang = reader["LoaiKhachHang"].ToString() ?? string.Empty,
                                DiaChi = reader["DiaChi"].ToString() ?? string.Empty,
                                TrangThai = reader["TrangThai"].ToString() ?? string.Empty
                            };

                            danhSach.Add(kh);
                        }
                    }
                }

                AppLogger.Information($"DAL: Đọc danh sách khách hàng thành công. Số lượng: {danhSach.Count}");
                return danhSach;
            }
            catch (Exception ex)
            {
                AppLogger.Error(ex, "DAL: Lỗi khi đọc danh sách khách hàng.");
                throw;
            }
        }

        public bool KiemTraTonTai(string maKhachHang)
        {
            using (SqlConnection conn = DbConnectionFactory.CreateConnection())
            {
                conn.Open();
                string query = "SELECT COUNT(*) FROM KhachHang WHERE MaKhachHang = @MaKhachHang";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@MaKhachHang", maKhachHang.Trim());
                    int count = (int)cmd.ExecuteScalar();
                    return count > 0;
                }
            }
        }

        public bool ThemKhachHang(KhachHangDTO kh)
        {
            using (SqlConnection conn = DbConnectionFactory.CreateConnection())
            {
                conn.Open();
                string query = @"
                    INSERT INTO KhachHang 
                    (MaKhachHang, TenKhachHang, GioiTinh, NgaySinh, SoDienThoai, Email, LoaiKhachHang, DiaChi, TrangThai, GhiChu)
                    VALUES 
                    (@MaKhachHang, @TenKhachHang, @GioiTinh, @NgaySinh, @SoDienThoai, @Email, @LoaiKhachHang, @DiaChi, @TrangThai, @GhiChu)";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@MaKhachHang", kh.MaKhachHang.Trim());
                    cmd.Parameters.AddWithValue("@TenKhachHang", kh.TenKhachHang.Trim());
                    cmd.Parameters.AddWithValue("@GioiTinh", (object)kh.GioiTinh ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@NgaySinh", kh.NgaySinh.HasValue ? (object)kh.NgaySinh.Value : DBNull.Value);
                    cmd.Parameters.AddWithValue("@SoDienThoai", string.IsNullOrWhiteSpace(kh.SoDienThoai) ? DBNull.Value : (object)kh.SoDienThoai.Trim());
                    cmd.Parameters.AddWithValue("@Email", string.IsNullOrWhiteSpace(kh.Email) ? DBNull.Value : (object)kh.Email.Trim());
                    cmd.Parameters.AddWithValue("@LoaiKhachHang", string.IsNullOrWhiteSpace(kh.LoaiKhachHang) ? "Khách thường" : (object)kh.LoaiKhachHang.Trim());
                    cmd.Parameters.AddWithValue("@DiaChi", string.IsNullOrWhiteSpace(kh.DiaChi) ? DBNull.Value : (object)kh.DiaChi.Trim());
                    cmd.Parameters.AddWithValue("@TrangThai", string.IsNullOrWhiteSpace(kh.TrangThai) ? "Đang hoạt động" : (object)kh.TrangThai.Trim());
                    cmd.Parameters.AddWithValue("@GhiChu", string.IsNullOrWhiteSpace(kh.GhiChu) ? DBNull.Value : (object)kh.GhiChu.Trim());

                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        public bool CapNhatKhachHang(KhachHangDTO kh)
        {
            using (SqlConnection conn = DbConnectionFactory.CreateConnection())
            {
                conn.Open();
                string query = @"
                    UPDATE KhachHang
                    SET 
                        TenKhachHang = @TenKhachHang,
                        GioiTinh = @GioiTinh,
                        NgaySinh = @NgaySinh,
                        SoDienThoai = @SoDienThoai,
                        Email = @Email,
                        LoaiKhachHang = @LoaiKhachHang,
                        DiaChi = @DiaChi,
                        TrangThai = @TrangThai,
                        GhiChu = @GhiChu
                    WHERE MaKhachHang = @MaKhachHang";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@MaKhachHang", kh.MaKhachHang.Trim());
                    cmd.Parameters.AddWithValue("@TenKhachHang", kh.TenKhachHang.Trim());
                    cmd.Parameters.AddWithValue("@GioiTinh", (object)kh.GioiTinh ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@NgaySinh", kh.NgaySinh.HasValue ? (object)kh.NgaySinh.Value : DBNull.Value);
                    cmd.Parameters.AddWithValue("@SoDienThoai", string.IsNullOrWhiteSpace(kh.SoDienThoai) ? DBNull.Value : (object)kh.SoDienThoai.Trim());
                    cmd.Parameters.AddWithValue("@Email", string.IsNullOrWhiteSpace(kh.Email) ? DBNull.Value : (object)kh.Email.Trim());
                    cmd.Parameters.AddWithValue("@LoaiKhachHang", string.IsNullOrWhiteSpace(kh.LoaiKhachHang) ? "Khách thường" : (object)kh.LoaiKhachHang.Trim());
                    cmd.Parameters.AddWithValue("@DiaChi", string.IsNullOrWhiteSpace(kh.DiaChi) ? DBNull.Value : (object)kh.DiaChi.Trim());
                    cmd.Parameters.AddWithValue("@TrangThai", string.IsNullOrWhiteSpace(kh.TrangThai) ? "Đang hoạt động" : (object)kh.TrangThai.Trim());
                    cmd.Parameters.AddWithValue("@GhiChu", string.IsNullOrWhiteSpace(kh.GhiChu) ? DBNull.Value : (object)kh.GhiChu.Trim());

                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        public bool XoaKhachHang(string maKhachHang, out string loiRao)
        {
            loiRao = string.Empty;
            using (SqlConnection conn = DbConnectionFactory.CreateConnection())
            {
                conn.Open();

                // Kiểm tra xem khách hàng có đơn hàng chưa
                string checkInvoice = "SELECT COUNT(*) FROM HoaDon WHERE MaKhachHang = @MaKhachHang";
                using (SqlCommand checkCmd = new SqlCommand(checkInvoice, conn))
                {
                    checkCmd.Parameters.AddWithValue("@MaKhachHang", maKhachHang.Trim());
                    int invoiceCount = (int)checkCmd.ExecuteScalar();
                    if (invoiceCount > 0)
                    {
                        loiRao = $"Không thể xóa khách hàng '{maKhachHang}' vì đã phát sinh {invoiceCount} hóa đơn trong hệ thống. Bạn có thể chuyển trạng thái sang 'Tạm ngừng'.";
                        return false;
                    }
                }

                string deleteQuery = "DELETE FROM KhachHang WHERE MaKhachHang = @MaKhachHang";
                using (SqlCommand cmd = new SqlCommand(deleteQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@MaKhachHang", maKhachHang.Trim());
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        public string TaoMaKhachHangTuDong()
        {
            using (SqlConnection conn = DbConnectionFactory.CreateConnection())
            {
                conn.Open();
                string query = "SELECT MAX(CAST(SUBSTRING(MaKhachHang, 3, 10) AS INT)) FROM KhachHang WHERE MaKhachHang LIKE 'KH[0-9]%'";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    object result = cmd.ExecuteScalar();
                    int maxId = (result != null && result != DBNull.Value) ? Convert.ToInt32(result) : 0;
                    return $"KH{(maxId + 1):D3}";
                }
            }
        }
    }
}
