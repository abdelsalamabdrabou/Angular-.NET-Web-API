using Microsoft.AspNetCore.Mvc;
using WebTask.Core.DTOs.Department;
using WebTask.Core.DTOs.Employee;
using WebTask.Core.Entities;
using WebTask.Infrastructure.Repository;

namespace WebTask.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Employee>>> GetEmployees()
        {
            var employees = await _employeeRepository.GetAll(navigationProperety: "Department");

            if (employees == null || employees.Count == 0)
                return NotFound();

            var model = employees.Select(x => new GetEmployeeDto
            {
                Id = x.Id,
                FirstName = x.FirstName,
                LastName = x.LastName,
                Email = x.Email,
                DateOfBirth = x.DateOfBirth,
                Salary = x.Salary,
                Department = new GetDepartmentDto
                {
                    Name = x.Department.Name,
                    Description = x.Department.Description
                }
            });

            return Ok(model);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Employee>> GetEmployee(int id)
        {
            var employee = await _employeeRepository.Get(id, navigationProperety: "Department");

            if (employee == null)
            {
                return NotFound();
            }

            var model = new GetEmployeeDto
            {
                Id = id,
                FirstName = employee.FirstName,
                LastName = employee.LastName,
                Email = employee.Email,
                DateOfBirth = employee.DateOfBirth,
                Salary = employee.Salary,
                Department = new GetDepartmentDto
                {
                    Name = employee.Department.Name,
                    Description = employee.Department.Description
                }
            };

            return Ok(model);
        }

        [HttpPost]
        public async Task<ActionResult<Employee>> CreateEmployee(CreateEmployeeDto model)
        {
            var entity = new Employee()
            {
                DepartmentId = model.DepartmentId,               
                FirstName= model.FirstName,
                LastName= model.LastName,
                Email= model.Email,
                DateOfBirth = model.DateOfBirth,
                Salary = model.Salary
            };

            await _employeeRepository.Add(entity);
            await _employeeRepository.SaveContext();

            return Ok(model);
        }

        [HttpPut()]
        public async Task<ActionResult<Employee>> UpdateEmployee(UpdateEmployeeDto model)
        {
            var entity = await _employeeRepository.Get(model.Id);

            if (entity == null)
            {
                return BadRequest();
            }

            entity.DepartmentId = model.DepartmentId;
            entity.FirstName = model.FirstName;
            entity.LastName = model.LastName;
            entity.Email = model.Email;
            entity.DateOfBirth = model.DateOfBirth;
            entity.Salary = model.Salary;

            _employeeRepository.Update(entity);
            await _employeeRepository.SaveContext();

            return Ok(model);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Employee>> DeleteEmployee(int id)
        {
            var employee = await _employeeRepository.Get(id);
            if (employee == null)
            {
                return NotFound();
            }

            _employeeRepository.Delete(employee);
            await _employeeRepository.SaveContext();

            return NoContent();
        }
    }
}
