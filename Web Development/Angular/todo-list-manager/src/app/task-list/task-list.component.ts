import { Component, Input  } from '@angular/core';
import { Task } from "../task";

@Component({
  selector: 'app-task-list',
  templateUrl: './task-list.component.html',
  styleUrls: ['./task-list.component.css']
})

export class TaskListComponent{
  tasks: Task[] = [];
  totaltasks:number=0;
  completedTasks:number=0;

  handleTaskAdded(newTask:Task){
    this.tasks.push(newTask);
    this.totaltasks++;
  }

  handleTaskDeleted(task: Task) {
    const index = this.tasks.indexOf(task);
    if (index !== -1) {
      this.tasks.splice(index, 1);
      this.totaltasks--;
    }
  }

  handleTaskCompleted(task:Task){
    this.completedTasks=0;
    this.tasks.forEach(task => {
      if(task.completed){
        this.completedTasks++;
      }
    });
  }
}
