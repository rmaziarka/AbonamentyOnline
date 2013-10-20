using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Abon.Dto.Portal.Home.Filter
{
    public class OfferFilterDto : PagedFilter
    {
        public string Name { get; set; }

        [Display(Name = "Miasto")]
        public Guid? CityId { get; set; }

        [Display(Name = "Cena od")]
        public decimal? PriceFrom { get; set; }

        [Display(Name = "Cena do")]
        public decimal? PriceTo { get; set; }

        public Guid? CategoryId { get; set; }
    }
}
