/* ================================================================
   CSDL: QuanLyHoSoBenhAn
   SQL Server 2019 / SQL Server Express
   Các trường ghi chú "đề xuất" được bổ sung để đáp ứng UC03/UC04/UC09.
   ================================================================ */
IF DB_ID(N'QuanLyHoSoBenhAn') IS NULL
    CREATE DATABASE QuanLyHoSoBenhAn;
GO
USE QuanLyHoSoBenhAn;
GO

/* Xóa theo thứ tự phụ thuộc để có thể chạy lại script trong môi trường thử nghiệm. */
IF OBJECT_ID(N'NhatKyTruyCap', N'U') IS NOT NULL DROP TABLE NhatKyTruyCap;
IF OBJECT_ID(N'GiaoDichThanhToan', N'U') IS NOT NULL DROP TABLE GiaoDichThanhToan;
IF OBJECT_ID(N'HoaDonVienPhi', N'U') IS NOT NULL DROP TABLE HoaDonVienPhi;
IF OBJECT_ID(N'ChiTietToaThuoc', N'U') IS NOT NULL DROP TABLE ChiTietToaThuoc;
IF OBJECT_ID(N'ChiTietXetNghiem', N'U') IS NOT NULL DROP TABLE ChiTietXetNghiem;
IF OBJECT_ID(N'LichKhamDinhKy', N'U') IS NOT NULL DROP TABLE LichKhamDinhKy;
IF OBJECT_ID(N'PhieuKham', N'U') IS NOT NULL DROP TABLE PhieuKham;
IF OBJECT_ID(N'LoaiXetNghiem', N'U') IS NOT NULL DROP TABLE LoaiXetNghiem;
IF OBJECT_ID(N'Thuoc', N'U') IS NOT NULL DROP TABLE Thuoc;
IF OBJECT_ID(N'HoSoBenhAn', N'U') IS NOT NULL DROP TABLE HoSoBenhAn;
IF OBJECT_ID(N'BenhNhan', N'U') IS NOT NULL DROP TABLE BenhNhan;
IF OBJECT_ID(N'NhanVien', N'U') IS NOT NULL DROP TABLE NhanVien;
GO

CREATE TABLE NhanVien (
    MaNhanVien       VARCHAR(20)    NOT NULL PRIMARY KEY,
    HoTen            NVARCHAR(120)  NOT NULL,
    ChucVu           NVARCHAR(50)   NOT NULL,
    ChuyenKhoa       NVARCHAR(100)  NULL,
    SoDienThoai      VARCHAR(20)   NULL
);
GO

CREATE TABLE BenhNhan (
    MaBenhNhan       VARCHAR(20)    NOT NULL PRIMARY KEY,
    HoTen            NVARCHAR(120)  NOT NULL,
    NgaySinh         DATE           NOT NULL,
    GioiTinh         NVARCHAR(20)   NULL,
    SoDienThoai      VARCHAR(20)   NOT NULL,
    DiaChi           NVARCHAR(250)  NOT NULL,
    SoCMND           VARCHAR(30)   NOT NULL UNIQUE,
    DuongDanAnh3x4   NVARCHAR(300)  NULL,
    SoTheBHYT        VARCHAR(30)   NULL
);
GO

CREATE TABLE HoSoBenhAn (
    MaHoSo           VARCHAR(20)    NOT NULL PRIMARY KEY,
    MaBenhNhan       VARCHAR(20)    NOT NULL UNIQUE,
    NgayTao          DATE           NOT NULL DEFAULT (CONVERT(date, GETDATE())),
    TrangThai        NVARCHAR(30)   NOT NULL DEFAULT N'Mới',
    TienSuBenh       NVARCHAR(MAX)  NULL,
    GhiChu           NVARCHAR(500)  NULL,
    CONSTRAINT FK_HSBA_BenhNhan FOREIGN KEY (MaBenhNhan)
        REFERENCES BenhNhan(MaBenhNhan),
    CONSTRAINT CK_HSBA_TrangThai CHECK (TrangThai IN
        (N'Mới', N'Đang theo dõi', N'Đã đóng/Lưu trữ', N'Đã khóa'))
);
GO

