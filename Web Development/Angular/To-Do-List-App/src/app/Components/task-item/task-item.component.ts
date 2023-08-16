import { Component, Input } from '@angular/core';
import { Task } from 'src/app/Interface/task';
import {ThemePalette} from '@angular/material/core';
import {ProgressSpinnerMode, MatProgressSpinnerModule} from '@angular/material/progress-spinner';


@Component({
  selector: 'app-task-item',
  templateUrl: './task-item.component.html',
  styleUrls: ['./task-item.component.css']
})
export class TaskItemComponent {
  @Input() tasklist: Task[] = [];
  @Input() listType!: 'active' | 'completed';

  //for the progress spinner
  color: ThemePalette = 'primary';
  mode: ProgressSpinnerMode = 'determinate';

  //when checkbox clicked
  inversionHappening: boolean = false;
  invertComplete(task: Task) {
    this.inversionHappening = true; //when state of the box changes
    task.completed = !task.completed;
    //if itentionally set to incomplete - reset the time to completion
    task.timeToCompletion = -1;
    //for the transition
    const transitionDuration = 1000 //ms
    
  }

  toggleEditMode(task: Task) {
    task.editMode = !task.editMode;
  }
  saveTask(task: Task, newTitle: string) {
    task.title = newTitle;
    task.editMode = false;
  }
  cancelEdit(task: Task) {
    task.editMode = false;
  }
}
