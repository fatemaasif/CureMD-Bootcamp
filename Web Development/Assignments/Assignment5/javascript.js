$(document).ready(function(){
    var taskList = [];

    //event handler for add task button
    $('#addTaskButn').click(function(){addTask();});
    //event handler for task property changed to completed
    $('#taskList').on('change','.taskCheckbox',function(){
        var index = $('.taskCheckbox').index(this);
        taskList[index].completed=this.checked;
        displayTasks();
    });
    //event handler for task deletion
    $(document).on('click', '.deleteTask', function() {
        var index = $(this).parent().index();
        taskList.splice(index, 1);
        displayTasks();
      });


    //function to add tasks
    function addTask(){
        var taskText = $('#taskInput').val();
        if (taskText !== ''){
            taskList.push({
                text: taskText,
                completed: false
            });
            displayTasks();
            $('#taskInput').val('');
        }
    }

    //function to update counter for the completed tasks
    function updateCounter(){
        var completedTasks = taskList.filter(task=>task.completed);
        $('#completedCounter').text(completedTasks.length);
    }

    //function to display tasks
    function displayTasks(){
        $('#taskList').empty();
        taskList.forEach((task) => {
            var taskItem = $('<li><input type="checkbox" class="taskCheckbox">' + task.text + '<span class="deleteTask"> &#10005;</span></li>');
            taskItem.find('.taskCheckbox').prop('checked', task.completed);
            if (task.completed) {
                taskItem.addClass('completed');
              }
            $('#taskList').append(taskItem);
        });
        updateCounter();
    }
    
});