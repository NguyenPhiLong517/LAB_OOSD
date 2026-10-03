using System;
using System.Windows.Forms;

namespace eShopping.Forms
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            this.Text = "HỆ THỐNG CỬA HÀNG TRỰC TUYẾN e-SHOPPING - LAB 04 - SV: NGUYỄN PHI LONG (1250080106)";
            lblTrangThai.Text = "Sẵn sàng | Đã đồng bộ với Hệ thống Quản lý Sản phẩm";

            // Mặc định khi mở ứng dụng, hiển thị sẵn màn hình Giỏ Hàng vào giữa
            MoFormCon(new frmGioHang());
        }

        // Hàm nhúng Form con trực tiếp vào panel trung tâm pnlContainer
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

        // Nhấp nút Giỏ Hàng -> mở frmGioHang vào giữa giao diện
        private void btnGioHang_Click(object sender, EventArgs e)
        {
            lblTrangThai.Text = "Đang xem: Chi tiết giỏ hàng hiện tại";
            MoFormCon(new frmGioHang());
        }

        // Nhấp nút Đặt Hàng & Thanh Toán -> mở frmThanhToan vào giữa giao diện
        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            lblTrangThai.Text = "Đang xử lý: Đặt hàng và thanh toán trực tuyến";
            MoFormCon(new frmThanhToan());
        }

        // Nhấp nút Sản Phẩm
        private void btnXemSanPham_Click(object sender, EventArgs e)
        {
            lblTrangThai.Text = "Đang xem: Danh mục nhóm sản phẩm nội bộ";
            MessageBox.Show("Chức năng: Lấy danh mục và thông tin tồn kho từ Hệ thống Quản lý Sản phẩm.",
                            "Sản Phẩm", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // Nhấp nút Tài Khoản
        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            lblTrangThai.Text = "Đang xem: Quản lý thông tin tài khoản khách hàng";
            MessageBox.Show("Chức năng: Đăng ký thành viên mới hoặc Xác thực tài khoản khách hàng.",
                            "Tài Khoản", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}