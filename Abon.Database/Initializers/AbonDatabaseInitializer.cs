using System.Data.Entity;
using Abon.Database.Initializers.Portal;
using System.Collections.Generic;
namespace Abon.Database.Initializers
{
    public class AbonDatabaseInitializer : DropCreateDatabaseAlways<AbonContext>
    {
        protected override void Seed(AbonContext context)
        {
            AddUniques(context);
            new CityInitializer().Initialize().ForEach(x => context.Cities.Add(x));
            new ImageInitializer().Initialize().ForEach(x => context.Images.Add(x));
            new AddressInitializer().Initialize().ForEach(x => context.Addresses.Add(x));
            new CompanyInitializer().Initialize().ForEach(x => context.Companies.Add(x));
            new CategoryInitializer().Initialize().ForEach(x => context.Categories.Add(x));
            new OfferInitializer().Initialize().ForEach(x => context.Offers.Add(x));
            new OfferImageInitializer().Initialize().ForEach(x => context.OfferImages.Add(x));

            base.Seed(context);
        }



        public void AddUniques(AbonContext context)
        {
            context.Database.ExecuteSqlCommand(@"alter table ""User"" add CONSTRAINT IX_User_UniqueName unique NONCLUSTERED (Name)");
            context.Database.ExecuteSqlCommand(@"alter table ""User"" add CONSTRAINT IX_User_UniqueEmail unique NONCLUSTERED (Email)");
            context.Database.ExecuteSqlCommand(@"alter table ""City"" add CONSTRAINT IX_City_UniqueName unique NONCLUSTERED (Name)");
        }
    }
}
