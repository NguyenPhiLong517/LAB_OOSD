namespace eShopping_NguyenPhiLong.BUS
{
    public class ShippingCalculator
    {
        // 1: Thường, 2: Chuyển phát nhanh, 3: Chuyển phát nhanh trong ngày
        public decimal TinhCuocPhi(int maLoaiPhieu, decimal tienHang, decimal cuocChuan)
        {
            // Nghiệp vụ: Đơn hàng >= 5 triệu miễn phí giao nhanh trong ngày
            if (maLoaiPhieu == 3 && tienHang >= 5000000m)
                return 0m;

            // Nghiệp vụ: Đơn hàng >= 1 triệu miễn phí chuyển phát nhanh
            if (maLoaiPhieu == 2 && tienHang >= 1000000m)
                return 0m;

            return cuocChuan;
        }
    }
}