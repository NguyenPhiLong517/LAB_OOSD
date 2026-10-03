/* =========================================================================
   HỆ THỐNG PHẦN MỀM CỬA HÀNG ONLINE "e-SHOPPING" - LAB 4
   Họ và tên SV: Nguyễn Phi Long
   MSSV: 1250080106
   Lớp: 12_ĐH_CNPM2
   ========================================================================= */

/* ===== 1. TẠO CƠ SỞ DỮ LIỆU ===== */
IF DB_ID(N'eShopping') IS NULL 
    CREATE DATABASE eShopping;
GO
USE eShopping;
GO

/* ===== 2. XÓA BẢNG CŨ NẾU ĐÃ TỒN TẠI (THEO THỨ TỰ KHÓA NGOẠI) ===== */
IF OBJECT_ID('ChiTietDonHang', 'U') IS NOT NULL DROP TABLE ChiTietDonHang;
IF OBJECT_ID('DonHang', 'U') IS NOT NULL DROP TABLE DonHang;
IF OBJECT_ID('NguoiNhan', 'U') IS NOT NULL DROP TABLE NguoiNhan;
IF OBJECT_ID('PhiGiaoHang', 'U') IS NOT NULL DROP TABLE PhiGiaoHang;
IF OBJECT_ID('LoaiThe', 'U') IS NOT NULL DROP TABLE LoaiThe;
IF OBJECT_ID('LoaiPhieu', 'U') IS NOT NULL DROP TABLE LoaiPhieu;
IF OBJECT_ID('KhuVuc', 'U') IS NOT NULL DROP TABLE KhuVuc;
IF OBJECT_ID('ChiTietGioHang', 'U') IS NOT NULL DROP TABLE ChiTietGioHang;
IF OBJECT_ID('KhachHang', 'U') IS NOT NULL DROP TABLE KhachHang;
IF OBJECT_ID('SanPham', 'U') IS NOT NULL DROP TABLE SanPham;
IF OBJECT_ID('NhomSanPham', 'U') IS NOT NULL DROP TABLE NhomSanPham;
GO

/* ===== 3. TẠO CÁC BẢNG QUAN HỆ (CHUẨN HÓA VÀ RÀNG BUỘC) ===== */

-- 3.1. Nhóm sản phẩm (Danh mục)
CREATE TABLE NhomSanPham (
    MaNhomSP   INT IDENTITY(1,1) PRIMARY KEY,
    TenNhomSP  NVARCHAR(100) NOT NULL
);

-- 3.2. Sản phẩm (Đồng bộ từ Hệ thống Quản lý Sản phẩm có sẵn)
CREATE TABLE SanPham (
    MaSP        VARCHAR(20)   PRIMARY KEY,
    TenSP       NVARCHAR(200) NOT NULL,
    NhaSanXuat  NVARCHAR(100),
    HinhAnh     NVARCHAR(300),
    MoTa        NVARCHAR(MAX),
    ThongSoKT   NVARCHAR(MAX),
    GiaBan      DECIMAL(18,0) NOT NULL CHECK (GiaBan >= 0),
    CoHang      BIT           NOT NULL DEFAULT 1,
    MaNhomSP    INT           NOT NULL REFERENCES NhomSanPham(MaNhomSP)
);

-- 3.3. Khách hàng (Đã sửa Email thành NOT NULL UNIQUE theo đúng yêu cầu đề bài)
CREATE TABLE KhachHang (
    MaKhachHang INT IDENTITY(1,1) PRIMARY KEY,
    HoTen       NVARCHAR(100) NOT NULL,
    NgaySinh    DATE          NOT NULL,
    SoCMND      VARCHAR(20)   NOT NULL UNIQUE,
    DiaChi      NVARCHAR(200) NOT NULL,
    DienThoai   VARCHAR(15)   NOT NULL,
    TenDangNhap VARCHAR(50)   NOT NULL UNIQUE,
    MatKhauHash VARCHAR(255)  NOT NULL,
    Email       VARCHAR(100)  NOT NULL UNIQUE
);

-- 3.4. Chi tiết giỏ hàng (Quan hệ nhiều - nhiều giữa Khách hàng và Sản phẩm)
CREATE TABLE ChiTietGioHang (
    MaKhachHang INT         NOT NULL REFERENCES KhachHang(MaKhachHang),
    MaSP        VARCHAR(20) NOT NULL REFERENCES SanPham(MaSP),
    SoLuong     INT         NOT NULL CHECK (SoLuong > 0),
    PRIMARY KEY (MaKhachHang, MaSP)
);

