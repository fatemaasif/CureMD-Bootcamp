USE [4828-BlogDB]
GO
CREATE PROCEDURE CreatePost
@PText varchar(500),
@CatID int,
@UID int,
@PTitle varchar(100),
@Username varchar(50)
AS
BEGIN
INSERT INTO Posts(PostText,CategoryID,UserID,PostTitle,Username)
     VALUES
			(@PText,
			@CatID,
			@UID,
			@PTitle,
			@Username)
END
GO


