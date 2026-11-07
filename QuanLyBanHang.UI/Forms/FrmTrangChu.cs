using System;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;
using QuanLyBanHang.BLL;
using QuanLyBanHang.DTO;
using QuanLyBanHang.Logging;
using QuanLyBanHang.UI.Helpers;

namespace QuanLyBanHang.UI
{
    public partial class FrmTrangChu : Form
    {
        private readonly TrangChuBLL _bll = new TrangChuBLL();
        private bool _isDangXuat = false;
        private static readonly CultureInfo s_viCulture = new CultureInfo("vi-VN");

        public TaiKhoanDTO? TaiKhoanDangNhap { get; private set; }

        public FrmTrangChu()
        {
            InitializeComponent();
            this.KeyPreview = true;
            this.KeyDown += FrmTrangChu_KeyDown;
        }

        public FrmTrangChu(TaiKhoanDTO taiKhoan) : this()
        {
            TaiKhoanDangNhap = taiKhoan;
        }

        // =========================================================================================
        // [BREAKPOINT 1]: Khởi tạo Form Trang Chủ & Kiểm tra quyền người dùng
        // Mục đích: Xem thông tin tài khoản đăng nhập (Session/DTO), phân quyền và chuẩn bị giao diện
        // =========================================================================================
        private void FrmTrangChu_Load(object sender, EventArgs e)
        {
            try
            {
                // Khởi động đồng hồ thời gian thực tiếng Việt
                tmrDongHo.Start();
                CapNhatDongHo();

                // [BREAKPOINT 1.1]: Kiểm tra và gắn tài khoản đăng nhập từ SessionManager
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
                // [BREAKPOINT 1.2]: Bắt ngoại lệ khởi động form, ghi log Serilog và thông báo thân thiện
                AppLogger.Error(ex, "UI: Loi khi khoi dong FrmTrangChu.");
                ThongBao.LoiHeThong(ex, "Không thể khởi động hoàn tất trang chủ. Vui lòng kiểm tra lại dịch vụ hệ thống.", "TrangChu");
            }
        }

        private void tmrDongHo_Tick(object sender, EventArgs e)
        {
            CapNhatDongHo();
        }

        // =========================================================================================
        // [BREAKPOINT 2]: Cập nhật đồng hồ thời gian thực chuẩn Tiếng Việt
        // Mục đích: Kiểm tra định dạng CultureInfo("vi-VN"), hiển thị Thứ và Ngày Giờ tiếng Việt
        // =========================================================================================
        private void CapNhatDongHo()
        {
            DateTime now = DateTime.Now;
            string thu = s_viCulture.DateTimeFormat.GetDayName(now.DayOfWeek);
            if (!string.IsNullOrEmpty(thu))
            {
                thu = char.ToUpper(thu[0]) + thu.Substring(1);
            }
            lblDongHo.Text = $"🕒 {thu}, ngày {now:dd/MM/yyyy HH:mm:ss}";
        }

        // =========================================================================================
        // [BREAKPOINT 3]: Nạp số liệu thống kê Dashboard từ tầng BLL -> DAL -> SQL
        // Mục đích: Luồng lấy số liệu Doanh thu hôm nay, Hóa đơn, Sản phẩm, Khách hàng
        // =========================================================================================
        public void NapDuLieuThongKe()
        {
            try
            {
                // [BREAKPOINT 3.1]: Gọi BLL để tính toán số liệu tổng quan
                TrangChuThongKeDTO thongKe = _bll.LayThongKeTongQuan();

                // [BREAKPOINT 3.2]: Format tiền tệ VND và số lượng theo đơn vị
                lblCardDoanhThuVal.Text = _bll.DinhDangTienTe(thongKe.DoanhThuHomNay);
                lblCardHoaDonVal.Text = _bll.DinhDangSoLuong(thongKe.SoHoaDonHomNay, "đơn");
                lblCardSanPhamVal.Text = _bll.DinhDangSoLuong(thongKe.TongSoSanPham, "SP");
                lblCardKhachHangVal.Text = _bll.DinhDangSoLuong(thongKe.TongSoKhachHang, "khách");
                lblStatusHeThong.Text = "🟢 Hệ thống sẵn sàng hoạt động (v1.0)";

                AppLogger.Information("UI: Cap nhat du lieu thong ke len Dashboard Trang chu thanh cong.");
            }
            catch (Exception ex)
            {
                // [BREAKPOINT 3.3]: Xử lý lỗi mất kết nối CSDL, hiển thị fallback an toàn
                AppLogger.Error(ex, "UI: Khong the tai du lieu thong ke tong quan cho FrmTrangChu.");
                lblCardDoanhThuVal.Text = "0 đ";
                lblCardHoaDonVal.Text = "0 đơn";
                lblCardSanPhamVal.Text = "0 SP";
                lblCardKhachHangVal.Text = "0 khách";
                lblStatusHeThong.Text = "⚠️ Chưa thể kết nối CSDL để lấy dữ liệu thống kê.";
            }
        }

