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
            lblheader = new Label();
            lblacc = new Label();
            lblpass = new Label();
            txtacc = new TextBox();
            txtpass = new TextBox();
            checkhienmatkhau = new CheckBox();
            btndangnhap = new Button();
            btnhuy = new Button();
            SuspendLayout();
            // 
            // lblheader
            // 
            lblheader.AutoSize = true;
            lblheader.Font = new Font("SimSun", 34.8F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            lblheader.Location = new Point(111, 51);
            lblheader.Name = "lblheader";
            lblheader.Size = new Size(614, 58);
            lblheader.TabIndex = 0;
            lblheader.Text = "Chào Mừng Bạn Đã Đến";
            // 
            // lblacc
            // 
            lblacc.AutoSize = true;
            lblacc.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblacc.Location = new Point(76, 141);
            lblacc.Name = "lblacc";
            lblacc.Size = new Size(153, 25);
            lblacc.TabIndex = 1;
            lblacc.Text = "Tên Đăng Nhập :";
            // 
            // lblpass
            // 
            lblpass.AutoSize = true;
            lblpass.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblpass.Location = new Point(76, 198);
            lblpass.Name = "lblpass";
            lblpass.Size = new Size(150, 25);
            lblpass.TabIndex = 2;
            lblpass.Text = "Mật Khẩu          :";
            lblpass.Click += label3_Click;
            // 
            // txtacc
            // 
            txtacc.Location = new Point(262, 142);
            txtacc.Name = "txtacc";
            txtacc.Size = new Size(502, 27);
            txtacc.TabIndex = 3;
            txtacc.TextChanged += txtacc_TextChanged;
            // 
            // txtpass
            // 
            txtpass.Location = new Point(262, 199);
            txtpass.Name = "txtpass";
            txtpass.Size = new Size(323, 27);
            txtpass.TabIndex = 4;
            txtpass.UseSystemPasswordChar = true;
            txtpass.TextChanged += txtpass_TextChanged;
            // 
            // checkhienmatkhau
            // 
            checkhienmatkhau.Location = new Point(624, 188);
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
            btndangnhap.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btndangnhap.ForeColor = Color.White;
            btndangnhap.Location = new Point(206, 296);
            btndangnhap.Name = "btndangnhap";
            btndangnhap.Size = new Size(145, 55);
            btndangnhap.TabIndex = 6;
            btndangnhap.Text = "Đăng nhập";
            btndangnhap.UseVisualStyleBackColor = false;
            btndangnhap.Click += button1_Click;
            // 
            // btnhuy
            // 
            btnhuy.BackColor = Color.Red;
            btnhuy.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnhuy.ForeColor = Color.White;
            btnhuy.Location = new Point(506, 296);
            btnhuy.Name = "btnhuy";
            btnhuy.Size = new Size(145, 55);
            btnhuy.TabIndex = 7;
            btnhuy.Text = "Huỷ";
            btnhuy.UseVisualStyleBackColor = false;
            btnhuy.Click += btnhuy_Click;
            // 
            // FrmDangNhap
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(856, 450);
            Controls.Add(btnhuy);
            Controls.Add(btndangnhap);
            Controls.Add(checkhienmatkhau);
            Controls.Add(txtpass);
            Controls.Add(txtacc);
            Controls.Add(lblpass);
            Controls.Add(lblacc);
            Controls.Add(lblheader);
            Name = "FrmDangNhap";
            Text = "FrmDangNhap";
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
    }
}