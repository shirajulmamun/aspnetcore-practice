using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeManagement.Models.EntityModels;
using EmployeeManagement.Repositories.Repository;
using EmployeeManagemetApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagemetApp.Controllers
{
    public class DepartmentController : Controller
    {
        private DepartmentRepository _departmentRepository;

        public DepartmentController(DepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(DepartmentCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                var department = new Department()
                {
                    Name=model.Name
                };
                bool isSaved = _departmentRepository.Add(department);

                if (isSaved)
                {
                    ViewBag.Message = "Saved Successfully!";
                }

            }
            ModelState.Clear();
            return View();
        }
    }
}