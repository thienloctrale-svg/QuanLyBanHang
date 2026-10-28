using System;
using System.Data;
using Microsoft.Data.SqlClient;

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
    }
}
