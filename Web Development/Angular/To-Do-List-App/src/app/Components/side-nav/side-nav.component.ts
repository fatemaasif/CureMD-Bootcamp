import { Component, ElementRef, ViewChild } from '@angular/core';
import { MatDrawer } from '@angular/material/sidenav';

@Component({
  selector: 'app-side-nav',
  templateUrl: './side-nav.component.html',
  styleUrls: ['./side-nav.component.css']
})
export class SideNavComponent {
  @ViewChild('drawer') drawer!:MatDrawer;

  ngAfterViewInit() {
    console.log('Drawer:', this.drawer);
  }

  toggleDrawer() {
    if (this.drawer) {
      this.drawer.toggle();
      console.log('drawer toggled');
    }
  }
}
