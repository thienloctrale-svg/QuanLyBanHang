using QuanLyBanHang.DAL;
using QuanLyBanHang.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyBanHang.UI
{
    public partial class FrmNhapHang : Form
    {
        public FrmNhapHang()
        {
            InitializeComponent();
        }

        private void FrmNhapHang_Load(object sender, EventArgs e)
        {
            dtpNgayNhap.Value = DateTime.Now;
            txtMaPN.Text = "PN" + DateTime.Now.ToString("yyyyMMddHHmmss");
            ChinhSuaGiaoDienNutBấm();

            // Gọi hàm load combobox
            LoadComboBoxData();
        }

        private void ChinhSuaGiaoDienNutBấm()
        {
            btnLuu.BackColor = Color.FromArgb(46, 204, 113);
            btnLuu.ForeColor = Color.White;
            btnLuu.FlatStyle = FlatStyle.Flat;
            btnLuu.FlatAppearance.BorderSize = 0;
            btnLuu.Font = new Font(btnLuu.Font, FontStyle.Bold);

            btnLamMoi.BackColor = Color.FromArgb(230, 126, 34);
            btnLamMoi.ForeColor = Color.White;
            btnLamMoi.FlatStyle = FlatStyle.Flat;
            btnLamMoi.FlatAppearance.BorderSize = 0;
            btnLamMoi.Font = new Font(btnLamMoi.Font, FontStyle.Bold);

            btnHome.BackColor = Color.FromArgb(41, 128, 185);
            btnHome.ForeColor = Color.White;
            btnHome.FlatStyle = FlatStyle.Flat;
            btnHome.FlatAppearance.BorderSize = 0;
            btnHome.Font = new Font(btnHome.Font, FontStyle.Bold);

            btnThemChiTiet.BackColor = Color.FromArgb(52, 73, 94);
            btnThemChiTiet.ForeColor = Color.White;
            btnThemChiTiet.FlatStyle = FlatStyle.Flat;
            btnThemChiTiet.FlatAppearance.BorderSize = 0;
            btnThemChiTiet.Font = new Font(btnThemChiTiet.Font, FontStyle.Bold);
        }

        private void LoadComboBoxData()
        {
            try
            {
                NhapHangDAL dal = new NhapHangDAL();

                DataTable dtNCC = dal.LayDanhSachNhaCungCap();
                DataTable dtSP = dal.LayDanhSachSanPham();

                cboNhaCungCap.DataSource = dtNCC;
                cboNhaCungCap.DisplayMember = "TenNCC";
                cboNhaCungCap.ValueMember = "MaNCC";

                cboSanPham.DataSource = dtSP;
                cboSanPham.DisplayMember = "TenSanPham";
                cboSanPham.ValueMember = "MaSanPham";

                cboNhaCungCap.SelectedIndex = -1;
                cboSanPham.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi chi tiết: " + ex.Message, "Lỗi kết nối", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnThemChiTiet_Click(object sender, EventArgs e)
        {
            // Kiểm tra xem đã chọn sản phẩm, nhập số lượng và giá chưa
            if (cboSanPham.SelectedValue == null || string.IsNullOrWhiteSpace(txtSoLuong.Text) || string.IsNullOrWhiteSpace(txtGiaNhap.Text))
            {
                MessageBox.Show("Vui lòng chọn sản phẩm, nhập số lượng và giá nhập!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                string maSP = cboSanPham.SelectedValue.ToString();
                string tenSP = cboSanPham.Text;
                int soLuong = int.Parse(txtSoLuong.Text);
                decimal giaNhap = decimal.Parse(txtGiaNhap.Text);

                decimal thanhTien = soLuong * giaNhap;

                // Thêm dữ liệu vào dòng mới của DataGridView
                dgvChiTietNhap.Rows.Add(maSP, tenSP, soLuong, giaNhap.ToString("N0"), thanhTien.ToString("N0"));

                // Tính lại tổng tiền
                TinhTongTien();

                // Xóa trắng ô nhập liệu để nhập tiếp món khác
                txtSoLuong.Clear();
                txtGiaNhap.Clear();
                cboSanPham.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Dữ liệu nhập không hợp lệ: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void TinhTongTien()
        {
            decimal tongTien = 0;
            foreach (DataGridViewRow row in dgvChiTietNhap.Rows)
            {
                if (row.Cells["ThanhTien"].Value != null)
                {
                    decimal tien = Convert.ToDecimal(row.Cells["ThanhTien"].Value.ToString().Replace(",", ""));
                    tongTien += tien;
                }
            }
            lblTongTien.Text = "Tổng tiền cần thanh toán: " + tongTien.ToString("N0") + " VNĐ";
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            // 1. Kiểm tra xem đã có sản phẩm nào trên lưới chưa
            if (dgvChiTietNhap.Rows.Count == 0)
            {
                MessageBox.Show("Phiếu nhập chưa có sản phẩm nào để lưu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 2. Kiểm tra xem đã chọn Nhà cung cấp chưa
            if (cboNhaCungCap.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn nhà cung cấp!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                string maPN = txtMaPN.Text;
                DateTime ngayNhap = dtpNgayNhap.Value;
                string maNCC = cboNhaCungCap.SelectedValue.ToString();
                int maTaiKhoan = 1; // (Hoặc lấy mã tài khoản của nhân viên đang đăng nhập hệ thống)

                // 3. Đưa dữ liệu từ DataGridView vào một DataTable để truyền xuống DAL
                DataTable dtChiTiet = new DataTable();
                dtChiTiet.Columns.Add("MaSanPham", typeof(string));
                dtChiTiet.Columns.Add("SoLuong", typeof(int));
                dtChiTiet.Columns.Add("GiaNhap", typeof(decimal));
                dtChiTiet.Columns.Add("ThanhTien", typeof(decimal));

                foreach (DataGridViewRow row in dgvChiTietNhap.Rows)
                {
                    // Bỏ qua dòng trống (nếu có)
                    if (row.Cells[0].Value != null)
                    {
                        string maSP = row.Cells[0].Value.ToString();
                        int soLuong = Convert.ToInt32(row.Cells[2].Value);
                        decimal giaNhap = Convert.ToDecimal(row.Cells[3].Value.ToString().Replace(",", ""));
                        decimal thanhTien = Convert.ToDecimal(row.Cells[4].Value.ToString().Replace(",", ""));

                        dtChiTiet.Rows.Add(maSP, soLuong, giaNhap, thanhTien);
                    }
                }

                // 4. Gọi hàm từ NhapHangDAL để lưu xuống CSDL và cập nhật tồn kho
                NhapHangDAL dal = new NhapHangDAL();
                bool ketQua = dal.ThemPhieuNhap(maPN, ngayNhap, maNCC, maTaiKhoan, dtChiTiet);

                if (ketQua)
                {
                    MessageBox.Show("Lưu phiếu nhập và cập nhật tồn kho thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Reset form sau khi lưu thành công
                    dgvChiTietNhap.Rows.Clear();
                    txtMaPN.Text = "PN" + DateTime.Now.ToString("yyyyMMddHHmmss");
                    lblTongTien.Text = "Tổng tiền cần thanh toán: 0 VNĐ";
                    cboNhaCungCap.SelectedIndex = -1;
                    cboSanPham.SelectedIndex = -1;
                }
                else
                {
                    MessageBox.Show("Lưu phiếu nhập thất bại, vui lòng kiểm tra lại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            // 1. Sinh mã phiếu nhập mới
            txtMaPN.Text = "PN" + DateTime.Now.ToString("yyyyMMddHHmmss");

            // 2. Đặt lại ngày hiện tại
            dtpNgayNhap.Value = DateTime.Now;

            // 3. Bỏ chọn các ComboBox
            cboNhaCungCap.SelectedIndex = -1;
            cboSanPham.SelectedIndex = -1;

            // 4. Xóa trắng các ô nhập liệu
            txtSoLuong.Clear();
            txtGiaNhap.Clear();
            txtMaNV.Clear();

            // 5. Khôi phục lại các cột nhập chi tiết sản phẩm trên lưới
            dgvChiTietNhap.DataSource = null;
            dgvChiTietNhap.Columns.Clear();
            dgvChiTietNhap.Columns.Add("MaSP", "Mã SP");
            dgvChiTietNhap.Columns.Add("TenSP", "Tên sản phẩm");
            dgvChiTietNhap.Columns.Add("SoLuong", "Số lượng");
            dgvChiTietNhap.Columns.Add("GiaNhap", "Giá nhập");
            dgvChiTietNhap.Columns.Add("ThanhTien", "Thành tiền");

            // 6. Đặt lại tổng tiền về 0
            lblTongTien.Text = "Tổng tiền cần thanh toán: 0 VNĐ";
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            FrmTrangChu frmTrangChu = new FrmTrangChu();
            frmTrangChu.Show();
            this.Hide();
        }

        private void btnXemDanhSach_Click(object sender, EventArgs e)
        {
            try
            {
                NhapHangDAL dal = new NhapHangDAL();
                DataTable dtPhieuNhap = dal.LayDanhSachPhieuNhap();

                if (dtPhieuNhap.Rows.Count > 0)
                {
                    // ⚠️ Xóa toàn bộ cấu hình cột cũ đi để lưới nhận hoàn toàn cột mới của danh sách phiếu nhập
                    dgvChiTietNhap.Columns.Clear();
                    dgvChiTietNhap.DataSource = dtPhieuNhap;

                    // Đổi lại tiêu đề tiếng Việt cho đẹp
                    if (dgvChiTietNhap.Columns["MaPhieuNhap"] != null)
                        dgvChiTietNhap.Columns["MaPhieuNhap"].HeaderText = "Mã Phiếu Nhập";
                    if (dgvChiTietNhap.Columns["NgayNhap"] != null)
                        dgvChiTietNhap.Columns["NgayNhap"].HeaderText = "Ngày Nhập";
                    if (dgvChiTietNhap.Columns["TenNCC"] != null)
                        dgvChiTietNhap.Columns["TenNCC"].HeaderText = "Nhà Cung Cấp";
                    if (dgvChiTietNhap.Columns["TongTien"] != null)
                    {
                        dgvChiTietNhap.Columns["TongTien"].HeaderText = "Tổng Tiền";
                        dgvChiTietNhap.Columns["TongTien"].DefaultCellStyle.Format = "N0";
                    }
                }
                else
                {
                    MessageBox.Show("Chưa có phiếu nhập nào được lưu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi hiển thị danh sách: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnXoaPhieu_Click(object sender, EventArgs e)
        {
            // Kiểm tra xem người dùng đã chọn dòng nào trên lưới chưa
            if (dgvChiTietNhap.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dgvChiTietNhap.SelectedRows[0];

                // Kiểm tra xem trên lưới đang hiển thị danh sách phiếu nhập (có cột MaPhieuNhap)
                if (dgvChiTietNhap.Columns.Contains("MaPhieuNhap") && row.Cells["MaPhieuNhap"].Value != null)
                {
                    string maPN = row.Cells["MaPhieuNhap"].Value.ToString();

                    // Hộp thoại xác nhận trước khi xóa trong CSDL
                    DialogResult dialogResult = MessageBox.Show($"Bạn có chắc chắn muốn XÓA VĨNH VIỄN phiếu nhập [{maPN}] này khỏi cơ sở dữ liệu không?", "Cảnh báo xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                    if (dialogResult == DialogResult.Yes)
                    {
                        try
                        {
                            NhapHangDAL dal = new NhapHangDAL();

                            // 1. GỌI HÀM XÓA TRONG CƠ SỞ DỮ LIỆU SQL SERVER
                            bool kq = dal.XoaPhieuNhap(maPN);

                            if (kq)
                            {
                                MessageBox.Show($"Đã xóa thành công phiếu nhập [{maPN}] khỏi hệ thống!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                // 2. TẢI LẠI DANH SÁCH ĐÃ LƯU ĐỂ CẬP NHẬT LƯỚI NGAY LẬP TỨC
                                btnXemDanhSach_Click(sender, e);
                            }
                            else
                            {
                                MessageBox.Show("Xóa phiếu nhập thất bại trong cơ sở dữ liệu!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Lỗi hệ thống khi xóa: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Vui lòng bấm 'Xem danh sách đã lưu' trước, sau đó chọn một phiếu nhập trên bảng để xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn dòng phiếu nhập cần xóa trên bảng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}