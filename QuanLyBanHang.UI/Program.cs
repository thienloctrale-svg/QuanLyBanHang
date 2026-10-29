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
            // Khoi tao he thong ghi log
            AppLogger.Initialize();

            try
            {
                // Cau hinh ung dung WinForms
                ApplicationConfiguration.Initialize();

                // Ghi log khi ung dung khoi dong
                AppLogger.Information(
                    "Ung dung QuanLyBanHang da khoi dong.");

                // Mo man hinh Quan ly khach hang de kiem tra giao dien va chuc nang
                Application.Run(new FrmKhachHang());
            }
            catch (Exception ex)
            {
                // Ghi log neu ung dung gap loi nghiem trong
                AppLogger.Error(
                    ex, "Ung dung gap loi nghiem trong.");

                throw;
            }
            finally
            {
                // Ghi log khi ung dung ket thuc
                AppLogger.Information(
                    "Ung dung QuanLyBanHang da dong.");

                // Dong he thong ghi log va ghi het du lieu con lai
                AppLogger.CloseAndFlush();
            }
        }
    }
}
