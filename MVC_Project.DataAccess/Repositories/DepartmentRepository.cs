using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVC_Project.DataAccess.Data.Contexts;
using MVC_Project.DataAccess.Models.DepartmentModel;

namespace MVC_Project.DataAccess.Repositories
{
    public class DepartmentRepository(ApplicationDbContext dbContext) : IDepartmentRepository
    {
        private readonly ApplicationDbContext _dbContext = dbContext;
        //public DepartmentRepository (ApplicationDbContext dbContext) { this._dbContext = dbContext;}

        public IEnumerable<Department> GetAll(bool WithTracking = false)
        {
            if (WithTracking) return _dbContext.Departments.ToList();
            else return _dbContext.Departments.AsNoTracking().ToList();
        }
        public Department? GetById(int id) => _dbContext.Departments.Find(id);

        public int Update(Department department)
        {
            _dbContext.Departments.Update(department);
            return _dbContext.SaveChanges();
        }

        public int Remove(Department department)
        {
            _dbContext.Departments.Remove(department);
            return _dbContext.SaveChanges();
        }

        public int Add(Department department)
        {
            _dbContext.Departments.Add(department);
            return _dbContext.SaveChanges();
        }


    }
}
