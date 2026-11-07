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
using QuanLyBanHang.Logging;

namespace QuanLyBanHang.UI
{
    public partial class FrmTaiKhoan : Form
    {
        private TaiKhoanBLL bll = new TaiKhoanBLL();
        private bool isLoaded = false;
        public FrmTaiKhoan()
        {
            InitializeComponent();
            AppLogger.Information("Khoi tao FrmTaiKhoan.");
            ResetForm();
            txtmk.UseSystemPasswordChar = true;
            checkmk.Checked = false;

            // Đặt mặc định checkbox "Hoạt động" luôn bật sẵn khi mở form
            cbhd.Checked = true;

            // GẮN TRỰC TIẾP CÁC SỰ KIỆN TÌM KIẾM BẰNG CODE (Tránh lỗi chưa kết nối trong Designer)
            txttk.TextChanged -= txttk_TextChanged;
            txttk.TextChanged += txttk_TextChanged; ;

            txttk.KeyDown -= txttk_KeyDown;
            txttk.KeyDown += txttk_KeyDown;

            cbhd.CheckedChanged -= cbhd_CheckedChanged;
            cbhd.CheckedChanged += cbhd_CheckedChanged;

            btntim.Click -= btntim_Click;
            btntim.Click += btntim_Click;

            LoadComboBoxVaiTro();
            LoadDataGrid();
            isLoaded = true;

            // Gắn sự kiện Enter tuần tự cho các ô nhập liệu thông tin
            txttendn.KeyDown += txttendn_KeyDown;
            txthoten.KeyDown += txthoten_KeyDown;
            txtmk.KeyDown += txtmk_KeyDown;
            txtsdt.KeyDown += txtsdt_KeyDown;
            txtmail.KeyDown += txtmail_KeyDown;

            // Gắn sự kiện định dạng dữ liệu cho DataGridView
            dgvTaiKhoan.CellFormatting += dgvTaiKhoan_CellFormatting;
        }
        private void FrmTaiKhoan_Load(object sender, EventArgs e)
        {
            AppLogger.Information("Tai giao dien FrmTaiKhoan_Load.");
            ResetForm();
            txtmk.UseSystemPasswordChar = true;
            checkmk.Checked = false;

            // Đặt mặc định checkbox "Hoạt động" luôn bật sẵn khi mở form
            cbhd.Checked = true;

            // GẮN TRỰC TIẾP CÁC SỰ KIỆN TÌM KIẾM BẰNG CODE (Tránh lỗi chưa kết nối trong Designer)
            txttk.TextChanged -= txttk_TextChanged;
            txttk.TextChanged += txttk_TextChanged; ;

            txttk.KeyDown -= txttk_KeyDown;
            txttk.KeyDown += txttk_KeyDown;

            cbhd.CheckedChanged -= cbhd_CheckedChanged;
            cbhd.CheckedChanged += cbhd_CheckedChanged;

            btntim.Click -= btntim_Click;
            btntim.Click += btntim_Click;

            LoadComboBoxVaiTro();
            LoadDataGrid();
            isLoaded = true;

            // Gắn sự kiện Enter tuần tự cho các ô nhập liệu thông tin
            txttendn.KeyDown += txttendn_KeyDown;
            txthoten.KeyDown += txthoten_KeyDown;
            txtmk.KeyDown += txtmk_KeyDown;
            txtsdt.KeyDown += txtsdt_KeyDown;
            txtmail.KeyDown += txtmail_KeyDown;
        }
        private void txttendn_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txthoten.Focus();          // Nhảy sang ô Họ tên
                e.SuppressKeyPress = true; // Chặn tiếng bíp
            }
        }

        private void txthoten_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtmk.Focus();             // Nhảy sang ô Mật khẩu
                e.SuppressKeyPress = true;
            }
        }

        private void txtmk_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtsdt.Focus();            // Nhảy sang ô Số điện thoại
                e.SuppressKeyPress = true;
            }
        }

        private void txtsdt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtmail.Focus();           // Nhảy sang ô Email
                e.SuppressKeyPress = true;
            }
        }

        private void txtmail_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cbvaitro.Focus();          // Nhảy tiếp sang ComboBox Vai trò (hoặc đổi thành btnthem.Focus() nếu muốn nhảy thẳng xuống nút Thêm)
                e.SuppressKeyPress = true;
            }
        }

        // mã hoá mk
        private void dgvTaiKhoan_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            // Kiểm tra xem có đúng là cột Mật Khẩu không (Giả sử cột Mật khẩu nằm ở Index = 2 hoặc bạn có thể check theo tên cột)
            // Nếu trong SQL cột tên là "MatKhau" hoặc "Password", bạn có thể kiểm tra: dgvTaiKhoan.Columns[e.ColumnIndex].Name == "MatKhau"
            if (e.ColumnIndex == 2 && e.Value != null) // Thay số 2 bằng index cột mật khẩu của bạn nếu khác
            {
                e.Value = "••••••••"; // Hiển thị dấu chấm hoặc "******"
                e.FormattingApplied = true;
            }
        }

        private void TimKiemTaiKhoan()
        {
            if (!isLoaded) return;

            try
            {
                // Lấy dữ liệu gốc từ BLL
                DataTable dt = bll.LayDanhSachTaiKhoan();
                if (dt != null)
                {
                    string keyword = txttk.Text.Trim().Replace("'", "''"); // Tránh lỗi cú pháp SQL nếu gõ dấu nháy
                    bool filterHoatDong = cbhd.Checked;

                    // Tạo danh sách các điều kiện lọc (RowFilter)
                    List<string> conditions = new List<string>();

                    // 1. Điều kiện tìm kiếm theo từ khóa (kiểm tra cả TenDangNhap và HoTen)
                    if (!string.IsNullOrEmpty(keyword))
                    {
                        conditions.Add($"(TenDangNhap LIKE '%{keyword}%' OR HoTen LIKE '%{keyword}%')");
                    }

                    // 2. Điều kiện lọc theo trạng thái hoạt động dựa vào checkbox cbhd
                    if (filterHoatDong)
                    {
                        // Khi checkbox BẬT (Checked): Chỉ hiện tài khoản đang hoạt động
                        conditions.Add("(TrangThai = 'Đang hoạt động' OR TrangThai = 'Hoạt động' OR TrangThai = 'True' OR TrangThai = '1')");
                    }
                    else
                    {
                        // Khi checkbox TẮT (Unchecked): Chỉ hiện tài khoản không hoạt động / đã khóa
                        conditions.Add("(TrangThai = 'Đã khóa' OR TrangThai = 'Khóa' OR TrangThai = 'False' OR TrangThai = '0')");
                    }

                    // Gộp các điều kiện lại bằng từ khóa AND
                    string finalFilter = string.Join(" AND ", conditions);

                    AppLogger.Debug($"Loc danh sach tai khoan voi tu khoa: '{keyword}', LocHoatDong: {filterHoatDong}, Filter: '{finalFilter}'");

                    // Áp dụng bộ lọc cho DataView của DataTable
                    DataView dv = dt.DefaultView;
                    dv.RowFilter = finalFilter;

                    // Gán lại lên DataGridView
                    dgvTaiKhoan.DataSource = dv;
                }
            }
            catch (Exception ex)
            {
                AppLogger.Error(ex, "Loi tim kiem tai khoan.");
                MessageBox.Show("Lỗi tìm kiếm: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        // Load ComboBox Vai Trò
        private void LoadComboBoxVaiTro()
        {
            cbvaitro.Items.Clear();
            cbvaitro.Items.Add("Quản trị viên");
            cbvaitro.Items.Add("Nhân viên");

            if (cbvaitro.Items.Count > 1)
            {
                cbvaitro.SelectedIndex = 1; // Mặc định 'Nhân viên'
            }
        }
        private void LoadDataGrid()
        {
            try
            {
                dgvTaiKhoan.AutoGenerateColumns = true; // dòng này để bảng tự động tạo cột chuẩn theo SQL
                dgvTaiKhoan.DataSource = bll.LayDanhSachTaiKhoan();
                AppLogger.Information("Tai danh sach tai khoan len DataGridView thanh cong.");
            }
            catch (Exception ex)
            {
                AppLogger.Error(ex, "Loi tai du lieu danh sach tai khoan len DataGridView.");
                MessageBox.Show("Lỗi tải dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Reset toàn bộ các ô nhập liệu
        private void ResetForm()
        {
            AppLogger.Debug("Reset form thong tin tai khoan.");
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
            LoadComboBoxVaiTro();
            txttendn.Focus();
        }

        // 2. Click chọn dòng trên DataGridView -> Hiện thông tin đầy đủ lên trên
        private void dgvTaiKhoan_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvTaiKhoan.Rows[e.RowIndex];

                txtma.Text = row.Cells[0].Value?.ToString() ?? "";
                txttendn.Text = row.Cells[1].Value?.ToString() ?? "";
                txtmk.Text = row.Cells[2].Value?.ToString() ?? "";
                txthoten.Text = row.Cells[3].Value?.ToString() ?? "";
                txtmail.Text = row.Cells[4].Value?.ToString() ?? "";
                txtsdt.Text = row.Cells[5].Value?.ToString() ?? "";

                // Fix chuẩn cho ComboBox dạng DropDownList: Chọn trực tiếp bằng giá trị chuỗi
                if (row.Cells[6].Value != null)
                {
                    string vaiTro = row.Cells[6].Value.ToString().Trim();
                    cbvaitro.SelectedItem = vaiTro;

                    // Phòng hờ nếu chuỗi không khớp chính xác 100% thì gán cứng theo index an toàn
                    if (cbvaitro.SelectedIndex == -1)
                    {
                        if (vaiTro.Contains("Quản trị")) cbvaitro.SelectedIndex = 0;
                        else cbvaitro.SelectedIndex = 1;
                    }
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

                txttendn.Enabled = false;
                AppLogger.Information($"Chon tai khoan ma: [{txtma.Text}], TenDangNhap: [{txttendn.Text}] tu danh sach.");
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
            dgvTaiKhoan_CellClick(sender, e);
        }

        private void btntrangchu_Click(object sender, EventArgs e)
        {
            AppLogger.Information("Dieu huong ve FrmTrangChu tu FrmTaiKhoan.");
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

            AppLogger.Information($"Nguoi dung nhan nut Them tai khoan: '{username}'.");

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(pass) || string.IsNullOrEmpty(hoTen))
            {
                AppLogger.Warning("Them tai khoan that bai: Thieu TenDangNhap, MatKhau hoac HoTen.");
                MessageBox.Show("Vui lòng điền đầy đủ Tên đăng nhập, Mật khẩu và Họ tên!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Thêm cảnh báo xác nhận trước khi thêm
            DialogResult dr = MessageBox.Show($"Bạn có chắc chắn muốn thêm tài khoản [{username}] không?", "Xác nhận thêm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                if (bll.ThemTaiKhoan(username, pass, hoTen, email, sdt, vaiTro, trangThai))
                {
                    AppLogger.Information($"Them tai khoan [{username}] thanh cong.");
                    MessageBox.Show("Thêm tài khoản thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadDataGrid();
                    ResetForm();
                }
                else
                {
                    AppLogger.Warning($"Them tai khoan [{username}] that bai tu tang BLL/CSDL.");
                    MessageBox.Show("Thêm thất bại (Tên đăng nhập đã tồn tại hoặc lỗi CSDL).", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                AppLogger.Information($"Nguoi dung da huy thao tac them tai khoan [{username}].");
            }
        }

        private void btnsua_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtma.Text))
            {
                AppLogger.Warning("Sua tai khoan that bai: Chua chon dong tai khoan can sua.");
                MessageBox.Show("Vui lòng chọn một dòng tài khoản từ danh sách để sửa!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            AppLogger.Information($"Nguoi dung nhan nut Sua tai khoan ma: [{txtma.Text}].");

            // Thêm cảnh báo xác nhận trước khi sửa
            DialogResult dr = MessageBox.Show($"Bạn có chắc chắn muốn cập nhật thông tin cho tài khoản có mã [{txtma.Text}] không?", "Xác nhận sửa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                int maTK = int.Parse(txtma.Text);
                string hoTen = txthoten.Text.Trim();
                string pass = txtmk.Text.Trim();
                string email = txtmail.Text.Trim();
                string sdt = txtsdt.Text.Trim();
                string vaiTro = cbvaitro.Text;
                string trangThai = checktrangthai.Checked ? "Đang hoạt động" : "Đã khóa";

                if (bll.SuaTaiKhoan(maTK, hoTen, pass, email, sdt, vaiTro, trangThai))
                {
                    AppLogger.Information($"Cap nhat thong tin tai khoan ma [{maTK}] thanh cong.");
                    MessageBox.Show("Cập nhật thông tin tài khoản thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadDataGrid();
                    ResetForm();
                }
                else
                {
                    AppLogger.Warning($"Cap nhat thong tin tai khoan ma [{maTK}] that bai tu tang BLL/CSDL.");
                    MessageBox.Show("Cập nhật thất bại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                AppLogger.Information($"Nguoi dung da huy thao tac sua tai khoan ma [{txtma.Text}].");
            }
        }

        private void btnkhoa_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtma.Text))
            {
                AppLogger.Warning("Doi trang thai that bai: Chua chon tai khoan.");
                MessageBox.Show("Vui lòng chọn tài khoản cần thay đổi trạng thái!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            bool trangThaiMoi = !checktrangthai.Checked;
            string trangThaiText = trangThaiMoi ? "Đang hoạt động" : "Đã khóa";

            AppLogger.Information($"Nguoi dung nhan nut Doi trang thai tai khoan ma: [{txtma.Text}] sang [{trangThaiText}].");

            // Thêm cảnh báo xác nhận trước khi khóa/mở khóa
            DialogResult dr = MessageBox.Show($"Bạn có chắc chắn muốn chuyển trạng thái tài khoản mã [{txtma.Text}] thành [{trangThaiText}] không?", "Xác nhận đổi trạng thái", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                int maTK = int.Parse(txtma.Text);

                if (bll.CapNhatTrangThai(maTK, trangThaiText))
                {
                    checktrangthai.Checked = trangThaiMoi; // Cập nhật checkbox
                    AppLogger.Information($"Doi trang thai tai khoan ma [{maTK}] thanh cong sang [{trangThaiText}].");
                    MessageBox.Show($"Đã đổi trạng thái tài khoản thành: [{trangThaiText}]!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadDataGrid(); // Đồng bộ lại DataGridView
                }
                else
                {
                    AppLogger.Warning($"Doi trang thai tai khoan ma [{maTK}] that bai tu tang BLL/CSDL.");
                    MessageBox.Show("Lỗi cập nhật trạng thái.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                AppLogger.Information($"Nguoi dung da huy thao tac doi trang thai tai khoan ma [{txtma.Text}].");
            }
        }

        private void btnlammoi_Click(object sender, EventArgs e)
        {
            AppLogger.Information("Nguoi dung nhan nut Lam moi Form.");
            // Thêm cảnh báo xác nhận trước khi làm mới (nếu muốn reset dữ liệu đang nhập dở)
            DialogResult dr = MessageBox.Show("Bạn có muốn làm mới lại form và hủy các thông tin đang nhập?", "Xác nhận làm mới", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                AppLogger.Information("Xac nhan lam moi du lieu tren FrmTaiKhoan.");
                txttk.Clear(); // Xóa ô tìm kiếm
                cbhd.Checked = true; // Đưa checkbox hoạt động về mặc định
                ResetForm();
                LoadDataGrid(); // Hiện dữ liệu mới nhất trong DataGridView
            }
            else
            {
                AppLogger.Information("Nguoi dung da huy thao tac lam moi.");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Kiểm tra xem đã chọn dòng nào trên bảng chưa (dựa vào ô Mã tài khoản)
            if (string.IsNullOrEmpty(txtma.Text))
            {
                AppLogger.Warning("Xoa tai khoan that bai: Chua chon tai khoan tu danh sach.");
                MessageBox.Show("Vui lòng chọn tài khoản cần xoá từ danh sách bên dưới!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            AppLogger.Information($"Nguoi dung nhan nut Xoa tai khoan ma: [{txtma.Text}].");

            // Hộp thoại cảnh báo xác nhận trước khi xoá (đã có sẵn từ trước của bạn)
            DialogResult dr = MessageBox.Show($"Bạn có chắc chắn muốn xoá tài khoản có mã [{txtma.Text}] không?", "Xác nhận xoá", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dr == DialogResult.Yes)
            {
                try
                {
                    int maTK = Convert.ToInt32(txtma.Text);
                    bool ketQua = bll.XoaTaiKhoan(maTK);

                    if (ketQua)
                    {
                        AppLogger.Information($"Xoa tai khoan ma [{maTK}] thanh cong.");
                        MessageBox.Show("Xoá tài khoản thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Cập nhật lại DataGridView và làm sạch form
                        LoadDataGrid();
                        ResetForm();
                    }
                    else
                    {
                        AppLogger.Warning($"Xoa tai khoan ma [{maTK}] that bai tu tang BLL/CSDL.");
                        MessageBox.Show("Xoá tài khoản thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    AppLogger.Error(ex, $"Loi he thong khi xoa tai khoan ma [{txtma.Text}].");
                    MessageBox.Show("Lỗi hệ thống: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                AppLogger.Information($"Nguoi dung da huy thao tac xoa tai khoan ma [{txtma.Text}].");
            }
        }

        private void lblhoten_Click(object sender, EventArgs e)
        {

        }

        private void txttk_TextChanged(object sender, EventArgs e)
        {
            TimKiemTaiKhoan(); // Tìm kiếm ngay trong lúc gõ
        }
        private void txttk_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                TimKiemTaiKhoan(); // Tìm kiếm khi nhấn Enter
                e.SuppressKeyPress = true; // Chặn tiếng kêu "bíp" của Windows
            }
        }
        private void cbhd_CheckedChanged(object sender, EventArgs e)
        {
            TimKiemTaiKhoan(); // Lọc lại danh sách ngay khi thay đổi trạng thái checkbox "Hoạt động"

        }

        private void btntim_Click(object sender, EventArgs e)
        {
            TimKiemTaiKhoan(); // Tìm kiếm khi bấm nút "Tìm"
        }
    }
}