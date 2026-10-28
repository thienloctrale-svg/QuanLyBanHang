using System.Data;
using Microsoft.Data.SqlClient;

namespace QuanLyBanHang.DAL
{
    public class SanPhamDAL
    {
        // 1. Lấy danh sách sản phẩm kết hợp tên Loại sản phẩm (Đã bổ sung sp.MaLoaiSP để ComboBox nhận diện)
        public DataTable LayDanhSachSanPham()
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = DbConnectionFactory.CreateConnection())
            {
                string query = @"SELECT sp.MaSanPham, sp.TenSanPham, sp.MaLoaiSP, lsp.TenLoaiSP, 
                                        sp.DonViTinh, sp.GiaNhap, sp.GiaBan, 
                                        sp.SoLuongTon, sp.TrangThai
                                 FROM SanPham sp
                                 LEFT JOIN LoaiSanPham lsp ON sp.MaLoaiSP = lsp.MaLoaiSP";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    conn.Open();
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        da.Fill(dt);
                    }
                }
            }
            return dt;
        }

        // 2. Thêm sản phẩm mới
        public bool ThemSanPham(string maSP, string tenSP, string maLoaiSP, string donViTinh, decimal giaNhap, decimal giaBan, int soLuongTon, string trangThai)
        {
            using (SqlConnection conn = DbConnectionFactory.CreateConnection())
            {
                string query = @"INSERT INTO SanPham (MaSanPham, TenSanPham, MaLoaiSP, DonViTinh, GiaNhap, GiaBan, SoLuongTon, TrangThai) 
                                 VALUES (@MaSP, @TenSP, @MaLoaiSP, @DonViTinh, @GiaNhap, @GiaBan, @SoLuongTon, @TrangThai)";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@MaSP", maSP);
                    cmd.Parameters.AddWithValue("@TenSP", tenSP);
                    cmd.Parameters.AddWithValue("@MaLoaiSP", string.IsNullOrEmpty(maLoaiSP) ? DBNull.Value : (object)maLoaiSP);
                    cmd.Parameters.AddWithValue("@DonViTinh", donViTinh);
                    cmd.Parameters.AddWithValue("@GiaNhap", giaNhap);
                    cmd.Parameters.AddWithValue("@GiaBan", giaBan);
                    cmd.Parameters.AddWithValue("@SoLuongTon", soLuongTon);
                    cmd.Parameters.AddWithValue("@TrangThai", trangThai);

                    conn.Open();
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        // 3. Sửa sản phẩm
        public bool SuaSanPham(string maSP, string tenSP, string maLoaiSP, string donViTinh, decimal giaNhap, decimal giaBan, int soLuongTon, string trangThai)
        {
            using (SqlConnection conn = DbConnectionFactory.CreateConnection())
            {
                string query = @"UPDATE SanPham 
                                 SET TenSanPham = @TenSP, MaLoaiSP = @MaLoaiSP, DonViTinh = @DonViTinh, 
                                     GiaNhap = @GiaNhap, GiaBan = @GiaBan, SoLuongTon = @SoLuongTon, TrangThai = @TrangThai 
                                 WHERE MaSanPham = @MaSP";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@MaSP", maSP);
                    cmd.Parameters.AddWithValue("@TenSP", tenSP);
                    cmd.Parameters.AddWithValue("@MaLoaiSP", string.IsNullOrEmpty(maLoaiSP) ? DBNull.Value : (object)maLoaiSP);
                    cmd.Parameters.AddWithValue("@DonViTinh", donViTinh);
                    cmd.Parameters.AddWithValue("@GiaNhap", giaNhap);
                    cmd.Parameters.AddWithValue("@GiaBan", giaBan);
                    cmd.Parameters.AddWithValue("@SoLuongTon", soLuongTon);
                    cmd.Parameters.AddWithValue("@TrangThai", trangThai);

                    conn.Open();
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        // 4. Xóa sản phẩm
        public bool XoaSanPham(string maSP)
        {
            using (SqlConnection conn = DbConnectionFactory.CreateConnection())
            {
                string query = "DELETE FROM SanPham WHERE MaSanPham = @MaSP";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@MaSP", maSP);
                    conn.Open();
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        // 5. Tìm kiếm sản phẩm theo Mã hoặc Tên (Cũng bổ sung sp.MaLoaiSP)
        public DataTable TimKiemSanPham(string tuKhoa)
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = DbConnectionFactory.CreateConnection())
            {
                string query = @"SELECT sp.MaSanPham, sp.TenSanPham, sp.MaLoaiSP, lsp.TenLoaiSP, 
                                        sp.DonViTinh, sp.GiaNhap, sp.GiaBan, 
                                        sp.SoLuongTon, sp.TrangThai
                                 FROM SanPham sp
                                 LEFT JOIN LoaiSanPham lsp ON sp.MaLoaiSP = lsp.MaLoaiSP
                                 WHERE sp.MaSanPham LIKE @TuKhoa OR sp.TenSanPham LIKE @TuKhoa";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@TuKhoa", "%" + tuKhoa + "%");
                    conn.Open();
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        da.Fill(dt);
                    }
                }
            }
            return dt;
        }
    }
}