using QuanLyBanHang.BLL;
using QuanLyBanHang.DAL;
using QuanLyBanHang.UI.Helpers; // Khai báo namespace ThongBao
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
        private NhapHangBLL bll = new NhapHangBLL();

        public FrmNhapHang()
        {
            InitializeComponent();
        }

        private void FrmNhapHang_Load(object sender, EventArgs e)
        {
            dtpNgayNhap.Value = DateTime.Now;
            txtMaPN.Text = "PN" + DateTime.Now.ToString("yyyyMMddHHmmss");
            ChinhSuaGiaoDienNutBấm();
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
                DataTable dtNCC = bll.LayDanhSachNhaCungCap();
                DataTable dtSP = bll.LayDanhSachSanPham();

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
                ThongBao.LoiHeThong(ex, "Lỗi tải dữ liệu danh mục cho phiếu nhập.", "FrmNhapHang");
            }
        }

        private void btnThemChiTiet_Click(object sender, EventArgs e)
        {
            if (cboSanPham.SelectedValue == null || string.IsNullOrWhiteSpace(txtSoLuong.Text) || string.IsNullOrWhiteSpace(txtGiaNhap.Text))
            {
                ThongBao.CanhBao("Vui lòng chọn sản phẩm, nhập số lượng và giá nhập!");
                return;
            }

            try
            {
                string maSP = cboSanPham.SelectedValue.ToString();
                string tenSP = cboSanPham.Text;
                int soLuong = int.Parse(txtSoLuong.Text);
                decimal giaNhap = decimal.Parse(txtGiaNhap.Text);

                decimal thanhTien = soLuong * giaNhap;

                dgvChiTietNhap.Rows.Add(maSP, tenSP, soLuong, giaNhap.ToString("N0"), thanhTien.ToString("N0"));
                TinhTongTien();

                txtSoLuong.Clear();
                txtGiaNhap.Clear();
                cboSanPham.Focus();
            }
            catch (Exception ex)
            {
                ThongBao.LoiHeThong(ex, "Dữ liệu số lượng hoặc giá nhập không hợp lệ.", "FrmNhapHang");
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
            if (dgvChiTietNhap.Rows.Count == 0)
            {
                ThongBao.CanhBao("Phiếu nhập chưa có sản phẩm nào để lưu!");
                return;
            }

            if (cboNhaCungCap.SelectedValue == null)
            {
                ThongBao.CanhBao("Vui lòng chọn nhà cung cấp!");
                return;
            }

            try
            {
                string maPN = txtMaPN.Text;
                DateTime ngayNhap = dtpNgayNhap.Value;
                string maNCC = cboNhaCungCap.SelectedValue?.ToString() ?? "";
                int maTaiKhoan = 1;

                DataTable dtChiTiet = new DataTable();
                dtChiTiet.Columns.Add("MaSanPham", typeof(string));
                dtChiTiet.Columns.Add("SoLuong", typeof(int));
                dtChiTiet.Columns.Add("GiaNhap", typeof(decimal));
                dtChiTiet.Columns.Add("ThanhTien", typeof(decimal));

                foreach (DataGridViewRow row in dgvChiTietNhap.Rows)
                {
                    if (row.Cells[0].Value != null)
                    {
                        string maSP = row.Cells[0].Value.ToString();
                        int soLuong = Convert.ToInt32(row.Cells[2].Value);
                        decimal giaNhap = Convert.ToDecimal(row.Cells[3].Value.ToString().Replace(",", ""));
                        decimal thanhTien = Convert.ToDecimal(row.Cells[4].Value.ToString().Replace(",", ""));

                        dtChiTiet.Rows.Add(maSP, soLuong, giaNhap, thanhTien);
                    }
                }

                bool ketQua = bll.ThemPhieuNhap(maPN, ngayNhap, maNCC, maTaiKhoan, dtChiTiet);

                if (ketQua)
                {
                    ThongBao.ThanhCong("Lưu phiếu nhập và cập nhật tồn kho thành công!");

                    dgvChiTietNhap.Rows.Clear();
                    txtMaPN.Text = "PN" + DateTime.Now.ToString("yyyyMMddHHmmss");
                    lblTongTien.Text = "Tổng tiền cần thanh toán: 0 VNĐ";
                    cboNhaCungCap.SelectedIndex = -1;
                    cboSanPham.SelectedIndex = -1;
                }
                else
                {
                    ThongBao.CanhBao("Lưu phiếu nhập thất bại, vui lòng kiểm tra lại!");
                }
            }
            catch (Exception ex)
            {
                ThongBao.LoiHeThong(ex, "Lỗi hệ thống khi lưu phiếu nhập.", "FrmNhapHang");
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            txtMaPN.Text = "PN" + DateTime.Now.ToString("yyyyMMddHHmmss");
            dtpNgayNhap.Value = DateTime.Now;
            cboNhaCungCap.SelectedIndex = -1;
            cboSanPham.SelectedIndex = -1;
            txtSoLuong.Clear();
            txtGiaNhap.Clear();

            Control[] foundControls = Controls.Find("txtMaNV", true);
            if (foundControls.Length > 0 && foundControls[0] is TextBox txtMaNV)
            {
                txtMaNV.Clear();
            }

            dgvChiTietNhap.DataSource = null;
            dgvChiTietNhap.Columns.Clear();
            dgvChiTietNhap.Columns.Add("MaSP", "Mã SP");
            dgvChiTietNhap.Columns.Add("TenSP", "Tên sản phẩm");
            dgvChiTietNhap.Columns.Add("SoLuong", "Số lượng");
            dgvChiTietNhap.Columns.Add("GiaNhap", "Giá nhập");
            dgvChiTietNhap.Columns.Add("ThanhTien", "Thành tiền");

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
                DataTable dtPhieuNhap = bll.LayDanhSachPhieuNhap();

                if (dtPhieuNhap.Rows.Count > 0)
                {
                    dgvChiTietNhap.Columns.Clear();
                    dgvChiTietNhap.DataSource = dtPhieuNhap;

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
                    ThongBao.ThongTin("Chưa có phiếu nhập nào được lưu trong hệ thống!");
                }
            }
            catch (Exception ex)
            {
                ThongBao.LoiHeThong(ex, "Lỗi hiển thị danh sách phiếu nhập.", "FrmNhapHang");
            }
        }

        private void btnXoaPhieu_Click(object sender, EventArgs e)
        {
            if (dgvChiTietNhap.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dgvChiTietNhap.SelectedRows[0];

                if (dgvChiTietNhap.Columns.Contains("MaPhieuNhap") && row.Cells["MaPhieuNhap"].Value != null)
                {
                    string maPN = row.Cells["MaPhieuNhap"].Value?.ToString() ?? "";

                    if (ThongBao.XacNhan($"Bạn có chắc chắn muốn XÓA VĨNH VIỄN phiếu nhập [{maPN}] này khỏi cơ sở dữ liệu không?", "Cảnh báo xóa"))
                    {
                        try
                        {
                            bool kq = bll.XoaPhieuNhap(maPN);

                            if (kq)
                            {
                                ThongBao.ThanhCong($"Đã xóa thành công phiếu nhập [{maPN}] khỏi hệ thống!");
                                btnXemDanhSach_Click(sender, e);
                            }
                            else
                            {
                                ThongBao.CanhBao("Xóa phiếu nhập thất bại trong cơ sở dữ liệu!");
                            }
                        }
                        catch (Exception ex)
                        {
                            ThongBao.LoiHeThong(ex, "Lỗi hệ thống khi xóa phiếu nhập.", "FrmNhapHang");
                        }
                    }
                }
                else
                {
                    ThongBao.CanhBao("Vui lòng bấm 'Xem danh sách đã lưu' trước, sau đó chọn một phiếu nhập trên bảng để xóa!");
                }
            }
            else
            {
                ThongBao.CanhBao("Vui lòng chọn dòng phiếu nhập cần xóa trên bảng!");
            }
        }
    }
}