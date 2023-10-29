USE QuanLyQuanNET
GO

-- Tạo view xem thông tin khách hàng
CREATE VIEW View_KhachHang AS
	SELECT MaKhachHang, TenKhachHang, SoDienThoai, DiaChi
	FROM KhachHang
GO

-- Tạo view xem thông tin chức vụ
CREATE VIEW View_ChucVu AS
	SELECT MaChucVu, TenChucVu, MoTaCongViec, Luong
	FROM ChucVu
GO

-- Tạo view xem thông tin nhân viên
CREATE VIEW View_NhanVien AS
	SELECT MaNhanVien, TenNhanVien, SoDienThoai, DiaChi, MaChucVu
	FROM NhanVien
GO

-- Tạo view xem thông tin phòng máy
CREATE VIEW View_PhongMay AS
	SELECT MaPhong, TenPhong, SoLuongMay, DonGiaMoiMay
	FROM PhongMay
GO

-- Tạo view xem thông tin 75 máy tính phòng thường
CREATE VIEW View_MayTinhThuong AS
	SELECT MaMayTinh, MaPhong, TenMayTinh, TrangThaiMayTinh, ThoiGianMo, MaTaiKhoan
	FROM MayTinh
	Where MaPhong = 'P001'
GO

-- Tạo view xem thông tin 50 máy tính phòng VIP
CREATE VIEW View_MayTinhVIP AS
	SELECT MaMayTinh, MaPhong, TenMayTinh, TrangThaiMayTinh, ThoiGianMo, MaTaiKhoan
	FROM MayTinh
	Where MaPhong = 'P002'
GO

-- Tạo view xem thông tin 25 máy tính phòng Stream
CREATE VIEW View_MayTinhStream AS
	SELECT MaMayTinh, MaPhong, TenMayTinh, TrangThaiMayTinh, ThoiGianMo, MaTaiKhoan
	FROM MayTinh
	Where MaPhong = 'P003'
GO

-- Tạo view xem thông tin 30 máy tính phòng Training
CREATE VIEW View_MayTinhTraining AS
	SELECT MaMayTinh, MaPhong, TenMayTinh, TrangThaiMayTinh, ThoiGianMo, MaTaiKhoan
	FROM MayTinh
	Where MaPhong = 'P004'
GO

-- Tạo view xem thông tin dịch vụ đồ uống
CREATE VIEW View_DichVu_DoUong AS
	SELECT MaDichVu, LoaiDichVu, TenSanPham, DonGia
	FROM DichVu
	Where LoaiDichVu = N'Đồ uống'
GO

-- Tạo view xem thông tin dịch vụ Đồ ăn nhanh
CREATE VIEW View_DichVu_DoAnNhanh AS
	SELECT MaDichVu, LoaiDichVu, TenSanPham, DonGia
	FROM DichVu
	Where LoaiDichVu = N'Đồ ăn nhanh'
GO

-- Tạo view xem thông tin dịch vụ Cơm
CREATE VIEW View_DichVu_Com AS
	SELECT MaDichVu, LoaiDichVu, TenSanPham, DonGia
	FROM DichVu
	Where LoaiDichVu = N'Cơm'
GO

-- Tạo view xem thông tin dịch vụ thẻ game và thẻ điện thoại
CREATE VIEW View_DichVu_The AS
	SELECT MaDichVu, LoaiDichVu, TenSanPham, DonGia
	FROM DichVu
	Where LoaiDichVu = N'Thẻ game' OR LoaiDichVu = N'Thẻ điện thoại'
GO

-- Tạo view xem thông tin tài khoản của nhân viên
CREATE VIEW View_TaiKhoan_NhanVien AS
	SELECT MaTaiKhoan, MaNhanVien, TenDangNhap, MatKhau
	FROM TaiKhoan_NhanVien
GO

-- Tạo view xem thông tin tài khoản của khách hàng
CREATE VIEW View_TaiKhoan_KhachHang AS
	SELECT MaTaiKhoan, MaKhachHang, TenDangNhap, MatKhau, SoTienDaNap, TrangThaiTaiKhoan
	FROM TaiKhoan_KhachHang
