import { CdkDragDrop } from '@angular/cdk/drag-drop';
import { Component, Inject, Input, Output, OnInit, EventEmitter } from '@angular/core';
import { Task } from 'src/app/Interface/task';
import { TasksService } from 'src/app/Services/tasks.service';

@Component({
  selector: 'app-active-task-list',
  templateUrl: './active-task-list.component.html',
  styleUrls: ['./active-task-list.component.css'],
  providers: [TasksService],
})
export class ActiveTaskListComponent implements OnInit {

  constructor(private tasksService: TasksService) { }
  @Input() activeTasks: Task[] = [];
  @Output() taskDropped: EventEmitter<CdkDragDrop<Task[]>> = new EventEmitter<CdkDragDrop<Task[]>>();
  @Output() taskAddedinActiveTasks = new EventEmitter<Task[]>

  ngOnInit(): void {
    this.activeTasks = this.tasksService.getActiveTasks();
  }

  updateService(tasks:Task[]){
    this.taskAddedinActiveTasks.emit(tasks);
  }

}
