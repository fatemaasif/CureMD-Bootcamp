CREATE PROCEDURE GetPostWithComments
@PID INT
AS
	SELECT Posts.PostText,Comments.CommentText
	FROM Posts
	INNER JOIN Comments
	ON Posts.PostID = Comments.PostID
	WHERE Posts.PostID=@PID;
GO