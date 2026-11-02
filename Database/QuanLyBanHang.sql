-- 1. Tạo cơ sở dữ liệu nếu chưa tồn tại
IF NOT EXISTS (SELECT * FROM sys.databases WHERE name = 'QuanLyBanHang')
BEGIN
    CREATE DATABASE QuanLyBanHang;
END
GO

USE QuanLyBanHang;
GO

-- 2. Xóa các bảng cũ theo thứ tự ràng buộc khóa ngoại (nếu có)
IF OBJECT_ID('ChiTietHoaDon', 'U') IS NOT NULL DROP TABLE ChiTietHoaDon;
IF OBJECT_ID('HoaDon', 'U') IS NOT NULL DROP TABLE HoaDon;
IF OBJECT_ID('ChiTietPhieuNhap', 'U') IS NOT NULL DROP TABLE ChiTietPhieuNhap;
IF OBJECT_ID('PhieuNhap', 'U') IS NOT NULL DROP TABLE PhieuNhap;
IF OBJECT_ID('SanPham', 'U') IS NOT NULL DROP TABLE SanPham;
IF OBJECT_ID('LoaiSanPham', 'U') IS NOT NULL DROP TABLE LoaiSanPham;
IF OBJECT_ID('KhachHang', 'U') IS NOT NULL DROP TABLE KhachHang;
IF OBJECT_ID('NhaCungCap', 'U') IS NOT NULL DROP TABLE NhaCungCap;
IF OBJECT_ID('TaiKhoan', 'U') IS NOT NULL DROP TABLE TaiKhoan;
GO

-- =============================================================
-- 3. Tạo cấu trúc các bảng
-- =============================================================

-- Bảng 3.1: Tài khoản người dùng / Nhân viên
CREATE TABLE TaiKhoan (
    MaTaiKhoan INT IDENTITY(1,1) PRIMARY KEY,
    TenDangNhap VARCHAR(50) NOT NULL UNIQUE,
    MatKhau NVARCHAR(100) NOT NULL,
    HoTen NVARCHAR(100) NOT NULL,
    Email VARCHAR(100) NULL,
    SoDienThoai VARCHAR(20) NULL,
    VaiTro NVARCHAR(50) NOT NULL DEFAULT N'Nhân viên', -- 'Quản trị viên', 'Nhóm trưởng', 'Nhân viên'
    TrangThai NVARCHAR(50) NOT NULL DEFAULT N'Đang hoạt động', -- 'Đang hoạt động', 'Đã khóa'
    NgayTao DATETIME NOT NULL DEFAULT GETDATE()
);
GO

-- Bảng 3.2: Khách hàng
CREATE TABLE KhachHang (
    MaKhachHang VARCHAR(20) PRIMARY KEY,
    TenKhachHang NVARCHAR(100) NOT NULL,
    GioiTinh NVARCHAR(10) NULL, -- 'Nam', 'Nữ', 'Khác'
    NgaySinh DATE NULL,
    SoDienThoai VARCHAR(20) NULL,
    Email VARCHAR(100) NULL,
    LoaiKhachHang NVARCHAR(50) NOT NULL DEFAULT N'Khách thường', -- 'Khách thường', 'Khách thân thiết', 'Khách VIP', 'Khách sỉ'
    DiaChi NVARCHAR(255) NULL,
    TrangThai NVARCHAR(50) NOT NULL DEFAULT N'Đang hoạt động', -- 'Đang hoạt động', 'Tạm ngừng'
    GhiChu NVARCHAR(500) NULL,
    NgayTao DATETIME NOT NULL DEFAULT GETDATE()
);
GO

-- Bảng 3.3: Loại sản phẩm / Ngành hàng
CREATE TABLE LoaiSanPham (
    MaLoaiSP VARCHAR(20) PRIMARY KEY,
    TenLoaiSP NVARCHAR(100) NOT NULL,
    MoTa NVARCHAR(255) NULL
);
GO

