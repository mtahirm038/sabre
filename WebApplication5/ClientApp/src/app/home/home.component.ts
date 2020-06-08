import { Component, Inject } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';

interface Employee {
  firstname: string,
  lastname: string,
  location: string
}

interface EmployeeViewModel {
  displayName: string,
  responsibilities: string

}

interface Manager {
  firstname: string,
  lastname: string,
  location: string
}

interface ManagerViewModel {
  displayName: string,
  responsibilities: string

}

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})

export class HomeComponent {
  public show: boolean = false;
  public buttonName: string = 'Show Roles';
  public showRoleClick: boolean;
  public employees = <Employee>{};
  public employeesViewModel = <EmployeeViewModel>{};
  public managers = <Manager>{};
  public managersViewModel = <ManagerViewModel>{};

  constructor(private http: HttpClient) {
  }

  public toggleRoles() {
    this.show = !this.show;
    if (this.show)
      this.buttonName = "Hide Roles";
    else
      this.buttonName = "Show Roles";
  };

  public getEmployee(employees) {
    const promise = this.http.post<any>('/api/employee', { employees: employees }).toPromise();

    promise.then((res) => {
      this.employeesViewModel.displayName = res.displayName;
      this.employeesViewModel.responsibilities = res.responsibilities;
    }).catch((error) => {
      console.log("Promise rejected with " + JSON.stringify(error));
    });
  }
  public getManager(managers) {
    const promise = this.http.post<any>('/api/manager', { managers: managers }).toPromise();

    promise.then((res) => {
      this.managersViewModel.displayName = res.displayName;
      this.managersViewModel.responsibilities = res.responsibilities;
    }).catch((error) => {
      console.log("Promise rejected with " + JSON.stringify(error));
    });
  }

  ngOnInit() {
    this.getEmployee(this.employees);
    this.getManager(this.managers);
  }
}
