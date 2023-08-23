

using Microsoft.EntityFrameworkCore;
using MyProject.Domain.Entities;
using MyProject.Infrastructure.Data;
using MyProject.Infrastructure.Repositories.Interfaces;

namespace MyProject.Infrastructure.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly AppDbContext _context;
        public EmployeeRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<Employee> AddEmployee(Employee employee)
        {
            try
            {
                _context.Employees.Add(employee);
                await _context.SaveChangesAsync();
                return employee;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
           
        }

        public async Task<Employee> DeleteEmployee(int id)
        {
            
            try
            {
                var employee = await _context.Employees
                    .Include(e => e.Designation)
                    .FirstOrDefaultAsync(e => e.Id == id);
                if (employee == null)
                {
                    return null;
                }
                _context.Employees.Remove(employee);
                await _context.SaveChangesAsync();
                return employee;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }

        public async Task<Employee> GetEmployee(int id)
        {
            try
            {
                var employee = await _context.Employees.Include(e => e.Designation)
                    .FirstOrDefaultAsync(e => e.Id == id);
                return employee;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }

        public async Task<List<Employee>> GetEmployees()
        {
            try
            {
                var employees = await _context.Employees.Include(e => e.Designation).ToListAsync();
                return employees;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }

        public async Task<Employee> UpdateEmployee(Employee employee)
        {
            try
            {
                _context.Employees.Update(employee);
                await _context.SaveChangesAsync();
                return employee;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }

        public async Task<List<Designation>> GetDesignations()
        {
            try
            {
                var designations = await _context.Designations.ToListAsync();
                return designations;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }
    }
}
