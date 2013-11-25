using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abon.Database.Model.Portal;
using Abon.Dto.Portal.Home;
using AutoMapper;
using System.Web.Mvc;
using Abon.Dto.Portal.OfferFolder;

namespace Abon.Dto.Portal
{
    public class PortalMapperConfiguration
    {
        public static void Configure()
        {
            Mapper.CreateMap<Category, CategoryDto>();
            Mapper.CreateMap<Image, ImageDto>();
            Mapper.CreateMap<Abon.Database.Model.Portal.Offer, OfferDto>()
                .ForMember(el => el.ProducerLogoId, m => m.MapFrom(el => el.CompanyLogoId ?? el.Company.LogoId))
                .ForMember(el=> el.ImageUrl, m => m.MapFrom(el => "File/GetImage?id="+el.LogoId));

            Mapper.CreateMap<City, SelectListItem>()
                .ForMember(el => el.Text, m => m.MapFrom(el => el.Name))
                .ForMember(el => el.Value, m => m.MapFrom(el => el.Id));


            Mapper.CreateMap<Abon.Database.Model.Portal.Offer, OfferDetailsDto>()
                .ForMember(el => el.Images, m => m.MapFrom(el => el.OfferImages))
                .ForMember(el => el.Logo, m => m.MapFrom(el => new ImagePathDto() { Id = el.LogoId }));

            Mapper.CreateMap<Abon.Database.Model.Portal.Company, OfferCompanyDto>();

            Mapper.CreateMap<Address, OfferCompanyAddressDto>();

            Mapper.CreateMap<OfferImage, ImagePathDto>();

        }
    }
}
