using System.ComponentModel.DataAnnotations;

namespace WebTask.Core.DTOs.Employee
{
    public class CreateEmployeeDto
    {
        [Required]
        public int DepartmentId { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        public string? Email { get; set; }
        public DateTime? DateOfBirth { get; set; }
        [Required]
        public int Salary { get; set; }
    }
}
