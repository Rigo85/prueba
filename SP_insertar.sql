ALTER PROC InsertarProducto
@ProductName VARCHAR(100),
@Description VARCHAR(255),
@Price DECIMAL(18,5),
@Active BIT
AS

	INSERT INTO dbo.Product(ProductName, ProductDesc, Price, Active) 
		VALUES (@ProductName, @Description, @Price, @Active);

	SELECT SCOPE_IDENTITY() AS [SCOPE_IDENTITY]

GO

ALTER PROC ActualizarProducto
@ProductID INT,
@ProductName VARCHAR(100),
@Description VARCHAR(255),
@Price DECIMAL(18,5),
@Active BIT
AS

	UPDATE [dbo].[Product] 
		SET [ProductName] = @ProductName
			,[ProductDesc] = @Description
			,[Price] = @Price
			,[Active] = @Active
		WHERE 
			[ProductoID] = @ProductID

GO

ALTER PROC EliminarProducto
@ProductID INT
AS

	UPDATE [dbo].[Product] 
		SET [Active] = 0
		WHERE 
			[ProductoID] = @ProductID

GO

ALTER PROC ListarProductos
@maxElements INT,
@offset INT
AS

	SELECT [ProductoID]
		  ,[ProductName]
		  ,[ProductDesc]
		  ,[Price]
		  ,[Active]
	  FROM [dbo].[Product]
	  WHERE [Active] = 1
	  ORDER BY [ProductoID]
	  OFFSET @offset ROWS
	  FETCH NEXT @maxElements ROWS ONLY;

GO

ALTER PROC ObtenerProducto
@ProductID INT
AS

	SELECT * FROM  [dbo].[Product] 
		WHERE [ProductoID] = @ProductID 
		AND [Active] = 1;

GO
