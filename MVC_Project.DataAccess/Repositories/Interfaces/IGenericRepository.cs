using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVC_Project.DataAccess.Models.Shared;

namespace MVC_Project.DataAccess.Repositories.Interfaces
{
    public interface IGenericRepository<TEntity> where TEntity : BaseEntity
    {
        int Add(TEntity entity);
        IEnumerable<TEntity> GetAll(bool WithTracking = false);
        TEntity? GetById(int id);
        int Remove(TEntity entity);
        int Update(TEntity entity);
    }
}
