using Abon.BusinessLogic.Services.Portal;
using Abon.Interfaces.Services.Portal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Abon.Areas.Portal.Controllers
{
    public class OffersController : Controller
    {
        private IOffersService _offersService;

        public OffersController(IOffersService offersService)
        {
            _offersService = offersService;
        }
        //
        // GET: /Portal/Offers/
        public ActionResult Details(Guid id)
        {
            var offer = _offersService.GetOfferDetails(id);

            if (offer == null)
                throw new ArgumentNullException();

            return View(offer);
        }
	}
}