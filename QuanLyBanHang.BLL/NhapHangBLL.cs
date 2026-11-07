using System;
using System.Data;
using QuanLyBanHang.DAL;
using QuanLyBanHang.Logging;

namespace QuanLyBanHang.BLL
{
    public class NhapHangBLL
    {
        private readonly INhapHangDAL dal;

        // Constructor mặc định dùng DAL thật cho Form
        public NhapHangBLL()
        {
            dal = new NhapHangDAL();
        }

        // Constructor hỗ trợ DAL giả lập (dùng cho Unit Test)
        public NhapHangBLL(INhapHangDAL? dal)
        {
            this.dal = dal ?? throw new ArgumentNullException(nameof(dal));
        }

        // Lấy danh sách nhà cung cấp
        public DataTable LayDanhSachNhaCungCap()
        {
            try
            {
                AppLogger.Debug("Bat dau lay danh sach nha cung cap.");
                DataTable dt = dal.LayDanhSachNhaCungCap();
                AppLogger.Information($"Lay danh sach nha cung cap thanh cong. So luong: {dt.Rows.Count}");
                return dt;
            }
            catch (Exception ex)
            {
                AppLogger.Error(ex, "Loi khi lay danh sach nha cung cap.");
                throw;
            }
        }

        // Lấy danh sách sản phẩm
        public DataTable LayDanhSachSanPham()
        {
            try
            {
                AppLogger.Debug("Bat dau lay danh sach san pham cho nhap hang.");
                DataTable dt = dal.LayDanhSachSanPham();
                AppLogger.Information($"Lay danh sach san pham thanh cong. So luong: {dt.Rows.Count}");
                return dt;
            }
            catch (Exception ex)
            {
                AppLogger.Error(ex, "Loi khi lay danh sach san pham.");
                throw;
            }
        }

        // Thêm phiếu nhập
        public bool ThemPhieuNhap(string maPN, DateTime ngayNhap, string maNCC, int maTaiKhoan, DataTable dtChiTiet)
        {
            try
            {
                AppLogger.Debug($"Bat dau them phieu nhap. Ma PN: {maPN}, NCC: {maNCC}");

                if (dtChiTiet == null || dtChiTiet.Rows.Count == 0)
                {
                    AppLogger.Warning($"Them phieu nhap that bai do chi tiet trong. Ma PN: {maPN}");
                    return false;
                }

                bool ketQua = dal.ThemPhieuNhap(maPN, ngayNhap, maNCC, maTaiKhoan, dtChiTiet);

                if (ketQua)
                {
                    AppLogger.Information($"Them phieu nhap thanh cong. Ma PN: {maPN}");
                }
                else
                {
                    AppLogger.Warning($"Them phieu nhap that bai trong CSDL. Ma PN: {maPN}");
                }

                return ketQua;
            }
            catch (Exception ex)
            {
                AppLogger.Error(ex, $"Loi khi them phieu nhap. Ma PN: {maPN}");
                throw;
            }
        }

        // Lấy danh sách các phiếu nhập đã lưu
        public DataTable LayDanhSachPhieuNhap()
        {
            try
            {
                AppLogger.Debug("Bat dau lay danh sach cac phieu nhap da luu.");
                DataTable dt = dal.LayDanhSachPhieuNhap();
                AppLogger.Information($"Lay danh sach phieu nhap thanh cong. So luong: {dt.Rows.Count}");
                return dt;
            }
            catch (Exception ex)
            {
                AppLogger.Error(ex, "Loi khi lay danh sach phieu nhap.");
                throw;
            }
        }

        // Xóa phiếu nhập
        public bool XoaPhieuNhap(string maPN)
        {
            try
            {
                AppLogger.Debug($"Bat dau xoa phieu nhap. Ma PN: {maPN}");
                bool ketQua = dal.XoaPhieuNhap(maPN);

                if (ketQua)
                {
                    AppLogger.Information($"Xoa phieu nhap thanh cong. Ma PN: {maPN}");
                }
                else
                {
                    AppLogger.Warning($"Xoa phieu nhap that bai, khong tim thay ma: {maPN}");
                }

                return ketQua;
            }
            catch (Exception ex)
            {
                AppLogger.Error(ex, $"Loi khi xoa phieu nhap. Ma PN: {maPN}");
                throw;
            }
        }
    }
}