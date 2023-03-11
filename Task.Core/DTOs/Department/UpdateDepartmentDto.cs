using System.ComponentModel.DataAnnotations;

namespace WebTask.Core.DTOs.Department
{
    public class UpdateDepartmentDto
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string? Description { get; set; }
    }
}
