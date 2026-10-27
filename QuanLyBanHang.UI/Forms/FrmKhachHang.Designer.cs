namespace QuanLyBanHang.UI
{
    partial class FrmKhachHang
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
            grpThongTinKhachHang = new GroupBox();
            cboTrangThai = new ComboBox();
            lblTrangThai = new Label();
            txtGhiChu = new TextBox();
            lblGhiChu = new Label();
            txtDiaChi = new TextBox();
            lblDiaChi = new Label();
            cboLoaiKhachHang = new ComboBox();
            lblLoaiKhachHang = new Label();
            dtpNgaySinh = new DateTimePicker();
            lblNgaySinh = new Label();
            cboGioiTinh = new ComboBox();
            lblGioiTinh = new Label();
            txtEmail = new TextBox();
            lblEmail = new Label();
            txtSoDienThoai = new TextBox();
            lblSoDienThoai = new Label();
            txtTenKhachHang = new TextBox();
            lblTenKhachHang = new Label();
            txtMaKhachHang = new TextBox();
            lblMaKhachHang = new Label();
            grpDanhSachKhachHang = new GroupBox();
            lblTongSoKhachHang = new Label();
            btnDatLai = new Button();
            btnTimKiem = new Button();
            cboLocLoaiKH = new ComboBox();
            lblLocLoaiKH = new Label();
            txtTimKiem = new TextBox();
            lblTimKiem = new Label();
            dgvKhachHang = new DataGridView();
            colSTT = new DataGridViewTextBoxColumn();
            colMaKH = new DataGridViewTextBoxColumn();
            colTenKH = new DataGridViewTextBoxColumn();
            colGioiTinh = new DataGridViewTextBoxColumn();
            colNgaySinh = new DataGridViewTextBoxColumn();
            colSoDienThoai = new DataGridViewTextBoxColumn();
            colEmail = new DataGridViewTextBoxColumn();
            colLoaiKH = new DataGridViewTextBoxColumn();
            colDiaChi = new DataGridViewTextBoxColumn();
            colTrangThai = new DataGridViewTextBoxColumn();
            colGhiChu = new DataGridViewTextBoxColumn();
            pnlChucNang = new Panel();
            btnHome = new Button();
            btnLuu = new Button();
            btnThem = new Button();
            btnSua = new Button();
            btnXoa = new Button();
            btnLamMoi = new Button();
            btnXuatExcel = new Button();
            btnDong = new Button();
            grpThongTinKhachHang.SuspendLayout();
            grpDanhSachKhachHang.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvKhachHang).BeginInit();
            pnlChucNang.SuspendLayout();
            SuspendLayout();
            // 
            // lblTieuDeForm
            // 
            lblTieuDeForm.BackColor = Color.FromArgb(239, 246, 255);
            lblTieuDeForm.Dock = DockStyle.Top;
            lblTieuDeForm.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTieuDeForm.ForeColor = Color.FromArgb(30, 58, 138);
            lblTieuDeForm.Location = new Point(0, 0);
            lblTieuDeForm.Name = "lblTieuDeForm";
            lblTieuDeForm.Size = new Size(1353, 61);
            lblTieuDeForm.TabIndex = 0;
            lblTieuDeForm.Text = "QUẢN LÝ THÔNG TIN KHÁCH HÀNG";
            lblTieuDeForm.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // grpThongTinKhachHang
            // 
            grpThongTinKhachHang.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            grpThongTinKhachHang.BackColor = Color.FromArgb(248, 250, 252);
            grpThongTinKhachHang.Controls.Add(cboTrangThai);
            grpThongTinKhachHang.Controls.Add(lblTrangThai);
            grpThongTinKhachHang.Controls.Add(txtGhiChu);
            grpThongTinKhachHang.Controls.Add(lblGhiChu);
            grpThongTinKhachHang.Controls.Add(txtDiaChi);
            grpThongTinKhachHang.Controls.Add(lblDiaChi);
            grpThongTinKhachHang.Controls.Add(cboLoaiKhachHang);
            grpThongTinKhachHang.Controls.Add(lblLoaiKhachHang);
            grpThongTinKhachHang.Controls.Add(dtpNgaySinh);
            grpThongTinKhachHang.Controls.Add(lblNgaySinh);
            grpThongTinKhachHang.Controls.Add(cboGioiTinh);
            grpThongTinKhachHang.Controls.Add(lblGioiTinh);
            grpThongTinKhachHang.Controls.Add(txtEmail);
            grpThongTinKhachHang.Controls.Add(lblEmail);
            grpThongTinKhachHang.Controls.Add(txtSoDienThoai);
            grpThongTinKhachHang.Controls.Add(lblSoDienThoai);
            grpThongTinKhachHang.Controls.Add(txtTenKhachHang);
            grpThongTinKhachHang.Controls.Add(lblTenKhachHang);
            grpThongTinKhachHang.Controls.Add(txtMaKhachHang);
            grpThongTinKhachHang.Controls.Add(lblMaKhachHang);
            grpThongTinKhachHang.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            grpThongTinKhachHang.ForeColor = Color.FromArgb(30, 41, 59);
            grpThongTinKhachHang.Location = new Point(17, 69);
            grpThongTinKhachHang.Margin = new Padding(3, 4, 3, 4);
            grpThongTinKhachHang.Name = "grpThongTinKhachHang";
            grpThongTinKhachHang.Padding = new Padding(3, 4, 3, 4);
            grpThongTinKhachHang.Size = new Size(1319, 210);
            grpThongTinKhachHang.TabIndex = 1;
            grpThongTinKhachHang.TabStop = false;
            grpThongTinKhachHang.Text = "A. Thông tin chi tiết khách hàng";
            // 
            // cboTrangThai
            // 
            cboTrangThai.DropDownStyle = ComboBoxStyle.DropDownList;
            cboTrangThai.Font = new Font("Segoe UI", 9.5F);
            cboTrangThai.FormattingEnabled = true;
            cboTrangThai.Items.AddRange(new object[] { "Đang hoạt động", "Tạm ngừng" });
            cboTrangThai.Location = new Point(895, 154);
            cboTrangThai.Name = "cboTrangThai";
            cboTrangThai.Size = new Size(200, 29);
            cboTrangThai.TabIndex = 19;
            // 
            // lblTrangThai
            // 
            lblTrangThai.AutoSize = true;
            lblTrangThai.Font = new Font("Segoe UI", 9.5F);
            lblTrangThai.Location = new Point(805, 158);
            lblTrangThai.Name = "lblTrangThai";
            lblTrangThai.Size = new Size(82, 21);
            lblTrangThai.TabIndex = 18;
            lblTrangThai.Text = "Trạng thái:";
            // 
            // txtGhiChu
            // 
            txtGhiChu.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtGhiChu.Font = new Font("Segoe UI", 9.5F);
            txtGhiChu.Location = new Point(895, 34);
            txtGhiChu.Margin = new Padding(3, 4, 3, 4);
            txtGhiChu.Multiline = true;
            txtGhiChu.Name = "txtGhiChu";
            txtGhiChu.PlaceholderText = "Nhập ghi chú hoặc yêu cầu đặc biệt của khách hàng...";
            txtGhiChu.ScrollBars = ScrollBars.Vertical;
            txtGhiChu.Size = new Size(405, 108);
            txtGhiChu.TabIndex = 17;
            // 
            // lblGhiChu
            // 
            lblGhiChu.AutoSize = true;
            lblGhiChu.Font = new Font("Segoe UI", 9.5F);
            lblGhiChu.Location = new Point(805, 38);
            lblGhiChu.Name = "lblGhiChu";
            lblGhiChu.Size = new Size(66, 21);
            lblGhiChu.TabIndex = 16;
            lblGhiChu.Text = "Ghi chú:";
            // 
            // txtDiaChi
            // 
            txtDiaChi.Font = new Font("Segoe UI", 9.5F);
            txtDiaChi.Location = new Point(535, 154);
            txtDiaChi.Margin = new Padding(3, 4, 3, 4);
            txtDiaChi.Name = "txtDiaChi";
            txtDiaChi.PlaceholderText = "VD: 123 Nguyễn Huệ, TP.HCM";
            txtDiaChi.Size = new Size(235, 29);
            txtDiaChi.TabIndex = 15;
            // 
            // lblDiaChi
            // 
            lblDiaChi.AutoSize = true;
            lblDiaChi.Font = new Font("Segoe UI", 9.5F);
            lblDiaChi.Location = new Point(410, 158);
            lblDiaChi.Name = "lblDiaChi";
            lblDiaChi.Size = new Size(60, 21);
            lblDiaChi.TabIndex = 14;
            lblDiaChi.Text = "Địa chỉ:";
            // 
            // cboLoaiKhachHang
            // 
            cboLoaiKhachHang.DropDownStyle = ComboBoxStyle.DropDownList;
            cboLoaiKhachHang.Font = new Font("Segoe UI", 9.5F);
            cboLoaiKhachHang.FormattingEnabled = true;
            cboLoaiKhachHang.Items.AddRange(new object[] { "Khách thường", "Khách thân thiết", "Khách VIP", "Khách sỉ" });
            cboLoaiKhachHang.Location = new Point(535, 114);
            cboLoaiKhachHang.Name = "cboLoaiKhachHang";
            cboLoaiKhachHang.Size = new Size(235, 29);
            cboLoaiKhachHang.TabIndex = 13;
            // 
            // lblLoaiKhachHang
            // 
            lblLoaiKhachHang.AutoSize = true;
            lblLoaiKhachHang.Font = new Font("Segoe UI", 9.5F);
            lblLoaiKhachHang.Location = new Point(410, 118);
            lblLoaiKhachHang.Name = "lblLoaiKhachHang";
            lblLoaiKhachHang.Size = new Size(89, 21);
            lblLoaiKhachHang.TabIndex = 12;
            lblLoaiKhachHang.Text = "Loại khách:";
            // 
            // dtpNgaySinh
            // 
            dtpNgaySinh.CustomFormat = "dd/MM/yyyy";
            dtpNgaySinh.Font = new Font("Segoe UI", 9.5F);
            dtpNgaySinh.Format = DateTimePickerFormat.Custom;
            dtpNgaySinh.Location = new Point(145, 154);
            dtpNgaySinh.Margin = new Padding(3, 4, 3, 4);
            dtpNgaySinh.Name = "dtpNgaySinh";
            dtpNgaySinh.Size = new Size(220, 29);
            dtpNgaySinh.TabIndex = 7;
            // 
            // lblNgaySinh
            // 
            lblNgaySinh.AutoSize = true;
            lblNgaySinh.Font = new Font("Segoe UI", 9.5F);
            lblNgaySinh.Location = new Point(20, 158);
            lblNgaySinh.Name = "lblNgaySinh";
            lblNgaySinh.Size = new Size(83, 21);
            lblNgaySinh.TabIndex = 6;
            lblNgaySinh.Text = "Ngày sinh:";
            // 
            // cboGioiTinh
            // 
            cboGioiTinh.DropDownStyle = ComboBoxStyle.DropDownList;
            cboGioiTinh.Font = new Font("Segoe UI", 9.5F);
            cboGioiTinh.FormattingEnabled = true;
            cboGioiTinh.Items.AddRange(new object[] { "Nam", "Nữ", "Khác" });
            cboGioiTinh.Location = new Point(145, 114);
            cboGioiTinh.Name = "cboGioiTinh";
            cboGioiTinh.Size = new Size(220, 29);
            cboGioiTinh.TabIndex = 5;
            // 
            // lblGioiTinh
            // 
            lblGioiTinh.AutoSize = true;
            lblGioiTinh.Font = new Font("Segoe UI", 9.5F);
            lblGioiTinh.Location = new Point(20, 118);
            lblGioiTinh.Name = "lblGioiTinh";
            lblGioiTinh.Size = new Size(73, 21);
            lblGioiTinh.TabIndex = 4;
            lblGioiTinh.Text = "Giới tính:";
            // 
            // txtEmail
            // 
            txtEmail.Font = new Font("Segoe UI", 9.5F);
            txtEmail.Location = new Point(535, 74);
            txtEmail.Margin = new Padding(3, 4, 3, 4);
            txtEmail.Name = "txtEmail";
            txtEmail.PlaceholderText = "VD: khachhang@gmail.com";
            txtEmail.Size = new Size(235, 29);
            txtEmail.TabIndex = 11;
            // 
            // lblEmail
            // 
            lblEmail.AutoSize = true;
            lblEmail.Font = new Font("Segoe UI", 9.5F);
            lblEmail.Location = new Point(410, 78);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(51, 21);
            lblEmail.TabIndex = 10;
            lblEmail.Text = "Email:";
            // 
            // txtSoDienThoai
            // 
            txtSoDienThoai.Font = new Font("Segoe UI", 9.5F);
            txtSoDienThoai.Location = new Point(535, 34);
            txtSoDienThoai.Margin = new Padding(3, 4, 3, 4);
            txtSoDienThoai.Name = "txtSoDienThoai";
            txtSoDienThoai.PlaceholderText = "VD: 0901234567";
            txtSoDienThoai.Size = new Size(235, 29);
            txtSoDienThoai.TabIndex = 9;
            // 
            // lblSoDienThoai
            // 
            lblSoDienThoai.AutoSize = true;
            lblSoDienThoai.Font = new Font("Segoe UI", 9.5F);
            lblSoDienThoai.Location = new Point(410, 38);
            lblSoDienThoai.Name = "lblSoDienThoai";
            lblSoDienThoai.Size = new Size(104, 21);
            lblSoDienThoai.TabIndex = 8;
            lblSoDienThoai.Text = "Số điện thoại:";
            // 
            // txtTenKhachHang
            // 
            txtTenKhachHang.Font = new Font("Segoe UI", 9.5F);
            txtTenKhachHang.Location = new Point(145, 74);
            txtTenKhachHang.Margin = new Padding(3, 4, 3, 4);
            txtTenKhachHang.Name = "txtTenKhachHang";
            txtTenKhachHang.PlaceholderText = "Nhập họ tên khách hàng";
            txtTenKhachHang.Size = new Size(220, 29);
            txtTenKhachHang.TabIndex = 3;
            // 
            // lblTenKhachHang
            // 
            lblTenKhachHang.AutoSize = true;
            lblTenKhachHang.Font = new Font("Segoe UI", 9.5F);
            lblTenKhachHang.Location = new Point(20, 78);
            lblTenKhachHang.Name = "lblTenKhachHang";
            lblTenKhachHang.Size = new Size(120, 21);
            lblTenKhachHang.TabIndex = 2;
            lblTenKhachHang.Text = "Tên khách hàng:";
            // 
            // txtMaKhachHang
            // 
            txtMaKhachHang.Font = new Font("Segoe UI", 9.5F);
            txtMaKhachHang.Location = new Point(145, 34);
            txtMaKhachHang.Margin = new Padding(3, 4, 3, 4);
            txtMaKhachHang.Name = "txtMaKhachHang";
            txtMaKhachHang.PlaceholderText = "VD: KH001";
            txtMaKhachHang.Size = new Size(220, 29);
            txtMaKhachHang.TabIndex = 1;
            // 
            // lblMaKhachHang
            // 
            lblMaKhachHang.AutoSize = true;
            lblMaKhachHang.Font = new Font("Segoe UI", 9.5F);
            lblMaKhachHang.Location = new Point(20, 38);
            lblMaKhachHang.Name = "lblMaKhachHang";
            lblMaKhachHang.Size = new Size(119, 21);
            lblMaKhachHang.TabIndex = 0;
            lblMaKhachHang.Text = "Mã khách hàng:";
            // 
            // grpDanhSachKhachHang
            // 
            grpDanhSachKhachHang.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            grpDanhSachKhachHang.BackColor = Color.FromArgb(248, 250, 252);
            grpDanhSachKhachHang.Controls.Add(lblTongSoKhachHang);
            grpDanhSachKhachHang.Controls.Add(btnDatLai);
            grpDanhSachKhachHang.Controls.Add(btnTimKiem);
            grpDanhSachKhachHang.Controls.Add(cboLocLoaiKH);
            grpDanhSachKhachHang.Controls.Add(lblLocLoaiKH);
            grpDanhSachKhachHang.Controls.Add(txtTimKiem);
            grpDanhSachKhachHang.Controls.Add(lblTimKiem);
            grpDanhSachKhachHang.Controls.Add(dgvKhachHang);
            grpDanhSachKhachHang.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            grpDanhSachKhachHang.ForeColor = Color.FromArgb(30, 41, 59);
            grpDanhSachKhachHang.Location = new Point(17, 287);
            grpDanhSachKhachHang.Margin = new Padding(3, 4, 3, 4);
            grpDanhSachKhachHang.Name = "grpDanhSachKhachHang";
            grpDanhSachKhachHang.Padding = new Padding(3, 4, 3, 4);
            grpDanhSachKhachHang.Size = new Size(1319, 530);
            grpDanhSachKhachHang.TabIndex = 2;
            grpDanhSachKhachHang.TabStop = false;
            grpDanhSachKhachHang.Text = "B. Danh sách khách hàng";
            // 
            // lblTongSoKhachHang
            // 
            lblTongSoKhachHang.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblTongSoKhachHang.Font = new Font("Segoe UI", 9.5F, FontStyle.Italic);
            lblTongSoKhachHang.ForeColor = Color.FromArgb(71, 85, 105);
            lblTongSoKhachHang.Location = new Point(1080, 36);
            lblTongSoKhachHang.Name = "lblTongSoKhachHang";
            lblTongSoKhachHang.Size = new Size(222, 25);
            lblTongSoKhachHang.TabIndex = 7;
            lblTongSoKhachHang.Text = "Tổng cộng: 0 khách hàng";
            lblTongSoKhachHang.TextAlign = ContentAlignment.MiddleRight;
            // 
            // btnDatLai
            // 
            btnDatLai.BackColor = Color.FromArgb(241, 245, 249);
            btnDatLai.Cursor = Cursors.Hand;
            btnDatLai.FlatStyle = FlatStyle.Flat;
            btnDatLai.Font = new Font("Segoe UI", 9F);
            btnDatLai.ForeColor = Color.FromArgb(15, 23, 42);
            btnDatLai.Location = new Point(870, 27);
            btnDatLai.Margin = new Padding(3, 4, 3, 4);
            btnDatLai.Name = "btnDatLai";
            btnDatLai.Size = new Size(110, 38);
            btnDatLai.TabIndex = 6;
            btnDatLai.Text = "🔄 Đặt lại";
            btnDatLai.UseVisualStyleBackColor = false;
            // 
            // btnTimKiem
            // 
            btnTimKiem.BackColor = Color.FromArgb(37, 99, 235);
            btnTimKiem.Cursor = Cursors.Hand;
            btnTimKiem.FlatStyle = FlatStyle.Flat;
            btnTimKiem.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnTimKiem.ForeColor = Color.White;
            btnTimKiem.Location = new Point(740, 27);
            btnTimKiem.Margin = new Padding(3, 4, 3, 4);
            btnTimKiem.Name = "btnTimKiem";
            btnTimKiem.Size = new Size(120, 38);
            btnTimKiem.TabIndex = 5;
            btnTimKiem.Text = "🔍 Tìm kiếm";
            btnTimKiem.UseVisualStyleBackColor = false;
            // 
            // cboLocLoaiKH
            // 
            cboLocLoaiKH.DropDownStyle = ComboBoxStyle.DropDownList;
            cboLocLoaiKH.Font = new Font("Segoe UI", 9.5F);
            cboLocLoaiKH.FormattingEnabled = true;
            cboLocLoaiKH.Items.AddRange(new object[] { "Tất cả loại KH", "Khách thường", "Khách thân thiết", "Khách VIP", "Khách sỉ" });
            cboLocLoaiKH.Location = new Point(530, 32);
            cboLocLoaiKH.Name = "cboLocLoaiKH";
            cboLocLoaiKH.Size = new Size(190, 29);
            cboLocLoaiKH.TabIndex = 4;
            // 
            // lblLocLoaiKH
            // 
            lblLocLoaiKH.AutoSize = true;
            lblLocLoaiKH.Font = new Font("Segoe UI", 9.5F);
            lblLocLoaiKH.Location = new Point(410, 36);
            lblLocLoaiKH.Name = "lblLocLoaiKH";
            lblLocLoaiKH.Size = new Size(114, 21);
            lblLocLoaiKH.TabIndex = 3;
            lblLocLoaiKH.Text = "Loại khách hàng:";
            // 
            // txtTimKiem
            // 
            txtTimKiem.Font = new Font("Segoe UI", 9.5F);
            txtTimKiem.Location = new Point(95, 32);
            txtTimKiem.Margin = new Padding(3, 4, 3, 4);
            txtTimKiem.Name = "txtTimKiem";
            txtTimKiem.PlaceholderText = "Nhập mã, tên hoặc số điện thoại...";
            txtTimKiem.Size = new Size(295, 29);
            txtTimKiem.TabIndex = 2;
            // 
            // lblTimKiem
            // 
            lblTimKiem.AutoSize = true;
            lblTimKiem.Font = new Font("Segoe UI", 9.5F);
            lblTimKiem.Location = new Point(17, 36);
            lblTimKiem.Name = "lblTimKiem";
            lblTimKiem.Size = new Size(76, 21);
            lblTimKiem.TabIndex = 1;
            lblTimKiem.Text = "Tìm kiếm:";
            // 
            // dgvKhachHang
            // 
            dgvKhachHang.AllowUserToAddRows = false;
            dgvKhachHang.AllowUserToDeleteRows = false;
            dgvKhachHang.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvKhachHang.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvKhachHang.BackgroundColor = Color.White;
            dgvKhachHang.BorderStyle = BorderStyle.Fixed3D;
            dgvKhachHang.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvKhachHang.Columns.AddRange(new DataGridViewColumn[] { colSTT, colMaKH, colTenKH, colGioiTinh, colNgaySinh, colSoDienThoai, colEmail, colLoaiKH, colDiaChi, colTrangThai, colGhiChu });
            dgvKhachHang.Font = new Font("Segoe UI", 9.5F);
            dgvKhachHang.Location = new Point(17, 76);
            dgvKhachHang.Margin = new Padding(3, 4, 3, 4);
            dgvKhachHang.MultiSelect = false;
            dgvKhachHang.Name = "dgvKhachHang";
            dgvKhachHang.ReadOnly = true;
            dgvKhachHang.RowHeadersVisible = false;
            dgvKhachHang.RowHeadersWidth = 51;
            dgvKhachHang.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvKhachHang.Size = new Size(1285, 438);
            dgvKhachHang.TabIndex = 0;
            // 
            // colSTT
            // 
            colSTT.FillWeight = 45F;
            colSTT.HeaderText = "STT";
            colSTT.MinimumWidth = 6;
            colSTT.Name = "colSTT";
            colSTT.ReadOnly = true;
            // 
            // colMaKH
            // 
            colMaKH.FillWeight = 85F;
            colMaKH.HeaderText = "Mã KH";
            colMaKH.MinimumWidth = 6;
            colMaKH.Name = "colMaKH";
            colMaKH.ReadOnly = true;
            // 
            // colTenKH
            // 
            colTenKH.FillWeight = 150F;
            colTenKH.HeaderText = "Tên khách hàng";
            colTenKH.MinimumWidth = 6;
            colTenKH.Name = "colTenKH";
            colTenKH.ReadOnly = true;
            // 
            // colGioiTinh
            // 
            colGioiTinh.FillWeight = 70F;
            colGioiTinh.HeaderText = "Giới tính";
            colGioiTinh.MinimumWidth = 6;
            colGioiTinh.Name = "colGioiTinh";
            colGioiTinh.ReadOnly = true;
            // 
            // colNgaySinh
            // 
            colNgaySinh.FillWeight = 85F;
            colNgaySinh.HeaderText = "Ngày sinh";
            colNgaySinh.MinimumWidth = 6;
            colNgaySinh.Name = "colNgaySinh";
            colNgaySinh.ReadOnly = true;
            // 
            // colSoDienThoai
            // 
            colSoDienThoai.FillWeight = 100F;
            colSoDienThoai.HeaderText = "Số điện thoại";
            colSoDienThoai.MinimumWidth = 6;
            colSoDienThoai.Name = "colSoDienThoai";
            colSoDienThoai.ReadOnly = true;
            // 
            // colEmail
            // 
            colEmail.FillWeight = 130F;
            colEmail.HeaderText = "Email";
            colEmail.MinimumWidth = 6;
            colEmail.Name = "colEmail";
            colEmail.ReadOnly = true;
            // 
            // colLoaiKH
            // 
            colLoaiKH.FillWeight = 100F;
            colLoaiKH.HeaderText = "Loại khách";
            colLoaiKH.MinimumWidth = 6;
            colLoaiKH.Name = "colLoaiKH";
            colLoaiKH.ReadOnly = true;
            // 
            // colDiaChi
            // 
            colDiaChi.FillWeight = 160F;
            colDiaChi.HeaderText = "Địa chỉ";
            colDiaChi.MinimumWidth = 6;
            colDiaChi.Name = "colDiaChi";
            colDiaChi.ReadOnly = true;
            // 
            // colTrangThai
            // 
            colTrangThai.FillWeight = 95F;
            colTrangThai.HeaderText = "Trạng thái";
            colTrangThai.MinimumWidth = 6;
            colTrangThai.Name = "colTrangThai";
            colTrangThai.ReadOnly = true;
            // 
            // colGhiChu
            // 
            colGhiChu.FillWeight = 120F;
            colGhiChu.HeaderText = "Ghi chú";
            colGhiChu.MinimumWidth = 6;
            colGhiChu.Name = "colGhiChu";
            colGhiChu.ReadOnly = true;
            // 
            // pnlChucNang
            // 
            pnlChucNang.BackColor = Color.FromArgb(241, 245, 249);
            pnlChucNang.Controls.Add(btnHome);
            pnlChucNang.Controls.Add(btnLuu);
            pnlChucNang.Controls.Add(btnThem);
            pnlChucNang.Controls.Add(btnSua);
            pnlChucNang.Controls.Add(btnXoa);
            pnlChucNang.Controls.Add(btnLamMoi);
            pnlChucNang.Controls.Add(btnXuatExcel);
            pnlChucNang.Controls.Add(btnDong);
            pnlChucNang.Dock = DockStyle.Bottom;
            pnlChucNang.Location = new Point(0, 825);
            pnlChucNang.Margin = new Padding(3, 4, 3, 4);
            pnlChucNang.Name = "pnlChucNang";
            pnlChucNang.Size = new Size(1353, 83);
            pnlChucNang.TabIndex = 3;
            // 
            // btnHome
            // 
            btnHome.BackColor = Color.FromArgb(30, 58, 138);
            btnHome.Cursor = Cursors.Hand;
            btnHome.FlatStyle = FlatStyle.Flat;
            btnHome.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnHome.ForeColor = Color.White;
            btnHome.Location = new Point(17, 18);
            btnHome.Margin = new Padding(3, 4, 3, 4);
            btnHome.Name = "btnHome";
            btnHome.Size = new Size(130, 48);
            btnHome.TabIndex = 0;
            btnHome.Text = "⌂ Trang chủ";
            btnHome.UseVisualStyleBackColor = false;
            // 
            // btnLuu
            // 
            btnLuu.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnLuu.BackColor = Color.FromArgb(37, 99, 235);
            btnLuu.Cursor = Cursors.Hand;
            btnLuu.FlatStyle = FlatStyle.Flat;
            btnLuu.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnLuu.ForeColor = Color.White;
            btnLuu.Location = new Point(446, 18);
            btnLuu.Margin = new Padding(3, 4, 3, 4);
            btnLuu.Name = "btnLuu";
            btnLuu.Size = new Size(120, 48);
            btnLuu.TabIndex = 1;
            btnLuu.Text = "💾 Lưu";
            btnLuu.UseVisualStyleBackColor = false;
            // 
            // btnThem
            // 
            btnThem.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnThem.BackColor = Color.FromArgb(29, 78, 216);
            btnThem.Cursor = Cursors.Hand;
            btnThem.FlatStyle = FlatStyle.Flat;
            btnThem.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnThem.ForeColor = Color.White;
            btnThem.Location = new Point(576, 18);
            btnThem.Margin = new Padding(3, 4, 3, 4);
            btnThem.Name = "btnThem";
            btnThem.Size = new Size(120, 48);
            btnThem.TabIndex = 2;
            btnThem.Text = "➕ Thêm mới";
            btnThem.UseVisualStyleBackColor = false;
            // 
            // btnSua
            // 
            btnSua.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnSua.BackColor = Color.FromArgb(234, 88, 12);
            btnSua.Cursor = Cursors.Hand;
            btnSua.FlatStyle = FlatStyle.Flat;
            btnSua.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnSua.ForeColor = Color.White;
            btnSua.Location = new Point(706, 18);
            btnSua.Margin = new Padding(3, 4, 3, 4);
            btnSua.Name = "btnSua";
            btnSua.Size = new Size(120, 48);
            btnSua.TabIndex = 3;
            btnSua.Text = "✏ Sửa";
            btnSua.UseVisualStyleBackColor = false;
            // 
            // btnXoa
            // 
            btnXoa.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnXoa.BackColor = Color.FromArgb(220, 38, 38);
            btnXoa.Cursor = Cursors.Hand;
            btnXoa.FlatStyle = FlatStyle.Flat;
            btnXoa.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnXoa.ForeColor = Color.White;
            btnXoa.Location = new Point(836, 18);
            btnXoa.Margin = new Padding(3, 4, 3, 4);
            btnXoa.Name = "btnXoa";
            btnXoa.Size = new Size(120, 48);
            btnXoa.TabIndex = 4;
            btnXoa.Text = "🗑 Xóa";
            btnXoa.UseVisualStyleBackColor = false;
            // 
            // btnLamMoi
            // 
            btnLamMoi.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnLamMoi.BackColor = Color.FromArgb(241, 245, 249);
            btnLamMoi.Cursor = Cursors.Hand;
            btnLamMoi.FlatStyle = FlatStyle.Flat;
            btnLamMoi.Font = new Font("Segoe UI", 9.5F);
            btnLamMoi.ForeColor = Color.FromArgb(15, 23, 42);
            btnLamMoi.Location = new Point(966, 18);
            btnLamMoi.Margin = new Padding(3, 4, 3, 4);
            btnLamMoi.Name = "btnLamMoi";
            btnLamMoi.Size = new Size(120, 48);
            btnLamMoi.TabIndex = 5;
            btnLamMoi.Text = "🔄 Làm mới";
            btnLamMoi.UseVisualStyleBackColor = false;
            // 
            // btnXuatExcel
            // 
            btnXuatExcel.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnXuatExcel.BackColor = Color.FromArgb(22, 163, 74);
            btnXuatExcel.Cursor = Cursors.Hand;
            btnXuatExcel.FlatStyle = FlatStyle.Flat;
            btnXuatExcel.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnXuatExcel.ForeColor = Color.White;
            btnXuatExcel.Location = new Point(1096, 18);
            btnXuatExcel.Margin = new Padding(3, 4, 3, 4);
            btnXuatExcel.Name = "btnXuatExcel";
            btnXuatExcel.Size = new Size(130, 48);
            btnXuatExcel.TabIndex = 6;
            btnXuatExcel.Text = "📊 Xuất Excel";
            btnXuatExcel.UseVisualStyleBackColor = false;
            // 
            // btnDong
            // 
            btnDong.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnDong.BackColor = Color.FromArgb(226, 232, 240);
            btnDong.Cursor = Cursors.Hand;
            btnDong.FlatStyle = FlatStyle.Flat;
            btnDong.Font = new Font("Segoe UI", 9.5F);
            btnDong.ForeColor = Color.FromArgb(15, 23, 42);
            btnDong.Location = new Point(1236, 18);
            btnDong.Margin = new Padding(3, 4, 3, 4);
            btnDong.Name = "btnDong";
            btnDong.Size = new Size(100, 48);
            btnDong.TabIndex = 7;
            btnDong.Text = "🚪 Đóng";
            btnDong.UseVisualStyleBackColor = false;
            // 
            // FrmKhachHang
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(248, 250, 252);
            ClientSize = new Size(1353, 908);
            Controls.Add(pnlChucNang);
            Controls.Add(grpDanhSachKhachHang);
            Controls.Add(grpThongTinKhachHang);
            Controls.Add(lblTieuDeForm);
            ForeColor = SystemColors.ControlText;
            Name = "FrmKhachHang";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Quản lý khách hàng";
            grpThongTinKhachHang.ResumeLayout(false);
            grpThongTinKhachHang.PerformLayout();
            grpDanhSachKhachHang.ResumeLayout(false);
            grpDanhSachKhachHang.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvKhachHang).EndInit();
            pnlChucNang.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Label lblTieuDeForm;
        private GroupBox grpThongTinKhachHang;
        private Label lblMaKhachHang;
        private TextBox txtMaKhachHang;
        private Label lblTenKhachHang;
        private TextBox txtTenKhachHang;
        private Label lblSoDienThoai;
        private TextBox txtSoDienThoai;
        private Label lblEmail;
        private TextBox txtEmail;
        private Label lblGioiTinh;
        private ComboBox cboGioiTinh;
        private Label lblNgaySinh;
        private DateTimePicker dtpNgaySinh;
        private Label lblLoaiKhachHang;
        private ComboBox cboLoaiKhachHang;
        private Label lblDiaChi;
        private TextBox txtDiaChi;
        private Label lblGhiChu;
        private TextBox txtGhiChu;
        private Label lblTrangThai;
        private ComboBox cboTrangThai;
        private GroupBox grpDanhSachKhachHang;
        private Label lblTimKiem;
        private TextBox txtTimKiem;
        private Label lblLocLoaiKH;
        private ComboBox cboLocLoaiKH;
        private Button btnTimKiem;
        private Button btnDatLai;
        private Label lblTongSoKhachHang;
        private DataGridView dgvKhachHang;
        private DataGridViewTextBoxColumn colSTT;
        private DataGridViewTextBoxColumn colMaKH;
        private DataGridViewTextBoxColumn colTenKH;
        private DataGridViewTextBoxColumn colGioiTinh;
        private DataGridViewTextBoxColumn colNgaySinh;
        private DataGridViewTextBoxColumn colSoDienThoai;
        private DataGridViewTextBoxColumn colEmail;
        private DataGridViewTextBoxColumn colLoaiKH;
        private DataGridViewTextBoxColumn colDiaChi;
        private DataGridViewTextBoxColumn colTrangThai;
        private DataGridViewTextBoxColumn colGhiChu;
        private Panel pnlChucNang;
        private Button btnHome;
        private Button btnLuu;
        private Button btnThem;
        private Button btnSua;
        private Button btnXoa;
        private Button btnLamMoi;
        private Button btnXuatExcel;
        private Button btnDong;
    }
}
