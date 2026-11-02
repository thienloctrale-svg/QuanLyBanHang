
using System;
using System.Data;
using Microsoft.Data.SqlClient;

namespace QuanLyBanHang.DAL
{
    public class ThongKeDAL
    {
        // Lấy danh sách hóa đơn hoàn thành
        public DataTable LayDanhSachHoaDon(
            DateTime tuNgay,
            DateTime denNgay,
            string phuongThucThanhToan,
            string tuKhoa)
        {
            DataTable dt = new DataTable();

            using (SqlConnection conn = DbConnectionFactory.CreateConnection())
            {
                conn.Open();

                string sql = @"
                    SELECT
                        hd.MaHoaDon,
                        hd.NgayLap,
                        hd.MaKhachHang,
                        kh.TenKhachHang,
                        hd.MaTaiKhoan,
                        hd.TrangThai AS PhuongThucThanhToan,
                        hd.TongTien
                    FROM HoaDon hd
                    LEFT JOIN KhachHang kh
                        ON hd.MaKhachHang = kh.MaKhachHang
                    WHERE hd.NgayLap >= @TuNgay
                      AND hd.NgayLap < @DenNgay";

                if (!string.IsNullOrWhiteSpace(phuongThucThanhToan)
                    && phuongThucThanhToan != "Tất cả")
                {
                    sql += " AND hd.TrangThai = @PhuongThucThanhToan";
                }

                if (!string.IsNullOrWhiteSpace(tuKhoa))
                {
                    sql += @"
                        AND (
                            hd.MaHoaDon LIKE @TuKhoa
                            OR hd.MaKhachHang LIKE @TuKhoa
                            OR kh.TenKhachHang LIKE @TuKhoa
                        )";
                }

                sql += " ORDER BY hd.NgayLap DESC";

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@TuNgay", tuNgay.Date);
                    cmd.Parameters.AddWithValue(
                        "@DenNgay", denNgay.Date.AddDays(1));

                    if (!string.IsNullOrWhiteSpace(phuongThucThanhToan)
                        && phuongThucThanhToan != "Tất cả")
                    {
                        cmd.Parameters.AddWithValue(
                            "@PhuongThucThanhToan",
                            phuongThucThanhToan);
                    }

                    if (!string.IsNullOrWhiteSpace(tuKhoa))
                    {
                        cmd.Parameters.AddWithValue(
                            "@TuKhoa",
                            "%" + tuKhoa.Trim() + "%");
                    }

                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        adapter.Fill(dt);
                    }
                }
            }

            return dt;
        }

        // Lấy các chỉ số thống kê
        public DataTable LayThongTinTongQuan(
    DateTime tuNgay,
    DateTime denNgay,
    string phuongThucThanhToan,
    string tuKhoa)
        {
            DataTable dt = new DataTable();

            using (SqlConnection conn = DbConnectionFactory.CreateConnection())
            {
                conn.Open();

                string sql = @"
            SELECT
                COUNT(*) AS SoHoaDon,

                ISNULL(
                    SUM(
                        CASE
                            WHEN hd.TrangThai <> N'Đã hủy'
                                 OR hd.TrangThai IS NULL
                            THEN hd.TongTien
                            ELSE 0
                        END
                    ), 0
                ) AS TongDoanhThu,

                SUM(
                    CASE
                        WHEN hd.TrangThai = N'Đã hủy'
                        THEN 1 ELSE 0
                    END
                ) AS SoHoaDonHuy,

                CASE
                    WHEN SUM(
                        CASE
                            WHEN hd.TrangThai <> N'Đã hủy'
                                 OR hd.TrangThai IS NULL
                            THEN 1 ELSE 0
                        END
                    ) = 0
                    THEN 0

                    ELSE
                        ISNULL(
                            SUM(
                                CASE
                                    WHEN hd.TrangThai <> N'Đã hủy'
                                         OR hd.TrangThai IS NULL
                                    THEN hd.TongTien
                                    ELSE 0
                                END
                            ), 0
                        )
                        /
                        SUM(
                            CASE
                                WHEN hd.TrangThai <> N'Đã hủy'
                                     OR hd.TrangThai IS NULL
                                THEN 1 ELSE 0
                            END
                        )
                END AS TrungBinhDon

            FROM HoaDon hd
            LEFT JOIN KhachHang kh
                ON hd.MaKhachHang = kh.MaKhachHang
            WHERE hd.NgayLap >= @TuNgay
              AND hd.NgayLap < @DenNgay";

                // Nếu chọn một phương thức thanh toán cụ thể,
                // vẫn giữ hóa đơn hủy để thống kê riêng.
                if (!string.IsNullOrWhiteSpace(phuongThucThanhToan)
                    && phuongThucThanhToan != "Tất cả")
                {
                    sql += @"
                AND (
                    hd.TrangThai = @PhuongThucThanhToan
                    OR hd.TrangThai = N'Đã hủy'
                )";
                }

                // Lọc từ khóa
                if (!string.IsNullOrWhiteSpace(tuKhoa))
                {
                    sql += @"
                AND (
                    hd.MaHoaDon LIKE @TuKhoa
                    OR hd.MaKhachHang LIKE @TuKhoa
                    OR kh.TenKhachHang LIKE @TuKhoa
                )";
                }

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@TuNgay", tuNgay.Date);
                    cmd.Parameters.AddWithValue(
                        "@DenNgay", denNgay.Date.AddDays(1));

                    if (!string.IsNullOrWhiteSpace(phuongThucThanhToan)
                        && phuongThucThanhToan != "Tất cả")
                    {
                        cmd.Parameters.AddWithValue(
                            "@PhuongThucThanhToan",
                            phuongThucThanhToan);
                    }

                    if (!string.IsNullOrWhiteSpace(tuKhoa))
                    {
                        cmd.Parameters.AddWithValue(
                            "@TuKhoa",
                            "%" + tuKhoa.Trim() + "%");
                    }

                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        adapter.Fill(dt);
                    }
                }
            }

            return dt;
        }

        // Lấy chi tiết sản phẩm trong một hóa đơn
        public DataTable LayChiTietHoaDon(string maHoaDon)
        {
            DataTable dt = new DataTable();

            using (SqlConnection conn = DbConnectionFactory.CreateConnection())
            {
                conn.Open();

                string sql = @"
                    SELECT
                        ROW_NUMBER() OVER (
                            ORDER BY ct.MaSanPham
                        ) AS STT,
                        ct.MaSanPham,
                        sp.TenSanPham,
                        ct.SoLuong,
                        ct.DonGia,
                        ct.ThanhTien
                    FROM ChiTietHoaDon ct
                    INNER JOIN SanPham sp
                        ON ct.MaSanPham = sp.MaSanPham
                    WHERE ct.MaHoaDon = @MaHoaDon";

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@MaHoaDon", maHoaDon);

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
