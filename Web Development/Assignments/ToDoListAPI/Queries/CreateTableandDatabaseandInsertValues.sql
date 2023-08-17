BEGIN TRY
    -- Check if the database exists
    IF NOT EXISTS (SELECT name FROM sys.databases WHERE name = 'ToDoListManager')
    BEGIN
        -- Create the database ToDoListManager
        CREATE DATABASE ToDoListManager;
    END

    -- Use the ToDoListManager database
    USE ToDoListManager;

    -- Check if the table ToDoList exists
    IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'dbo.ToDoList') AND type = 'U')
    BEGIN
        -- Create the ToDoList table
        CREATE TABLE ToDoList (
            TaskTitle VARCHAR(100),
            Completed BIT DEFAULT 0,
            TimeToCompletion INT,
            EditMode BIT DEFAULT 0,
            TaskCategory VARCHAR(20)
        );
    END

    -- Insert data into the ToDoList table
    INSERT INTO ToDoList (TaskTitle, Completed, TimeToCompletion, TaskCategory)
    VALUES
        ('TaskOne', 0, -1, 'Test Category'),
        ('TaskTwo', 0, -1, 'Test Category'),
        ('TaskThree', 1, 0, 'Test Category'),
        ('TaskFour', 1, 0, 'Test Category'),
        ('TaskFive', 1, 0, 'Test Category');
        
END TRY
BEGIN CATCH
    -- Handle exceptions here, if needed
    PRINT 'An error occurred: ' + ERROR_MESSAGE();
END CATCH;
