CREATE PROCEDURE UpdateTask
@NewTaskTitle VARCHAR(100),
@TaskTitle VARCHAR(100)
AS
BEGIN
UPDATE ToDoList
SET TaskTitle=@NewTaskTitle
WHERE TaskTitle=@TaskTitle
END;
GO
