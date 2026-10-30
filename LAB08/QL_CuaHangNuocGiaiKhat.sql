/*
  HE THONG QUAN LY CUA HANG NUOC GIAI KHAT
  SQL Server 2016 SP1+ (CREATE OR ALTER) / SQL Server Express LocalDB
  Chay file nay bang SQL Server Management Studio (SSMS) hoac Visual Studio SQL Server Object Explorer.
*/
IF DB_ID(N'QL_CuaHangNuocGiaiKhat') IS NULL
    CREATE DATABASE QL_CuaHangNuocGiaiKhat;
GO
USE QL_CuaHangNuocGiaiKhat;
GO

IF OBJECT_ID(N'dbo.NHAN_HIEU', N'U') IS NULL
BEGIN
    CREATE TABLE dbo.NHAN_HIEU(
        MaLoai VARCHAR(10) NOT NULL CONSTRAINT PK_NHAN_HIEU PRIMARY KEY,
        TenLoai NVARCHAR(100) NOT NULL
    );
END;
GO
IF OBJECT_ID(N'dbo.NHA_CUNG_UNG', N'U') IS NULL
BEGIN
    CREATE TABLE dbo.NHA_CUNG_UNG(
        MaNCC VARCHAR(10) NOT NULL CONSTRAINT PK_NHA_CUNG_UNG PRIMARY KEY,
        TenNCC NVARCHAR(150) NOT NULL,
        DiaChi NVARCHAR(250) NULL,
        SoDienThoai VARCHAR(20) NULL
    );
END;
GO
IF OBJECT_ID(N'dbo.NHAN_VIEN', N'U') IS NULL
BEGIN
    CREATE TABLE dbo.NHAN_VIEN(
        MaNV VARCHAR(10) NOT NULL CONSTRAINT PK_NHAN_VIEN PRIMARY KEY,
        HoTen NVARCHAR(150) NOT NULL,
        SoDienThoai VARCHAR(20) NULL
    );
END;
GO
IF OBJECT_ID(N'dbo.KHACH_HANG', N'U') IS NULL
BEGIN
    CREATE TABLE dbo.KHACH_HANG(
        MaKH VARCHAR(10) NOT NULL CONSTRAINT PK_KHACH_HANG PRIMARY KEY,
        TenKH NVARCHAR(150) NOT NULL,
        DiaChi NVARCHAR(250) NULL,
        SoDienThoai VARCHAR(20) NULL,
        LoaiKhach VARCHAR(20) NOT NULL CONSTRAINT DF_KHACH_HANG_Loai DEFAULT('KHACH_QUEN'),
        CONSTRAINT CK_KHACH_HANG_Loai CHECK(LoaiKhach IN ('KHACH_QUEN','VANG_LAI'))
    );
END;
GO
IF OBJECT_ID(N'dbo.NUOC_GIAI_KHAT', N'U') IS NULL
BEGIN
    CREATE TABLE dbo.NUOC_GIAI_KHAT(
        MaNGK VARCHAR(10) NOT NULL CONSTRAINT PK_NUOC_GIAI_KHAT PRIMARY KEY,
        TenNGK NVARCHAR(150) NOT NULL,
        DonViTinh NVARCHAR(30) NOT NULL,
        MaLoai VARCHAR(10) NOT NULL,
        MaNCC VARCHAR(10) NOT NULL,
        SoLuongTon INT NOT NULL CONSTRAINT DF_NGK_Ton DEFAULT(0),
        GiaBan DECIMAL(18,2) NOT NULL CONSTRAINT DF_NGK_Gia DEFAULT(0),
        CONSTRAINT CK_NGK_Ton CHECK(SoLuongTon >= 0),
        CONSTRAINT CK_NGK_Gia CHECK(GiaBan >= 0),
        CONSTRAINT FK_NGK_NhanHieu FOREIGN KEY(MaLoai) REFERENCES dbo.NHAN_HIEU(MaLoai),
        CONSTRAINT FK_NGK_NCC FOREIGN KEY(MaNCC) REFERENCES dbo.NHA_CUNG_UNG(MaNCC)
    );
