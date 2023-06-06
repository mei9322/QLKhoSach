namespace Btl_QuanLyNhaSach
{
    partial class tbldanhsachhoadonnhap
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.sMaHDBan = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.dataGridView_DanhSachHDNhap = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_DanhSachHDNhap)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.sMaHDBan);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(265, 95);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Size = new System.Drawing.Size(506, 99);
            this.groupBox1.TabIndex = 82;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Tìm kiếm hóa đơn theo mã hóa đơn ";
            // 
            // sMaHDBan
            // 
            this.sMaHDBan.Location = new System.Drawing.Point(198, 38);
            this.sMaHDBan.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.sMaHDBan.Name = "sMaHDBan";
            this.sMaHDBan.Size = new System.Drawing.Size(257, 25);
            this.sMaHDBan.TabIndex = 3;
            this.sMaHDBan.TextChanged += new System.EventHandler(this.sMaHDBan_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(61, 41);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(132, 17);
            this.label5.TabIndex = 2;
            this.label5.Text = "Mã Hóa Đơn Bán:  ";
            // 
            // dataGridView_DanhSachHDNhap
            // 
            this.dataGridView_DanhSachHDNhap.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_DanhSachHDNhap.Location = new System.Drawing.Point(134, 253);
            this.dataGridView_DanhSachHDNhap.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dataGridView_DanhSachHDNhap.Name = "dataGridView_DanhSachHDNhap";
            this.dataGridView_DanhSachHDNhap.RowHeadersWidth = 62;
            this.dataGridView_DanhSachHDNhap.RowTemplate.Height = 28;
            this.dataGridView_DanhSachHDNhap.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView_DanhSachHDNhap.Size = new System.Drawing.Size(760, 275);
            this.dataGridView_DanhSachHDNhap.TabIndex = 81;
            this.dataGridView_DanhSachHDNhap.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_DanhSachHDNhap_CellClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(312, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(441, 33);
            this.label1.TabIndex = 80;
            this.label1.Text = "Danh Sách Hóa Đơn Nhập Sách";
            // 
            // tbldanhsachhoadonnhap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(1109, 583);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dataGridView_DanhSachHDNhap);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "tbldanhsachhoadonnhap";
            this.Text = "Danh Sách Hóa Đơn Nhập";
            this.Load += new System.EventHandler(this.tbldanhsachhoadonnhap_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_DanhSachHDNhap)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox sMaHDBan;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridView dataGridView_DanhSachHDNhap;
        private System.Windows.Forms.Label label1;
    }
}