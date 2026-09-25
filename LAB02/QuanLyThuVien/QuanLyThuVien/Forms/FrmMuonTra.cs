using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using QuanLyThuVien.Services;

namespace QuanLyThuVien.Forms
{
    public partial class FrmMuonTra : Form
    {
        private readonly MuonTraService service = new MuonTraService();
        private readonly SachService sachService = new SachService();
        private readonly DocGiaService docGiaService = new DocGiaService();
        private readonly DanhMucService danhMuc = new DanhMucService();
        private DataTable selectedBooks;

        public FrmMuonTra()
        {
            InitializeComponent();
        }

        private void FrmMuonTra_Load(object sender, EventArgs e)
        {
            DataTable readers = docGiaService.LayComboDocGia();
            cboDocGia.DataSource = readers.Copy();
            cboDocGia.DisplayMember = "HoTen";
            cboDocGia.ValueMember = "MaDocGia";

            cboDocGiaTra.DataSource = readers.Copy();
            cboDocGiaTra.DisplayMember = "HoTen";
            cboDocGiaTra.ValueMember = "MaDocGia";

            DataTable staff = danhMuc.LayNhanVien();
            cboNhanVienMuon.DataSource = staff.Copy();
            cboNhanVienMuon.DisplayMember = "MaNhanVien";
            cboNhanVienMuon.ValueMember = "MaNhanVien";

            cboNhanVienTra.DataSource = staff.Copy();
            cboNhanVienTra.DisplayMember = "MaNhanVien";
            cboNhanVienTra.ValueMember = "MaNhanVien";

            cboTinhTrang.Items.AddRange(new object[] { "Bình thường", "Rách/Hư hỏng", "Mất" });
            cboTinhTrang.SelectedIndex = 0;

            dtNgayMuon.Value = DateTime.Today;
            dtHenTra.Value = DateTime.Today.AddDays(7);
            dtNgayTra.Value = DateTime.Today;

            TaoBangChon();
            TaiSachCon();
            TaiSachDangMuon();
        }

        private void TaoBangChon()
        {
            selectedBooks = new DataTable();
            selectedBooks.Columns.Add("MaDauSach", typeof(string));
            selectedBooks.Columns.Add("TenSach", typeof(string));
            dgvSachChon.DataSource = selectedBooks;
            dgvSachChon.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private string MaDocGiaMuon => cboDocGia.SelectedValue?.ToString() ?? "";
        private string MaDocGiaTra => cboDocGiaTra.SelectedValue?.ToString() ?? "";
        private string MaNhanVienMuon => cboNhanVienMuon.SelectedValue?.ToString() ?? "";
        private string MaNhanVienTra => cboNhanVienTra.SelectedValue?.ToString() ?? "";

        private void TaiSachCon()
        {
            dgvSachCon.DataSource = sachService.LaySachConTrongKho();
            dgvSachCon.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void btnKiemTra_Click(object sender, EventArgs e)
        {
            KetQuaXuLy kq = service.KiemTraDieuKienMuon(MaDocGiaMuon, Math.Max(1, selectedBooks.Rows.Count));
            lblTrangThai.Text = kq.ThongBao;
            lblTrangThai.ForeColor = kq.ThanhCong ? System.Drawing.Color.DarkGreen : System.Drawing.Color.DarkRed;
        }

        private void btnThemSach_Click(object sender, EventArgs e)
        {
            if (!(dgvSachCon.CurrentRow?.DataBoundItem is DataRowView r)) return;
            if (selectedBooks.Rows.Count >= 3)
            {
                MessageBox.Show("Chỉ được chọn tối đa 3 đầu sách khác nhau (BR04).");
                return;
            }

            string ma = Convert.ToString(r["MaDauSach"]);
            foreach (DataRow row in selectedBooks.Rows)
            {
                if (string.Equals(Convert.ToString(row["MaDauSach"]), ma, StringComparison.OrdinalIgnoreCase))
                {
                    MessageBox.Show("Đầu sách này đã có trong danh sách mượn (BR06).");
                    return;
                }
            }

            selectedBooks.Rows.Add(ma, Convert.ToString(r["TenSach"]));
        }

        private void btnBoSach_Click(object sender, EventArgs e)
        {
            if (dgvSachChon.CurrentRow?.DataBoundItem is DataRowView r)
                r.Row.Delete();
        }

        private void btnLapPhieu_Click(object sender, EventArgs e)
        {
            var ds = new List<string>();
            foreach (DataRow r in selectedBooks.Rows)
                if (r.RowState != DataRowState.Deleted) ds.Add(Convert.ToString(r["MaDauSach"]));

            KetQuaXuLy kq = service.LapPhieuMuon(MaDocGiaMuon, MaNhanVienMuon, ds, dtNgayMuon.Value, dtHenTra.Value);
            MessageBox.Show(kq.ThongBao, kq.ThanhCong ? "Thông báo" : "Lỗi",
                MessageBoxButtons.OK, kq.ThanhCong ? MessageBoxIcon.Information : MessageBoxIcon.Warning);

            if (kq.ThanhCong)
            {
                selectedBooks.Rows.Clear();
                TaiSachCon();
                TaiSachDangMuon();
                lblTrangThai.Text = "";
            }
        }

        private void TaiSachDangMuon()
        {
            if (string.IsNullOrWhiteSpace(MaDocGiaTra)) return;
            dgvDangMuon.DataSource = service.LaySachDangMuon(MaDocGiaTra);
            dgvDangMuon.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void btnTaiSachMuon_Click(object sender, EventArgs e) => TaiSachDangMuon();

        private void cboDocGiaTra_SelectedIndexChanged(object sender, EventArgs e) => TaiSachDangMuon();

        private void btnTraSach_Click(object sender, EventArgs e)
        {
            if (!(dgvDangMuon.CurrentRow?.DataBoundItem is DataRowView r))
            {
                MessageBox.Show("Vui lòng chọn sách cần trả.");
                return;
            }

            string maCT = Convert.ToString(r["MaChiTiet"]);
            KetQuaXuLy kq = service.TraSach(maCT, MaNhanVienTra, dtNgayTra.Value, Convert.ToString(cboTinhTrang.SelectedItem), numPhiPhat.Value);

            MessageBox.Show(kq.ThongBao, kq.ThanhCong ? "Thông báo" : "Lỗi",
                MessageBoxButtons.OK, kq.ThanhCong ? MessageBoxIcon.Information : MessageBoxIcon.Warning);

            if (kq.ThanhCong)
            {
                TaiSachDangMuon();
                TaiSachCon();
                numPhiPhat.Value = 0;
                cboTinhTrang.SelectedIndex = 0;
            }
        }

        private void btnDong_Click(object sender, EventArgs e) => Close();
    }
}