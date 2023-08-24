using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MyProject.Application.Mappings;
using MyProject.Application.Services;
using MyProject.Application.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Application
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddAppicationServices(this IServiceCollection services, IConfiguration configuration)
        {
            try
            {
                services.AddAutoMapper(typeof(MappingProfiles));
                services.AddScoped<IEmployeeService, EmployeeService>();
                return services;
            }

            catch (Exception ex)
            {
                throw;
            }

        }
    }
}
