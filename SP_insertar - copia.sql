ALTER PROC InsertarProducto
@ProductID INT OUT,
@ProductName VARCHAR(100),
@Description VARCHAR(255),
@Price DECIMAL(18,0)
AS

	INSERT INTO dbo.Product(ProductName, ProductDesc, Price) VALUES (@ProductName, @Description, @Price);
	SET @ProductID = SCOPE_IDENTITY();
GO

alter proc ActualizarProducto
@result bit out,
@ProductID int,
@ProductName varchar(100),
@Description varchar(255),
@Price decimal(18,0)
as

set @result = 0;

begin transaction

begin try

UPDATE [dbo].[Product] 
   SET [ProductName] = @ProductName
      ,[ProductDesc] = @Description
      ,[price] =@Price
 WHERE 
	[ProductoID] = @ProductID

  commit transaction
  set @result = 1;

end try

begin catch
  raiserror('Message here', 16, 1)
  rollback transaction
end catch

go

create proc EliminarProducto
@result bit out,
@ProductID int
as
set @result = 0;

begin transaction
begin try
	DELETE FROM [dbo].[Product]
		WHERE [ProductoID] = @ProductID

	commit transaction
	set @result = 1;
end try

begin catch
  raiserror('Message here', 16, 1)
  rollback transaction
end catch
go

