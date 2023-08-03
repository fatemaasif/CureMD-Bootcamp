CREATE PROCEDURE GetAllStudents
AS
BEGIN
SELECT [ID]
      ,[FirstName]
      ,[LastName]
      ,[Age]
      ,[Course]
  FROM [4828-IntellisenseStudents].[Students]
END
GO