END;
GO
IF OBJECT_ID(N'dbo.DON_DAT_HANG', N'U') IS NULL
BEGIN
    CREATE TABLE dbo.DON_DAT_HANG(
        MaDDH INT IDENTITY(1,1) NOT NULL CONSTRAINT PK_DON_DAT_HANG PRIMARY KEY,
        MaNCC VARCHAR(10) NOT NULL,
        NgayDat DATE NOT NULL,
        NgayNhanDuKien DATE NOT NULL,
        MaNV VARCHAR(10) NOT NULL,
        TrangThai NVARCHAR(30) NOT NULL CONSTRAINT DF_DDH_TrangThai DEFAULT(N'CHO_GIAO'),
        CONSTRAINT CK_DDH_Ngay CHECK(NgayNhanDuKien >= NgayDat),
        CONSTRAINT FK_DDH_NCC FOREIGN KEY(MaNCC) REFERENCES dbo.NHA_CUNG_UNG(MaNCC),
        CONSTRAINT FK_DDH_NV FOREIGN KEY(MaNV) REFERENCES dbo.NHAN_VIEN(MaNV)
    );
END;
GO
IF OBJECT_ID(N'dbo.CT_DON_DAT_HANG', N'U') IS NULL
BEGIN
    CREATE TABLE dbo.CT_DON_DAT_HANG(
        MaDDH INT NOT NULL,
        MaNGK VARCHAR(10) NOT NULL,
        SoLuongDat INT NOT NULL,
        CONSTRAINT PK_CT_DON_DAT_HANG PRIMARY KEY(MaDDH, MaNGK),
        CONSTRAINT CK_CT_DDH_SoLuong CHECK(SoLuongDat > 0),
        CONSTRAINT FK_CT_DDH_DDH FOREIGN KEY(MaDDH) REFERENCES dbo.DON_DAT_HANG(MaDDH),
        CONSTRAINT FK_CT_DDH_NGK FOREIGN KEY(MaNGK) REFERENCES dbo.NUOC_GIAI_KHAT(MaNGK)
    );
END;
GO
IF OBJECT_ID(N'dbo.PHIEU_GIAO_HANG', N'U') IS NULL
BEGIN
    CREATE TABLE dbo.PHIEU_GIAO_HANG(
        MaPGH INT IDENTITY(1,1) NOT NULL CONSTRAINT PK_PHIEU_GIAO_HANG PRIMARY KEY,
        MaDDH INT NOT NULL,
        SoDotGiao TINYINT NOT NULL,
        NgayGiao DATE NOT NULL,
        SoTienPhaiTra DECIMAL(18,2) NOT NULL,
        MaNV VARCHAR(10) NOT NULL,
        CONSTRAINT UQ_PGH_DDH_Dot UNIQUE(MaDDH, SoDotGiao),
        CONSTRAINT CK_PGH_Dot CHECK(SoDotGiao BETWEEN 1 AND 3),
        CONSTRAINT CK_PGH_Tien CHECK(SoTienPhaiTra >= 0),
        CONSTRAINT FK_PGH_DDH FOREIGN KEY(MaDDH) REFERENCES dbo.DON_DAT_HANG(MaDDH),
        CONSTRAINT FK_PGH_NV FOREIGN KEY(MaNV) REFERENCES dbo.NHAN_VIEN(MaNV)
    );
END;
GO
IF OBJECT_ID(N'dbo.CT_PHIEU_GIAO', N'U') IS NULL
BEGIN
    CREATE TABLE dbo.CT_PHIEU_GIAO(
        MaPGH INT NOT NULL,
        MaNGK VARCHAR(10) NOT NULL,
        SoLuongThucGiao INT NOT NULL,
        CONSTRAINT PK_CT_PHIEU_GIAO PRIMARY KEY(MaPGH, MaNGK),
        CONSTRAINT CK_CT_PGH_SoLuong CHECK(SoLuongThucGiao > 0),
        CONSTRAINT FK_CT_PGH_PGH FOREIGN KEY(MaPGH) REFERENCES dbo.PHIEU_GIAO_HANG(MaPGH),
        CONSTRAINT FK_CT_PGH_NGK FOREIGN KEY(MaNGK) REFERENCES dbo.NUOC_GIAI_KHAT(MaNGK)
    );
