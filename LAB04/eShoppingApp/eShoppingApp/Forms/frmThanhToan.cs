using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace eShopping.Forms
{
    public partial class frmThanhToan : Form
    {
        private decimal tongTienHang = 50200000m; // Mặc định từ giỏ sang
        private decimal phiShip = 0m;

        public frmThanhToan()
        {
            InitializeComponent();
        }

        // Constructor nhận tổng tiền truyền sang từ giỏ hàng
        public frmThanhToan(decimal tienHangTuGio) : this()
        {
            this.tongTienHang = tienHangTuGio;
        }

        private void frmThanhToan_Load(object sender, EventArgs e)
        {
            cboKhuVuc.Items.AddRange(new string[] { "Nội thành", "Ngoại thành", "Tỉnh khác" });
            cboKhuVuc.SelectedIndex = 0;

            cboLoaiThe.Items.AddRange(new string[] { "VISA", "Master", "Discover", "American Express" });
            cboLoaiThe.SelectedIndex = 0;

            TinhTongThanhToan();
        }

        private void CapNhatGia(object sender, EventArgs e)
        {
            TinhTongThanhToan();
        }

        private void TinhTongThanhToan()
        {
            // Bảng cước cơ bản: Nội thành = 20k, Ngoại thành = 30k, Tỉnh = 45k
            decimal cuocKhuVuc = 20000m;
            if (cboKhuVuc.SelectedIndex == 1) cuocKhuVuc = 30000m;
            else if (cboKhuVuc.SelectedIndex == 2) cuocKhuVuc = 45000m;

            if (radTrongNgay.Checked)
            {
                // Quy tắc: Đơn >= 5.000.000 đ thì MIỄN PHÍ giao nhanh trong ngày
                if (tongTienHang >= 5000000m)
                    phiShip = 0m;
                else
                    phiShip = cuocKhuVuc + 40000m;
            }
            else if (radNhanh.Checked)
            {
                // Quy tắc: Đơn >= 1.000.000 đ thì MIỄN PHÍ giao nhanh
                if (tongTienHang >= 1000000m)
                    phiShip = 0m;
                else
                    phiShip = cuocKhuVuc + 15000m;
            }
            else
            {
                phiShip = cuocKhuVuc;
            }

            lblTienHang.Text = tongTienHang.ToString("N0") + " VNĐ";
            lblPhiShip.Text = phiShip == 0 ? "0 VNĐ (Được miễn phí)" : phiShip.ToString("N0") + " VNĐ";
            lblTongCong.Text = (tongTienHang + phiShip).ToString("N0") + " VNĐ";
        }

        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            string loaiThe = cboLoaiThe.SelectedItem.ToString();
            string soThe = txtSoThe.Text.Replace(" ", "").Trim();
            string csv = txtCSV.Text.Trim();

            // 1. Kiểm tra định dạng thẻ tín dụng theo đúng đặc tả Lab 4
            if (loaiThe == "American Express")
            {
                if (!Regex.IsMatch(soThe, @"^\d{15}$") || !Regex.IsMatch(csv, @"^\d{4}$"))
                {
                    MessageBox.Show("Thẻ American Express yêu cầu số thẻ đủ 15 chữ số và mã CSV gồm 4 chữ số!",
                                    "Lỗi thẻ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            else // VISA, Master, Discover
            {
                if (!Regex.IsMatch(soThe, @"^\d{16}$") || !Regex.IsMatch(csv, @"^\d{3}$"))
                {
                    MessageBox.Show($"Thẻ {loaiThe} yêu cầu số thẻ đủ 16 chữ số và mã CSV gồm 3 chữ số!",
                                    "Lỗi thẻ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            // 2. Bảo mật: Che số thẻ (chỉ giữ lại 4 số cuối)
            string soTheChe = new string('*', soThe.Length - 4) + soThe.Substring(soThe.Length - 4);
            decimal tongThanhToan = tongTienHang + phiShip;

            // 3. Thông báo hoàn tất
            string thongBao = "=== GIAO DỊCH THÀNH CÔNG ===\n\n" +
                              $"Khách hàng: NGUYỄN PHI LONG (MSSV: 1250080106)\n" +
                              $"Người nhận: {txtHoTen.Text}\n" +
                              $"Địa chỉ nhận: {txtDiaChi.Text} ({cboKhuVuc.SelectedItem})\n" +
                              $"Thẻ thanh toán: {loaiThe} ({soTheChe})\n" +
                              $"Tổng tiền thanh toán: {tongThanhToan:N0} VNĐ\n\n" +
                              "Hệ thống đã lưu hóa đơn và gửi email xác nhận thành công!";

            MessageBox.Show(thongBao, "Thông Báo e-SHOPPING", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}