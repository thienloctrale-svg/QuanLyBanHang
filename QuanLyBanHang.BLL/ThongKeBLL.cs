using System;
using System.Data;
using System.Text;
using QuanLyBanHang.DAL;

namespace QuanLyBanHang.BLL
{
    public enum LoaiLocThoiGian
    {
        HomNay,
        BayNgayGanNhat,
        BaMuoiNgayGanNhat
    }

    public class ThongKeBLL
    {
        private readonly ThongKeDAL thongKeDAL = new ThongKeDAL();

        #region Logic nghiệp vụ thuần (Sử dụng để viết Unit Test)

        // 1. Logic tính toán khoảng ngày theo lựa chọn
        public (DateTime TuNgay, DateTime DenNgay) TinhKhoangThoiGian(LoaiLocThoiGian loaiLoc, DateTime ngayMoc)
        {
            DateTime moc = ngayMoc.Date;
            switch (loaiLoc)
            {
                case LoaiLocThoiGian.HomNay:
                    return (moc, moc);
                case LoaiLocThoiGian.BayNgayGanNhat:
                    return (moc.AddDays(-6), moc);
                case LoaiLocThoiGian.BaMuoiNgayGanNhat:
                    return (moc.AddDays(-29), moc);
                default:
                    return (moc, moc);
            }
        }

        // 2. Logic kiểm tra tính hợp lệ của khoảng ngày
        public bool KiemTraKhoangNgayHopLe(DateTime tuNgay, DateTime denNgay, out string thongBaoLoi)
        {
            if (tuNgay.Date > denNgay.Date)
            {
                thongBaoLoi = "Từ ngày không được lớn hơn đến ngày.";
                return false;
            }

            thongBaoLoi = string.Empty;
            return true;
        }

        // 3. Logic xử lý chuỗi nội dung báo cáo CSV
        public string TaoNoiDungBaoCaoCsv(DataTable dsHoaDon)
        {
            if (dsHoaDon == null || dsHoaDon.Rows.Count == 0)
                return string.Empty;

            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Mã hóa đơn,Ngày lập,Khách hàng,Phương thức thanh toán,Tổng tiền");

            foreach (DataRow row in dsHoaDon.Rows)
            {
                string ma = Convert.ToString(row["MaHoaDon"]);
                string ngay = row.IsNull("NgayLap")
                    ? string.Empty
                    : Convert.ToDateTime(row["NgayLap"]).ToString("dd/MM/yyyy");

                string khachHang = row.IsNull("TenKhachHang") || string.IsNullOrWhiteSpace(Convert.ToString(row["TenKhachHang"]))
                    ? "Khách lẻ"
                    : Convert.ToString(row["TenKhachHang"]);

                string phuongThuc = Convert.ToString(row["PhuongThucThanhToan"]);

                decimal tongTien = row.IsNull("TongTien") ? 0 : Convert.ToDecimal(row["TongTien"]);
                string tongTienStr = tongTien.ToString("N0") + " VNĐ";

                sb.AppendLine($"\"{ma}\",\"{ngay}\",\"{khachHang}\",\"{phuongThuc}\",\"{tongTienStr}\"");
            }

            return sb.ToString();
        }

        #endregion

        #region Truy xuất dữ liệu (DAL)

        public DataTable LayDanhSachHoaDon(
            DateTime tuNgay,
            DateTime denNgay,
            string phuongThucThanhToan,
            string tuKhoa)
        {
            if (!KiemTraKhoangNgayHopLe(tuNgay, denNgay, out string loi))
                throw new ArgumentException(loi);

            return thongKeDAL.LayDanhSachHoaDon(
                tuNgay, denNgay, phuongThucThanhToan, tuKhoa);
        }

        public DataTable LayThongTinTongQuan(
            DateTime tuNgay,
            DateTime denNgay,
            string phuongThucThanhToan,
            string tuKhoa)
        {
            if (!KiemTraKhoangNgayHopLe(tuNgay, denNgay, out string loi))
                throw new ArgumentException(loi);

            return thongKeDAL.LayThongTinTongQuan(
                tuNgay, denNgay, phuongThucThanhToan, tuKhoa);
        }

        public DataTable LayChiTietHoaDon(string maHoaDon)
        {
            if (string.IsNullOrWhiteSpace(maHoaDon))
                return new DataTable();

            return thongKeDAL.LayChiTietHoaDon(maHoaDon);
        }

        #endregion
    }
}