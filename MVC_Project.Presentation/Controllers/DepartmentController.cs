using Microsoft.AspNetCore.Mvc;
using MVC_Project.BusinessLayer.Services;

namespace MVC_Project.Presentation.Controllers
{
    public class DepartmentController(IDepartmentService _departmentService) : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            var departments = _departmentService.GetAllDepartments();
            return View(departments);
        }
    }
}
