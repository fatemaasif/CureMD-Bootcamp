CREATE PROCEDURE GetUser
@Username VARCHAR(50),
@PassWd VARCHAR(50)

AS
BEGIN 

SELECT Username, PassWd, Email
FROM Users
WHERE Username=@Username AND PassWd=@PassWd

END
GO