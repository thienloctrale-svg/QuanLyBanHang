namespace QuanLyBanHang.UI
{
    partial class FrmBanHang
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
            grpThongTinHoaDon = new GroupBox();
            cboKhachHang = new ComboBox();
            dtpNgayLap = new DateTimePicker();
            txtMaHoaDon = new TextBox();
            lblKhachHang = new Label();
            lblNgayLap = new Label();
            lblMaHoaDon = new Label();
            grpSanPham = new GroupBox();
            dgvSanPham = new DataGridView();
            colSP_Ma = new DataGridViewTextBoxColumn();
            colSP_Ten = new DataGridViewTextBoxColumn();
            colSP_DVT = new DataGridViewTextBoxColumn();
            colSP_Gia = new DataGridViewTextBoxColumn();
            colSP_TonKho = new DataGridViewTextBoxColumn();
            btnThemSanPham = new Button();
            numSoLuong = new NumericUpDown();
            lblSoLuong = new Label();
            btnTimSanPham = new Button();
            txtTimSanPham = new TextBox();
            grpGioHang = new GroupBox();
            dgvGioHang = new DataGridView();
            colGH_STT = new DataGridViewTextBoxColumn();
            colGH_Ma = new DataGridViewTextBoxColumn();
            colGH_Ten = new DataGridViewTextBoxColumn();
            colGH_DVT = new DataGridViewTextBoxColumn();
            colGH_SoLuong = new DataGridViewTextBoxColumn();
            colGH_DonGia = new DataGridViewTextBoxColumn();
            colGH_ThanhTien = new DataGridViewTextBoxColumn();
            btnXoaSanPham = new Button();
            btnCapNhatSoLuong = new Button();
            grpThanhToan = new GroupBox();
            lblTongTien = new Label();
            lblTieuDeTongTien = new Label();
            btnLamMoi = new Button();
            btnHuyHoaDon = new Button();
            btnDong = new Button();
            btnLuuHoaDon = new Button();
            panelChucNang = new Panel();
            bntHome = new Button();
            grpPhuongThucThanhToan = new GroupBox();
            tableLayoutPanel1 = new TableLayoutPanel();
            rdoTienMat = new RadioButton();
            rdoChuyenKhoan = new RadioButton();
            rdoQuetThe = new RadioButton();
            grpThongTinHoaDon.SuspendLayout();
            grpSanPham.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvSanPham).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numSoLuong).BeginInit();
            grpGioHang.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvGioHang).BeginInit();
            grpThanhToan.SuspendLayout();
            panelChucNang.SuspendLayout();
            grpPhuongThucThanhToan.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // lblTieuDeForm
            // 
            lblTieuDeForm.BackColor = Color.FromArgb(239, 246, 255);
            lblTieuDeForm.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTieuDeForm.ForeColor = Color.FromArgb(30, 58, 138);
            lblTieuDeForm.Location = new Point(0, 0);
            lblTieuDeForm.Name = "lblTieuDeForm";
            lblTieuDeForm.Size = new Size(1353, 61);
            lblTieuDeForm.TabIndex = 0;
            lblTieuDeForm.Text = "HÓA ĐƠN BÁN HÀNG VÀ XUẤT KHO";
            lblTieuDeForm.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // grpThongTinHoaDon
            // 
            grpThongTinHoaDon.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            grpThongTinHoaDon.BackColor = Color.FromArgb(248, 250, 252);
            grpThongTinHoaDon.Controls.Add(cboKhachHang);
            grpThongTinHoaDon.Controls.Add(dtpNgayLap);
            grpThongTinHoaDon.Controls.Add(txtMaHoaDon);
            grpThongTinHoaDon.Controls.Add(lblKhachHang);
            grpThongTinHoaDon.Controls.Add(lblNgayLap);
            grpThongTinHoaDon.Controls.Add(lblMaHoaDon);
            grpThongTinHoaDon.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            grpThongTinHoaDon.ForeColor = Color.FromArgb(30, 41, 59);
            grpThongTinHoaDon.Location = new Point(17, 69);
            grpThongTinHoaDon.Margin = new Padding(3, 4, 3, 4);
            grpThongTinHoaDon.Name = "grpThongTinHoaDon";
            grpThongTinHoaDon.Padding = new Padding(3, 4, 3, 4);
            grpThongTinHoaDon.Size = new Size(1319, 100);
            grpThongTinHoaDon.TabIndex = 1;
            grpThongTinHoaDon.TabStop = false;
            grpThongTinHoaDon.Text = "A. Thông tin hóa đơn";
            // 
            // cboKhachHang
            // 
            cboKhachHang.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            cboKhachHang.DropDownWidth = 454;
            cboKhachHang.Font = new Font("Segoe UI", 9.5F);
            cboKhachHang.FormattingEnabled = true;
            cboKhachHang.Location = new Point(840, 39);
            cboKhachHang.Name = "cboKhachHang";
            cboKhachHang.Size = new Size(454, 29);
            cboKhachHang.TabIndex = 5;
            // 
            // dtpNgayLap
            // 
            dtpNgayLap.CalendarFont = new Font("Segoe UI", 9.5F);
            dtpNgayLap.CustomFormat = "dd/MM/yyyy HH:mm";
            dtpNgayLap.Font = new Font("Segoe UI", 9.5F);
            dtpNgayLap.Format = DateTimePickerFormat.Custom;
            dtpNgayLap.Location = new Point(491, 37);
            dtpNgayLap.Margin = new Padding(3, 4, 3, 4);
            dtpNgayLap.Name = "dtpNgayLap";
            dtpNgayLap.Size = new Size(211, 29);
            dtpNgayLap.TabIndex = 3;
            // 
            // txtMaHoaDon
            // 
            txtMaHoaDon.Font = new Font("Segoe UI", 9.5F);
            txtMaHoaDon.Location = new Point(143, 37);
            txtMaHoaDon.Margin = new Padding(3, 4, 3, 4);
            txtMaHoaDon.Name = "txtMaHoaDon";
            txtMaHoaDon.Size = new Size(222, 29);
            txtMaHoaDon.TabIndex = 1;
            // 
            // lblKhachHang
            // 
            lblKhachHang.AutoSize = true;
            lblKhachHang.Font = new Font("Segoe UI", 9.5F);
            lblKhachHang.Location = new Point(737, 43);
            lblKhachHang.Name = "lblKhachHang";
            lblKhachHang.Size = new Size(94, 21);
            lblKhachHang.TabIndex = 4;
            lblKhachHang.Text = "Khách hàng:";
            // 
            // lblNgayLap
            // 
            lblNgayLap.AutoSize = true;
            lblNgayLap.Font = new Font("Segoe UI", 9.5F);
            lblNgayLap.Location = new Point(406, 43);
            lblNgayLap.Name = "lblNgayLap";
            lblNgayLap.Size = new Size(75, 21);
            lblNgayLap.TabIndex = 2;
            lblNgayLap.Text = "Ngày lập:";
            // 
            // lblMaHoaDon
            // 
            lblMaHoaDon.AutoSize = true;
            lblMaHoaDon.Font = new Font("Segoe UI", 9.5F);
            lblMaHoaDon.Location = new Point(29, 43);
            lblMaHoaDon.Name = "lblMaHoaDon";
            lblMaHoaDon.Size = new Size(97, 21);
            lblMaHoaDon.TabIndex = 0;
            lblMaHoaDon.Text = "Mã hóa đơn:";
            // 
            // grpSanPham
            // 
            grpSanPham.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            grpSanPham.BackColor = Color.FromArgb(248, 250, 252);
            grpSanPham.Controls.Add(dgvSanPham);
            grpSanPham.Controls.Add(btnThemSanPham);
            grpSanPham.Controls.Add(numSoLuong);
            grpSanPham.Controls.Add(lblSoLuong);
            grpSanPham.Controls.Add(btnTimSanPham);
            grpSanPham.Controls.Add(txtTimSanPham);
            grpSanPham.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            grpSanPham.ForeColor = Color.FromArgb(30, 41, 59);
            grpSanPham.Location = new Point(17, 177);
            grpSanPham.Margin = new Padding(3, 4, 3, 4);
            grpSanPham.Name = "grpSanPham";
            grpSanPham.Padding = new Padding(3, 4, 3, 4);
            grpSanPham.Size = new Size(589, 536);
            grpSanPham.TabIndex = 2;
            grpSanPham.TabStop = false;
            grpSanPham.Text = "B. Tìm kiếm và chọn sản phẩm";
            // 
            // dgvSanPham
            // 
            dgvSanPham.AllowUserToAddRows = false;
            dgvSanPham.AllowUserToDeleteRows = false;
            dgvSanPham.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvSanPham.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvSanPham.BackgroundColor = Color.White;
            dgvSanPham.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvSanPham.Columns.AddRange(new DataGridViewColumn[] { colSP_Ma, colSP_Ten, colSP_DVT, colSP_Gia, colSP_TonKho });
            dgvSanPham.Location = new Point(17, 91);
            dgvSanPham.Margin = new Padding(3, 4, 3, 4);
            dgvSanPham.MultiSelect = false;
            dgvSanPham.Name = "dgvSanPham";
            dgvSanPham.ReadOnly = true;
            dgvSanPham.RowHeadersVisible = false;
            dgvSanPham.RowHeadersWidth = 51;
            dgvSanPham.Size = new Size(554, 371);
            dgvSanPham.TabIndex = 2;
            // 
            // colSP_Ma
            // 
            colSP_Ma.FillWeight = 84.89307F;
            colSP_Ma.HeaderText = "Mã SP";
            colSP_Ma.MinimumWidth = 6;
            colSP_Ma.Name = "colSP_Ma";
            colSP_Ma.ReadOnly = true;
            // 
            // colSP_Ten
            // 
            colSP_Ten.FillWeight = 160.427826F;
            colSP_Ten.HeaderText = "Tên sản phẩm";
            colSP_Ten.MinimumWidth = 6;
            colSP_Ten.Name = "colSP_Ten";
            colSP_Ten.ReadOnly = true;
            // 
            // colSP_DVT
            // 
            colSP_DVT.FillWeight = 84.89307F;
            colSP_DVT.HeaderText = "ĐVT";
            colSP_DVT.MinimumWidth = 6;
            colSP_DVT.Name = "colSP_DVT";
            colSP_DVT.ReadOnly = true;
            // 
            // colSP_Gia
            // 
            colSP_Gia.FillWeight = 84.89307F;
            colSP_Gia.HeaderText = "Giá bán";
            colSP_Gia.MinimumWidth = 6;
            colSP_Gia.Name = "colSP_Gia";
            colSP_Gia.ReadOnly = true;
            // 
            // colSP_TonKho
            // 
            colSP_TonKho.FillWeight = 84.89307F;
            colSP_TonKho.HeaderText = "Tồn kho";
            colSP_TonKho.MinimumWidth = 6;
            colSP_TonKho.Name = "colSP_TonKho";
            colSP_TonKho.ReadOnly = true;
            // 
            // btnThemSanPham
            // 
            btnThemSanPham.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnThemSanPham.BackColor = Color.FromArgb(239, 246, 255);
            btnThemSanPham.Cursor = Cursors.Hand;
            btnThemSanPham.FlatStyle = FlatStyle.Flat;
            btnThemSanPham.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnThemSanPham.ForeColor = Color.FromArgb(29, 78, 216);
            btnThemSanPham.Location = new Point(211, 476);
            btnThemSanPham.Margin = new Padding(3, 4, 3, 4);
            btnThemSanPham.Name = "btnThemSanPham";
            btnThemSanPham.Size = new Size(183, 45);
            btnThemSanPham.TabIndex = 5;
            btnThemSanPham.Text = "➕ Thêm vào giỏ";
            btnThemSanPham.UseVisualStyleBackColor = false;
            // 
            // numSoLuong
            // 
            numSoLuong.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            numSoLuong.Font = new Font("Segoe UI", 9.5F);
            numSoLuong.Location = new Point(103, 483);
            numSoLuong.Margin = new Padding(3, 4, 3, 4);
            numSoLuong.Maximum = new decimal(new int[] { 99999, 0, 0, 0 });
            numSoLuong.Name = "numSoLuong";
            numSoLuong.Size = new Size(91, 29);
            numSoLuong.TabIndex = 4;
            numSoLuong.TextAlign = HorizontalAlignment.Right;
            numSoLuong.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // lblSoLuong
            // 
            lblSoLuong.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            lblSoLuong.AutoSize = true;
            lblSoLuong.Font = new Font("Segoe UI", 9.5F);
            lblSoLuong.Location = new Point(21, 487);
            lblSoLuong.Name = "lblSoLuong";
            lblSoLuong.Size = new Size(76, 21);
            lblSoLuong.TabIndex = 3;
            lblSoLuong.Text = "Số lượng:";
            // 
            // btnTimSanPham
            // 
            btnTimSanPham.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnTimSanPham.BackColor = Color.FromArgb(241, 245, 249);
            btnTimSanPham.Cursor = Cursors.Hand;
            btnTimSanPham.Font = new Font("Segoe UI", 9.5F);
            btnTimSanPham.Location = new Point(446, 36);
            btnTimSanPham.Margin = new Padding(3, 4, 3, 4);
            btnTimSanPham.Name = "btnTimSanPham";
            btnTimSanPham.Size = new Size(126, 40);
            btnTimSanPham.TabIndex = 1;
            btnTimSanPham.Text = "🔍 Tìm kiếm";
            btnTimSanPham.UseVisualStyleBackColor = false;
            // 
            // txtTimSanPham
            // 
            txtTimSanPham.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtTimSanPham.Font = new Font("Segoe UI", 9.5F);
            txtTimSanPham.Location = new Point(17, 40);
            txtTimSanPham.Margin = new Padding(3, 4, 3, 4);
            txtTimSanPham.Name = "txtTimSanPham";
            txtTimSanPham.PlaceholderText = "Nhập mã hoặc tên sản phẩm...";
            txtTimSanPham.Size = new Size(417, 29);
            txtTimSanPham.TabIndex = 0;
            // 
            // grpGioHang
            // 
            grpGioHang.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            grpGioHang.BackColor = Color.FromArgb(248, 250, 252);
            grpGioHang.Controls.Add(dgvGioHang);
            grpGioHang.Controls.Add(btnXoaSanPham);
            grpGioHang.Controls.Add(btnCapNhatSoLuong);
            grpGioHang.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            grpGioHang.ForeColor = Color.FromArgb(30, 41, 59);
            grpGioHang.Location = new Point(617, 177);
            grpGioHang.Margin = new Padding(3, 4, 3, 4);
            grpGioHang.Name = "grpGioHang";
            grpGioHang.Padding = new Padding(3, 4, 3, 4);
            grpGioHang.Size = new Size(719, 500);
            grpGioHang.TabIndex = 3;
            grpGioHang.TabStop = false;
            grpGioHang.Text = "C. Giỏ hàng / Chi tiết hóa đơn";
            // 
            // dgvGioHang
            // 
            dgvGioHang.AllowUserToAddRows = false;
            dgvGioHang.AllowUserToDeleteRows = false;
            dgvGioHang.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvGioHang.BackgroundColor = Color.White;
            dgvGioHang.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvGioHang.Columns.AddRange(new DataGridViewColumn[] { colGH_STT, colGH_Ma, colGH_Ten, colGH_DVT, colGH_SoLuong, colGH_DonGia, colGH_ThanhTien });
            dgvGioHang.Location = new Point(17, 36);
            dgvGioHang.Margin = new Padding(3, 4, 3, 4);
            dgvGioHang.MultiSelect = false;
            dgvGioHang.Name = "dgvGioHang";
            dgvGioHang.ReadOnly = true;
            dgvGioHang.RowHeadersVisible = false;
            dgvGioHang.RowHeadersWidth = 51;
            dgvGioHang.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvGioHang.Size = new Size(685, 387);
            dgvGioHang.TabIndex = 0;
            // 
            // colGH_STT
            // 
            colGH_STT.HeaderText = "STT";
            colGH_STT.MinimumWidth = 6;
            colGH_STT.Name = "colGH_STT";
            colGH_STT.ReadOnly = true;
            colGH_STT.Width = 50;
            // 
            // colGH_Ma
            // 
            colGH_Ma.HeaderText = "Mã SP";
            colGH_Ma.MinimumWidth = 6;
            colGH_Ma.Name = "colGH_Ma";
            colGH_Ma.ReadOnly = true;
            colGH_Ma.Width = 90;
            // 
            // colGH_Ten
            // 
            colGH_Ten.HeaderText = "Tên sản phẩm";
            colGH_Ten.MinimumWidth = 6;
            colGH_Ten.Name = "colGH_Ten";
            colGH_Ten.ReadOnly = true;
            colGH_Ten.Width = 170;
            // 
            // colGH_DVT
            // 
            colGH_DVT.HeaderText = "ĐVT";
            colGH_DVT.MinimumWidth = 6;
            colGH_DVT.Name = "colGH_DVT";
            colGH_DVT.ReadOnly = true;
            colGH_DVT.Width = 70;
            // 
            // colGH_SoLuong
            // 
            colGH_SoLuong.HeaderText = "Số lượng";
            colGH_SoLuong.MinimumWidth = 6;
            colGH_SoLuong.Name = "colGH_SoLuong";
            colGH_SoLuong.ReadOnly = true;
            colGH_SoLuong.Width = 85;
            // 
            // colGH_DonGia
            // 
            colGH_DonGia.HeaderText = "Đơn giá";
            colGH_DonGia.MinimumWidth = 6;
            colGH_DonGia.Name = "colGH_DonGia";
            colGH_DonGia.ReadOnly = true;
            colGH_DonGia.Width = 125;
            // 
            // colGH_ThanhTien
            // 
            colGH_ThanhTien.HeaderText = "Thành tiền";
            colGH_ThanhTien.MinimumWidth = 6;
            colGH_ThanhTien.Name = "colGH_ThanhTien";
            colGH_ThanhTien.ReadOnly = true;
            colGH_ThanhTien.Width = 125;
            // 
            // btnXoaSanPham
            // 
            btnXoaSanPham.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnXoaSanPham.BackColor = Color.FromArgb(254, 242, 242);
            btnXoaSanPham.Cursor = Cursors.Hand;
            btnXoaSanPham.FlatStyle = FlatStyle.Flat;
            btnXoaSanPham.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnXoaSanPham.ForeColor = Color.FromArgb(185, 28, 28);
            btnXoaSanPham.Location = new Point(217, 440);
            btnXoaSanPham.Margin = new Padding(3, 4, 3, 4);
            btnXoaSanPham.Name = "btnXoaSanPham";
            btnXoaSanPham.Size = new Size(171, 44);
            btnXoaSanPham.TabIndex = 2;
            btnXoaSanPham.Text = "❌ Xóa sản phẩm";
            btnXoaSanPham.UseVisualStyleBackColor = false;
            // 
            // btnCapNhatSoLuong
            // 
            btnCapNhatSoLuong.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnCapNhatSoLuong.BackColor = Color.FromArgb(240, 253, 244);
            btnCapNhatSoLuong.Cursor = Cursors.Hand;
            btnCapNhatSoLuong.FlatStyle = FlatStyle.Flat;
            btnCapNhatSoLuong.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnCapNhatSoLuong.ForeColor = Color.FromArgb(21, 128, 61);
            btnCapNhatSoLuong.Location = new Point(17, 440);
            btnCapNhatSoLuong.Margin = new Padding(3, 4, 3, 4);
            btnCapNhatSoLuong.Name = "btnCapNhatSoLuong";
            btnCapNhatSoLuong.Size = new Size(189, 44);
            btnCapNhatSoLuong.TabIndex = 1;
            btnCapNhatSoLuong.Text = "🔄 Cập nhật số lượng";
            btnCapNhatSoLuong.UseVisualStyleBackColor = false;
            // 
            // grpThanhToan
            // 
            grpThanhToan.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            grpThanhToan.BackColor = Color.FromArgb(248, 250, 252);
            grpThanhToan.Controls.Add(lblTongTien);
            grpThanhToan.Controls.Add(lblTieuDeTongTien);
            grpThanhToan.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            grpThanhToan.ForeColor = Color.FromArgb(30, 41, 59);
            grpThanhToan.Location = new Point(617, 689);
            grpThanhToan.Margin = new Padding(3, 4, 3, 4);
            grpThanhToan.Name = "grpThanhToan";
            grpThanhToan.Padding = new Padding(3, 4, 3, 4);
            grpThanhToan.Size = new Size(719, 121);
            grpThanhToan.TabIndex = 4;
            grpThanhToan.TabStop = false;
            grpThanhToan.Text = "E. Thanh toán";
            // 
            // lblTongTien
            // 
            lblTongTien.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lblTongTien.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            lblTongTien.ForeColor = Color.FromArgb(220, 38, 38);
            lblTongTien.Location = new Point(285, 33);
            lblTongTien.Name = "lblTongTien";
            lblTongTien.Size = new Size(417, 69);
            lblTongTien.TabIndex = 1;
            lblTongTien.Text = "0 VNĐ";
            lblTongTien.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblTieuDeTongTien
            // 
            lblTieuDeTongTien.AutoSize = true;
            lblTieuDeTongTien.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblTieuDeTongTien.ForeColor = Color.FromArgb(51, 65, 85);
            lblTieuDeTongTien.Location = new Point(23, 56);
            lblTieuDeTongTien.Name = "lblTieuDeTongTien";
            lblTieuDeTongTien.Size = new Size(265, 28);
            lblTieuDeTongTien.TabIndex = 0;
            lblTieuDeTongTien.Text = "TỔNG TIỀN THANH TOÁN:";
            // 
            // btnLamMoi
            // 
            btnLamMoi.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnLamMoi.BackColor = Color.FromArgb(248, 250, 252);
            btnLamMoi.Cursor = Cursors.Hand;
            btnLamMoi.FlatStyle = FlatStyle.Flat;
            btnLamMoi.Font = new Font("Segoe UI", 9.5F);
            btnLamMoi.ForeColor = Color.FromArgb(15, 23, 42);
            btnLamMoi.Location = new Point(874, 17);
            btnLamMoi.Margin = new Padding(3, 4, 3, 4);
            btnLamMoi.Name = "btnLamMoi";
            btnLamMoi.Size = new Size(131, 48);
            btnLamMoi.TabIndex = 1;
            btnLamMoi.Text = "🔄 Làm mới";
            btnLamMoi.UseVisualStyleBackColor = false;
            // 
            // btnHuyHoaDon
            // 
            btnHuyHoaDon.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnHuyHoaDon.BackColor = Color.FromArgb(254, 242, 242);
            btnHuyHoaDon.Cursor = Cursors.Hand;
            btnHuyHoaDon.FlatStyle = FlatStyle.Flat;
            btnHuyHoaDon.Font = new Font("Segoe UI", 9F);
            btnHuyHoaDon.ForeColor = Color.FromArgb(185, 28, 28);
            btnHuyHoaDon.Location = new Point(1023, 17);
            btnHuyHoaDon.Margin = new Padding(3, 4, 3, 4);
            btnHuyHoaDon.Name = "btnHuyHoaDon";
            btnHuyHoaDon.Size = new Size(154, 48);
            btnHuyHoaDon.TabIndex = 2;
            btnHuyHoaDon.Text = "🚫 Hủy hóa đơn";
            btnHuyHoaDon.UseVisualStyleBackColor = false;
            // 
            // btnDong
            // 
            btnDong.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnDong.BackColor = Color.FromArgb(226, 232, 240);
            btnDong.Cursor = Cursors.Hand;
            btnDong.FlatStyle = FlatStyle.Flat;
            btnDong.Font = new Font("Segoe UI", 9.5F);
            btnDong.ForeColor = Color.FromArgb(15, 23, 42);
            btnDong.Location = new Point(1194, 17);
            btnDong.Margin = new Padding(3, 4, 3, 4);
            btnDong.Name = "btnDong";
            btnDong.Size = new Size(131, 48);
            btnDong.TabIndex = 3;
            btnDong.Text = "🚪 Đóng";
            btnDong.UseVisualStyleBackColor = false;
            // 
            // btnLuuHoaDon
            // 
            btnLuuHoaDon.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnLuuHoaDon.BackColor = Color.FromArgb(22, 163, 74);
            btnLuuHoaDon.Cursor = Cursors.Hand;
            btnLuuHoaDon.FlatStyle = FlatStyle.Flat;
            btnLuuHoaDon.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnLuuHoaDon.ForeColor = Color.White;
            btnLuuHoaDon.Location = new Point(691, 17);
            btnLuuHoaDon.Margin = new Padding(3, 4, 3, 4);
            btnLuuHoaDon.Name = "btnLuuHoaDon";
            btnLuuHoaDon.Size = new Size(166, 48);
            btnLuuHoaDon.TabIndex = 0;
            btnLuuHoaDon.Text = "💾 Lưu hóa đơn";
            btnLuuHoaDon.UseVisualStyleBackColor = false;
            // 
            // panelChucNang
            // 
            panelChucNang.BackColor = Color.FromArgb(241, 245, 249);
            panelChucNang.Controls.Add(bntHome);
            panelChucNang.Controls.Add(btnLuuHoaDon);
            panelChucNang.Controls.Add(btnDong);
            panelChucNang.Controls.Add(btnHuyHoaDon);
            panelChucNang.Controls.Add(btnLamMoi);
            panelChucNang.Dock = DockStyle.Bottom;
            panelChucNang.Location = new Point(0, 825);
            panelChucNang.Margin = new Padding(3, 4, 3, 4);
            panelChucNang.Name = "panelChucNang";
            panelChucNang.Size = new Size(1353, 83);
            panelChucNang.TabIndex = 5;
            // 
            // bntHome
            // 
            bntHome.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            bntHome.BackColor = Color.FromArgb(37, 99, 235);
            bntHome.Cursor = Cursors.Hand;
            bntHome.FlatStyle = FlatStyle.Flat;
            bntHome.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            bntHome.ForeColor = Color.White;
            bntHome.Location = new Point(30, 17);
            bntHome.Margin = new Padding(3, 4, 3, 4);
            bntHome.Name = "bntHome";
            bntHome.Size = new Size(150, 48);
            bntHome.TabIndex = 4;
            bntHome.Text = "⌂ Home";
            bntHome.UseVisualStyleBackColor = false;
            // 
            // grpPhuongThucThanhToan
            // 
            grpPhuongThucThanhToan.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            grpPhuongThucThanhToan.Controls.Add(tableLayoutPanel1);
            grpPhuongThucThanhToan.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            grpPhuongThucThanhToan.ForeColor = Color.FromArgb(30, 41, 59);
            grpPhuongThucThanhToan.Location = new Point(17, 725);
            grpPhuongThucThanhToan.Name = "grpPhuongThucThanhToan";
            grpPhuongThucThanhToan.Size = new Size(589, 85);
            grpPhuongThucThanhToan.TabIndex = 6;
            grpPhuongThucThanhToan.TabStop = false;
            grpPhuongThucThanhToan.Text = "D. Phương thức thanh toán";
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 3;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel1.Controls.Add(rdoTienMat, 0, 0);
            tableLayoutPanel1.Controls.Add(rdoChuyenKhoan, 1, 0);
            tableLayoutPanel1.Controls.Add(rdoQuetThe, 2, 0);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(3, 25);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Size = new Size(583, 57);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // rdoTienMat
            // 
            rdoTienMat.Anchor = AnchorStyles.None;
            rdoTienMat.AutoSize = true;
            rdoTienMat.Checked = true;
            rdoTienMat.Location = new Point(48, 16);
            rdoTienMat.Name = "rdoTienMat";
            rdoTienMat.Size = new Size(98, 25);
            rdoTienMat.TabIndex = 0;
            rdoTienMat.TabStop = true;
            rdoTienMat.Text = "Tiền mặt";
            rdoTienMat.TextAlign = ContentAlignment.MiddleCenter;
            rdoTienMat.UseVisualStyleBackColor = true;
            // 
            // rdoChuyenKhoan
            // 
            rdoChuyenKhoan.Anchor = AnchorStyles.None;
            rdoChuyenKhoan.AutoSize = true;
            rdoChuyenKhoan.Location = new Point(220, 16);
            rdoChuyenKhoan.Name = "rdoChuyenKhoan";
            rdoChuyenKhoan.Size = new Size(141, 25);
            rdoChuyenKhoan.TabIndex = 1;
            rdoChuyenKhoan.Text = "Chuyển khoản";
            rdoChuyenKhoan.UseVisualStyleBackColor = true;
            // 
            // rdoQuetThe
            // 
            rdoQuetThe.Anchor = AnchorStyles.None;
            rdoQuetThe.AutoSize = true;
            rdoQuetThe.Location = new Point(437, 16);
            rdoQuetThe.Name = "rdoQuetThe";
            rdoQuetThe.Size = new Size(97, 25);
            rdoQuetThe.TabIndex = 2;
            rdoQuetThe.Text = "Quẹt thẻ";
            rdoQuetThe.UseVisualStyleBackColor = true;
            // 
            // FrmBanHang
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(248, 250, 252);
            ClientSize = new Size(1353, 908);
            Controls.Add(grpPhuongThucThanhToan);
            Controls.Add(panelChucNang);
            Controls.Add(grpThanhToan);
            Controls.Add(grpGioHang);
            Controls.Add(grpSanPham);
            Controls.Add(grpThongTinHoaDon);
            Controls.Add(lblTieuDeForm);
            ForeColor = SystemColors.ControlText;
            Name = "FrmBanHang";
            Text = "FrmBanHang";
            grpThongTinHoaDon.ResumeLayout(false);
            grpThongTinHoaDon.PerformLayout();
            grpSanPham.ResumeLayout(false);
            grpSanPham.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvSanPham).EndInit();
            ((System.ComponentModel.ISupportInitialize)numSoLuong).EndInit();
            grpGioHang.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvGioHang).EndInit();
            grpThanhToan.ResumeLayout(false);
            grpThanhToan.PerformLayout();
            panelChucNang.ResumeLayout(false);
            grpPhuongThucThanhToan.ResumeLayout(false);
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Label lblTieuDeForm;
        public GroupBox grpThongTinHoaDon;
        private Label lblKhachHang;
        private Label lblNgayLap;
        private Label lblMaHoaDon;
        private ComboBox cboKhachHang;
        private DateTimePicker dtpNgayLap;
        private TextBox txtMaHoaDon;
        private GroupBox grpSanPham;
        private GroupBox grpGioHang;
        private GroupBox grpThanhToan;
        private Button btnTimSanPham;
        private TextBox txtTimSanPham;
        private Button btnThemSanPham;
        private NumericUpDown numSoLuong;
        private Label lblSoLuong;
        private Button btnXoaSanPham;
        private Button btnCapNhatSoLuong;
        private Label lblTongTien;
        private Label lblTieuDeTongTien;
        private Button btnLamMoi;
        private Button btnHuyHoaDon;
        private Button btnDong;
        private Button btnLuuHoaDon;
        private Panel panelChucNang;
        private DataGridView dgvSanPham;
        private DataGridView dgvGioHang;
        private DataGridViewTextBoxColumn colGH_STT;
        private DataGridViewTextBoxColumn colGH_Ma;
        private DataGridViewTextBoxColumn colGH_Ten;
        private DataGridViewTextBoxColumn colGH_DVT;
        private DataGridViewTextBoxColumn colGH_SoLuong;
        private DataGridViewTextBoxColumn colGH_DonGia;
        private DataGridViewTextBoxColumn colGH_ThanhTien;
        private DataGridViewTextBoxColumn colSP_Ma;
        private DataGridViewTextBoxColumn colSP_Ten;
        private DataGridViewTextBoxColumn colSP_DVT;
        private DataGridViewTextBoxColumn colSP_Gia;
        private DataGridViewTextBoxColumn colSP_TonKho;
        private Button bntHome;
        private GroupBox grpPhuongThucThanhToan;
        private TableLayoutPanel tableLayoutPanel1;
        private RadioButton rdoTienMat;
        private RadioButton rdoChuyenKhoan;
        private RadioButton rdoQuetThe;
    }
}