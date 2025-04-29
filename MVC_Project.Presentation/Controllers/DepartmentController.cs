﻿using Microsoft.AspNetCore.Mvc;
using MVC_Project.BusinessLayer.DataTransferObjects;
using MVC_Project.BusinessLayer.DataTransferObjects.DepartmentDtos;
using MVC_Project.BusinessLayer.Services.Interfaces;
using MVC_Project.Presentation.ViewModels.DepartmentViewModel;

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
        //[ValidateAntiForgeryToken]
        public IActionResult Create(DepartmentViewModel departmentViewModel)
        {
            if (ModelState.IsValid) // Server Side Validation
            {
                try
                {
                    var departmentDto = new CreatedDepartmentDto()
                    {
                        Name = departmentViewModel.Name,
                        Code = departmentViewModel.Code,
                        DateOfCreation = departmentViewModel.DateOfCreation,
                        Description = departmentViewModel.Description
                    };
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
            
            return View(departmentViewModel);
        }


        #endregion

        #region Department Details
        [HttpGet]
        public IActionResult Details(int? id) {
            if (!id.HasValue) return BadRequest();
            var department = _departmentService.GetDepartmentById(id.Value);
            if(department is null) return NotFound();
            return View(department);
        }
        #endregion

        #region Edit Department
        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (!id.HasValue) return BadRequest();
            var department = _departmentService.GetDepartmentById(id.Value);
            if (department is null) return NotFound();
            var departmentViewModel = new DepartmentViewModel()
            {
                Code = department.Code,
                Name = department.Name,
                Description = department.Description,
                DateOfCreation = (DateOnly)department.CreatedOn
            };
            return View(departmentViewModel);
        }

        [HttpPost]
        public IActionResult Edit([FromRoute]int id, DepartmentViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                try{
                    var UpdatedDepartment = new UpdatedDepartmentDto()
                    {
                        Id = id,
                        Code = viewModel.Code,
                        Name = viewModel.Name,
                        Description = viewModel.Description,
                        DateOfCreation = (DateOnly)viewModel.DateOfCreation
                    };

                    int Result = _departmentService.UpdateDepartment(UpdatedDepartment);
                    if (Result > 0) return RedirectToAction(nameof(Index));
                    else
                    {
                        ModelState.AddModelError(string.Empty, "Department is not Updated");
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
                        return View("Error View", ex);
                    }
                }

            }
            
            return View(viewModel);
            
        }

        #endregion

        #region Delete Department

        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if (!id.HasValue) return BadRequest();
            var department = _departmentService.GetDepartmentById(id.Value);
            if (department is null) return NotFound();
            return View(department);
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            if (id == 0) return BadRequest();

            try
            {
                bool Deleted = _departmentService.DeleteDepartment(id);
                if (Deleted) return RedirectToAction(nameof(Index));
                
                else
                {
                    ModelState.AddModelError(string.Empty, "Department Is Not Deleted");
                    return RedirectToAction(nameof(Delete), new { id });
                }
            }
            catch (Exception ex)
            {
                if (_environment.IsDevelopment())
                {
                    ModelState.AddModelError(string.Empty, ex.Message);
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    _logger.LogError(ex.Message);
                    return View("ErrorView", ex);
                }
                
            }
        }


        #endregion
    }
}
