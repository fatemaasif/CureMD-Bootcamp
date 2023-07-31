CREATE PROCEDURE GetPostsByUser
@UID INT
AS
	SELECT Users.Username, Posts.PostText
	FROM Users
	RIGHT JOIN Posts
	ON Users.UserID=Posts.UserID
	WHERE Users.UserID = @UID
GO