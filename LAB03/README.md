# BÁO CÁO THỰC HÀNH LAB 03: HỆ THỐNG QUẢN LÝ KHÁCH SẠN

## 1. Thông tin sinh viên
- **Họ và tên:** Nguyễn Phi Long
- **Mã số sinh viên:** 1250080106
- **Lớp:** 12_ĐH_CNPM2
- **Email:** 1250080106@sv.hcmunre.edu.vn
- **Tên bài thực hành:** Bài 3 - Xây dựng Hệ thống Quản lý Khách sạn (WinForms C# & SQL Server)

---

## 2. Thông tin môi trường & Công cụ sử dụng
- **Hệ điều hành:** Windows 11 Home 64-bit
- **Môi trường phát triển (IDE):** Microsoft Visual Studio 2022
- **Hệ quản trị cơ sở dữ liệu:** Microsoft SQL Server (Instance: `PHI-LONG\KTEAM` / LocalDB)
- **Nền tảng công nghệ:** .NET Framework 4.7.2, Windows Forms App (C#), ADO.NET (`System.Data.SqlClient`)
- **Công cụ quản trị CSDL:** SQL Server Management Studio (SSMS)

---

## 3. Nội dung thực hiện

### 3.1. Thiết kế và tạo lập Cơ sở dữ liệu (Database)
1. **Khởi tạo Database & Bảng dữ liệu:**
   - Xây dựng CSDL `QuanLyKhachSan` gồm đầy đủ 18 bảng thực thể nghiệp vụ: `NhanVien`, `KhuVuc`, `Phong`, `LoaiTienNghi`, `TienNghi`, `PhieuLapDat`, `KhachHang`, `PhieuDatPhong`, `ChiTietDatPhong`, `NguoiLuuTru`, `DichVu`, `PhieuSuDungDV`, `ChiTietPhieuSuDungDV`, `QuyDinhDenBu`, `PhieuDenBu`, `ChiTietPhieuDenBu`, `HoaDon`, `ThanhToan`.
2. **Cài đặt ràng buộc toàn vẹn & Quy tắc nghiệp vụ (Business Rules):**
   - Ràng buộc kiểm tra số người tối đa `Phong.SoNguoiToiDa > 0`, đơn giá `>= 0`.
   - Ràng buộc duy nhất `UQ_TienNghi_Loai_STT` (`MaLoaiTN`, `SoThuTu`) phân biệt tiện nghi cùng loại.
   - Ràng buộc quy tắc một thiết bị chỉ ở một phòng trong ngày qua `UQ_PhieuLapDat_ThietBi_Ngay` (`MaTienNghi`, `NgayLap`).
   - Ràng buộc gộp phiếu dịch vụ theo phòng/ngày `UQ_PhieuSDDV_PhongNgay` (`SoPhieuDat`, `SoPhong`, `NgaySuDung`) và khóa chính chi tiết `(SoPhieuSDDV, MaDV)` để cộng dồn số lượng dùng trong ngày.
3. **Các cải tiến & Bổ sung CSDL thực tế (SQL Script updates):**
   - Bổ sung cột `TienDenBu decimal(18,2) DEFAULT 0` vào bảng `HoaDon` nhằm hỗ trợ gom tiền đền bù hư hỏng/mất mát vào tổng thanh toán khi trả phòng.
   - Bổ sung và tạo các chỉ mục (Indexes) để tăng tốc độ truy vấn nghiệp vụ:
     - `IX_PhieuDatPhong_Ngay` trên `(NgayNhan, NgayTraDuKien, TrangThai)`: Tối ưu hóa việc rà soát chồng lấn lịch đặt phòng.
     - `IX_CTDat_Phong` trên bảng `ChiTietDatPhong(SoPhong, SoPhieuDat)`: Tăng tốc độ tra cứu phòng theo phiếu đặt.
     - `IX_PhieuSDDV_DatPhong` trên bảng `PhieuSuDungDV(SoPhieuDat, SoPhong, NgaySuDung)`: Tối ưu kiểm tra phiếu dịch vụ trong ngày của phòng đang ở.

---

## 4. Kết quả đạt được
- **Cơ sở dữ liệu:** Tạo lập hoàn chỉnh trên SQL Server, dữ liệu mẫu khởi tạo hiển thị đầy đủ trên các giao diện.
- **Tính toàn vẹn & Nghiệp vụ:**
  - Ngăn chặn triệt để đặt phòng vượt sức chứa hoặc chồng chéo ngày thuê của phòng khác.
  - Tự động cộng dồn số lượng dịch vụ phát sinh cùng ngày trong bảng `ChiTietPhieuSuDungDV`.
  - Hóa đơn chỉ chuyển sang trạng thái `Đã thanh toán` khi tổng số tiền các giao dịch thanh toán bằng đúng số tiền cần trả; hệ thống từ chối trả phòng nếu chưa thanh toán đủ.
- **Giao diện:** Thiết kế WinForms gọn gàng, bố cục phân nhóm theo TabControl và GroupBox, hỗ trợ hiển thị tốt không bị tràn viền hay đè chữ.

---
