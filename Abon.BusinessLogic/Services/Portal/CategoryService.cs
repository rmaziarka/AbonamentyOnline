using System;
using System.CodeDom;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Abon.Core.AutoMapper;
using Abon.Database.Model.Portal;
using Abon.Dto;
using Abon.Dto.Portal.Home;
using Abon.Dto.Portal.Home.Filter;
using Abon.Interfaces;
using Abon.Interfaces.Services.Portal;
using AutoMapper.Internal;
using System.Web.Mvc;
using Abon.Database.Model.Portal.Enums;

namespace Abon.BusinessLogic.Services.Portal
{
    public class CategoryService : BaseService, ICategoryService
    {
        public CategoryService(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        public IEnumerable<CategoryDto> GetMainCategories()
        {

            var categories = UnitOfWork.Repository<Category>().All().ToList();
            var first = categories.Single(el => el.ParentId == null);

            SetChildren(categories, first);

            var mainCategories = first.Children;

            return mainCategories.Map <IEnumerable<CategoryDto>>();
        }

        private void SetChildren(List<Category> categories, Category masterCategory)
        {
            foreach (var cat in categories)
            {
                if (cat.ParentId == masterCategory.Id)
                {
                    masterCategory.Children.Add(cat);
                    SetChildren(categories, cat);
                }
            }
        }
    }
}
