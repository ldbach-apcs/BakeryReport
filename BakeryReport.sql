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
		bName nchar(30) Primary Key,
		bGiaBan int
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
		bGiaThanh int,

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

		Primary Key (nxLoai, nxNgay, nlName),
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
-- Nhập kho hoặc xuất kho sẽ thay đổi nội dung bảng TonKho
-- Nhập Kho được gọi khi nhập Stock, Xuất kho được gọi khi hoàn thành báo cáo ngày
-- Nhập Stock và nhập báo cáo ngày sẽ thay đổi tồn (và giá) của nguyên liệu
-- không cần xử lý ở đây
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE type = 'TR' AND name = N'tr_AddStock')
	Exec('Create Trigger dbo.tr_AddStock On dbo.NoiDungNhapXuat
	After Insert 
	As Begin
		Declare @nxNgay Date, @nxNguyenLieu nchar(30), 
				@nlGia int, @nlSoLuong float;
		Select 	@nxNgay = nxNgay, @nxNguyenLieu = nlName, @nlSoLuong = nlSoLuong
		From	Inserted;

		Select	@nlGia = nlGia, @nlSoLuong = nlTonKho + @nlSoLuong
		From	dbo.NguyenLieu
		Where	nlName = @nxNguyenLieu

		--- Update TonKho
		-- Xóa Tồn Kho cũ của Nguyên liệu
		Delete From dbo.TonKho
		Where (tkNgay = @nxNgay and nlName = @nxNguyenLieu)

		-- Thêm Tồn kho của nguyên liệu
		Insert Into dbo.TonKho
		Values (@nxNgay, @nxNguyenLieu, @nlGia, @nlSoLuong);

	End;')
GO

-- Stored-Procedure
-- check existence before adding
-- Procedure for adding Ingridient
IF NOT EXISTS (SELECT * FROM sys.sysobjects WHERE id = object_id(N'[dbo].[sp_AddIngridient]') AND type in (N'P'))
	Exec('Create Procedure dbo.sp_AddIngridient 
		@nlName nchar(30),
		@nlGia int,
		@nlSoLuong float
	As Begin
		-- May throw SQLException here
		Insert Into dbo.NguyenLieu values (@nlName, @nlGia, 0);
		Declare @curDate Date;
		Set @curDate = GETDATE();

		Exec sp_AddStock @curDate, @nlName, @nlGia, @nlSoLuong
		--Insert Into dbo.TonKho values (@curDate, @nlName, @nlGia, @nlSoLuong);
	End')
GO

IF NOT EXISTS (SELECT * FROM sys.sysobjects WHERE id = object_id(N'[dbo].[sp_AddStock]') AND type in (N'P'))
	Exec('Create Procedure dbo.sp_AddStock 
		@tkNgay date,
		@nlName nchar(30),
		@nlGia int,
		@nlSoLuong float
	As Begin 
		Declare @type int;
		Set @type = 0; -- Nhập

		-- Create NhapXuatKho Log if not exists
		If Not Exists (Select * From dbo.NhapXuatKho WHERE nxNgay = @tkNgay And nxLoai = @type)
			Insert Into dbo.NhapXuatKho Values (@type, @tkNgay);

		Delete From dbo.NoiDungNhapXuat
		Where nxLoai = @type And nxNgay = @tkNgay And nlName = @nlName;
		Insert Into dbo.NoiDungNhapXuat
		Values (@type, @tkNgay, @nlName, @nlSoLuong, @nlGia);


		-- Update NguyenLieu
		Select @nlGia = (nlGia * nlTonKho + @nlGia * @nlSoLuong) / (@nlSoLuong + nlTonKho), @nlSoLuong  = nlTonKho + @nlSoLuong
		From dbo.NguyenLieu
		Where (nlName = @nlName);

		Update dbo.NguyenLieu
		Set nlGia = @nlGia, nlTonKho = @nlSoLuong
		Where (nlName = @nlName);

				
	End')
GO

IF NOT EXISTS (SELECT * FROM sys.sysobjects where id = OBJECT_ID(N'[dbo].[sp_RevertMakeCake]') AND type in (N'P'))
	Exec('Create Procedure dbo.sp_RevertMakeCake
		@nxNgay date,
		@bName nchar(30),
		@bSoLuong int
	As Begin
		Declare @nlName nchar(30), @ctDinhLuong float;
		
		Declare nlCursor Cursor For
		Select nlName, ctDinhLuong
		From dbo.CongThuc
		Where bName = @bName;

		-- For each Ingridient, multiply it by bSoLuong
		-- and Nhập kho coresponding
		Open nlCursor;

		Fetch Next From nlCursor Into @nlName, @ctDinhLuong;
		While @@Fetch_Status = 0
		Begin
			Update dbo.NguyenLieu
			Set nlTonKho = nlTonKho + @ctDinhLuong * @bSoLuong
			Where nlName = @nlName;

			Update dbo.NoiDungNhapXuat
			Set nlSoLuong = nlSoLuong - @ctDinhLuong * @bSoLuong
			Where nxLoai = 1 And nlName = @nlName  And @nxNgay = @nxNgay;

			Fetch Next From nlCursor Into @nlName, @ctDinhLuong;
		End;

		Close nlCursor;
		Deallocate nlCursor;
	End;')
GO

IF NOT EXISTS (SELECT * FROM sys.sysobjects Where id = OBJECT_ID(N'[dbo].[sp_RevertAddStock]') AND type in (N'P'))
	Exec('Create Procedure dbo.sp_RevertAddStock
		@nxNgay date, 
		@nlName nchar(30)
	As Begin
		-- No need to remove NhapXuatKho, only modified the content
		Declare @quantity float, @price int;
		
		Select @quantity = nlSoLuong, @price = nlGia
		From dbo.NoiDungNhapXuat
		Where nxLoai = 0 And nxNgay = @nxNgay And nlName = @nlName;

		-- - - - - - - - - -
		Update dbo.NguyenLieu 
		Set nlGia = (nlGia * nlTonKho - @quantity * @price) /  (nlTonKho - @quantity),
			nlTonKho = nlTonKho - @quantity
		Where nlName = @nlName And nlTonKho > @quantity;
		-- - - - - - - - - -
		Update dbo.NguyenLieu 
		Set nlTonKho = nlTonKho - @quantity
		Where nlName = @nlName And nlTonKho = @quantity;
		-- - - - - - - - - - 


		--Delete From dbo.NoiDungNhapXuat
		--Where nxLoai = 0 and nxNgay = @nxNgay and nlName = @nlName;
	End');
GO

IF NOT EXISTS (SELECT * FROM sys.sysobjects WHERE id = object_id(N'[dbo].[sp_GetStockIngridient]') AND type in (N'P'))
	Exec('Create Procedure dbo.sp_GetStockIngridient
	As Begin
		Declare @today Date;
		Set @today = GetDate();
		Declare @new int;
		Set @new = 0;

		If Not Exists (Select * From dbo.NhapXuatKho Where nxLoai = 0 And nxNgay = @today)
		Begin
			Insert Into dbo.NhapXuatKho
			Values (0, @today);
			Set @new = 1;
		End;

		-- Foreach NguyenLieu add/or revert NoiDungNhapXuat
		Declare nlCursor Cursor For
		Select nlName, nlGia From NguyenLieu;
		Declare @nlName nchar(30), @nlGia int;
		Open nlCursor
		Fetch Next From nlCursor into @nlName, @nlGia;
		While (@@Fetch_Status = 0) 
		Begin	
			If (@new = 1)
				Exec sp_AddStock @today, @nlName, @nlGia, 0;
			If (@new = 0)
				Exec sp_RevertAddStock @today, @nlName;
	
			Fetch Next From nlCursor into @nlName, @nlGia;
		End
		Close nlCursor;
		Deallocate nlCursor;			

		Select nlName, nlSoLuong, nlGia
		From dbo.NoiDungNhapXuat
		Where nxNgay = @today And nxLoai = 0;
	End')
GO
-- Bảng sẽ ảnh hưởng sau khi làm bánh:
-- NoiDungBaoCao, BaoCaoNgay, NguyenLieu, TonKho
IF NOT EXISTS (SELECT * FROM sys.sysobjects WHERE id = object_id(N'[dbo].[sp_MakeCake]') AND type in (N'P'))
	Exec('Create Procedure dbo.sp_MakeCake 
		@nxNgay date,
		@bName nchar(30),
		@bSoLuong int
	As Begin
		-- Handle the case where there is already a MakeCake for today :)
		-- For each type of Banh, if there already in XuatKho for today
		-- 1.	Remove from NoiDungNhapXuat
		-- 2.	Create trigger on deletion of NoiDungNhapXuat 
		--		to revert changes
		-- Hahaha I dont know how :) :) :) :) :) :) :)

		-- Use cursor to fetch ingridients needed for given Banh
		Declare @nlName nchar(30), @ctDinhLuong float;
		
		Declare nlCursor Cursor For
		Select nlName, ctDinhLuong
		From dbo.CongThuc
		Where bName = @bName;

		If Not Exists (Select * From dbo.NhapXuatKho Where nxLoai = 1 And nxNgay = @nxNgay)
			Insert Into dbo.NhapXuatKho Values (1, @nxNgay);
			

		-- For each Ingridient, multiply it by bSoLuong
		-- and XuatKho coresponding
		Open nlCursor;

		Fetch Next From nlCursor Into @nlName, @ctDinhLuong;
		While @@Fetch_Status = 0
		Begin
			Declare @nlGia int;
			Select @nlGia = nlGia From dbo.NguyenLieu Where @nlName = nlName;

			Update dbo.NguyenLieu
			Set nlTonKho = nlTonKho - @ctDinhLuong * @bSoLuong
			Where nlName = @nlName;

			If Not Exists (Select * From dbo.NoiDungNhapXuat Where nlName = @nlName And nxLoai = 1 And nxNgay = @nxNgay)
				Insert Into dbo.NoiDungNhapXuat Values (1, @nxNgay, @nlName, 0, @nlgia); 

			Update dbo.NoiDungNhapXuat
			Set nlSoLuong = nlSoLuong + @ctDinhLuong * @bSoLuong
			Where nxLoai = 1 And nlName = @nlName  And @nxNgay = @nxNgay;

			Fetch Next From nlCursor Into @nlName, @ctDinhLuong;
		End;

		Close nlCursor;
		Deallocate nlCursor;

	End')
