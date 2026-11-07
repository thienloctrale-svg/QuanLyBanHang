using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using QuanLyBanHang.BLL;
using QuanLyBanHang.Logging;

namespace QuanLyBanHang.UI
{
    public partial class FrmDangNhap : Form
    {
        private TaiKhoanBLL bll;

        // Biến static lưu tài khoản đăng nhập để dùng xuyên suốt ứng dụng
        public static object TaiKhoanDangNhap = null;

        public FrmDangNhap()
        {
            InitializeComponent();

            AppLogger.Information("Khoi tao Form Dang Nhap.");

            txtpass.UseSystemPasswordChar = true;
            checkhienmatkhau.Checked = false;

            if (!this.DesignMode)
            {
                bll = new TaiKhoanBLL();
            }
            txtacc.Focus();

            // Gắn sự kiện Enter cho ô tài khoản (nhảy sang ô mật khẩu)
            txtacc.KeyDown += txtacc_KeyDown;

            txtpass.KeyDown += txtpass_KeyDown;
        }

        private void FrmDangNhap_Load(object sender, EventArgs e)
        {
            txtpass.UseSystemPasswordChar = true;
        }

        // Giữ lại các hàm này để khớp với sự kiện trong Designer
        private void label3_Click(object sender, EventArgs e)
        {
        }

        private void txtacc_TextChanged(object sender, EventArgs e)
        {
        }

        private void txtpass_TextChanged(object sender, EventArgs e)
        {
        }

        private void checkhienmatkhau_CheckedChanged(object sender, EventArgs e)
        {
            txtpass.UseSystemPasswordChar = !checkhienmatkhau.Checked;
        }

        private void txtacc_KeyDown(object sender, KeyEventArgs e)
        {
            // Kiểm tra nếu phím được nhấn là phím Enter
            if (e.KeyCode == Keys.Enter)
            {
                txtpass.Focus();          // Chuyển con trỏ chuột sang ô mật khẩu
                e.SuppressKeyPress = true; // Chặn tiếng kêu "bíp" khó chịu của Windows
            }
        }

        private void txtpass_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                // Gọi trực tiếp sự kiện click của nút đăng nhập
                button1_Click(sender, e);
                e.SuppressKeyPress = true; // Chặn tiếng kêu "bíp" của Windows
            }
        }

        private void button1_Click(object sender, EventArgs e)// đăng nhập
        {
            string user = txtacc.Text.Trim();
            string pass = txtpass.Text.Trim();

            AppLogger.Information($"Nguoi dung nhan nut Dang nhap voi tai khoan: '{user}'");

            // 1. Kiểm tra đầu vào
            if (string.IsNullOrEmpty(user) || string.IsNullOrEmpty(pass))
            {
                AppLogger.Warning("Dang nhap that bai: Chua nhap day du tai khoan hoac mat khau.");
                MessageBox.Show("Vui lòng nhập đầy đủ tài khoản và mật khẩu!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (bll == null) bll = new TaiKhoanBLL();

            // 2. Kiểm tra tài khoản từ CSDL
            var tk = bll.DangNhap(user, pass);

            if (tk != null)
            {
                AppLogger.Information($"Dang nhap thanh cong voi tai khoan: '{user}'.");

                // Lưu vào biến static toàn cục
                TaiKhoanDangNhap = tk;

                // Ẩn Form Đăng Nhập
                this.Hide();

                // Khởi tạo và hiển thị Form Trang Chủ
                FrmTrangChu mainForm = new FrmTrangChu();

                // Đảm bảo khi tắt Form Trang Chủ thì toàn bộ ứng dụng sẽ thoát hẳn
                mainForm.FormClosed += (s, args) =>
                {
                    AppLogger.Information("Dong Form Trang Chu, thoat ung dung.");
                    Application.Exit();
                };

                mainForm.Show();
            }
            else
            {
                AppLogger.Warning($"Dang nhap that bai: Sai ten tai khoan hoac mat khau cho '{user}'.");
                MessageBox.Show("Tài khoản hoặc mật khẩu không chính xác!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtpass.Clear();
                txtpass.Focus();
            }
        }

        private void btnhuy_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn thoát ứng dụng không?", "Xác nhận thoát", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                AppLogger.Information("Nguoi dung xac nhan thoat ung dung tu Form Dang Nhap.");
                Application.Exit();
            }
        }

        private void FrmDangNhap_Load_1(object sender, EventArgs e)
        {

        }
    }
}