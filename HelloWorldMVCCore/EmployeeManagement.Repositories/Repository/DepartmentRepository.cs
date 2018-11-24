using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EmployeeManagement.Models.EntityModels;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagement.Repositories.Repository
{
    public class DepartmentRepository
    {
        EmployeeDbContext db = new EmployeeDbContext();
        public bool Add(Department department)
        {
            db.Departments.Add(department);
            return db.SaveChanges() > 0;

        }

        public List<Department> GetAll()
        {
            return db.Departments.ToList();
        }

        public Department GetById(int id)
        {
            return db.Departments
                .Include(c=>c.Employees)
                .FirstOrDefault(c => c.Id == id);
        }
    }
}
