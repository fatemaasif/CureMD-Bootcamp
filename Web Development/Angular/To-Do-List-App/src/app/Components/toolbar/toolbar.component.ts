import { Component,Input,ViewChild } from '@angular/core';
import { MatDrawer } from '@angular/material/sidenav';
import { SideNavComponent } from '../side-nav/side-nav.component';


@Component({
  selector: 'app-toolbar',
  templateUrl: './toolbar.component.html',
  styleUrls: ['./toolbar.component.css'],
  providers: [SideNavComponent]
})

export class ToolbarComponent {
  constructor(private sideNavComp: SideNavComponent){}

  @Input() title:string = ''; 

  menuClicked(){
    this.sideNavComp.toggleDrawer();
  }
}
