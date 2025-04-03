using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVC_Project.DataAccess.Models;

namespace MVC_Project.BusinessLayer.DataTransferObjects
{
    public class DepartmentDetailsDto
    {
        /* DepartmentDetailsDto(Department department) { 
            Id = department.Id;
            Name = department.Name;
            CreatedOn = DateOnly.FromDateTime((DateTime)department.CreatedOn);
        }*/
        public int Id { get; set; }
        public int CreatedBy { get; set; }
        public DateOnly? CreatedOn { get; set; }

        public int LastModifiedBy { get; set; }

        public DateOnly? LastModifiedOn { get; set; }

        public bool IsDeleted { get; set; }
        public string Name { get; set; } = null!;
        public string Code { get; set; } = null!;
        public string? Description { get; set; }
    }
}
