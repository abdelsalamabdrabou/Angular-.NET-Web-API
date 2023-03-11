using Microsoft.AspNetCore.Mvc;
using WebTask.Core.DTOs.Department;
using WebTask.Core.Entities;
using WebTask.Infrastructure.Repository;

namespace WebTask.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IDepartmentRepository _departmentRepository;

        public DepartmentController(IDepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Department>>> GetDepartments()
        {
            var departments = await _departmentRepository.GetAll();
            
            if (departments == null || departments.Count == 0)
                return NotFound();

            return Ok(departments);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Department>> GetDepartment(int id)
        {
            var department = await _departmentRepository.Get(id);
            if (department == null)
            {
                return NotFound();
            }

            return Ok(department);
        }

        [HttpPost]
        public async Task<ActionResult<Department>> CreateDepartment(CreateDepartmentDto model)
        {
            var entity = new Department()
            {
                Name = model.Name,
                Description = model.Description
            };

            await _departmentRepository.Add(entity);
            await _departmentRepository.SaveContext();

            return Ok(model);
        }

        [HttpPut()]
        public async Task<ActionResult<Department>> UpdateDepartment(UpdateDepartmentDto model)
        {
            var entity = await _departmentRepository.Get(model.Id);

            if (entity == null)
            {
                return BadRequest();
            }

            entity.Name = model.Name;
            entity.Description = model.Description;

            _departmentRepository.Update(entity);
            await _departmentRepository.SaveContext();

            return Ok(model);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Department>> DeleteDepartment(int id)
        {
            var department = await _departmentRepository.Get(id);
            if (department == null)
            {
                return NotFound();
            }

            _departmentRepository.Delete(department);
            await _departmentRepository.SaveContext();

            return NoContent();
        }
    }
}