-- Bảng 3.4: Sản phẩm
CREATE TABLE SanPham (
    MaSanPham VARCHAR(20) PRIMARY KEY,
    TenSanPham NVARCHAR(150) NOT NULL,
    MaLoaiSP VARCHAR(20) NULL FOREIGN KEY REFERENCES LoaiSanPham(MaLoaiSP),
    DonViTinh NVARCHAR(30) NOT NULL, -- 'Lon', 'Chai', 'Gói', 'Hộp', 'Túi', 'Cái'
    GiaNhap DECIMAL(18,2) NOT NULL DEFAULT 0,
    GiaBan DECIMAL(18,2) NOT NULL DEFAULT 0,
    SoLuongTon INT NOT NULL DEFAULT 0,
    TrangThai NVARCHAR(50) NOT NULL DEFAULT N'Đang kinh doanh', -- 'Đang kinh doanh', 'Ngừng kinh doanh'
    NgayTao DATETIME NOT NULL DEFAULT GETDATE()
);
GO

-- Bảng 3.5: Nhà cung cấp (dùng cho nhập hàng)
CREATE TABLE NhaCungCap (
    MaNCC VARCHAR(20) PRIMARY KEY,
    TenNCC NVARCHAR(150) NOT NULL,
    SoDienThoai VARCHAR(20) NULL,
    DiaChi NVARCHAR(255) NULL,
    Email VARCHAR(100) NULL
);
GO

-- Bảng 3.6: Hóa đơn bán hàng
CREATE TABLE HoaDon (
    MaHoaDon VARCHAR(20) PRIMARY KEY,
    NgayLap DATETIME NOT NULL DEFAULT GETDATE(),
    MaKhachHang VARCHAR(20) NULL FOREIGN KEY REFERENCES KhachHang(MaKhachHang),
    MaTaiKhoan INT NULL FOREIGN KEY REFERENCES TaiKhoan(MaTaiKhoan),
    TongTien DECIMAL(18,2) NOT NULL DEFAULT 0,
    TrangThai NVARCHAR(50) NOT NULL DEFAULT N'Đã thanh toán', -- 'Đã thanh toán', 'Đã hủy', 'Chờ xử lý'
    GhiChu NVARCHAR(255) NULL
);
GO

-- Bảng 3.7: Chi tiết hóa đơn
CREATE TABLE ChiTietHoaDon (
    MaHoaDon VARCHAR(20) NOT NULL FOREIGN KEY REFERENCES HoaDon(MaHoaDon) ON DELETE CASCADE,
    MaSanPham VARCHAR(20) NOT NULL FOREIGN KEY REFERENCES SanPham(MaSanPham),
    SoLuong INT NOT NULL DEFAULT 1,
    DonGia DECIMAL(18,2) NOT NULL DEFAULT 0,
    ThanhTien DECIMAL(18,2) NOT NULL DEFAULT 0,
    PRIMARY KEY (MaHoaDon, MaSanPham)
);
GO

-- Bảng 3.8: Phiếu nhập hàng
CREATE TABLE PhieuNhap (
    MaPhieuNhap VARCHAR(20) PRIMARY KEY,
    NgayNhap DATETIME NOT NULL DEFAULT GETDATE(),
    MaNCC VARCHAR(20) NULL FOREIGN KEY REFERENCES NhaCungCap(MaNCC),
    MaTaiKhoan INT NULL FOREIGN KEY REFERENCES TaiKhoan(MaTaiKhoan),
    TongTien DECIMAL(18,2) NOT NULL DEFAULT 0,
    GhiChu NVARCHAR(255) NULL
);
GO

-- Bảng 3.9: Chi tiết phiếu nhập
CREATE TABLE ChiTietPhieuNhap (
    MaPhieuNhap VARCHAR(20) NOT NULL FOREIGN KEY REFERENCES PhieuNhap(MaPhieuNhap) ON DELETE CASCADE,
    MaSanPham VARCHAR(20) NOT NULL FOREIGN KEY REFERENCES SanPham(MaSanPham),
    SoLuong INT NOT NULL DEFAULT 1,
    DonGiaNhap DECIMAL(18,2) NOT NULL DEFAULT 0,
    ThanhTien DECIMAL(18,2) NOT NULL DEFAULT 0,
    PRIMARY KEY (MaPhieuNhap, MaSanPham)
);
GO

-- =============================================================
-- 4. NẠP DỮ LIỆU MẪU (SEED DATA)
-- =============================================================

