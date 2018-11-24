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
           
            Department department = new Department()
            {
                Name = "Accounting"
            };

            Console.WriteLine("Adding Department...");
            bool isSaved = departmentRepository.Add(department);
            if (isSaved)
            {
                Console.WriteLine("Department Added");
            }

            var employee = new Employee()
            {
                Name = "Mr. A",
                Address = "Dhaka",
                Email = "a@mail.com",
                RegNo = "001",
                Salary = 28923,
                DepartmentId = department.Id
            };

            Console.WriteLine("Employee Adding...");
            bool isAdded = repository.Add(employee);

            if (isAdded)
            {
                Console.WriteLine("Employee is added.");
            }

            Console.ReadKey();
        }
    }
}
