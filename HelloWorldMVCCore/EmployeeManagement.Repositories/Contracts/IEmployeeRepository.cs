using System;
using System.Collections.Generic;
using System.Text;
using EmployeeManagement.Models.EntityModels;
using Microsoft.EntityFrameworkCore.Migrations.Operations;

namespace EmployeeManagement.Repositories.Contracts
{
    public interface IEmployeeRepository
    {
        bool Add(Employee entity);
        bool Update(Employee entity);
        bool Remove(Employee entity);

        Employee GetById(int id);
        ICollection<Employee> GetAll();

        IEnumerable<Employee> Search(Employee employeeSearchCriteria);

        List<Employee> GetByDepartmentId(int departmentId);
    }
}