END;
GO
IF OBJECT_ID(N'dbo.HOA_DON', N'U') IS NULL
BEGIN
    CREATE TABLE dbo.HOA_DON(
        MaHD INT IDENTITY(1,1) NOT NULL CONSTRAINT PK_HOA_DON PRIMARY KEY,
        MaKH VARCHAR(10) NOT NULL,
        NgayLap DATETIME2(0) NOT NULL CONSTRAINT DF_HD_Ngay DEFAULT(SYSDATETIME()),
        TongTien DECIMAL(18,2) NOT NULL,
        TrangThaiThanhToan VARCHAR(20) NOT NULL CONSTRAINT DF_HD_ThanhToan DEFAULT('DA_THANH_TOAN'),
        MaNV VARCHAR(10) NOT NULL,
        CONSTRAINT CK_HD_TongTien CHECK(TongTien >= 0),
        CONSTRAINT CK_HD_ThanhToan CHECK(TrangThaiThanhToan IN ('DA_THANH_TOAN','CON_NO')),
        CONSTRAINT FK_HD_KH FOREIGN KEY(MaKH) REFERENCES dbo.KHACH_HANG(MaKH),
        CONSTRAINT FK_HD_NV FOREIGN KEY(MaNV) REFERENCES dbo.NHAN_VIEN(MaNV)
    );
END;
GO
IF OBJECT_ID(N'dbo.CT_HOA_DON', N'U') IS NULL
BEGIN
    CREATE TABLE dbo.CT_HOA_DON(
        MaHD INT NOT NULL,
        MaNGK VARCHAR(10) NOT NULL,
        SoLuongYeuCau INT NOT NULL,
        SoLuongGiaoNgay INT NOT NULL,
        DonGia DECIMAL(18,2) NOT NULL,
        CONSTRAINT PK_CT_HOA_DON PRIMARY KEY(MaHD, MaNGK),
        CONSTRAINT CK_CTHD_SoLuong CHECK(SoLuongYeuCau > 0 AND SoLuongGiaoNgay >= 0 AND SoLuongGiaoNgay <= SoLuongYeuCau),
        CONSTRAINT CK_CTHD_DonGia CHECK(DonGia >= 0),
        CONSTRAINT FK_CTHD_HD FOREIGN KEY(MaHD) REFERENCES dbo.HOA_DON(MaHD),
        CONSTRAINT FK_CTHD_NGK FOREIGN KEY(MaNGK) REFERENCES dbo.NUOC_GIAI_KHAT(MaNGK)
    );
END;
GO
IF OBJECT_ID(N'dbo.PHIEU_HEN', N'U') IS NULL
BEGIN
    CREATE TABLE dbo.PHIEU_HEN(
        MaPH INT IDENTITY(1,1) NOT NULL CONSTRAINT PK_PHIEU_HEN PRIMARY KEY,
        MaHD INT NOT NULL,
        NgayHen DATE NOT NULL,
        TrangThai NVARCHAR(30) NOT NULL CONSTRAINT DF_PH_TrangThai DEFAULT(N'CHO_GIAO'),
        MaNV VARCHAR(10) NOT NULL,
        CONSTRAINT FK_PH_HD FOREIGN KEY(MaHD) REFERENCES dbo.HOA_DON(MaHD),
        CONSTRAINT FK_PH_NV FOREIGN KEY(MaNV) REFERENCES dbo.NHAN_VIEN(MaNV)
    );
END;
GO
IF OBJECT_ID(N'dbo.CT_PHIEU_HEN', N'U') IS NULL
BEGIN
    CREATE TABLE dbo.CT_PHIEU_HEN(
        MaPH INT NOT NULL,
        MaNGK VARCHAR(10) NOT NULL,
        SoLuongHen INT NOT NULL,
        SoLuongDaGiao INT NOT NULL CONSTRAINT DF_CT_PH_DaGiao DEFAULT(0),
        CONSTRAINT PK_CT_PHIEU_HEN PRIMARY KEY(MaPH, MaNGK),
        CONSTRAINT CK_CT_PH_SoLuong CHECK(SoLuongHen > 0 AND SoLuongDaGiao >= 0 AND SoLuongDaGiao <= SoLuongHen),
        CONSTRAINT FK_CT_PH_PH FOREIGN KEY(MaPH) REFERENCES dbo.PHIEU_HEN(MaPH),
        CONSTRAINT FK_CT_PH_NGK FOREIGN KEY(MaNGK) REFERENCES dbo.NUOC_GIAI_KHAT(MaNGK)
    );
