using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abon.Dto.Portal.Home.Filter
{
    public class OfferFilterDto : PagedFilter
    {
        public string Name { get; set; }

        public Guid? CityId { get; set; }

        public decimal? PriceFrom { get; set; }

        public decimal? PriceTo { get; set; }

        public Guid? CategoryId { get; set; }

    }
}
