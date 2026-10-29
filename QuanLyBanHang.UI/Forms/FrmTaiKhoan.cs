using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLyBanHang.BLL;

namespace QuanLyBanHang.UI
{
    public partial class FrmTaiKhoan : Form
    {
        private TaiKhoanBLL bll = new TaiKhoanBLL();
        public FrmTaiKhoan()
        {
            InitializeComponent();

            // Mặc định ẩn mật khẩu
            txtmk.UseSystemPasswordChar = true;
            checkmk.Checked = false;

            // Gọi trực tiếp các hàm load ở đây để chắc chắn nó chạy 100%
            LoadComboBoxVaiTro();
            LoadDataGrid();
            ResetForm();

        }
        private void FrmTaiKhoan_Load(object sender, EventArgs e)
        {
            // Thiết lập ẩn mật khẩu ban đầu
            txtmk.UseSystemPasswordChar = true;
            checkmk.Checked = false;

            // Nạp dữ liệu ComboBox Vai trò & CSDL
            LoadComboBoxVaiTro();
            LoadDataGrid();
            ResetForm();
        }

        // Load ComboBox Vai Trò
        private void LoadComboBoxVaiTro()
        {
            cbvaitro.Items.Clear();
            cbvaitro.Items.Add("Quản trị viên");
            cbvaitro.Items.Add("Nhóm trưởng");
            cbvaitro.Items.Add("Nhân viên");
            cbvaitro.SelectedIndex = 2; // Mặc định 'Nhân viên'
        }
        private void LoadDataGrid()
        {
            try
            {
                dgvTaiKhoan.AutoGenerateColumns = true; // dòng này để bảng tự động tạo cột chuẩn theo SQL
                dgvTaiKhoan.DataSource = bll.LayDanhSachTaiKhoan();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Reset toàn bộ các ô nhập liệu
        private void ResetForm()
        {
            txtma.Clear();
            txttendn.Clear();
            txthoten.Clear();
            txtmk.Clear();
            txtsdt.Clear();
            txtmail.Clear();

            txtma.Enabled = false; // Mã tự tăng trong SQL nên không cho gõ
            dtngaytao.Value = DateTime.Now; // Ngày tạo luôn là ngày hiện tại
            checktrangthai.Checked = true; // Mặc định Hoạt động
            checkmk.Checked = false;
            txtmk.UseSystemPasswordChar = true;

            txttendn.Enabled = true;
            cbvaitro.SelectedIndex = 2;
            txttendn.Focus();
        }

        // 2. Click chọn dòng trên DataGridView -> Hiện thông tin đầy đủ lên trên
        private void dgvTaiKhoan_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Kiểm tra click dòng hợp lệ (tránh click vào tiêu đề)
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvTaiKhoan.Rows[e.RowIndex];

                // Lấy dữ liệu theo thứ tự cột chuẩn từ SQL:
                // 0: MaTaiKhoan, 1: TenDangNhap, 2: MatKhau, 3: HoTen, 4: Email, 5: SoDienThoai, 6: VaiTro, 7: TrangThai, 8: NgayTao
                txtma.Text = row.Cells[0].Value?.ToString() ?? "";
                txttendn.Text = row.Cells[1].Value?.ToString() ?? "";
                txtmk.Text = row.Cells[2].Value?.ToString() ?? "";
                txthoten.Text = row.Cells[3].Value?.ToString() ?? "";
                txtmail.Text = row.Cells[4].Value?.ToString() ?? "";
                txtsdt.Text = row.Cells[5].Value?.ToString() ?? "";

                // Vai trò (ComboBox)
                if (row.Cells[6].Value != null)
                {
                    cbvaitro.Text = row.Cells[6].Value.ToString();
                }

                // Trạng thái (CheckBox)
                if (row.Cells[7].Value != null)
                {
                    string trangThai = row.Cells[7].Value.ToString();
                    checktrangthai.Checked = (trangThai.Contains("Hoạt động") || trangThai == "True" || trangThai == "Đang hoạt động");
                }

                // Ngày tạo (DateTimePicker)
                if (row.Cells[8].Value != null && row.Cells[8].Value != DBNull.Value)
                {
                    dtngaytao.Value = Convert.ToDateTime(row.Cells[8].Value);
                }

                // Khóa tên đăng nhập không cho sửa khi đang chọn dòng cập nhật
                txttendn.Enabled = false;
            }
        }
        private void lblma_Click(object sender, EventArgs e)
        {

        }

        private void gbthongtinngoai_Enter(object sender, EventArgs e)
        {

        }

        private void lblmk_Click(object sender, EventArgs e)
        {

        }

        private void lblmail_Click(object sender, EventArgs e)
        {

        }

        private void checkmk_CheckedChanged(object sender, EventArgs e)
        {
            txtmk.UseSystemPasswordChar = !checkmk.Checked;
        }

        private void txttendn_TextChanged(object sender, EventArgs e)
        {

        }

        private void txthoten_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtmk_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtsdt_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtmail_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtma_TextChanged(object sender, EventArgs e)
        {

        }

        private void dtngaytao_ValueChanged(object sender, EventArgs e)
        {

        }

        private void cbvaitro_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void checktrangthai_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Kiểm tra xem người dùng có click vào dòng hợp lệ không (tránh click nhấp vào tiêu đề cột)
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvTaiKhoan.Rows[e.RowIndex];

