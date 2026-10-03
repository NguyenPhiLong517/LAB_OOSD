```mermaid
sequenceDiagram
    actor KH as KhachHang
    participant UI as frmChiTietSP
    participant CS as CartService
    participant PA as ProductAdapter

    KH ->> UI: ChonSoLuong_BamThem()
    activate UI
    UI ->> CS: AddToCart(maSP, soLuong)
    activate CS
    CS ->> PA: CheckStock(maSP)
    activate PA
    PA -->> CS: TraVeTonKho(duHang = true)
    deactivate PA
    CS ->> CS: CapNhatSessionGioHang()
    CS -->> UI: Result(Success = true)
    deactivate CS
    UI -->> KH: ThongBaoThanhCong()
    deactivate UI
