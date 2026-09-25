# BÁO CÁO THỰC HÀNH LAB 01

## 1. Thông tin sinh viên
- **Họ và tên:** Nguyễn Phi Long
- **Mã số sinh viên:** 1250080106
- **Lớp:** 12_ĐH_CNPM2
- **Email:** 1250080106@sv.hcmunre.edu.vn

---

## 2. Thông tin môi trường & Công cụ sử dụng
- **Hệ điều hành:** Windows 11 Home 64-bit
- **IDE:** IntelliJ IDEA 2026.2 (Community Edition)
- **Công cụ mô hình hóa / Thiết kế sơ đồ:**
  - Plugin IntelliJ: `plantuml4idea` (PlantUML Integration) / Draw.io / UML Modeling Tools
- **Bộ công cụ văn bản:** Microsoft Word (kết xuất tài liệu báo cáo nghiệm thu `.docx`)

---

## 3. Nội dung thực hiện

### 3.1. Bài 1: Hệ thống Thư viện Trực tuyến
1. **Phân tích yêu cầu chức năng:**
   - Nhóm chức năng Độc giả: Tìm kiếm tài liệu đa tiêu chí, đọc trực tuyến, tải file bằng mã thẻ thư viện, đăng ký mượn sách in, đăng ký/đăng nhập tài khoản, gửi đề xuất đặt mua tài liệu số.
   - Nhóm chức năng Thủ thư: Kế thừa quyền Độc giả, đăng nhập quản trị, quản lý mượn – trả sách, cập nhật danh mục sách & e-book, tra cứu tình trạng mượn/quá hạn, kiểm duyệt đơn đặt mua, kết xuất thống kê báo cáo.
   - Chức năng tự động: Tự động quét dữ liệu và kích hoạt gửi email nhắc hạn trả sách trước thời điểm hết hạn 3 ngày.
2. **Xây dựng bảng thuật ngữ hệ thống:** Chuẩn hóa định nghĩa 10 thuật ngữ cốt lõi (Độc giả, Thủ thư, Thẻ thư viện, Mã thẻ thư viện, Tài liệu điện tử, Sách thư viện, Đăng ký mượn, Yêu cầu đặt mua, Mạng Intranet, Hạn trả sách).
3. **Mô hình hóa Use Case:**
   - Xác định 4 tác nhân (Actors): `Độc giả`, `Thủ thư` (kế thừa Độc giả), `Hệ thống Email` (Secondary), `Đồng hồ hệ thống (Timer)` (Secondary).
   - Thiết lập và gán mã định danh cho 12 Use Cases (từ `UC01` đến `UC12`).
   - Xây dựng sơ đồ Use Case tổng thể có bao gồm các quan hệ `<<include>>`, `<<extend>>` và Generalization giữa các Actor.
   - Viết bảng đặc tả Use Case chi tiết cho toàn bộ 12 Use Cases theo đúng biểu mẫu chuẩn (ID, Tên, Tóm tắt, Tiền điều kiện, Hậu điều kiện, Luồng sự kiện chính Main Scenario, Luồng mở rộng Extensions, Vấn đề mở Open Issues).

### 3.2. Bài 2: Hệ thống Quản lý Cửa hàng Nước giải khát
1. **Mô hình hóa Use Case (Câu 1):**
   - Xác định Actor: `Nhân viên cửa hàng`, `Nhà cung ứng`, `Khách hàng` (phân rã kế thừa thành `Khách vãng lai` và `Khách quen`).
   - Xây dựng danh mục 7 Use Cases nghiệp vụ: Quản lý danh mục & nhãn hiệu, Đặt hàng NCC, Tiếp nhận giao hàng từ NCC, Bán hàng & thanh toán, Quản lý hẹn giao hàng, Quản lý công nợ (lập phiếu nợ), Thống kê và báo cáo.
   - Thiết kế sơ đồ Use Case nghiệp vụ cửa hàng nước giải khát.
2. **Thiết kế Lớp phân tích - Class Diagram (Câu 2):**
   - Định nghĩa chi tiết thuộc tính và phương thức cho 10 Lớp đối tượng: `NhanHieu`, `NuocGiaiKhat`, `NhaCungUng`, `DonDatHang`, `PhieuGiaoHang`, `KhachHang`, `HoaDon`, `PhieuHenGiaoHang`, `PhieuGhiNo`, `NhanVien`.
3. **Xác định mối quan hệ giữa các lớp (Câu 3):**
   - Thiết lập chính xác bản số (Multiplicity) và loại liên kết:
     - `NhanHieu` - `NuocGiaiKhat` (1 - n)
     - `NhaCungUng` - `NuocGiaiKhat` (1 - n)
     - `NhaCungUng` - `DonDatHang` (1 - n)
     - `DonDatHang` - `PhieuGiaoHang` (1 - n, tối đa 3 đợt)
     - `KhachHang` - `HoaDon` (1 - n)
     - `HoaDon` - `NuocGiaiKhat` (n - n)
     - `HoaDon` - `PhieuHenGiaoHang` (1 - n)
     - `HoaDon` - `PhieuGhiNo` (1 - 1, tùy chọn)
     - `NhanVien` với `HoaDon`, `PhieuGhiNo`, `DonDatHang` (1 - n).

---

## 4. Kết quả đạt được
- Hoàn thành đầy đủ hồ sơ phân tích yêu cầu cho cả 2 bài toán thực tế.
- Sơ đồ Use Case được thiết kế đúng cú pháp UML, thể hiện rõ vai trò kế thừa và mối quan hệ phụ thuộc giữa các chức năng.
- Bảng đặc tả 12 Use Case chi tiết, bao quát các trường hợp ngoại lệ (sai thông tin, thẻ quá hạn, tranh chấp sách khi hết kho, lỗi hệ thống gửi mail,...).
- Thiết kế hướng đối tượng (Class Diagram) chặt chẽ, thuộc tính và phương thức bám sát mô tả bài toán kinh doanh phân phối nước giải khát.

---