-- 4.1. Nạp Tài khoản
INSERT INTO TaiKhoan (TenDangNhap, MatKhau, HoTen, Email, SoDienThoai, VaiTro, TrangThai)
VALUES 
('tiepdm', '123456', N'Đỗ Minh Tiệp', 'tiep.dm@gmail.com', '0912345601', N'Quản trị viên', N'Đang hoạt động'),
('loctlt', '123456', N'Trà Lê Thiên Lộc', 'thienloctrale@gmail.com', '0912345602', N'Nhóm trưởng', N'Đang hoạt động'),
('lienvt', '123456', N'Võ Thuỷ Liên', 'lien.vt@gmail.com', '0912345603', N'Nhân viên', N'Đang hoạt động'),
('nghialtt', '123456', N'Lê Tấn Trọng Nghĩa', 'nghia.ltt@gmail.com', '0912345604', N'Nhân viên', N'Đang hoạt động');
GO

-- 4.2. Nạp Khách hàng
INSERT INTO KhachHang (MaKhachHang, TenKhachHang, GioiTinh, NgaySinh, SoDienThoai, Email, LoaiKhachHang, DiaChi, TrangThai, GhiChu)
VALUES
('KH001', N'Nguyễn Văn An', N'Nam', '1990-05-15', '0901234567', 'an.nguyen@gmail.com', N'Khách VIP', N'123 Lê Lợi, Phường Bến Nghé, Quận 1, TP.HCM', N'Đang hoạt động', N'Khách hàng thân thiết nhiều năm'),
('KH002', N'Trần Thị Mai', N'Nữ', '1995-08-20', '0912345678', 'mai.tran@gmail.com', N'Khách thân thiết', N'456 Hai Bà Trưng, Phường Tân Định, Quận 1, TP.HCM', N'Đang hoạt động', N'Thường mua số lượng vừa'),
('KH003', N'Lê Hoàng Nam', N'Nam', '1988-12-10', '0923456789', 'nam.le@gmail.com', N'Khách thường', N'789 Cách Mạng Tháng 8, Quận 10, TP.HCM', N'Đang hoạt động', N'Khách lẻ vãng lai'),
('KH004', N'Phạm Thanh Thảo', N'Nữ', '1992-03-25', '0934567890', 'thao.pham@gmail.com', N'Khách VIP', N'12 Nguyễn Thị Minh Khai, Quận 1, TP.HCM', N'Đang hoạt động', N'Ưu tiên giao hàng nhanh'),
('KH005', N'Huỳnh Quốc Bảo', N'Nam', '1985-07-04', '0945678901', 'bao.huynh@gmail.com', N'Khách sỉ', N'88 Hùng Vương, Quận 5, TP.HCM', N'Đang hoạt động', N'Lấy sỉ hàng tuần'),
('KH006', N'Hoàng Mỹ Linh', N'Nữ', '1998-11-18', '0956789012', 'linh.hoang@gmail.com', N'Khách thường', N'54 Nguyễn Trãi, Quận 5, TP.HCM', N'Đang hoạt động', N''),
('KH007', N'Đặng Gia Huy', N'Nam', '1993-09-09', '0967890123', 'huy.dang@gmail.com', N'Khách thân thiết', N'102 Trần Hưng Đạo, Quận 1, TP.HCM', N'Đang hoạt động', N'Thanh toán qua chuyển khoản'),
('KH008', N'Vũ Bích Ngọc', N'Nữ', '1996-01-30', '0978901234', 'ngoc.vu@gmail.com', N'Khách thường', N'204 Điện Biên Phủ, Quận Bình Thạnh, TP.HCM', N'Tạm ngừng', N'Khách chuyển chỗ ở');
GO

-- 4.3. Nạp Loại sản phẩm
INSERT INTO LoaiSanPham (MaLoaiSP, TenLoaiSP, MoTa)
VALUES
('LSP01', N'Nước giải khát', N'Các loại đồ uống, nước ngọt có ga, nước khoáng'),
('LSP02', N'Thực phẩm khô', N'Mì gói, bánh mì, ngũ cốc ăn liền'),
('LSP03', N'Bánh kẹo & Snack', N'Các loại bánh ngọt, bim bim, kẹo'),
('LSP04', N'Hàng gia dụng', N'Hóa phẩm giặt xả, nước rửa chén, chất tẩy rửa');
GO

