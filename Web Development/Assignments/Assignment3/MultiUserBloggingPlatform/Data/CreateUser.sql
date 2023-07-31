CREATE PROCEDURE CreateUser
@Username VARCHAR(50),
@PassWd VARCHAR(50),
@Email VARCHAR(100)

AS
BEGIN 

INSERT INTO Users(Username, PassWd, Email)
VALUES(@Username,@PassWd,@Email)

END
GO