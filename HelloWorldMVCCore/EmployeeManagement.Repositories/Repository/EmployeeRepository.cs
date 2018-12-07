using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EmployeeManagement.Models.EntityModels;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagement.Repositories.Repository
{
    public class EmployeeRepository
    {
        EmployeeDbContext db = new EmployeeDbContext();
        public bool Add(Employee employee)
        {
            db.Employees.Add(employee);
            return db.SaveChanges() > 0;
        }

        public Employee GetById(int id)
        {
            return db.Employees.FirstOrDefault(c => c.Id == id);

        }

        public bool Update(Employee employee)
        {
            db.Entry(employee).State = EntityState.Modified;
            return db.SaveChanges() > 0;
        }

        public IEnumerable<Employee> Search(Employee employeeSearchCriteria)
        {
            var result = db.Employees.AsQueryable();
            if (!string.IsNullOrEmpty(employeeSearchCriteria.Name))
            {
                result = result.Where(c => c.Name.Contains(employeeSearchCriteria.Name));
            }

            if (!string.IsNullOrEmpty(employeeSearchCriteria.RegNo))
            {
                result = result.Where(c => c.RegNo.Contains(employeeSearchCriteria.RegNo));
            }

            if (!string.IsNullOrEmpty(employeeSearchCriteria.MobileNumber))
            {
                result = result.Where(c => c.MobileNumber.StartsWith(employeeSearchCriteria.MobileNumber));
            }

            return result.ToList();
        }

        public IEnumerable<Employee> GetAll()
        {
            return db.Employees.Include(c=>c.Department).ToList();
        }

        public List<Employee> GetByDepartmentId(int departmentId)
        {
            return db.Employees.Where(c => c.DepartmentId == departmentId).ToList();
        }
    }
}

