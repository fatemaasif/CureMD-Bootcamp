import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TaskAdderDialogComponent } from './task-adder-dialog.component';

describe('TaskAdderDialogComponent', () => {
  let component: TaskAdderDialogComponent;
  let fixture: ComponentFixture<TaskAdderDialogComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [TaskAdderDialogComponent]
    });
    fixture = TestBed.createComponent(TaskAdderDialogComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
