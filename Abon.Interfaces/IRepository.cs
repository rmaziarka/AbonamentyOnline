using System;
using System.Linq;
using Abon.Database.Model;

namespace Abon.Interfaces
{
    public interface IRepository<T> where T : ModelBase
    {
        void Add(T entity);
        void Delete(T entity);
        void Update(T entity);
        T GetById(Guid id);
        IQueryable<T> All();
    }
}
