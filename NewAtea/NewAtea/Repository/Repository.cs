using System;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using NewAtea.Models;

namespace NewAtea.Repository
{
    public interface IRepository<T>
    {
        void Insert(T entity);
        IQueryable<T> GetAll();
    }

    public class Repository<T> : IRepository<T> where T : class
    {
        protected DbSet<T> DbSet;

        public Repository(DbContext dataContext)
        {
            DbSet = dataContext.Set<T>();
        }

        public void Insert(T entity)
        {
            DbSet.Add(entity);
        }

        public IQueryable<T> GetAll()
        {
            return DbSet;
        }
    }
}