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
    public class UserOffersController : AbonController
    {
        private IOffersService _offersService;

        public UserOffersController(IOffersService offersService)
        {
            _offersService = offersService;
        }


        public ActionResult Test()
        {
            return View();
        }

        public ActionResult Index(OfferFilterDto filter)
        {
            var model = _offersService.GetOffers(filter);
            model.Cities = _offersService.GetOffersCities();
            model.Page = filter.Page;
            model.Take = filter.Take;
            return View(model);
        }

        public LoweredJsonResult Get(OfferFilterDto filter)
                            {
                                var dto = _offersService.GetOffers(filter);
                                dto.Page = filter.Page;
                                dto.Take = filter.Take;
            return LoweredJson(dto);
        }


	}
}