END;
GO
/* Tuong thich khi chay lai script tren CSDL da tao bang chi tiet phieu hen tu ban cu. */
IF COL_LENGTH(N'dbo.CT_PHIEU_HEN', N'SoLuongDaGiao') IS NULL
BEGIN
    ALTER TABLE dbo.CT_PHIEU_HEN ADD SoLuongDaGiao INT NOT NULL CONSTRAINT DF_CT_PH_DaGiao DEFAULT(0);
END;
IF NOT EXISTS (SELECT 1 FROM sys.check_constraints WHERE name=N'CK_CT_PH_DaGiaoRange')
BEGIN
    ALTER TABLE dbo.CT_PHIEU_HEN ADD CONSTRAINT CK_CT_PH_DaGiaoRange CHECK(SoLuongDaGiao >= 0 AND SoLuongDaGiao <= SoLuongHen);
END;
GO
IF OBJECT_ID(N'dbo.GIAO_HANG_KHACH', N'U') IS NULL
BEGIN
    CREATE TABLE dbo.GIAO_HANG_KHACH(
        MaGiao INT IDENTITY(1,1) NOT NULL CONSTRAINT PK_GIAO_HANG_KHACH PRIMARY KEY,
        MaPH INT NOT NULL,
        NgayGiao DATE NOT NULL,
        MaNV VARCHAR(10) NOT NULL,
        CONSTRAINT FK_GHK_PH FOREIGN KEY(MaPH) REFERENCES dbo.PHIEU_HEN(MaPH),
        CONSTRAINT FK_GHK_NV FOREIGN KEY(MaNV) REFERENCES dbo.NHAN_VIEN(MaNV)
    );
END;
GO
IF OBJECT_ID(N'dbo.CT_GIAO_HANG_KHACH', N'U') IS NULL
BEGIN
    CREATE TABLE dbo.CT_GIAO_HANG_KHACH(
        MaGiao INT NOT NULL,
        MaNGK VARCHAR(10) NOT NULL,
        SoLuongGiao INT NOT NULL,
        CONSTRAINT PK_CT_GIAO_HANG_KHACH PRIMARY KEY(MaGiao, MaNGK),
        CONSTRAINT CK_CT_GHK_SoLuong CHECK(SoLuongGiao > 0),
        CONSTRAINT FK_CT_GHK_Giao FOREIGN KEY(MaGiao) REFERENCES dbo.GIAO_HANG_KHACH(MaGiao),
        CONSTRAINT FK_CT_GHK_NGK FOREIGN KEY(MaNGK) REFERENCES dbo.NUOC_GIAI_KHAT(MaNGK)
    );
END;
GO
IF OBJECT_ID(N'dbo.PHIEU_GHI_NO', N'U') IS NULL
BEGIN
    CREATE TABLE dbo.PHIEU_GHI_NO(
        MaPGN INT IDENTITY(1,1) NOT NULL CONSTRAINT PK_PHIEU_GHI_NO PRIMARY KEY,
        MaKH VARCHAR(10) NOT NULL,
        MaHD INT NULL,
        NgayLap DATE NOT NULL,
        SoTienNo DECIMAL(18,2) NOT NULL,
        SoTienDaTra DECIMAL(18,2) NOT NULL CONSTRAINT DF_PGN_DaTra DEFAULT(0),
        NgayDuKienTra DATE NOT NULL,
        LyDo NVARCHAR(300) NOT NULL,
        MaNV VARCHAR(10) NOT NULL,
        CONSTRAINT CK_PGN_Tien CHECK(SoTienNo > 0 AND SoTienDaTra >= 0 AND SoTienDaTra <= SoTienNo),
        CONSTRAINT CK_PGN_Ngay CHECK(NgayDuKienTra >= NgayLap),
        CONSTRAINT FK_PGN_KH FOREIGN KEY(MaKH) REFERENCES dbo.KHACH_HANG(MaKH),
        CONSTRAINT FK_PGN_HD FOREIGN KEY(MaHD) REFERENCES dbo.HOA_DON(MaHD),
        CONSTRAINT FK_PGN_NV FOREIGN KEY(MaNV) REFERENCES dbo.NHAN_VIEN(MaNV)
    );
