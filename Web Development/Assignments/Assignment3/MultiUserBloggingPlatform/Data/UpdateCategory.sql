CREATE PROCEDURE UpdateCategory
@CatID int,
@CatText VARCHAR(100)
AS
BEGIN
	UPDATE Categories
	SET 
	Category=@CatText
	WHERE CategoryID = @CatID
END
GO