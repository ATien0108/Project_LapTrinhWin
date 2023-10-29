CREATE DATABASE QuanLyQuanNET
GO

USE QuanLyQuanNET
GO

-- Tạo bảng Khách hàng
CREATE TABLE KhachHang (
	MaKhachHang NVARCHAR(10) PRIMARY KEY,
	TenKhachHang NVARCHAR(100),
	SoDienThoai NVARCHAR(10),
	DiaChi NVARCHAR(100)
)
GO

-- Tạo bảng Tài khoản Khách hàng
CREATE TABLE TaiKhoan_KhachHang (
	MaTaiKhoan NVARCHAR(10) PRIMARY KEY,
	MaKhachHang NVARCHAR(10),
	TenDangNhap NVARCHAR(50),
	MatKhau NVARCHAR(50),
	SoTienDaNap INT,
	TrangThaiTaiKhoan INT,
	CONSTRAINT FK_TaiKhoan_KhachHang FOREIGN KEY (MaKhachHang) REFERENCES KhachHang(MaKhachHang)
)
go

-- Tạo bảng Chức vụ
CREATE TABLE ChucVu (
	MaChucVu NVARCHAR(10) PRIMARY KEY,
	TenChucVu NVARCHAR(50),
	MoTaCongViec NVARCHAR(200),
	Luong DECIMAL(18,2)
)
go

-- Tạo bảng Nhân viên
CREATE TABLE NhanVien (
	MaNhanVien NVARCHAR(10) PRIMARY KEY,
	TenNhanVien NVARCHAR(100),
	SoDienThoai NVARCHAR(10),
	DiaChi NVARCHAR(100),
	MaChucVu NVARCHAR(10),
	CONSTRAINT FK_ChucVu_NhanVien FOREIGN KEY (MaChucVu) REFERENCES ChucVu(MaChucVu)
)
GO

-- Tạo bảng Tài khoản Nhân Viên
CREATE TABLE TaiKhoan_NhanVien (
	MaTaiKhoan NVARCHAR(10) PRIMARY KEY,
	MaNhanVien NVARCHAR(10),
	TenDangNhap NVARCHAR(50),
	MatKhau NVARCHAR(50),
	CONSTRAINT FK_TaiKhoan_NhanVien FOREIGN KEY (MaNhanVien) REFERENCES NhanVien(MaNhanVien)
)
go

-- Tạo bảng Phòng máy
CREATE TABLE PhongMay (
	MaPhong NVARCHAR(10) PRIMARY KEY,
	TenPhong NVARCHAR(50),
	SoLuongMay INT,
	DonGiaMoiMay INT,
)
go

-- Tạo bảng Máy tính
CREATE TABLE MayTinh (
	MaMayTinh NVARCHAR(10) PRIMARY KEY,
	MaPhong NVARCHAR(10),
	TenMayTinh NVARCHAR(50),
	TrangThaiMayTinh INT,
	ThoiGianMo DATETIME,
	MaTaiKhoan NVARCHAR(10),
	CONSTRAINT FK_TaiKhoan_KhachHang_MayTinh FOREIGN KEY (MaTaiKhoan) REFERENCES TaiKhoan_KhachHang(MaTaiKhoan),
	CONSTRAINT FK_PhongMay_MayTinh FOREIGN KEY (MaPhong) REFERENCES PhongMay(MaPhong)
)
go

-- Tạo bảng Dịch vụ
CREATE TABLE DichVu (
	MaDichVu NVARCHAR(10) PRIMARY KEY,
	LoaiDichVu NVARCHAR(50),
	TenSanPham NVARCHAR(50),
	DonGia INT
)
go

-- Tạo bảng hóa đơn dịch vụ
CREATE TABLE HoaDon_DichVu (
	MaHoaDonDV NVARCHAR(10) PRIMARY KEY,
	MaTaiKhoan NVARCHAR(10),
	MaDichVu NVARCHAR(10),
	SoLuong INT,
	ThoiGianDatHang DATETIME,
	TongThanhTien INT,
	CONSTRAINT FK_TaiKhoan_HoaDonDichVu FOREIGN KEY (MaTaiKhoan) REFERENCES TaiKhoan_KhachHang(MaTaiKhoan)
)
go

-- Tạo bảng Hóa đơn máy tính
CREATE TABLE HoaDon_MayTinh (
	MaHoaDonMT NVARCHAR(10) PRIMARY KEY,
	MaTaiKhoan NVARCHAR(10),
	MaMayTinh NVARCHAR(10),
	ThoiGianMoMay DATETIME,
	ThoiGianThanhToan DATETIME,
	ThoiGianSuDung INT,
	TongThanhTien INT,
	CONSTRAINT FK_TaiKhoan_HoaDonMayTinh FOREIGN KEY (MaTaiKhoan) REFERENCES TaiKhoan_KhachHang(MaTaiKhoan),
	CONSTRAINT FK_MayTinh_HoaDonMayTinh FOREIGN KEY (MaMayTinh) REFERENCES MayTinh(MaMayTinh)
)
go