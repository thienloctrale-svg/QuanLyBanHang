using System;
using System.Windows.Forms;
using QuanLyBanHang.Logging;

namespace QuanLyBanHang.UI
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // Khởi tạo hệ thống ghi log
            AppLogger.Initialize();

            try
            {
                // Cấu hình ứng dụng WinForms
                ApplicationConfiguration.Initialize();

                // Ghi log khi ứng dụng khởi động
                AppLogger.Information(
                    "Ứng dụng QuanLyBanHang đã khởi động.");

                // Mở màn hình chính
                Application.Run(new FrmTaiKhoan());
            }
            catch (Exception ex)
            {
                // Ghi log nếu ứng dụng gặp lỗi nghiêm trọng
                AppLogger.Error(
                    ex, "Ứng dụng gặp lỗi nghiêm trọng.");

                throw;
            }
            finally
            {
                // Ghi log khi ứng dụng kết thúc
                AppLogger.Information(
                    "Ứng dụng QuanLyBanHang đã đóng.");

                // Đóng hệ thống ghi log
                AppLogger.CloseAndFlush();
            }
        }
    }
}