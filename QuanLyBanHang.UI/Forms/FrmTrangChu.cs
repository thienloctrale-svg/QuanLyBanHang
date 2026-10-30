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
            // Kiểm tra trực tiếp qua biến static của FrmDangNhap
            if (FrmDangNhap.TaiKhoanDangNhap == null)
            {
                MessageBox.Show("Vui lòng đăng nhập lại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                FrmDangNhap login = new FrmDangNhap();
                login.Show();
                this.Hide();
                return;
            }

            // Nếu đã đăng nhập thì mở bán hàng bình thường
            FrmBanHang banHang = new FrmBanHang();
            banHang.Show();
            this.Hide();
        }
    }
}