-- 3.5. Khu vực giao hàng
CREATE TABLE KhuVuc (
    MaKhuVuc  INT IDENTITY(1,1) PRIMARY KEY,
    TenKhuVuc NVARCHAR(100) NOT NULL
);

-- 3.6. Loại phiếu đặt hàng (3 hình thức giao nhận)
CREATE TABLE LoaiPhieu (
    MaLoaiPhieu  INT PRIMARY KEY,           -- 1: Thường, 2: Giao nhanh, 3: Giao nhanh trong ngày
    TenLoaiPhieu NVARCHAR(100) NOT NULL,
    ThoiGianXuLy NVARCHAR(100)
);

-- 3.7. Biểu cước phí giao hàng theo khu vực và loại phiếu
CREATE TABLE PhiGiaoHang (
    MaKhuVuc    INT NOT NULL REFERENCES KhuVuc(MaKhuVuc),
    MaLoaiPhieu INT NOT NULL REFERENCES LoaiPhieu(MaLoaiPhieu),
    Phi         DECIMAL(18,0) NOT NULL CHECK (Phi >= 0),
    PRIMARY KEY (MaKhuVuc, MaLoaiPhieu)
);

-- 3.8. Danh mục loại thẻ tín dụng và cấu hình an ninh
CREATE TABLE LoaiThe (
    MaLoaiThe  INT PRIMARY KEY,
    TenLoaiThe NVARCHAR(50) NOT NULL,       -- VISA, Master, Discover, American Express
    DoDaiSoThe INT NOT NULL,                -- 16 hoặc 15
    DoDaiCSV   INT NOT NULL,                -- 3 hoặc 4
    LePhi      DECIMAL(18,0) NOT NULL DEFAULT 0
);

-- 3.9. Thông tin Người nhận hàng (Có thể khác với người mua hàng)
CREATE TABLE NguoiNhan (
    MaNguoiNhan INT IDENTITY(1,1) PRIMARY KEY,
    HoTen       NVARCHAR(100) NOT NULL,
    DiaChi      NVARCHAR(200) NOT NULL,
    DienThoai   VARCHAR(15)   NOT NULL,
    MaKhuVuc    INT NOT NULL REFERENCES KhuVuc(MaKhuVuc)
);

-- 3.10. Đơn đặt hàng (Lưu trữ giao dịch hoàn chỉnh)
CREATE TABLE DonHang (
    MaDonHang    INT IDENTITY(1,1) PRIMARY KEY,
    MaKhachHang  INT NOT NULL REFERENCES KhachHang(MaKhachHang),
    MaNguoiNhan  INT NOT NULL REFERENCES NguoiNhan(MaNguoiNhan),
    MaLoaiPhieu  INT NOT NULL REFERENCES LoaiPhieu(MaLoaiPhieu),
    MaLoaiThe    INT NOT NULL REFERENCES LoaiThe(MaLoaiThe),
    SoTheChe     VARCHAR(25)   NOT NULL,    -- Chỉ lưu dạng che số (VD: ************1234)
    TenChuThe    NVARCHAR(100) NOT NULL,
    NgayHetHan   DATE          NOT NULL,
    TienHang     DECIMAL(18,0) NOT NULL CHECK (TienHang >= 0),
    PhiGiaoHang  DECIMAL(18,0) NOT NULL CHECK (PhiGiaoHang >= 0),
    LePhiThe     DECIMAL(18,0) NOT NULL DEFAULT 0,
    TongTriGia   DECIMAL(18,0) NOT NULL CHECK (TongTriGia > 0),
    ThoiDiemDat  DATETIME      NOT NULL DEFAULT GETDATE(),
    TrangThai    NVARCHAR(50)  NOT NULL DEFAULT N'Đã thanh toán'
);

-- 3.11. Chi tiết đơn đặt hàng (Lưu số lượng và đơn giá chốt tại thời điểm mua)
CREATE TABLE ChiTietDonHang (
    MaDonHang INT         NOT NULL REFERENCES DonHang(MaDonHang),
    MaSP      VARCHAR(20) NOT NULL REFERENCES SanPham(MaSP),
    SoLuong   INT         NOT NULL CHECK (SoLuong > 0),
    DonGia    DECIMAL(18,0) NOT NULL CHECK (DonGia >= 0),
    PRIMARY KEY (MaDonHang, MaSP)
);
GO

/* ===== 4. NẠP DỮ LIỆU MẪU (SEED DATA) ===== */

-- Nhóm sản phẩm
INSERT INTO NhomSanPham(TenNhomSP) VALUES 
(N'Máy chụp hình kỹ thuật số'),
(N'Đồ chơi'),
(N'Thiết bị điện gia dụng'),
(N'Thiết bị máy tính');

