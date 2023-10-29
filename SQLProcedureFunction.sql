USE QuanLyQuanNET
GO

--------------------------------------------------------------PROCEDURE--------------------------------------------------------------
-- FORM MÁY TÍNH

CREATE PROCEDURE HienThiMayTinh
	@MaMayTinh NVARCHAR (10)
AS
	SELECT * FROM MayTinh WHERE MayTinh.MaMayTinh=@MaMayTinh
GO

-- PROCEDURE ThemMayTinh: thêm thông tin máy tính vào hệ thống
-- drop procedure ThemMayTinh
CREATE PROCEDURE ThemMayTinh
    @MaPhong NVARCHAR(10),
    @TenMayTinh NVARCHAR(50),
    @TrangThaiMayTinh INT
AS
BEGIN
    SET NOCOUNT ON

	DECLARE @OldCode VARCHAR(10) = (SELECT MAX(MaMayTinh) FROM MayTinh)
	DECLARE @NewCode VARCHAR(10)
	DECLARE @Suffix INT
	DECLARE @TongLuong DECIMAL(18,2)

	SET @Suffix = CAST(RIGHT(@OldCode, 3) AS INT) + 1
	SET @NewCode = 'MT' + RIGHT('00' + CAST(@Suffix AS VARCHAR(3)), 3)

    INSERT INTO MayTinh (MaMayTinh, MaPhong, TenMayTinh, TrangThaiMayTinh)
    VALUES (@NewCode, @MaPhong, @TenMayTinh, @TrangThaiMayTinh)
END
GO

-- PROCEDURE SuaMayTinh: sửa thông tin máy tính vào hệ thống
-- drop procedure SuaMayTinh
CREATE PROCEDURE SuaMayTinh
    @MaMayTinh NVARCHAR(10),
	@MaPhong NVARCHAR(10),
    @TenMayTinh NVARCHAR(50),
    @TrangThaiMayTinh INT
AS
BEGIN
    SET NOCOUNT ON

    UPDATE MayTinh
    SET MaPhong = @MaPhong,
		TenMayTinh = @TenMayTinh,
        TrangThaiMayTinh = @TrangThaiMayTinh
    WHERE MaMayTinh = @MaMayTinh
END
GO

-- PROCEDURE MoMayTinh: thực hiện mở máy tính và update các thông tin của máy tính
-- drop procedure MoMayTinh
CREATE PROCEDURE MoMayTinh
    @MaMayTinh NVARCHAR(10),
    @MaTaiKhoan NVARCHAR(10)
AS
BEGIN
    SET NOCOUNT ON;

    IF (SELECT TrangThaiMayTinh FROM MayTinh WHERE MaMayTinh = @MaMayTinh) = 0
    BEGIN
        IF EXISTS (SELECT 1 FROM TaiKhoan_KhachHang WHERE MaTaiKhoan = @MaTaiKhoan AND TrangThaiTaiKhoan = 0 AND SoTienDaNap > 0)
        BEGIN
            UPDATE MayTinh
            SET TrangThaiMayTinh = 1,
                ThoiGianMo = GETDATE(),
                MaTaiKhoan = @MaTaiKhoan
            WHERE MaMayTinh = @MaMayTinh;
        END
        ELSE
        BEGIN
            RAISERROR ('Tài khoản đã hoặc đang sử dụng máy khác hoặc tiền trong tài khoản không đủ', 16, 1);
        END
    END
    ELSE
    BEGIN
        RAISERROR ('Máy tính đang được mở hoặc sử dụng bởi một tài khoản khác', 16, 1);
    END
END
GO

-- PROCEDURE TatMayTinh: thực hiện tắt máy tính và update các thông tin của máy tính
-- drop procedure TatMayTinh
CREATE PROCEDURE TatMayTinh
    @MaMayTinh NVARCHAR(10)
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @TrangThaiMayTinh INT;
    
    -- Lấy trạng thái máy tính
    SELECT @TrangThaiMayTinh = TrangThaiMayTinh
    FROM MayTinh
    WHERE MaMayTinh = @MaMayTinh;

    -- Kiểm tra trạng thái máy tính
    IF @TrangThaiMayTinh = 0
    BEGIN
        -- Máy tính đã tắt, thông báo lỗi
        RAISERROR ('Máy tính đã được tắt', 16, 1);
    END
    ELSE
    BEGIN
        -- Cập nhật trạng thái và thông tin tài khoản
        UPDATE MayTinh
        SET TrangThaiMayTinh = 0,
            ThoiGianMo = NULL,
            MaTaiKhoan = NULL
        WHERE MaMayTinh = @MaMayTinh;

        UPDATE TaiKhoan_KhachHang
        SET TrangThaiTaiKhoan = 0
        WHERE MaTaiKhoan = (SELECT MaTaiKhoan FROM MayTinh WHERE MaMayTinh = @MaMayTinh);
    END
