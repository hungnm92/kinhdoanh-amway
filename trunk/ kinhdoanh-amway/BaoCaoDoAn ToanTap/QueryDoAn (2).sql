--===================Tạo bảng=====================
CREATE TABLE Tinh
(
	MaTinh varchar(2) primary key,
	TenTinh nvarchar(20) not null unique
)
----------------------------------------------------------------
CREATE TABLE Huyen
(
	MaHuyen varchar(4) primary key,
	TenHuyen nvarchar(25) not null unique, 
	MaTinh varchar(2) not null foreign key references Tinh(MaTinh),
)
------------------------------------------------------------
CREATE TABLE XaPhuong
(
	MaXa varchar(6) primary key,
	TenXa nvarchar(25) not null unique,
	MaHuyen varchar(4) not null foreign key references Huyen(MaHuyen),
)
-----------------------------------------------------------------------
CREATE TABLE Duong
(
	MaDuong varchar(4) primary key,
	TenDuong nvarchar(30) not null unique
)
-------------------------------------------------------------------------
CREATE TABLE LoaiSP
(
	MaLSP tinyint primary key,
	TenLSP nvarchar(30) not null
)
--------------------------------------------------------------------------
CREATE TABLE SanPham
(
	MaSP varchar(6) primary key,
	MaLSP tinyint not null foreign key references LoaiSP(MaLSP),
	TenSP nvarchar(100) not null,
	ChiTiet nvarchar(500),
	CachSuDung nvarchar(500),
	AnhSP varchar(50) not null,
	Gia money not null	
)
-------------------------------------------------------
CREATE TABLE CapDo
(
	MaCD tinyint primary key,
	TenCD nvarchar(50) not null,
	NoiDung nvarchar(500) not null, 
	AnhCD nvarchar(50)
)
---------------------------------------------------------------------
CREATE TABLE ChuongTrinh
(
	MaCT varchar(3) primary key,
	TenCT nvarchar(50) not null
)
-------------------------------------------------------------------
CREATE TABLE KhachHang
(
	MaKH varchar(7) primary key,
	HoKH nvarchar(20) not null,
	TenKH nvarchar(10) not null,
	NgaySinh date not null,
	GioiTinh bit,
	CMND varchar(9),
	SoDT varchar(11) not null,
	Email nvarchar(100),
	Loai bit not null,
	SoNhaKHLL nvarchar(10),
	SoNhaKHTT nvarchar(10),
	MaDuongKHLL varchar(4) foreign key references Duong(MaDuong),
	MaDuongKHTT varchar(4) foreign key references Duong(MaDuong),
	MaXaKHLL varchar(6) not null foreign key references XaPhuong(MaXa),
	MaXaKHTT varchar(6) not null foreign key references XaPhuong(MaXa)
)
---------------------------------------------------------------------
CREATE TABLE NhaPhanPhoi
(
	MaNPP varchar(7) primary key,
	HoNPP nvarchar(20) not null,
	TenNPP nvarchar(10) not null,
	NgaySinh date not null,
	GioiTinh bit not null,
	AnhNPP nvarchar(50) not null,
	CMND varchar(9) not null,
	SoDT varchar(11) not null,
	Email nvarchar(100) not null,
	MatKhau nvarchar(100) not null,
	NgayKyThe date not null,
	NgayHetHan date not null,
	SoNhaNPPLL nvarchar(10),
	SoNhaNPPTT nvarchar(10),
	ViDo numeric(18, 7),
	KinhDo numeric(18, 7),
	MaDuongNPPLL varchar(4) foreign key references Duong(MaDuong),
	MaDuongNPPTT varchar(4) foreign key references Duong(MaDuong),
	MaXaNPPLL varchar(6) not null foreign key references XaPhuong(MaXa),
	MaXaNPPTT varchar(6) not null foreign key references XaPhuong(MaXa),
	MaNBT varchar(7) foreign key references NhaPhanPhoi(MaNPP),
	TinhTrang bit,
)
---------------------------------------------------------------------------------------------------------------------------------------
CREATE TABLE QuaTrinhCD
(
	MaNPP varchar(7) not null foreign key references NhaPhanPhoi(MaNPP),
	MaCD tinyint not null foreign key references CapDo(MaCD),
	ThoiGian date not null,
	constraint PK_QuaTrinhCD primary key (MaNPP, MaCD)
)
---------------------------------------------------------------------------------------------------------------------------------------
CREATE TABLE ChamSoc
(
	MaCS varchar(6) primary key,
	NgayCS date not null,
	SoLan tinyint not null,
	ThamDu bit,
	MaCT varchar(3) not null foreign key references ChuongTrinh(MaCT),
	MaKH varchar(7) not null foreign key references KhachHang(MaKH),
	MaNPP varchar(7) not null foreign key references NhaPhanPhoi(MaNPP)
)
-----------------------------------------------------------------------------
CREATE TABLE DaoTao
(
	MaDT varchar(6) primary key,
	NgayDT date not null,
	MaCT varchar(3) not null foreign key references ChuongTrinh(MaCT),
	MaNPP varchar(7) not null foreign key references NhaPhanPhoi(MaNPP),
	SoLan tinyint not null
)
----------------------------------------------------------------------------------
CREATE TABLE KHSuDung
(
	MaKHSD varchar(8) primary key,
	MaSP varchar(6) not null foreign key references SanPham(MaSP),
	MaKH varchar(7)not null foreign key references KhachHang(MaKH),
	MaNPP varchar(7) not null foreign key references NhaPhanPhoi(MaNPP),
	NgayKHSD date not null,
	NgayKHSDHH date,
	GhiChu nvarchar(200),
	SoLuong tinyint not null,
	MinhHoa bit not null
)
-------------------------------------------------------------------------
CREATE TABLE NPPSuDung
(
	MaNPPSD varchar(8) primary key,
	MaSP varchar(6) not null foreign key references SanPham(MaSP),
	MaNPP varchar(7) not null foreign key references NhaPhanPhoi(MaNPP),
	NgayNPPSD date not null,
	NgayNPPSDHH date,
	GhiChu nvarchar(200),
	SoLuong tinyint not null,
	MinhHoa bit not null
)
--------------------------------------------------------------------------
CREATE TABLE DoanhThu
(
	ThangNam varchar(7),
	MaNPP varchar(7) not null foreign key references NhaPhanPhoi(MaNPP),
	Diem int,
	constraint PK_DoanhThu primary key (MaNPP, ThangNam)
)
-----------------------------------------------------------------------------
CREATE TABLE PhanQuyen
(
	MaQuyen tinyint primary key,
	TenQuyen nvarchar(50) not null,
)
-----------------------------------------------------------------------------
CREATE TABLE QuyDinh
(
	MaQD tinyint primary key,
	TenQD nvarchar(50) not null,
	NoiDung nvarchar(500) not null
)
------------------------------------------------------------------------------
CREATE TABLE TrungTamPP
(
	MaTT varchar(50) not null,
	ViDo numeric(18, 7) not null,
	KinhDo numeric(18, 7) not null,
	MoTa varchar(300)
)
--===================Xóa bảng====================
Drop table TrungTamPP
Drop table QuyDinh
Drop table PhanQuyen
Drop table DoanhThu
Drop table NPPSuDung
Drop table KHSuDung
Drop table DaoTao
Drop table ChamSoc
Drop table QuaTrinhCD
Drop table NhaPhanPhoi
Drop table KhachHang
Drop table ChuongTrinh
Drop table CapDo
Drop table SanPham
Drop table LoaiSP 
Drop table Duong
Drop table XaPhuong
Drop table Huyen
Drop table Tinh
