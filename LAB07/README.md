# BÁO CÁO THỰC HÀNH LAB 07: HỆ THỐNG QUẢN LÝ NHÂN SỰ CÔNG TY SƠN ĐÔNG Á

## 1. Thông tin sinh viên
- **Họ và tên:** Nguyễn Phi Long
- **Mã số sinh viên:** 1250080106
- **Lớp:** 12_ĐH_CNPM2
- **Email:** 1250080106@sv.hcmunre.edu.vn
- **Tên bài thực hành:** Lab 07 - Phân tích, Thiết kế và Cài đặt Hệ thống Quản lý Nhân sự (WinForms C# & SQL Server)

---

## 2. Thông tin môi trường & Công cụ sử dụng
- **Hệ điều hành:** Windows 11 Home 64-bit
- **Môi trường phát triển (IDE):** Microsoft Visual Studio 2022
- **Nền tảng công nghệ:** 
  - Ngôn ngữ lập trình: C# (Windows Forms Desktop)
  - Nền tảng thực thi: Microsoft .NET Framework 4.7.2 *(Lưu ý: Hệ sinh thái .NET hiện nay đã được Microsoft hợp nhất từ .NET Core thành tên gọi ngắn gọn là ".NET" như .NET 8 / .NET 9; tuy nhiên đồ án này tuân thủ cấu hình mẫu dùng .NET Framework 4.7.2 để bảo đảm tính tương thích tối đa với công cụ thiết kế WinForms Designer và cấu hình App.config)*.
- **Hệ quản trị CSDL:** Microsoft SQL Server (Instance: `PHI-LONG\KTEAM` / LocalDB)
- **Công nghệ truy xuất CSDL:** ADO.NET (`System.Data.SqlClient`)
- **Công cụ quản lý & Thiết kế mô hình:** SQL Server Management Studio (SSMS), Draw.io

---

## 3. Nội dung thực hiện

### 3.1. Phân tích Nghiệp vụ & Quy tắc Hệ thống (Business Rules - BR)
1. **Quy trình Quản lý Nhân sự:**
   - **Tuyển dụng & Thử việc:** Nhân viên mới vào phải có Quyết định tuyển dụng ghi rõ phòng ban, thời gian thử việc, mức lương thử việc và điều khoản hai bên (BR01).
   - **Hợp đồng lao động:** Khi hết thử việc và đạt yêu cầu, nhân viên được ký Hợp đồng dài hạn hoặc ngắn hạn (BR02, BR03).
   - **Lịch sử chức vụ & Lương:** Bổ nhiệm chức vụ mới và tăng/điều chỉnh lương cơ bản, phụ cấp độc hại được lưu vết bằng các Quyết định độc lập có ngày hiệu lực (BR04).
   - **Chính sách BHXH/BHYT:** Nhân viên ký hợp đồng dài hạn bắt buộc phải được lập hồ sơ BHXH và BHYT; tỷ lệ đóng của người lao động được trích tự động khi tính lương (BR05).
   - **Phân ca & Giờ phụ trội:** Hằng tuần trưởng phòng ban lập kế hoạch ca tuần (BR09). Ban chấm công lập phiếu phụ trội (ghi rõ hình thức tăng ca, ngày lễ, ngày nghỉ) và được quy đổi theo hệ số 1,5 lần giờ lao động bình thường khi tính thu nhập (BR07, BR08).
   - **Tính bảng lương tháng:** Kết hợp quyết định lương/chức vụ có hiệu lực, công chuẩn, giờ phụ trội nhân hệ số 1,5, trừ tiền bảo hiểm và trừ khoản phạt (BR06).
   - **Khen thưởng & Kỷ luật:** Khen thưởng được duyệt qua quyết định và lập phiếu chi (BR12, BR13); kỷ luật nộp qua phiếu thu hoặc khấu trừ trực tiếp vào lương cá nhân (BR12).

2. **Mô hình hóa biểu đồ UML:**
   - **Use Case:** Xây dựng sơ đồ tổng quát Level 0 (UC01–UC19) và 4 sơ đồ phân rã Level 1 chi tiết: Tuyển dụng & Hợp đồng, Hồ sơ & Quyết định nhân sự, Chấm công & Tiền lương, Bảo hiểm - Khen thưởng & Kỷ luật.
   - **Biểu đồ lớp phân tích (Analysis Class Diagram):** Tách biệt các lớp quyết định để lưu lịch sử (`QuyetDinhTuyenDung`, `HopDongLaoDong`, `QuyetDinhChucVu`, `QuyetDinhLuong`, `HoSoBaoHiem`, `BangLuong`, `PhieuChamCong`, `PhieuPhuTroi`, `PhieuChi`, `PhieuThu`).
   - **Biểu đồ trạng thái (State Machine):** Vòng đời Nhân viên (`Thử việc` $\rightarrow$ `Đang làm việc` $\rightarrow$ `Tạm nghỉ` $\rightarrow$ `Nghỉ việc`), Hợp đồng lao động, Bảng lương tháng.
   - **Biểu đồ hoạt động & Tuần tự:** Mô hình hóa chi tiết quy trình Lập quyết định tuyển dụng và quy trình Tính bảng lương tháng (quy đổi hệ số phụ trội 1,5).

### 3.2. Cài đặt CSDL SQL Server (`QuanLyNhanSu_DongA`)
- Tạo lập 19 bảng thực thể chuẩn hóa quan hệ 3NF:
  `PHONG_BAN`, `CHUC_VU`, `NHAN_VIEN`, `QUYET_DINH_TUYEN_DUNG`, `HOP_DONG_LAO_DONG`, `QUYET_DINH_CHUC_VU`, `QUYET_DINH_LUONG`, `HO_SO_BAO_HIEM`, `CA_LAM_VIEC`, `KE_HOACH_PHAN_CONG`, `PHIEU_CHAM_CONG`, `CHI_TIET_CHAM_CONG`, `PHIEU_PHU_TROI`, `CHI_TIET_PHU_TROI`, `BANG_LUONG`, `QUYET_DINH_KHEN_THUONG`, `PHIEU_CHI_KHEN_THUONG`, `QUYET_DINH_KY_LUAT`, `PHIEU_THU_NOP_PHAT`.
- Ràng buộc toàn vẹn & Bảo mật:
  - Ràng buộc `UNIQUE` chống chấm công trùng nhân viên trong ngày, chống trùng bảng lương trong kỳ.
  - Ràng buộc `CHECK` lương không âm, giờ phụ trội $> 0$, ngày kết thúc không trước ngày bắt đầu.
  - Thủ tục lưu trữ `sp_TinhBangLuongThang` bọc trong `SqlTransaction` để tự động tính toán và khấu trừ chính xác.

### 3.3. Xây dựng Kiến trúc 3 lớp & Hệ thống Form WinForms
- **Data Access Layer (`Data/Db.cs`):** Mở kết nối SQL an toàn, sử dụng tham số hóa `SqlParameter` ngăn ngừa SQL Injection.
- **Service Layer (`Services/`):** Tách riêng `TuyenDungService`, `HopDongService`, `ChamCongService`, `PhuTroiService`, `BangLuongService`, `BaoHiemService`, `QuyetDinhService`.
- **Presentation Layer (`Forms/`):** Thiết kế hệ thống Form trực quan:
  - `FrmDangNhap`: Xác thực tài khoản nội bộ và phân quyền vai trò (Nhân sự, Kế toán, Trưởng phòng, Giám đốc).
  - `FrmMain`: Trang chủ dashboard hiển thị KPI tổng quan (Nhân viên đang làm, Hợp đồng dài hạn, Quyết định chờ ký) và menu điều hướng.
  - `FrmHoSoNhanVien`: Quản lý hồ sơ cá nhân và phòng ban.
  - `FrmTuyenDung`: Lập quyết định thử việc, mức lương thử việc và điều khoản cam kết.
  - `FrmHopDong` & `FrmBaoHiem`: Quản lý hợp đồng dài hạn/ngắn hạn và hồ sơ BHXH/BHYT.
  - `FrmChamCong`: Chốt công kỳ, nhập giờ công từng nhân viên theo ngày.
  - `FrmPhuTroi`: Ghi nhận phiếu phụ trội, chọn hình thức và tính hệ số 1,5.
  - `FrmBangLuong`: Tính lương tự động theo công chuẩn, kiểm tra hồ sơ bảo hiểm và chốt lương.
  - `FrmKhenThuongKyLuat`: Lập quyết định thưởng/phạt, phiếu chi và phiếu thu nộp phạt.

---

## 4. Kết quả đạt được
- Toàn bộ 19 bảng và stored procedure tính lương được triển khai hoàn chỉnh trên SQL Server.
- Quy tắc hệ số giờ phụ trội 1,5 được tính toán tự động và khớp với bảng công thực tế.
- Hợp đồng dài hạn được kiểm soát chặt chẽ: tự động phát hiện và cảnh báo nếu thiếu hồ sơ BHXH/BHYT trước khi chốt bảng lương.
- Giao diện thiết kế theo phong cách phẳng hiện đại, bố cục rõ ràng, khóa trường mã khóa chính khi cập nhật và chống vỡ khung/tràn chữ trên màn hình độ phân giải cao.

---

## 5. Lỗi gặp phải và cách khắc phục
- **Lỗi 1: Tranh chấp dữ liệu và tính sai bảng lương khi chưa đủ quyết định có hiệu lực.**
  - *Hiện tượng:* Nếu nhân viên có nhiều quyết định tăng lương trong quá khứ, hàm tính lương dễ lấy sai quyết định cũ.
  - *Khắc phục:* Viết truy vấn lấy quyết định có ngày hiệu lực mới nhất nhưng phải nhỏ hơn hoặc bằng ngày cuối của kỳ lương (`NgayHieuLuc <= @NgayCuoiKy`).
- **Lỗi 2: Tràn giao diện và nhầm lẫn giữa .NET Framework và .NET Core.**
  - *Hiện tượng:* Visual Studio 2022 có 2 template tạo Windows Forms App ("Windows Forms App" cho .NET 8/.NET 9 và "Windows Forms App (.NET Framework)"). Chọn nhầm bản modern .NET làm sai cấu hình `App.config`.
  - *Khắc phục:* Chọn chuẩn xác template **Windows Forms App (.NET Framework)** phiên bản **4.7.2** để đồng bộ đúng với bộ thư viện của bài thực hành.
- **Lỗi 3: Ràng buộc khóa ngoại khi xóa phòng ban đang có nhân viên.**
  - *Hiện tượng:* Ném biệt lệ `SqlException (547)` khi xóa dữ liệu đang được tham chiếu.
  - *Khắc phục:* Bắt mã lỗi 547 tại Service và hiển thị thông báo nghiệp vụ: *"Không thể xóa vì dữ liệu đang được liên kết với hồ sơ nhân viên"* thay vì văng crash ứng dụng.

---

## 6. Hướng dẫn kiểm tra và chạy lại dự án
1. **Thiết lập Cơ sở dữ liệu:**
   - Mở SSMS, mở file script `QuanLyNhanSu_DongA.sql` và nhấn **Execute (F5)** để khởi tạo Database, 19 bảng và nạp dữ liệu mẫu.
   - Kiểm tra chuỗi kết nối trong file `App.config`:
     ```xml
     <connectionStrings>
       <add name="QuanLyNhanSu" 
            connectionString="Data Source=PHI-LONG\KTEAM;Initial Catalog=QuanLyNhanSu_DongA;Integrated Security=True" 
            providerName="System.Data.SqlClient" />
     </connectionStrings>
     ```
2. **Biên dịch và chạy ứng dụng:**
   - Mở Solution `QuanLyNhanSu_DongA.sln` bằng Visual Studio 2022.
   - Nhấn **Ctrl + Shift + B** để Rebuild Solution (bảo đảm `0 Errors`).
   - Nhấn **F5** để khởi chạy chương trình.
3. **Kịch bản kiểm thử (Test Cases):**
   - **Tuyển dụng:** Lập quyết định thử việc mới -> Hệ thống tự động lưu trạng thái `Thử việc` cho nhân viên.
   - **Hợp đồng & Bảo hiểm:** Ký hợp đồng dài hạn -> Hệ thống yêu cầu kiểm tra và tạo hồ sơ BHXH/BHYT (TC05).
   - **Phụ trội:** Lập phiếu phụ trội tăng ca 4 giờ cho nhân viên `NV001` (TC10).
   - **Tính lương:** Chọn kỳ lương tháng 10/2026, nhập giờ công chuẩn 208 giờ -> Bấm `Tính lương` -> Kiểm tra tiền phụ trội được nhân đúng hệ số 1,5 và trừ tiền bảo hiểm/khoản phạt chính xác (TC11, TC13).
