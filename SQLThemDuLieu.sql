USE QuanLyQuanNET
GO

-- Thêm dữ liệu vào bảng Khách hàng
INSERT INTO KhachHang (MaKhachHang, TenKhachHang, SoDienThoai, DiaChi)
VALUES 
	('KH001', N'Trần Thụ Nhân', '0987654321', N'Số 20, Đường Nguyễn Huệ, Quận 1, Hồ Chí Minh'),
	('KH002', N'Trần Huy Phong', '0974153628', N'Số 30, Đường Võ Văn Tần, Quận 3, Hồ Chí Minh'),
	('KH003', N'Trần Hữu Thắng', '0905123498', N'Số 40, Đường Đề Thám, Quận 5, Hồ Chí Minh'),
	('KH004', N'Nguyễn Minh Chiến', '0912345678', N'Số 50, Đường Nguyễn Văn Cừ, Quận 10, Hồ Chí Minh'),
	('KH005', N'Nguyễn Thiện Sinh', '0987456321', N'Số 60, Đường Lý Thường Kiệt, Quận 7, Hồ Chí Minh'),
	('KH006', N'Nguyễn Khánh Minh', '0909876543', N'Số 70, Đường Trần Hưng Đạo, Quận 4, Hồ Chí Minh'),
	('KH007', N'Nguyễn Huy Thông', '0912384765', N'Số 80, Đường Nguyễn Thị Minh Khai, Quận 1, Hồ Chí Minh'),
	('KH008', N'Nguyễn Ngọc Phương', '0976432154', N'Số 90, Đường Cách Mạng Tháng 8, Quận 3, Hồ Chí Minh'),
	('KH009', N'Trần Văn Dương', '0987456213', N'Số 100, Đường Nguyễn Đình Chiểu, Quận 5, Hồ Chí Minh'),
	('KH010', N'Phạm Ðức Thọ', '0905467392', N'Số 110, Đường Lê Lợi, Quận 10, Hồ Chí Minh'),
	('KH011', N'Vũ Văn Việt', '0913458762', N'Số 120, Đường Trần Quang Diệu, Quận Phú Nhuận, Hồ Chí Minh'),
	('KH012', N'Nguyễn Văn Phát', '0987654321', N'Số 130, Đường Lê Lai, Quận 1, Hồ Chí Minh'),
	('KH013', N'Phạm Gia Ðức', '0974153628', N'Số 140, Đường Trần Phú, Quận 5, Hồ Chí Minh'),
	('KH014', N'Lê Văn Khương', '0905123498', N'Số 150, Đường Nguyễn Thái Bình, Quận 3, Hồ Chí Minh'),
	('KH015', N'Phạm Hiểu Minh', '0912345678', N'Số 160, Đường Hai Bà Trưng, Quận 4, Hồ Chí Minh'),
	('KH016', N'Nguyễn Văn Lý', '0987456321', N'Số 170, Đường Nam Kỳ Khởi Nghĩa, Quận 1, Hồ Chí Minh'),
	('KH017', N'Trần Văn Luân', '0987654321', N'Số 180, Đường Cao Thắng, Quận 3, Hồ Chí Minh'),
	('KH018', N'Phạm Hữu Toàn', '0974153628', N'Số 190, Đường Nguyễn Thị Minh Khai, Quận 1, Hồ Chí Minh'),
	('KH019', N'Nguyễn Văn Bảo', '0905123498', N'Số 200, Đường Trường Sa, Quận 2, Hồ Chí Minh'),
	('KH020', N'Phạm Viễn Ðông', '0912345678', N'Số 210, Đường Nguyễn Cư Trinh, Quận 1, Hồ Chí Minh'),
	('KH021', N'Phạm Hùng Cường', '0987456321', N'Số 220, Đường Điện Biên Phủ, Quận Bình Thạnh, Hồ Chí Minh'),
	('KH022', N'Phạm Duy Cường', '0987654321', N'Số 230, Đường Lê Duẩn, Quận 1, Hồ Chí Minh'),
	('KH023', N'Đào Duy Thông', '0974153628', N'Số 240, Đường Võ Thị Sáu, Quận 3, Hồ Chí Minh'),
	('KH024', N'Đào Minh Trí', '0905123498', N'Số 250, Đường Hai Bà Trưng, Quận 1, Hồ Chí Minh'),
	('KH025', N'Đào Ngọc Quyết', '0912345678', N'Số 260, Đường Trần Quang Diệu, Quận Phú Nhuận, Hồ Chí Minh'),
	('KH026', N'Đào Hiệp Hào', '0987456321', N'Số 270, Đường Nguyễn Công Trứ, Quận 1, Hồ Chí Minh'),
	('KH027', N'Lê Thu Vân', '0909876543', N'Số 280, Đường Nguyễn Thị Thập, Quận 7, Hồ Chí Minh'),
	('KH028', N'Lê Thùy Giang', '0912384765', N'Số 290, Đường Đặng Thúc Liễu, Quận 5, Hồ Chí Minh'),
	('KH029', N'Lê Triệu Mẫn', '0976432154', N'Số 300, Đường Hàm Nghi, Quận 1, Hồ Chí Minh'),
	('KH030', N'Lê Thủy Linh', '0987456213', N'Số 310, Đường Võ Văn Kiệt, Quận 4, Hồ Chí Minh'),
	('KH031', N'Lê Hồng Vân', '0905467392', N'Số 320, Đường Phạm Ngọc Thạch, Quận 3, Hồ Chí Minh'),
	('KH032', N'Lê Thục Vân', '0913458762', N'Số 330, Đường Nguyễn Đình Chiểu, Quận 5, Hồ Chí Minh'),
	('KH033', N'Đào Thanh Sơn', '0987123456', N'Số 340, Đường Phan Đình Phùng, Quận Phú Nhuận, Hồ Chí Minh'),
	('KH034', N'Trần Thái Dương', '0978213546', N'Số 350, Đường Huỳnh Văn Bánh, Quận 10, Hồ Chí Minh'),
	('KH035', N'Lê Ánh Ngọc', '0909812374', N'Số 360, Đường Nguyễn Khoái, Quận 4, Hồ Chí Minh'),
	('KH036', N'Trần Anh Việt', '0912756432', N'Số 370, Đường Lạc Long Quân, Quận 11, Hồ Chí Minh'),
	('KH037', N'Trần Đăng Khương', '0987654321', N'Số 380, Đường Cách Mạng Tháng 8, Quận 1, Hồ Chí Minh'),
	('KH038', N'Nguyễn Kim Phú', '0974153628', N'Số 390, Đường Lê Văn Sỹ, Quận 3, Hồ Chí Minh'),
	('KH039', N'Nguyễn Phước Sơn', '0905123498', N'Số 400, Đường Nguyễn Thị Minh Khai, Quận 1, Hồ Chí Minh'),
	('KH040', N'Nguyễn Hữu Lương', '0912345678', N'Số 410, Đường Huỳnh Tịnh Của, Quận 4, Hồ Chí Minh'),
	('KH041', N'Đào Quang Nhân', '0987456321', N'Số 420, Đường Nguyễn Đình Chiểu, Quận 1, Hồ Chí Minh'),
	('KH042', N'Đào Cao Minh', '0909876543', N'Số 430, Đường Trần Hưng Đạo, Quận 5, Hồ Chí Minh'),
	('KH043', N'Cao Minh Hùng', '0912384765', N'Số 440, Đường Lý Thường Kiệt, Quận 10, Hồ Chí Minh'),
	('KH044', N'Cao Tường Phát', '0976432154', N'Số 450, Đường Võ Văn Kiệt, Quận 4, Hồ Chí Minh'),
	('KH045', N'Cao Hòa Giang', '0987456213', N'Số 460, Đường Nguyễn Văn Cừ, Quận 7, Hồ Chí Minh'),
	('KH046', N'Cao Tùng Quang', '0905467392', N'Số 470, Đường Điện Biên Phủ, Quận 3, Hồ Chí Minh'),
	('KH047', N'Hoàng Hải Bằng', '0913458762', N'Số 480, Đường Hai Bà Trưng, Quận 5, Hồ Chí Minh'),
	('KH048', N'Hoàng Duy Hoàng', '0987123456', N'Số 490, Đường Trường Sa, Quận Phú Nhuận, Hồ Chí Minh'),
	('KH049', N'Hoàng Đức Nhân', '0978213546', N'Số 500, Đường Lê Duẩn, Quận 1, Hồ Chí Minh'),
	('KH050', N'Hoàng Quang Hòa', '0909812374', N'Số 510, Đường Nguyễn Thái Bình, Quận 3, Hồ Chí Minh'),
	('KH051', N'Phan Quỳnh Hoa', '0912756432', N'Số 520, Đường Võ Thị Sáu, Quận 5, Hồ Chí Minh'),
	('KH052', N'Phan Thái Vân', '0987654321', N'Số 530, Đường Trần Quang Diệu, Quận 1, Hồ Chí Minh'),
	('KH053', N'Phan Tú Vy', '0974153628', N'Số 540, Đường Nguyễn Công Trứ, Quận 3, Hồ Chí Minh'),
	('KH054', N'Diệp Tuấn Ðức', '0905123498', N'Số 550, Đường Nguyễn Thị Thập, Quận 7, Hồ Chí Minh'),
	('KH055', N'Diệp Gia Anh', '0912345678', N'Số 560, Đường Đặng Thúc Liễu, Quận 5, Hồ Chí Minh'),
	('KH056', N'Diệp Thái Minh', '0987456321', N'Số 570, Đường Hàm Nghi, Quận 1, Hồ Chí Minh'),
	('KH057', N'Diệp Việt Thắng', '0909876543', N'Số 580, Đường Võ Văn Kiệt, Quận 4, Hồ Chí Minh'),
	('KH058', N'Mai Quốc Mạnh', '0912384765', N'Số 590, Đường Phạm Ngọc Thạch, Quận 3, Hồ Chí Minh'),
	('KH059', N'Mai Tấn Thành', '0976432154', N'Số 600, Đường Nguyễn Đình Chiểu, Quận 5, Hồ Chí Minh'),
	('KH060', N'Mai Anh Tú', '0987456213', N'Số 610, Đường Phan Đình Phùng, Quận Phú Nhuận, Hồ Chí Minh'),
	('KH061', N'Võ Xuân Hiếu', '0905467392', N'Số 620, Đường Huỳnh Văn Bánh, Quận 10, Hồ Chí Minh'),
	('KH062', N'Võ Bá Tùng', '0913458762', N'Số 630, Đường Nguyễn Khoái, Quận 4, Hồ Chí Minh'),
	('KH063', N'Võ Tấn Nam', '0987123456', N'Số 640, Đường Lạc Long Quân, Quận 11, Hồ Chí Minh'),
	('KH064', N'Hồ Gia Hưng', '0978213546', N'Số 650, Đường Lê Văn Lương, Quận 7, Hồ Chí Minh'),
	('KH065', N'Hồ Quốc Hải', '0909812374', N'Số 660, Đường Bà Huyện Thanh Quan, Quận 3, Hồ Chí Minh'),
	('KH066', N'Hồ Cao Sỹ', '0912756432', N'Số 670, Đường Nguyễn Cư Trinh, Quận 1, Hồ Chí Minh'),
	('KH067', N'Hồ Ðức Khang', '0987654321', N'Số 680, Đường Trường Sa, Quận 3, Hồ Chí Minh'),
	('KH068', N'Hồ Triệu Thái', '0974153628', N'Số 690, Đường Lê Duẩn, Quận 1, Hồ Chí Minh'),
	('KH069', N'Hồ Tùng Anh', '0905123498', N'Số 700, Đường Hai Bà Trưng, Quận 5, Hồ Chí Minh'),
	('KH070', N'Võ Gia Cần', '0912345678', N'Số 710, Đường Nguyễn Thái Học, Quận 10, Hồ Chí Minh'),
	('KH071', N'Võ Quang Bửu', '0987456321', N'Số 720, Đường Võ Thị Sáu, Quận 3, Hồ Chí Minh'),
	('KH072', N'Võ Thái Duy', '0909876543', N'Số 730, Đường Nguyễn Công Trứ, Quận 1, Hồ Chí Minh'),
	('KH073', N'Võ Thế Doanh', '0912384765', N'Số 740, Đường Lê Văn Sỹ, Quận 3, Hồ Chí Minh'),
	('KH074', N'Mai Thanh Hậu', '0976432154', N'Số 750, Đường Trần Hưng Đạo, Quận 5, Hồ Chí Minh'),
	('KH075', N'Mai Thuận Phương', '0987456213', N'Số 760, Đường Điện Biên Phủ, Quận 3, Hồ Chí Minh'),
	('KH076', N'Mai Nhật Minh', '0905467392', N'Số 770, Đường Hai Bà Trưng, Quận 1, Hồ Chí Minh'),
	('KH077', N'Diệp Gia Phước', '0913458762', N'Số 780, Đường Lê Lợi, Quận 5, Hồ Chí Minh'),
	('KH078', N'Diệp Quốc Hòa', '0987123456', N'Số 790, Đường Trần Quang Diệu, Quận Phú Nhuận, Hồ Chí Minh'),
	('KH079', N'Diệp Tuấn Hùng', '0978213546', N'Số 800, Đường Huỳnh Văn Bánh, Quận 10, Hồ Chí Minh'),
	('KH080', N'Diệp Sỹ Hoàng', '0909812374', N'Số 810, Đường Nguyễn Khoái, Quận 4, Hồ Chí Minh'),
	('KH081', N'Phan Thùy Dung', '0912756432', N'Số 820, Đường Phạm Ngọc Thạch, Quận 3, Hồ Chí Minh'),
	('KH082', N'Phan Quỳnh Hoa', '0987654321', N'Số 830, Đường Bà Huyện Thanh Quan, Quận 1, Hồ Chí Minh'),
	('KH083', N'Phan Thanh Thảo', '0974153628', N'Số 840, Đường Nguyễn Cư Trinh, Quận 4, Hồ Chí Minh'),
	('KH084', N'Phan Nhã Linh', '0905123498', N'Số 850, Đường Lê Thánh Tôn, Quận 3, Hồ Chí Minh'),
	('KH085', N'Hoàng Ngọc Quang', '0912345678', N'Số 860, Đường Nguyễn Du, Quận 1, Hồ Chí Minh'),
	('KH086', N'Hoàng Thuận Thành', '0987456321', N'Số 870, Đường Lý Tự Trọng, Quận 5, Hồ Chí Minh'),
	('KH087', N'Hoàng Chí Anh', '0909876543', N'Số 880, Đường Đinh Tiên Hoàng, Quận 3, Hồ Chí Minh'),
	('KH088', N'Hoàng Ðức Kiên', '0912384765', N'Số 890, Đường Trường Sa, Quận 4, Hồ Chí Minh'),
	('KH089', N'Cao Chí Giang', '0976432154', N'Số 900, Đường Hai Bà Trưng, Quận 1, Hồ Chí Minh'),
	('KH090', N'Cao Thành Lợi', '0987456213', N'Số 910, Đường Võ Văn Kiệt, Quận 5, Hồ Chí Minh'),
	('KH091', N'Cao Kim Toàn', '0905467392', N'Số 920, Đường Phạm Ngọc Thạch, Quận 3, Hồ Chí Minh'),
	('KH092', N'Cao Thiện Dũng', '0913458762', N'Số 930, Đường Nguyễn Đình Chiểu, Quận 1, Hồ Chí Minh'),
	('KH093', N'Lê Yến Thảo', '0987123456', N'Số 940, Đường Trần Quang Diệu, Quận Phú Nhuận, Hồ Chí Minh'),
	('KH094', N'Lê Bích Hồng', '0978213546', N'Số 950, Đường Huỳnh Văn Bánh, Quận 10, Hồ Chí Minh'),
	('KH095', N'Lê Vân Thanh', '0909812374', N'Số 960, Đường Nguyễn Khoái, Quận 4, Hồ Chí Minh'),
	('KH096', N'Lê Tuệ Minh', '0912756432', N'Số 970, Đường Phạm Ngọc Thạch, Quận 3, Hồ Chí Minh'),
	('KH097', N'Đào Thanh Tú', '0987654321', N'Số 980, Đường Nguyễn Văn Trỗi, Quận 1, Hồ Chí Minh'),
	('KH098', N'Đào Hồng Đức', '0974153628', N'Số 990, Đường Đề Thám, Quận 3, Hồ Chí Minh'),
	('KH099', N'Đào Nam Sơn', '0905123498', N'Số 1000, Đường Nguyễn Hữu Cầu, Quận 5, Hồ Chí Minh'),
	('KH100', N'Đào Ðức Quyền', '0912345678', N'Số 1010, Đường Trường Sa, Quận 1, Hồ Chí Minh'),
	('KH101', N'Phạm Xuân Cao', '0987456321', N'Số 1020, Đường Võ Văn Tần, Quận 3, Hồ Chí Minh'),
	('KH102', N'Phạm Tuấn Hải', '0909876543', N'Số 1030, Đường Nguyễn Thái Bình, Quận 4, Hồ Chí Minh'),
	('KH103', N'Phạm Duy Quang', '0912384765', N'Số 1040, Đường Hai Bà Trưng, Quận 1, Hồ Chí Minh'),
	('KH104', N'Nguyễn Minh Tú', '0976432154', N'Số 1050, Đường Đồng Khởi, Quận 5, Hồ Chí Minh'),
	('KH105', N'Nguyễn Đăng Khôi', '0987456213', N'Số 1060, Đường Lý Tự Trọng, Quận 3, Hồ Chí Minh'),
	('KH106', N'Nguyễn Minh Phúc', '0905467392', N'Số 1070, Đường Trần Hưng Đạo, Quận 1, Hồ Chí Minh'),
	('KH107', N'Trần Nguyên Phong', '0913458762', N'Số 1080, Đường Võ Văn Kiệt, Quận 5, Hồ Chí Minh'),
	('KH108', N'Trần Công Hoan', '0987123456', N'Số 1090, Đường Hai Bà Trưng, Quận 3, Hồ Chí Minh'),
	('KH109', N'Trần Hiếu Liêm', '0978213546', N'Số 1100, Đường Lê Lợi, Quận 1, Hồ Chí Minh'),
	('KH110', N'Trần Minh Khuê', '0909812374', N'Số 1110, Đường Trần Quang Diệu, Quận Phú Nhuận, Hồ Chí Minh'),
	('KH111', N'Trần Mạnh Quỳnh', '0912756432', N'Số 1120, Đường Huỳnh Văn Bánh, Quận 10, Hồ Chí Minh')
