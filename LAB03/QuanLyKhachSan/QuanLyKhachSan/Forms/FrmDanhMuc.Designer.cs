namespace QuanLyKhachSan.Forms
{
    partial class FrmDanhMuc
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
            this.tabKhuVuc = new System.Windows.Forms.TabPage();
            this.btnThemKhu = new System.Windows.Forms.Button();
            this.txtKhuTen = new System.Windows.Forms.TextBox();
            this.lblKhuTen = new System.Windows.Forms.Label();
            this.txtKhuMa = new System.Windows.Forms.TextBox();
            this.lblKhuMa = new System.Windows.Forms.Label();
            this.dgvKhu = new System.Windows.Forms.DataGridView();
            this.tabNhanVien = new System.Windows.Forms.TabPage();
            this.btnThemNV = new System.Windows.Forms.Button();
            this.txtNVSDT = new System.Windows.Forms.TextBox();
            this.lblNVSDT = new System.Windows.Forms.Label();
            this.txtNVVaiTro = new System.Windows.Forms.TextBox();
            this.lblNVVaiTro = new System.Windows.Forms.Label();
            this.txtNVTen = new System.Windows.Forms.TextBox();
            this.lblNVTen = new System.Windows.Forms.Label();
            this.txtNVMa = new System.Windows.Forms.TextBox();
            this.lblNVMa = new System.Windows.Forms.Label();
            this.dgvNV = new System.Windows.Forms.DataGridView();
            this.tabLoaiTN = new System.Windows.Forms.TabPage();
            this.btnThemLoaiTN = new System.Windows.Forms.Button();
            this.txtLoaiTen = new System.Windows.Forms.TextBox();
            this.lblLoaiTen = new System.Windows.Forms.Label();
            this.txtLoaiMa = new System.Windows.Forms.TextBox();
            this.lblLoaiMa = new System.Windows.Forms.Label();
            this.dgvLoaiTN = new System.Windows.Forms.DataGridView();
            this.tabDichVu = new System.Windows.Forms.TabPage();
            this.btnThemDV = new System.Windows.Forms.Button();
            this.numDVGia = new System.Windows.Forms.NumericUpDown();
            this.lblDVGia = new System.Windows.Forms.Label();
            this.txtDVDVT = new System.Windows.Forms.TextBox();
            this.lblDVDVT = new System.Windows.Forms.Label();
            this.txtDVTen = new System.Windows.Forms.TextBox();
            this.lblDVTen = new System.Windows.Forms.Label();
            this.txtDVMa = new System.Windows.Forms.TextBox();
            this.lblDVMa = new System.Windows.Forms.Label();
            this.dgvDV = new System.Windows.Forms.DataGridView();
            this.tabQuyDinh = new System.Windows.Forms.TabPage();
            this.btnThemQD = new System.Windows.Forms.Button();
            this.numQDTien = new System.Windows.Forms.NumericUpDown();
            this.lblQDTien = new System.Windows.Forms.Label();
            this.txtQDMucDo = new System.Windows.Forms.TextBox();
            this.lblQDMucDo = new System.Windows.Forms.Label();
            this.cboQDLoai = new System.Windows.Forms.ComboBox();
            this.lblQDLoai = new System.Windows.Forms.Label();
            this.txtQDMa = new System.Windows.Forms.TextBox();
            this.lblQDMa = new System.Windows.Forms.Label();
            this.dgvQD = new System.Windows.Forms.DataGridView();
            this.btnDong = new System.Windows.Forms.Button();
            this.tabControl.SuspendLayout();
            this.tabKhuVuc.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvKhu)).BeginInit();
            this.tabNhanVien.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNV)).BeginInit();
            this.tabLoaiTN.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLoaiTN)).BeginInit();
            this.tabDichVu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numDVGia)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDV)).BeginInit();
            this.tabQuyDinh.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numQDTien)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvQD)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabKhuVuc);
            this.tabControl.Controls.Add(this.tabNhanVien);
            this.tabControl.Controls.Add(this.tabLoaiTN);
            this.tabControl.Controls.Add(this.tabDichVu);
            this.tabControl.Controls.Add(this.tabQuyDinh);
            this.tabControl.Location = new System.Drawing.Point(12, 12);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(680, 420);
            this.tabControl.TabIndex = 0;
            // 
            // tabKhuVuc
            // 
            this.tabKhuVuc.Controls.Add(this.btnThemKhu);
            this.tabKhuVuc.Controls.Add(this.txtKhuTen);
            this.tabKhuVuc.Controls.Add(this.lblKhuTen);
            this.tabKhuVuc.Controls.Add(this.txtKhuMa);
            this.tabKhuVuc.Controls.Add(this.lblKhuMa);
            this.tabKhuVuc.Controls.Add(this.dgvKhu);
            this.tabKhuVuc.Location = new System.Drawing.Point(4, 34);
            this.tabKhuVuc.Name = "tabKhuVuc";
            this.tabKhuVuc.Padding = new System.Windows.Forms.Padding(3);
            this.tabKhuVuc.Size = new System.Drawing.Size(672, 382);
            this.tabKhuVuc.TabIndex = 0;
            this.tabKhuVuc.Text = "Khu vực";
            this.tabKhuVuc.UseVisualStyleBackColor = true;
            // 
            // btnThemKhu
            // 
            this.btnThemKhu.Location = new System.Drawing.Point(480, 345);
            this.btnThemKhu.Name = "btnThemKhu";
            this.btnThemKhu.Size = new System.Drawing.Size(100, 30);
            this.btnThemKhu.TabIndex = 5;
            this.btnThemKhu.Text = "Thêm khu";
            this.btnThemKhu.UseVisualStyleBackColor = true;
            this.btnThemKhu.Click += new System.EventHandler(this.btnThemKhu_Click);
            // 
            // txtKhuTen
            // 
            this.txtKhuTen.Location = new System.Drawing.Point(294, 347);
            this.txtKhuTen.Name = "txtKhuTen";
            this.txtKhuTen.Size = new System.Drawing.Size(180, 31);
            this.txtKhuTen.TabIndex = 4;
            // 
            // lblKhuTen
            // 
            this.lblKhuTen.AutoSize = true;
            this.lblKhuTen.Location = new System.Drawing.Point(220, 353);
            this.lblKhuTen.Name = "lblKhuTen";
            this.lblKhuTen.Size = new System.Drawing.Size(76, 25);
            this.lblKhuTen.TabIndex = 3;
            this.lblKhuTen.Text = "Tên khu:";
            // 
            // txtKhuMa
            // 
            this.txtKhuMa.Location = new System.Drawing.Point(104, 350);
            this.txtKhuMa.Name = "txtKhuMa";
            this.txtKhuMa.Size = new System.Drawing.Size(110, 31);
            this.txtKhuMa.TabIndex = 2;
            // 
            // lblKhuMa
            // 
            this.lblKhuMa.AutoSize = true;
            this.lblKhuMa.Location = new System.Drawing.Point(30, 353);
            this.lblKhuMa.Name = "lblKhuMa";
            this.lblKhuMa.Size = new System.Drawing.Size(75, 25);
            this.lblKhuMa.TabIndex = 1;
            this.lblKhuMa.Text = "Mã khu:";
            // 
            // dgvKhu
            // 
            this.dgvKhu.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvKhu.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvKhu.Location = new System.Drawing.Point(6, 6);
            this.dgvKhu.Name = "dgvKhu";
            this.dgvKhu.RowHeadersWidth = 51;
            this.dgvKhu.Size = new System.Drawing.Size(660, 320);
            this.dgvKhu.TabIndex = 0;
            // 
            // tabNhanVien
            // 
            this.tabNhanVien.Controls.Add(this.btnThemNV);
            this.tabNhanVien.Controls.Add(this.txtNVSDT);
            this.tabNhanVien.Controls.Add(this.lblNVSDT);
            this.tabNhanVien.Controls.Add(this.txtNVVaiTro);
            this.tabNhanVien.Controls.Add(this.lblNVVaiTro);
            this.tabNhanVien.Controls.Add(this.txtNVTen);
            this.tabNhanVien.Controls.Add(this.lblNVTen);
            this.tabNhanVien.Controls.Add(this.txtNVMa);
            this.tabNhanVien.Controls.Add(this.lblNVMa);
            this.tabNhanVien.Controls.Add(this.dgvNV);
            this.tabNhanVien.Location = new System.Drawing.Point(4, 34);
            this.tabNhanVien.Name = "tabNhanVien";
            this.tabNhanVien.Padding = new System.Windows.Forms.Padding(3);
            this.tabNhanVien.Size = new System.Drawing.Size(672, 382);
            this.tabNhanVien.TabIndex = 1;
            this.tabNhanVien.Text = "Nhân viên";
            this.tabNhanVien.UseVisualStyleBackColor = true;
            // 
            // btnThemNV
            // 
            this.btnThemNV.Location = new System.Drawing.Point(540, 345);
            this.btnThemNV.Name = "btnThemNV";
            this.btnThemNV.Size = new System.Drawing.Size(110, 30);
            this.btnThemNV.TabIndex = 9;
            this.btnThemNV.Text = "Thêm nhân viên";
            this.btnThemNV.UseVisualStyleBackColor = true;
            this.btnThemNV.Click += new System.EventHandler(this.btnThemNV_Click);
            // 
            // txtNVSDT
            // 
            this.txtNVSDT.Location = new System.Drawing.Point(423, 350);
            this.txtNVSDT.Name = "txtNVSDT";
            this.txtNVSDT.Size = new System.Drawing.Size(100, 31);
            this.txtNVSDT.TabIndex = 8;
            // 
            // lblNVSDT
            // 
            this.lblNVSDT.AutoSize = true;
            this.lblNVSDT.Location = new System.Drawing.Point(380, 354);
            this.lblNVSDT.Name = "lblNVSDT";
            this.lblNVSDT.Size = new System.Drawing.Size(48, 25);
            this.lblNVSDT.TabIndex = 7;
            this.lblNVSDT.Text = "SĐT:";
            // 
            // txtNVVaiTro
            // 
            this.txtNVVaiTro.Location = new System.Drawing.Point(279, 350);
            this.txtNVVaiTro.Name = "txtNVVaiTro";
            this.txtNVVaiTro.Size = new System.Drawing.Size(95, 31);
            this.txtNVVaiTro.TabIndex = 6;
            this.txtNVVaiTro.TextChanged += new System.EventHandler(this.txtNVVaiTro_TextChanged);
            // 
            // lblNVVaiTro
            // 
            this.lblNVVaiTro.AutoSize = true;
            this.lblNVVaiTro.Location = new System.Drawing.Point(220, 354);
            this.lblNVVaiTro.Name = "lblNVVaiTro";
            this.lblNVVaiTro.Size = new System.Drawing.Size(67, 25);
            this.lblNVVaiTro.TabIndex = 5;
            this.lblNVVaiTro.Text = "Vai trò:";
            // 
            // txtNVTen
            // 
            this.txtNVTen.Location = new System.Drawing.Point(136, 351);
            this.txtNVTen.Name = "txtNVTen";
            this.txtNVTen.Size = new System.Drawing.Size(90, 31);
            this.txtNVTen.TabIndex = 4;
            this.txtNVTen.TextChanged += new System.EventHandler(this.txtNVTen_TextChanged);
            // 
            // lblNVTen
            // 
            this.lblNVTen.AutoSize = true;
            this.lblNVTen.Location = new System.Drawing.Point(70, 354);
            this.lblNVTen.Name = "lblNVTen";
            this.lblNVTen.Size = new System.Drawing.Size(70, 25);
            this.lblNVTen.TabIndex = 3;
            this.lblNVTen.Text = "Họ tên:";
            // 
            // txtNVMa
            // 
            this.txtNVMa.Location = new System.Drawing.Point(39, 351);
            this.txtNVMa.Name = "txtNVMa";
            this.txtNVMa.Size = new System.Drawing.Size(35, 31);
            this.txtNVMa.TabIndex = 2;
            // 
            // lblNVMa
            // 
            this.lblNVMa.AutoSize = true;
            this.lblNVMa.Location = new System.Drawing.Point(4, 354);
            this.lblNVMa.Name = "lblNVMa";
            this.lblNVMa.Size = new System.Drawing.Size(41, 25);
            this.lblNVMa.TabIndex = 1;
            this.lblNVMa.Text = "Mã:";
            // 
            // dgvNV
            // 
            this.dgvNV.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvNV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvNV.Location = new System.Drawing.Point(6, 6);
            this.dgvNV.Name = "dgvNV";
            this.dgvNV.RowHeadersWidth = 51;
            this.dgvNV.Size = new System.Drawing.Size(660, 320);
            this.dgvNV.TabIndex = 0;
            // 
            // tabLoaiTN
            // 
            this.tabLoaiTN.Controls.Add(this.btnThemLoaiTN);
            this.tabLoaiTN.Controls.Add(this.txtLoaiTen);
            this.tabLoaiTN.Controls.Add(this.lblLoaiTen);
            this.tabLoaiTN.Controls.Add(this.txtLoaiMa);
            this.tabLoaiTN.Controls.Add(this.lblLoaiMa);
            this.tabLoaiTN.Controls.Add(this.dgvLoaiTN);
            this.tabLoaiTN.Location = new System.Drawing.Point(4, 34);
            this.tabLoaiTN.Name = "tabLoaiTN";
            this.tabLoaiTN.Size = new System.Drawing.Size(672, 382);
            this.tabLoaiTN.TabIndex = 2;
            this.tabLoaiTN.Text = "Loại tiện nghi";
            this.tabLoaiTN.UseVisualStyleBackColor = true;
            // 
            // btnThemLoaiTN
            // 
            this.btnThemLoaiTN.Location = new System.Drawing.Point(480, 345);
            this.btnThemLoaiTN.Name = "btnThemLoaiTN";
            this.btnThemLoaiTN.Size = new System.Drawing.Size(120, 30);
            this.btnThemLoaiTN.TabIndex = 5;
            this.btnThemLoaiTN.Text = "Thêm loại TN";
            this.btnThemLoaiTN.UseVisualStyleBackColor = true;
            this.btnThemLoaiTN.Click += new System.EventHandler(this.btnThemLoaiTN_Click);
            // 
            // txtLoaiTen
            // 
            this.txtLoaiTen.Location = new System.Drawing.Point(294, 350);
            this.txtLoaiTen.Name = "txtLoaiTen";
            this.txtLoaiTen.Size = new System.Drawing.Size(180, 31);
            this.txtLoaiTen.TabIndex = 4;
            // 
            // lblLoaiTen
            // 
            this.lblLoaiTen.AutoSize = true;
            this.lblLoaiTen.Location = new System.Drawing.Point(220, 353);
            this.lblLoaiTen.Name = "lblLoaiTen";
            this.lblLoaiTen.Size = new System.Drawing.Size(75, 25);
            this.lblLoaiTen.TabIndex = 3;
            this.lblLoaiTen.Text = "Tên loại:";
            // 
            // txtLoaiMa
            // 
            this.txtLoaiMa.Location = new System.Drawing.Point(104, 350);
            this.txtLoaiMa.Name = "txtLoaiMa";
            this.txtLoaiMa.Size = new System.Drawing.Size(110, 31);
            this.txtLoaiMa.TabIndex = 2;
            // 
            // lblLoaiMa
            // 
            this.lblLoaiMa.AutoSize = true;
            this.lblLoaiMa.Location = new System.Drawing.Point(30, 353);
            this.lblLoaiMa.Name = "lblLoaiMa";
            this.lblLoaiMa.Size = new System.Drawing.Size(74, 25);
            this.lblLoaiMa.TabIndex = 1;
            this.lblLoaiMa.Text = "Mã loại:";
            // 
            // dgvLoaiTN
            // 
            this.dgvLoaiTN.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvLoaiTN.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLoaiTN.Location = new System.Drawing.Point(6, 6);
            this.dgvLoaiTN.Name = "dgvLoaiTN";
            this.dgvLoaiTN.RowHeadersWidth = 51;
            this.dgvLoaiTN.Size = new System.Drawing.Size(660, 320);
            this.dgvLoaiTN.TabIndex = 0;
            // 
            // tabDichVu
            // 
            this.tabDichVu.Controls.Add(this.btnThemDV);
            this.tabDichVu.Controls.Add(this.numDVGia);
            this.tabDichVu.Controls.Add(this.lblDVGia);
            this.tabDichVu.Controls.Add(this.txtDVDVT);
            this.tabDichVu.Controls.Add(this.lblDVDVT);
            this.tabDichVu.Controls.Add(this.txtDVTen);
            this.tabDichVu.Controls.Add(this.lblDVTen);
            this.tabDichVu.Controls.Add(this.txtDVMa);
            this.tabDichVu.Controls.Add(this.lblDVMa);
            this.tabDichVu.Controls.Add(this.dgvDV);
            this.tabDichVu.Location = new System.Drawing.Point(4, 34);
            this.tabDichVu.Name = "tabDichVu";
            this.tabDichVu.Size = new System.Drawing.Size(672, 382);
            this.tabDichVu.TabIndex = 3;
            this.tabDichVu.Text = "Dịch vụ";
            this.tabDichVu.UseVisualStyleBackColor = true;
            // 
            // btnThemDV
            // 
            this.btnThemDV.Location = new System.Drawing.Point(566, 349);
            this.btnThemDV.Name = "btnThemDV";
            this.btnThemDV.Size = new System.Drawing.Size(100, 30);
            this.btnThemDV.TabIndex = 9;
            this.btnThemDV.Text = "Thêm DV";
            this.btnThemDV.UseVisualStyleBackColor = true;
            this.btnThemDV.Click += new System.EventHandler(this.btnThemDV_Click);
            // 
            // numDVGia
            // 
            this.numDVGia.DecimalPlaces = 2;
            this.numDVGia.Location = new System.Drawing.Point(450, 350);
            this.numDVGia.Maximum = new decimal(new int[] {
            100000000,
            0,
            0,
            0});
            this.numDVGia.Name = "numDVGia";
            this.numDVGia.Size = new System.Drawing.Size(110, 31);
            this.numDVGia.TabIndex = 8;
            // 
            // lblDVGia
            // 
            this.lblDVGia.AutoSize = true;
            this.lblDVGia.Location = new System.Drawing.Point(375, 354);
            this.lblDVGia.Name = "lblDVGia";
            this.lblDVGia.Size = new System.Drawing.Size(79, 25);
            this.lblDVGia.TabIndex = 7;
            this.lblDVGia.Text = "Đơn giá:";
            // 
            // txtDVDVT
            // 
            this.txtDVDVT.Location = new System.Drawing.Point(289, 351);
            this.txtDVDVT.Name = "txtDVDVT";
            this.txtDVDVT.Size = new System.Drawing.Size(80, 31);
            this.txtDVDVT.TabIndex = 6;
            // 
            // lblDVDVT
            // 
            this.lblDVDVT.AutoSize = true;
            this.lblDVDVT.Location = new System.Drawing.Point(245, 354);
            this.lblDVDVT.Name = "lblDVDVT";
            this.lblDVDVT.Size = new System.Drawing.Size(49, 25);
            this.lblDVDVT.TabIndex = 5;
            this.lblDVDVT.Text = "ĐVT:";
            // 
            // txtDVTen
            // 
            this.txtDVTen.Location = new System.Drawing.Point(140, 350);
            this.txtDVTen.Name = "txtDVTen";
            this.txtDVTen.Size = new System.Drawing.Size(99, 31);
            this.txtDVTen.TabIndex = 4;
            // 
            // lblDVTen
            // 
            this.lblDVTen.AutoSize = true;
            this.lblDVTen.Location = new System.Drawing.Point(75, 354);
            this.lblDVTen.Name = "lblDVTen";
            this.lblDVTen.Size = new System.Drawing.Size(71, 25);
            this.lblDVTen.TabIndex = 3;
            this.lblDVTen.Text = "Tên DV:";
            // 
            // txtDVMa
            // 
            this.txtDVMa.Location = new System.Drawing.Point(38, 351);
            this.txtDVMa.Name = "txtDVMa";
            this.txtDVMa.Size = new System.Drawing.Size(40, 31);
            this.txtDVMa.TabIndex = 2;
            // 
            // lblDVMa
            // 
            this.lblDVMa.AutoSize = true;
            this.lblDVMa.Location = new System.Drawing.Point(2, 354);
            this.lblDVMa.Name = "lblDVMa";
            this.lblDVMa.Size = new System.Drawing.Size(41, 25);
            this.lblDVMa.TabIndex = 1;
            this.lblDVMa.Text = "Mã:";
            // 
            // dgvDV
            // 
            this.dgvDV.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDV.Location = new System.Drawing.Point(6, 6);
            this.dgvDV.Name = "dgvDV";
            this.dgvDV.RowHeadersWidth = 51;
            this.dgvDV.Size = new System.Drawing.Size(660, 320);
            this.dgvDV.TabIndex = 0;
            // 
            // tabQuyDinh
            // 
            this.tabQuyDinh.Controls.Add(this.btnThemQD);
            this.tabQuyDinh.Controls.Add(this.numQDTien);
            this.tabQuyDinh.Controls.Add(this.lblQDTien);
            this.tabQuyDinh.Controls.Add(this.txtQDMucDo);
            this.tabQuyDinh.Controls.Add(this.lblQDMucDo);
            this.tabQuyDinh.Controls.Add(this.cboQDLoai);
            this.tabQuyDinh.Controls.Add(this.lblQDLoai);
            this.tabQuyDinh.Controls.Add(this.txtQDMa);
            this.tabQuyDinh.Controls.Add(this.lblQDMa);
            this.tabQuyDinh.Controls.Add(this.dgvQD);
            this.tabQuyDinh.Location = new System.Drawing.Point(4, 34);
            this.tabQuyDinh.Name = "tabQuyDinh";
            this.tabQuyDinh.Size = new System.Drawing.Size(672, 382);
            this.tabQuyDinh.TabIndex = 4;
            this.tabQuyDinh.Text = "Quy định đền bù";
            this.tabQuyDinh.UseVisualStyleBackColor = true;
            // 
            // btnThemQD
            // 
            this.btnThemQD.Location = new System.Drawing.Point(566, 348);
            this.btnThemQD.Name = "btnThemQD";
            this.btnThemQD.Size = new System.Drawing.Size(100, 30);
            this.btnThemQD.TabIndex = 9;
            this.btnThemQD.Text = "Thêm quy định";
            this.btnThemQD.UseVisualStyleBackColor = true;
            this.btnThemQD.Click += new System.EventHandler(this.btnThemQD_Click);
            // 
            // numQDTien
            // 
            this.numQDTien.DecimalPlaces = 2;
            this.numQDTien.Location = new System.Drawing.Point(449, 351);
            this.numQDTien.Maximum = new decimal(new int[] {
            100000000,
            0,
            0,
            0});
            this.numQDTien.Name = "numQDTien";
            this.numQDTien.Size = new System.Drawing.Size(105, 31);
            this.numQDTien.TabIndex = 8;
            // 
            // lblQDTien
            // 
            this.lblQDTien.AutoSize = true;
            this.lblQDTien.Location = new System.Drawing.Point(385, 353);
            this.lblQDTien.Name = "lblQDTien";
            this.lblQDTien.Size = new System.Drawing.Size(71, 25);
            this.lblQDTien.TabIndex = 7;
            this.lblQDTien.Text = "Số tiền:";
            // 
            // txtQDMucDo
            // 
            this.txtQDMucDo.Location = new System.Drawing.Point(280, 349);
            this.txtQDMucDo.Name = "txtQDMucDo";
            this.txtQDMucDo.Size = new System.Drawing.Size(110, 31);
            this.txtQDMucDo.TabIndex = 6;
            // 
            // lblQDMucDo
            // 
            this.lblQDMucDo.AutoSize = true;
            this.lblQDMucDo.Location = new System.Drawing.Point(210, 353);
            this.lblQDMucDo.Name = "lblQDMucDo";
            this.lblQDMucDo.Size = new System.Drawing.Size(78, 25);
            this.lblQDMucDo.TabIndex = 5;
            this.lblQDMucDo.Text = "Mức độ:";
            // 
            // cboQDLoai
            // 
            this.cboQDLoai.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboQDLoai.FormattingEnabled = true;
            this.cboQDLoai.Location = new System.Drawing.Point(134, 348);
            this.cboQDLoai.Name = "cboQDLoai";
            this.cboQDLoai.Size = new System.Drawing.Size(77, 33);
            this.cboQDLoai.TabIndex = 4;
            // 
            // lblQDLoai
            // 
            this.lblQDLoai.AutoSize = true;
            this.lblQDLoai.Location = new System.Drawing.Point(80, 353);
            this.lblQDLoai.Name = "lblQDLoai";
            this.lblQDLoai.Size = new System.Drawing.Size(48, 25);
            this.lblQDLoai.TabIndex = 3;
            this.lblQDLoai.Text = "Loại:";
            // 
            // txtQDMa
            // 
            this.txtQDMa.Location = new System.Drawing.Point(34, 351);
            this.txtQDMa.Name = "txtQDMa";
            this.txtQDMa.Size = new System.Drawing.Size(40, 31);
            this.txtQDMa.TabIndex = 2;
            // 
            // lblQDMa
            // 
            this.lblQDMa.AutoSize = true;
            this.lblQDMa.Location = new System.Drawing.Point(2, 353);
            this.lblQDMa.Name = "lblQDMa";
            this.lblQDMa.Size = new System.Drawing.Size(41, 25);
            this.lblQDMa.TabIndex = 1;
            this.lblQDMa.Text = "Mã:";
            // 
            // dgvQD
            // 
            this.dgvQD.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvQD.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvQD.Location = new System.Drawing.Point(6, 6);
            this.dgvQD.Name = "dgvQD";
            this.dgvQD.RowHeadersWidth = 51;
            this.dgvQD.Size = new System.Drawing.Size(660, 320);
            this.dgvQD.TabIndex = 0;
            // 
            // btnDong
            // 
            this.btnDong.Location = new System.Drawing.Point(600, 440);
            this.btnDong.Name = "btnDong";
            this.btnDong.Size = new System.Drawing.Size(90, 30);
            this.btnDong.TabIndex = 1;
            this.btnDong.Text = "Đóng";
            this.btnDong.UseVisualStyleBackColor = true;
            this.btnDong.Click += new System.EventHandler(this.btnDong_Click);
            // 
            // FrmDanhMuc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(846, 526);
            this.Controls.Add(this.btnDong);
            this.Controls.Add(this.tabControl);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "FrmDanhMuc";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Quản lý danh mục nền";
            this.Load += new System.EventHandler(this.FrmDanhMuc_Load);
            this.tabControl.ResumeLayout(false);
            this.tabKhuVuc.ResumeLayout(false);
            this.tabKhuVuc.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvKhu)).EndInit();
            this.tabNhanVien.ResumeLayout(false);
            this.tabNhanVien.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNV)).EndInit();
            this.tabLoaiTN.ResumeLayout(false);
            this.tabLoaiTN.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLoaiTN)).EndInit();
            this.tabDichVu.ResumeLayout(false);
            this.tabDichVu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numDVGia)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDV)).EndInit();
            this.tabQuyDinh.ResumeLayout(false);
            this.tabQuyDinh.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numQDTien)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvQD)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabKhuVuc;
        private System.Windows.Forms.TabPage tabNhanVien;
        private System.Windows.Forms.TabPage tabLoaiTN;
        private System.Windows.Forms.TabPage tabDichVu;
        private System.Windows.Forms.TabPage tabQuyDinh;
        private System.Windows.Forms.DataGridView dgvKhu;
        private System.Windows.Forms.Button btnThemKhu;
        private System.Windows.Forms.TextBox txtKhuTen;
        private System.Windows.Forms.Label lblKhuTen;
        private System.Windows.Forms.TextBox txtKhuMa;
        private System.Windows.Forms.Label lblKhuMa;
        private System.Windows.Forms.DataGridView dgvNV;
        private System.Windows.Forms.Button btnThemNV;
        private System.Windows.Forms.TextBox txtNVSDT;
        private System.Windows.Forms.Label lblNVSDT;
        private System.Windows.Forms.TextBox txtNVVaiTro;
        private System.Windows.Forms.Label lblNVVaiTro;
        private System.Windows.Forms.TextBox txtNVTen;
        private System.Windows.Forms.Label lblNVTen;
        private System.Windows.Forms.TextBox txtNVMa;
        private System.Windows.Forms.Label lblNVMa;
        private System.Windows.Forms.DataGridView dgvLoaiTN;
        private System.Windows.Forms.Button btnThemLoaiTN;
        private System.Windows.Forms.TextBox txtLoaiTen;
        private System.Windows.Forms.Label lblLoaiTen;
        private System.Windows.Forms.TextBox txtLoaiMa;
        private System.Windows.Forms.Label lblLoaiMa;
        private System.Windows.Forms.DataGridView dgvDV;
        private System.Windows.Forms.Button btnThemDV;
        private System.Windows.Forms.NumericUpDown numDVGia;
        private System.Windows.Forms.Label lblDVGia;
        private System.Windows.Forms.TextBox txtDVDVT;
        private System.Windows.Forms.Label lblDVDVT;
        private System.Windows.Forms.TextBox txtDVTen;
        private System.Windows.Forms.Label lblDVTen;
        private System.Windows.Forms.TextBox txtDVMa;
        private System.Windows.Forms.Label lblDVMa;
        private System.Windows.Forms.DataGridView dgvQD;
        private System.Windows.Forms.Button btnThemQD;
        private System.Windows.Forms.NumericUpDown numQDTien;
        private System.Windows.Forms.Label lblQDTien;
        private System.Windows.Forms.TextBox txtQDMucDo;
        private System.Windows.Forms.Label lblQDMucDo;
        private System.Windows.Forms.ComboBox cboQDLoai;
        private System.Windows.Forms.Label lblQDLoai;
        private System.Windows.Forms.TextBox txtQDMa;
        private System.Windows.Forms.Label lblQDMa;
        private System.Windows.Forms.Button btnDong;
    }
}