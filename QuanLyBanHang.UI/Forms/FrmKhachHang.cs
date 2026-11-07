using System;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Text;
using System.Windows.Forms;
using QuanLyBanHang.BLL;
using QuanLyBanHang.DTO;
using QuanLyBanHang.Logging;

namespace QuanLyBanHang.UI
{
    public partial class FrmKhachHang : Form
    {
        private readonly KhachHangBLL _khachHangBLL = new KhachHangBLL();
        private bool _isAdding = false;

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

                if (dt.Rows.Count > 0 && !_isAdding)
                {
                    // Tự động load dòng đầu tiên lên controls
                    HienThiChiTietDong(0);
                }
            }
            catch (Exception ex)
            {
                AppLogger.Error(ex, "Lỗi khi lấy danh sách khách hàng.");
                MessageBox.Show("Không thể tải danh sách khách hàng: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void HienThiChiTietDong(int rowIndex)
        {
            if (rowIndex < 0 || rowIndex >= dgvKhachHang.Rows.Count) return;

            DataGridViewRow row = dgvKhachHang.Rows[rowIndex];

            txtMaKhachHang.Text = row.Cells["colMaKH"].Value?.ToString() ?? string.Empty;
            txtTenKhachHang.Text = row.Cells["colTenKH"].Value?.ToString() ?? string.Empty;
            cboGioiTinh.Text = row.Cells["colGioiTinh"].Value?.ToString() ?? "Nam";

            if (DateTime.TryParse(row.Cells["colNgaySinh"].Value?.ToString(), out DateTime ngaySinh))
            {
                dtpNgaySinh.Value = ngaySinh;
            }
            else
            {
                dtpNgaySinh.Value = DateTime.Now;
            }

            txtSoDienThoai.Text = row.Cells["colSoDienThoai"].Value?.ToString() ?? string.Empty;
            txtEmail.Text = row.Cells["colEmail"].Value?.ToString() ?? string.Empty;
            cboLoaiKhachHang.Text = row.Cells["colLoaiKH"].Value?.ToString() ?? "Khách thường";
            txtDiaChi.Text = row.Cells["colDiaChi"].Value?.ToString() ?? string.Empty;
            cboTrangThai.Text = row.Cells["colTrangThai"].Value?.ToString() ?? "Đang hoạt động";
            txtGhiChu.Text = row.Cells["colGhiChu"].Value?.ToString() ?? string.Empty;

            txtMaKhachHang.ReadOnly = true;
            _isAdding = false;
        }

        private void dgvKhachHang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                HienThiChiTietDong(e.RowIndex);
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            _isAdding = true;

            txtMaKhachHang.ReadOnly = false;
            txtMaKhachHang.Text = _khachHangBLL.TaoMaKhachHangTuDong();
            txtTenKhachHang.Clear();
            txtSoDienThoai.Clear();
            txtEmail.Clear();
            txtDiaChi.Clear();
            txtGhiChu.Clear();

            if (cboGioiTinh.Items.Count > 0) cboGioiTinh.SelectedIndex = 0;
            if (cboLoaiKhachHang.Items.Count > 0) cboLoaiKhachHang.SelectedIndex = 0;
            if (cboTrangThai.Items.Count > 0) cboTrangThai.SelectedIndex = 0;

            dtpNgaySinh.Value = new DateTime(1995, 1, 1);
            txtTenKhachHang.Focus();

            MessageBox.Show("Đã bật chế độ thêm mới. Vui lòng nhập thông tin rồi bấm [Lưu].", "Thêm mới", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaKhachHang.Text))
            {
                MessageBox.Show("Vui lòng chọn một khách hàng từ danh sách để sửa thông tin.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            _isAdding = false;
            txtMaKhachHang.ReadOnly = true;
            txtTenKhachHang.Focus();

            MessageBox.Show("Đã chọn chế độ cập nhật. Bạn có thể sửa thông tin rồi bấm [Lưu].", "Cập nhật", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            string maKH = txtMaKhachHang.Text.Trim();
            string tenKH = txtTenKhachHang.Text.Trim();

            if (string.IsNullOrWhiteSpace(maKH))
            {
                MessageBox.Show("Mã khách hàng không được để trống.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaKhachHang.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(tenKH))
            {
                MessageBox.Show("Tên khách hàng không được để trống.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenKhachHang.Focus();
                return;
            }

            var kh = new KhachHangDTO
            {
                MaKhachHang = maKH,
                TenKhachHang = tenKH,
                GioiTinh = cboGioiTinh.SelectedItem?.ToString() ?? "Nam",
                NgaySinh = dtpNgaySinh.Value,
                SoDienThoai = txtSoDienThoai.Text.Trim(),
                Email = txtEmail.Text.Trim(),
                LoaiKhachHang = cboLoaiKhachHang.SelectedItem?.ToString() ?? "Khách thường",
                DiaChi = txtDiaChi.Text.Trim(),
                TrangThai = cboTrangThai.SelectedItem?.ToString() ?? "Đang hoạt động",
                GhiChu = txtGhiChu.Text.Trim()
            };

            bool ketQua;
            string thongBao;

            if (_isAdding)
            {
                ketQua = _khachHangBLL.ThemKhachHang(kh, out thongBao);
            }
            else
            {
                ketQua = _khachHangBLL.CapNhatKhachHang(kh, out thongBao);
            }

            if (ketQua)
            {
                AppLogger.Information($"{( _isAdding ? "Them" : "Cap nhat" )} khach hang {maKH} thanh cong.");
                MessageBox.Show(thongBao, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                _isAdding = false;
                txtMaKhachHang.ReadOnly = true;
                HienThiDanhSachKhachHang();
            }
            else
            {
                AppLogger.Warning($"Loi khi luu khach hang {maKH}: {thongBao}");
                MessageBox.Show(thongBao, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string maKH = txtMaKhachHang.Text.Trim();
            string tenKH = txtTenKhachHang.Text.Trim();

            if (string.IsNullOrWhiteSpace(maKH))
            {
                MessageBox.Show("Vui lòng chọn khách hàng cần xóa từ danh sách.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var dialogResult = MessageBox.Show(
                $"Bạn có chắc chắn muốn xóa khách hàng '{tenKH}' (Mã: {maKH}) không?",
                "Xác nhận xóa",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (dialogResult == DialogResult.Yes)
            {
                bool ketQua = _khachHangBLL.XoaKhachHang(maKH, out string thongBao);
                if (ketQua)
                {
                    AppLogger.Information($"Xoa khach hang {maKH} thanh cong.");
                    MessageBox.Show(thongBao, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    btnLamMoi_Click(sender, e);
                }
                else
                {
                    AppLogger.Warning($"Khong the xoa khach hang {maKH}: {thongBao}");
                    MessageBox.Show(thongBao, "Không thể xóa", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            _isAdding = false;
            txtMaKhachHang.ReadOnly = true;

            txtMaKhachHang.Clear();
            txtTenKhachHang.Clear();
            txtSoDienThoai.Clear();
            txtEmail.Clear();
            txtDiaChi.Clear();
            txtGhiChu.Clear();

            txtTimKiem.Clear();
            if (cboLocLoaiKH.Items.Count > 0) cboLocLoaiKH.SelectedIndex = 0;
            if (cboGioiTinh.Items.Count > 0) cboGioiTinh.SelectedIndex = 0;
            if (cboLoaiKhachHang.Items.Count > 0) cboLoaiKhachHang.SelectedIndex = 0;
            if (cboTrangThai.Items.Count > 0) cboTrangThai.SelectedIndex = 0;

            dtpNgaySinh.Value = DateTime.Now;

            HienThiDanhSachKhachHang();
        }

        private void btnXuatExcel_Click(object sender, EventArgs e)
        {
            if (dgvKhachHang.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu để xuất.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (var sfd = new SaveFileDialog())
            {
                sfd.Filter = "Tệp CSV (Hỗ trợ mở bằng Excel) (*.csv)|*.csv|Tất cả tệp (*.*)|*.*";
                sfd.FileName = $"DanhSachKhachHang_{DateTime.Now:yyyyMMdd_HHmmss}.csv";
                sfd.Title = "Xuất danh sách khách hàng ra Excel/CSV";

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        var sb = new StringBuilder();

                        // Header
                        string[] headers = new string[]
                        {
                            "STT", "Mã KH", "Tên khách hàng", "Giới tính", "Ngày sinh",
                            "Số điện thoại", "Email", "Loại khách", "Địa chỉ", "Trạng thái", "Ghi chú"
                        };
                        sb.AppendLine(string.Join(",", headers));

                        // Data rows
                        foreach (DataGridViewRow row in dgvKhachHang.Rows)
                        {
                            if (row.IsNewRow) continue;

                            string stt = row.Cells["colSTT"].Value?.ToString() ?? "";
                            string ma = EscapeCsv(row.Cells["colMaKH"].Value?.ToString() ?? "");
                            string ten = EscapeCsv(row.Cells["colTenKH"].Value?.ToString() ?? "");
                            string gt = EscapeCsv(row.Cells["colGioiTinh"].Value?.ToString() ?? "");
                            string ns = "";
                            if (DateTime.TryParse(row.Cells["colNgaySinh"].Value?.ToString(), out DateTime d))
                            {
                                ns = d.ToString("dd/MM/yyyy");
                            }
                            string sdt = EscapeCsv(row.Cells["colSoDienThoai"].Value?.ToString() ?? "");
                            string email = EscapeCsv(row.Cells["colEmail"].Value?.ToString() ?? "");
                            string loai = EscapeCsv(row.Cells["colLoaiKH"].Value?.ToString() ?? "");
                            string diaChi = EscapeCsv(row.Cells["colDiaChi"].Value?.ToString() ?? "");
                            string tt = EscapeCsv(row.Cells["colTrangThai"].Value?.ToString() ?? "");
                            string gc = EscapeCsv(row.Cells["colGhiChu"].Value?.ToString() ?? "");

                            sb.AppendLine($"{stt},{ma},{ten},{gt},{ns},{sdt},{email},{loai},{diaChi},{tt},{gc}");
                        }

                        // Lưu file với UTF-8 kèm BOM để Excel mở không bị lỗi font tiếng Việt
                        File.WriteAllText(sfd.FileName, sb.ToString(), new UTF8Encoding(true));

                        AppLogger.Information($"Xuat file CSV thanh cong: {sfd.FileName}");
                        MessageBox.Show("Xuất dữ liệu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        AppLogger.Error(ex, "Lỗi khi xuất file Excel/CSV.");
                        MessageBox.Show("Lỗi khi xuất tệp: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private static string EscapeCsv(string value)
        {
            if (string.IsNullOrEmpty(value)) return "";
            if (value.Contains(",") || value.Contains("\"") || value.Contains("\n") || value.Contains("\r"))
            {
                return $"\"{value.Replace("\"", "\"\"")}\"";
            }
            return value;
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
