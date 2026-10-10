using System;
using System.Windows.Forms;

namespace DuLichVanHoaViet.Forms
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            this.Text = "HỆ THỐNG QUẢN LÝ CÔNG TY DU LỊCH VĂN HÓA VIỆT - SV: NGUYỄN PHI LONG (1250080106)";
            // Mở sẵn form Đăng ký đoàn vào container
            MoFormCon(new FrmDangKyDoan());
        }

        public void MoFormCon(Form formCon)
        {
            pnlContainer.Controls.Clear();
            formCon.TopLevel = false;
            formCon.FormBorderStyle = FormBorderStyle.None;
            formCon.Dock = DockStyle.Fill;
            pnlContainer.Controls.Add(formCon);
            pnlContainer.Tag = formCon;
            formCon.Show();
        }

        private void btnDangKyDoan_Click(object sender, EventArgs e)
        {
            lblStatus.Text = "Đang xử lý: Đăng ký tour theo đoàn (quy mô > 12 khách)";
            MoFormCon(new FrmDangKyDoan());
        }

        private void btnPhanCong_Click(object sender, EventArgs e)
        {
            lblStatus.Text = "Đang xử lý: Phân công hướng dẫn viên & kiểm tra trùng lịch";
            MessageBox.Show("Chức năng Phân công hướng dẫn viên: Kiểm tra không chồng chéo lịch trình theo BR10 & BR11.",
                            "Phân Công HDV", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnBangLuong_Click(object sender, EventArgs e)
        {
            lblStatus.Text = "Đang xử lý: Bảng lương tháng hướng dẫn viên";
            MessageBox.Show("Chức năng Bảng lương: Tổng hợp lương căn bản + thù lao các tour hoàn thành theo BR15.",
                            "Bảng Lương Tháng", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}