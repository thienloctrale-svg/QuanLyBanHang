using Serilog;
using System;
using System.IO;

namespace QuanLyBanHang.Logging
{
    public static class AppLogger
    {
        public static void Initialize()
        {
            string logDirectory = Path.Combine(
                AppContext.BaseDirectory, "Logs");

            Directory.CreateDirectory(logDirectory);

            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Information()
                .WriteTo.File(
                    Path.Combine(logDirectory, "log-.txt"),
                    rollingInterval: RollingInterval.Day,
                    retainedFileCountLimit: 30,
                    shared: true,
                    outputTemplate:
                        "{Timestamp:yyyy-MM-dd HH:mm:ss.fff} " +
                        "[{Level:u3}] {Message:lj}{NewLine}{Exception}")
                .CreateLogger();

            Log.Information("He thong bat dau khoi dong.");
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
            Log.CloseAndFlush();
        }
    }
}
