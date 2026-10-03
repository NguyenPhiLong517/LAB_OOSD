```mermaid
stateDiagram-v2
    [*] --> KhoiTao: createOrder()
    KhoiTao --> ChoThanhToan: submitOrder()
    ChoThanhToan --> DaThanhToan: paymentSuccess
    ChoThanhToan --> DaHuy: paymentFailed
    DaThanhToan --> DangGiaoHang: dispatchGoods()
    DangGiaoHang --> HoanTat: deliverySuccess
    DangGiaoHang --> DaHuy: deliveryFailed
    HoanTat --> [*]
    DaHuy --> [*]
