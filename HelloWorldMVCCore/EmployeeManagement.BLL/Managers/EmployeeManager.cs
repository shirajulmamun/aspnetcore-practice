using System;
using System.Collections.Generic;
using System.Text;
using EmployeeManagement.BLL.Contracts;
using EmployeeManagement.Models.EntityModels;
using EmployeeManagement.Repositories.Contracts;

namespace EmployeeManagement.BLL.Managers
{
    public class EmployeeManager:Manager<Employee>,IEmployeeManager
    {
        private IEmployeeRepository _employeeRepository;
        public EmployeeManager(IEmployeeRepository repository) : base(repository)
        {
            _employeeRepository = repository;
        }

        public List<Employee> GetByDepartment(int departmentId)
        {
            return _employeeRepository.GetByDepartmentId(departmentId);
        }
    }
}
