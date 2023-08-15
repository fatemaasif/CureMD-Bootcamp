import { Component, Input} from '@angular/core';
import { CdkDragDrop,
  moveItemInArray,
  transferArrayItem,
  CdkDrag,
  CdkDropList } from '@angular/cdk/drag-drop';
import { TasksService } from 'src/app/Services/tasks.service';
import { Task } from 'src/app/Interface/task';
import { interval } from 'rxjs';

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
    interval(1000).subscribe(() => {
      this.updateTaskStatus();
    });
  }

  ngDoCheck(): void {
    this.activeTasks = this.tasksService.getActiveTasks();
    this.completedTasks = this.tasksService.getCompletedTasks();
  }

  //method to handle drag drop events in the list
  drop(event: CdkDragDrop<Task[]>) {
    if (event.previousContainer === event.container) {
      moveItemInArray(event.container.data, event.previousIndex, event.currentIndex);
    }
    else {
      transferArrayItem(event.previousContainer.data, event.container.data, event.previousIndex, event.currentIndex);
      //toggles the complete state of the event
      event.container.data[event.currentIndex].completed=!event.container.data[event.currentIndex].completed;
    }
  };

  //update the tasks from the event emitter output
  updateService(modifiedTasks:Task[]){
    this.tasks=modifiedTasks;
  }

  updateTaskStatus() {
    const tasks = this.tasksService.getTasks();
    tasks.forEach(task => {
      if (task.completed || task.timeToCompletion === 0) {
        task.completed = true;
      }
      if (!task.completed) {
        task.timeToCompletion--; // Decrement the time remaining
      }
    });
    this.tasksService.updateWithNewTasks(tasks);
  }
}
