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
        private IEmployeeRepository _employeeRepository;
        private readonly ApplicationDbContext _dbContext;
        private IDepartmentRepository _departmentRepository;
        public UnitOfWork(IDepartmentRepository departmentRepository, IEmployeeRepository employeeRepository, ApplicationDbContext dbContext) {
            _employeeRepository = employeeRepository;
            this._dbContext = dbContext;
            _departmentRepository = departmentRepository;
        }
        public IEmployeeRepository EmployeeRepository => _employeeRepository; 
        public IDepartmentRepository DepartmentRepository => _departmentRepository;

        public int SaveChanges() => _dbContext.SaveChanges();

    }
}
