using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVC_Project.DataAccess.Models.DepartmentModel;
using MVC_Project.DataAccess.Models.EmployeeMode;

namespace MVC_Project.DataAccess.Repositories.Interfaces
{
    public interface IEmployeeRepository : IGenericRepository<Employee>
    {
        int Add(Employee employee);
    }
}
