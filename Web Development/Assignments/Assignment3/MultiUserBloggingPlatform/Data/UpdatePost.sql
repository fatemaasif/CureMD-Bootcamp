USE [4828-BlogDB]
GO

CREATE PROCEDURE UpdatePost
@PID INT,
@PText varchar(500),
@CatID INT,
@UID INT,
@PTitle VARCHAR(100),
@Username VARCHAR(50)
AS
BEGIN
	UPDATE [dbo].[Posts]
	   SET PostText=@PText,
		   CategoryID = @CatID,
		   UserID=@UID,
		   PostTitle=@PTitle,
		   Username=@Username
			
	 WHERE PostID=@PID
END
GO




