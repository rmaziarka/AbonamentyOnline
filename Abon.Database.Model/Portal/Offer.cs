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

        public DateTime CreateDate { get; set; }

        public OfferType OfferType { get; set; }

        public Guid CompanyId { get; set; }
        public virtual Company Company { get; set; }

        public Guid CategoryId { get; set; }
        public virtual Category Category { get; set; }

        public Guid? CityId { get; set; }
        public virtual City City { get; set; }

        public Guid? ImageId { get; set; }
        public virtual Image Image { get; set; }

        public Guid? CompanyLogoId { get; set; }
        public virtual Image CompanyLogo { get; set; }
    }
}
