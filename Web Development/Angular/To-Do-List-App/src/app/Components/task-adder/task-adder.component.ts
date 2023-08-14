import { Component, EventEmitter, Output } from '@angular/core';
import { TasksService } from 'src/app/Services/tasks.service';
import { TaskAdderDialogComponent } from '../task-adder-dialog/task-adder-dialog.component';
import { Task } from 'src/app/Interface/task';
import { MatDialog, MAT_DIALOG_DATA, MatDialogRef, MatDialogModule } from '@angular/material/dialog';

@Component({
  selector: 'app-task-adder',
  templateUrl: './task-adder.component.html',
  styleUrls: ['./task-adder.component.css']
})
export class TaskAdderComponent {
  constructor(public tasksService: TasksService, public dialog: MatDialog) { }
  @Output() taskAdded = new EventEmitter<Task[]>(); 
  task: Task = { title: '', completed: false };

  addTask() {
    this.openDialog();
  }
  taskTitle: string = '';
  timeToExpiry: number = 0;

  openDialog(): void {

    const dialogRef = this.dialog.open(TaskAdderDialogComponent, {
      data: { title: this.taskTitle, completed: false, timeToCompletion: this.timeToExpiry },
    });

    dialogRef.afterClosed().subscribe(result => {
      console.log('The dialog was closed');
      this.taskAdded.emit(this.tasksService.getTasks());
    });
  }

  

}


