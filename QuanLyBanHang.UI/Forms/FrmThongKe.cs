using System;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Text;
using System.Windows.Forms;
using QuanLyBanHang.BLL;

namespace QuanLyBanHang.UI
{
    public partial class FrmThongKe : Form
    {
        private readonly ThongKeBLL thongKeBLL = new ThongKeBLL();

        public FrmThongKe()
        {
            InitializeComponent();

            KhoiTaoGiaoDien();
            GanSuKien();
            ThucHienThongKe();
        }

        private void KhoiTaoGiaoDien()
        {
            // Bộ lọc phương thức thanh toán
            cboTrangThai.Items.Clear();
            cboTrangThai.Items.Add("Tất cả");
            cboTrangThai.Items.Add("Tiền mặt");
            cboTrangThai.Items.Add("Chuyển khoản");
            cboTrangThai.Items.Add("Quẹt thẻ");
            cboTrangThai.SelectedIndex = 0;

            // Mặc định thống kê từ đầu tháng đến hiện tại
            dtpTuNgay.Value = new DateTime(
                DateTime.Now.Year,
                DateTime.Now.Month,
                1);

            dtpDenNgay.Value = DateTime.Now;

            // Cấu hình bảng
            dgvHoaDon.AutoGenerateColumns = false;
            dgvChiTietHoaDon.AutoGenerateColumns = false;

            dgvHoaDon.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;

            dgvHoaDon.MultiSelect = false;

            dgvChiTietHoaDon.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;

            dgvChiTietHoaDon.MultiSelect = false;
        }

        private void GanSuKien()
        {
            btnThongKe.Click += btnThongKe_Click;
            button1.Click += button1_Click;

            dgvHoaDon.CellClick += dgvHoaDon_CellClick;

            btnDong.Click += btnDong_Click;
            btnXuatBaoCao.Click += btnXuatBaoCao_Click;

            // Nếu bạn đã double-click nút btnHome trên giao diện Design,
            // bạn có thể xóa dòng bên dưới để tránh chạy sự kiện 2 lần:
            btnHome.Click += btnHome_Click;
        }

