CREATE PROCEDURE CreateComment
@CText varchar(500),
@UID int,
@PID int,
@Username varchar(50),
@PTitle varchar(100)
AS
BEGIN
	INSERT INTO Comments
	(CommentText,
	UserID,
	PostID,
	Username,
	PostTitle)
           
	VALUES (@CText,@UID,@PID,@Username,@PTitle)
           
END

GO


