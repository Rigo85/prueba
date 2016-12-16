use warehouse
go
declare @_ProductID int
exec InsertarProducto @ProductName = "producto1", @Description = "sassasasa", @Price = 12.434, @ProductID = @_ProductID out
declare @_result bit

--exec ActualizarProducto 
--@ProductID = 1, 
--@ProductName = "producto1",
--@Description = "descripción 1",
--@Price = 20.3,
--@result = @_result out

--exec EliminarProducto @ProductID = 1, @result = @_result out 

go

