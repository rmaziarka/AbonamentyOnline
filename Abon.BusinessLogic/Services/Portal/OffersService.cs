using System;
using System.CodeDom;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
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
using Abon.Dto.Portal.OfferFolder;

namespace Abon.BusinessLogic.Services.Portal
{
    public class OffersService : BaseService,IOffersService
    {
        public OffersService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        #region Members

        public UserOffersDto GetOffers(OfferFilterDto filter, OfferType offerType)
        {
            var offers = UnitOfWork.Repository<Offer>()
                .All()
                .Include(el => el.Company);

            offers = offers.Where(el => el.OfferType == offerType);

            if (!String.IsNullOrEmpty(filter.Name))
                offers = offers.Where(el => el.Name.ToLower().Contains(filter.Name.ToLower()));

            if (filter.PriceFrom.HasValue)
                offers = offers.Where(el => el.OurPrice >= filter.PriceFrom);

            if (filter.PriceTo.HasValue)
                offers = offers.Where(el => el.OurPrice <= filter.PriceTo);

            if (filter.CityId.HasValue)
                offers = offers.Where(el => el.CityId == filter.CityId.Value);


            var category = filter.CategoryId.HasValue
                ? UnitOfWork.Repository<Category>().GetById(filter.CategoryId.Value)
                : UnitOfWork.Repository<Category>().All().First(el => el.Parent == null);

            if (category.ParentId != null)
            {
                offers = FilterByCategories(offers, category.Left,category.Right);
            }

            var total = offers.Count();

            var selectedCategory = GetCategoryWithChildren(category, offers);
            SetCategoryParents(selectedCategory);

            offers = offers
                .OrderBy(el => el.Name)
                .Skip(filter.Skip)
                .Take(filter.Take);

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

        private void SetCategoryParents(CategoryDto category)
        {
            var categories = UnitOfWork.Repository<Category>()
                .All().ToList();

            SetCategoryParent(categories, category);
        }
        private void SetCategoryParent(IEnumerable<Category> categories, CategoryDto category)
        {
            if (category.ParentId == null)
                return;

            foreach (var cat in categories)
            {
                if (cat.Id == category.ParentId)
                {
                    var dto = cat.Map<CategoryDto>();
                    category.Children = null;
                    dto.Children = null;
                    category.Parent = dto;
                    SetCategoryParent(categories, dto);
                    break;
                }
            }
        }



        public IEnumerable<SelectListItem> GetOffersCities()
        {
            var cities = UnitOfWork.Repository<City>()
                .All();

            return cities.Map<IEnumerable<SelectListItem>>();

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
                .Where(el => el.OffersNumber > 0)
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


        public OfferDetailsDto GetOfferDetails(Guid id)
        {
            var offerRepo = UnitOfWork.Repository<Offer>();

            var offer = offerRepo.GetById(id);
            
            if (offer == null)
                return null;

            UnitOfWork.LoadReference(offer, o => o.Company);
            UnitOfWork.LoadReference(offer.Company, c => c.Address);
            UnitOfWork.LoadCollection(offer, o => o.OfferImages);

            var offerDto = offer.Map<OfferDetailsDto>();
            offerDto.Company.Logo = new ImagePathDto() { Id = offer.CompanyLogoId ?? offer.Company.LogoId };


            return offerDto;
        }
    }
}
