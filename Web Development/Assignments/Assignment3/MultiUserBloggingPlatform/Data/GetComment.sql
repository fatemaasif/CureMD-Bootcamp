CREATE PROCEDURE GetComment
@CID INT
AS
BEGIN
	SELECT CommentID,CommentText,UserID,PostID,Username,PostTitle
	  FROM Comments
	  WHERE CommentID=@CID;
END
GO


