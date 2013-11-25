using Abon.Database.Model;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Abon.Interfaces
{
    public interface IUnitOfWork
    {
        IRepository<TEntity> Repository<TEntity>() where TEntity : ModelBase;
        void Save();


        void LoadReference<T>(T entity, Expression<Func<T, object>> reference) where T : ModelBase;

        void LoadCollection<T, TCol>(T entity, Expression<Func<T, ICollection<TCol>>> reference)
            where T : ModelBase
            where TCol : ModelBase;
    }
}
