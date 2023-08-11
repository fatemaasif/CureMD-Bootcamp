import { Component, EventEmitter, Input, Output } from '@angular/core';
import { Task } from '../task';

@Component({
  selector: 'app-task-item',
  templateUrl: './task-item.component.html',
  styleUrls: ['./task-item.component.css']
})
export class TaskItemComponent {
  @Input() task?: Task;
  @Output() taskDeleted = new EventEmitter<Task>();
  @Output() taskCompleted = new EventEmitter<Task>();

  deleteTask(task:Task){
    this.taskDeleted.emit(task);
  }

  checkboxChange(task: Task){
    task.completed = !task.completed;
    this.taskCompleted.emit(task);
  }
}
