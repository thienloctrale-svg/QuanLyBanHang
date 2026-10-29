using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;
using QuanLyBanHang.BLL;
using QuanLyBanHang.DAL;

namespace QuanLyBanHang.UI
{
    public partial class FrmSanPham : Form
    {
        private SanPhamBLL bll = new SanPhamBLL();

        public FrmSanPham()
        {
            InitializeComponent();
            dgvSanPham.CellClick += dgvSanPham_CellClick;
        }

        private void FrmSanPham_Load(object sender, EventArgs e)
        {
            dgvSanPham.AutoGenerateColumns = true; // Tự động sinh cột từ CSDL
            LoadComboBoxLoaiSanPham();
            LoadDataGrid();

            // Thiết lập trạng thái chữ mờ ban đầu cho ô tìm kiếm
            if (string.IsNullOrWhiteSpace(txtTimKiem.Text))
            {
                txtTimKiem.Text = "Tìm kiếm theo mã hoặc tên";
                txtTimKiem.ForeColor = Color.Gray;
            }
        }

        // Đổ dữ liệu vào ComboBox Loại sản phẩm (LSP01, LSP02...)
        private void LoadComboBoxLoaiSanPham()
        {
            try
            {
                using (SqlConnection conn = DbConnectionFactory.CreateConnection())
                {
                    string query = "SELECT MaLoaiSP, TenLoaiSP FROM LoaiSanPham";
                    SqlDataAdapter da = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    cboLoaiSanPham.DataSource = dt;
                    cboLoaiSanPham.DisplayMember = "TenLoaiSP";
                    cboLoaiSanPham.ValueMember = "MaLoaiSP";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải danh mục loại sản phẩm: " + ex.Message);
            }
        }

        // Tải danh sách sản phẩm lên DataGridView và tự động đổi tên tiếng Việt
        private void LoadDataGrid()
        {
            try
            {
                DataTable dt = bll.LayDanhSach();

                // Xóa sạch cột cũ trên giao diện thiết kế để tự động sinh cột mới chuẩn xác từ CSDL
                dgvSanPham.Columns.Clear();
                dgvSanPham.AutoGenerateColumns = true;

                dgvSanPham.DataSource = dt;

                // Đặt lại tên tiêu đề hiển thị tiếng Việt cho các cột
                if (dgvSanPham.Columns["MaSanPham"] != null)
                    dgvSanPham.Columns["MaSanPham"].HeaderText = "Mã SP";

                if (dgvSanPham.Columns["TenSanPham"] != null)
                    dgvSanPham.Columns["TenSanPham"].HeaderText = "Tên sản phẩm";

                if (dgvSanPham.Columns["TenLoaiSP"] != null)
                    dgvSanPham.Columns["TenLoaiSP"].HeaderText = "Loại sản phẩm";

                if (dgvSanPham.Columns["DonViTinh"] != null)
                    dgvSanPham.Columns["DonViTinh"].HeaderText = "Đơn vị tính";

                if (dgvSanPham.Columns["GiaNhap"] != null)
                    dgvSanPham.Columns["GiaNhap"].HeaderText = "Giá nhập";

                if (dgvSanPham.Columns["GiaBan"] != null)
                    dgvSanPham.Columns["GiaBan"].HeaderText = "Giá bán";

                if (dgvSanPham.Columns["SoLuongTon"] != null)
                    dgvSanPham.Columns["SoLuongTon"].HeaderText = "Số lượng tồn";

                if (dgvSanPham.Columns["TrangThai"] != null)
                    dgvSanPham.Columns["TrangThai"].HeaderText = "Trạng thái";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải danh sách sản phẩm: " + ex.Message);
            }
        }
        // Sự kiện Thêm sản phẩm
        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                string ma = txtMaSanPham.Text.Trim();
                string ten = txtTenSanPham.Text.Trim();
                string maloai = cboLoaiSanPham.SelectedValue?.ToString() ?? "";
                string dvt = txtDonViTinh.Text.Trim();
                decimal gn = decimal.Parse(txtGiaNhap.Text);
                decimal gb = decimal.Parse(txtGiaBan.Text);
                int sl = int.Parse(txtSoLuongTon.Text);
                string tt = "Đang kinh doanh";

                if (bll.Them(ma, ten, maloai, dvt, gn, gb, sl, tt))
                {
                    MessageBox.Show("Thêm sản phẩm thành công!");
                    LoadDataGrid();
                    btnLamMoi_Click(sender, e);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi thêm sản phẩm: " + ex.Message);
            }
        }

