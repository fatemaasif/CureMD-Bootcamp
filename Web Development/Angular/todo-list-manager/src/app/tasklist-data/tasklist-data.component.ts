import { Component, Input} from '@angular/core';

@Component({
  selector: 'app-tasklist-data',
  templateUrl: './tasklist-data.component.html',
  styleUrls: ['./tasklist-data.component.css']
})
export class TasklistDataComponent {
  @Input() totalTasks?: number;
  @Input() tasksCompleted: number = 0;
}
