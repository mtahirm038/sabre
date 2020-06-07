import { Component, Inject } from '@angular/core';
/*import { Employee } from '../models/Employee';*/
import { HttpClient, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';


interface Employee {
  FirstName: string,
  LastName: string,
  Location: string
}

interface EmployeeViewModel {
  DisplayName: string
}

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})

export class HomeComponent {
  public show: boolean = false;
  public buttonName: any = 'Show Employee Roles';

  public showRoleClick: boolean;
  public employees = <Employee>{};
  public employeesViewModel = <EmployeeViewModel>{};

  constructor(private http: HttpClient) {
  }

  public toggleRoles() {
    this.show = !this.show;
    if (this.show)
      this.buttonName = "Hide Employee Roles";
    else
      this.buttonName = "Show Employee Roles";
  };
  public getEmployee(employees) {
/*    let params = new HttpParams();
    params = params.append('data', employees);*/
/*    this.http.get<Employee[]>('/api/employee').subscribe(data => {
      this.employees = data;
    });*/

    this.http.post<any>('/api/employee', { employees: employees }).subscribe(res => {
      this.employeesViewModel.DisplayName = res.displayName;
    });
  }

  ngOnInit() {
   this.getEmployee(this.employees);
  }
}
