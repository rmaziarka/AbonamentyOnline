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
    public class HomeController : AbonController
    {
        private IOffersService _offersService;

        public HomeController(IOffersService offersService)
        {
            _offersService = offersService;
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
            var model = new MenuDto() { Categories = GetMainCategories() };
            return PartialView("_Partials/Menu",model);
        }

        private IEnumerable<CategoryDto> GetMainCategories()
        {
            var first = new CategoryDto()
            {
                CategoryType = CategoryType.Both,
                Children = new List<CategoryDto>(),
                Id = Guid.NewGuid(),
                Name = "Pierwsza",
                Parent = null
            };
            var second = new CategoryDto()
            {
                CategoryType = CategoryType.Both,
                Children = new List<CategoryDto>(),
                Id = Guid.NewGuid(),
                Name = "Druga",
                Parent = null
            };

            var third = new CategoryDto()
            {
                CategoryType = CategoryType.Both,
                Children = new List<CategoryDto>(),
                Id = Guid.NewGuid(),
                Name = "Trzecia",
                Parent = null
            };
            var categories = new List<CategoryDto> {first, second, third};
            AssingSecondLevelCategories(first);
            AssingSecondLevelCategories(second);
            AssingSecondLevelCategories(third);

            return categories;
        }

        public void AssingSecondLevelCategories(CategoryDto parent)
        {

            var first = new CategoryDto()
            {
                CategoryType = CategoryType.Individual,
                Id = Guid.NewGuid(),
                Name = parent.Name + " - Pierwsza",
                Parent = parent
            };
            var second = new CategoryDto()
            {
                CategoryType = CategoryType.Individual,
                Id = Guid.NewGuid(),
                Name = parent.Name + " - Druga",
                Parent = parent
            };

            var third = new CategoryDto()
            {
                CategoryType = CategoryType.Individual,
                Id = Guid.NewGuid(),
                Name = parent.Name + " - Trzecia",
                Parent = parent
            };
            parent.Children = new List<CategoryDto> { first, second, third };

        } 

	}
}