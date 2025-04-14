using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MVC_Project.DataAccess.Data.Contexts;
using MVC_Project.DataAccess.Models.Shared;
using MVC_Project.DataAccess.Repositories.Interfaces;

namespace MVC_Project.DataAccess.Repositories.Classes
{
    public class GenericRepository<TEntity>(ApplicationDbContext _dbContext) : IGenericRepository<TEntity> where TEntity : BaseEntity
    {
        public TEntity? GetById(int id) => _dbContext.Set<TEntity>().Find(id);

        public IEnumerable<TEntity> GetAll(bool WithTracking = false)
        {
            if (WithTracking) return _dbContext.Set<TEntity>().ToList();
            else return _dbContext.Set<TEntity>().AsNoTracking().ToList();
        }


        public int Update(TEntity entity)
        {
            _dbContext.Set<TEntity>().Update(entity);
            return _dbContext.SaveChanges();
        }

        public int Remove(TEntity entity)
        {
            _dbContext.Set<TEntity>().Remove(entity);
            return _dbContext.SaveChanges();
        }

        public int Add(TEntity entity)
        {
            _dbContext.Set<TEntity>().Add(entity);
            return _dbContext.SaveChanges();
        }
    }
}
