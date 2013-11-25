using Abon.Dto.Portal.OfferFolder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abon.Dto.Portal.Home
{
    public class OfferDetailsDto
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public decimal ProducerPrice { get; set; }

        public decimal OurPrice { get; set; }


        public decimal Saving
        {
            get
            {
                return ProducerPrice - OurPrice;
            }
        }

        public DateTime CreateDate { get; set; }

        public ICollection<ImagePathDto> Images { get; set; }

        public ImagePathDto Logo { get; set; }

        public OfferCompanyDto Company { get; set; }

    }
}
