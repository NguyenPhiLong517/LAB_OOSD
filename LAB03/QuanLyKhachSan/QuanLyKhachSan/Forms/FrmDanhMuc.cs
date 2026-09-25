using System;
using System.Windows.Forms;
using QuanLyKhachSan.Services;

namespace QuanLyKhachSan.Forms
{
    public partial class FrmDanhMuc : Form
    {
        readonly DanhMucService s = new DanhMucService();

        public FrmDanhMuc()
        {
            InitializeComponent();
        }

        private void FrmDanhMuc_Load(object sender, EventArgs e)
        {
            TaiDuLieu();
        }

        void TaiDuLieu()
        {
            dgvKhu.DataSource = s.LayKhuVuc();
            dgvNV.DataSource = s.LayNhanVien();
            dgvLoaiTN.DataSource = s.LayLoaiTienNghi();
            dgvDV.DataSource = s.LayDichVu();
            dgvQD.DataSource = s.LayQuyDinhDenBu();

            cboQDLoai.DataSource = s.LayLoaiTienNghi();
            cboQDLoai.DisplayMember = "TenLoaiTN";
            cboQDLoai.ValueMember = "MaLoaiTN";
        }

        void ThongBaoKetQua(KetQuaXuLy k)
        {
            MessageBox.Show(k.ThongBao, "Thông báo");
            if (k.ThanhCong) TaiDuLieu();
        }

        private void btnThemKhu_Click(object sender, EventArgs e)
        {
            ThongBaoKetQua(s.ThemKhu(txtKhuMa.Text.Trim(), txtKhuTen.Text.Trim()));
        }

        private void btnThemNV_Click(object sender, EventArgs e)
        {
            ThongBaoKetQua(s.ThemNhanVien(txtNVMa.Text.Trim(), txtNVTen.Text.Trim(), txtNVVaiTro.Text.Trim(), txtNVSDT.Text.Trim()));
        }

        private void btnThemLoaiTN_Click(object sender, EventArgs e)
        {
            ThongBaoKetQua(s.ThemLoaiTN(txtLoaiMa.Text.Trim(), txtLoaiTen.Text.Trim()));
        }

        private void btnThemDV_Click(object sender, EventArgs e)
        {
            ThongBaoKetQua(s.ThemDichVu(txtDVMa.Text.Trim(), txtDVTen.Text.Trim(), txtDVDVT.Text.Trim(), numDVGia.Value));
        }

        private void btnThemQD_Click(object sender, EventArgs e)
        {
            ThongBaoKetQua(s.ThemQuyDinh(txtQDMa.Text.Trim(), cboQDLoai.SelectedValue?.ToString() ?? "", txtQDMucDo.Text.Trim(), numQDTien.Value));
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void txtNVVaiTro_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtNVTen_TextChanged(object sender, EventArgs e)
        {

        }
    }
}