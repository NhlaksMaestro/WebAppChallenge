import { Component, Input } from '@angular/core';

@Component({
  selector: 'app-employee-detail',
  templateUrl: './employee-detail.component.html'
})
export class EmployeeDetailComponent {
  @Input() subordinates: IEmployee[];
  @Input() selectedEmployee: IEmployee;

  constructor() {
  }
}
