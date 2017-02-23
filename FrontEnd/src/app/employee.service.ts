import { Injectable } from '@angular/core';
import { EmployeeClass } from './employee-class';
import { Http, Headers, Response } from '@angular/http';
import 'rxjs/Rx';
import { Observable } from 'rxjs/Observable';

@Injectable()
export class EmployeeService {
  constructor(private http: Http) {

  }

  getDesignationBand(): Observable<any> {
    return this.http.get("http://localhost:11681/api/addEmployee").map((response: Response) => response.json());
  }

  getEmployee(): Observable<any> {
    return this.http.get("http://localhost:11681/api/employee/all").map((response: Response) => response.json());
  }
  searchResult() {
    return this.http.get("http://localhost:11681/api/pageload").map((response: Response) => response.json());
  }
  loadFilter(id) {

    return this.http.get("http://localhost:11681/api/filter/" + id).map((response: Response) => response.json());
  }

  getSearchEmployee(searchQuery: any) {
    //  const myJSON = JSON.stringify(searchQuery);
    const headers = new Headers();
    headers.append('Content-Type', 'application/json');
    return this.http.post("http://localhost:11681/api/employee/filter", searchQuery, { headers: headers }).map((response: Response) => response.json()
    );
  }

  deleteEmployee(deleteDetails: any){
    const headers = new Headers();
    headers.append('Content-Type', 'application/json');
    return this.http.post("http://localhost:11681/api/employee/delete/{id}", deleteDetails, { headers: headers }).map((response: Response) => response.json()
    );
  }

  addNew(employee) {
    //this.employeeList.push(new EmployeeClass(c.employeeId, c.EmployeeName, c.dateOfJoining, c.Designation, c.Band));
    const myJSON = JSON.stringify(employee);
    const headers = new Headers();
    headers.append('Content-Type', 'application/json');
    return this.http.post("http://localhost:11681/api/employee/save", myJSON, { headers: headers }).map((response: Response) => response.json()
    );
  }

  getEmployeeById(id){
    return this.http.get("http://localhost:11681/api/employee/get/" + id).map((response: Response) => response.json());
  }
}
