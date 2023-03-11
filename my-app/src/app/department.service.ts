import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Department } from './models';

@Injectable({
  providedIn: 'root'
})
export class DepartmentService {
  private baseUrl = 'https://localhost:7200/api/Department';

  constructor(private http: HttpClient) { }

  getDepartments(): Observable<Department[]> {
    return this.http.get<Department[]>(this.baseUrl);
  }

  getDepartmentById(id: number): Observable<Department> {
    const url = `${this.baseUrl}/${id}`;
    return this.http.get<Department>(url);
  }

  addDepartment(department: Department): Observable<Department> {
    return this.http.post<Department>(this.baseUrl, department);
  }

  updateDepartment(department: Department): Observable<void> {
    return this.http.put<void>(this.baseUrl, department);
  }

  deleteDepartment(id: number): Observable<void> {
    const url = `${this.baseUrl}/${id}`;
    return this.http.delete<void>(url);
  }
}