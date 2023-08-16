import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MaterialModule } from './material/material.module';
import { ToolbarComponent } from './Components/toolbar/toolbar.component';
import { TaskAdderComponent } from './Components/task-adder/task-adder.component';
import { TaskListContainerComponent } from './Components/task-list-container/task-list-container.component';
import { ActiveTaskListComponent } from './Components/active-task-list/active-task-list.component';
import { CompletedTaskListComponent } from './Components/completed-task-list/completed-task-list.component';
import { TaskAdderDialogComponent } from './Components/task-adder-dialog/task-adder-dialog.component';
import { TaskItemComponent } from './Components/task-item/task-item.component';
import { TaskDataComponent } from './Components/task-data/task-data.component';
import { SideNavComponent } from './Components/side-nav/side-nav.component';

@NgModule({
  declarations: [
    AppComponent,
    ToolbarComponent,
    TaskAdderComponent,
    TaskListContainerComponent,
    ActiveTaskListComponent,
    CompletedTaskListComponent,
    TaskAdderDialogComponent,
    TaskItemComponent,
    TaskDataComponent,
    SideNavComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    MaterialModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
