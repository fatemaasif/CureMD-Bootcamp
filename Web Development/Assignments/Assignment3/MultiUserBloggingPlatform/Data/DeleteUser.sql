CREATE PROCEDURE DeleteUser
@UID INT,
@Username VARCHAR(50)

AS
BEGIN 
DELETE FROM Users
WHERE UserID=@UID OR Username=@Username
END
GO