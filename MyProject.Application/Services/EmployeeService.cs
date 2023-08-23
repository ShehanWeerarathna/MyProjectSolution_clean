using AutoMapper;


using MyProject.Application.DTOs;
using MyProject.Application.Services.Interfaces;
using MyProject.Domain.Entities;
using MyProject.Infrastructure.Repositories.Interfaces;

namespace MyProject.Application.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IMapper _mapper;

        public EmployeeService(IEmployeeRepository employeeRepository, IMapper mapper)
        {
            _employeeRepository = employeeRepository;
            _mapper = mapper;
        }

        public async Task<EmployeeDto> GetEmployee(int id)
        {
            try
            {
                Employee? employee = await _employeeRepository.GetEmployee(id);
                EmployeeDto? employeeDto = _mapper.Map<EmployeeDto>(employee);
                List<Designation> designationList = await _employeeRepository.GetDesignations();
                employeeDto.DesignationList = ConvertDesignationToDropDown(designationList); 
                return employeeDto;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }

        public async Task<EmployeeDto> AddEmployee(Employee employee)
        {
            try
            {
                Employee? savedEmployee = await _employeeRepository.AddEmployee(employee);
                if (savedEmployee.Id > 0)
                {
                    return await GetEmployee(savedEmployee.Id);
                }
                else
                {
                    return null;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }

        public async Task<EmployeeDto> DeleteEmployee(int id)
        {
            try
            {
                Employee? employee = await _employeeRepository.DeleteEmployee(id);
                if (employee.Id > 0)
                {
                    return _mapper.Map<EmployeeDto>(employee);
                }
                else
                {
                    return null;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }

        
    

    public async Task<List<EmployeeDto>> GetEmployees()
        {
            try
            {
                List<Employee> employees = await _employeeRepository.GetEmployees();
                List<EmployeeDto> employeeDtos = _mapper.Map<List<EmployeeDto>>(employees);
                List<Designation> designationList = await _employeeRepository.GetDesignations();
                List<DropDownDto> dropDownDtos = ConvertDesignationToDropDown(designationList);
                foreach (var employeeDto in employeeDtos)
                {
                    employeeDto.DesignationList = dropDownDtos;
                }

                return employeeDtos;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }

        public async Task<EmployeeDto> UpdateEmployee(Employee employee)
        {
            try
            {
                Employee? updatedEmployee = await _employeeRepository.UpdateEmployee(employee);
                if (updatedEmployee.Id > 0)
                {
                    return await GetEmployee(updatedEmployee.Id);
                }
                else
                {
                    return null;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }

        public async Task<EmployeeDto> AddEmployeeInitData()
        {
            try
            {
                EmployeeDto employeeDto = new EmployeeDto
                {
                    Id = 0,
                    Name = "",
                    DesignationId = 0,
                };
                var dbDesignationList = await _employeeRepository.GetDesignations();
                employeeDto.DesignationList = ConvertDesignationToDropDown(dbDesignationList);
                return employeeDto;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }
        
        private List<DropDownDto> ConvertDesignationToDropDown(List<Designation> designationList)
        {
            List<DropDownDto> dropDownDtos = new List<DropDownDto>();
            foreach (var designation in designationList)
            {
                DropDownDto dropDownDto = new DropDownDto
                {
                    Value = designation.Id,
                    Label = designation.Name
                };
                dropDownDtos.Add(dropDownDto);
            }
            return dropDownDtos;
        }

    }
}
