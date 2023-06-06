namespace Btl_QuanLyNhaSach
{
    partial class tblhoadonban
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
            this.sTenTk = new System.Windows.Forms.TextBox();
            this.dNgayLap = new System.Windows.Forms.DateTimePicker();
            this.dataGridView_HDBan = new System.Windows.Forms.DataGridView();
            this.btnCapNhatHDBan = new System.Windows.Forms.Button();
            this.btnXoaHDBan = new System.Windows.Forms.Button();
            this.btnThemHDBan = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.sMaHDBan = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.sTimKiemMaHDBan = new System.Windows.Forms.TextBox();
            this.comboBox_sTenKH = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_HDBan)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // sTenTk
            // 
            this.sTenTk.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sTenTk.Location = new System.Drawing.Point(144, 110);
            this.sTenTk.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.sTenTk.Name = "sTenTk";
            this.sTenTk.Size = new System.Drawing.Size(260, 26);
            this.sTenTk.TabIndex = 85;
            // 
            // dNgayLap
            // 
            this.dNgayLap.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dNgayLap.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dNgayLap.Location = new System.Drawing.Point(144, 216);
            this.dNgayLap.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dNgayLap.Name = "dNgayLap";
            this.dNgayLap.Size = new System.Drawing.Size(260, 27);
            this.dNgayLap.TabIndex = 84;
            // 
            // dataGridView_HDBan
            // 
            this.dataGridView_HDBan.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_HDBan.Location = new System.Drawing.Point(30, 186);
            this.dataGridView_HDBan.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dataGridView_HDBan.Name = "dataGridView_HDBan";
            this.dataGridView_HDBan.RowHeadersWidth = 62;
            this.dataGridView_HDBan.RowTemplate.Height = 28;
            this.dataGridView_HDBan.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView_HDBan.Size = new System.Drawing.Size(605, 359);
            this.dataGridView_HDBan.TabIndex = 81;
            this.dataGridView_HDBan.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_HDBan_CellClick);
            // 
            // btnCapNhatHDBan
            // 
            this.btnCapNhatHDBan.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCapNhatHDBan.Location = new System.Drawing.Point(751, 439);
            this.btnCapNhatHDBan.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnCapNhatHDBan.Name = "btnCapNhatHDBan";
            this.btnCapNhatHDBan.Size = new System.Drawing.Size(207, 43);
            this.btnCapNhatHDBan.TabIndex = 78;
            this.btnCapNhatHDBan.Text = "Cập Nhật Hóa Đơn Bán";
            this.btnCapNhatHDBan.UseVisualStyleBackColor = true;
            this.btnCapNhatHDBan.Click += new System.EventHandler(this.btnCapNhatHDBan_Click);
            // 
            // btnXoaHDBan
            // 
            this.btnXoaHDBan.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXoaHDBan.Location = new System.Drawing.Point(887, 502);
            this.btnXoaHDBan.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnXoaHDBan.Name = "btnXoaHDBan";
            this.btnXoaHDBan.Size = new System.Drawing.Size(171, 43);
            this.btnXoaHDBan.TabIndex = 77;
            this.btnXoaHDBan.Text = "Xóa Hóa Đơn Bán";
            this.btnXoaHDBan.UseVisualStyleBackColor = true;
            this.btnXoaHDBan.Click += new System.EventHandler(this.btnXoaHDBan_Click);
            // 
            // btnThemHDBan
            // 
            this.btnThemHDBan.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThemHDBan.Location = new System.Drawing.Point(668, 502);
            this.btnThemHDBan.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnThemHDBan.Name = "btnThemHDBan";
            this.btnThemHDBan.Size = new System.Drawing.Size(171, 43);
            this.btnThemHDBan.TabIndex = 76;
            this.btnThemHDBan.Text = "Thêm Hóa Đơn Bán";
            this.btnThemHDBan.UseVisualStyleBackColor = true;
            this.btnThemHDBan.Click += new System.EventHandler(this.btnThemHDBan_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(12, 162);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(121, 17);
            this.label7.TabIndex = 74;
            this.label7.Text = "Tên Khách Hàng:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(25, 111);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(106, 17);
            this.label5.TabIndex = 73;
            this.label5.Text = "Người Lập HĐ:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(29, 219);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(98, 17);
            this.label4.TabIndex = 72;
            this.label4.Text = "Ngày Lập HĐ:";
            // 
            // sMaHDBan
            // 
            this.sMaHDBan.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sMaHDBan.Location = new System.Drawing.Point(144, 54);
            this.sMaHDBan.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.sMaHDBan.Name = "sMaHDBan";
            this.sMaHDBan.Size = new System.Drawing.Size(260, 26);
            this.sMaHDBan.TabIndex = 69;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(44, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 17);
            this.label2.TabIndex = 68;
            this.label2.Text = "Mã HĐ Bán:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(304, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(483, 33);
            this.label1.TabIndex = 67;
            this.label1.Text = "Danh Sách Các Hóa Đơn Bán Sách";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.comboBox_sTenKH);
            this.groupBox1.Controls.Add(this.sMaHDBan);
            this.groupBox1.Controls.Add(this.dNgayLap);
            this.groupBox1.Controls.Add(this.sTenTk);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Location = new System.Drawing.Point(668, 74);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Size = new System.Drawing.Size(422, 350);
            this.groupBox1.TabIndex = 86;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông tin hóa đơn bán";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.sTimKiemMaHDBan);
            this.groupBox2.Location = new System.Drawing.Point(70, 74);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox2.Size = new System.Drawing.Size(531, 80);
            this.groupBox2.TabIndex = 87;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Tìm Kiếm Mã Hóa Đơn";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(57, 37);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(96, 19);
            this.label3.TabIndex = 44;
            this.label3.Text = "Mã HĐ Bán";
            // 
            // sTimKiemMaHDBan
            // 
            this.sTimKiemMaHDBan.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sTimKiemMaHDBan.Location = new System.Drawing.Point(194, 34);
            this.sTimKiemMaHDBan.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.sTimKiemMaHDBan.Name = "sTimKiemMaHDBan";
            this.sTimKiemMaHDBan.Size = new System.Drawing.Size(263, 26);
            this.sTimKiemMaHDBan.TabIndex = 38;
            this.sTimKiemMaHDBan.TextChanged += new System.EventHandler(this.sTimKiemMaHDBan_TextChanged);
            // 
            // comboBox_sTenKH
            // 
            this.comboBox_sTenKH.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox_sTenKH.FormattingEnabled = true;
            this.comboBox_sTenKH.Location = new System.Drawing.Point(144, 160);
            this.comboBox_sTenKH.Name = "comboBox_sTenKH";
            this.comboBox_sTenKH.Size = new System.Drawing.Size(260, 28);
            this.comboBox_sTenKH.TabIndex = 86;
            // 
            // tblhoadonban
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(1109, 583);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dataGridView_HDBan);
            this.Controls.Add(this.btnCapNhatHDBan);
            this.Controls.Add(this.btnXoaHDBan);
            this.Controls.Add(this.btnThemHDBan);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "tblhoadonban";
            this.Text = "Hóa Đơn Bán";
            this.Load += new System.EventHandler(this.tblhoadonban_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_HDBan)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox sTenTk;
        private System.Windows.Forms.DateTimePicker dNgayLap;
        private System.Windows.Forms.DataGridView dataGridView_HDBan;
        private System.Windows.Forms.Button btnCapNhatHDBan;
        private System.Windows.Forms.Button btnXoaHDBan;
        private System.Windows.Forms.Button btnThemHDBan;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox sMaHDBan;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox sTimKiemMaHDBan;
        private System.Windows.Forms.ComboBox comboBox_sTenKH;
    }
}