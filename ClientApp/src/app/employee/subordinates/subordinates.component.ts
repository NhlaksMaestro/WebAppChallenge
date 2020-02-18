import { Component, Input, Output, EventEmitter } from '@angular/core';

@Component({
  selector: 'app-subordinates',
  templateUrl: './subordinates.component.html'
})
export class SubordinatesComponent {
  @Input() subordinates: IEmployee[];
  @Input() selectedEmployee: IEmployee
  @Output() clearedSelectedEmployee = new EventEmitter();

  constructor() {
  }

  close() {
    this.clearedSelectedEmployee.emit(undefined);
  }
}
