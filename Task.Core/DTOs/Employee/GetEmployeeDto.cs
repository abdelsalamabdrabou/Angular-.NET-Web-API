using WebTask.Core.DTOs.Department;

namespace WebTask.Core.DTOs.Employee
{
    public class GetEmployeeDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? Email { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public int Salary { get; set; }
        public GetDepartmentDto Department { get; set; }
    }
}
