```mermaid
stateDiagram-v2
    [*] --> KhoiTao
    KhoiTao --> ChoThanhToan: Tao don hang
    ChoThanhToan --> DaThanhToan: Thanh toan thanh cong
    ChoThanhToan --> DaHuy: Thanh toan that bai
    DaThanhToan --> DangGiaoHang: Giao cho van chuyen
    DangGiaoHang --> HoanTat: Khach da nhan hang
    DangGiaoHang --> DaHuy: Giao hang that bai
    DaHuy --> [*]
    HoanTat --> [*]
```
