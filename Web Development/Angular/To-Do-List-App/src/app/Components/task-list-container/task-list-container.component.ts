import { Component, Input, OnChanges, ViewChild } from '@angular/core';
import { CdkDragDrop,
  moveItemInArray,
  transferArrayItem,
  CdkDrag,
  CdkDropList } from '@angular/cdk/drag-drop';
import { TasksService } from 'src/app/Services/tasks.service';
import { Task } from 'src/app/Interface/task';

@Component({
  selector: 'app-task-list-container',
  templateUrl: './task-list-container.component.html',
  styleUrls: ['./task-list-container.component.css']
})
export class TaskListContainerComponent{
  constructor(public tasksService: TasksService) { }
  @Input() title: string = '';
  @Input() listType!: 'active' | 'completed';

  tasks:Task[]=[];
  activeTasks: Task[] = [];
  completedTasks: Task[] = [];

  ngOnInit(): void {
    this.tasksService.tasksObservable.subscribe(updatedTasks => {
      this.tasks = updatedTasks;
    });
  }

  ngDoCheck(): void {
    this.activeTasks = this.tasksService.getActiveTasks();
    this.completedTasks = this.tasksService.getCompletedTasks();
  }

  drop(event: CdkDragDrop<Task[]>) {
    if (event.previousContainer === event.container) {
      moveItemInArray(event.container.data, event.previousIndex, event.currentIndex);
    }
    else {
      transferArrayItem(event.previousContainer.data, event.container.data, event.previousIndex, event.currentIndex);
      //toggles the complete state of the event
      event.container.data[event.currentIndex].completed=!event.container.data[event.currentIndex].completed;
    }
    this.updateTasksService(event.container.data, event.previousContainer.data);
  };

  updateTasksService(taskList1:Task[],taskList2:Task[]):void{
    this.tasksService.updateTasks(taskList1,taskList2);
    this.activeTasks = this.tasksService.getActiveTasks();
    this.completedTasks = this.tasksService.getCompletedTasks();
  }
  updateService(modifiedTasks:Task[]){
    this.tasks=modifiedTasks;
  }
}
