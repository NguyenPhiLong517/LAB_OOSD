namespace eShopping.Forms
{
    partial class frmThanhToan
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
            this.grpNguoiNhan = new System.Windows.Forms.GroupBox();
            this.cboKhuVuc = new System.Windows.Forms.ComboBox();
            this.lblKhuVuc = new System.Windows.Forms.Label();
            this.txtDiaChi = new System.Windows.Forms.TextBox();
            this.lblDiaChi = new System.Windows.Forms.Label();
            this.txtSDT = new System.Windows.Forms.TextBox();
            this.lblSDT = new System.Windows.Forms.Label();
            this.txtHoTen = new System.Windows.Forms.TextBox();
            this.lblHoTen = new System.Windows.Forms.Label();
            this.grpGiaoHang = new System.Windows.Forms.GroupBox();
            this.lblUuDai = new System.Windows.Forms.Label();
            this.radTrongNgay = new System.Windows.Forms.RadioButton();
            this.radNhanh = new System.Windows.Forms.RadioButton();
            this.radThuong = new System.Windows.Forms.RadioButton();
            this.grpThe = new System.Windows.Forms.GroupBox();
            this.dtpHanThe = new System.Windows.Forms.DateTimePicker();
            this.txtCSV = new System.Windows.Forms.TextBox();
            this.lblCSV = new System.Windows.Forms.Label();
            this.lblHanThe = new System.Windows.Forms.Label();
            this.txtChuThe = new System.Windows.Forms.TextBox();
            this.lblChuThe = new System.Windows.Forms.Label();
            this.txtSoThe = new System.Windows.Forms.TextBox();
            this.lblSoThe = new System.Windows.Forms.Label();
            this.cboLoaiThe = new System.Windows.Forms.ComboBox();
            this.lblLoaiThe = new System.Windows.Forms.Label();
            this.grpTongKet = new System.Windows.Forms.GroupBox();
            this.lblTongCong = new System.Windows.Forms.Label();
            this.lblTongCongLabel = new System.Windows.Forms.Label();
            this.lblPhiShip = new System.Windows.Forms.Label();
            this.lblPhiShipLabel = new System.Windows.Forms.Label();
            this.lblTienHang = new System.Windows.Forms.Label();
            this.lblTienHangLabel = new System.Windows.Forms.Label();
            this.btnXacNhan = new System.Windows.Forms.Button();
            this.btnHuy = new System.Windows.Forms.Button();
            this.grpNguoiNhan.SuspendLayout();
            this.grpGiaoHang.SuspendLayout();
            this.grpThe.SuspendLayout();
            this.grpTongKet.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpNguoiNhan
            // 
            this.grpNguoiNhan.Controls.Add(this.cboKhuVuc);
            this.grpNguoiNhan.Controls.Add(this.lblKhuVuc);
            this.grpNguoiNhan.Controls.Add(this.txtDiaChi);
            this.grpNguoiNhan.Controls.Add(this.lblDiaChi);
            this.grpNguoiNhan.Controls.Add(this.txtSDT);
            this.grpNguoiNhan.Controls.Add(this.lblSDT);
            this.grpNguoiNhan.Controls.Add(this.txtHoTen);
            this.grpNguoiNhan.Controls.Add(this.lblHoTen);
            this.grpNguoiNhan.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.grpNguoiNhan.Location = new System.Drawing.Point(20, 20);
            this.grpNguoiNhan.Name = "grpNguoiNhan";
            this.grpNguoiNhan.Size = new System.Drawing.Size(430, 230);
            this.grpNguoiNhan.TabIndex = 0;
            this.grpNguoiNhan.TabStop = false;
            this.grpNguoiNhan.Text = "1. Thông Tin Người Nhận Hàng";
            // 
            // cboKhuVuc
            // 
            this.cboKhuVuc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboKhuVuc.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.cboKhuVuc.FormattingEnabled = true;
            this.cboKhuVuc.Location = new System.Drawing.Point(130, 175);
            this.cboKhuVuc.Name = "cboKhuVuc";
            this.cboKhuVuc.Size = new System.Drawing.Size(275, 25);
            this.cboKhuVuc.TabIndex = 7;
            this.cboKhuVuc.SelectedIndexChanged += new System.EventHandler(this.CapNhatGia);
            // 
            // lblKhuVuc
            // 
            this.lblKhuVuc.AutoSize = true;
            this.lblKhuVuc.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.lblKhuVuc.Location = new System.Drawing.Point(20, 178);
            this.lblKhuVuc.Name = "lblKhuVuc";
            this.lblKhuVuc.Size = new System.Drawing.Size(61, 17);
            this.lblKhuVuc.TabIndex = 6;
            this.lblKhuVuc.Text = "Khu vực: ";
            // 
            // txtDiaChi
            // 
            this.txtDiaChi.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.txtDiaChi.Location = new System.Drawing.Point(130, 125);
            this.txtDiaChi.Name = "txtDiaChi";
            this.txtDiaChi.Size = new System.Drawing.Size(275, 25);
            this.txtDiaChi.TabIndex = 5;
            this.txtDiaChi.Text = "123 Lê Lợi, Quận 1, TP.HCM";
            // 
            // lblDiaChi
            // 
            this.lblDiaChi.AutoSize = true;
            this.lblDiaChi.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.lblDiaChi.Location = new System.Drawing.Point(20, 128);
            this.lblDiaChi.Name = "lblDiaChi";
            this.lblDiaChi.Size = new System.Drawing.Size(54, 17);
            this.lblDiaChi.TabIndex = 4;
            this.lblDiaChi.Text = "Địa chỉ: ";
            // 
            // txtSDT
            // 
            this.txtSDT.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.txtSDT.Location = new System.Drawing.Point(130, 80);
            this.txtSDT.Name = "txtSDT";
            this.txtSDT.Size = new System.Drawing.Size(275, 25);
            this.txtSDT.TabIndex = 3;
            this.txtSDT.Text = "0987654321";
            // 
            // lblSDT
            // 
            this.lblSDT.AutoSize = true;
            this.lblSDT.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.lblSDT.Location = new System.Drawing.Point(20, 83);
            this.lblSDT.Name = "lblSDT";
            this.lblSDT.Size = new System.Drawing.Size(92, 17);
            this.lblSDT.TabIndex = 2;
            this.lblSDT.Text = "Số điện thoại: ";
            // 
            // txtHoTen
            // 
            this.txtHoTen.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.txtHoTen.Location = new System.Drawing.Point(130, 35);
            this.txtHoTen.Name = "txtHoTen";
            this.txtHoTen.Size = new System.Drawing.Size(275, 25);
            this.txtHoTen.TabIndex = 1;
            this.txtHoTen.Text = "Nguyễn Văn Nhận";
            // 
            // lblHoTen
            // 
            this.lblHoTen.AutoSize = true;
            this.lblHoTen.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.lblHoTen.Location = new System.Drawing.Point(20, 38);
            this.lblHoTen.Name = "lblHoTen";
            this.lblHoTen.Size = new System.Drawing.Size(71, 17);
            this.lblHoTen.TabIndex = 0;
            this.lblHoTen.Text = "Họ và tên: ";
            // 
            // grpGiaoHang
            // 
            this.grpGiaoHang.Controls.Add(this.lblUuDai);
            this.grpGiaoHang.Controls.Add(this.radTrongNgay);
            this.grpGiaoHang.Controls.Add(this.radNhanh);
            this.grpGiaoHang.Controls.Add(this.radThuong);
            this.grpGiaoHang.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.grpGiaoHang.Location = new System.Drawing.Point(470, 20);
            this.grpGiaoHang.Name = "grpGiaoHang";
            this.grpGiaoHang.Size = new System.Drawing.Size(430, 230);
            this.grpGiaoHang.TabIndex = 1;
            this.grpGiaoHang.TabStop = false;
            this.grpGiaoHang.Text = "2. Chọn Loại Phiếu Giao Hàng";
            // 
            // lblUuDai
            // 
            this.lblUuDai.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Italic);
            this.lblUuDai.ForeColor = System.Drawing.Color.DarkGreen;
            this.lblUuDai.Location = new System.Drawing.Point(20, 160);
            this.lblUuDai.Name = "lblUuDai";
            this.lblUuDai.Size = new System.Drawing.Size(390, 45);
            this.lblUuDai.TabIndex = 3;
            this.lblUuDai.Text = "* Đơn >= 1.000.000 đ: Miễn phí Giao nhanh.\r\n* Đơn >= 5.000.000 đ: Miễn phí Hỏa tốc" +
    " trong ngày.";
            // 
            // radTrongNgay
            // 
            this.radTrongNgay.AutoSize = true;
            this.radTrongNgay.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.radTrongNgay.Location = new System.Drawing.Point(30, 120);
            this.radTrongNgay.Name = "radTrongNgay";
            this.radTrongNgay.Size = new System.Drawing.Size(262, 21);
            this.radTrongNgay.TabIndex = 2;
            this.radTrongNgay.Text = "Chuyển phát nhanh trong ngày (Hỏa tốc)";
            this.radTrongNgay.UseVisualStyleBackColor = true;
            this.radTrongNgay.CheckedChanged += new System.EventHandler(this.CapNhatGia);
            // 
            // radNhanh
            // 
            this.radNhanh.AutoSize = true;
            this.radNhanh.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.radNhanh.Location = new System.Drawing.Point(30, 75);
            this.radNhanh.Name = "radNhanh";
            this.radNhanh.Size = new System.Drawing.Size(222, 21);
            this.radNhanh.TabIndex = 1;
            this.radNhanh.Text = "Phiếu chuyển phát nhanh (1-2 ngày)";
            this.radNhanh.UseVisualStyleBackColor = true;
            this.radNhanh.CheckedChanged += new System.EventHandler(this.CapNhatGia);
            // 
            // radThuong
            // 
            this.radThuong.AutoSize = true;
            this.radThuong.Checked = true;
            this.radThuong.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.radThuong.Location = new System.Drawing.Point(30, 35);
            this.radThuong.Name = "radThuong";
            this.radThuong.Size = new System.Drawing.Size(225, 21);
            this.radThuong.TabIndex = 0;
            this.radThuong.TabStop = true;
            this.radThuong.Text = "Phiếu đặt hàng thường (3-5 ngày)";
            this.radThuong.UseVisualStyleBackColor = true;
            this.radThuong.CheckedChanged += new System.EventHandler(this.CapNhatGia);
            // 
            // grpThe
            // 
            this.grpThe.Controls.Add(this.dtpHanThe);
            this.grpThe.Controls.Add(this.txtCSV);
            this.grpThe.Controls.Add(this.lblCSV);
            this.grpThe.Controls.Add(this.lblHanThe);
            this.grpThe.Controls.Add(this.txtChuThe);
            this.grpThe.Controls.Add(this.lblChuThe);
            this.grpThe.Controls.Add(this.txtSoThe);
            this.grpThe.Controls.Add(this.lblSoThe);
            this.grpThe.Controls.Add(this.cboLoaiThe);
            this.grpThe.Controls.Add(this.lblLoaiThe);
            this.grpThe.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.grpThe.Location = new System.Drawing.Point(20, 260);
            this.grpThe.Name = "grpThe";
            this.grpThe.Size = new System.Drawing.Size(430, 240);
            this.grpThe.TabIndex = 2;
            this.grpThe.TabStop = false;
            this.grpThe.Text = "3. Thông Tin Thẻ Tín Dụng";
            // 
            // dtpHanThe
            // 
            this.dtpHanThe.CustomFormat = "MM/yyyy";
            this.dtpHanThe.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.dtpHanThe.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpHanThe.Location = new System.Drawing.Point(130, 155);
            this.dtpHanThe.Name = "dtpHanThe";
            this.dtpHanThe.Size = new System.Drawing.Size(100, 25);
            this.dtpHanThe.TabIndex = 9;
            // 
            // txtCSV
            // 
            this.txtCSV.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.txtCSV.Location = new System.Drawing.Point(335, 155);
            this.txtCSV.Name = "txtCSV";
            this.txtCSV.Size = new System.Drawing.Size(70, 25);
            this.txtCSV.TabIndex = 8;
            this.txtCSV.Text = "123";
            // 
            // lblCSV
            // 
            this.lblCSV.AutoSize = true;
            this.lblCSV.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.lblCSV.Location = new System.Drawing.Point(255, 158);
            this.lblCSV.Name = "lblCSV";
            this.lblCSV.Size = new System.Drawing.Size(65, 17);
            this.lblCSV.TabIndex = 7;
            this.lblCSV.Text = "Mã CSV: ";
            // 
            // lblHanThe
            // 
            this.lblHanThe.AutoSize = true;
            this.lblHanThe.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.lblHanThe.Location = new System.Drawing.Point(20, 158);
            this.lblHanThe.Name = "lblHanThe";
            this.lblHanThe.Size = new System.Drawing.Size(61, 17);
            this.lblHanThe.TabIndex = 6;
            this.lblHanThe.Text = "Hạn thẻ: ";
            // 
            // txtChuThe
            // 
            this.txtChuThe.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.txtChuThe.Location = new System.Drawing.Point(130, 115);
            this.txtChuThe.Name = "txtChuThe";
            this.txtChuThe.Size = new System.Drawing.Size(275, 25);
            this.txtChuThe.TabIndex = 5;
            this.txtChuThe.Text = "NGUYEN PHI LONG";
            // 
            // lblChuThe
            // 
            this.lblChuThe.AutoSize = true;
            this.lblChuThe.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.lblChuThe.Location = new System.Drawing.Point(20, 118);
            this.lblChuThe.Name = "lblChuThe";
            this.lblChuThe.Size = new System.Drawing.Size(81, 17);
            this.lblChuThe.TabIndex = 4;
            this.lblChuThe.Text = "Tên chủ thẻ: ";
            // 
            // txtSoThe
            // 
            this.txtSoThe.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.txtSoThe.Location = new System.Drawing.Point(130, 75);
            this.txtSoThe.Name = "txtSoThe";
            this.txtSoThe.Size = new System.Drawing.Size(275, 25);
            this.txtSoThe.TabIndex = 3;
            this.txtSoThe.Text = "4111222233334444";
            // 
            // lblSoThe
            // 
            this.lblSoThe.AutoSize = true;
            this.lblSoThe.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.lblSoThe.Location = new System.Drawing.Point(20, 78);
            this.lblSoThe.Name = "lblSoThe";
            this.lblSoThe.Size = new System.Drawing.Size(52, 17);
            this.lblSoThe.TabIndex = 2;
            this.lblSoThe.Text = "Số thẻ: ";
            // 
            // cboLoaiThe
            // 
            this.cboLoaiThe.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLoaiThe.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.cboLoaiThe.FormattingEnabled = true;
            this.cboLoaiThe.Location = new System.Drawing.Point(130, 35);
            this.cboLoaiThe.Name = "cboLoaiThe";
            this.cboLoaiThe.Size = new System.Drawing.Size(275, 25);
            this.cboLoaiThe.TabIndex = 1;
            // 
            // lblLoaiThe
            // 
            this.lblLoaiThe.AutoSize = true;
            this.lblLoaiThe.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.lblLoaiThe.Location = new System.Drawing.Point(20, 38);
            this.lblLoaiThe.Name = "lblLoaiThe";
            this.lblLoaiThe.Size = new System.Drawing.Size(61, 17);
            this.lblLoaiThe.TabIndex = 0;
            this.lblLoaiThe.Text = "Loại thẻ: ";
            // 
            // grpTongKet
            // 
            this.grpTongKet.Controls.Add(this.lblTongCong);
            this.grpTongKet.Controls.Add(this.lblTongCongLabel);
            this.grpTongKet.Controls.Add(this.lblPhiShip);
            this.grpTongKet.Controls.Add(this.lblPhiShipLabel);
            this.grpTongKet.Controls.Add(this.lblTienHang);
            this.grpTongKet.Controls.Add(this.lblTienHangLabel);
            this.grpTongKet.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.grpTongKet.Location = new System.Drawing.Point(470, 260);
            this.grpTongKet.Name = "grpTongKet";
            this.grpTongKet.Size = new System.Drawing.Size(430, 170);
            this.grpTongKet.TabIndex = 3;
            this.grpTongKet.TabStop = false;
            this.grpTongKet.Text = "4. Tổng Kết Chi Phí Hóa Đơn";
            // 
            // lblTongCong
            // 
            this.lblTongCong.AutoSize = true;
            this.lblTongCong.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblTongCong.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(57)))), ((int)(((byte)(43)))));
            this.lblTongCong.Location = new System.Drawing.Point(180, 120);
            this.lblTongCong.Name = "lblTongCong";
            this.lblTongCong.Size = new System.Drawing.Size(46, 21);
            this.lblTongCong.TabIndex = 5;
            this.lblTongCong.Text = "0 đ";
            // 
            // lblTongCongLabel
            // 
            this.lblTongCongLabel.AutoSize = true;
            this.lblTongCongLabel.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblTongCongLabel.Location = new System.Drawing.Point(30, 120);
            this.lblTongCongLabel.Name = "lblTongCongLabel";
            this.lblTongCongLabel.Size = new System.Drawing.Size(95, 19);
            this.lblTongCongLabel.TabIndex = 4;
            this.lblTongCongLabel.Text = "TỔNG CỘNG:";
            // 
            // lblPhiShip
            // 
            this.lblPhiShip.AutoSize = true;
            this.lblPhiShip.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.lblPhiShip.Location = new System.Drawing.Point(180, 78);
            this.lblPhiShip.Name = "lblPhiShip";
            this.lblPhiShip.Size = new System.Drawing.Size(26, 17);
            this.lblPhiShip.TabIndex = 3;
            this.lblPhiShip.Text = "0 đ";
            // 
            // lblPhiShipLabel
            // 
            this.lblPhiShipLabel.AutoSize = true;
            this.lblPhiShipLabel.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.lblPhiShipLabel.Location = new System.Drawing.Point(30, 78);
            this.lblPhiShipLabel.Name = "lblPhiShipLabel";
            this.lblPhiShipLabel.Size = new System.Drawing.Size(107, 17);
            this.lblPhiShipLabel.TabIndex = 2;
            this.lblPhiShipLabel.Text = "Cước vận chuyển:";
            // 
            // lblTienHang
            // 
            this.lblTienHang.AutoSize = true;
            this.lblTienHang.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.lblTienHang.Location = new System.Drawing.Point(180, 38);
            this.lblTienHang.Name = "lblTienHang";
            this.lblTienHang.Size = new System.Drawing.Size(26, 17);
            this.lblTienHang.TabIndex = 1;
            this.lblTienHang.Text = "0 đ";
            // 
            // lblTienHangLabel
            // 
            this.lblTienHangLabel.AutoSize = true;
            this.lblTienHangLabel.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.lblTienHangLabel.Location = new System.Drawing.Point(30, 38);
            this.lblTienHangLabel.Name = "lblTienHangLabel";
            this.lblTienHangLabel.Size = new System.Drawing.Size(70, 17);
            this.lblTienHangLabel.TabIndex = 0;
            this.lblTienHangLabel.Text = "Tiền hàng: ";
            // 
            // btnXacNhan
            // 
            this.btnXacNhan.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(174)))), ((int)(((byte)(96)))));
            this.btnXacNhan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXacNhan.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnXacNhan.ForeColor = System.Drawing.Color.White;
            this.btnXacNhan.Location = new System.Drawing.Point(670, 445);
            this.btnXacNhan.Name = "btnXacNhan";
            this.btnXacNhan.Size = new System.Drawing.Size(230, 50);
            this.btnXacNhan.TabIndex = 4;
            this.btnXacNhan.Text = "XÁC NHẬN THANH TOÁN";
            this.btnXacNhan.UseVisualStyleBackColor = false;
            this.btnXacNhan.Click += new System.EventHandler(this.btnXacNhan_Click);
            // 
            // btnHuy
            // 
            this.btnHuy.BackColor = System.Drawing.Color.LightGray;
            this.btnHuy.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHuy.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnHuy.Location = new System.Drawing.Point(530, 445);
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.Size = new System.Drawing.Size(120, 50);
            this.btnHuy.TabIndex = 5;
            this.btnHuy.Text = "Hủy Bỏ";
            this.btnHuy.UseVisualStyleBackColor = false;
            this.btnHuy.Click += new System.EventHandler(this.btnHuy_Click);
            // 
            // frmThanhToan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(246)))), ((int)(((byte)(250)))));
            this.ClientSize = new System.Drawing.Size(920, 520);
            this.Controls.Add(this.btnHuy);
            this.Controls.Add(this.btnXacNhan);
            this.Controls.Add(this.grpTongKet);
            this.Controls.Add(this.grpThe);
            this.Controls.Add(this.grpGiaoHang);
            this.Controls.Add(this.grpNguoiNhan);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "frmThanhToan";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Đặt Mua Hàng & Thanh Toán Trực Tuyến";
            this.Load += new System.EventHandler(this.frmThanhToan_Load);
            this.grpNguoiNhan.ResumeLayout(false);
            this.grpNguoiNhan.PerformLayout();
            this.grpGiaoHang.ResumeLayout(false);
            this.grpGiaoHang.PerformLayout();
            this.grpThe.ResumeLayout(false);
            this.grpThe.PerformLayout();
            this.grpTongKet.ResumeLayout(false);
            this.grpTongKet.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpNguoiNhan;
        private System.Windows.Forms.Label lblHoTen;
        private System.Windows.Forms.TextBox txtHoTen;
        private System.Windows.Forms.Label lblSDT;
        private System.Windows.Forms.TextBox txtSDT;
        private System.Windows.Forms.Label lblDiaChi;
        private System.Windows.Forms.TextBox txtDiaChi;
        private System.Windows.Forms.Label lblKhuVuc;
        private System.Windows.Forms.ComboBox cboKhuVuc;
        private System.Windows.Forms.GroupBox grpGiaoHang;
        private System.Windows.Forms.RadioButton radThuong;
        private System.Windows.Forms.RadioButton radNhanh;
        private System.Windows.Forms.RadioButton radTrongNgay;
        private System.Windows.Forms.Label lblUuDai;
        private System.Windows.Forms.GroupBox grpThe;
        private System.Windows.Forms.Label lblLoaiThe;
        private System.Windows.Forms.ComboBox cboLoaiThe;
        private System.Windows.Forms.Label lblSoThe;
        private System.Windows.Forms.TextBox txtSoThe;
        private System.Windows.Forms.Label lblChuThe;
        private System.Windows.Forms.TextBox txtChuThe;
        private System.Windows.Forms.Label lblHanThe;
        private System.Windows.Forms.DateTimePicker dtpHanThe;
        private System.Windows.Forms.Label lblCSV;
        private System.Windows.Forms.TextBox txtCSV;
        private System.Windows.Forms.GroupBox grpTongKet;
        private System.Windows.Forms.Label lblTienHangLabel;
        private System.Windows.Forms.Label lblTienHang;
        private System.Windows.Forms.Label lblPhiShipLabel;
        private System.Windows.Forms.Label lblPhiShip;
        private System.Windows.Forms.Label lblTongCongLabel;
        private System.Windows.Forms.Label lblTongCong;
        private System.Windows.Forms.Button btnXacNhan;
        private System.Windows.Forms.Button btnHuy;
    }
}