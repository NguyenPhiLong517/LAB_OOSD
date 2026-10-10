using System;
using System.Data;
using System.Data.SqlClient;
using DuLichVanHoaViet.Data;

namespace DuLichVanHoaViet.Services
{
    public class TourService
    {
        public DataTable LayDanhSachTour()
        {
            return DBHelper.ExecuteQuery("SELECT MaTour, TenTour, SoNgay, SoDem, DonGiaKhach FROM TOUR");
        }

        // Quy tắc BR03: Kiểm tra đoàn phải > 12 người
        public bool KiemTraSoLuongDoan(int soNguoi)
        {
            return soNguoi > 12;
        }

        // Tính ngày về dựa trên ngày đi và số ngày tour
        public DateTime TinhNgayVe(DateTime ngayDi, int soNgayTour)
        {
            return ngayDi.AddDays(soNgayTour - 1);
        }

        // Lưu phiếu đăng ký đoàn cùng giao dịch đặt cọc vào CSDL (Transaction)
        public bool LuuDangKyDoan(int maTour, string tenCoQuan, string diaChi, string sdt, string nguoiDaiDien,
                                 int soNguoi, DateTime ngayDi, DateTime ngayVe, string diemDon,
                                 bool coBaoHiem, decimal tienCoc, decimal tongTienDuKien)
        {
            using (SqlConnection conn = DBHelper.GetConnection())
            {
                conn.Open();
                SqlTransaction tran = conn.BeginTransaction();
                try
                {
                    // 1. Tạo Khách hàng đại diện
                    string sqlKH = @"INSERT INTO KHACH_HANG (LoaiKhachHang, TenKhachHoacDonVi, DiaChi, DienThoai, NguoiDaiDien) 
                                     OUTPUT INSERTED.MaKhachHang 
                                     VALUES (N'Doan', @Ten, @DiaChi, @SDT, @DaiDien)";
                    SqlCommand cmdKH = new SqlCommand(sqlKH, conn, tran);
                    cmdKH.Parameters.AddWithValue("@Ten", tenCoQuan);
                    cmdKH.Parameters.AddWithValue("@DiaChi", diaChi);
                    cmdKH.Parameters.AddWithValue("@SDT", sdt);
                    cmdKH.Parameters.AddWithValue("@DaiDien", nguoiDaiDien);
                    int maKH = (int)cmdKH.ExecuteScalar();

                    // 2. Tạo Phiếu Đăng Ký cha
                    string sqlPhieu = @"INSERT INTO PHIEU_DANG_KY (MaKhachHang, TrangThai, TongTienDuKien) 
                                        OUTPUT INSERTED.MaPhieuDangKy 
                                        VALUES (@MaKH, N'ChoXacNhan', @TongTien)";
                    SqlCommand cmdPhieu = new SqlCommand(sqlPhieu, conn, tran);
                    cmdPhieu.Parameters.AddWithValue("@MaKH", maKH);
                    cmdPhieu.Parameters.AddWithValue("@TongTien", tongTienDuKien);
                    int maPhieu = (int)cmdPhieu.ExecuteScalar();

                    // 3. Tạo Phiếu Đăng Ký Đoàn con
                    string sqlDoan = @"INSERT INTO PHIEU_DANG_KY_DOAN 
                                      (MaPhieuDangKy, MaTour, NgayDiChon, NgayVeDuKien, TenCoQuan, DiaChiCoQuan, 
                                       DienThoaiCoQuan, NguoiDaiDien, SoNguoi, DiaDiemDon, CoMuaBaoHiem, TienDatCoc)
                                       VALUES 
                                      (@MaPhieu, @MaTour, @NgayDi, @NgayVe, @Ten, @DiaChi, @SDT, @DaiDien, @SoNguoi, @DiemDon, @CoBH, @TienCoc)";
                    SqlCommand cmdDoan = new SqlCommand(sqlDoan, conn, tran);
                    cmdDoan.Parameters.AddWithValue("@MaPhieu", maPhieu);
                    cmdDoan.Parameters.AddWithValue("@MaTour", maTour);
                    cmdDoan.Parameters.AddWithValue("@NgayDi", ngayDi);
                    cmdDoan.Parameters.AddWithValue("@NgayVe", ngayVe);
                    cmdDoan.Parameters.AddWithValue("@Ten", tenCoQuan);
                    cmdDoan.Parameters.AddWithValue("@DiaChi", diaChi);
                    cmdDoan.Parameters.AddWithValue("@SDT", sdt);
                    cmdDoan.Parameters.AddWithValue("@DaiDien", nguoiDaiDien);
                    cmdDoan.Parameters.AddWithValue("@SoNguoi", soNguoi);
                    cmdDoan.Parameters.AddWithValue("@DiemDon", diemDon);
                    cmdDoan.Parameters.AddWithValue("@CoBH", coBaoHiem);
                    cmdDoan.Parameters.AddWithValue("@TienCoc", tienCoc);
                    cmdDoan.ExecuteNonQuery();

                    // 4. Nếu có tiền đặt cọc -> Ghi nhận Giao dịch thanh toán
                    if (tienCoc > 0)
                    {
                        string sqlGD = @"INSERT INTO GIAO_DICH_THANH_TOAN (MaPhieuDangKy, LoaiThanhToan, SoTien, TrangThai)
                                         VALUES (@MaPhieu, N'DatCoc', @SoTien, N'ThanhCong')";
                        SqlCommand cmdGD = new SqlCommand(sqlGD, conn, tran);
                        cmdGD.Parameters.AddWithValue("@MaPhieu", maPhieu);
                        cmdGD.Parameters.AddWithValue("@SoTien", tienCoc);
                        cmdGD.ExecuteNonQuery();
                    }

                    tran.Commit();
                    return true;
                }
                catch
                {
                    tran.Rollback();
                    return false;
                }
            }
        }
    }
}