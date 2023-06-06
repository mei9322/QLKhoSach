namespace Btl_QuanLyNhaSach
{
    partial class tbldanhsachhoadonban
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
            this.dataGridView_DanhSachHDBan = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_DanhSachHDBan)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.sMaHDBan);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Location = new System.Drawing.Point(319, 114);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Size = new System.Drawing.Size(506, 99);
            this.groupBox1.TabIndex = 78;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Tìm kiếm hóa đơn theo mã hóa đơn ";
            // 
            // sMaHDBan
            // 
            this.sMaHDBan.Location = new System.Drawing.Point(198, 38);
            this.sMaHDBan.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.sMaHDBan.Name = "sMaHDBan";
            this.sMaHDBan.Size = new System.Drawing.Size(257, 22);
            this.sMaHDBan.TabIndex = 3;
            this.sMaHDBan.TextChanged += new System.EventHandler(this.sMaHDBan_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(61, 41);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(118, 16);
            this.label5.TabIndex = 2;
            this.label5.Text = "Mã Hóa Đơn Bán:  ";
            // 
            // dataGridView_DanhSachHDBan
            // 
            this.dataGridView_DanhSachHDBan.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_DanhSachHDBan.Location = new System.Drawing.Point(78, 259);
            this.dataGridView_DanhSachHDBan.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dataGridView_DanhSachHDBan.Name = "dataGridView_DanhSachHDBan";
            this.dataGridView_DanhSachHDBan.RowHeadersWidth = 62;
            this.dataGridView_DanhSachHDBan.RowTemplate.Height = 28;
            this.dataGridView_DanhSachHDBan.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView_DanhSachHDBan.Size = new System.Drawing.Size(892, 275);
            this.dataGridView_DanhSachHDBan.TabIndex = 77;
            this.dataGridView_DanhSachHDBan.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_DanhSachHDBan_CellClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(377, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(363, 29);
            this.label1.TabIndex = 74;
            this.label1.Text = "Danh Sách Hóa Đơn Bán Sách";
            // 
            // tbldanhsachhoadonban
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(1109, 583);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dataGridView_DanhSachHDBan);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "tbldanhsachhoadonban";
            this.Text = "Danh Sách Hóa Đơn Bán";
            this.Load += new System.EventHandler(this.danhsachhoadonban_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_DanhSachHDBan)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dataGridView_DanhSachHDBan;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox sMaHDBan;
        private System.Windows.Forms.Label label5;
    }
}