        // Thực hiện thống kê
        private void ThucHienThongKe()
        {
            try
            {
                DateTime tuNgay = dtpTuNgay.Value.Date;
                DateTime denNgay = dtpDenNgay.Value.Date;

                if (tuNgay > denNgay)
                {
                    MessageBox.Show(
                        "Từ ngày không được lớn hơn đến ngày.",
                        "Thông báo",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    return;
                }

                string phuongThuc = cboTrangThai.Text;
                string tuKhoa = txtTimKiem.Text.Trim();

                // Lấy danh sách hóa đơn
                DataTable dsHoaDon =
                    thongKeBLL.LayDanhSachHoaDon(
                        tuNgay,
                        denNgay,
                        phuongThuc,
                        tuKhoa);

                dgvHoaDon.Rows.Clear();

                foreach (DataRow row in dsHoaDon.Rows)
                {
                    int index = dgvHoaDon.Rows.Add();

                    dgvHoaDon.Rows[index].Cells["colHD_Ma"].Value =
                        row["MaHoaDon"];

                    dgvHoaDon.Rows[index].Cells["colHD_NgayLap"].Value =
                        Convert.ToDateTime(row["NgayLap"])
                            .ToString("dd/MM/yyyy");

                    dgvHoaDon.Rows[index].Cells["colHD_KhachHang"].Value =
                        row["TenKhachHang"] == DBNull.Value
                            ? "Khách lẻ"
                            : row["TenKhachHang"];

                    dgvHoaDon.Rows[index].Cells["colHD_TrangThai"].Value =
                        row["PhuongThucThanhToan"];

                    dgvHoaDon.Rows[index].Cells["colHD_TongTien"].Value =
                        Convert.ToDecimal(row["TongTien"])
                            .ToString("N0") + " VNĐ";
                }

                // Lấy thông tin tổng quan
                DataTable tongQuan =
                    thongKeBLL.LayThongTinTongQuan(
                        tuNgay,
                        denNgay,
                        phuongThuc,
                        tuKhoa);

                if (tongQuan.Rows.Count > 0)
                {
                    DataRow row = tongQuan.Rows[0];

                    lblSoHoaDon.Text =
                        Convert.ToInt32(row["SoHoaDon"]).ToString("N0");

                    lblTongDoanhThu.Text =
                        Convert.ToDecimal(row["TongDoanhThu"])
                            .ToString("N0") + " VNĐ";

                    lblSoHoaDonHuy.Text =
                        Convert.ToInt32(row["SoHoaDonHuy"]).ToString("N0");

                    lblGiaTriTrungBinh.Text =
                        Convert.ToDecimal(row["TrungBinhDon"])
                            .ToString("N0") + " VNĐ";
                }

                // Xóa chi tiết cũ khi thống kê lại
                dgvChiTietHoaDon.Rows.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Không thể thực hiện thống kê.\n" + ex.Message,
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void btnThongKe_Click(object sender, EventArgs e)
        {
            ThucHienThongKe();
        }

        // Đặt lại bộ lọc
        private void button1_Click(object sender, EventArgs e)
        {
            dtpTuNgay.Value = new DateTime(
                DateTime.Now.Year,
                DateTime.Now.Month,
                1);

            dtpDenNgay.Value = DateTime.Now;

            cboTrangThai.SelectedIndex = 0;
            txtTimKiem.Clear();

            ThucHienThongKe();
        }

        // Chọn hóa đơn để xem chi tiết
        private void dgvHoaDon_CellClick(
            object sender,
            DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            try
            {
                string maHoaDon = Convert.ToString(
                    dgvHoaDon.Rows[e.RowIndex]
                        .Cells["colHD_Ma"].Value);

                if (string.IsNullOrWhiteSpace(maHoaDon))
                    return;

                DataTable chiTiet =
                    thongKeBLL.LayChiTietHoaDon(maHoaDon);

                dgvChiTietHoaDon.Rows.Clear();

                foreach (DataRow row in chiTiet.Rows)
                {
                    int index = dgvChiTietHoaDon.Rows.Add();

                    dgvChiTietHoaDon.Rows[index]
                        .Cells["colCT_STT"].Value = row["STT"];

                    dgvChiTietHoaDon.Rows[index]
                        .Cells["colCT_MaSP"].Value = row["MaSanPham"];

                    dgvChiTietHoaDon.Rows[index]
                        .Cells["colCT_SoLuong"].Value = row["SoLuong"];

                    dgvChiTietHoaDon.Rows[index]
                        .Cells["colCT_ThanhTien"].Value =
                        Convert.ToDecimal(row["ThanhTien"])
                            .ToString("N0");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Không thể tải chi tiết hóa đơn.\n" + ex.Message,
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // Xuất danh sách hóa đơn ra CSV để mở bằng Excel
        private void btnXuatBaoCao_Click(object sender, EventArgs e)
        {
            if (dgvHoaDon.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu để xuất.");
                return;
            }

            using (SaveFileDialog saveDialog = new SaveFileDialog())
            {
                saveDialog.Filter = "Excel CSV (*.csv)|*.csv";
                saveDialog.FileName =
                    "BaoCaoThongKe_" +
                    DateTime.Now.ToString("yyyyMMdd_HHmmss") +
                    ".csv";

                if (saveDialog.ShowDialog() != DialogResult.OK)
                    return;

                try
                {
                    StringBuilder sb = new StringBuilder();

                    sb.AppendLine(
                        "Mã hóa đơn,Ngày lập,Khách hàng,Phương thức thanh toán,Tổng tiền");

                    foreach (DataGridViewRow row in dgvHoaDon.Rows)
                    {
                        string ma = Convert.ToString(
                            row.Cells["colHD_Ma"].Value);

                        string ngay = Convert.ToString(
                            row.Cells["colHD_NgayLap"].Value);

                        string khachHang = Convert.ToString(
                            row.Cells["colHD_KhachHang"].Value);

                        string phuongThuc = Convert.ToString(
                            row.Cells["colHD_TrangThai"].Value);

                        string tongTien = Convert.ToString(
                            row.Cells["colHD_TongTien"].Value);

                        sb.AppendLine(
                            $"\"{ma}\",\"{ngay}\",\"{khachHang}\",\"{phuongThuc}\",\"{tongTien}\"");
                    }

                    File.WriteAllText(
                        saveDialog.FileName,
                        sb.ToString(),
                        new UTF8Encoding(true));

                    MessageBox.Show(
                        "Xuất báo cáo thành công!",
                        "Thông báo",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(
                        "Không thể xuất báo cáo.\n" + ex.Message);
                }
            }
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            try
            {
                FrmTrangChu frmHome = new FrmTrangChu();

                // Đăng ký sự kiện: Khi đóng Form Trang Chủ thì đóng luôn ứng dụng
                frmHome.FormClosed += (s, args) => this.Close();

                // Ẩn form Thống Kê hiện tại
                this.Hide();

                // Mở Form Trang Chủ
                frmHome.Show();
            }
            catch (Exception ex)
            {
                // Hiển thị thông báo nếu có lỗi bên trong FrmTrangChu
                MessageBox.Show("Lỗi khi mở Trang Chủ: " + ex.Message, "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Show(); // Hiện lại form thống kê nếu mở thất bại
            }
        }
    }
}