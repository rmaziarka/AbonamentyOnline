﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abon.Database.Model.Portal;
using Abon.Dto.Portal.Home;
using AutoMapper;
using System.Web.Mvc;

namespace Abon.Dto.Portal
{
    public class PortalMapperConfiguration
    {
        public static void Configure()
        {
            Mapper.CreateMap<Category, CategoryDto>();
            Mapper.CreateMap<Image, ImageDto>();
            Mapper.CreateMap<Offer, OfferDto>()
                .ForMember(el => el.CompanyLogoId, m => m.MapFrom(el => el.CompanyLogoId ?? el.Company.LogoId))
                .ForMember(el=> el.ImageUrl, m => m.MapFrom(el => "File/GetImage?id="+el.ImageId));

            Mapper.CreateMap<City, SelectListItem>()
                .ForMember(el => el.Text, m => m.MapFrom(el => el.Name))
                .ForMember(el => el.Value, m => m.MapFrom(el => el.Id));
                
        }
    }
}
