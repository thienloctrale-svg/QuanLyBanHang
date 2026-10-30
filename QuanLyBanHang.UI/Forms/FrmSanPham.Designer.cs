namespace QuanLyBanHang.UI
{
    partial class FrmSanPham : System.Windows.Forms.Form
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
            label1 = new Label();
            groupBox1 = new GroupBox();
            cboLoaiSanPham = new ComboBox();
            txtTimKiem = new TextBox();
            label7 = new Label();
            txtSoLuongTon = new TextBox();
            label6 = new Label();
            txtGiaBan = new TextBox();
            label5 = new Label();
            txtGiaNhap = new TextBox();
            label4 = new Label();
            txtDonViTinh = new TextBox();
            label3 = new Label();
            txtTenSanPham = new TextBox();
            label2 = new Label();
            txtMaSanPham = new TextBox();
            btnThem = new Button();
            btnSua = new Button();
            btnXoa = new Button();
            btnLamMoi = new Button();
            btnTimKiem = new Button();
            dgvSanPham = new DataGridView();
            colMaSP = new DataGridViewTextBoxColumn();
            colTenSP = new DataGridViewTextBoxColumn();
            colLoaiSP = new DataGridViewTextBoxColumn();
            colDVT = new DataGridViewTextBoxColumn();
            colGiaNhap = new DataGridViewTextBoxColumn();
            colGiaBan = new DataGridViewTextBoxColumn();
            colSoLuong = new DataGridViewTextBoxColumn();
            colTrangThai = new DataGridViewTextBoxColumn();
            btnHome = new Button();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvSanPham).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(38, 45);
            label1.Name = "label1";
            label1.Size = new Size(50, 20);
            label1.TabIndex = 0;
            label1.Text = "Mã SP";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(cboLoaiSanPham);
            groupBox1.Controls.Add(txtTimKiem);
            groupBox1.Controls.Add(label7);
            groupBox1.Controls.Add(txtSoLuongTon);
            groupBox1.Controls.Add(label6);
            groupBox1.Controls.Add(txtGiaBan);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(txtGiaNhap);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(txtDonViTinh);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(txtTenSanPham);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(txtMaSanPham);
            groupBox1.Controls.Add(label1);
            groupBox1.Location = new Point(12, 27);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(1020, 209);
            groupBox1.TabIndex = 1;
            groupBox1.TabStop = false;
            groupBox1.Text = "Thông tin sản phẩm";
            // 
            // cboLoaiSanPham
            // 
            cboLoaiSanPham.FormattingEnabled = true;
            cboLoaiSanPham.Location = new Point(744, 79);
            cboLoaiSanPham.Name = "cboLoaiSanPham";
            cboLoaiSanPham.Size = new Size(241, 28);
            cboLoaiSanPham.TabIndex = 15;
            // 
            // txtTimKiem
            // 
            txtTimKiem.ForeColor = SystemColors.GrayText;
            txtTimKiem.Location = new Point(744, 127);
            txtTimKiem.Name = "txtTimKiem";
            txtTimKiem.Size = new Size(246, 27);
            txtTimKiem.TabIndex = 14;
            txtTimKiem.Text = "Tìm kiếm theo mã hoặc tên";
            txtTimKiem.Enter += txtTimKiem_Enter;
            txtTimKiem.Leave += txtTimKiem_Leave;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(744, 42);
            label7.Name = "label7";
            label7.Size = new Size(105, 20);
            label7.TabIndex = 12;
            label7.Text = "Loại sản phẩm";
            // 
            // txtSoLuongTon
            // 
            txtSoLuongTon.Location = new Point(538, 143);
            txtSoLuongTon.Name = "txtSoLuongTon";
            txtSoLuongTon.Size = new Size(125, 27);
            txtSoLuongTon.TabIndex = 11;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(413, 150);
            label6.Name = "label6";
            label6.Size = new Size(95, 20);
            label6.TabIndex = 10;
            label6.Text = "Số lượng tồn";
            // 
            // txtGiaBan
            // 
            txtGiaBan.Location = new Point(538, 89);
            txtGiaBan.Name = "txtGiaBan";
            txtGiaBan.Size = new Size(125, 27);
            txtGiaBan.TabIndex = 9;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(413, 96);
            label5.Name = "label5";
            label5.Size = new Size(60, 20);
            label5.TabIndex = 8;
            label5.Text = "Giá bán";
            // 
            // txtGiaNhap
            // 
            txtGiaNhap.Location = new Point(538, 42);
            txtGiaNhap.Name = "txtGiaNhap";
            txtGiaNhap.Size = new Size(125, 27);
            txtGiaNhap.TabIndex = 7;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(413, 45);
            label4.Name = "label4";
            label4.Size = new Size(68, 20);
            label4.TabIndex = 6;
            label4.Text = "Giá nhập";
            // 
            // txtDonViTinh
            // 
            txtDonViTinh.Location = new Point(159, 143);
            txtDonViTinh.Name = "txtDonViTinh";
            txtDonViTinh.Size = new Size(125, 27);
            txtDonViTinh.TabIndex = 5;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(38, 150);
            label3.Name = "label3";
            label3.Size = new Size(81, 20);
            label3.TabIndex = 4;
            label3.Text = "Đơn vị tính";
            // 
            // txtTenSanPham
            // 
            txtTenSanPham.Location = new Point(159, 89);
            txtTenSanPham.Name = "txtTenSanPham";
            txtTenSanPham.Size = new Size(125, 27);
            txtTenSanPham.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(38, 96);
            label2.Name = "label2";
            label2.Size = new Size(52, 20);
            label2.TabIndex = 2;
            label2.Text = "Tên SP";
            // 
            // txtMaSanPham
            // 
            txtMaSanPham.Location = new Point(159, 38);
            txtMaSanPham.Name = "txtMaSanPham";
            txtMaSanPham.Size = new Size(125, 27);
            txtMaSanPham.TabIndex = 1;
            // 
            // btnThem
            // 
            btnThem.BackColor = Color.MediumSeaGreen;
            btnThem.FlatStyle = FlatStyle.Flat;
            btnThem.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 163);
            btnThem.ForeColor = Color.White;
            btnThem.Location = new Point(333, 278);
            btnThem.Name = "btnThem";
            btnThem.Size = new Size(94, 29);
            btnThem.TabIndex = 15;
            btnThem.Text = "➕ Thêm";
            btnThem.UseVisualStyleBackColor = false;
            btnThem.Click += btnThem_Click;
            // 
            // btnSua
            // 
            btnSua.BackColor = Color.Olive;
            btnSua.FlatStyle = FlatStyle.Flat;
            btnSua.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 163);
            btnSua.ForeColor = SystemColors.ButtonHighlight;
            btnSua.Location = new Point(498, 278);
            btnSua.Name = "btnSua";
            btnSua.Size = new Size(94, 29);
            btnSua.TabIndex = 16;
            btnSua.Text = "🛠️ Sửa";
            btnSua.UseVisualStyleBackColor = false;
            btnSua.Click += btnSua_Click;
            // 
            // btnXoa
            // 
            btnXoa.BackColor = Color.Red;
            btnXoa.FlatStyle = FlatStyle.Flat;
            btnXoa.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 163);
            btnXoa.ForeColor = Color.White;
            btnXoa.Location = new Point(659, 278);
            btnXoa.Name = "btnXoa";
            btnXoa.Size = new Size(94, 29);
            btnXoa.TabIndex = 17;
            btnXoa.Text = "❌ Xóa";
            btnXoa.UseVisualStyleBackColor = false;
            btnXoa.Click += btnXoa_Click;
            // 
            // btnLamMoi
            // 
            btnLamMoi.BackColor = Color.FromArgb(255, 128, 0);
            btnLamMoi.FlatStyle = FlatStyle.Flat;
            btnLamMoi.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 163);
            btnLamMoi.ForeColor = Color.White;
            btnLamMoi.Location = new Point(812, 278);
            btnLamMoi.Name = "btnLamMoi";
            btnLamMoi.Size = new Size(117, 29);
            btnLamMoi.TabIndex = 18;
            btnLamMoi.Text = "🔁 Làm mới ";
            btnLamMoi.UseVisualStyleBackColor = false;
            btnLamMoi.Click += btnLamMoi_Click;
            // 
            // btnTimKiem
            // 
            btnTimKiem.BackColor = Color.Gray;
            btnTimKiem.FlatStyle = FlatStyle.Flat;
            btnTimKiem.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 163);
            btnTimKiem.ForeColor = SystemColors.ButtonHighlight;
            btnTimKiem.Location = new Point(983, 278);
            btnTimKiem.Name = "btnTimKiem";
            btnTimKiem.Size = new Size(110, 29);
            btnTimKiem.TabIndex = 19;
            btnTimKiem.Text = "🔍 Tìm kiếm";
            btnTimKiem.UseVisualStyleBackColor = false;
            btnTimKiem.Click += btnTimKiem_Click;
            // 
            // dgvSanPham
            // 
            dgvSanPham.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvSanPham.Columns.AddRange(new DataGridViewColumn[] { colMaSP, colTenSP, colLoaiSP, colDVT, colGiaNhap, colGiaBan, colSoLuong, colTrangThai });
            dgvSanPham.Location = new Point(26, 345);
            dgvSanPham.Name = "dgvSanPham";
            dgvSanPham.RowHeadersWidth = 51;
            dgvSanPham.Size = new Size(1067, 220);
            dgvSanPham.TabIndex = 20;
            // 
            // colMaSP
            // 
            colMaSP.HeaderText = "Mã SP";
            colMaSP.MinimumWidth = 6;
            colMaSP.Name = "colMaSP";
            colMaSP.Width = 125;
            // 
            // colTenSP
            // 
            colTenSP.HeaderText = "Tên SP";
            colTenSP.MinimumWidth = 6;
            colTenSP.Name = "colTenSP";
            colTenSP.Width = 125;
            // 
            // colLoaiSP
            // 
            colLoaiSP.HeaderText = "Loại SP";
            colLoaiSP.MinimumWidth = 6;
            colLoaiSP.Name = "colLoaiSP";
            colLoaiSP.Width = 125;
            // 
            // colDVT
            // 
            colDVT.HeaderText = "Đơn Vị Tính";
            colDVT.MinimumWidth = 6;
            colDVT.Name = "colDVT";
            colDVT.Width = 125;
            // 
            // colGiaNhap
            // 
            colGiaNhap.HeaderText = "Giá Nhập";
            colGiaNhap.MinimumWidth = 6;
            colGiaNhap.Name = "colGiaNhap";
            colGiaNhap.Width = 125;
            // 
            // colGiaBan
            // 
            colGiaBan.HeaderText = "Giá Bán";
            colGiaBan.MinimumWidth = 6;
            colGiaBan.Name = "colGiaBan";
            colGiaBan.Width = 125;
            // 
            // colSoLuong
            // 
            colSoLuong.HeaderText = "Số Lượng";
            colSoLuong.MinimumWidth = 6;
            colSoLuong.Name = "colSoLuong";
            colSoLuong.Width = 125;
            // 
            // colTrangThai
            // 
            colTrangThai.HeaderText = "Trạng Thái";
            colTrangThai.MinimumWidth = 6;
            colTrangThai.Name = "colTrangThai";
            colTrangThai.Width = 125;
            // 
            // btnHome
            // 
            btnHome.BackColor = Color.Blue;
            btnHome.FlatStyle = FlatStyle.Flat;
            btnHome.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 163);
            btnHome.ForeColor = Color.White;
            btnHome.Location = new Point(26, 278);
            btnHome.Name = "btnHome";
            btnHome.Size = new Size(105, 29);
            btnHome.TabIndex = 21;
            btnHome.Text = " ⌂ Home ";
            btnHome.UseVisualStyleBackColor = false;
            btnHome.Click += btnHome_Click;
            // 
            // FrmSanPham
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1189, 615);
            Controls.Add(btnHome);
            Controls.Add(dgvSanPham);
            Controls.Add(btnThem);
            Controls.Add(btnSua);
            Controls.Add(btnXoa);
            Controls.Add(btnLamMoi);
            Controls.Add(btnTimKiem);
            Controls.Add(groupBox1);
            Name = "FrmSanPham";
            Text = "FrmSanPham";
            Load += FrmSanPham_Load;
            Click += btnThem_Click;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvSanPham).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Label label1;
        private GroupBox groupBox1;
        private TextBox txtMaSanPham;
        private TextBox txtGiaNhap;
        private Label label4;
        private TextBox txtDonViTinh;
        private Label label3;
        private TextBox txtTenSanPham;
        private Label label2;
        private TextBox txtTimKiem;
        private Label label7;
        private TextBox txtSoLuongTon;
        private Label label6;
        private TextBox txtGiaBan;
        private Label label5;
        private Button btnLamMoi;
        private Button btnXoa;
        private Button btnSua;
        private Button btnThem;
        private Button btnTimKiem;
        private DataGridView dgvSanPham;
        private ComboBox cboLoaiSanPham;
        private DataGridViewTextBoxColumn colMaSP;
        private DataGridViewTextBoxColumn colTenSP;
        private DataGridViewTextBoxColumn colLoaiSP;
        private DataGridViewTextBoxColumn colDVT;
        private DataGridViewTextBoxColumn colGiaNhap;
        private DataGridViewTextBoxColumn colGiaBan;
        private DataGridViewTextBoxColumn colSoLuong;
        private DataGridViewTextBoxColumn colTrangThai;
        private Button btnHome;
    }
}