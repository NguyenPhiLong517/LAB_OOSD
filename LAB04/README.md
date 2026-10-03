```mermaid
stateDiagram-v2
    [*] --> ConHang: nhapKhoMoi()
    ConHang --> TamHetHang: banHetHang [soLuongTon == 0]
    TamHetHang --> ConHang: nhapThemHang [soLuongTon > 0]
    ConHang --> NgungKinhDoanh: ngungPhanPhoi()
    TamHetHang --> NgungKinhDoanh: ngungPhanPhoi()
    NgungKinhDoanh --> [*]
