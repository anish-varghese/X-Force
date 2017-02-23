import { Component, OnInit } from '@angular/core';
import { EmployeeClass } from '../employee-class';
import { EmployeeService } from '../employee.service';
import { Router, RouterModule } from '@angular/router';

@Component({
  selector: 'ep-view-all',
  templateUrl: './view-all.component.html'
})
export class ViewAllComponent implements OnInit {
  employee: any;

  constructor(private add: EmployeeService, private router: Router) { }

  ngOnInit() {
    var data = JSON.parse(localStorage.getItem('currentUser'));
    if (!data.Status) {
      this.router.navigate(['']);
    }

    this.add.getEmployee().subscribe((data) => {
      this.employee = data.Data;
    });
  }
}
