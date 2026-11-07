using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using QuanLyBanHang.BLL;
using QuanLyBanHang.DTO;
using QuanLyBanHang.Logging;
using QuanLyBanHang.UI.Helpers;

namespace QuanLyBanHang.UI
{
    public partial class FrmBanHang : Form
    {
        private readonly SanPhamBLL sanPhamBLL = new SanPhamBLL();
        private readonly KhachHangBLL khachHangBLL = new KhachHangBLL();
        private readonly HoaDonBLL hoaDonBLL = new HoaDonBLL();
        private readonly GioHangBLL gioHangBLL = new GioHangBLL();

        private List<SanPhamDTO> danhSachSanPham = new List<SanPhamDTO>();
        private List<KhachHangDTO> danhSachKhachHang = new List<KhachHangDTO>();
        private readonly List<ChiTietHoaDonDTO> danhSachGioHang = new List<ChiTietHoaDonDTO>();

        private TaiKhoanDTO taiKhoanDangNhap;
        private bool dangCapNhatCombo = false;

        public FrmBanHang()
        {
            InitializeComponent();
            KhoiTaoSuKien();
            AppLogger.Information("Khoi tao FrmBanHang (che do mac dinh).");
        }

        public FrmBanHang(TaiKhoanDTO taiKhoan)
        {
            InitializeComponent();
            KhoiTaoSuKien();

            taiKhoanDangNhap = taiKhoan;
            lblHoTen.Text = taiKhoanDangNhap.HoTen;
            AppLogger.Information($"Khoi tao FrmBanHang cho nhan vien: '{taiKhoanDangNhap.HoTen}' (MaTK: {taiKhoanDangNhap.MaTaiKhoan}).");
        }

        private void KhoiTaoSuKien()
        {
            Load += FrmBanHang_Load;

            btnTimSanPham.Click += btnTimSanPham_Click;
            btnThemSanPham.Click += btnThemSanPham_Click;
            btnXoaSanPham.Click += btnXoaSanPham_Click;
            btnCapNhatSoLuong.Click += btnCapNhatSoLuong_Click;
            btnLamMoi.Click += btnLamMoi_Click;
            btnDong.Click += btnDong_Click;
            btnHuyHoaDon.Click += btnHuyHoaDon_Click;
            btnLuuHoaDon.Click += btnLuuHoaDon_Click;
            btnHome.Click += btnHome_Click;
        }

        private void FrmBanHang_Load(object sender, EventArgs e)
        {
            try
            {
                txtMaHoaDon.ReadOnly = true;
                txtMaHoaDon.TabStop = false;

                dtpNgayLap.Value = DateTime.Now;
                dtpNgayLap.Enabled = false;

                txtMaHoaDon.Text = hoaDonBLL.TaoMaHoaDonMoi();

                numSoLuong.Minimum = 1;
                numSoLuong.Maximum = 100000;
                numSoLuong.Value = 1;
                numSoLuong.KeyPress += numSoLuong_KeyPress;

                // Cấu hình bảng sản phẩm
                dgvSanPham.ReadOnly = true;
                dgvSanPham.AllowUserToAddRows = false;
                dgvSanPham.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dgvSanPham.MultiSelect = false;
                dgvSanPham.AutoGenerateColumns = false;

                // Cấu hình bảng giỏ hàng
                dgvGioHang.ReadOnly = true;
                dgvGioHang.AllowUserToAddRows = false;
                dgvGioHang.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dgvGioHang.MultiSelect = false;
                dgvGioHang.AutoGenerateColumns = false;

                // Tải dữ liệu ban đầu
                danhSachSanPham = sanPhamBLL.LayDanhSachSanPham();
                HienThiDanhSachSanPham(danhSachSanPham);

                // Cấu hình combobox khách hàng
                cboKhachHang.DropDownStyle = ComboBoxStyle.DropDown;
                cboKhachHang.AutoCompleteMode = AutoCompleteMode.None;
                cboKhachHang.TextUpdate += cboKhachHang_TextUpdate;

                LoadKhachHang();
                HienThiGioHang();

                AppLogger.Information($"Form ban hang: mo form thanh cong voi MaHoaDon: '{txtMaHoaDon.Text}'.");
            }
            catch (Exception ex)
            {
                AppLogger.Error(ex, "Form ban hang: khong the tai du lieu.");
                ThongBao.LoiHeThong(ex, "Không thể tải danh sách sản phẩm. Vui lòng kiểm tra lại kết nối cơ sở dữ liệu!", "FrmBanHang - Load");
            }
        }

