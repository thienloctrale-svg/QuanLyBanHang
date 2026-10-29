using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using QuanLyBanHang.DTO;

namespace QuanLyBanHang.DAL
{
    public class HoaDonDAL
    {
        public void LuuHoaDon(
            string maHoaDon,
            DateTime ngayLap,
            string? maKhachHang,
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
                                (MaHoaDon, NgayLap, MaKhachHang,
                                 TongTien, TrangThai)
                            VALUES
                                (@MaHoaDon, @NgayLap, @MaKhachHang,
                                 @TongTien, @TrangThai);";

                        using (SqlCommand cmd = new SqlCommand(
                            sqlHoaDon, conn, transaction))
                        {
                            cmd.Parameters.AddWithValue("@MaHoaDon", maHoaDon);
                            cmd.Parameters.AddWithValue("@NgayLap", ngayLap);
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
                            // Chỉ trừ kho nếu sản phẩm còn đủ số lượng.
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

                            string sqlChiTiet = @"
                                INSERT INTO ChiTietHoaDon
                                    (MaHoaDon, MaSanPham, SoLuong,
                                     DonGia, ThanhTien)
                                VALUES
                                    (@MaHoaDon, @MaSanPham, @SoLuong,
                                     @DonGia, @ThanhTien);";

                            using (SqlCommand cmd = new SqlCommand(
                                sqlChiTiet, conn, transaction))
                            {
                                cmd.Parameters.AddWithValue(
                                    "@MaHoaDon", maHoaDon);
                                cmd.Parameters.AddWithValue(
                                    "@MaSanPham", item.MaSanPham);
                                cmd.Parameters.AddWithValue(
                                    "@SoLuong", item.SoLuong);
                                cmd.Parameters.AddWithValue(
                                    "@DonGia", item.DonGia);
                                cmd.Parameters.AddWithValue(
                                    "@ThanhTien", item.ThanhTien);

                                cmd.ExecuteNonQuery();
                            }
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
    }
}
