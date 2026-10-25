/*
 LAB 7 - HE THONG QUAN LY NHAN SU CONG TY SON DONG A
 SQL Server - script khoi tao schema moi.
 Luu y:
 - Tao database rieng QuanLyNhanSu_DongA; khong sua/xoa BusOnDemandDB_Test hay database khac.
 - Ty le bao hiem, gio cong chuan va quy tac quy doi luong phai duoc cong ty xac nhan truoc khi tinh luong that.
 - Script nay duoc soan theo mo ta bai lab; can chay thu tren instance SQL Server truoc khi xem la da kiem thu.
*/
IF DB_ID(N'QuanLyNhanSu_DongA') IS NULL
    EXEC(N'CREATE DATABASE [QuanLyNhanSu_DongA]');
GO
USE QuanLyNhanSu_DongA;
GO
SET ANSI_NULLS ON;
SET QUOTED_IDENTIFIER ON;
GO

-- Cac bang se chi duoc tao neu chua ton tai; khong xoa du lieu dang co.
IF OBJECT_ID(N'dbo.PHONG_BAN', N'U') IS NULL
BEGIN
    CREATE TABLE dbo.PHONG_BAN (
    MaPhongBan       VARCHAR(10)     NOT NULL CONSTRAINT PK_PHONG_BAN PRIMARY KEY,
    TenPhongBan      NVARCHAR(120)   NOT NULL CONSTRAINT UQ_PHONG_BAN_TEN UNIQUE,
    LoaiDonVi        NVARCHAR(40)    NOT NULL CONSTRAINT DF_PHONG_BAN_LOAI DEFAULT N'Phòng ban',
    MoTa             NVARCHAR(300)   NULL,
    TrangThai        NVARCHAR(20)    NOT NULL CONSTRAINT DF_PHONG_BAN_TT DEFAULT N'Hoạt động',
    CONSTRAINT CK_PHONG_BAN_TT CHECK (TrangThai IN (N'Hoạt động', N'Ngừng hoạt động'))
);
END;
GO
IF OBJECT_ID(N'dbo.CHUC_VU', N'U') IS NULL
BEGIN
    CREATE TABLE dbo.CHUC_VU (
    MaChucVu         VARCHAR(10)     NOT NULL CONSTRAINT PK_CHUC_VU PRIMARY KEY,
    TenChucVu        NVARCHAR(100)   NOT NULL CONSTRAINT UQ_CHUC_VU_TEN UNIQUE,
    MoTa             NVARCHAR(300)   NULL,
    TrangThai        NVARCHAR(20)    NOT NULL CONSTRAINT DF_CHUC_VU_TT DEFAULT N'Hoạt động',
    CONSTRAINT CK_CHUC_VU_TT CHECK (TrangThai IN (N'Hoạt động', N'Ngừng hoạt động'))
);
END;
GO
IF OBJECT_ID(N'dbo.NHAN_VIEN', N'U') IS NULL
BEGIN
    CREATE TABLE dbo.NHAN_VIEN (
    MaNhanVien       VARCHAR(15)     NOT NULL CONSTRAINT PK_NHAN_VIEN PRIMARY KEY,
    HoTen            NVARCHAR(150)   NOT NULL,
    NgaySinh         DATE            NULL,
    GioiTinh         NVARCHAR(20)    NULL,
    SoGiayTo         VARCHAR(30)     NULL CONSTRAINT UQ_NHAN_VIEN_GIAYTO UNIQUE,
    SoDienThoai      VARCHAR(20)     NULL,
    Email            NVARCHAR(150)   NULL,
    DiaChi           NVARCHAR(300)   NULL,
    NgayVaoCongTy    DATE            NULL,
    MaPhongBan       VARCHAR(10)     NOT NULL,
    TrangThai        NVARCHAR(30)    NOT NULL CONSTRAINT DF_NHAN_VIEN_TT DEFAULT N'Thử việc',
    GhiChu           NVARCHAR(300)   NULL,
    CONSTRAINT FK_NHAN_VIEN_PHONG FOREIGN KEY (MaPhongBan) REFERENCES dbo.PHONG_BAN(MaPhongBan),
    CONSTRAINT CK_NHAN_VIEN_TT CHECK (TrangThai IN (N'Thử việc', N'Đang làm việc', N'Tạm nghỉ', N'Nghỉ việc')),
    CONSTRAINT CK_NHAN_VIEN_GIOITINH CHECK (GioiTinh IS NULL OR GioiTinh IN (N'Nam', N'Nữ', N'Khác'))
);
END;
GO
IF OBJECT_ID(N'dbo.QUYET_DINH_TUYEN_DUNG', N'U') IS NULL
BEGIN
    CREATE TABLE dbo.QUYET_DINH_TUYEN_DUNG (
    MaQDTuyenDung    VARCHAR(20)     NOT NULL CONSTRAINT PK_QD_TUYEN_DUNG PRIMARY KEY,
    MaNhanVien       VARCHAR(15)     NOT NULL,
    MaPhongBan       VARCHAR(10)     NOT NULL,
    NgayQuyetDinh    DATE            NOT NULL,
    NgayBatDauThuViec DATE           NOT NULL,
    NgayKetThucThuViec DATE          NOT NULL,
    MucLuongThuViec  DECIMAL(18,2)   NOT NULL,
    NoiDung          NVARCHAR(500)   NOT NULL,
    DieuKhoanHaiBen  NVARCHAR(MAX)   NOT NULL,
    NguoiKy          VARCHAR(15)     NULL,
    TrangThai        NVARCHAR(20)    NOT NULL CONSTRAINT DF_QD_TD_TT DEFAULT N'Bản nháp',
    CONSTRAINT FK_QD_TD_NV FOREIGN KEY (MaNhanVien) REFERENCES dbo.NHAN_VIEN(MaNhanVien),
    CONSTRAINT FK_QD_TD_PB FOREIGN KEY (MaPhongBan) REFERENCES dbo.PHONG_BAN(MaPhongBan),
    CONSTRAINT FK_QD_TD_NGUOIKY FOREIGN KEY (NguoiKy) REFERENCES dbo.NHAN_VIEN(MaNhanVien),
    CONSTRAINT CK_QD_TD_NGAY CHECK (NgayKetThucThuViec >= NgayBatDauThuViec AND NgayBatDauThuViec >= NgayQuyetDinh),
    CONSTRAINT CK_QD_TD_LUONG CHECK (MucLuongThuViec >= 0),
    CONSTRAINT CK_QD_TD_TT CHECK (TrangThai IN (N'Bản nháp', N'Đã ký', N'Từ chối'))
);
END;
GO
IF OBJECT_ID(N'dbo.HOP_DONG_LAO_DONG', N'U') IS NULL
BEGIN
    CREATE TABLE dbo.HOP_DONG_LAO_DONG (
    MaHopDong        VARCHAR(20)     NOT NULL CONSTRAINT PK_HOP_DONG PRIMARY KEY,
    SoHopDong        VARCHAR(30)     NOT NULL CONSTRAINT UQ_HOP_DONG_SO UNIQUE,
    MaNhanVien       VARCHAR(15)     NOT NULL,
    LoaiHopDong      NVARCHAR(20)    NOT NULL,
    NgayKy           DATE            NOT NULL,
    NgayHieuLuc      DATE            NOT NULL,
    NgayKetThuc      DATE            NULL,
    TrangThai        NVARCHAR(20)    NOT NULL CONSTRAINT DF_HOP_DONG_TT DEFAULT N'Chờ hiệu lực',
    NoiDung          NVARCHAR(MAX)   NULL,
    CONSTRAINT FK_HOP_DONG_NV FOREIGN KEY (MaNhanVien) REFERENCES dbo.NHAN_VIEN(MaNhanVien),
    CONSTRAINT CK_HOP_DONG_LOAI CHECK (LoaiHopDong IN (N'Dài hạn', N'Ngắn hạn')),
    CONSTRAINT CK_HOP_DONG_NGAY CHECK (NgayHieuLuc >= NgayKy AND (NgayKetThuc IS NULL OR NgayKetThuc >= NgayHieuLuc)),
    CONSTRAINT CK_HOP_DONG_TT CHECK (TrangThai IN (N'Chờ hiệu lực', N'Hiệu lực', N'Hết hạn', N'Chấm dứt'))
);
END;
GO
IF OBJECT_ID(N'dbo.QUYET_DINH_CHUC_VU', N'U') IS NULL
BEGIN
    CREATE TABLE dbo.QUYET_DINH_CHUC_VU (
    MaQDChucVu       VARCHAR(20)     NOT NULL CONSTRAINT PK_QD_CHUC_VU PRIMARY KEY,
    MaNhanVien       VARCHAR(15)     NOT NULL,
    MaChucVu         VARCHAR(10)     NOT NULL,
    MaPhongBan       VARCHAR(10)     NULL,
    NgayQuyetDinh    DATE            NOT NULL,
    NgayHieuLuc      DATE            NOT NULL,
    PhuCapChucVu     DECIMAL(18,2)   NOT NULL CONSTRAINT DF_QD_CV_PC DEFAULT 0,
    NoiDung          NVARCHAR(500)   NOT NULL,
    NguoiKy          VARCHAR(15)     NULL,
    TrangThai        NVARCHAR(20)    NOT NULL CONSTRAINT DF_QD_CV_TT DEFAULT N'Bản nháp',
    CONSTRAINT FK_QD_CV_NV FOREIGN KEY (MaNhanVien) REFERENCES dbo.NHAN_VIEN(MaNhanVien),
    CONSTRAINT FK_QD_CV_CV FOREIGN KEY (MaChucVu) REFERENCES dbo.CHUC_VU(MaChucVu),
    CONSTRAINT FK_QD_CV_PB FOREIGN KEY (MaPhongBan) REFERENCES dbo.PHONG_BAN(MaPhongBan),
    CONSTRAINT FK_QD_CV_NGUOIKY FOREIGN KEY (NguoiKy) REFERENCES dbo.NHAN_VIEN(MaNhanVien),
    CONSTRAINT CK_QD_CV_PC CHECK (PhuCapChucVu >= 0),
    CONSTRAINT CK_QD_CV_TT CHECK (TrangThai IN (N'Bản nháp', N'Đã ký', N'Từ chối'))
);
END;
GO
IF OBJECT_ID(N'dbo.QUYET_DINH_LUONG', N'U') IS NULL
BEGIN
    CREATE TABLE dbo.QUYET_DINH_LUONG (
    MaQDLuong        VARCHAR(20)     NOT NULL CONSTRAINT PK_QD_LUONG PRIMARY KEY,
    MaNhanVien       VARCHAR(15)     NOT NULL,
    NgayQuyetDinh    DATE            NOT NULL,
    NgayHieuLuc      DATE            NOT NULL,
    MucLuongCoBan    DECIMAL(18,2)   NOT NULL,
    PhuCapLuong      DECIMAL(18,2)   NOT NULL CONSTRAINT DF_QD_LUONG_PCL DEFAULT 0,
    PhuCapDocHai     DECIMAL(18,2)   NOT NULL CONSTRAINT DF_QD_LUONG_PCDH DEFAULT 0,
    NoiDung          NVARCHAR(500)   NOT NULL,
    NguoiKy          VARCHAR(15)     NULL,
    TrangThai        NVARCHAR(20)    NOT NULL CONSTRAINT DF_QD_LUONG_TT DEFAULT N'Bản nháp',
    CONSTRAINT FK_QD_LUONG_NV FOREIGN KEY (MaNhanVien) REFERENCES dbo.NHAN_VIEN(MaNhanVien),
    CONSTRAINT FK_QD_LUONG_NGUOIKY FOREIGN KEY (NguoiKy) REFERENCES dbo.NHAN_VIEN(MaNhanVien),
    CONSTRAINT CK_QD_LUONG_TIEN CHECK (MucLuongCoBan >= 0 AND PhuCapLuong >= 0 AND PhuCapDocHai >= 0),
    CONSTRAINT CK_QD_LUONG_TT CHECK (TrangThai IN (N'Bản nháp', N'Đã ký', N'Từ chối'))
);
END;
GO
IF OBJECT_ID(N'dbo.HO_SO_BAO_HIEM', N'U') IS NULL
BEGIN
    CREATE TABLE dbo.HO_SO_BAO_HIEM (
    MaHoSoBaoHiem    VARCHAR(20)     NOT NULL CONSTRAINT PK_HO_SO_BAO_HIEM PRIMARY KEY,
    MaNhanVien       VARCHAR(15)     NOT NULL,
    MaHopDong        VARCHAR(20)     NOT NULL,
    LoaiBaoHiem      NVARCHAR(10)    NOT NULL,
    SoTheMaSo        VARCHAR(40)     NULL,
    MucLuongCanCu    DECIMAL(18,2)   NULL,
    TyLeNguoiLaoDong DECIMAL(5,2)    NULL,
    TyLeCongTy       DECIMAL(5,2)    NULL,
    NgayBatDau       DATE            NOT NULL,
    NgayKetThuc      DATE            NULL,
    TrangThai        NVARCHAR(20)    NOT NULL CONSTRAINT DF_HS_BH_TT DEFAULT N'Hiệu lực',
    CONSTRAINT FK_HS_BH_NV FOREIGN KEY (MaNhanVien) REFERENCES dbo.NHAN_VIEN(MaNhanVien),
    CONSTRAINT FK_HS_BH_HD FOREIGN KEY (MaHopDong) REFERENCES dbo.HOP_DONG_LAO_DONG(MaHopDong),
    CONSTRAINT CK_HS_BH_LOAI CHECK (LoaiBaoHiem IN (N'BHXH', N'BHYT')),
    CONSTRAINT CK_HS_BH_MUC CHECK ((MucLuongCanCu IS NULL OR MucLuongCanCu >= 0) AND (TyLeNguoiLaoDong IS NULL OR TyLeNguoiLaoDong BETWEEN 0 AND 100) AND (TyLeCongTy IS NULL OR TyLeCongTy BETWEEN 0 AND 100)),
    CONSTRAINT CK_HS_BH_NGAY CHECK (NgayKetThuc IS NULL OR NgayKetThuc >= NgayBatDau),
    CONSTRAINT CK_HS_BH_TT CHECK (TrangThai IN (N'Hiệu lực', N'Tạm dừng', N'Kết thúc'))
);
END;
GO
IF OBJECT_ID(N'dbo.CA_LAM_VIEC', N'U') IS NULL
BEGIN
    CREATE TABLE dbo.CA_LAM_VIEC (
    MaCa             VARCHAR(10)     NOT NULL CONSTRAINT PK_CA_LAM_VIEC PRIMARY KEY,
    TenCa            NVARCHAR(80)    NOT NULL CONSTRAINT UQ_CA_LAM_VIEC_TEN UNIQUE,
    GioBatDau        TIME            NOT NULL,
    GioKetThuc       TIME            NOT NULL,
    MoTa             NVARCHAR(200)   NULL,
    TrangThai        NVARCHAR(20)    NOT NULL CONSTRAINT DF_CA_TT DEFAULT N'Hoạt động',
    CONSTRAINT CK_CA_TT CHECK (TrangThai IN (N'Hoạt động', N'Ngừng hoạt động'))
);
END;
GO
IF OBJECT_ID(N'dbo.KE_HOACH_PHAN_CONG', N'U') IS NULL
BEGIN
    CREATE TABLE dbo.KE_HOACH_PHAN_CONG (
    MaPhanCong       BIGINT IDENTITY(1,1) NOT NULL CONSTRAINT PK_KE_HOACH_PHAN_CONG PRIMARY KEY,
    MaNhanVien       VARCHAR(15)     NOT NULL,
    MaCa             VARCHAR(10)     NOT NULL,
    NgayLamViec      DATE            NOT NULL,
    TuanBatDau       DATE            NOT NULL,
    MaNguoiLap       VARCHAR(15)     NOT NULL,
    NgayLap          DATETIME2(0)    NOT NULL CONSTRAINT DF_KH_NGAYLAP DEFAULT SYSDATETIME(),
    GhiChu           NVARCHAR(200)   NULL,
    CONSTRAINT FK_KH_PC_NV FOREIGN KEY (MaNhanVien) REFERENCES dbo.NHAN_VIEN(MaNhanVien),
    CONSTRAINT FK_KH_PC_CA FOREIGN KEY (MaCa) REFERENCES dbo.CA_LAM_VIEC(MaCa),
    CONSTRAINT FK_KH_PC_NGUOILAP FOREIGN KEY (MaNguoiLap) REFERENCES dbo.NHAN_VIEN(MaNhanVien),
    CONSTRAINT UQ_KH_PC_NV_NGAY UNIQUE (MaNhanVien, NgayLamViec),
    CONSTRAINT CK_KH_PC_TUAN CHECK (TuanBatDau <= NgayLamViec)
);
END;
GO
IF OBJECT_ID(N'dbo.PHIEU_CHAM_CONG', N'U') IS NULL
BEGIN
    CREATE TABLE dbo.PHIEU_CHAM_CONG (
    MaPhieuChamCong  VARCHAR(20)     NOT NULL CONSTRAINT PK_PHIEU_CHAM_CONG PRIMARY KEY,
    Thang            TINYINT         NOT NULL,
    Nam              SMALLINT        NOT NULL,
    NgayLap          DATETIME2(0)    NOT NULL CONSTRAINT DF_PCC_NGAYLAP DEFAULT SYSDATETIME(),
    MaNguoiLap       VARCHAR(15)     NOT NULL,
    TrangThai        NVARCHAR(20)    NOT NULL CONSTRAINT DF_PCC_TT DEFAULT N'Bản nháp',
    GhiChu           NVARCHAR(300)   NULL,
    CONSTRAINT FK_PCC_NGUOILAP FOREIGN KEY (MaNguoiLap) REFERENCES dbo.NHAN_VIEN(MaNhanVien),
    CONSTRAINT UQ_PCC_KY UNIQUE (Thang, Nam),
    CONSTRAINT CK_PCC_THANG CHECK (Thang BETWEEN 1 AND 12),
    CONSTRAINT CK_PCC_NAM CHECK (Nam BETWEEN 2000 AND 2100),
    CONSTRAINT CK_PCC_TT CHECK (TrangThai IN (N'Bản nháp', N'Đã chốt'))
);
END;
GO
IF OBJECT_ID(N'dbo.CHI_TIET_CHAM_CONG', N'U') IS NULL
BEGIN
    CREATE TABLE dbo.CHI_TIET_CHAM_CONG (
    MaChiTietChamCong BIGINT IDENTITY(1,1) NOT NULL CONSTRAINT PK_CT_CHAM_CONG PRIMARY KEY,
    MaPhieuChamCong  VARCHAR(20)     NOT NULL,
    MaNhanVien       VARCHAR(15)     NOT NULL,
    NgayCong         DATE            NOT NULL,
    SoGioCong        DECIMAL(5,2)    NOT NULL CONSTRAINT DF_CT_CC_GIO DEFAULT 0,
    TrangThai        NVARCHAR(20)    NOT NULL,
    GhiChu           NVARCHAR(200)   NULL,
    CONSTRAINT FK_CT_CC_PCC FOREIGN KEY (MaPhieuChamCong) REFERENCES dbo.PHIEU_CHAM_CONG(MaPhieuChamCong),
    CONSTRAINT FK_CT_CC_NV FOREIGN KEY (MaNhanVien) REFERENCES dbo.NHAN_VIEN(MaNhanVien),
    CONSTRAINT UQ_CT_CC_NV_NGAY UNIQUE (MaPhieuChamCong, MaNhanVien, NgayCong),
    CONSTRAINT CK_CT_CC_GIO CHECK (SoGioCong BETWEEN 0 AND 24),
    CONSTRAINT CK_CT_CC_TT CHECK (TrangThai IN (N'Có mặt', N'Vắng có phép', N'Vắng không phép', N'Nghỉ lễ', N'Nghỉ phép'))
);
END;
GO
IF OBJECT_ID(N'dbo.PHIEU_PHU_TROI', N'U') IS NULL
BEGIN
    CREATE TABLE dbo.PHIEU_PHU_TROI (
    MaPhieuPhuTroi    VARCHAR(20)     NOT NULL CONSTRAINT PK_PHIEU_PHU_TROI PRIMARY KEY,
    NgayPhuTroi       DATE            NOT NULL,
    SoGioPhuTroi      DECIMAL(5,2)    NOT NULL,
    HinhThuc          NVARCHAR(20)    NOT NULL,
    NgayLap           DATETIME2(0)    NOT NULL CONSTRAINT DF_PPT_NGAYLAP DEFAULT SYSDATETIME(),
    MaNguoiLap        VARCHAR(15)     NOT NULL,
    TrangThai         NVARCHAR(20)    NOT NULL CONSTRAINT DF_PPT_TT DEFAULT N'Bản nháp',
    GhiChu            NVARCHAR(300)   NULL,
    CONSTRAINT FK_PPT_NGUOILAP FOREIGN KEY (MaNguoiLap) REFERENCES dbo.NHAN_VIEN(MaNhanVien),
    CONSTRAINT CK_PPT_GIO CHECK (SoGioPhuTroi > 0 AND SoGioPhuTroi <= 24),
    CONSTRAINT CK_PPT_HT CHECK (HinhThuc IN (N'Tăng ca', N'Ngày lễ', N'Ngày nghỉ')),
    CONSTRAINT CK_PPT_TT CHECK (TrangThai IN (N'Bản nháp', N'Đã xác nhận', N'Hủy'))
);
END;
GO
IF OBJECT_ID(N'dbo.CHI_TIET_PHU_TROI', N'U') IS NULL
BEGIN
    CREATE TABLE dbo.CHI_TIET_PHU_TROI (
    MaPhieuPhuTroi    VARCHAR(20)     NOT NULL,
    MaNhanVien        VARCHAR(15)     NOT NULL,
    GhiChu            NVARCHAR(200)   NULL,
    CONSTRAINT PK_CT_PHU_TROI PRIMARY KEY (MaPhieuPhuTroi, MaNhanVien),
    CONSTRAINT FK_CT_PT_PPT FOREIGN KEY (MaPhieuPhuTroi) REFERENCES dbo.PHIEU_PHU_TROI(MaPhieuPhuTroi),
    CONSTRAINT FK_CT_PT_NV FOREIGN KEY (MaNhanVien) REFERENCES dbo.NHAN_VIEN(MaNhanVien)
);
END;
GO
IF OBJECT_ID(N'dbo.BANG_LUONG', N'U') IS NULL
BEGIN
    CREATE TABLE dbo.BANG_LUONG (
    MaBangLuong       VARCHAR(20)     NOT NULL CONSTRAINT PK_BANG_LUONG PRIMARY KEY,
    MaNhanVien        VARCHAR(15)     NOT NULL,
    Thang             TINYINT         NOT NULL,
    Nam               SMALLINT        NOT NULL,
    MucLuongCoBan     DECIMAL(18,2)   NOT NULL,
    PhuCapChucVu      DECIMAL(18,2)   NOT NULL CONSTRAINT DF_BL_PCCV DEFAULT 0,
    PhuCapLuong       DECIMAL(18,2)   NOT NULL CONSTRAINT DF_BL_PCL DEFAULT 0,
    PhuCapDocHai      DECIMAL(18,2)   NOT NULL CONSTRAINT DF_BL_PCDH DEFAULT 0,
    SoGioCong         DECIMAL(8,2)    NOT NULL CONSTRAINT DF_BL_GIOCONG DEFAULT 0,
    SoGioPhuTroi      DECIMAL(8,2)    NOT NULL CONSTRAINT DF_BL_GIOPT DEFAULT 0,
    HeSoPhuTroi       DECIMAL(4,2)    NOT NULL CONSTRAINT DF_BL_HSPT DEFAULT 1.5,
    TienLuongTheoCong DECIMAL(18,2)   NOT NULL CONSTRAINT DF_BL_LTC DEFAULT 0,
    TienPhuTroi       DECIMAL(18,2)   NOT NULL CONSTRAINT DF_BL_TPT DEFAULT 0,
    TienBHXH          DECIMAL(18,2)   NOT NULL CONSTRAINT DF_BL_BHXH DEFAULT 0,
    TienBHYT          DECIMAL(18,2)   NOT NULL CONSTRAINT DF_BL_BHYT DEFAULT 0,
    TienPhatTruLuong  DECIMAL(18,2)   NOT NULL CONSTRAINT DF_BL_PHAT DEFAULT 0,
    LuongThucLanh     DECIMAL(18,2)   NOT NULL CONSTRAINT DF_BL_TL DEFAULT 0,
    NgayTinh          DATETIME2(0)    NOT NULL CONSTRAINT DF_BL_NGAYTINH DEFAULT SYSDATETIME(),
    TrangThai         NVARCHAR(20)    NOT NULL CONSTRAINT DF_BL_TT DEFAULT N'Bản nháp',
    GhiChu            NVARCHAR(300)   NULL,
    CONSTRAINT FK_BL_NV FOREIGN KEY (MaNhanVien) REFERENCES dbo.NHAN_VIEN(MaNhanVien),
    CONSTRAINT UQ_BL_NV_KY UNIQUE (MaNhanVien, Thang, Nam),
    CONSTRAINT CK_BL_KY CHECK (Thang BETWEEN 1 AND 12 AND Nam BETWEEN 2000 AND 2100),
    CONSTRAINT CK_BL_TIEN CHECK (MucLuongCoBan >= 0 AND PhuCapChucVu >= 0 AND PhuCapLuong >= 0 AND PhuCapDocHai >= 0 AND TienBHXH >= 0 AND TienBHYT >= 0 AND TienPhatTruLuong >= 0),
    CONSTRAINT CK_BL_HS CHECK (HeSoPhuTroi > 0),
    CONSTRAINT CK_BL_TT CHECK (TrangThai IN (N'Bản nháp', N'Chờ duyệt', N'Đã duyệt', N'Đã thanh toán'))
);
END;
GO
IF OBJECT_ID(N'dbo.QUYET_DINH_KHEN_THUONG', N'U') IS NULL
BEGIN
    CREATE TABLE dbo.QUYET_DINH_KHEN_THUONG (
    MaQDKhenThuong    VARCHAR(20)     NOT NULL CONSTRAINT PK_QD_KHEN_THUONG PRIMARY KEY,
    LoaiDoiTuong      NVARCHAR(20)    NOT NULL,
    MaNhanVien        VARCHAR(15)     NULL,
    MaPhongBan        VARCHAR(10)     NULL,
    NgayQuyetDinh     DATE            NOT NULL,
    SoTienThuong      DECIMAL(18,2)   NOT NULL,
    LyDo              NVARCHAR(500)   NOT NULL,
    NguoiKy           VARCHAR(15)     NULL,
    TrangThai         NVARCHAR(20)    NOT NULL CONSTRAINT DF_QDKT_TT DEFAULT N'Bản nháp',
    CONSTRAINT FK_QDKT_NV FOREIGN KEY (MaNhanVien) REFERENCES dbo.NHAN_VIEN(MaNhanVien),
    CONSTRAINT FK_QDKT_PB FOREIGN KEY (MaPhongBan) REFERENCES dbo.PHONG_BAN(MaPhongBan),
    CONSTRAINT FK_QDKT_NGUOIKY FOREIGN KEY (NguoiKy) REFERENCES dbo.NHAN_VIEN(MaNhanVien),
    CONSTRAINT CK_QDKT_DOITUONG CHECK ((LoaiDoiTuong = N'Cá nhân' AND MaNhanVien IS NOT NULL AND MaPhongBan IS NULL) OR (LoaiDoiTuong = N'Tập thể' AND MaNhanVien IS NULL AND MaPhongBan IS NOT NULL)),
    CONSTRAINT CK_QDKT_TIEN CHECK (SoTienThuong >= 0),
    CONSTRAINT CK_QDKT_TT CHECK (TrangThai IN (N'Bản nháp', N'Đã ký', N'Từ chối', N'Đã chi'))
);
END;
GO
IF OBJECT_ID(N'dbo.PHIEU_CHI_KHEN_THUONG', N'U') IS NULL
BEGIN
    CREATE TABLE dbo.PHIEU_CHI_KHEN_THUONG (
    MaPhieuChi        VARCHAR(20)     NOT NULL CONSTRAINT PK_PHIEU_CHI_KT PRIMARY KEY,
    MaQDKhenThuong    VARCHAR(20)     NOT NULL CONSTRAINT UQ_PHIEU_CHI_QDKT UNIQUE,
    NgayChi           DATE            NOT NULL,
    SoTienChi         DECIMAL(18,2)   NOT NULL,
    NguoiLap          VARCHAR(15)     NOT NULL,
    GhiChu            NVARCHAR(200)   NULL,
    CONSTRAINT FK_PC_KT_QD FOREIGN KEY (MaQDKhenThuong) REFERENCES dbo.QUYET_DINH_KHEN_THUONG(MaQDKhenThuong),
    CONSTRAINT FK_PC_KT_NV FOREIGN KEY (NguoiLap) REFERENCES dbo.NHAN_VIEN(MaNhanVien),
    CONSTRAINT CK_PC_KT_TIEN CHECK (SoTienChi >= 0)
);
END;
GO
IF OBJECT_ID(N'dbo.QUYET_DINH_KY_LUAT', N'U') IS NULL
BEGIN
    CREATE TABLE dbo.QUYET_DINH_KY_LUAT (
    MaQDKyLuat        VARCHAR(20)     NOT NULL CONSTRAINT PK_QD_KY_LUAT PRIMARY KEY,
    LoaiDoiTuong      NVARCHAR(20)    NOT NULL,
    MaNhanVien        VARCHAR(15)     NULL,
    MaPhongBan        VARCHAR(10)     NULL,
    NgayQuyetDinh     DATE            NOT NULL,
    SoTienPhat        DECIMAL(18,2)   NOT NULL,
    HinhThucXuLy      NVARCHAR(20)    NOT NULL,
    LyDo              NVARCHAR(500)   NOT NULL,
    NguoiKy           VARCHAR(15)     NULL,
    MaBangLuongTru    VARCHAR(20)     NULL,
    TrangThai         NVARCHAR(20)    NOT NULL CONSTRAINT DF_QDKL_TT DEFAULT N'Bản nháp',
    CONSTRAINT FK_QDKL_NV FOREIGN KEY (MaNhanVien) REFERENCES dbo.NHAN_VIEN(MaNhanVien),
    CONSTRAINT FK_QDKL_PB FOREIGN KEY (MaPhongBan) REFERENCES dbo.PHONG_BAN(MaPhongBan),
    CONSTRAINT FK_QDKL_NGUOIKY FOREIGN KEY (NguoiKy) REFERENCES dbo.NHAN_VIEN(MaNhanVien),
    CONSTRAINT FK_QDKL_BL FOREIGN KEY (MaBangLuongTru) REFERENCES dbo.BANG_LUONG(MaBangLuong),
    CONSTRAINT CK_QDKL_DOITUONG CHECK ((LoaiDoiTuong = N'Cá nhân' AND MaNhanVien IS NOT NULL AND MaPhongBan IS NULL) OR (LoaiDoiTuong = N'Tập thể' AND MaNhanVien IS NULL AND MaPhongBan IS NOT NULL)),
    CONSTRAINT CK_QDKL_TIEN CHECK (SoTienPhat >= 0),
    CONSTRAINT CK_QDKL_HT CHECK (HinhThucXuLy IN (N'Thu phiếu', N'Trừ lương')),
    CONSTRAINT CK_QDKL_TRULUONG CHECK (HinhThucXuLy <> N'Trừ lương' OR (LoaiDoiTuong = N'Cá nhân' AND MaNhanVien IS NOT NULL)),
    CONSTRAINT CK_QDKL_TT CHECK (TrangThai IN (N'Bản nháp', N'Đã ký', N'Đã thu', N'Đã khấu trừ', N'Từ chối'))
);
END;
GO
IF OBJECT_ID(N'dbo.PHIEU_THU_NOP_PHAT', N'U') IS NULL
BEGIN
    CREATE TABLE dbo.PHIEU_THU_NOP_PHAT (
    MaPhieuThu        VARCHAR(20)     NOT NULL CONSTRAINT PK_PHIEU_THU_PHAT PRIMARY KEY,
    MaQDKyLuat        VARCHAR(20)     NOT NULL CONSTRAINT UQ_PHIEU_THU_QDKL UNIQUE,
    NgayThu           DATE            NOT NULL,
    SoTienThu         DECIMAL(18,2)   NOT NULL,
    NguoiLap          VARCHAR(15)     NOT NULL,
    GhiChu            NVARCHAR(200)   NULL,
    CONSTRAINT FK_PT_PHAT_QD FOREIGN KEY (MaQDKyLuat) REFERENCES dbo.QUYET_DINH_KY_LUAT(MaQDKyLuat),
    CONSTRAINT FK_PT_PHAT_NV FOREIGN KEY (NguoiLap) REFERENCES dbo.NHAN_VIEN(MaNhanVien),
    CONSTRAINT CK_PT_PHAT_TIEN CHECK (SoTienThu >= 0)
);
END;
GO

