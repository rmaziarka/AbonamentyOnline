using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abon.Database.Model;

namespace Abon.Database.Repository
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
