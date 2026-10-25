# QuanLyBanHang

Phần mềm quản lý bán hàng được xây dựng bằng C# WinForms, .NET 8 và SQL Server.

## 1. Giới thiệu

Dự án được thực hiện nhằm hỗ trợ các nghiệp vụ quản lý bán hàng cơ bản, với giao diện Windows Forms và cơ sở dữ liệu SQL Server.

## 2. Công nghệ sử dụng

- **Ngôn ngữ:** C#
- **Nền tảng:** .NET 8
- **Giao diện:** Windows Forms (WinForms)
- **Cơ sở dữ liệu:** Microsoft SQL Server
- **Truy cập dữ liệu:** ADO.NET, Microsoft.Data.SqlClient
- **Logging:** Serilog
- **Kiểm thử:** MSTest
- **IDE:** Visual Studio

## 3. Cấu trúc dự án

- `QuanLyBanHang.UI`: Giao diện người dùng.
- `QuanLyBanHang.BLL`: Xử lý nghiệp vụ.
- `QuanLyBanHang.DAL`: Truy cập dữ liệu.
- `QuanLyBanHang.DTO`: Các đối tượng truyền tải dữ liệu.
- `QuanLyBanHang.Logging`: Ghi nhật ký hoạt động và lỗi.
- `QuanLyBanHang.Tests`: Dự án kiểm thử.
- `QuanLyBanHang.slnx`: File Solution của Visual Studio.

## 4. Các chức năng và hạng mục

Cấu trúc dự án hiện có các màn hình liên quan đến:

- Đăng nhập.
- Trang chủ.
- Quản lý sản phẩm.
- Quản lý khách hàng.
- Quản lý tài khoản.
- Nhập hàng.
- Bán hàng.
- Thống kê.

Lưu ý: Mức độ hoàn thiện của từng chức năng phụ thuộc vào phần triển khai trong mã nguồn.

## 5. Yêu cầu môi trường

- Windows.
- Visual Studio hỗ trợ .NET 8.
- .NET 8 SDK.
- Microsoft SQL Server.
- Git (nếu muốn tải mã nguồn bằng Git).

## 6. Cấu hình cơ sở dữ liệu

1. Cài đặt và khởi động SQL Server.
2. Tạo cơ sở dữ liệu `QuanLyBanHang`.
3. Kiểm tra chuỗi kết nối trong file `appsettings.json` của dự án UI và dự án Tests.
4. Nếu tên instance SQL Server trên máy khác với cấu hình hiện tại, hãy cập nhật chuỗi kết nối tương ứng.

Chuỗi kết nối mẫu cho môi trường phát triển cục bộ:

`Server=.;Database=QuanLyBanHang;Integrated Security=True;TrustServerCertificate=True;`

Cấu hình này sử dụng Windows Authentication. Tùy môi trường, bạn có thể cần điều chỉnh tên máy chủ, instance và thiết lập chứng chỉ.

## 7. Cách chạy dự án

1. Clone repository về máy.
2. Mở `QuanLyBanHang.slnx` bằng Visual Studio.
3. Khôi phục các gói NuGet nếu được yêu cầu.
4. Cấu hình SQL Server và cơ sở dữ liệu `QuanLyBanHang`.
5. Chọn `QuanLyBanHang.UI` làm Startup Project.
6. Build Solution và chạy chương trình.

## 8. Kiểm thử

Mở Test Explorer trong Visual Studio, build dự án kiểm thử và chạy các test phù hợp với môi trường đã cấu hình.

Một số test có thể cần SQL Server đang hoạt động và cơ sở dữ liệu được thiết lập đúng.

## 9. Logging

Dự án sử dụng Serilog để ghi nhật ký hoạt động và lỗi. Thư mục log được tạo trong thư mục chạy ứng dụng theo cấu hình của dự án Logging.

## 10. Trạng thái dự án

Dự án đang trong quá trình phát triển và hoàn thiện.

## 11. Repository

GitHub: https://github.com/thienloctrale-svg/QuanLyBanHang
