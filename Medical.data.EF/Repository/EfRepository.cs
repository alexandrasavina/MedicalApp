using Medical.data.EF;
using Medical.data.EF.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Medical.data.EF.Repository
{
    public class EfRepository<T> : IRepository<T>  where T : class, IEntity
    {
        private DbSet<T> _dbSet;

        public EfRepository(DbSet<T> dbSet)
        {
            _dbSet = dbSet;
            
        }
        public void Create(T item)
        {
            _dbSet.Add(item);
            
        }

        public void Delete(long id)
        {
           
        }

        public void Dispose()
        {
            
        }

        public T Get(long id)
        {
            return _dbSet.Find(id);
        }

        public IEnumerable<T> GetList()
        {
            return _dbSet;
        }

        public void Save()
        {
            
        }

        public void Update(T item)
        {
             
        }
    }
}
