using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using QuanLyBanHang.DTO;

namespace QuanLyBanHang.DAL
{
    public class HoaDonDAL
    {

        // Tự động tạo mã hóa đơn mới: HD001, HD002, HD003...
        public string TaoMaHoaDonMoi()
        {
            using (SqlConnection conn = DbConnectionFactory.CreateConnection())
            {
                conn.Open();

                string sql = @"
            SELECT ISNULL(
                MAX(TRY_CAST(SUBSTRING(MaHoaDon, 3, LEN(MaHoaDon)) AS INT)),
                0
            ) + 1
            FROM HoaDon
            WHERE MaHoaDon LIKE 'HD%'
              AND TRY_CAST(SUBSTRING(MaHoaDon, 3, LEN(MaHoaDon)) AS INT) IS NOT NULL;";

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    int soThuTu = Convert.ToInt32(cmd.ExecuteScalar());

                    return "HD" + soThuTu.ToString("D3");
                }
            }
        }
        // Lưu hóa đơn bán hàng bình thường
        // Có trừ số lượng tồn kho.
        public void LuuHoaDon(
            string maHoaDon,
            DateTime ngayLap,
            string? maKhachHang,
            int maTaiKhoan,
            decimal tongTien,
            string phuongThucThanhToan,
            List<ChiTietHoaDonDTO> chiTiet)
        {
            using (SqlConnection conn = DbConnectionFactory.CreateConnection())
            {
                conn.Open();

                using (SqlTransaction transaction = conn.BeginTransaction())
                {
                    try
                    {
                        string sqlHoaDon = @"
                            INSERT INTO HoaDon
                                (MaHoaDon, NgayLap, MaKhachHang, MaTaiKhoan,
                                 TongTien, TrangThai)
                            VALUES
                                (@MaHoaDon, @NgayLap, @MaKhachHang, @MaTaiKhoan,
                                 @TongTien, @TrangThai);";

                        using (SqlCommand cmd = new SqlCommand(
                            sqlHoaDon, conn, transaction))
                        {
                            cmd.Parameters.AddWithValue("@MaHoaDon", maHoaDon);
                            cmd.Parameters.AddWithValue("@NgayLap", ngayLap);
                            cmd.Parameters.AddWithValue("@MaTaiKhoan", maTaiKhoan);

                            cmd.Parameters.AddWithValue(
                                "@MaKhachHang",
                                string.IsNullOrWhiteSpace(maKhachHang)
                                    ? (object)DBNull.Value
                                    : maKhachHang);

                            cmd.Parameters.AddWithValue("@TongTien", tongTien);
                            cmd.Parameters.AddWithValue(
                                "@TrangThai", phuongThucThanhToan);

                            cmd.ExecuteNonQuery();
                        }

                        foreach (ChiTietHoaDonDTO item in chiTiet)
                        {
                            // Trừ tồn kho
                            string sqlTruKho = @"
                                UPDATE SanPham
                                SET SoLuongTon = SoLuongTon - @SoLuong
                                WHERE MaSanPham = @MaSanPham
                                  AND SoLuongTon >= @SoLuong;";

                            using (SqlCommand cmd = new SqlCommand(
                                sqlTruKho, conn, transaction))
                            {
                                cmd.Parameters.AddWithValue(
                                    "@MaSanPham", item.MaSanPham);

                                cmd.Parameters.AddWithValue(
                                    "@SoLuong", item.SoLuong);

                                if (cmd.ExecuteNonQuery() != 1)
                                {
                                    throw new Exception(
                                        "Sản phẩm " + item.MaSanPham +
                                        " không tồn tại hoặc không đủ tồn kho.");
                                }
                            }

                            ThemChiTietHoaDon(
                                conn, transaction, maHoaDon, item);
                        }

                        transaction.Commit();
                    }
                    catch
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }

        // Lưu hóa đơn đã hủy
        // Không trừ tồn kho.
        public void LuuHoaDonHuy(
            string maHoaDon,
            DateTime ngayLap,
            string? maKhachHang,
            int maTaiKhoan,
            decimal tongTien,
            List<ChiTietHoaDonDTO> chiTiet)
        {
            using (SqlConnection conn = DbConnectionFactory.CreateConnection())
            {
                conn.Open();

                using (SqlTransaction transaction = conn.BeginTransaction())
                {
                    try
                    {
                        string sqlHoaDon = @"
                            INSERT INTO HoaDon
                                (MaHoaDon, NgayLap, MaKhachHang, MaTaiKhoan,
                                 TongTien, TrangThai)
                            VALUES
                                (@MaHoaDon, @NgayLap, @MaKhachHang, @MaTaiKhoan,
                                 @TongTien, @TrangThai);";

                        using (SqlCommand cmd = new SqlCommand(
                            sqlHoaDon, conn, transaction))
                        {
                            cmd.Parameters.AddWithValue("@MaHoaDon", maHoaDon);
                            cmd.Parameters.AddWithValue("@NgayLap", ngayLap);
                            cmd.Parameters.AddWithValue("@MaTaiKhoan", maTaiKhoan);

                            cmd.Parameters.AddWithValue(
                                "@MaKhachHang",
                                string.IsNullOrWhiteSpace(maKhachHang)
                                    ? (object)DBNull.Value
                                    : maKhachHang);

                            cmd.Parameters.AddWithValue("@TongTien", tongTien);

                            // Trạng thái hóa đơn đã hủy
                            cmd.Parameters.AddWithValue(
                                "@TrangThai", "Đã hủy");

                            cmd.ExecuteNonQuery();
                        }

                        // Lưu chi tiết nhưng tuyệt đối không trừ kho
                        foreach (ChiTietHoaDonDTO item in chiTiet)
                        {
                            ThemChiTietHoaDon(
                                conn, transaction, maHoaDon, item);
                        }

                        transaction.Commit();
                    }
                    catch
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }

        // Hàm dùng chung để lưu chi tiết hóa đơn
        private void ThemChiTietHoaDon(
            SqlConnection conn,
            SqlTransaction transaction,
            string maHoaDon,
            ChiTietHoaDonDTO item)
        {
            string sqlChiTiet = @"
                INSERT INTO ChiTietHoaDon
                    (MaHoaDon, MaSanPham, SoLuong, DonGia, ThanhTien)
                VALUES
                    (@MaHoaDon, @MaSanPham, @SoLuong, @DonGia, @ThanhTien);";

            using (SqlCommand cmd = new SqlCommand(
                sqlChiTiet, conn, transaction))
            {
                cmd.Parameters.AddWithValue("@MaHoaDon", maHoaDon);
                cmd.Parameters.AddWithValue("@MaSanPham", item.MaSanPham);
                cmd.Parameters.AddWithValue("@SoLuong", item.SoLuong);
                cmd.Parameters.AddWithValue("@DonGia", item.DonGia);
                cmd.Parameters.AddWithValue("@ThanhTien", item.ThanhTien);

                cmd.ExecuteNonQuery();
            }
        }
    }
}
