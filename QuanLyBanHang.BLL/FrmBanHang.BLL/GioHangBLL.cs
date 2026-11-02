using System;
using System.Collections.Generic;
using System.Linq;
using QuanLyBanHang.DTO;

namespace QuanLyBanHang.BLL
{
    public class GioHangBLL
    {
        // Thêm sản phẩm vào giỏ hàng
        public void ThemSanPham(
            List<ChiTietHoaDonDTO> gioHang,
            SanPhamDTO sanPham,
            int soLuong)
        {
            if (gioHang == null)
                throw new ArgumentNullException(nameof(gioHang));

            if (sanPham == null)
                throw new ArgumentNullException(nameof(sanPham));

            if (soLuong <= 0)
                throw new ArgumentException("Số lượng phải lớn hơn 0.");

            if (soLuong > sanPham.SoLuongTon)
                throw new InvalidOperationException("Số lượng yêu cầu vượt quá tồn kho.");

            ChiTietHoaDonDTO? itemCu = gioHang.FirstOrDefault(
                x => x.MaSanPham == sanPham.MaSanPham);

            if (itemCu != null)
            {
                int soLuongMoi = itemCu.SoLuong + soLuong;

                if (soLuongMoi > sanPham.SoLuongTon)
                    throw new InvalidOperationException("Tổng số lượng trong giỏ vượt quá tồn kho.");

                itemCu.SoLuong = soLuongMoi;
                itemCu.ThanhTien = soLuongMoi * itemCu.DonGia;
            }
            else
            {
                gioHang.Add(new ChiTietHoaDonDTO
                {
                    MaSanPham = sanPham.MaSanPham,
                    SoLuong = soLuong,
                    DonGia = sanPham.GiaBan,
                    ThanhTien = soLuong * sanPham.GiaBan
                });
            }
        }

        // Xóa sản phẩm khỏi giỏ hàng
        public void XoaSanPham(
            List<ChiTietHoaDonDTO> gioHang,
            string maSanPham)
        {
            if (gioHang == null)
                throw new ArgumentNullException(nameof(gioHang));

            ChiTietHoaDonDTO? item = gioHang.FirstOrDefault(
                x => x.MaSanPham == maSanPham);

            if (item == null)
                throw new InvalidOperationException("Không tìm thấy sản phẩm trong giỏ hàng.");

            gioHang.Remove(item);
        }

        // Cập nhật số lượng sản phẩm
        public void CapNhatSoLuong(
            List<ChiTietHoaDonDTO> gioHang,
            SanPhamDTO sanPham,
            int soLuongMoi)
        {
            if (gioHang == null)
                throw new ArgumentNullException(nameof(gioHang));

            if (sanPham == null)
                throw new ArgumentNullException(nameof(sanPham));

            if (soLuongMoi <= 0)
                throw new ArgumentException("Số lượng phải lớn hơn 0.");

            if (soLuongMoi > sanPham.SoLuongTon)
                throw new InvalidOperationException("Số lượng yêu cầu vượt quá tồn kho.");

            ChiTietHoaDonDTO? item = gioHang.FirstOrDefault(
                x => x.MaSanPham == sanPham.MaSanPham);

            if (item == null)
                throw new InvalidOperationException("Không tìm thấy sản phẩm trong giỏ hàng.");

            item.SoLuong = soLuongMoi;
            item.DonGia = sanPham.GiaBan;
            item.ThanhTien = soLuongMoi * sanPham.GiaBan;
        }

        // Tính tổng tiền giỏ hàng
        public decimal TinhTongTien(List<ChiTietHoaDonDTO> gioHang)
        {
            if (gioHang == null)
                throw new ArgumentNullException(nameof(gioHang));

            return gioHang.Sum(x => x.ThanhTien);
        }
    }
}