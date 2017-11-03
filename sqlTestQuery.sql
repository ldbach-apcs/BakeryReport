Use BakeryReport;
Go

Declare @d DATE, @nlName nchar(30), @bName nchar(30), @gia int, @soluong float;
Set @d = GETDATE();
Set @nlName = N'Nguyên liệu';
Set @bName = N'Bánh';
Set @gia = 250000;
Set @soluong = 5;

-- Test insert NguyenLieu
Insert into dbo.NguyenLieu
Values (@nlName, @gia, @soluong), (N'Nguyên liệu 2', 10, 5);
	
-- Test insert Banh
Insert into dbo.Banh
Values (@bName, 20000);

-- Test insert dbo.CongThuc
Insert Into dbo.CongThuc
Values (@bName, @nlName, 3), (@bName, N'Nguyên liệu 2', 2);

-- Test MakeCake
Exec [dbo].sp_AddReport @d, 0, @bName, 1;


Exec [dbo].[sp_AddStock]@d,@nlName,@gia,@soluong;
--Exec [dbo].[sp_RevertAddStock] @nxNgay=@d,@nlName=@name;

--Select * From dbo.NguyenLieu;
--Select * From dbo.CongThuc;
--Select * From dbo.TonKho;
--Select * From dbo.NoiDungNhapXuat
--Select * From dbo.NoiDungBaoCao;

Exec dbo.sp_RevertAddReport 0, @d;

Go
Exec dbo.sp_AddIngridient N'Trứng', 2200, 5;

Select * From dbo.NguyenLieu;
Select * From dbo.TonKho;
Select * From dbo.NoiDungNhapXuat