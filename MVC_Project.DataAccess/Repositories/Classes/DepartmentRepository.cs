using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVC_Project.DataAccess.Data.Contexts;
using MVC_Project.DataAccess.Models.DepartmentModel;
using MVC_Project.DataAccess.Repositories.Interfaces;

namespace MVC_Project.DataAccess.Repositories.Classes
{
    public class DepartmentRepository(ApplicationDbContext dbContext) : GenericRepository<Department>(dbContext), IDepartmentRepository
    {
        

    }
}
