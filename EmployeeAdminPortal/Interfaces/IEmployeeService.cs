using EmployeeAdminPortal.Models;
using EmployeeAdminPortal.Models.Entities;

namespace EmployeeAdminPortal.Interfaces
{
    public interface IEmployeeService
    {
        IEnumerable<Employee> GetAllEmployees();
        Employee GetEmployeeById(Guid id);
        Employee AddEmployee(AddEmployeeDTO addEmployeeDTO);
        Employee UpdateEmployee(Guid id, UpdateEmployeeDTO updateEmployeeDTO);
        bool DeleteEmployee(Guid id);
    }
}
