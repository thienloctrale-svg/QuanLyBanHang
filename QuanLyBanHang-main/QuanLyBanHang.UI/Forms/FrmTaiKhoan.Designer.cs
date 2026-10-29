namespace QuanLyBanHang.UI
{
    partial class FrmTaiKhoan
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
            gbtk = new GroupBox();
            gbtths = new GroupBox();
            dtngaytao = new DateTimePicker();
            checktrangthai = new CheckBox();
            cbvaitro = new ComboBox();
            txtma = new TextBox();
            lblngaytao = new Label();
            lvltrangthai = new Label();
            lblvaitro = new Label();
            lblma = new Label();
            gbthongtinngoai = new GroupBox();
            checkmk = new CheckBox();
            txtmail = new TextBox();
            txtsdt = new TextBox();
            txtmk = new TextBox();
            txthoten = new TextBox();
            txttendn = new TextBox();
            lbltendn = new Label();
            lblsdt = new Label();
            lblmail = new Label();
            lblmk = new Label();
            lblhoten = new Label();
            btnthem = new Button();
            btnsua = new Button();
            btnkhoa = new Button();
            btnlammoi = new Button();
            btntrangchu = new Button();
            dgvTaiKhoan = new DataGridView();
            MaTaiKhoan = new DataGridViewTextBoxColumn();
            TenDangNhap = new DataGridViewTextBoxColumn();
            HoTen = new DataGridViewTextBoxColumn();
            MatKhau = new DataGridViewTextBoxColumn();
            Email = new DataGridViewTextBoxColumn();
            SoDienThoai = new DataGridViewTextBoxColumn();
            VaiTro = new DataGridViewTextBoxColumn();
            TrangThai = new DataGridViewTextBoxColumn();
            NgayTao = new DataGridViewTextBoxColumn();
            button1 = new Button();
            gbtk.SuspendLayout();
            gbtths.SuspendLayout();
            gbthongtinngoai.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvTaiKhoan).BeginInit();
            SuspendLayout();
            // 
            // gbtk
            // 
            gbtk.Controls.Add(gbtths);
            gbtk.Controls.Add(gbthongtinngoai);
            gbtk.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            gbtk.Location = new Point(27, 29);
            gbtk.Name = "gbtk";
            gbtk.Size = new Size(1074, 341);
            gbtk.TabIndex = 0;
            gbtk.TabStop = false;
            gbtk.Text = "Thông Tin Tài Khoản";
            // 
            // gbtths
            // 
            gbtths.Controls.Add(dtngaytao);
            gbtths.Controls.Add(checktrangthai);
            gbtths.Controls.Add(cbvaitro);
            gbtths.Controls.Add(txtma);
            gbtths.Controls.Add(lblngaytao);
            gbtths.Controls.Add(lvltrangthai);
            gbtths.Controls.Add(lblvaitro);
            gbtths.Controls.Add(lblma);
            gbtths.Location = new Point(592, 29);
            gbtths.Name = "gbtths";
            gbtths.Size = new Size(459, 290);
            gbtths.TabIndex = 9;
            gbtths.TabStop = false;
            gbtths.Text = "Thông Tin Hồ Sơ";
            // 
            // dtngaytao
            // 
            dtngaytao.Location = new Point(149, 98);
            dtngaytao.Name = "dtngaytao";
            dtngaytao.Size = new Size(286, 30);
            dtngaytao.TabIndex = 13;
            dtngaytao.ValueChanged += dtngaytao_ValueChanged;
            // 
            // checktrangthai
            // 
            checktrangthai.AutoSize = true;
            checktrangthai.Location = new Point(148, 197);
            checktrangthai.Name = "checktrangthai";
            checktrangthai.Size = new Size(120, 27);
            checktrangthai.TabIndex = 12;
            checktrangthai.Text = "Hoạt Động";
            checktrangthai.UseVisualStyleBackColor = true;
            checktrangthai.CheckedChanged += checktrangthai_CheckedChanged;
            // 
            // cbvaitro
            // 
            cbvaitro.FormattingEnabled = true;
            cbvaitro.Location = new Point(148, 146);
            cbvaitro.Name = "cbvaitro";
            cbvaitro.Size = new Size(287, 31);
            cbvaitro.TabIndex = 11;
            cbvaitro.SelectedIndexChanged += cbvaitro_SelectedIndexChanged;
            // 
            // txtma
            // 
            txtma.Location = new Point(149, 51);
            txtma.Name = "txtma";
            txtma.Size = new Size(286, 30);
            txtma.TabIndex = 9;
            txtma.TextChanged += txtma_TextChanged;
            // 
            // lblngaytao
            // 
            lblngaytao.AutoSize = true;
            lblngaytao.Location = new Point(6, 104);
            lblngaytao.Name = "lblngaytao";
            lblngaytao.Size = new Size(126, 23);
            lblngaytao.TabIndex = 8;
            lblngaytao.Text = "Ngày Tạo       :";
            // 
            // lvltrangthai
            // 
            lvltrangthai.AutoSize = true;
            lvltrangthai.Location = new Point(6, 197);
            lvltrangthai.Name = "lvltrangthai";
            lvltrangthai.Size = new Size(125, 23);
            lvltrangthai.TabIndex = 5;
            lvltrangthai.Text = "Trạng Thái     :";
            // 
            // lblvaitro
            // 
            lblvaitro.AutoSize = true;
            lblvaitro.Location = new Point(6, 149);
            lblvaitro.Name = "lblvaitro";
            lblvaitro.Size = new Size(125, 23);
            lblvaitro.TabIndex = 4;
            lblvaitro.Text = "Vai Trò           :";
            // 
            // lblma
            // 
            lblma.AutoSize = true;
            lblma.Location = new Point(6, 54);
            lblma.Name = "lblma";
            lblma.Size = new Size(128, 23);
            lblma.TabIndex = 0;
            lblma.Text = "Mã Tài Khoản :";
            lblma.Click += lblma_Click;
            // 
            // gbthongtinngoai
            // 
            gbthongtinngoai.Controls.Add(checkmk);
            gbthongtinngoai.Controls.Add(txtmail);
            gbthongtinngoai.Controls.Add(txtsdt);
            gbthongtinngoai.Controls.Add(txtmk);
            gbthongtinngoai.Controls.Add(txthoten);
            gbthongtinngoai.Controls.Add(txttendn);
            gbthongtinngoai.Controls.Add(lbltendn);
            gbthongtinngoai.Controls.Add(lblsdt);
            gbthongtinngoai.Controls.Add(lblmail);
            gbthongtinngoai.Controls.Add(lblmk);
            gbthongtinngoai.Controls.Add(lblhoten);
            gbthongtinngoai.Location = new Point(25, 29);
            gbthongtinngoai.Name = "gbthongtinngoai";
            gbthongtinngoai.Size = new Size(528, 289);
            gbthongtinngoai.TabIndex = 8;
            gbthongtinngoai.TabStop = false;
            gbthongtinngoai.Text = "Thông Tin Cơ Bản";
            gbthongtinngoai.Enter += gbthongtinngoai_Enter;
            // 
            // checkmk
            // 
            checkmk.AutoSize = true;
            checkmk.Location = new Point(427, 146);
            checkmk.Name = "checkmk";
            checkmk.Size = new Size(69, 27);
            checkmk.TabIndex = 13;
            checkmk.Text = "Hiện";
            checkmk.UseVisualStyleBackColor = true;
            checkmk.CheckedChanged += checkmk_CheckedChanged;
            // 
            // txtmail
            // 
            txtmail.Location = new Point(153, 241);
            txtmail.Name = "txtmail";
            txtmail.Size = new Size(343, 30);
            txtmail.TabIndex = 12;
            txtmail.TextChanged += txtmail_TextChanged;
            // 
            // txtsdt
            // 
            txtsdt.Location = new Point(153, 191);
            txtsdt.Name = "txtsdt";
            txtsdt.Size = new Size(343, 30);
            txtsdt.TabIndex = 11;
            txtsdt.TextChanged += txtsdt_TextChanged;
            // 
            // txtmk
            // 
            txtmk.Location = new Point(153, 142);
            txtmk.Name = "txtmk";
            txtmk.Size = new Size(250, 30);
            txtmk.TabIndex = 10;
            txtmk.UseSystemPasswordChar = true;
            txtmk.TextChanged += txtmk_TextChanged;
            // 
            // txthoten
            // 
            txthoten.Location = new Point(153, 94);
            txthoten.Name = "txthoten";
            txthoten.Size = new Size(343, 30);
            txthoten.TabIndex = 9;
            txthoten.TextChanged += txthoten_TextChanged;
            // 
            // txttendn
            // 
            txttendn.Location = new Point(153, 48);
            txttendn.Name = "txttendn";
            txttendn.Size = new Size(343, 30);
            txttendn.TabIndex = 8;
            txttendn.TextChanged += txttendn_TextChanged;
            // 
            // lbltendn
            // 
            lbltendn.AutoSize = true;
            lbltendn.Location = new Point(6, 51);
            lbltendn.Name = "lbltendn";
            lbltendn.Size = new Size(143, 23);
            lbltendn.TabIndex = 1;
            lbltendn.Text = "Tên Đăng Nhập :";
            // 
            // lblsdt
            // 
            lblsdt.AutoSize = true;
            lblsdt.Location = new Point(6, 194);
            lblsdt.Name = "lblsdt";
            lblsdt.Size = new Size(136, 23);
            lblsdt.TabIndex = 6;
            lblsdt.Text = "Số Điện Thoại  :";
            // 
            // lblmail
            // 
            lblmail.AutoSize = true;
            lblmail.Location = new Point(6, 244);
            lblmail.Name = "lblmail";
            lblmail.Size = new Size(134, 23);
            lblmail.TabIndex = 7;
            lblmail.Text = "Email               :";
            lblmail.Click += lblmail_Click;
            // 
            // lblmk
            // 
            lblmk.AutoSize = true;
            lblmk.Location = new Point(6, 149);
            lblmk.Name = "lblmk";
            lblmk.Size = new Size(137, 23);
            lblmk.TabIndex = 3;
            lblmk.Text = "Mật Khẩu         :";
            lblmk.Click += lblmk_Click;
            // 
            // lblhoten
            // 
            lblhoten.AutoSize = true;
            lblhoten.Location = new Point(6, 101);
            lblhoten.Name = "lblhoten";
            lblhoten.Size = new Size(140, 23);
            lblhoten.TabIndex = 2;
            lblhoten.Text = "Họ Tên              :";
            // 
            // btnthem
            // 
            btnthem.BackColor = Color.LimeGreen;
            btnthem.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnthem.ForeColor = Color.White;
            btnthem.Location = new Point(279, 376);
            btnthem.Name = "btnthem";
            btnthem.Size = new Size(125, 57);
            btnthem.TabIndex = 1;
            btnthem.Text = "➕Thêm";
            btnthem.UseVisualStyleBackColor = false;
            btnthem.Click += btnthem_Click;
            // 
            // btnsua
            // 
            btnsua.BackColor = Color.DarkGoldenrod;
            btnsua.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnsua.ForeColor = Color.White;
            btnsua.Location = new Point(442, 376);
            btnsua.Name = "btnsua";
            btnsua.Size = new Size(125, 57);
            btnsua.TabIndex = 2;
            btnsua.Text = "🛠️ Sửa";
            btnsua.UseVisualStyleBackColor = false;
            btnsua.Click += btnsua_Click;
            // 
            // btnkhoa
            // 
            btnkhoa.BackColor = Color.FromArgb(192, 0, 192);
            btnkhoa.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnkhoa.ForeColor = Color.White;
            btnkhoa.Location = new Point(758, 376);
            btnkhoa.Name = "btnkhoa";
            btnkhoa.Size = new Size(190, 57);
            btnkhoa.TabIndex = 3;
            btnkhoa.Text = "🔐 Khoá/Mở Khoá";
            btnkhoa.UseVisualStyleBackColor = false;
            btnkhoa.Click += btnkhoa_Click;
            // 
            // btnlammoi
            // 
            btnlammoi.BackColor = Color.DarkTurquoise;
            btnlammoi.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnlammoi.ForeColor = Color.White;
            btnlammoi.Location = new Point(967, 376);
            btnlammoi.Name = "btnlammoi";
            btnlammoi.Size = new Size(134, 57);
            btnlammoi.TabIndex = 5;
            btnlammoi.Text = "🔁 Làm mới";
            btnlammoi.UseVisualStyleBackColor = false;
            btnlammoi.Click += btnlammoi_Click;
            // 
            // btntrangchu
            // 
            btntrangchu.BackColor = Color.RoyalBlue;
            btntrangchu.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btntrangchu.ForeColor = Color.White;
            btntrangchu.Location = new Point(27, 376);
            btntrangchu.Name = "btntrangchu";
            btntrangchu.Size = new Size(152, 57);
            btntrangchu.TabIndex = 6;
            btntrangchu.Text = "⌂ Trang Chủ";
            btntrangchu.UseVisualStyleBackColor = false;
            btntrangchu.Click += btntrangchu_Click;
            // 
            // dgvTaiKhoan
            // 
            dgvTaiKhoan.BackgroundColor = SystemColors.ControlLightLight;
            dgvTaiKhoan.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvTaiKhoan.Columns.AddRange(new DataGridViewColumn[] { MaTaiKhoan, TenDangNhap, HoTen, MatKhau, Email, SoDienThoai, VaiTro, TrangThai, NgayTao });
            dgvTaiKhoan.Location = new Point(27, 451);
            dgvTaiKhoan.Name = "dgvTaiKhoan";
            dgvTaiKhoan.RowHeadersWidth = 51;
            dgvTaiKhoan.Size = new Size(1074, 161);
            dgvTaiKhoan.TabIndex = 7;
            dgvTaiKhoan.CellContentClick += dgvTaiKhoan_CellClick;
            // 
            // MaTaiKhoan
            // 
            MaTaiKhoan.DataPropertyName = "MaTaiKhoan";
            MaTaiKhoan.HeaderText = "Mã Tài Khoản";
            MaTaiKhoan.MinimumWidth = 6;
            MaTaiKhoan.Name = "MaTaiKhoan";
            MaTaiKhoan.Width = 125;
            // 
            // TenDangNhap
            // 
            TenDangNhap.DataPropertyName = "TenDangNhap";
            TenDangNhap.HeaderText = "Tên Đăng Nhập";
            TenDangNhap.MinimumWidth = 6;
            TenDangNhap.Name = "TenDangNhap";
            TenDangNhap.Width = 125;
            // 
            // HoTen
            // 
            HoTen.DataPropertyName = "HoTen";
            HoTen.HeaderText = "Họ Tên";
            HoTen.MinimumWidth = 6;
            HoTen.Name = "HoTen";
            HoTen.Width = 125;
            // 
            // MatKhau
            // 
            MatKhau.DataPropertyName = "MatKhau";
            MatKhau.HeaderText = "Mật Khẩu";
            MatKhau.MinimumWidth = 6;
            MatKhau.Name = "MatKhau";
            MatKhau.Width = 125;
            // 
            // Email
            // 
            Email.DataPropertyName = "Email";
            Email.HeaderText = "Email";
            Email.MinimumWidth = 6;
            Email.Name = "Email";
            Email.Width = 125;
            // 
            // SoDienThoai
            // 
            SoDienThoai.DataPropertyName = "SoDienThoai";
            SoDienThoai.HeaderText = "Số Điện Thoại";
            SoDienThoai.MinimumWidth = 6;
            SoDienThoai.Name = "SoDienThoai";
            SoDienThoai.Width = 125;
            // 
            // VaiTro
            // 
            VaiTro.DataPropertyName = "VaiTro";
            VaiTro.HeaderText = "Vai Trò";
            VaiTro.MinimumWidth = 6;
            VaiTro.Name = "VaiTro";
            VaiTro.Width = 125;
            // 
            // TrangThai
            // 
            TrangThai.DataPropertyName = "TrangThai";
            TrangThai.HeaderText = "Trạng Thái";
            TrangThai.MinimumWidth = 6;
            TrangThai.Name = "TrangThai";
            TrangThai.Width = 125;
            // 
            // NgayTao
            // 
            NgayTao.DataPropertyName = "NgayTao";
            NgayTao.HeaderText = "Ngày Tạo";
            NgayTao.MinimumWidth = 6;
            NgayTao.Name = "NgayTao";
            NgayTao.Width = 125;
            // 
            // button1
            // 
            button1.BackColor = Color.Red;
            button1.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button1.ForeColor = Color.White;
            button1.Location = new Point(599, 376);
            button1.Name = "button1";
            button1.Size = new Size(123, 57);
            button1.TabIndex = 8;
            button1.Text = "❌Xoá";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // FrmTaiKhoan
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1134, 624);
            Controls.Add(button1);
            Controls.Add(dgvTaiKhoan);
            Controls.Add(btntrangchu);
            Controls.Add(btnlammoi);
            Controls.Add(btnkhoa);
            Controls.Add(btnsua);
            Controls.Add(btnthem);
            Controls.Add(gbtk);
            Name = "FrmTaiKhoan";
            Text = "FrmTaiKhoan";
            gbtk.ResumeLayout(false);
            gbtths.ResumeLayout(false);
            gbtths.PerformLayout();
            gbthongtinngoai.ResumeLayout(false);
            gbthongtinngoai.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvTaiKhoan).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox gbtk;
        private Label lvltrangthai;
        private Label lblvaitro;
        private Label lblmk;
        private Label lblhoten;
        private Label lbltendn;
        private Label lblma;
        private Label lblmail;
        private Label lblsdt;
        private Label lblngaytao;
        private GroupBox gbthongtinngoai;
        private TextBox txtmail;
        private TextBox txtsdt;
        private TextBox txtmk;
        private TextBox txthoten;
        private TextBox txttendn;
        private GroupBox gbtths;
        private CheckBox checkmk;
        private DateTimePicker dtngaytao;
        private CheckBox checktrangthai;
        private ComboBox cbvaitro;
        private TextBox txtma;
        private Button btnthem;
        private Button btnsua;
        private Button btnkhoa;
        private Button btnlammoi;
        private Button btntrangchu;
        private DataGridView dgvTaiKhoan;
        private DataGridViewTextBoxColumn MaTaiKhoan;
        private DataGridViewTextBoxColumn TenDangNhap;
        private DataGridViewTextBoxColumn HoTen;
        private DataGridViewTextBoxColumn MatKhau;
        private DataGridViewTextBoxColumn Email;
        private DataGridViewTextBoxColumn SoDienThoai;
        private DataGridViewTextBoxColumn VaiTro;
        private DataGridViewTextBoxColumn TrangThai;
        private DataGridViewTextBoxColumn NgayTao;
        private Button button1;
    }
}