        // Sự kiện Sửa sản phẩm
        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                string ma = txtMaSanPham.Text.Trim();
                string ten = txtTenSanPham.Text.Trim();
                string maloai = cboLoaiSanPham.SelectedValue?.ToString() ?? "";
                string dvt = txtDonViTinh.Text.Trim();
                decimal gn = decimal.Parse(txtGiaNhap.Text);
                decimal gb = decimal.Parse(txtGiaBan.Text);
                int sl = int.Parse(txtSoLuongTon.Text);
                string tt = "Đang kinh doanh";

                if (bll.Sua(ma, ten, maloai, dvt, gn, gb, sl, tt))
                {
                    MessageBox.Show("Cập nhật sản phẩm thành công!");
                    LoadDataGrid();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi sửa sản phẩm: " + ex.Message);
            }
        }

        // Sự kiện Xóa sản phẩm
        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                string ma = txtMaSanPham.Text.Trim();
                if (MessageBox.Show("Bạn có chắc chắn muốn xóa sản phẩm này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    if (bll.Xoa(ma))
                    {
                        MessageBox.Show("Xóa sản phẩm thành công!");
                        LoadDataGrid();
                        btnLamMoi_Click(sender, e);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không thể xóa vì sản phẩm này đã phát sinh hóa đơn hoặc phiếu nhập: " + ex.Message);
            }
        }

        // Sự kiện Tìm kiếm sản phẩm
        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string tuKhoa = txtTimKiem.Text.Trim();
            if (tuKhoa == "Tìm kiếm theo mã hoặc tên")
            {
                tuKhoa = "";
            }
            dgvSanPham.DataSource = bll.TimKiem(tuKhoa);
        }

        // Sự kiện Làm mới form
        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            txtMaSanPham.Clear();
            txtTenSanPham.Clear();
            txtDonViTinh.Clear();
            txtGiaNhap.Clear();
            txtGiaBan.Clear();
            txtSoLuongTon.Clear();

            txtTimKiem.Text = "Tìm kiếm theo mã hoặc tên";
            txtTimKiem.ForeColor = Color.Gray;

            txtMaSanPham.Enabled = true; // Mở lại ô khóa mã để nhập mới
            LoadDataGrid();
            txtMaSanPham.Focus();
        }

        // Click chọn dòng trên DataGridView để đưa dữ liệu lên các ô nhập
        private void dgvSanPham_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvSanPham.Rows[e.RowIndex];

                // Đổ dữ liệu lên các ô TextBox
                txtMaSanPham.Text = row.Cells["MaSanPham"]?.Value?.ToString() ?? "";
                txtTenSanPham.Text = row.Cells["TenSanPham"]?.Value?.ToString() ?? "";
                txtDonViTinh.Text = row.Cells["DonViTinh"]?.Value?.ToString() ?? "";
                txtGiaNhap.Text = row.Cells["GiaNhap"]?.Value?.ToString() ?? "";
                txtGiaBan.Text = row.Cells["GiaBan"]?.Value?.ToString() ?? "";
                txtSoLuongTon.Text = row.Cells["SoLuongTon"]?.Value?.ToString() ?? "";

                // TỰ ĐỘNG CHỌN ĐÚNG LOẠI SẢN PHẨM TRÊN COMBOBOX THEO DÒNG ĐƯỢC CLICK
                // (Giả sử trong DataTable kết quả SELECT có cột MaLoaiSP)
                if (row.Cells["MaLoaiSP"]?.Value != null)
                {
                    cboLoaiSanPham.SelectedValue = row.Cells["MaLoaiSP"].Value.ToString();
                }

                // Khóa ô Mã sản phẩm lại không cho sửa mã chính khi đang chọn dòng cũ để cập nhật
                txtMaSanPham.Enabled = false;
            }
        }
        // Hiệu ứng chữ mờ cho ô tìm kiếm
        private void txtTimKiem_Enter(object sender, EventArgs e)
        {
            if (txtTimKiem.Text == "Tìm kiếm theo mã hoặc tên")
            {
                txtTimKiem.Text = "";
                txtTimKiem.ForeColor = Color.Black; // Đổi sang chữ đen để gõ
            }
        }

        private void txtTimKiem_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTimKiem.Text))
            {
                txtTimKiem.Text = "Tìm kiếm theo mã hoặc tên";
                txtTimKiem.ForeColor = Color.Gray; // Đổi sang màu xám cho giống chữ mờ
            }
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            // 1. Khởi tạo form Trang chủ với tên chính xác FrmTrangChu
            FrmTrangChu frmTrangChu = new FrmTrangChu();

            // 2. Hiển thị form trang chủ lên
            frmTrangChu.Show();

            // 3. Ẩn form quản lý sản phẩm hiện tại đi
            this.Hide();
        }
    }
}