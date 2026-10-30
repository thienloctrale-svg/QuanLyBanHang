using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using QuanLyBanHang.BLL;
using QuanLyBanHang.DTO;
using QuanLyBanHang.Logging;

namespace QuanLyBanHang.UI
{
    public partial class FrmBanHang : Form
    {
        private readonly SanPhamBLL sanPhamBLL = new SanPhamBLL();
        private readonly KhachHangBLL khachHangBLL = new KhachHangBLL();
        private readonly HoaDonBLL hoaDonBLL = new HoaDonBLL();

        private List<SanPhamDTO> danhSachSanPham =
            new List<SanPhamDTO>();

        private List<ChiTietHoaDonDTO> LayChiTietTuGioHang()
        {
            List<ChiTietHoaDonDTO> chiTiet =
                new List<ChiTietHoaDonDTO>();

            foreach (DataGridViewRow row in dgvGioHang.Rows)
            {
                if (row.IsNewRow)
                    continue;

                chiTiet.Add(new ChiTietHoaDonDTO
                {
                    MaSanPham = Convert.ToString(
                        row.Cells["colGH_Ma"].Value) ?? string.Empty,

                    SoLuong = Convert.ToInt32(
                        row.Cells["colGH_SoLuong"].Value),

                    DonGia = Convert.ToDecimal(
                        row.Cells["colGH_DonGia"].Value),

                    ThanhTien = Convert.ToDecimal(
                        row.Cells["colGH_ThanhTien"].Value)
                });
            }

            return chiTiet;
        }


        private void TaoHoaDonMoi()
        {
            dgvGioHang.Rows.Clear();

            txtTimSanPham.Clear();

            danhSachSanPham = sanPhamBLL.LayDanhSachSanPham();
            HienThiDanhSachSanPham(danhSachSanPham);

            txtMaHoaDon.Text = hoaDonBLL.TaoMaHoaDonMoi();

            dtpNgayLap.Value = DateTime.Now;

            cboKhachHang.SelectedIndex = -1;

            numSoLuong.Value = 1;

            rdoTienMat.Checked = false;
            rdoChuyenKhoan.Checked = false;
            rdoQuetThe.Checked = false;

            CapNhatTongTien();
        }

        private TaiKhoanDTO taiKhoanDangNhap;

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

