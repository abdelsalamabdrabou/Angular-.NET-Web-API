import { Component, OnInit } from '@angular/core';
import { Department } from '../models';
import { DepartmentService } from '../department.service';

@Component({
  selector: 'app-department',
  templateUrl: './department.component.html',
  styleUrls: ['./department.component.css']
})
export class DepartmentComponent implements OnInit {
  departments: Department[] = [];
  newDepartment: Department = { id: 0, name: '', description: '' };
  editingDepartment: Department | null = null;

  constructor(private departmentService: DepartmentService) { }

  ngOnInit(): void {
    this.getDepartments();
  }

  getDepartments(): void {
    this.departmentService.getDepartments()
      .subscribe(departments => this.departments = departments);
  }

  addDepartment(): void {
    this.departmentService.addDepartment(this.newDepartment)
      .subscribe(department => {
        this.departments.push(department);
        this.newDepartment = { id: 0, name: '', description: '' };
      });
  }

  deleteDepartment(id: number): void {
    this.departmentService.deleteDepartment(id)
      .subscribe(() => {
        this.departments = this.departments.filter(d => d.id !== id);
      });
  }

  editDepartment(department: Department): void {
    this.editingDepartment = department;
  }

  updateDepartment(): void {
    if (this.editingDepartment) {
      this.departmentService.updateDepartment(this.editingDepartment)
        .subscribe(() => {
          this.editingDepartment = null;
        });
    }
  }

  cancelEditDepartment(): void {
    this.editingDepartment = null;
  }
}