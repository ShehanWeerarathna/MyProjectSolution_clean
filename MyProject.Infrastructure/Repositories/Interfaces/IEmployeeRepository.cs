

using MyProject.Domain.Entities;

namespace MyProject.Infrastructure.Repositories.Interfaces
{
    public interface IEmployeeRepository
    {
        Task<List<Employee>> GetEmployees();
        Task<Employee> GetEmployee(int id);
        Task<Employee> AddEmployee(Employee employee);
        Task<Employee> UpdateEmployee(Employee employee);
        Task<Employee> DeleteEmployee(int id);
        Task<List<Designation>> GetDesignations();
    }
}
