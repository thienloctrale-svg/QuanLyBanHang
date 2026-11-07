using System;
using System.Collections.Generic;
using QuanLyBanHang.DAL;
using QuanLyBanHang.DTO;

namespace QuanLyBanHang.Tests.BanHang
{
    // Lớp giả lập (Mock/Fake) tầng DAL của Sản phẩm phục vụ chạy Unit Test độc lập với cơ sở dữ liệu
    public class BanHang_SanPhamDALFake : ISanPhamDAL
    {
        public List<SanPhamDTO> DanhSachSanPham { get; set; } // Danh sách sản phẩm mẫu được nạp vào bộ nhớ tạm để phục vụ kiểm thử
            = new List<SanPhamDTO>();

        public bool PhatSinhLoi { get; set; } // Cờ kích hoạt giả lập tình huống ném ngoại lệ từ cơ sở dữ liệu

        // Giả lập hàm lấy toàn bộ danh sách sản phẩm từ cơ sở dữ liệu
        public List<SanPhamDTO> LayDanhSachSanPham()
        {
            if (PhatSinhLoi)
            {
                throw new Exception("Lỗi giả lập khi lấy sản phẩm.");
            }

            return DanhSachSanPham;
        }
    }
}