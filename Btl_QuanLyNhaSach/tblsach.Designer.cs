namespace Btl_QuanLyNhaSach
{
    partial class tblsach
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
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.sTenNXB = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnCapNhatSach = new System.Windows.Forms.Button();
            this.btnXoaSach = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dataGridView_Sach = new System.Windows.Forms.DataGridView();
            this.sMaSach = new System.Windows.Forms.TextBox();
            this.fGiaSach = new System.Windows.Forms.TextBox();
            this.iSoLuong = new System.Windows.Forms.TextBox();
            this.sTenSach = new System.Windows.Forms.TextBox();
            this.sTheLoai = new System.Windows.Forms.TextBox();
            this.btnThemSach = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textBox_TimKiemSach = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Sach)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // comboBox1
            // 
            this.comboBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(124, 120);
            this.comboBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(235, 28);
            this.comboBox1.TabIndex = 0;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // sTenNXB
            // 
            this.sTenNXB.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sTenNXB.Location = new System.Drawing.Point(124, 175);
            this.sTenNXB.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.sTenNXB.Name = "sTenNXB";
            this.sTenNXB.Size = new System.Drawing.Size(235, 26);
            this.sTenNXB.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(376, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(363, 33);
            this.label1.TabIndex = 2;
            this.label1.Text = "Danh Sách Các Loại Sách";
            // 
            // btnCapNhatSach
            // 
            this.btnCapNhatSach.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btnCapNhatSach.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Fuchsia;
            this.btnCapNhatSach.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Fuchsia;
            this.btnCapNhatSach.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCapNhatSach.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCapNhatSach.Location = new System.Drawing.Point(20, 486);
            this.btnCapNhatSach.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnCapNhatSach.Name = "btnCapNhatSach";
            this.btnCapNhatSach.Size = new System.Drawing.Size(171, 43);
            this.btnCapNhatSach.TabIndex = 18;
            this.btnCapNhatSach.Text = "Cập Nhật Sách";
            this.btnCapNhatSach.UseVisualStyleBackColor = true;
            this.btnCapNhatSach.Click += new System.EventHandler(this.btnCapNhatSach_Click);
            // 
            // btnXoaSach
            // 
            this.btnXoaSach.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btnXoaSach.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Fuchsia;
            this.btnXoaSach.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Fuchsia;
            this.btnXoaSach.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXoaSach.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXoaSach.Location = new System.Drawing.Point(20, 319);
            this.btnXoaSach.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnXoaSach.Name = "btnXoaSach";
            this.btnXoaSach.Size = new System.Drawing.Size(171, 43);
            this.btnXoaSach.TabIndex = 17;
            this.btnXoaSach.Text = "Xóa Sách";
            this.btnXoaSach.UseVisualStyleBackColor = true;
            this.btnXoaSach.Click += new System.EventHandler(this.btnXoaSach_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(36, 126);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(68, 18);
            this.label8.TabIndex = 23;
            this.label8.Text = "Mã NXB:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(803, 125);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(73, 18);
            this.label6.TabIndex = 22;
            this.label6.Text = "Giá Sách:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(28, 178);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(72, 18);
            this.label5.TabIndex = 21;
            this.label5.Text = "Tên NXB:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(32, 72);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 18);
            this.label2.TabIndex = 20;
            this.label2.Text = "Mã Sách:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(800, 70);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(76, 18);
            this.label7.TabIndex = 26;
            this.label7.Text = "Số Lượng:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(399, 121);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(69, 18);
            this.label4.TabIndex = 25;
            this.label4.Text = "Thể Loại:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(393, 70);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 18);
            this.label3.TabIndex = 24;
            this.label3.Text = "Tên Sách:";
            // 
            // dataGridView_Sach
            // 
            this.dataGridView_Sach.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_Sach.Location = new System.Drawing.Point(208, 304);
            this.dataGridView_Sach.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dataGridView_Sach.Name = "dataGridView_Sach";
            this.dataGridView_Sach.RowHeadersWidth = 62;
            this.dataGridView_Sach.RowTemplate.Height = 28;
            this.dataGridView_Sach.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView_Sach.Size = new System.Drawing.Size(889, 254);
            this.dataGridView_Sach.TabIndex = 29;
            this.dataGridView_Sach.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_Sach_CellClick);
            // 
            // sMaSach
            // 
            this.sMaSach.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sMaSach.Location = new System.Drawing.Point(124, 71);
            this.sMaSach.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.sMaSach.Name = "sMaSach";
            this.sMaSach.Size = new System.Drawing.Size(235, 26);
            this.sMaSach.TabIndex = 30;
            // 
            // fGiaSach
            // 
            this.fGiaSach.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fGiaSach.Location = new System.Drawing.Point(889, 120);
            this.fGiaSach.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.fGiaSach.Name = "fGiaSach";
            this.fGiaSach.Size = new System.Drawing.Size(201, 26);
            this.fGiaSach.TabIndex = 31;
            // 
            // iSoLuong
            // 
            this.iSoLuong.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.iSoLuong.Location = new System.Drawing.Point(887, 70);
            this.iSoLuong.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.iSoLuong.Name = "iSoLuong";
            this.iSoLuong.Size = new System.Drawing.Size(203, 26);
            this.iSoLuong.TabIndex = 32;
            this.iSoLuong.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.iSoLuong_KeyPress);
            // 
            // sTenSach
            // 
            this.sTenSach.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sTenSach.Location = new System.Drawing.Point(481, 70);
            this.sTenSach.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.sTenSach.Name = "sTenSach";
            this.sTenSach.Size = new System.Drawing.Size(288, 26);
            this.sTenSach.TabIndex = 33;
            // 
            // sTheLoai
            // 
            this.sTheLoai.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sTheLoai.Location = new System.Drawing.Point(481, 120);
            this.sTheLoai.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.sTheLoai.Name = "sTheLoai";
            this.sTheLoai.Size = new System.Drawing.Size(288, 26);
            this.sTheLoai.TabIndex = 34;
            // 
            // btnThemSach
            // 
            this.btnThemSach.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btnThemSach.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Fuchsia;
            this.btnThemSach.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Fuchsia;
            this.btnThemSach.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThemSach.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThemSach.Location = new System.Drawing.Point(20, 404);
            this.btnThemSach.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnThemSach.Name = "btnThemSach";
            this.btnThemSach.Size = new System.Drawing.Size(171, 43);
            this.btnThemSach.TabIndex = 35;
            this.btnThemSach.Text = "Thêm Sách";
            this.btnThemSach.UseVisualStyleBackColor = true;
            this.btnThemSach.Click += new System.EventHandler(this.btnThemSach_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textBox_TimKiemSach);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Location = new System.Drawing.Point(403, 186);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Size = new System.Drawing.Size(687, 80);
            this.groupBox1.TabIndex = 36;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Tìm Kiếm";
            // 
            // textBox_TimKiemSach
            // 
            this.textBox_TimKiemSach.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_TimKiemSach.Location = new System.Drawing.Point(249, 32);
            this.textBox_TimKiemSach.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBox_TimKiemSach.Name = "textBox_TimKiemSach";
            this.textBox_TimKiemSach.Size = new System.Drawing.Size(288, 26);
            this.textBox_TimKiemSach.TabIndex = 35;
            this.textBox_TimKiemSach.TextChanged += new System.EventHandler(this.textBox_TimKiemSach_TextChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(138, 33);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(75, 18);
            this.label9.TabIndex = 34;
            this.label9.Text = "Tên Sách:";
            // 
            // tblsach
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SteelBlue;
            this.ClientSize = new System.Drawing.Size(1109, 583);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnThemSach);
            this.Controls.Add(this.sTheLoai);
            this.Controls.Add(this.sTenSach);
            this.Controls.Add(this.iSoLuong);
            this.Controls.Add(this.fGiaSach);
            this.Controls.Add(this.sMaSach);
            this.Controls.Add(this.dataGridView_Sach);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnCapNhatSach);
            this.Controls.Add(this.btnXoaSach);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.sTenNXB);
            this.Controls.Add(this.comboBox1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "tblsach";
            this.Text = "Sách";
            this.Load += new System.EventHandler(this.tblsach_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Sach)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.TextBox sTenNXB;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnCapNhatSach;
        private System.Windows.Forms.Button btnXoaSach;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dataGridView_Sach;
        private System.Windows.Forms.TextBox sMaSach;
        private System.Windows.Forms.TextBox fGiaSach;
        private System.Windows.Forms.TextBox iSoLuong;
        private System.Windows.Forms.TextBox sTenSach;
        private System.Windows.Forms.TextBox sTheLoai;
        private System.Windows.Forms.Button btnThemSach;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox textBox_TimKiemSach;
        private System.Windows.Forms.Label label9;
    }
}