                // Đổ dữ liệu từ các cột lên các control tương ứng
                txtma.Text = row.Cells["MaTaiKhoan"].Value?.ToString() ?? "";
                txttendn.Text = row.Cells["TenDangNhap"].Value?.ToString() ?? "";
                txthoten.Text = row.Cells["HoTen"].Value?.ToString() ?? "";
                txtmk.Text = row.Cells["MatKhau"].Value?.ToString() ?? "";
                txtsdt.Text = row.Cells["SoDienThoai"].Value?.ToString() ?? "";
                txtmail.Text = row.Cells["Email"].Value?.ToString() ?? "";

                // ComboBox Vai trò
                if (row.Cells["VaiTro"].Value != null)
                {
                    cbvaitro.Text = row.Cells["VaiTro"].Value.ToString();
                }

                // CheckBox Trạng thái (Giả sử trong SQL lưu chữ "Đang hoạt động" hoặc tương tự)
                if (row.Cells["VaiTro"].Value != null)
                {
                    string trangThai = row.Cells["TrangThai"].Value.ToString();
                    checktrangthai.Checked = (trangThai.Contains("Hoạt động") || trangThai == "True");
                }

                // DateTimePicker Ngày tạo
                if (row.Cells["NgayTao"].Value != null && row.Cells["NgayTao"].Value != DBNull.Value)
                {
                    dtngaytao.Value = Convert.ToDateTime(row.Cells["NgayTao"].Value);
                }

                // Khóa không cho sửa tên đăng nhập hoặc mã nếu đang chọn dòng để sửa
                txttendn.Enabled = false;
            }
        }

        private void btntrangchu_Click(object sender, EventArgs e)
        {
            // 1. Mở Form Trang Chủ lên
            FrmTrangChu frmHome = new FrmTrangChu();
            frmHome.Show();

            // 2. Ẩn Form quản lý tài khoản hiện tại thay vì dùng Close()
            this.Hide();
        }

        private void btnthem_Click(object sender, EventArgs e)
        {
            string username = txttendn.Text.Trim();
            string pass = txtmk.Text.Trim();
            string hoTen = txthoten.Text.Trim();
            string email = txtmail.Text.Trim();
            string sdt = txtsdt.Text.Trim();
            string vaiTro = cbvaitro.Text;
            string trangThai = checktrangthai.Checked ? "Đang hoạt động" : "Đã khóa";

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(pass) || string.IsNullOrEmpty(hoTen))
            {
                MessageBox.Show("Vui lòng điền đầy đủ Tên đăng nhập, Mật khẩu và Họ tên!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (bll.ThemTaiKhoan(username, pass, hoTen, email, sdt, vaiTro, trangThai))
            {
                MessageBox.Show("Thêm tài khoản thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadDataGrid();
                ResetForm();
            }
            else
            {
                MessageBox.Show("Thêm thất bại (Tên đăng nhập đã tồn tại hoặc lỗi CSDL).", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnsua_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtma.Text))
            {
                MessageBox.Show("Vui lòng chọn một dòng tài khoản từ danh sách để sửa!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int maTK = int.Parse(txtma.Text);
            string hoTen = txthoten.Text.Trim();
            string pass = txtmk.Text.Trim();
            string email = txtmail.Text.Trim();
            string sdt = txtsdt.Text.Trim();
            string vaiTro = cbvaitro.Text;
            string trangThai = checktrangthai.Checked ? "Đang hoạt động" : "Đã khóa";

            if (bll.SuaTaiKhoan(maTK, hoTen, pass, email, sdt, vaiTro, trangThai))
            {
                MessageBox.Show("Cập nhật thông tin tài khoản thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadDataGrid();
                ResetForm();
            }
            else
            {
                MessageBox.Show("Cập nhật thất bại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnkhoa_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtma.Text))
            {
                MessageBox.Show("Vui lòng chọn tài khoản cần thay đổi trạng thái!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int maTK = int.Parse(txtma.Text);

            // Đảo ngược trạng thái CheckBox
            bool trangThaiMoi = !checktrangthai.Checked;
            string trangThaiText = trangThaiMoi ? "Đang hoạt động" : "Đã khóa";

            if (bll.CapNhatTrangThai(maTK, trangThaiText))
            {
                checktrangthai.Checked = trangThaiMoi; // Cập nhật checkbox
                MessageBox.Show($"Đã đổi trạng thái tài khoản thành: [{trangThaiText}]!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadDataGrid(); // Đồng bộ lại DataGridView
            }
            else
            {
                MessageBox.Show("Lỗi cập nhật trạng thái.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnlammoi_Click(object sender, EventArgs e)
        {
            ResetForm();
            LoadDataGrid(); // Hiện dữ liệu mới nhất trong DataGridView
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Kiểm tra xem đã chọn dòng nào trên bảng chưa (dựa vào ô Mã tài khoản)
            if (string.IsNullOrEmpty(txtma.Text))
            {
                MessageBox.Show("Vui lòng chọn tài khoản cần xoá từ danh sách bên dưới!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Hiển thị hộp thoại cảnh báo trước khi xoá để tránh bấm nhầm
            DialogResult dr = MessageBox.Show($"Bạn có chắc chắn muốn xoá tài khoản có mã [{txtma.Text}] không?", "Xác nhận xoá", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dr == DialogResult.Yes)
            {
                try
                {
                    int maTK = Convert.ToInt32(txtma.Text);
                    bool ketQua = bll.XoaTaiKhoan(maTK);

                    if (ketQua)
                    {
                        MessageBox.Show("Xoá tài khoản thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Cập nhật lại DataGridView và làm sạch form
                        LoadDataGrid();
                        ResetForm();
                    }
                    else
                    {
                        MessageBox.Show("Xoá tài khoản thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi hệ thống: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
