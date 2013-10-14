using Abon.Database.Model;

namespace Abon.Interfaces
{
    public interface IUnitOfWork
    {
        IRepository<TEntity> Repository<TEntity>() where TEntity : ModelBase;
        void Save();
    }
}
