using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using Abon.Core;
using Abon.Database.Model.Portal.Enums;
using Abon.Dto.Portal.Home;
using Abon.Dto.Portal.Home.Filter;
using Abon.Interfaces.Services.Portal;
using Newtonsoft.Json.Serialization;

namespace Abon.Areas.Portal.Controllers
{
    public class BusinessOffersController : AbonController
    {
        private IOffersService _offersService;

        public BusinessOffersController(IOffersService offersService)
        {
            _offersService = offersService;
        }

        public ActionResult Index(OfferFilterDto filter)
        {
            OfferType = OfferType.Business;

            var model = _offersService.GetOffers(filter, OfferType);
            model.Cities = _offersService.GetOffersCities();
            model.Page = filter.Page;
            model.Take = filter.Take;
            return View("../Offers/Index",model);
        }
	}
}