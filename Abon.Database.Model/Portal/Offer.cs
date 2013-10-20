using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abon.Database.Model.Portal
{
    public class Offer:ModelBase
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public string CompanyLogoUrl { get; set; }

        public decimal ProducerPrice { get; set; }

        public decimal OurPrice { get; set; }

        public string OfferImageUrl { get; set; }

        public DateTime CreateDate { get; set; }

        public Guid CategoryId { get; set; }

        public Category Category { get; set; }

        public Guid? CityId { get; set; }

        public City City { get; set; }
    }
}
