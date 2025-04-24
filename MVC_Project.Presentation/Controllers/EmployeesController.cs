using Microsoft.AspNetCore.Mvc;
using MVC_Project.BusinessLayer.DataTransferObjects.EmployeeDtos;
using MVC_Project.BusinessLayer.Services.Interfaces;

namespace MVC_Project.Presentation.Controllers
{
    public class EmployeesController(IEmployeeService _employeeService, IWebHostEnvironment environment, ILogger<EmployeesController> logger) : Controller
    {
        public IActionResult Index()
        {
            var Employees = _employeeService.GetAllEmployees();
            return View(Employees);
        }

        #region Create Employee

        [HttpGet]
        public IActionResult Create() => View();

        [HttpPost]
        public IActionResult Create(CreatedEmployeeDto employeeDto) {
            if (ModelState.IsValid) // Server Side Validation
            {
                try
                {
                    int result = _employeeService.CreateEmployee(employeeDto);
                    if (result > 0)
                        return RedirectToAction(actionName: nameof(Index));
                    else
                        ModelState.AddModelError(key: string.Empty, errorMessage: "Can't Create Employee");
                }
                catch (Exception ex)
                {
                    if (environment.IsDevelopment())
                        ModelState.AddModelError(key: string.Empty, errorMessage: ex.Message);
                    else
                        logger.LogError(message: ex.Message);
                }
            }
            return View(employeeDto);
        }

        #endregion

        #region Details of Employee

        [HttpGet]
        public IActionResult Details(int? id)
        {

            if (!id.HasValue) return BadRequest();
            var employee = _employeeService.GetEmployeeById(id.Value);
            return employee is null ? NotFound() : View(employee);
        }

        #endregion

    }
}