CREATE TABLE LoaiXetNghiem (
    MaLoaiXN         VARCHAR(20)    NOT NULL PRIMARY KEY,
    TenXetNghiem     NVARCHAR(150)  NOT NULL,
    DonGia           DECIMAL(18,2)  NOT NULL CHECK (DonGia >= 0),
    MoTa             NVARCHAR(500)  NULL
);
GO

CREATE TABLE Thuoc (
    MaThuoc          VARCHAR(20)    NOT NULL PRIMARY KEY,
    TenThuoc         NVARCHAR(150)  NOT NULL,
    DonViTinh        NVARCHAR(30)   NOT NULL,
    DonGia           DECIMAL(18,2)  NOT NULL CHECK (DonGia >= 0),
    SoLuongTon       INT            NOT NULL DEFAULT 0 CHECK (SoLuongTon >= 0)
);
GO

CREATE TABLE PhieuKham (
    MaPhieuKham      VARCHAR(20)    NOT NULL PRIMARY KEY,
    MaHoSo           VARCHAR(20)    NOT NULL,
    MaNhanVien       VARCHAR(20)    NOT NULL,
    NgayKham         DATETIME2      NOT NULL DEFAULT SYSDATETIME(),
    TrieuChung       NVARCHAR(MAX)  NOT NULL,
    ChanDoan         NVARCHAR(1000) NULL,
    TrangThai        NVARCHAR(30)   NOT NULL DEFAULT N'Đang khám',
    LoiDuyenBao      NVARCHAR(1000) NULL,
    CONSTRAINT FK_PhieuKham_HoSo FOREIGN KEY (MaHoSo)
        REFERENCES HoSoBenhAn(MaHoSo),
    CONSTRAINT FK_PhieuKham_NhanVien FOREIGN KEY (MaNhanVien)
        REFERENCES NhanVien(MaNhanVien),
    CONSTRAINT CK_PhieuKham_TrangThai CHECK (TrangThai IN
        (N'Chờ khám', N'Đang khám', N'Chờ xét nghiệm', N'Chờ thanh toán', N'Đã hoàn tất', N'Đã hủy'))
);
GO

CREATE TABLE ChiTietXetNghiem (
    MaChiTietXN      VARCHAR(20)    NOT NULL PRIMARY KEY,
    MaPhieuKham      VARCHAR(20)    NOT NULL,
    MaLoaiXN         VARCHAR(20)    NOT NULL,
    KetQua           NVARCHAR(MAX)  NULL,
    NgayThucHien     DATETIME2      NULL,
    GhiChuDanhGia    NVARCHAR(1000) NULL,
    TrangThai        NVARCHAR(30)   NOT NULL DEFAULT N'Chờ thực hiện',
    CONSTRAINT FK_CTXN_PhieuKham FOREIGN KEY (MaPhieuKham)
        REFERENCES PhieuKham(MaPhieuKham),
    CONSTRAINT FK_CTXN_LoaiXN FOREIGN KEY (MaLoaiXN)
        REFERENCES LoaiXetNghiem(MaLoaiXN),
    CONSTRAINT CK_CTXN_TrangThai CHECK (TrangThai IN
        (N'Chờ thực hiện', N'Đang thực hiện', N'Chờ duyệt', N'Đã hoàn thành', N'Hủy mẫu'))
);
GO

CREATE TABLE ChiTietToaThuoc (
    MaPhieuKham      VARCHAR(20)    NOT NULL,
    MaThuoc          VARCHAR(20)    NOT NULL,
    SoLuong          INT            NOT NULL CHECK (SoLuong > 0),
    LieuDung         NVARCHAR(250)  NOT NULL,
    CachDung         NVARCHAR(500)  NOT NULL,
    DonGiaThoiDiem   DECIMAL(18,2)  NOT NULL CHECK (DonGiaThoiDiem >= 0),
    CONSTRAINT PK_ChiTietToaThuoc PRIMARY KEY (MaPhieuKham, MaThuoc),
    CONSTRAINT FK_CTTT_PhieuKham FOREIGN KEY (MaPhieuKham)
        REFERENCES PhieuKham(MaPhieuKham),
    CONSTRAINT FK_CTTT_Thuoc FOREIGN KEY (MaThuoc)
        REFERENCES Thuoc(MaThuoc)
);
GO

