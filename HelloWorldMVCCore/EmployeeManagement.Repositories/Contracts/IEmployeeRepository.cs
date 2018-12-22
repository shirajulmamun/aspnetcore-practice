using System;
using System.Collections.Generic;
using System.Text;
using EmployeeManagement.Models.EntityModels;
using Microsoft.EntityFrameworkCore.Migrations.Operations;

namespace EmployeeManagement.Repositories.Contracts
{
    public interface IEmployeeRepository:IRepository<Employee>
    {
        IEnumerable<Employee> Search(Employee employeeSearchCriteria);

        List<Employee> GetByDepartmentId(int departmentId);
    }
}