        // =========================================================================================
        // [BREAKPOINT 4]: Điều hướng mở Form chức năng con
        // Mục đích: Cơ chế ẩn Trang chủ, lắng nghe sự kiện FormClosed để tự động refresh Dashboard
        // =========================================================================================
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
                ThongBao.LoiHeThong(ex, "Không thể mở phân hệ chức năng này vào lúc này. Vui lòng thử lại sau.", "TrangChu");
                this.Show();
            }
        }

        // =========================================================================================
        // [BREAKPOINT 5]: Xử lý bộ phím tắt thường dùng trên Trang Chủ
        // Mục đích: Bắt phím tắt F1-F8, Esc điều hướng nhanh các phân hệ chức năng
        // =========================================================================================
        private void FrmTrangChu_KeyDown(object? sender, KeyEventArgs e)
        {
            // F1: Trợ giúp phím tắt
            if (e.KeyCode == Keys.F1)
            {
                HienThiHuongDanPhimTat();
                e.Handled = true;
            }
            // F2 hoặc Ctrl + B: Bán hàng
            else if (e.KeyCode == Keys.F2 || (e.Control && e.KeyCode == Keys.B))
            {
                btnMenuBanHang_Click(sender!, EventArgs.Empty);
                e.Handled = true;
            }
            // F3 hoặc Ctrl + S: Sản phẩm
            else if (e.KeyCode == Keys.F3 || (e.Control && e.KeyCode == Keys.S))
            {
                btnMenuSanPham_Click(sender!, EventArgs.Empty);
                e.Handled = true;
            }
            // F4 hoặc Ctrl + K: Khách hàng
            else if (e.KeyCode == Keys.F4 || (e.Control && e.KeyCode == Keys.K))
            {
                btnMenuKhachHang_Click(sender!, EventArgs.Empty);
                e.Handled = true;
            }
            // F5: Làm mới bảng điều khiển
            else if (e.KeyCode == Keys.F5)
            {
                btnMenuTrangChu_Click(sender!, EventArgs.Empty);
                e.Handled = true;
            }
            // F6 hoặc Ctrl + N: Nhập hàng
            else if (e.KeyCode == Keys.F6 || (e.Control && e.KeyCode == Keys.N))
            {
                btnMenuNhapHang_Click(sender!, EventArgs.Empty);
                e.Handled = true;
            }
            // F7 hoặc Ctrl + T: Tài khoản
            else if (e.KeyCode == Keys.F7 || (e.Control && e.KeyCode == Keys.T))
            {
                btnMenuTaiKhoan_Click(sender!, EventArgs.Empty);
                e.Handled = true;
            }
            // F8 hoặc Ctrl + E: Thống kê
            else if (e.KeyCode == Keys.F8 || (e.Control && e.KeyCode == Keys.E))
            {
                btnMenuThongKe_Click(sender!, EventArgs.Empty);
                e.Handled = true;
            }
            // Esc: Thoát ứng dụng
            else if (e.KeyCode == Keys.Escape)
            {
                btnThoat_Click(sender!, EventArgs.Empty);
                e.Handled = true;
            }
        }

        private void HienThiHuongDanPhimTat()
        {
            string huongDan =
                "DANH SÁCH PHÍM TẮT TRANG CHỦ:\n\n" +
                "• [F1]: Hiển thị hướng dẫn phím tắt này\n" +
                "• [F2] hoặc [Ctrl + B]: Mở phân hệ Bán hàng (POS)\n" +
                "• [F3] hoặc [Ctrl + S]: Mở Quản lý Sản phẩm\n" +
                "• [F4] hoặc [Ctrl + K]: Mở Quản lý Khách hàng\n" +
                "• [F5]: Làm mới dữ liệu thống kê Dashboard\n" +
                "• [F6] hoặc [Ctrl + N]: Mở Quản lý Nhập hàng\n" +
                "• [F7] hoặc [Ctrl + T]: Mở Quản lý Tài khoản\n" +
                "• [F8] hoặc [Ctrl + E]: Mở Báo cáo & Thống kê\n" +
                "• [Esc]: Xác nhận thoát ứng dụng";

            ThongBao.ThongTin(huongDan, "Trợ giúp phím tắt - Trang Chủ");
        }

        // ================== SỰ KIỆN ĐIỀU HƯỚNG CÁC PHÂN HỆ ==================

        private void btnMenuTrangChu_Click(object sender, EventArgs e)
        {
            NapDuLieuThongKe();
            ThongBao.ThongTin("Đã làm mới dữ liệu bảng điều khiển!", "Thông báo");
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
            bool xacNhan = ThongBao.XacNhan(
                "Bạn có chắc chắn muốn đăng xuất khỏi hệ thống?",
                "Xác nhận đăng xuất");

            if (xacNhan)
            {
                _isDangXuat = true;
                AppLogger.Information($"UI: Nguoi dung {TaiKhoanDangNhap?.TenDangNhap ?? "Guest"} da dang xuat.");

                FrmDangNhap.TaiKhoanDangNhap = null!;
                SessionManager.DangXuat();

                FrmDangNhap login = new FrmDangNhap();
                login.Show();
                this.Close();
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            bool xacNhan = ThongBao.XacNhan(
                "Bạn có chắc chắn muốn thoát ứng dụng?",
                "Xác nhận thoát");

            if (xacNhan)
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
