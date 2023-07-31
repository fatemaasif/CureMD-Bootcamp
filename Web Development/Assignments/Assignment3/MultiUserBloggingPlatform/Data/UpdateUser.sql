CREATE PROCEDURE UpdateUser
    @UID INT,
    @Username VARCHAR(50),
    @PassWd VARCHAR(50),
    @Email VARCHAR(100)
AS
BEGIN
    UPDATE Users
    SET Username = @Username,
        PassWd = @PassWd,
        Email = @Email
    WHERE UserID = @UID;
END;
GO