END
GO

-- FORM THÔNG TIN

-- PROCEDURE hiển thị thông tin nhân viên
CREATE PROCEDURE HienThiThongTinNhanVien
	@MaNhanVien NVARCHAR(10)
AS
BEGIN
	SELECT * FROM NhanVien INNER JOIN TaiKhoan_NhanVien ON NhanVien.MaNhanVien = TaiKhoan_NhanVien.MaTaiKhoan 
	WHERE NhanVien.MaNhanVien = @MaNhanVien
END
GO

-- PROCEDURE hiển thị thông tin khách hàng
CREATE PROCEDURE HienThiThongTinKhachHang
	@MaKhachHang NVARCHAR(10)
AS
BEGIN
	SELECT * FROM KhachHang INNER JOIN TaiKhoan_KhachHang ON KhachHang.MaKhachHang = TaiKhoan_KhachHang.MaTaiKhoan 
	WHERE KhachHang.MaKhachHang = @MaKhachHang
END
GO

-- PROCEDURE thay đổi tài khoản khách hàng
-- drop procedure DoiTaiKhoanMatKhauKhachHang
CREATE PROCEDURE DoiTaiKhoanMatKhauKhachHang
    @MaTaiKhoan NVARCHAR(10),
    @TenDangNhapMoi NVARCHAR(50),
    @MatKhauMoi NVARCHAR(50)
AS
BEGIN
    SET NOCOUNT ON;

    -- Kiểm tra xem tài khoản tồn tại trong bảng
    IF EXISTS (SELECT 1 FROM TaiKhoan_KhachHang WHERE MaTaiKhoan = @MaTaiKhoan)
    BEGIN
        -- Cập nhật tên đăng nhập và mật khẩu mới
        UPDATE TaiKhoan_KhachHang
        SET TenDangNhap = @TenDangNhapMoi,
            MatKhau = @MatKhauMoi
        WHERE MaTaiKhoan = @MaTaiKhoan;

        PRINT N'Đã đổi tài khoản và mật khẩu thành công.'
    END
    ELSE
    BEGIN
        PRINT N'Không tìm thấy tài khoản khách hàng tương ứng.'
    END
END
GO

-- FORM NHÂN VIÊN

CREATE PROCEDURE HienThiNhanVien
	@MaNhanVien NVARCHAR (10)
AS
	SELECT * FROM NhanVien WHERE NhanVien.MaNhanVien=@MaNhanVien
GO

-- PROCEDURE AddEmployee: Thêm thông tin nhân viên mới vào hệ thống
-- drop procedure ThemNhanVien
CREATE PROCEDURE ThemNhanVien
	@TenNhanVien NVARCHAR(100),
	@SoDienThoai NVARCHAR(10),
	@DiaChi NVARCHAR(100),
	@MaChucVu NVARCHAR(10)
AS
	BEGIN
		DECLARE @OldCode VARCHAR(10) = (SELECT MAX(MaNhanVien) FROM NhanVien)
		DECLARE @NewCode VARCHAR(10)
		DECLARE @Suffix INT
		DECLARE @TongLuong DECIMAL(18,2)

		SET @Suffix = CAST(RIGHT(@OldCode, 3) AS INT) + 1
		SET @NewCode = 'NV' + RIGHT('00' + CAST(@Suffix AS VARCHAR(3)), 3)
		
		--Thêm vào Nhân Viên
		INSERT INTO NhanVien(MaNhanVien, TenNhanVien, SoDienThoai, DiaChi, MaChucVu) 
		VALUES (@NewCode, @TenNhanVien, @SoDienThoai, @DiaChi, @MaChucVu)
	END
