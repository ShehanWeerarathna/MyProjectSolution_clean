using MyProject.Application.DTOs;
using MyProject.Domain.Entities;

namespace MyProject.Application.Mappings;
using AutoMapper;

public class MappingProfiles: Profile
{
    public MappingProfiles()
    {
        CreateMap<Employee, EmployeeDto>().ReverseMap();
        CreateMap<Designation, DesignationDto>().ReverseMap();
    }
}