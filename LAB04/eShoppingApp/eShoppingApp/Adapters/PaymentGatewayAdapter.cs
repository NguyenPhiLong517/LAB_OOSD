using System.Text.RegularExpressions;

namespace eShopping_NguyenPhiLong.Adapters
{
    public class PaymentGatewayAdapter
    {
        // Kiểm tra đúng định dạng theo đề bài yêu cầu
        public bool ValidateCreditCard(string loaiThe, string soThe, string csv)
        {
            soThe = soThe.Replace(" ", "").Trim();
            csv = csv.Trim();

            if (loaiThe == "American Express")
            {
                // Amex: 15 số, CSV 4 số
                return Regex.IsMatch(soThe, @"^\d{15}$") && Regex.IsMatch(csv, @"^\d{4}$");
            }
            else // VISA, Master, Discover
            {
                // Visa/Master/Discover: 16 số, CSV 3 số
                return Regex.IsMatch(soThe, @"^\d{16}$") && Regex.IsMatch(csv, @"^\d{3}$");
            }
        }

        // Tạo chuỗi che số thẻ bảo mật (VD: ************1234)
        public string MaskCardNumber(string soThe)
        {
            soThe = soThe.Replace(" ", "").Trim();
            if (soThe.Length >= 4)
            {
                return new string('*', soThe.Length - 4) + soThe.Substring(soThe.Length - 4);
            }
            return soThe;
        }

        // Giả lập gửi thông tin sang cổng thanh toán ngoài
        public bool ChargeMoney(string soThe, decimal tongTien)
        {
            return true; // Giả lập ngân hàng phê duyệt thành công
        }
    }
}