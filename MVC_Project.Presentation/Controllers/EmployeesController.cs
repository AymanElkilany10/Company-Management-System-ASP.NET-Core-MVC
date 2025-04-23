using Microsoft.AspNetCore.Mvc;
using MVC_Project.BusinessLayer.Services.Interfaces;

namespace MVC_Project.Presentation.Controllers
{
    public class EmployeesController(IEmployeeService _employeeService): Controller
    {
        public IActionResult Index()
        {
            var Employees = _employeeService.GetAllEmployees();
            return View(Employees);
        }
    }
}
