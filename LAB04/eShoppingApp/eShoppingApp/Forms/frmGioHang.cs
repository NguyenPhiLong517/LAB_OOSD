using System;
using System.Data;
using System.Windows.Forms;

namespace eShopping.Forms
{
    public partial class frmGioHang : Form
    {
        private DataTable dtCart;

        public frmGioHang()
        {
            InitializeComponent();
        }

        private void frmGioHang_Load(object sender, EventArgs e)
        {
            KhoiTaoDuLieuGioHang();
            CapNhatTongTien();
        }

        private void KhoiTaoDuLieuGioHang()
        {
            dtCart = new DataTable();
            dtCart.Columns.Add("MaSP", typeof(string));
            dtCart.Columns.Add("TenSP", typeof(string));
            dtCart.Columns.Add("DonGia", typeof(decimal));
            dtCart.Columns.Add("SoLuong", typeof(int));
            dtCart.Columns.Add("ThanhTien", typeof(decimal));

            // Dữ liệu hàng hóa mẫu trong giỏ (mô phỏng đơn > 5M để kích hoạt miễn phí ship hỏa tốc)
            dtCart.Rows.Add("SP01", "Máy ảnh Sony Alpha A7 IV", 45000000m, 1, 45000000m);
            dtCart.Rows.Add("SP02", "Ống kính Sony FE 50mm", 5200000m, 1, 5200000m);

            dgvGioHang.DataSource = dtCart;

            dgvGioHang.Columns["MaSP"].HeaderText = "Mã Sản Phẩm";
            dgvGioHang.Columns["TenSP"].HeaderText = "Tên Sản Phẩm";
            dgvGioHang.Columns["DonGia"].HeaderText = "Đơn Giá (VNĐ)";
            dgvGioHang.Columns["DonGia"].DefaultCellStyle.Format = "N0";
            dgvGioHang.Columns["SoLuong"].HeaderText = "Số Lượng Mua";
            dgvGioHang.Columns["ThanhTien"].HeaderText = "Thành Tiền (VNĐ)";
            dgvGioHang.Columns["ThanhTien"].DefaultCellStyle.Format = "N0";

            dgvGioHang.Columns["MaSP"].ReadOnly = true;
            dgvGioHang.Columns["TenSP"].ReadOnly = true;
            dgvGioHang.Columns["DonGia"].ReadOnly = true;
            dgvGioHang.Columns["ThanhTien"].ReadOnly = true;
        }

        private void CapNhatTongTien()
        {
            decimal tong = 0;
            foreach (DataRow row in dtCart.Rows)
            {
                tong += Convert.ToDecimal(row["ThanhTien"]);
            }
            lblTongTien.Text = tong.ToString("N0") + " VNĐ";
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            foreach (DataRow row in dtCart.Rows)
            {
                int sl = Convert.ToInt32(row["SoLuong"]);
                if (sl <= 0)
                {
                    MessageBox.Show("Số lượng mua phải lớn hơn 0!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    row["SoLuong"] = 1;
                }
                decimal gia = Convert.ToDecimal(row["DonGia"]);
                row["ThanhTien"] = Convert.ToInt32(row["SoLuong"]) * gia;
            }
            CapNhatTongTien();
            MessageBox.Show("Cập nhật giỏ hàng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dgvGioHang.SelectedRows.Count > 0)
            {
                dgvGioHang.Rows.RemoveAt(dgvGioHang.SelectedRows[0].Index);
                CapNhatTongTien();
            }
            else
            {
                MessageBox.Show("Vui lòng chọn dòng sản phẩm cần xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnTiepTucMua_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnTienHanhDatHang_Click(object sender, EventArgs e)
        {
            decimal tongTien = 0;
            foreach (DataRow row in dtCart.Rows)
            {
                tongTien += Convert.ToDecimal(row["ThanhTien"]);
            }

            if (tongTien <= 0)
            {
                MessageBox.Show("Giỏ hàng đang trống! Vui lòng chọn sản phẩm.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Chuyển trực tiếp sang Form Đặt Hàng & Thanh Toán
            frmThanhToan frm = new frmThanhToan(tongTien);
            frm.ShowDialog();
        }
    }
}