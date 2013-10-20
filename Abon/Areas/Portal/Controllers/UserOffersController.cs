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

        public ActionResult Index(Guid? categoryId, string name = null)
        {
            var model = _offersService.GetOffers(new OfferFilterDto() {CategoryId = categoryId, Name = name});

            model.Cities = _offersService.GetOffersCities();

            return View(model);
        }

        public LoweredJsonResult Get(OfferFilterDto filter)
                            {
            var dto = _offersService.GetOffers(filter);
            return LoweredJson(dto);
        }


	}
}