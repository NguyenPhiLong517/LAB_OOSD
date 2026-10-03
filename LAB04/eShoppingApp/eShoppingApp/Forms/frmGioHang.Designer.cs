namespace eShopping.Forms
{
    partial class frmGioHang
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.lblTitle = new System.Windows.Forms.Label();
            this.dgvGioHang = new System.Windows.Forms.DataGridView();
            this.pnlBottom = new System.Windows.Forms.Panel();
            this.btnTiepTucMua = new System.Windows.Forms.Button();
            this.btnTienHanhDatHang = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnCapNhat = new System.Windows.Forms.Button();
            this.lblTongTien = new System.Windows.Forms.Label();
            this.lblTongTienLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGioHang)).BeginInit();
            this.pnlBottom.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.lblTitle.Location = new System.Drawing.Point(0, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Padding = new System.Windows.Forms.Padding(15, 10, 0, 0);
            this.lblTitle.Size = new System.Drawing.Size(900, 45);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "GIỎ HÀNG CỦA BẠN";
            // 
            // dgvGioHang
            // 
            this.dgvGioHang.AllowUserToAddRows = false;
            this.dgvGioHang.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvGioHang.BackgroundColor = System.Drawing.Color.White;
            this.dgvGioHang.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvGioHang.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvGioHang.Location = new System.Drawing.Point(0, 45);
            this.dgvGioHang.MultiSelect = false;
            this.dgvGioHang.Name = "dgvGioHang";
            this.dgvGioHang.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvGioHang.Size = new System.Drawing.Size(900, 385);
            this.dgvGioHang.TabIndex = 1;
            // 
            // pnlBottom
            // 
            this.pnlBottom.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pnlBottom.Controls.Add(this.btnTiepTucMua);
            this.pnlBottom.Controls.Add(this.btnTienHanhDatHang);
            this.pnlBottom.Controls.Add(this.btnXoa);
            this.pnlBottom.Controls.Add(this.btnCapNhat);
            this.pnlBottom.Controls.Add(this.lblTongTien);
            this.pnlBottom.Controls.Add(this.lblTongTienLabel);
            this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBottom.Location = new System.Drawing.Point(0, 430);
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.Size = new System.Drawing.Size(900, 90);
            this.pnlBottom.TabIndex = 2;
            // 
            // btnTiepTucMua
            // 
            this.btnTiepTucMua.BackColor = System.Drawing.Color.LightGray;
            this.btnTiepTucMua.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTiepTucMua.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.btnTiepTucMua.Location = new System.Drawing.Point(20, 30);
            this.btnTiepTucMua.Name = "btnTiepTucMua";
            this.btnTiepTucMua.Size = new System.Drawing.Size(150, 38);
            this.btnTiepTucMua.TabIndex = 5;
            this.btnTiepTucMua.Text = "<< Mua Thêm";
            this.btnTiepTucMua.UseVisualStyleBackColor = false;
            this.btnTiepTucMua.Click += new System.EventHandler(this.btnTiepTucMua_Click);
            // 
            // btnTienHanhDatHang
            // 
            this.btnTienHanhDatHang.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnTienHanhDatHang.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(174)))), ((int)(((byte)(96)))));
            this.btnTienHanhDatHang.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTienHanhDatHang.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnTienHanhDatHang.ForeColor = System.Drawing.Color.White;
            this.btnTienHanhDatHang.Location = new System.Drawing.Point(680, 25);
            this.btnTienHanhDatHang.Name = "btnTienHanhDatHang";
            this.btnTienHanhDatHang.Size = new System.Drawing.Size(200, 45);
            this.btnTienHanhDatHang.TabIndex = 4;
            this.btnTienHanhDatHang.Text = "TIẾN HÀNH ĐẶT HÀNG >>";
            this.btnTienHanhDatHang.UseVisualStyleBackColor = false;
            this.btnTienHanhDatHang.Click += new System.EventHandler(this.btnTienHanhDatHang_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
            this.btnXoa.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXoa.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnXoa.ForeColor = System.Drawing.Color.White;
            this.btnXoa.Location = new System.Drawing.Point(300, 30);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(100, 38);
            this.btnXoa.TabIndex = 3;
            this.btnXoa.Text = "Xóa Món";
            this.btnXoa.UseVisualStyleBackColor = false;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnCapNhat
            // 
            this.btnCapNhat.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.btnCapNhat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCapNhat.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnCapNhat.ForeColor = System.Drawing.Color.White;
            this.btnCapNhat.Location = new System.Drawing.Point(180, 30);
            this.btnCapNhat.Name = "btnCapNhat";
            this.btnCapNhat.Size = new System.Drawing.Size(110, 38);
            this.btnCapNhat.TabIndex = 2;
            this.btnCapNhat.Text = "Cập Nhật SL";
            this.btnCapNhat.UseVisualStyleBackColor = false;
            this.btnCapNhat.Click += new System.EventHandler(this.btnCapNhat_Click);
            // 
            // lblTongTien
            // 
            this.lblTongTien.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTongTien.AutoSize = true;
            this.lblTongTien.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblTongTien.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(57)))), ((int)(((byte)(43)))));
            this.lblTongTien.Location = new System.Drawing.Point(520, 38);
            this.lblTongTien.Name = "lblTongTien";
            this.lblTongTien.Size = new System.Drawing.Size(46, 21);
            this.lblTongTien.TabIndex = 1;
            this.lblTongTien.Text = "0 đ";
            // 
            // lblTongTienLabel
            // 
            this.lblTongTienLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTongTienLabel.AutoSize = true;
            this.lblTongTienLabel.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lblTongTienLabel.Location = new System.Drawing.Point(435, 38);
            this.lblTongTienLabel.Name = "lblTongTienLabel";
            this.lblTongTienLabel.Size = new System.Drawing.Size(81, 20);
            this.lblTongTienLabel.TabIndex = 0;
            this.lblTongTienLabel.Text = "Tổng tiền: ";
            // 
            // frmGioHang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(900, 520);
            this.Controls.Add(this.dgvGioHang);
            this.Controls.Add(this.pnlBottom);
            this.Controls.Add(this.lblTitle);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmGioHang";
            this.Text = "Quản Lý Giỏ Hàng";
            this.Load += new System.EventHandler(this.frmGioHang_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvGioHang)).EndInit();
            this.pnlBottom.ResumeLayout(false);
            this.pnlBottom.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.DataGridView dgvGioHang;
        private System.Windows.Forms.Panel pnlBottom;
        private System.Windows.Forms.Button btnTiepTucMua;
        private System.Windows.Forms.Button btnTienHanhDatHang;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnCapNhat;
        private System.Windows.Forms.Label lblTongTien;
        private System.Windows.Forms.Label lblTongTienLabel;
    }
}