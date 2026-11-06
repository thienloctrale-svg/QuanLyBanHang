namespace QuanLyBanHang.UI
{
    partial class FrmDangNhap
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmDangNhap));
            lblheader = new Label();
            lblacc = new Label();
            lblpass = new Label();
            txtacc = new TextBox();
            txtpass = new TextBox();
            checkhienmatkhau = new CheckBox();
            btndangnhap = new Button();
            dn = new ImageList(components);
            btnhuy = new Button();
            huy = new ImageList(components);
            groupBox1 = new GroupBox();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // lblheader
            // 
            lblheader.AutoSize = true;
            lblheader.Font = new Font("Verdana", 34.8F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            lblheader.Location = new Point(91, 56);
            lblheader.Name = "lblheader";
            lblheader.Size = new Size(629, 71);
            lblheader.TabIndex = 0;
            lblheader.Text = "Quản Lý Bán Hàng";
            // 
            // lblacc
            // 
            lblacc.AutoSize = true;
            lblacc.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblacc.Location = new Point(144, 151);
            lblacc.Name = "lblacc";
            lblacc.Size = new Size(190, 31);
            lblacc.TabIndex = 1;
            lblacc.Text = "Tên Đăng Nhập :";
            // 
            // lblpass
            // 
            lblpass.AutoSize = true;
            lblpass.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblpass.Location = new Point(144, 255);
            lblpass.Name = "lblpass";
            lblpass.Size = new Size(130, 31);
            lblpass.TabIndex = 2;
            lblpass.Text = "Mật Khẩu :";
            lblpass.Click += label3_Click;
            // 
            // txtacc
            // 
            txtacc.Location = new Point(144, 196);
            txtacc.Name = "txtacc";
            txtacc.Size = new Size(474, 27);
            txtacc.TabIndex = 3;
            txtacc.TextChanged += txtacc_TextChanged;
            // 
            // txtpass
            // 
            txtpass.Location = new Point(144, 298);
            txtpass.Name = "txtpass";
            txtpass.Size = new Size(323, 27);
            txtpass.TabIndex = 4;
            txtpass.UseSystemPasswordChar = true;
            txtpass.TextChanged += txtpass_TextChanged;
            // 
            // checkhienmatkhau
            // 
            checkhienmatkhau.Location = new Point(495, 287);
            checkhienmatkhau.Name = "checkhienmatkhau";
            checkhienmatkhau.Size = new Size(140, 50);
            checkhienmatkhau.TabIndex = 5;
            checkhienmatkhau.Text = "Hiện Mật Khẩu";
            checkhienmatkhau.UseVisualStyleBackColor = true;
            checkhienmatkhau.CheckedChanged += checkhienmatkhau_CheckedChanged;
            // 
            // btndangnhap
            // 
            btndangnhap.BackColor = Color.FromArgb(0, 192, 0);
            btndangnhap.FlatStyle = FlatStyle.Popup;
            btndangnhap.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btndangnhap.ForeColor = Color.White;
            btndangnhap.ImageAlign = ContentAlignment.MiddleLeft;
            btndangnhap.ImageKey = "dnn.jpg";
            btndangnhap.ImageList = dn;
            btndangnhap.Location = new Point(144, 358);
            btndangnhap.Name = "btndangnhap";
            btndangnhap.Size = new Size(180, 55);
            btndangnhap.TabIndex = 6;
            btndangnhap.Text = "Đăng nhập";
            btndangnhap.TextAlign = ContentAlignment.MiddleRight;
            btndangnhap.UseVisualStyleBackColor = false;
            btndangnhap.Click += button1_Click;
            // 
            // dn
            // 
            dn.ColorDepth = ColorDepth.Depth32Bit;
            dn.ImageStream = (ImageListStreamer)resources.GetObject("dn.ImageStream");
            dn.TransparentColor = Color.Transparent;
            dn.Images.SetKeyName(0, "dnn.jpg");
            // 
            // btnhuy
            // 
            btnhuy.BackColor = Color.Red;
            btnhuy.FlatStyle = FlatStyle.Popup;
            btnhuy.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnhuy.ForeColor = Color.White;
            btnhuy.ImageAlign = ContentAlignment.MiddleLeft;
            btnhuy.ImageKey = "xoa.png";
            btnhuy.ImageList = huy;
            btnhuy.Location = new Point(438, 358);
            btnhuy.Name = "btnhuy";
            btnhuy.Size = new Size(180, 55);
            btnhuy.TabIndex = 7;
            btnhuy.Text = "Huỷ";
            btnhuy.UseVisualStyleBackColor = false;
            btnhuy.Click += btnhuy_Click;
            // 
            // huy
            // 
            huy.ColorDepth = ColorDepth.Depth32Bit;
            huy.ImageStream = (ImageListStreamer)resources.GetObject("huy.ImageStream");
            huy.TransparentColor = Color.Transparent;
            huy.Images.SetKeyName(0, "xoa.png");
            // 
            // groupBox1
            // 
            groupBox1.BackColor = Color.OldLace;
            groupBox1.Controls.Add(lblheader);
            groupBox1.Location = new Point(-4, -13);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(867, 161);
            groupBox1.TabIndex = 8;
            groupBox1.TabStop = false;
            // 
            // FrmDangNhap
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FloralWhite;
            ClientSize = new Size(815, 450);
            Controls.Add(groupBox1);
            Controls.Add(btnhuy);
            Controls.Add(btndangnhap);
            Controls.Add(checkhienmatkhau);
            Controls.Add(txtpass);
            Controls.Add(txtacc);
            Controls.Add(lblpass);
            Controls.Add(lblacc);
            Name = "FrmDangNhap";
            Text = "Đăng Nhập";
            Load += FrmDangNhap_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblheader;
        private Label lblacc;
        private Label lblpass;
        private TextBox txtacc;
        private TextBox txtpass;
        private CheckBox checkhienmatkhau;
        private Button btndangnhap;
        private Button btnhuy;
        private GroupBox groupBox1;
        private ImageList dn;
        private ImageList huy;
    }
}