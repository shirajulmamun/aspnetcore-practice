using System;
using System.Collections.Generic;
using System.Text;
using EmployeeManagement.BLL.Contracts;
using EmployeeManagement.Models.EntityModels;
using EmployeeManagement.Repositories.Contracts;

namespace EmployeeManagement.BLL.Managers
{
    public class DepartmentManager:Manager<Department>,IDepartmentManager
    {
        public DepartmentManager(IDepartmentRepository repository) : base(repository)
        {
        }
    }
}