GO

-- Tạo view xem thông tin hóa đơn dịch vụ
CREATE VIEW View_DonHangDichVu AS
	SELECT MaHoaDonDV, MaTaiKhoan, MaDichVu, SoLuong, ThoiGianDatHang, TongThanhTien
	FROM HoaDon_DichVu
GO

-- Tạo view xem thông tin hóa đơn máy tính
CREATE VIEW View_HoaDonMayTinh AS
	SELECT MaHoaDonMT, MaTaiKhoan, MaMayTinh, ThoiGianMoMay, ThoiGianThanhToan, ThoiGianSuDung, TongThanhTien
	FROM HoaDon_MayTinh
GO

-- Tạo view thống kê hóa đơn dịch vụ
CREATE VIEW ThongKeDoanhThu_DichVu AS
SELECT
	DAY(ThoiGianDatHang) AS Ngay,
    MONTH(ThoiGianDatHang) AS Thang,
    YEAR(ThoiGianDatHang) AS Nam,
    SUM(TongThanhTien) AS DoanhThu
FROM HoaDon_DichVu
GROUP BY DAY(ThoiGianDatHang), MONTH(ThoiGianDatHang), YEAR(ThoiGianDatHang)
GO

-- Tao view thống kê hóa đơn dịch vụ theo tuần trong năm
CREATE VIEW ThongKeDoanhThu_DichVu_TheoTuan AS
SELECT
    DATEPART(ISO_WEEK, ThoiGianDatHang) AS Tuan,
    YEAR(ThoiGianDatHang) AS Nam,
    SUM(TongThanhTien) AS DoanhThu
FROM HoaDon_DichVu
GROUP BY DATEPART(ISO_WEEK, ThoiGianDatHang), YEAR(ThoiGianDatHang)
GO

-- Tạo view thống kê hóa đơn máy tính
CREATE VIEW ThongKeDoanhThu_MayTinh AS
SELECT
	DAY(ThoiGianMoMay) AS Ngay,
    MONTH(ThoiGianMoMay) AS Thang,
    YEAR(ThoiGianMoMay) AS Nam,
    SUM(TongThanhTien) AS DoanhThu
FROM HoaDon_MayTinh
GROUP BY DAY(ThoiGianMoMay), MONTH(ThoiGianMoMay), YEAR(ThoiGianMoMay)
GO

-- Tao view thống kê hóa đơn dịch vụ theo tuần trong năm
CREATE VIEW ThongKeDoanhThu_MayTinh_TheoTuan AS
SELECT
    DATEPART(ISO_WEEK, ThoiGianMoMay) AS Tuan,
    YEAR(ThoiGianMoMay) AS Nam,
    SUM(TongThanhTien) AS DoanhThu
FROM HoaDon_MayTinh
GROUP BY DATEPART(ISO_WEEK, ThoiGianMoMay), YEAR(ThoiGianMoMay)
GO

-- Tạo trigger tự động tính tổng thành tiền của hóa đơn dịch vụ
CREATE TRIGGER Trg_TinhTongThanhTien_HDDV
ON HoaDon_DichVu AFTER INSERT AS
BEGIN
    UPDATE HD
    SET TongThanhTien = DV.DonGia * HD.SoLuong
    FROM HoaDon_DichVu HD
    JOIN DICHVU DV ON HD.MaDichVu = DV.MaDichVu
	
	DECLARE @MaTaiKhoan NVARCHAR(10)
    DECLARE @TongThanhTien INT
    DECLARE @SoTienDaNap INT

	Select @TongThanhTien = TongThanhTien,
		   @MaTaiKhoan = MaTaiKhoan
	From HoaDon_DichVu

	Select @SoTienDaNap = SoTienDaNap
	From TaiKhoan_KhachHang

	UPDATE TaiKhoan_KhachHang
	SET SoTienDaNap = SoTienDaNap - @TongThanhTien
	Where MaTaiKhoan = @MaTaiKhoan
END
GO

