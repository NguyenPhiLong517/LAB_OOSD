# BÁO CÁO KẾT QUẢ THỰC HIỆN - LAB 05 (BÀI 6)

## 1. THÔNG TIN SINH VIÊN & BÀI THỰC HÀNH
* **Họ và tên:** Nguyễn Phi Long
* **Mã số sinh viên (MSSV):** 1250080106
* **Lớp:** 12_ĐH_CNPM2
* **Tên bài thực hành:** LAB 05 — Quản lý Công ty Du lịch Văn Hóa Việt TP.HCM (Bài 6)

---

## 2. MÔI TRƯỜNG & PHIÊN BẢN (ENVIRONMENT & VERSIONS)
* **IDE / Trình soạn thảo:** Microsoft Visual Studio 2022
* **Nền tảng / Target Framework:** C# Windows Forms (.NET Framework 4.7.2)
* **Hệ quản trị CSDL:** Microsoft SQL Server 2019 / 2022
* **Thư viện kết nối CSDL:** `System.Data.SqlClient`, `System.Configuration`

---

## 3. NỘI DUNG ĐÃ THỰC HIỆN
1. **Thiết kế CSDL quan hệ:** 
   * Áp dụng đầy đủ 5 quy tắc chuyển đổi lược đồ lớp sang mô hình quan hệ.
   * Cài đặt kế thừa 2 tầng: `PHIEU_DANG_KY` (cha) $\rightarrow$ `PHIEU_DANG_KY_DOAN` & `PHIEU_DANG_KY_CHUYEN` (con).
   * Cài đặt quan hệ nhiều - nhiều giữa `TOUR` và `DIEM_THAM_QUAN` qua bảng trung gian `CHI_TIET_THAM_QUAN`.
2. **Xây dựng ứng dụng WinForms theo kiến trúc 3 lớp (3-Tier):**
   * **Data Layer (`DBHelper.cs`):** Quản lý kết nối SQL Server và thực thi truy vấn/transaction.
   * **Service Layer (`TourService.cs`):** Xử lý nghiệp vụ (kiểm tra đoàn $> 12$ người, tính ngày về dự kiến, tính tổng tiền, lưu phiếu đoàn qua `SqlTransaction`).
   * **Presentation / Forms Layer:**
     * `FrmMain.cs`: Màn hình điều hướng trung tâm, nhúng Form con vào Panel hiển thị.
     * `FrmDangKyDoan.cs`: Giao diện lập phiếu đăng ký tour theo đoàn, tự động tính chi phí và bắt lỗi nghiệp vụ.

---

## 4. KẾT QUẢ ĐẠT ĐƯỢC
* CSDL tạo thành công trên SQL Server với đầy đủ khóa chính (PK), khóa ngoại (FK), các ràng buộc `CHECK (SoNguoi > 12)`, `CHECK (NgayVe >= NgayDi)` và dữ liệu mẫu (Seed Data).
* Ứng dụng biên dịch thành công (`Build: 1 succeeded, 0 failed`), kết nối ổn định với CSDL.
* Giao diện `FrmDangKyDoan` hoạt động chính xác:
  * Tự động tính ngày về dự kiến khi thay đổi ngày đi hoặc chọn tour khác.
  * Tự động nhân đơn giá theo số người để ra tổng tiền dự kiến.
  * Chặn nhập số người $\le 12$, thông báo hướng dẫn khách lẻ hoặc xác nhận chính sách.
  * Lưu thành công thông tin khách hàng, phiếu đăng ký và giao dịch đặt cọc vào SQL Server trong một giao dịch an toàn.

---


## 5. HƯỚNG DẪN KIỂM TRA & CHẠY LẠI (DÀNH CHO GIẢNG VIÊN)

1. **Khởi tạo Cơ sở Dữ liệu:**
   * Mở phần mềm **SQL Server Management Studio (SSMS)**.
   * Mở và thực thi toàn bộ kịch bản file **`DuLichVanHoaViet.sql`** (đã có sẵn lệnh tạo database `QuanLyCongTyDuLich`, tạo bảng và nạp sẵn dữ liệu mẫu).
2. **Cấu hình chuỗi kết nối:**
   * Mở file Solution `DuLichVanHoaViet.sln` bằng **Visual Studio 2022**.
   * Mở file **`App.config`**, kiểm tra và cập nhật lại thuộc tính `Data Source` cho đúng với tên SQL Server trên máy chấm bài (mặc định: `Data Source=.;Initial Catalog=QuanLyCongTyDuLich;Integrated Security=True;`).
3. **Biên dịch và Chạy thử:**
   * Nhấn tổ hợp phím **Ctrl + Shift + B** để Rebuild Solution (đảm bảo không còn lỗi).
   * Nhấn **F5** (hoặc nút **Start**) để chạy ứng dụng.
4. **Kiểm tra chức năng:**
   * Chọn nút **"Đăng Ký Tour Đoàn"** trên thanh điều hướng màn hình chính `FrmMain`.
   * Thử đổi ngày đi hoặc số người để kiểm tra tính năng tự động tính ngày về và tiền dự kiến.
   * Nhập thử số người $\le 12$ để kiểm tra thông báo chặn quy tắc nghiệp vụ BR03.
   * Nhập đầy đủ thông tin (số người $> 12$) và bấm **"LẬP PHIẾU ĐĂNG KÝ ĐOÀN"** để kiểm tra việc lưu dữ liệu vào CSDL.
