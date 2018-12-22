﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeManagement.Models.EntityModels;
using EmployeeManagement.Repositories.Contracts;
using EmployeeManagement.Repositories.Repository;
using EmployeeManagemetApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagemetApp.Controllers
{
    public class DepartmentController : Controller
    {
        private IDepartmentRepository _departmentRepository;

        public DepartmentController(IDepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create()
        {
            ViewBag.RegNo = "ABCD";
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