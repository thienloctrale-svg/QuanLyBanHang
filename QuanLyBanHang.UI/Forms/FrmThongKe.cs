using System;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Text;
using System.Windows.Forms;
using QuanLyBanHang.BLL;
using QuanLyBanHang.UI.Helpers;
using QuanLyBanHang.Logging;

namespace QuanLyBanHang.UI
{
    public partial class FrmThongKe : Form
    {
        private readonly ThongKeBLL thongKeBLL = new ThongKeBLL();

        public FrmThongKe()
        {
            InitializeComponent();

            AppLogger.Information("Khoi tao FrmThongKe.");

            KhoiTaoGiaoDien();
            GanSuKien();
            ThucHienThongKe();
        }

        private void KhoiTaoGiaoDien()
        {
            cboTrangThai.Items.Clear();
            cboTrangThai.Items.Add("Tất cả");
            cboTrangThai.Items.Add("Tiền mặt");
            cboTrangThai.Items.Add("Chuyển khoản");
            cboTrangThai.Items.Add("Quẹt thẻ");
            cboTrangThai.Items.Add("Đã hủy");
            cboTrangThai.SelectedIndex = 0;

            dtpTuNgay.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            dtpDenNgay.Value = DateTime.Now;

            dgvHoaDon.AutoGenerateColumns = false;
            dgvChiTietHoaDon.AutoGenerateColumns = false;

            dgvHoaDon.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvHoaDon.MultiSelect = false;

            dgvChiTietHoaDon.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvChiTietHoaDon.MultiSelect = false;
        }

        private void GanSuKien()
        {
            btnThongKe.Click += btnThongKe_Click;
            button1.Click += button1_Click;

            dgvHoaDon.CellClick += dgvHoaDon_CellClick;

            btnDong.Click += btnDong_Click;
            btnXuatBaoCao.Click += btnXuatBaoCao_Click;
            btnHome.Click += btnHome_Click;

            rdoHomNay.CheckedChanged += RdoLocNgay_CheckedChanged;
            rdo7NgayGanNhat.CheckedChanged += RdoLocNgay_CheckedChanged;
            rdo30NgayGanNhat.CheckedChanged += RdoLocNgay_CheckedChanged;

            dgvHoaDon.DataError += Dgv_DataError;
            dgvChiTietHoaDon.DataError += Dgv_DataError;
        }

        private void Dgv_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.ThrowException = false;
            DataGridView dgv = sender as DataGridView;
            string tenBang = dgv != null ? dgv.Name : "DataGridView";

            AppLogger.Error(e.Exception, $"Loi hien thi du lieu tai bang {tenBang} (Cot: {e.ColumnIndex}, Dong: {e.RowIndex}).");

            ThongBao.LoiHeThong(
                e.Exception,
                "Không thể hiển thị một số dữ liệu trên bảng. Vui lòng thử lại!",
                $"{this.Name} - {tenBang} (Cột {e.ColumnIndex}, Dòng {e.RowIndex})"
            );
        }

        private void RdoLocNgay_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rdo = sender as RadioButton;
            if (rdo == null || !rdo.Checked) return;

            LoaiLocThoiGian loaiLoc;
            if (rdo == rdoHomNay)
                loaiLoc = LoaiLocThoiGian.HomNay;
            else if (rdo == rdo7NgayGanNhat)
                loaiLoc = LoaiLocThoiGian.BayNgayGanNhat;
            else if (rdo == rdo30NgayGanNhat)
                loaiLoc = LoaiLocThoiGian.BaMuoiNgayGanNhat;
            else
                return;

            AppLogger.Debug($"Chon bo loc thoi gian nhanh: {loaiLoc}.");

            // Gọi logic tính toán từ BLL
            var khoangNgay = thongKeBLL.TinhKhoangThoiGian(loaiLoc, DateTime.Now);
            dtpTuNgay.Value = khoangNgay.TuNgay;
            dtpDenNgay.Value = khoangNgay.DenNgay;

