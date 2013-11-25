using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abon.Database.Mappings.Portal;
using Abon.Database.Model.Portal;
using System.Configuration;

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
        public virtual IDbSet<Image> Images { get; set; }
        public virtual IDbSet<Address> Addresses { get; set; }
        public virtual IDbSet<Company> Companies { get; set; }
        public virtual IDbSet<OfferImage> OfferImages { get; set; }

        public AbonContext()
        {
            Configuration.LazyLoadingEnabled = false;


            var connection = ConfigurationManager.ConnectionStrings["Abon"];
            Database.Connection.ConnectionString =
                connection.ConnectionString;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new UserMapping());
            modelBuilder.Configurations.Add(new UserLoginMapping());
            modelBuilder.Configurations.Add(new UserSecretMapping());
            modelBuilder.Configurations.Add(new OfferMapping());
            modelBuilder.Configurations.Add(new CategoryMapping());
            modelBuilder.Configurations.Add(new CityMapping());
            modelBuilder.Configurations.Add(new ImageMapping());
            modelBuilder.Configurations.Add(new AddressMapping());
            modelBuilder.Configurations.Add(new CompanyMapping());
            modelBuilder.Configurations.Add(new OfferImageMapping());
            base.OnModelCreating(modelBuilder);
        }
    }
}
