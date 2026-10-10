-- =========================================================================
-- HỆ THỐNG QUẢN LÝ CÔNG TY DU LỊCH VĂN HÓA VIỆT TP.HCM (BÀI 6)
-- SV: Nguyễn Phi Long - MSSV: 1250080106 - Lớp: 12_ĐH_CNPM2
-- =========================================================================

IF DB_ID(N'QuanLyCongTyDuLich') IS NULL
    CREATE DATABASE QuanLyCongTyDuLich;
GO
USE QuanLyCongTyDuLich;
GO

-- 1. BẢNG TOUR & ĐỊA ĐIỂM
CREATE TABLE TOUR (
    MaTour INT IDENTITY(1,1) PRIMARY KEY,
    TenTour NVARCHAR(200) NOT NULL,
    SoNgay SMALLINT NOT NULL CHECK (SoNgay > 0),
    SoDem SMALLINT NOT NULL CHECK (SoDem >= 0),
    DonGiaKhach DECIMAL(18,2) NOT NULL CHECK (DonGiaKhach >= 0)
);

CREATE TABLE KHACH_HANG (
    MaKhachHang INT IDENTITY(1,1) PRIMARY KEY,
    LoaiKhachHang NVARCHAR(20) NOT NULL CHECK (LoaiKhachHang IN (N'Doan', N'KhachLe')),
    TenKhachHoacDonVi NVARCHAR(200) NOT NULL,
    DiaChi NVARCHAR(300) NULL,
    DienThoai VARCHAR(20) NOT NULL,
    NguoiDaiDien NVARCHAR(150) NULL
);

CREATE TABLE PHIEU_DANG_KY (
    MaPhieuDangKy INT IDENTITY(1,1) PRIMARY KEY,
    MaKhachHang INT NOT NULL,
    NgayLap DATETIME2 NOT NULL DEFAULT SYSDATETIME(),
    TrangThai NVARCHAR(30) NOT NULL DEFAULT N'ChoXacNhan',
    TongTienDuKien DECIMAL(18,2) NOT NULL DEFAULT 0 CHECK (TongTienDuKien >= 0),
    CONSTRAINT FK_Phieu_Khach FOREIGN KEY (MaKhachHang) REFERENCES KHACH_HANG(MaKhachHang)
);

CREATE TABLE CHUYEN_TOUR (
    MaChuyen INT IDENTITY(1,1) PRIMARY KEY,
    MaTour INT NOT NULL,
    NgayDi DATE NOT NULL,
    NgayVe DATE NOT NULL,
    DiemDonQuyDinh NVARCHAR(300) NOT NULL,
    TrangThai NVARCHAR(30) NOT NULL DEFAULT N'DuKien',
    CONSTRAINT FK_Chuyen_Tour FOREIGN KEY (MaTour) REFERENCES TOUR(MaTour),
    CONSTRAINT CK_Chuyen_Ngay CHECK (NgayVe >= NgayDi)
);

CREATE TABLE DIEM_BAN_VE (
    MaDiemBanVe INT IDENTITY(1,1) PRIMARY KEY,
    TenDiemBan NVARCHAR(150) NOT NULL,
    DiaChi NVARCHAR(300) NOT NULL,
    DienThoai VARCHAR(20) NULL
);

-- 2. KẾ THỪA PHIẾU ĐOÀN VÀ PHIẾU CHUYẾN
CREATE TABLE PHIEU_DANG_KY_DOAN (
    MaPhieuDangKy INT PRIMARY KEY,
    MaTour INT NOT NULL,
    NgayDiChon DATE NOT NULL,
    NgayVeDuKien DATE NOT NULL,
    TenCoQuan NVARCHAR(200) NOT NULL,
    DiaChiCoQuan NVARCHAR(300) NOT NULL,
    DienThoaiCoQuan VARCHAR(20) NOT NULL,
    NguoiDaiDien NVARCHAR(150) NOT NULL,
    SoNguoi INT NOT NULL CHECK (SoNguoi > 12),
    DiaDiemDon NVARCHAR(300) NOT NULL,
    CoMuaBaoHiem BIT NOT NULL DEFAULT 0,
    TienDatCoc DECIMAL(18,2) NOT NULL DEFAULT 0 CHECK (TienDatCoc >= 0),
    CONSTRAINT FK_PhieuDoan_Phieu FOREIGN KEY (MaPhieuDangKy) REFERENCES PHIEU_DANG_KY(MaPhieuDangKy) ON DELETE CASCADE,
    CONSTRAINT FK_PhieuDoan_Tour FOREIGN KEY (MaTour) REFERENCES TOUR(MaTour),
    CONSTRAINT CK_PhieuDoan_Ngay CHECK (NgayVeDuKien >= NgayDiChon)
);

CREATE TABLE NGUOI_DI_BAO_HIEM (
    MaNguoiDiBaoHiem INT IDENTITY(1,1) PRIMARY KEY,
    MaPhieuDangKy INT NOT NULL,
    HoTen NVARCHAR(150) NOT NULL,
    SoGiayTo VARCHAR(50) NULL,
    GhiChu NVARCHAR(200) NULL,
    CONSTRAINT FK_BaoHiem_PhieuDoan FOREIGN KEY (MaPhieuDangKy) REFERENCES PHIEU_DANG_KY_DOAN(MaPhieuDangKy) ON DELETE CASCADE
);

