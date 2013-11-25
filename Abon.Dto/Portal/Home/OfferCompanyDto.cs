using Abon.Dto.Portal.OfferFolder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abon.Dto.Portal.Home
{
    public class OfferCompanyDto
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public string Regon { get; set; }

        public string Phone { get; set; }

        public string Nip { get; set; }

        public string Email { get; set; }

        public bool ShowAddressInOffers { get; set; }

        public ImagePathDto Logo { get; set; }

        public OfferCompanyAddressDto Address { get; set; }

    }
}
