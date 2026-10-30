namespace QuanLyBanHang.UI
{
    partial class FrmThongKe
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
            lblTieuDeForm = new Label();
            grpBoLoc = new GroupBox();
            button1 = new Button();
            btnThongKe = new Button();
            txtTimKiem = new TextBox();
            cboTrangThai = new ComboBox();
            dtpDenNgay = new DateTimePicker();
            dtpTuNgay = new DateTimePicker();
            lblTimKiem = new Label();
            lblTrangThai = new Label();
            lblDenNgay = new Label();
            lblTuNgay = new Label();
            tblCards = new TableLayoutPanel();
            panel1 = new Panel();
            lblSoHoaDon = new Label();
            lblTitleSoHoaDon = new Label();
            panel2 = new Panel();
            lblTongDoanhThu = new Label();
            lblTitleTongDoanhThu = new Label();
            panel3 = new Panel();
            lblSoHoaDonHuy = new Label();
            lblTitleSoHoaDonHuy = new Label();
            panel4 = new Panel();
            lblGiaTriTrungBinh = new Label();
            lblTitleGiaTriTrungBinh = new Label();
            grpDanhSachHoaDon = new GroupBox();
            dgvHoaDon = new DataGridView();
            colHD_Ma = new DataGridViewTextBoxColumn();
            colHD_NgayLap = new DataGridViewTextBoxColumn();
            colHD_KhachHang = new DataGridViewTextBoxColumn();
            colHD_TrangThai = new DataGridViewTextBoxColumn();
            colHD_TongTien = new DataGridViewTextBoxColumn();
            tblGrids = new TableLayoutPanel();
            grpChiTietHoaDon = new GroupBox();
            dgvChiTietHoaDon = new DataGridView();
            colCT_STT = new DataGridViewTextBoxColumn();
            colCT_MaSP = new DataGridViewTextBoxColumn();
            colCT_DVT = new DataGridViewTextBoxColumn();
            colCT_SoLuong = new DataGridViewTextBoxColumn();
            colCT_ThanhTien = new DataGridViewTextBoxColumn();
            panelChucNang = new Panel();
            btnHome = new Button();
            btnDong = new Button();
            btnXuatBaoCao = new Button();
            grpBoLoc.SuspendLayout();
            tblCards.SuspendLayout();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            panel4.SuspendLayout();
            grpDanhSachHoaDon.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvHoaDon).BeginInit();
            tblGrids.SuspendLayout();
            grpChiTietHoaDon.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvChiTietHoaDon).BeginInit();
            panelChucNang.SuspendLayout();
            SuspendLayout();
            // 
            // lblTieuDeForm
            // 
            lblTieuDeForm.BackColor = Color.FromArgb(239, 246, 255);
            lblTieuDeForm.Dock = DockStyle.Top;
            lblTieuDeForm.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblTieuDeForm.ForeColor = Color.FromArgb(30, 58, 138);
            lblTieuDeForm.Location = new Point(0, 0);
            lblTieuDeForm.Name = "lblTieuDeForm";
            lblTieuDeForm.Size = new Size(1353, 61);
            lblTieuDeForm.TabIndex = 0;
            lblTieuDeForm.Text = "BÁO CÁO VÀ THỐNG KÊ DOANH THU BÁN HÀNG";
            lblTieuDeForm.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // grpBoLoc
            // 
            grpBoLoc.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            grpBoLoc.Controls.Add(button1);
            grpBoLoc.Controls.Add(btnThongKe);
            grpBoLoc.Controls.Add(txtTimKiem);
            grpBoLoc.Controls.Add(cboTrangThai);
            grpBoLoc.Controls.Add(dtpDenNgay);
            grpBoLoc.Controls.Add(dtpTuNgay);
            grpBoLoc.Controls.Add(lblTimKiem);
            grpBoLoc.Controls.Add(lblTrangThai);
            grpBoLoc.Controls.Add(lblDenNgay);
            grpBoLoc.Controls.Add(lblTuNgay);
            grpBoLoc.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            grpBoLoc.ForeColor = Color.FromArgb(30, 41, 59);
            grpBoLoc.Location = new Point(17, 69);
            grpBoLoc.Margin = new Padding(3, 4, 3, 4);
            grpBoLoc.Name = "grpBoLoc";
            grpBoLoc.Padding = new Padding(3, 4, 3, 4);
            grpBoLoc.Size = new Size(1319, 101);
            grpBoLoc.TabIndex = 1;
            grpBoLoc.TabStop = false;
            grpBoLoc.Text = "A. Bộ lọc báo cáo";
            // 
            // button1
            // 
            button1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            button1.BackColor = Color.FromArgb(241, 245, 249);
            button1.Cursor = Cursors.Hand;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Segoe UI", 9.5F);
            button1.ForeColor = Color.FromArgb(15, 23, 42);
            button1.Location = new Point(1195, 33);
            button1.Margin = new Padding(3, 4, 3, 4);
            button1.Name = "button1";
            button1.Size = new Size(109, 45);
            button1.TabIndex = 9;
            button1.Text = "🔄 Đặt lại";
            button1.UseVisualStyleBackColor = false;
            // 
            // btnThongKe
            // 
            btnThongKe.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnThongKe.BackColor = Color.FromArgb(37, 99, 235);
            btnThongKe.Cursor = Cursors.Hand;
            btnThongKe.FlatStyle = FlatStyle.Flat;
            btnThongKe.ForeColor = Color.White;
            btnThongKe.Location = new Point(1060, 33);
            btnThongKe.Margin = new Padding(3, 4, 3, 4);
            btnThongKe.Name = "btnThongKe";
            btnThongKe.Size = new Size(126, 45);
            btnThongKe.TabIndex = 8;
            btnThongKe.Text = "🔍 Thống kê";
            btnThongKe.UseVisualStyleBackColor = false;
            // 
            // txtTimKiem
            // 
            txtTimKiem.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtTimKiem.Font = new Font("Segoe UI", 9.5F);
            txtTimKiem.Location = new Point(818, 40);
            txtTimKiem.Margin = new Padding(3, 4, 3, 4);
            txtTimKiem.Name = "txtTimKiem";
            txtTimKiem.PlaceholderText = "Mã HĐ hoặc tên khách hàng...";
            txtTimKiem.Size = new Size(222, 29);
            txtTimKiem.TabIndex = 7;
            // 
            // cboTrangThai
            // 
            cboTrangThai.DropDownWidth = 154;
            cboTrangThai.Font = new Font("Segoe UI", 9.5F);
            cboTrangThai.FormattingEnabled = true;
            cboTrangThai.Location = new Point(574, 40);
            cboTrangThai.Margin = new Padding(3, 4, 3, 4);
            cboTrangThai.Name = "cboTrangThai";
            cboTrangThai.Size = new Size(154, 29);
            cboTrangThai.TabIndex = 5;
            // 
            // dtpDenNgay
            // 
            dtpDenNgay.CalendarFont = new Font("Segoe UI", 9.5F);
            dtpDenNgay.CustomFormat = "dd/MM/yyyy";
            dtpDenNgay.Font = new Font("Segoe UI", 9.5F);
            dtpDenNgay.Format = DateTimePickerFormat.Custom;
            dtpDenNgay.Location = new Point(325, 40);
            dtpDenNgay.Margin = new Padding(3, 4, 3, 4);
            dtpDenNgay.Name = "dtpDenNgay";
            dtpDenNgay.Size = new Size(142, 29);
            dtpDenNgay.TabIndex = 3;
            // 
            // dtpTuNgay
            // 
            dtpTuNgay.CalendarFont = new Font("Segoe UI", 9.5F);
            dtpTuNgay.CustomFormat = "dd/MM/yyyy";
            dtpTuNgay.Font = new Font("Segoe UI", 9.5F);
            dtpTuNgay.Format = DateTimePickerFormat.Custom;
            dtpTuNgay.Location = new Point(89, 40);
            dtpTuNgay.Margin = new Padding(3, 4, 3, 4);
            dtpTuNgay.Name = "dtpTuNgay";
            dtpTuNgay.Size = new Size(142, 29);
            dtpTuNgay.TabIndex = 1;
            // 
            // lblTimKiem
            // 
            lblTimKiem.AutoSize = true;
            lblTimKiem.Font = new Font("Segoe UI", 9.5F);
            lblTimKiem.Location = new Point(747, 45);
            lblTimKiem.Name = "lblTimKiem";
            lblTimKiem.Size = new Size(68, 21);
            lblTimKiem.TabIndex = 6;
            lblTimKiem.Text = "Từ khóa:";
            // 
            // lblTrangThai
            // 
            lblTrangThai.AutoSize = true;
            lblTrangThai.Font = new Font("Segoe UI", 9.5F);
            lblTrangThai.Location = new Point(488, 45);
            lblTrangThai.Name = "lblTrangThai";
            lblTrangThai.Size = new Size(82, 21);
            lblTrangThai.TabIndex = 4;
            lblTrangThai.Text = "Trạng thái:";
            // 
            // lblDenNgay
            // 
            lblDenNgay.AutoSize = true;
            lblDenNgay.Font = new Font("Segoe UI", 9.5F);
            lblDenNgay.Location = new Point(245, 45);
            lblDenNgay.Name = "lblDenNgay";
            lblDenNgay.Size = new Size(79, 21);
            lblDenNgay.TabIndex = 2;
            lblDenNgay.Text = "Đến ngày:";
            // 
            // lblTuNgay
            // 
            lblTuNgay.AutoSize = true;
            lblTuNgay.Font = new Font("Segoe UI", 9.5F);
            lblTuNgay.Location = new Point(17, 45);
            lblTuNgay.Name = "lblTuNgay";
            lblTuNgay.Size = new Size(68, 21);
            lblTuNgay.TabIndex = 0;
            lblTuNgay.Text = "Từ ngày:";
            // 
            // tblCards
            // 
            tblCards.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            tblCards.ColumnCount = 4;
            tblCards.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tblCards.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tblCards.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tblCards.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tblCards.Controls.Add(panel1, 0, 0);
            tblCards.Controls.Add(panel2, 1, 0);
            tblCards.Controls.Add(panel3, 2, 0);
            tblCards.Controls.Add(panel4, 3, 0);
            tblCards.Location = new Point(17, 179);
            tblCards.Margin = new Padding(3, 4, 3, 4);
            tblCards.Name = "tblCards";
            tblCards.RowCount = 1;
            tblCards.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tblCards.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tblCards.Size = new Size(1319, 117);
            tblCards.TabIndex = 2;
            // 
            // panel1
            // 
            panel1.BackColor = Color.White;
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(lblSoHoaDon);
            panel1.Controls.Add(lblTitleSoHoaDon);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(3, 3);
            panel1.Name = "panel1";
            panel1.Size = new Size(323, 111);
            panel1.TabIndex = 0;
            // 
            // lblSoHoaDon
            // 
            lblSoHoaDon.BackColor = Color.White;
            lblSoHoaDon.Dock = DockStyle.Fill;
            lblSoHoaDon.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblSoHoaDon.ForeColor = Color.FromArgb(21, 128, 61);
            lblSoHoaDon.Location = new Point(0, 37);
            lblSoHoaDon.Name = "lblSoHoaDon";
            lblSoHoaDon.Padding = new Padding(14, 0, 0, 0);
            lblSoHoaDon.Size = new Size(321, 72);
            lblSoHoaDon.TabIndex = 1;
            lblSoHoaDon.Text = "0";
            lblSoHoaDon.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblTitleSoHoaDon
            // 
            lblTitleSoHoaDon.BackColor = Color.White;
            lblTitleSoHoaDon.Dock = DockStyle.Top;
            lblTitleSoHoaDon.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
            lblTitleSoHoaDon.ForeColor = Color.FromArgb(100, 116, 139);
            lblTitleSoHoaDon.Location = new Point(0, 0);
            lblTitleSoHoaDon.Name = "lblTitleSoHoaDon";
            lblTitleSoHoaDon.Padding = new Padding(14, 13, 0, 0);
            lblTitleSoHoaDon.Size = new Size(321, 37);
            lblTitleSoHoaDon.TabIndex = 0;
            lblTitleSoHoaDon.Text = "SỐ HÓA ĐƠN HOÀN THÀNH";
            // 
            // panel2
            // 
            panel2.BackColor = Color.White;
            panel2.BorderStyle = BorderStyle.FixedSingle;
            panel2.Controls.Add(lblTongDoanhThu);
            panel2.Controls.Add(lblTitleTongDoanhThu);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(332, 3);
            panel2.Name = "panel2";
            panel2.Size = new Size(323, 111);
            panel2.TabIndex = 1;
            // 
            // lblTongDoanhThu
            // 
            lblTongDoanhThu.BackColor = Color.White;
            lblTongDoanhThu.Dock = DockStyle.Fill;
            lblTongDoanhThu.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblTongDoanhThu.ForeColor = Color.FromArgb(29, 78, 216);
            lblTongDoanhThu.Location = new Point(0, 37);
            lblTongDoanhThu.Name = "lblTongDoanhThu";
            lblTongDoanhThu.Padding = new Padding(14, 0, 0, 0);
            lblTongDoanhThu.Size = new Size(321, 72);
            lblTongDoanhThu.TabIndex = 1;
            lblTongDoanhThu.Text = "0 VNĐ";
            lblTongDoanhThu.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblTitleTongDoanhThu
            // 
            lblTitleTongDoanhThu.BackColor = Color.White;
            lblTitleTongDoanhThu.Dock = DockStyle.Top;
            lblTitleTongDoanhThu.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
            lblTitleTongDoanhThu.ForeColor = Color.FromArgb(100, 116, 139);
            lblTitleTongDoanhThu.Location = new Point(0, 0);
            lblTitleTongDoanhThu.Name = "lblTitleTongDoanhThu";
            lblTitleTongDoanhThu.Padding = new Padding(14, 13, 0, 0);
            lblTitleTongDoanhThu.Size = new Size(321, 37);
            lblTitleTongDoanhThu.TabIndex = 1;
            lblTitleTongDoanhThu.Text = "TỔNG DOANH THU";
            // 
            // panel3
            // 
            panel3.BackColor = Color.White;
            panel3.BorderStyle = BorderStyle.FixedSingle;
            panel3.Controls.Add(lblSoHoaDonHuy);
            panel3.Controls.Add(lblTitleSoHoaDonHuy);
            panel3.Dock = DockStyle.Fill;
            panel3.Location = new Point(661, 3);
            panel3.Name = "panel3";
            panel3.Size = new Size(323, 111);
            panel3.TabIndex = 2;
            // 
            // lblSoHoaDonHuy
            // 
            lblSoHoaDonHuy.BackColor = Color.White;
            lblSoHoaDonHuy.Dock = DockStyle.Fill;
            lblSoHoaDonHuy.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblSoHoaDonHuy.ForeColor = Color.FromArgb(185, 28, 28);
            lblSoHoaDonHuy.Location = new Point(0, 37);
            lblSoHoaDonHuy.Name = "lblSoHoaDonHuy";
            lblSoHoaDonHuy.Padding = new Padding(14, 0, 0, 0);
            lblSoHoaDonHuy.Size = new Size(321, 72);
            lblSoHoaDonHuy.TabIndex = 1;
            lblSoHoaDonHuy.Text = "0";
            lblSoHoaDonHuy.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblTitleSoHoaDonHuy
            // 
            lblTitleSoHoaDonHuy.BackColor = Color.White;
            lblTitleSoHoaDonHuy.Dock = DockStyle.Top;
            lblTitleSoHoaDonHuy.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
            lblTitleSoHoaDonHuy.ForeColor = Color.FromArgb(100, 116, 139);
            lblTitleSoHoaDonHuy.Location = new Point(0, 0);
            lblTitleSoHoaDonHuy.Name = "lblTitleSoHoaDonHuy";
            lblTitleSoHoaDonHuy.Padding = new Padding(14, 13, 0, 0);
            lblTitleSoHoaDonHuy.Size = new Size(321, 37);
            lblTitleSoHoaDonHuy.TabIndex = 1;
            lblTitleSoHoaDonHuy.Text = "HÓA ĐƠN BỊ HỦY";
            // 
            // panel4
            // 
            panel4.BackColor = Color.White;
            panel4.BorderStyle = BorderStyle.FixedSingle;
            panel4.Controls.Add(lblGiaTriTrungBinh);
            panel4.Controls.Add(lblTitleGiaTriTrungBinh);
            panel4.Dock = DockStyle.Fill;
            panel4.Location = new Point(990, 3);
            panel4.Name = "panel4";
            panel4.Size = new Size(326, 111);
            panel4.TabIndex = 3;
            // 
            // lblGiaTriTrungBinh
            // 
            lblGiaTriTrungBinh.BackColor = Color.White;
            lblGiaTriTrungBinh.Dock = DockStyle.Fill;
            lblGiaTriTrungBinh.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblGiaTriTrungBinh.ForeColor = Color.FromArgb(79, 70, 229);
            lblGiaTriTrungBinh.Location = new Point(0, 37);
            lblGiaTriTrungBinh.Name = "lblGiaTriTrungBinh";
            lblGiaTriTrungBinh.Padding = new Padding(14, 0, 0, 0);
            lblGiaTriTrungBinh.Size = new Size(324, 72);
            lblGiaTriTrungBinh.TabIndex = 1;
            lblGiaTriTrungBinh.Text = "0 VNĐ";
            lblGiaTriTrungBinh.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblTitleGiaTriTrungBinh
            // 
            lblTitleGiaTriTrungBinh.BackColor = Color.White;
            lblTitleGiaTriTrungBinh.Dock = DockStyle.Top;
            lblTitleGiaTriTrungBinh.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
            lblTitleGiaTriTrungBinh.ForeColor = Color.FromArgb(100, 116, 139);
            lblTitleGiaTriTrungBinh.Location = new Point(0, 0);
            lblTitleGiaTriTrungBinh.Name = "lblTitleGiaTriTrungBinh";
            lblTitleGiaTriTrungBinh.Padding = new Padding(14, 13, 0, 0);
            lblTitleGiaTriTrungBinh.Size = new Size(324, 37);
            lblTitleGiaTriTrungBinh.TabIndex = 1;
            lblTitleGiaTriTrungBinh.Text = "GIÁ TRỊ TRUNG BÌNH / ĐƠN";
            // 
            // grpDanhSachHoaDon
            // 
            grpDanhSachHoaDon.Controls.Add(dgvHoaDon);
            grpDanhSachHoaDon.Dock = DockStyle.Fill;
            grpDanhSachHoaDon.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            grpDanhSachHoaDon.ForeColor = Color.FromArgb(30, 41, 59);
            grpDanhSachHoaDon.Location = new Point(0, 0);
            grpDanhSachHoaDon.Margin = new Padding(0, 0, 9, 0);
            grpDanhSachHoaDon.Name = "grpDanhSachHoaDon";
            grpDanhSachHoaDon.Padding = new Padding(11, 13, 11, 13);
            grpDanhSachHoaDon.Size = new Size(650, 560);
            grpDanhSachHoaDon.TabIndex = 0;
            grpDanhSachHoaDon.TabStop = false;
            grpDanhSachHoaDon.Text = "B. Danh sách hóa đơn (Chọn một hóa đơn để xem chi tiết)";
            // 
            // dgvHoaDon
            // 
            dgvHoaDon.AllowUserToAddRows = false;
            dgvHoaDon.AllowUserToDeleteRows = false;
            dgvHoaDon.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvHoaDon.BackgroundColor = Color.White;
            dgvHoaDon.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvHoaDon.Columns.AddRange(new DataGridViewColumn[] { colHD_Ma, colHD_NgayLap, colHD_KhachHang, colHD_TrangThai, colHD_TongTien });
            dgvHoaDon.Dock = DockStyle.Fill;
            dgvHoaDon.Location = new Point(11, 35);
            dgvHoaDon.Margin = new Padding(3, 4, 3, 4);
            dgvHoaDon.Name = "dgvHoaDon";
            dgvHoaDon.ReadOnly = true;
            dgvHoaDon.RowHeadersVisible = false;
            dgvHoaDon.RowHeadersWidth = 51;
            dgvHoaDon.Size = new Size(628, 512);
            dgvHoaDon.TabIndex = 0;
            // 
            // colHD_Ma
            // 
            colHD_Ma.HeaderText = "Mã HĐ";
            colHD_Ma.MinimumWidth = 6;
            colHD_Ma.Name = "colHD_Ma";
            colHD_Ma.ReadOnly = true;
            // 
            // colHD_NgayLap
            // 
            colHD_NgayLap.HeaderText = "Ngày lập";
            colHD_NgayLap.MinimumWidth = 6;
            colHD_NgayLap.Name = "colHD_NgayLap";
            colHD_NgayLap.ReadOnly = true;
            // 
            // colHD_KhachHang
            // 
            colHD_KhachHang.HeaderText = "Khánh hàng";
            colHD_KhachHang.MinimumWidth = 6;
            colHD_KhachHang.Name = "colHD_KhachHang";
            colHD_KhachHang.ReadOnly = true;
            // 
            // colHD_TrangThai
            // 
            colHD_TrangThai.HeaderText = "Trạng thái";
            colHD_TrangThai.MinimumWidth = 6;
            colHD_TrangThai.Name = "colHD_TrangThai";
            colHD_TrangThai.ReadOnly = true;
            // 
            // colHD_TongTien
            // 
            colHD_TongTien.HeaderText = "Tổng tiền";
            colHD_TongTien.MinimumWidth = 6;
            colHD_TongTien.Name = "colHD_TongTien";
            colHD_TongTien.ReadOnly = true;
            // 
            // tblGrids
            // 
            tblGrids.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tblGrids.ColumnCount = 2;
            tblGrids.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tblGrids.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tblGrids.Controls.Add(grpChiTietHoaDon, 1, 0);
            tblGrids.Controls.Add(grpDanhSachHoaDon, 0, 0);
            tblGrids.Location = new Point(17, 307);
            tblGrids.Margin = new Padding(3, 4, 3, 4);
            tblGrids.Name = "tblGrids";
            tblGrids.RowCount = 1;
            tblGrids.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tblGrids.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tblGrids.Size = new Size(1319, 560);
            tblGrids.TabIndex = 3;
            // 
            // grpChiTietHoaDon
            // 
            grpChiTietHoaDon.Controls.Add(dgvChiTietHoaDon);
            grpChiTietHoaDon.Dock = DockStyle.Fill;
            grpChiTietHoaDon.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            grpChiTietHoaDon.ForeColor = Color.FromArgb(30, 41, 59);
            grpChiTietHoaDon.Location = new Point(668, 0);
            grpChiTietHoaDon.Margin = new Padding(9, 0, 0, 0);
            grpChiTietHoaDon.Name = "grpChiTietHoaDon";
            grpChiTietHoaDon.Padding = new Padding(11, 13, 11, 13);
            grpChiTietHoaDon.Size = new Size(651, 560);
            grpChiTietHoaDon.TabIndex = 1;
            grpChiTietHoaDon.TabStop = false;
            grpChiTietHoaDon.Text = "C. Chi tiết hóa đơn được chọn";
            // 
            // dgvChiTietHoaDon
            // 
            dgvChiTietHoaDon.AllowUserToAddRows = false;
            dgvChiTietHoaDon.AllowUserToDeleteRows = false;
            dgvChiTietHoaDon.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvChiTietHoaDon.BackgroundColor = Color.White;
            dgvChiTietHoaDon.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvChiTietHoaDon.Columns.AddRange(new DataGridViewColumn[] { colCT_STT, colCT_MaSP, colCT_DVT, colCT_SoLuong, colCT_ThanhTien });
            dgvChiTietHoaDon.Dock = DockStyle.Fill;
            dgvChiTietHoaDon.Location = new Point(11, 35);
            dgvChiTietHoaDon.Margin = new Padding(3, 4, 3, 4);
            dgvChiTietHoaDon.Name = "dgvChiTietHoaDon";
            dgvChiTietHoaDon.ReadOnly = true;
            dgvChiTietHoaDon.RowHeadersVisible = false;
            dgvChiTietHoaDon.RowHeadersWidth = 51;
            dgvChiTietHoaDon.Size = new Size(629, 512);
            dgvChiTietHoaDon.TabIndex = 0;
            // 
            // colCT_STT
            // 
            colCT_STT.HeaderText = "STT";
            colCT_STT.MinimumWidth = 6;
            colCT_STT.Name = "colCT_STT";
            colCT_STT.ReadOnly = true;
            // 
            // colCT_MaSP
            // 
            colCT_MaSP.HeaderText = "Mã SP";
            colCT_MaSP.MinimumWidth = 6;
            colCT_MaSP.Name = "colCT_MaSP";
            colCT_MaSP.ReadOnly = true;
            // 
            // colCT_DVT
            // 
            colCT_DVT.HeaderText = "ĐVT";
            colCT_DVT.MinimumWidth = 6;
            colCT_DVT.Name = "colCT_DVT";
            colCT_DVT.ReadOnly = true;
            // 
            // colCT_SoLuong
            // 
            colCT_SoLuong.HeaderText = "Số lượng";
            colCT_SoLuong.MinimumWidth = 6;
            colCT_SoLuong.Name = "colCT_SoLuong";
            colCT_SoLuong.ReadOnly = true;
            // 
            // colCT_ThanhTien
            // 
            colCT_ThanhTien.HeaderText = "Thành tiền";
            colCT_ThanhTien.MinimumWidth = 6;
            colCT_ThanhTien.Name = "colCT_ThanhTien";
            colCT_ThanhTien.ReadOnly = true;
            // 
            // panelChucNang
            // 
            panelChucNang.Controls.Add(btnHome);
            panelChucNang.Controls.Add(btnDong);
            panelChucNang.Controls.Add(btnXuatBaoCao);
            panelChucNang.Dock = DockStyle.Bottom;
            panelChucNang.Location = new Point(0, 874);
            panelChucNang.Name = "panelChucNang";
            panelChucNang.Size = new Size(1353, 87);
            panelChucNang.TabIndex = 4;
            // 
            // btnHome
            // 
            btnHome.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnHome.BackColor = Color.FromArgb(37, 99, 235);
            btnHome.Cursor = Cursors.Hand;
            btnHome.FlatStyle = FlatStyle.Flat;
            btnHome.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnHome.ForeColor = Color.White;
            btnHome.Location = new Point(30, 19);
            btnHome.Margin = new Padding(3, 4, 3, 4);
            btnHome.Name = "btnHome";
            btnHome.Size = new Size(150, 48);
            btnHome.TabIndex = 11;
            btnHome.Text = "⌂ Home";
            btnHome.UseVisualStyleBackColor = false;
            // 
            // btnDong
            // 
            btnDong.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnDong.BackColor = Color.FromArgb(226, 232, 240);
            btnDong.Cursor = Cursors.Hand;
            btnDong.FlatStyle = FlatStyle.Flat;
            btnDong.Font = new Font("Segoe UI", 9.5F);
            btnDong.ForeColor = Color.FromArgb(15, 23, 42);
            btnDong.Location = new Point(1200, 19);
            btnDong.Margin = new Padding(3, 4, 3, 4);
            btnDong.Name = "btnDong";
            btnDong.Size = new Size(131, 48);
            btnDong.TabIndex = 10;
            btnDong.Text = "🚪 Đóng";
            btnDong.UseVisualStyleBackColor = false;
            // 
            // btnXuatBaoCao
            // 
            btnXuatBaoCao.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnXuatBaoCao.BackColor = Color.FromArgb(22, 163, 74);
            btnXuatBaoCao.Cursor = Cursors.Hand;
            btnXuatBaoCao.FlatStyle = FlatStyle.Flat;
            btnXuatBaoCao.ForeColor = Color.White;
            btnXuatBaoCao.Location = new Point(956, 19);
            btnXuatBaoCao.Margin = new Padding(3, 4, 3, 4);
            btnXuatBaoCao.Name = "btnXuatBaoCao";
            btnXuatBaoCao.Size = new Size(217, 48);
            btnXuatBaoCao.TabIndex = 9;
            btnXuatBaoCao.Text = "📊 Xuất Báo Cáo (Excel)";
            btnXuatBaoCao.UseVisualStyleBackColor = false;
            // 
            // FrmThongKe
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(248, 250, 252);
            ClientSize = new Size(1353, 961);
            Controls.Add(panelChucNang);
            Controls.Add(tblGrids);
            Controls.Add(tblCards);
            Controls.Add(grpBoLoc);
            Controls.Add(lblTieuDeForm);
            Name = "FrmThongKe";
            Text = "FrmThongKe";
            grpBoLoc.ResumeLayout(false);
            grpBoLoc.PerformLayout();
            tblCards.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel3.ResumeLayout(false);
            panel4.ResumeLayout(false);
            grpDanhSachHoaDon.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvHoaDon).EndInit();
            tblGrids.ResumeLayout(false);
            grpChiTietHoaDon.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvChiTietHoaDon).EndInit();
            panelChucNang.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Label lblTieuDeForm;
        private GroupBox grpBoLoc;
        private Label lblTuNgay;
        private DateTimePicker dtpTuNgay;
        private Label lblTimKiem;
        private Label lblTrangThai;
        private Label lblDenNgay;
        private TextBox txtTimKiem;
        private ComboBox cboTrangThai;
        private DateTimePicker dtpDenNgay;
        private Button button1;
        private Button btnThongKe;
        private TableLayoutPanel tblCards;
        private Panel panel1;
        private Label lblTitleSoHoaDon;
        private Panel panel2;
        private Panel panel3;
        private Panel panel4;
        private Label label1;
        private Label lblTitleTongDoanhThu;
        private Label lblSoHoaDon;
        private Label lblTongDoanhThu;
        private Label lblSoHoaDonHuy;
        private Label lblTitleSoHoaDonHuy;
        private Label lblGiaTriTrungBinh;
        private Label lblTitleGiaTriTrungBinh;
        private GroupBox grpDanhSachHoaDon;
        private TableLayoutPanel tblGrids;
        private GroupBox grpChiTietHoaDon;
        private Panel panelChucNang;
        private Button btnXuatBaoCao;
        private Button btnDong;
        private Button btnHome;
        private DataGridView dgvHoaDon;
        private DataGridView dgvChiTietHoaDon;
        private DataGridViewTextBoxColumn colCT_STT;
        private DataGridViewTextBoxColumn colCT_MaSP;
        private DataGridViewTextBoxColumn colCT_DVT;
        private DataGridViewTextBoxColumn colCT_SoLuong;
        private DataGridViewTextBoxColumn colCT_ThanhTien;
        private DataGridViewTextBoxColumn colHD_Ma;
        private DataGridViewTextBoxColumn colHD_NgayLap;
        private DataGridViewTextBoxColumn colHD_KhachHang;
        private DataGridViewTextBoxColumn colHD_TrangThai;
        private DataGridViewTextBoxColumn colHD_TongTien;
        private Label label3;
    }
}