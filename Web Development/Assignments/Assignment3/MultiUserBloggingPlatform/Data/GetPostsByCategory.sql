CREATE PROCEDURE GetPostsByCategory
@CID INT
AS
	SELECT Categories.Category, Posts.PostText
	FROM Categories
	RIGHT JOIN Posts
	ON Categories.CategoryID = Posts.CategoryID
	WHERE Categories.CategoryID = @CID
GO