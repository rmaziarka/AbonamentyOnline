using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abon.Database.Mappings.Portal;
using Abon.Database.Model.Portal;

namespace Abon.Database
{
    public class AbonContext : DbContext
    {
        public virtual IDbSet<User> Users { get; set; }
        public virtual IDbSet<UserLogin> UserLogins { get; set; }
        public virtual IDbSet<UserSecret> UserSecrets { get; set; }
        public virtual IDbSet<Offer> Offers { get; set; }
        public virtual IDbSet<Category> Categories { get; set; }
        public virtual IDbSet<City> Cities { get; set; }

        public AbonContext()
        {
            Database.Connection.ConnectionString =
                @"Data Source=SIARAPC\SQLEXPRESS;Initial Catalog=Abon;Integrated Security=True;";


        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new UserMapping());
            modelBuilder.Configurations.Add(new UserLoginMapping());
            modelBuilder.Configurations.Add(new UserSecretMapping());
            modelBuilder.Configurations.Add(new OfferMapping());
            modelBuilder.Configurations.Add(new CategoryMapping());
            modelBuilder.Configurations.Add(new CityMapping());
            base.OnModelCreating(modelBuilder);
        }
    }
}