IF NOT EXISTS (SELECT 1 FROM sys.indexes WHERE name=N'IX_NHAN_VIEN_PHONG_TT' AND object_id=OBJECT_ID(N'dbo.NHAN_VIEN')) CREATE INDEX IX_NHAN_VIEN_PHONG_TT ON dbo.NHAN_VIEN(MaPhongBan, TrangThai);
IF NOT EXISTS (SELECT 1 FROM sys.indexes WHERE name=N'IX_HD_NV_HIEULUC' AND object_id=OBJECT_ID(N'dbo.HOP_DONG_LAO_DONG')) CREATE INDEX IX_HD_NV_HIEULUC ON dbo.HOP_DONG_LAO_DONG(MaNhanVien, NgayHieuLuc, NgayKetThuc);
IF NOT EXISTS (SELECT 1 FROM sys.indexes WHERE name=N'IX_QDL_NV_HIEULUC' AND object_id=OBJECT_ID(N'dbo.QUYET_DINH_LUONG')) CREATE INDEX IX_QDL_NV_HIEULUC ON dbo.QUYET_DINH_LUONG(MaNhanVien, NgayHieuLuc, TrangThai);
IF NOT EXISTS (SELECT 1 FROM sys.indexes WHERE name=N'IX_QDCV_NV_HIEULUC' AND object_id=OBJECT_ID(N'dbo.QUYET_DINH_CHUC_VU')) CREATE INDEX IX_QDCV_NV_HIEULUC ON dbo.QUYET_DINH_CHUC_VU(MaNhanVien, NgayHieuLuc, TrangThai);
IF NOT EXISTS (SELECT 1 FROM sys.indexes WHERE name=N'IX_CTCC_NGAY_NV' AND object_id=OBJECT_ID(N'dbo.CHI_TIET_CHAM_CONG')) CREATE INDEX IX_CTCC_NGAY_NV ON dbo.CHI_TIET_CHAM_CONG(NgayCong, MaNhanVien);
IF NOT EXISTS (SELECT 1 FROM sys.indexes WHERE name=N'IX_PPT_NGAY_TT' AND object_id=OBJECT_ID(N'dbo.PHIEU_PHU_TROI')) CREATE INDEX IX_PPT_NGAY_TT ON dbo.PHIEU_PHU_TROI(NgayPhuTroi, TrangThai);
GO

