USE [4828-BlogDB]
GO

/****** Object:  StoredProcedure [dbo].[UpdateComment]    Script Date: 7/31/2023 3:27:48 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[UpdateComment]
	  @CID INT,
	  @CText varchar(200),
      @UID int,
      @PID int,
      @Username varchar(50),
      @Title varchar(100)
AS
BEGIN
	UPDATE Comments
	   SET 
			CommentText=@CID,
			UserID =@UID,
			PostID =@PID,
			Username =@Username,
			PostTitle =@Title
	 WHERE CommentID=@CID
END
GO


