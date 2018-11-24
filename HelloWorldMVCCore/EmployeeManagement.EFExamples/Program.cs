using System;
using System.Linq;
using EmployeeManagement.Models.EntityModels;
using EmployeeManagement.Repositories.Repository;

namespace EmployeeManagement.EFExamples
{
    class Program
    {
        static void Main(string[] args)
        { 
          
            EmployeeRepository repository = new EmployeeRepository(); 
            DepartmentRepository departmentRepository = new DepartmentRepository();

            var department = departmentRepository.GetById(1);

            Console.WriteLine("Department: "+department.Name);
            if (department.Employees != null)
            {
                Console.WriteLine("Employees: "+department.Employees.Count);

                foreach (var employee in department.Employees)
                {
                     Console.WriteLine(employee.Name);
                }
            }
            else
            {
                Console.WriteLine("No Employee Found!");
            }
            

          
            Console.ReadKey();
        }
    }
}
