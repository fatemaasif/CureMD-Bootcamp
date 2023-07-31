CREATE PROCEDURE CreateCategory
@CatText varchar(100)
AS
BEGIN
	INSERT INTO Categories(Category)
	VALUES (@CatText)
           
END
GO


