# BÁO CÁO KẾT QUẢ THỰC HIỆN - LAB 06

## 1. THÔNG TIN SINH VIÊN & BÀI THỰC HÀNH
* **Họ và tên sinh viên:** Nguyễn Phi Long[cite: 12]
* **Mã số sinh viên (MSSV):** 1250080106[cite: 12]
* **Lớp:** 12_ĐH_CNPM2[cite: 12]
* **Tên bài thực hành:** LAB 06 — Hệ thống Quản lý Hồ sơ Bệnh án.[cite: 12]
* **Khoa / Trường:** Khoa Công nghệ Thông tin — Đại học Tài nguyên và Môi trường TP.HCM

---

## 2. MÔI TRƯỜNG & PHIÊN BẢN (ENVIRONMENT & VERSIONS)
* **Hệ điều hành:** Windows 10 / Windows 11 64-bit
* **IDE / Trình soạn thảo:** Microsoft Visual Studio 2022
* **Nền tảng / Target Framework:** C# Windows Forms (.NET Framework 4.7.2)
* **Hệ quản trị CSDL:** Microsoft SQL Server 2019 / 2022 (T-SQL)
* **Thư viện tham chiếu bắt buộc:** `System.Data.SqlClient`, `System.Configuration`

---

## 3. NỘI DUNG ĐÃ THỰC HIỆN
1. **Khảo sát nghiệp vụ & Xây dựng mô hình phân tích:**
   * Khảo sát 5 tác nhân (Actor): Bệnh nhân, Nhân viên CSKH/Tiếp nhận, Bác sĩ, Nhân viên xét nghiệm, Thu ngân[cite: 12].
   * Xây dựng 9 Use Case chính (UC01–UC09) và các sơ đồ phân rã: Tiếp nhận bệnh nhân, Khám bệnh điều trị, Xét nghiệm, Thanh toán xuất viện, Đặt lịch khám định kỳ, Báo cáo thống kê[cite: 12].
   * Cài đặt 10 quy tắc nghiệp vụ cốt lõi (BR01–BR10): Cấp mã HSBA duy nhất sau khi đóng lệ phí năm (BR01, BR03); miễn phí khám định kỳ theo quý cho bệnh nhân đã có HSBA (BR08); quyết toán 100% viện phí trước khi xuất viện và khóa hồ sơ bệnh án (BR09, BR10)[cite: 12].
2. **Thiết kế Cơ sở Dữ liệu quan hệ chuẩn hóa:**
   * Ánh xạ từ 11 lớp thực thể miền không gian bài toán sang CSDL `QuanLyHoSoBenhAn`[cite: 12].
   * Thiết lập quan hệ 1-1 giữa `BenhNhan` và `HoSoBenhAn` thông qua khóa ngoại `MaBenhNhan UNIQUE` (BR01)[cite: 12].
   * Thiết lập quan hệ nhiều - nhiều giữa `PhieuKham` và `Thuoc` thông qua bảng liên kết `ChiTietToaThuoc (MaPhieuKham, MaThuoc)`[cite: 12].
   * Quản lý giao dịch thanh toán nhiều đợt thông qua quan hệ 1-n giữa `HoaDonVienPhi` và `GiaoDichThanhToan`[cite: 12].
   * Bổ sung bảng nhật ký truy cập `NhatKyTruyCap` để đảm bảo Audit Log bảo mật thông tin y tế (UC03)[cite: 12].
3. **Hiện thực giao diện WinForms theo kiến trúc phân tầng (3-Tier):**
   * **`Data/DBHelper.cs`:** Quản lý chuỗi kết nối và thực thi các câu lệnh truy vấn, Transaction[cite: 12].
   * **`Services/`:** Triển khai các dịch vụ `BenhNhanService`, `KhamBenhService`, `ThanhToanService` kiểm soát quy tắc nghiệp vụ trước khi lưu CSDL[cite: 12].
   * **`Forms/`:** Xây dựng hệ thống form điều hướng `FrmMain` và các màn hình nghiệp vụ chi tiết: `FrmBenhNhan`, `FrmHoSoBenhAn`, `FrmTraCuuHoSo`, `FrmLichKham`, `FrmKhamBenh`, `FrmXetNghiem`, `FrmToaThuoc`, `FrmThanhToan`, `FrmThongKe`[cite: 12].

