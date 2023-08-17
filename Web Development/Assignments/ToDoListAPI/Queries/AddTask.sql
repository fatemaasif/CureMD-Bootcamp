CREATE PROCEDURE AddTask
    @TaskTitle VARCHAR(100),
    @TimeToCompletion INT,
    @TaskCategory VARCHAR(20)
AS
BEGIN
    INSERT INTO ToDoList (TaskTitle, TimeToCompletion, TaskCategory)
    VALUES (@TaskTitle, @TimeToCompletion, @TaskCategory);
END
GO