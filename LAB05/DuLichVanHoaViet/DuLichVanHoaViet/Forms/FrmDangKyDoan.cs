using System;
using System.Data;
using System.Windows.Forms;
using DuLichVanHoaViet.Services;

namespace DuLichVanHoaViet.Forms
{
    public partial class FrmDangKyDoan : Form
    {
        private TourService tourService = new TourService();
        private DataTable dtTour;
        private decimal tongTienDuKien = 0;

        public FrmDangKyDoan()
        {
            InitializeComponent();
        }

        private void FrmDangKyDoan_Load(object sender, EventArgs e)
        {
            LoadDanhSachTour();
        }

        private void LoadDanhSachTour()
        {
            dtTour = tourService.LayDanhSachTour();
            cboTour.DataSource = dtTour;
            cboTour.DisplayMember = "TenTour";
            cboTour.ValueMember = "MaTour";

            if (dtTour != null && dtTour.Rows.Count > 0)
            {
                cboTour.SelectedIndex = 0;
                TinhChiPhiVaNgayVe();
            }
        }

        private void TinhChiPhiVaNgayVe()
        {
            if (cboTour.SelectedValue == null || !(cboTour.SelectedValue is int)) return;

            DataRowView row = (DataRowView)cboTour.SelectedItem;
            int soNgay = Convert.ToInt32(row["SoNgay"]);
            decimal donGia = Convert.ToDecimal(row["DonGiaKhach"]);

            // Tính ngày về dự kiến
            dtpNgayVe.Value = tourService.TinhNgayVe(dtpNgayDi.Value, soNgay);

            // Tính tổng tiền dự kiến
            if (int.TryParse(txtSoNguoi.Text, out int soNguoi) && soNguoi > 0)
            {
                tongTienDuKien = soNguoi * donGia;
                lblTongTien.Text = tongTienDuKien.ToString("N0") + " VNĐ";
            }
            else
            {
                lblTongTien.Text = "0 VNĐ";
            }
        }

        private void cboTour_SelectedIndexChanged(object sender, EventArgs e)
        {
            TinhChiPhiVaNgayVe();
        }

        private void dtpNgayDi_ValueChanged(object sender, EventArgs e)
        {
            TinhChiPhiVaNgayVe();
        }

        private void txtSoNguoi_TextChanged(object sender, EventArgs e)
        {
            TinhChiPhiVaNgayVe();
        }

        private void btnLuuPhieu_Click(object sender, EventArgs e)
        {
            // 1. Kiểm tra trường bắt buộc
            if (string.IsNullOrWhiteSpace(txtTenCoQuan.Text) || string.IsNullOrWhiteSpace(txtDienThoai.Text) ||
                string.IsNullOrWhiteSpace(txtNguoiDaiDien.Text) || string.IsNullOrWhiteSpace(txtDiemDon.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ các trường thông tin bắt buộc!", "Thiếu dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 2. Kiểm tra quy tắc BR03: Khách đoàn phải > 12 người
            if (!int.TryParse(txtSoNguoi.Text, out int soNguoi))
            {
                MessageBox.Show("Số người phải là số nguyên hợp lệ!", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (soNguoi == 12)
            {
                MessageBox.Show("Số lượng đúng 12 người chưa có quy định cụ thể, vui lòng xác nhận chính sách công ty!", "Chờ xác nhận", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (!tourService.KiemTraSoLuongDoan(soNguoi))
            {
                MessageBox.Show("Khách theo đoàn phải trên 12 người! Dưới 12 người vui lòng chuyển sang đăng ký khách lẻ theo chuyến.", "Không đủ điều kiện đoàn", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 3. Tiền đặt cọc
            if (!decimal.TryParse(txtTienCoc.Text, out decimal tienCoc) || tienCoc < 0)
            {
                MessageBox.Show("Tiền đặt cọc không hợp lệ!", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 4. Lưu phiếu qua Service (Transaction)
            int maTour = (int)cboTour.SelectedValue;
            bool thanhCong = tourService.LuuDangKyDoan(
                maTour, txtTenCoQuan.Text.Trim(), txtDiaChi.Text.Trim(), txtDienThoai.Text.Trim(),
                txtNguoiDaiDien.Text.Trim(), soNguoi, dtpNgayDi.Value, dtpNgayVe.Value,
                txtDiemDon.Text.Trim(), chkMuaBaoHiem.Checked, tienCoc, tongTienDuKien
            );

            if (thanhCong)
            {
                string msg = "=== LẬP PHIẾU ĐĂNG KÝ ĐOÀN THÀNH CÔNG ===\n\n" +
                             $"Cơ quan: {txtTenCoQuan.Text}\n" +
                             $"Người đại diện: {txtNguoiDaiDien.Text}\n" +
                             $"Số lượng: {soNguoi} khách\n" +
                             $"Ngày đi: {dtpNgayDi.Value:dd/MM/yyyy} - Ngày về: {dtpNgayVe.Value:dd/MM/yyyy}\n" +
                             $"Tổng dự kiến: {tongTienDuKien:N0} VNĐ\n" +
                             $"Đã đặt cọc: {tienCoc:N0} VNĐ\n\n" +
                             "Phiếu đã được ghi nhận vào cơ sở dữ liệu!";
                MessageBox.Show(msg, "Thông Báo Thành Công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else
            {
                MessageBox.Show("Lỗi trong quá trình lưu dữ liệu vào CSDL! Vui lòng kiểm tra lại kết nối.", "Lỗi CSDL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}