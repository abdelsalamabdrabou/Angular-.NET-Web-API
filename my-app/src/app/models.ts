export interface Department {
    id: number;
    name: string;
    description?: string;
}
  
export interface Employee {
    id: number;
    departmentId: number;
    firstName: string;
    lastName: string;
    email?: string;
    dateOfBirth?: Date;
    salary: number;
    department: Department
  }