GO

-- Thêm dữ liệu vào bảng Chức vụ
INSERT INTO ChucVu (MaChucVu, TenChucVu, MoTaCongViec, Luong)
VALUES 
	('CV001', N'Quản lý', N'Quản lý toàn bộ hoạt động của quán NET', 15000000),
	('CV002', N'Thu ngân', N'Quản lý giao dịch thu chi và tài chính của quán NET', 13000000),
	('CV003', N'Kế toán', N'Quản lý công việc liên quan đến tài chính và kế toán của quán NET', 13000000),
	('CV004', N'Kỹ thuật viên', N'Bảo trì và sửa chữa các thiết bị máy tính trong quán NET', 12000000),
	('CV005', N'Nhân viên bếp', N'Chuẩn bị và phục vụ các món ăn cho khách hàng', 9000000),
	('CV006', N'Phục vụ', N'Chăm sóc khách hàng và phục vụ các yêu cầu của khách hàng', 7000000)
GO

-- Thêm dữ liệu vào bảng Nhân viên
INSERT INTO NhanVien (MaNhanVien, TenNhanVien, SoDienThoai, DiaChi, MaChucVu)
VALUES 
	('NV001', N'Đào Duy Phát', '0987654321', N'Số 1, Đường ABC, Quận 1, Hồ Chí Minh', 'CV001'),
	('NV002', N'Lê Nguyễn Thiên Tứ', '0974153628', N'Số 2, Đường DEF, Quận 2, Hồ Chí Minh', 'CV002'),
	('NV003', N'Trần Thị Á Tiên', '0905123498', N'Số 3, Đường GHI, Quận 3, Hồ Chí Minh', 'CV002'),
	('NV004', N'Phạm Tuấn Minh', '0912345678', N'Số 4, Đường JKL, Quận 4, Hồ Chí Minh', 'CV002'),
	('NV005', N'Lê Đức Duy', '0987456321', N'Số 5, Đường MNO, Quận 5, Hồ Chí Minh', 'CV002'),
	('NV006', N'Vương Đình Hiếu', '0909876543', N'Số 6, Đường PQR, Quận 6, Hồ Chí Minh', 'CV003'),
	('NV007', N'Nguyễn Văn Hào', '0912384765', N'Số 7, Đường STU, Quận 7, Hồ Chí Minh', 'CV003'),
	('NV008', N'Trình Học Tuấn', '0976432154', N'Số 8, Đường VWX, Quận 8, Hồ Chí Minh', 'CV004'),
	('NV009', N'Đặng Hoàng Toàn', '0987456213', N'Số 9, Đường YZ1, Quận 9, Hồ Chí Minh', 'CV004'),
	('NV010', N'Trần Hoàng Anh Tú', '0905467392', N'Số 10, Đường 123, Quận 10, Hồ Chí Minh', 'CV005'),
	('NV011', N'Nguyễn Quang Vinh', '0913458762', N'Số 11, Đường 456, Quận 11, Hồ Chí Minh', 'CV005'),
	('NV012', N'Trương Quang Anh', '0987654321', N'Số 12, Đường 789, Quận 12, Hồ Chí Minh', 'CV005'),
	('NV013', N'Cao Nguyễn Thành An', '0974153628', N'Số 13, Đường XYZ, Quận Tân Bình, Hồ Chí Minh', 'CV005'),
	('NV014', N'Tào Chí Vỹ', '0905123498', N'Số 14, Đường ABC, Quận Bình Thạnh, Hồ Chí Minh', 'CV006'),
	('NV015', N'Ngô Hoàng Ân', '0987456321', N'Số 16, Đường EFG, Quận Thủ Đức, Hồ Chí Minh', 'CV006'),
	('NV016', N'Nguyễn Trần Huỳnh Lê', '0909876543', N'Số 17, Đường HIJ, Quận Gò Vấp, Hồ Chí Minh', 'CV006'),
	('NV017', N'Lê Quốc Văn', '0912384765', N'Số 18, Đường KLM, Quận Bình Tân, Hồ Chí Minh', 'CV006'),
	('NV018', N'Lê Nguyễn Trí Nhân', '0976432154', N'Số 19, Đường NOP, Quận Tân Phú, Hồ Chí Minh', 'CV006'),
	('NV019', N'Trần Vĩnh Hùng', '0987456213', N'Số 20, Đường QRS, Quận Bình Chánh, Hồ Chí Minh', 'CV006'),
	('NV020', N'Vũ Khánh Quốc', '0905467392', N'Số 21, Đường TUV, Quận Củ Chi, Hồ Chí Minh', 'CV006')
