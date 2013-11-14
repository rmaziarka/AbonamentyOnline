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
    public class CompanyInitializer : IDbInitializer<Company>
    {
        public List<Company> Initialize()
        {
            return new List<Company>()
                    {
                   new Company()
                    { 
                       Id = Guid.Parse("75326404-d874-400d-8723-b4eaa62b0d68"),
                       Name ="InsERT",
                       LogoId = Guid.Parse("eacac2c8-0f68-49dd-a9e7-4ac50f894966"),
                       Description = "Firma zajmująca się rozwijaniem oprogramowania ERP",
                       AddressId = Guid.Parse("3f277a66-6828-4e33-aee8-829d988fc87e"),
                       Email = "kontakt@insert.com.pl",
                       Nip = "111111111",
                       Phone = "555 666 777",
                       Regon = "123123123321"
                    }
               };


        }


    }
}