            ThucHienThongKe();
        }

        private void ThucHienThongKe()
        {
            try
            {
                DateTime tuNgay = dtpTuNgay.Value.Date;
                DateTime denNgay = dtpDenNgay.Value.Date;

                // Gọi validation từ BLL
                if (!thongKeBLL.KiemTraKhoangNgayHopLe(tuNgay, denNgay, out string thongBaoLoi))
                {
                    AppLogger.Warning($"Thong ke that bai: Khoang ngay khong hop le (Tu {tuNgay:dd/MM/yyyy} den {denNgay:dd/MM/yyyy}). Ly do: {thongBaoLoi}");
                    ThongBao.CanhBao(thongBaoLoi);
                    return;
                }

                string phuongThuc = cboTrangThai.Text;
                string tuKhoa = txtTimKiem.Text.Trim();

                DataTable dsHoaDon = thongKeBLL.LayDanhSachHoaDon(tuNgay, denNgay, phuongThuc, tuKhoa);

                dgvHoaDon.Rows.Clear();

                foreach (DataRow row in dsHoaDon.Rows)
                {
                    int index = dgvHoaDon.Rows.Add();

                    dgvHoaDon.Rows[index].Cells["colHD_Ma"].Value = row["MaHoaDon"];
                    dgvHoaDon.Rows[index].Cells["colHD_NgayLap"].Value = Convert.ToDateTime(row["NgayLap"]).ToString("dd/MM/yyyy");
                    dgvHoaDon.Rows[index].Cells["colHD_KhachHang"].Value = row["TenKhachHang"] == DBNull.Value ? "Khách lẻ" : row["TenKhachHang"];
                    dgvHoaDon.Rows[index].Cells["colHD_TrangThai"].Value = row["PhuongThucThanhToan"];
                    dgvHoaDon.Rows[index].Cells["colHD_TongTien"].Value =
                        (row.IsNull("TongTien") ? 0 : Convert.ToDecimal(row["TongTien"])).ToString("N0") + " VNĐ";
                }

                DataTable tongQuan = thongKeBLL.LayThongTinTongQuan(tuNgay, denNgay, phuongThuc, tuKhoa);

                if (tongQuan.Rows.Count > 0)
                {
                    DataRow row = tongQuan.Rows[0];

                    int soHoaDon = row.IsNull("SoHoaDon") ? 0 : Convert.ToInt32(row["SoHoaDon"]);
                    decimal tongDoanhThu = row.IsNull("TongDoanhThu") ? 0 : Convert.ToDecimal(row["TongDoanhThu"]);
                    int soHoaDonHuy = row.IsNull("SoHoaDonHuy") ? 0 : Convert.ToInt32(row["SoHoaDonHuy"]);
                    decimal trungBinhDon = row.IsNull("TrungBinhDon") ? 0 : Convert.ToDecimal(row["TrungBinhDon"]);

                    lblSoHoaDon.Text = soHoaDon.ToString("N0");
                    lblTongDoanhThu.Text = tongDoanhThu.ToString("N0") + " VNĐ";
                    lblSoHoaDonHuy.Text = soHoaDonHuy.ToString("N0");
                    lblGiaTriTrungBinh.Text = trungBinhDon.ToString("N0") + " VNĐ";

                    // Ghi nhận log truy vấn thành công
                    AppLogger.Information($"Tai du lieu thong ke thanh cong: Tu {tuNgay:dd/MM/yyyy} den {denNgay:dd/MM/yyyy} | Tong HD: {soHoaDon} | Tong DT: {tongDoanhThu:N0} VND");
                }

                dgvChiTietHoaDon.Rows.Clear();
            }
            catch (Exception ex)
            {
                // Ghi log lỗi chi tiết kèm stack trace
                AppLogger.Error(ex, "Loi ngoai le khi thuc hien thong ke doanh thu.");
                ThongBao.LoiHeThong(ex, "Không thể tải dữ liệu thống kê. Vui lòng thử lại sau!", "FrmThongKe - ThucHienThongKe");
            }
        }

        private void btnThongKe_Click(object sender, EventArgs e)
        {
            AppLogger.Information("Nguoi dung nhan nut Thong ke.");
            ThucHienThongKe();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AppLogger.Information("Nguoi dung nhan nut Lam moi/Dat lai bo loc thong ke.");
            rdoHomNay.Checked = false;
            rdo7NgayGanNhat.Checked = false;
            rdo30NgayGanNhat.Checked = false;

            dtpTuNgay.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            dtpDenNgay.Value = DateTime.Now;

            cboTrangThai.SelectedIndex = 0;
            txtTimKiem.Clear();

            ThucHienThongKe();
        }

        private void dgvHoaDon_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            try
            {
                string maHoaDon = Convert.ToString(dgvHoaDon.Rows[e.RowIndex].Cells["colHD_Ma"].Value);
                if (string.IsNullOrWhiteSpace(maHoaDon)) return;

                DataTable chiTiet = thongKeBLL.LayChiTietHoaDon(maHoaDon);
                dgvChiTietHoaDon.Rows.Clear();

                foreach (DataRow row in chiTiet.Rows)
                {
                    int index = dgvChiTietHoaDon.Rows.Add();

                    dgvChiTietHoaDon.Rows[index].Cells["colCT_STT"].Value = row["STT"];
                    dgvChiTietHoaDon.Rows[index].Cells["colCT_MaSP"].Value = row["MaSanPham"];

                    if (dgvChiTietHoaDon.Columns.Contains("colCT_TenSP"))
                        dgvChiTietHoaDon.Rows[index].Cells["colCT_TenSP"].Value = row["TenSanPham"];

                    if (dgvChiTietHoaDon.Columns.Contains("colCT_DVT"))
                        dgvChiTietHoaDon.Rows[index].Cells["colCT_DVT"].Value = row["DonViTinh"];

                    dgvChiTietHoaDon.Rows[index].Cells["colCT_SoLuong"].Value = row["SoLuong"];
                    dgvChiTietHoaDon.Rows[index].Cells["colCT_ThanhTien"].Value =
                        Convert.ToDecimal(row["ThanhTien"]).ToString("N0");
                }

                // Ghi log khi nhân viên tra cứu hóa đơn cụ thể
                AppLogger.Debug($"Nguoi dung xem chi tiet hoa don: {maHoaDon} ({chiTiet.Rows.Count} san pham).");
            }
            catch (Exception ex)
            {
                AppLogger.Error(ex, "Loi khi tai chi tiet hoa don tai FrmThongKe.");
                ThongBao.LoiHeThong(ex, "Không thể tải chi tiết hóa đơn này.", "FrmThongKe - dgvHoaDon_CellClick");
            }
        }

        private void btnXuatBaoCao_Click(object sender, EventArgs e)
        {
            if (dgvHoaDon.Rows.Count == 0)
            {
                AppLogger.Warning("Xuat bao cao that bai: Khong co du lieu hoa don tren bang.");
                ThongBao.ThongTin("Không có dữ liệu hóa đơn để xuất.");
                return;
            }

            using (SaveFileDialog saveDialog = new SaveFileDialog())
            {
                saveDialog.Filter = "Excel CSV (*.csv)|*.csv";
                saveDialog.FileName = "BaoCaoThongKe_" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".csv";

                if (saveDialog.ShowDialog() != DialogResult.OK)
                {
                    AppLogger.Debug("Nguoi dung da huy hop thoai chon file luu bao cao CSV.");
                    return;
                }

                try
                {
                    DateTime tuNgay = dtpTuNgay.Value.Date;
                    DateTime denNgay = dtpDenNgay.Value.Date;
                    string phuongThuc = cboTrangThai.Text;
                    string tuKhoa = txtTimKiem.Text.Trim();

                    // Lấy dữ liệu và tạo nội dung CSV thông qua BLL
                    DataTable dsHoaDon = thongKeBLL.LayDanhSachHoaDon(tuNgay, denNgay, phuongThuc, tuKhoa);
                    string noiDungCsv = thongKeBLL.TaoNoiDungBaoCaoCsv(dsHoaDon);

                    File.WriteAllText(saveDialog.FileName, noiDungCsv, new UTF8Encoding(true));

                    // Ghi log xuất file thành công
                    AppLogger.Information($"Xuat bao cao CSV thanh cong: {Path.GetFileName(saveDialog.FileName)} voi {dsHoaDon.Rows.Count} hoa don.");

                    ThongBao.ThanhCong("Xuất báo cáo doanh thu thành công!");
                }
                catch (Exception ex)
                {
                    AppLogger.Error(ex, "Loi khi xuat file bao cao thong ke CSV.");
                    ThongBao.LoiHeThong(ex, "Không thể lưu file báo cáo. Vui lòng kiểm tra quyền truy cập thư mục!", "FrmThongKe - btnXuatBaoCao_Click");
                }
            }
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            AppLogger.Information("Dong FrmThongKe.");
            Close();
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            try
            {
                AppLogger.Information("Dieu huong ve FrmTrangChu tu FrmThongKe.");
                FrmTrangChu frmHome = new FrmTrangChu();
                frmHome.FormClosed += (s, args) => this.Close();
                this.Hide();
                frmHome.Show();
            }
            catch (Exception ex)
            {
                AppLogger.Error(ex, "Loi khi dieu huong ve FrmTrangChu tu FrmThongKe.");
                ThongBao.LoiHeThong(ex, "Không thể chuyển về Trang Chủ.", "FrmThongKe - btnHome_Click");
                this.Show();
            }
        }
    }
}