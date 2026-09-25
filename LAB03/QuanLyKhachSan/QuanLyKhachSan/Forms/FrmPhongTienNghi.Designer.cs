namespace QuanLyKhachSan.Forms
{
    partial class FrmPhongTienNghi
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
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPhong = new System.Windows.Forms.TabPage();
            this.btnThemPhong = new System.Windows.Forms.Button();
            this.numGia = new System.Windows.Forms.NumericUpDown();
            this.lblGia = new System.Windows.Forms.Label();
            this.numMax = new System.Windows.Forms.NumericUpDown();
            this.lblMax = new System.Windows.Forms.Label();
            this.cboKhu = new System.Windows.Forms.ComboBox();
            this.lblKhu = new System.Windows.Forms.Label();
            this.txtPhong = new System.Windows.Forms.TextBox();
            this.lblPhong = new System.Windows.Forms.Label();
            this.dgvPhong = new System.Windows.Forms.DataGridView();
            this.tabTienNghi = new System.Windows.Forms.TabPage();
            this.btnThemTN = new System.Windows.Forms.Button();
            this.txtTinhTrang = new System.Windows.Forms.TextBox();
            this.lblTT = new System.Windows.Forms.Label();
            this.numSTT = new System.Windows.Forms.NumericUpDown();
            this.lblSTT = new System.Windows.Forms.Label();
            this.cboLoai = new System.Windows.Forms.ComboBox();
            this.lblLoai = new System.Windows.Forms.Label();
            this.txtMaTN = new System.Windows.Forms.TextBox();
            this.lblMaTN = new System.Windows.Forms.Label();
            this.dgvTN = new System.Windows.Forms.DataGridView();
            this.tabLapDat = new System.Windows.Forms.TabPage();
            this.btnLapDat = new System.Windows.Forms.Button();
            this.txtGhiChu = new System.Windows.Forms.TextBox();
            this.lblGhiChu = new System.Windows.Forms.Label();
            this.cboNV = new System.Windows.Forms.ComboBox();
            this.lblNV = new System.Windows.Forms.Label();
            this.txtTTLD = new System.Windows.Forms.TextBox();
            this.lblTTLD = new System.Windows.Forms.Label();
            this.dtNgay = new System.Windows.Forms.DateTimePicker();
            this.lblNgay = new System.Windows.Forms.Label();
            this.cboPhong = new System.Windows.Forms.ComboBox();
            this.lblPhongLD = new System.Windows.Forms.Label();
            this.cboTN = new System.Windows.Forms.ComboBox();
            this.lblTNLD = new System.Windows.Forms.Label();
            this.txtSoLD = new System.Windows.Forms.TextBox();
            this.lblSoLD = new System.Windows.Forms.Label();
            this.dgvLD = new System.Windows.Forms.DataGridView();
            this.btnDong = new System.Windows.Forms.Button();
            this.tabControl.SuspendLayout();
            this.tabPhong.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numGia)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPhong)).BeginInit();
            this.tabTienNghi.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numSTT)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTN)).BeginInit();
            this.tabLapDat.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLD)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabPhong);
            this.tabControl.Controls.Add(this.tabTienNghi);
            this.tabControl.Controls.Add(this.tabLapDat);
            this.tabControl.Location = new System.Drawing.Point(12, 12);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(830, 480);
            this.tabControl.TabIndex = 0;
            // 
            // tabPhong
            // 
            this.tabPhong.Controls.Add(this.btnThemPhong);
            this.tabPhong.Controls.Add(this.numGia);
            this.tabPhong.Controls.Add(this.lblGia);
            this.tabPhong.Controls.Add(this.numMax);
            this.tabPhong.Controls.Add(this.lblMax);
            this.tabPhong.Controls.Add(this.cboKhu);
            this.tabPhong.Controls.Add(this.lblKhu);
            this.tabPhong.Controls.Add(this.txtPhong);
            this.tabPhong.Controls.Add(this.lblPhong);
            this.tabPhong.Controls.Add(this.dgvPhong);
            this.tabPhong.Location = new System.Drawing.Point(4, 34);
            this.tabPhong.Name = "tabPhong";
            this.tabPhong.Padding = new System.Windows.Forms.Padding(3);
            this.tabPhong.Size = new System.Drawing.Size(822, 442);
            this.tabPhong.TabIndex = 0;
            this.tabPhong.Text = "Phòng";
            this.tabPhong.UseVisualStyleBackColor = true;
            // 
            // btnThemPhong
            // 
            this.btnThemPhong.Location = new System.Drawing.Point(695, 395);
            this.btnThemPhong.Name = "btnThemPhong";
            this.btnThemPhong.Size = new System.Drawing.Size(115, 35);
            this.btnThemPhong.TabIndex = 9;
            this.btnThemPhong.Text = "Thêm phòng";
            this.btnThemPhong.UseVisualStyleBackColor = true;
            this.btnThemPhong.Click += new System.EventHandler(this.btnThemPhong_Click);
            // 
            // numGia
            // 
            this.numGia.DecimalPlaces = 2;
            this.numGia.Location = new System.Drawing.Point(559, 405);
            this.numGia.Maximum = new decimal(new int[] {
            100000000,
            0,
            0,
            0});
            this.numGia.Name = "numGia";
            this.numGia.Size = new System.Drawing.Size(130, 31);
            this.numGia.TabIndex = 8;
            // 
            // lblGia
            // 
            this.lblGia.AutoSize = true;
            this.lblGia.Location = new System.Drawing.Point(485, 405);
            this.lblGia.Name = "lblGia";
            this.lblGia.Size = new System.Drawing.Size(79, 25);
            this.lblGia.TabIndex = 7;
            this.lblGia.Text = "Đơn giá:";
            // 
            // numMax
            // 
            this.numMax.Location = new System.Drawing.Point(414, 404);
            this.numMax.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numMax.Name = "numMax";
            this.numMax.Size = new System.Drawing.Size(65, 31);
            this.numMax.TabIndex = 6;
            this.numMax.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // lblMax
            // 
            this.lblMax.AutoSize = true;
            this.lblMax.Location = new System.Drawing.Point(330, 405);
            this.lblMax.Name = "lblMax";
            this.lblMax.Size = new System.Drawing.Size(88, 25);
            this.lblMax.TabIndex = 5;
            this.lblMax.Text = "Sức chứa:";
            // 
            // cboKhu
            // 
            this.cboKhu.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboKhu.FormattingEnabled = true;
            this.cboKhu.Location = new System.Drawing.Point(215, 401);
            this.cboKhu.Name = "cboKhu";
            this.cboKhu.Size = new System.Drawing.Size(95, 33);
            this.cboKhu.TabIndex = 4;
            // 
            // lblKhu
            // 
            this.lblKhu.AutoSize = true;
            this.lblKhu.Location = new System.Drawing.Point(175, 405);
            this.lblKhu.Name = "lblKhu";
            this.lblKhu.Size = new System.Drawing.Size(46, 25);
            this.lblKhu.TabIndex = 3;
            this.lblKhu.Text = "Khu:";
            // 
            // txtPhong
            // 
            this.txtPhong.Location = new System.Drawing.Point(79, 403);
            this.txtPhong.Name = "txtPhong";
            this.txtPhong.Size = new System.Drawing.Size(90, 31);
            this.txtPhong.TabIndex = 2;
            // 
            // lblPhong
            // 
            this.lblPhong.AutoSize = true;
            this.lblPhong.Location = new System.Drawing.Point(12, 405);
            this.lblPhong.Name = "lblPhong";
            this.lblPhong.Size = new System.Drawing.Size(68, 25);
            this.lblPhong.TabIndex = 1;
            this.lblPhong.Text = "Phòng:";
            // 
            // dgvPhong
            // 
            this.dgvPhong.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvPhong.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPhong.Location = new System.Drawing.Point(6, 6);
            this.dgvPhong.Name = "dgvPhong";
            this.dgvPhong.RowHeadersWidth = 51;
            this.dgvPhong.Size = new System.Drawing.Size(810, 370);
            this.dgvPhong.TabIndex = 0;
            // 
            // tabTienNghi
            // 
            this.tabTienNghi.Controls.Add(this.btnThemTN);
            this.tabTienNghi.Controls.Add(this.txtTinhTrang);
            this.tabTienNghi.Controls.Add(this.lblTT);
            this.tabTienNghi.Controls.Add(this.numSTT);
            this.tabTienNghi.Controls.Add(this.lblSTT);
            this.tabTienNghi.Controls.Add(this.cboLoai);
            this.tabTienNghi.Controls.Add(this.lblLoai);
            this.tabTienNghi.Controls.Add(this.txtMaTN);
            this.tabTienNghi.Controls.Add(this.lblMaTN);
            this.tabTienNghi.Controls.Add(this.dgvTN);
            this.tabTienNghi.Location = new System.Drawing.Point(4, 34);
            this.tabTienNghi.Name = "tabTienNghi";
            this.tabTienNghi.Padding = new System.Windows.Forms.Padding(3);
            this.tabTienNghi.Size = new System.Drawing.Size(822, 442);
            this.tabTienNghi.TabIndex = 1;
            this.tabTienNghi.Text = "Tiện nghi";
            this.tabTienNghi.UseVisualStyleBackColor = true;
            // 
            // btnThemTN
            // 
            this.btnThemTN.Location = new System.Drawing.Point(701, 395);
            this.btnThemTN.Name = "btnThemTN";
            this.btnThemTN.Size = new System.Drawing.Size(115, 35);
            this.btnThemTN.TabIndex = 9;
            this.btnThemTN.Text = "Thêm tiện nghi";
            this.btnThemTN.UseVisualStyleBackColor = true;
            this.btnThemTN.Click += new System.EventHandler(this.btnThemTN_Click);
            // 
            // txtTinhTrang
            // 
            this.txtTinhTrang.Location = new System.Drawing.Point(550, 401);
            this.txtTinhTrang.Name = "txtTinhTrang";
            this.txtTinhTrang.Size = new System.Drawing.Size(133, 31);
            this.txtTinhTrang.TabIndex = 8;
            this.txtTinhTrang.Text = "Tốt";
            // 
            // lblTT
            // 
            this.lblTT.AutoSize = true;
            this.lblTT.Location = new System.Drawing.Point(448, 405);
            this.lblTT.Name = "lblTT";
            this.lblTT.Size = new System.Drawing.Size(96, 25);
            this.lblTT.TabIndex = 7;
            this.lblTT.Text = "Tình trạng:";
            // 
            // numSTT
            // 
            this.numSTT.Location = new System.Drawing.Point(375, 403);
            this.numSTT.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numSTT.Name = "numSTT";
            this.numSTT.Size = new System.Drawing.Size(65, 31);
            this.numSTT.TabIndex = 6;
            this.numSTT.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // lblSTT
            // 
            this.lblSTT.AutoSize = true;
            this.lblSTT.Location = new System.Drawing.Point(325, 405);
            this.lblSTT.Name = "lblSTT";
            this.lblSTT.Size = new System.Drawing.Size(44, 25);
            this.lblSTT.TabIndex = 5;
            this.lblSTT.Text = "STT:";
            // 
            // cboLoai
            // 
            this.cboLoai.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLoai.FormattingEnabled = true;
            this.cboLoai.Location = new System.Drawing.Point(224, 402);
            this.cboLoai.Name = "cboLoai";
            this.cboLoai.Size = new System.Drawing.Size(95, 33);
            this.cboLoai.TabIndex = 4;
            // 
            // lblLoai
            // 
            this.lblLoai.AutoSize = true;
            this.lblLoai.Location = new System.Drawing.Point(175, 405);
            this.lblLoai.Name = "lblLoai";
            this.lblLoai.Size = new System.Drawing.Size(48, 25);
            this.lblLoai.TabIndex = 3;
            this.lblLoai.Text = "Loại:";
            // 
            // txtMaTN
            // 
            this.txtMaTN.Location = new System.Drawing.Point(79, 401);
            this.txtMaTN.Name = "txtMaTN";
            this.txtMaTN.Size = new System.Drawing.Size(90, 31);
            this.txtMaTN.TabIndex = 2;
            // 
            // lblMaTN
            // 
            this.lblMaTN.AutoSize = true;
            this.lblMaTN.Location = new System.Drawing.Point(12, 405);
            this.lblMaTN.Name = "lblMaTN";
            this.lblMaTN.Size = new System.Drawing.Size(68, 25);
            this.lblMaTN.TabIndex = 1;
            this.lblMaTN.Text = "Mã TN:";
            // 
            // dgvTN
            // 
            this.dgvTN.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvTN.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTN.Location = new System.Drawing.Point(6, 6);
            this.dgvTN.Name = "dgvTN";
            this.dgvTN.RowHeadersWidth = 51;
            this.dgvTN.Size = new System.Drawing.Size(810, 370);
            this.dgvTN.TabIndex = 0;
            // 
            // tabLapDat
            // 
            this.tabLapDat.Controls.Add(this.btnLapDat);
            this.tabLapDat.Controls.Add(this.txtGhiChu);
            this.tabLapDat.Controls.Add(this.lblGhiChu);
            this.tabLapDat.Controls.Add(this.cboNV);
            this.tabLapDat.Controls.Add(this.lblNV);
            this.tabLapDat.Controls.Add(this.txtTTLD);
            this.tabLapDat.Controls.Add(this.lblTTLD);
            this.tabLapDat.Controls.Add(this.dtNgay);
            this.tabLapDat.Controls.Add(this.lblNgay);
            this.tabLapDat.Controls.Add(this.cboPhong);
            this.tabLapDat.Controls.Add(this.lblPhongLD);
            this.tabLapDat.Controls.Add(this.cboTN);
            this.tabLapDat.Controls.Add(this.lblTNLD);
            this.tabLapDat.Controls.Add(this.txtSoLD);
            this.tabLapDat.Controls.Add(this.lblSoLD);
            this.tabLapDat.Controls.Add(this.dgvLD);
            this.tabLapDat.Location = new System.Drawing.Point(4, 34);
            this.tabLapDat.Name = "tabLapDat";
            this.tabLapDat.Size = new System.Drawing.Size(822, 442);
            this.tabLapDat.TabIndex = 2;
            this.tabLapDat.Text = "Phiếu lắp đặt";
            this.tabLapDat.UseVisualStyleBackColor = true;
            // 
            // btnLapDat
            // 
            this.btnLapDat.Location = new System.Drawing.Point(695, 387);
            this.btnLapDat.Name = "btnLapDat";
            this.btnLapDat.Size = new System.Drawing.Size(115, 45);
            this.btnLapDat.TabIndex = 15;
            this.btnLapDat.Text = "Lập phiếu";
            this.btnLapDat.UseVisualStyleBackColor = true;
            this.btnLapDat.Click += new System.EventHandler(this.btnLapDat_Click);
            // 
            // txtGhiChu
            // 
            this.txtGhiChu.Location = new System.Drawing.Point(479, 419);
            this.txtGhiChu.Name = "txtGhiChu";
            this.txtGhiChu.Size = new System.Drawing.Size(210, 31);
            this.txtGhiChu.TabIndex = 14;
            // 
            // lblGhiChu
            // 
            this.lblGhiChu.AutoSize = true;
            this.lblGhiChu.Location = new System.Drawing.Point(405, 419);
            this.lblGhiChu.Name = "lblGhiChu";
            this.lblGhiChu.Size = new System.Drawing.Size(75, 25);
            this.lblGhiChu.TabIndex = 13;
            this.lblGhiChu.Text = "Ghi chú:";
            // 
            // cboNV
            // 
            this.cboNV.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboNV.FormattingEnabled = true;
            this.cboNV.Location = new System.Drawing.Point(265, 411);
            this.cboNV.Name = "cboNV";
            this.cboNV.Size = new System.Drawing.Size(119, 33);
            this.cboNV.TabIndex = 12;
            // 
            // lblNV
            // 
            this.lblNV.AutoSize = true;
            this.lblNV.Location = new System.Drawing.Point(225, 419);
            this.lblNV.Name = "lblNV";
            this.lblNV.Size = new System.Drawing.Size(40, 25);
            this.lblNV.TabIndex = 11;
            this.lblNV.Text = "NV:";
            // 
            // txtTTLD
            // 
            this.txtTTLD.Location = new System.Drawing.Point(114, 413);
            this.txtTTLD.Name = "txtTTLD";
            this.txtTTLD.Size = new System.Drawing.Size(108, 31);
            this.txtTTLD.TabIndex = 10;
            this.txtTTLD.Text = "Mới lắp đặt";
            // 
            // lblTTLD
            // 
            this.lblTTLD.AutoSize = true;
            this.lblTTLD.Location = new System.Drawing.Point(12, 419);
            this.lblTTLD.Name = "lblTTLD";
            this.lblTTLD.Size = new System.Drawing.Size(96, 25);
            this.lblTTLD.TabIndex = 9;
            this.lblTTLD.Text = "Tình trạng:";
            // 
            // dtNgay
            // 
            this.dtNgay.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtNgay.Location = new System.Drawing.Point(589, 383);
            this.dtNgay.Name = "dtNgay";
            this.dtNgay.Size = new System.Drawing.Size(100, 31);
            this.dtNgay.TabIndex = 8;
            // 
            // lblNgay
            // 
            this.lblNgay.AutoSize = true;
            this.lblNgay.Location = new System.Drawing.Point(530, 387);
            this.lblNgay.Name = "lblNgay";
            this.lblNgay.Size = new System.Drawing.Size(58, 25);
            this.lblNgay.TabIndex = 7;
            this.lblNgay.Text = "Ngày:";
            // 
            // cboPhong
            // 
            this.cboPhong.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPhong.FormattingEnabled = true;
            this.cboPhong.Location = new System.Drawing.Point(429, 381);
            this.cboPhong.Name = "cboPhong";
            this.cboPhong.Size = new System.Drawing.Size(95, 33);
            this.cboPhong.TabIndex = 6;
            // 
            // lblPhongLD
            // 
            this.lblPhongLD.AutoSize = true;
            this.lblPhongLD.Location = new System.Drawing.Point(365, 387);
            this.lblPhongLD.Name = "lblPhongLD";
            this.lblPhongLD.Size = new System.Drawing.Size(68, 25);
            this.lblPhongLD.TabIndex = 5;
            this.lblPhongLD.Text = "Phòng:";
            // 
            // cboTN
            // 
            this.cboTN.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTN.FormattingEnabled = true;
            this.cboTN.Location = new System.Drawing.Point(265, 379);
            this.cboTN.Name = "cboTN";
            this.cboTN.Size = new System.Drawing.Size(94, 33);
            this.cboTN.TabIndex = 4;
            // 
            // lblTNLD
            // 
            this.lblTNLD.AutoSize = true;
            this.lblTNLD.Location = new System.Drawing.Point(180, 387);
            this.lblTNLD.Name = "lblTNLD";
            this.lblTNLD.Size = new System.Drawing.Size(88, 25);
            this.lblTNLD.TabIndex = 3;
            this.lblTNLD.Text = "Tiện nghi:";
            // 
            // txtSoLD
            // 
            this.txtSoLD.Location = new System.Drawing.Point(85, 383);
            this.txtSoLD.Name = "txtSoLD";
            this.txtSoLD.Size = new System.Drawing.Size(85, 31);
            this.txtSoLD.TabIndex = 2;
            // 
            // lblSoLD
            // 
            this.lblSoLD.AutoSize = true;
            this.lblSoLD.Location = new System.Drawing.Point(12, 387);
            this.lblSoLD.Name = "lblSoLD";
            this.lblSoLD.Size = new System.Drawing.Size(67, 25);
            this.lblSoLD.TabIndex = 1;
            this.lblSoLD.Text = "Số P/L:";
            // 
            // dgvLD
            // 
            this.dgvLD.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvLD.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLD.Location = new System.Drawing.Point(6, 6);
            this.dgvLD.Name = "dgvLD";
            this.dgvLD.RowHeadersWidth = 51;
            this.dgvLD.Size = new System.Drawing.Size(810, 360);
            this.dgvLD.TabIndex = 0;
            // 
            // btnDong
            // 
            this.btnDong.Location = new System.Drawing.Point(740, 500);
            this.btnDong.Name = "btnDong";
            this.btnDong.Size = new System.Drawing.Size(100, 32);
            this.btnDong.TabIndex = 1;
            this.btnDong.Text = "Đóng";
            this.btnDong.UseVisualStyleBackColor = true;
            this.btnDong.Click += new System.EventHandler(this.btnDong_Click);
            // 
            // FrmPhongTienNghi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(854, 545);
            this.Controls.Add(this.btnDong);
            this.Controls.Add(this.tabControl);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "FrmPhongTienNghi";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Quản lý phòng và tiện nghi";
            this.Load += new System.EventHandler(this.FrmPhongTienNghi_Load);
            this.tabControl.ResumeLayout(false);
            this.tabPhong.ResumeLayout(false);
            this.tabPhong.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numGia)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPhong)).EndInit();
            this.tabTienNghi.ResumeLayout(false);
            this.tabTienNghi.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numSTT)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTN)).EndInit();
            this.tabLapDat.ResumeLayout(false);
            this.tabLapDat.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLD)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabPhong;
        private System.Windows.Forms.TabPage tabTienNghi;
        private System.Windows.Forms.TabPage tabLapDat;
        private System.Windows.Forms.DataGridView dgvPhong;
        private System.Windows.Forms.Button btnThemPhong;
        private System.Windows.Forms.NumericUpDown numGia;
        private System.Windows.Forms.Label lblGia;
        private System.Windows.Forms.NumericUpDown numMax;
        private System.Windows.Forms.Label lblMax;
        private System.Windows.Forms.ComboBox cboKhu;
        private System.Windows.Forms.Label lblKhu;
        private System.Windows.Forms.TextBox txtPhong;
        private System.Windows.Forms.Label lblPhong;
        private System.Windows.Forms.DataGridView dgvTN;
        private System.Windows.Forms.Button btnThemTN;
        private System.Windows.Forms.TextBox txtTinhTrang;
        private System.Windows.Forms.Label lblTT;
        private System.Windows.Forms.NumericUpDown numSTT;
        private System.Windows.Forms.Label lblSTT;
        private System.Windows.Forms.ComboBox cboLoai;
        private System.Windows.Forms.Label lblLoai;
        private System.Windows.Forms.TextBox txtMaTN;
        private System.Windows.Forms.Label lblMaTN;
        private System.Windows.Forms.DataGridView dgvLD;
        private System.Windows.Forms.Button btnLapDat;
        private System.Windows.Forms.TextBox txtGhiChu;
        private System.Windows.Forms.Label lblGhiChu;
        private System.Windows.Forms.ComboBox cboNV;
        private System.Windows.Forms.Label lblNV;
        private System.Windows.Forms.TextBox txtTTLD;
        private System.Windows.Forms.Label lblTTLD;
        private System.Windows.Forms.DateTimePicker dtNgay;
        private System.Windows.Forms.Label lblNgay;
        private System.Windows.Forms.ComboBox cboPhong;
        private System.Windows.Forms.Label lblPhongLD;
        private System.Windows.Forms.ComboBox cboTN;
        private System.Windows.Forms.Label lblTNLD;
        private System.Windows.Forms.TextBox txtSoLD;
        private System.Windows.Forms.Label lblSoLD;
        private System.Windows.Forms.Button btnDong;
    }
}