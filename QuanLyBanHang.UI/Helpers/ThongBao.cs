using System;
using System.Windows.Forms;
using QuanLyBanHang.Logging;

namespace QuanLyBanHang.UI.Helpers
{
    public static class ThongBao
    {
        // 1. Thông báo thông tin - màu xanh dương
        public static void ThongTin(string noiDung, string tieuDe = "Thông tin")
        {
            MessageBox.Show(
                noiDung,
                tieuDe,
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        // 2. Cảnh báo nhập liệu - màu vàng
        public static void CanhBao(string noiDung, string tieuDe = "Cảnh báo")
        {
            AppLogger.Warning("Canh bao nguoi dung: " + noiDung);

            MessageBox.Show(
                noiDung,
                tieuDe,
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);
        }

        // 3. Thông báo thành công - màu xanh lá
        public static void ThanhCong(string noiDung, string tieuDe = "Thành công")
        {
            MessageBox.Show(
                noiDung,
                tieuDe,
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        // 4. Thông báo lỗi hệ thống - màu đỏ
        // Người dùng chỉ thấy nội dung thân thiện.
        // Chi tiết lỗi được lưu vào log.
        public static void LoiHeThong(
            Exception ex,
            string noiDung = "Đã xảy ra lỗi trong quá trình xử lý. Vui lòng thử lại sau.",
            string nguCanh = "Ung dung")
        {
            AppLogger.Error(
                ex,
                nguCanh + ": Loi he thong.");

            MessageBox.Show(
                noiDung,
                "Lỗi hệ thống",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
        }

        // 5. Hộp thoại xác nhận - màu xanh dương
        public static bool XacNhan(
            string noiDung,
            string tieuDe = "Xác nhận")
        {
            DialogResult ketQua = MessageBox.Show(
                noiDung,
                tieuDe,
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            return ketQua == DialogResult.Yes;
        }
    }
}