-- Sản phẩm mẫu
INSERT INTO SanPham(MaSP, TenSP, NhaSanXuat, GiaBan, CoHang, MaNhomSP, MoTa) VALUES
('SP01', N'Máy ảnh Sony Alpha A7 IV', N'Sony', 45000000, 1, 1, N'Máy ảnh Mirrorless chuyên nghiệp'),
('SP02', N'Ống kính Sony FE 50mm F1.8', N'Sony', 5200000, 1, 1, N'Ống kính chụp chân dung'),
('SP03', N'Bộ xếp hình Lego City', N'Lego', 1200000, 1, 2, N'Đồ chơi lắp ráp trẻ em'),
('SP04', N'Nồi chiên không dầu Philips', N'Philips', 3500000, 1, 3, N'Dung tích 4.1 lít công nghệ Rapid Air'),
('SP05', N'Bàn phím cơ Logitech G Pro', N'Logitech', 2400000, 1, 4, N'Bàn phím gaming switch cơ học');

-- Loại phiếu đặt hàng
INSERT INTO LoaiPhieu(MaLoaiPhieu, TenLoaiPhieu, ThoiGianXuLy) VALUES 
(1, N'Phiếu đặt hàng thường', N'3-5 ngày làm việc'),
(2, N'Phiếu chuyển phát nhanh', N'1-2 ngày'),
(3, N'Phiếu chuyển phát nhanh trong ngày', N'Trong 24 giờ');

-- Khu vực giao hàng
INSERT INTO KhuVuc(TenKhuVuc) VALUES 
(N'Nội thành'),
(N'Ngoại thành'),
(N'Tỉnh khác');

-- Biểu cước vận chuyển chuẩn
INSERT INTO PhiGiaoHang(MaKhuVuc, MaLoaiPhieu, Phi) VALUES 
(1, 1, 20000), (1, 2, 35000), (1, 3, 60000),
(2, 1, 30000), (2, 2, 50000), (2, 3, 80000),
(3, 1, 45000), (3, 2, 70000), (3, 3, 120000);

-- Loại thẻ tín dụng
INSERT INTO LoaiThe(MaLoaiThe, TenLoaiThe, DoDaiSoThe, DoDaiCSV, LePhi) VALUES 
(1, N'VISA', 16, 3, 0),
(2, N'MasterCard', 16, 3, 0),
(3, N'Discover', 16, 3, 0),
(4, N'American Express', 15, 4, 0);

-- Khách hàng mẫu
INSERT INTO KhachHang(HoTen, NgaySinh, SoCMND, DiaChi, DienThoai, TenDangNhap, MatKhauHash, Email) VALUES
(N'Nguyễn Phi Long', '2004-01-01', '079204001234', N'123 Lê Lợi, Q.1, TP.HCM', '0901234567', 'philong', 'hash_pass_123', 'philong@gmail.com');
GO

/* ===== 5. CÁC HÀM VÀ THỦ TỤC XỬ LÝ NGHIỆP VỤ ===== */

-- 5.1 Hàm tính phí giao hàng (Tự động miễn phí: Nhanh >= 1.000.000 đ; Hỏa tốc >= 5.000.000 đ)
CREATE OR ALTER FUNCTION dbo.fn_PhiGiaoHang (
    @MaKhuVuc INT, 
    @MaLoaiPhieu INT, 
    @TienHang DECIMAL(18,0)
)
RETURNS DECIMAL(18,0)
AS
BEGIN
    -- Nếu tổng tiền hàng >= 5.000.000 thì miễn phí hỏa tốc trong ngày (Loại 3)
    IF (@MaLoaiPhieu = 3 AND @TienHang >= 5000000)
        RETURN 0;

    -- Nếu tổng tiền hàng >= 1.000.000 thì miễn phí chuyển phát nhanh (Loại 2)
    IF (@MaLoaiPhieu = 2 AND @TienHang >= 1000000)
        RETURN 0;

    -- Ngược lại, lấy cước chuẩn theo khu vực
    RETURN ISNULL((SELECT Phi FROM PhiGiaoHang WHERE MaKhuVuc = @MaKhuVuc AND MaLoaiPhieu = @MaLoaiPhieu), 0);
END
GO

-- 5.2 Thủ tục thêm hoặc cập nhật sản phẩm vào giỏ hàng
CREATE OR ALTER PROCEDURE dbo.sp_ThemVaoGio 
    @MaKhachHang INT, 
    @MaSP VARCHAR(20), 
    @SoLuong INT = 1
