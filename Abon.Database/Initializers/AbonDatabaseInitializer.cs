using System.Data.Entity;
using Abon.Database.Initializers.Portal;
using System.Collections.Generic;
namespace Abon.Database.Initializers
{
    public class AbonDatabaseInitializer : DropCreateDatabaseAlways<AbonContext>
    {
        protected override void Seed(AbonContext context)
        {
            new OfferInitializer().Initialize().ForEach(x => context.Offers.Add(x));
            new CategoryInitializer().Initialize().ForEach(x => context.Categories.Add(x));

            base.Seed(context);
        }
    }
}
