import { Component, OnInit } from '@angular/core';
import { Employee } from '../models';
import { Department } from '../models';
import { EmployeeService } from '../employee.service';
import { DepartmentService } from '../department.service';

@Component({
  selector: 'app-employee',
  templateUrl: './employee.component.html',
  styleUrls: ['./employee.component.css']
})
export class EmployeeComponent implements OnInit {
  department: Department = {id: 0, name: '', description: ''}
  employees: Employee[] = [];
  newEmployee: Employee = { id: 0, departmentId: 0, firstName: '', lastName: '', email: '', dateOfBirth: new Date(), salary: 0, department: this.department};
  editingEmployee: Employee | null = null;
  departments: Department[] = [];

  constructor(private employeeService: EmployeeService, private departmentService: DepartmentService) { }

  ngOnInit(): void {
    this.getEmployees();
    this.getDepartments();
  }

  getEmployees(): void {
    this.employeeService.getEmployees()
      .subscribe(employees => this.employees = employees);
  }

  addEmployee(): void {
    this.employeeService.addEmployee(this.newEmployee)
      .subscribe(employee => {
        this.employees.push(employee);
        this.newEmployee = { id: 0, departmentId: 0, firstName: '', lastName: '', email: '', dateOfBirth: new Date(), salary: 0, department: this.department};
      });
  }

  deleteEmployee(id: number): void {
    this.employeeService.deleteEmployee(id)
      .subscribe(() => {
        this.employees = this.employees.filter(d => d.id !== id);
      });
  }

  editEmployee(Employee: Employee): void {
    this.editingEmployee = Employee;
  }

  updateEmployee(): void {
    if (this.editingEmployee) {
      this.employeeService.updateEmployee(this.editingEmployee)
        .subscribe(() => {
          this.editingEmployee = null;
        });
    }
  }

  cancelEditEmployee(): void {
    this.editingEmployee = null;
  }

  getDepartments(): void {
    this.departmentService.getDepartments()
      .subscribe(departments => this.departments = departments);
  }
}