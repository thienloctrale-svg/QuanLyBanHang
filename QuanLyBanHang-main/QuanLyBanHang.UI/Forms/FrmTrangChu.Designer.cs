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
            btnBanHang = new Button();
            SuspendLayout();
            // 
            // btnKiemTraSQL
            // 
            btnKiemTraSQL.Location = new Point(260, 186);
            btnKiemTraSQL.Name = "btnKiemTraSQL";
            btnKiemTraSQL.Size = new Size(262, 29);
            btnKiemTraSQL.TabIndex = 0;
            btnKiemTraSQL.Text = "Kiểm tra kết nối SQL";
            btnKiemTraSQL.UseVisualStyleBackColor = true;
            btnKiemTraSQL.Click += btnKiemTraSQL_Click;
            // 
            // btnBanHang
            // 
            btnBanHang.Location = new Point(312, 293);
            btnBanHang.Name = "btnBanHang";
            btnBanHang.Size = new Size(94, 29);
            btnBanHang.TabIndex = 1;
            btnBanHang.Text = "Bán hàng";
            btnBanHang.UseVisualStyleBackColor = true;
            btnBanHang.Click += btnBanHang_Click;
            // 
            // FrmTrangChu
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnBanHang);
            Controls.Add(btnKiemTraSQL);
            Name = "FrmTrangChu";
            Text = "FrmTrangChu";
            ResumeLayout(false);
        }

        #endregion

        private Button btnKiemTraSQL;
        private Button btnBanHang;
    }
}
