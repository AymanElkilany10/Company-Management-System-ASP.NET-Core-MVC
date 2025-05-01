using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVC_Project.DataAccess.Data.Contexts;
using MVC_Project.DataAccess.Repositories.Interfaces;

namespace MVC_Project.DataAccess.Repositories.Classes
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly Lazy<IDepartmentRepository>  _departmentRepository;
        private readonly Lazy<IEmployeeRepository>  _employeeRepository;
        public UnitOfWork( ApplicationDbContext dbContext) {
            this._dbContext = dbContext;
            _departmentRepository = new Lazy<IDepartmentRepository>( ()=> new DepartmentRepository(dbContext));
             _employeeRepository = new Lazy<IEmployeeRepository> (( ()=> new EmployeeRepository(dbContext)));
        }
        public IEmployeeRepository EmployeeRepository => _employeeRepository.Value; 
        public IDepartmentRepository DepartmentRepository => _departmentRepository.Value;

        public int SaveChanges() => _dbContext.SaveChanges();

    }
}
