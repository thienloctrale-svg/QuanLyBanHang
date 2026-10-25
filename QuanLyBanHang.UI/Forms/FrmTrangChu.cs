using QuanLyBanHang.BLL;
using QuanLyBanHang.Logging;
using System;
using System.Windows.Forms;

namespace QuanLyBanHang.UI
{
    public partial class FrmTrangChu : Form
    {
        public FrmTrangChu()
        {
            InitializeComponent();
        }

        private void btnKiemTraSQL_Click(object sender, EventArgs e)
        {
            bool ketNoiThanhCong =
                ConnectionService.TestConnection(out string message);

            if (ketNoiThanhCong)
            {
                AppLogger.Information(
                    "Kiem tra ket noi SQL Server thanh cong.");
            }
            else
            {
                AppLogger.Error(
                    "Kiem tra ket noi SQL Server that bai: " + message);
            }

            MessageBox.Show(
                message,
                "Kiểm tra SQL Server",
                MessageBoxButtons.OK,
                ketNoiThanhCong
                    ? MessageBoxIcon.Information
                    : MessageBoxIcon.Error);
        }
    }
}
