import { Component, EventEmitter, Inject, Output } from '@angular/core';
import { MatDialog, MAT_DIALOG_DATA, MatDialogRef, MatDialogModule } from '@angular/material/dialog';
import { FormsModule } from '@angular/forms';
import { Task } from 'src/app/Interface/task';
import { TasksService } from 'src/app/Services/tasks.service';

@Component({
  selector: 'app-task-adder-dialog',
  templateUrl: './task-adder-dialog.component.html',
  styleUrls: ['./task-adder-dialog.component.css']
})
export class TaskAdderDialogComponent {
  constructor(
    public dialogRef: MatDialogRef<TaskAdderDialogComponent>,
    @Inject(MAT_DIALOG_DATA) public data: Task,
    public tasksService: TasksService
  ) { }

  onNoClick(): void {
    this.dialogRef.close();
  }
  onOkayClick(tasktitle:string,taskTime:string) {
    if (taskTime==='0'||taskTime===''){taskTime='-1'}
    const newTask:Task = {title:tasktitle, completed:false, timeToCompletion:Number(taskTime)}
    this.tasksService.addTask(newTask);
    this.tasksService.updateWithNewTasks(this.tasksService.getTasks());
  }
}