END;
GO
IF OBJECT_ID(N'dbo.THANH_TOAN_NO', N'U') IS NULL
BEGIN
    CREATE TABLE dbo.THANH_TOAN_NO(
        MaTT INT IDENTITY(1,1) NOT NULL CONSTRAINT PK_THANH_TOAN_NO PRIMARY KEY,
        MaPGN INT NOT NULL,
        NgayThanhToan DATE NOT NULL,
        SoTien DECIMAL(18,2) NOT NULL,
        MaNV VARCHAR(10) NOT NULL,
        CONSTRAINT CK_TTN_SoTien CHECK(SoTien > 0),
        CONSTRAINT FK_TTN_PGN FOREIGN KEY(MaPGN) REFERENCES dbo.PHIEU_GHI_NO(MaPGN),
        CONSTRAINT FK_TTN_NV FOREIGN KEY(MaNV) REFERENCES dbo.NHAN_VIEN(MaNV)
    );
END;
GO

/* Mot don dat hang khong duoc nhan qua 3 dot giao. */
CREATE OR ALTER TRIGGER dbo.trg_PGH_ToiDa3Dot
ON dbo.PHIEU_GIAO_HANG
AFTER INSERT
AS
BEGIN
    SET NOCOUNT ON;
    IF EXISTS (
        SELECT i.MaDDH
        FROM inserted i
        JOIN dbo.PHIEU_GIAO_HANG p ON p.MaDDH = i.MaDDH
        GROUP BY i.MaDDH
        HAVING COUNT(*) > 3
    )
    BEGIN
        ROLLBACK TRANSACTION;
        THROW 51001, N'Mot don dat hang chi duoc giao toi da 3 dot.', 1;
    END;
END;
GO

/* Chi duoc dat mat hang tu nha cung ung da gan cho mat hang. */
CREATE OR ALTER TRIGGER dbo.trg_CT_DDH_KiemTraNCC
ON dbo.CT_DON_DAT_HANG
AFTER INSERT
AS
BEGIN
    SET NOCOUNT ON;
    IF EXISTS (
        SELECT 1 FROM inserted i
        JOIN dbo.DON_DAT_HANG d ON d.MaDDH=i.MaDDH
        JOIN dbo.NUOC_GIAI_KHAT n ON n.MaNGK=i.MaNGK
        WHERE n.MaNCC <> d.MaNCC
    )
    BEGIN
        ROLLBACK TRANSACTION;
        THROW 51008, N'Mat hang khong thuoc nha cung ung cua don dat hang.', 1;
    END;
END;
GO

/* Phieu hen giao chi danh cho khach quen. */
CREATE OR ALTER TRIGGER dbo.trg_PH_HenChiKhachQuen
ON dbo.PHIEU_HEN
AFTER INSERT
AS
BEGIN
    SET NOCOUNT ON;
    IF EXISTS (
        SELECT 1 FROM inserted i
        JOIN dbo.HOA_DON h ON h.MaHD=i.MaHD
        JOIN dbo.KHACH_HANG k ON k.MaKH=h.MaKH
        WHERE k.LoaiKhach <> 'KHACH_QUEN'
    )
    BEGIN
        ROLLBACK TRANSACTION;
        THROW 51009, N'Chi khach quen moi duoc lap phieu hen giao.', 1;
    END;
END;
GO

/* So luong tren phieu giao chi duoc ghi cho mat hang da co trong don dat hang. Ton kho tang theo luong thuc nhan. */
CREATE OR ALTER TRIGGER dbo.trg_CT_PGH_CapNhatTon
ON dbo.CT_PHIEU_GIAO
AFTER INSERT
AS
BEGIN
    SET NOCOUNT ON;
    IF EXISTS (
        SELECT 1 FROM inserted i
        JOIN dbo.PHIEU_GIAO_HANG p ON p.MaPGH = i.MaPGH
        LEFT JOIN dbo.CT_DON_DAT_HANG d ON d.MaDDH = p.MaDDH AND d.MaNGK = i.MaNGK
        WHERE d.MaNGK IS NULL
    )
    BEGIN
        ROLLBACK TRANSACTION;
        THROW 51002, N'Mat hang tren phieu giao khong thuoc don dat hang.', 1;
    END;
    ;WITH x AS (
        SELECT i.MaNGK, SUM(i.SoLuongThucGiao) AS SoLuong
        FROM inserted i GROUP BY i.MaNGK
    )
    UPDATE n SET n.SoLuongTon = n.SoLuongTon + x.SoLuong
    FROM dbo.NUOC_GIAI_KHAT n JOIN x ON x.MaNGK = n.MaNGK;
