namespace Btl_QuanLyNhaSach
{
    partial class tbltunghoadonnhap
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
            this.label2 = new System.Windows.Forms.Label();
            this.sMaHDNhap = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridView_sanpham = new System.Windows.Forms.DataGridView();
            this.sTenTK = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.dNgayNhap = new System.Windows.Forms.DateTimePicker();
            this.btnInHoaDon = new System.Windows.Forms.Button();
            this.fTongTien = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_sanpham)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(50, 148);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 16);
            this.label2.TabIndex = 10;
            this.label2.Text = "Tổng Tiền:";
            // 
            // sMaHDNhap
            // 
            this.sMaHDNhap.Location = new System.Drawing.Point(124, 83);
            this.sMaHDNhap.Margin = new System.Windows.Forms.Padding(2);
            this.sMaHDNhap.Name = "sMaHDNhap";
            this.sMaHDNhap.Size = new System.Drawing.Size(224, 23);
            this.sMaHDNhap.TabIndex = 9;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(37, 86);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 16);
            this.label1.TabIndex = 8;
            this.label1.Text = "Mã Hóa Đơn:";
            // 
            // dataGridView_sanpham
            // 
            this.dataGridView_sanpham.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_sanpham.Location = new System.Drawing.Point(85, 193);
            this.dataGridView_sanpham.Name = "dataGridView_sanpham";
            this.dataGridView_sanpham.RowHeadersWidth = 62;
            this.dataGridView_sanpham.RowTemplate.Height = 28;
            this.dataGridView_sanpham.Size = new System.Drawing.Size(573, 198);
            this.dataGridView_sanpham.TabIndex = 7;
            // 
            // sTenTK
            // 
            this.sTenTK.Location = new System.Drawing.Point(531, 84);
            this.sTenTK.Margin = new System.Windows.Forms.Padding(2);
            this.sTenTK.Name = "sTenTK";
            this.sTenTK.Size = new System.Drawing.Size(224, 23);
            this.sTenTK.TabIndex = 13;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(393, 87);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(124, 16);
            this.label3.TabIndex = 12;
            this.label3.Text = "Người Lập Hóa Đơn:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(393, 148);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(119, 16);
            this.label4.TabIndex = 14;
            this.label4.Text = "Ngày Lập Hóa Đơn:";
            // 
            // dNgayNhap
            // 
            this.dNgayNhap.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dNgayNhap.Location = new System.Drawing.Point(531, 148);
            this.dNgayNhap.Name = "dNgayNhap";
            this.dNgayNhap.Size = new System.Drawing.Size(223, 23);
            this.dNgayNhap.TabIndex = 15;
            // 
            // btnInHoaDon
            // 
            this.btnInHoaDon.BackColor = System.Drawing.Color.RosyBrown;
            this.btnInHoaDon.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInHoaDon.Location = new System.Drawing.Point(364, 11);
            this.btnInHoaDon.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnInHoaDon.Name = "btnInHoaDon";
            this.btnInHoaDon.Size = new System.Drawing.Size(148, 50);
            this.btnInHoaDon.TabIndex = 86;
            this.btnInHoaDon.Text = "In Hóa Đơn";
            this.btnInHoaDon.UseVisualStyleBackColor = false;
            this.btnInHoaDon.Click += new System.EventHandler(this.btnInHoaDon_Click);
            // 
            // fTongTien
            // 
            this.fTongTien.AutoSize = true;
            this.fTongTien.Location = new System.Drawing.Point(121, 148);
            this.fTongTien.Name = "fTongTien";
            this.fTongTien.Size = new System.Drawing.Size(0, 16);
            this.fTongTien.TabIndex = 87;
            // 
            // tbltunghoadonnhap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(782, 403);
            this.Controls.Add(this.fTongTien);
            this.Controls.Add(this.btnInHoaDon);
            this.Controls.Add(this.dNgayNhap);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.sTenTK);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.sMaHDNhap);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView_sanpham);
            this.Font = new System.Drawing.Font("Times New Roman", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MaximumSize = new System.Drawing.Size(800, 450);
            this.Name = "tbltunghoadonnhap";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Chi Tiết Từng Hóa Đơn Nhập";
            this.Load += new System.EventHandler(this.tbltunghoadonnhap_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_sanpham)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox sMaHDNhap;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridView_sanpham;
        private System.Windows.Forms.TextBox sTenTK;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dNgayNhap;
        private System.Windows.Forms.Button btnInHoaDon;
        private System.Windows.Forms.Label fTongTien;
    }
}