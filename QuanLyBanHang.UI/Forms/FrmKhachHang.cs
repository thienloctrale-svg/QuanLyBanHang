using System;
using System.Data;
using System.Windows.Forms;
using QuanLyBanHang.BLL;
using QuanLyBanHang.Logging;

namespace QuanLyBanHang.UI
{
    public partial class FrmKhachHang : Form
    {
        private readonly KhachHangBLL _khachHangBLL = new KhachHangBLL();

        public FrmKhachHang()
        {
            InitializeComponent();
        }

        private void FrmKhachHang_Load(object sender, EventArgs e)
        {
            try
            {
                // Chọn giá trị mặc định cho các ComboBox
                if (cboGioiTinh.Items.Count > 0) cboGioiTinh.SelectedIndex = 0;
                if (cboLoaiKhachHang.Items.Count > 0) cboLoaiKhachHang.SelectedIndex = 0;
                if (cboTrangThai.Items.Count > 0) cboTrangThai.SelectedIndex = 0;
                if (cboLocLoaiKH.Items.Count > 0) cboLocLoaiKH.SelectedIndex = 0;

                // Tải dữ liệu khách hàng từ SQL Server lên DataGridView
                HienThiDanhSachKhachHang();
            }
            catch (Exception ex)
            {
                AppLogger.Error(ex, "Lỗi khi tải dữ liệu FrmKhachHang.");
                MessageBox.Show("Lỗi kết nối cơ sở dữ liệu: " + ex.Message, "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void HienThiDanhSachKhachHang(string tuKhoa = "", string loaiKhachHang = "")
        {
            try
            {
                DataTable dt = _khachHangBLL.LayDanhSachKhachHang(tuKhoa, loaiKhachHang);
                dgvKhachHang.DataSource = dt;
                lblTongSoKhachHang.Text = $"Tổng cộng: {dt.Rows.Count} khách hàng";
            }
            catch (Exception ex)
            {
                AppLogger.Error(ex, "Lỗi khi lấy danh sách khách hàng.");
                MessageBox.Show("Không thể tải danh sách khách hàng: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string tuKhoa = txtTimKiem.Text.Trim();
            string loaiKhachHang = cboLocLoaiKH.SelectedItem?.ToString() ?? "";
            HienThiDanhSachKhachHang(tuKhoa, loaiKhachHang);
        }

        private void btnDatLai_Click(object sender, EventArgs e)
        {
            txtTimKiem.Clear();
            if (cboLocLoaiKH.Items.Count > 0) cboLocLoaiKH.SelectedIndex = 0;
            HienThiDanhSachKhachHang();
        }

        private void dgvKhachHang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex >= dgvKhachHang.Rows.Count) return;

            DataGridViewRow row = dgvKhachHang.Rows[e.RowIndex];

            txtMaKhachHang.Text = row.Cells["colMaKH"].Value?.ToString() ?? string.Empty;
            txtTenKhachHang.Text = row.Cells["colTenKH"].Value?.ToString() ?? string.Empty;
            cboGioiTinh.Text = row.Cells["colGioiTinh"].Value?.ToString() ?? "Nam";

            if (DateTime.TryParse(row.Cells["colNgaySinh"].Value?.ToString(), out DateTime ngaySinh))
            {
                dtpNgaySinh.Value = ngaySinh;
            }

            txtSoDienThoai.Text = row.Cells["colSoDienThoai"].Value?.ToString() ?? string.Empty;
            txtEmail.Text = row.Cells["colEmail"].Value?.ToString() ?? string.Empty;
            cboLoaiKhachHang.Text = row.Cells["colLoaiKH"].Value?.ToString() ?? "Khách thường";
            txtDiaChi.Text = row.Cells["colDiaChi"].Value?.ToString() ?? string.Empty;
            cboTrangThai.Text = row.Cells["colTrangThai"].Value?.ToString() ?? "Đang hoạt động";
            txtGhiChu.Text = row.Cells["colGhiChu"].Value?.ToString() ?? string.Empty;
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            txtMaKhachHang.Clear();
            txtTenKhachHang.Clear();
            txtSoDienThoai.Clear();
            txtEmail.Clear();
            txtDiaChi.Clear();
            txtGhiChu.Clear();

            if (cboGioiTinh.Items.Count > 0) cboGioiTinh.SelectedIndex = 0;
            if (cboLoaiKhachHang.Items.Count > 0) cboLoaiKhachHang.SelectedIndex = 0;
            if (cboTrangThai.Items.Count > 0) cboTrangThai.SelectedIndex = 0;

            dtpNgaySinh.Value = DateTime.Now;
            txtMaKhachHang.Focus();
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
