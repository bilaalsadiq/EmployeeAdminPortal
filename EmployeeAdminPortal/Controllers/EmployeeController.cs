using EmployeeAdminPortal.Data;
using EmployeeAdminPortal.Models;
using EmployeeAdminPortal.Models.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeAdminPortal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;
        public EmployeeController(ApplicationDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult GetAllEmployees()
        {
            var result = _dbContext.Employees.ToList();
            return Ok(result);
        }

        [HttpGet]
        [Route("{id:guid}")]
        public IActionResult GetEmployeeById(Guid id)
        {
            var employee = _dbContext.Employees.Find(id);

            if (employee == null)
            {
                return NotFound();
            }

            return Ok(employee);
        }

        [HttpPost]
        public IActionResult AddEmployee(AddEmployeeDTO addEmployeeDTO)
        {
            var employeeEntity = new Employee
            {
                Name = addEmployeeDTO.Name,
                Email = addEmployeeDTO.Email,
                Phone = addEmployeeDTO.Phone,
                Salary = addEmployeeDTO.Salary
            };

            _dbContext.Employees.Add(employeeEntity);
            _dbContext.SaveChanges();
            return Ok(employeeEntity);
        }

        [HttpPut]
        [Route("{id:guid}")]
        public IActionResult UpdateEmployee(Guid id, UpdateEmployeeDTO updateEmployeeDTO)
        {
            var employee = _dbContext.Employees.Find(id);

            if (employee == null)
            {
                return NotFound();
            }

            //diffset to manage properties that haven't been updated?

            employee.Name = updateEmployeeDTO.Name;
            employee.Email = updateEmployeeDTO.Email;
            employee.Phone = updateEmployeeDTO.Phone;
            employee.Salary = updateEmployeeDTO.Salary;

            _dbContext.SaveChanges();

            return Ok(employee);
        }

        [HttpDelete]
        [Route("{id:guid}")]
        public IActionResult DeleteEmployee(Guid id)
        {
            var employee = _dbContext.Employees.Find(id);

            if (employee == null)
            {
                return NotFound();
            }

            _dbContext.Employees.Remove(employee);
            _dbContext.SaveChanges();

            return Ok();
        }
    }
}
