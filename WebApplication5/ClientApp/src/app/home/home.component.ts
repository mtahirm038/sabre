import { Component, Inject } from '@angular/core';
/*import { Employee } from '../models/Employee';*/
import { HttpClient, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';

interface Employee {
  FirstName: "Muhammad",
  LastName: "Tahir",
  Location: "philadelphia"
}

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})

export class HomeComponent {

  employees: Employee[] = [];

  constructor(private http: HttpClient) {
  }

  public getEmployee(employees) {
/*    let params = new HttpParams();
    params = params.append('data', employees);*/
    this.http.get<Employee[]>('/api/employee').subscribe(data => {
      this.employees = data;
    });
  }

  ngOnInit() {
   this.getEmployee(this.employees);
  }
}
