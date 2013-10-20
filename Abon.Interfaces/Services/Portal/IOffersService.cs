using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Abon.Dto;
using Abon.Dto.Portal.Home;
using Abon.Dto.Portal.Home.Filter;
using System.Web.Mvc;

namespace Abon.Interfaces.Services.Portal
{
    public interface IOffersService
    {
        UserOffersDto GetOffers(OfferFilterDto filter);
        IEnumerable<SelectListItem> GetOffersCities();
    }
}
