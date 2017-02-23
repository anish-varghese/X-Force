import { Component, OnInit } from '@angular/core';
import { Router, RouterModule } from '@angular/router';

import { DropdownDirective } from './dropdown.directive'

@Component({
  selector: 'ep-header',
  templateUrl: './header.component.html'
})
export class HeaderComponent implements OnInit {

  constructor(private router: Router) { }

  public onlogout() {
    localStorage.removeItem('currentUser');
    this.router.navigate(['']);
  }

  ngOnInit() {
  }

}