CREATE OR ALTER VIEW dbo.vw_HoSoNhanVienTongHop
AS
SELECT nv.MaNhanVien, nv.HoTen, nv.NgaySinh, nv.GioiTinh, nv.SoDienThoai, nv.Email,
       pb.TenPhongBan, nv.TrangThai, nv.NgayVaoCongTy
FROM dbo.NHAN_VIEN nv
JOIN dbo.PHONG_BAN pb ON pb.MaPhongBan = nv.MaPhongBan;
GO

/*
 Stored procedure tinh bang luong o muc khung tham khao.
 @GioCongChuanThang bat buoc do de bai khong quy dinh con so nay.
 Ty le bao hiem lay tu HO_SO_BAO_HIEM; khong hard-code ty le phap ly.
 Can doi chieu quy tac luong cua cong ty truoc khi su dung cho tinh luong that.
*/
CREATE OR ALTER PROCEDURE dbo.sp_TinhBangLuongThang
    @Thang TINYINT,
    @Nam SMALLINT,
    @GioCongChuanThang DECIMAL(8,2)
AS
BEGIN
    SET NOCOUNT ON;
    SET XACT_ABORT ON;
    IF @Thang NOT BETWEEN 1 AND 12 THROW 51001, N'Thang khong hop le.', 1;
    IF @GioCongChuanThang <= 0 THROW 51002, N'Gio cong chuan phai lon hon 0 va do cong ty xac nhan.', 1;

    DECLARE @NgayDau DATE = DATEFROMPARTS(@Nam, @Thang, 1);
    DECLARE @NgayCuoi DATE = EOMONTH(@NgayDau);

    IF EXISTS (
        SELECT 1
        FROM dbo.NHAN_VIEN nv
        WHERE nv.TrangThai = N'Đang làm việc'
          AND EXISTS (SELECT 1 FROM dbo.HOP_DONG_LAO_DONG hd WHERE hd.MaNhanVien=nv.MaNhanVien AND hd.LoaiHopDong=N'Dài hạn' AND hd.NgayHieuLuc<=@NgayCuoi AND (hd.NgayKetThuc IS NULL OR hd.NgayKetThuc>=@NgayDau) AND hd.TrangThai=N'Hiệu lực')
          AND (SELECT COUNT(DISTINCT hs.LoaiBaoHiem) FROM dbo.HO_SO_BAO_HIEM hs WHERE hs.MaNhanVien=nv.MaNhanVien AND hs.TrangThai=N'Hiệu lực' AND hs.NgayBatDau<=@NgayCuoi AND (hs.NgayKetThuc IS NULL OR hs.NgayKetThuc>=@NgayDau) AND hs.LoaiBaoHiem IN (N'BHXH',N'BHYT') AND hs.MucLuongCanCu IS NOT NULL AND hs.TyLeNguoiLaoDong IS NOT NULL) < 2
    ) THROW 51003, N'Nhat ky luong: nhan vien co hop dong dai han can co ho so BHXH/BHYT va ty le nguoi lao dong duoc khai bao.', 1;

    BEGIN TRANSACTION;
    DECLARE @Tinh TABLE (
      MaNhanVien VARCHAR(15) PRIMARY KEY,
      MucLuongCoBan DECIMAL(18,2), PhuCapChucVu DECIMAL(18,2), PhuCapLuong DECIMAL(18,2), PhuCapDocHai DECIMAL(18,2),
      SoGioCong DECIMAL(8,2), SoGioPhuTroi DECIMAL(8,2), TienLuongTheoCong DECIMAL(18,2), TienPhuTroi DECIMAL(18,2),
      TienBHXH DECIMAL(18,2), TienBHYT DECIMAL(18,2), TienPhatTruLuong DECIMAL(18,2), LuongThucLanh DECIMAL(18,2)
    );

    ;WITH Nguon AS (
      SELECT nv.MaNhanVien,
        ISNULL(qdl.MucLuongCoBan,qdt.MucLuongThuViec) AS MucLuongCoBan,
        ISNULL(qdcv.PhuCapChucVu,0) AS PhuCapChucVu,
        ISNULL(qdl.PhuCapLuong,0) AS PhuCapLuong,
        ISNULL(qdl.PhuCapDocHai,0) AS PhuCapDocHai,
        ISNULL(cc.SoGioCong,0) AS SoGioCong,
        ISNULL(pt.SoGioPhuTroi,0) AS SoGioPhuTroi,
        ISNULL(bh.TienBHXH,0) AS TienBHXH,
        ISNULL(bh.TienBHYT,0) AS TienBHYT,
        ISNULL(ph.TienPhat,0) AS TienPhatTruLuong
      FROM dbo.NHAN_VIEN nv
      OUTER APPLY (SELECT TOP (1) q.MucLuongCoBan,q.PhuCapLuong,q.PhuCapDocHai FROM dbo.QUYET_DINH_LUONG q WHERE q.MaNhanVien=nv.MaNhanVien AND q.TrangThai=N'Đã ký' AND q.NgayHieuLuc<=@NgayCuoi ORDER BY q.NgayHieuLuc DESC,q.NgayQuyetDinh DESC) qdl
      OUTER APPLY (SELECT TOP (1) q.MucLuongThuViec FROM dbo.QUYET_DINH_TUYEN_DUNG q WHERE q.MaNhanVien=nv.MaNhanVien AND q.TrangThai=N'Đã ký' AND q.NgayBatDauThuViec<=@NgayCuoi AND q.NgayKetThucThuViec>=@NgayDau ORDER BY q.NgayQuyetDinh DESC) qdt
      OUTER APPLY (SELECT TOP (1) q.PhuCapChucVu FROM dbo.QUYET_DINH_CHUC_VU q WHERE q.MaNhanVien=nv.MaNhanVien AND q.TrangThai=N'Đã ký' AND q.NgayHieuLuc<=@NgayCuoi ORDER BY q.NgayHieuLuc DESC,q.NgayQuyetDinh DESC) qdcv
      OUTER APPLY (SELECT SUM(ct.SoGioCong) AS SoGioCong FROM dbo.CHI_TIET_CHAM_CONG ct JOIN dbo.PHIEU_CHAM_CONG p ON p.MaPhieuChamCong=ct.MaPhieuChamCong WHERE ct.MaNhanVien=nv.MaNhanVien AND p.Thang=@Thang AND p.Nam=@Nam AND p.TrangThai=N'Đã chốt' AND ct.NgayCong BETWEEN @NgayDau AND @NgayCuoi) cc
      OUTER APPLY (SELECT SUM(p.SoGioPhuTroi) AS SoGioPhuTroi FROM dbo.PHIEU_PHU_TROI p JOIN dbo.CHI_TIET_PHU_TROI ct ON ct.MaPhieuPhuTroi=p.MaPhieuPhuTroi WHERE ct.MaNhanVien=nv.MaNhanVien AND p.NgayPhuTroi BETWEEN @NgayDau AND @NgayCuoi AND p.TrangThai=N'Đã xác nhận') pt
      OUTER APPLY (SELECT SUM(CASE WHEN hs.LoaiBaoHiem=N'BHXH' THEN hs.MucLuongCanCu*hs.TyLeNguoiLaoDong/100.0 ELSE 0 END) AS TienBHXH,
                          SUM(CASE WHEN hs.LoaiBaoHiem=N'BHYT' THEN hs.MucLuongCanCu*hs.TyLeNguoiLaoDong/100.0 ELSE 0 END) AS TienBHYT
                   FROM dbo.HO_SO_BAO_HIEM hs WHERE hs.MaNhanVien=nv.MaNhanVien AND hs.TrangThai=N'Hiệu lực' AND hs.NgayBatDau<=@NgayCuoi AND (hs.NgayKetThuc IS NULL OR hs.NgayKetThuc>=@NgayDau)) bh
      OUTER APPLY (SELECT SUM(q.SoTienPhat) AS TienPhat FROM dbo.QUYET_DINH_KY_LUAT q LEFT JOIN dbo.BANG_LUONG b ON b.MaBangLuong=q.MaBangLuongTru WHERE q.MaNhanVien=nv.MaNhanVien AND q.HinhThucXuLy=N'Trừ lương' AND q.TrangThai IN (N'Đã ký',N'Đã khấu trừ') AND q.NgayQuyetDinh BETWEEN @NgayDau AND @NgayCuoi AND (q.MaBangLuongTru IS NULL OR (b.Thang=@Thang AND b.Nam=@Nam))) ph
      WHERE nv.TrangThai IN (N'Thử việc', N'Đang làm việc')
    )
    INSERT INTO @Tinh
    SELECT MaNhanVien,MucLuongCoBan,PhuCapChucVu,PhuCapLuong,PhuCapDocHai,SoGioCong,SoGioPhuTroi,
      CAST((MucLuongCoBan+PhuCapChucVu+PhuCapLuong+PhuCapDocHai) * CASE WHEN SoGioCong>@GioCongChuanThang THEN 1 ELSE SoGioCong/@GioCongChuanThang END AS DECIMAL(18,2)),
      CAST((MucLuongCoBan/@GioCongChuanThang)*1.5*SoGioPhuTroi AS DECIMAL(18,2)),
      CAST(TienBHXH AS DECIMAL(18,2)),CAST(TienBHYT AS DECIMAL(18,2)),CAST(TienPhatTruLuong AS DECIMAL(18,2)),
      CAST(((MucLuongCoBan+PhuCapChucVu+PhuCapLuong+PhuCapDocHai) * CASE WHEN SoGioCong>@GioCongChuanThang THEN 1 ELSE SoGioCong/@GioCongChuanThang END)
       + ((MucLuongCoBan/@GioCongChuanThang)*1.5*SoGioPhuTroi) - TienBHXH - TienBHYT - TienPhatTruLuong AS DECIMAL(18,2))
    FROM Nguon
    WHERE MucLuongCoBan > 0;

    UPDATE b SET MucLuongCoBan=t.MucLuongCoBan,PhuCapChucVu=t.PhuCapChucVu,PhuCapLuong=t.PhuCapLuong,PhuCapDocHai=t.PhuCapDocHai,
      SoGioCong=t.SoGioCong,SoGioPhuTroi=t.SoGioPhuTroi,TienLuongTheoCong=t.TienLuongTheoCong,TienPhuTroi=t.TienPhuTroi,
      TienBHXH=t.TienBHXH,TienBHYT=t.TienBHYT,TienPhatTruLuong=t.TienPhatTruLuong,LuongThucLanh=t.LuongThucLanh,
      NgayTinh=SYSDATETIME(),TrangThai=N'Bản nháp'
    FROM dbo.BANG_LUONG b JOIN @Tinh t ON t.MaNhanVien=b.MaNhanVien WHERE b.Thang=@Thang AND b.Nam=@Nam AND b.TrangThai<>N'Đã thanh toán';

    INSERT INTO dbo.BANG_LUONG (MaBangLuong,MaNhanVien,Thang,Nam,MucLuongCoBan,PhuCapChucVu,PhuCapLuong,PhuCapDocHai,SoGioCong,SoGioPhuTroi,HeSoPhuTroi,TienLuongTheoCong,TienPhuTroi,TienBHXH,TienBHYT,TienPhatTruLuong,LuongThucLanh,TrangThai)
    SELECT 'BL'+CONVERT(CHAR(6),@Nam*100+@Thang)+'_'+t.MaNhanVien,t.MaNhanVien,@Thang,@Nam,t.MucLuongCoBan,t.PhuCapChucVu,t.PhuCapLuong,t.PhuCapDocHai,t.SoGioCong,t.SoGioPhuTroi,1.5,t.TienLuongTheoCong,t.TienPhuTroi,t.TienBHXH,t.TienBHYT,t.TienPhatTruLuong,t.LuongThucLanh,N'Bản nháp'
    FROM @Tinh t WHERE NOT EXISTS (SELECT 1 FROM dbo.BANG_LUONG b WHERE b.MaNhanVien=t.MaNhanVien AND b.Thang=@Thang AND b.Nam=@Nam);

    UPDATE q SET MaBangLuongTru=b.MaBangLuong,TrangThai=N'Đã khấu trừ'
    FROM dbo.QUYET_DINH_KY_LUAT q JOIN dbo.BANG_LUONG b ON b.MaNhanVien=q.MaNhanVien AND b.Thang=@Thang AND b.Nam=@Nam
    WHERE q.HinhThucXuLy=N'Trừ lương' AND q.NgayQuyetDinh BETWEEN @NgayDau AND @NgayCuoi AND q.MaBangLuongTru IS NULL AND q.TrangThai=N'Đã ký' AND b.TrangThai<>N'Đã thanh toán';

    COMMIT TRANSACTION;
    SELECT * FROM dbo.BANG_LUONG WHERE Thang=@Thang AND Nam=@Nam ORDER BY MaNhanVien;
