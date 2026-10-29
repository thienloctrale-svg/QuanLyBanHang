using System;
using System.Collections.Generic;
using QuanLyBanHang.DAL;
using QuanLyBanHang.DTO;

namespace QuanLyBanHang.Tests
{
    public class SanPhamDALGia : ISanPhamDAL
    {
        public List<SanPhamDTO> DanhSachSanPham { get; set; }
            = new List<SanPhamDTO>();

        public bool PhatSinhLoi { get; set; }

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
