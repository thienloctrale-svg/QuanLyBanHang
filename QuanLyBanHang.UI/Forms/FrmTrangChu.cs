using System;
using System.Drawing;
using System.Windows.Forms;
using QuanLyBanHang.BLL;
using QuanLyBanHang.DTO;
using QuanLyBanHang.Logging;

namespace QuanLyBanHang.UI
{
    public partial class FrmTrangChu : Form
    {
        private readonly TrangChuBLL _bll = new TrangChuBLL();
        private bool _isDangXuat = false;

        public TaiKhoanDTO? TaiKhoanDangNhap { get; private set; }

        public FrmTrangChu()
        {
            InitializeComponent();
        }

        public FrmTrangChu(TaiKhoanDTO taiKhoan) : this()
        {
            TaiKhoanDangNhap = taiKhoan;
        }

        private void FrmTrangChu_Load(object sender, EventArgs e)
        {
            try
            {
                // Khởi động đồng hồ thời gian thực
                tmrDongHo.Start();
                CapNhatDongHo();

                // Xác định thông tin tài khoản đăng nhập
                if (TaiKhoanDangNhap == null)
                {
                    if (FrmDangNhap.TaiKhoanDangNhap is TaiKhoanDTO tkDangNhap)
                    {
                        TaiKhoanDangNhap = tkDangNhap;
                    }
                    else if (SessionManager.TaiKhoanHienTai != null)
                    {
                        TaiKhoanDangNhap = SessionManager.TaiKhoanHienTai;
                    }
                }

                // Hiển thị lời chào người dùng
                if (TaiKhoanDangNhap != null && !string.IsNullOrWhiteSpace(TaiKhoanDangNhap.HoTen))
                {
                    lblXinChao.Text = $"👤 Xin chào: {TaiKhoanDangNhap.HoTen}";
                    lblStatusThoiGian.Text = $"Tài khoản: {TaiKhoanDangNhap.TenDangNhap}";
                }
                else
                {
                    lblXinChao.Text = "👤 Xin chào: Quản trị viên";
                }

                // Tải dữ liệu thống kê tổng quan
                NapDuLieuThongKe();

                AppLogger.Information($"UI: Khoi dong FrmTrangChu thanh cong. Nguoi dung: {TaiKhoanDangNhap?.TenDangNhap ?? "Guest"}");
            }
            catch (Exception ex)
            {
                AppLogger.Error(ex, "UI: Loi khi khoi dong FrmTrangChu.");
            }
        }

        private void tmrDongHo_Tick(object sender, EventArgs e)
        {
            CapNhatDongHo();
        }

        private void CapNhatDongHo()
        {
            lblDongHo.Text = $"🕒 {DateTime.Now:dddd, dd/MM/yyyy HH:mm:ss}";
        }

        public void NapDuLieuThongKe()
        {
            try
            {
                TrangChuThongKeDTO thongKe = _bll.LayThongKeTongQuan();

                lblCardDoanhThuVal.Text = _bll.DinhDangTienTe(thongKe.DoanhThuHomNay);
                lblCardHoaDonVal.Text = _bll.DinhDangSoLuong(thongKe.SoHoaDonHomNay, "đơn");
                lblCardSanPhamVal.Text = _bll.DinhDangSoLuong(thongKe.TongSoSanPham, "SP");
                lblCardKhachHangVal.Text = _bll.DinhDangSoLuong(thongKe.TongSoKhachHang, "khách");

                AppLogger.Information("UI: Cap nhat du lieu thong ke len Dashboard Trang chu thanh cong.");
            }
            catch (Exception ex)
            {
                AppLogger.Error(ex, "UI: Khong the tai du lieu thong ke tong quan cho FrmTrangChu.");
                lblCardDoanhThuVal.Text = "0 đ";
                lblCardHoaDonVal.Text = "0 đơn";
                lblCardSanPhamVal.Text = "0 SP";
                lblCardKhachHangVal.Text = "0 khách";
            }
        }

        private void MoForm(Form formCon)
        {
            try
            {
                this.Hide();
                formCon.FormClosed += (s, args) =>
                {
                    // Khi form con đóng lại, hiển thị lại Trang Chủ và tự động nạp lại số liệu thống kê mới nhất
                    this.Show();
                    NapDuLieuThongKe();
                };
                formCon.Show();
            }
            catch (Exception ex)
            {
                AppLogger.Error(ex, $"UI: Loi khi mo form {formCon.GetType().Name}.");
                MessageBox.Show($"Không thể mở màn hình: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Show();
            }
        }

        // ================== SỰ KIỆN ĐIỀU HƯỚNG CÁC PHÂN HỆ ==================

        private void btnMenuTrangChu_Click(object sender, EventArgs e)
        {
            NapDuLieuThongKe();
            MessageBox.Show("Đã làm mới dữ liệu bảng điều khiển!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnMenuBanHang_Click(object sender, EventArgs e)
        {
            AppLogger.Information("UI: Chuyen den man hinh Ban Hang (POS).");
            if (TaiKhoanDangNhap != null)
            {
                MoForm(new FrmBanHang(TaiKhoanDangNhap));
            }
            else
            {
                MoForm(new FrmBanHang());
            }
        }

        private void btnMenuSanPham_Click(object sender, EventArgs e)
        {
            AppLogger.Information("UI: Chuyen den man hinh Quan Ly San Pham.");
            MoForm(new FrmSanPham());
        }

        private void btnMenuKhachHang_Click(object sender, EventArgs e)
        {
            AppLogger.Information("UI: Chuyen den man hinh Quan Ly Khach Hang.");
            MoForm(new FrmKhachHang());
        }

        private void btnMenuNhapHang_Click(object sender, EventArgs e)
        {
            AppLogger.Information("UI: Chuyen den man hinh Quan Ly Nhap Hang.");
            MoForm(new FrmNhapHang());
        }

        private void btnMenuTaiKhoan_Click(object sender, EventArgs e)
        {
            AppLogger.Information("UI: Chuyen den man hinh Quan Ly Tai Khoan.");
            MoForm(new FrmTaiKhoan());
        }

        private void btnMenuThongKe_Click(object sender, EventArgs e)
        {
            AppLogger.Information("UI: Chuyen den man hinh Bao Cao Thong Ke.");
            MoForm(new FrmThongKe());
        }

        // ================== ĐĂNG XUẤT & THOÁT ==================

        private void btnDangXuat_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show(
                "Bạn có chắc chắn muốn đăng xuất khỏi hệ thống?",
                "Xác nhận đăng xuất",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (dr == DialogResult.Yes)
            {
                _isDangXuat = true;
                AppLogger.Information($"UI: Nguoi dung {TaiKhoanDangNhap?.TenDangNhap ?? "Guest"} da dang xuat.");

                FrmDangNhap.TaiKhoanDangNhap = null;
                SessionManager.DangXuat();

                FrmDangNhap login = new FrmDangNhap();
                login.Show();
                this.Close();
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show(
                "Bạn có chắc chắn muốn thoát ứng dụng?",
                "Xác nhận thoát",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (dr == DialogResult.Yes)
            {
                AppLogger.Information("UI: Nguoi dung thoat ung dung tu FrmTrangChu.");
                Application.Exit();
            }
        }

        private void FrmTrangChu_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Nếu người dùng ấn nút X trên cửa sổ (không phải đăng xuất), thoát toàn bộ ứng dụng
            if (!_isDangXuat)
            {
                AppLogger.Information("UI: Dong ung dung qua FrmTrangChu_FormClosing.");
                Application.Exit();
            }
        }
    }
}
