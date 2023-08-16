import { Component, OnInit, OnChanges } from '@angular/core';
import { TasksService } from 'src/app/Services/tasks.service';

@Component({
  selector: 'app-task-data',
  templateUrl: './task-data.component.html',
  styleUrls: ['./task-data.component.css']
})
export class TaskDataComponent{
  constructor(public tasksService:TasksService){}
  completedTasks:number = 0;
  activeTasks:number = 0;
  
  ngOnInit():void{
    this.completedTasks=this.tasksService.getNumberofCompletedTasks();
    this.activeTasks=this.tasksService.getNumberofActiveTasks();
  }

  setAllTasksToComplete():void{
    this.tasksService.setAllTasksToComplete();
  }
}
