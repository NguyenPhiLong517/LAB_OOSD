classDiagram
    class KhachHang {
        -string maKH
        -string hoTen
        -string cmnd
        -string diaChi
        -string dienThoai
        -string email
        +dangNhap() bool
        +dangKy() bool
    }

    class DonHang {
        -string maDonHang
        -DateTime ngayDat
        -string nguoiNhan_HoTen
        -string nguoiNhan_DiaChi
        -string nguoiNhan_SDT
        -decimal phiVanChuyen
        -decimal tongTien
        +tinhTongTien() decimal
    }

    class ChiTietDonHang {
        -int soLuong
        -decimal donGiaBan
        +tinhThanhTien() decimal
    }

    class SanPham {
        -string maSP
        -string tenSP
        -decimal giaHienHanh
        -int soLuongTon
        +kiemTraTonKho() bool
    }

    KhachHang "1" --> "0..*" DonHang : DatMua
    DonHang "1" *-- "1..*" ChiTietDonHang : BaoGom
    SanPham "1" <-- "0..*" ChiTietDonHang : ThamChieu
