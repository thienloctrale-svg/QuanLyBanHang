namespace QuanLyBanHang.UI
{
    partial class FrmTrangChu
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            pnlSidebar = new Panel();
            pnlSidebarBottom = new Panel();
            btnThoat = new Button();
            btnDangXuat = new Button();
            btnMenuThongKe = new Button();
            btnMenuTaiKhoan = new Button();
            btnMenuNhapHang = new Button();
            btnMenuKhachHang = new Button();
            btnMenuSanPham = new Button();
            btnMenuBanHang = new Button();
            btnMenuTrangChu = new Button();
            pnlLogo = new Panel();
            lblStoreSub = new Label();
            lblStoreName = new Label();
            pnlHeader = new Panel();
            lblDongHo = new Label();
            lblXinChao = new Label();
            lblTitle = new Label();
            pnlMain = new Panel();
            grpQuickActions = new GroupBox();
            btnQuickTaiKhoan = new Button();
            btnQuickNhapHang = new Button();
            btnQuickThongKe = new Button();
            btnQuickKhachHang = new Button();
            btnQuickSanPham = new Button();
            btnQuickBanHang = new Button();
            pnlCardKhachHang = new Panel();
            lblCardKhachHangSub = new Label();
            lblCardKhachHangVal = new Label();
            lblCardKhachHangTitle = new Label();
            pnlCardSanPham = new Panel();
            lblCardSanPhamSub = new Label();
            lblCardSanPhamVal = new Label();
            lblCardSanPhamTitle = new Label();
            pnlCardHoaDon = new Panel();
            lblCardHoaDonSub = new Label();
            lblCardHoaDonVal = new Label();
            lblCardHoaDonTitle = new Label();
            pnlCardDoanhThu = new Panel();
            lblCardDoanhThuSub = new Label();
            lblCardDoanhThuVal = new Label();
            lblCardDoanhThuTitle = new Label();
            pnlWelcomeBanner = new Panel();
            lblWelcomeDesc = new Label();
            lblWelcomeTitle = new Label();
            statusStripTrangChu = new StatusStrip();
            lblStatusHeThong = new ToolStripStatusLabel();
            lblStatusDatabase = new ToolStripStatusLabel();
            lblStatusThoiGian = new ToolStripStatusLabel();
            tmrDongHo = new System.Windows.Forms.Timer(components);
            pnlSidebar.SuspendLayout();
            pnlSidebarBottom.SuspendLayout();
            pnlLogo.SuspendLayout();
            pnlHeader.SuspendLayout();
            pnlMain.SuspendLayout();
            grpQuickActions.SuspendLayout();
            pnlCardKhachHang.SuspendLayout();
            pnlCardSanPham.SuspendLayout();
            pnlCardHoaDon.SuspendLayout();
            pnlCardDoanhThu.SuspendLayout();
            pnlWelcomeBanner.SuspendLayout();
            statusStripTrangChu.SuspendLayout();
            SuspendLayout();
            // 
            // pnlSidebar
            // 
            pnlSidebar.BackColor = Color.FromArgb(24, 30, 54);
            pnlSidebar.Controls.Add(pnlSidebarBottom);
            pnlSidebar.Controls.Add(btnMenuThongKe);
            pnlSidebar.Controls.Add(btnMenuTaiKhoan);
            pnlSidebar.Controls.Add(btnMenuNhapHang);
            pnlSidebar.Controls.Add(btnMenuKhachHang);
            pnlSidebar.Controls.Add(btnMenuSanPham);
            pnlSidebar.Controls.Add(btnMenuBanHang);
            pnlSidebar.Controls.Add(btnMenuTrangChu);
            pnlSidebar.Controls.Add(pnlLogo);
            pnlSidebar.Dock = DockStyle.Left;
            pnlSidebar.Location = new Point(0, 0);
            pnlSidebar.Name = "pnlSidebar";
            pnlSidebar.Size = new Size(250, 750);
            pnlSidebar.TabIndex = 0;
            // 
            // pnlSidebarBottom
            // 
            pnlSidebarBottom.Controls.Add(btnThoat);
            pnlSidebarBottom.Controls.Add(btnDangXuat);
            pnlSidebarBottom.Dock = DockStyle.Bottom;
            pnlSidebarBottom.Location = new Point(0, 642);
            pnlSidebarBottom.Name = "pnlSidebarBottom";
            pnlSidebarBottom.Size = new Size(250, 108);
            pnlSidebarBottom.TabIndex = 8;
            // 
            // btnThoat
            // 
            btnThoat.Cursor = Cursors.Hand;
            btnThoat.Dock = DockStyle.Top;
            btnThoat.FlatAppearance.BorderSize = 0;
            btnThoat.FlatStyle = FlatStyle.Flat;
            btnThoat.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnThoat.ForeColor = Color.FromArgb(203, 213, 225);
            btnThoat.Location = new Point(0, 50);
            btnThoat.Name = "btnThoat";
            btnThoat.Padding = new Padding(25, 0, 0, 0);
            btnThoat.Size = new Size(250, 50);
            btnThoat.TabIndex = 1;
            btnThoat.Text = "❌  Thoát ứng dụng";
            btnThoat.TextAlign = ContentAlignment.MiddleLeft;
            btnThoat.UseVisualStyleBackColor = true;
            // 
            // btnDangXuat
            // 
            btnDangXuat.Cursor = Cursors.Hand;
            btnDangXuat.Dock = DockStyle.Top;
            btnDangXuat.FlatAppearance.BorderSize = 0;
            btnDangXuat.FlatStyle = FlatStyle.Flat;
            btnDangXuat.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnDangXuat.ForeColor = Color.FromArgb(248, 113, 113);
            btnDangXuat.Location = new Point(0, 0);
            btnDangXuat.Name = "btnDangXuat";
            btnDangXuat.Padding = new Padding(25, 0, 0, 0);
            btnDangXuat.Size = new Size(250, 50);
            btnDangXuat.TabIndex = 0;
            btnDangXuat.Text = "🚪  Đăng xuất";
            btnDangXuat.TextAlign = ContentAlignment.MiddleLeft;
            btnDangXuat.UseVisualStyleBackColor = true;
            // 
            // btnMenuThongKe
            // 
            btnMenuThongKe.Cursor = Cursors.Hand;
            btnMenuThongKe.Dock = DockStyle.Top;
            btnMenuThongKe.FlatAppearance.BorderSize = 0;
            btnMenuThongKe.FlatStyle = FlatStyle.Flat;
            btnMenuThongKe.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnMenuThongKe.ForeColor = Color.FromArgb(226, 232, 240);
            btnMenuThongKe.Location = new Point(0, 390);
            btnMenuThongKe.Name = "btnMenuThongKe";
            btnMenuThongKe.Padding = new Padding(25, 0, 0, 0);
            btnMenuThongKe.Size = new Size(250, 48);
            btnMenuThongKe.TabIndex = 7;
            btnMenuThongKe.Text = "📊  Báo cáo & Thống kê";
            btnMenuThongKe.TextAlign = ContentAlignment.MiddleLeft;
            btnMenuThongKe.UseVisualStyleBackColor = true;
            // 
            // btnMenuTaiKhoan
            // 
            btnMenuTaiKhoan.Cursor = Cursors.Hand;
            btnMenuTaiKhoan.Dock = DockStyle.Top;
            btnMenuTaiKhoan.FlatAppearance.BorderSize = 0;
            btnMenuTaiKhoan.FlatStyle = FlatStyle.Flat;
            btnMenuTaiKhoan.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnMenuTaiKhoan.ForeColor = Color.FromArgb(226, 232, 240);
            btnMenuTaiKhoan.Location = new Point(0, 342);
            btnMenuTaiKhoan.Name = "btnMenuTaiKhoan";
            btnMenuTaiKhoan.Padding = new Padding(25, 0, 0, 0);
            btnMenuTaiKhoan.Size = new Size(250, 48);
            btnMenuTaiKhoan.TabIndex = 6;
            btnMenuTaiKhoan.Text = "👤  Quản lý tài khoản";
            btnMenuTaiKhoan.TextAlign = ContentAlignment.MiddleLeft;
            btnMenuTaiKhoan.UseVisualStyleBackColor = true;
            // 
            // btnMenuNhapHang
            // 
            btnMenuNhapHang.Cursor = Cursors.Hand;
            btnMenuNhapHang.Dock = DockStyle.Top;
            btnMenuNhapHang.FlatAppearance.BorderSize = 0;
            btnMenuNhapHang.FlatStyle = FlatStyle.Flat;
            btnMenuNhapHang.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnMenuNhapHang.ForeColor = Color.FromArgb(226, 232, 240);
            btnMenuNhapHang.Location = new Point(0, 294);
            btnMenuNhapHang.Name = "btnMenuNhapHang";
            btnMenuNhapHang.Padding = new Padding(25, 0, 0, 0);
            btnMenuNhapHang.Size = new Size(250, 48);
            btnMenuNhapHang.TabIndex = 5;
            btnMenuNhapHang.Text = "📥  Quản lý nhập hàng";
            btnMenuNhapHang.TextAlign = ContentAlignment.MiddleLeft;
            btnMenuNhapHang.UseVisualStyleBackColor = true;
            // 
            // btnMenuKhachHang
            // 
            btnMenuKhachHang.Cursor = Cursors.Hand;
            btnMenuKhachHang.Dock = DockStyle.Top;
            btnMenuKhachHang.FlatAppearance.BorderSize = 0;
            btnMenuKhachHang.FlatStyle = FlatStyle.Flat;
            btnMenuKhachHang.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnMenuKhachHang.ForeColor = Color.FromArgb(226, 232, 240);
            btnMenuKhachHang.Location = new Point(0, 246);
            btnMenuKhachHang.Name = "btnMenuKhachHang";
            btnMenuKhachHang.Padding = new Padding(25, 0, 0, 0);
            btnMenuKhachHang.Size = new Size(250, 48);
            btnMenuKhachHang.TabIndex = 4;
            btnMenuKhachHang.Text = "👥  Quản lý khách hàng";
            btnMenuKhachHang.TextAlign = ContentAlignment.MiddleLeft;
            btnMenuKhachHang.UseVisualStyleBackColor = true;
            // 
            // btnMenuSanPham
            // 
            btnMenuSanPham.Cursor = Cursors.Hand;
            btnMenuSanPham.Dock = DockStyle.Top;
            btnMenuSanPham.FlatAppearance.BorderSize = 0;
            btnMenuSanPham.FlatStyle = FlatStyle.Flat;
            btnMenuSanPham.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnMenuSanPham.ForeColor = Color.FromArgb(226, 232, 240);
            btnMenuSanPham.Location = new Point(0, 198);
            btnMenuSanPham.Name = "btnMenuSanPham";
            btnMenuSanPham.Padding = new Padding(25, 0, 0, 0);
            btnMenuSanPham.Size = new Size(250, 48);
            btnMenuSanPham.TabIndex = 3;
            btnMenuSanPham.Text = "📦  Quản lý sản phẩm";
            btnMenuSanPham.TextAlign = ContentAlignment.MiddleLeft;
            btnMenuSanPham.UseVisualStyleBackColor = true;
            // 
            // btnMenuBanHang
            // 
            btnMenuBanHang.Cursor = Cursors.Hand;
            btnMenuBanHang.Dock = DockStyle.Top;
            btnMenuBanHang.FlatAppearance.BorderSize = 0;
            btnMenuBanHang.FlatStyle = FlatStyle.Flat;
            btnMenuBanHang.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnMenuBanHang.ForeColor = Color.FromArgb(226, 232, 240);
            btnMenuBanHang.Location = new Point(0, 150);
            btnMenuBanHang.Name = "btnMenuBanHang";
            btnMenuBanHang.Padding = new Padding(25, 0, 0, 0);
            btnMenuBanHang.Size = new Size(250, 48);
            btnMenuBanHang.TabIndex = 2;
            btnMenuBanHang.Text = "🛒  Bán hàng (POS)";
            btnMenuBanHang.TextAlign = ContentAlignment.MiddleLeft;
            btnMenuBanHang.UseVisualStyleBackColor = true;
            // 
            // btnMenuTrangChu
            // 
            btnMenuTrangChu.BackColor = Color.FromArgb(41, 53, 86);
            btnMenuTrangChu.Cursor = Cursors.Hand;
            btnMenuTrangChu.Dock = DockStyle.Top;
            btnMenuTrangChu.FlatAppearance.BorderSize = 0;
            btnMenuTrangChu.FlatStyle = FlatStyle.Flat;
            btnMenuTrangChu.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnMenuTrangChu.ForeColor = Color.White;
            btnMenuTrangChu.Location = new Point(0, 102);
            btnMenuTrangChu.Name = "btnMenuTrangChu";
            btnMenuTrangChu.Padding = new Padding(25, 0, 0, 0);
            btnMenuTrangChu.Size = new Size(250, 48);
            btnMenuTrangChu.TabIndex = 1;
            btnMenuTrangChu.Text = "🏠  Trang chủ";
            btnMenuTrangChu.TextAlign = ContentAlignment.MiddleLeft;
            btnMenuTrangChu.UseVisualStyleBackColor = false;
            // 
            // pnlLogo
            // 
            pnlLogo.BackColor = Color.FromArgb(18, 23, 42);
            pnlLogo.Controls.Add(lblStoreSub);
            pnlLogo.Controls.Add(lblStoreName);
            pnlLogo.Dock = DockStyle.Top;
            pnlLogo.Location = new Point(0, 0);
            pnlLogo.Name = "pnlLogo";
            pnlLogo.Size = new Size(250, 102);
            pnlLogo.TabIndex = 0;
            // 
            // lblStoreSub
            // 
            lblStoreSub.AutoSize = true;
            lblStoreSub.Font = new Font("Segoe UI", 8.5F);
            lblStoreSub.ForeColor = Color.FromArgb(148, 163, 184);
            lblStoreSub.Location = new Point(22, 57);
            lblStoreSub.Name = "lblStoreSub";
            lblStoreSub.Size = new Size(183, 19);
            lblStoreSub.TabIndex = 1;
            lblStoreSub.Text = "Hệ thống quản lý bán hàng";
            // 
            // lblStoreName
            // 
            lblStoreName.AutoSize = true;
            lblStoreName.Font = new Font("Segoe UI", 13.5F, FontStyle.Bold);
            lblStoreName.ForeColor = Color.White;
            lblStoreName.Location = new Point(20, 22);
            lblStoreName.Name = "lblStoreName";
            lblStoreName.Size = new Size(207, 31);
            lblStoreName.TabIndex = 0;
            lblStoreName.Text = "🏪 POS MANAGER";
            // 
            // pnlHeader
            // 
            pnlHeader.BackColor = Color.White;
            pnlHeader.Controls.Add(lblDongHo);
            pnlHeader.Controls.Add(lblXinChao);
            pnlHeader.Controls.Add(lblTitle);
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Location = new Point(250, 0);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Size = new Size(950, 72);
            pnlHeader.TabIndex = 1;
            // 
            // lblDongHo
            // 
            lblDongHo.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblDongHo.Font = new Font("Segoe UI", 9F);
            lblDongHo.ForeColor = Color.FromArgb(100, 116, 139);
            lblDongHo.Location = new Point(620, 39);
            lblDongHo.Name = "lblDongHo";
            lblDongHo.RightToLeft = RightToLeft.No;
            lblDongHo.Size = new Size(310, 22);
            lblDongHo.TabIndex = 2;
            lblDongHo.Text = "🕒 Thứ Bảy, 31/10/2026 15:30:00";
            lblDongHo.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblXinChao
            // 
            lblXinChao.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblXinChao.Font = new Font("Segoe UI", 10.5F, FontStyle.Bold);
            lblXinChao.ForeColor = Color.FromArgb(30, 64, 175);
            lblXinChao.Location = new Point(620, 12);
            lblXinChao.Name = "lblXinChao";
            lblXinChao.Size = new Size(310, 25);
            lblXinChao.TabIndex = 1;
            lblXinChao.Text = "👤 Xin chào: Quản trị viên";
            lblXinChao.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblTitle.ForeColor = Color.FromArgb(15, 23, 42);
            lblTitle.Location = new Point(24, 20);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(378, 32);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "BẢNG ĐIỀU KHIỂN HỆ THỐNG";
            // 
            // pnlMain
            // 
            pnlMain.AutoScroll = true;
            pnlMain.BackColor = Color.FromArgb(244, 246, 249);
            pnlMain.Controls.Add(grpQuickActions);
            pnlMain.Controls.Add(pnlCardKhachHang);
            pnlMain.Controls.Add(pnlCardSanPham);
            pnlMain.Controls.Add(pnlCardHoaDon);
            pnlMain.Controls.Add(pnlCardDoanhThu);
            pnlMain.Controls.Add(pnlWelcomeBanner);
            pnlMain.Dock = DockStyle.Fill;
            pnlMain.Location = new Point(250, 72);
            pnlMain.Name = "pnlMain";
            pnlMain.Padding = new Padding(25);
            pnlMain.Size = new Size(950, 648);
            pnlMain.TabIndex = 2;
            // 
            // grpQuickActions
            // 
            grpQuickActions.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            grpQuickActions.BackColor = Color.White;
            grpQuickActions.Controls.Add(btnQuickTaiKhoan);
            grpQuickActions.Controls.Add(btnQuickNhapHang);
            grpQuickActions.Controls.Add(btnQuickThongKe);
            grpQuickActions.Controls.Add(btnQuickKhachHang);
            grpQuickActions.Controls.Add(btnQuickSanPham);
            grpQuickActions.Controls.Add(btnQuickBanHang);
            grpQuickActions.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            grpQuickActions.ForeColor = Color.FromArgb(30, 41, 59);
            grpQuickActions.Location = new Point(25, 280);
            grpQuickActions.Name = "grpQuickActions";
            grpQuickActions.Size = new Size(900, 335);
            grpQuickActions.TabIndex = 5;
            grpQuickActions.TabStop = false;
            grpQuickActions.Text = "  ⚡ Lối tắt chức năng nhanh (Quick Access)  ";
            // 
            // btnQuickTaiKhoan
            // 
            btnQuickTaiKhoan.BackColor = Color.FromArgb(248, 250, 252);
            btnQuickTaiKhoan.Cursor = Cursors.Hand;
            btnQuickTaiKhoan.FlatAppearance.BorderColor = Color.FromArgb(203, 213, 225);
            btnQuickTaiKhoan.FlatStyle = FlatStyle.Flat;
            btnQuickTaiKhoan.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnQuickTaiKhoan.ForeColor = Color.FromArgb(51, 65, 85);
            btnQuickTaiKhoan.Location = new Point(608, 185);
            btnQuickTaiKhoan.Name = "btnQuickTaiKhoan";
            btnQuickTaiKhoan.Size = new Size(265, 120);
            btnQuickTaiKhoan.TabIndex = 5;
            btnQuickTaiKhoan.Text = "👤\r\nQUẢN LÝ TÀI KHOẢN\r\nPhân quyền & tài khoản";
            btnQuickTaiKhoan.UseVisualStyleBackColor = false;
            // 
            // btnQuickNhapHang
            // 
            btnQuickNhapHang.BackColor = Color.FromArgb(248, 250, 252);
            btnQuickNhapHang.Cursor = Cursors.Hand;
            btnQuickNhapHang.FlatAppearance.BorderColor = Color.FromArgb(203, 213, 225);
            btnQuickNhapHang.FlatStyle = FlatStyle.Flat;
            btnQuickNhapHang.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnQuickNhapHang.ForeColor = Color.FromArgb(51, 65, 85);
            btnQuickNhapHang.Location = new Point(318, 185);
            btnQuickNhapHang.Name = "btnQuickNhapHang";
            btnQuickNhapHang.Size = new Size(265, 120);
            btnQuickNhapHang.TabIndex = 4;
            btnQuickNhapHang.Text = "📥\r\nQUẢN LÝ NHẬP HÀNG\r\nNhập kho từ nhà cung cấp";
            btnQuickNhapHang.UseVisualStyleBackColor = false;
            // 
            // btnQuickThongKe
            // 
            btnQuickThongKe.BackColor = Color.FromArgb(248, 250, 252);
            btnQuickThongKe.Cursor = Cursors.Hand;
            btnQuickThongKe.FlatAppearance.BorderColor = Color.FromArgb(203, 213, 225);
            btnQuickThongKe.FlatStyle = FlatStyle.Flat;
            btnQuickThongKe.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnQuickThongKe.ForeColor = Color.FromArgb(51, 65, 85);
            btnQuickThongKe.Location = new Point(27, 185);
            btnQuickThongKe.Name = "btnQuickThongKe";
            btnQuickThongKe.Size = new Size(265, 120);
            btnQuickThongKe.TabIndex = 3;
            btnQuickThongKe.Text = "📊\r\nBÁO CÁO THỐNG KÊ\r\nTheo dõi doanh thu & lãi";
            btnQuickThongKe.UseVisualStyleBackColor = false;
            // 
            // btnQuickKhachHang
            // 
            btnQuickKhachHang.BackColor = Color.FromArgb(248, 250, 252);
            btnQuickKhachHang.Cursor = Cursors.Hand;
            btnQuickKhachHang.FlatAppearance.BorderColor = Color.FromArgb(203, 213, 225);
            btnQuickKhachHang.FlatStyle = FlatStyle.Flat;
            btnQuickKhachHang.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnQuickKhachHang.ForeColor = Color.FromArgb(51, 65, 85);
            btnQuickKhachHang.Location = new Point(608, 45);
            btnQuickKhachHang.Name = "btnQuickKhachHang";
            btnQuickKhachHang.Size = new Size(265, 120);
            btnQuickKhachHang.TabIndex = 2;
            btnQuickKhachHang.Text = "👥\r\nQUẢN LÝ KHÁCH HÀNG\r\nThông tin & chính sách VIP";
            btnQuickKhachHang.UseVisualStyleBackColor = false;
            // 
            // btnQuickSanPham
            // 
            btnQuickSanPham.BackColor = Color.FromArgb(248, 250, 252);
            btnQuickSanPham.Cursor = Cursors.Hand;
            btnQuickSanPham.FlatAppearance.BorderColor = Color.FromArgb(203, 213, 225);
            btnQuickSanPham.FlatStyle = FlatStyle.Flat;
            btnQuickSanPham.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnQuickSanPham.ForeColor = Color.FromArgb(51, 65, 85);
            btnQuickSanPham.Location = new Point(318, 45);
            btnQuickSanPham.Name = "btnQuickSanPham";
            btnQuickSanPham.Size = new Size(265, 120);
            btnQuickSanPham.TabIndex = 1;
            btnQuickSanPham.Text = "📦\r\nQUẢN LÝ SẢN PHẨM\r\nDanh mục, giá cả & tồn kho";
            btnQuickSanPham.UseVisualStyleBackColor = false;
            // 
            // btnQuickBanHang
            // 
            btnQuickBanHang.BackColor = Color.FromArgb(238, 242, 255);
            btnQuickBanHang.Cursor = Cursors.Hand;
            btnQuickBanHang.FlatAppearance.BorderColor = Color.FromArgb(165, 180, 252);
            btnQuickBanHang.FlatStyle = FlatStyle.Flat;
            btnQuickBanHang.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnQuickBanHang.ForeColor = Color.FromArgb(67, 56, 202);
            btnQuickBanHang.Location = new Point(27, 45);
            btnQuickBanHang.Name = "btnQuickBanHang";
            btnQuickBanHang.Size = new Size(265, 120);
            btnQuickBanHang.TabIndex = 0;
            btnQuickBanHang.Text = "🛒\r\nLẬP HÓA ĐƠN BÁN HÀNG\r\nThu ngân & in phiếu";
            btnQuickBanHang.UseVisualStyleBackColor = false;
            // 
            // pnlCardKhachHang
            // 
            pnlCardKhachHang.BackColor = Color.White;
            pnlCardKhachHang.BorderStyle = BorderStyle.FixedSingle;
            pnlCardKhachHang.Controls.Add(lblCardKhachHangSub);
            pnlCardKhachHang.Controls.Add(lblCardKhachHangVal);
            pnlCardKhachHang.Controls.Add(lblCardKhachHangTitle);
            pnlCardKhachHang.Location = new Point(697, 145);
            pnlCardKhachHang.Name = "pnlCardKhachHang";
            pnlCardKhachHang.Padding = new Padding(15);
            pnlCardKhachHang.Size = new Size(215, 115);
            pnlCardKhachHang.TabIndex = 4;
            // 
            // lblCardKhachHangSub
            // 
            lblCardKhachHangSub.AutoSize = true;
            lblCardKhachHangSub.Font = new Font("Segoe UI", 8.5F);
            lblCardKhachHangSub.ForeColor = Color.FromArgb(100, 116, 139);
            lblCardKhachHangSub.Location = new Point(14, 82);
            lblCardKhachHangSub.Name = "lblCardKhachHangSub";
            lblCardKhachHangSub.Size = new Size(137, 19);
            lblCardKhachHangSub.TabIndex = 2;
            lblCardKhachHangSub.Text = "👥 Đang hoạt động";
            // 
            // lblCardKhachHangVal
            // 
            lblCardKhachHangVal.AutoSize = true;
            lblCardKhachHangVal.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblCardKhachHangVal.ForeColor = Color.FromArgb(147, 51, 234);
            lblCardKhachHangVal.Location = new Point(12, 38);
            lblCardKhachHangVal.Name = "lblCardKhachHangVal";
            lblCardKhachHangVal.Size = new Size(122, 41);
            lblCardKhachHangVal.TabIndex = 1;
            lblCardKhachHangVal.Text = "8 khách";
            // 
            // lblCardKhachHangTitle
            // 
            lblCardKhachHangTitle.AutoSize = true;
            lblCardKhachHangTitle.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
            lblCardKhachHangTitle.ForeColor = Color.FromArgb(100, 116, 139);
            lblCardKhachHangTitle.Location = new Point(14, 14);
            lblCardKhachHangTitle.Name = "lblCardKhachHangTitle";
            lblCardKhachHangTitle.Size = new Size(106, 19);
            lblCardKhachHangTitle.TabIndex = 0;
            lblCardKhachHangTitle.Text = "KHÁCH HÀNG";
            // 
            // pnlCardSanPham
            // 
            pnlCardSanPham.BackColor = Color.White;
            pnlCardSanPham.BorderStyle = BorderStyle.FixedSingle;
            pnlCardSanPham.Controls.Add(lblCardSanPhamSub);
            pnlCardSanPham.Controls.Add(lblCardSanPhamVal);
            pnlCardSanPham.Controls.Add(lblCardSanPhamTitle);
            pnlCardSanPham.Location = new Point(473, 145);
            pnlCardSanPham.Name = "pnlCardSanPham";
            pnlCardSanPham.Padding = new Padding(15);
            pnlCardSanPham.Size = new Size(215, 115);
            pnlCardSanPham.TabIndex = 3;
            // 
            // lblCardSanPhamSub
            // 
            lblCardSanPhamSub.AutoSize = true;
            lblCardSanPhamSub.Font = new Font("Segoe UI", 8.5F);
            lblCardSanPhamSub.ForeColor = Color.FromArgb(100, 116, 139);
            lblCardSanPhamSub.Location = new Point(14, 82);
            lblCardSanPhamSub.Name = "lblCardSanPhamSub";
            lblCardSanPhamSub.Size = new Size(140, 19);
            lblCardSanPhamSub.TabIndex = 2;
            lblCardSanPhamSub.Text = "📦 Mặt hàng còn tồn";
            // 
            // lblCardSanPhamVal
            // 
            lblCardSanPhamVal.AutoSize = true;
            lblCardSanPhamVal.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblCardSanPhamVal.ForeColor = Color.FromArgb(217, 119, 6);
            lblCardSanPhamVal.Location = new Point(12, 38);
            lblCardSanPhamVal.Name = "lblCardSanPhamVal";
            lblCardSanPhamVal.Size = new Size(102, 41);
            lblCardSanPhamVal.TabIndex = 1;
            lblCardSanPhamVal.Text = "12 SP";
            // 
            // lblCardSanPhamTitle
            // 
            lblCardSanPhamTitle.AutoSize = true;
            lblCardSanPhamTitle.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
            lblCardSanPhamTitle.ForeColor = Color.FromArgb(100, 116, 139);
            lblCardSanPhamTitle.Location = new Point(14, 14);
            lblCardSanPhamTitle.Name = "lblCardSanPhamTitle";
            lblCardSanPhamTitle.Size = new Size(88, 19);
            lblCardSanPhamTitle.TabIndex = 0;
            lblCardSanPhamTitle.Text = "SẢN PHẨM";
            // 
            // pnlCardHoaDon
            // 
            pnlCardHoaDon.BackColor = Color.White;
            pnlCardHoaDon.BorderStyle = BorderStyle.FixedSingle;
            pnlCardHoaDon.Controls.Add(lblCardHoaDonSub);
            pnlCardHoaDon.Controls.Add(lblCardHoaDonVal);
            pnlCardHoaDon.Controls.Add(lblCardHoaDonTitle);
            pnlCardHoaDon.Location = new Point(249, 145);
            pnlCardHoaDon.Name = "pnlCardHoaDon";
            pnlCardHoaDon.Padding = new Padding(15);
            pnlCardHoaDon.Size = new Size(215, 115);
            pnlCardHoaDon.TabIndex = 2;
            // 
            // lblCardHoaDonSub
            // 
            lblCardHoaDonSub.AutoSize = true;
            lblCardHoaDonSub.Font = new Font("Segoe UI", 8.5F);
            lblCardHoaDonSub.ForeColor = Color.FromArgb(100, 116, 139);
            lblCardHoaDonSub.Location = new Point(14, 82);
            lblCardHoaDonSub.Name = "lblCardHoaDonSub";
            lblCardHoaDonSub.Size = new Size(130, 19);
            lblCardHoaDonSub.TabIndex = 2;
            lblCardHoaDonSub.Text = "🧾 Đã lập trong ngày";
            // 
            // lblCardHoaDonVal
            // 
            lblCardHoaDonVal.AutoSize = true;
            lblCardHoaDonVal.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblCardHoaDonVal.ForeColor = Color.FromArgb(37, 99, 235);
            lblCardHoaDonVal.Location = new Point(12, 38);
            lblCardHoaDonVal.Name = "lblCardHoaDonVal";
            lblCardHoaDonVal.Size = new Size(106, 41);
            lblCardHoaDonVal.TabIndex = 1;
            lblCardHoaDonVal.Text = "5 đơn";
            // 
            // lblCardHoaDonTitle
            // 
            lblCardHoaDonTitle.AutoSize = true;
            lblCardHoaDonTitle.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
            lblCardHoaDonTitle.ForeColor = Color.FromArgb(100, 116, 139);
            lblCardHoaDonTitle.Location = new Point(14, 14);
            lblCardHoaDonTitle.Name = "lblCardHoaDonTitle";
            lblCardHoaDonTitle.Size = new Size(79, 19);
            lblCardHoaDonTitle.TabIndex = 0;
            lblCardHoaDonTitle.Text = "HÓA ĐƠN";
            // 
            // pnlCardDoanhThu
            // 
            pnlCardDoanhThu.BackColor = Color.White;
            pnlCardDoanhThu.BorderStyle = BorderStyle.FixedSingle;
            pnlCardDoanhThu.Controls.Add(lblCardDoanhThuSub);
            pnlCardDoanhThu.Controls.Add(lblCardDoanhThuVal);
            pnlCardDoanhThu.Controls.Add(lblCardDoanhThuTitle);
            pnlCardDoanhThu.Location = new Point(25, 145);
            pnlCardDoanhThu.Name = "pnlCardDoanhThu";
            pnlCardDoanhThu.Padding = new Padding(15);
            pnlCardDoanhThu.Size = new Size(215, 115);
            pnlCardDoanhThu.TabIndex = 1;
            // 
            // lblCardDoanhThuSub
            // 
            lblCardDoanhThuSub.AutoSize = true;
            lblCardDoanhThuSub.Font = new Font("Segoe UI", 8.5F);
            lblCardDoanhThuSub.ForeColor = Color.FromArgb(100, 116, 139);
            lblCardDoanhThuSub.Location = new Point(14, 82);
            lblCardDoanhThuSub.Name = "lblCardDoanhThuSub";
            lblCardDoanhThuSub.Size = new Size(141, 19);
            lblCardDoanhThuSub.TabIndex = 2;
            lblCardDoanhThuSub.Text = "📈 Doanh số hôm nay";
            // 
            // lblCardDoanhThuVal
            // 
            lblCardDoanhThuVal.AutoSize = true;
            lblCardDoanhThuVal.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblCardDoanhThuVal.ForeColor = Color.FromArgb(5, 150, 105);
            lblCardDoanhThuVal.Location = new Point(10, 41);
            lblCardDoanhThuVal.Name = "lblCardDoanhThuVal";
            lblCardDoanhThuVal.Size = new Size(198, 37);
            lblCardDoanhThuVal.TabIndex = 1;
            lblCardDoanhThuVal.Text = "16.500.000 đ";
            // 
            // lblCardDoanhThuTitle
            // 
            lblCardDoanhThuTitle.AutoSize = true;
            lblCardDoanhThuTitle.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
            lblCardDoanhThuTitle.ForeColor = Color.FromArgb(100, 116, 139);
            lblCardDoanhThuTitle.Location = new Point(14, 14);
            lblCardDoanhThuTitle.Name = "lblCardDoanhThuTitle";
            lblCardDoanhThuTitle.Size = new Size(97, 19);
            lblCardDoanhThuTitle.TabIndex = 0;
            lblCardDoanhThuTitle.Text = "DOANH THU";
            // 
            // pnlWelcomeBanner
            // 
            pnlWelcomeBanner.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            pnlWelcomeBanner.BackColor = Color.FromArgb(30, 64, 175);
            pnlWelcomeBanner.Controls.Add(lblWelcomeDesc);
            pnlWelcomeBanner.Controls.Add(lblWelcomeTitle);
            pnlWelcomeBanner.Location = new Point(25, 20);
            pnlWelcomeBanner.Name = "pnlWelcomeBanner";
            pnlWelcomeBanner.Padding = new Padding(25, 20, 25, 20);
            pnlWelcomeBanner.Size = new Size(895, 105);
            pnlWelcomeBanner.TabIndex = 0;
            // 
            // lblWelcomeDesc
            // 
            lblWelcomeDesc.AutoSize = true;
            lblWelcomeDesc.Font = new Font("Segoe UI", 9.5F);
            lblWelcomeDesc.ForeColor = Color.FromArgb(219, 234, 254);
            lblWelcomeDesc.Location = new Point(25, 60);
            lblWelcomeDesc.Name = "lblWelcomeDesc";
            lblWelcomeDesc.Size = new Size(670, 21);
            lblWelcomeDesc.TabIndex = 1;
            lblWelcomeDesc.Text = "Hệ thống quản lý bán hàng toàn diện: Lập hóa đơn, kiểm soát kho hàng, theo dõi doanh thu realtime.";
            // 
            // lblWelcomeTitle
            // 
            lblWelcomeTitle.AutoSize = true;
            lblWelcomeTitle.Font = new Font("Segoe UI", 13.5F, FontStyle.Bold);
            lblWelcomeTitle.ForeColor = Color.White;
            lblWelcomeTitle.Location = new Point(23, 20);
            lblWelcomeTitle.Name = "lblWelcomeTitle";
            lblWelcomeTitle.Size = new Size(712, 31);
            lblWelcomeTitle.TabIndex = 0;
            lblWelcomeTitle.Text = "Chào mừng bạn đến với Hệ thống Quản trị Bán hàng & Thu ngân";
            // 
            // statusStripTrangChu
            // 
            statusStripTrangChu.ImageScalingSize = new Size(20, 20);
            statusStripTrangChu.Items.AddRange(new ToolStripItem[] { lblStatusHeThong, lblStatusDatabase, lblStatusThoiGian });
            statusStripTrangChu.Location = new Point(250, 720);
            statusStripTrangChu.Name = "statusStripTrangChu";
            statusStripTrangChu.Size = new Size(950, 30);
            statusStripTrangChu.TabIndex = 3;
            statusStripTrangChu.Text = "statusStrip1";
            // 
            // lblStatusHeThong
            // 
            lblStatusHeThong.Font = new Font("Segoe UI", 9F);
            lblStatusHeThong.ForeColor = Color.FromArgb(71, 85, 105);
            lblStatusHeThong.Name = "lblStatusHeThong";
            lblStatusHeThong.Size = new Size(260, 24);
            lblStatusHeThong.Text = "🟢 Hệ thống sẵn sàng hoạt động (v1.0)";
            // 
            // lblStatusDatabase
            // 
            lblStatusDatabase.Font = new Font("Segoe UI", 9F);
            lblStatusDatabase.ForeColor = Color.FromArgb(71, 85, 105);
            lblStatusDatabase.Name = "lblStatusDatabase";
            lblStatusDatabase.Size = new Size(320, 24);
            lblStatusDatabase.Spring = true;
            lblStatusDatabase.Text = "CSDL: Microsoft SQL Server (QuanLyBanHang)";
            // 
            // lblStatusThoiGian
            // 
            lblStatusThoiGian.Font = new Font("Segoe UI", 9F);
            lblStatusThoiGian.ForeColor = Color.FromArgb(71, 85, 105);
            lblStatusThoiGian.Name = "lblStatusThoiGian";
            lblStatusThoiGian.Size = new Size(130, 24);
            lblStatusThoiGian.Text = "Trạng thái: Đã kết nối";
            // 
            // FrmTrangChu
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(244, 246, 249);
            ClientSize = new Size(1200, 750);
            Controls.Add(statusStripTrangChu);
            Controls.Add(pnlMain);
            Controls.Add(pnlHeader);
            Controls.Add(pnlSidebar);
            MinimumSize = new Size(1000, 650);
            Name = "FrmTrangChu";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Hệ thống Quản lý Bán hàng - Trang Chủ";
            pnlSidebar.ResumeLayout(false);
            pnlSidebarBottom.ResumeLayout(false);
            pnlLogo.ResumeLayout(false);
            pnlLogo.PerformLayout();
            pnlHeader.ResumeLayout(false);
            pnlHeader.PerformLayout();
            pnlMain.ResumeLayout(false);
            grpQuickActions.ResumeLayout(false);
            pnlCardKhachHang.ResumeLayout(false);
            pnlCardKhachHang.PerformLayout();
            pnlCardSanPham.ResumeLayout(false);
            pnlCardSanPham.PerformLayout();
            pnlCardHoaDon.ResumeLayout(false);
            pnlCardHoaDon.PerformLayout();
            pnlCardDoanhThu.ResumeLayout(false);
            pnlCardDoanhThu.PerformLayout();
            pnlWelcomeBanner.ResumeLayout(false);
            pnlWelcomeBanner.PerformLayout();
            statusStripTrangChu.ResumeLayout(false);
            statusStripTrangChu.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel pnlSidebar;
        private Panel pnlLogo;
        private Label lblStoreName;
        private Label lblStoreSub;
        private Button btnMenuTrangChu;
        private Button btnMenuBanHang;
        private Button btnMenuSanPham;
        private Button btnMenuKhachHang;
        private Button btnMenuNhapHang;
        private Button btnMenuTaiKhoan;
        private Button btnMenuThongKe;
        private Panel pnlSidebarBottom;
        private Button btnDangXuat;
        private Button btnThoat;
        private Panel pnlHeader;
        private Label lblTitle;
        private Label lblXinChao;
        private Label lblDongHo;
        private Panel pnlMain;
        private Panel pnlWelcomeBanner;
        private Label lblWelcomeTitle;
        private Label lblWelcomeDesc;
        private Panel pnlCardDoanhThu;
        private Label lblCardDoanhThuTitle;
        private Label lblCardDoanhThuVal;
        private Label lblCardDoanhThuSub;
        private Panel pnlCardHoaDon;
        private Label lblCardHoaDonTitle;
        private Label lblCardHoaDonVal;
        private Label lblCardHoaDonSub;
        private Panel pnlCardSanPham;
        private Label lblCardSanPhamTitle;
        private Label lblCardSanPhamVal;
        private Label lblCardSanPhamSub;
        private Panel pnlCardKhachHang;
        private Label lblCardKhachHangTitle;
        private Label lblCardKhachHangVal;
        private Label lblCardKhachHangSub;
        private GroupBox grpQuickActions;
        private Button btnQuickBanHang;
        private Button btnQuickSanPham;
        private Button btnQuickKhachHang;
        private Button btnQuickThongKe;
        private Button btnQuickNhapHang;
        private Button btnQuickTaiKhoan;
        private StatusStrip statusStripTrangChu;
        private ToolStripStatusLabel lblStatusHeThong;
        private ToolStripStatusLabel lblStatusDatabase;
        private ToolStripStatusLabel lblStatusThoiGian;
        private System.Windows.Forms.Timer tmrDongHo;
    }
}
