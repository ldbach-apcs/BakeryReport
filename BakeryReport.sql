-- Check database existence before creating it
IF NOT EXISTS (SELECT name FROM master.dbo.sysdatabases WHERE name = N'BakeryReport')
	CREATE DATABASE [BakeryReport];
GO

USE BakeryReport;
GO

-- Check table existence before creating it
IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = N'NguyenLieu')
	CREATE TABLE dbo.NguyenLieu (
		nlName nchar(30) Primary Key,
		nlGia int,
		nlTonKho float Default 0
	); -- khi nhập hàng, mỗi nlName sẽ đảm bảo được nhập với nlId tương ứng mới nhất

IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = N'Banh')
	CREATE TABLE dbo.Banh (
		bName nchar(30) Primary Key
	);

IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = N'CongThuc')
	CREATE TABLE dbo.CongThuc (
		bName nchar(30),
		nlName nchar(30),
		ctDinhLuong float,

		Primary Key (bName, nlName),
		Foreign Key (bName) References dbo.Banh(bName),
		Foreign Key (nlName) References dbo.NguyenLieu(nlName)
	);

IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = N'BaoCao')
	CREATE TABLE dbo.BaoCao (
		bcLoai int Check (bcLoai in (0, 1, 2)), -- Sản xuất / Tồn / Hủy
		bcNgay date,

		Primary Key (bcLoai, bcNgay)
	);

IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = N'NoiDungBaoCao')
	CREATE TABLE dbo.NoiDungBaoCao (
		bcLoai int,
		bcNgay date,
		bName nchar(30), 
		bSoLuong int Not Null,
		bThanhTien int,

		Primary Key (bcLoai, bcNgay, bName),
		Foreign Key (bcLoai, bcNgay) References dbo.BaoCao(bcLoai, bcNgay),
		Foreign Key (bName) References dbo.Banh(bName)

	);

IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = N'NhapXuatKho')
	CREATE TABLE dbo.NhapXuatKho (
		nxLoai int Check (nxLoai in (0, 1)), -- Nhập / Xuất
		nxNgay date,

		Primary Key (nxLoai, nxNgay)
	);

IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = N'NoiDungNhapXuat')
	CREATE TABLE dbo.NoiDungNhapXuat (
		nxLoai int,
		nxNgay date,
		nlName nchar(30),
		nlSoLuong float,
		nlGia int,

		Primary Key (nxLoai, nxNgay),
		Foreign Key (nxLoai, nxNgay) References dbo.NhapXuatKho(nxLoai, nxNgay),
		Foreign Key (nlName) References dbo.NguyenLieu(nlName)
	);

IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = N'TonKho')
	CREATE TABLE dbo.TonKho (
		tkNgay date,
		nlName nchar(30),
		nlGia int,
		nlTonKho float,

		Primary Key (tkNgay, nlName),
		Foreign Key (nlName) References dbo.NguyenLieu(nlName)
	);
GO

-- Triggers
--IF NOT EXISTS (SELECT * FROM sys.objects WHERE type = 'TR' AND name = N'tr_AddStock')
--	Create Trigger dbo.tr_AddStock 
--


-- Stored-Procedure
-- check existence before adding
-- Procedure for adding Ingridient
--IF NOT EXISTS (SELECT * FROM sys.sysobjects WHERE id = object_id(N'[dbo].[sp_IngridientAdd]') AND type in (N'P'))
Create Procedure dbo.sp_IngridientAdd 
	@nlName nchar(30),
	@nlGia int,
	@nlSoLuong float
As Begin
	-- May throw SQLException here
	Insert Into dbo.NguyenLieu values (@nlName, @nlGia, @nlSoLuong);
	Declare @curDate Date;
	Set @curDate = GETDATE();
	Insert Into dbo.TonKho values (@curDate, @nlName, @nlGia, @nlSoLuong);
End
GO

Create Procedure dbo.sp_StockAdd 
	@tkNgay date,
	@nlName nchar(30),
	@nlGia int,
	@nlSoLuong float
As Begin 
	Declare @type int;
	Set @type = 0; -- Nhập

	-- Update NguyenLieu
	Update dbo.NguyenLieu
	Set nlGia = (nlGia + @nlGia) / (@nlSoLuong + nlTonKho), nlTonKho = nlTonKho + @nlSoLuong
	Where (nlName = @nlName);

	-- Create NhapXuatKho Log if not exists
	If Not Exists (Select * From dbo.NhapXuatKho WHERE nxNgay = @tkNgay And nxLoai = @type)
		Insert Into dbo.NhapXuatKho Values (@type, @tkNgay);

	-- Add current item to NhapXuatKho Log
	Delete From dbo.NoiDungNhapXuat
	Where (nxLoai = @type And nxNgay = @tkNgay And nlName = @nlName);

	Insert Into dbo.NoiDungNhapXuat
	Values (@type, @tkNgay, @nlName, @nlGia, @nlSoLuong);
End
GO

Create Procedure dbo.sp_GetListIngridient
As Begin
	Select * From dbo.NguyenLieu;
End


/*
-- Insert ingredients
Insert into dbo.NguyenLieu(nlName, nlGia) values 
	(N'Xúc Xích', 2250),
	(N'Jambong', 160000),
	(N'Trứng muối', 5000),
	(N'Cream', 190000),
	(N'Phô Mai', 190000),
	(N'Bột mì 8', 20000),
	(N'Bột mì 11', 22000),
	(N'Bột bắp', 30000),
	(N'Bột sữa', 120000),
	(N'Sữa tươi', 27300),
	(N'Dầu', 25000),
	(N'Trứng gà', 2000),
	(N'Trứng vịt', 2000),
	(N'Đường', 20000),
	(N'Chà bông', 30000),
	(N'Men lạt', 190000),
	(N'Bơ', 50000),
	(N'Muối', 5000),
	(N'Phụ gia ngọt', 90000),
	(N'Whipping', 115000),
	(N'Sữa đặc', 2000),
	(N'Nước dừa', 66000),
	(N'Thịt', 77000),
	(N'Pate', 210000),
	(N'Hành', 20000),
	(N'Bột ngọt', 42000),
	(N'Vỏ bánh', 4000),
	(N'Dừa sấy', 89000),
	(N'Mức dâu', 70000),
	(N'Mức thơm', 30000);
*/

-- Syntatic checking, delete all table after creating
-- Comment following lines out for proper usage
-- Start procedure deletion
Drop Procedure dbo.sp_IngridientAdd;
Drop Procedure dbo.sp_StockAdd;
-- End procedure deletion
-- Start Table deletion
drop table dbo.TonKho
drop table dbo.NoiDungNhapXuat
drop table dbo.NhapXuatKho
drop table dbo.NoiDungBaoCao;
drop table dbo.BaoCao;
drop table dbo.CongThuc;
drop table dbo.Banh;
drop table dbo.NguyenLieu;
--  End Table deletion
