using System;
using System.Data;
using QuanLyBanHang.DAL;

namespace QuanLyBanHang.BLL
{
    public class ThongKeBLL
    {
        private readonly ThongKeDAL thongKeDAL = new ThongKeDAL();

        public DataTable LayDanhSachHoaDon(
            DateTime tuNgay,
            DateTime denNgay,
            string phuongThucThanhToan,
            string tuKhoa)
        {
            if (tuNgay.Date > denNgay.Date)
                throw new Exception("Từ ngày không được lớn hơn đến ngày.");

            return thongKeDAL.LayDanhSachHoaDon(
                tuNgay, denNgay, phuongThucThanhToan, tuKhoa);
        }

        public DataTable LayThongTinTongQuan(
            DateTime tuNgay,
            DateTime denNgay,
            string phuongThucThanhToan,
            string tuKhoa)
        {
            if (tuNgay.Date > denNgay.Date)
                throw new Exception("Từ ngày không được lớn hơn đến ngày.");

            return thongKeDAL.LayThongTinTongQuan(
                tuNgay, denNgay, phuongThucThanhToan, tuKhoa);
        }

        public DataTable LayChiTietHoaDon(string maHoaDon)
        {
            if (string.IsNullOrWhiteSpace(maHoaDon))
                return new DataTable();

            return thongKeDAL.LayChiTietHoaDon(maHoaDon);
        }
    }
}