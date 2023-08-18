IF EXISTS (SELECT 1 FROM sys.procedures WHERE OBJECT_ID = OBJECT_ID(N'[dbo].[GetStudentById]'))
    DROP PROCEDURE GetStudentById;
GO

CREATE PROCEDURE GetStudentById
    @Id INT
AS
BEGIN
    SELECT Id, FirstName, LastName, Address, Age, PhoneNo
    FROM [4099_Student]
    WHERE Id = @Id;
END
