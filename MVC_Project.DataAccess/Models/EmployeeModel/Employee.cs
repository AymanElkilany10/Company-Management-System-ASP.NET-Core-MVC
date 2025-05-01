using MVC_Project.DataAccess.Models.Shared.Enums;
using MVC_Project.DataAccess.Models.Shared;
using MVC_Project.DataAccess.Models.DepartmentModel;

namespace MVC_Project.DataAccess.Models.EmployeeMode
{
    public class Employee : BaseEntity
    {
        public string Name { get; set; } = null!;
        public int Age { get; set; }
        public string? Address { get; set; }
        public decimal Salary { get; set; }
        public bool IsActive { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public DateTime HiringDate { get; set; }
        public Gender Gender { get; set; }
        public EmployeeType EmployeeType { get; set; }
        public int? DepartmentId { get; set; }
        public Department? Department { get; set; }
    }

}