GO

-- Thêm dữ liệu vào bảng Tài khoản nhân viên
INSERT INTO TaiKhoan_NhanVien (MaTaiKhoan, MaNhanVien, TenDangNhap, MatKhau) VALUES ('NV001', 'NV001','NV001', 'NV001')
INSERT INTO TaiKhoan_NhanVien (MaTaiKhoan, MaNhanVien, TenDangNhap, MatKhau) VALUES ('NV002', 'NV002','NV002', 'NV002')
INSERT INTO TaiKhoan_NhanVien (MaTaiKhoan, MaNhanVien, TenDangNhap, MatKhau) VALUES ('NV003', 'NV002','NV003', 'NV003')
INSERT INTO TaiKhoan_NhanVien (MaTaiKhoan, MaNhanVien, TenDangNhap, MatKhau) VALUES ('NV004', 'NV004','NV004', 'NV004')
INSERT INTO TaiKhoan_NhanVien (MaTaiKhoan, MaNhanVien, TenDangNhap, MatKhau) VALUES ('NV005', 'NV005','NV005', 'NV005')
INSERT INTO TaiKhoan_NhanVien (MaTaiKhoan, MaNhanVien, TenDangNhap, MatKhau) VALUES ('NV006', 'NV006','NV006', 'NV006')
INSERT INTO TaiKhoan_NhanVien (MaTaiKhoan, MaNhanVien, TenDangNhap, MatKhau) VALUES ('NV007', 'NV007','NV007', 'NV007')

