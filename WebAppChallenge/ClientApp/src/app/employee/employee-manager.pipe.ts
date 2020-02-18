import { Pipe, PipeTransform } from '@angular/core';

@Pipe({ name: 'employeeManager'})
export class EmployeeManagerPipe implements PipeTransform {
  transform(value: string): string {
    if (!value) {
      return "No Manager";
    }
    return value;
  }
}
