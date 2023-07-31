CREATE PROCEDURE GetPost
@PID INT
AS
BEGIN
	SELECT PostID,
		   PostText,
		   CategoryID,
		   UserID,
		   PostTitle,
		   Username
	  FROM Posts
	  WHERE PostID=@PID
END
GO


