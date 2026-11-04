using Serilog;
using System;
using System.Diagnostics;
using System.IO;

namespace QuanLyBanHang.Logging
{
    public static class AppLogger
    {
        public static string LogDirectory { get; private set; } = string.Empty;

        public static void Initialize()
        {
            // Tự động tìm thư mục Logs tại thư mục gốc của Solution để thuận tiện mở file khi demo/thuyết trình
            string baseDir = AppContext.BaseDirectory;
            string logDirectory = Path.Combine(baseDir, "Logs");

            try
            {
                DirectoryInfo? current = new DirectoryInfo(baseDir);
                while (current != null)
                {
                    if (File.Exists(Path.Combine(current.FullName, "QuanLyBanHang.slnx")) ||
                        File.Exists(Path.Combine(current.FullName, "QuanLyBanHang.sln")))
                    {
                        logDirectory = Path.Combine(current.FullName, "Logs");
                        break;
                    }
                    current = current.Parent;
                }
            }
            catch
            {
                logDirectory = Path.Combine(baseDir, "Logs");
            }

            LogDirectory = logDirectory;
            Directory.CreateDirectory(logDirectory);

            Log.Logger = new LoggerConfiguration()
                // Cho phép ghi từ Debug trở lên
                .MinimumLevel.Debug()
                .WriteTo.File(
                    Path.Combine(logDirectory, "log-.txt"),
                    rollingInterval: RollingInterval.Day,
                    retainedFileCountLimit: 30,
                    shared: true,
                    outputTemplate:
                        "{Timestamp:yyyy-MM-dd HH:mm:ss.fff} " +
                        "[{Level:u3}] {Message:lj}{NewLine}{Exception}")
                .CreateLogger();

            Log.Information("He thong QuanLyBanHang bat dau khoi dong.");
        }

        public static void Debug(string message)
        {
            Log.Debug("{LogMessage}", message);
        }

        public static void Information(string message)
        {
            Log.Information("{LogMessage}", message);
        }

        public static void Warning(string message)
        {
            Log.Warning("{LogMessage}", message);
        }

        public static void Error(string message)
        {
            Log.Error("{LogMessage}", message);
        }

        public static void Error(Exception ex, string message)
        {
            Log.Error(ex, "{LogMessage}", message);
        }

        public static void CloseAndFlush()
        {
            Log.Information("He thong QuanLyBanHang da dong.");
            Log.CloseAndFlush();
        }

        /// <summary>
        /// Mở trực tiếp thư mục Logs trên Windows Explorer (tiện cho việc thuyết trình demo)
        /// </summary>
        public static void MoThuMucLog()
        {
            try
            {
                if (!string.IsNullOrEmpty(LogDirectory) && Directory.Exists(LogDirectory))
                {
                    Process.Start(new ProcessStartInfo
                    {
                        FileName = LogDirectory,
                        UseShellExecute = true
                    });
                }
            }
            catch (Exception ex)
            {
                Error(ex, "Khong the mo thu muc Logs qua Windows Explorer.");
            }
        }

        /// <summary>
        /// Mở ngay file log của ngày hôm nay bằng Notepad để xem tức thì
        /// </summary>
        public static void MoFileLogHomNay()
        {
            try
            {
                string logFile = Path.Combine(LogDirectory, $"log-{DateTime.Now:yyyyMMdd}.txt");
                if (File.Exists(logFile))
                {
                    Process.Start(new ProcessStartInfo
                    {
                        FileName = "notepad.exe",
                        Arguments = $"\"{logFile}\"",
                        UseShellExecute = true
                    });
                }
                else
                {
                    MoThuMucLog();
                }
            }
            catch (Exception ex)
            {
                Error(ex, "Khong the mo file log hom nay.");
            }
        }
    }
}
