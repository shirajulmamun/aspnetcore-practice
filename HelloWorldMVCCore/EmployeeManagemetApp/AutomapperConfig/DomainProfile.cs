using AutoMapper;
using EmployeeManagement.Models.EntityModels;
using EmployeeManagemetApp.Models;

namespace EmployeeManagemetApp.AutomapperConfig
{
    public class DomainProfile:Profile
    {
        public DomainProfile()
        {
            CreateMap<EmployeeCreateViewModel, Employee>();
            CreateMap<Employee, EmployeeCreateViewModel>();
        }
    }
}
