# BÁO CÁO THỰC HÀNH LAB 04: HỆ THỐNG CỬA HÀNG ONLINE "e-SHOPPING"

## 1. Thông tin sinh viên
- **Họ và tên:** Nguyễn Phi Long
- **Mã số sinh viên:** 1250080106
- **Lớp:** 12_ĐH_CNPM2
- **Email:** 1250080106@sv.hcmunre.edu.vn
- **Tên bài thực hành:** Lab 04 - Phân tích, Thiết kế và Cài đặt Hệ thống Cửa hàng Trực tuyến e-Shopping

---

## 2. Thông tin môi trường & Công cụ sử dụng
- **Hệ điều hành:** Windows 11 Home 64-bit
- **Môi trường phát triển (IDE):** Microsoft Visual Studio 2022
- **Hệ quản trị CSDL:** Microsoft SQL Server (Instance: `PHI-LONG\KTEAM` / LocalDB)
- **Nền tảng công nghệ:** .NET Framework 4.7.2, Windows Forms App (C#), ADO.NET (`System.Data.SqlClient`)
- **Công cụ thiết kế & mô hình hóa:** Draw.io, UML Modeling Tools, SQL Server Management Studio (SSMS)

---

## 3. Nội dung thực hiện

### 3.1. Phân tích & Đặc tả Yêu cầu Hệ thống
1. **Xác định các Tác nhân (Actors):**
   - **Khách hàng (Customer - Primary Actor):** Duyệt danh mục sản phẩm, quản lý giỏ hàng, đăng ký tài khoản, lựa chọn phương thức giao hàng và thanh toán
   - **Hệ thống Quản lý Sản phẩm (Product Management System - External System):** Cung cấp thông tin sản phẩm, danh mục, thông số kỹ thuật và số lượng tồn kho khả dụng
   - **Hệ thống Cổng Thanh toán Trực tuyến (Payment Gateway - External System):** Xác thực thông tin thẻ tín dụng, kiểm tra tính hợp lệ và trừ tiền[cite: 79].
   - **Dịch vụ Email (Email Service - External System):** Tự động gửi email xác nhận đặt hàng thành công đến địa chỉ thư điện tử của khách hàng[cite: 79].
   - **Quản trị viên (Admin):** Quản lý nhóm sản phẩm, nhà sản xuất và tài khoản người dùng[cite: 79].

2. **Cài đặt Quy tắc nghiệp vụ (Business Rules - BR):**
   - **Giao hàng & Miễn phí cước vận chuyển:**
     - Hỗ trợ 3 hình thức giao nhận: *Phiếu đặt hàng thường*, *Phiếu chuyển phát nhanh*, *Phiếu chuyển phát nhanh trong ngày*[cite: 79, 80].
     - Miễn phí chuyển phát nhanh cho đơn hàng có tổng trị giá $\ge 1.000.000$ VNĐ[cite: 79, 80].
     - Miễn phí chuyển phát nhanh trong ngày (Hỏa tốc) cho đơn hàng có tổng trị giá $\ge 5.000.000$ VNĐ[cite: 79, 80].
     - Công thức tính: $\text{Tổng thanh toán} = \text{Tiền hàng} + \text{Phí giao hàng} + \text{Lệ phí thẻ}$[cite: 79, 80].
   - **Ràng buộc an ninh Thẻ tín dụng:**
     - VISA, MasterCard, Discover: Số thẻ chuẩn 16 chữ số; mã an ninh CSV/CVV gồm 3 chữ số[cite: 79, 80].
     - American Express (Amex): Số thẻ chuẩn 15 chữ số; mã an ninh CSV gồm 4 chữ số[cite: 79, 80].
     - Ngày hết hạn của thẻ phải sau ngày giao dịch hiện tại của hệ thống[cite: 79].
     - Bảo mật an toàn: Tuyệt đối không lưu mã CSV/CVV vào CSDL và chỉ lưu số thẻ ở dạng che dấu (`************1234`)[cite: 79, 80].

### 3.2. Mô hình hóa Hệ thống theo chuẩn UML
1. **Biểu đồ Use Case & Phân rã:**
   - Xây dựng Use Case Diagram tổng quát: Đặt mua hàng, Xem sản phẩm, Đăng nhập, Đăng ký, Giỏ hàng, Thanh toán, Quản lý sản phẩm, Quản lý tài khoản[cite: 79].
   - Phân rã và lập bảng đặc tả Use Case chi tiết:
     - `UC_GH_001 - Giỏ hàng`: Xem danh sách, loại bỏ sản phẩm, cập nhật số lượng[cite: 79].
     - `UC_DMH_001 - Đặt mua hàng`: Chọn loại phiếu giao hàng, tính phí vận chuyển và khởi tạo đơn hàng[cite: 79].
     - `UC_QLNSP_001 - Quản lý nhóm sản phẩm`: Quản lý danh mục, nhà sản xuất và sản phẩm chi tiết[cite: 79].
     - `UC_QLTK_001 - Quản lý tài khoản`: Quản lý hồ sơ cá nhân và email liên kết của khách hàng[cite: 79].
2. **Biểu đồ Lớp (Class Diagram) & Áp dụng Design Pattern:**
   - **Lớp thực thể:** `KhachHang`, `SanPham`, `DonHang`, `ChiTietDonHang`[cite: 79].
   - **Kế thừa Giao hàng:** Lớp trừu tượng `PhieuGiaoHang` với phương thức `tinhPhiGiaoHang()`, được kế thừa bởi `GiaoHangThuong`, `GiaoHangNhanh`, `GiaoHangTrongNgay`[cite: 79].
   - **Adapter Pattern cho Thanh toán:** Thiết kế Interface `IPaymentGateway` (`validateCard`, `charge`) và lớp `OnlinePaymentAdapter` để bao bọc (wrap) việc giao tiếp với cổng thanh toán bên thứ ba[cite: 79].
3. **Biểu đồ Động (Dynamic Diagrams):**
   - **State Machine Diagram (Biểu đồ trạng thái):**
     - Vòng đời đơn hàng: `KhoiTao` $\rightarrow$ `ChoThanhToan` $\rightarrow$ `DaThanhToan` $\rightarrow$ `DangGiaoHang` $\rightarrow$ `HoanTat` (hoặc chuyển sang `DaHuy` nếu thanh toán/giao hàng thất bại)[cite: 79].
     - Vòng đời sản phẩm: `ConHang` $\rightarrow$ `TamHetHang` (khi tồn kho $= 0$) $\rightarrow$ `NgungKinhDoanh`[cite: 79].
   - **Sequence Diagram (Biểu đồ tuần tự):** Mô hình hóa quy trình Thêm sản phẩm vào giỏ hàng giữa Khách hàng, `frmChiTietSP`, `CartService` và `ProductAdapter` kiểm tra tồn kho[cite: 79].

### 3.3. Xây dựng Cơ sở dữ liệu SQL Server (`eShopping`)
- Thiết kế 11 bảng chuẩn hóa quan hệ: `NhomSanPham`, `SanPham`, `KhachHang`, `ChiTietGioHang`, `KhuVuc`, `LoaiPhieu`, `PhiGiaoHang`, `LoaiThe`, `NguoiNhan`, `DonHang`, `ChiTietDonHang`[cite: 80].
- Cài đặt Hàm & Thủ tục nghiệp vụ tối ưu:
  - `fn_PhiGiaoHang`: Hàm tự động tính cước và áp dụng miễn phí vận chuyển theo hạn mức hóa đơn[cite: 80].
  - `sp_ThemVaoGio`: Thủ tục sử dụng lệnh `MERGE` để thêm mới hoặc cộng dồn số lượng mặt hàng trong giỏ[cite: 80].
  - `sp_DatHang`: Thủ tục bọc trong `SqlTransaction` để chốt đơn hàng, lưu thông tin người nhận, lưu số thẻ che bảo mật, chuyển chi tiết giỏ hàng sang chi tiết đơn hàng và làm sạch giỏ hàng[cite: 80].

### 3.4. Xây dựng Giao diện WinForms
- **`FrmMain`:** Màn hình chính chứa thanh điều hướng banner và nhúng động các phân hệ[cite: 79].
- **`FrmGioHang`:** Bảng DataGridView hiển thị danh sách mặt hàng, tính thành tiền, cập nhật số lượng, xóa món và nút tiến hành đặt hàng[cite: 79].
- **`FrmThanhToan`:** Phân nhóm trực quan gồm 4 khối chức năng:
  1. *Thông tin người nhận hàng* (Họ tên, SĐT, Địa chỉ, Khu vực)[cite: 79].
  2. *Chọn loại phiếu giao hàng* (Radio button tự động tính lại cước)[cite: 79].
  3. *Thông tin thẻ tín dụng* (Kiểm tra định dạng thẻ, tự động che số thẻ an toàn)[cite: 79].
  4. *Tổng kết chi phí hóa đơn* (Hiển thị tiền hàng, cước vận chuyển, tổng cộng và nút xác nhận thanh toán)[cite: 79].

---

## 4. Kết quả đạt được
- Hoàn thiện tài liệu phân tích thiết kế phần mềm với đầy đủ các sơ đồ Use Case, Class Diagram, State Machine, Sequence Diagram[cite: 79].
- CSDL `eShopping` được triển khai hoàn chỉnh với đầy đủ dữ liệu mẫu và stored procedure nghiệp vụ[cite: 80].
- Logic tính cước giao hàng và miễn phí cước vận chuyển được kiểm thử đạt chuẩn 100%:
  - Đơn hàng $\ge 1.000.000$ VNĐ: Cước chuyển phát nhanh tự động về $0$ VNĐ[cite: 79, 80].
  - Đơn hàng $\ge 5.000.000$ VNĐ: Cước chuyển phát nhanh trong ngày tự động về $0$ VNĐ[cite: 79, 80].
- Giao diện WinForms hoạt động ổn định, phân tách rõ ràng người mua và người nhận, thông tin thanh toán trực quan và bảo mật[cite: 79].
