using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVC_Project.DataAccess.Data.Contexts;

namespace MVC_Project.DataAccess.Repositories
{
    class DepartmentRepository(ApplicationDbContext dbContext)
    {
        private readonly ApplicationDbContext _dbContext = dbContext;
        //public DepartmentRepository (ApplicationDbContext dbContext) { this._dbContext = dbContext;}
        public Department? GetById(int id)
        {
            var department = _dbContext.Departments.Find(id);
            return department;
        }
    }
}
