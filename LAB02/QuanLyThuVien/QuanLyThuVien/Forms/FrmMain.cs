using System;
using System.Windows.Forms;

namespace QuanLyThuVien.Forms
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }

        private void btnDanhMuc_Click(object sender, EventArgs e)
        {
            using (var f = new FrmDanhMuc()) f.ShowDialog(this);
        }

        private void btnSach_Click(object sender, EventArgs e)
        {
            using (var f = new FrmSach()) f.ShowDialog(this);
        }

        private void btnDocGia_Click(object sender, EventArgs e)
        {
            using (var f = new FrmDocGia()) f.ShowDialog(this);
        }

        private void btnMuonTra_Click(object sender, EventArgs e)
        {
            using (var f = new FrmMuonTra()) f.ShowDialog(this);
        }

        private void btnThongKe_Click(object sender, EventArgs e)
        {
            using (var f = new FrmThongKe()) f.ShowDialog(this);
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có thực sự muốn thoát chương trình?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                Close();
        }
    }
}