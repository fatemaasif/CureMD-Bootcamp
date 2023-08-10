import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TasklistDataComponent } from './tasklist-data.component';

describe('TasklistDataComponent', () => {
  let component: TasklistDataComponent;
  let fixture: ComponentFixture<TasklistDataComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [TasklistDataComponent]
    });
    fixture = TestBed.createComponent(TasklistDataComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