GO

IF NOT EXISTS (SELECT * FROM sys.sysobjects WHERE id = object_id(N'[dbo].[sp_AddReport]') AND type in (N'P'))
	Exec('Create Procedure dbo.sp_AddReport
		@bcNgay date,
		@bcLoai int,
		@bName nchar(30),
		@bSoLuong int
	As Begin
		If Not Exists (Select * From dbo.BaoCao Where bcLoai = @bcLoai And @bcNgay = bcNgay)
			Insert Into dbo.BaoCao Values (@bcLoai, @bcNgay);
		
		Delete From dbo.NoiDungBaoCao
		Where bcLoai = @bcLoai And bcNgay = @bcNgay And bName = @bName;

		Declare @bThanhTien int;
		Select @bThanhTien = bGiaBan
		From dbo.Banh
		Where bName = @bName;

		Insert Into dbo.NoiDungBaoCao
		Values (@bcLoai, @bcNgay, @bName, @bSoLuong, @bThanhTien);

		-- Báo cáo Hủy và Báo cáo tồn không ảnh hưởng đến những bảng khác, không cần xử lý
		If (@bcLoai = 0) -- San Xuat
		Begin
			Exec dbo.sp_MakeCake @bcNgay, @bName, @bSoLuong;
			Return;
		End;
	End')
GO

IF NOT EXISTS (SELECT * FROM sys.sysobjects WHERE id = OBJECT_ID(N'dbo.sp_RevertAddReport') AND type = N'P')
	Exec('Create Procedure dbo.sp_RevertAddReport
		@bcLoai int,
		@bcNgay date
	As Begin
	
		If (@bcLoai = 0) 	
		Begin
			Declare bcCursor Cursor For
			Select bName, bSoLuong From NoiDungBaoCao Where bcLoai = @bcLoai And bcNgay = bcNgay

			Declare @bName nchar(30), @bSoLuong int;
			Open bcCursor;
			Fetch Next From bcCursor into @bName, @bSoLuong;
			While (@@Fetch_Status = 0) 
			Begin
				Exec dbo.sp_RevertMakeCake @bcNgay, @bName, @bSoLuong;
				Fetch next From bcCursor into @bName, @bSoLuong;
			End;

			Close bcCursor
			Deallocate bcCursor
		End;

		Delete From dbo.NoiDungBaoCao
		Where bcLoai = @bcLoai And bcNgay = @bcNgay And bName = @bName;

	End')
Go

IF NOT EXISTS (SELECT * FROM sys.sysobjects WHERE id = OBJECT_ID(N'dbo.sp_GetRecipeIngridient') AND type = N'P')
	Exec('Create Procedure dbo.sp_GetRecipeIngridient
	As Begin
		Select nlName as [nlName], nlGia as [nlGia], nlTonKho as [nlSoLuong]
		From NguyenLieu;
	End')
GO

IF NOT EXISTS (SELECT * FROM sys.sysobjects WHERE id = OBJECT_ID(N'dbo.sp_GetCake') AND type = N'P')
	Exec('Create Procedure dbo.sp_GetCake
	As Begin
		Select * From dbo.Banh;
	End')
GO

IF NOT EXISTS (SELECT * FROM sys.sysobjects WHERE id = OBJECT_ID(N'dbo.sp_AddCake') AND type = N'P')
	Exec('Create Procedure dbo.sp_AddCake
		@bName nchar(30),
		@bGia int
	As Begin
		Insert Into dbo.Banh
		Values (@bname, @bGia);
	End')
GO

IF NOT EXISTS (SELECT * FROM sys.sysobjects WHERE id = OBJECT_ID(N'dbo.sp_AddToRecipe') AND type = N'P')
	Exec('Create Procedure dbo.sp_AddToRecipe 
		@bName nchar(30),
		@bNguyenLieu nchar(30),
		@nlDinhLuong float
	As Begin
		Insert Into dbo.CongThuc
		Values (@bName, @bNguyenLieu, @nlDinhLuong);
	End')
GO

IF NOT EXISTS (SELECT * FROM sys.sysobjects WHERE id = OBJECT_ID(N'dbo.sp_ChangePrice') AND type = N'P')
	Exec('Create Procedure dbo.sp_ChangePrice
		@bName nchar(30),
		@bGiaBan int
	As Begin
		Update dbo.Banh
		Set bGiaBan = @bGiaBan
		Where bname = @bName;
	End')
GO

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

/*
-- Syntatic checking, delete all table after creating
-- Comment following lines out for proper usage
-- Start procedure deletion
use BakeryReport;
Drop Procedure dbo.sp_RevertAddStock;
Drop Procedure dbo.sp_AddIngridient;
Drop Procedure dbo.sp_AddStock;
Drop Procedure dbo.sp_GetStockIngridient;
Drop Procedure dbo.sp_GetRecipeIngridient;
Drop Procedure dbo.sp_MakeCake;
Drop Procedure dbo.sp_RevertMakeCake;
Drop Procedure dbo.sp_RevertAddReport;
Drop Procedure dbo.sp_GetCake;
Drop Procedure dbo.sp_AddCake;
Drop Procedure dbo.sp_AddToRecipe;
Drop Procedure dbo.sp_ChangePrice;
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
use master
go
Drop database BakeryReport;
*/