---

## 4. KẾT QUẢ ĐẠT ĐƯỢC
* Kịch bản SQL `QuanLyHoSoBenhAn.sql` thực thi hoàn chỉnh không lỗi trên SQL Server: thiết lập đầy đủ khóa chính (PK), khóa ngoại (FK), các ràng buộc toàn vẹn `CHECK`, cột tính toán `PERSISTED` (`TongTien`, `SoTienPhaiTra`) và các chỉ mục `INDEX` tối ưu tốc độ tra cứu[cite: 12].
* Ứng dụng WinForms biên dịch thành công (`Build: 1 succeeded, 0 failed`), không phát sinh lỗi cảnh báo.
* Giao diện hoạt động đúng luồng nghiệp vụ:
  * Tiếp nhận đăng ký bệnh nhân mới kèm ảnh 3x4 và CCCD/CMND[cite: 12].
  * Cấp mã HSBA và thu lệ phí quản lý khám định kỳ ban đầu[cite: 12].
  * Bác sĩ mở phiên khám, ghi nhận triệu chứng lâm sàng, chỉ định xét nghiệm và kê toa thuốc[cite: 12].
  * Thu ngân tổng hợp viện phí, thực hiện giao dịch thanh toán, tự động trừ tiền BHYT chi trả và khóa trạng thái bệnh án sau xuất viện[cite: 12].

---

## 5. HƯỚNG DẪN KIỂM TRA & CHẠY LẠI (DÀNH CHO GIẢNG VIÊN)

1. **Khởi tạo Cơ sở Dữ liệu:**
   * Mở phần mềm **SQL Server Management Studio (SSMS)**.
   * Mở file script SQL của đồ án (hoặc chạy đoạn script tạo bảng trong mục 4.4 của tài liệu báo cáo) để tự động tạo CSDL `QuanLyHoSoBenhAn` và các bảng liên kết[cite: 12].
2. **Cấu hình chuỗi kết nối:**
   * Mở Solution bằng **Visual Studio 2022**.
   * Mở file **`App.config`**, kiểm tra và cập nhật `connectionString` cho đúng với tên SQL Server trên máy chấm bài (Ví dụ: `Data Source=.;Initial Catalog=QuanLyHoSoBenhAn;Integrated Security=True;`).
3. **Biên dịch & Khởi chạy:**
   * Nhấn tổ hợp phím **Ctrl + Shift + B** để Build toàn bộ Solution (đảm bảo `0 errors`).
   * Nhấn **F5** (hoặc nút **Start**) để khởi chạy màn hình chính `FrmMain`[cite: 12].
4. **Kiểm tra chức năng theo quy trình:**
   * **Bước 1 (Đăng ký & Cấp HSBA):** Mở `FrmBenhNhan` nhập thông tin bệnh nhân mới[cite: 12], sau đó sang `FrmHoSoBenhAn` tạo mã hồ sơ và xác nhận đóng lệ phí ban đầu[cite: 12].
   * **Bước 2 (Khám & Chỉ định):** Mở `FrmKhamBenh` chọn mã hồ sơ vừa tạo, nhập triệu chứng, chẩn đoán và bấm lưu phiếu khám[cite: 12].
   * **Bước 3 (Kê toa & Xét nghiệm):** Mở `FrmToaThuoc` chọn mã phiếu khám để kê đơn thuốc và kiểm tra đơn giá thành tiền[cite: 12].
   * **Bước 4 (Thanh toán & Đóng hồ sơ):** Mở `FrmThanhToan` tổng hợp chi phí đợt khám, thực hiện thanh toán đủ 100% để kiểm tra việc cập nhật trạng thái hồ sơ bệnh án sang "Đã đóng/Lưu trữ"[cite: 12].