END;
GO

/* Tru ton theo luong giao ngay; khach vang lai phai duoc giao du so luong ngay tren hoa don. */
CREATE OR ALTER TRIGGER dbo.trg_CT_HD_TruTon
ON dbo.CT_HOA_DON
AFTER INSERT
AS
BEGIN
    SET NOCOUNT ON;
    IF EXISTS (
        SELECT 1 FROM inserted i
        JOIN dbo.HOA_DON h ON h.MaHD = i.MaHD
        JOIN dbo.KHACH_HANG k ON k.MaKH = h.MaKH
        WHERE k.LoaiKhach = 'VANG_LAI' AND i.SoLuongGiaoNgay <> i.SoLuongYeuCau
    )
    BEGIN
        ROLLBACK TRANSACTION;
        THROW 51003, N'Khach vang lai phai thanh toan va nhan du hang ngay.', 1;
    END;
    IF EXISTS (
        SELECT i.MaNGK
        FROM inserted i
        JOIN dbo.NUOC_GIAI_KHAT n ON n.MaNGK = i.MaNGK
        GROUP BY i.MaNGK, n.SoLuongTon
        HAVING n.SoLuongTon < SUM(i.SoLuongGiaoNgay)
    )
    BEGIN
        ROLLBACK TRANSACTION;
        THROW 51004, N'Ton kho khong du de ghi nhan giao hang ngay.', 1;
    END;
    ;WITH x AS (
        SELECT i.MaNGK, SUM(i.SoLuongGiaoNgay) AS SoLuong
        FROM inserted i GROUP BY i.MaNGK
    )
    UPDATE n SET n.SoLuongTon = n.SoLuongTon - x.SoLuong
    FROM dbo.NUOC_GIAI_KHAT n JOIN x ON x.MaNGK = n.MaNGK;
END;
GO

/* Chi khach quen duoc ghi no. */
CREATE OR ALTER TRIGGER dbo.trg_PGN_ChiKhachQuen
ON dbo.PHIEU_GHI_NO
AFTER INSERT
AS
BEGIN
    SET NOCOUNT ON;
    IF EXISTS (
        SELECT 1 FROM inserted i JOIN dbo.KHACH_HANG k ON k.MaKH = i.MaKH
        WHERE k.LoaiKhach <> 'KHACH_QUEN'
    )
    BEGIN
        ROLLBACK TRANSACTION;
        THROW 51005, N'Chi khach quen moi duoc lap phieu ghi no.', 1;
    END;
END;
GO

CREATE OR ALTER PROCEDURE dbo.sp_GhiNhanThanhToanNo
    @MaPGN INT,
    @NgayThanhToan DATE,
    @SoTien DECIMAL(18,2),
    @MaNV VARCHAR(10)
AS
BEGIN
    SET NOCOUNT ON;
    SET XACT_ABORT ON;
    BEGIN TRANSACTION;
    DECLARE @ConNo DECIMAL(18,2);
    SELECT @ConNo = SoTienNo - SoTienDaTra
    FROM dbo.PHIEU_GHI_NO WITH (UPDLOCK, ROWLOCK)
    WHERE MaPGN = @MaPGN;
    IF @ConNo IS NULL
    BEGIN
        ROLLBACK TRANSACTION;
        THROW 51006, N'Khong tim thay phieu ghi no.', 1;
    END;
    IF @SoTien <= 0 OR @SoTien > @ConNo
    BEGIN
        ROLLBACK TRANSACTION;
        THROW 51007, N'So tien thanh toan phai lon hon 0 va khong vuot qua so no con lai.', 1;
    END;
    INSERT INTO dbo.THANH_TOAN_NO(MaPGN, NgayThanhToan, SoTien, MaNV)
    VALUES(@MaPGN, @NgayThanhToan, @SoTien, @MaNV);
    UPDATE dbo.PHIEU_GHI_NO SET SoTienDaTra = SoTienDaTra + @SoTien WHERE MaPGN = @MaPGN;
    UPDATE h SET TrangThaiThanhToan='DA_THANH_TOAN'
    FROM dbo.HOA_DON h
    WHERE EXISTS (SELECT 1 FROM dbo.PHIEU_GHI_NO p WHERE p.MaPGN=@MaPGN AND p.MaHD=h.MaHD)
      AND NOT EXISTS (SELECT 1 FROM dbo.PHIEU_GHI_NO p2 WHERE p2.MaHD=h.MaHD AND p2.SoTienDaTra < p2.SoTienNo);
    COMMIT TRANSACTION;
