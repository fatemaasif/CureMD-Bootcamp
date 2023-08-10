import { Component, EventEmitter, Output } from '@angular/core';
import { Task } from '../task';

@Component({
  selector: 'app-task-form',
  templateUrl: './task-form.component.html',
  styleUrls: ['./task-form.component.css']
})


export class TaskFormComponent{
  @Output() taskAdded = new EventEmitter<Task>();

  addTask(newTaskTitle: string) {
    if (newTaskTitle.trim()) {
      const newTask: Task = {
        title: newTaskTitle,
        completed: false
      };
      this.taskAdded.emit(newTask);
      newTaskTitle='';
    }
  }
  
}