-- Thêm dữ liệu vào bảng Phòng máy
INSERT INTO PhongMay (MaPhong, TenPhong, SoLuongMay, DonGiaMoiMay)
VALUES 
	('P001', N'Phòng Thường', 75, 8000),
	('P002', N'Phòng VIP', 50, 12000),
	('P003', N'Phòng Stream', 25, 25000),
	('P004', N'Phòng Training', 30, 20000)
GO

-- Thêm dữ liệu cho 75 máy tính của loại phòng thường vào bảng Máy tính
DECLARE @i INT = 1
WHILE @i <= 75
BEGIN
    DECLARE @MaMayTinh NVARCHAR(10) = 'MT' + RIGHT('00' + CAST(@i AS NVARCHAR(2)), 3)
    INSERT INTO MayTinh(MaMayTinh, MaPhong, TenMayTinh, TrangThaiMayTinh, ThoiGianMo, MaTaiKhoan)
    VALUES (@MaMayTinh, 'P001', N'Máy ' + RIGHT('00' + CAST(@i AS NVARCHAR(2)), 3), 0, NULL, NULL)
    
    SET @i = @i + 1
END
GO

-- Thêm dữ liệu cho 50 máy tính của loại phòng VIP vào bảng Máy tính
DECLARE @MaxMaMayTinh NVARCHAR(10)
SELECT @MaxMaMayTinh = MAX(MaMayTinh) FROM MayTinh

