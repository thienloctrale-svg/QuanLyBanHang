namespace GD_Quản_Lý_Sản_Phẩm
{
    partial class FrmSanPham
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
            textBox1 = new TextBox();
            label1 = new Label();
            label2 = new Label();
            textBox2 = new TextBox();
            groupBoxThongTin = new GroupBox();
            txtTimKiem = new TextBox();
            comboBox1 = new ComboBox();
            label7 = new Label();
            textBox6 = new TextBox();
            label6 = new Label();
            textBox5 = new TextBox();
            label5 = new Label();
            textBox4 = new TextBox();
            label4 = new Label();
            textBox3 = new TextBox();
            label3 = new Label();
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            button4 = new Button();
            button5 = new Button();
            dataGridView1 = new DataGridView();
            groupBoxThongTin.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // textBox1
            // 
            textBox1.Location = new Point(148, 38);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(125, 27);
            textBox1.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(26, 45);
            label1.Name = "label1";
            label1.Size = new Size(50, 20);
            label1.TabIndex = 1;
            label1.Text = "Mã SP";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(26, 94);
            label2.Name = "label2";
            label2.Size = new Size(52, 20);
            label2.TabIndex = 2;
            label2.Text = "Tên SP";
            // 
            // textBox2
            // 
            textBox2.Location = new Point(148, 87);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(125, 27);
            textBox2.TabIndex = 3;
            // 
            // groupBoxThongTin
            // 
            groupBoxThongTin.Controls.Add(dataGridView1);
            groupBoxThongTin.Controls.Add(button5);
            groupBoxThongTin.Controls.Add(button4);
            groupBoxThongTin.Controls.Add(button3);
            groupBoxThongTin.Controls.Add(button2);
            groupBoxThongTin.Controls.Add(button1);
            groupBoxThongTin.Controls.Add(txtTimKiem);
            groupBoxThongTin.Controls.Add(comboBox1);
            groupBoxThongTin.Controls.Add(label7);
            groupBoxThongTin.Controls.Add(textBox6);
            groupBoxThongTin.Controls.Add(label6);
            groupBoxThongTin.Controls.Add(textBox5);
            groupBoxThongTin.Controls.Add(label5);
            groupBoxThongTin.Controls.Add(textBox4);
            groupBoxThongTin.Controls.Add(label4);
            groupBoxThongTin.Controls.Add(textBox3);
            groupBoxThongTin.Controls.Add(label3);
            groupBoxThongTin.Controls.Add(textBox1);
            groupBoxThongTin.Controls.Add(label2);
            groupBoxThongTin.Controls.Add(textBox2);
            groupBoxThongTin.Controls.Add(label1);
            groupBoxThongTin.Location = new Point(12, 12);
            groupBoxThongTin.Name = "groupBoxThongTin";
            groupBoxThongTin.Size = new Size(938, 518);
            groupBoxThongTin.TabIndex = 4;
            groupBoxThongTin.TabStop = false;
            groupBoxThongTin.Text = "Thông tin sản phẩm";
            // 
            // txtTimKiem
            // 
            txtTimKiem.ForeColor = SystemColors.GrayText;
            txtTimKiem.Location = new Point(672, 127);
            txtTimKiem.Name = "txtTimKiem";
            txtTimKiem.Size = new Size(238, 27);
            txtTimKiem.TabIndex = 14;
            txtTimKiem.Text = "Tìm kiếm theo mã hoặc tên";
            txtTimKiem.Enter += txtTimKiem_Enter;
            txtTimKiem.Leave += txtTimKiem_Leave;
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(672, 70);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(239, 28);
            comboBox1.TabIndex = 13;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(672, 34);
            label7.Name = "label7";
            label7.Size = new Size(76, 20);
            label7.TabIndex = 12;
            label7.Text = "Danh mục";
            // 
            // textBox6
            // 
            textBox6.Location = new Point(438, 127);
            textBox6.Name = "textBox6";
            textBox6.Size = new Size(125, 27);
            textBox6.TabIndex = 11;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(326, 134);
            label6.Name = "label6";
            label6.Size = new Size(95, 20);
            label6.TabIndex = 10;
            label6.Text = "Số lượng tồn";
            // 
            // textBox5
            // 
            textBox5.Location = new Point(438, 80);
            textBox5.Name = "textBox5";
            textBox5.Size = new Size(125, 27);
            textBox5.TabIndex = 9;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(344, 87);
            label5.Name = "label5";
            label5.Size = new Size(60, 20);
            label5.TabIndex = 8;
            label5.Text = "Giá bán";
            // 
            // textBox4
            // 
            textBox4.Location = new Point(438, 31);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(125, 27);
            textBox4.TabIndex = 7;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(344, 38);
            label4.Name = "label4";
            label4.Size = new Size(68, 20);
            label4.TabIndex = 6;
            label4.Text = "Giá nhập";
            // 
            // textBox3
            // 
            textBox3.Location = new Point(148, 134);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(125, 27);
            textBox3.TabIndex = 5;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(26, 137);
            label3.Name = "label3";
            label3.Size = new Size(81, 20);
            label3.TabIndex = 4;
            label3.Text = "Đơn vị tính";
            // 
            // button1
            // 
            button1.Location = new Point(26, 216);
            button1.Name = "button1";
            button1.Size = new Size(95, 34);
            button1.TabIndex = 15;
            button1.Text = "Thêm";
            button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            button2.Location = new Point(191, 217);
            button2.Name = "button2";
            button2.Size = new Size(95, 33);
            button2.TabIndex = 16;
            button2.Text = "Sửa ";
            button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            button3.Location = new Point(354, 221);
            button3.Name = "button3";
            button3.Size = new Size(95, 35);
            button3.TabIndex = 17;
            button3.Text = "Xóa";
            button3.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            button4.Location = new Point(540, 224);
            button4.Name = "button4";
            button4.Size = new Size(94, 29);
            button4.TabIndex = 18;
            button4.Text = "Làm mới";
            button4.UseVisualStyleBackColor = true;
            // 
            // button5
            // 
            button5.Location = new Point(700, 226);
            button5.Name = "button5";
            button5.Size = new Size(94, 29);
            button5.TabIndex = 19;
            button5.Text = "Tìm kiếm";
            button5.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(26, 286);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(479, 176);
            dataGridView1.TabIndex = 20;
            // 
            // FrmSanPham
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1155, 598);
            Controls.Add(groupBoxThongTin);
            Name = "FrmSanPham";
            Text = "Quản Lý Sản Phẩm";
            groupBoxThongTin.ResumeLayout(false);
            groupBoxThongTin.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TextBox textBox1;
        private Label label1;
        private Label label2;
        private TextBox textBox2;
        private GroupBox groupBoxThongTin;
        private Label label3;
        private Label label6;
        private TextBox textBox5;
        private Label label5;
        private TextBox textBox4;
        private Label label4;
        private TextBox textBox3;
        private ComboBox comboBox1;
        private Label label7;
        private TextBox textBox6;
        private TextBox txtTimKiem;
        private Button button4;
        private Button button3;
        private Button button2;
        private Button button1;
        private DataGridView dataGridView1;
        private Button button5;
    }
}
