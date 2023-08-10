import { Component } from '@angular/core';
import { Task } from './task';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'To-Do List Manager';

  tasks: Task[]=[];

  handleTaskAdded(newTask:Task){
    this.tasks.push(newTask);
    console.log(this.tasks.length);
  }
  tasksTotal:number = this.tasks.length;
  
}
