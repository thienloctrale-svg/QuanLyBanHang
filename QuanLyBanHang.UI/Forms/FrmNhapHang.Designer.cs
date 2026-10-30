namespace QuanLyBanHang.UI
{
    partial class FrmNhapHang : Form
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
            groupBox1 = new GroupBox();
            txtMaNV = new TextBox();
            cboNhaCungCap = new ComboBox();
            dtpNgayNhap = new DateTimePicker();
            txtMaPN = new TextBox();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            groupBox2 = new GroupBox();
            btnXemDanhSach = new Button();
            btnThemChiTiet = new Button();
            cboSanPham = new ComboBox();
            txtGiaNhap = new TextBox();
            label7 = new Label();
            txtSoLuong = new TextBox();
            label6 = new Label();
            label5 = new Label();
            dgvChiTietNhap = new DataGridView();
            MaSP = new DataGridViewTextBoxColumn();
            TenSP = new DataGridViewTextBoxColumn();
            SoLuong = new DataGridViewTextBoxColumn();
            GiaNhap = new DataGridViewTextBoxColumn();
            ThanhTien = new DataGridViewTextBoxColumn();
            lblTongTien = new Label();
            btnLuu = new Button();
            btnLamMoi = new Button();
            btnHome = new Button();
            btnXoaPhieu = new Button();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvChiTietNhap).BeginInit();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(txtMaNV);
            groupBox1.Controls.Add(cboNhaCungCap);
            groupBox1.Controls.Add(dtpNgayNhap);
            groupBox1.Controls.Add(txtMaPN);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(label1);
            groupBox1.Location = new Point(34, 22);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(576, 207);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Thông tin phiếu nhập";
            // 
            // txtMaNV
            // 
            txtMaNV.Location = new Point(253, 156);
            txtMaNV.Name = "txtMaNV";
            txtMaNV.Size = new Size(281, 27);
            txtMaNV.TabIndex = 7;
            // 
            // cboNhaCungCap
            // 
            cboNhaCungCap.FormattingEnabled = true;
            cboNhaCungCap.Location = new Point(253, 112);
            cboNhaCungCap.Name = "cboNhaCungCap";
            cboNhaCungCap.Size = new Size(281, 28);
            cboNhaCungCap.TabIndex = 6;
            // 
            // dtpNgayNhap
            // 
            dtpNgayNhap.Location = new Point(253, 73);
            dtpNgayNhap.Name = "dtpNgayNhap";
            dtpNgayNhap.Size = new Size(281, 27);
            dtpNgayNhap.TabIndex = 5;
            // 
            // txtMaPN
            // 
            txtMaPN.Location = new Point(253, 35);
            txtMaPN.Name = "txtMaPN";
            txtMaPN.Size = new Size(281, 27);
            txtMaPN.TabIndex = 4;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(32, 163);
            label4.Name = "label4";
            label4.Size = new Size(124, 20);
            label4.TabIndex = 3;
            label4.Text = "Nhân Viên Nhập";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(32, 120);
            label3.Name = "label3";
            label3.Size = new Size(108, 20);
            label3.TabIndex = 2;
            label3.Text = "Nhà Cung Cấp";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(32, 80);
            label2.Name = "label2";
            label2.Size = new Size(88, 20);
            label2.TabIndex = 1;
            label2.Text = "Ngày Nhập";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(32, 42);
            label1.Name = "label1";
            label1.Size = new Size(116, 20);
            label1.TabIndex = 0;
            label1.Text = "Mã Phiếu Nhập";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(btnXemDanhSach);
            groupBox2.Controls.Add(btnThemChiTiet);
            groupBox2.Controls.Add(cboSanPham);
            groupBox2.Controls.Add(txtGiaNhap);
            groupBox2.Controls.Add(label7);
            groupBox2.Controls.Add(txtSoLuong);
            groupBox2.Controls.Add(label6);
            groupBox2.Controls.Add(label5);
            groupBox2.Location = new Point(692, 22);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(710, 207);
            groupBox2.TabIndex = 1;
            groupBox2.TabStop = false;
            groupBox2.Text = "Chi tiết nhập hàng";
            // 
            // btnXemDanhSach
            // 
            btnXemDanhSach.BackColor = Color.FromArgb(192, 192, 0);
            btnXemDanhSach.FlatStyle = FlatStyle.Flat;
            btnXemDanhSach.ForeColor = Color.White;
            btnXemDanhSach.Location = new Point(465, 153);
            btnXemDanhSach.Name = "btnXemDanhSach";
            btnXemDanhSach.Size = new Size(219, 29);
            btnXemDanhSach.TabIndex = 8;
            btnXemDanhSach.Text = "📋 Xem danh sách đã lưu";
            btnXemDanhSach.UseVisualStyleBackColor = false;
            btnXemDanhSach.Click += btnXemDanhSach_Click;
            // 
            // btnThemChiTiet
            // 
            btnThemChiTiet.BackColor = Color.Gray;
            btnThemChiTiet.FlatStyle = FlatStyle.Flat;
            btnThemChiTiet.ForeColor = Color.White;
            btnThemChiTiet.Location = new Point(466, 94);
            btnThemChiTiet.Name = "btnThemChiTiet";
            btnThemChiTiet.Size = new Size(192, 29);
            btnThemChiTiet.TabIndex = 7;
            btnThemChiTiet.Text = "➕ Thêm vào phiếu";
            btnThemChiTiet.UseVisualStyleBackColor = false;
            btnThemChiTiet.Click += btnThemChiTiet_Click;
            // 
            // cboSanPham
            // 
            cboSanPham.FormattingEnabled = true;
            cboSanPham.Location = new Point(228, 34);
            cboSanPham.Name = "cboSanPham";
            cboSanPham.Size = new Size(286, 28);
            cboSanPham.TabIndex = 6;
            // 
            // txtGiaNhap
            // 
            txtGiaNhap.Location = new Point(228, 149);
            txtGiaNhap.Name = "txtGiaNhap";
            txtGiaNhap.Size = new Size(132, 27);
            txtGiaNhap.TabIndex = 5;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(39, 156);
            label7.Name = "label7";
            label7.Size = new Size(71, 20);
            label7.TabIndex = 4;
            label7.Text = "Giá nhập";
            // 
            // txtSoLuong
            // 
            txtSoLuong.Location = new Point(228, 91);
            txtSoLuong.Name = "txtSoLuong";
            txtSoLuong.Size = new Size(132, 27);
            txtSoLuong.TabIndex = 3;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(39, 98);
            label6.Name = "label6";
            label6.Size = new Size(71, 20);
            label6.TabIndex = 2;
            label6.Text = "Số lượng";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(39, 42);
            label5.Name = "label5";
            label5.Size = new Size(78, 20);
            label5.TabIndex = 0;
            label5.Text = "Sản Phẩm";
            // 
            // dgvChiTietNhap
            // 
            dgvChiTietNhap.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvChiTietNhap.Columns.AddRange(new DataGridViewColumn[] { MaSP, TenSP, SoLuong, GiaNhap, ThanhTien });
            dgvChiTietNhap.Location = new Point(30, 272);
            dgvChiTietNhap.Name = "dgvChiTietNhap";
            dgvChiTietNhap.RowHeadersWidth = 51;
            dgvChiTietNhap.Size = new Size(778, 188);
            dgvChiTietNhap.TabIndex = 2;
            // 
            // MaSP
            // 
            MaSP.HeaderText = "Mã SP";
            MaSP.MinimumWidth = 6;
            MaSP.Name = "MaSP";
            MaSP.Width = 125;
            // 
            // TenSP
            // 
            TenSP.HeaderText = "Tên SP";
            TenSP.MinimumWidth = 6;
            TenSP.Name = "TenSP";
            TenSP.Width = 125;
            // 
            // SoLuong
            // 
            SoLuong.HeaderText = "Số Lượng";
            SoLuong.MinimumWidth = 6;
            SoLuong.Name = "SoLuong";
            SoLuong.Width = 125;
            // 
            // GiaNhap
            // 
            GiaNhap.HeaderText = "Giá Nhập";
            GiaNhap.MinimumWidth = 6;
            GiaNhap.Name = "GiaNhap";
            GiaNhap.Width = 125;
            // 
            // ThanhTien
            // 
            ThanhTien.HeaderText = "Thành Tiền";
            ThanhTien.MinimumWidth = 6;
            ThanhTien.Name = "ThanhTien";
            ThanhTien.Width = 125;
            // 
            // lblTongTien
            // 
            lblTongTien.AutoSize = true;
            lblTongTien.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 163);
            lblTongTien.Location = new Point(335, 484);
            lblTongTien.Name = "lblTongTien";
            lblTongTien.Size = new Size(357, 38);
            lblTongTien.TabIndex = 3;
            lblTongTien.Text = "Tổng tiền cần thanh toán:";
            // 
            // btnLuu
            // 
            btnLuu.BackColor = Color.Green;
            btnLuu.FlatStyle = FlatStyle.Flat;
            btnLuu.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 163);
            btnLuu.ForeColor = SystemColors.Window;
            btnLuu.Location = new Point(134, 543);
            btnLuu.Name = "btnLuu";
            btnLuu.Size = new Size(173, 52);
            btnLuu.TabIndex = 4;
            btnLuu.Text = "💾 Lưu phiếu nhập";
            btnLuu.UseVisualStyleBackColor = false;
            btnLuu.Click += btnLuu_Click;
            // 
            // btnLamMoi
            // 
            btnLamMoi.BackColor = Color.FromArgb(255, 128, 0);
            btnLamMoi.FlatStyle = FlatStyle.Flat;
            btnLamMoi.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 163);
            btnLamMoi.ForeColor = SystemColors.Window;
            btnLamMoi.Location = new Point(770, 543);
            btnLamMoi.Name = "btnLamMoi";
            btnLamMoi.Size = new Size(158, 52);
            btnLamMoi.TabIndex = 5;
            btnLamMoi.Text = "🔄 Làm mới";
            btnLamMoi.UseVisualStyleBackColor = false;
            btnLamMoi.Click += btnLamMoi_Click;
            // 
            // btnHome
            // 
            btnHome.BackColor = Color.Blue;
            btnHome.FlatStyle = FlatStyle.Flat;
            btnHome.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 163);
            btnHome.ForeColor = SystemColors.Window;
            btnHome.Location = new Point(1084, 543);
            btnHome.Name = "btnHome";
            btnHome.Size = new Size(165, 52);
            btnHome.TabIndex = 6;
            btnHome.Text = "🏠 Home";
            btnHome.UseVisualStyleBackColor = false;
            btnHome.Click += btnHome_Click;
            // 
            // btnXoaPhieu
            // 
            btnXoaPhieu.BackColor = Color.Red;
            btnXoaPhieu.FlatStyle = FlatStyle.Flat;
            btnXoaPhieu.ForeColor = Color.White;
            btnXoaPhieu.Location = new Point(463, 543);
            btnXoaPhieu.Name = "btnXoaPhieu";
            btnXoaPhieu.Size = new Size(157, 52);
            btnXoaPhieu.TabIndex = 7;
            btnXoaPhieu.Text = "❌ Xóa phiếu nhập";
            btnXoaPhieu.UseVisualStyleBackColor = false;
            btnXoaPhieu.Click += btnXoaPhieu_Click;
            // 
            // FrmNhapHang
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1433, 607);
            Controls.Add(btnXoaPhieu);
            Controls.Add(btnHome);
            Controls.Add(btnLamMoi);
            Controls.Add(btnLuu);
            Controls.Add(lblTongTien);
            Controls.Add(dgvChiTietNhap);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 163);
            Name = "FrmNhapHang";
            Text = "FrmNhapHang";
            Load += FrmNhapHang_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvChiTietNhap).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private GroupBox groupBox1;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
        private TextBox txtMaNV;
        private ComboBox cboNhaCungCap;
        private DateTimePicker dtpNgayNhap;
        private TextBox txtMaPN;
        private GroupBox groupBox2;
        private Label label6;
        private Label label5;
        private ComboBox cboSanPham;
        private TextBox txtGiaNhap;
        private Label label7;
        private TextBox txtSoLuong;
        private Button btnThemChiTiet;
        private DataGridView dgvChiTietNhap;
        private Label lblTongTien;
        private Button btnLuu;
        private Button btnLamMoi;
        private Button btnHome;
        private Button btnXemDanhSach;
        private DataGridViewTextBoxColumn MaSP;
        private DataGridViewTextBoxColumn TenSP;
        private DataGridViewTextBoxColumn SoLuong;
        private DataGridViewTextBoxColumn GiaNhap;
        private DataGridViewTextBoxColumn ThanhTien;
        private Button btnXoaPhieu;
    }
}