GO

-- PROCEDURE UpdateEmployee: Cập nhật thông tin nhân viên trong hệ thống
-- drop procedure CapNhatNhanVien
CREATE PROCEDURE CapNhatNhanVien
	@MaNhanVien NVARCHAR(10),
    @TenNhanVien NVARCHAR(100),
	@SoDienThoai NVARCHAR(10),
	@DiaChi NVARCHAR(100),
	@MaChucVu NVARCHAR(10)
AS
BEGIN
	-- Cập nhật Nhân viên
    UPDATE NhanVien
    SET TenNhanVien = @TenNhanVien, SoDienThoai = @SoDienThoai, DiaChi = @DiaChi, MaChucVu = @MaChucVu
    WHERE MaNhanVien = @MaNhanVien
END
GO

CREATE PROCEDURE HienThiTaiKhoanNV
	@MaTaiKhoan NVARCHAR (10)
AS
	SELECT * FROM TaiKhoan_NhanVien WHERE TaiKhoan_NhanVien.MaTaiKhoan=@MaTaiKhoan
GO

-- PROCEDURE Thêm thông tin tài khoản nhân viên mới vào hệ thống 
create procedure ThemTaiKhoanNhanVien
	@MaTaiKhoan		varchar(10),
	@MaNhanVien		varchar(10),
	@TenDangNhap	nvarchar(10),
	@MatKhau		nvarchar(30)
as
	begin
		insert into TaiKhoan_NhanVien values (@MaTaiKhoan, @MaNhanVien, @TenDangNhap, @MatKhau)
	end
go

-- PROCEDURE Cập nhật thông tin tài khoản nhân viên trong hệ thống
CREATE PROCEDURE SuaTaiKhoanNhanVien
	@MaTaiKhoan		varchar(10),
	@MaNhanVien		varchar(10),
	@TenDangNhap	nvarchar(10),
	@MatKhau		nvarchar(30)
