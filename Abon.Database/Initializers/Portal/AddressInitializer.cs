using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abon.Database.Model.Portal;
using Abon.Database.Model.Portal.Enums;
using Abon.Database.Helpers;

namespace Abon.Database.Initializers.Portal
{
    public class AddressInitializer : IDbInitializer<Address>
    {
        public List<Address> Initialize()
        {
            return new List<Address>()
                    {
                   new Address(){ CityName = "Wrocław", 
                       LocalNumber = "20", PostCode="53-525", Street="Stysia", StreetNumber="31", Id = Guid.Parse("3f277a66-6828-4e33-aee8-829d988fc87e")}
               };


        }


    }
}
