using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVC_Project.DataAccess.Models.Shared;

namespace MVC_Project.DataAccess.Models.DepartmentModel
{
    public class Department : BaseEntity
    {
        public string Name { get; set; } = null!;
        public string Code { get; set; } = null!;
        public string? Description { get; set; }

        public ICollection<Employee> Employees { get; set; } = new HashSet<Employee>();
    }
}
