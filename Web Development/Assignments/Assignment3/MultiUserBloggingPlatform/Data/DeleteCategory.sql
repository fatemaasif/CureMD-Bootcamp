CREATE PROCEDURE DeleteCategory
@CatId INT
AS
BEGIN
DELETE FROM Categories
      WHERE CategoryID=@CatId
END
GO