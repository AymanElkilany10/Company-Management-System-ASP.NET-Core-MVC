using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVC_Project.BusinessLayer.DataTransferObjects.EmployeeDtos;

namespace MVC_Project.BusinessLayer.Services.Interfaces
{
    public interface IEmployeeService
    {
        IEnumerable<EmployeeDto> GetAllEmployees(bool withTracking);
        EmployeeDetailsDto GetEmployeeById(int id);
        int CreateEmployee(CreatedEmployeeDto employeeDto);
        int UpdateEmployee(UpdatedEmployeeDto employeeDto);
        bool DeleteEmployee(int id);
    }
}
