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

        public HomeController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        //
        // GET: /Portal/Home/
        public ActionResult Index()
        {
            return View();
        }

        
        public ActionResult Test()
        {
            return View();
        }


        public ActionResult Menu()
        {
            var model = new MenuDto() { Categories = _categoryService.GetMainCategories() };
            return PartialView("_Partials/Menu",model);
        }

     
	}
}