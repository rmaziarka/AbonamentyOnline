using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abon.Database.Model.Portal;
using Abon.Dto.Portal.Home;
using AutoMapper;

namespace Abon.Dto.Portal
{
    public class PortalMapperConfiguration
    {
        public static void Configure()
        {
            Mapper.CreateMap<Category, CategoryDto>();
            Mapper.CreateMap<Offer, OfferDto>();
        }
    }
}
