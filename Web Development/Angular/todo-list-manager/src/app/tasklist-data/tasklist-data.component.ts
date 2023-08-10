import { Component, Input, OnChanges, SimpleChanges } from '@angular/core';

@Component({
  selector: 'app-tasklist-data',
  templateUrl: './tasklist-data.component.html',
  styleUrls: ['./tasklist-data.component.css']
})
export class TasklistDataComponent implements OnChanges{
  @Input() tasknum: number=0;

  total: number = 0;
  tasksCompleted: number = 0;

  ngOnChanges(changes: SimpleChanges) {
    if (changes['tasknum']) {
      this.total = changes['tasknum'].currentValue;
    }
  }
}
