using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System;
using System.Windows.Forms;
using QuanLyBanHang.BLL;

namespace QuanLyBanHang.UI
{
    public partial class FrmDangNhap : Form
    {
        private TaiKhoanBLL bll;
        public FrmDangNhap()
        {
            InitializeComponent();

            // Mặc định ô mật khẩu sẽ ẩn ký tự khi vừa chạy lên
            txtpass.UseSystemPasswordChar = true;
            checkhienmatkhau.Checked = false; // Đảm bảo ô checkbox chưa tích

            if (!this.DesignMode)
            {
                bll = new TaiKhoanBLL();
            }
        }
        private void FrmDangNhap_Load(object sender, EventArgs e)
        {
            // Mặc định ẩn mật khẩu
            txtpass.UseSystemPasswordChar = true;
        }

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

        private void button1_Click(object sender, EventArgs e)// đăng nhập
        {
            string user = txtacc.Text.Trim();
            string pass = txtpass.Text.Trim();

            // 1. Kiểm tra đầu vào
            if (string.IsNullOrEmpty(user) || string.IsNullOrEmpty(pass))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ tài khoản và mật khẩu!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (bll == null) bll = new TaiKhoanBLL();

            // 2. Kiểm tra tài khoản từ CSDL
            var tk = bll.DangNhap(user, pass);

            if (tk != null)
            {
                // Ẩn Form Đăng Nhập
                this.Hide();

                // Khởi tạo và hiển thị Form Trang Chủ
                FrmTrangChu mainForm = new FrmTrangChu();

                // Đảm bảo khi tắt Form Trang Chủ thì toàn bộ ứng dụng sẽ thoát hẳn (không chạy ngầm)
                mainForm.FormClosed += (s, args) => Application.Exit();

                mainForm.Show();
            }
            else
            {
                // Sai tài khoản/mật khẩu thì vẫn báo lỗi để người dùng biết
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
                Application.Exit(); // Thoát chương trình
            }
        }
    }
}
