using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abon.Database.Model;
using Abon.Interfaces;

namespace Tests.Core
{
    public class MockUnitOfWork : IUnitOfWork
    {
        public IRepository<TEntity> Repository<TEntity>() where TEntity : ModelBase
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }
    }
}