END;
GO

CREATE OR ALTER PROCEDURE dbo.sp_GhiNhanGiaoHangHen
    @MaPH INT,
    @MaNGK VARCHAR(10),
    @SoLuongGiaoThem INT,
    @NgayGiao DATE,
    @MaNV VARCHAR(10)
AS
BEGIN
    SET NOCOUNT ON;
    SET XACT_ABORT ON;
    BEGIN TRANSACTION;
    DECLARE @SoLuongHen INT, @SoLuongDaGiao INT, @TonKho INT, @MaGiao INT;
    SELECT @SoLuongHen=SoLuongHen, @SoLuongDaGiao=SoLuongDaGiao
    FROM dbo.CT_PHIEU_HEN WITH (UPDLOCK, ROWLOCK)
    WHERE MaPH=@MaPH AND MaNGK=@MaNGK;
    IF @SoLuongHen IS NULL
    BEGIN
        ROLLBACK TRANSACTION;
        THROW 51010, N'Mat hang khong ton tai tren phieu hen nay.', 1;
    END;
    IF @SoLuongGiaoThem <= 0 OR @SoLuongGiaoThem > (@SoLuongHen-@SoLuongDaGiao)
    BEGIN
        ROLLBACK TRANSACTION;
        THROW 51011, N'So luong giao them khong hop le hoac vuot qua so luong con hen.', 1;
    END;
    SELECT @TonKho=SoLuongTon FROM dbo.NUOC_GIAI_KHAT WITH (UPDLOCK, ROWLOCK) WHERE MaNGK=@MaNGK;
    IF @TonKho IS NULL OR @TonKho < @SoLuongGiaoThem
    BEGIN
        ROLLBACK TRANSACTION;
        THROW 51012, N'Ton kho khong du de giao cho khach.', 1;
    END;
    INSERT INTO dbo.GIAO_HANG_KHACH(MaPH,NgayGiao,MaNV) VALUES(@MaPH,@NgayGiao,@MaNV);
    SET @MaGiao = CONVERT(INT, SCOPE_IDENTITY());
    INSERT INTO dbo.CT_GIAO_HANG_KHACH(MaGiao,MaNGK,SoLuongGiao) VALUES(@MaGiao,@MaNGK,@SoLuongGiaoThem);
    UPDATE dbo.NUOC_GIAI_KHAT SET SoLuongTon=SoLuongTon-@SoLuongGiaoThem WHERE MaNGK=@MaNGK;
    UPDATE dbo.CT_PHIEU_HEN SET SoLuongDaGiao=SoLuongDaGiao+@SoLuongGiaoThem WHERE MaPH=@MaPH AND MaNGK=@MaNGK;
    IF NOT EXISTS (SELECT 1 FROM dbo.CT_PHIEU_HEN WHERE MaPH=@MaPH AND SoLuongDaGiao < SoLuongHen)
        UPDATE dbo.PHIEU_HEN SET TrangThai=N'DA_GIAO_DU' WHERE MaPH=@MaPH;
    ELSE
        UPDATE dbo.PHIEU_HEN SET TrangThai=N'GIAO_MOT_PHAN' WHERE MaPH=@MaPH;
    COMMIT TRANSACTION;
END;
GO

CREATE OR ALTER VIEW dbo.vw_TonKho AS
SELECT n.MaNGK, n.TenNGK, n.DonViTinh, h.TenLoai, c.TenNCC,
       n.SoLuongTon, n.GiaBan
FROM dbo.NUOC_GIAI_KHAT n
JOIN dbo.NHAN_HIEU h ON h.MaLoai=n.MaLoai
JOIN dbo.NHA_CUNG_UNG c ON c.MaNCC=n.MaNCC;
GO
CREATE OR ALTER VIEW dbo.vw_CongNo AS
SELECT p.MaPGN, p.NgayLap, k.MaKH, k.TenKH, p.MaHD, p.SoTienNo,
       p.SoTienDaTra, p.SoTienNo-p.SoTienDaTra AS SoTienConNo,
       p.NgayDuKienTra, p.LyDo, nv.HoTen AS NhanVienLap
