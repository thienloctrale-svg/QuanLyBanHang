using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Data;
using QuanLyBanHang.BLL;

namespace QuanLyBanHang.Tests
{
    [TestClass]
    public class ThongKeBLLTests
    {
        private ThongKeBLL bll;

        [TestInitialize]  /// Khởi tạo môi trường kiểm thử trước khi mỗi test case được thực thi.
        public void Setup()
        {
            bll = new ThongKeBLL();
        }


        [TestMethod] /// Test case: Kiểm tra logic tính khoảng thời gian khi chọn lọc "Hôm nay".
        public void TinhKhoangThoiGian_HomNay_TraVeNgayTrungNhau()
        {
            // 1. Arrange: Chuẩn bị ngày mốc giả lập
            DateTime moc = new DateTime(2026, 11, 3);

            // 2. Act: Thực hiện tính toán khoảng ngày
            var ketQua = bll.TinhKhoangThoiGian(LoaiLocThoiGian.HomNay, moc);

            // 3. Assert: Kiểm tra ngày bắt đầu và kết thúc có cùng là ngày mốc hay không
            Assert.AreEqual(moc.Date, ketQua.TuNgay, "TuNgay phai khop voi ngay moc.");
            Assert.AreEqual(moc.Date, ketQua.DenNgay, "DenNgay phai khop voi ngay moc.");
        }


        [TestMethod] /// Test case: Kiểm tra logic tính khoảng thời gian khi chọn lọc "7 ngày gần nhất".
        public void TinhKhoangThoiGian_7NgayGanNhat_TraVeDung7Ngay()
        {
            // 1. Arrange: Chuẩn bị ngày mốc giả lập
            DateTime moc = new DateTime(2026, 11, 3);

            // 2. Act: Thực hiện tính toán khoảng ngày
            var ketQua = bll.TinhKhoangThoiGian(LoaiLocThoiGian.BayNgayGanNhat, moc);

            // 3. Assert: 
            // - TuNgay phai tru di 6 ngay so voi moc (03/11 tru 6 ngay la 28/10)
            // - DenNgay phai la ngay moc
            // - Tong so ngay tinh ca 2 dau moc phai bang 7
            Assert.AreEqual(new DateTime(2026, 10, 28), ketQua.TuNgay, "TuNgay tinh toan khong chinh xac.");
            Assert.AreEqual(moc.Date, ketQua.DenNgay, "DenNgay phai la ngay moc hien tai.");
            Assert.AreEqual(7, (ketQua.DenNgay - ketQua.TuNgay).Days + 1, "Khoang thoi gian phai tron ven 7 ngay.");
        }


        [TestMethod] /// Test case: Kiểm tra logic xác thực khoảng ngày khi người dùng nhập sai thứ tự ngày.
        public void KiemTraKhoangNgayHopLe_TuNgayLonHonDenNgay_TraVeFalse()
        {
            // 1. Arrange: Nhập ngày bắt đầu lớn hơn ngày kết thúc (05/11 > 01/11)
            DateTime tuNgay = new DateTime(2026, 11, 5);
            DateTime denNgay = new DateTime(2026, 11, 1);

            // 2. Act: Gọi hàm kiểm tra hợp lệ
            bool hopLe = bll.KiemTraKhoangNgayHopLe(tuNgay, denNgay, out string loi);

            // 3. Assert: Kết quả phải là không hợp lệ và có câu thông báo tương ứng
            Assert.IsFalse(hopLe, "Khoang ngay sai phai tra ve ket qua false.");
            Assert.AreEqual("Từ ngày không được lớn hơn đến ngày.", loi, "Thong bao loi khong khop voi yeu cau.");
        }


        [TestMethod] /// Test case: Kiểm tra logic tạo nội dung file CSV báo cáo doanh thu.
        public void TaoNoiDungBaoCaoCsv_DuLieuHopLe_SinhDungDinhDangVaGiaTriMacDinh()
        {
            // 1. Arrange: Khởi tạo bảng dữ liệu mẫu trực tiếp trong bộ nhớ
            DataTable dt = new DataTable();
            dt.Columns.Add("MaHoaDon");
            dt.Columns.Add("NgayLap", typeof(DateTime));
            dt.Columns.Add("TenKhachHang");
            dt.Columns.Add("PhuongThucThanhToan");
            dt.Columns.Add("TongTien", typeof(decimal));

            // Dòng 1: Hóa đơn đầy đủ tên khách hàng
            dt.Rows.Add("HD01", new DateTime(2026, 11, 1), "Nguyễn Văn A", "Tiền mặt", 150000m);
            // Dòng 2: Hóa đơn không có tên khách hàng (DBNull.Value) để kiểm tra giá trị mặc định
            dt.Rows.Add("HD02", new DateTime(2026, 11, 2), DBNull.Value, "Chuyển khoản", 200000m);

            // 2. Act: Xuất nội dung chuỗi CSV
            string csv = bll.TaoNoiDungBaoCaoCsv(dt);

            // 3. Assert: Kiểm tra chuỗi trả về
            // Kiểm tra dòng tiêu đề
            StringAssert.Contains(csv, "Mã hóa đơn,Ngày lập,Khách hàng,Phương thức thanh toán,Tổng tiền", "Thieu hoac sai tieu de cot CSV.");
            // Kiểm tra định dạng bản ghi có tên khách
            StringAssert.Contains(csv, "\"HD01\",\"01/11/2026\",\"Nguyễn Văn A\",\"Tiền mặt\",\"150,000 VNĐ\"", "Du lieu dong 1 khong dung dinh dang.");
            // Kiểm tra xử lý trường hợp khách lẻ (DBNull)
            StringAssert.Contains(csv, "\"HD02\",\"02/11/2026\",\"Khách lẻ\",\"Chuyển khoản\",\"200,000 VNĐ\"", "Gia tri mac dinh 'Khach le' chua duoc xu ly dung.");
        }
    }
}