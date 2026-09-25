USE QuanLyKhachSan;
GO

-- 1. Bổ sung trường Tiền đền bù vào Hóa đơn (nếu chưa có) để dự phòng trường hợp cộng tiền đền bù vào hóa đơn tổng
IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID('HoaDon') AND name = 'TienDenBu')
BEGIN
    ALTER TABLE HoaDon ADD TienDenBu decimal(18,2) NOT NULL DEFAULT 0;
END
GO

-- 2. Đảm bảo các chỉ mục hỗ trợ kiểm tra trùng phòng và tìm kiếm nhanh theo khoảng thời gian
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE name = 'IX_PhieuDatPhong_Ngay' AND object_id = OBJECT_ID('PhieuDatPhong'))
BEGIN
    CREATE INDEX IX_PhieuDatPhong_Ngay ON PhieuDatPhong(NgayNhan, NgayTraDuKien, TrangThai);
END
GO

IF NOT EXISTS (SELECT * FROM sys.indexes WHERE name = 'IX_CTDat_Phong' AND object_id = OBJECT_ID('ChiTietDatPhong'))
BEGIN
    CREATE INDEX IX_CTDat_Phong ON ChiTietDatPhong(SoPhong, SoPhieuDat);
END
GO

IF NOT EXISTS (SELECT * FROM sys.indexes WHERE name = 'IX_PhieuSDDV_DatPhong' AND object_id = OBJECT_ID('PhieuSuDungDV'))
BEGIN
    CREATE INDEX IX_PhieuSDDV_DatPhong ON PhieuSuDungDV(SoPhieuDat, SoPhong, NgaySuDung);
END
GO