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
        }

        public FrmBanHang(TaiKhoanDTO taiKhoan)
        {
            InitializeComponent();
            KhoiTaoSuKien();

            taiKhoanDangNhap = taiKhoan;
            lblHoTen.Text = taiKhoanDangNhap.HoTen;
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

                AppLogger.Information("Form bán hàng: mở form thành công.");
            }
            catch (Exception ex)
            {
                AppLogger.Error(ex, "Form bán hàng: không thể tải dữ liệu.");
                MessageBox.Show(
                    "Không thể tải danh sách sản phẩm.\nVui lòng kiểm tra kết nối cơ sở dữ liệu.\n\n" + ex.Message,
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
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
            HienThiDanhSachSanPham(ketQua);
        }

        private void btnThemSanPham_Click(object sender, EventArgs e)
        {
            if (dgvSanPham.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn sản phẩm.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string maSP = Convert.ToString(dgvSanPham.CurrentRow.Cells["colSP_Ma"].Value) ?? string.Empty;
            SanPhamDTO? sp = danhSachSanPham.FirstOrDefault(x => x.MaSanPham == maSP);

            if (sp == null)
            {
                MessageBox.Show("Không tìm thấy sản phẩm đã chọn.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int soLuongThem = (int)numSoLuong.Value;

            try
            {
                gioHangBLL.ThemSanPham(danhSachGioHang, sp, soLuongThem);
                HienThiGioHang();
                numSoLuong.Value = 1;
                AppLogger.Information("Form bán hàng: thêm sản phẩm vào giỏ.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnXoaSanPham_Click(object sender, EventArgs e)
        {
            if (dgvGioHang.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn sản phẩm cần xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string maSP = Convert.ToString(dgvGioHang.CurrentRow.Cells["colGH_Ma"].Value) ?? string.Empty;

            try
            {
                gioHangBLL.XoaSanPham(danhSachGioHang, maSP);
                HienThiGioHang();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnCapNhatSoLuong_Click(object sender, EventArgs e)
        {
            if (dgvGioHang.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn sản phẩm trong giỏ hàng.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string maSP = Convert.ToString(dgvGioHang.CurrentRow.Cells["colGH_Ma"].Value) ?? string.Empty;
            SanPhamDTO? sp = danhSachSanPham.FirstOrDefault(x => x.MaSanPham == maSP);

            if (sp == null)
                return;

            int soLuongMoi = (int)numSoLuong.Value;

            try
            {
                gioHangBLL.CapNhatSoLuong(danhSachGioHang, sp, soLuongMoi);
                HienThiGioHang();
                numSoLuong.Value = 1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
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
        }

        private void btnHuyHoaDon_Click(object sender, EventArgs e)
        {
            try
            {
                if (danhSachGioHang.Count == 0)
                {
                    MessageBox.Show("Giỏ hàng đang trống, không có hóa đơn để hủy.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string maHoaDon = txtMaHoaDon.Text.Trim();

                DialogResult xacNhan = MessageBox.Show(
                    $"Bạn có chắc chắn muốn hủy hóa đơn này không?\n\nMã hóa đơn: {maHoaDon}\nTổng tiền: {lblTongTien.Text}\n\nThông tin hóa đơn sẽ được lưu vào hệ thống với trạng thái Đã hủy.",
                    "Xác nhận hủy hóa đơn",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (xacNhan != DialogResult.Yes)
                    return;

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

                MessageBox.Show(
                    $"Hóa đơn đã bị hủy!\n\nMã hóa đơn: {maHoaDon}\nTổng tiền: {tongTien:N0} VNĐ\nTrạng thái: Đã hủy",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                TaoHoaDonMoi();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không thể hủy hóa đơn.\nChi tiết: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLuuHoaDon_Click(object sender, EventArgs e)
        {
            try
            {
                if (danhSachGioHang.Count == 0)
                {
                    MessageBox.Show("Giỏ hàng chưa có sản phẩm.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string phuongThucThanhToan;
                if (rdoTienMat.Checked) phuongThucThanhToan = "Tiền mặt";
                else if (rdoChuyenKhoan.Checked) phuongThucThanhToan = "Chuyển khoản";
                else if (rdoQuetThe.Checked) phuongThucThanhToan = "Quẹt thẻ";
                else
                {
                    MessageBox.Show("Vui lòng chọn phương thức thanh toán.");
                    return;
                }

                if (cboKhachHang.SelectedItem is not KhachHangDTO khachHang || string.IsNullOrWhiteSpace(khachHang.MaKhachHang))
                {
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

                MessageBox.Show(
                    $"Lưu hóa đơn thành công!\n\nMã hóa đơn: {maHoaDon}\nPhương thức thanh toán: {phuongThucThanhToan}\nTổng tiền: {tongTien:N0} VNĐ",
                    "Thành công",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                TaoHoaDonMoi();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không thể lưu hóa đơn.\nChi tiết: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            Close();
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            FrmTrangChu home = new FrmTrangChu();
            home.Show();
            Close();
        }
    }
}