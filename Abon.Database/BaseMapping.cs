using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abon.Database.Model;
using System.Data.Entity.ModelConfiguration.Configuration;
using System.Data.Entity.ModelConfiguration.Configuration.Properties.Primitive;
using System.Linq.Expressions;

namespace Abon.Database
{
    public abstract class MappingBase<TEntity> : EntityTypeConfiguration<TEntity>
    where TEntity : ModelBase
    {
        protected MappingBase()
        {
            var tableName = typeof(TEntity).Name;
            ToTable(tableName);
            HasKey(e => e.Id);
        }
    }
}