        // Khi mở form
        private void FrmBanHang_Load(object sender, EventArgs e)
        {
            try
            {
                txtMaHoaDon.Text = hoaDonBLL.TaoMaHoaDonMoi();

                dtpNgayLap.Value = DateTime.Now;

                // Thiết lập số lượng
                numSoLuong.Minimum = 1;
                numSoLuong.Value = 1;

                // Cấu hình bảng
                dgvSanPham.ReadOnly = true;
                dgvSanPham.AllowUserToAddRows = false;
                dgvSanPham.SelectionMode =
                    DataGridViewSelectionMode.FullRowSelect;
                dgvSanPham.MultiSelect = false;
                dgvSanPham.AutoGenerateColumns = false;

                dgvGioHang.ReadOnly = true;
                dgvGioHang.AllowUserToAddRows = false;
                dgvGioHang.SelectionMode =
                    DataGridViewSelectionMode.FullRowSelect;
                dgvGioHang.MultiSelect = false;
                dgvGioHang.AutoGenerateColumns = false;

                // Hiển thị sản phẩm từ SQL Server
                danhSachSanPham =
                    sanPhamBLL.LayDanhSachSanPham();

                HienThiDanhSachSanPham(danhSachSanPham);

                CapNhatTongTien();

                // Tải danh sách khách hàng
                LoadKhachHang();

                AppLogger.Information(
                    "Form bán hàng: mở form thành công.");
            }
            catch (Exception ex)
            {
                AppLogger.Error(
                    ex,
                    "Form bán hàng: không thể tải dữ liệu.");

                MessageBox.Show(
                    "Không thể tải danh sách sản phẩm.\n" +
                    "Vui lòng kiểm tra kết nối cơ sở dữ liệu.\n\n" +
                    ex.Message,
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // Hiển thị danh sách sản phẩm
        private void HienThiDanhSachSanPham(
            List<SanPhamDTO> danhSach)
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

        // Tìm sản phẩm theo mã hoặc tên
        private void btnTimSanPham_Click(
            object sender, EventArgs e)
        {
            string tuKhoa =
                txtTimSanPham.Text.Trim();

            List<SanPhamDTO> ketQua =
                danhSachSanPham
                    .Where(sp =>
                        sp.MaSanPham.Contains(
                            tuKhoa,
                            StringComparison.OrdinalIgnoreCase)
                        ||
                        sp.TenSanPham.Contains(
                            tuKhoa,
                            StringComparison.OrdinalIgnoreCase))
                    .ToList();

            HienThiDanhSachSanPham(ketQua);
        }

        // Thêm sản phẩm vào giỏ hàng
        private void btnThemSanPham_Click(
            object sender, EventArgs e)
        {
            if (dgvSanPham.CurrentRow == null)
            {
                MessageBox.Show(
                    "Vui lòng chọn sản phẩm.",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                return;
            }

            string maSP = Convert.ToString(
                dgvSanPham.CurrentRow.Cells["colSP_Ma"].Value)
                ?? string.Empty;

            SanPhamDTO? sp = danhSachSanPham.FirstOrDefault(
                x => x.MaSanPham == maSP);

            if (sp == null)
            {
                MessageBox.Show(
                    "Không tìm thấy sản phẩm đã chọn.",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            int soLuongThem = (int)numSoLuong.Value;

            if (soLuongThem > sp.SoLuongTon)
            {
                MessageBox.Show(
                    "Số lượng yêu cầu vượt quá tồn kho.",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            // Kiểm tra sản phẩm đã có trong giỏ chưa
            DataGridViewRow? dongCu =
                dgvGioHang.Rows
                    .Cast<DataGridViewRow>()
                    .FirstOrDefault(row =>
                        Convert.ToString(
                            row.Cells["colGH_Ma"].Value) == maSP);

            if (dongCu != null)
            {
                int soLuongCu = Convert.ToInt32(
                    dongCu.Cells["colGH_SoLuong"].Value);

                int soLuongMoi = soLuongCu + soLuongThem;

                if (soLuongMoi > sp.SoLuongTon)
                {
                    MessageBox.Show(
                        "Tổng số lượng trong giỏ vượt quá tồn kho.",
                        "Thông báo",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    return;
                }

                dongCu.Cells["colGH_SoLuong"].Value = soLuongMoi;

                dongCu.Cells["colGH_ThanhTien"].Value =
                    soLuongMoi * sp.GiaBan;
            }
            else
            {
                int stt = dgvGioHang.Rows.Count + 1;
                decimal thanhTien = soLuongThem * sp.GiaBan;

                dgvGioHang.Rows.Add(
                    stt,
                    sp.MaSanPham,
                    sp.TenSanPham,
                    sp.DonViTinh,
                    soLuongThem,
                    sp.GiaBan,
                    thanhTien);
            }

            CapNhatTongTien();

            numSoLuong.Value = 1;

            AppLogger.Information(
                "Form bán hàng: thêm sản phẩm vào giỏ.");
        }

        // Xóa sản phẩm khỏi giỏ hàng
        private void btnXoaSanPham_Click(
            object sender, EventArgs e)
        {
            if (dgvGioHang.CurrentRow == null)
            {
                MessageBox.Show(
                    "Vui lòng chọn sản phẩm cần xóa.",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                return;
            }

            dgvGioHang.Rows.Remove(
                dgvGioHang.CurrentRow);

            CapNhatSTT();
            CapNhatTongTien();
        }

        // Cập nhật số lượng sản phẩm đang chọn
        private void btnCapNhatSoLuong_Click(
            object sender, EventArgs e)
        {
            if (dgvGioHang.CurrentRow == null)
            {
                MessageBox.Show(
                    "Vui lòng chọn sản phẩm trong giỏ hàng.",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                return;
            }

            DataGridViewRow dong =
                dgvGioHang.CurrentRow;

            string maSP = Convert.ToString(
                dong.Cells["colGH_Ma"].Value)
                ?? string.Empty;

            SanPhamDTO? sp = danhSachSanPham.FirstOrDefault(
                x => x.MaSanPham == maSP);

            if (sp == null)
                return;

            int soLuongMoi = (int)numSoLuong.Value;

            if (soLuongMoi > sp.SoLuongTon)
            {
                MessageBox.Show(
                    "Số lượng yêu cầu vượt quá tồn kho.",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            dong.Cells["colGH_SoLuong"].Value = soLuongMoi;

            dong.Cells["colGH_ThanhTien"].Value =
                soLuongMoi * sp.GiaBan;

            numSoLuong.Value = 1;

            CapNhatTongTien();
        }

        // Đánh lại số thứ tự
        private void CapNhatSTT()
        {
            for (int i = 0; i < dgvGioHang.Rows.Count; i++)
            {
                dgvGioHang.Rows[i].Cells["colGH_STT"].Value =
                    i + 1;
            }
        }

        // Tính tổng tiền giỏ hàng
        private void CapNhatTongTien()
        {
            decimal tongTien = 0;

            foreach (DataGridViewRow dong in dgvGioHang.Rows)
            {
                if (dong.Cells["colGH_ThanhTien"].Value != null)
                {
                    tongTien += Convert.ToDecimal(
                        dong.Cells["colGH_ThanhTien"].Value);
                }
            }

            lblTongTien.Text =
                tongTien.ToString("N0") + " VNĐ";
        }

        // Làm mới hóa đơn đang nhập
        private void btnLamMoi_Click(
            object sender, EventArgs e)
        {
            dgvGioHang.Rows.Clear();

            txtTimSanPham.Clear();

            HienThiDanhSachSanPham(danhSachSanPham);

            numSoLuong.Value = 1;

            CapNhatTongTien();

            txtMaHoaDon.Text = hoaDonBLL.TaoMaHoaDonMoi();

            dtpNgayLap.Value = DateTime.Now;
        }

        // Hủy hóa đơn đang nhập
        private void btnHuyHoaDon_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvGioHang.Rows.Count == 0)
                {
                    MessageBox.Show(
                        "Giỏ hàng đang trống, không có hóa đơn để hủy.",
                        "Thông báo",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    return;
                }

                string maHoaDon = txtMaHoaDon.Text.Trim();

                DialogResult xacNhan = MessageBox.Show(
                    "Bạn có chắc chắn muốn hủy hóa đơn này không?\n\n" +
                    "Mã hóa đơn: " + maHoaDon + "\n" +
                    "Tổng tiền: " + lblTongTien.Text + "\n\n" +
                    "Thông tin hóa đơn sẽ được lưu vào hệ thống với trạng thái Đã hủy.",
                    "Xác nhận hủy hóa đơn",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (xacNhan != DialogResult.Yes)
                    return;

                string? maKhachHang = null;

                if (cboKhachHang.SelectedIndex >= 0 &&
                    cboKhachHang.SelectedValue != null)
                {
                    maKhachHang = Convert.ToString(
                        cboKhachHang.SelectedValue);
                }

                List<ChiTietHoaDonDTO> chiTiet =
                    LayChiTietTuGioHang();

                decimal tongTien = chiTiet.Sum(x => x.ThanhTien);

                hoaDonBLL.LuuHoaDonHuy(
                    maHoaDon,
                    dtpNgayLap.Value,
                    maKhachHang,
                    taiKhoanDangNhap.MaTaiKhoan,
                    tongTien,
                    chiTiet);

                MessageBox.Show(
                    "Hóa đơn đã bị hủy!\n\n" +
                    "Mã hóa đơn: " + maHoaDon + "\n" +
                    "Tổng tiền: " + tongTien.ToString("N0") + " VNĐ\n" +
                    "Trạng thái: Đã hủy",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                TaoHoaDonMoi();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Không thể hủy hóa đơn.\nChi tiết: " + ex.Message,
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // Đóng form
        private void btnDong_Click(
            object sender, EventArgs e)
        {
            Close();
        }


        // Tải danh sách khách hàng
        private void LoadKhachHang()
        {
            try
            {
                List<KhachHangDTO> danhSach =
                    khachHangBLL.LayDanhSachKhachHang();

                cboKhachHang.DataSource = null;
                cboKhachHang.DisplayMember =
                    nameof(KhachHangDTO.TenKhachHang);
                cboKhachHang.ValueMember =
                    nameof(KhachHangDTO.MaKhachHang);
                cboKhachHang.DataSource = danhSach;

                // Chưa chọn khách hàng mặc định
                cboKhachHang.SelectedIndex = -1;

                AppLogger.Information(
                    $"Form bán hàng: tải {danhSach.Count} khách hàng.");
            }
            catch (Exception ex)
            {
                AppLogger.Error(
                    ex,
                    "Form bán hàng: không thể tải danh sách khách hàng.");

                MessageBox.Show(
                    "Không thể tải danh sách khách hàng.\n" + ex.Message,
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }


        // Xử lý nút Lưu hóa đơn

        private void btnLuuHoaDon_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvGioHang.Rows.Count == 0)
                {
                    MessageBox.Show(
                        "Giỏ hàng chưa có sản phẩm.",
                        "Thông báo",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    return;
                }

                string phuongThucThanhToan;

                if (rdoTienMat.Checked)
                    phuongThucThanhToan = "Tiền mặt";
                else if (rdoChuyenKhoan.Checked)
                    phuongThucThanhToan = "Chuyển khoản";
                else if (rdoQuetThe.Checked)
                    phuongThucThanhToan = "Quẹt thẻ";
                else
                {
                    MessageBox.Show("Vui lòng chọn phương thức thanh toán.");
                    return;
                }

                string? maKhachHang = null;

                if (cboKhachHang.SelectedIndex >= 0 &&
                    cboKhachHang.SelectedValue != null)
                {
                    maKhachHang = Convert.ToString(
                        cboKhachHang.SelectedValue);
                }

                List<ChiTietHoaDonDTO> chiTiet =
                    LayChiTietTuGioHang();

                decimal tongTien = chiTiet.Sum(x => x.ThanhTien);
                string maHoaDon = txtMaHoaDon.Text.Trim();

                hoaDonBLL.LuuHoaDon(
                    maHoaDon,
                    dtpNgayLap.Value,
                    maKhachHang,
                    taiKhoanDangNhap.MaTaiKhoan,
                    tongTien,
                    phuongThucThanhToan,
                    chiTiet);

                MessageBox.Show(
                    "Lưu hóa đơn thành công!\n" +
                    "Mã hóa đơn: " + maHoaDon + "\n" +
                    "Phương thức thanh toán: " + phuongThucThanhToan + "\n" +
                    "Tổng tiền: " + tongTien.ToString("N0") + " VNĐ",
                    "Thành công",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                TaoHoaDonMoi();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Không thể lưu hóa đơn.\nChi tiết: " + ex.Message,
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            FrmTrangChu home = new FrmTrangChu();
            home.Show();
            this.Close();
        }

    }
}
