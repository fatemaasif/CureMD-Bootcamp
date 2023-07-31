CREATE PROCEDURE GetCategory
@CatID INT
AS
BEGIN
	SELECT CategoryID, Category
	  FROM Categories
	  WHERE CategoryID=@CatID
END
GO


