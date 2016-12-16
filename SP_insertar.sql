ALTER PROC InsertarProducto
@ProductName VARCHAR(100),
@Description VARCHAR(255),
@Price DECIMAL(18,0)
AS

	INSERT INTO dbo.Product(ProductName, ProductDesc, Price) 
		VALUES (@ProductName, @Description, @Price);

	SELECT SCOPE_IDENTITY() AS [SCOPE_IDENTITY]

GO

ALTER PROC ActualizarProducto
@ProductID INT,
@ProductName VARCHAR(100),
@Description VARCHAR(255),
@Price DECIMAL(18,0)
AS

	UPDATE [dbo].[Product] 
		SET [ProductName] = @ProductName
			,[ProductDesc] = @Description
			,[price] = @Price
		WHERE 
			[ProductoID] = @ProductID

GO

ALTER PROC EliminarProducto
@ProductID INT
AS

	DELETE FROM [dbo].[Product]
		WHERE [ProductoID] = @ProductID

GO

ALTER PROC ListarProductos
@maxElements INT,
@offset INT
AS

	SELECT [ProductoID]
		  ,[ProductName]
		  ,[ProductDesc]
		  ,[price]
	  FROM [dbo].[Product]
	  ORDER BY [ProductoID]
	  OFFSET @offset ROWS
	  FETCH NEXT @maxElements ROWS ONLY;

GO

CREATE PROC ObtenerProducto
@ProductID INT
AS

	SELECT * FROM  [dbo].[Product] 
		WHERE [ProductoID] = @ProductID;

GO
