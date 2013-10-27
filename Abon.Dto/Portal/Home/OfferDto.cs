using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abon.Dto.Portal.Home
{
    public class OfferDto
    {
        public string ImageUrl { get; set; }

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
