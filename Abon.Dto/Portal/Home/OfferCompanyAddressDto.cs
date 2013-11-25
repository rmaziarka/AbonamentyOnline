using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abon.Dto.Portal.Home
{
    public class OfferCompanyAddressDto
    {
        public string Street { get; set; }

        public string LocalNumber { get; set; }

        public string StreetNumber { get; set; }

        public string CityName { get; set; }

        public string PostCode { get; set; }

        public string StreetAndLocalNumber
        {
            get
            {
                if (String.IsNullOrWhiteSpace(LocalNumber))
                    return StreetNumber;

                return StreetNumber + " / " + LocalNumber;
            }
        }
    }
}
