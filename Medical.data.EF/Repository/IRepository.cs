using Medical.data.EF.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Medical.data.EF.Repository
{
    interface IRepository<T> : IDisposable
        where T : class, IEntity
    {
        IEnumerable<T> GetList();
        T Get(long id);
        void Create(T item);
        void Update(T item);
        void Delete(long id);
        void Save();
    }
}
