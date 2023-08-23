

using MyProject.Application.DTOs;
using MyProject.Domain.Entities;

namespace MyProject.Application.Services.Interfaces
{
    public interface IEmployeeService
    {
        Task<List<EmployeeDto>> GetEmployees();
        Task<EmployeeDto> GetEmployee(int id);
        Task<EmployeeDto> AddEmployee(Employee employee);
        Task<EmployeeDto> UpdateEmployee(Employee employee);
        Task<EmployeeDto> DeleteEmployee(int id);
        Task<EmployeeDto> AddEmployeeInitData();
    }
}
