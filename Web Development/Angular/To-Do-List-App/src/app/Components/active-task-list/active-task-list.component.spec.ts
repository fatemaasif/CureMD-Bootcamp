import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ActiveTaskListComponent } from './active-task-list.component';

describe('ActiveTaskListComponent', () => {
  let component: ActiveTaskListComponent;
  let fixture: ComponentFixture<ActiveTaskListComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [ActiveTaskListComponent]
    });
    fixture = TestBed.createComponent(ActiveTaskListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
