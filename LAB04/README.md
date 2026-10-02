```mermaid
stateDiagram-v2
    [*] --> KhoiTao: createOrder()
    KhoiTao --> ChoThanhToan: submitInfo()
    ChoThanhToan --> DaThanhToan: paymentSuccess
    ChoThanhToan --> DaHuy: paymentFailed / cancel
    DaThanhToan --> DangGiaoHang: dispatchGoods()
    DangGiaoHang --> HoanTat: deliverySuccess / signed
    DangGiaoHang --> DaHuy: deliveryFailed / returned
    HoanTat --> [*]
    DaHuy --> [*]
```
