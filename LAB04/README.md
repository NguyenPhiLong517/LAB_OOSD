@startuml StateDiagram_DonHang
hide empty description

[*] --> KhoiTao : Khách tạo đơn hàng
KhoiTao --> ChoThanhToan : Bấm Xác nhận & Nhập thẻ

state ChoThanhToan {
    [*] --> GuiYeuCauSangCongTT
    GuiYeuCauSangCongTT --> KiemTraThe : Gửi thông tin thẻ
}

ChoThanhToan --> DaThanhToan : Thanh toán thành công (OK)
ChoThanhToan --> DaHuy : Thẻ lỗi / Từ chối / Hủy đơn

DaThanhToan --> DangGiaoHang : Xuất kho, bàn giao Shipper
DangGiaoHang --> HoanTat : Khách đã nhận & ký nhận
DangGiaoHang --> DaHuy : Giao không thành công / Hoàn hàng

HoanTat --> [*]
DaHuy --> [*]
@enduml
