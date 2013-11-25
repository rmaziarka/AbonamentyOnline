using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abon.Database.Model;
using Abon.Database.Repository;
using Abon.Interfaces;
using System.Linq.Expressions;

namespace Abon.Database
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AbonContext _ctx;
        private Dictionary<Type, object> _repositories;
        private bool _disposed;

        public UnitOfWork()
        {
            _ctx = new AbonContext();
            _repositories = new Dictionary<Type, object>();
            _disposed = false;

        }

        public IRepository<TEntity> Repository<TEntity>() where TEntity : ModelBase
        {
            if (_repositories.Keys.Contains(typeof(TEntity)))
                return _repositories[typeof(TEntity)] as IRepository<TEntity>;

            var repository = new Repository<TEntity>(_ctx);
            _repositories.Add(typeof(TEntity), repository);
            return repository;

        }

        public void LoadReference<T>(T entity, Expression<Func<T, object>> reference) where T:ModelBase
        {
            _ctx.Entry(entity).Reference(reference).Load();
        }

        public void LoadCollection<T,TCol>(T entity, Expression<Func<T, ICollection<TCol>>> reference) where T : ModelBase where TCol : ModelBase
        {
            _ctx.Entry(entity).Collection(reference).Load();
        }

        public void Save()
        {
            _ctx.SaveChanges();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (this._disposed) return;

            if (disposing)
            {
                _ctx.Dispose();
            }

            this._disposed = true;
        }
    }
}
