using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeManagement.Models.EntityModels;
using EmployeeManagement.Repositories.Repository;
using EmployeeManagemetApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;

namespace EmployeeManagemetApp.Controllers
{
    public class EmployeeController:Controller
    {
        private EmployeeRepository _employeeRepository;
        private DepartmentRepository _departmentRepository;

        public EmployeeController(EmployeeRepository employeeRepository, DepartmentRepository departmentRepository)
        {
            this._employeeRepository = employeeRepository;
            this._departmentRepository = departmentRepository;
        }
        public IActionResult Create()
        {
            var model = new EmployeeCreateViewModel();
           model.Departments = _departmentRepository
                .GetAll()
                .Select(c=>new SelectListItem
                {
                    Value = c.Id.ToString(),
                    Text = c.Name
                }).ToList();
            model.Employees = _employeeRepository.GetAll();
            return View(model);
        }

        [HttpPost]
        public IActionResult Create(EmployeeCreateViewModel model)
        {

            if (ModelState.IsValid)
            {
                var employee = new Employee()
                {
                    Name = model.Name,
                    Address =  model.Address,
                    DepartmentId = model.DepartmentId,
                    Email = model.Email,
                    MobileNumber = model.MobileNumber,
                    Salary =  model.Salary,
                    RegNo = model.RegNo
                };
                bool isSaved = _employeeRepository.Add(employee);
                if (isSaved)
                {
                    ViewBag.Message = "Saved Succesful!";
                }
            }
          
           model.Departments = _departmentRepository
               .GetAll()
               .Select(c => new SelectListItem
               {
                   Value = c.Id.ToString(),
                   Text = c.Name
               }).ToList();
            model.Employees = _employeeRepository.GetAll();
            return View(model);
        }

        public IActionResult DepartmentEmployee()
        {
            var model = new DepartmentEmployeeViewModel();
            model.Departments = _departmentRepository
                .GetAll()
                .Select(c => new SelectListItem
                {
                    Value = c.Id.ToString(),
                    Text = c.Name
                }).ToList();

            return View(model);
        }


        //[Produces("application/json")]
        public IActionResult GetEmployeeBy(int departmentId)
        {
            var employees = _employeeRepository.GetByDepartmentId(departmentId);

            return Json(employees);
        }


        public IActionResult GetEmployee(int employeeId)
        {
            var employee = _employeeRepository.GetById(employeeId);
            if (employee != null)
            {
                return PartialView("_EmployeeView", employee);
            }
            else
            {
                return null;
            }
            
        }

        public IActionResult Edit(int employeeId)
        {
            var employee = _employeeRepository.GetById(employeeId);


            var model = new EmployeeCreateViewModel()
            {
                Id=employee.Id,
                Name =  employee.Name,
                Address = employee.Address,
                DepartmentId =  employee.DepartmentId,
                Email = employee.Email,
                MobileNumber = employee.MobileNumber,
                Salary =  employee.Salary
            };
            model.Departments = _departmentRepository.GetAll()
                .Select(c => new SelectListItem() {Value = c.Id.ToString(), Text = c.Name}).ToList();

            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(EmployeeCreateViewModel model)
        {

            var employee = new Employee()
            {
                Id = model.Id,
                Name = model.Name,
                Address = model.Address,
                DepartmentId = model.DepartmentId,
                Email = model.Email,
                MobileNumber = model.MobileNumber,
                Salary = model.Salary,
                RegNo = model.RegNo
            };

            bool isUpdated = _employeeRepository.Update(employee);

            model.Departments = _departmentRepository.GetAll()
                .Select(c => new SelectListItem() { Value = c.Id.ToString(), Text = c.Name }).ToList();
            if (isUpdated)
            {
                ViewBag.Message = "Updated Successful";
                return View(model);
            }

            return View(model);
        }

        public IActionResult GetEmployeeEditPartial(int employeeId)
        {
            var employee = _employeeRepository.GetById(employeeId);


            var model = new EmployeeCreateViewModel()
            {
                Id=employee.Id,
                Name = employee.Name,
                Address = employee.Address,
                DepartmentId = employee.DepartmentId,
                Email = employee.Email,
                MobileNumber = employee.MobileNumber,
                Salary = employee.Salary
            };
            model.Departments = _departmentRepository.GetAll()
                .Select(c => new SelectListItem() { Value = c.Id.ToString(), Text = c.Name }).ToList();

            return PartialView("Employee/_EmployeeEdit", model);
        }

    }
}