DECLARE @i INT = 1
WHILE @i <= 50
BEGIN
    DECLARE @MaMayTinh NVARCHAR(10) = 'MT' + RIGHT('00' + CAST(CAST(RIGHT(@MaxMaMayTinh, 3) AS INT) + @i AS NVARCHAR(3)), 3)
    INSERT INTO MayTinh(MaMayTinh, MaPhong, TenMayTinh, TrangThaiMayTinh, ThoiGianMo, MaTaiKhoan)
    VALUES (@MaMayTinh, 'P002', N'Máy ' + RIGHT('00' + CAST(@i AS NVARCHAR(2)), 3), 0, NULL, NULL)
    
    SET @i = @i + 1
END
GO

-- Thêm dữ liệu cho 25 máy tính của loại phòng Stream vào bảng Máy tính
DECLARE @MaxMaMayTinh NVARCHAR(10)
SELECT @MaxMaMayTinh = MAX(MaMayTinh) FROM MayTinh

DECLARE @i INT = 1
WHILE @i <= 25
BEGIN
    DECLARE @MaMayTinh NVARCHAR(10) = 'MT' + RIGHT('00' + CAST(CAST(RIGHT(@MaxMaMayTinh, 3) AS INT) + @i AS NVARCHAR(3)), 3)
    INSERT INTO MayTinh(MaMayTinh, MaPhong, TenMayTinh, TrangThaiMayTinh, ThoiGianMo, MaTaiKhoan)
    VALUES (@MaMayTinh, 'P003', N'Máy ' + RIGHT('00' + CAST(@i AS NVARCHAR(2)), 3), 0, NULL, NULL)
    
    SET @i = @i + 1
