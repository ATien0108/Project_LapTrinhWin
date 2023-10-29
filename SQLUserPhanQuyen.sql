USE QuanLyQuanNET
GO

--------------------------------------------------------- Tạo Phân quyền ---------------------------------------------------------
------------------- ROLE Thu Ngân
CREATE ROLE ThuNgan
GRANT SELECT, INSERT, UPDATE, REFERENCES ON MayTinh TO ThuNgan
GRANT SELECT, INSERT, UPDATE, REFERENCES ON DichVu TO ThuNgan
GRANT SELECT, INSERT, UPDATE, REFERENCES ON HoaDon_MayTinh TO ThuNgan
GRANT SELECT, INSERT, UPDATE, REFERENCES ON HoaDon_DichVu TO ThuNgan
GRANT SELECT, INSERT, UPDATE, REFERENCES ON KhachHang TO ThuNgan
GRANT SELECT, INSERT, UPDATE, REFERENCES ON TaiKhoan_KhachHang TO ThuNgan

REVOKE EXECUTE TO ThuNgan
REVOKE SELECT TO ThuNgan

-- Bảng Máy tính
GRANT SELECT ON View_MayTinhThuong TO ThuNgan
GRANT SELECT ON View_MayTinhVIP TO ThuNgan
GRANT SELECT ON View_MayTinhStream TO ThuNgan
GRANT SELECT ON View_MayTinhTraining TO ThuNgan

GRANT EXECUTE ON ThemMayTinh TO ThuNgan
GRANT EXECUTE ON SuaMayTinh TO ThuNgan
GRANT EXECUTE ON MoMayTinh TO ThuNgan
GRANT EXECUTE ON TatMayTinh TO ThuNgan


-- Bảng Dịch vụ
GRANT SELECT ON View_DichVu_DoUong TO ThuNgan
GRANT SELECT ON View_DichVu_DoAnNhanh TO ThuNgan
GRANT SELECT ON View_DichVu_Com TO ThuNgan
GRANT SELECT ON View_DichVu_The TO ThuNgan

GRANT EXECUTE ON GoiDichVu TO ThuNgan
GRANT EXECUTE ON SuaDichVu TO ThuNgan
GRANT EXECUTE ON ThemDichVu TO ThuNgan

-- Bảng Hóa đơn máy tính
GRANT SELECT ON View_HoaDonMayTinh TO ThuNgan
GRANT SELECT ON TimKiemHoaDonMayTinh TO ThuNgan

GRANT EXECUTE ON SuaHoaDonMayTinh TO ThuNgan
GRANT EXECUTE ON ThemHoaDonMayTinh TO ThuNgan

-- Bảng Hóa đơn dịch vụ
GRANT SELECT ON View_DonHangDichVu TO ThuNgan
GRANT SELECT ON TimKiemHoaDonDichVu TO ThuNgan

GRANT EXECUTE ON SuaHoaDonDichVu TO ThuNgan
GRANT EXECUTE ON ThemHoaDonDichVu TO ThuNgan

-- Bảng Khách hàng
GRANT SELECT ON View_KhachHang TO ThuNgan
GRANT SELECT ON TimKiemKhachHang TO ThuNgan

GRANT EXECUTE ON HienThiThongTinKhachHang TO ThuNgan
GRANT EXECUTE ON ThemKhachHang TO ThuNgan
GRANT EXECUTE ON SuaKhachHang TO ThuNgan
GRANT EXECUTE ON MoMayTinh TO ThuNgan
GRANT EXECUTE ON TatMayTinh TO ThuNgan
GRANT EXECUTE ON GoiDichVu TO ThuNgan

-- Bảng Tài khoản Khách hàng
GRANT SELECT ON View_TaiKhoan_KhachHang TO ThuNgan

GRANT EXECUTE ON HienThiThongTinKhachHang TO ThuNgan
GRANT EXECUTE ON DoiTaiKhoanMatKhauKhachHang TO ThuNgan
GRANT EXECUTE ON ThemTaiKhoanKhachHang TO ThuNgan
GRANT EXECUTE ON SuaTaiKhoanKhachHang TO ThuNgan

-- Procedure HienThiThongTinNhanVien
GRANT EXECUTE ON HienThiThongTinNhanVien TO ThuNgan
GRANT EXECUTE ON CapNhatNhanVien TO ThuNgan

------------------- ROLE Kế toán 
CREATE ROLE KeToan
GRANT SELECT, REFERENCES ON MayTinh TO ThuNgan
GRANT SELECT, INSERT, UPDATE, REFERENCES ON DichVu TO KeToan
GRANT SELECT, INSERT, UPDATE, REFERENCES ON HoaDon_MayTinh TO KeToan
GRANT SELECT, INSERT, UPDATE, REFERENCES ON HoaDon_DichVu TO KeToan
GRANT SELECT, INSERT, UPDATE, REFERENCES ON KhachHang TO KeToan
GRANT SELECT, INSERT, UPDATE, REFERENCES ON TaiKhoan_KhachHang TO KeToan

