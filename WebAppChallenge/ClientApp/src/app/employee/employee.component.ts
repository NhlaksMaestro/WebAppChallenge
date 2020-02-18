import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { FormControl, Validators, FormGroup } from '@angular/forms';

@Component({
  selector: 'app-employee',
  templateUrl: './employee.component.html'
})
export class EmployeeComponent {
  public employees: IEmployee[];
  public subordinates: IEmployee[];
  public selectedEmployee: IEmployee;
  public selectedEmployeeToEdit: IEmployee;
  public selectedEmployeeManager: IEmployee;
  public selectedManager: string;
  public expandDropdown = false;
  public createNewUser = false;
  baseUrl: string;
  alertMessage: string;
  urlEndPoint = 'api/employee';
  employeeForm: FormGroup;

  constructor(private readonly http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.baseUrl = baseUrl;
    this.selectedManager = "None";
    http.get<IEmployee[]>(baseUrl + this.urlEndPoint).subscribe(result => {
      this.employees = result;
    }, error => console.error(error));

  }

  get name() { return this.employeeForm.get('name'); }

  get surname() { return this.employeeForm.get('surname'); }

  viewSubordinates(employees: Array<IEmployee>, employee: IEmployee) {
    this.subordinates = employees;
    this.selectedEmployee = employee;
  }
  expandDropdownHandler() {
    this.expandDropdown = !this.expandDropdown;
  }
  editEmployee(employee: IEmployee) {
    this.selectedEmployeeToEdit = employee;
    this.selectedManager = employee.name;
    this.employeeForm = new FormGroup({
      'name': new FormControl(employee.name, [
        Validators.required,
        Validators.minLength(1)
      ]),
      'surname': new FormControl(employee.surname, [
        Validators.required,
        Validators.minLength(1)
      ])
    });
  }
  cancelEdit() {
    this.clearSelectedEmployee();
  }
  closeAlert() {
    this.alertMessage = "";
  }
  saveEmployee() {
    let empToSave: IEmployee;
    if (this.selectedEmployeeToEdit && !this.createNewUser) {
      empToSave= this.selectedEmployeeToEdit;
      empToSave.name = this.name.value;
      empToSave.surname = this.surname.value;
      empToSave.managerId = this.selectedEmployeeManager ? this.selectedEmployeeManager.id: null;
      this.http.put<IEmployee[]>(this.baseUrl + this.urlEndPoint, empToSave).subscribe(result => {
        this.alertMessage = `Employee ${empToSave.name} ${empToSave.surname}'s details have been updated!`;
        this.clearSelectedEmployee();
      }, error => console.error(error));
    } else {
      empToSave = {
        name: this.name.value,
        surname: this.surname.value,
        managerId: this.selectedEmployeeManager ? this.selectedEmployeeManager.id : null
      } as IEmployee;
      this.http.put<IEmployee[]>(this.baseUrl + this.urlEndPoint, empToSave).subscribe(result => {
        this.alertMessage = `Employee ${empToSave.name} ${empToSave.surname}'s details have been updated!`;
        this.clearSelectedEmployee();
      }, error => console.error(error));
    }
  }
  private clearSelectedEmployee(): void {
    this.selectedEmployee = undefined;
    this.selectedEmployeeToEdit = undefined;
    this.selectedEmployeeManager = undefined;
  }
  clearEmployeeSelection(valueEmitted: any): void {
    this.selectedEmployee = valueEmitted;
  }
  selectManger(employee: IEmployee) {
    this.selectedEmployeeManager = employee;
    this.selectedManager = `${employee.name} ${employee.surname}`;
    this.expandDropdownHandler();
  }
  checkEmployeeSelected(employee: IEmployee) {
    return !this.selectedEmployeeToEdit || (this.selectedEmployeeToEdit && this.selectedEmployeeToEdit.id !== employee.id)
  }
  createNewEmployee() {
    this.createNewUser = !this.createNewUser;
    this.employeeForm = new FormGroup({
      'name': new FormControl("", [
        Validators.required,
        Validators.minLength(1)
      ]),
      'surname': new FormControl("", [
        Validators.required,
        Validators.minLength(1)
      ])
    });
  }
}
