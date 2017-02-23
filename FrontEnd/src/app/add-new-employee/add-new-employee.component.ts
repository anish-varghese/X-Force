import { Component, OnInit } from '@angular/core';
import { EmployeeService } from '../employee.service';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { EmployeeClass } from '../employee-class';
import { Router, RouterModule } from '@angular/router';
import { Response } from '@angular/http';


@Component({
  selector: 'ep-add-new-employee',
  templateUrl: './add-new-employee.component.html'

})
export class AddNewEmployeeComponent implements OnInit {  
  myForm: FormGroup;
  bands:any;
  designations:any;
  constructor(private add: EmployeeService, private router: Router, private employeeservice: EmployeeService) {

    this.myForm = new FormGroup({
      'Number': new FormControl('', [Validators.required]),
      'Name': new FormControl('', [Validators.required]),
      'DateOfJoin': new FormControl('', [Validators.required]),
      'DesignationId': new FormControl(''),
      'BandId': new FormControl('')

    });
  }

  onAdd() {
    let str = this.myForm.value;
    this.add.addNew(str).subscribe(data => {
        if(!data){alert("Employee already exist");}
        else{alert("Registration Successfull");}
    });
  }

  ngOnInit() {
    
    var status = JSON.parse(localStorage.getItem('currentUser'));
    if (!status.Status) {
      this.router.navigate(['']);
    }
    this.employeeservice.getDesignationBand()
      .subscribe((data) => {      
        this.bands = data.Data.Bands;
        this.designations=data.Data.Designation;
    }
    );
   }
}