CREATE TABLE LichKhamDinhKy (
    MaLichHen        VARCHAR(20)    NOT NULL PRIMARY KEY,
    MaHoSo           VARCHAR(20)    NOT NULL,
    MaNhanVien       VARCHAR(20)    NULL,
    NgayHen          DATETIME2      NOT NULL,
    NoiDungHen       NVARCHAR(500)  NULL,
    TrangThai        NVARCHAR(30)   NOT NULL DEFAULT N'Mới đặt',
    CONSTRAINT FK_LichKham_HoSo FOREIGN KEY (MaHoSo)
        REFERENCES HoSoBenhAn(MaHoSo),
    CONSTRAINT FK_LichKham_NhanVien FOREIGN KEY (MaNhanVien)
        REFERENCES NhanVien(MaNhanVien),
    CONSTRAINT CK_LichKham_TrangThai CHECK (TrangThai IN
        (N'Mới đặt', N'Đã xác nhận', N'Đã khám', N'Đã hủy'))
);
GO

CREATE TABLE HoaDonVienPhi (
    MaHoaDon            VARCHAR(20)   NOT NULL PRIMARY KEY,
    MaPhieuKham         VARCHAR(20)   NULL,
    MaHoSo              VARCHAR(20)   NOT NULL,
    MaNhanVienThuNgan   VARCHAR(20)   NOT NULL,
    NgayLap             DATETIME2     NOT NULL DEFAULT SYSDATETIME(),
    LoaiHoaDon          NVARCHAR(50)  NOT NULL DEFAULT N'Viện phí',
    TienLePhi           DECIMAL(18,2) NOT NULL DEFAULT 0 CHECK (TienLePhi >= 0),
    TienKham            DECIMAL(18,2) NOT NULL DEFAULT 0 CHECK (TienKham >= 0),
    TienXetNghiem       DECIMAL(18,2) NOT NULL DEFAULT 0 CHECK (TienXetNghiem >= 0),
    TienThuoc           DECIMAL(18,2) NOT NULL DEFAULT 0 CHECK (TienThuoc >= 0),
    TienBHYTChiTra      DECIMAL(18,2) NOT NULL DEFAULT 0 CHECK (TienBHYTChiTra >= 0),
    TongTien AS (TienLePhi + TienKham + TienXetNghiem + TienThuoc) PERSISTED,
    SoTienPhaiTra AS
        (CASE WHEN TienLePhi + TienKham + TienXetNghiem + TienThuoc - TienBHYTChiTra < 0
              THEN CONVERT(DECIMAL(18,2), 0)
              ELSE TienLePhi + TienKham + TienXetNghiem + TienThuoc - TienBHYTChiTra END) PERSISTED,
    TrangThaiThanhToan NVARCHAR(30) NOT NULL DEFAULT N'Chưa thanh toán',
    CONSTRAINT FK_HoaDon_PhieuKham FOREIGN KEY (MaPhieuKham)
        REFERENCES PhieuKham(MaPhieuKham),
    CONSTRAINT FK_HoaDon_HoSo FOREIGN KEY (MaHoSo)
        REFERENCES HoSoBenhAn(MaHoSo),
    CONSTRAINT FK_HoaDon_ThuNgan FOREIGN KEY (MaNhanVienThuNgan)
        REFERENCES NhanVien(MaNhanVien),
    CONSTRAINT CK_HoaDon_TrangThai CHECK (TrangThaiThanhToan IN
        (N'Chưa thanh toán', N'Thanh toán một phần', N'Đã thanh toán', N'Đã hủy')),
    CONSTRAINT CK_HoaDon_Loai CHECK (LoaiHoaDon IN
        (N'Lệ phí mở hồ sơ', N'Phí định kỳ', N'Viện phí'))
);
GO

