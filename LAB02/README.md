# BÁO CÁO THỰC HÀNH LAB 02: HỆ THỐNG QUẢN LÝ THƯ VIỆN

## 1. Thông tin sinh viên
- **Họ và tên:** Nguyễn Phi Long
- **Mã số sinh viên:** 1250080106
- **Lớp:** 12_ĐH_CNPM2
- **Email:** 1250080106@sv.hcmunre.edu.vn
- **Tên bài thực hành:** Lab 02 - Hệ thống Quản lý Thư viện (Mô hình hóa UML Activity/Sequence Diagram, CSDL SQL Server và Lập trình C# WinForms)

---

## 2. Thông tin môi trường & Công cụ sử dụng
- **Hệ điều hành:** Windows 11 Home 64-bit
- **Công cụ thiết kế mô hình:** Draw.io / UML Modeling Tools
- **Môi trường phát triển:** Microsoft Visual Studio 2022 (.NET Framework 4.7.2)
- **Hệ quản trị CSDL:** Microsoft SQL Server (Instance: `PHI-LONG\KTEAM` / LocalDB)
- **Nền tảng giao diện:** C# Windows Forms, ADO.NET (`System.Data.SqlClient`)
- **Công cụ quản trị CSDL:** SQL Server Management Studio (SSMS)

---

## 3. Nội dung thực hiện

### 3.1. Phân tích & Xây dựng Sơ đồ Hành vi (Behavioral Diagrams)
1. **Activity Diagram (Biểu đồ hoạt động phân làn Swimlane):**
   - **Quản lý trả sách & Lập phiếu phạt:** Mô hình hóa 3 làn (Độc giả - Thủ thư - Hệ thống); kiểm tra tình trạng vật lý, đối soát hạn trả, rẽ nhánh tính phạt (trễ hạn / mất / hư hỏng), xử lý logic cập nhật tồn kho (chỉ cộng tồn kho khi sách không bị mất/hư) và hoàn tất trả sách
   - **Đăng ký mượn sách:** Kiểm tra hợp lệ thẻ, rà soát sách quá hạn, kiểm tra trần số lượng mượn (tối đa 3 cuốn) và kiểm tra số lượng tồn kho khả dụng
   - **Quản lý mượn - trả sách:** Tra cứu phiếu theo mã thẻ/mã sách, lưu mốc thời gian thực tế, tính phạt trễ hạn và giải phóng phiếu mượn
   - **Duyệt yêu cầu đặt mua:** Quy trình thủ thư tiếp nhận đơn đề xuất mua tài liệu từ độc giả, kiểm duyệt chấp nhận hoặc từ chối kèm lý do phản hồi

2. **Sequence Diagram (Biểu đồ tuần tự tương tác hệ thống):**
   - **Quản lý trả sách:** Thủ thư -> `FrmMuonTra` -> `MuonTraService` -> CSDL (Truy vấn phiếu mượn `Đang mượn`, cập nhật trạng thái `Đã trả`, tăng tồn kho và commit giao dịch)
   - **Tải tài liệu điện tử:** Độc giả -> `FrmChiTietTaiLieu` -> `TaiLieuService` -> CSDL (Xác thực mã thẻ thư viện còn hạn, ghi nhận lượt tải và trả về đường dẫn file)
   - **Đăng nhập hệ thống:** Người dùng -> `FrmLogin` -> `TaiKhoanService` -> CSDL (Kiểm tra mật khẩu, nhận diện phân quyền độc giả/thủ thư và điều hướng màn hình)
   - **Duyệt yêu cầu đặt mua:** Thủ thư -> `FrmDuyetDatMua` -> `DatMuaService` -> CSDL (Truy xuất danh sách chờ duyệt, lưu quyết định duyệt/từ chối vào CSDL)

### 3.2. Cài đặt CSDL SQL Server (`QuanLyThuVienDB`)
- Xây dựng 9 bảng thực thể: `NhanVien`, `TheLoai`, `NhaXuatBan`, `DauSach`, `DocGia`, `TheDocGia`, `PhieuMuon`, `ChiTietPhieuMuon`, `PhieuPhat`
- Cài đặt Filtered Unique Index `UX_TheDocGia_MotTheHoatDong` trên `TheDocGia(MaDocGia)` với `WHERE TrangThai=1` (đảm bảo độc giả chỉ có duy nhất 1 thẻ hoạt động tại một thời điểm)
- Ràng buộc `UNIQUE(MaPhieuMuon, MaDauSach)` ngăn mượn trùng đầu sách trong một phiếu
- Ràng buộc `CHECK (SoLuongHienCo >= 0)` và `CHECK (NgayHenTra >= NgayMuon)`

### 3.3. Xây dựng Kiến trúc phần mềm & Giao diện WinForms
- **Data Layer (`Data/Db.cs`):** Mở kết nối tập trung, thực thi truy vấn parameterized an toàn
- **Service Layer (`Services/`):** Tách riêng `DanhMucService`, `SachService`, `DocGiaService`, `MuonTraService`, `ThongKeService`[cite: 19]. Bọc giao dịch mượn/trả trong `SqlTransaction` mức `Serializable` để chống tranh chấp tồn kho
- **Presentation Layer (`Forms/`):** Thiết kế hoàn chỉnh 6 Form chức năng
  1. `FrmMain`: Màn hình điều hướng trung tâm
  2. `FrmDanhMuc`: Quản lý 3 Tab (Nhân viên, Thể loại, Nhà xuất bản)
  3. `FrmSach`: Quản lý đầu sách, năm xuất bản, nhà xuất bản, thể loại và tìm kiếm nhanh
  4. `FrmDocGia`: Quản lý thông tin độc giả, cấp thẻ mới (hạn 1 năm), gia hạn thẻ và đóng lệ phí
  5. `FrmMuonTra`: Phân hệ Mượn sách (chọn tối đa 3 cuốn khác nhau, kiểm tra thẻ/lệ phí/sách quá hạn) và Trả sách (xử lý tình trạng sách, tính phí phạt trễ hạn/mất/hư hỏng)
  6. `FrmThongKe`: Thống kê KPI (lượt mượn, quá hạn, mất, hư hỏng, tổng phí phạt) và bảng chi tiết phiếu phạt theo khoảng thời gian

---

## 4. Kết quả đạt được
- Mô hình hóa đầy đủ các luồng nghiệp vụ phức tạp bằng Activity và Sequence Diagram chuẩn cú pháp UML
- Kết nối CSDL và hiển thị dữ liệu thành công trên cả 6 Form WinForms
  - `FrmMain`: Điều hướng mượt mà đến tất cả các module
  - `FrmDanhMuc`: Nạp và thao tác CRUD trơn tru trên 3 tab Nhân viên, Thể loại, NXB
  - `FrmSach`: Load dữ liệu sách, thể loại, NXB và tự động khóa mã khi chọn dòng sửa
  - `FrmDocGia`: Quản lý hồ sơ độc giả và trạng thái thẻ thư viện trực quan
  - `FrmMuonTra`: Kiểm tra điều kiện mượn chuẩn xác, chặn vượt 3 cuốn, tự động tính phạt và cập nhật kho chính xác
  - `FrmThongKe`: Báo cáo số liệu tổng hợp và chi tiết phạt đầy đủ

---
