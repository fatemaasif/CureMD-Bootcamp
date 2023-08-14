import { Injectable } from '@angular/core';
import { Task } from '../Interface/task';
import { BehaviorSubject, Observable } from 'rxjs';


@Injectable({
  providedIn: 'root'
})
export class TasksService {
  public tasks: Task[]=[
    {
      'title': 'TaskOne',
      'completed': false
    },
    {
      'title': 'TaskTwo',
      'completed': false
    },
    {
      'title': 'TaskThree',
      'completed': true
    },
    {
      'title': 'TaskFour',
      'completed': true
    },
    {
      'title': 'TaskFive',
      'completed': true
    }
  ];
  private tasksSubject = new BehaviorSubject<Task[]>(this.tasks);
  constructor() { }
  //get tasks as an observable
  get tasksObservable(): Observable<Task[]> {
    return this.tasksSubject.asObservable();
  }
  getTasks():Task[]{
    return this.tasks;
  }
  //add tasks
  addTask(task: Task):void{
    this.tasks.push({title:task.title,completed:false});
  }
  //get number of total tasks
  getTotalTaskCount():number{
    return this.tasks.length;
  }
  //obtain array of active tasks to be shown in active task list
  getActiveTasks() : Task[] {
    let activeTasks:Task[] = [];
    this.tasks.forEach(task => {
      if(task.completed==false){
        activeTasks.push(task);
      }
    });
    return activeTasks;
  }
  //get count of active tasks
  getNumberofActiveTasks():number{
    return this.getActiveTasks.length;
  }
  //obtain array of completed tasks to be shown in completed task list
  getCompletedTasks() : Task[] {
    let completedTasks:Task[] = [];
    this.tasks.forEach(task => {
      if(task.completed==true){
        completedTasks.push(task);
      }
    });
    return completedTasks;
  }
  //get count of completed tasks
  getNumberofCompletedTasks():number{
    return this.getCompletedTasks.length;
  }
  //update the task lists
  updateTasks(taskList1: Task[], taskList2: Task[]) {
    taskList1.forEach(updatedTask => {
      const originalTaskIndex = this.tasks.findIndex(t => t.title === updatedTask.title);
      if (originalTaskIndex !== -1) {
        this.tasks[originalTaskIndex].completed = updatedTask.completed;
      }
    });
    taskList2.forEach(updatedTask => {
      const originalTaskIndex = this.tasks.findIndex(t => t.title === updatedTask.title);
      if (originalTaskIndex !== -1) {
        this.tasks[originalTaskIndex].completed = updatedTask.completed;
      }
    });
  }
  //update
  updateWithNewTasks(newTasks: Task[]): void {
    this.tasks = newTasks;
    this.tasksSubject.next(this.tasks); // Emit the updated tasks array
  }
}
