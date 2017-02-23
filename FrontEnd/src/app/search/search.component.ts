import { Component, OnInit } from '@angular/core';
import { Http } from '@angular/http';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { EmployeeClass } from '../employee-class';
import { EmployeeService } from '../employee.service';
import { Router, RouterModule } from '@angular/router';

@Component({
  selector: 'ep-search',
  templateUrl: './search.component.html'
})
export class SearchComponent implements OnInit {

  employee: any;
  searchBy: any;
  filterBy: any;
  toDateFlag = false;
  designationFlag = false;
  bandFlag = false;
  queryFlag = true;
  bands: any;
  designations: any;
  type: string = "text";

  myForm: FormGroup;
  constructor(private add: EmployeeService, private router: Router) {

    this.myForm = new FormGroup({
      'SearchBy': new FormControl('', [Validators.required]),
      'FilterBy': new FormControl('', [Validators.required]),
      'Query': new FormControl('', [Validators.required]),
      'toDate': new FormControl('', [Validators.required])
    });
  }
  onChangeSearch(val) {
    this.type = "text";
    this.toDateFlag = false;
    this.add.loadFilter(val).subscribe((data) => {
      this.filterBy = data.Data.FilterOperators;
      this.bands = data.Data.Bands;
      this.designations = data.Data.Designation;
    }
    );
    switch (val) {
      case '3':
        this.type = "date";

        break;
      case '4':
        this.designationFlag = true;
        this.queryFlag = false;
        this.bandFlag = false;
        break;
      case '5':
        this.bandFlag = true;
        this.queryFlag = false;
        this.designationFlag = false;

        break;
      default:
        this.queryFlag = true;
        this.designationFlag = false;
        this.bandFlag = false;
        break;
    }
  }

  onChangeFilter(value) {
    this.toDateFlag = false;
    if (value == '10') {
      this.toDateFlag = true;
    }
  }

  resetData() {
    this.toDateFlag = false;    
    this.queryFlag = true;
    this.designationFlag = false;
    this.bandFlag = false;
    this.type='text';
    this.add.getEmployee().subscribe((data) => {
      this.employee = data.Data;
    });
  }

  searchData() {

    this.add.getSearchEmployee(this.myForm.value).subscribe((data) => {
      this.employee = data.Data;
    });
  }


  ngOnInit() {
    var data = JSON.parse(localStorage.getItem('currentUser'));
    if (!data.Status) {
      this.router.navigate(['']);
    }
    this.add.searchResult().subscribe((data) => {
      this.searchBy = data.Data.Attributes;
      this.filterBy = data.Data.FilterOperators;
    }

    );
  }
}