-- Tạo trigger tự động thêm vào hóa đơn máy tính
CREATE TRIGGER Trg_TuDongThemHoaDonMayTinh ON MayTinh
AFTER UPDATE AS
BEGIN
    SET NOCOUNT ON

    DECLARE @MaMayTinh NVARCHAR(10);
    DECLARE @TrangThaiMayTinh INT;
    DECLARE @ThoiGianMo DATETIME;
    DECLARE @MaTaiKhoan NVARCHAR(10);
    DECLARE @ThoiGianThanhToan DATETIME;
    DECLARE @ThoiGianSuDung INT;
    DECLARE @TongThanhTien INT;

    SELECT @MaMayTinh = MaMayTinh,
           @TrangThaiMayTinh = TrangThaiMayTinh,
           @ThoiGianMo = ThoiGianMo,
           @MaTaiKhoan = MaTaiKhoan
    FROM inserted

	DECLARE @OldCode VARCHAR(10) = (SELECT MAX(MaHoaDonMT) FROM HoaDon_MayTinh)
	DECLARE @NewCode VARCHAR(10)
	DECLARE @Suffix INT

	IF @OldCode IS NOT NULL
		SET @Suffix = CAST(RIGHT(@OldCode, 3) AS INT) + 1
	ELSE
		SET @Suffix = 1

	SET @NewCode = 'HD' + RIGHT('00' + CAST(@Suffix AS VARCHAR(3)), 3)

    IF @TrangThaiMayTinh = 1 AND @ThoiGianMo IS NOT NULL AND @MaTaiKhoan IS NOT NULL
    BEGIN
        INSERT INTO HoaDon_MayTinh (MaHoaDonMT, MaTaiKhoan, MaMayTinh, ThoiGianMoMay, ThoiGianThanhToan)
        VALUES (@NewCode, @MaTaiKhoan, @MaMayTinh, @ThoiGianMo, NULL)

		UPDATE TaiKhoan_KhachHang
		SET TrangThaiTaiKhoan = 1
		Where MaTaiKhoan = @MaTaiKhoan
    END
    IF @TrangThaiMayTinh = 0 AND @ThoiGianMo IS NULL AND @MaTaiKhoan IS NULL
    BEGIN
        UPDATE HoaDon_MayTinh
        SET ThoiGianThanhToan = GETDATE()
		Where MaHoaDonMT = @OldCode

		UPDATE HoaDon_MayTinh
		SET ThoiGianSuDung = DATEDIFF(HOUR, ThoiGianMoMay, ThoiGianThanhToan),
			TongThanhTien = (DATEDIFF(HOUR, ThoiGianMoMay, ThoiGianThanhToan)) * (
			SELECT DISTINCT DonGiaMoiMay FROM MayTinh JOIN PhongMay ON MayTinh.MaPhong = PhongMay.MaPhong Where MayTinh.MaMayTinh = @MaMayTinh)
		Where MaHoaDonMT = @OldCode

		Select @TongThanhTien = TongThanhTien,
			   @MaTaiKhoan = MaTaiKhoan
		From HoaDon_MayTinh

		UPDATE TaiKhoan_KhachHang
		SET SoTienDaNap = SoTienDaNap - @TongThanhTien,
			TrangThaiTaiKhoan = 0
		Where MaTaiKhoan = @MaTaiKhoan
    END
END
GO

-- Tạo trigger tự động tạo tài khoản khách hàng khi thêm khách hàng mới
CREATE TRIGGER Trg_TuDongTaoTaiKhoanKhachHang ON KhachHang
AFTER INSERT AS
BEGIN
    SET NOCOUNT ON

    INSERT INTO TaiKhoan_KhachHang (MaTaiKhoan, MaKhachHang, TenDangNhap, MatKhau, SoTienDaNap, TrangThaiTaiKhoan)
    SELECT inserted.MaKhachHang, inserted.MaKhachHang, inserted.MaKhachHang, KhachHang.MaKhachHang, 100000, 0
    FROM inserted
    INNER JOIN KhachHang ON inserted.MaKhachHang = KhachHang.MaKhachHang;
END
GO