CREATE TABLE PHIEU_DANG_KY_CHUYEN (
    MaPhieuDangKy INT PRIMARY KEY,
    MaChuyen INT NOT NULL,
    MaDiemBanVe INT NOT NULL,
    SoLuongVe INT NOT NULL CHECK (SoLuongVe > 0),
    TongTienVe DECIMAL(18,2) NOT NULL CHECK (TongTienVe >= 0),
    CONSTRAINT FK_PhieuChuyen_Phieu FOREIGN KEY (MaPhieuDangKy) REFERENCES PHIEU_DANG_KY(MaPhieuDangKy) ON DELETE CASCADE,
    CONSTRAINT FK_PhieuChuyen_Chuyen FOREIGN KEY (MaChuyen) REFERENCES CHUYEN_TOUR(MaChuyen),
    CONSTRAINT FK_PhieuChuyen_DiemBan FOREIGN KEY (MaDiemBanVe) REFERENCES DIEM_BAN_VE(MaDiemBanVe)
);

CREATE TABLE GIAO_DICH_THANH_TOAN (
    MaGiaoDich INT IDENTITY(1,1) PRIMARY KEY,
    MaPhieuDangKy INT NOT NULL,
    LoaiThanhToan NVARCHAR(30) NOT NULL CHECK (LoaiThanhToan IN (N'DatCoc', N'VeKhachLe', N'PhanConLai')),
    SoTien DECIMAL(18,2) NOT NULL CHECK (SoTien >= 0),
    NgayThanhToan DATETIME2 NOT NULL DEFAULT SYSDATETIME(),
    TrangThai NVARCHAR(20) NOT NULL DEFAULT N'ChoXuLy' CHECK (TrangThai IN (N'ChoXuLy', N'ThanhCong', N'ThatBai')),
    CONSTRAINT FK_ThanhToan_Phieu FOREIGN KEY (MaPhieuDangKy) REFERENCES PHIEU_DANG_KY(MaPhieuDangKy)
);

-- 3. HƯỚNG DẪN VIÊN & PHÂN CÔNG
CREATE TABLE NHAN_VIEN_HUONG_DAN (
    MaHuongDan INT IDENTITY(1,1) PRIMARY KEY,
    HoTen NVARCHAR(150) NOT NULL,
    DienThoai VARCHAR(20) NULL,
    LuongCanBan DECIMAL(18,2) NOT NULL DEFAULT 0 CHECK (LuongCanBan >= 0),
    TrangThai NVARCHAR(20) NOT NULL DEFAULT N'DangLam'
);

CREATE TABLE PHAN_CONG_HUONG_DAN (
    MaPhanCong INT IDENTITY(1,1) PRIMARY KEY,
    MaHuongDan INT NOT NULL,
    ThoiGianBatDau DATETIME2 NOT NULL,
    ThoiGianKetThuc DATETIME2 NOT NULL,
    TrangThai NVARCHAR(20) NOT NULL DEFAULT N'DuKien',
    TienLuongTour DECIMAL(18,2) NOT NULL DEFAULT 0 CHECK (TienLuongTour >= 0),
    CONSTRAINT FK_PhanCong_HuongDan FOREIGN KEY (MaHuongDan) REFERENCES NHAN_VIEN_HUONG_DAN(MaHuongDan),
    CONSTRAINT CK_PhanCong_ThoiGian CHECK (ThoiGianKetThuc > ThoiGianBatDau)
);

CREATE TABLE PHAN_CONG_DOAN (
    MaPhanCong INT PRIMARY KEY,
    MaPhieuDangKy INT NOT NULL,
    CONSTRAINT FK_PCD_PhanCong FOREIGN KEY (MaPhanCong) REFERENCES PHAN_CONG_HUONG_DAN(MaPhanCong) ON DELETE CASCADE,
    CONSTRAINT FK_PCD_PhieuDoan FOREIGN KEY (MaPhieuDangKy) REFERENCES PHIEU_DANG_KY_DOAN(MaPhieuDangKy)
);

CREATE TABLE PHAN_CONG_CHUYEN (
    MaPhanCong INT PRIMARY KEY,
    MaChuyen INT NOT NULL,
    CONSTRAINT FK_PCC_PhanCong FOREIGN KEY (MaPhanCong) REFERENCES PHAN_CONG_HUONG_DAN(MaPhanCong) ON DELETE CASCADE,
    CONSTRAINT FK_PCC_Chuyen FOREIGN KEY (MaChuyen) REFERENCES CHUYEN_TOUR(MaChuyen)
);

-- NẠP DỮ LIỆU KIỂM THỬ BAN ĐẦU
INSERT INTO TOUR (TenTour, SoNgay, SoDem, DonGiaKhach) VALUES
(N'TP.HCM - Đà Lạt Mộng Mơ', 3, 2, 2500000),
(N'TP.HCM - Nha Trang Biển Gọi', 4, 3, 3200000),
(N'TP.HCM - Miền Tây Sông Nước', 2, 1, 1500000);

INSERT INTO DIEM_BAN_VE (TenDiemBan, DiaChi, DienThoai) VALUES
(N'Văn phòng chính Quận 1', N'123 Lê Lợi, Q.1, TP.HCM', '02838221122'),
(N'Chi nhánh Tân Bình', N'45 Trường Sơn, Tân Bình, TP.HCM', '02838445566');

INSERT INTO NHAN_VIEN_HUONG_DAN (HoTen, DienThoai, LuongCanBan) VALUES
(N'Nguyễn Phi Long', '0901234567', 8000000),
(N'Trần Văn Hướng Dẫn', '0912345678', 7500000);

INSERT INTO CHUYEN_TOUR (MaTour, NgayDi, NgayVe, DiemDonQuyDinh, TrangThai) VALUES
(1, '2026-11-01', '2026-11-03', N'Nhà Văn Hóa Thanh Niên, Q.1', N'DuKien'),
(2, '2026-11-05', '2026-11-08', N'Công viên Tao Đàn, Q.1', N'DuKien');
GO