using EmployeeAdminPortal.Interfaces;
using EmployeeAdminPortal.Models.Entities;
using EmployeeAdminPortal.Models;
using EmployeeAdminPortal.Data;

namespace EmployeeAdminPortal.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly ApplicationDbContext _dbContext;
        public EmployeeService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IEnumerable<Employee> GetAllEmployees()
        {
            return _dbContext.Employees.ToList();
        }
        public Employee GetEmployeeById(Guid id)
        {
            return _dbContext.Employees.Find(id);
        }

        public Employee AddEmployee(AddEmployeeDTO addEmployeeDTO)
        {
            var employee = new Employee
            {
                Name = addEmployeeDTO.Name,
                Email = addEmployeeDTO.Email,
                Phone = addEmployeeDTO.Phone,
                Salary = addEmployeeDTO.Salary
            };

            _dbContext.Employees.Add(employee);
            _dbContext.SaveChanges();
            return employee;
        }

        public Employee UpdateEmployee(Guid id, UpdateEmployeeDTO updateEmployeeDTO)
        {
            var existingEmployee = _dbContext.Employees.Find(id);
            if (existingEmployee == null)
            {
                return null;
            }

            existingEmployee.Name = updateEmployeeDTO.Name;
            existingEmployee.Email = updateEmployeeDTO.Email;
            existingEmployee.Phone = updateEmployeeDTO.Phone;
            existingEmployee.Salary = updateEmployeeDTO.Salary;

            _dbContext.SaveChanges();
            return existingEmployee;
        }

        public bool DeleteEmployee(Guid id) 
        {
            var employee = _dbContext.Employees.Find(id);

            if (employee == null)
            {
                return false;
            }

            _dbContext.Employees.Remove(employee);
            _dbContext.SaveChanges();
            return true;
        }
    }
}
