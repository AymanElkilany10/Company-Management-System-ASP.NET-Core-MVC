using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVC_Project.DataAccess.Repositories;

namespace MVC_Project.BusinessLayer.Services
{
    class DepartmentService
    {
        private readonly IDepartmentRepository departmentRepository;

        public DepartmentService(IDepartmentRepository departmentRepository) {
            this.departmentRepository = departmentRepository;
        }
    }
}
