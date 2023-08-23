using MyProject.Application.DTOs;
using MyProject.Domain.Entities;
using AutoMapper;

namespace MyProject.Application.Mappings;
public class MappingProfiles: Profile
{
    public MappingProfiles()
    {
        CreateMap<Employee, EmployeeDto>().ReverseMap();
        CreateMap<Designation, DesignationDto>().ReverseMap();
    }
}