-- 4.4. Nạp Sản phẩm
INSERT INTO SanPham (MaSanPham, TenSanPham, MaLoaiSP, DonViTinh, GiaNhap, GiaBan, SoLuongTon, TrangThai)
VALUES
('SP001', N'Coca Cola Lon 330ml', 'LSP01', N'Lon', 8000, 10000, 150, N'Đang kinh doanh'),
('SP002', N'Pepsi Không Calo 330ml', 'LSP01', N'Lon', 8000, 10000, 120, N'Đang kinh doanh'),
('SP003', N'Nước Khoáng Lavie 500ml', 'LSP01', N'Chai', 4500, 6000, 200, N'Đang kinh doanh'),
('SP004', N'Trà Xanh Không Độ 455ml', 'LSP01', N'Chai', 9000, 12000, 85, N'Đang kinh doanh'),
('SP005', N'Sữa Tươi Vinamilk 100% 1L', 'LSP01', N'Hộp', 29000, 35000, 60, N'Đang kinh doanh'),
('SP006', N'Mì Hảo Hảo Tôm Chua Cay', 'LSP02', N'Gói', 3800, 4500, 300, N'Đang kinh doanh'),
('SP007', N'Mì Xào Indomie Goreng', 'LSP02', N'Gói', 5000, 6500, 180, N'Đang kinh doanh'),
('SP008', N'Bánh Chocopie Hộp 12 Cái', 'LSP03', N'Hộp', 45000, 55000, 45, N'Đang kinh doanh'),
('SP009', N'Snack Khoai Tây Lay''s 95g', 'LSP03', N'Gói', 17000, 22000, 90, N'Đang kinh doanh'),
('SP010', N'Nước Rửa Chén Sunlight 750g', 'LSP04', N'Chai', 22000, 28000, 75, N'Đang kinh doanh'),
('SP011', N'Nước Xả Vải Comfort 1.8L', 'LSP04', N'Túi', 95000, 115000, 40, N'Đang kinh doanh'),
('SP012', N'Dầu Ăn Simply Nguyên Chất 1L', 'LSP02', N'Chai', 42000, 52000, 110, N'Đang kinh doanh');
GO

-- 4.5. Nạp Nhà cung cấp mẫu
INSERT INTO NhaCungCap (MaNCC, TenNCC, SoDienThoai, DiaChi, Email)
VALUES
('NCC01', N'Công ty Cổ phần Thực phẩm Suntory PepsiCo', '02838272727', N'Quận 1, TP.HCM', 'contact@pepsico.com.vn'),
('NCC02', N'Công ty Cổ phần Acecook Việt Nam', '02838154064', N'KCN Tân Bình, TP.HCM', 'info@acecookvietnam.com'),
('NCC03', N'Công ty TNHH Unilever Việt Nam', '02854135686', N'Khu chế xuất Tân Thuận, Quận 7, TP.HCM', 'care@unilever.com');
GO

-- 4.6. Nạp Hóa đơn bán hàng mẫu
INSERT INTO HoaDon (MaHoaDon, NgayLap, MaKhachHang, MaTaiKhoan, TongTien, TrangThai, GhiChu)
VALUES
('HD001', '2026-10-25 09:30:00', 'KH001', 1, 125000, N'Đã thanh toán', N'Khách thanh toán tiền mặt'),
('HD002', '2026-10-26 14:15:00', 'KH002', 2, 230000, N'Đã thanh toán', N'Khách quét mã QR Momo'),
('HD003', '2026-10-27 10:00:00', 'KH003', 3, 85000, N'Đã thanh toán', N'Khách thanh toán tiền mặt'),
('HD004', '2026-10-27 16:45:00', 'KH004', 4, 450000, N'Đã thanh toán', N'Giao tận nơi'),
('HD005', '2026-10-28 11:20:00', 'KH005', 1, 75000, N'Đã hủy', N'Khách đổi ý không mua');
GO

-- 4.7. Nạp Chi tiết hóa đơn
INSERT INTO ChiTietHoaDon (MaHoaDon, MaSanPham, SoLuong, DonGia, ThanhTien)
VALUES
('HD001', 'SP001', 5, 10000, 50000),
('HD001', 'SP008', 1, 55000, 55000),
('HD001', 'SP003', 3, 6000, 18000),
('HD002', 'SP011', 2, 115000, 230000),
('HD003', 'SP006', 10, 4500, 45000),
('HD003', 'SP002', 4, 10000, 40000),
('HD004', 'SP012', 5, 52000, 260000),
('HD004', 'SP005', 4, 35000, 140000),
('HD004', 'SP009', 2, 22000, 44000),
('HD005', 'SP001', 5, 10000, 50000),
('HD005', 'SP003', 4, 6000, 24000);
GO

PRINT N'>>> ĐÃ TẠO DATABASE VÀ NẠP SEED DATA THÀNH CÔNG CHO QUANLYBANHANG! <<<';
GO