        private void numSoLuong_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsControl(e.KeyChar))
                return;

            if (e.KeyChar == '-')
            {
                e.Handled = true;
                ThongBao.CanhBao("Không được nhập số âm.");
                return;
            }

            if (!char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void HienThiDanhSachSanPham(List<SanPhamDTO> danhSach)
        {
            dgvSanPham.Rows.Clear();
            foreach (SanPhamDTO sp in danhSach)
            {
                dgvSanPham.Rows.Add(
                    sp.MaSanPham,
                    sp.TenSanPham,
                    sp.DonViTinh,
                    sp.GiaBan,
                    sp.SoLuongTon);
            }
        }

        // Cập nhật hiển thị DataGridView giỏ hàng từ List<ChiTietHoaDonDTO>
        private void HienThiGioHang()
        {
            dgvGioHang.Rows.Clear();

            for (int i = 0; i < danhSachGioHang.Count; i++)
            {
                var ct = danhSachGioHang[i];
                var sp = danhSachSanPham.FirstOrDefault(x => x.MaSanPham == ct.MaSanPham);

                dgvGioHang.Rows.Add(
                    i + 1,
                    ct.MaSanPham,
                    sp?.TenSanPham ?? string.Empty,
                    sp?.DonViTinh ?? string.Empty,
                    ct.SoLuong,
                    ct.DonGia,
                    ct.ThanhTien
                );
            }

            decimal tongTien = gioHangBLL.TinhTongTien(danhSachGioHang);
            lblTongTien.Text = tongTien.ToString("N0") + " VNĐ";
        }

        private void btnTimSanPham_Click(object sender, EventArgs e)
        {
            string tuKhoa = txtTimSanPham.Text.Trim();
            List<SanPhamDTO> ketQua = sanPhamBLL.TimKiemSanPham(danhSachSanPham, tuKhoa);
            AppLogger.Debug($"Tim kiem san pham voi tu khoa: '{tuKhoa}' - Ket qua: {ketQua.Count} san pham.");
            HienThiDanhSachSanPham(ketQua);
        }

        private void btnThemSanPham_Click(object sender, EventArgs e)
        {
            if (dgvSanPham.CurrentRow == null)
            {
                AppLogger.Warning("Them san pham that bai: Chua chon san pham tren danh sach.");
                ThongBao.CanhBao("Vui lòng chọn sản phẩm cần thêm vào giỏ hàng.");
                return;
            }

            string maSP = Convert.ToString(dgvSanPham.CurrentRow.Cells["colSP_Ma"].Value) ?? string.Empty;
            SanPhamDTO? sp = danhSachSanPham.FirstOrDefault(x => x.MaSanPham == maSP);

            if (sp == null)
            {
                AppLogger.Warning($"Them san pham that bai: Khong tim thay thong tin san pham ma '{maSP}'.");
                ThongBao.CanhBao("Không tìm thấy thông tin sản phẩm đã chọn.");
                return;
            }

            int soLuongThem = (int)numSoLuong.Value;

            try
            {
                gioHangBLL.ThemSanPham(danhSachGioHang, sp, soLuongThem);
                HienThiGioHang();
                numSoLuong.Value = 1;
                AppLogger.Information($"Form ban hang: them san pham vao gio - MaSP: '{sp.MaSanPham}', TenSP: '{sp.TenSanPham}', SoLuong: {soLuongThem}.");
            }
            catch (Exception ex)
            {
                AppLogger.Warning($"Them san pham that bai: {ex.Message}");
                ThongBao.CanhBao(ex.Message);
            }
        }

        private void btnXoaSanPham_Click(object sender, EventArgs e)
        {
            if (dgvGioHang.CurrentRow == null)
            {
                AppLogger.Warning("Xoa san pham khoi gio that bai: Chua chon san pham can xoa.");
                ThongBao.CanhBao("Vui lòng chọn sản phẩm trong giỏ hàng cần xóa.");
                return;
            }

            string maSP = Convert.ToString(dgvGioHang.CurrentRow.Cells["colGH_Ma"].Value) ?? string.Empty;

            try
            {
                gioHangBLL.XoaSanPham(danhSachGioHang, maSP);
                HienThiGioHang();
                AppLogger.Information($"Form ban hang: da xoa san pham '{maSP}' khoi gio hang.");
            }
            catch (Exception ex)
            {
                AppLogger.Warning($"Xoa san pham khoi gio that bai: {ex.Message}");
                ThongBao.CanhBao(ex.Message);
            }
        }

        private void btnCapNhatSoLuong_Click(object sender, EventArgs e)
        {
            if (dgvGioHang.CurrentRow == null)
            {
                AppLogger.Warning("Cap nhat so luong that bai: Chua chon san pham trong gio.");
                ThongBao.CanhBao("Vui lòng chọn sản phẩm trong giỏ hàng để cập nhật số lượng.");
                return;
            }

            string maSP = Convert.ToString(dgvGioHang.CurrentRow.Cells["colGH_Ma"].Value) ?? string.Empty;
            SanPhamDTO? sp = danhSachSanPham.FirstOrDefault(x => x.MaSanPham == maSP);

            if (sp == null)
            {
                AppLogger.Warning($"Cap nhat so luong that bai: Khong tim thay ma san pham '{maSP}'.");
                return;
            }

            int soLuongMoi = (int)numSoLuong.Value;

            try
            {
                gioHangBLL.CapNhatSoLuong(danhSachGioHang, sp, soLuongMoi);
                HienThiGioHang();
                numSoLuong.Value = 1;
                AppLogger.Information($"Form ban hang: cap nhat so luong cho MaSP: '{maSP}' thanh {soLuongMoi}.");
            }
            catch (Exception ex)
            {
                AppLogger.Warning($"Cap nhat so luong that bai: {ex.Message}");
                ThongBao.CanhBao(ex.Message);
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            AppLogger.Information("Nguoi dung nhan nut Lam moi hoa don.");
            TaoHoaDonMoi();
        }

        private void TaoHoaDonMoi()
        {
            danhSachGioHang.Clear();
            HienThiGioHang();

            txtTimSanPham.Clear();
            danhSachSanPham = sanPhamBLL.LayDanhSachSanPham();
            HienThiDanhSachSanPham(danhSachSanPham);

            txtMaHoaDon.Text = hoaDonBLL.TaoMaHoaDonMoi();
            dtpNgayLap.Value = DateTime.Now;

            cboKhachHang.SelectedIndex = -1;
            cboKhachHang.Text = string.Empty;

            numSoLuong.Value = 1;

            rdoTienMat.Checked = false;
            rdoChuyenKhoan.Checked = false;
            rdoQuetThe.Checked = false;

            LoadKhachHang();
            AppLogger.Information($"Da tao hoa don moi: MaHoaDon: '{txtMaHoaDon.Text}'.");
        }

        private void btnHuyHoaDon_Click(object sender, EventArgs e)
        {
            try
            {
                if (danhSachGioHang.Count == 0)
                {
                    AppLogger.Warning("Huy hoa don that bai: Gio hang dang trong.");
                    ThongBao.CanhBao("Giỏ hàng đang trống, không có hóa đơn để hủy.");
                    return;
                }

                string maHoaDon = txtMaHoaDon.Text.Trim();

                if (!ThongBao.XacNhan($"Bạn có chắc chắn muốn hủy hóa đơn {maHoaDon} không?\nTổng tiền: {lblTongTien.Text}", "Xác nhận hủy hóa đơn"))
                {
                    AppLogger.Information($"Nguoi dung da huy thao tac xac nhan huy hoa don '{maHoaDon}'.");
                    return;
                }

                string? maKhachHang = null;
                if (cboKhachHang.SelectedItem is KhachHangDTO kh && !string.IsNullOrWhiteSpace(kh.MaKhachHang))
                {
                    maKhachHang = kh.MaKhachHang;
                }

                decimal tongTien = gioHangBLL.TinhTongTien(danhSachGioHang);

                hoaDonBLL.LuuHoaDonHuy(
                    maHoaDon,
                    dtpNgayLap.Value,
                    maKhachHang,
                    taiKhoanDangNhap.MaTaiKhoan,
                    tongTien,
                    danhSachGioHang);

                AppLogger.Warning($"Huy hoa don thanh cong: MaHD: '{maHoaDon}', TongTien: {tongTien:N0}, SoMatHang: {danhSachGioHang.Count}.");
                ThongBao.ThongTin($"Hóa đơn {maHoaDon} đã được chuyển sang trạng thái Đã hủy.");

                TaoHoaDonMoi();
            }
            catch (Exception ex)
            {
                AppLogger.Error(ex, $"Loi khi huy hoa don '{txtMaHoaDon.Text}'.");
                // Thay thế bằng hàm này:
                ThongBao.LoiHeThong(
                    ex,
                    "Không thể lưu hóa đơn. Vui lòng kiểm tra lại thông tin hoặc mã hóa đơn!",
                    "FrmBanHang - LuuHoaDon"
                );
            }
        }

        private void btnLuuHoaDon_Click(object sender, EventArgs e)
        {
            try
            {
                if (danhSachGioHang.Count == 0)
                {
                    AppLogger.Warning("Luu hoa don that bai: Gio hang chua co san pham.");
                    ThongBao.CanhBao("Giỏ hàng chưa có sản phẩm. Vui lòng thêm sản phẩm trước khi thanh toán.");
                    return;
                }

                string phuongThucThanhToan;
                if (rdoTienMat.Checked) phuongThucThanhToan = "Tiền mặt";
                else if (rdoChuyenKhoan.Checked) phuongThucThanhToan = "Chuyển khoản";
                else if (rdoQuetThe.Checked) phuongThucThanhToan = "Quẹt thẻ";
                else
                {
                    AppLogger.Warning("Luu hoa don that bai: Chua chon phuong thuc thanh toan.");
                    ThongBao.CanhBao("Vui lòng chọn phương thức thanh toán (Tiền mặt, Chuyển khoản hoặc Quẹt thẻ).");
                    return;
                }

                if (cboKhachHang.SelectedItem is not KhachHangDTO khachHang || string.IsNullOrWhiteSpace(khachHang.MaKhachHang))
                {
                    AppLogger.Warning("Luu hoa don that bai: Chua chon khach hang.");
                    ThongBao.CanhBao("Chưa chọn khách hàng.");
                    cboKhachHang.Focus();
                    return;
                }

                string maKhachHang = khachHang.MaKhachHang;
                string maHoaDon = txtMaHoaDon.Text.Trim();
                decimal tongTien = gioHangBLL.TinhTongTien(danhSachGioHang);

                hoaDonBLL.LuuHoaDon(
                    maHoaDon,
                    dtpNgayLap.Value,
                    maKhachHang,
                    taiKhoanDangNhap.MaTaiKhoan,
                    tongTien,
                    phuongThucThanhToan,
                    danhSachGioHang);

                AppLogger.Information($"Thanh toan & Luu hoa don thanh cong: MaHD: '{maHoaDon}', MaKH: '{maKhachHang}', MaNV: {taiKhoanDangNhap.MaTaiKhoan}, TongTien: {tongTien:N0} VND, PTTT: '{phuongThucThanhToan}', SoMatHang: {danhSachGioHang.Count}.");

                ThongBao.ThanhCong($"Lưu hóa đơn {maHoaDon} thành công!\nTổng tiền: {tongTien:N0} VNĐ ({phuongThucThanhToan})");

                TaoHoaDonMoi();
            }
            catch (Exception ex)
            {
                AppLogger.Error(ex, $"Loi khi luu hoa don '{txtMaHoaDon.Text}'.");
                // Thay thế bằng hàm này:
                ThongBao.LoiHeThong(
                    ex,
                    "Không thể lưu hóa đơn. Vui lòng kiểm tra lại thông tin hoặc mã hóa đơn!",
                    "FrmBanHang - LuuHoaDon"
                );
            }
        }

        private void LoadKhachHang()
        {
            try
            {
                danhSachKhachHang = khachHangBLL.LayDanhSachKhachHangDTO();

                cboKhachHang.DataSource = null;
                cboKhachHang.DisplayMember = nameof(KhachHangDTO.TenKhachHang);
                cboKhachHang.ValueMember = nameof(KhachHangDTO.MaKhachHang);
                cboKhachHang.DataSource = danhSachKhachHang;

                cboKhachHang.SelectedIndex = -1;
                cboKhachHang.Text = string.Empty;

                AppLogger.Information($"Form bán hàng: tải {danhSachKhachHang.Count} khách hàng.");
            }
            catch (Exception ex)
            {
                AppLogger.Error(ex, "Form bán hàng: không thể tải danh sách khách hàng.");
                ThongBao.LoiHeThong(ex, "Không thể tải danh sách khách hàng. Vui lòng thử lại.", "Form bán hàng");
            }
        }

        private void cboKhachHang_TextUpdate(object sender, EventArgs e)
        {
            if (dangCapNhatCombo)
                return;

            try
            {
                dangCapNhatCombo = true;

                string tuKhoa = cboKhachHang.Text.Trim();
                int viTriConTro = cboKhachHang.SelectionStart;

                cboKhachHang.DroppedDown = false;

                // Gọi qua BLL thay vì truy vấn LINQ tại UI
                List<KhachHangDTO> ketQua = khachHangBLL.TimKiemKhachHang(danhSachKhachHang, tuKhoa);

                cboKhachHang.DataSource = null;
                cboKhachHang.DisplayMember = nameof(KhachHangDTO.TenKhachHang);
                cboKhachHang.ValueMember = nameof(KhachHangDTO.MaKhachHang);
                cboKhachHang.DataSource = ketQua;

                cboKhachHang.SelectedIndex = -1;
                cboKhachHang.Text = tuKhoa;

                cboKhachHang.SelectionStart = Math.Min(viTriConTro, cboKhachHang.Text.Length);
                cboKhachHang.SelectionLength = 0;

                if (ketQua.Count > 0 && cboKhachHang.Focused)
                {
                    cboKhachHang.DroppedDown = true;
                    cboKhachHang.SelectionStart = Math.Min(viTriConTro, cboKhachHang.Text.Length);
                    cboKhachHang.SelectionLength = 0;
                }
            }
            finally
            {
                dangCapNhatCombo = false;
            }
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            AppLogger.Information("Dong FrmBanHang.");
            Close();
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            AppLogger.Information("Dieu huong ve FrmTrangChu tu FrmBanHang.");
            FrmTrangChu home = new FrmTrangChu();
            home.Show();
            Close();
        }
    }
}