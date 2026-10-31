using System;
using System.Drawing;
using System.Windows.Forms;
using QuanLyBanHang.DTO;

namespace QuanLyBanHang.UI
{
    public partial class FrmTrangChu : Form
    {
        public TaiKhoanDTO? TaiKhoanDangNhap { get; private set; }

        public FrmTrangChu()
        {
            InitializeComponent();
        }

        public FrmTrangChu(TaiKhoanDTO taiKhoan) : this()
        {
            TaiKhoanDangNhap = taiKhoan;
            if (taiKhoan != null && !string.IsNullOrWhiteSpace(taiKhoan.HoTen))
            {
                lblXinChao.Text = $"👤 Xin chào: {taiKhoan.HoTen}";
            }
        }
    }
}
