﻿using System;
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

namespace Abon.BusinessLogic.Services.Portal
{
    public class OffersService : BaseService,IOffersService
    {
        public OffersService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        #region Members

        public UserOffersDto GetOffers(OfferFilterDto filter)
        {
            var offers = UnitOfWork.Repository<Offer>().All();
            if (!String.IsNullOrEmpty(filter.Name))
                offers = offers.Where(el => el.Name.ToLower().Contains(filter.Name.ToLower()));

            if (filter.PriceFrom.HasValue)
                offers = offers.Where(el => el.OurPrice >= filter.PriceFrom);

            if (filter.PriceTo.HasValue)
                offers = offers.Where(el => el.OurPrice <= filter.PriceTo);


            var category = filter.CategoryId.HasValue
                ? UnitOfWork.Repository<Category>().GetById(filter.CategoryId.Value)
                : UnitOfWork.Repository<Category>().All().First(el => el.Parent == null);

            if (category.ParentId != null)
            {
                offers = FilterByCategories(offers, category.Left,category.Right);
            }

            var total = offers.Count();

            var selectedCategory = GetCategoryWithChildren(category, offers);


            var list = offers.Map <IEnumerable<OfferDto>>();

            var pagedList = new PagedList<OfferDto>() { List = list , Total = total};
            var model = new UserOffersDto()
                        {
                            Name = filter.Name,
                            Offers = pagedList,
                            SelectedCategory = selectedCategory
                        };
            return model;
        }


        #endregion

        public CategoryDto GetCategoryWithChildren(Category category, IQueryable<Offer> filteredOffers)
        {
            var repo = UnitOfWork.Repository<Category>();

            var categories = repo
                .All()
                .Where(el => el.Left > category.Left && el.Right < category.Right)
                .Select(el => new CategoryDto()
                                    {
                                        Id = el.Id,
                                        Name = el.Name,
                                        CategoryType = el.CategoryType,
                                        OffersNumber = filteredOffers.Count(o => o.Category.Left >= el.Left && o.Category.Right <= el.Right)
                                    })
               .ToList();

            var parent = category.Map<CategoryDto>();
            parent.Children = categories.Map<IEnumerable<CategoryDto>>();

            return parent;
        }

        public IQueryable<Offer> FilterByCategories(IQueryable<Offer> offers, int categoryLeft, int categoryRight)
        {
            offers = offers
                .Where(el => el.Category.Left >= categoryLeft && el.Category.Right <= categoryRight);

            return offers;
        }

    }
}
