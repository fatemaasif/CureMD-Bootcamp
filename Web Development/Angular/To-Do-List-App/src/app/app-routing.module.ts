import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { SideNavComponent } from './Components/side-nav/side-nav.component';
import { AppComponent } from './app.component';

const routes: Routes = [
  { path: 'navbar', component: SideNavComponent },
  { path: 'home', component: AppComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
