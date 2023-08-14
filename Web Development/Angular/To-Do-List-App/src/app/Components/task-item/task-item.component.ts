import { Component,Input } from '@angular/core';
import { Task } from 'src/app/Interface/task';

@Component({
  selector: 'app-task-item',
  templateUrl: './task-item.component.html',
  styleUrls: ['./task-item.component.css']
})
export class TaskItemComponent {
@Input() tasklist: Task[] = [];
@Input() listType!: 'active' | 'completed';
invertComplete(task:Task){
  task.completed = !task.completed;
}
toggleEditMode(task:Task){
  task.editMode=!task.editMode;
}
saveTask(task:Task, newTitle:string){
  task.title=newTitle;
  task.editMode = false;
}
cancelEdit(task:Task){
  task.editMode = false;
}
}