END
GO

-- Thêm dữ liệu cho 30 máy tính của loại phòng Training vào bảng Máy tính
DECLARE @MaxMaMayTinh NVARCHAR(10)
SELECT @MaxMaMayTinh = MAX(MaMayTinh) FROM MayTinh

DECLARE @i INT = 1
WHILE @i <= 30
BEGIN
    DECLARE @MaMayTinh NVARCHAR(10) = 'MT' + RIGHT('00' + CAST(CAST(RIGHT(@MaxMaMayTinh, 3) AS INT) + @i AS NVARCHAR(3)), 3)
    INSERT INTO MayTinh(MaMayTinh, MaPhong, TenMayTinh, TrangThaiMayTinh, ThoiGianMo, MaTaiKhoan)
    VALUES (@MaMayTinh, 'P004', N'Máy ' + RIGHT('00' + CAST(@i AS NVARCHAR(2)), 3), 0, NULL, NULL)
    
    SET @i = @i + 1
END
GO

INSERT INTO DichVu (MaDichVu, LoaiDichVu, TenSanPham, DonGia)
VALUES
	('DV001', N'Đồ uống', N'Nước suối', 8000),
	('DV002', N'Đồ uống', N'Cà phê sữa', 20000),
	('DV003', N'Đồ uống', N'Cà phê đá', 15000),
	('DV004', N'Đồ uống', N'Coca Cola', 15000),
	('DV005', N'Đồ uống', N'String', 15000),
	('DV006', N'Đồ uống', N'Pepsi', 15000),
	('DV007', N'Đồ uống', N'Mirinda', 15000),
	('DV008', N'Đồ uống', N'Fanta', 15000),
	('DV009', N'Đồ uống', N'7 up', 15000),
	('DV010', N'Đồ uống', N'Trà đá', 3000),
	('DV011', N'Đồ ăn nhanh', N'Bánh mì', 20000),
	('DV012', N'Đồ ăn nhanh', N'Khoai tây chiên', 25000),
	('DV013', N'Đồ ăn nhanh', N'Gà rán', 35000),
	('DV014', N'Đồ ăn nhanh', N'Cánh gà nướng', 30000),
	('DV015', N'Đồ ăn nhanh', N'Bánh mì sandwich', 20000),
	('DV016', N'Đồ ăn nhanh', N'Hamburger', 40000),
	('DV017', N'Đồ ăn nhanh', N'Hotdog', 15000),
	('DV018', N'Đồ ăn nhanh', N'Kimbap', 30000),
	('DV019', N'Đồ ăn nhanh', N'Pizza', 65000),
	('DV020', N'Đồ ăn nhanh', N'Snack', 10000),
	('DV021', N'Đồ ăn nhanh', N'Mì tôm', 10000),
	('DV022', N'Đồ ăn nhanh', N'Mì tôm trứng', 15000),
	('DV023', N'Đồ ăn nhanh', N'Mì tôm trứng xúc xích', 20000),
	('DV024', N'Đồ ăn nhanh', N'Mì tôm cay', 35000),
	('DV025', N'Đồ ăn nhanh', N'Mì ý', 35000),
	('DV026', N'Cơm', N'Cơm gà', 40000),
	('DV027', N'Cơm', N'Cơm chiên hải sản', 42000),
	('DV028', N'Cơm', N'Cơm rang dưa bò', 38000),
	('DV029', N'Cơm', N'Cơm bò kho', 39000),
	('DV030', N'Cơm', N'Cơm sườn nướng', 38000),
	('DV031', N'Cơm', N'Cơm tấm', 35000),
	('DV032', N'Cơm', N'Cơm tôm rang mắm', 42000),
	('DV033', N'Cơm', N'Cơm bò sốt tiêu đen', 48000),
	('DV034', N'Cơm', N'Cơm trứng hấp', 39000),
	('DV035', N'Cơm', N'Cơm xào thập cẩm', 42000),
	('DV036', N'Cơm', N'Cơm gà xối mỡ', 45000),
	('DV037', N'Cơm', N'Cơm gà chua ngọt', 42000),
	('DV038', N'Cơm', N'Cơm chay', 38000),
	('DV039', N'Thẻ game', N'Thẻ Zing', 50000),
	('DV040', N'Thẻ game', N'Thẻ Garena', 50000),
	('DV041', N'Thẻ game', N'Thẻ GATE', 50000),
	('DV042', N'Thẻ game', N'Thẻ VCoin (VTC)', 50000),
	('DV043', N'Thẻ game', N'Thẻ APPOTA', 50000),
	('DV044', N'Thẻ game', N'Thẻ FunCard', 50000),
	('DV045', N'Thẻ game', N'Thẻ SCoin', 50000),
	('DV046', N'Thẻ game', N'Thẻ SohaCoin', 50000),
	('DV047', N'Thẻ game', N'Thẻ Bit', 50000),
	('DV048', N'Thẻ game', N'Thẻ Gosu', 50000),
	('DV049', N'Thẻ game', N'Thẻ Kul', 50000),
	('DV050', N'Thẻ game', N'Thẻ Oncash', 50000),
	('DV051', N'Thẻ điện thoại', N'Thẻ Viettel', 50000),
	('DV052', N'Thẻ điện thoại', N'Thẻ Vinaphone', 50000),
	('DV053', N'Thẻ điện thoại', N'Thẻ Mobifone', 50000),
	('DV054', N'Thẻ điện thoại', N'Thẻ Vietnanmobile', 50000),
	('DV055', N'Thẻ điện thoại', N'Thẻ Itel', 50000)
GO

-- Tạo trigger tự động tạo tài khoản nhân viên khi thêm nhân viên mới
CREATE TRIGGER Trg_TuDongTaoTaiKhoanNhanVien ON NhanVien
AFTER INSERT AS
BEGIN
    SET NOCOUNT ON

    INSERT INTO TaiKhoan_NhanVien (MaTaiKhoan, MaNhanVien, TenDangNhap, MatKhau)
    SELECT inserted.MaNhanVien, inserted.MaNhanVien, inserted.MaNhanVien, inserted.MaNhanVien
    FROM inserted
    INNER JOIN NhanVien ON inserted.MaNhanVien = NhanVien.MaNhanVien
	WHERE inserted.MaChucVu IN ('CV001', 'CV002', 'CV003')
END
GO