CREATE UNIQUE INDEX UX_HoaDonVienPhi_PhieuKham
    ON HoaDonVienPhi(MaPhieuKham) WHERE MaPhieuKham IS NOT NULL;
GO

CREATE TABLE GiaoDichThanhToan (
    MaGiaoDich          VARCHAR(20)   NOT NULL PRIMARY KEY,
    MaHoaDon            VARCHAR(20)   NOT NULL,
    NgayGiaoDich        DATETIME2     NOT NULL DEFAULT SYSDATETIME(),
    SoTien              DECIMAL(18,2) NOT NULL CHECK (SoTien > 0),
    PhuongThuc          NVARCHAR(30)  NOT NULL,
    MaGiaoDichNganHang  NVARCHAR(100) NULL,
    TrangThai           NVARCHAR(30)  NOT NULL DEFAULT N'Thành công',
    CONSTRAINT FK_GiaoDich_HoaDon FOREIGN KEY (MaHoaDon)
        REFERENCES HoaDonVienPhi(MaHoaDon),
    CONSTRAINT CK_GiaoDich_PhuongThuc CHECK (PhuongThuc IN
        (N'Tiền mặt', N'Thẻ', N'Chuyển khoản', N'QR')),
    CONSTRAINT CK_GiaoDich_TrangThai CHECK (TrangThai IN
        (N'Đang xử lý', N'Thành công', N'Thất bại', N'Đã hoàn tiền'))
);
GO

/* Bảng mở rộng cho hậu điều kiện ghi nhật ký truy cập của UC03. */
CREATE TABLE NhatKyTruyCap (
    MaNhatKy          BIGINT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    MaNhanVien        VARCHAR(20)   NOT NULL,
    MaHoSo            VARCHAR(20)   NULL,
    ThoiDiem          DATETIME2     NOT NULL DEFAULT SYSDATETIME(),
    HanhDong          NVARCHAR(100) NOT NULL,
    NoiDung           NVARCHAR(500) NULL,
    CONSTRAINT FK_NhatKy_NhanVien FOREIGN KEY (MaNhanVien)
        REFERENCES NhanVien(MaNhanVien),
    CONSTRAINT FK_NhatKy_HoSo FOREIGN KEY (MaHoSo)
        REFERENCES HoSoBenhAn(MaHoSo)
);
GO

/* Chỉ mục hỗ trợ các tiêu chí tra cứu thường dùng. */
CREATE INDEX IX_BenhNhan_HoTen ON BenhNhan(HoTen);
CREATE INDEX IX_PhieuKham_MaHoSo_Ngay ON PhieuKham(MaHoSo, NgayKham DESC);
CREATE INDEX IX_LichKham_NgayHen ON LichKhamDinhKy(NgayHen, TrangThai);
CREATE INDEX IX_ChiTietXN_PhieuKham ON ChiTietXetNghiem(MaPhieuKham, TrangThai);
CREATE INDEX IX_GiaoDich_HoaDon ON GiaoDichThanhToan(MaHoaDon, NgayGiaoDich);
GO

/* Quy tắc phải kiểm tra trong Service/Transaction:
   1. Chỉ tạo HoSoBenhAn sau khi đã thu đủ lệ phí mở hồ sơ (BR03 / UC02).
   2. Đặt lịch trước ít nhất 24 giờ, kiểm tra quota của bác sĩ và tránh trùng lịch (UC04).
   3. Kiểm tra tồn kho, dị ứng và tương tác thuốc trước khi xác nhận toa (UC08).
   4. Tổng tiền giao dịch thành công không vượt số tiền phải trả; chỉ đặt hóa đơn
      'Đã thanh toán' khi tổng tiền đã thu đạt SoTienPhaiTra (BR09).
   5. Khi xuất viện, chuyển hồ sơ/phiếu khám sang trạng thái lưu trữ, khóa chỉnh sửa;
      việc mở khóa phải có phê duyệt quản lý (BR10).
   6. Nên thực hiện thanh toán, trừ kho thuốc và khóa hồ sơ trong transaction để
      tránh cập nhật dở dang. Không xóa cứng hồ sơ bệnh án đã phát sinh dữ liệu y tế.
*/
