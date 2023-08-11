import { Component, ElementRef, EventEmitter, Output, ViewChild } from '@angular/core';
import { Task } from '../task';

@Component({
  selector: 'app-task-form',
  templateUrl: './task-form.component.html',
  styleUrls: ['./task-form.component.css']
})


export class TaskFormComponent{
  @Output() taskAdded = new EventEmitter<Task>();
  @ViewChild('taskInput', {static:false}) taskInput!:ElementRef<HTMLInputElement>;

  addTask(inputElement: HTMLInputElement) {
    let newTaskTitle= inputElement.value.trim();
    if (newTaskTitle) {
      const newTask: Task = {
        title: newTaskTitle,
        completed: false
      };
      this.taskAdded.emit(newTask);
      inputElement.value = '';
    }
  }
  
}
