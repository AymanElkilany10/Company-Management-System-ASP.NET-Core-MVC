using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVC_Project.BusinessLayer.DataTransferObjects.DepartmentDtos;
using MVC_Project.BusinessLayer.Factories;
using MVC_Project.BusinessLayer.Services.Interfaces;
using MVC_Project.DataAccess.Models;
using MVC_Project.DataAccess.Repositories.Interfaces;

namespace MVC_Project.BusinessLayer.Services.Classes
{
    public class DepartmentService(IDepartmentRepository departmentRepository) : IDepartmentService
    {
        public IEnumerable<DepartmentDto> GetAllDepartments()
        {
            var departments = departmentRepository.GetAll();

            return departments.Select(D => D.ToDepartmentDto());
        }

        public DepartmentDetailsDto? GetDepartmentById(int id)
        {
            var department = departmentRepository.GetById(id);

            return department is null ? null : department.ToDepartmentDetailsDto();
        }

        public int AddDepartment(CreatedDepartmentDto departmentDto)
        {
            var department = departmentDto.ToEntity();

            return departmentRepository.Add(department);
        }

        public int UpdateDepartment(UpdatedDepartmentDto departmentDto)
        {
            return departmentRepository.Update(departmentDto.ToEntity());
        }

        public bool DeleteDepartment(int id)
        {
            var department = departmentRepository.GetById(id);
            if (department is null) return false;
            else
            {
                int Result = departmentRepository.Remove(department);
                return Result > 0 ? true : false;

            }
        }

        public int CreateDepartment(CreatedDepartmentDto departmentDto)
        {
            var department = departmentDto.ToEntity();
            return departmentRepository.Add(department);
        }
    }
}
