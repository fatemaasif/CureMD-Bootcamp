import { Injectable } from '@angular/core';
import { Task } from '../Interface/task';
import { BehaviorSubject, Observable } from 'rxjs';
import { ToastrService } from 'ngx-toastr';


@Injectable({
  providedIn: 'root'
})
export class TasksService {
  public tasks: Task[]=[
    {
      'title': 'TaskOne',
      'completed': false,
      timeToCompletion:-1
    },
    {
      'title': 'TaskTwo',
      'completed': false,
      timeToCompletion:-1
    },
    {
      'title': 'TaskThree',
      'completed': true,
      timeToCompletion:0
    },
    {
      'title': 'TaskFour',
      'completed': true,
      timeToCompletion:0
    },
    {
      'title': 'TaskFive',
      'completed': true,
      timeToCompletion:0
    }
  ];
  private tasksSubject = new BehaviorSubject<Task[]>(this.tasks);
  constructor(private toastr: ToastrService) { }
  //get tasks as an observable
  get tasksObservable(): Observable<Task[]> {
    return this.tasksSubject.asObservable();
  }
  getTasks():Task[]{
    return this.tasks;
  }
  //add tasks
  addTask(task: Task):void{
    this.tasks.push({title:task.title,completed:false, timeToCompletion:task.timeToCompletion});
    this.toastr.success('Task Added', 'Your task has been added succesfully!');
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
    return this.getActiveTasks().length;
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
    return this.getCompletedTasks().length;
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
  //set all to complete
  setAllTasksToComplete():void{
    this.tasks.forEach(task => {
      task.completed=true;
    });
  }
}
