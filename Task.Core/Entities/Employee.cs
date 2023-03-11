using System.ComponentModel.DataAnnotations.Schema;

namespace WebTask.Core.Entities
{
    public class Employee : BaseEntity
    {
        public int DepartmentId { get; set; }
        [ForeignKey("DepartmentId")]
        public Department Department { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? Email { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public int Salary { get; set; }
    }
}
