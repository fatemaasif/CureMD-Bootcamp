CREATE PROCEDURE DeleteComment
@CId INT
AS
BEGIN
DELETE FROM Comments
      WHERE CommentID=@CId
END
GO