using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abon.Dto.Portal.Home
{
    public class OfferDto
    {
        public Guid Id { get; set; }

        public Guid? ImageId { get; set; }
        public string ImageUrl
        {
            get
            {
                return "File/GetImage?id=" + ImageId;
            }
        }

        public Guid CompanyLogoId { get; set; }
        public string CompanyLogoUrl
        {
            get
            {
                return "File/GetImage?id=" + CompanyLogoId;
            }
        }

        public string Name { get; set; }

        public decimal ProducerPrice { get; set; }

        public decimal OurPrice { get; set; }

        public decimal Saving
        {
            get
            {
                return ProducerPrice - OurPrice;
            }
        }

        public string Description { get; set; }

    }
}