AS
BEGIN
    SET NOCOUNT ON;
    -- Kiểm tra sản phẩm có tồn tại và còn hàng không
    IF NOT EXISTS (SELECT 1 FROM SanPham WHERE MaSP = @MaSP AND CoHang = 1)
    BEGIN 
        RAISERROR(N'Sản phẩm hiện đang hết hàng hoặc không tồn tại.', 16, 1); 
        RETURN; 
    END

    MERGE ChiTietGioHang AS target
    USING (SELECT @MaKhachHang AS MaKhachHang, @MaSP AS MaSP) AS source
       ON target.MaKhachHang = source.MaKhachHang AND target.MaSP = source.MaSP
    WHEN MATCHED THEN 
        UPDATE SET SoLuong = target.SoLuong + @SoLuong
    WHEN NOT MATCHED THEN 
        INSERT(MaKhachHang, MaSP, SoLuong) VALUES(@MaKhachHang, @MaSP, @SoLuong);
END
GO

-- 5.3 Thủ tục đặt hàng và ghi nhận giao dịch thanh toán
CREATE OR ALTER PROCEDURE dbo.sp_DatHang
    @MaKhachHang INT, 
    @MaNguoiNhan INT, 
    @MaLoaiPhieu INT,
    @MaLoaiThe INT, 
    @SoTheChe VARCHAR(25), 
    @TenChuThe NVARCHAR(100), 
    @NgayHetHan DATE
AS
BEGIN
    SET NOCOUNT ON;
    BEGIN TRY
        BEGIN TRAN;

        DECLARE @TienHang DECIMAL(18,0), 
                @MaKhuVuc INT, 
                @PhiShip DECIMAL(18,0), 
                @LePhiThe DECIMAL(18,0), 
                @MaDonHangMoi INT;

        -- 1. Tính tổng tiền các mặt hàng trong giỏ
        SELECT @TienHang = SUM(sp.GiaBan * g.SoLuong)
        FROM ChiTietGioHang g 
        JOIN SanPham sp ON sp.MaSP = g.MaSP
        WHERE g.MaKhachHang = @MaKhachHang;

        IF @TienHang IS NULL OR @TienHang = 0
        BEGIN
            RAISERROR(N'Giỏ hàng của bạn đang trống.', 16, 1);
            RETURN;
        END

        -- 2. Xác định khu vực và tính phí giao hàng
        SELECT @MaKhuVuc = MaKhuVuc FROM NguoiNhan WHERE MaNguoiNhan = @MaNguoiNhan;
        SET @PhiShip = dbo.fn_PhiGiaoHang(@MaKhuVuc, @MaLoaiPhieu, @TienHang);

        -- 3. Lấy lệ phí thẻ
        SELECT @LePhiThe = ISNULL(LePhi, 0) FROM LoaiThe WHERE MaLoaiThe = @MaLoaiThe;

        -- 4. Tạo hóa đơn đơn hàng
        INSERT INTO DonHang(MaKhachHang, MaNguoiNhan, MaLoaiPhieu, MaLoaiThe, SoTheChe, TenChuThe, NgayHetHan,
                            TienHang, PhiGiaoHang, LePhiThe, TongTriGia)
        VALUES (@MaKhachHang, @MaNguoiNhan, @MaLoaiPhieu, @MaLoaiThe, @SoTheChe, @TenChuThe, @NgayHetHan,
                @TienHang, @PhiShip, @LePhiThe, @TienHang + @PhiShip + @LePhiThe);

        SET @MaDonHangMoi = SCOPE_IDENTITY();

        -- 5. Chuyển chi tiết giỏ hàng sang chi tiết đơn hàng (Chốt giá bán)
        INSERT INTO ChiTietDonHang(MaDonHang, MaSP, SoLuong, DonGia)
        SELECT @MaDonHangMoi, g.MaSP, g.SoLuong, sp.GiaBan
        FROM ChiTietGioHang g 
        JOIN SanPham sp ON sp.MaSP = g.MaSP
        WHERE g.MaKhachHang = @MaKhachHang;

        -- 6. Làm sạch giỏ hàng của khách sau khi đã đặt hàng
        DELETE FROM ChiTietGioHang WHERE MaKhachHang = @MaKhachHang;

        COMMIT TRAN;

        -- Trả về mã đơn hàng để ứng dụng gửi email xác nhận
        SELECT @MaDonHangMoi AS MaDonHang;
    END TRY
    BEGIN CATCH
        IF @@TRANCOUNT > 0 
            ROLLBACK TRAN;
        THROW;
    END CATCH
END
GO