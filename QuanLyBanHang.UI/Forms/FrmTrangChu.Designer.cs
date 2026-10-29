namespace QuanLyBanHang.UI
{
    partial class FrmTrangChu
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btnKiemTraSQL = new Button();
            btnQuanLyKhachHang = new Button();
            SuspendLayout();
            // 
            // btnKiemTraSQL
            // 
            btnKiemTraSQL.Location = new Point(260, 160);
            btnKiemTraSQL.Name = "btnKiemTraSQL";
            btnKiemTraSQL.Size = new Size(262, 40);
            btnKiemTraSQL.TabIndex = 0;
            btnKiemTraSQL.Text = "🔍 Kiểm tra kết nối SQL";
            btnKiemTraSQL.UseVisualStyleBackColor = true;
            btnKiemTraSQL.Click += btnKiemTraSQL_Click;
            // 
            // btnQuanLyKhachHang
            // 
            btnQuanLyKhachHang.Location = new Point(260, 220);
            btnQuanLyKhachHang.Name = "btnQuanLyKhachHang";
            btnQuanLyKhachHang.Size = new Size(262, 40);
            btnQuanLyKhachHang.TabIndex = 1;
            btnQuanLyKhachHang.Text = "👤 Quản lý khách hàng";
            btnQuanLyKhachHang.UseVisualStyleBackColor = true;
            btnQuanLyKhachHang.Click += btnQuanLyKhachHang_Click;
            // 
            // FrmTrangChu
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnQuanLyKhachHang);
            Controls.Add(btnKiemTraSQL);
            Name = "FrmTrangChu";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Trang chủ - Quản lý bán hàng";
            ResumeLayout(false);
        }

        #endregion

        private Button btnKiemTraSQL;
        private Button btnQuanLyKhachHang;
    }
}
