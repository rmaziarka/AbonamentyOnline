using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abon.Database.Model.Portal.Enums;

namespace Abon.Database.Model.Portal
{
    public class Offer : ModelBase
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public decimal ProducerPrice { get; set; }

        public decimal OurPrice { get; set; }

        public byte OfferImageUrl { get; set; }

        public DateTime CreateDate { get; set; }

        public Guid CategoryId { get; set; }

        public Category Category { get; set; }

        public Guid? CityId { get; set; }

        public City City { get; set; }

        public OfferType OfferType { get; set; }

        public Guid? ImageId { get; set; }

        public Image Image { get; set; }
    }
}
