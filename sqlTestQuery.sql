Use BakeryReport;
Go

Declare @d DATE, @nlName nchar(30), @bName nchar(30), @gia int, @soluong float;
Set @d = GETDATE();
Set @nlName = N'Nguyên liệu2';
Set @bName = N'Bánh2';
Set @gia = 250000;
Set @soluong = 5;

-- Test insert NguyenLieu
Insert into dbo.NguyenLieu
Values (@nlName, @gia, @soluong);

-- Test insert Banh
Insert into dbo.Banh
Values (@bName);

-- Test insert dbo.CongThuc
Insert Into dbo.CongThuc
Values (@bName, @nlName, 3);

-- Test MakeCake
Exec [dbo].sp_MakeCake @d, @bName, 1;

--Exec [dbo].[sp_AddStock] @tkNgay=@d,@nlName=@name,@nlGia=@gia,@nlSoLuong=@soluong;
--Exec [dbo].[sp_RevertAddStock] @nxNgay=@d,@nlName=@name;
Go

Select * From dbo.NguyenLieu;
Select * From dbo.CongThuc;
Select * From dbo.TonKho;
Select * From dbo.NoiDungNhapXuat;