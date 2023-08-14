import { Component, inject, OnInit } from '@angular/core';
import { Task } from 'src/app/Interface/task';
import { TasksService } from 'src/app/Services/tasks.service';

@Component({
  selector: 'app-active-task-list',
  templateUrl: './active-task-list.component.html',
  styleUrls: ['./active-task-list.component.css'],
  providers: [TasksService]
})
export class ActiveTaskListComponent implements OnInit{
  constructor(private tasksService: TasksService) { }

  activeTasks: Task[] = [];

  ngOnInit(): void {
    this.activeTasks = this.tasksService.getActiveTasks();
  }
  
  
    
}