FROM dbo.PHIEU_GHI_NO p
JOIN dbo.KHACH_HANG k ON k.MaKH=p.MaKH
JOIN dbo.NHAN_VIEN nv ON nv.MaNV=p.MaNV;
GO
CREATE OR ALTER VIEW dbo.vw_DonDatHang AS
SELECT d.MaDDH, c.TenNCC, d.NgayDat, d.NgayNhanDuKien,
       d.TrangThai, COUNT(p.MaPGH) AS SoDotDaGiao
FROM dbo.DON_DAT_HANG d
JOIN dbo.NHA_CUNG_UNG c ON c.MaNCC=d.MaNCC
LEFT JOIN dbo.PHIEU_GIAO_HANG p ON p.MaDDH=d.MaDDH
GROUP BY d.MaDDH,c.TenNCC,d.NgayDat,d.NgayNhanDuKien,d.TrangThai;
GO

/* Du lieu demo de chay thu; xoa cac INSERT nay neu khong can du lieu mau. */
IF NOT EXISTS (SELECT 1 FROM dbo.NHAN_VIEN WHERE MaNV='NV01')
    INSERT dbo.NHAN_VIEN(MaNV,HoTen,SoDienThoai) VALUES('NV01',N'Nhân viên mẫu','0900000001');
IF NOT EXISTS (SELECT 1 FROM dbo.NHA_CUNG_UNG WHERE MaNCC='NCC01')
    INSERT dbo.NHA_CUNG_UNG(MaNCC,TenNCC,DiaChi,SoDienThoai) VALUES('NCC01',N'Nhà cung ứng mẫu 1',N'TP. Hồ Chí Minh','0900000011');
IF NOT EXISTS (SELECT 1 FROM dbo.NHA_CUNG_UNG WHERE MaNCC='NCC02')
    INSERT dbo.NHA_CUNG_UNG(MaNCC,TenNCC,DiaChi,SoDienThoai) VALUES('NCC02',N'Nhà cung ứng mẫu 2',N'TP. Hồ Chí Minh','0900000022');
IF NOT EXISTS (SELECT 1 FROM dbo.NHAN_HIEU WHERE MaLoai='LOAI01')
    INSERT dbo.NHAN_HIEU(MaLoai,TenLoai) VALUES('LOAI01',N'Nước có gas');
IF NOT EXISTS (SELECT 1 FROM dbo.NHAN_HIEU WHERE MaLoai='LOAI02')
    INSERT dbo.NHAN_HIEU(MaLoai,TenLoai) VALUES('LOAI02',N'Nước suối');
IF NOT EXISTS (SELECT 1 FROM dbo.NHAN_HIEU WHERE MaLoai='LOAI03')
    INSERT dbo.NHAN_HIEU(MaLoai,TenLoai) VALUES('LOAI03',N'Nước tăng lực');
IF NOT EXISTS (SELECT 1 FROM dbo.KHACH_HANG WHERE MaKH='KH01')
    INSERT dbo.KHACH_HANG(MaKH,TenKH,DiaChi,SoDienThoai,LoaiKhach) VALUES('KH01',N'Khách quen mẫu',N'TP. Hồ Chí Minh','0910000001','KHACH_QUEN');
IF NOT EXISTS (SELECT 1 FROM dbo.KHACH_HANG WHERE MaKH='KH02')
    INSERT dbo.KHACH_HANG(MaKH,TenKH,DiaChi,SoDienThoai,LoaiKhach) VALUES('KH02',N'Khách vãng lai mẫu',NULL,NULL,'VANG_LAI');
IF NOT EXISTS (SELECT 1 FROM dbo.NUOC_GIAI_KHAT WHERE MaNGK='NGK01')
    INSERT dbo.NUOC_GIAI_KHAT(MaNGK,TenNGK,DonViTinh,MaLoai,MaNCC,SoLuongTon,GiaBan) VALUES
    ('NGK01',N'Nước ngọt có gas 330ml',N'Lon','LOAI01','NCC01',100,10000),
    ('NGK02',N'Nước suối 500ml',N'Chai','LOAI02','NCC02',100,5000),
    ('NGK03',N'Nước tăng lực 250ml',N'Lon','LOAI03','NCC01',80,12000);
GO
PRINT N'Da tao/cap nhat schema QL_CuaHangNuocGiaiKhat. Du lieu mau chi duoc chen khi chua ton tai.';
GO
