import { Component, Inject } from '@angular/core';
/*import { Employee } from '../models/Employee';*/
import { HttpClient, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';


interface Employee {
  firstname: string,
  lastname: string,
  location: string
}

interface EmployeeViewModel {
  displayName: string,
  responsibilities: string

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
    const promise = this.http.post<any>('/api/employee', { employees: employees }).toPromise();
    console.log(promise);
    promise.then((res) => {
      this.employeesViewModel.displayName = res.displayName;
      this.employeesViewModel.responsibilities = res.responsibilities;
    }).catch((error) => {
      console.log("Promise rejected with " + JSON.stringify(error));
    });
  }

  ngOnInit() {
   this.getEmployee(this.employees);
  }
}
