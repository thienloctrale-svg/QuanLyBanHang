namespace GD_Quản_Lý_Sản_Phẩm
{
    public partial class FrmSanPham : Form
    {
        public FrmSanPham()
        {
            InitializeComponent();
        }

        private void txtTimKiem_Enter(object sender, EventArgs e)
        {
            if (txtTimKiem.Text == "Tìm kiếm theo mã hoặc tên")
            {
                txtTimKiem.Text = "";
                txtTimKiem.ForeColor = System.Drawing.Color.Black; // Đổi sang chữ đen để gõ
            }
        }

        private void txtTimKiem_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTimKiem.Text))
            {
                txtTimKiem.Text = "Tìm kiếm theo mã hoặc tên";
                txtTimKiem.ForeColor = System.Drawing.Color.Gray; // Đổi sang màu xám cho giống chữ mờ
            }
        }
    }
}
