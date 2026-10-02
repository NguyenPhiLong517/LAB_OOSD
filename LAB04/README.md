```mermaid
stateMachine BankATM
stateDiagram-v2

    [*] --> KhoiTao: createOrder()

    state "DangXuLyThanhToan (Serving Payment)" as DangXuLy {
        [*] --> KiemTraThongTinThe
        KiemTraThongTinThe --> GuiCongThanhToan: [theHopLe == true] / requestPayment()
        GuiCongThanhToan --> XacNhanKetQua: paymentCallback()
        
        --
        entry / lockCart()
        exit / unlockCart()
    }

    KhoiTao --> DangXuLy: submitOrder() / inputCard()
    
    DangXuLy --> DaThanhToan: paymentSuccess / createInvoice()
    DangXuLy --> DaHuy: paymentFailed [retryCount > 3] / cancelOrder()
    
    state "DangGiaoHang (Shipping)" as DangGiaoHang {
        [*] --> DongGoi
        DongGoi --> DangVanChuyen: banGiaoShipper()
        DangVanChuyen --> PhatHang: denDiaChiNhan()
    }

    DaThanhToan --> DangGiaoHang: dispatchGoods()
    
    DangGiaoHang --> HoanTat: deliverySuccess / customerSign()
    DangGiaoHang --> DaHuy: deliveryFailed / returnToStock()

    HoanTat --> [*]
    DaHuy --> [*]
```
