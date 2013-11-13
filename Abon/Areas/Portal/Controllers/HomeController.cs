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
using Abon.Interfaces;
using Abon.Database.Model.Portal;
using Abon.Core.AutoMapper;

namespace Abon.Areas.Portal.Controllers
{
    public class HomeController : AbonController
    {
        private ICategoryService _categoryService;
        private IOffersService _offersService;

        public HomeController(ICategoryService categoryService, IOffersService offersService)
        {
            _categoryService = categoryService;
            _offersService = offersService;
        }
        //
        // GET: /Portal/Home/
        public ActionResult Index()
        {
            if (OfferType == OfferType.Individual)
                return RedirectToAction("Index", "UserOffers");

            return RedirectToAction("Index", "BusinessOffers");
        }

       

        public ActionResult Menu()
        {
            var categoryType = OfferType == OfferType.Individual ? CategoryType.Individual : CategoryType.Business;

            var model = new MenuDto() { Categories = _categoryService.GetMainCategories(categoryType) };
            return PartialView("_Partials/Menu",model);
        }

        public LoweredJsonResult GetOffers(OfferFilterDto filter)
        {
            var dto = _offersService.GetOffers(filter, OfferType);
            dto.Page = filter.Page;
            dto.Take = filter.Take;
            return LoweredJson(dto);
        }


        public ActionResult ChangeType()
        {
            if (OfferType == OfferType.Individual)
                return PartialView("_Partials/ChangeTypeBusiness");

            return PartialView("_Partials/ChangeTypeIndividual");
        }
	}
}