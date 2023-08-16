import { CdkDragDrop } from '@angular/cdk/drag-drop';
import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { Task } from 'src/app/Interface/task';
import { TasksService } from 'src/app/Services/tasks.service';

@Component({
  selector: 'app-completed-task-list',
  templateUrl: './completed-task-list.component.html',
  styleUrls: ['./completed-task-list.component.css'],
  providers: [TasksService]
})
export class CompletedTaskListComponent implements OnInit{
  constructor(private tasksService: TasksService){};

  @Input() completedTasks: Task[] = []
  @Output() taskDropped: EventEmitter<CdkDragDrop<Task[]>> = new EventEmitter<CdkDragDrop<Task[]>>();

  ngOnInit(): void {
    this.completedTasks=this.tasksService.getCompletedTasks();
  }
  
}