REVOKE EXECUTE TO ThuNgan
REVOKE SELECT TO ThuNgan

-- Bảng Máy tính
GRANT SELECT ON View_MayTinhThuong TO KeToan
GRANT SELECT ON View_MayTinhTraining TO KeToan

-- Bảng Dịch vụ
GRANT SELECT ON View_DichVu_DoUong TO KeToan
GRANT SELECT ON View_DichVu_DoAnNhanh TO KeToan
GRANT SELECT ON View_DichVu_Com TO KeToan
GRANT SELECT ON View_DichVu_The TO KeToan

GRANT EXECUTE ON GoiDichVu TO KeToan
GRANT EXECUTE ON SuaDichVu TO KeToan
GRANT EXECUTE ON ThemDichVu TO KeToan

-- Bảng Hóa đơn máy tính
GRANT SELECT ON View_HoaDonMayTinh TO KeToan
GRANT SELECT ON TimKiemHoaDonMayTinh TO KeToan

GRANT EXECUTE ON SuaHoaDonMayTinh TO KeToan
GRANT EXECUTE ON ThemHoaDonMayTinh TO KeToan

-- Bảng Hóa đơn dịch vụ
GRANT SELECT ON View_DonHangDichVu TO KeToan
GRANT SELECT ON TimKiemHoaDonDichVu TO KeToan

GRANT EXECUTE ON SuaHoaDonDichVu TO KeToan
GRANT EXECUTE ON ThemHoaDonDichVu TO KeToan

-- Bảng Khách hàng
GRANT SELECT ON View_KhachHang TO KeToan
GRANT SELECT ON TimKiemKhachHang TO KeToan

GRANT EXECUTE ON HienThiThongTinKhachHang TO KeToan
GRANT EXECUTE ON ThemKhachHang TO KeToan
GRANT EXECUTE ON SuaKhachHang TO KeToan
GRANT EXECUTE ON MoMayTinh TO KeToan
GRANT EXECUTE ON TatMayTinh TO KeToan
GRANT EXECUTE ON GoiDichVu TO KeToan

-- Bảng Tài khoản Khách hàng
GRANT SELECT ON View_TaiKhoan_KhachHang TO KeToan

GRANT EXECUTE ON HienThiThongTinKhachHang TO KeToan
GRANT EXECUTE ON DoiTaiKhoanMatKhauKhachHang TO KeToan
GRANT EXECUTE ON ThemTaiKhoanKhachHang TO KeToan
GRANT EXECUTE ON SuaTaiKhoanKhachHang TO KeToan

-- Procedure HienThiThongTinNhanVien
GRANT EXECUTE ON HienThiThongTinNhanVien TO KeToan
GRANT EXECUTE ON CapNhatNhanVien TO KeToan
GO

create TRIGGER TaoTaiKhoanDangNhap ON TaiKhoan_NhanVien
AFTER INSERT
AS
BEGIN
	DECLARE @sqlString nvarchar(2000)
    DECLARE @userName NVARCHAR(50)
    DECLARE @passWord NVARCHAR(50)
    DECLARE @cv NVARCHAR(10)
    
    SELECT @userName = TaiKhoan_NhanVien.TenDangNhap, @passWord = TaiKhoan_NhanVien.MatKhau, @cv = NhanVien.MaChucVu 
    FROM TaiKhoan_NhanVien 
    INNER JOIN NhanVien ON TaiKhoan_NhanVien.MaNhanVien = NhanVien.MaNhanVien
    INNER JOIN INSERTED ON TaiKhoan_NhanVien.MaNhanVien = INSERTED.MaNhanVien
	
	SET @sqlString= 'CREATE LOGIN [' + @userName +'] WITH PASSWORD='''+ @passWord
	+''', DEFAULT_DATABASE=[QuanLyQuanNET], CHECK_EXPIRATION=OFF,
	CHECK_POLICY=OFF'
	EXEC (@sqlString)
	SET @sqlString= 'CREATE USER ' + @userName +' FOR LOGIN '+ @userName
	EXEC (@sqlString)
	--ROLE Quản lý 
	if (@cv='CV001')
	begin
		SET @sqlString = N'ALTER SERVER ROLE sysadmin ADD MEMBER ' +@userName;
		exec (@sqlString)
	end
	--ROLE Thu ngân
	else if(@cv='CV002')
	begin
		SET @sqlString = N'ALTER ROLE ThuNgan ADD MEMBER ' + @userName;
		exec (@sqlString)
	end
	--ROLE Kế toán
	else if(@cv='CV003')
	begin
		SET @sqlString = N'ALTER ROLE KeToan ADD MEMBER ' + @userName;
		exec (@sqlString)
	end
END
go