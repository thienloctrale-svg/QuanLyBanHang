using System;
using System.Data;
using QuanLyBanHang.DAL;
using QuanLyBanHang.DTO;
using QuanLyBanHang.Logging;

namespace QuanLyBanHang.BLL
{
    public class KhachHangBLL
    {
        private readonly KhachHangDAL _khachHangDAL = new KhachHangDAL();

        public DataTable LayDanhSachKhachHang(string tuKhoa = "", string loaiKhachHang = "")
        {
            try
            {
                DataTable dt = _khachHangDAL.LayDanhSachKhachHang(tuKhoa, loaiKhachHang);
                AppLogger.Information($"Lay danh sach khach hang: tuKhoa='{tuKhoa}', loai='{loaiKhachHang}' => tim thay {dt.Rows.Count} ban ghi.");
                return dt;
            }
            catch (Exception ex)
            {
                AppLogger.Error(ex, "Loi khi lay danh sach khach hang trong KhachHangBLL.");
                throw;
            }
        }

        public string TaoMaKhachHangTuDong()
        {
            try
            {
                string maMoi = _khachHangDAL.TaoMaKhachHangTuDong();
                AppLogger.Information($"Tao ma khach hang tu dong: {maMoi}");
                return maMoi;
            }
            catch (Exception ex)
            {
                AppLogger.Error(ex, "Loi khi tao ma khach hang tu dong trong KhachHangBLL.");
                throw;
            }
        }

        public bool ThemKhachHang(KhachHangDTO kh, out string thongBao)
        {
            if (string.IsNullOrWhiteSpace(kh.MaKhachHang))
            {
                thongBao = "Mã khách hàng không được để trống.";
                AppLogger.Warning($"Them khach hang that bai: {thongBao}");
                return false;
            }

            if (string.IsNullOrWhiteSpace(kh.TenKhachHang))
            {
                thongBao = "Tên khách hàng không được để trống.";
                AppLogger.Warning($"Them khach hang that bai (Ma: {kh.MaKhachHang}): {thongBao}");
                return false;
            }

            if (_khachHangDAL.KiemTraTonTai(kh.MaKhachHang))
            {
                thongBao = $"Mã khách hàng '{kh.MaKhachHang}' đã tồn tại trong hệ thống.";
                AppLogger.Warning($"Them khach hang that bai: {thongBao}");
                return false;
            }

            try
            {
                bool ketQua = _khachHangDAL.ThemKhachHang(kh);
                if (ketQua)
                {
                    thongBao = "Thêm mới khách hàng thành công!";
                    AppLogger.Information($"Them moi khach hang thanh cong: Ma={kh.MaKhachHang}, Ten={kh.TenKhachHang}");
                }
                else
                {
                    thongBao = "Thêm mới khách hàng thất bại.";
                    AppLogger.Warning($"Them moi khach hang khong thanh cong: Ma={kh.MaKhachHang}");
                }
                return ketQua;
            }
            catch (Exception ex)
            {
                thongBao = "Lỗi khi thêm khách hàng: " + ex.Message;
                AppLogger.Error(ex, $"Ngoai le khi them khach hang: Ma={kh.MaKhachHang}");
                return false;
            }
        }

        public bool CapNhatKhachHang(KhachHangDTO kh, out string thongBao)
        {
            if (string.IsNullOrWhiteSpace(kh.MaKhachHang))
            {
                thongBao = "Mã khách hàng không được để trống.";
                AppLogger.Warning($"Cap nhat khach hang that bai: {thongBao}");
                return false;
            }

            if (string.IsNullOrWhiteSpace(kh.TenKhachHang))
            {
                thongBao = "Tên khách hàng không được để trống.";
                AppLogger.Warning($"Cap nhat khach hang that bai (Ma: {kh.MaKhachHang}): {thongBao}");
                return false;
            }

            if (!_khachHangDAL.KiemTraTonTai(kh.MaKhachHang))
            {
                thongBao = $"Không tìm thấy khách hàng mã '{kh.MaKhachHang}' để cập nhật.";
                AppLogger.Warning($"Cap nhat khach hang that bai: {thongBao}");
                return false;
            }

            try
            {
                bool ketQua = _khachHangDAL.CapNhatKhachHang(kh);
                if (ketQua)
                {
                    thongBao = "Cập nhật thông tin khách hàng thành công!";
                    AppLogger.Information($"Cap nhat khach hang thanh cong: Ma={kh.MaKhachHang}, Ten={kh.TenKhachHang}");
                }
                else
                {
                    thongBao = "Cập nhật thông tin khách hàng thất bại.";
                    AppLogger.Warning($"Cap nhat khach hang khong thanh cong: Ma={kh.MaKhachHang}");
                }
                return ketQua;
            }
            catch (Exception ex)
            {
                thongBao = "Lỗi khi cập nhật khách hàng: " + ex.Message;
                AppLogger.Error(ex, $"Ngoai le khi cap nhat khach hang: Ma={kh.MaKhachHang}");
                return false;
            }
        }

        public bool XoaKhachHang(string maKhachHang, out string thongBao)
        {
            if (string.IsNullOrWhiteSpace(maKhachHang))
            {
                thongBao = "Vui lòng chọn khách hàng cần xóa.";
                AppLogger.Warning($"Xoa khach hang that bai: {thongBao}");
                return false;
            }

            if (!_khachHangDAL.KiemTraTonTai(maKhachHang))
            {
                thongBao = $"Không tìm thấy khách hàng mã '{maKhachHang}' để xóa.";
                AppLogger.Warning($"Xoa khach hang that bai: {thongBao}");
                return false;
            }

            try
            {
                bool ketQua = _khachHangDAL.XoaKhachHang(maKhachHang, out string loiRao);
                if (!ketQua)
                {
                    thongBao = !string.IsNullOrWhiteSpace(loiRao) ? loiRao : "Xóa khách hàng thất bại.";
                    AppLogger.Warning($"Xoa khach hang {maKhachHang} khong thanh cong: {thongBao}");
                    return false;
                }

                thongBao = "Xóa khách hàng thành công!";
                AppLogger.Information($"Xoa khach hang thanh cong: Ma={maKhachHang}");
                return true;
            }
            catch (Exception ex)
            {
                thongBao = "Lỗi khi xóa khách hàng: " + ex.Message;
                AppLogger.Error(ex, $"Ngoai le khi xoa khach hang: Ma={maKhachHang}");
                return false;
            }
        }
    }
}