AS
BEGIN
-- Cập nhật thông tin tài khoản Nhân viên
    UPDATE TaiKhoan_NhanVien
    SET MaNhanVien = @MaNhanVien, TenDangNhap = @TenDangNhap, MatKhau = @MatKhau
    WHERE MaTaiKhoan = @MaTaiKhoan

	DECLARE @command NVARCHAR(MAX) = '';
	SET @command = '';
	SELECT @command = @command + 'ALTER LOGIN [' + name + '] WITH PASSWORD = '''+@MatKhau+''';'
	FROM sys.syslogins
	WHERE name LIKE @MaTaiKhoan;
	EXEC (@command);
END
GO

-- FORM HÓA ĐƠN 

CREATE PROCEDURE HienThiHoaDonMayTinh
	@MaHoaDonMT NVARCHAR (10)
AS
	SELECT * FROM HoaDon_MayTinh WHERE HoaDon_MayTinh.MaHoaDonMT=@MaHoaDonMT
GO

-- PROCEDURE AddOrder: Thêm thông tin hóa đơn máy tính mới vào hệ thống
CREATE PROCEDURE ThemHoaDonMayTinh
	@MaTaiKhoan NVARCHAR(10),
	@MaMayTinh NVARCHAR(10),
	@ThoiGianMoMay DATETIME,
	@ThoiGianSuDung INT,
	@TongThanhTien INT
AS
BEGIN 
	DECLARE @OldCode VARCHAR(10) = (SELECT MAX(MaHoaDonMT) FROM HoaDon_MayTinh)
	DECLARE @NewCode VARCHAR(10)
	DECLARE @Suffix INT
	SET @Suffix = CAST(RIGHT(@OldCode, 3) AS INT) + 1
	SET @NewCode = 'HD' + RIGHT('00' + CAST(@Suffix AS VARCHAR(3)), 3)

	INSERT INTO HoaDon_MayTinh (MaHoaDonMT, MaTaiKhoan, MaMayTinh, ThoiGianMoMay, ThoiGianThanhToan, ThoiGianSuDung, TongThanhTien) 
	VALUES 
	(@NewCode,@MaTaiKhoan,@MaMayTinh, @ThoiGianMoMay, GETDATE(), @ThoiGianSuDung, @TongThanhTien)
END
GO

-- PROCEDURE Cập nhật thông tin của Hóa đơn máy tính trong hệ thống
CREATE PROCEDURE SuaHoaDonMayTinh
	@MaHoaDonMT NVARCHAR(10),
	@MaTaiKhoan NVARCHAR(10),
	@MaMayTinh NVARCHAR(10),
	@ThoiGianMoMay DATETIME,
	@ThoiGianThanhToan DATETIME,
	@ThoiGianSuDung INT,
	@TongThanhTien INT
AS
BEGIN 
	UPDATE HoaDon_MayTinh SET MaHoaDonMT = @MaHoaDonMT, MaTaiKhoan = @MaTaiKhoan, MaMayTinh = @MaMayTinh, TongThanhTien = @TongThanhTien
END
GO

CREATE PROCEDURE HienThiHoaDonDichVu
	@MaHoaDonDV NVARCHAR (10)
AS
	SELECT * FROM HoaDon_DichVu WHERE HoaDon_DichVu.MaHoaDonDV=@MaHoaDonDV
GO

-- PROCEDURE AddOrder: Thêm thông tin hóa đơn dịch vu mới vào hệ thống
-- drop procedure ThemHoaDonDichVu
CREATE PROCEDURE ThemHoaDonDichVu
	@MaTaiKhoan NVARCHAR(10),
	@MaDichVu NVARCHAR(10),
	@SoLuong INT
AS
BEGIN 
	DECLARE @OldCode VARCHAR(10) = (SELECT MAX(MaHoaDonDV) FROM HoaDon_DichVu)
	DECLARE @NewCode VARCHAR(10)
	DECLARE @Suffix INT

	IF @OldCode IS NOT NULL
	BEGIN
		SET @Suffix = CAST(RIGHT(@OldCode, 3) AS INT) + 1
	END
	ELSE
	BEGIN
		SET @Suffix = 1
	END

	SET @NewCode = 'HD' + RIGHT('00' + CAST(@Suffix AS VARCHAR(3)), 3)


	INSERT INTO HoaDon_DichVu (MaHoaDonDV, MaTaiKhoan, MaDichVu, SoLuong, ThoiGianDatHang) 
	VALUES 
	(@NewCode,@MaTaiKhoan,@MaDichVu, @SoLuong, GETDATE())
END
GO

-- PROCEDURE Cập nhật thông tin của Hóa đơn dich vụ trong hệ thống
CREATE PROCEDURE SuaHoaDonDichVu 
	@MaHoaDonDV NVARCHAR(10),
	@MaTaiKhoan NVARCHAR(10),
	@MaDichVu NVARCHAR(10),
	@SoLuong INT,
	@ThoiGianDatHang DATETIME,
	@TongThanhTien INT
AS
BEGIN 
	UPDATE HoaDon_DichVu SET MaHoaDonDV = @MaHoaDonDV, MaTaiKhoan = @MaTaiKhoan, MaDichVu = @MaDichVu, SoLuong = @SoLuong, TongThanhTien = @TongThanhTien
END
GO

-- FORM DỊCH VỤ

CREATE PROCEDURE HienThiDichVu
	@MaDichVu NVARCHAR (10)
AS
	SELECT * FROM DichVu WHERE DichVu.MaDichVu=@MaDichVu
GO

-- PROCEDURE ThemDichVu
-- drop procedure ThemDichVu
CREATE PROCEDURE ThemDichVu
    @LoaiDichVu NVARCHAR(50),
    @TenSanPham NVARCHAR(50),
    @DonGia INT
AS
BEGIN
    SET NOCOUNT ON;

	DECLARE @OldCode VARCHAR(10) = (SELECT MAX(MaDichVu) FROM DichVu)
	DECLARE @NewCode VARCHAR(10)
	DECLARE @Suffix INT
	DECLARE @TongLuong DECIMAL(18,2)

	SET @Suffix = CAST(RIGHT(@OldCode, 3) AS INT) + 1
	SET @NewCode = 'DV' + RIGHT('00' + CAST(@Suffix AS VARCHAR(3)), 3)

    -- Thêm dịch vụ mới
    INSERT INTO DichVu (MaDichVu, LoaiDichVu, TenSanPham, DonGia)
    VALUES (@NewCode, @LoaiDichVu, @TenSanPham, @DonGia)
END
GO

-- PROCEDURE SuaDichVu
-- drop procedure SuaDichVu
CREATE PROCEDURE SuaDichVu
    @MaDichVu NVARCHAR(10),
    @LoaiDichVu NVARCHAR(50),
    @TenSanPham NVARCHAR(50),
    @DonGia INT
AS
BEGIN
    SET NOCOUNT ON;

    -- Cập nhật thông tin của dịch vụ
    UPDATE DichVu
    SET LoaiDichVu = @LoaiDichVu,
        TenSanPham = @TenSanPham,
        DonGia = @DonGia
    WHERE MaDichVu = @MaDichVu;
END
GO

-- PROCEDURE GoiDichVu
-- drop procedure GoiDichVu
CREATE PROCEDURE GoiDichVu
    @MaTaiKhoan NVARCHAR(10),
    @MaDichVu NVARCHAR(10),
    @SoLuong INT
AS
BEGIN
    DECLARE @DonGia INT
    SET @DonGia = (SELECT DonGia FROM DichVu WHERE MaDichVu = @MaDichVu)
    DECLARE @SoTienDaNap INT
    SET @SoTienDaNap = (SELECT SoTienDaNap FROM TaiKhoan_KhachHang WHERE MaTaiKhoan = @MaTaiKhoan)

    DECLARE @TongTien INT
    SET @TongTien = @DonGia * @SoLuong

    IF @TongTien > @SoTienDaNap
    BEGIN
        -- Số tiền không đủ, thông báo lỗi
        RAISERROR ('Số tiền không đủ để gọi dịch vụ này.', 16, 1)
    END
	ELSE
	BEGIN
		-- Số tiền đủ, thực hiện thêm hóa đơn dịch vụ
		EXEC ThemHoaDonDichVu @MaTaiKhoan, @MaDichVu, @SoLuong
	END
END
GO

-- FORM KHÁCH HÀNG 

CREATE PROCEDURE HienThiKhachHang
	@MaKhachHang NVARCHAR (10)
AS
	SELECT * FROM KhachHang WHERE KhachHang.MaKhachHang=@MaKhachHang
GO

-- PROCEDURE AddEmployee: Thêm thông tin khách hàng mới vào hệ thống
-- drop procedure AddCustomer
CREATE PROCEDURE ThemKhachHang
	@TenKhachHang NVARCHAR(100),
	@SoDienThoai NVARCHAR(10),
	@DiaChi NVARCHAR(100)
AS
	BEGIN
		DECLARE @OldCode VARCHAR(10) = (SELECT MAX(MaKhachHang) FROM KhachHang)
		DECLARE @NewCode VARCHAR(10)
		DECLARE @Suffix INT
		DECLARE @TongLuong DECIMAL(18,2)

		SET @Suffix = CAST(RIGHT(@OldCode, 3) AS INT) + 1
		SET @NewCode = 'KH' + RIGHT('00' + CAST(@Suffix AS VARCHAR(3)), 3)
		
		--Thêm vào Khách hàng 
		INSERT INTO KhachHang(MaKhachHang, TenKhachHang, SoDienThoai, DiaChi) 
		VALUES (@NewCode, @TenKhachHang, @SoDienThoai, @DiaChi)
	END
GO

-- PROCEDURE UpdateEmployee: Cập nhật thông tin khách hàng trong hệ thống
-- drop procedure UpdateCustomer
CREATE PROCEDURE SuaKhachHang
	@MaKhachHang NVARCHAR(10),
	@TenKhachHang NVARCHAR(100),
	@SoDienThoai NVARCHAR(10),
	@DiaChi NVARCHAR(100)
AS
BEGIN
-- Cập nhật Nhân viên
    UPDATE KhachHang
    SET TenKhachHang = @TenKhachHang, SoDienThoai = @SoDienThoai, DiaChi = @DiaChi
    WHERE MaKhachHang = @MaKhachHang
END
GO

CREATE PROCEDURE HienThiTaiKhoanKH
	@MaTaiKhoan NVARCHAR (10)
AS
	SELECT * FROM TaiKhoan_KhachHang WHERE TaiKhoan_KhachHang.MaTaiKhoan=@MaTaiKhoan
GO

-- PROCEDURE Thêm thông tin tài khoản khách hàng vaof trong hệ thống 
create procedure ThemTaiKhoanKhachHang
	@MaTaiKhoan			varchar(10),
	@MaKhachHang		varchar(10),
	@TenDangNhap		nvarchar(10),
	@SoTienDaNap		INT,
	@TrangThaiTaiKhoan  INT,
	@MatKhau			nvarchar(30)
as
	begin
		insert into TaiKhoan_KhachHang values (@MaTaiKhoan, @MaKhachHang, @TenDangNhap, @SoTienDaNap, @TrangThaiTaiKhoan, @MatKhau)
	end
go

-- PROCEDURE Cập nhật thông tin tài khoản khách hàng trong hệ thống
CREATE PROCEDURE SuaTaiKhoanKhachHang
	@MaTaiKhoan			varchar(10),
	@MaKhachHang		varchar(10),
	@TenDangNhap		nvarchar(10),
	@SoTienDaNap		INT,
	@TrangThaiTaiKhoan  INT,
	@MatKhau			nvarchar(30)
AS
BEGIN
-- Cập nhật thông tin tài khoản Khách hàng
    UPDATE TaiKhoan_KhachHang
    SET MaKhachHang = @MaKhachHang, TenDangNhap = @TenDangNhap, SoTienDaNap = @SoTienDaNap, TrangThaiTaiKhoan = @TrangThaiTaiKhoan, MatKhau = @MatKhau
    WHERE MaTaiKhoan = @MaTaiKhoan
END
GO

-- FORM MỤC KHÁC

CREATE PROCEDURE HienThiChucVu
	@MaChucVu NVARCHAR(10)
AS
	SELECT * FROM ChucVu WHERE ChucVu.MaChucVu=@MaChucVu
GO

-- PROCEDURE AddEmployee: Thêm thông tin chức vụ mới vào hệ thống
-- drop procedure AddPosition
CREATE PROCEDURE ThemChucVu
	@TenChucVu NVARCHAR(50),
	@MoTaCongViec NVARCHAR(200),
	@Luong DECIMAL(18,2)
AS
	BEGIN
		DECLARE @OldCode VARCHAR(10) = (SELECT MAX(MaChucVu) FROM ChucVu)
		DECLARE @NewCode VARCHAR(10)
		DECLARE @Suffix INT
		DECLARE @TongLuong DECIMAL(18,2)

		SET @Suffix = CAST(RIGHT(@OldCode, 3) AS INT) + 1
		SET @NewCode = 'CV' + RIGHT('00' + CAST(@Suffix AS VARCHAR(3)), 3)
		
		--Thêm vào Chức vụ 
		INSERT INTO ChucVu(MaChucVu, TenChucVu, MoTaCongViec, Luong) 
		VALUES (@NewCode, @TenChucVu, @MoTaCongViec, @Luong)
	END
GO

--- PROCEDURE Cập nhật thông tin chức vụ trong hệ thống
CREATE PROCEDURE SuaChucVu
	@MaChucVu NVARCHAR(10),
	@TenChucVu NVARCHAR(50),
	@MoTaCongViec NVARCHAR(200),
	@Luong DECIMAL(18,2)
AS
BEGIN
	-- Cập nhật thông tin chức vụ
    UPDATE ChucVu
    SET TenChucVu = @TenChucVu, MoTaCongViec = @MoTaCongViec, Luong = @Luong
    WHERE MaChucVu = @MaChucVu
END
GO

CREATE PROCEDURE HienThiPhongMay
	@MaPhong NVARCHAR(10)
AS
	SELECT * FROM PhongMay WHERE PhongMay.MaPhong=@MaPhong
GO

-- PROCEDURE AddEmployee: Thêm thông tin phòng máy mới vào hệ thống
-- drop procedure AddPCRoom
CREATE PROCEDURE ThemPhongMay
	@TenPhong NVARCHAR(50),
	@SoLuongMay INT,
	@DonGiaMoiMay INT
AS
	BEGIN
		DECLARE @OldCode VARCHAR(10) = (SELECT MAX(MaPhong) FROM PhongMay)
		DECLARE @NewCode VARCHAR(10)
		DECLARE @Suffix INT
		DECLARE @TongLuong DECIMAL(18,2)

		SET @Suffix = CAST(RIGHT(@OldCode, 3) AS INT) + 1
		SET @NewCode = 'P' + RIGHT('00' + CAST(@Suffix AS VARCHAR(3)), 3)
		
		--Thêm vào Phòng máy
		INSERT INTO PhongMay(MaPhong, TenPhong, SoLuongMay, DonGiaMoiMay) 
		VALUES (@NewCode, @TenPhong, @SoLuongMay, @DonGiaMoiMay)
	END
GO

--- PROCEDURE Cập nhật thông tin phòng máy trong hệ thống
CREATE PROCEDURE SuaPhongMay 
	@MaPhong NVARCHAR(10),
	@TenPhong NVARCHAR(50),
	@SoLuongMay INT,
	@DonGiaMoiMay INT
AS
BEGIN
-- Cập nhật thông tin tài khoản Khách hàng
    UPDATE PhongMay
    SET TenPhong = @TenPhong, SoLuongMay = SoLuongMay, DonGiaMoiMay = @DonGiaMoiMay
    WHERE MaPhong = @MaPhong
END
GO

--------------------------------------------------------------FUNCTION--------------------------------------------------------------
--FORM HÓA ĐƠN MÁY TÍNH

-- FUNCTION Tìm kiếm thông tin hóa đơn máy tính trong hệ thống dựa vào mã tài khoản hoặc mã máy tính hoặc thời gian mở máy hoặc thời gian thanh toán 
CREATE FUNCTION TimKiemHoaDonMayTinh
    (@MaTaiKhoan NVARCHAR(10),
	 @MaMayTinh NVARCHAR(10),
	 @ThoiGianMoMay DATETIME,
	 @ThoiGianThanhToan DATETIME)
RETURNS TABLE
AS
RETURN
    SELECT * FROM HoaDon_MayTinh
    WHERE MaTaiKhoan LIKE @MaTaiKhoan or MaMayTinh LIKE @MaMayTinh or ThoiGianMoMay LIKE @ThoiGianMoMay or ThoiGianThanhToan LIKE @ThoiGianThanhToan
GO

-- FORM HÓA ĐƠN DỊCH VỤ 

-- FUNCTION Tìm kiếm thông tin hóa đơn dịch vụ trong hệ thống dựa vào mã hóa đơn hoặc mã tìa khoản hoặc thời gian mở máy hoặc thời gian thanh toán 
CREATE FUNCTION TimKiemHoaDonDichVu
    (@MaHoaDonDV NVARCHAR(10),
	 @MaTaiKhoan NVARCHAR(10),
	 @ThoiGianMoMay DATETIME,
	 @ThoiGianThanhToan DATETIME)
RETURNS TABLE
AS
RETURN
    SELECT * FROM HoaDon_MayTinh
    WHERE MaTaiKhoan LIKE @MaTaiKhoan or MaTaiKhoan LIKE @MaTaiKhoan or ThoiGianMoMay LIKE @ThoiGianMoMay or ThoiGianThanhToan LIKE @ThoiGianThanhToan
GO

--FORM KHÁCH HÀNG

-- FUNCTION Tìm kiếm thông tin khách hàng trong hệ thống dựa trên mã khách hàng hoặc tên khách hàng
CREATE FUNCTION TimKiemKhachHang
    (@MaKhachHang nvarchar(10),
	@TenKhachHang nvarchar(100))
RETURNS TABLE
AS
RETURN
    SELECT * FROM KhachHang
    WHERE TenKhachHang LIKE @TenKhachHang or MaKhachHang LIKE @MaKhachHang 
GO

-- FORM NHÂN VIÊN  

-- FUNCTION Tìm kiếm thông tin nhân viên trong hệ thống dựa trên tên nhân viên hoặc mã nhân viên hoặc mã chức vụ 
CREATE FUNCTION TimKiemNhanVien
    (@TenNhanVien nvarchar(100),
	 @MaNhanVien nvarchar(10),
 	 @MaChucVu NVARCHAR(10))
RETURNS TABLE
AS
RETURN
    SELECT * FROM NhanVien
	WHERE TenNhanVien LIKE @TenNhanVien or MaNhanVien LIKE @MaNhanVien or MaChucVu LIKE @MaChucVu
GO