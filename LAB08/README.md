# LAB 08: PHÂN TÍCH VÀ THIẾT KẾ HỆ THỐNG QUẢN LÝ CỬA HÀNG NƯỚC GIẢI KHÁT

[![Course](https://img.shields.io/badge/Course-OOSD%20%2F%20TKPMHDT-blue.svg)](https://github.com/NguyenPhiLong517/LAB_OOSD)
[![Author](https://img.shields.io/badge/Author-Nguyen%20Phi%20Long-success.svg)](https://github.com/NguyenPhiLong517)
[![Student%20ID](https://img.shields.io/badge/MSSV-1250080106-informational.svg)](https://github.com/NguyenPhiLong517/LAB_OOSD)
[![Platform](https://img.shields.io/badge/Platform-C%23%20WinForms%20%7C%20.NET-orange.svg)](#)
[![Database](https://img.shields.io/badge/Database-SQL%20Server%20(17%20Tables)-red.svg)](#)
[![UML](https://img.shields.io/badge/UML-Draw.io%20%7C%2022%20Diagrams-purple.svg)](#)

Báo cáo phân tích và thiết kế phần mềm hướng đối tượng (OOSD) toàn diện cho đồ án **Hệ thống Quản lý Cửa hàng Nước giải khát**, được xây dựng và chuẩn hóa theo quy chuẩn đồ án chuyên nghiệp. Tài liệu bao gồm khảo sát nghiệp vụ, mô hình hóa UML hoàn chỉnh (22 sơ đồ), cơ sở dữ liệu quan hệ 17 bảng, ràng buộc toàn vẹn trigger/stored procedure và mã nguồn C# WinForms.

---

## 📑 Mục Lục
- [1. Thông Tin Tác Giả & Đề Tài](#1-thông-tin-tác-giả--đề-tài)
- [2. Tổng Quan Nghiệp Vụ](#2-tổng-quan-nghiệp-vụ)
- [3. Kiến Trúc Ứng Dụng](#3-kiến-trúc-ứng-dụng)
- [4. Danh Mục Sơ Đồ UML Đã Thiết Kế (22 Sơ Đồ)](#4-danh-mục-sơ-đồ-uml-đã-thiết-kế-22-sơ-đồ)
- [5. Thiết Kế Cơ Sở Dữ Liệu SQL Server](#5-thiết-kế-cơ-sở-dữ-liệu-sql-server)
- [6. Cấu Trúc Mã Nguồn & Thư Mục Dự Án](#6-cấu-trúc-mã-nguồn--thư-mục-dự-án)
- [7. Hướng Dẫn Cài Đặt & Triển Khai](#7-hướng-dẫn-cài-đặt--triển-khai)

---

## 1. Thông Tin Tác Giả & Đề Tài
- **Học phần**: Thiết kế phần mềm hướng đối tượng (Object-Oriented Software Design - OOSD)
- **Sinh viên thực hiện**: Nguyễn Phi Long
- **Mã số sinh viên (MSSV)**: `1250080106`
- **Đề tài**: Quản lý cửa hàng nước giải khát (Beverage Store Management System)
- **Báo cáo hoàn chỉnh**: [`1250080106_NguyenPhiLong_Lab08.docx`](./1250080106_NguyenPhiLong_Lab08.docx)
- **File Draw.io thiết kế**: [`SoDo_Lab8_QL_CuaHangNuocGiaiKhat.drawio`](./SoDo_Lab8_QL_CuaHangNuocGiaiKhat.drawio)

---

## 2. Tổng Quan Nghiệp Vụ
Hệ thống giải quyết trọn vẹn chu trình hoạt động của một cửa hàng nước giải khát bán sỉ và lẻ:
1. **Quản lý danh mục & tồn kho**: Phân loại theo nhãn hiệu, nhà cung ứng; kiểm tra tồn khả dụng theo thời gian thực; tự động cập nhật kho khi nhập và bán.
2. **Quản lý nhập hàng từ nhà cung ứng (NCC)**:
   - Lập đơn đặt hàng (`DON_DAT_HANG`) chỉ cho phép các mặt hàng thuộc đúng nhà cung ứng phân phối.
   - Theo dõi tiến độ giao hàng; **quy tắc cứng**: Mỗi đơn đặt hàng được giao **tối đa 3 đợt** (`trg_PGH_ToiDa3Dot`).
3. **Bán hàng & Quản lý hẹn giao khi thiếu hàng**:
   - Khách vãng lai: Yêu cầu thanh toán ngay; nếu thiếu hàng trong kho sẽ từ chối giao dịch.
   - Khách quen: Cho phép giao phần hàng hiện có trong kho (trừ tồn kho và lập hóa đơn giao ngay), đồng thời tự động lập **Phiếu hẹn giao** (`PHIEU_HEN`) cho phần còn thiếu khi có hàng về (`trg_PH_HenChiKhachQuen`).
4. **Quản lý công nợ khách quen**:
   - Khách quen được phép mua nợ với phiếu ghi nợ (`PHIEU_GHI_NO`).
   - Hỗ trợ thanh toán nợ nhiều lần (`THANH_TOAN_NO`); tự động tính dư nợ (`DuNo = SoTienNo - SoTienDaTra`) và cập nhật trạng thái `DA_TAT_TOAN` khi trả đủ bằng Stored Procedure có Transaction an toàn.

---

## 3. Kiến Trúc Ứng Dụng
Hệ thống được thiết kế theo mô hình 3 tầng phân định rạch ròi trách nhiệm (Separation of Concerns):

```
┌─────────────────────────────────────────────────────────────┐
│ 1. PRESENTATION LAYER (Tầng Giao Diện - C# WinForms)       │
│    MainForm (TabControl) | MasterDataDialog                 │
│    PurchaseOrderDialog   | DeliveryDialog                   │
│    SalesDialog           | AppointmentDeliveryDialog        │
│    DebtPaymentDialog                                        │
└──────────────────────────────┬──────────────────────────────┘
                               │ Gọi hàm nghiệp vụ / Dữ liệu UI
                               ▼
┌─────────────────────────────────────────────────────────────┐
│ 2. BUSINESS LOGIC & DATA ACCESS (Tầng Nghiệp Vụ & ADO.NET)  │
│    Class Database (SqlConnection, SqlCommand, SqlTransaction)│
│    OrderService | SalesService | DebtService               │
│    Validation Rules & Data Integrity Checks                 │
└──────────────────────────────┬──────────────────────────────┘
                               │ T-SQL, Stored Procedures, Views
                               ▼
┌─────────────────────────────────────────────────────────────┐
│ 3. DATABASE LAYER (Tầng CSDL - Microsoft SQL Server)        │
│    17 Bảng quan hệ 3NF (PK, FK, CHECK, DEFAULT)             │
│    6 Triggers kiểm soát logic nghiệp vụ tự động            │
│    2 Stored Procedures bọc Transaction an toàn              │
│    3 Views tra cứu tổng hợp                                 │
└─────────────────────────────────────────────────────────────┘
```

---

## 4. Danh Mục Sơ Đồ UML Đã Thiết Kế (22 Sơ Đồ)
Toàn bộ sơ đồ được thiết kế đồng nhất theo hệ thống nhận diện đồ án chuyên nghiệp: màu đỏ đô (`#7A0A2E`), vàng nhạt (`#FFFFCC`), xanh nhạt (`#E3F0FF`), vàng ấm (`#FFF3C4`). Toàn bộ đã được đóng gói trong file [`SoDo_Lab8_QL_CuaHangNuocGiaiKhat.drawio`](./SoDo_Lab8_QL_CuaHangNuocGiaiKhat.drawio) và xuất thành ảnh chất lượng cao trong thư mục [`generated_diagrams/`](./generated_diagrams/):

| STT | Mã Hình | Tên Sơ Đồ UML | File Ảnh Tương Ứng |
|:---:|:---:|:---|:---|
| 1 | Hình 2.1 | Biểu đồ Use Case tổng quát (Level 0) | `P01_Use_Case_Tong_Quat.png` |
| 2 | Hình 2.2 | Phân rã Use Case Quản lý danh mục & tồn kho | `P02_Phan_Ra_DanhMuc.png` |
| 3 | Hình 2.3 | Phân rã Use Case Quản lý nhập hàng từ NCC | `P03_Phan_Ra_NhapHang.png` |
| 4 | Hình 2.4 | Phân rã Use Case Bán hàng & hẹn giao | `P04_Phan_Ra_BanHang.png` |
| 5 | Hình 2.5 | Phân rã Use Case Quản lý công nợ khách quen | `P05_Phan_Ra_CongNo.png` |
| 6 | Hình 2.6 | Biểu đồ lớp phân tích hệ thống (Analysis Class Diagram) | `P06_Lop_Phan_Tich.png` |
| 7 | Hình 2.7 | Biểu đồ trạng thái đơn đặt hàng (`DonDatHang`) | `P07_Trang_Thai_Don_Dat_Hang.png` |
| 8 | Hình 2.8 | Biểu đồ trạng thái phiếu hẹn giao (`PhieuHen`) | `P08_Trang_Thai_Phieu_Hen.png` |
| 9 | Hình 2.9 | Biểu đồ trạng thái phiếu ghi nợ (`PhieuGhiNo`) | `P09_Trang_Thai_Phieu_Ghi_No.png` |
| 10 | Hình 2.10 | Biểu đồ hoạt động Ghi nhận phiếu giao NCC (UC07) | `P10_Hoat_Dong_Giao_Hang_NCC.png` |
| 11 | Hình 2.11 | Biểu đồ hoạt động Bán hàng & hẹn giao khi thiếu (UC09, UC11) | `P11_Hoat_Dong_Ban_Hang_Hen_Giao.png` |
| 12 | Hình 2.12 | Biểu đồ hoạt động Ghi nhận thanh toán nợ (UC15) | `P12_Hoat_Dong_Thu_No.png` |
| 13 | Hình 2.13 | Biểu đồ tuần tự Ghi nhận phiếu giao NCC (UC07) | `P13_Tuan_Tu_Giao_Hang_NCC.png` |
| 14 | Hình 2.14 | Biểu đồ tuần tự Lập hóa đơn & hẹn giao (UC09, UC11) | `P14_Tuan_Tu_Ban_Hang_Hen_Giao.png` |
| 15 | Hình 2.15 | Biểu đồ tuần tự Ghi nhận thanh toán nợ (UC15) | `P15_Tuan_Tu_Thu_No.png` |
| 16 | Hình 2.16 | Biểu đồ lớp thiết kế chi tiết toàn hệ thống (3 tầng) | `P16_Lop_Thiet_Ke_Chi_Tiet.png` |
| 17 | Hình 2.17 | Lớp thiết kế VOPC: Lập đơn đặt hàng & nhận hàng (2.7.1) | `P17_Thiet_Ke_Dat_Hang.png` |
| 18 | Hình 2.18 | Lớp thiết kế VOPC: Bán hàng & hẹn giao khi thiếu (2.7.2) | `P18_Thiet_Ke_Ban_Hang.png` |
| 19 | Hình 2.19 | Lớp thiết kế VOPC: Thu nợ & tất toán công nợ (2.7.3) | `P19_Thiet_Ke_Thu_No.png` |
| 20 | Hình 3.1 | Mô hình thực thể liên kết (ERD) SQL Server - 17 bảng | `P20_ERD_SQL_Server.png` |
| 21 | Hình 4.1 | Kiến trúc ứng dụng 3 tầng WinForms - ADO.NET - SQL Server | `P21_Kien_Truc_He_Thong.png` |
| 22 | Hình 4.2 | Sơ đồ điều hướng hệ thống Form (Form Navigation) | `P22_Dieu_Huong_Form.png` |

---

## 5. Thiết Kế Cơ Sở Dữ Liệu SQL Server
File script [`QL_CuaHangNuocGiaiKhat.sql`](./QL_CuaHangNuocGiaiKhat.sql) khởi tạo hoàn chỉnh CSDL gồm:

### 17 Bảng quan hệ chuẩn 3NF:
1. `NHAN_HIEU`: Phân loại nhóm nước giải khát (Nước ngọt, Nước khoáng, Nước trái cây, Tăng lực...).
2. `NHA_CUNG_UNG`: Đối tác cung cấp nguồn hàng.
3. `NHAN_VIEN`: Nhân viên phụ trách bán hàng, quản lý kho hoặc điều hành.
4. `KHACH_HANG`: Danh sách khách hàng kèm phân loại (`KHACH_QUEN`, `KHACH_VANG_LAI`).
5. `NUOC_GIAI_KHAT`: Danh mục sản phẩm, đơn vị tính, số lượng tồn kho, giá niêm yết.
6. `DON_DAT_HANG`: Đơn đặt hàng gửi NCC kèm trạng thái giao hàng.
7. `CT_DON_DAT_HANG`: Chi tiết các mặt hàng và số lượng cần đặt.
8. `PHIEU_GIAO_HANG`: Phiếu nhận hàng từng đợt từ NCC (`SoDotGiao` từ 1 đến 3).
9. `CT_PHIEU_GIAO`: Chi tiết số lượng thực giao từng đợt.
10. `HOA_DON`: Hóa đơn bán hàng xuất cho khách.
11. `CT_HOA_DON`: Chi tiết số lượng mua yêu cầu và số lượng giao ngay tại quầy.
12. `PHIEU_HEN`: Phiếu hẹn ngày giao bổ sung phần hàng bị thiếu.
13. `CT_PHIEU_HEN`: Số lượng hẹn giao và số lượng đã giao lũy kế.
14. `GIAO_HANG_KHACH`: Đợt giao hàng thực tế trả theo phiếu hẹn.
15. `CT_GIAO_HANG_KHACH`: Số lượng giao theo từng đợt trả hẹn.
16. `PHIEU_GHI_NO`: Phiếu theo dõi nợ của khách quen, số tiền nợ, số đã trả, hạn trả.
17. `THANH_TOAN_NO`: Nhật ký các lần nộp tiền trả nợ từng phần.

### 6 Triggers bảo vệ toàn vẹn:
- `trg_PGH_ToiDa3Dot`: Chặn đứng hành vi ghi nhận vượt quá 3 đợt giao cho một đơn đặt hàng.
- `trg_CT_DDH_KiemTraNCC`: Đảm bảo mặt hàng trong đơn đặt phải do chính NCC đó phân phối.
- `trg_PH_HenChiKhachQuen`: Nghiêm cấm tạo phiếu hẹn cho khách vãng lai khi thiếu hàng.
- `trg_CT_PGH_CapNhatTon`: Tự động cộng số lượng vào tồn kho `NUOC_GIAI_KHAT` khi nhận hàng.
- `trg_CT_HD_TruTon`: Tự động trừ tồn kho theo `SoLuongGiaoNgay` khi lập hóa đơn.
- `trg_PGN_ChiKhachQuen`: Chỉ khách quen mới được phép mua nợ.

### 2 Stored Procedures bọc Transaction:
- `sp_GhiNhanThanhToanNo`: Kiểm tra số tiền trả hợp lệ (`0 < SoTien <= DuNo`), ghi nhận thanh toán, cộng dồn `SoTienDaTra`, tự động chuyển trạng thái `DA_TAT_TOAN` khi hoàn tất.
- `sp_GhiNhanGiaoHangHen`: Ghi nhận giao trả hàng hẹn, trừ tồn kho, cập nhật `SoLuongDaGiao`, tự động chuyển trạng thái `DA_GIAO_DU` khi đã giao đủ.

---

## 6. Cấu Trúc Mã Nguồn & Thư Mục Dự Án
```
Lab08/
├── 1250080106_NguyenPhiLong_Lab08.docx          # Báo cáo Word chuẩn hóa hoàn chỉnh
├── 1250080106_NguyenPhiLong_Lab08_backup.docx   # Bản sao lưu gốc ban đầu
├── SoDo_Lab8_QL_CuaHangNuocGiaiKhat.drawio     # File thiết kế Draw.io 22 trang
├── QL_CuaHangNuocGiaiKhat.sql                  # Script SQL Server 17 bảng + Triggers + SPs
├── QL_CuaHangNuocGiaiKhat_VS.zip               # Mã nguồn C# WinForms giải pháp Visual Studio
│   └── QL_CuaHangNuocGiaiKhat/
│       ├── Program.cs                          # Điểm khởi chạy ứng dụng
│       ├── Database.cs                         # Lớp tiện ích ADO.NET kết nối DB & Transaction
│       ├── MainForm.cs                         # Form chính điều hướng các phân hệ
│       ├── MasterDataDialog.cs                 # Hộp thoại quản trị danh mục (CRUD)
│       └── TransactionDialogs.cs               # Các hộp thoại giao dịch nghiệp vụ
├── generated_diagrams/                         # Thư mục lưu 22 ảnh sơ đồ UML chất lượng cao
│   ├── P01_Use_Case_Tong_Quat.png
│   ├── ...
│   └── P22_Dieu_Huong_Form.png
└── README.md                                   # Tài liệu hướng dẫn bài Lab 08
```

---

## 7. Hướng Dẫn Cài Đặt & Triển Khai

### Yêu cầu môi trường:
- **Hệ điều hành**: Windows 10 / 11
- **Cơ sở dữ liệu**: Microsoft SQL Server 2017+ / SQL Server Management Studio (SSMS)
- **Công cụ lập trình**: Microsoft Visual Studio 2019 / 2022 (.NET Framework 4.7.2 / 4.8)
- **Công cụ sơ đồ**: Diagrams.net / Draw.io Desktop

### Bước 1: Khởi tạo Cơ sở Dữ liệu
1. Mở **SQL Server Management Studio (SSMS)** và kết nối tới SQL Server instance của bạn (`localhost` hoặc `.\SQLEXPRESS`).
2. Mở file [`QL_CuaHangNuocGiaiKhat.sql`](./QL_CuaHangNuocGiaiKhat.sql).
3. Nhấn **Execute (F5)** để chạy script. Script sẽ tạo database `QL_CuaHangNuocGiaiKhat`, 17 bảng, 6 triggers, 2 stored procedures, 3 views và nạp sẵn dữ liệu mẫu (Seed Data) chuẩn xác.

### Bước 2: Mở và Chạy Ứng Dụng C# WinForms
1. Giải nén file [`QL_CuaHangNuocGiaiKhat_VS.zip`](./QL_CuaHangNuocGiaiKhat_VS.zip).
2. Mở file giải pháp `QL_CuaHangNuocGiaiKhat.csproj` bằng **Visual Studio**.
3. Mở file `Database.cs`, kiểm tra và điều chỉnh chuỗi kết nối kết nối tới máy chủ của bạn nếu cần:
   ```csharp
   private static string connectionString = @"Data Source=.;Initial Catalog=QL_CuaHangNuocGiaiKhat;Integrated Security=True;TrustServerCertificate=True";
   ```
4. Nhấn **Build Solution (Ctrl + Shift + B)** và nhấn **F5** để khởi chạy ứng dụng.
5. Thao tác kiểm thử các ca nghiệp vụ:
   - Thêm/sửa mặt hàng nước giải khát, kiểm tra số lượng tồn kho.
   - Lập đơn đặt hàng và giao hàng đợt 1, 2, 3 (xác minh chặn đợt 4).
   - Bán hàng cho khách vãng lai và khách quen; trải nghiệm tự động lập phiếu hẹn giao khi thiếu hàng.
   - Thu tiền nợ khách quen từng phần, kiểm tra tự động cập nhật dư nợ và tất toán.

