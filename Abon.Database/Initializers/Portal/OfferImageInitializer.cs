using Abon.Database.Model.Portal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abon.Database.Initializers.Portal
{
    public class OfferImageInitializer : IDbInitializer<OfferImage>
    {
        public List<OfferImage> Initialize()
        {
            return new List<OfferImage>()
            {
                new OfferImage(){Id = Guid.NewGuid(), ImageId =  Guid.Parse("6aee9e1d-59d4-4f3e-b08a-afc0cbb7f0ae"), OfferId = Guid.Parse("349b9df2-3c1c-41cd-94d2-fb9336bd0b27")},
                new OfferImage(){Id = Guid.NewGuid(), ImageId =  Guid.Parse("085579a9-a710-4bd6-aba9-97c45199fb77"), OfferId = Guid.Parse("349b9df2-3c1c-41cd-94d2-fb9336bd0b27")},


            };
        }
    }
}
