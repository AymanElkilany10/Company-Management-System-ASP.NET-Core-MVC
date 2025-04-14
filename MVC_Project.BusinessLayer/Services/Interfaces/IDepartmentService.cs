using MVC_Project.BusinessLayer.DataTransferObjects.DepartmentDtos;

namespace MVC_Project.BusinessLayer.Services.Interfaces
{
    public interface IDepartmentService
    {
        int AddDepartment(CreatedDepartmentDto departmentDto);
        int CreateDepartment(CreatedDepartmentDto departmentDto);
        bool DeleteDepartment(int id);
        IEnumerable<DepartmentDto> GetAllDepartments();
        DepartmentDetailsDto? GetDepartmentById(int id);
        int UpdateDepartment(UpdatedDepartmentDto departmentDto);
    }
}