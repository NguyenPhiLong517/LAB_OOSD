```mermaid
classDiagram
    class PhieuGiaoHang {
        <<abstract>>
        #string maPhieu
        #string diaChiNhan
        #decimal cuocPhiChuan
        +tinhPhiGiaoHang(decimal tongTien)* decimal
    }

    class GiaoHangThuong {
        +tinhPhiGiaoHang(decimal tongTien) decimal
    }

    class GiaoHangNhanh {
        +tinhPhiGiaoHang(decimal tongTien) decimal
    }

    class GiaoHangTrongNgay {
        +tinhPhiGiaoHang(decimal tongTien) decimal
    }

    PhieuGiaoHang <|-- GiaoHangThuong
    PhieuGiaoHang <|-- GiaoHangNhanh
    PhieuGiaoHang <|-- GiaoHangTrongNgay

    class IPaymentGateway {
        <<interface>>
        +validateCard(string soThe, string csv) bool
        +charge(decimal amount) bool
    }

    class OnlinePaymentAdapter {
        +validateCard(string soThe, string csv) bool
        +charge(decimal amount) bool
    }

    IPaymentGateway <|.. OnlinePaymentAdapter
