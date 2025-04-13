using Microsoft.AspNetCore.Mvc;
using MVC_Project.BusinessLayer.DataTransferObjects;
using MVC_Project.BusinessLayer.Services;

namespace MVC_Project.Presentation.Controllers
{
    public class DepartmentController(IDepartmentService _departmentService,
        ILogger<DepartmentController> _logger,
        IWebHostEnvironment _environment) : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            var departments = _departmentService.GetAllDepartments();
            return View(departments);
        }

        #region Create Department
        [HttpGet]
        public IActionResult Create() => View();

        [HttpPost]
        public IActionResult Create(CreatedDepartmentDto departmentDto)
        {
            if (ModelState.IsValid) // Server Side Validation
            {
                try
                {
                    int result = _departmentService.CreateDepartment(departmentDto);
                    if (result > 0)
                    {
                        return RedirectToAction(nameof(Index));
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, "Department Can't Be Created");
                    }
                }
                catch (Exception ex)
                {
                    if (_environment.IsDevelopment())
                    {
                        // 1. Development => Log Error In Console and Return Same View With Error Message
                        ModelState.AddModelError(string.Empty, ex.Message);
                    }
                    else
                    {
                        // 2. Deployment => Log Error In File | Table in Database And Return Error View
                        _logger.LogError(ex.Message);
                    }
                }
            }
            
            return View(departmentDto);
        }


        #endregion
    }
}