END;
GO

/* Du lieu danh muc mau toi thieu; khong tao thong tin nhan vien ca nhan. */
IF NOT EXISTS (SELECT 1 FROM dbo.PHONG_BAN WHERE MaPhongBan='PB_TC') INSERT dbo.PHONG_BAN(MaPhongBan,TenPhongBan,LoaiDonVi) VALUES('PB_TC',N'Phòng Tài chính kế toán',N'Phòng ban');
IF NOT EXISTS (SELECT 1 FROM dbo.PHONG_BAN WHERE MaPhongBan='PB_KT') INSERT dbo.PHONG_BAN(MaPhongBan,TenPhongBan,LoaiDonVi) VALUES('PB_KT',N'Phòng Kỹ thuật',N'Phòng ban');
IF NOT EXISTS (SELECT 1 FROM dbo.PHONG_BAN WHERE MaPhongBan='PB_SX') INSERT dbo.PHONG_BAN(MaPhongBan,TenPhongBan,LoaiDonVi) VALUES('PB_SX',N'Phân xưởng Sản xuất',N'Phân xưởng');
IF NOT EXISTS (SELECT 1 FROM dbo.PHONG_BAN WHERE MaPhongBan='PB_NS') INSERT dbo.PHONG_BAN(MaPhongBan,TenPhongBan,LoaiDonVi) VALUES('PB_NS',N'Phòng Nhân sự',N'Phòng ban');
IF NOT EXISTS (SELECT 1 FROM dbo.CHUC_VU WHERE MaChucVu='CV_NV') INSERT dbo.CHUC_VU(MaChucVu,TenChucVu) VALUES('CV_NV',N'Nhân viên');
IF NOT EXISTS (SELECT 1 FROM dbo.CHUC_VU WHERE MaChucVu='CV_TP') INSERT dbo.CHUC_VU(MaChucVu,TenChucVu) VALUES('CV_TP',N'Trưởng phòng');
IF NOT EXISTS (SELECT 1 FROM dbo.CHUC_VU WHERE MaChucVu='CV_GD') INSERT dbo.CHUC_VU(MaChucVu,TenChucVu) VALUES('CV_GD',N'Giám đốc');
IF NOT EXISTS (SELECT 1 FROM dbo.CA_LAM_VIEC WHERE MaCa='CA_SANG') INSERT dbo.CA_LAM_VIEC(MaCa,TenCa,GioBatDau,GioKetThuc) VALUES('CA_SANG',N'Ca sáng','08:00','12:00');
IF NOT EXISTS (SELECT 1 FROM dbo.CA_LAM_VIEC WHERE MaCa='CA_CHIEU') INSERT dbo.CA_LAM_VIEC(MaCa,TenCa,GioBatDau,GioKetThuc) VALUES('CA_CHIEU',N'Ca chiều','13:00','17:00');
GO

/* Kiem tra nhanh schema sau khi chay script */
SELECT name AS TenBang FROM sys.tables WHERE schema_id=SCHEMA_ID('dbo') ORDER BY name;
GO
