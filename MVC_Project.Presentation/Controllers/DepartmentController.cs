﻿using Microsoft.AspNetCore.Mvc;
using MVC_Project.BusinessLayer.Services;

namespace MVC_Project.Presentation.Controllers
{
    public class DepartmentController(IDepartmentService departmentService) : Controller
    {
        

        public IActionResult Index()
        {
            var Departments = departmentService.GetAllDepartments();
            return View();
        }
    }
}
