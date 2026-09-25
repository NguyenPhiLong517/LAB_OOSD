namespace QuanLyThuVien.Forms
{
    partial class FrmDanhMuc
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.tabs = new System.Windows.Forms.TabControl();
            this.tabNV = new System.Windows.Forms.TabPage();
            this.btnNVMoi = new System.Windows.Forms.Button();
            this.btnNVXoa = new System.Windows.Forms.Button();
            this.btnNVCapNhat = new System.Windows.Forms.Button();
            this.btnNVThem = new System.Windows.Forms.Button();
            this.dgvNV = new System.Windows.Forms.DataGridView();
            this.txtNVSDT = new System.Windows.Forms.TextBox();
            this.lblNVSDT = new System.Windows.Forms.Label();
            this.txtNVChucVu = new System.Windows.Forms.TextBox();
            this.lblNVChucVu = new System.Windows.Forms.Label();
            this.dtNVNgaySinh = new System.Windows.Forms.DateTimePicker();
            this.lblNVNgaySinh = new System.Windows.Forms.Label();
            this.cboNVPhai = new System.Windows.Forms.ComboBox();
            this.lblNVPhai = new System.Windows.Forms.Label();
            this.txtNVTen = new System.Windows.Forms.TextBox();
            this.lblNVTen = new System.Windows.Forms.Label();
            this.txtNVHo = new System.Windows.Forms.TextBox();
            this.lblNVHo = new System.Windows.Forms.Label();
            this.txtNVMa = new System.Windows.Forms.TextBox();
            this.lblNVMa = new System.Windows.Forms.Label();
            this.tabTL = new System.Windows.Forms.TabPage();
            this.btnTLMoi = new System.Windows.Forms.Button();
            this.btnTLXoa = new System.Windows.Forms.Button();
            this.btnTLCapNhat = new System.Windows.Forms.Button();
            this.btnTLThem = new System.Windows.Forms.Button();
            this.dgvTL = new System.Windows.Forms.DataGridView();
            this.txtTLTen = new System.Windows.Forms.TextBox();
            this.lblTLTen = new System.Windows.Forms.Label();
            this.txtTLMa = new System.Windows.Forms.TextBox();
            this.lblTLMa = new System.Windows.Forms.Label();
            this.tabNXB = new System.Windows.Forms.TabPage();
            this.btnNXBMoi = new System.Windows.Forms.Button();
            this.btnNXBXoa = new System.Windows.Forms.Button();
            this.btnNXBCapNhat = new System.Windows.Forms.Button();
            this.btnNXBThem = new System.Windows.Forms.Button();
            this.dgvNXB = new System.Windows.Forms.DataGridView();
            this.txtNXBSDT = new System.Windows.Forms.TextBox();
            this.lblNXBSDT = new System.Windows.Forms.Label();
            this.txtNXBDiaChi = new System.Windows.Forms.TextBox();
            this.lblNXBDiaChi = new System.Windows.Forms.Label();
            this.txtNXBMa = new System.Windows.Forms.TextBox();
            this.lblNXBMa = new System.Windows.Forms.Label();
            this.btnDong = new System.Windows.Forms.Button();
            this.tabs.SuspendLayout();
            this.tabNV.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNV)).BeginInit();
            this.tabTL.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTL)).BeginInit();
            this.tabNXB.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNXB)).BeginInit();
            this.SuspendLayout();
            // 
            // tabs
            // 
            this.tabs.Controls.Add(this.tabNV);
            this.tabs.Controls.Add(this.tabTL);
            this.tabs.Controls.Add(this.tabNXB);
            this.tabs.Location = new System.Drawing.Point(12, 12);
            this.tabs.Name = "tabs";
            this.tabs.SelectedIndex = 0;
            this.tabs.Size = new System.Drawing.Size(920, 520);
            this.tabs.TabIndex = 0;
            // 
            // tabNV
            // 
            this.tabNV.Controls.Add(this.btnNVMoi);
            this.tabNV.Controls.Add(this.btnNVXoa);
            this.tabNV.Controls.Add(this.btnNVCapNhat);
            this.tabNV.Controls.Add(this.btnNVThem);
            this.tabNV.Controls.Add(this.dgvNV);
            this.tabNV.Controls.Add(this.txtNVSDT);
            this.tabNV.Controls.Add(this.lblNVSDT);
            this.tabNV.Controls.Add(this.txtNVChucVu);
            this.tabNV.Controls.Add(this.lblNVChucVu);
            this.tabNV.Controls.Add(this.dtNVNgaySinh);
            this.tabNV.Controls.Add(this.lblNVNgaySinh);
            this.tabNV.Controls.Add(this.cboNVPhai);
            this.tabNV.Controls.Add(this.lblNVPhai);
            this.tabNV.Controls.Add(this.txtNVTen);
            this.tabNV.Controls.Add(this.lblNVTen);
            this.tabNV.Controls.Add(this.txtNVHo);
            this.tabNV.Controls.Add(this.lblNVHo);
            this.tabNV.Controls.Add(this.txtNVMa);
            this.tabNV.Controls.Add(this.lblNVMa);
            this.tabNV.Location = new System.Drawing.Point(4, 24);
            this.tabNV.Name = "tabNV";
            this.tabNV.Padding = new System.Windows.Forms.Padding(3);
            this.tabNV.Size = new System.Drawing.Size(912, 492);
            this.tabNV.TabIndex = 0;
            this.tabNV.Text = "Nhân viên";
            this.tabNV.UseVisualStyleBackColor = true;
            // 
            // btnNVMoi
            // 
            this.btnNVMoi.Location = new System.Drawing.Point(780, 115);
            this.btnNVMoi.Name = "btnNVMoi";
            this.btnNVMoi.Size = new System.Drawing.Size(100, 32);
            this.btnNVMoi.TabIndex = 18;
            this.btnNVMoi.Text = "Làm mới";
            this.btnNVMoi.UseVisualStyleBackColor = true;
            this.btnNVMoi.Click += new System.EventHandler(this.btnNVMoi_Click);
            // 
            // btnNVXoa
            // 
            this.btnNVXoa.Location = new System.Drawing.Point(665, 115);
            this.btnNVXoa.Name = "btnNVXoa";
            this.btnNVXoa.Size = new System.Drawing.Size(100, 32);
            this.btnNVXoa.TabIndex = 17;
            this.btnNVXoa.Text = "Xóa";
            this.btnNVXoa.UseVisualStyleBackColor = true;
            this.btnNVXoa.Click += new System.EventHandler(this.btnNVXoa_Click);
            // 
            // btnNVCapNhat
            // 
            this.btnNVCapNhat.Location = new System.Drawing.Point(780, 70);
            this.btnNVCapNhat.Name = "btnNVCapNhat";
            this.btnNVCapNhat.Size = new System.Drawing.Size(100, 32);
            this.btnNVCapNhat.TabIndex = 16;
            this.btnNVCapNhat.Text = "Cập nhật";
            this.btnNVCapNhat.UseVisualStyleBackColor = true;
            this.btnNVCapNhat.Click += new System.EventHandler(this.btnNVCapNhat_Click);
            // 
            // btnNVThem
            // 
            this.btnNVThem.Location = new System.Drawing.Point(665, 70);
            this.btnNVThem.Name = "btnNVThem";
            this.btnNVThem.Size = new System.Drawing.Size(100, 32);
            this.btnNVThem.TabIndex = 15;
            this.btnNVThem.Text = "Thêm";
            this.btnNVThem.UseVisualStyleBackColor = true;
            this.btnNVThem.Click += new System.EventHandler(this.btnNVThem_Click);
            // 
            // dgvNV
            // 
            this.dgvNV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvNV.Location = new System.Drawing.Point(15, 165);
            this.dgvNV.MultiSelect = false;
            this.dgvNV.Name = "dgvNV";
            this.dgvNV.ReadOnly = true;
            this.dgvNV.RowHeadersWidth = 51;
            this.dgvNV.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvNV.Size = new System.Drawing.Size(880, 310);
            this.dgvNV.TabIndex = 14;
            this.dgvNV.SelectionChanged += new System.EventHandler(this.dgvNV_SelectionChanged);
            // 
            // txtNVSDT
            // 
            this.txtNVSDT.Location = new System.Drawing.Point(440, 115);
            this.txtNVSDT.Name = "txtNVSDT";
            this.txtNVSDT.Size = new System.Drawing.Size(180, 23);
            this.txtNVSDT.TabIndex = 13;
            // 
            // lblNVSDT
            // 
            this.lblNVSDT.AutoSize = true;
            this.lblNVSDT.Location = new System.Drawing.Point(365, 118);
            this.lblNVSDT.Name = "lblNVSDT";
            this.lblNVSDT.Size = new System.Drawing.Size(64, 15);
            this.lblNVSDT.TabIndex = 12;
            this.lblNVSDT.Text = "Điện thoại:";
            // 
            // txtNVChucVu
            // 
            this.txtNVChucVu.Location = new System.Drawing.Point(440, 75);
            this.txtNVChucVu.Name = "txtNVChucVu";
            this.txtNVChucVu.Size = new System.Drawing.Size(180, 23);
            this.txtNVChucVu.TabIndex = 11;
            // 
            // lblNVChucVu
            // 
            this.lblNVChucVu.AutoSize = true;
            this.lblNVChucVu.Location = new System.Drawing.Point(365, 78);
            this.lblNVChucVu.Name = "lblNVChucVu";
            this.lblNVChucVu.Size = new System.Drawing.Size(54, 15);
            this.lblNVChucVu.TabIndex = 10;
            this.lblNVChucVu.Text = "Chức vụ:";
            // 
            // dtNVNgaySinh
            // 
            this.dtNVNgaySinh.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtNVNgaySinh.Location = new System.Drawing.Point(440, 35);
            this.dtNVNgaySinh.Name = "dtNVNgaySinh";
            this.dtNVNgaySinh.Size = new System.Drawing.Size(180, 23);
            this.dtNVNgaySinh.TabIndex = 9;
            // 
            // lblNVNgaySinh
            // 
            this.lblNVNgaySinh.AutoSize = true;
            this.lblNVNgaySinh.Location = new System.Drawing.Point(365, 38);
            this.lblNVNgaySinh.Name = "lblNVNgaySinh";
            this.lblNVNgaySinh.Size = new System.Drawing.Size(63, 15);
            this.lblNVNgaySinh.TabIndex = 8;
            this.lblNVNgaySinh.Text = "Ngày sinh:";
            // 
            // cboNVPhai
            // 
            this.cboNVPhai.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboNVPhai.FormattingEnabled = true;
            this.cboNVPhai.Location = new System.Drawing.Point(115, 115);
            this.cboNVPhai.Name = "cboNVPhai";
            this.cboNVPhai.Size = new System.Drawing.Size(210, 23);
            this.cboNVPhai.TabIndex = 7;
            // 
            // lblNVPhai
            // 
            this.lblNVPhai.AutoSize = true;
            this.lblNVPhai.Location = new System.Drawing.Point(25, 118);
            this.lblNVPhai.Name = "lblNVPhai";
            this.lblNVPhai.Size = new System.Drawing.Size(33, 15);
            this.lblNVPhai.TabIndex = 6;
            this.lblNVPhai.Text = "Phái:";
            // 
            // txtNVTen
            // 
            this.txtNVTen.Location = new System.Drawing.Point(115, 75);
            this.txtNVTen.Name = "txtNVTen";
            this.txtNVTen.Size = new System.Drawing.Size(210, 23);
            this.txtNVTen.TabIndex = 5;
            // 
            // lblNVTen
            // 
            this.lblNVTen.AutoSize = true;
            this.lblNVTen.Location = new System.Drawing.Point(25, 78);
            this.lblNVTen.Name = "lblNVTen";
            this.lblNVTen.Size = new System.Drawing.Size(29, 15);
            this.lblNVTen.TabIndex = 4;
            this.lblNVTen.Text = "Tên:";
            // 
            // txtNVHo
            // 
            this.txtNVHo.Location = new System.Drawing.Point(115, 45);
            this.txtNVHo.Name = "txtNVHo";
            this.txtNVHo.Size = new System.Drawing.Size(210, 23);
            this.txtNVHo.TabIndex = 3;
            // 
            // lblNVHo
            // 
            this.lblNVHo.AutoSize = true;
            this.lblNVHo.Location = new System.Drawing.Point(25, 48);
            this.lblNVHo.Name = "lblNVHo";
            this.lblNVHo.Size = new System.Drawing.Size(26, 15);
            this.lblNVHo.TabIndex = 2;
            this.lblNVHo.Text = "Họ:";
            // 
            // txtNVMa
            // 
            this.txtNVMa.Location = new System.Drawing.Point(115, 15);
            this.txtNVMa.Name = "txtNVMa";
            this.txtNVMa.Size = new System.Drawing.Size(210, 23);
            this.txtNVMa.TabIndex = 1;
            // 
            // lblNVMa
            // 
            this.lblNVMa.AutoSize = true;
            this.lblNVMa.Location = new System.Drawing.Point(25, 18);
            this.lblNVMa.Name = "lblNVMa";
            this.lblNVMa.Size = new System.Drawing.Size(46, 15);
            this.lblNVMa.TabIndex = 0;
            this.lblNVMa.Text = "Mã NV:";
            // 
            // tabTL
            // 
            this.tabTL.Controls.Add(this.btnTLMoi);
            this.tabTL.Controls.Add(this.btnTLXoa);
            this.tabTL.Controls.Add(this.btnTLCapNhat);
            this.tabTL.Controls.Add(this.btnTLThem);
            this.tabTL.Controls.Add(this.dgvTL);
            this.tabTL.Controls.Add(this.txtTLTen);
            this.tabTL.Controls.Add(this.lblTLTen);
            this.tabTL.Controls.Add(this.txtTLMa);
            this.tabTL.Controls.Add(this.lblTLMa);
            this.tabTL.Location = new System.Drawing.Point(4, 24);
            this.tabTL.Name = "tabTL";
            this.tabTL.Padding = new System.Windows.Forms.Padding(3);
            this.tabTL.Size = new System.Drawing.Size(912, 492);
            this.tabTL.TabIndex = 1;
            this.tabTL.Text = "Thể loại";
            this.tabTL.UseVisualStyleBackColor = true;
            // 
            // btnTLMoi
            // 
            this.btnTLMoi.Location = new System.Drawing.Point(495, 65);
            this.btnTLMoi.Name = "btnTLMoi";
            this.btnTLMoi.Size = new System.Drawing.Size(100, 32);
            this.btnTLMoi.TabIndex = 8;
            this.btnTLMoi.Text = "Làm mới";
            this.btnTLMoi.UseVisualStyleBackColor = true;
            this.btnTLMoi.Click += new System.EventHandler(this.btnTLMoi_Click);
            // 
            // btnTLXoa
            // 
            this.btnTLXoa.Location = new System.Drawing.Point(375, 65);
            this.btnTLXoa.Name = "btnTLXoa";
            this.btnTLXoa.Size = new System.Drawing.Size(100, 32);
            this.btnTLXoa.TabIndex = 7;
            this.btnTLXoa.Text = "Xóa";
            this.btnTLXoa.UseVisualStyleBackColor = true;
            this.btnTLXoa.Click += new System.EventHandler(this.btnTLXoa_Click);
            // 
            // btnTLCapNhat
            // 
            this.btnTLCapNhat.Location = new System.Drawing.Point(255, 65);
            this.btnTLCapNhat.Name = "btnTLCapNhat";
            this.btnTLCapNhat.Size = new System.Drawing.Size(100, 32);
            this.btnTLCapNhat.TabIndex = 6;
            this.btnTLCapNhat.Text = "Cập nhật";
            this.btnTLCapNhat.UseVisualStyleBackColor = true;
            this.btnTLCapNhat.Click += new System.EventHandler(this.btnTLCapNhat_Click);
            // 
            // btnTLThem
            // 
            this.btnTLThem.Location = new System.Drawing.Point(135, 65);
            this.btnTLThem.Name = "btnTLThem";
            this.btnTLThem.Size = new System.Drawing.Size(100, 32);
            this.btnTLThem.TabIndex = 5;
            this.btnTLThem.Text = "Thêm";
            this.btnTLThem.UseVisualStyleBackColor = true;
            this.btnTLThem.Click += new System.EventHandler(this.btnTLThem_Click);
            // 
            // dgvTL
            // 
            this.dgvTL.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTL.Location = new System.Drawing.Point(15, 115);
            this.dgvTL.MultiSelect = false;
            this.dgvTL.Name = "dgvTL";
            this.dgvTL.ReadOnly = true;
            this.dgvTL.RowHeadersWidth = 51;
            this.dgvTL.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTL.Size = new System.Drawing.Size(880, 360);
            this.dgvTL.TabIndex = 4;
            this.dgvTL.SelectionChanged += new System.EventHandler(this.dgvTL_SelectionChanged);
            // 
            // txtTLTen
            // 
            this.txtTLTen.Location = new System.Drawing.Point(440, 20);
            this.txtTLTen.Name = "txtTLTen";
            this.txtTLTen.Size = new System.Drawing.Size(250, 23);
            this.txtTLTen.TabIndex = 3;
            // 
            // lblTLTen
            // 
            this.lblTLTen.AutoSize = true;
            this.lblTLTen.Location = new System.Drawing.Point(365, 23);
            this.lblTLTen.Name = "lblTLTen";
            this.lblTLTen.Size = new System.Drawing.Size(71, 15);
            this.lblTLTen.TabIndex = 2;
            this.lblTLTen.Text = "Tên thể loại:";
            // 
            // txtTLMa
            // 
            this.txtTLMa.Location = new System.Drawing.Point(135, 20);
            this.txtTLMa.Name = "txtTLMa";
            this.txtTLMa.Size = new System.Drawing.Size(200, 23);
            this.txtTLMa.TabIndex = 1;
            // 
            // lblTLMa
            // 
            this.lblTLMa.AutoSize = true;
            this.lblTLMa.Location = new System.Drawing.Point(45, 23);
            this.lblTLMa.Name = "lblTLMa";
            this.lblTLMa.Size = new System.Drawing.Size(68, 15);
            this.lblTLMa.TabIndex = 0;
            this.lblTLMa.Text = "Mã thể loại:";
            // 
            // tabNXB
            // 
            this.tabNXB.Controls.Add(this.btnNXBMoi);
            this.tabNXB.Controls.Add(this.btnNXBXoa);
            this.tabNXB.Controls.Add(this.btnNXBCapNhat);
            this.tabNXB.Controls.Add(this.btnNXBThem);
            this.tabNXB.Controls.Add(this.dgvNXB);
            this.tabNXB.Controls.Add(this.txtNXBSDT);
            this.tabNXB.Controls.Add(this.lblNXBSDT);
            this.tabNXB.Controls.Add(this.txtNXBDiaChi);
            this.tabNXB.Controls.Add(this.lblNXBDiaChi);
            this.tabNXB.Controls.Add(this.txtNXBMa);
            this.tabNXB.Controls.Add(this.lblNXBMa);
            this.tabNXB.Location = new System.Drawing.Point(4, 24);
            this.tabNXB.Name = "tabNXB";
            this.tabNXB.Padding = new System.Windows.Forms.Padding(3);
            this.tabNXB.Size = new System.Drawing.Size(912, 492);
            this.tabNXB.TabIndex = 2;
            this.tabNXB.Text = "Nhà xuất bản";
            this.tabNXB.UseVisualStyleBackColor = true;
            // 
            // btnNXBMoi
            // 
            this.btnNXBMoi.Location = new System.Drawing.Point(520, 65);
            this.btnNXBMoi.Name = "btnNXBMoi";
            this.btnNXBMoi.Size = new System.Drawing.Size(100, 32);
            this.btnNXBMoi.TabIndex = 10;
            this.btnNXBMoi.Text = "Làm mới";
            this.btnNXBMoi.UseVisualStyleBackColor = true;
            this.btnNXBMoi.Click += new System.EventHandler(this.btnNXBMoi_Click);
            // 
            // btnNXBXoa
            // 
            this.btnNXBXoa.Location = new System.Drawing.Point(400, 65);
            this.btnNXBXoa.Name = "btnNXBXoa";
            this.btnNXBXoa.Size = new System.Drawing.Size(100, 32);
            this.btnNXBXoa.TabIndex = 9;
            this.btnNXBXoa.Text = "Xóa";
            this.btnNXBXoa.UseVisualStyleBackColor = true;
            this.btnNXBXoa.Click += new System.EventHandler(this.btnNXBXoa_Click);
            // 
            // btnNXBCapNhat
            // 
            this.btnNXBCapNhat.Location = new System.Drawing.Point(280, 65);
            this.btnNXBCapNhat.Name = "btnNXBCapNhat";
            this.btnNXBCapNhat.Size = new System.Drawing.Size(100, 32);
            this.btnNXBCapNhat.TabIndex = 8;
            this.btnNXBCapNhat.Text = "Cập nhật";
            this.btnNXBCapNhat.UseVisualStyleBackColor = true;
            this.btnNXBCapNhat.Click += new System.EventHandler(this.btnNXBCapNhat_Click);
            // 
            // btnNXBThem
            // 
            this.btnNXBThem.Location = new System.Drawing.Point(160, 65);
            this.btnNXBThem.Name = "btnNXBThem";
            this.btnNXBThem.Size = new System.Drawing.Size(100, 32);
            this.btnNXBThem.TabIndex = 7;
            this.btnNXBThem.Text = "Thêm";
            this.btnNXBThem.UseVisualStyleBackColor = true;
            this.btnNXBThem.Click += new System.EventHandler(this.btnNXBThem_Click);
            // 
            // dgvNXB
            // 
            this.dgvNXB.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvNXB.Location = new System.Drawing.Point(15, 115);
            this.dgvNXB.MultiSelect = false;
            this.dgvNXB.Name = "dgvNXB";
            this.dgvNXB.ReadOnly = true;
            this.dgvNXB.RowHeadersWidth = 51;
            this.dgvNXB.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvNXB.Size = new System.Drawing.Size(880, 360);
            this.dgvNXB.TabIndex = 6;
            this.dgvNXB.SelectionChanged += new System.EventHandler(this.dgvNXB_SelectionChanged);
            // 
            // txtNXBSDT
            // 
            this.txtNXBSDT.Location = new System.Drawing.Point(680, 20);
            this.txtNXBSDT.Name = "txtNXBSDT";
            this.txtNXBSDT.Size = new System.Drawing.Size(180, 23);
            this.txtNXBSDT.TabIndex = 5;
            // 
            // lblNXBSDT
            // 
            this.lblNXBSDT.AutoSize = true;
            this.lblNXBSDT.Location = new System.Drawing.Point(630, 23);
            this.lblNXBSDT.Name = "lblNXBSDT";
            this.lblNXBSDT.Size = new System.Drawing.Size(30, 15);
            this.lblNXBSDT.TabIndex = 4;
            this.lblNXBSDT.Text = "SĐT:";
            // 
            // txtNXBDiaChi
            // 
            this.txtNXBDiaChi.Location = new System.Drawing.Point(375, 20);
            this.txtNXBDiaChi.Name = "txtNXBDiaChi";
            this.txtNXBDiaChi.Size = new System.Drawing.Size(230, 23);
            this.txtNXBDiaChi.TabIndex = 3;
            // 
            // lblNXBDiaChi
            // 
            this.lblNXBDiaChi.AutoSize = true;
            this.lblNXBDiaChi.Location = new System.Drawing.Point(320, 23);
            this.lblNXBDiaChi.Name = "lblNXBDiaChi";
            this.lblNXBDiaChi.Size = new System.Drawing.Size(46, 15);
            this.lblNXBDiaChi.TabIndex = 2;
            this.lblNXBDiaChi.Text = "Địa chỉ:";
            // 
            // txtNXBMa
            // 
            this.txtNXBMa.Location = new System.Drawing.Point(120, 20);
            this.txtNXBMa.Name = "txtNXBMa";
            this.txtNXBMa.Size = new System.Drawing.Size(180, 23);
            this.txtNXBMa.TabIndex = 1;
            // 
            // lblNXBMa
            // 
            this.lblNXBMa.AutoSize = true;
            this.lblNXBMa.Location = new System.Drawing.Point(40, 23);
            this.lblNXBMa.Name = "lblNXBMa";
            this.lblNXBMa.Size = new System.Drawing.Size(53, 15);
            this.lblNXBMa.TabIndex = 0;
            this.lblNXBMa.Text = "Mã NXB:";
            // 
            // btnDong
            // 
            this.btnDong.Location = new System.Drawing.Point(830, 540);
            this.btnDong.Name = "btnDong";
            this.btnDong.Size = new System.Drawing.Size(100, 32);
            this.btnDong.TabIndex = 1;
            this.btnDong.Text = "Đóng";
            this.btnDong.UseVisualStyleBackColor = true;
            this.btnDong.Click += new System.EventHandler(this.btnDong_Click);
            // 
            // FrmDanhMuc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(944, 581);
            this.Controls.Add(this.btnDong);
            this.Controls.Add(this.tabs);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "FrmDanhMuc";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Danh mục và nhân viên";
            this.Load += new System.EventHandler(this.FrmDanhMuc_Load);
            this.tabs.ResumeLayout(false);
            this.tabNV.ResumeLayout(false);
            this.tabNV.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNV)).EndInit();
            this.tabTL.ResumeLayout(false);
            this.tabTL.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTL)).EndInit();
            this.tabNXB.ResumeLayout(false);
            this.tabNXB.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNXB)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabs;
        private System.Windows.Forms.TabPage tabNV;
        private System.Windows.Forms.TabPage tabTL;
        private System.Windows.Forms.TabPage tabNXB;
        private System.Windows.Forms.DataGridView dgvNV;
        private System.Windows.Forms.TextBox txtNVSDT;
        private System.Windows.Forms.Label lblNVSDT;
        private System.Windows.Forms.TextBox txtNVChucVu;
        private System.Windows.Forms.Label lblNVChucVu;
        private System.Windows.Forms.DateTimePicker dtNVNgaySinh;
        private System.Windows.Forms.Label lblNVNgaySinh;
        private System.Windows.Forms.ComboBox cboNVPhai;
        private System.Windows.Forms.Label lblNVPhai;
        private System.Windows.Forms.TextBox txtNVTen;
        private System.Windows.Forms.Label lblNVTen;
        private System.Windows.Forms.TextBox txtNVHo;
        private System.Windows.Forms.Label lblNVHo;
        private System.Windows.Forms.TextBox txtNVMa;
        private System.Windows.Forms.Label lblNVMa;
        private System.Windows.Forms.Button btnNVMoi;
        private System.Windows.Forms.Button btnNVXoa;
        private System.Windows.Forms.Button btnNVCapNhat;
        private System.Windows.Forms.Button btnNVThem;
        private System.Windows.Forms.Button btnTLMoi;
        private System.Windows.Forms.Button btnTLXoa;
        private System.Windows.Forms.Button btnTLCapNhat;
        private System.Windows.Forms.Button btnTLThem;
        private System.Windows.Forms.DataGridView dgvTL;
        private System.Windows.Forms.TextBox txtTLTen;
        private System.Windows.Forms.Label lblTLTen;
        private System.Windows.Forms.TextBox txtTLMa;
        private System.Windows.Forms.Label lblTLMa;
        private System.Windows.Forms.Button btnNXBMoi;
        private System.Windows.Forms.Button btnNXBXoa;
        private System.Windows.Forms.Button btnNXBCapNhat;
        private System.Windows.Forms.Button btnNXBThem;
        private System.Windows.Forms.DataGridView dgvNXB;
        private System.Windows.Forms.TextBox txtNXBSDT;
        private System.Windows.Forms.Label lblNXBSDT;
        private System.Windows.Forms.TextBox txtNXBDiaChi;
        private System.Windows.Forms.Label lblNXBDiaChi;
        private System.Windows.Forms.TextBox txtNXBMa;
        private System.Windows.Forms.Label lblNXBMa;
        private System.Windows.Forms.Button btnDong;
    }
}