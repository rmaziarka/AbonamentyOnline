﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abon.Dto.Portal.Home
{
    public class UserOffersDto
    {
        public string Name { get; set; }

        public PagedList<OfferDto> Offers { get; set; }
 
        public CategoryDto SelectedCategory { get; set; }
    }
}
