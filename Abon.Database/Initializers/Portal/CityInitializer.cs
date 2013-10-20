using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abon.Database.Model.Portal;
using Abon.Database.Model.Portal.Enums;

namespace Abon.Database.Initializers.Portal
{
    public class CityInitializer : IDbInitializer<City>
    {
        public List<City> Initialize()
        {
            return new List<City>()
                {
                    new City
                        {
                            Id= Guid.Parse("571bc239-d6ac-411a-ab0b-62ddb3f4ad4d") ,
                            Name = "Warszawa",
                        },
                    new City
                        {
                            Id= Guid.Parse("a5a82340-25a8-4c26-932a-c646ec534d62") ,
                            Name = "Wrocław",
                        },
                    new City
                        {
                            Id= Guid.Parse("8678c06c-a9e3-4ade-92da-cc810d4fa9fe") ,
                            Name = "Kraków",
                        },
                        

                };
        }
    }
}
