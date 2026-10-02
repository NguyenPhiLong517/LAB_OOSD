stateDiagram-v2
    [*] --> KhoiTao: Tạo đơn hàng từ giỏ

    KhoiTao --> ChoThanhToan: Nhập thông tin & chọn thanh toán thẻ
    
    ChoThanhToan --> DaThanhToan: Cổng thanh toán báo Thành công
    ChoThanhToan --> DaHuy: Thẻ bị từ chối / Khách hủy giao dịch

    DaThanhToan --> DangGiao: Kho xuất hàng & bàn giao vận chuyển
    
    DangGiao --> HoanTat: Khách hàng ký nhận thành công
    DangGiao --> DaHuy: Giao hàng thất bại / Trả hàng

    DaHuy --> [*]
    HoanTat --> [*]
