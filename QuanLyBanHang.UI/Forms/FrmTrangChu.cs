using QuanLyBanHang.BLL;
using QuanLyBanHang.Logging;
using System;
using System.Windows.Forms;
using QuanLyBanHang.DTO;

namespace QuanLyBanHang.UI
{
    public partial class FrmTrangChu : Form
    {
        public FrmTrangChu()
        {
            InitializeComponent();

        }

        public TaiKhoanDTO TaiKhoanDangNhap { get; private set; }

        public FrmTrangChu(TaiKhoanDTO taiKhoan)
        {
            InitializeComponent();
            TaiKhoanDangNhap = taiKhoan;
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

        private void btnBanHang_Click(object sender, EventArgs e)
        {
            if (TaiKhoanDangNhap == null)
            {
                MessageBox.Show("Không tìm thấy thông tin tài khoản đăng nhập!");
                return;
            }

            FrmBanHang formBanHang = new FrmBanHang(TaiKhoanDangNhap);
            formBanHang.ShowDialog();
        }
    }
}
